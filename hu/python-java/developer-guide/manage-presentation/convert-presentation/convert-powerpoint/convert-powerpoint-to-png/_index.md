---
title: PowerPoint diák konvertálása PNG-re Pythonban
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- Python
- Java
- Aspose.Slides
description: "PowerPoint diák konvertálása PNG képekké Pythonban Java segítségével. PPT, PPTX és ODP prezentációk exportálása egyedi méretezéssel vagy pontos képméretekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a bemutatódiákot PNG képekké konvertálni az Aspose.Slides for Python via Java segítségével. Betöltheti a bemutatókat olyan formátumokban, mint a PPT, PPTX és ODP, renderelheti az egyes diát, és külön PNG képként mentheti.

Az alábbi példák az alapértelmezett méretezés szerinti renderelést, a méretezés növelését, a kimeneti méretek pixelben megadását és a gradient renderelési stílus kiválasztását mutatják be.

## **PowerPoint konvertálása PNG-re**

Töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal, és érje el a diákat a [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) gyűjteményen keresztül. A példa minden diát a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) paraméterek nélküli verziójával renderel egy bélyegkép létrehozásához. Ezután meghívja az [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metódust a [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) használatával, hogy minden renderelt diát PNG képként mentse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
A paraméter nélküli [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) túlterhelés 0,2 méretezésben renderel. Például egy 720 × 540 pont méretű dia 144 × 108 pixeles bélyegképet eredményez. A kimeneti méretek szabályozásához használja a méretarányokkal vagy egy explicit képmérettel rendelkező túlterheléseket, ahogy alább látható.
{{% /alert %}}

## **PowerPoint konvertálása PNG-re egyéni méretekkel**

Adjon meg vízszintes és függőleges méretarányokat a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) metódusnak a renderelt méretek szabályozásához. Ebben a példában mindkét arány 2, így egy 720 × 540 pont méretű dia 1440 × 1080 pixeles képet eredményez. Az egyenlő méretarányok megőrzik a dia képarányát. Minden renderelt képet PNG formátumban mentünk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint konvertálása PNG-re egyéni mérettel**

A kimeneti méretek pixelben történő megadásához adjon meg egy méretet a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) metódusnak a méretarányok helyett. Ez a példa minden diát 960 × 720 pixelben renderel, és az eredményt PNG formátumban menti. Válasszon olyan méreteket, amelyek megfelelnek a dia képarányának, hogy elkerülje a kép nyúlását.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Gradient renderelési stílus kiválasztása**

Tegyük fel, hogy egy dia gradient kitöltéseket tartalmaz, de az exportált PNG-ben a átmenetek könnyebbek vagy másként eltérnek attól, amit a PowerPointban lát. Használhatja a [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) metódust, amelyet a [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) örököl, a gradientek renderelésének módjának kiválasztásához.

Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első dia két lineáris gradienst tartalmaz: ciánról narancssárgára felül, valamint kékről sárgára alul. Minden gradientnek két színállapítása van, 0 % és 100 % értéknél.

A következő példa betölti ezt a bemutatót, és mindkét módban rendereli az első diát a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) segítségével.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Az alábbi képek a ugyanabból a diából származó kimenetet mutatják, mindkét gradient mindegyik képen:

| Default | PowerPointUI |
| --- | --- |
| ![Cianról narancssárgára és kékről sárgára gradientek a Default rendereléssel](gradient-Default.png) | ![Ugyanazok a gradientek a PowerPointUI rendereléssel](gradient-PowerPointUI.png) |

Ebben a példában a `Default` világosabb köztes színeket eredményez, míg a `PowerPointUI` sötétebb köztes színeket. A különbség a gradient színeitől és színállapításaitól függ.

Válassza a `Default`-et, ha a szabványos Aspose.Slides kimenet megfelel az igényeinek. Próbálja a `PowerPointUI`-t, ha az a legfontosabb, hogy a megjelenés egyezzen a PowerPointban látottal. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem általánosan előnyösebb.

## **GYIK**

**Hogyan exportálhatok egy meghatározott alakzatot, például egy diagramot vagy képet, a teljes dia helyett?**

Az Aspose.Slides támogatja a [miniaturek generálása egyedi alakzatokhoz](/slides/hu/python-java/create-shape-thumbnails/), amely lehetővé teszi egy alakzat PNG képként történő renderelését.

**Támogatott a párhuzamos konvertálás egy szerveren?**

Igen. Használjon külön bemutatópéldányt minden szál vagy folyamat számára; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/python-java/multithreading/).

**Mik a kiértékelési korlátozások PNG-exportálásnál?**

Az értékelési mód a kimeneti képekre vízjelet helyez, és [további korlátozásokat](/slides/hu/python-java/licensing/) alkalmaz, amíg a licenc nincs aktiválva.