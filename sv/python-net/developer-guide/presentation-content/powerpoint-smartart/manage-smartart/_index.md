---
title: Hantera SmartArt i PowerPoint-presentationer med Python
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt‑text
- layouttyp
- dold egenskap
- organisationsdiagram
- bild‑organisationsdiagram
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint‑SmartArt med Aspose.Slides för Python via .NET med tydliga kodexempel som påskyndar bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint‑diagram som består av noder, nodformer och en layout. Med Aspose.Slides för Python via .NET kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, inspektera dolda noder, konfigurera organisationsdiagramlayout och skapa bild‑organisationsdiagram.

## **Hämta text från ett SmartArt‑objekt**

En SmartArt‑nod kan innehålla en eller flera former. För att läsa text från nodformerna, iterera genom [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), läs sedan [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) som returneras av [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Exemplet kräver en presentation med minst en bild och ett SmartArt‑objekt som den första formen på den bilden. Det skriver ut varje tillgänglig textram till konsolen.

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

## **Ändra layouttypen för ett SmartArt‑objekt**

SmartArt‑layouten styr hur noder arrangeras och kopplas ihop. Följande exempel skapar ett SmartArt‑objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/)‑värdet `BASIC_BLOCK_LIST`, ändrar det till värdet `BASIC_PROCESS` och sparar presentationen. Positionen och storleken som skickas till [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) mäts i punkter. Ställ in [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) för att ändra layouten.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrollera om en SmartArt‑nod är dold**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indikerar om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt‑objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/)‑värdet `RADIAL_CYCLE` och kontrollerar den tillagda nodens dolda tillstånd. Det skriver ut ett meddelande om noden är dold och sparar diagrammet.

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

## **Hämta eller ange organisationsdiagramlayouten**

För SmartArt‑diagram som använder en organisationsdiagramlayout definierar [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) hur barnnoder arrangeras under en föräldranod. Till exempel kan du ange att barnnoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och anger layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/)‑värdet `LEFT_HANGING`. Det nollbaserade indexet `0` väljer den första toppnivånoden; dess barnnoder använder den valda arrangemanget. Den modifierade presentationen sparas sedan.

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

## **Skapa ett bild‑organisationsdiagram**

Ett bild‑organisationsdiagram är en SmartArt‑layout avsedd för hierarkidiagram som inkluderar bild‑platshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/)‑värdet `PICTURE_ORGANIZATION_CHART` när du lägger till SmartArt‑objektet på en bild. Detta exempel sparar ett diagram med bild‑platshållare; det fyller inte i platshållarna med bilder.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Konvertera äldre diagram till grupper av former**

När du moderniserar en befintlig presentation kan du behöva uppdatera ett organisationsdiagram som ursprungligen skapades i PowerPoint 97–2003. Aspose.Slides representerar dessa äldre diagram som [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/)‑objekt. Använd [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) för att konvertera ett diagram till en grupp av former så att du kan redigera enskilda visuella element. Se [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) för detaljer.

Konverteringen lägger till en ny grupp i formsamlingen utan att ta bort det ursprungliga diagrammet. Efter lyckad konvertering, ta bort originalet med [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) för att undvika duplicerat innehåll. Samla de äldre diagrammen i en lista innan du konverterar dem så att tillägg och borttagning av former inte stör iterationen.

Följande exempel öppnar en presentation, söker igenom varje bild, konverterar diagrammen till grupper av former och sparar den uppdaterade presentationen som PPTX.

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

Den sparade presentationen innehåller redigerbara grupper av former i stället för de konverterade äldre diagrammen, utan några ursprungliga diagram kvar bredvid dem. Öppna PPTX‑filen i PowerPoint för att redigera enskilda element i varje grupp, såsom deras text, fyllning eller position.

## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Egenskapen [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) växlar diagrammets riktning från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stödjer omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/python-net/shape-manipulations/) med [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) eller [klona hela bilden](/slides/sv/python-net/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/python-net/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Ange ett tydligt [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/)‑ eller [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/)‑värde på SmartArt‑formen, sök efter det värdet i [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), och kontrollera sedan att den matchande formen är en [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).