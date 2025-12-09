---
title: 管理缩放
type: docs
weight: 60
url: /zh/nodejs-java/manage-zoom/
keywords: "缩放, 缩放框架, 添加缩放, 格式化缩放框架, 概要缩放, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中向 PowerPoint 演示文稿添加缩放或缩放框架"
---

## **概述**

PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间跳转。在演示时，这种快速跨内容导航的能力可能非常有用。

![overview_image](overview.png)

* 要在单张幻灯片上概览整个演示文稿，请使用[概要缩放](#Summary-Zoom)。
* 仅显示选定幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 仅显示单个章节，请使用[章节缩放](#Section-Zoom)。

## **幻灯片缩放**

幻灯片缩放可以使您的演示更具活力，允许您以任意顺序自由在幻灯片之间导航，而不会中断演示的流程。幻灯片缩放非常适合章节不多的短篇演示，但您仍可在不同的演示场景中使用它们。

幻灯片缩放帮助您在感觉像在单一画布上的同时深入多个信息块。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomImageType) 枚举、[ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomFrame) 类以及 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 类下的部分方法。

### **创建缩放帧**

您可以通过以下方式在幻灯片上添加缩放帧：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 创建您打算链接缩放帧的新幻灯片。
3. 向创建的幻灯片添加标识文本和背景。
4. 向第一张幻灯片添加缩放帧（包含对创建的幻灯片的引用）。
5. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 向演示文稿添加新幻灯片
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 为第二张幻灯片创建背景
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 为第二张幻灯片创建文本框
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 为第三张幻灯片创建背景
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 为第三张幻灯片创建文本框
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // 添加 ZoomFrame 对象
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **使用自定义图像创建缩放帧**

使用 Aspose.Slides for Node.js via Java，您可以通过以下方式创建带有不同幻灯片预览图像的缩放帧：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 创建您打算链接缩放帧的新幻灯片。
3. 向该幻灯片添加标识文本和背景。
4. 通过向与 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) 对象，以用于填充帧。
5. 向第一张幻灯片添加缩放帧（包含对创建的幻灯片的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 向演示文稿添加新幻灯片
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 为第二张幻灯片创建背景
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 为第三张幻灯片创建文本框
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 为缩放对象创建新图像
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 添加 ZoomFrame 对象
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **格式化缩放帧**

在前面的章节中，我们向您展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，您必须更改简单帧的格式。您可以对缩放帧应用多种格式选项。

您可以通过以下方式控制幻灯片上缩放帧的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 创建您打算链接缩放帧的新幻灯片。
3. 向创建的幻灯片添加一些标识文本和背景。
4. 向第一张幻灯片添加缩放帧（包含对创建的幻灯片的引用）。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) 对象，以用于填充帧。
6. 为第一个缩放帧对象设置自定义图像。
7. 更改第二个缩放帧对象的线条格式。
8. 移除第二个缩放帧对象图像的背景。
5. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 向演示文稿添加新幻灯片
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // 为第二张幻灯片创建背景
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // 为第二张幻灯片创建文本框
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // 为第三张幻灯片创建背景
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // 为第三张幻灯片创建文本框
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // 添加 ZoomFrame 对象
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // 为缩放对象创建新图像
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 为 zoomFrame1 对象设置自定义图像
    zoomFrame1.setImage(picture);
    // 为 zoomFrame2 对象设置缩放框架格式
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // 设置 zoomFrame2 对象不显示背景
    zoomFrame2.setShowBackground(false);
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **章节缩放**

章节缩放是指向演示文稿中章节的链接。您可以使用章节缩放返回您想要重点强调的章节，或用来突出演示文稿中某些部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了 [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionZoomFrame) 类以及 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 类下的部分方法。

### **创建章节缩放框架**

您可以通过以下方式在幻灯片上添加章节缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建您打算链接缩放帧的新章节。
5. 向第一张幻灯片添加章节缩放框架（包含对创建的章节的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 向演示文稿添加新幻灯片
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);
    // 添加 SectionZoomFrame 对象
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **使用自定义图像创建章节缩放框架**

使用 Aspose.Slides for Node.js via Java，您可以通过以下方式创建带有不同幻灯片预览图像的章节缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建您打算链接缩放帧的新章节。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) 对象，以用于填充帧。
5. 向第一张幻灯片添加章节缩放框架（包含对创建的章节的引用）。
6. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 向演示文稿添加新幻灯片
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);
    // 为缩放对象创建新图像
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 添加 SectionZoomFrame 对象
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **格式化章节缩放框架**

要创建更复杂的章节缩放框架，您必须更改简单帧的格式。您可以对章节缩放框架应用多种格式选项。

您可以通过以下方式控制幻灯片上章节缩放框架的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建您打算链接缩放帧的新章节。
5. 向第一张幻灯片添加章节缩放框架（包含对创建的章节的引用）。
6. 更改创建的章节缩放对象的大小和位置。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) 对象，以用于填充帧。
8. 为创建的章节缩放框架对象设置自定义图像。
9. 设置*从链接的章节返回到原始幻灯片*的功能。
10. 移除章节缩放框架对象图像的背景。
11. 更改第二个缩放帧对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 向演示文稿添加新幻灯片
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);
    // 添加 SectionZoomFrame 对象
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // SectionZoomFrame 的格式设置
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **概要缩放**

概要缩放类似于一个登陆页，所有演示文稿的片段一次性展示。当您进行演示时，可以使用缩放在演示的任意位置之间任意顺序跳转。您可以创意无限，快进或回顾幻灯片的各个部分，而不会打断演示的流程。

![overview_image](sumzoomsel.png)

对于概要缩放对象，Aspose.Slides 提供了 [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomFrame)、[SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) 与 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) 类以及 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 类下的部分方法。

### **创建概要缩放**

您可以通过以下方式在幻灯片上添加概要缩放框架：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 为创建的幻灯片创建带有标识背景的新幻灯片并创建新章节。
3. 将概要缩放框架添加到第一张幻灯片。
4. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加新的幻灯片到演示文稿
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 添加新的章节到演示文稿
    pres.getSections().addSection("Section 1", slide);
    // 添加新的幻灯片到演示文稿
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 添加新的章节到演示文稿
    pres.getSections().addSection("Section 2", slide);
    // 添加新的幻灯片到演示文稿
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 添加新的章节到演示文稿
    pres.getSections().addSection("Section 3", slide);
    // 添加新的幻灯片到演示文稿
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 添加新的章节到演示文稿
    pres.getSections().addSection("Section 4", slide);
    // 添加 SummaryZoomFrame 对象
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **添加和删除概要缩放章节**

所有概要缩放框架中的章节均由 [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) 对象表示，这些对象存储在 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) 对象中。您可以通过以下方式使用 [SummaryZoomSectionCollection] 类添加或删除概要缩放章节对象：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 为创建的幻灯片创建带有标识背景的新幻灯片并创建新章节。
3. 将概要缩放框架添加到第一张幻灯片。
4. 向演示文稿添加新幻灯片和章节。
5. 将创建的章节添加到概要缩放框架中。
6. 从概要缩放框架中移除第一章节。
7. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加新的幻灯片到演示文稿
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);
    // 添加新的幻灯片到演示文稿
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 2", slide);
    // 添加 SummaryZoomFrame 对象
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 添加新的幻灯片到演示文稿
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    var section3 = pres.getSections().addSection("Section 3", slide);
    // 向 Summary Zoom 添加章节
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // 从 Summary Zoom 中移除章节
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **格式化概要缩放章节**

要创建更复杂的概要缩放章节对象，您必须更改简单帧的格式。您可以对概要缩放章节对象应用多种格式选项。

您可以通过以下方式控制概要缩放框架中概要缩放章节对象的格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 为创建的幻灯片创建带有标识背景的新幻灯片并创建新章节。
3. 将概要缩放框架添加到第一张幻灯片。
4. 从 `ISummaryZoomSectionCollection` 中获取第一个对象的概要缩放章节对象。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 对象关联的 images 集合中添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) 对象，以用于填充帧。
8. 为创建的章节缩放框架对象设置自定义图像。
9. 设置*从链接的章节返回到原始幻灯片*的功能。
11. 更改第二个缩放帧对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 向演示文稿添加新幻灯片
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);
    // 向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 2", slide);
    // 添加 SummaryZoomFrame 对象
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // 获取第一个 SummaryZoomSection 对象
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // 对 SummaryZoomSection 对象进行格式设置
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // 保存演示文稿
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以控制在显示目标后返回“父”幻灯片吗？**

是的。[Zoom 框架](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/)或[章节](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/)都有 `setReturnToParent` 方法，启用后在观看者访问目标内容后会返回到原始幻灯片。

**我可以调整 Zoom 过渡的“速度”或持续时间吗？**

可以。Zoom 提供 `setTransitionDuration` 方法，您可以控制跳转动画的持续时间。

**演示文稿中可以包含多少个 Zoom 对象有上限吗？**

没有文档中硬性的 API 限制。实际限制取决于演示文稿的整体复杂度和观看者的性能。您可以添加很多 Zoom 框架，但需考虑文件大小和渲染时间。