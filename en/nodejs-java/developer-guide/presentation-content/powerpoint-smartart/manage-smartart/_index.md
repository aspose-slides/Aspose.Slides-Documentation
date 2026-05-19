---
title: Manage SmartArt in PowerPoint Presentations Using JavaScript
linktitle: Manage SmartArt
type: docs
weight: 10
url: /nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt text
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for Node.js using clear JavaScript code samples that speed up slide design and automation."
---

## **Overview**

SmartArt is a PowerPoint diagram made from nodes, node shapes, and a layout. With Aspose.Slides for Node.js via Java, you can create SmartArt, read text from its nodes, change its layout, inspect hidden nodes, configure organization chart layouts, and create picture organization charts.

## **Get Text from a SmartArt Object**

A SmartArt node can contain one or more shapes. To read the visible text, iterate through [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/#getAllNodes--), then read the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) returned by [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

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

## **Change the Layout Type of a SmartArt Object**

The SmartArt layout controls how nodes are arranged and connected. The following example creates a SmartArt object with the [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` value, changes it to the `BasicProcess` value, and saves the presentation.

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

## **Check Whether a SmartArt Node Is Hidden**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) indicates whether the node is hidden in the SmartArt data model. Hidden nodes can exist in the structure even when the selected layout does not display them as visible diagram elements.

The following example adds a node to a SmartArt object that uses the [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` value and checks the node's hidden state.

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

## **Get or Set the Organization Chart Layout**

For SmartArt diagrams that use an organization chart layout, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) and [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) define how child nodes are arranged under a parent node. For example, you can set child nodes to hang from the left, right, or both sides, depending on the selected [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

The following example creates an organization chart and sets the layout for the first node to the [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` value.

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

## **Create a Picture Organization Chart**

A picture organization chart is a SmartArt layout designed for hierarchy diagrams that include image placeholders. Use the [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` value when adding the SmartArt object to a slide.

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

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Yes. The [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) method switches the diagram direction from left-to-right to right-to-left, or back, when the selected SmartArt layout supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/nodejs-java/shape-manipulations/) with [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) or [clone the whole slide](/slides/nodejs-java/clone-slides/) that contains the SmartArt. Both approaches preserve size, position, and formatting.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/nodejs-java/convert-powerpoint-to-png/) or the whole presentation to PNG or JPEG. SmartArt is rendered as part of the slide.

**How can I find a specific SmartArt object on a slide if there are several?**

Set a distinctive [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) or [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) value on the SmartArt shape, search for that value in [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), and then check that the matching shape is a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).
