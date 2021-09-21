---
title: Manage TextBox
type: docs
weight: 20
url: /java/manage-textbox/
---


## **Create TextBox on Slide**
Using Aspose.Slides for Java, developers can create TextBox on a [Slide](https://apireference.aspose.com/slides/java/com.aspose.slides/Slide) in the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation). All you have to do is to add an AutoShape of [Rectangle](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) type and call the [addTextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/AutoShape#addTextFrame-java.lang.String-) method exposed by [AutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/AutoShape) object. Please follow the steps below to create TextBox by using Aspose.Slides for Java API:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of the first slide in the presentation which is created on the instantiation of Presentation.
- Add an [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) with [ShapeType](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType) as Rectangle at a specified position of the slide and obtain the reference of that newly added [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) object.
- Add a [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) to the [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) containing TextBox as default text.
- Finally, write the PPTX file using the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object.

The implementation of the above steps is demonstrated below in an example.

```java
// Instantiate Presentation
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");

    // Accessing the text frame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Create the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Create Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // Set Text
    portion.setText("Aspose TextBox");

    // Save the presentation to disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Column In TextBoxes**
Using Aspose.Slides for Java, developers can add column in text boxes on a [Slide](https://apireference.aspose.com/slides/java/com.aspose.slides/Slide) in the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation), methods [setColumnCount](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-), [getColumnCount](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getColumnCount--), [setColumnSpacing](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) and [getColumnSpacing](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getColumnSpacing--) have been added to [ITextFrameFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) interface and [TextFrameFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) class respectively. These properties specify the number of columns in the textbox and set an amount of spacing in points between columns.

The implementation is demonstrated below in an example.

```java
Presentation pres = new Presentation();
try {
    // Get the first slide of presentation
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add an AutoShape of Rectangle type
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    
    // Add TextFrame to the Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");
    
    // Get text format of TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();
    
    // Specify number of columns in TextFrame
    format.setColumnCount(3);
    
    // Specify spacing between columns
    format.setColumnSpacing(10);
    
    // Save created presentation
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Columns In Text Frame**
Using Aspose.Slides for Java, developers can add columns in text frames on a [Slide](https://apireference.aspose.com/slides/java/com.aspose.slides/Slide) in the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation). Methods [getColumnCount](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getColumnCount--) and [setColumnCount](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) have been added to [ITextFrameFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) interface. This property specifies the number of columns in the text frame.

The implementation is demonstrated below in an example.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");
    pres.save("output_column1.pptx", SaveFormat.Pptx);

    Presentation test1 = new Presentation("output_column1.pptx");
    try {
        Assert.assertEquals(2, ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertEquals(Double.NaN, ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnSpacing(20);
    pres.save("output_column2.pptx", SaveFormat.Pptx);

    Presentation test2 = new Presentation("output_column2.pptx");
    try {
        Assert.assertEquals(2, ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertEquals(20, ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save("output_column3.pptx", SaveFormat.Pptx);

    Presentation test3 = new Presentation("output_column3.pptx");
    try {
        Assert.assertEquals(3, ((AutoShape)test3.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertEquals(15, ((AutoShape)test3.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test3 != null) test3.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create TextBox with Hyperlink**
In this topic, we will create a TextBox with a Hyperlink. You will have to instantiate [IHyperlinkManager](https://apireference.aspose.com/slides/java/com.aspose.slides/IHyperlinkManager) class and assign it to the desired portion of the TextFrame associated with the TextBox. Please follow the steps below to create a TextBox with Hyperlink by using Aspose.Slides for Java API:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of the first slide in the presentation which is created on instantiation of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Add an [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) with ShapeType as [Rectangle](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) at a specified position of the slide and obtain the reference of that newly added [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) object.
- Add a [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) to the [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) containing TextBox as default text.
- Instantiate the [IHyperlinkManager](https://apireference.aspose.com/slides/java/com.aspose.slides/IHyperlinkManager) class.
- Assign the [IHyperlinkManager](https://apireference.aspose.com/slides/java/com.aspose.slides/IHyperlinkManager) object to the HyperlinkClick property associated with the desired portion of the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) using [setExternalHyperlinkClick](https://apireference.aspose.com/slides/java/com.aspose.slides/IHyperlinkManager#setExternalHyperlinkClick-java.lang.String-) method.
- Finally, write the PPTX file using the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object.

The implementation of the above steps is demonstrated below in an example.

```java
// Instantiate a Presentation class that represents a PPTX
Presentation pres = new Presentation();
try {
    // Get first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add an AutoShape of Rectangle Type
    IShape pptxShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);
    
    // Cast the shape to AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)pptxShape;
    
    // Access ITextFrame associated with the AutoShape
    pptxAutoShape.addTextFrame("");
    
    ITextFrame ITextFrame = pptxAutoShape.getTextFrame();
    
    // Add some text to the frame
    ITextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    
    // Set Hyperlink for the portion text
    IHyperlinkManager HypMan = ITextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    HypMan.setExternalHyperlinkClick("http://www.aspose.com");
    // Save the PPTX Presentation
    pres.save("hLinkPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
