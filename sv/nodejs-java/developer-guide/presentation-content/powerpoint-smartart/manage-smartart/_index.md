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
description: Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för Node.js med tydliga JavaScript-kodexempel som påskyndar bilddesign och automatisering.
---
## **Översikt**

SmartArt är ett PowerPoint-diagram som består av noder, nodformer och en layout. Med Aspose.Slides för Node.js via Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, inspektera dolda noder, konfigurera organisationsdiagramlayouter och skapa bildorganisationsdiagram.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [SmartArt.getAllNodes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/#getAllNodes--), och läs sedan [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) som returneras av [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

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

## **Ändra layouttyp för ett SmartArt-objekt**

SmartArt‑layouten styr hur noder arrangeras och kopplas ihop. Följande exempel skapar ett SmartArt‑objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartlayouttype/)‑värdet `BasicBlockList`, ändrar det till värdet `BasicProcess` och sparar presentationen.

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

## **Kontrollera om en SmartArt-nod är dold**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartnode/ishidden/) visar om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramdelar.

Följande exempel lägger till en nod i ett SmartArt‑objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartlayouttype/)‑värdet `RadialCycle` och kontrollerar nodens dolda tillstånd.

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

## **Hämta eller ange layout för organisationsdiagram**

För SmartArt‑diagram som använder en organisationsdiagramlayout definierar [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) och [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) hur undernoder ordnas under en föräldranod. Till exempel kan du ange att undernoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och anger layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/organizationchartlayouttype/)‑värdet `LeftHanging`.

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

## **Skapa ett bildorganisationsdiagram**

Ett bildorganisationsdiagram är en SmartArt‑layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartlayouttype/)‑värdet `PictureOrganizationChart` när du lägger till SmartArt‑objektet på en bild.

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

## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL‑språk?**

Ja. Metoden [SmartArt.setReversed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/setreversed/) byter diagramriktning från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stödjer omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/nodejs-java/shape-manipulations/) med [ShapeCollection.addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/addclone/) eller [klona hela bilden](/slides/sv/nodejs-java/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbuttag?**

[Rendera bilden](/slides/sv/nodejs-java/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Ange ett tydligt värde med [Shape.setAlternativeText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/setalternativetext/) eller [Shape.setName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/setname/) på SmartArt‑formen, sök efter det värdet i [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getShapes), och kontrollera sedan att den matchande formen är ett [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/).