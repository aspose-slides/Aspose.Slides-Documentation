---
title: PowerPoint diák átalakítása PNG-re Pythonban
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint átalakítása PNG-re
- prezentáció átalakítása PNG-re
- dia átalakítása PNG-re
- PPT átalakítása PNG-re
- PPTX átalakítása PNG-re
- ODP átalakítása PNG-re
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- ODP PNG-re
- Python
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument prezentációkat magas minőségű PNG képekké gyorsan az Aspose.Slides for Python via .NET használatával, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a bemutatódiapozitívákat PNG képekké konvertálni az Aspose.Slides for Python via .NET használatával. Betöltheti a prezentációkat PPT, PPTX és ODP formátumokban, megjelenítheti az egyes diát, és külön PNG képként mentheti el.

Az alábbi példák bemutatják a megjelenítést alapértelmezett méretezésben, a méretezés növelését, a kimeneti méretek pixelben való megadását, valamint egy színátmenetes renderelési stílus kiválasztását.

## **PowerPoint konvertálása PNG-re**

Töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal, és érje el a diát a [diák](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) gyűjteményen keresztül. A példa minden egyes diát a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) paraméterek nélküli hívásával rendereli, ezzel egy bélyegképet hozva létre. Ezután a [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) metódust hívja a [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) formátummal, hogy az egyes renderelt diák PNG képként legyenek mentve.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
A paraméter nélküli [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) túlterhelés 0,2-s méretezésben renderel. Például egy 720 × 540 pont méretű dia 144 × 108 pixeles bélyegképet eredményez. A kimeneti méretek szabályozásához használja a méretarányokkal vagy egy explicit képmérettel rendelkező túlterheléseket, ahogy az alább látható.
{{% /alert %}}

## **PowerPoint konvertálása PNG-re egyéni dimenziókkal**

Adjon meg vízszintes és függőleges méretarány‑faktorokat a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) hívásához a renderelt méretek szabályozásához. Ebben a példában mindkét tényező 2, így egy 720 × 540 pont méretű dia 1440 × 1080 pixeles képet eredményez. Az egyenlő méretarány‑faktorok megőrzik a dia képarányát. Minden képet a [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) metódus PNG formátumban ment.

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **PowerPoint konvertálása PNG-re egyéni mérettel**

A kimeneti méretek pixelben való megadásához adjon át egy méretet a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) hívásához a méretarány‑faktorok helyett. Ez a példa minden diát 960 × 720 pixelben renderel, és az eredményt a [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) menti. Válasszon olyan méreteket, amelyek megfelelnek a dia képarányának, hogy elkerülje a kép nyújtását.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Válasszon egy színátmenetes renderelési stílust**

Tegyük fel, hogy egy dia színátmenetes kitöltéseket tartalmaz, de az exportált PNG‑ben a átmenetek világosabbak vagy más módon eltérnek attól, amit a PowerPointban látsz. Használhatja a [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) tulajdonságot a [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) osztályban, hogy kiválassza, hogyan legyenek renderelve a színátmenetek.

Töltse le a [gradient-styles.pptx](gradient-styles.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Első diája két lineáris színátmenetet tartalmaz: a tetején ciánról narancsra, az alján kékről sárgára. Minden színátmenetnek két állomása van, 0 % és 100 %.

A következő példa betölti ezt a prezentációt, és a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) segítségével mindkét módban rendereli az első diát.

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Az alábbi képek a ugyanazon dia kimenetét mutatják, mindkét színátmenettel minden képen:

| Alapértelmezett | PowerPointUI |
| --- | --- |
| ![Cian‑narancs és kék‑sárga színátmenetek megjelenítve alapértelmezett móddal](gradient-Default.png) | ![Ugyanazok a színátmenetek megjelenítve PowerPointUI móddal](gradient-PowerPointUI.png) |

Ebben a példában a `DEFAULT` világosabb közbülső színeket eredményez, míg a `POWER_POINT_UI` sötétebb közbülső színeket. A különbség a színátmenet színeitől és állomásaitól függ.

Válassza a `DEFAULT`‑et, ha a szabványos Aspose.Slides kimenet megfelel az igényeinek. Próbálja a `POWER_POINT_UI`‑t, ha elsődleges célja a PowerPoint megjelenésének egyezése. Hasonlítsa össze mindkét kimenetet a kívánt eredménnyel; egyik mód sem általánosan előnyösebb.

## **GYIK**

**Hogyan exportálhatok egy adott alakzatot, például diagramot vagy képet, a teljes dia helyett?**

Az Aspose.Slides támogatja az [egyedi alakzatok bélyegképeinek létrehozását](/slides/hu/python-net/create-shape-thumbnails/), amely lehetővé teszi egy alakzat PNG képpé renderelését.

**Támogatott-e a párhuzamos konvertálás egy szerveren?**

Igen. Használjon külön prezentációs példányt minden szál vagy folyamat számára; [ne osszon meg egyetlen példányt a szálak között](/slides/hu/python-net/multithreading/).

**Milyen korlátozások vannak az értékelő módban PNG exportálásakor?**

Az értékelő mód vízjeleket ad a kimeneti képekhez, és [egyéb korlátozásokat](/slides/hu/python-net/licensing/) alkalmaz, amíg licencet nem telepítenek.