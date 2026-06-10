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
description: "Testreszabhatja a PowerPoint diák betűtípusait az Aspose.Slides for Java segítségével, hogy a prezentációk minden eszközön élesek és konzisztens megjelenést mutassanak."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a prezentációkban anélkül, hogy azokat az operációs rendszerre telepítené. Betűtípusokat tölthet be egyéni mappákból, megadhat betűtípusokat egy adott prezentációhoz dokumentumszintű betűtípusforrásokon keresztül, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

Betöltött betűtípusok akkor kerülnek felhasználásra, amikor egy prezentációt renderelnek vagy exportálnak, például PDF, képek és más támogatott formátumok esetén. Ez segít a prezentáció kimenet konzisztens megtartásában különböző környezetek között. A cikk azt is bemutatja, hogyan ellenőrizhető az Aspose.Slides által használt betűtípus‑mappák, és hogyan törölhető a betűtípus‑gyorsítótár a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különbözik a betűtípusok PPTX fájlba ágyazásától. Ha egy betűtípust a prezentáción belül kell tárolni, használja explicit módon a betűtípus ágyazási funkciókat.

{{% alert color="primary" %}} 

Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy a prezentációban használt betűtípusokat a rendszerre történő telepítés nélkül töltsön be. Ez befolyásolja az exportálási kimenetet — például PDF, képek és más támogatott formátumok — így a kapott dokumentumok minden környezetben egységesnek tűnnek. A betűtípusok egyéni könyvtárakból kerülnek betöltésre.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a betűtípusok betöltéséhez a megadott mappákból.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader#clearCache--) metódust a betűtípus‑gyorsítótár törléséhez.

A következő kódrészlet bemutatja a betűtípus‑betöltési folyamatot:

```java
// Határozza meg az egyéni betűtípusfájlokat tartalmazó mappákat.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Töltsön be egyéni betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Renderelje/exportálja a prezentációt (például PDF‑re, képekre vagy más formátumokra) a betöltött betűtípusok használatával.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus-gyorsítótárat a munka befejezése után.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűtípus keresési útvonalakhoz, de nem változtatja meg a betűtípus inicializálási sorrendet.  
A betűtípusok a következő sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus útvonala.  
1. A [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus‑mappák lekérése**

Az Aspose.Slides biztosítja a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust, amely lehetővé teszi a betűtípus‑mappák megkeresését. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűtípus‑mappákat.

Ez a Java kód bemutatja, hogyan használja a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust:

```java
// Ez a sor kiírja azoknak a mappáknak a listáját, ahol a betűtípusfájlok keresésre kerülnek.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűtípusmappái.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **A prezentációval használt egyéni betűtípusok megadása**

Az Aspose.Slides biztosítja a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot, amely lehetővé teszi, hogy külső betűtípusokat adjon meg, amelyeket a prezentáció használni fog.

Ez a Java kód mutatja, hogyan használja a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Dolgozzon a prezentációval
    // CustomFont1, CustomFont2 és az assets\fonts & global\fonts mappákból, valamint azok alkönyvtáraiból származó betűtípusok elérhetők a prezentáció számára
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides biztosítja a [loadExternalFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust, amely lehetővé teszi a külső betűtípusok betöltését bináris adatokból.

Ez a Java kód bemutatja a bájt‑tömbös betűtípus‑betöltési folyamatot:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // külső betűtípus betöltve a prezentáció életciklusa alatt
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**Be­folyásolják az egyéni betűtípusok az exportálást minden formátumba (PDF, PNG, SVG, HTML)?**

Igen. A kapcsolt betűtípusok a renderelő által minden export formátumban használatosak.

**Ágyazódnak automatikusan az egyéni betűtípusok a létrehozott PPTX‑be?**

Nem. Egy betűtípus regisztrálása a rendereléshez nem ugyanaz, mint annak PPTX‑be ágyazása. Ha a betűtípust a prezentáció fájlba szeretné beágyazni, használja a kifejezett [embedding features](/slides/hu/java/embedded-font/) funkciót.

**Irányítható a helyettesítési viselkedés, ha egy egyéni betűtípus hiányos karakterekkel rendelkezik?**

Igen. Konfigurálja a [font substitution](/slides/hu/java/font-substitution/), [replacement rules](/slides/hu/java/font-replacement/) és [fallback sets](/slides/hu/java/fallback-font/) beállításokat, hogy pontosan meghatározza, mely betűtípust használja, ha a kért karakter nem található.

**Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy a rendszer szintjén telepíteném őket?**

Igen. Hivatkozhat saját betűtípus‑mappáira, vagy betöltheti a betűtípusokat bájt tömbökből. Ez eltávolítja a rendszer betűtípus könyvtárakra való függőséget a konténer képben.

**Mi van a licenceléssel—beágyazhatok bármilyen egyéni betűtípust korlátozás nélkül?**

Ön felel a betűtípus‑licencelés betartásáért. A feltételek változóak; egyes licencek tiltják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimeneteket terjesztené.