---
title: 管理缩放
type: docs
weight: 60
url: /zh/androidjava/manage-zoom/
keywords: "缩放, 缩放框, 添加缩放, 格式化缩放框, 总结缩放, PowerPoint演示文稿, Java, Aspose.Slides for Android via Java"
description: "在Java中为PowerPoint演示文稿添加缩放或缩放框"
---

## **概述**
PowerPoint中的缩放允许您在特定幻灯片、部分和演示文稿的片段之间跳转。当您在演示时，这种快速导航内容的能力可能会非常有用。

![overview_image](overview.png)

* 要在单个幻灯片上总结整个演示文稿，请使用[总结缩放](#Summary-Zoom)。
* 要仅显示选定的幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 要仅显示单个部分，请使用[部分缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示文稿更加动态，允许您自由地按任何顺序在幻灯片之间导航，而不会中断演示流程。幻灯片缩放非常适合没有太多部分的短演示，但您仍然可以在不同的演示场景中使用它们。

幻灯片缩放帮助您在感觉上是在单一画布上的同时深入多个信息。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides提供了[ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType)枚举、[IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame)接口以及一些位于[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)接口下的方法。

### **创建缩放框**

您可以通过以下方式在幻灯片上添加缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建您打算链接缩放框的新幻灯片。
3. 为创建的幻灯片添加识别文本和背景。
4. 向第一张幻灯片添加缩放框（包含对创建的幻灯片的引用）。
5. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何在幻灯片上创建一个缩放框：

``` java
Presentation pres = new Presentation();
try {
    //Adds new slides to the presentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the second slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第二张幻灯片");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Create a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第三张幻灯片");

    //Adds ZoomFrame objects
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **使用自定义图像创建缩放框**
通过Aspose.Slides for Android via Java，您可以通过以下方式创建带有不同幻灯片预览图像的缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建您打算链接缩放框的新幻灯片。
3. 为幻灯片添加识别文本和背景。
4. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)对象相关联的Images集合中来创建[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)对象，该图像将用于填充框架。
5. 向第一张幻灯片添加缩放框（包含对创建幻灯片的引用）。
6. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何创建一个带有不同图像的缩放框：

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the third slide
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第二张幻灯片");

    // Creates a new image for the zoom object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Adds the ZoomFrame object
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **格式化缩放框**
在前面的章节中，我们向您展示了如何创建简单的缩放框。要创建更复杂的缩放框，您必须更改简单框的格式。有几种格式选项可应用于缩放框。

您可以通过以下方式控制幻灯片上缩放框的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建新幻灯片以链接到您打算链接的缩放框。
3. 向创建的幻灯片添加一些识别文本和背景。
4. 向第一张幻灯片添加缩放框（包含对创建的幻灯片的引用）。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)对象相关联的Images集合中，创建[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)对象，以用于填充框架。
6. 为第一个缩放框对象设置自定义图像。
7. 更改第二个缩放框对象的线条格式。
8. 移除第二个缩放框对象图像的背景。
5. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何更改幻灯片上缩放框的格式：

``` java 
Presentation pres = new Presentation();
try {
    //Adds new slides to the presentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the second slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第二张幻灯片");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Creates a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第三张幻灯片");

    //Adds ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Creates a new image for the zoom object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Sets custom image for zoomFrame1 object
    zoomFrame1.setImage(picture);

    // Sets a zoom frame format for the zoomFrame2 object
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Setting for Do not show background for zoomFrame2 object
    zoomFrame2.setShowBackground(false);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **部分缩放**

部分缩放是您演示文稿中某个部分的链接。您可以使用部分缩放返回到您希望真正强调的部分。或者，您可以使用它们来突出显示您演示文稿中某些部分之间的连接。

![overview_image](seczoomsel.png)

对于部分缩放对象，Aspose.Slides提供了[ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame)接口和一些位于[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)接口下的方法。

### **创建部分缩放框**

您可以通过以下方式向幻灯片添加部分缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建新幻灯片。
3. 为创建的幻灯片添加识别背景。
4. 创建您打算链接缩放框的新部分。
5. 向第一张幻灯片添加部分缩放框（包含对创建部分的引用）。
6. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何在幻灯片上创建缩放框：

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("部分 1", slide);

    // Adds a SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **使用自定义图像创建部分缩放框**

使用Aspose.Slides for Android via Java，您可以通过以下方式创建带有不同幻灯片预览图像的部分缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建新幻灯片。
3. 为创建的幻灯片添加识别背景。
4. 创建您打算链接缩放框的新部分。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)对象相关联的Images集合中，创建[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)对象，该图像将用于填充框架。
5. 向第一张幻灯片添加部分缩放框（包含对创建部分的引用）。
6. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何创建一个带有不同图像的部分缩放框：

``` java 
Presentation pres = new Presentation();
try {
    //Adds new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("部分 1", slide);

    // Creates a new image for the zoom object
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **格式化部分缩放框**

要创建更复杂的部分缩放框，您必须更改简单框的格式。有几种格式选项可应用于部分缩放框。

您可以通过以下方式控制幻灯片上部分缩放框的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建新幻灯片。
3. 为创建的幻灯片添加识别背景。
4. 创建您打算链接缩放框的新部分。
5. 向第一张幻灯片添加部分缩放框（包含对创建部分的引用）。
6. 更改创建的部分缩放对象的大小和位置。
7. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)对象相关联的Images集合中，创建[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)对象，该图像将用于填充框架。
8. 为创建的部分缩放框对象设置自定义图像。
9. 设置*从链接部分返回到原始幻灯片*的能力。
10. 移除部分缩放框对象图像的背景。
11. 更改第二个缩放框对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何更改部分缩放框的格式：

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("部分 1", slide);

    // Add SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatting for SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **总结缩放**

总结缩放就像一个登录页面，您可以在其中一次性显示您演示文稿中的所有部分。当您进行演示时，您可以使用缩放从演示文稿中的一个地方转到另一个地方，顺序随您喜欢。您可以发挥创意，跳过先前的内容，或重新访问您的幻灯片集中的部分，而不会中断演示的流。

![overview_image](sumzoomsel.png)

对于总结缩放对象，Aspose.Slides提供了[ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)和[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)接口以及一些位于[IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)接口下的方法。

### **创建总结缩放**

您可以通过以下方式向幻灯片添加总结缩放框：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建带有识别背景和为创建的幻灯片的新部分的新幻灯片。
3. 向第一张幻灯片添加总结缩放框。
4. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何在幻灯片上创建一个总结缩放框：

``` java 
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 2", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 3", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 4", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **添加和移除总结缩放部分**

总结缩放框中的所有部分由[ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)对象表示，这些对象存储在[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)对象中。您可以通过[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection)接口添加或移除总结缩放部分对象，方法如下：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建带有识别背景和为创建的幻灯片的新部分的新幻灯片。
3. 向第一张幻灯片添加总结缩放框。
4. 添加新幻灯片和部分到演示文稿中。
5. 将创建的部分添加到总结缩放框。
6. 从总结缩放框中移除第一部分。
7. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何在总结缩放框中添加和移除部分：

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 2", slide);

    // Adds SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    ISection section3 = pres.getSections().addSection("部分 3", slide);

    // Adds a section to the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Removes section from the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **格式化总结缩放部分**

要创建更复杂的总结缩放部分对象，您必须更改简单框的格式。有几种格式选项可应用于总结缩放部分对象。

您可以通过以下方式控制总结缩放部分对象在总结缩放框中的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
2. 创建带有识别背景和为创建的幻灯片的新部分的新幻灯片。
3. 向第一张幻灯片添加总结缩放框。
4. 从`ISummaryZoomSectionCollection`中获取第一个总结缩放部分对象。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)对象相关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)对象，该图像将用于填充框架。
6. 为创建的部分缩放框对象设置自定义图像。
7. 设置*从链接部分返回到原始幻灯片*的能力。
8. 更改第二个缩放框对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿写入PPTX文件。

以下Java代码向您展示了如何更改总结缩放部分对象的格式：

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("部分 2", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Gets the first SummaryZoomSection object
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatting for SummaryZoomSection object
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```