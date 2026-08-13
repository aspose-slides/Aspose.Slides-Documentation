---
title: PowerPoint betűtípusok testreszabása Java-ban
linktitle: Egyéni betűtípus
type: docs
weight: 20
url: /hu/java/custom-font/
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
- Java
- Aspose.Slides
description: "Testreszabja a betűtípusokat a PowerPoint diákon az Aspose.Slides for Java segítségével, hogy prezentációi élesek és következetesek legyenek bármely eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egyéni betűtípusokat használjon prezentációkban a betűtípusok operációs rendszerre történő telepítése nélkül. Betűtípusokat tölthet be egyéni mappákból, megadhat betűtípusokat egy adott prezentációhoz dokumentumszintű betűtípusforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor egy prezentációt renderelnek vagy exportálnak, például PDF‑be, képekbe és más támogatott formátumokba. Ez segít a prezentációk kimenetének konzisztens maradásában különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus‑mappákat, és hogyan törölheti a betűtípus‑gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különbözik a betűtípusok PPTX‑fájlba ágyazásától. Ha egy betűtípust a prezentációba kell ágyazni, használja kifejezetten a betűtípus‑ágyazási funkciókat.

{{% alert color="info" %}} 

Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus használatával:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy a prezentációban használt betűtípusokat a rendszer telepítése nélkül töltse be. Ez befolyásolja az export kimenetét – például PDF, képek és más támogatott formátumok –, így a megjelenő dokumentumok környezetek között konzisztensnek tűnnek. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípus‑fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a betűtípusok betöltéséhez a megadott mappákból.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader#clearCache--) metódust a betűtípus‑gyorsítót törléshez.

Az alábbi kódrészlet demonstrálja a betűtípus‑betöltési folyamatot:

```java
import com.aspose.slides.*;

// Határozza meg az egyéni betűtípus fájlokat tartalmazó mappákat.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Töltse be az egyéni betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderelje/exportálja a prezentációt (pl. PDF-be, képekbe vagy más formátumokba) a betöltött betűtípusok használatával.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus-gyorsítót a munka befejezése után.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Megjegyzés" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűtípus‑keresési útvonalakhoz, de nem változtatja meg a betűtípus‑inicializálás sorrendjét. A betűtípusok a következő sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus‑útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus‑mappák lekérése**

Az Aspose.Slides biztosítja a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust, amely lehetővé teszi a betűtípus‑mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódus által hozzáadott mappákat és a rendszer betűtípus‑mappákat.

Ez a Java‑kód megmutatja, hogyan kell használni a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust:

```java
import com.aspose.slides.*;

// Ez a sor kiírja azokat a mappákat, ahol a betűtípus fájlokat keresik.
// Ezek a LoadExternalFonts metóduson keresztül hozzáadott mappák és a rendszer betűtípus mappái.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Egyéni betűtípusok megadása egy prezentációhoz**

Az Aspose.Slides biztosítja a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot, amely lehetővé teszi a prezentációhoz használandó külső betűtípusok megadását. 

Ez a Java‑kód megmutatja, hogyan kell használni a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot:

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
    // Munka a prezentációval
    // CustomFont1, CustomFont2, valamint az assets\fonts & global\fonts mappákból és azok almappáiból származó betűtípusok elérhetők a prezentáció számára
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides biztosítja a [loadExternalFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust, amely lehetővé teszi a külső betűtípusok betöltését bináris adatból.

Ez a Java‑kód demonstrálja a bájt‑tömbös betűtípus‑betöltés folyamatát:

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
        // külső betűtípus betöltve a prezentáció életciklusa során
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **GYIK**

### Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?

Igen. A kapcsolt betűtípusokat a renderelő minden export formátumban használja.

### Are custom fonts automatically embedded into the resulting PPTX?

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be ágyazás. Ha a betűtípust a prezentációfájlban szeretné tárolni, akkor kifejezetten a [beágyazási funkciókat](/slides/hu/java/embedded-font/) kell használnia.

### Can I control fallback behavior when a custom font lacks certain glyphs?

Igen. Konfigurálja a [betűtípus‑helyettesítést](/slides/hu/java/font-substitution/), [helyettesítési szabályokat](/slides/hu/java/font-replacement/) és a [fallback készleteket](/slides/hu/java/fallback-font/), hogy pontosan meghatározza, melyik betűtípust használja, ha a kért glif hiányzik.

### Can I use fonts in Linux/Docker containers without installing them system-wide?

Igen. Hivatkozzon saját betűtípus‑mappáira, vagy töltse be a betűtípusokat bájt‑tömbökből. Ez eltávolítja a rendszer betűtípus‑könyvtárakra való függőséget a konténer‑képből.

### What about licensing—can I embed any custom font without restrictions?

Ön felelős a betűtípus‑licencelés betartásáért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimenetet közzétenné.