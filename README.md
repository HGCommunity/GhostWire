# GhostWire - Steam & Photon Redirector

GhostWire is a **BepInEx** plugin that redirects Steamworks AppIDs and Photon multiplayer connections, allowing you to bypass official authentication and connect to custom servers.

## Features
- **Steam AppID Spoofing** – Forces the game to use AppID **480** (Spacewar) for Steamworks.
- **Photon Redirect** – Replaces the game's default Photon IDs with custom ones.
- **Authentication Bypass** – Disables custom authentication to avoid verification issues.

## Installation
1. Install [BepInEx](https://github.com/BepInEx/BepInEx/releases) for your game.
2. Download **GhostWire.dll** and place it in `BepInEx/plugins/`.
3. Make a [PhotonEngine account](https://id.photonengine.com/) and setup a PUN and a Voice project, note down the project IDs.
4. Configure your Photon AppIDs in the plugin's config file (`BepInEx/config/dev.hgcommunity.ghostwire.cfg`).
5. Launch the game and enjoy your custom multiplayer setup!
6. (Optionally) If you want to play with friends, send them this plugin and your config file (`BepInEx/config/dev.hgcommunity.ghostwire.cfg`).

## Configuration
After running the game once, a config file will be generated at:
```
BepInEx/config/dev.hgcommunity.ghostwire.cfg
```
Edit the following values to match your Photon project:
```
[GhostWire]
realtimeAppId = "your-realtime-app-id"
voiceAppId = "your-voice-app-id"
enabled = true
```

## Notes
- This plugin **does not provide servers**; you need to set up your own Photon project.
- Some games may require modifying `resources.assets` for full compatibility.

## Disclaimer
This tool is for **educational and research purposes only**. Use it responsibly!


