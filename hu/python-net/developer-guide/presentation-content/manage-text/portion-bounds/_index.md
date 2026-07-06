---
title: Szövegrészlet határainak lekérése prezentációkból Pythonban
linktitle: Részlet határok
type: docs
weight: 47
url: /hu/python-net/portion-bounds/
keywords:
- szövegrészlet határok
- szövegrészlet
- szövegrész
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a szövegrészlet határokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

A szöveg‑részlet egy bekezdésen belüli konkrét szövegdarabot jelöl, és lehetővé teszi, hogy ezt a darabot a környező tartalomtól függetlenül kezelje. Az Aspose.Slides‑ben a részek akkor használhatók, amikor a szövegdarab határait kell lekérni, csak a bekezdés egy részére szeretne formázást alkalmazni, vagy részletesebb szintű szövegviselkedést szeretne szabályozni.

Ez a cikk bemutatja, hogyan lehet a részlet határoló téglalapját lekérni a [Portion.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/get_rect/) használatával. Emellett megmutatja, hogyan lehet a részlet kezdő koordinátáit lekérni a [Portion.get_coordinates](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/get_coordinates/) segítségével. Továbbá kiemeli a gyakori, részletekkel kapcsolatos helyzeteket, például hogyan lehet hiperhivatkozást alkalmazni egyetlen szövegdarabon, hogyan épül fel a formázás a részlet, bekezdés, szövegkeret és téma öröklése során, valamint hogyan kezelhetők azok az esetek, amikor egy megadott betűtípus nem érhető el.

## **Szövegrészlet határoló téglalapjának lekérése**

Használja a [Portion.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/get_rect/) metódust a szövegrészlet határoló téglalapjának lekéréséhez:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Szövegrészlet kezdő koordinátáinak lekérése**

Használja a [Portion.get_coordinates](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/get_coordinates/) metódust a szövegrészlet kezdetének koordinátáinak lekéréséhez:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, az egyes részekhez is [társíthat hiperhivatkozást](/slides/hu/python-net/manage-hyperlinks/) rendelhet; csak az a darab lesz kattintható, nem az egész bekezdés.

**Hogyan működik a stílus öröklődés: mit felülír egy részlet, és mi kerül át a bekezdésből vagy a szövegkeretből?**

A részletszintű tulajdonságok a legmagasabb precedenciával bírnak. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) szintjén, az Aspose.Slides a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) szintjéről veszi át. Ha ott sem van beállítva, akkor az Aspose.Slides a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/theme/) stílusát használja.

**Mi történik, ha egy részlethez megadott betűtípus hiányzik a céleszközön vagy szerveren?**

A [Font substitution rules](/slides/hu/python-net/font-selection-sequence/) érvényesülnek. A szöveg újra tud átalakulni: a metrikák, szóelválasztás és a szélesség változhat, ami a pontos elhelyezés szempontjából fontos.

**Beállíthatok részlet‑specifikus szövegtöltés átlátszóságot vagy fokozatot a bekezdés többi részétől függetlenül?**

Igen, a szöveg színe, kitöltése és átlátszósága a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) szintjén eltérhet a szomszédos daraboktól.