---
title: Deklaráció
type: docs
weight: 60
url: /hu/php-java/declaration/
keywords:
- deklaráció
- komponensek
- Full Trust engedély
- rendszerleíró beállítások
- rendszerfájlok
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for PHP bizalmi követelményeit, jogosultságait és tárhelykorlátait, hogy biztonságosan telepíthessen alkalmazásokat, amelyek PPT, PPTX és ODP fájlokat dolgoznak fel a szervereken."
---
{{% alert color="primary" %}} 

Minden Aspose Java komponensnek Full Trust jogosultságkészletre van szüksége. Ennek oka, hogy az Aspose Java komponenseknek hozzá kell férniük a rendszerleíró adatbázis beállításaihoz, a virtuális könyvtáron kívüli rendszerfájlokhoz bizonyos műveletekhez, például betűkészletek feldolgozásához stb. Továbbá az Aspose Java komponensek a Java alaprendszer osztályaira épülnek, amelyek szintén sok esetben Full Trust jogosultságkészletet igényelnek. 

{{% /alert %}} 

Az internetszolgáltatók, amelyek több, különböző cégek alkalmazásait hosztolják, általában Medium Trust biztonsági szintet alkalmaznak: 

- OleDbPermission nem érhető el. Ez azt jelenti, hogy nem használhatja az ADO.NET által kezelt OLE DB adatszolgáltatót adatbázisok eléréséhez.
- EventLogPermission nem érhető el. Ez azt jelenti, hogy nem érheti el a Windows eseménynaplót.
- ReflectionPermission nem érhető el. Ez azt jelenti, hogy nem használhat reflexiót.
- RegistryPermission nem érhető el. Ez azt jelenti, hogy nem érheti el a rendszerleíró adatbázist.
- WebPermission korlátozott. Ez azt jelenti, hogy alkalmazása csak olyan címmel vagy címcsoporttal kommunikálhat, amelyet a <trust> elemben határoz meg.
- FileIOPermission korlátozott. Ez azt jelenti, hogy csak az alkalmazása virtuális könyvtárhierarchiájában lévő fájlokhoz férhet hozzá.

{{% alert color="primary" %}} 

A fent felsorolt okok miatt az Aspose Java komponenseket nem lehet olyan szervereken használni, amelyek nem Full Trust jogosultságkészletet biztosítanak. 

{{% /alert %}}