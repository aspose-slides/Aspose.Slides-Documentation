---
title: Manage TextBox
type: docs
weight: 20
url: /nodejs-java/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- text box with a hyperlink
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Manage a text box or text frame in PowerPoint presentations using JavaScript"
---


Texts on slides typically exist in text boxes or shapes. Therefore, to add a text to a slide, you have to add a text box and then put some text inside the textbox. Aspose.Slides for Node.js via Java provides the [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) class that allows you to add a shape containing some text.

{{% alert title="Info" color="info" %}}

Aspose.Slides also provides the [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) class that allows you to add shapes to slides. However, not all shapes added through the `Shape` class can hold text. But shapes added through the [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) class may contain text.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Therefore, when dealing with a shape to which you want to add text, you may want to check and confirm that it was cast through the `AutoShape` class. Only then will you be able to work with [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), which is a property under `AutoShape`. See the [Update Text](https://docs.aspose.com/slides/nodejs-java/manage-textbox/#update-text) section on this page.

{{% /alert %}}

## **Create Text Box on Slide**

To create a textbox on a slide, go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) object with [ShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) set as `Rectangle` at a specified position on the slide and obtain the reference for the newly added `AutoShape` object.
4. Add a `TextFrame` property to the `AutoShape` object that will contain a text. In the example below, we added this text: *Aspose TextBox*
5. Finally, write the PPTX file through the `Presentation` object. 

This JavaScript code—an implementation of the steps above—shows you how to add text to a slide:

```javascript
// Instantiates Presentation
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide in the presentation
    var sld = pres.getSlides().get_Item(0);
    // Adds an AutoShape with type set as Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Adds TextFrame to the Rectangle
    ashp.addTextFrame(" ");
    // Accesses the text frame
    var txtFrame = ashp.getTextFrame();
    // Creates the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Creates a Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    // Sets Text
    portion.setText("Aspose TextBox");
    // Saves the presentation to disk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Check for Text Box Shape**

Aspose.Slides provides the [isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox) method from the [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) class, allowing you to examine shapes and identify text boxes.

![Text box and shape](istextbox.png)

This JavaScript code shows you how to check whether a shape was created as a text box:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Note that if you simply add an autoshape using the `addAutoShape` method from the [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) class, the `isTextBox` method of the autoshape will return `false`. However, after you add text to the autoshape using the `addTextFrame` method or the `setText` method, the `isTextBox` property returns `true`.

```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() returns false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() returns true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() returns false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() returns true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() returns false
shape3.addTextFrame("");
// shape3.isTextBox() returns false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() returns false
shape4.getTextFrame().setText("");
// shape4.isTextBox() returns false
```

## **Add Column In Text Box**

Aspose.Slides provides the [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) and [setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) methods from the [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) class and [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) class that allow you to add columns to textboxes. You get to specify the number of columns in a text box and set the amount spacing in points between columns.

This code in JavaScript demonstrates the described operation: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide in the presentation
    var slide = pres.getSlides().get_Item(0);
    // Add an AutoShape with type set as Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Add TextFrame to the Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Gets the text format of TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Specifies the number of columns in TextFrame
    format.setColumnCount(3);
    // Specifies the spacing between columns
    format.setColumnSpacing(10);
    // Saves the presentation
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Add Column In Text Frame**
Aspose.Slides for Node.js via Java provides the [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) method from the [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) class that allows you to add columns in text frames. Through this property, you can specify your preferred number of columns in a text frame.

This JavaScript code shows you how to add a column inside a text frame:

```javascript
var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Update Text**

Aspose.Slides allows you to change or update the text contained in a text box or all the texts contained in a presentation. 

This JavaScript code demonstrates an operation where all the texts in a presentation are updated or changed:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Checks if shape supports text frame (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Iterates through paragraphs in text frame
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Iterates through each portion in paragraph
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Changes text
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Changes formatting
                    }
                }
            }
        }
    }
    // Saves modified presentation
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Text Box with Hyperlink** 

You can insert a link inside a text box. When the text box is clicked, users are directed to open the link. 

 To add a text box containing a link, go through these steps:

1. Create an instance of the `Presentation` class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an `AutoShape` object with `ShapeType` set as `Rectangle` at a specified position on the slide and obtain a reference of the newly added AutoShape object.
4. Add a `TextFrame` to the `AutoShape` object that contains *Aspose TextBox* as its default text. 
5. Instantiate the `HyperlinkManager` class. 
6. Assign the `HyperlinkManager` object to the [HyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) property associated with your preferred portion of the `TextFrame`.
7. Finally, write the PPTX file through the `Presentation` object. 

This JavaScript code—an implementation of the steps above—shows you how to add a text box with a hyperlink to a slide:

```javascript
// Instantiates a Presentation class that represents a PPTX
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide in the presentation
    var slide = pres.getSlides().get_Item(0);
    // Adds an AutoShape object with type set as Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Casts the shape to AutoShape
    var pptxAutoShape = shape;
    // Accesses the ITextFrame property associated with the AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Adds some text to the frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Sets the Hyperlink for the portion text
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Saves the PPTX Presentation
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
