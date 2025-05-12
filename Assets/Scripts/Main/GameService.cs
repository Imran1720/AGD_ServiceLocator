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
    public class GameService : MonoBehaviour
    {
        // Services:
        private EventService EventService;
        private MapService MapService;
        private WaveService WaveService;
        private SoundService SoundService;
        private PlayerService PlayerService;

        [SerializeField] private WaveSpawner waveSpawner;
        public WaveSpawner WaveSpawner => waveSpawner;

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;

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
            WaveService.Init(EventService, MapService, SoundService, UIService, PlayerService, waveSpawner);
            MapService.Init(EventService);
            UIService.Init(EventService, WaveService, PlayerService);
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
            playerService.Update();
        }
    }
}