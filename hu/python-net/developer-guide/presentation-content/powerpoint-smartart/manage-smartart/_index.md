---
title: SmartArt kezelése PowerPoint prezentációkban Python segítségével
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezés típusa
- rejtett tulajdonság
- szervezeti diagram
- kép szervezeti diagram
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg a PowerPoint SmartArt létrehozását és szerkesztését az Aspose.Slides for Python via .NET használatával, egyértelmű kódmintákkal, amelyek felgyorsítják a diatervezést és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint-diagram, amely csomópontokból, csomópontalakzatokból és egy elrendezésből áll. Az Aspose.Slides for Python via .NET segítségével létrehozhat SmartArt-ot, olvashatja a szöveget a csomópontjaiból, megváltoztathatja az elrendezését, vizsgálhatja a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat kép szervezeti diagramokat.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A látható szöveg beolvasásához iteráljon a [SmartArt.all_nodes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/all_nodes/) -en, majd olvassa el a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) -et, amelyet a [SmartArtShape.text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartartshape/text_frame/) visszaad.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **A SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés határozza meg, hogyan helyezkednek el és kapcsolódnak a csomópontok. Az alábbi példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` értékkel, módosítja azt `BASIC_PROCESS` értékre, és elmenti a bemutatót.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

A [SmartArtNode.is_hidden](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartartnode/is_hidden/) jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. Rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemekként.

Az alábbi példa egy csomópontot ad hozzá egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` értéket használja, és ellenőrzi a csomópont rejtett állapotát.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **A szervezeti diagram elrendezésének lekérése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti diagram elrendezést használnak, a [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) meghatározza, hogyan helyezkednek el a gyermekcsomópontok egy szülőcsomópont alatt. Például a gyermekcsomópontokat beállíthatja, hogy balról, jobbról vagy mindkét oldalról függjenek, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/organizationchartlayouttype/) függvényében.

Az alábbi példa létrehoz egy szervezeti diagramot, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` értékre állítja.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kép szervezeti diagram létrehozása**

A kép szervezeti diagram egy SmartArt elrendezés, amely hierarchikus diagramokhoz készült, és képhelyeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` értéket a SmartArt objektum diára való hozzáadásakor.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**A SmartArt támogatja a tükrözést vagy fordítást RTL nyelvek esetén?**

Igen. A [SmartArt.is_reversed](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/is_reversed/) tulajdonság a diagram irányát balról jobbra helyett jobbról balra (vagy vissza) állítja, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik bemutatóba, miközben megőrzöm a formázást?**

A [SmartArt alakzatot klónozhatja](/slides/hu/python-net/shape-manipulations/) a [ShapeCollection.add_clone](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_clone/) segítségével, vagy klónozhatja a SmartArt-ot tartalmazó egész diát [ezzel](/slides/hu/python-net/clone-slides/). Mindkét módszer megőrzi a méretet, pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézet vagy webes export céljából?**

A [dia renderelése](/slides/hu/python-net/convert-powerpoint-to-png/) vagy a teljes bemutató PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Állítson be egy egyedi [Shape.alternative_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/alternative_text/) vagy [Shape.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/name/) értéket a SmartArt alakzatra, keresse meg ezt az értéket a [Slide.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/shapes/) között, majd ellenőrizze, hogy a találat egy [SmartArt](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/).