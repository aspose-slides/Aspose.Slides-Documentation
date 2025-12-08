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

## **Get Text from SmartArt**
Now TextFrame method has been added to [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) class and [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) class respectively. This property allows you to get all text from [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Change Layout Type of SmartArt**
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Change [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Add SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Change LayoutType to BasicProcess
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // Saving Presentation
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Check Hidden Property of SmartArt**
Please note: method [SmartArtNode.isHidden()]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)) returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Add node on SmartArt.
- Check [isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--) property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Add SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // Add node on SmartArt
    var node = smart.getAllNodes().addNode();
    // Check isHidden property
    var hidden = node.isHidden();// Returns true
    if (hidden) {
        // Do some actions or notifications
    }
    // Saving Presentation
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Get or Set Organization Chart Type**
Methods [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
- Get or [set the organization chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Add SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Get or Set the organization chart type
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // Saving Presentation
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Create Picture Organization Chart**
Aspose.Slides for Node.js via Java provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Get or Set SmartArt State**
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
1. [Get](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) or [Set](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) the state of SmartArt Diagram.
1. Write the presentation as a PPTX file.

The following code is used to create a chart.

```javascript
// Instantiate Presentation class that represents the PPTX file
var pres = new aspose.slides.Presentation();
try {
    // Add SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // Get or Set the state of SmartArt Diagram
    smart.setReversed(true);
    var flag = smart.isReversed();
    // Saving Presentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Does SmartArt support mirroring/reversing for RTL languages?**

Yes. The [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) method switches the diagram direction (LTR/RTL) if the selected SmartArt type supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/nodejs-java/shape-manipulations/) via the shapes collection ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) or [clone the entire slide](/slides/nodejs-java/clone-slides/) containing this shape. Both approaches preserve size, position, and styling.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/nodejs-java/convert-powerpoint-to-png/) (or the whole presentation) to PNG/JPEG through the API that converts slides/presentations to images—SmartArt will be drawn as part of the slide.

**How can I programmatically select a specific SmartArt on a slide if there are several?**

A common practice is to use [alternative text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt Text) or [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) and search for the shape by that attribute using [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), then check the type to confirm it’s [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/). The documentation describes typical techniques for finding and working with shapes.
