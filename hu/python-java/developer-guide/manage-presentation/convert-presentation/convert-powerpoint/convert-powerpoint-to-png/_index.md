---
title: PowerPoint diák konvertálása PNG-re Pythonban
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- bemutató PNG-re
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
description: "PowerPoint diák konvertálása PNG képekké Pythonban Java segítségével. PPT, PPTX és ODP bemutatók exportálása egyedi méretezéssel vagy pontos képméretekkel."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a PowerPoint bemutatókat PNG képekké konvertálni az Aspose.Slides for Python via Java használatával. Betöltheti a PPT, PPTX és ODP fájlokat, megjelenítheti az egyes diát, és külön PNG képként mentheti el.

A példák azt is bemutatják, hogyan lehet a kimeneti méreteket skálázási tényezőkkel vagy pontos szélesség és magasság megadásával szabályozni. Minden példa elindítja a Java virtuális gépet, ha szükséges, és a használat után felszabadítja a bemutató és a kép erőforrásait.

## **PowerPoint konvertálása PNG-re**

1. Töltse be a bemeneti fájlt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal.  
2. Hozza elő a diákat a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) segítségével.  
3. Renderelje az egyes diát a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) használatával.  
4. Mentse az egyes renderelt képeket a [ImageFormat.Png](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/#Png) használatával, majd szabadítsa fel azok erőforrásait.

A következő Python példa az összes diát az alapértelmezett méretükben exportálja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint konvertálása PNG-re egyéni skálával**

Adjon át vízszintes és függőleges skálázási tényezőket a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) metódusnak a kimeneti méretek növeléséhez vagy csökkentéséhez. Például egy 720 × 540 pont méretű dia, amelyet 2-es skálafaktorral mindkét tengelyen renderelnek, 1440 × 1080 képpontos képet eredményez.

Azonos skálafaktorok használatával megőrizhető a dia méretarányai. Különböző tényezők a diát vízszintesen vagy függőlegesen nyújtják.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint konvertálása PNG-re egyedi mérettel**

A pontos képpontméretek megadásához adjon át egy Java `Dimension` objektumot a kívánt szélességgel és magassággal a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) metódusnak. Válasszon olyan méreteket, amelyek az eredeti dia arányával megegyeznek, hogy elkerülje a torzulást.

A következő példa minden diát 960 × 720 képpontos PNG képként ment el:

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
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **GYIK**

**Exportálhatok egy adott alakzatot, például egy diagramot vagy képet, a teljes dia helyett?**  
Igen. Az Aspose.Slides támogatja a [különálló alakzatok előnézeti képeinek generálását](/slides/hu/python-java/create-shape-thumbnails/), amelyeket PNG képként menthet.

**Konvertálhatok bemutatókat párhuzamosan egy szerveren?**  
Használjon külön bemutató példányt minden szál vagy folyamat számára, és alkalmazzon egyedi kimeneti útvonalakat a fájlok felülírásának elkerülése érdekében. Ne osszon meg bemutató példányt a szálak között. Lásd a [Multithreading](/slides/hu/python-java/multithreading/) oldalt.

**Mik a próba-verzió korlátai PNG-re exportáláskor?**  
Az értékelési mód vízjel hozzáadásával és [egyéb korlátozások](/slides/hu/python-java/licensing/) alkalmazásával jelöli a kimeneti képeket. Licenc alkalmazásával eltávolíthatók ezek a korlátok.