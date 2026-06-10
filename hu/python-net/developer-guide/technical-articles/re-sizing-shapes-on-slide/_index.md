---
title: Alakzatok átméretezése prezentációkban Python segítségével
linktitle: Alakzatok átméretezése
type: docs
weight: 130
url: /hu/python-net/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Python .NET-en keresztül—automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Az Aspose.Slides for Python ügyfelei leggyakrabban felmerülő kérdése, hogyan lehet átméretezni az alakzatokat úgy, hogy a diák méretének változása esetén az adatok ne vágódjanak le. Ez a rövid technikai cikk bemutatja, hogyan kell ezt megtenni.

## **Alakzatok átméretezése**

Az alakzatok eltolódásának megakadályozása érdekében a diák méretének változása esetén frissíteni kell minden alakzat helyét és méretét, hogy azok megfeleljenek az új diaképre.

```py
import aspose.slides as slides

# Töltse be a prezentáció fájlt.
with slides.Presentation("sample.pptx") as presentation:
    # Szerezze meg az eredeti dia méretét.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Módosítsa a dia méretét a meglévő alakzatok méretezése nélkül.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Szerezze meg az új dia méretét.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Átméretezze és helyezze át az alakzatokat minden dián.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Méretezze az alakzat méretét.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Méretezze az alakzat pozícióját.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Ha egy dia táblázatot tartalmaz, a fenti kód nem fog megfelelően működni. Ebben az esetben a táblázat minden celláját át kell méretezni.
{{% /alert %}} 

Használja az alábbi kódot a táblázatot tartalmazó diák átméretezéséhez. Táblázatok esetén a szélesség vagy magasság beállítása speciális eset: egyes sorok magasságát és oszlopok szélességét kell módosítani a táblázat teljes méretének megváltoztatásához.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Az eredeti dia méretének lekérése.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # A dia méretének módosítása a meglévő alakzatok méretezése nélkül.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Az új dia méretének lekérése.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Az alakzat méretének méretezése.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Az alakzat pozíciójának méretezése.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Az alakzat méretének méretezése.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Az alakzat pozíciójának méretezése.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Az alakzat méretének méretezése.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Az alakzat pozíciójának méretezése.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

Dia átméretezésekor az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a méretezés nem kerül kifejezetten módosításra. Ez tartalmak levágódásához vagy alakzatok eltolódásához vezethet.

**Működik a megadott kód minden alakzattípusra?**

Az alap példa a legtöbb alakzattípusra (szövegdobozok, képek, diagramok stb.) működik. Azonban táblázatok esetén külön kell kezelni a sorokat és oszlopokat, mivel egy táblázat magasságát és szélességét az egyes cellák méretei határozzák meg.

**Hogyan méretezhetem át a táblázatokat a dia átméretezésekor?**

A táblázat összes sorát és oszlopát végig kell iterálni, és magasságukat, szélességüket arányosan át kell méretezni, ahogyan a második kódrészletben látható.

**Működik ez az átméretezés mester- és elrendezési diák esetén is?**  
Igen, de a [Masters](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/masters/) és a [Layout slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/layout_slides/) elemein is végig kell iterálni, és ugyanazt a méretezési logikát alkalmazni kell az alakzataikra, hogy a teljes bemutatóban konzisztens legyen.

**Módosíthatom a dia tájolását (álló/fekvő) az átméretezés mellett?**  
Igen. A [presentation.slide_size.orientation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/islidesize/orientation/) segítségével megváltoztatható a tájolás. Ügyeljen arra, hogy a méretezési logikát ennek megfelelően állítsa be a elrendezés megőrzéséhez.

**Van korlátja annak a diaméretnek, amelyet beállíthatok?**  
Az Aspose.Slides támogatja az egyedi méreteket, de a nagyon nagy méretek hatással lehetnek a teljesítményre vagy a PowerPoint egyes verzióival való kompatibilitásra.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**  
A méretezés előtt ellenőrizheti az alakzat `aspect_ratio_locked` tulajdonságát. Ha zárolt, a szélességet vagy magasságot arányosan kell módosítani, ahelyett, hogy külön-külön méretné a.