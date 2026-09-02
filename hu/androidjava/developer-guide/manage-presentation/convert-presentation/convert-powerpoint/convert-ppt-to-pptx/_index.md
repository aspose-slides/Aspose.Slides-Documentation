---
title: PPT konvertálása PPTX-re Androidon
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Hagyományos PPT fájlok konvertálása PPTX-re Androidon az Aspose.Slides segítségével. Tartalmaz Java példákat egyedi fájl és kötegelt konvertáláshoz, hibakezeléshez, valamint pontossági megjegyzéseket."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Android via Java képes betölteni egy PPT fájlt és PPTX‑ként menteni azt anélkül, hogy a Microsoft PowerPoint telepítve lenne. Ez a cikk bemutatja, hogyan konvertáljunk egyetlen fájlt vagy egy könyvtárban lévő fájlokat, és elmagyarázza, mit kell ellenőrizni a konvertálás után.

## **PPT fájl konvertálása PPTX‑re**

Töltsük be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal, majd hívjuk meg a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/#Pptx) argumentummal. A `finally` blokk felszabadítja a prezentációt és elengedi erőforrásait.

```java
// Töltsük be a régi PPT prezentációt.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Mentsük a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/#Pptx) argumentum határozza meg. Tartsa külön a bemeneti és kimeneti útvonalakat, ha meg kell őriznie az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa minden egyes `.ppt` fájlt konvertál egy könyvtárban. Minden fájl önállóan kerül feldolgozásra, így egy hibás konverzió sem állítja meg a többi feldolgozását.

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

Éles környezetben naplózza a teljes kivételt, döntse el, hogy a létező kimeneti fájl felülírható‑e, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett fájlok a megfelelő jelszó nélkül, elérhetetlen utak és nem támogatott tartalom is okozhat konverziós hibát. Lásd a [Password-Protected Presentations](/androidjava/password-protected-presentation/) cikket a titkosított fájlok betöltéséhez.

## **Pontosság és régi funkciók**

A konvertálás általában megőrzi a diák, mester‑diák, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy olyan régi funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálódhat, kihagyódhat vagy másként jelenhet meg.

Ellenőrizze a konvertált fájlt, ha animációkat, átmeneteket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makrókkal ellátott formátum, ezért használjon megfelelő makrókkal ellátott munkafolyamatot, ha a VBA‑nak elérhetőnek kell maradnia. Ezen felül győződjön meg róla, hogy a szükséges betűtípusok és külső erőforrások jelen vannak abban a környezetben, ahol a konvertált prezentációt megnyitják vagy megjelenítik.

Fontos dokumentumok esetén programkóddal nyissa meg újra a generált PPTX‑et, ellenőrizze a kulcsfontosságú diák számát és tartalmát, majd hasonlítsa össze megjelenését és diavetítés‑viselkedését a kívánt megjelenítőben. Ne tekintse a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) hívást bizonyítékra, hogy minden régi funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX‑et**

Használja a PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑et archivként vagy visszaállítási példányként, amíg a konvertált prezentáció nem teljesíti a pontossági ellenőrzéseket.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy más kimeneti típusra van szüksége, használja a [Convert Presentations to Multiple Formats](/slides/hu/androidjava/convert-presentation/) útmutatót a formátumspecifikus irányelvekhez, ahelyett, hogy feltételezné, hogy minden célformátum megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Ritkán előforduló fájlok vagy gyors összehasonlítás esetén használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használja az Android via Java API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/androidjava/ppt-vs-pptx/)
- [Prezentációk mentése Androidon](/slides/hu/androidjava/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/androidjava/supported-file-formats/)
- [Prezentációk megnyitása Androidon](/slides/hu/androidjava/open-presentation/)

## **GYIK**

**Konvertálhatok PPT‑t PPTX‑re a Microsoft PowerPoint telepítése nélkül?**

Igen. Az Aspose.Slides for Android via Java betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑PPTX konvertálás megőrzi minden tartalmat pontosan?**

Megőrzi a gyakori prezentációtartalmat, de minden régi vagy nem támogatott funkció pontos pontossága nem garantált. Tekintse át a generált fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a megfelelő jelszót. Hiányzó vagy helytelen jelszó esetén a betöltés sikertelen.

**Törötnöm kell a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg a PPTX‑et a kívánt megjelenítőkben és munkafolyamatokban ellenőrizte. Így visszaállítási másolat áll rendelkezésre, ha egy régi funkció másként konvertálódik.