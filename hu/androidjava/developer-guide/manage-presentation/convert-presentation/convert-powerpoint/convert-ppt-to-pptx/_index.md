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
description: "Konvertálja a régi PPT fájlokat PPTX-re Androidon az Aspose.Slides segítségével. Tartalmaz Java példákat egyetlen fájl és kötegelt konverzióra, hibakezelésre és hűségjegyzetekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Android via Java képes betölteni egy PPT fájlt, és Microsoft PowerPoint nélkül PPTX formátumba menteni. Ez a cikk bemutatja, hogyan konvertálhat egy fájlt vagy egy könyvtár fájljait, és elmagyarázza, mit kell ellenőrizni a konvertálás után.

## **PPT fájl konvertálása PPTX-re**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/#Pptx) argumentummal. A `finally` blokk felszabadítja a prezentációt és elengedheti erőforrásait.

```java
// Töltsd be a régi PPT prezentációt.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Mentsd a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A fájlkiterjesztés önmagában nem választja ki a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/#Pptx) argumentum határozza meg. Tartsa külön a bemeneti és kimeneti útvonalakat, ha meg szeretné őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa minden `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió sem állítja le a többi köteg feldolgozását.

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

Éles környezetben naplózza a teljes kivételt, döntse el, hogy felülírható-e egy már létező kimeneti fájl, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett fájlok megfelelő jelszó nélkül történő megnyitása, elérhetetlen útvonalak és nem támogatott tartalom mind konverziósikert okozhatnak. Lásd a [Password-Protected Presentations](/androidjava/password-protected-presentation/) oldalt a titkosított fájlok betöltéséhez.

## **Hűség és régi funkciók**

A konverzió általában megőrzi a diák, a mesterdiák, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy régi funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, elhagyható vagy másként jeleníthető meg.

Ellenőrizze a konvertált fájlt, ha animációkat, átmeneteket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makrókat támogató formátum, ezért használjon megfelelő makrókat támogató munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Emellett ellenőrizze, hogy a szükséges betűtípusok és külső erőforrások jelen vannak-e abban a környezetben, ahol a konvertált prezentációt megnyitják vagy megjelenítik.

Fontos dokumentumok esetén nyissa meg programozottan a létrehozott PPTX-et, ellenőrizze a kulcsfontosságú dia számát és a tartalmat, majd hasonlítsa össze megjelenését és diavetítés‑viselkedését a kívánt megjelenítőben. Ne tekintse a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) hívást bizonyítéknak arra, hogy minden régi funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX-et**

Használja a PPTX-et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és helyreállítható a régi bináris PPT-nél. Tartsa meg az eredeti PPT‑t archiválási vagy visszalépési példányként, amíg a konvertált prezentáció át nem esik a hűség‑ellenőrzéseken.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy más kimeneti típusra van szüksége, használja a [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) formátum‑specifikus útmutatót, ahelyett, hogy feltételezné, hogy minden célformátum megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Ritka fájlokhoz vagy gyors összehasonlításhoz használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismételhető konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hiba‑kezeléshez használja az Android via Java API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/androidjava/save-presentation/)
- [Supported File Formats](/androidjava/supported-file-formats/)
- [Open Presentations on Android](/androidjava/open-presentation/)

## **FAQ**

**Konvertálhatok PPT‑t PPTX‑re anélkül, hogy a Microsoft PowerPoint telepítve lenne?**

Igen. Az Aspose.Slides for Android via Java betölti és elmenti a prezentációs fájlokat a Microsoft PowerPoint nélkül.

**A PPT‑ról PPTX‑re konverzió pontosan megőrzi az összes tartalmat?**

Megőrzi a közös prezentációs tartalmakat, de a pontos hűség nem garantált minden régi vagy nem támogatott funkcióra. Tekintse át a generált fájlt, ha makrókat, OLE‑ vagy ActiveX‑objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a helyes jelszót. Hiányzó vagy helytelen jelszó esetén a betöltés sikertelen.

**Törötnöm kell a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg a PPTX‑et a számára fontos megjelenítőkben és munkafolyamatokban ellenőrizte. Ez visszalépési példányt biztosít, ha egy régi funkció másként konvertálódik.