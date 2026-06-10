---
title: Felső és alsóindex kezelése prezentációkban JavaScript használatával
linktitle: Felső és alsóindex
type: docs
weight: 80
url: /hu/nodejs-java/superscript-and-subscript/
keywords:
- felsőindex
- alsóindex
- felsőindex hozzáadása
- alsóindex hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Bővítse tudását a felső és alsóindex kezelésében az Aspose.Slides Node.js-hez Java-val, és emelje prezentációit professzionális szövegformázással a maximális hatás érdekében."
---
## **Áttekintés**

Az Aspose.Slides funkciókat biztosít a felső és alsó indexű szöveg beillesztéséhez a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkba. Akár kémiai képleteket, matematikai egyenleteket szeretne kiemelni, akár lábjegyzetekkel kívánja megjegyzéseket fűzni a tartalomhoz, ezek a speciális formázási lehetőségek segítenek az átláthatóság és precizitás megőrzésében. Ebben a cikkben megtanulja, hogyan alkalmazhatja zökkenőmentesen a felső‑ és alsóindex stílusokat, és biztosíthatja a professzionális eredményeket minden dián.

## **Felső‑ és alsóindex szöveg kezelése**

Bármely bekezdés részébe hozzáadhat felső‑ vagy alsóindex szöveget. Az Aspose.Slides szövegdobozában felső‑ vagy alsóindex szöveg hozzáadásához a [**setEscapement**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) metódust kell használni a [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PortionFormat) osztályból.

Ez a tulajdonság visszaadja vagy beállítja a felső‑ vagy alsóindex szöveget (érték -100 % (alsóindex) és 100 % (felsőindex) között). Például:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index segítségével.
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) [Rectangle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeType#Rectangle) típusú alakzatot a diára.
- Érje el a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame) elemet, amely az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape)-hez tartozik.
- Törölje a meglévő bekezdéseket.
- Hozzon létre egy új bekezdésobjektumot a felsőindex szöveg tárolására, és adja hozzá a [Paragraphs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame#getParagraphs--) gyűjteményéhez a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame)-ben.
- Hozzon létre egy új részletobjektumot.
- Állítsa be az Escapement tulajdonságot 0‑tól 100‑ig a felsőindexhez. (0 = nincs felsőindex)
- Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Portion) számára, majd adja hozzá a bekezdés részletgyűjteményéhez.
- Hozzon létre egy új bekezdésobjektumot a alsóindex szöveg tárolására, és adja hozzá az IParagraphs gyűjteményhez az ITextFrame-ben.
- Hozzon létre egy új részletobjektumot.
- Állítsa be az Escapement tulajdonságot 0‑tól -100‑ig a alsóindexhez. (0 = nincs alsóindex)
- Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Portion) számára, majd adja hozzá a bekezdés részletgyűjteményéhez.
- Mentse a prezentációt PPTX fájlként.

A fentiek megvalósítása alább látható.

```javascript
// Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
var pres = new aspose.slides.Presentation();
try {
    // Diát lekérni
    var slide = pres.getSlides().get_Item(0);
    // Szövegdoboz létrehozása
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Bekezdés létrehozása felső indexű szöveghez
    var superPar = new aspose.slides.Paragraph();
    // Részlet létrehozása szokásos szöveggel
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Részlet létrehozása felső indexű szöveggel
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Bekezdés létrehozása alsó indexű szöveghez
    var paragraph2 = new aspose.slides.Paragraph();
    // Részlet létrehozása szokásos szöveggel
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Részlet létrehozása alsó indexű szöveggel
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Bekezdések hozzáadása a szövegdobozhoz
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Megmarad a felső‑ és alsóindex formázás a PDF‑re vagy más formátumokra történő exportáláskor?**

Igen, az Aspose.Slides megfelelően megőrzi a felső‑ és alsóindex formázást a prezentációk PDF, PPT/PPTX, kép és egyéb támogatott formátumokba történő exportálásakor. A speciális formázás minden kimeneti fájlban változatlan marad.

**Kombinálható a felső‑ és alsóindex más formázási stílusokkal, például félkövérrel vagy dőlt betűvel?**

Igen, az Aspose.Slides lehetővé teszi különböző szövegstílusok keverését egyetlen szöveggészben. Bekapcsolhatja a félkövér, dőlt, aláhúzott stb. tulajdonságokat, miközben a felső‑ vagy alsóindexet a megfelelő [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/) beállításokkal alkalmazza.

**Működik a felső‑ és alsóindex formázás táblázatokon, diagramokon vagy SmartArt elemein belül?**

Igen, az Aspose.Slides támogatja a formázást a legtöbb objektumban, beleértve a táblázatokat és diagramelemeket is. SmartArt esetén el kell érnie a megfelelő elemeket (például a [SmartArtNode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartnode/) ) és azok szövegkonténereit, majd a [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/) tulajdonságait hasonló módon beállítani.