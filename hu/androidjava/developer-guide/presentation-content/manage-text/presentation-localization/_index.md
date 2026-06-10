---
title: "Prezentáció lokalizációjának automatizálása Androidon"
linktitle: "Prezentáció lokalizálása"
type: docs
weight: 100
url: /hu/androidjava/presentation-localization/
keywords:
- nyelvváltás
- helyesírás-ellenőrzés
- nyelvi azonosító
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Automatizálja a PowerPoint és OpenDocument diák lokalizációját Java-val az Androidra készült Aspose.Slides segítségével, gyakorlati kódpéldákkal és tippekkel a gyorsabb globális bevezetéshez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan állítható be a `LanguageId` a szöveghez egy bemutatóban az Aspose.Slides használatával. Megmutatja, hogyan nyitható meg egy bemutató, hogyan adható hozzá szöveget tartalmazó alakzat, hogyan rendelhetünk nyelvi azonosítót egy szövegrészhez, és hogyan menthető az eredmény PPTX fájlként.

## **A bemutató és az alakzat szövegének nyelvének módosítása**
- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) [Rectangle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeType#Rectangle) típusú elemet a diára.
- Adjon szöveget a TextFrame-hez.
- [Language Id beállítása](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) a szöveghez.
- Mentse a bemutatót PPTX fájlként.

A fenti lépések megvalósítása alább egy példában van bemutatva.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**A nyelvi azonosító automatikus szövegfordítást vált ki?**

Nem. A [Language ID](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) az Aspose.Slides-ben a helyesírás- és nyelvtan-ellenőrzéshez tárolja a nyelvet, de nem fordítja le vagy nem módosítja a szöveg tartalmát. Ez metaadat, amelyet a PowerPoint a bizonyításhoz ért meg.

**A nyelvi azonosító befolyásolja a szóelválasztást és a sortöréseket a megjelenítés során?**

Az Aspose.Slides-ben a [language ID](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) a bizonyításhoz szolgál. A szóelválasztás minősége és a sortörés elsősorban a [megfelelő betűtípusok](/slides/hu/androidjava/powerpoint-fonts/) elérhetőségétől, valamint az írásrendszerhez tartozó elrendezés/sortörés beállításoktól függ. A helyes megjelenítés biztosításához tegye elérhetővé a szükséges betűtípusokat, konfigurálja a [betűtípus-helyettesítési szabályokat](/slides/hu/androidjava/font-substitution/), és/vagy [ágyazza be a betűtípusokat](/slides/hu/androidjava/embedded-font/) a bemutatóba.

**Beállíthatók különböző nyelvek egyetlen bekezdésen belül?**

Igen. A [Language ID](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) a szövegrész szinten kerül alkalmazásra, ezért egyetlen bekezdésben több nyelv keverhető különálló ellenőrzési beállításokkal.