---
title: SmartArt beheren in PowerPoint-presentaties met Python
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- indelingstype
- verborgen eigenschap
- organisatiediagram
- afbeeldings-organisatiediagram
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer PowerPoint-SmartArt bouwen en bewerken met Aspose.Slides voor Python via Java aan de hand van duidelijke code-voorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram dat bestaat uit knooppunten, knooppuntvormen en een indeling. Met Aspose.Slides voor Python via Java kunt u SmartArt maken, tekst lezen uit de knooppunten, de indeling wijzigen, verborgen knooppunten inspecteren, indelingen voor organisatiediagrammen configureren en afbeelding‑organisatiediagrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meer vormen bevatten. Om de zichtbare tekst te lezen, itereren we door [SmartArt.getAllNodes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/#getAllNodes), en lezen daarna het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) dat wordt geretourneerd door [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartshape/#getTextFrame).

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

## **Indelingstype van een SmartArt‑object wijzigen**

De SmartArt‑indeling bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#isHidden) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de geselecteerde indeling ze niet weergeeft als zichtbare diagramonderdelen.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑waarde gebruikt en controleert de verborgen‑status van het knooppunt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Organisatiediagram‑indeling ophalen of instellen**

Voor SmartArt‑diagrammen die een organisatiediagram‑indeling gebruiken, definiëren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) en [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. U kunt bijvoorbeeld onderliggende knooppunten laten hangen aan de linker‑, rechter‑ of beide zijden, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organisatiediagram en stelt de indeling voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑waarde.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Afbeeldings‑organisatiediagram maken**

Een afbeelding‑organisatiediagram is een SmartArt‑indeling ontworpen voor hiërarchische diagrammen met afbeeldings‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [SmartArt.setReversed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/#setReversed)‑methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de geselecteerde SmartArt‑indeling omkering ondersteunt.

**Hoe kan ik SmartArt naar dezelfde dia of naar een andere presentatie kopiëren terwijl de opmaak behouden blijft?**

U kunt de SmartArt‑vorm [klonen](/slides/nl/python-java/shape-manipulations/) met [ShapeCollection.addClone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addClone) of de hele dia [klonen](/slides/nl/python-java/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeld of webexport?**

Render de dia (/slides/nl/python-java/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object vinden op een dia als er meerdere zijn?**

Stel een onderscheidende [Shape.getAlternativeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getAlternativeText) of [Shape.getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getName)‑waarde in op de SmartArt‑vorm, zoek die waarde in [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getShapes), en controleer vervolgens of de overeenkomstige vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/) is.