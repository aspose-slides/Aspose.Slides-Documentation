---
title: Beheer SmartArt in PowerPoint‑presentaties met Python
linktitle: Beheer SmartArt
type: docs
weight: 10
url: /nl/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt‑tekst
- lay‑outtype
- verborgen eigenschap
- organisatie‑chart
- afbeelding‑organisatie‑chart
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u PowerPoint SmartArt kunt bouwen en bewerken met Aspose.Slides voor Python via Java, met duidelijke codevoorbeelden die het ontwerpen van dia's en automatisering versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint‑diagram dat bestaat uit knooppunten, knooppuntvormen en een lay‑out. Met Aspose.Slides voor Python via Java kunt u SmartArt maken, tekst uit de knooppunten lezen, de lay‑out wijzigen, verborgen knooppunten inspecteren, organisatie‑chart‑lay‑outs configureren en afbeelding‑organisatie‑charts maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meer vormen bevatten. Om tekst uit de vormen van het knooppunt te lezen, doorloop [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), en lees vervolgens het [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) dat wordt geretourneerd door [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

Het voorbeeld vereist een presentatie met ten minste één dia en een SmartArt‑object als de eerste vorm op die dia. Het drukt elk beschikbaar tekstframe af naar de console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Lay‑outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay‑out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op. De positie en grootte die worden doorgegeven aan [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) worden gemeten in points. Gebruik [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) om de lay‑out te wijzigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen bestaan in de structuur, zelfs wanneer de geselecteerde lay‑out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑waarde gebruikt en controleert de verborgen status van het toegevoegde knooppunt. Het drukt een bericht af als het knooppunt verborgen is en slaat het diagram op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Organisatie‑chart‑lay‑out ophalen of instellen**

Voor SmartArt‑diagrammen die een organisatie‑chart‑lay‑out gebruiken, definiëren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) en [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) hoe kindknooppunten onder een bovenliggend knooppunt worden gerangschikt. U kunt bijvoorbeeld kindknooppunten laten hangen aan de linker-, rechter- of beide kanten, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organisatie‑chart en stelt de lay‑out voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑waarde. De nul‑gebaseerde index `0` selecteert het eerste top‑level knooppunt; de kindknooppunten gebruiken de geselecteerde rangschikking. De aangepaste presentatie wordt vervolgens opgeslagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Afbeeldings‑organisatie‑chart maken**

Een afbeelding‑organisatie‑chart is een SmartArt‑lay‑out die is ontworpen voor hiërarchiediagrammen met afbeeldings‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia. Dit voorbeeld slaat een diagram op met afbeeldings‑plaatsaanduidingen; het vult de plaatsaanduidingen niet met afbeeldingen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Legacy‑diagrammen omzetten naar groepen vormen**

Bij het moderniseren van een bestaande presentatie moet u mogelijk een organisatie‑chart bijwerken die oorspronkelijk is gemaakt in PowerPoint 97–2003. Aspose.Slides vertegenwoordigt deze legacy‑diagrammen als [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/)‑objecten. Gebruik [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) om een diagram om te zetten in een groep vormen, zodat u afzonderlijke visuele elementen kunt bewerken. Zie de [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) voor details.

De conversie voegt een nieuwe groep toe aan de vormverzameling zonder het oorspronkelijke diagram te verwijderen. Na een geslaagde conversie verwijdert u het origineel met [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) om dubbele inhoud te voorkomen. Verzamel de legacy‑diagrammen eerst in een lijst voordat u ze converteert, zodat het toevoegen en verwijderen van vormen de iteratie niet verstoort.

Het volgende voorbeeld opent een presentatie, doorzoekt elke dia, zet de diagrammen om in groepen vormen en slaat de bijgewerkte presentatie op als PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De opgeslagen presentatie bevat bewerkbare groepen vormen in plaats van de geconverteerde legacy‑diagrammen, zonder dat er nog originele diagrammen naast staan. Open de PPTX in PowerPoint om afzonderlijke elementen binnen elke groep te bewerken, zoals hun tekst, opvulling of positie.

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed)‑methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de geselecteerde SmartArt‑lay‑out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie waarbij de opmaak behouden blijft?**

U kunt [de SmartArt‑vorm klonen](/slides/nl/python-java/shape-manipulations/) met [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) of [de hele dia klonen](/slides/nl/python-java/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een raster‑afbeelding voor voorbeeld of web‑export?**

[De dia renderen](/slides/nl/python-java/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object vinden op een dia als er meerdere zijn?**

Gebruik [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) of [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) om een onderscheidende alternatieve tekst of naam toe te wijzen aan de SmartArt‑vorm, zoek die waarde in [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), en controleer vervolgens dat de overeenkomende vorm een [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) is.