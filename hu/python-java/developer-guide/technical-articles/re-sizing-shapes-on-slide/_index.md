---
title: Alakzatok átméretezése prezentációs diákon Python via Java
type: docs
weight: 110
url: /hu/python-java/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Python via Java segítségével—automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java felhasználói egyik leggyakoribb kérdése, hogyan lehet átméretezni az alakzatokat úgy, hogy a dia méretének változása esetén az adatok ne vágódjanak le. Ez a rövid technikai cikk bemutatja, hogyan kell ezt megtenni.

## **Alakzatok átméretezése**

Annak érdekében, hogy a dia méretének változása során az alakzatok ne torzuljanak, frissítsd minden alakzat helyzetét és méretét úgy, hogy azok illeszkedjenek az új diaelrendezéshez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Töltsük be a prezentáció fájlt.
presentation = Presentation("sample.ppt")
try:
    # Szerezze meg az eredeti dia méretét.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Módosítsa a dia méretét a meglévő alakzatok átméretezése nélkül.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Szerezze meg az új dia méretét.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Átméretezze és átpozícionálja az alakzatokat minden dián.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Méretezze az alakzat méretét.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Méretezze az alakzat pozícióját.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}} 

A táblázatoknak nincs különleges kezelése: a táblázat szélességének és magasságának beállítása arányosan átméretezi az oszlopait és sorait, így ezek újraméretezése ugyanazt a hányadost alkalmazná kétszer.

{{% /alert %}} 

A fenti kód csak a diákon lévő alakzatokat módosítja. A mesterdiák és az elrendezési diák saját alakzatokkal rendelkeznek, ezért ha az egész prezentációt az új dia mérethez szeretnéd igazítani, ezeket is méretezd át:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Szerezze meg az eredeti dia méretét.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Módosítsa a dia méretét a meglévő alakzatok átméretezése nélkül.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Szerezze meg az új dia méretét.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Méretezze az alakzat méretét.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Méretezze az alakzat pozícióját.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Méretezze az alakzat méretét.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Méretezze az alakzat pozícióját.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Méretezze az alakzat méretét.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Méretezze az alakzat pozícióját.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

Amikor átméretezed a diát, az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a méretezést nem módosítod kifejezetten. Ez a tartalom levágásához vagy az alakzatok elcsúszásához vezethet.

**Működik a megadott kód minden alakzattípusra?**

Igen. A magasság és szélesség beállítása szövegdobozokra, képekre, diagramokra és táblázatokra egyaránt működik.

**Hogyan méretezhetem át a táblázatokat a dia átméretezésekor?**

Méretezze a táblázat alakzatot magát, ugyanúgy, mint a többi alakzatot. Sorai és oszlopai arányosan követik, ezért ne méretezd újra őket később.

**Működik ez az átméretezés a mesterdiákon és elrendezési diákon is?**

Igen, de a [Presentation.getMasters](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasters) és a [Presentation.getLayoutSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getLayoutSlides) elemeket is be kell járni, és ugyanazt a méretezési logikát alkalmazni kell az ő alakzataikra is, hogy a teljes prezentáció következetes legyen.

**Megváltoztathatom a dia tájolását (álló/fekvő) az átméretezéssel együtt?**

Igen. Használhatod a [SlideSize.setOrientation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#setOrientation) metódust a tájolás megváltoztatásához. Győződj meg róla, hogy a méretezési logikát ennek megfelelően állítod be a elrendezés megőrzéséhez.

**Van korlátja a beállítható dia méretnek?**

Az Aspose.Slides támogatja az egyedi méreteket, de nagyon nagy méretek befolyásolhatják a teljesítményt vagy a PowerPoint bizonyos verzióival való kompatibilitást.

**Hogyan kerülhetem el, hogy a rögzített képarányú alakzatok torzuljanak?**

Mielőtt méreteznél, ellenőrizd az alakzat zárolásánál a [getAspectRatioLocked](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) metódust. Ha zárolva van, akkor a szélességet vagy magasságot arányosan módosítsd, a különálló méretezés helyett.