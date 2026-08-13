---
title: Nyilatkozat
type: docs
weight: 110
url: /hu/net/declaration/
keywords:
- nyilatkozat
- komponensek
- Full Trust engedély
- regisztrációs beállítások
- rendszerfájlok
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for .NET megbízhatósági követelményeit, engedélyeit és a hosztolási korlátozásokat, hogy biztonságosan telepíthessen olyan alkalmazásokat, amelyek PPT, PPTX és ODP fájlokat dolgoznak fel a szervereken."
---
{{% alert color="info" %}} 

Minden Aspose .NET komponensnek szüksége van a Full Trust engedélykészletre, mivel néha hozzá kell férnie a regisztrációs beállításokhoz, rendszerfájlokhoz, illetve a virtuális könyvtáron kívül tárolt fájlokhoz bizonyos műveletek (például betűkészletek feldolgozása) során. Ráadásul az Aspose .NET komponensek a .NET alaprendszer osztályain alapulnak, amelyek sok esetben a Full Trust engedélykészletet igénylik. 

{{% /alert %}} 

Az internetszolgáltatók, amelyek több, különböző cég alkalmazásait üzemeltetik, általában a Medium Trust biztonsági szintet kényszerítik ki. .NET 2.0 esetén ez a biztonsági szint a következő korlátozásokat alkalmazza: 

- OleDbPermission nem érhető el. Ez azt jelenti, hogy nem használhatja az ADO.NET kezelt OLE DB adatprovidert adatbázisok eléréséhez.
- EventLogPermission nem érhető el. Ez azt jelenti, hogy nem férhet hozzá a Windows eseménynaplóhoz.
- ReflectionPermission nem érhető el. Ez azt jelenti, hogy nem használhat reflexiót.
- RegistryPermission nem érhető el. Ez azt jelenti, hogy nem férhet hozzá a regisztrációhoz.
- WebPermission korlátozott. Ez azt jelenti, hogy alkalmazása csak egy olyan címhez vagy címcsoporthoz tud kommunikálni, amelyet a <trust> elemben definiált.
- FileIOPermission korlátozott. Ez azt jelenti, hogy csak az alkalmazás virtuális könyvtárhierarchiájában lévő fájlokhoz férhet hozzá.

{{% alert color="info" %}} 

Az előbb említett okok miatt az Aspose .NET komponenseket csak olyan szervereken lehet használni, amelyek biztosítják a Full Trust engedélykészletet. 

{{% /alert %}}