---
title: Manage TextBox
type: docs
weight: 20
url: /java/manage-textbox/
description: Create Text Box on PowerPoint Slides using Java. Add Column in Text Box or Text Frame in PowerPoint Slides using Java. Add Text Box with Hyperlink in PowerPoint Slides using Java.
---


Texts on slides typically exist in text boxes or shapes. Therefore, to add a text to a slide, you have to add a text box and then put some text inside the textbox. Aspose.Slides for Java provides the [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) interface that allows you to add a shape containing some text.

{{% alert title="Info" color="info" %}}

Aspose.Slides also provides the [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) interface that allows you to add shapes to slides. However, not all shapes added through the `IShape` interface can hold text. But shapes added through the [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) interface may contain text. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Therefore, when dealing with a shape to which you want to add text, you may want to check and confirm that it was cast through the `IAutoShape` interface. Only then will you be able to work with [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), which is a property under `IAutoShape`. See the [Update Text](https://docs.aspose.com/slides/java/manage-textbox/#update-text) section on this page. 

{{% /alert %}}

## **Create Text Box on Slide**

To create a textbox on a slide, go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) object with [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) set as `Rectangle` at a specified position on the slide and obtain the reference for the newly added `IAutoShape` object. 
4. Add a `TextFrame` property to the `IAutoShape` object that will contain a text. In the example below, we added this text: *Aspose TextBox*
5. Finally, write the PPTX file through the `Presentation` object. 

This Java code—an implementation of the steps above—shows you how to add text to a slide:

```java
// Instantiates Presentation
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds an AutoShape with type set as Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adds TextFrame to the Rectangle
    ashp.addTextFrame(" ");

    // Accesses the text frame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Creates the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Creates a Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // Sets Text
    portion.setText("Aspose TextBox");

    // Saves the presentation to disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Check for Text Box Shape**

Aspose.Slides provides the [isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) property (from the [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) class) to allow you to examine shapes and find text boxes.

![Text box and shape](istextbox.png)

This Java code shows you how to check whether a shape was created as a text box: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "shape is text box" : "shape is text not box");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Column In Text Box**

Aspose.Slides provides the [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) and [ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) properties (from the [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) interface and [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) class) that allow you to add columns to textboxes. You get to specify the number of columns in a text box and set the amount spacing in points between columns. 

This code in Java demonstrates the described operation: 

```java
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape with type set as Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Add TextFrame to the Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Gets the text format of TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Specifies the number of columns in TextFrame
    format.setColumnCount(3);

    // Specifies the spacing between columns
    format.setColumnSpacing(10);

    // Saves the presentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Add Column In Text Frame**
Aspose.Slides for Java provides the [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) property (from the [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) interface) that allows you to add columns in text frames. Through this property, you can specify your preferred number of columns in a text frame. 

This Java code shows you how to add a column inside a text frame:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Update Text**

Aspose.Slides allows you to change or update the text contained in a text box or all the texts contained in a presentation. 

This Java code demonstrates an operation where all the texts in a presentation are updated or changed:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Checks if shape supports text frame (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Iterates through paragraphs in text frame
                {
                    for (IPortion portion : paragraph.getPortions()) //Iterates through each portion in paragraph
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Changes text
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Changes formatting
                    }
                }
            }
        }
    }

    //Saves modified presentation
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Text Box with Hyperlink** 

You can insert a link inside a text box. When the text box is clicked, users are directed to open the link. 

 To add a text box containing a link, go through these steps:

1. Create an instance of the `Presentation` class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an `AutoShape` object with `ShapeType` set as `Rectangle` at a specified position on the slide and obtain a reference of the newly added AutoShape object.
4. Add a `TextFrame` to the `AutoShape` object that contains *Aspose TextBox* as its default text. 
5. Instantiate the `IHyperlinkManager` class. 
6. Assign the `IHyperlinkManager` object to the [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) property associated with your preferred portion of the `TextFrame`. 
7. Finally, write the PPTX file through the `Presentation` object. 

This Java code—an implementation of the steps above—shows you how to add a text box with a hyperlink to a slide:

```java
// Instantiates a Presentation class that represents a PPTX
Presentation pres = new Presentation();
try {
    // Gets the first slide in the presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Adds an AutoShape object with type set as Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Casts the shape to AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accesses the ITextFrame property associated with the AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Adds some text to the frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Sets the Hyperlink for the portion text
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Saves the PPTX Presentation
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
