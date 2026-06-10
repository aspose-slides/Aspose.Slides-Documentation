---
title: Automatizálja a prezentációk lokalizálását C++-ban
linktitle: Prezentáció lokalizálás
type: docs
weight: 100
url: /hu/cpp/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- nyelvi azonosító
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Automatizálja a PowerPoint és OpenDocument diák lokalizálását C++-ban az Aspose.Slides segítségével, gyakorlati kódmintákkal és tippekkel a gyorsabb globális bevezetés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan állítható be a `LanguageId` egy prezentáció szövegéhez az Aspose.Slides használatával. Megmutatja, hogyan nyitható meg egy prezentáció, hogyan adható hozzá szöveges alakzat, hogyan rendelhető nyelvi azonosító egy szövegrészlethez, és hogyan menthető az eredmény PPTX fájlként.

## **Nyelv módosítása egy prezentáció és alakzat szövegéhez**
- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
- Szerezze meg egy dia hivatkozását az Indexe alapján.
- Adjon hozzá egy Rectangle típusú AutoShape-t a diához.
- Adjon szöveget a TextFrame-hez.
- Állítsa be a Language Id-t a szövegre.
- Írja ki a prezentációt PPTX fájlként.

A fenti lépések megvalósítása az alábbi példában látható.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **GYIK**

**Kiváltja-e a nyelvi ID az automatikus szövegfordítást?**

Nem. A [Language ID](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/) az Aspose.Slides-ben a helyesírás- és nyelvtani ellenőrzéshez tárolja a nyelvet, de nem fordítja le vagy módosítja a szövegtartalmat. Ez metaadat, amelyet a PowerPoint a korrektúrához ért meg.

**Befolyásolja-e a nyelvi ID a szóelválasztást és a sortöréseket a megjelenítés során?**

Az Aspose.Slides-ben a [Language ID](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/) a korrektúrára szolgál. A szóelválasztás minősége és a sortörés elsősorban a [megfelelő betűtípusok](/slides/hu/cpp/powerpoint-fonts/) rendelkezésre állásától, valamint a írásrendszer elrendezési/sortörési beállításaitól függ. A helyes megjelenítés biztosításához tegye elérhetővé a szükséges betűtípusokat, konfigurálja a [betűtípus-helyettesítési szabályokat](/slides/hu/cpp/font-substitution/), és/vagy [ágyazzon be betűtípusokat](/slides/hu/cpp/embedded-font/) a prezentációba.

**Beállíthatok-e különböző nyelveket egyetlen bekezdésen belül?**

Igen. A [Language ID](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/) a szövegrészlet szintjén alkalmazható, így egyetlen bekezdés több nyelvet is keverhet különálló korrektúra beállításokkal.