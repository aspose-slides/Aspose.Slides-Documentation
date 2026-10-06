---
title: SmartArt beheren in PowerPoint‑presentaties met JavaScript
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt‑tekst
- lay‑outtype
- verborgen eigenschap
- organisatiediagram
- foto‑organisatiediagram
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer PowerPoint SmartArt bouwen en bewerken met Aspose.Slides voor Node.js aan de hand van duidelijke JavaScript‑codevoorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram bestaande uit knooppunten, knooppuntvormen en een lay-out. Met Aspose.Slides voor Node.js via Java kun je SmartArt maken, tekst lezen uit de knooppunten, de lay-out wijzigen, verborgen knooppunten inspecteren, lay-outs voor organisatiediagrammen configureren en foto‑organisatiediagrammen maken.

## **Tekst ophalen van een SmartArt-object**

Een SmartArt‑knooppunt kan een of meer vormen bevatten. Om tekst uit de knooppuntvormen te lezen, iterate door [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), en lees vervolgens het [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) dat wordt geretourneerd door [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

Het voorbeeld vereist een presentatie met minstens één dia en een SmartArt‑object als de eerste vorm op die dia. Het drukt elk beschikbaar tekstframe af naar de console.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Lay-outtype van een SmartArt-object wijzigen**

De SmartArt‑lay-out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op. De positie en grootte die worden doorgegeven aan [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) worden gemeten in points. Gebruik [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) om de lay-out te wijzigen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de gekozen lay-out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑waarde gebruikt en controleert de verborgen toestand van het toegevoegde knooppunt. Het drukt een bericht af als het knooppunt verborgen is en slaat het diagram op.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organisatiediagramlay-out ophalen of instellen**

Voor SmartArt‑diagrammen die een organisatiediagram‑lay-out gebruiken, definiëren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) en [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. Je kunt bijvoorbeeld onderliggende knooppunten laten hangen aan de linker‑, rechter‑ of beide zijden, afhankelijk van de gekozen [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organisatiediagram en stelt de lay-out voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑waarde. De nul‑gebaseerde index `0` selecteert het eerste top‑level knooppunt; de onderliggende knooppunten gebruiken de gekozen indeling. De gewijzigde presentatie wordt vervolgens opgeslagen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een foto‑organisatiediagram maken**

Een foto‑organisatiediagram is een SmartArt‑lay-out ontworpen voor hiërarchiediagrammen die afbeeldings‑plaatsaanduidingen bevatten. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia. Dit voorbeeld slaat een diagram met afbeeldings‑plaatsaanduidingen op; het vult de plaatsaanduidingen niet met afbeeldingen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy‑diagrammen omzetten naar groepen van vormen**

Bij het moderniseren van een bestaande presentatie moet je mogelijk een organisatiediagram bijwerken dat oorspronkelijk is gemaakt in PowerPoint 97–2003. Aspose.Slides vertegenwoordigt deze legacy‑diagrammen als [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/)‑objecten. Gebruik [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) om een diagram om te zetten naar een groep van vormen zodat je individuele visuele elementen kunt bewerken. Zie de [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) voor details.

Conversie voegt een nieuwe groep toe aan de vormverzameling zonder het oorspronkelijke diagram te verwijderen. Na een geslaagde conversie verwijder je het origineel met [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) om duplicaatinhoud te voorkomen. Verzamel de legacy‑diagrammen eerst in een lijst voordat je ze converteert, zodat het toevoegen en verwijderen van vormen de iteratie niet verstoort.

Het volgende voorbeeld opent een presentatie, doorzoekt elke dia, zet de diagrammen om naar groepen van vormen en slaat de bijgewerkte presentatie op als PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De opgeslagen presentatie bevat bewerkbare groepen van vormen op de plaats van de geconverteerde legacy‑diagrammen, zonder dat er originele diagrammen meer naast staan. Open het PPTX‑bestand in PowerPoint om individuele elementen binnen elke groep te bewerken, zoals hun tekst, opvulling of positie.

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/)‑methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of omgekeerd, wanneer de geselecteerde SmartArt‑lay-out omkeren ondersteunt.

**Hoe kan ik SmartArt naar dezelfde dia of naar een andere presentatie kopiëren terwijl de opmaak behouden blijft?**

Je kunt de SmartArt‑vorm [de SmartArt‑vorm klonen](/slides/nl/nodejs-java/shape-manipulations/) klonen met [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) of de hele dia [de hele dia klonen](/slides/nl/nodejs-java/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeld of webexport?**

[Render de dia](/slides/nl/nodejs-java/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere aanwezig zijn?**

Gebruik [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) of [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) om een onderscheidende alternatieve tekst of naam toe te wijzen aan de SmartArt‑vorm, zoek die waarde in [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), en controleer vervolgens of de gevonden vorm een [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) is.