---
title: Vonalalakzatok létrehozása prezentációkban Python segítségével
linktitle: Vonal
type: docs
weight: 50
url: /hu/python-net/line/
keywords:
- vonal
- vonal létrehozása
- vonal hozzáadása
- egyszerű vonal
- vonal konfigurálása
- vonal testreszabása
- szaggatott stílus
- nyílfej
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet manipulálni a vonalformázást PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Fedezze fel a tulajdonságokat, metódusokat és példákat."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET támogatja különféle alakzatok hozzáadását a diákhoz. Ebben a témában a alakzatokkal való munka elkezdéséhez vonalakat adunk a diákhoz. Az Aspose.Slides használatával a fejlesztők nem csak egyszerű vonalakat hozhatnak létre, hanem néhány díszes vonalat is rajzolhatnak a diákra.

## **Egyszerű vonalak létrehozása**

Használja az Aspose.Slides-et egy egyszerű vonal hozzáadásához egy diára, mint egyszerű elválasztó vagy csatlakozó. Egy egyszerű vonal hozzáadásához egy kiválasztott diához egy prezentációban kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát a diára index alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) típusú `LINE` objektumot a `add_auto_shape` metódus használatával a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) objektumon.
1. Mentse a prezentációt PPTX fájlként.

Az alábbi példában egy vonalat adunk hozzá a prezentáció első diájához.

```py
import aspose.slides as slides

# A Presentation osztály példányosítása.
with slides.Presentation() as presentation:

    # Az első dia lekérése.
    slide = presentation.slides[0]

    # LINE típusú automatikus alakzat hozzáadása.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Nyíl alakú vonalak létrehozása**

Az Aspose.Slides lehetővé teszi a vonal tulajdonságainak beállítását, hogy vizuálisan vonzóbbá váljanak. Az alábbiakban néhány vonaltulajdonságot konfigurálunk, hogy nyílnak tűnjön. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) típusú `LINE` objektumot a `add_auto_shape` metódus használatával a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) objektumon.
1. Állítsa be a [vonalstílus](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linestyle/) értékét.
1. Állítsa be a vonalvastagságot.
1. Állítsa be a vonal [szaggatott stílusát](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linedashstyle/).
1. Állítsa be a vonal kezdőpontjának [nyílfej stílusát](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linearrowheadstyle/) és hosszát.
1. Állítsa be a vonal végpontjának [nyílfej stílusát](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linearrowheadstyle/) és hosszát.
1. Mentse a prezentációt PPTX fájlként.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# A Presentation osztály példányosítása, amely a PPTX fájlt képviseli.
with slides.Presentation() as presentation:
    # Az első dia lekérése.
    slide = presentation.slides[0]

    # LINE típusú automatikus alakzat hozzáadása.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # A vonal formázásának alkalmazása.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # A prezentáció mentése PPTX fájlként.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Átalakíthatok egy egyszerű vonalat csatlakozóvá, hogy "rögzüljön" az alakzatokhoz?**

Nem. Egy egyszerű vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) típusú [LINE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapetype/)) nem válik automatikusan csatlakozóvá. Ahhoz, hogy rögzüljön az alakzatokhoz, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/python-net/aspose.slides/connector/) típust és a [megfelelő API-kat](/slides/hu/python-net/connector/) a kapcsolatokhoz.

**Mit tegyek, ha egy vonal tulajdonságai a témából öröklődnek, és nehéz meghatározni a végső értékeket?**

[Olvassa el a hatékony tulajdonságokat](/slides/hu/python-net/shape-effective-properties/) a [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ilinefillformateffectivedata/) osztályokon keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusokat.

**Zárolhatom a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [zárolási objektumokat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/auto_shape_lock/) biztosítanak, amelyek lehetővé teszik a [szerkesztési műveletek tiltását](/slides/hu/python-net/applying-protection-to-presentation/).