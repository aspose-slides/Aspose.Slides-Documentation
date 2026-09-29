---
title: PowerPoint betűtípusok testreszabása Java nyelven
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
- bemutató
- Java
- Aspose.Slides
description: "Testreszabhatja a PowerPoint diák betűtípusait az Aspose.Slides for Java segítségével, hogy bemutatói minden eszközön élesek és következetesek maradjanak."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a bemutatókban anélkül, hogy azokat a operációs rendszerre telepítené. Betűtípusokat tölthet be egyéni mappákból, biztosíthat betűtípusokat egy adott bemutatóhoz dokumentumszintű betűforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok a bemutató renderelésekor vagy exportálásakor kerülnek felhasználásra, például PDF, képek és egyéb támogatott formátumok esetén. Ez segít a bemutató kimenetnek környezetek között konzisztensnek maradni. A cikk elmagyarázza, hogyan ellenőrizhető az Aspose.Slides által használt betűtípus-mappák, valamint hogyan törölhető a betűtípus-gyorsítótár a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különbözik a betűtípusok PPTX fájlba ágyazásától. Ha a betűtípust a bemutatóba kell beágyazni, használja kifejezetten a betűtípus-beágyazási funkciókat.

Egy bemutató téma különböző betűcsaládokra hivatkozhat az egyes írásrendszerekhez. Ezek a leképezések csak a betűtípus-neveket tárolják, de nem telepítik vagy töltik be a betűtípus-fájlokat. Lásd a [Szkript-specifikus téma betűtípusok](/slides/hu/java/script-specific-font-mappings/) részt a leképezések kezeléséhez, és használja az alábbi betöltési beállításokat a hivatkozott betűtípusok konzisztens rendereléshez történő elérhetővé tételéhez.

{{% alert color="info" title="Note" %}}
Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.

* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.
{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi a bemutatóban használt betűtípusok betöltését anélkül, hogy azokat a rendszerbe telepítené. Ez befolyásolja az exportált kimenetet – például PDF, képek és egyéb támogatott formátumok – így a létrehozott dokumentumok környezetek között egységesek maradnak. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípus-fájlokat tartalmazza.  
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódust, hogy betöltse a betűtípusokat a megadott mappákból.  
3. Töltse be és renderelje/exportálja a bemutatót.  
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#clearCache--) metódust a betűtípus-gyorsítótár törléséhez.

```java
import com.aspose.slides.*;

// Határozza meg a saját betűtípus fájlokat tartalmazó mappákat.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Töltsön be egyéni betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderelje/exportálja a bemutatót (pl. PDF, képek vagy más formátumok) a betöltött betűtípusok használatával.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus gyorsítótárát a munka befejezése után.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem változtatja meg a betűtípus-kezdeti sorrendet.
A betűtípusok a következő sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus útvonala.  
1. A [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni betűtípus-mappák lekérése**
Aspose.Slides biztosítja a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust, amely lehetővé teszi a betűtípus-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódus által hozzáadott mappákat, valamint a rendszer betűtípus-mappákat.

Ez a Java kód bemutatja, hogyan kell használni a [getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--) metódust:

```java
import com.aspose.slides.*;

// Ez a sor kiírja azokat a mappákat, ahol a betűtípusfájlok keresése történik.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűtípus mappái.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Egyéni betűtípusok megadása egy bemutatóhoz**
Aspose.Slides biztosítja a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot, amely lehetővé teszi a külső betűtípusok megadását, amelyek a bemutatóval együtt lesznek használva.

Ez a Java kód bemutatja, hogyan kell használni a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) tulajdonságot:

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
    // Dolgozzon a bemutatóval
    // A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappákból és azok alkönyvtáraiból származó betűtípusok elérhetők a bemutató számára
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides biztosítja a [loadExternalFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust, amely lehetővé teszi a külső betűtípusok betöltését bináris adatokból.

Ez a Java kód demonstrálja a bájt-tömb betűtípus betöltési folyamatát:

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

### A egyéni betűtípusok befolyásolják az exportálást minden formátumba (PDF, PNG, SVG, HTML)?

Igen. A csatlakoztatott betűtípusokat a renderelő minden export formátumban használja.

### Az egyéni betűtípusok automatikusan be vannak ágyazva a létrehozott PPTX-be?

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX-be való beágyazás. Ha a betűtípust a bemutató fájlban kell szerepeltetni, akkor a kifejezett [beágyazási funkciókat](/slides/hu/java/embedded-font/) kell használni.

### Irányíthatom a fallback viselkedést, ha egy egyéni betűtípusból hiányoznak bizonyos karakterek?

Igen. Konfigurálja a [betűtípus helyettesítést](/slides/hu/java/font-substitution/), a [csere szabályokat](/slides/hu/java/font-replacement/) és a [fallback készleteket](/slides/hu/java/fallback-font/), hogy pontosan meghatározza, melyik betűtípust használja, ha a kért karakter hiányzik.

### Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy a rendszer szintjén telepíteném őket?

Részben. Az Aspose.Slides használhat betűtípusokat saját mappáiból vagy bájt-tömbökből anélkül, hogy azokat telepítené, de a Java betűtípus-támogatásának még mindig szüksége van legalább egy telepített betűtípusra a képen. Ennek hiányában a betöltés a "Fontconfig head is null, check your fonts or fonts configuration" hibával meghiúsul. Lásd a [Betűtípusok telepítése](/slides/hu/java/deploy-fonts/) oldalt.

### Mi van a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?

Ön felelős a betűtípusok licencfeltételeinek betartásáért. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA-ját, mielőtt a kimeneteket terjesztené.