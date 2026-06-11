---
title: Hantera SmartArt i PowerPoint-presentationer med Python
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/python-net/manage-smartart/
keywords:
- SmartArt
- text från SmartArt
- layouttyp
- dold egenskap
- organisationsdiagram
- bildorganisationsdiagram
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint-SmartArt med Aspose.Slides för Python via .NET med tydliga kodexempel som påskyndar bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint‑diagram bestående av noder, nodformer och en layout. Med Aspose.Slides för Python via .NET kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, undersöka dolda noder, konfigurera organisationsdiagramlayouter och skapa bild‑organisationsdiagram.

## **Hämta text från ett SmartArt‑objekt**

En SmartArt‑nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [SmartArt.all_nodes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/all_nodes/), och läs sedan den [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) som returneras av [SmartArtShape.text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartartshape/text_frame/).

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

## **Ändra layouttyp för ett SmartArt‑objekt**

SmartArt‑layouten styr hur noder arrangeras och kopplas ihop. Följande exempel skapar ett SmartArt‑objekt med värdet `BASIC_BLOCK_LIST` från [SmartArtLayoutType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartartlayouttype/), ändrar det till värdet `BASIC_PROCESS` och sparar presentationen.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrollera om en SmartArt‑nod är dold**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartartnode/is_hidden/) visar om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt‑objekt som använder värdet `RADIAL_CYCLE` från [SmartArtLayoutType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartartlayouttype/) och kontrollerar nodens dolda tillstånd.

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

## **Hämta eller ange layout för organisationsdiagram**

För SmartArt‑diagram som använder en organisationsdiagramlayout definierar [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) hur underordnade noder placeras under en föräldranod. Du kan till exempel ange att underordnade noder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och anger layouten för den första noden till värdet `LEFT_HANGING` från [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/organizationchartlayouttype/).

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

## **Skapa ett bild‑organisationsdiagram**

Ett bild‑organisationsdiagram är en SmartArt‑layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd värdet `PICTURE_ORGANIZATION_CHART` från [SmartArtLayoutType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartartlayouttype/) när du lägger till SmartArt‑objektet på en bild.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Stöder SmartArt spegling eller omvändning för RTL‑språk?**

Ja. Egenskapen [SmartArt.is_reversed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/is_reversed/) växlar diagrammets riktning från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stödjer omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/python-net/shape-manipulations/) med [ShapeCollection.add_clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_clone/) eller [klona hela bilden](/slides/sv/python-net/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/python-net/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Ange ett unikt [Shape.alternative_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/alternative_text/) eller [Shape.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/name/)‑värde på SmartArt‑formen, sök efter det värdet i [Slide.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/shapes/), och kontrollera sedan att den matchande formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/).