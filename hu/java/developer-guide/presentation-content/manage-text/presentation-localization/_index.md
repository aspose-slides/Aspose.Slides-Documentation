---
title: Automatizálja a prezentáció lokalizálását Java-ban
linktitle: Prezentáció lokalizációja
type: docs
weight: 100
url: /hu/java/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- nyelvi azonosító
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Automatizálja a PowerPoint és OpenDocument diák lokalizálását Java-ban az Aspose.Slides segítségével, gyakorlati kódmintákkal és tippekkel a gyorsabb globális bevezetés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan állítható be a `LanguageId` a prezentáció szövegéhez az Aspose.Slides használatával. Megmutatja, hogyan nyissunk meg egy prezentációt, adjunk hozzá egy alakzatot szöveggel, rendeljünk nyelvazonosítót egy szövegrészhez, és mentsük el az eredményt PPTX fájlként.

## **Nyelv módosítása egy prezentációban és alakzati szövegben**
- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjá hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) [Rectangle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeType#Rectangle) típusú alakkal a diára.
- Adjon hozzá szöveget a TextFrame-hez.
- [Nyelvi azonosító beállítása](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) a szöveghez.
- Írja a prezentációt PPTX fájlként.

Az alábbi példában a fenti lépések megvalósítása látható.

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

**Azonosítja-e a nyelv ID az automatikus szövegfordítást?**

Nem. A [Language ID](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) az Aspose.Slides-ban a helyesírás- és nyelvtani ellenőrzés nyelvét tárolja, de nem fordítja le vagy módosítja a szöveg tartalmát. Ez metaadat, amelyet a PowerPoint az ellenőrzéshez ért meg.

**A nyelv ID befolyásolja a szóelválasztást és a sortöréseket a renderelés során?**

Az Aspose.Slides-ban a [language ID](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) az ellenőrzéshez szolgál. A szóelválasztás minősége és a sortörés főként a [megfelelő betűtípusok](/slides/hu/java/powerpoint-fonts/) elérhetőségétől, valamint az írásrendszer elrendezés-/sortörésbeállításaitól függ. A helyes renderelés érdekében biztosítsa a szükséges betűtípusok elérhetőségét, konfigurálja a [betűtípus helyettesítési szabályokat](/slides/hu/java/font-substitution/), és/vagy [ágyazzon be betűtípusokat](/slides/hu/java/embedded-font/) a prezentációba.

**Beállíthatok különböző nyelveket egyetlen bekezdésen belül?**

Igen. A [Language ID](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) a szövegrész szintjén alkalmazandó, így egy bekezdésen belül több nyelv keverhető különálló ellenőrzési beállításokkal.