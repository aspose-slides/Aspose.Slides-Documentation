---
title: "PowerPoint betűtípusok testreszabása Androidon"
linktitle: "Egyedi betűtípus"
type: docs
weight: 20
url: /hu/androidjava/custom-font/
keywords:
- betűtípus
- egyedi betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus-mappa
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Testreszabja a betűtípusokat a PowerPoint diákon az Androidra készült Aspose.Slides segítségével Java-ban, hogy bemutatói élesek és következetesek legyenek bármilyen eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a bemutatókban anélkül, hogy azokat az operációs rendszerre telepítené. Betűtípusokat tölthet fel egyéni mappákból, megadhat betűtípusokat egy adott bemutatóhoz dokumentumszintű betűtípus-források segítségével, vagy betöltheti a külső betűtípusokat közvetlenül bináris adatokból.

A betöltött betűtípusok akkor kerülnek felhasználásra, amikor a bemutatót renderelik vagy exportálják, például PDF-be, képekbe és más támogatott formátumokba. Ez segít a bemutató kimenetének konzisztens maradásában különböző környezetekben. A cikk azt is bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus-mappákat, és hogyan tisztíthatja a betűtípus-gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez elkülönül a betűtípusok PPTX-fájlba ágyazásától. Ha egy betűtípust a bemutatóba kell tárolni, használja a betűtípus-ágyazás funkciókat kifejezetten.

{{% alert color="primary" %}} 

Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.

* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi a bemutatóban használt betűtípusok betöltését anélkül, hogy azokat a rendszerbe telepítené. Ez befolyásolja az export kimenetet – például PDF-et, képeket és más támogatott formátumokat – így a létrehozott dokumentumok környezetek között konzisztensnek tűnnek. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több olyan mappát, amely a betűtípus-fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust a betűtípusok betöltéséhez az adott mappákból.
3. Töltse be és renderelje/exportálja a bemutatót.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsLoader#clearCache--) metódust a betűtípus-gyorsítót törléséhez.

A következő kódrészlet bemutatja a betűtípus betöltési folyamatát:

```java
// Határozza meg az egyéni betűtípus fájlokat tartalmazó mappákat.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Töltsön be egyéni betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Renderelje/exportálja a bemutatót (pl. PDF-be, képekbe vagy más formátumokba) a betöltött betűtípusokkal.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus gyorsítót a munka befejezése után.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem változtatja meg a betűtípusok inicializálási sorrendjét.
A betűtípusok ebben a sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípusmappák lekérdezése**
Az Aspose.Slides biztosítja a [getFontFolders](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) metódust, amely lehetővé teszi a betűtípus-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metóduson keresztül hozzáadott mappákat és a rendszer betűtípus-mappákat.

Ez a Java kód bemutatja, hogyan kell használni a [getFontFolders](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) metódust:

```java
// Ez a sor kiírja azokat a mappákat, ahol a betűtípus fájlok keresése történik.
// Ezek a LoadExternalFonts metóduson keresztül hozzáadott mappák és a rendszer betűtípus mappák.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Egyéni betűtípusok megadása egy bemutatóhoz**
Az Aspose.Slides biztosítja a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot, amely lehetővé teszi a bemutatóhoz használandó külső betűtípusok megadását.

Ez a Java kód bemutatja, hogyan kell használni a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Dolgozzon a bemutatóval
    // A CustomFont1, a CustomFont2 és az assets\fonts & global\fonts mappákból (és azok almappáiból) származó betűtípusok elérhetők a bemutatóban
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides biztosítja a [loadExternalFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust, amely lehetővé teszi külső betűtípusok betöltését bináris adatokból.

Ez a Java kód bemutatja a byte tömbből történő betűtípus betöltési folyamatot:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // külső betűtípus betöltve a bemutató élettartama alatt
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **GYIK**

**Az egyéni betűtípusok hatnak-e az összes formátumba történő exportálásra (PDF, PNG, SVG, HTML)?**

Igen. A kapcsolódó betűtípusokat a renderelő minden exportformátumban felhasználja.

**Az egyéni betűtípusok automatikusan be vannak ágyazva a létrejövő PPTX-be?**

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX-be ágyazás. Ha a betűtípust a bemutató fájlba be kell ágyazni, explicit módon a [beágyazási funkciókat](/slides/hu/androidjava/embedded-font/) kell használnia.

**Irányíthatom-e a visszaeső (fallback) viselkedést, ha egy egyéni betűtípus hiányos bizonyos glifekkel?**

Igen. Konfigurálja a [betűtípus helyettesítést](/slides/hu/androidjava/font-substitution/), a [csere szabályokat](/slides/hu/androidjava/font-replacement/) és a [visszalépő készleteket](/slides/hu/androidjava/fallback-font/) annak meghatározásához, hogy melyik betűtípus legyen használva, ha a kért glif hiányzik.

**Használhatok-e betűtípusokat Linux/Docker konténerekben anélkül, hogy rendszerszinten telepíteném őket?**

Igen. Hivatkozzon saját betűtípus-mappáira, vagy töltse be a betűtípusokat byte tömbökből. Ez eltávolítja a konténer képen lévő rendszermappákra való függőséget.

**Mi van a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?**

Ön felelős a betűtípusok licencelési követelményeinek betartásáért. A feltételek változhatnak; egyes licencek tiltják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA-ját, mielőtt a kimeneteket terjesztené.