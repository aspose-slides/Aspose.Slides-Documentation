---
title: Hantera SmartArt i PowerPoint-presentationer med JavaScript
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layouttyp
- dold egenskap
- organisationsdiagram
- bildorganisationsdiagram
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för Node.js med tydliga JavaScript-kodexempel som snabbar upp bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint‑diagram bestående av noder, nodformer och en layout. Med Aspose.Slides för Node.js via Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, inspektera dolda noder, konfigurera organisationsdiagramlayout och skapa bildorganisationsdiagram.

## **Hämta text från ett SmartArt‑objekt**

En SmartArt‑nod kan innehålla en eller flera former. För att läsa text från nodformerna, iterera genom [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), läs sedan [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) som returneras av [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

Exemplet kräver en presentation med minst en bild och ett SmartArt‑objekt som den första formen på den bilden. Det skriver ut varje tillgänglig textram till konsolen.

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

## **Ändra layouttypen för ett SmartArt‑objekt**

SmartArt‑layouten styr hur noder ordnas och kopplas ihop. Följande exempel skapar ett SmartArt‑objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑värdet, ändrar det till värdet `BasicProcess` och sparar presentationen. Positionen och storleken som skickas till [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) anges i punkter. Använd [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) för att ändra layouten.

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

## **Kontrollera om en SmartArt‑nod är dold**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) indikerar om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt‑objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑värdet och kontrollerar den tillagda nodens dolda tillstånd. Det skriver ut ett meddelande om noden är dold och sparar diagrammet.

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

## **Hämta eller ange organisationsdiagramlayout**

För SmartArt‑diagram som använder en organisationsdiagramlayout definierar [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) och [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) hur undernoder ordnas under en föräldranod. Till exempel kan du ställa in att undernoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och ställer in layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑värdet. Nollbaserade indexet `0` väljer den första top‑nivå noden; dess undernoder använder den valda ordningen. Den modifierade presentationen sparas sedan.

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

## **Skapa ett bildorganisationsdiagram**

Ett bildorganisationsdiagram är en SmartArt‑layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑värdet när du lägger till SmartArt‑objektet på en bild. Detta exempel sparar ett diagram med bildplatshållare; det fyller inte i platshållarna med bilder.

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

## **Konvertera äldre diagram till grupper av former**

När du moderniserar en befintlig presentation kan du behöva uppdatera ett organisationsdiagram som ursprungligen skapades i PowerPoint 97–2003. Aspose.Slides representerar dessa äldre diagram som [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/)‑objekt. Använd [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) för att konvertera ett diagram till en grupp av former så att du kan redigera enskilda visuella element. Se [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) för detaljer.

Konverteringen lägger till en ny grupp i formkollektionen utan att ta bort det ursprungliga diagrammet. Efter lyckad konvertering, ta bort originalet med [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) för att undvika duplicerat innehåll. Samla de äldre diagrammen i en lista innan du konverterar dem så att tillägg och borttagning av former inte stör iterationen.

Följande exempel öppnar en presentation, söker igenom varje bild, konverterar diagrammen till grupper av former och sparar den uppdaterade presentationen som PPTX.

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

Den sparade presentationen innehåller redigerbara grupper av former i stället för de konverterade äldre diagrammen, utan några originaldiagram kvar bredvid dem. Öppna PPTX‑filen i PowerPoint för att redigera enskilda element i varje grupp, såsom deras text, fyllning eller position.

## **FAQ**

**Stöder SmartArt spegling eller omvändning för RTL‑språk?**

Ja. Metoden [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) byter diagramriktning från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stöder omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/nodejs-java/shape-manipulations/) med [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) eller [klona hela bilden](/slides/sv/nodejs-java/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbutlåtelse?**

[Rendera bilden](/slides/sv/nodejs-java/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur hittar jag ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Använd [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) eller [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) för att tilldela en unik alternativtext eller namn till SmartArt‑formen, sök efter det värdet i [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), och verifiera sedan att den matchande formen är en [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).