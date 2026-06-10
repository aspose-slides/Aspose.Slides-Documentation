---
title: Prezentáció lokalizáció automatizálása .NET-ben
linktitle: Prezentáció lokalizáció
type: docs
weight: 100
url: /hu/net/presentation-localization/
keywords:
- nyelvváltás
- helyesírás-ellenőrzés
- nyelvi azonosító
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Automatizálja a PowerPoint és OpenDocument diák lokalizációját .NET-ben az Aspose.Slides segítségével, gyakorlati C# kódrészletek és tippek használatával a gyorsabb globális bevezetés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan állítható be a `LanguageId` a prezentáció szövegéhez az Aspose.Slides használatával. Megmutatja, hogyan nyithatunk meg egy prezentációt, adhatunk hozzá egy szöveges alakzatot, adhatunk nyelvi azonosítót egy szövegrésszel, és menthetjük az eredményt PPTX fájlként.

## **Nyelv módosítása egy prezentációban és az alakzat szövegében**
- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy Rectangle típusú AutoShape-et a diára.
- Adjon szöveget a TextFrame-hez.
- Állítsa be a Language Id-t a szövegre.
- Írja ki a prezentációt PPTX fájlként.

A fenti lépések megvalósítása az alábbi példában látható.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **GYIK**

**A nyelvazonosító automatikus szövegfordítást indít el?**

Nem. Az Aspose.Slides-ben a [LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/languageid/) a helyesírás- és nyelvtani ellenőrzéshez tárolja a nyelvet, de nem fordítja le vagy változtatja meg a szöveg tartalmát. Ez egy metaadat, amelyet a PowerPoint a lektoráláshoz ért meg.

**A nyelvazonosító befolyásolja a szóelválasztást és a sortöréseket a megjelenítés során?**

Az Aspose.Slides-ben a [LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/languageid/) a lektoráláshoz szolgál. A szóelválasztás minősége és a sortörés elsősorban a [megfelelő betűtípusok](/slides/hu/net/powerpoint-fonts/) és a írásrendszer elrendezési/sortörési beállításainak rendelkezésre állásától függ. A helyes megjelenítés érdekében tegye elérhetővé a szükséges betűtípusokat, konfigurálja a [betűtípus helyettesítési szabályokat](/slides/hu/net/font-substitution/), és/vagy [ágyazza be a betűtípusokat](/slides/hu/net/embedded-font/) a prezentációba.

**Beállíthatok különböző nyelveket egyetlen bekezdésen belül?**

Igen. A [LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/languageid/) a szövegrésszel szintjén kerül alkalmazásra, így egyetlen bekezdés több nyelvet keverhet, mindegyiknek saját lektorálási beállításaival.