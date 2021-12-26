using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator menuAnimation;
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UsernameMenu;


    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField HostGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
    }

    public void MultiplayerButton()
    {
        OnConnectedToMaster();
        menuAnimation.SetTrigger("OnlineMenu");
    }

    public void MultiplayerBackButton()
    {
        menuAnimation.SetTrigger("StartMenu");
    }

    public void OnHostBackButton()
    {
        menuAnimation.SetTrigger("OnlineMenu");
    }

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Current room we are in:" + PhotonNetwork.room);
        Debug.Log("Connected");

    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(HostGameInput.text, new RoomOptions() { maxPlayers = 2 }, null);
        
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.room.Name);
        PhotonNetwork.LoadLevel("OnlineGame");
    }

    public void ChangeUsername()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUsername()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }

}
