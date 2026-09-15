---
title: Többszálú feldolgozás az Aspose.Slides for Python via Java esetén
linktitle: Többszálú feldolgozás
type: docs
weight: 310
url: /hu/python-java/multithreading/
keywords:
- többszálú feldolgozás
- több szál
- párhuzamos munka
- diák konvertálása
- diák képekké
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Python via Java többszálú feldolgozása felgyorsítja a PowerPoint és OpenDocument feldolgozást. Ismerje meg a hatékony prezentációs munkafolyamatok legjobb gyakorlatait."
---
## **Bevezetés**

Bár a prezentációkkal végzett párhuzamos munka lehetséges (kivéve a feldolgozást, betöltést és klónozást), és általában jól működik, mégis van egy kis esély a helytelen eredményekre, ha a könyvtárat több szálban használja.

Erősen ajánljuk, hogy **ne** használjon egyetlen [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt több szálas környezetben, mert ez kiszámíthatatlan hibákhoz vagy könnyen nem észlelhető hibákhoz vezethet.

Ez **nem** biztonságos betölteni, menteni és/vagy klónozni egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt több szálon. Az ilyen műveletek **nem** támogatottak. Ha ilyen feladatokat kell végrehajtania, a műveleteket több egyetlen szálas folyamat segítségével kell párhuzamosítani – és minden folyamatnak saját prezentációpéldányt kell használnia.

## **Prezentációs diák képekké konvertálása párhuzamosan**

Tegyük fel, hogy minden diát egy PowerPoint prezentációból párhuzamosan szeretnénk PNG képekké konvertálni. Mivel egyetlen [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány használata több szálon nem biztonságos, a prezentáció diákat különálló prezentációkra bontjuk, és a diáket párhuzamosan képekké konvertáljuk, minden prezentációt külön szálban használva. Az alábbi kódrészlet bemutatja, hogyan lehet ezt megtenni.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Kivonja a diát egy külön bemutatóba.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Átalakítja a diát képpé egy külön feladatban.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Várakozik, amíg az összes feladat befejeződik.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **GYIK**

**Szükséges-e minden szálban a licenc beállítását meghívni?**

Nem. Elég egyszer, a folyamat indítása előtt elvégezni, mielőtt a szálak elindulnak. Ha a [license setup](/slides/hu/python-java/licensing/) párhuzamosan hívható meg (például a lusta inicializálás során), szinkronizálja a hívást, mivel a licenc beállítási metódus önmagában nem szálbiztos.

**Átadhatok [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) vagy [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) objektumokat szálak között?**

Élő (live) prezentációobjektumok szálak közötti átadása nem ajánlott: használjon minden szálhoz független példányt, vagy előre hozzon létre külön prezentációkat vagy diakonténereket minden szál számára. Ez a megközelítés követi az általános ajánlást, hogy ne osszunk meg egyetlen prezentációpéldányt a szálak között.

**Biztonságos-e a különböző formátumokba (PDF, HTML, képek) való export párhuzamosítása, ha minden szálnak saját [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példánya van?**

Igen. Független példányokkal és különálló kimeneti útvonalakkal az ilyen feladatok általában helyesen párhuzamosíthatók; kerülje el a közös prezentációobjektumok és közös I/O stream-ek használatát.

**Mit kell tennem a globális betűtípusbeállításokkal (mappák, helyettesítések) több szálas környezetben?**

Inicializálja az összes globális [font settings](/slides/hu/python-java/powerpoint-fonts/) beállítást a szálak indítása előtt, és ne módosítsa azokat a párhuzamos munka során. Ez megszünteti a versenyhelyzeteket a megosztott betűtípus-erőforrások elérésekor.