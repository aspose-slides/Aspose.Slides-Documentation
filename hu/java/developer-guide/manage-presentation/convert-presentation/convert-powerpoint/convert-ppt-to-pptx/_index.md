---
title: PPT konvertálása PPTX-re Java-ban
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálás
- prezentáció konvertálás
- dia konvertálás
- PPT konvertálás
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Örökölt PPT fájlok konvertálása PPTX-re Java-val az Aspose.Slides segítségével. Tartalmaz Java példákat egyetlen fájl és kötegelt konverzióra, hiba kezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Java képes betölteni egy PPT fájlt és PPTX‑ként menteni anélkül, hogy a Microsoft PowerPointra lenne szükség. Ez a cikk bemutatja, hogyan konvertáljunk egyetlen fájlt vagy egy könyvtárban lévő fájlokat, és ismerteti, mit kell ellenőrizni a konverzió után.

## **PPT fájl konvertálása PPTX formátumba**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/#Pptx) argumentummal. A `finally` blokk felszabadítja a prezentációt és elengedi az erőforrásait.

```java
// Töltsd be a régi PPT prezentációt.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Mentsd el a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/#Pptx) argumentum végzi. Ha meg kell őrizni az eredeti PPT fájlt, a bemeneti és kimeneti útvonalakat tegye különbözővé.

## **Több PPT fájl konvertálása**

Az alábbi példa minden `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió nem állítja le a többi darabot.

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

Éles környezetben naplózza a teljes kivételt, döntse el, hogy a meglévő kimeneti fájlt felülírhatja-e, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett, de a szükséges jelszó nélkül megnyitott fájlok, elérhetetlen útvonalak és nem támogatott tartalom mind a konverzió kudarcát okozhatják. Lásd a [Password-Protected Presentations](/slides/hu/java/password-protected-presentation/) szakaszt a titkosított fájlok betöltéséhez.

## **Pontosság és örökölt funkciók**

A konverzió általában megőrzi a diák, mesterdiák, elrendezések, szövegek, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem ábrázolja minden funkciót pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, kihagyható vagy másként jeleníthető meg.

Ellenőrizze a konvertált fájlt, ha animációkat, átmeneteket, beágyazott vagy hivatkozott OLE-objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűkészleteket vagy VBA makrókat tartalmaz. A sima PPTX fájl nem makró‑engedélyezett formátum, ezért használjon megfelelő makró‑engedélyezett munkafolyamatot, amikor a VBA-nak elérhetőnek kell maradnia. Győződjön meg továbbá arról, hogy a szükséges betűkészletek és külső erőforrások jelen vannak abban a környezetben, ahol a konvertált prezentációt megnyitják vagy renderelik.

Fontos dokumentumok esetén nyissa meg programozottan a létrehozott PPTX‑et, ellenőrizze a kulcsfontosságú diák számát és tartalmát, majd hasonlítsa össze a megjelenését és a diavetítés viselkedését a kívánt megjelenítőben. Ne tekintse a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX‑et**

Használja a PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és visszaállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑t archiválási vagy visszaállítási másolatként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF‑et, HTML‑t, képeket, XPS‑t vagy más kimeneti típust kíván, használja a [Convert Presentations to Multiple Formats](/slides/hu/java/convert-presentation/) útmutatót a célformátumokhoz, ahelyett, hogy azt feltételezné, minden cél megőrzi a szerkeszthető PowerPoint‑jellemzőket.

## **Online konverter**

Alkalmi fájlok vagy gyors összehasonlítás esetén használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hiba‑kezeléshez használja a Java API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/java/ppt-vs-pptx/)
- [Save Presentations in Java](/slides/hu/java/save-presentation/)
- [Supported File Formats](/slides/hu/java/supported-file-formats/)
- [Open Presentations in Java](/slides/hu/java/open-presentation/)

## **GYIK**

**Konvertálhatok PPT‑t PPTX‑be anélkül, hogy a Microsoft PowerPoint telepítve lenne?**

Igen. Az Aspose.Slides for Java a prezentációs fájlokat betölti és menti anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑ról PPTX‑re történő konverzió minden tartalmat pontosan megőriz?**

A gyakori prezentációs tartalmat megőrzi, de a pontos pontosság nem garantált minden örökölt vagy nem támogatott funkció esetén. Tekintse át a generált fájlt, ha makrókat, OLE‑ vagy ActiveX‑objektumokat, médiát, speciális animációkat vagy ritka betűkészleteket tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor a helyes jelszót adja meg. Hiányzó vagy helytelen jelszó esetén a betöltés sikertelen lesz.

**Töröjem a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg a PPTX‑et a Önnek fontos megjelenítőkben és munkafolyamatokban ellenőrizte. Ez visszaállítási másolatot biztosít, ha egy örökölt funkció másként konvertálódik.