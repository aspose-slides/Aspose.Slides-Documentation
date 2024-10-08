---
title: 管理缩放
type: docs
weight: 60
url: /java/manage-zoom/
keywords: "缩放, 缩放框, 添加缩放, 格式化缩放框, 总结缩放, PowerPoint 演示文稿, Java, Aspose.Slides for Java"
description: "在 Java 中向 PowerPoint 演示文稿添加缩放或缩放框"
---

## **概述**
PowerPoint 中的缩放允许您在特定幻灯片、部分和演示文稿之间快速切换。当您进行演示时，这种快速浏览内容的能力非常有用。

![overview_image](overview.png)

* 要在单个幻灯片上总结整个演示文稿，请使用 [总结缩放](#Summary-Zoom)。
* 要仅显示选择的幻灯片，请使用 [幻灯片缩放](#Slide-Zoom)。
* 要仅显示单个部分，请使用 [部分缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示文稿更具动态性，允许您以任意顺序在幻灯片之间自由导航，而不打断演示的流畅性。幻灯片缩放非常适合没有许多部分的短演示，但您仍然可以在不同的演示场景中使用它们。

幻灯片缩放使您能够深入多个信息片段，同时感觉是在单一画布上。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType) 枚举、[IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) 接口，以及 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口下的一些方法。

### **创建缩放框**

您可以通过以下方式在幻灯片上添加缩放框：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建您打算链接缩放框的新幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 将包含对已创建幻灯片引用的缩放框添加到第一张幻灯片。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何在幻灯片上创建缩放框：

``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 为第二张幻灯片创建背景
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 为第二张幻灯片创建文本框
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第二张幻灯片");

    // 为第三张幻灯片创建背景
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 为第三张幻灯片创建文本框
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第三张幻灯片");

    //添加缩放框对象
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **使用自定义图像创建缩放框**
使用 Aspose.Slides for Java，您可以通过以下方式创建具有不同幻灯片预览图像的缩放框：
1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建一张您打算链接缩放框的新幻灯片。
3. 为幻灯片添加标识文本和背景。
4. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的图像集合中添加图像，创建 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，该图像将用于填充框。
5. 将包含对已创建幻灯片引用的缩放框添加到第一张幻灯片。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何创建具有不同图像的缩放框：

``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 为第二张幻灯片创建背景
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 为第三张幻灯片创建文本框
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第二张幻灯片");

    // 为缩放对象创建新图像
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // 添加缩放框对象
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **格式化缩放框**
在前面的部分中，我们向您展示了如何创建简单的缩放框。要创建更复杂的缩放框，您需要更改简单框的格式。您可以给缩放框应用多种格式设置。

您可以通过以下方式控制幻灯片上缩放框的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建新幻灯片，以链接到您打算链接的缩放框。
3. 为创建的幻灯片添加一些标识文本和背景。
4. 将包含对已创建幻灯片引用的缩放框添加到第一张幻灯片。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的图像集合中添加图像，创建 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，该图像将用于填充框。
6. 为第一个缩放框对象设置自定义图像。
7. 更改第二个缩放框对象的线格式。
8. 从第二个缩放框对象的图像中移除背景。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何更改幻灯片上缩放框的格式：

``` java 
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // 为第二张幻灯片创建背景
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // 为第二张幻灯片创建文本框
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第二张幻灯片");

    // 为第三张幻灯片创建背景
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 为第三张幻灯片创建文本框
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("第三张幻灯片");

    //添加缩放框对象
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // 为缩放对象创建新图像
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // 为 zoomFrame1 对象设置自定义图像
    zoomFrame1.setImage(picture);

    // 为 zoomFrame2 对象设置缩放框格式
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // 设置不显示 zoomFrame2 对象的背景
    zoomFrame2.setShowBackground(false);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **部分缩放**

部分缩放是指向演示文稿中某一部分的链接。您可以使用部分缩放返回到您希望重点强调的部分。或者您可以用它们来突出演示文稿中某些部分之间的关联。

![overview_image](seczoomsel.png)

对于部分缩放对象，Aspose.Slides 提供了 [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口下的一些方法。

### **创建部分缩放框**

您可以通过以下方式在幻灯片上添加部分缩放框：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个新部分以链接到缩放框。
5. 将包含对创建部分的引用的部分缩放框添加到第一张幻灯片。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何在幻灯片上创建缩放框：

``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 1", slide);

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **使用自定义图像创建部分缩放框**

使用 Aspose.Slides for Java，您可以通过以下方式创建具有不同幻灯片预览图像的部分缩放框：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个新部分以链接到缩放框。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的图像集合中添加图像，创建 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，该图像将用于填充框。
5. 将包含对创建部分的引用的部分缩放框添加到第一张幻灯片。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何创建具有不同图像的缩放框：

``` java 
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 1", slide);

    // 为缩放对象创建新图像
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **格式化部分缩放框**

要创建更复杂的部分缩放框，您需要更改简单框的格式。您可以给部分缩放框应用多种格式设置。

您可以通过以下方式控制幻灯片上部分缩放框的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建一个新部分以链接到缩放框。
5. 将包含对创建部分的引用的部分缩放框添加到第一张幻灯片。
6. 更改创建的部分缩放对象的大小和位置。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的图像集合中添加图像，创建 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，该图像将用于填充框。
8. 为创建的部分缩放框对象设置自定义图像。
9. 设置*从链接部分返回到原始幻灯片*的能力。
10. 从部分缩放框对象的图像中移除背景。
11. 更改第二个缩放框对象的线格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何更改部分缩放框的格式：

``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 1", slide);

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // 格式化 SectionZoomFrame
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

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **总结缩放**

总结缩放就像一个着陆页，所有演示文稿的部分都一次性显示出来。进行演示时，您可以使用缩放在演示文稿中的任意位置之间跳转。您可以发挥创意，提前跳转或重新访问幻灯片中的内容，而不打断演示的流畅性。

![overview_image](sumzoomsel.png)

对于总结缩放对象，Aspose.Slides 提供了 [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) 和 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) 接口，以及 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口下的一些方法。

### **创建总结缩放**

您可以通过以下方式在幻灯片上添加总结缩放框：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建带有标识背景的新幻灯片和新部分。
3. 将总结缩放框添加到第一张幻灯片。
4. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何在幻灯片上创建总结缩放框：

``` java 
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 2", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 3", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 4", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **添加和删除总结缩放部分**

总结缩放框中的所有部分由 [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) 对象表示，这些对象存储在 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) 对象中。您可以通过 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) 接口以以下方式添加或删除总结缩放部分对象：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建带有标识背景的新幻灯片和新部分。
3. 将总结缩放框添加到第一张幻灯片。
4. 添加新幻灯片和部分到演示文稿。
5. 将创建的部分添加到总结缩放框中。
6. 从总结缩放框中删除第一部分。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何在总结缩放框中添加和删除部分：

``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 2", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    ISection section3 = pres.getSections().addSection("部分 3", slide);

    // 向总结缩放中添加部分
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // 从总结缩放中移除部分
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **格式化总结缩放部分**

要创建更复杂的总结缩放部分对象，您需要更改简单框的格式。您可以给总结缩放部分对象应用多种格式设置。

您可以通过以下方式控制总结缩放部分对象的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 创建带有标识背景的新幻灯片和新部分。
3. 将总结缩放框添加到第一张幻灯片。
4. 从 `ISummaryZoomSectionCollection` 中获取第一个总结缩放部分对象。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的图像集合中添加图像，创建 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，该图像将用于填充框。
6. 为创建的部分缩放框对象设置自定义图像。
7. 设置*从链接部分返回到原始幻灯片*的能力。 
8. 更改第二个缩放框对象的线格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何更改总结缩放部分对象的格式：

``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新部分
    pres.getSections().addSection("部分 2", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 获取第一个 SummaryZoomSection 对象
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // 格式化 SummaryZoomSection 对象
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

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```