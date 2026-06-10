---
title: Felső- és alsó index kezelése prezentációkban Androidon
linktitle: Felső- és alsó index
type: docs
weight: 80
url: /hu/androidjava/superscript-and-subscript/
keywords:
- felső index
- alsó index
- felső index hozzáadása
- alsó index hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "A felső- és alsó index kezelésének elsajátítása az Aspose.Slides Android verziójában Java segítségével, és prezentációinak professzionális szövegformázással való feljavítása a maximális hatás érdekében."
---
## **Áttekintés**

Az Aspose.Slides funkciókat biztosít a felső index és alsó index szöveg beillesztéséhez PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkba. Akár kémiai képleteket, matematikai egyenleteket szeretne kiemelni, akár lábjegyzetekkel kívánja megjegyzéseket fűzni, ezek a speciális formázási lehetőségek segítenek a tisztaság és pontosság megőrzésében. Ebben a cikkben megtanulja, hogyan alkalmazza zökkenőmentesen a felső és alsó index stílusokat, és biztosíthatja a professzionális eredményeket minden dián.

## **Felső és alsó index szöveg kezelése**
Felső vagy alsó index szöveget bármely bekezdés részéhez hozzáadhat. Az Aspose.Slides szövegkeretben felső vagy alsó index szöveg hozzáadásához a [**setEscapement**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) metódust kell használni a [PortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PortionFormat) osztályban.

Ez a tulajdonság visszaadja vagy beállítja a felső vagy alsó index szöveget (érték -100 % (alsó index) és 100 % (felső index) között). Például:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze meg a diák hivatkozását az Index használatával.
- Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) [Rectangle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeType#Rectangle) típusú elemet a diára.
- Hozzáférés a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrame) objektumhoz, amely a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape)-hez tartozik.
- Törölje a meglévő bekezdéseket
- Hozzon létre egy új bekezdésobjektumot a felső index szöveg tárolásához, és adja hozzá az [IParagraphs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) gyűjteményhez a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrame)-en belül.
- Hozzon létre egy új részt (portion) objektumot
- Állítsa be az Escapement tulajdonságot a részhez 0 és 100 között a felső index hozzáadásához. (0 jelent felső index hiányát)
- Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Portion) számára, majd adja hozzá a bekezdés részgyűjteményéhez.
- Hozzon létre egy új bekezdésobjektumot az alsó index szöveg tárolásához, és adja hozzá az IParagraphs gyűjteményhez az ITextFrame-ben.
- Hozzon létre egy új részt (portion) objektumot
- Állítsa be az Escapement tulajdonságot a részhez 0 és -100 között az alsó index hozzáadásához. (0 jelent alsó index hiányát)
- Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Portion) számára, majd adja hozzá a bekezdés részgyűjteményéhez.
- Mentse a prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább látható.

```java
// Hozzon létre egy Presentation osztályt, amely egy PPTX-et képvisel
    // Szerezze meg a diát
    // Hozzon létre egy szövegdobozt
    // Hozzon létre egy bekezdést a felső index szöveghez
    // Hozzon létre egy részt szokványos szöveggel
    // Hozzon létre egy részt felső index szöveggel
    // Hozzon létre egy bekezdést az alsó index szöveghez
    // Hozzon létre egy részt szokványos szöveggel
    // Hozzon létre egy részt alsó index szöveggel
    // Adja hozzá a bekezdéseket a szövegdobozhoz
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Create paragraph for superscript text
    IParagraph superPar = new Paragraph();

    // Create portion with usual text
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Create portion with superscript text
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Create paragraph for subscript text
    IParagraph paragraph2 = new Paragraph();

    // Create portion with usual text
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Create portion with subscript text
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Add paragraphs to text box
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Megmarad a felső és alsó index formázás PDF vagy más formátumra exportáláskor?**

Igen, az Aspose.Slides megfelelően megőrzi a felső és alsó index formázást a prezentációk PDF, PPT/PPTX, képek és más támogatott formátumokba történő exportálásakor. A speciális formázás minden kimeneti fájlban változatlan marad.

**Kombinálható a felső és alsó index más formázási stílusokkal, például félkövérrel vagy dőlt betűvel?**

Igen, az Aspose.Slides lehetővé teszi különböző szövegstílusok keverését egyetlen szövedrészben. Bekapcsolhatja a félkövér, dőlt, aláhúzott stílusokat, és egyidőben alkalmazhatja a felső vagy alsó indexet a megfelelő tulajdonságok [PortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portionformat/) osztályban történő beállításával.

**Működik a felső és alsó index formázás táblázatok, diagramok vagy SmartArt szövegeiben?**

Igen, az Aspose.Slides támogatja a formázást a legtöbb objektumban, beleértve a táblázatokat és diagramelemeket is. SmartArt használatakor hozzá kell férnie a megfelelő elemekhez (például a [SmartArtNode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/smartartnode/)) és azok szövegtárolóihoz, majd hasonló módon be kell állítania a [PortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portionformat/) tulajdonságait.