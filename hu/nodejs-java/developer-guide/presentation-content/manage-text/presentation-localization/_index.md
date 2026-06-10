---
title: Prezentációk lokalizációjának automatizálása JavaScriptben
linktitle: Prezentáció lokalizáció
type: docs
weight: 100
url: /hu/nodejs-java/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- nyelvi azonosító
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizálja a PowerPoint és OpenDocument diák lokalizációját JavaScriptben az Aspose.Slides használatával, gyakorlati kódmintákkal és tippekkel a gyorsabb globális bevezetéshez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet beállítani a `LanguageId` értéket egy prezentáció szövegéhez az Aspose.Slides használatával. Megmutatja, hogyan lehet megnyitni egy prezentációt, szöveggel ellátott alakzatot hozzáadni, nyelvi azonosítót hozzárendelni egy szövegrészhez, és az eredményt PPTX fájlként menteni.

## **A prezentáció és az alakzat szövegének nyelvének módosítása**

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) [Rectangle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeType#Rectangle) típusú alakzatot a diára.
- Adjon szöveget a TextFrame-hez.
- [Setting Language Id](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) a szöveghez.
- Mentse a prezentációt PPTX fájlként.

A fenti lépések megvalósítása az alábbi példában van bemutatva.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**A nyelvi azonosító automatikus szövegfordítást indít el?**

Nem. A [setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) az Aspose.Slides-ben a nyelvet tárolja helyesírás- és nyelvtan-ellenőrzéshez, de nem fordítja le vagy módosítja a szöveg tartalmát. Ez egy metaadat, amelyet a PowerPoint a lektoráláshoz ért meg.

**A nyelvi azonosító befolyásolja a szóelválasztást és a sortöréseket a megjelenítés során?**

Az Aspose.Slides-ben a [setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) a lektorálásra szolgál. A szóelválasztás minősége és a sortörés elsősorban a [megfelelő betűtípusok](/slides/hu/nodejs-java/powerpoint-fonts/) rendelkezésre állásától, valamint az írásrendszer elrendezési/sortörés beállításaitól függ. A helyes megjelenítés érdekében biztosítsa a szükséges betűtípusok elérhetőségét, konfigurálja a [betűtípus-helyettesítési szabályokat](/slides/hu/nodejs-java/font-substitution/), és/vagy [ágyazza be a betűtípusokat](/slides/hu/nodejs-java/embedded-font/) a prezentációba.

**Beállíthatok különböző nyelveket egyetlen bekezdésen belül?**

Igen. A [setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) a szövegrész szintjén alkalmazandó, ezért egy bekezdés több nyelvet is tartalmazhat különálló lektorálási beállításokkal.