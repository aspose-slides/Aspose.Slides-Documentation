---
title: Szövegrészek kezelése prezentációkban Python használatával
linktitle: Szövegrész
type: docs
weight: 70
url: /hu/python-net/portion/
keywords:
- szövegrész
- szövegrészlet
- szövegkoordináták
- szövegpozíció
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a szövegrészeket PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével, növelve a teljesítményt és a testreszabhatóságot."
---
## **Bevezetés**

A szövegrész egy bekezdésen belül egy meghatározott szövegrészt képvisel, és lehetővé teszi, hogy ezzel a résszel függetlenül dolgozzon a környező tartalomtól. Az Aspose.Slides-ben a részek akkor használhatók, amikor a szövegrész pozícióját kell lekérni, csak a bekezdés egy részére alkalmazni a formázást, vagy a szöveg viselkedését részletesebb szinten szabályozni.

## **A szövegrészek koordinátáinak lekérdezése**

Az [get_coordinates](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/get_coordinates/) metódus hozzá lett adva a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) osztályhoz, amely lehetővé teszi a szövegrészek koordinátáinak lekérését:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a bekezdésen belül egy szövegrészre?**

Igen, [hiperhivatkozás hozzárendelése](/slides/hu/python-net/manage-hyperlinks/) egy egyedi részhez; csak az a rész lesz kattintható, nem az egész bekezdés.

**Hogyan működik a stílus öröklődése: mit felülír egy Portion, és mi származik a Paragraph/TextFrame-ből?**

A Portion szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/)-n, a motor a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/)-ból veszi; ha ott sem van beállítva, akkor a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/theme/)-ból származó stílusból.

**Mi történik, ha a Portion számára megadott betűkészlet hiányzik a célgépen/kiszolgálón?**

[Font substitution rules](/slides/hu/python-net/font-selection-sequence/) érvényesek. A szöveg újraformálódhat: a metrikák, elválasztás és szélesség változhat, ami a pontos pozicionálásnál számít.

**Beállíthatok Portion-specifikus szövegkitöltés átlátszóságot vagy fokozatot a bekezdés többi részétől függetlenül?**

Igen, a szöveg színe, kitöltése és átlátszósága a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/)-szinten eltérhet a szomszédos részeketől.