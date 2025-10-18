# SOD Basic Mod

> **⚠️ Warning**
> All .dll files in lib/ are from GameVersion 1.0.9. Use the newer one if needed.

A simple mod template for Shape of Dreams that demonstrates basic Harmony patching and mod development.

Here's a walkthorough for this repo (Korean): [link](https://www.notion.so/mind-map/Hello-World-290be6a9f7ab80a0a912c8e4e52a0496)

## Features

- **Harmony Patching**: Example of patching `ZoneManager.OnStart()` method
- **Server-side Logic**: Demonstrates server-only execution with proper checks
- **Error proof**: Proper Harmony lifecycle management

## Getting Started

### Prerequisites

- Shape of Dreams (Steam)
- .NET Standard 2.1 SDK

### Installation

1. Clone this repository
2. Build the project: `dotnet build -c release`
3. Copy the generated files to your game's Mods folder
4. Enable the mod in-game

### Usage

This mod automatically spawns a sneeze skill trigger when starting a new game (server-side only).

# Disclaimer

This repo is a fan-made mod for the game Shape of Dreams and is not affiliated with the developers.