---
title: "Felső- és alsóindex kezelése a prezentációkban Java használatával"
linktitle: "Felső- és alsóindex"
type: docs
weight: 80
url: /hu/java/superscript-and-subscript/
keywords:
- "felsőindex"
- "alsóindex"
- "felsőindex hozzáadása"
- "alsóindex hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Mesteri szintű felső- és alsóindex kezelése az Aspose.Slides for Java-ban, és emelje fel prezentációit professzionális szövegformázással a maximális hatás érdekében."
---
## **Áttekintés**

Az Aspose.Slides olyan funkciókat kínál, amelyek lehetővé teszik a felső- és alsóindex szöveg beillesztését a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációidba. Akár kémiai képleteket, matematikai egyenleteket kell kiemelni, akár lábjegyzetekkel szeretnéd megjegyzésekkel ellátni a tartalmat, ezek a speciális formázási lehetőségek segítenek a tisztaság és a pontosság megőrzésében. Ebben a cikkben megtanulod, hogyan alkalmazz zökkenőmentesen felső- és alsóindex stílusokat, és biztosítsd a professzionális eredményeket minden dián.

## **Felső- és alsóindex szöveg kezelése**
Bármely bekezdés részébe hozzáadhatsz felső- és alsóindex szöveget. Az Aspose.Slides szövegkeretben felső- vagy alsóindex szöveg hozzáadásához a [**setEscapement**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) metódust kell használni a [PortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PortionFormat) osztályban.

Ez a tulajdonság visszaadja vagy beállítja a felső- vagy alsóindex szöveget (érték -100% (alsóindex) és 100% (felsőindex) között). Például:

- Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Szerezd meg a diára való hivatkozást az Index segítségével.
- Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) objektumot, amely [Rectangle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeType#Rectangle) típusú, a diához.
- Érd el a [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrame) objektumot, amely a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape)-hez kapcsolódik.
- Töröld a meglévő bekezdéseket
- Hozz létre egy új bekezdésobjektumot a felsőindex szöveg tárolásához, és add hozzá az [IParagraphs gyűjteményhez](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrame#getParagraphs--) a [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrame)-ben.
- Hozz létre egy új részletobjektumot
- Állítsd be az Escapement tulajdonságot a részletnél 0 és 100 között a felsőindex hozzáadásához. (0 = nincs felsőindex)
- Adj be némi szöveget a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Portion) számára, majd add hozzá a bekezdés részletgyűjteményéhez.
- Hozz létre egy új bekezdésobjektumot az alsóindex szöveg tárolásához, és add hozzá az IParagraphs gyűjteményhez az ITextFrame-ben.
- Hozz létre egy új részletobjektumot
- Állítsd be az Escapement tulajdonságot a részletnél 0 és -100 között az alsóindex hozzáadásához. (0 = nincs alsóindex)
- Adj be némi szöveget a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Portion) számára, majd add hozzá a bekezdés részletgyűjteményéhez.
- Mentse a prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább található.

```java
// Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
Presentation pres = new Presentation();
try {
    // Diát lekér
    ISlide slide = pres.getSlides().get_Item(0);

    // Szövegdobozt hoz létre
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Bekezdés létrehozása felsőindex szöveghez
    IParagraph superPar = new Paragraph();

    // Részlet létrehozása normál szöveggel
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Részlet létrehozása felsőindex szöveggel
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Bekezdés létrehozása alsóindex szöveghez
    IParagraph paragraph2 = new Paragraph();

    // Részlet létrehozása normál szöveggel
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Részlet létrehozása alsóindex szöveggel
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Bekezdések hozzáadása a szövegdobozhoz
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Megmarad a felső- és alsóindex formázás a PDF vagy más formátumokba exportálás során?**

Igen, az Aspose.Slides megfelelően megőrzi a felső- és alsóindex formázást, amikor a prezentációkat PDF, PPT/PPTX, képek és egyéb támogatott formátumokba exportálja. A speciális formázás minden kimeneti fájlban érintetlen marad.

**Kombinálható a felső- és alsóindex más formázási stílusokkal, például félkövérrel vagy dőlt betűvel?**

Igen, az Aspose.Slides lehetővé teszi, hogy különböző szövegstílusokat keverj egyetlen szövegrészben. Engedélyezheted a félkövér, dőlt, aláhúzott formátumot, és egyszerre alkalmazhatod a felső- vagy alsóindexet a megfelelő [PortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portionformat/) tulajdonságok beállításával.

**Működik a felső- és alsóindex formázás táblázatokban, diagramokban vagy SmartArt-ban lévő szövegre?**

Igen, az Aspose.Slides támogatja a formázást a legtöbb objektumban, beleértve a táblázatokat és diagramelemeket is. SmartArt használatakor hozzá kell férned a megfelelő elemekhez (például a [SmartArtNode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/smartartnode/)) és azok szövegtárolóihoz, majd hasonló módon kell konfigurálnod a [PortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portionformat/) tulajdonságokat.