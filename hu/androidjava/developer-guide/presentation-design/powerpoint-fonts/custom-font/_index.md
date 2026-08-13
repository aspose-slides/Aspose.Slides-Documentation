---
title: "PowerPoint betűtípusok testreszabása Androidon"
linktitle: "Egyedi betűtípus"
type: docs
weight: 20
url: /hu/androidjava/custom-font/
keywords:
- "betűtípus"
- "egyedi betűtípus"
- "külső betűtípus"
- "betűtípus betöltése"
- "betűtípusok kezelése"
- "betűtípus mappa"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Testreszabhatja a PowerPoint diák betűtípusait az Aspose.Slides for Android segítségével Java nyelven, hogy prezentációi élesek és következetesek legyenek bármilyen eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a prezentációkban egyedi betűtípusokat használjon anélkül, hogy azokat az operációs rendszerre telepítené. Betűtípusokat tölthet be egyedi mappákból, megadhat betűtípusokat egy adott prezentációhoz dokumentumszintű betűforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusokat a prezentáció renderelésekor vagy exportálásakor használja, például PDF, kép vagy más támogatott formátumok esetén. Ez segít a prezentációk kimenetét konzisztens módon tartani különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípusmappákat, és hogyan tisztíthatja a betűtípus-gyorsítót a külső betűtípusok használata után.

Regisztrálja az egyedi betűtípusokat a rendereléshez, ami különbözik a betűtípusok PPTX fájlba ágyazásától. Ha egy betűtípust magában a prezentációban kell tárolni, használja kifejezetten a betűtípus‑ágyazás funkciókat.

{{% alert color="info" %}} 
Az Aspose Slides lehetővé teszi ezeknek a betűtípusoknak a betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.  
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.  
{{% /alert %}}

## **Betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy a prezentációban használt betűtípusokat betöltse anélkül, hogy azokat a rendszeren telepítené. Ez befolyásolja az export kimenetét – például PDF, képek és más támogatott formátumok – így a létrehozott dokumentumok minden környezetben egységesnek tűnnek. A betűtípusok egyedi könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.  
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a betűtípusok betöltéséhez a megadott mappákból.  
3. Töltse be és renderelje/exportálja a prezentációt.  
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsLoader#clearCache--) metódust a betűtípus-gyorsítót törléséhez.  

Az alábbi kódrészlet bemutatja a betűtípus betöltési folyamatát:

```java
import com.aspose.slides.*;

// Határozza meg az egyedi betűtípus fájlokat tartalmazó mappákat.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Töltse be az egyedi betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderelje/exportálja a prezentációt (például PDF, képek vagy más formátumok) a betöltött betűtípusokkal.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus-gyorsítót a munka befejezése után.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad hozzá a betűtípus-keresési útvonalakhoz, de nem változtatja meg a betűtípusok inicializálási sorrendjét.  
A betűtípusok a következő sorrendben kerülnek inicializálásra:

1. Az alapértelmezett operációs rendszer betűtípus útvonala.  
1. Az [FontsLoader](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/) által betöltött útvonalak.  
{{%/alert %}}

## **Egyedi betűtípus mappák lekérése**

Az Aspose.Slides biztosítja a [getFontFolders](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) metódust, amely lehetővé teszi a betűtípusmappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűtípus mappákat.

Ez a Java kód bemutatja, hogyan kell használni a [getFontFolders](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) metódust:

```java
import com.aspose.slides.*;

// Ez a sor kiírja azokat a mappákat, ahol a betűtípusfájlok keresése történik.
// Ezek azok a mappák, amelyeket a LoadExternalFonts metódus és a rendszer betűtípus mappái adtak hozzá.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **A prezentációval használt egyedi betűtípusok megadása**

Az Aspose.Slides biztosítja a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot, amely lehetővé teszi, hogy külső betűtípusokat adjon meg, amelyek a prezentációval együtt lesznek használva.

Ez a Java kód bemutatja, hogyan kell használni a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot:

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
    // Dolgozz a prezentációval
    // A CustomFont1, CustomFont2 és az assets\fonts valamint a global\fonts mappákból és azok alkönyvtáraiból származó betűtípusok a prezentáció számára elérhetők
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides biztosítja a [loadExternalFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust, amely lehetővé teszi, hogy külső betűtípusokat töltsön be bináris adatokból.

Ez a Java kód demonstrálja a bájt‑tömb alapú betűtípus betöltési folyamatot:

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

### Be­folyásolják‑e az egyedi betűtípusok az exportot minden formátumra (PDF, PNG, SVG, HTML)?

Igen. A kapcsolt betűtípusokat a renderelő minden exportformátum esetén használja.

### Á‑gyazódnak‑e automatikusan az egyedi betűtípusok a létrejövő PPTX‑be?

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint az ágyazás PPTX‑be. Ha a betűtípust a prezentáció fájlban kell tárolni, használja a kifejezett [embedding features](/slides/hu/androidjava/embedded-font/) funkciókat.

### Vezérelhetem‑e a helyettesítési viselkedést, ha egy egyedi betűtípus egyes glyfek hiányzik?

Igen. Konfigurálja a [font substitution](/slides/hu/androidjava/font-substitution/), [replacement rules](/slides/hu/androidjava/font-replacement/) és a [fallback sets](/slides/hu/androidjava/fallback-font/) beállításokat, hogy pontosan meghatározza, mely betűtípust használja, ha a kért glif hiányzik.

### Használhatok‑e betűtípusokat Linux/Docker konténerekben anélkül, hogy rendszer szintjén telepíteném őket?

Igen. Mutasson az Ön saját betűtípus‑mappáira vagy töltsön be betűtípusokat bájt‑tömbökből. Ez megszünteti a rendszer betűtípus könyvtárakra való függőséget a konténer képen.

### Mi a helyzet a licenceléssel — beágyazhatok‑e bármilyen egyedi betűtípust korlátozások nélkül?

Ön felelős a betűtípus licencelési megfelelésért. A feltételek változóak; egyes licencek tilthatják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimeneteket terjesztené.