---
title: PPT konvertálása PPTX-re Java-ban
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Konvertálja a régi PPT fájlokat PPTX-re Java-val az Aspose.Slides segítségével. Tartalmaz Java példákat egyetlen fájlra és kötegelt konverzióra, hibakezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Java képes betölteni egy PPT fájlt és PPTX‑ként menteni anélkül, hogy a Microsoft PowerPoint telepítve lenne. Ez a cikk bemutatja, hogyan konvertálhat egyetlen fájlt vagy egy mappában lévő fájlokat, illetve mi ellenőrizhető a konverzió után.

## **PPT fájl konvertálása PPTX‑be**

Töltsd be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal, majd hívd meg a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/#Pptx) argumentummal. A `finally` blokk felszabadítja a prezentációt és felszabadítja erőforrásait.

```java
// Töltsd be a régi PPT bemutatót.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Mentse a bemutatót PPTX formátumban.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Magától a fájlkiterjesztés nem választja ki a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/#Pptx) argumentum határozza meg. Ha meg kell őrizni az eredeti PPT fájlt, tartsd külön a bemeneti és kimeneti útvonalakat.

## **Több PPT fájl konvertálása**

Az alábbi példa minden egyes `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió sem állítja meg a többi feldolgozását.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Éles környezetben naplózd a teljes kivételt, döntsd el, hogy felülírható-e egy már létező kimeneti fájl, és írd a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, a szükséges jelszó nélkül megnyitott jelszóval védett fájlok, elérhetetlen útvonalak és nem támogatott tartalom mind konverziós hibához vezethetnek. Lásd a [Jelszóval védett bemutatók](/java/password-protected-presentation/) oldalt a titkosított fájlok betöltéséhez.

## **Pontosság és örökölt funkciók**

A konverzió általában megőrzi a diák, mesterdiák, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, kihagyható vagy másként jeleníthető meg.

Ellenőrizd a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. A sima PPTX fájl nem támogatja a makrókat, ezért megfelelő, makró‑támogatott munkafolyamatot kell alkalmazni, ha a VBA-nak elérhetőnek kell maradnia. Emellett ellenőrizd, hogy a szükséges betűtípusok és külső erőforrások jelen vannak-e abban a környezetben, ahol a konvertált prezentációt megnyitják vagy renderelik.

Fontos dokumentumok esetén programozottan nyisd meg újra a létrehozott PPTX‑et, vizsgáld meg a kulcsfontosságú diák számát és tartalmát, majd hasonlítsd össze a megjelenését és a diavetítés viselkedését a kívánt megjelenítőben. Ne tekintsd a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) hívást bizonyítékul arra, hogy minden örökölt funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX‑et**

Használd a PPTX‑et, ha a bemutatót a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerek között cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsd meg az eredeti PPT‑t archiválási vagy visszaállítási másolatként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseiden.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy más kimeneti típusra van szükséged, használd a [Prezentációk konvertálása több formátumba](/java/convert-presentation/) útmutatót a formátumspecifikus tanácsokhoz, ahelyett, hogy azt feltételeznéd, minden cél megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Egy alkalmi fájlhoz vagy gyors összehasonlításhoz használhatod a [online PPT‑t PPTX‑re konvertáló](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használjuk a Java API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Prezentációk mentése Java-ban](/java/save-presentation/)
- [Támogatott fájlformátumok](/java/supported-file-formats/)
- [Prezentációk megnyitása Java-ban](/java/open-presentation/)

## **GYIK**

**Átkonvertálhatok PPT‑t PPTX‑be a Microsoft PowerPoint telepítése nélkül?**

Igen. Az Aspose.Slides for Java betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑ból PPTX‑be konverzió pontosan megőrzi az összes tartalmat?**

Megőrzi a gyakori prezentációs tartalmakat, de a pontos pontosság nem garantált minden örökölt vagy nem támogatott funkcióra. Tekintsd át a generált fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Átkonvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadod a helyes jelszót. Hiányzó vagy helytelen jelszó esetén a betöltés meghiúsul.

**Töröttenem a PPT fájlt a konverzió után?**

Tartsd meg az eredetit, amíg a számodra fontos megjelenítőkben és munkafolyamatokban ellenőrizted a PPTX‑et. Ez visszagörgetési másolatot biztosít, ha egy örökölt funkció másként konvertálódik.