---
title: "Kezdő lépések"
type: docs
weight: 10
url: /hu/java/getting-started/
keywords:
- "első lépések"
- "rendszerkövetelmények"
- "telepítés"
- "első prezentáció"
- Maven
- "PPT feldolgozás"
- "PPTX feldolgozás"
- "ODP feldolgozás"
- PowerPoint
- OpenDocument
- "prezentáció"
- Java
- Aspose.Slides
description: "Az út egy új Java projektből az Aspose.Slides-szel elkészített első mentett prezentációig: ellenőrizze a követelményeket, adja hozzá a könyvtárat az Aspose Maven tárolójából, futtassa az első programot, majd folytassa a gyakori feladatokkal."
---
## **Áttekintés**

A lenti négy lépést sorrendben hajtsa végre. Minden lépés megnevezi, mit kell tenni, és hivatkozást tartalmaz a részleteket bemutató cikkre. Az értékelés, licencelés és támogatás a lépések után található.

## **Lépés 1: Ellenőrizze a rendszerkövetelményeket**

Az Aspose.Slides for Java egyetlen JAR fájl, amely nem tartalmaz natív kódot, ezért bármilyen olyan operációs rendszeren fut, amely támogatott Java futtatókörnyezetet tartalmaz. [System Requirements](/slides/hu/java/system-requirements/) felsorolja a támogatott operációs rendszereket és Java verziókat. A következő lépésekben szereplő projekt és parancsok JDK 11 vagy újabb verziót igényelnek, valamint a Maven útvonal esetén [Apache Maven](https://maven.apache.org/install.html)-t.

## **Lépés 2: Adja hozzá a könyvtárat a projekthez**

Az Aspose.Slides for Java az Aspose saját Maven tárolójában érhető el, nem a Maven Central-ban. Válassza a következő útvonalak egyikét:

- Maven használatával: adja hozzá a `https://releases.aspose.com/java/repo/` tárolót a *pom.xml*-hez, és adja meg a `com.aspose:aspose-slides` függőséget a `jdk16` osztályozóval.
- Maven nélkül: töltse le a *-jdk16.jar* végződésű JAR fájlt a tárolóból, és helyezze el az osztályúton.

Linuxon telepítenie kell a fontconfig könyvtárat és legalább egy betűtípust. Ezek hiányában a prezentáció mentése a "Fontconfig head is null, check your fonts or fonts configuration" hiba miatt meghiúsul.

[Installation](/slides/hu/java/installation/) tartalmazza a *pom.xml* bejegyzéseket, a JAR letöltését és a Linux parancsot.

## **Lépés 3: Hozza létre az első prezentációját**

A [quick start on the Aspose.Slides for Java home page](/slides/hu/java/#your-first-presentation) egy teljes Maven projekt: egy *pom.xml* fájl és egy program, amely felhő alakzatot szöveggel ad egy diára, majd PPTX fájlként menti a prezentációt. A programot `mvn compile exec:java` paranccsal futtathatja. A [Create Presentations](/slides/hu/java/create-presentation/) leírja ugyanazt a programot lépésről‑lépésre. Egy meglévő prezentáció megnyitásához és más formátumba mentéséhez nézze meg a [Open Presentations](/slides/hu/java/open-presentation/) és a [Save Presentations](/slides/hu/java/save-presentation/) oldalakat.

## **Lépés 4: Folytassa a gyakori feladatokkal**

- [Open a presentation](/slides/hu/java/open-presentation/)
- [Save a presentation](/slides/hu/java/save-presentation/)
- [Convert a presentation to PDF](/slides/hu/java/convert-powerpoint-to-pdf/)
- [Render slides as images](/slides/hu/java/convert-slide/)
- [Edit presentation text](/slides/hu/java/manage-text/)
- [Examples by slide element](/slides/hu/java/examples/)

## **Értékelés és licenc**

Licenc nélkül az Aspose.Slides értékelő módban működik: minden mentett diára vízjelet helyez, és a prezentációkból beolvasott szöveget csonkolja.

- [Evaluate Aspose.Slides](/slides/hu/java/evaluate-aspose-slides/) bemutatja az értékelési korlátokat és a ideiglenes licenc igénylésének módját.
- [Licensing](/slides/hu/java/licensing/) megmutatja, hogyan alkalmazzon licencet fájlból vagy adatfolyamból.
- [Metered Licensing](/slides/hu/java/metered-licensing/) a felhasználás alapú licencelést tárgyalja.
- [Supported File Formats](/slides/hu/java/supported-file-formats/) felsorolja az Aspose.Slides által betölthető és menthető formátumokat.

## **Segítség kérése**

[Technical Support](/slides/hu/java/technical-support/) elmagyarázza, hogyan tehet fel kérdést az [ingyenes támogatási fórumon](https://forum.aspose.com/c/slides/hu/11), és mit tartalmazzon a hiba bejelentése.

## **GYIK**

**Szükségem van a Microsoft PowerPoint telepítésére?**

Nem. Az Aspose.Slides saját maga olvassa és írja a prezentációs fájlokat, nem használ PowerPointot, így szervereken és Linuxon is futtatható.

**Miért nem találja a Maven az Aspose.Slides for Java-t?**

A könyvtár nem érhető el a Maven Central-ban. Adja meg az Aspose tárolóját a *pom.xml*-ben, ahogyan az [Installation](/slides/hu/java/installation/) mutatja, és a Maven onnan tölti le a könyvtárat.

**A `jdk16` osztályozó azt jelenti, hogy a könyvtárnak Java 16‑ra van szüksége?**

Nem. Az osztályozó a könyvtár Java SE változatát választja; a másik változat Androidra van. Ugyanez a változat fut a jelenlegi JDK-ken, például a JDK 21‑en.