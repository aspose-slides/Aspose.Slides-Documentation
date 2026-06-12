---
title: Beheer SmartArt in PowerPoint-presentaties met JavaScript
linktitle: Beheer SmartArt
type: docs
weight: 10
url: /nl/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- afbeelding-organigram
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer PowerPoint SmartArt bouwen en bewerken met Aspose.Slides voor Node.js met duidelijke JavaScript-codevoorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint‑diagram bestaande uit knopen, knoopvormen en een lay‑out. Met Aspose.Slides for Node.js via Java kunt u SmartArt maken, tekst uit de knoppen lezen, de lay‑out wijzigen, verborgen knoppen inspecteren, lay‑outs voor organigrammen configureren en afbeelding‑organigrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knoop kan één of meer vormen bevatten. Om de zichtbare tekst te lezen, iterate door [SmartArt.getAllNodes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/#getAllNodes--), lees vervolgens het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) dat wordt geretourneerd door [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lay‑outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay‑out bepaalt hoe knopen worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een SmartArt‑knoop verborgen is**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartnode/ishidden/) geeft aan of de knoop verborgen is in het SmartArt‑datamodel. Verborgen knopen kunnen in de structuur bestaan, zelfs wanneer de geselecteerde lay‑out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knoop toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑waarde gebruikt en controleert de verborgen status van de knoop.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lay‑out van organigram ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay‑out gebruiken, definiëren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) en [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) hoe kindknooppunten onder een ouderknoop worden gerangschikt. U kunt bijvoorbeeld kindknooppunten laten hangen aan de linker-, rechter- of beide zijden, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de lay‑out van de eerste knoop in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑waarde.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Maak een afbeelding‑organigram**

Een afbeelding‑organigram is een SmartArt‑lay‑out ontworpen voor hiërarchiediagrammen die beeld‑plaatsaanduidingen bevatten. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De methode [SmartArt.setReversed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/setreversed/) schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of omgekeerd, wanneer de geselecteerde SmartArt‑lay‑out omkeren ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt de SmartArt‑vorm [clonen](/slides/nl/nodejs-java/shape-manipulations/) met [ShapeCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/addclone/) of de hele dia [clonen](/slides/nl/nodejs-java/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeld of web‑export?**

Render de dia (/slides/nl/nodejs-java/convert-powerpoint-to-png/) of de volledige presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe vind ik een specifiek SmartArt‑object op een dia als er meerdere aanwezig zijn?**

Stel een onderscheidende [Shape.setAlternativeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/setalternativetext/) of [Shape.setName](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/setname/)‑waarde in op de SmartArt‑vorm, zoek naar die waarde in [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getShapes), en controleer vervolgens of de overeenkomstige vorm een [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/) is.