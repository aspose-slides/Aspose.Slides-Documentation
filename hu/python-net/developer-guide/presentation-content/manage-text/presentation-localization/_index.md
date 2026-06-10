---
title: Automatizálja a prezentációk lokalizációját Pythonban
linktitle: Prezentáció lokalizáció
type: docs
weight: 100
url: /hu/python-net/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás ellenőrzés
- nyelvi azonosító
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Automatizálja a PowerPoint és OpenDocument diák lokalizációját Pythonban az Aspose.Slides segítségével, gyakorlati kódrészletekkel és tippekkel a gyorsabb globális bevezetéshez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan állítható be a `language_id` egy prezentáció szövegéhez az Aspose.Slides használatával. Megmutatja, hogyan nyissunk meg egy prezentációt, adjunk hozzá egy alakzatot szöveggel, rendeljünk nyelvi azonosítót a szövegrészhez, és mentsük el az eredményt PPTX fájlként.

## **A bemutató és az alakzat szövegének nyelvének módosítása**
- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
- Szerezze be egy dia hivatkozását az Index használatával.
- Adjon hozzá egy Rectangle típusú AutoShape-et a diára.
- Adjon szöveget a TextFrame-hez.
- Állítsa be a nyelvi azonosítót a szöveghez.
- Mentse a bemutatót PPTX fájlként.

Az alábbi példában bemutatjuk a fenti lépések megvalósítását.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Előidéz-e a language ID automatikus szövegfordítást?**

Nem. A [language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) az Aspose.Slides-ben a helyesírás- és nyelvhelyesség-ellenőrzés nyelvét tárolja, de nem fordítja le vagy módosítja a szöveg tartalmát. Ez egy metaadat, amelyet a PowerPoint a helyesírás-ellenőrzéshez ért meg.

**A language ID befolyásolja-e a szóelválasztást és a sortöréseket a renderelés során?**

Az Aspose.Slides-ben a [language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) a helyesírási ellenőrzésre szolgál. A szóelválasztás minősége és a sortörés elsősorban a [megfelelő betűkészletek](/slides/hu/python-net/powerpoint-fonts/) rendelkezésre állásától, valamint az írásrendszer elrendezési/sortörés beállításaitól függ. A helyes megjelenítés biztosításához tegye elérhetővé a szükséges betűkészleteket, konfigurálja a [betűkészlet-helyettesítési szabályokat](/slides/hu/python-net/font-substitution/), és/vagy [ágyazza be a betűkészleteket](/slides/hu/python-net/embedded-font/) a prezentációba.

**Beállíthatok különböző nyelveket egyetlen bekezdésen belül?**

Igen. A [language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) a szövegrész szintjén kerül alkalmazásra, így egyetlen bekezdés több nyelvet is keverhet különálló helyesírási beállításokkal.