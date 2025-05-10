using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System;
using UnityEngine;

namespace ServiceLocator.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        // Services:
        public EventService EventService { get; private set; }
        public MapService MapService { get; private set; }
        public WaveService WaveService { get; private set; }
        public SoundService SoundService { get; private set; }
        public PlayerService PlayerService { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;

        [SerializeField] private MapButton mapButton;
        public MapButton MapButton => mapButton;

        // Scriptable Objects:
        [SerializeField] private MapScriptableObject mapScriptableObject;
        [SerializeField] private WaveScriptableObject waveScriptableObject;
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        // Scene Referneces:
        [SerializeField] private AudioSource SFXSource;
        [SerializeField] private AudioSource BGSource;

        private void Start()
        {
            CreateService();
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            PlayerService.Init(UIService, MapService, WaveService, SoundService);
            WaveService.Init(EventService, MapService, SoundService, UIService, PlayerService);
            MapService.Init(EventService);
            UIService.Init(EventService, WaveService, PlayerService);
            MapButton.Init(EventService);
        }

        private void CreateService()
        {
            EventService = new EventService();
            MapService = new MapService(mapScriptableObject);
            WaveService = new WaveService(waveScriptableObject);
            SoundService = new SoundService(soundScriptableObject, SFXSource, BGSource);
            PlayerService = new PlayerService(playerScriptableObject);
        }

        private void Update()
        {
            PlayerService.Update();
        }
    }
}