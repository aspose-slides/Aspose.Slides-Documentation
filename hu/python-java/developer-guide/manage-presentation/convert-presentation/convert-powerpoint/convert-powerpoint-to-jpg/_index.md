---
title: PPT és PPTX konvertálása JPG-re Pythonban
linktitle: PowerPoint JPG-re
type: docs
weight: 60
url: /hu/python-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PowerPoint JPG-re
- PPT JPG-re
- PPTX JPG-re
- dia mentése JPG-ként
- PPT exportálása JPG-re
- PPTX exportálása JPG-re
- Python
- Java
- Aspose.Slides
description: "PowerPoint (PPT, PPTX) diákat JPG képekké konvertálja Pythonon keresztül Java használatával. Állítson be egyedi képméreteket, és renderelje a jegyzeteket és megjegyzéseket az Aspose.Slides segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy a PowerPoint és OpenDocument prezentációkat (PPT, PPTX és ODP) JPEG képekké konvertálja. Exportálhat minden diát vagy egy kiválasztott diát, hogy miniaturákat készítsen, prezentációs megjelenítőt építsen, vagy diaképeket ágyazzon be egy weboldalba vagy alkalmazásba.

## **PowerPoint PPT/PPTX konvertálása JPG-re**

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) segítségével.  
2. Hozza vissza a diák listáját a [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) használatával.  
3. Hívja meg a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) függvényt vízszintes és függőleges méretezési tényezőkkel, hogy minden diához képet generáljon.  
4. Mentse el minden renderelt képet JPEG formátumban az [ImageFormat.Jpeg](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/#Jpeg) használatával, majd szabadítsa fel a kép erőforrásait.

{{% alert color="info" title="Megjegyzés" %}}
A JPG formátumba exportálás minden dia számára külön képet hoz létre. Mentse a renderelt képet, ahelyett, hogy a prezentációt közvetlenül képfájlformátumba mentené.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint PPT/PPTX konvertálása JPG-re testreszabott méretekkel**

Számolja ki a vízszintes és függőleges méretezési tényezőket a kívánt pixelméretek és az eredeti diaméret alapján, majd adja át őket a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) függvénynek. A következő példa 1200 × 800 pixel méretű képet céloz meg minden diára.

Különböző méretezési tényezők használata nyújthatja a diát. Az oldalarány megőrzéséhez használjon ugyanazt a tényezőt mindkét tengelyen; az eredő szélesség és magasság ezután az eredeti dia arányait követi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Megjegyzések renderelése diák képként való mentésekor**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) osztályt a jegyzetek és megjegyzések beállításához, és alkalmazza a elrendezést a [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) segítségével. Ez a példa a jegyzeteket alul helyezi, a nem illeszkedő jegyzeteket csonkolja, és a megjegyzéseket jobbra, 200 pixel széles területen jeleníti meg. Minden renderelt diát JPG képként ment.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **GYIK**

**Átalakíthatok több diát vagy prezentációt JPG-re?**

Igen. A példák végigjárják az összes diát, és minden diához egy JPG-t mentenek. Több prezentáció feldolgozásához ismételje meg a konverziót minden bemeneti fájlra, és használjon külön kimeneti mappákat vagy egyedi fájlneveket a képek felülírásának elkerülése érdekében.

**A diagramok, SmartArt, táblázatok és alakzatok szerepelnek a képekben?**

Ezek az objektumok a dia részeként kerülnek renderelésre. Győződjön meg arról, hogy a prezentációban használt betűtípusok elérhetők a konverziós környezetben, hogy csökkentse a betűtípuscsere okozta eltéréseket.

**Hogyan csökkenthetem a memóriahasználatot nagy prezentációk exportálásakor?**

Kezelje a képeket egyesével, minden kép mentése után szabadítsa fel, és kerüljön el indokolatlanul nagy kimeneti méreteket. A memóriaigény a dia tartalmától és a kép méretétől függ.

## **Lásd még**

- [PowerPoint konvertálása PNG-re](/slides/hu/python-java/convert-powerpoint-to-png/).
- [Dia renderelése SVG képként](/slides/hu/python-java/render-a-slide-as-an-svg-image/).