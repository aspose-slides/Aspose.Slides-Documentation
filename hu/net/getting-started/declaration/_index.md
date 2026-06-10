---
title: Kijelentés
type: docs
weight: 110
url: /hu/net/declaration/
keywords:
- kijelentés
- komponensek
- Full Trust jogosultság
- regisztrációs beállítások
- rendszerfájlok
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for .NET bizalmi követelményeit, jogosultságait és üzemeltetési korlátozásait, hogy biztonságosan telepíthessen olyan alkalmazásokat, amelyek PPT, PPTX és ODP fájlokat dolgoznak fel a szervereken."
---
{{% alert color="primary" %}} 

Az összes Aspose .NET komponens a Full Trust jogosultságkészletet igényli, mert bizonyos műveletekhez (például betűtípusok beolvasása) hozzá kell férnie a regisztrációs beállításokhoz, a rendszerfájlokhoz, valamint más helyeken (a virtuális könyvtáron kívül) tárolt fájlokhoz. Továbbá az Aspose .NET komponensek a .NET alap osztályain alapulnak, amelyek sok esetben a Full Trust jogosultságkészletet követelik. 

{{% /alert %}} 

Az internetes szolgáltatók, amelyek különböző vállalatok több alkalmazását hosztolják, általában a Medium Trust biztonsági szintet alkalmazzák. Egy .NET 2.0 esetben ez a biztonsági szint a következő korlátozásokat vonja maga után: 

- OleDbPermission nem elérhető. Ez azt jelenti, hogy nem használhatja az ADO.NET kezelt OLE DB adatforrást az adatbázisok eléréséhez.  
- EventLogPermission nem elérhető. Ez azt jelenti, hogy nem férhet hozzá a Windows eseménynaplóhoz.  
- ReflectionPermission nem elérhető. Ez azt jelenti, hogy nem használhat reflexiót.  
- RegistryPermission nem elérhető. Ez azt jelenti, hogy nem férhet hozzá a regiszterhez.  
- WebPermission korlátozott. Ez azt jelenti, hogy az alkalmazás csak az <trust> elemben definiált cím vagy címek tartományával kommunikálhat.  
- FileIOPermission korlátozott. Ez azt jelenti, hogy csak az alkalmazás virtuális könyvtárhierarchiájában lévő fájlokhoz férhet hozzá.  

{{% alert color="primary" %}} 

A fentiek miatt az Aspose .NET komponenseket csak olyan szervereken lehet használni, amelyek biztosítják a Full Trust jogosultságkészletet. 

{{% /alert %}}