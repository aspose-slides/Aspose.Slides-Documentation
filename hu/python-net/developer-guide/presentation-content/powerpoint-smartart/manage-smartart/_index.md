---
title: SmartArt kezelése PowerPoint prezentációkban Python használatával
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezéstípus
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan építsen és szerkesszen PowerPoint SmartArt-ot az Aspose.Slides for Python via .NET segítségével, egyértelmű kódmintákkal, amelyek felgyorsítják a dia tervezést és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for Python via .NET segítségével létrehozhat SmartArt-ot, kiolvashatja a szöveget a csomópontjaiból, módosíthatja az elrendezést, ellenőrizheti a rejtett csomópontokat, beállíthatja a szervezeti diagram elrendezéseket, és képes szervezeti diagramokat hozhat létre.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatok szövegének kiolvasásához iteráljon a [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/) elemen, majd olvassa el a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) objektumot, amelyet a [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) ad vissza.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés határozza meg, hogy a csomópontok hogyan helyezkednek el és kapcsolódnak egymáshoz. Az alábbi példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` értékkel, átállítja `BASIC_PROCESS` értékre, és elmenti a prezentációt. A [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) hívásban megadott pozíció és méret pontokban van megadva. Az elrendezés módosításához állítsa be a [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) tulajdonságot.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

A [SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. Rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

Az alábbi példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` értéket használja, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Ha a csomópont rejtett, üzenetet ír ki, majd elmenti a diagramot.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Szervezeti diagram elrendezésének lekérdezése vagy beállítása**

Azokra a SmartArt diagramokra, amelyek szervezeti diagram elrendezést használnak, a [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) határozza meg, hogy a gyermekcsomópontok hogyan helyezkednek el egy szülőcsomópont alatt. Például beállíthatja, hogy a gyermekcsomópontok balról, jobbról vagy mindkét oldalról függjenek le, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) értéktől függően.

Az alábbi példa létrehoz egy szervezeti diagramot, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` értékére állítja. A 0‑s indexű csomópont a legfelső szintű első csomópont; gyermekei az így kiválasztott elrendezést használják. A módosított prezentációt ezután elmenti.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy SmartArt elrendezés, amely hierarchikus diagramokhoz készült, és tartalmaz képhelyeket. Amikor a SmartArt objektumot egy diára helyezi, használja a [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` értékét. Ez a példa egy diagramot ment el képhelyekkel; a helyeket nem tölti ki képekkel.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Örökölt diagramok átalakítása alakzatcsoportokká**

Egy meglévő prezentáció modernizálásakor előfordulhat, hogy frissítenie kell egy PowerPoint 97–2003‑ban létrehozott szervezeti diagramot. Az Aspose.Slides az ilyen örökölt diagramokat [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) objektumokként jeleníti meg. Használja a [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) metódust, hogy a diagramot alakzatcsoporttá alakítsa, így egyedi vizuális elemeket szerkeszthet. A részletekért tekintse meg a [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) dokumentációt.

Az átalakítás egy új csoportot ad az alakzatgyűjteményhez, anélkül hogy eltávolítaná az eredeti diagramot. Sikeres átalakítás után a [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) segítségével távolítsa el az eredetit, hogy elkerülje a duplikált tartalmat. Gyűjtse össze az örökölt diagramokat egy listába, mielőtt átalakítaná őket, hogy a formák hozzáadása és eltávolítása ne szakítsa meg az iterációt.

Az alábbi példa megnyit egy prezentációt, minden diát átvizsgál, a diagramokat alakzatcsoportokká alakítja, majd elmenti a frissített prezentációt PPTX formátumban.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

Az elmentett prezentáció szerkeszthető alakzatcsoportokat tartalmaz az átalakított örökölt diagramok helyén, az eredeti diagramok már nem szerepelnek. Nyissa meg a PPTX‑et a PowerPointban, hogy szerkessze az egyes csoportok elemeit, például a szöveget, kitöltést vagy pozíciót.

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy a visszafelé irányítást RTL nyelvek esetén?**

Igen. A [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) tulajdonság az irányt balról jobbra vagy jobbról balra állítja át, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba a formázás megtartása mellett?**

A [clone the SmartArt shape](/slides/hu/python-net/shape-manipulations/) segítségével a [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) vagy a [clone the whole slide](/slides/hu/python-net/clone-slides/) használatával másolhatja a SmartArt-ot. Mindkét módszer megtartja a méretet, a pozíciót és a formázást.

**Hogyan jeleníthetem meg a SmartArt-ot raszteres képként előnézet vagy webes export céljából?**

A [Render the slide](/slides/hu/python-net/convert-powerpoint-to-png/) vagy a teljes prezentáció PNG vagy JPEG formátumba való konvertálása. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Állítson be egy egyedi [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) vagy [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) értéket a SmartArt alakzaton, keresse meg ezt az értéket a [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) gyűjteményben, majd ellenőrizze, hogy a megtalált alakzat egy [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) legyen.