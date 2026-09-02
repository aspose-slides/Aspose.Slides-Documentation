---
title: PowerPoint betűtípusok testreszabása Java-ban
linktitle: Egyedi betűtípus
type: docs
weight: 20
url: /hu/java/custom-font/
keywords:
- betűtípus
- egyedi betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Testreszabhatja a PowerPoint diák betűtípusait az Aspose.Slides for Java segítségével, hogy prezentációi élesek és következetesek legyenek minden eszközön."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi egyedi betűtípusok használatát a prezentációkban anélkül, hogy azokat az operációs rendszerre telepítenénk. Betűtípusokat tölthet be egyedi mappákból, a dokumentumszintű betűtípusforrások segítségével egy adott prezentációhoz, vagy közvetlenül bináris adatokból külső betűtípusokként.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor egy prezentációt renderelnek vagy exportálnak, például PDF‑hez, képekhez és más támogatott formátumokhoz. Ez segít a prezentációk kimenetének egységességében különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus-mappákat, és hogyan törölheti a betűtípus-gyorsítót a külső betűtípusok használata után.

Az egyedi betűtípusok regisztrálása a rendereléshez különválik a betűtípusok PPTX‑fájlba való beágyazásától. Ha egy betűtípust a prezentáción belül kell tárolni, használja kifejezetten a betűtípus-beágyazási funkciókat.

Egy prezentációs téma különböző betűcsaládokra hivatkozhat az egyes írásrendszerekhez. Ezek a leképezések betűtípusneveket tárolnak, de nem telepítik vagy töltik be a betűtípusfájlokat. Lásd a [Szkriptre specifikus téma betűtípusok](/slides/hu/java/script-specific-font-mappings/) szakaszt a leképezések kezeléséhez, és használja az alább felsorolt betöltési beállításokat a hivatkozott betűtípusok elérhetővé tételéhez a konzisztens rendereléshez.

{{% alert color="info" title="Megjegyzés" %}}
Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.
{{% /alert %}}

## **Egyedi betűtípusok betöltése**

Aspose.Slides lehetővé teszi egy prezentációban használt betűtípusok betöltését anélkül, hogy azokat a rendszeren telepítené. Ez befolyásolja az exportálási kimenetet – például PDF, képek és más támogatott formátumok – így a létrehozott dokumentumok minden környezetben egységesek maradnak. A betűtípusok egyedi könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a betűtípusok betöltéséhez az adott mappákból.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader#clearCache--) metódust a betűtípus-gyorsítót törléshez.

A következő kódrészlet bemutatja a betűtípus betöltési folyamatát:

```java
import com.aspose.slides.*;

// Határozza meg az egyedi betűtípus fájlokat tartalmazó mappákat.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Töltsön be egyedi betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderelje/exportálja a prezentációt (például PDF, képek vagy egyéb formátumok) a betöltött betűtípusok használatával.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus gyorsítótárát a munka befejezése után.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Megjegyzés" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem változtatja meg a betűtípus‑inicializálás sorrendjét.  
A betűtípusok ebben a sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyedi betűtípus-mappák lekérése**

Aspose.Slides a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust biztosítja, amely lehetővé teszi a betűtípus-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűtípus-mappákat.

Ez a Java‑kód bemutatja, hogyan kell használni a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust:

```java
import com.aspose.slides.*;

// Ez a sor megjeleníti a mappákat, ahol a betűtípusfájlok keresése történik.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűtípus mappái.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Egyedi betűtípusok megadása egy prezentációhoz**

Aspose.Slides a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot biztosítja, amellyel külső betűtípusokat adhat meg, amelyeket a prezentáció használni fog.

Ez a Java‑kód bemutatja, hogyan kell használni a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Munkavégzés a prezentációval
    // CustomFont1, CustomFont2, és a assets\fonts & global\fonts mappák és alkönyvtáraik betűtípusai elérhetőek a prezentációban
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípusok külső kezelése**

Aspose.Slides a [loadExternalFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust biztosítja, amely lehetővé teszi külső betűtípusok betöltését bináris adatokból.

Ez a Java‑kód szemlélteti a bájt‑tömbből történő betűtípus‑betöltés folyamatát:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
            // külső betűtípus betöltve a prezentáció élettartama alatt
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **GYIK**

### Hatással vannak az egyedi betűtípusok az összes formátum (PDF, PNG, SVG, HTML) exportjára?
Igen. A kapcsolódó betűtípusokat a renderelő minden exportformátumban használja.

### Ágyazódnak-e automatikusan az egyedi betűtípusok a létrejövő PPTX‑be?
Nem. Egy betűtípus regisztrálása a rendereléshez nem egyenlő a PPTX‑be való beágyazással. Ha a betűtípust a prezentáció fájlban kell tárolni, használja a kifejezett [embedding features](/slides/hu/java/embedded-font/) lehetőséget.

### Irányíthatom-e a fallback viselkedést, ha egy egyedi betűtípus nem tartalmaz bizonyos glifeket?
Igen. Állítsa be a [font substitution](/slides/hu/java/font-substitution/), [replacement rules](/slides/hu/java/font-replacement/) és [fallback sets](/slides/hu/java/fallback-font/) beállításait, hogy pontosan meghatározza, melyik betűtípust használja a hiányzó glif esetén.

### Használhatok-e betűtípusokat Linux/Docker konténerekben anélkül, hogy azokat rendszerszinten telepíteném?
Igen. Mutasson a saját betűtípus-mappáira vagy töltsön be betűtípusokat bájt tömbökből. Ez megszünteti a rendszer betűtípus könyvtárakra való függést a konténer képen.

### Mi van a licenceléssel – beágyazhatok-e bármilyen egyedi betűtípust korlátozások nélkül?
Ön felelős a betűtípus-licencelés betartásáért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt terjesztené a kimenetet.