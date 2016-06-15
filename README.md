# GladNet.PhotonServer (GladNet2)

GladNet2 is Message based networking API library for Unity3D/.Net developers. Defines an API from which other lowerlevel network libraries can be adapted to. This particular repo are the adapters and implementation of the GladNet2 API for PhotonServer SDK.

Come chat: [![https://gitter.im/HelloKitty/GladNet2.0y](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/HelloKitty/GladNet2.0?utm_source=share-link&utm_medium=link&utm_campaign=share-link)

## Implementations

GladNet2 API: https://github.com/HelloKitty/GladNet2.0

Lidgren's: https://github.com/HelloKitty/GladNet2-Lidgren

Photon Server's: https://github.com/HelloKitty/GladNet.PhotonServer

## Setup

To use this project you'll first need a couple of things:
  - Visual Studio 2015
  - Add Nuget Feed https://www.myget.org/F/hellokitty/api/v2 in VS (Options -> NuGet -> Package Sources)

## Builds

Available on a Nuget Feed: https://www.myget.org/F/hellokitty/api/v2 [![hellokitty MyGet Build Status](https://www.myget.org/BuildSource/Badge/hellokitty?identifier=2de8fa51-b575-4fb5-ab5a-5854013c0ac0)](https://www.myget.org/gallery/hellokitty)

##Tests

#### Linux/Mono - Unit Tests
||Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|:--:|
|**master**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/GladNet.PhotonServer.svg?branch=master)](https://travis-ci.org/HelloKitty/GladNet.PhotonServer) |
|**dev**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/GladNet.PhotonServer.svg?branch=dev)](https://travis-ci.org/HelloKitty/GladNet.PhotonServer)|

#### Windows - Unit Tests

(Done locally)

##Licensing

This project is licensed under the MIT license.
