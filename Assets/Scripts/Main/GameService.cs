using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    
    [SerializeField]private PlayerScriptableObject playerScriptableObject;
    [SerializeField]private SoundScriptableObject soundScriptableObject;
    [SerializeField]private AudioSource audioEffects;
    [SerializeField]private AudioSource backgroundMusic;
    [SerializeField]private WaveScriptableObject waveScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;


    
    public UIService uIService;
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public WaveService waveService { get; private set; }
    public MapService mapService { get; private set; }

    public EventService eventService { get; private set; }

    private void Start()
    {
        eventService = new EventService();
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        waveService = new WaveService(waveScriptableObject);
        mapService = new MapService(mapScriptableObject);
        
        uIService.SubscribeToEvents();

    }

    private void Update()
    {
        playerService.Update();
    }
}
