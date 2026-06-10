---
title: PowerPoint-diák PNG-re konvertálása Pythonban
linktitle: Dia PNG-re
type: docs
weight: 30
url: /hu/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása PNG-re
- prezentáció konvertálása PNG-re
- dia konvertálása PNG-re
- PPT konvertálása PNG-re
- PPTX konvertálása PNG-re
- ODP konvertálása PNG-re
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- ODP PNG-re
- Python
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációkat gyorsan magas minőségű PNG képekké konvertál az Aspose.Slides for Python via .NET segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET egyszerűvé teszi a PowerPoint‑prezentációk PNG‑re konvertálását. Betölti a prezentációt, végig iterál a diákon, minden diához raster képet renderel, és az eredményt PNG fájlként menti. Ez ideális a diaelőnézetek létrehozásához, diák weboldalakba ágyazásához, vagy statikus eszközök előállításához a további feldolgozáshoz.

## **Diák konvertálása PNG‑re**

Ez a rész a legegyszerűbb példát mutatja be a PowerPoint‑prezentáció PNG‑képekké konvertálására az Aspose.Slides for Python via .NET használatával.

Kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt.
2. Szerezzen be egy diát a `Presentation.slides` gyűjteményből (lásd a [Slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) osztályt).
3. Használja a `Slide.get_image` metódust a dia előnézeti képének (thumbnail) generálásához.
4. Használja a `Presentation.save` metódust a dia előnézeti képének PNG formátumban történő mentéséhez.

Ez a Python kód bemutatja, hogyan konvertáljon egy PowerPoint‑prezentációt PNG‑re:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Diák konvertálása PNG‑re egyéni méretekkel**

A diák egyéni méretarányban történő PNG‑exportálásához hívja meg a `Slide.get_image` metódust vízszintes és függőleges méretarány‑paraméterekkel. Ezek a szorzók a kimenetet a dia eredeti méreteihez képest méretezik – például a `2.0` megduplázza a szélességet és a magasságot is. Az arány megőrzéséhez használjon egyenlő értékeket a `scale_x` és `scale_y` paraméterekhez.

Ez a Python kód demonstrálja a leírt műveletet:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Diák konvertálása PNG‑re egyéni mérettel**

Ha meghatározott méretű PNG‑fájlokat szeretne előállítani, adja meg a kívánt `width` és `height` értékeket. Az alábbi kód bemutatja, hogyan konvertáljon egy PowerPoint‑prezentációt PNG‑re a képméret megadásával:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Érdemes kipróbálni az Aspose ingyenes **PowerPoint‑to‑PNG konvertereit** – a [PPTX to PNG](https://products.aspose.app/slides/hu/conversion/pptx-to-png) és a [PPT to PNG](https://products.aspose.app/slides/hu/conversion/ppt-to-png) linkeken. Ezek élő megvalósítást nyújtanak az ezen az oldalon leírt folyamathoz.
{{% /alert %}}

## **GYIK**

**Hogyan exportálhatok csak egy adott alakzatot (például diagramot vagy képet) a teljes dia helyett?**

Az Aspose.Slides támogatja a [különálló alakzatok előnézeti képeinek generálását](/slides/hu/python-net/create-shape-thumbnails/); egy alakzatot PNG‑képként is renderelhet.

**Támogatott a párhuzamos konvertálás szerveren?**

Igen, de ne [ossza meg](/slides/hu/python-net/multithreading/) egyetlen prezentációpéldányt a szálak között. Használjon külön példányt szálanként vagy folyamatanként.

**Mik a próbaverzió korlátozásai PNG exportáláskor?**

Az értékelő mód vízjelet tesz a kimeneti képekre, és a [további korlátozások](/slides/hu/python-net/licensing/) érvényesek, amíg a licenc nem kerül alkalmazásra.