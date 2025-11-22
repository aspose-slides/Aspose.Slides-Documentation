---
title: Create or Manage PowerPoint SmartArt Shape Node in JavaScript
linktitle: Manage SmartArt Shape Node
type: docs
weight: 30
url: /nodejs-java/manage-smartart-shape-node/
keywords: smartart powerpoint, smartart nodes, smartart position, remove smartart, smartart nodes add, powerpoint presentation, powerpoint java, powerpoint JavaScript api
description: Manage smart art node and child node in PowerPoint Presentations in JavaScript
---

## **Add SmartArt Node in PowerPoint Presentation using JavaScript**
Aspose.Slides for Node.js via Java has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to add node and child node inside SmartArt shape.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it is SmartArt.
1. [Add a new Node](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) in SmartArt shape [**NodeCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) and set the text in TextFrame.
1. Now, [Add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) a [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) in newly added [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) Node and set the text in TextFrame
1. Save the Presentation.

```javascript
// Load the desired the presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Traverse through every shape inside first slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Check if shape is of SmartArt type
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Typecast shape to SmartArt
            var smart = shape;
            // Adding a new SmartArt Node
            var TemNode = smart.getAllNodes().addNode();
            // Adding text
            TemNode.getTextFrame().setText("Test");
            // Adding new child node in parent node. It will be added in the end of collection
            var newNode = TemNode.getChildNodes().addNode();
            // Adding text
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Saving Presentation
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add SmartArt Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

1. Create an instance of Presentation class.
1. Obtain the reference of first slide by using its Index.
1. Add a [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) shape in accessed slide.
1. Access the first node in added SmartArt shape
1. Now, add the [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) for selected [**Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) at position 2 and set its text.
1. Save the Presentation

```javascript
// Creating a presentation instance
var pres = new aspose.slides.Presentation();
try {
    // Access the presentation slide
    var slide = pres.getSlides().get_Item(0);
    // Add Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accessing the SmartArt node at index 0
    var node = smart.getAllNodes().get_Item(0);
    // Adding new child node at position 2 in parent node
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Add Text
    chNode.getTextFrame().setText("Sample Text Added");
    // Save Presentation
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access SmartArt Node in PowerPoint Presentation using JavaScript**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it is SmartArt.
1. Traverse through all [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) inside SmartArt Shape.
1. Access and display information like SmartArt Node position, level and Text.

```javascript
// Instantiate Presentation Class
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Get first slide
    var slide = pres.getSlides().get_Item(0);
    // Traverse through every shape inside first slide
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Check if shape is of SmartArt type
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typecast shape to SmartArt
            var smart = shape;
            // Traverse through all nodes inside SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Accessing SmartArt node at index i
                var node = smart.getAllNodes().get_Item(j);
                // Printing the SmartArt node parameters
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Access SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it is SmartArt.
1. Traverse through all [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) inside SmartArt Shape.
1. For every selected SmartArt shape [**Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode), traverse through all [**Child Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) inside particular node.
1. Access and display information like [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) position, level and Text.

```javascript
// Instantiate Presentation Class
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Get first slide
    var slide = pres.getSlides().get_Item(0);
    // Traverse through every shape inside first slide
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Check if shape is of SmartArt type
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typecast shape to SmartArt
            var smart = shape;
            // Traverse through all nodes inside SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Accessing SmartArt node at index i
                var node0 = smart.getAllNodes().get_Item(i);
                // Traversing through the child nodes in SmartArt node at index i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Accessing the child node in SmartArt node
                    var node = node0.getChildNodes().get_Item(j);
                    // Printing the SmartArt child node parameters
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access SmartArt Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Obtain the reference of first slide by using its Index.
1. Add a [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) type SmartArt shape.
1. Access the added SmartArt shape.
1. Access the node at index 0 for accessed SmartArt shape.
1. Now, access the [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) at position 1 for accessed SmartArt node using **get_Item()** method.
1. Access and display information like [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) position, level and Text.

```javascript
// Instantiate the presentation
var pres = new aspose.slides.Presentation();
try {
    // Accessing the first slide
    var slide = pres.getSlides().get_Item(0);
    // Adding the SmartArt shape in first slide
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accessing the SmartArt node at index 0
    var node = smart.getAllNodes().get_Item(0);
    // Accessing the child node at position 1 in parent node
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Printing the SmartArt child node parameters
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remove SmartArt Node in PowerPoint Presentation using JavaScript**
In this example, we will learn to remove the nodes inside SmartArt shape.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it is SmartArt.
1. Check if the [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) has more than 0 nodes.
1. Select the SmartArt node to be deleted.
1. Now, remove the selected node using [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) method.
1. Save the Presentation.

```javascript
// Load the desired the presentation
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Traverse through every shape inside first slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Check if shape is of SmartArt type
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typecast shape to SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accessing SmartArt node at index 0
                var node = smart.getAllNodes().get_Item(0);
                // Removing the selected node
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Save Presentation
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remove SmartArt Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it is SmartArt.
1. Select the SmartArt shape node at index 0.
1. Now, check if the selected SmartArt node has more than 2 child nodes.
1. Now, remove the node at **Position 1** using [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-) method.
1. Save the Presentation.

```javascript
// Load the desired the presentation
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Traverse through every shape inside first slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Check if shape is of SmartArt type
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Typecast shape to SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accessing SmartArt node at index 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Removing the child node at position 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Save Presentation
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Custom Position for Child Node in SmartArt**
Now Aspose.Slides for Node.js via Java support for setting [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setX-float-) and [Y](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setY-float-) properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes. Also with custom position settings, user may set the nodes as per requirements.

```javascript
// Instantiate Presentation Class
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Move SmartArt shape to new position
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Change SmartArt shape's widths
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Change SmartArt shape's height
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Change SmartArt shape's rotation
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Check Assistant Node**
{{% alert color="primary" %}} 

In this article we will further investigate features of SmartArt shapes added in presentation slides programmatically using Aspose.Slides for Node.js via Java.

{{% /alert %}} 

We will use the following source SmartArt shape for our investigation in different sections of this article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

In the following sample code we will investigate how to identify **Assistant Nodes** in the SmartArt nodes collection and changing them.

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of second slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it is SmartArt.
1. Traverse through all nodes inside SmartArt shape and check if they are [**Assistant Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
1. Change the status of Assistant Node to normal node.
1. Save the Presentation.

```javascript
// Creating a presentation instance
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Traverse through every shape inside first slide
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Check if shape is of SmartArt type
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typecast shape to SmartArt
            var smart = shape;
            // Traversing through all nodes of SmartArt shape
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Check if node is Assistant node
                if (node.isAssistant()) {
                    // Setting Assistant node to false and making it normal node
                    node.isAssistant();
                }
            }
        }
    }
    // Save Presentation
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **Set Node’s Fill Format**
Aspose.Slides for Node.js via Java makes it possible to add custom SmartArt shapes and set their fill format. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Node.js via Java.

Please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Obtain the reference of a slide using its index.
1. Add a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) shape by setting its [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Set the [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--) for the SmartArt shape nodes.
1. Write the modified presentation as a PPTX file.

```javascript
// Instantiate the presentation
var pres = new aspose.slides.Presentation();
try {
    // Accessing the slide
    var slide = pres.getSlides().get_Item(0);
    // Adding SmartArt shape and nodes
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Setting node fill color
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Save the presentation
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generate Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. [Add SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Obtain the reference of a node by using its Index
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

```javascript
// Instantiate Presentation class that represents the PPTX file
var pres = new aspose.slides.Presentation();
try {
    // Add SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Obtain the reference of a node by using its Index
    var node = smart.getNodes().get_Item(1);
    // Get thumbnail
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Save thumbnail
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Is SmartArt animation supported?**

Yes. SmartArt is treated as a regular shape, so you can [apply standard animations](/slides/nodejs-java/shape-animation/) (entrance, exit, emphasis, motion paths) and adjust timing. You can also animate shapes inside SmartArt nodes when needed.

**How can I reliably locate a specific SmartArt on a slide if its internal ID is unknown?**

Assign and search by [alternative text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/). Setting a distinctive AltText on the SmartArt lets you find it without relying on internal identifiers.

**Will the SmartArt appearance be preserved when converting the presentation to PDF?**

Yes. Aspose.Slides renders SmartArt with high visual fidelity during [PDF export](/slides/nodejs-java/convert-powerpoint-to-pdf/), preserving layout, colors, and effects.

**Can I extract an image of the entire SmartArt (for previews or reports)?**

Yes. You can render a SmartArt shape to [raster formats](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) or to [SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) for scalable vector output, making it suitable for thumbnails, reports, or web use.
