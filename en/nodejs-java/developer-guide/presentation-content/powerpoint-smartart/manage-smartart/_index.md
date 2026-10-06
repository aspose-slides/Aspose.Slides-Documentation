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

A SmartArt node can contain one or more shapes. To read text from the node shapes, iterate through [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), then read the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) returned by [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

The example requires a presentation with at least one slide and a SmartArt object as the first shape on that slide. It prints each available text frame to the console.

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

## **Change the Layout Type of a SmartArt Object**

The SmartArt layout controls how nodes are arranged and connected. The following example creates a SmartArt object with the [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` value, changes it to the `BasicProcess` value, and saves the presentation. The position and size passed to [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) are measured in points. Use [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) to change the layout.

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

## **Check Whether a SmartArt Node Is Hidden**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) indicates whether the node is hidden in the SmartArt data model. Hidden nodes can exist in the structure even when the selected layout does not display them as visible diagram elements.

The following example adds a node to a SmartArt object that uses the [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` value and checks the added node's hidden state. It prints a message if the node is hidden and saves the diagram.

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

## **Get or Set the Organization Chart Layout**

For SmartArt diagrams that use an organization chart layout, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) and [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) define how child nodes are arranged under a parent node. For example, you can set child nodes to hang from the left, right, or both sides, depending on the selected [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

The following example creates an organization chart and sets the layout for the first node to the [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` value. The zero-based index `0` selects the first top-level node; its child nodes use the selected arrangement. The modified presentation is then saved.

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

## **Create a Picture Organization Chart**

A picture organization chart is a SmartArt layout designed for hierarchy diagrams that include image placeholders. Use the [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` value when adding the SmartArt object to a slide. This example saves a diagram with image placeholders; it does not populate the placeholders with images.

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

## **Convert Legacy Diagrams to Groups of Shapes**

When modernizing an existing presentation, you may need to update an organization chart originally created in PowerPoint 97–2003. Aspose.Slides represents these legacy diagrams as [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) objects. Use [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) to convert a diagram into a group of shapes so that you can edit individual visual elements. See the [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) for details.

Conversion adds a new group to the shape collection without removing the original diagram. After successful conversion, remove the original with [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) to avoid duplicate content. Collect the legacy diagrams into a list before converting them so that adding and removing shapes does not disrupt iteration.

The following example opens a presentation, searches every slide, converts the diagrams to groups of shapes, and saves the updated presentation as PPTX.

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

The saved presentation contains editable groups of shapes in place of the converted legacy diagrams, with no original diagrams left alongside them. Open the PPTX in PowerPoint to edit individual elements within each group, such as their text, fill, or position.

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Yes. The [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) method switches the diagram direction from left-to-right to right-to-left, or back, when the selected SmartArt layout supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/nodejs-java/shape-manipulations/) with [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) or [clone the whole slide](/slides/nodejs-java/clone-slides/) that contains the SmartArt. Both approaches preserve size, position, and formatting.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/nodejs-java/convert-powerpoint-to-png/) or the whole presentation to PNG or JPEG. SmartArt is rendered as part of the slide.

**How can I find a specific SmartArt object on a slide if there are several?**

Use [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) or [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) to assign a distinctive alternative text or name to the SmartArt shape, search for that value in [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), and then check that the matching shape is a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).
