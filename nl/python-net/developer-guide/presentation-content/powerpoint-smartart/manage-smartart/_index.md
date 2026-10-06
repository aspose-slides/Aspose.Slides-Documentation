---
title: Beheer SmartArt in PowerPoint-presentaties met Python
linktitle: Beheer SmartArt
type: docs
weight: 10
url: /nl/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- foto‑organigram
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer PowerPoint SmartArt maken en bewerken met Aspose.Slides for Python via .NET met duidelijke codevoorbeelden die het ontwerpen van dia's en automatisering versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram bestaande uit knooppunten, knooppuntvormen en een lay-out. Met Aspose.Slides for Python via .NET kunt u SmartArt maken, tekst lezen uit de knooppunten, de lay-out wijzigen, verborgen knooppunten inspecteren, lay-outs voor organigrammen configureren en foto‑organigrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meer vormen bevatten. Om tekst uit de knooppuntvormen te lezen, loop [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/) door en lees vervolgens het [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) dat wordt geretourneerd door [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Het voorbeeld vereist een presentatie met ten minste één dia en een SmartArt‑object als eerste vorm op die dia. Het drukt elk beschikbaar tekstkader af naar de console.

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

## **Lay-outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay-out bepaalt hoe knooppunten worden geplaatst en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`‑waarde, wijzigt deze naar de `BASIC_PROCESS`‑waarde en slaat de presentatie op. De positie en grootte die aan [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) worden doorgegeven, worden gemeten in punten. Stel [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) in om de lay-out te wijzigen.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de geselecteerde lay-out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`‑waarde gebruikt en controleert de verborgen status van het toegevoegde knooppunt. Het drukt een bericht af als het knooppunt verborgen is en slaat het diagram op.

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

## **Organigram‑lay-out ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay-out gebruiken, definieert [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. U kunt bijvoorbeeld de onderliggende knooppunten laten hangen aan de linker-, rechter- of beide zijden, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de lay-out voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`‑waarde. De index `0` (zero‑based) selecteert het eerste knooppunt op het hoogste niveau; de onderliggende knooppunten gebruiken de gekozen indeling. De gewijzigde presentatie wordt vervolgens opgeslagen.

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

## **Een foto‑organigram maken**

Een foto‑organigram is een SmartArt‑lay-out die is ontworpen voor hiërarchiediagrammen met afbeeldings‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART`‑waarde bij het toevoegen van het SmartArt‑object aan een dia. Dit voorbeeld slaat een diagram op met afbeeldings‑plaatsaanduidingen; het vult de plaatsaanduidingen niet met afbeeldingen.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Legacy‑diagrammen converteren naar groepen vormen**

Bij het moderniseren van een bestaande presentatie moet u mogelijk een organigram bijwerken dat oorspronkelijk werd gemaakt in PowerPoint 97–2003. Aspose.Slides vertegenwoordigt deze legacy‑diagrammen als [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/)‑objecten. Gebruik [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) om een diagram te converteren naar een groep vormen, zodat u afzonderlijke visuele elementen kunt bewerken. Zie de [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) voor details.

Conversie voegt een nieuwe groep toe aan de vormverzameling zonder het oorspronkelijke diagram te verwijderen. Na een geslaagde conversie verwijdert u het origineel met [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) om dubbele inhoud te voorkomen. Verzamel de legacy‑diagrammen in een lijst voordat u ze converteert, zodat het toevoegen en verwijderen van vormen de iteratie niet verstoort.

Het volgende voorbeeld opent een presentatie, doorzoekt elke dia, converteert de diagrammen naar groepen vormen en slaat de bijgewerkte presentatie op als PPTX.

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

De opgeslagen presentatie bevat bewerkbare groepen vormen op de plaats van de geconverteerde legacy‑diagrammen, zonder dat de oorspronkelijke diagrammen overblijven. Open de PPTX in PowerPoint om afzonderlijke elementen binnen elke groep te bewerken, zoals hun tekst, opvulling of positie.

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/)‑eigenschap schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links (of omgekeerd) wanneer de geselecteerde SmartArt‑lay-out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt de SmartArt‑vorm [klonen van de SmartArt‑vorm](/slides/nl/python-net/shape-manipulations/) met [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) of de volledige dia die de SmartArt bevat [de hele dia klonen](/slides/nl/python-net/clone-slides/). Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeldweergave of web‑export?**

[Render de dia](/slides/nl/python-net/convert-powerpoint-to-png/) of de volledige presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere zijn?**

Stel een kenmerkende [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) of [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/)‑waarde in op de SmartArt‑vorm, zoek die waarde in [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), en controleer vervolgens dat de overeenkomende vorm een [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) is.