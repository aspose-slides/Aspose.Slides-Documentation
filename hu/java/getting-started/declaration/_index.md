---
title: Nyilatkozat
type: docs
weight: 60
url: /hu/java/declaration/
keywords:
- nyilatkozat
- összetevők
- Full Trust jogosultság
- regisztrációs beállítások
- rendszerfájlok
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Java bizalmi követelményeket, jogosultságokat és üzemeltetési korlátozásokat, hogy biztonságosan telepíthessen PPT, PPTX és ODP fájlokat feldolgozó alkalmazásokat a szervereken."
---
{{% alert color="info" %}} 

Minden Aspose Java komponens a Full Trust jogosultságkészletet igényli. Ennek oka, hogy az Aspose Java komponenseknek hozzá kell férniük a regisztrációs beállításokhoz, a virtuális könyvtáron kívüli rendszerfájlokhoz bizonyos műveletekhez, például betűkészletek feldolgozásához stb. Továbbá, az Aspose Java komponensek a Java alaprendszer osztályain alapulnak, amelyek sok esetben szintén a Full Trust jogosultságkészletet igénylik. 

{{% /alert %}} 

Az internetszolgáltatók, amelyek több, különböző cégek alkalmazásait is kiszolgálják, általában a Medium Trust biztonsági szintet alkalmazzák: 

- OleDbPermission nem érhető el. Ez azt jelenti, hogy nem használhatja az ADO.NET kezelett OLE DB adatbirtokost adatbázisok eléréséhez.  
- EventLogPermission nem érhető el. Ez azt jelenti, hogy nem férhet hozzá a Windows eseménynaplóhoz.  
- ReflectionPermission nem érhető el. Ez azt jelenti, hogy nem használhat reflexiót.  
- RegistryPermission nem érhető el. Ez azt jelenti, hogy nem férhet hozzá a regisztrációs adatbázishoz.  
- WebPermission korlátozott. Ez azt jelenti, hogy az alkalmazása csak azokkal a címekkel vagy címcsoportokkal kommunikálhat, amelyeket a <trust> elemben definiál.  
- FileIOPermission korlátozott. Ez azt jelenti, hogy csak az alkalmazása virtuális könyvtárhierarchiájában lévő fájlokhoz férhet hozzá.  

{{% alert color="info" %}} 

A fent felsorolt okok miatt az Aspose Java komponensek nem használhatók olyan szervereken, amelyek nem a Full Trust jogosultságkészletet biztosítják. 

{{% /alert %}}