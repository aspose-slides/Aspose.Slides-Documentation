---
title: "SmartArt beheren in PowerPoint-presentaties met Python"
linktitle: "SmartArt beheren"
type: docs
weight: 10
url: /nl/python-net/manage-smartart/
keywords:
- SmartArt
- tekst uit SmartArt
- lay-outtype
- verborgen eigenschap
- organigram
- afbeeldings-organigram
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer PowerPoint-SmartArt maken en bewerken met Aspose.Slides for Python via .NET aan de hand van duidelijke code-voorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint‑diagram bestaande uit knooppunten, knooppuntvormen en een lay‑out. Met Aspose.Slides for Python via .NET kunt u SmartArt maken, tekst lezen uit de knooppunten, de lay‑out wijzigen, verborgen knooppunten inspecteren, lay‑outs voor organigrammen configureren en beeld‑organigrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meer vormen bevatten. Om de zichtbare tekst te lezen, iterereert u door [SmartArt.all_nodes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/all_nodes/), en leest u vervolgens de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) die wordt geretourneerd door [SmartArtShape.text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartartshape/text_frame/) .

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

## **Lay‑outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay‑out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`‑waarde, wijzigt deze naar de `BASIC_PROCESS`‑waarde en slaat de presentatie op.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartartnode/is_hidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen bestaan in de structuur, zelfs wanneer de geselecteerde lay‑out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`‑waarde gebruikt en controleert de verborgen‑status van het knooppunt.

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

## **Organigramlay‑out ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay‑out gebruiken, definieert [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) hoe onderliggende knooppunten worden gerangschikt onder een bovenliggend knooppunt. U kunt bijvoorbeeld onderliggende knooppunten laten hangen aan de linkerkant, rechterkant of beide kanten, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/organizationchartlayouttype/) .

Het volgende voorbeeld maakt een organigram en stelt de lay‑out voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`‑waarde.

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

## **Een afbeelding‑organigram maken**

Een afbeelding‑organigram is een SmartArt‑lay‑out die is ontworpen voor hiërarchiediagrammen met afbeeldings‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART`‑waarde wanneer u het SmartArt‑object aan een dia toevoegt.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De eigenschap [SmartArt.is_reversed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/is_reversed/) schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de geselecteerde SmartArt‑lay‑out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt de [SmartArt‑vorm klonen](/slides/nl/python-net/shape-manipulations/) met [ShapeCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_clone/) of de hele dia klonen [/slides/nl/python-net/clone-slides/](/slides/nl/python-net/clone-slides/) die de SmartArt bevat. Beide benaderingen behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeldweergave of web‑export?**

[Render de dia](/slides/nl/python-net/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object vinden op een dia als er meerdere aanwezig zijn?**

Stel een onderscheidende [Shape.alternative_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/alternative_text/) of [Shape.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/name/) waarde in op de SmartArt‑vorm, zoek naar die waarde in [Slide.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/shapes/), en controleer vervolgens of de overeenkomstige vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/) is.