---
title: Androidon a PowerPoint betűtípusok testreszabása
linktitle: Egyéni betűtípus
type: docs
weight: 20
url: /hu/androidjava/custom-font/
keywords:
- betűtípus
- egyéni betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Testreszabja a betűtípusokat a PowerPoint diákon az Aspose.Slides for Android segítségével Java nyelven, hogy prezentációi élesek és következetesek legyenek minden eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a prezentációkban anélkül, hogy telepítené őket az operációs rendszerre. Betűtípusokat tölthet be egyéni mappákból, megadhat betűtípusokat egy adott prezentációhoz dokumentumszintű betűforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok a prezentáció megjelenítésekor vagy exportálásakor kerülnek felhasználásra, például PDF, képek és más támogatott formátumok esetén. Ez segít azonos megjelenést biztosítani a különböző környezetekben. A cikk azt is bemutatja, hogyan vizsgálhatja meg az Aspose.Slides által használt betűtípus-mappákat, és hogyan tisztíthatja meg a betűtípus-gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a megjelenítéshez különálló a betűtípusok PPTX fájlba ágyazásától. Ha a betűtípust magában a prezentációban kell tárolni, használja a betűtípus-ágyazási funkciókat kifejezetten.

Egy prezentáció témája különböző írásrendszerekhez külön betűcsaládokat hivatkozhat. Ezek a leképezések csak a betűtípusok nevét tárolják, de nem telepítik vagy töltik be a betűtípusfájlokat. Lásd a [Script-Specific Theme Fonts](/slides/hu/androidjava/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használja az alábbi betöltési beállításokat a hivatkozott betűtípusok elérhetővé tételéhez a konzisztens megjelenítéshez.

{{% alert color="info" title="Note" %}}
Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódussal:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) cikket.
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) cikket.
{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi a prezentációban használt betűtípusok betöltését anélkül, hogy azokat a rendszerre telepítené. Ez befolyásolja az exportálási kimenetet – például PDF, képek és más támogatott formátumok – így a létrehozott dokumentumok minden környezetben egységesen jelennek meg. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adja meg egy vagy több mappát, amely a betűtípus‑fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a megadott mappák betöltéséhez.
3. Töltse be és jelenítse meg/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsLoader#clearCache--) metódust a betűtípus‑gyorsítótörléshez.

Az alábbi kódrészlet bemutatja a betűtípus‑betöltési folyamatot:

```java
import com.aspose.slides.*;

// Határozza meg az egyéni betűtípusfájlokat tartalmazó mappákat.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Töltse be az egyéni betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderelje/exportálja a prezentációt (például PDF-be, képekbe vagy más formátumokba) a betöltött betűtípusok használatával.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus-gyorsítót a munka befejezése után.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűtípus‑keresési útvonalakhoz, de nem változtatja meg a betűtípus‑inicializálási sorrendet.
A betűtípusok ezen a sorrenden inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus‑útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni betűtípus‑mappák lekérése**

Az Aspose.Slides a [getFontFolders](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) metódust biztosítja, amely lehetővé teszi a betűtípus‑mappák megtalálását. Ez a metódus a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűtípus‑mappákat adja vissza.

Az alábbi Java‑kód bemutatja a [getFontFolders](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) használatát:

```java
import com.aspose.slides.*;

// Ez a sor kiírja azokat a mappákat, ahol a betűtípusfájlok keresése történik.
// Ezek a LoadExternalFonts metóduson keresztül hozzáadott mappák és a rendszer betűtípus-mappái.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Egy prezentációval használt egyéni betűtípusok megadása**

Az Aspose.Slides a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot biztosítja, amely lehetővé teszi a prezentációval együtt használandó külső betűtípusok megadását.

Az alábbi Java‑kód mutatja, hogyan kell használni a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot:

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
    // A prezentációval dolgozás
    // A CustomFont1, CustomFont2 és az assets\fonts & global\fonts mappákból és azok alkönyvtáraiból származó betűtípusok elérhetők a prezentáció számára
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides a [loadExternalFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust biztosítja, amely lehetővé teszi külső betűtípusok betöltését bináris adatokból.

Az alábbi Java‑kód bemutatja a bájt‑tömbös betűtípus‑betöltési folyamatot:

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
        //        külső betűtípus betöltve a prezentáció életciklusa során
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **GYIK**

### Befolyásolják a saját betűtípusok az exportálást minden formátumba (PDF, PNG, SVG, HTML)?

Igen. A csatolt betűtípusok a renderelő által minden export formátumban használatra kerülnek.

### A saját betűtípusok automatikusan beágyazódnak a létrejött PPTX‑be?

Nem. A betűtípus regisztrálása a megjelenítéshez nem azonos a PPTX‑be ágyazással. Ha a betűtípust a prezentáció fájljában szeretné tárolni, használja a kifejezett [embedding features](/slides/hu/androidjava/embedded-font/) lehetőséget.

### Szabályozhatom a fallback viselkedést, ha egy saját betűtípusból hiányoznak bizonyos glifyek?

Igen. Konfigurálja a [font substitution](/slides/hu/androidjava/font-substitution/), [replacement rules](/slides/hu/androidjava/font-replacement/) és [fallback sets](/slides/hu/androidjava/fallback-font/) beállításokat, hogy pontosan meghatározza, melyik betűtípus kerüljön felhasználásra hiányzó glif esetén.

### Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy a rendszeren telepíteném őket?

Igen. Hivatkozhat saját betűtípus‑mappákra, vagy betöltheti a betűtípusokat bájt‑tömbökből. Ez eltávolítja a konténer‑image rendszer‑betűtípus‑könyvtárakra való függőséget.

### Mi a helyzet a licenceléssel – beágyazhatok bármilyen saját betűtípust korlátozások nélkül?

Ön felelős a betűtípus‑licenc megfelelőségért. A feltételek változóak; egyes licencek tiltják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimeneteket terjesztené.