---
title: Deklaráció
type: docs
weight: 60
url: /hu/java/declaration/
keywords:
- deklaráció
- komponensek
- Full Trust engedély
- regisztrációs beállítások
- rendszerfájlok
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Java megbízhatósági követelményeit, engedélyeit és hostingkorlátozásait, hogy biztonságosan telepíthessen olyan alkalmazásokat, amelyek PPT, PPTX és ODP fájlokat dolgoznak fel a szervereken."
---
{{% alert color="primary" %}} 

Az összes Aspose Java komponens Full Trust jogosultságkészletet igényel. Ennek oka, hogy az Aspose Java komponenseknek hozzá kell férniük a regisztrációs beállításokhoz, a virtuális könyvtáron kívüli rendszerfájlokhoz bizonyos műveletekhez, például betűtípusok feldolgozásához stb. Emellett az Aspose Java komponensek a Java alaprendszer osztályaira épülnek, amelyek számos esetben szintén Full Trust jogosultságkészletet igényelnek. 

{{% /alert %}} 

Az internetszolgáltatók, amelyek több, különböző vállalatok alkalmazásait üzemeltetik, általában Medium Trust biztonsági szintet alkalmaznak: 

- OleDbPermission nem érhető el. Ez azt jelenti, hogy nem használhatja az ADO.NET kezelt OLE DB adatforrást adatbázisok elérésére.
- EventLogPermission nem érhető el. Ez azt jelenti, hogy nem férhet hozzá a Windows eseménynaplóhoz.
- ReflectionPermission nem érhető el. Ez azt jelenti, hogy nem használhat reflexiót.
- RegistryPermission nem érhető el. Ez azt jelenti, hogy nem férhet hozzá a regisztrációs adatbázishoz.
- WebPermission korlátozott. Ez azt jelenti, hogy az alkalmazása csak olyan címekkel vagy címek tartományával kommunikálhat, amelyet a <trust> elemben határoz meg.
- FileIOPermission korlátozott. Ez azt jelenti, hogy csak az alkalmazása virtuális könyvtárhierarchiájában lévő fájlokhoz férhet hozzá.

{{% alert color="primary" %}} 

A fentiekben felsorolt okok miatt az Aspose Java komponensek nem használhatók olyan szervereken, ahol a jogosultságkészlet nem Full Trust. 

{{% /alert %}}