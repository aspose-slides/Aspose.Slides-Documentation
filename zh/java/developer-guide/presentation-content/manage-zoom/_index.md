---
title: 管理 Java 中的演示文稿缩放
linktitle: 管理缩放
type: docs
weight: 60
url: /zh/java/manage-zoom/
keywords:
- 缩放
- 缩放框架
- 幻灯片缩放
- 章节缩放
- 摘要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 创建和自定义缩放 — 在 PPT、PPTX 和 ODP 演示文稿中在章节间跳转、添加缩略图和过渡效果。"
---

## **概览**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间来回跳转。在演示时，这种快速浏览内容的能力可能非常有用。 

![overview_image](overview.png)

* 要在单张幻灯片上概括整个演示文稿，请使用[Summary Zoom](#Summary-Zoom)。
* 若只显示选定的幻灯片，请使用[Slide Zoom](#Slide-Zoom)。
* 若只显示单个章节，请使用[Section Zoom](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示更具活力，让您能够以任意顺序在幻灯片之间自由导航，而不会中断演示流程。幻灯片缩放非常适合章节不多的短篇演示，但在其他演示场景中也同样可用。

幻灯片缩放帮助您在感觉仍在同一画布上的情况下，深入查看多个信息片段。 

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了 [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType) 枚举、[IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口下的部分方法。

### **创建缩放框架**

您可以按下面的方式在幻灯片上添加缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 创建要链接缩放框架的新幻灯片。  
3. 向已创建的幻灯片添加标识文本和背景。  
4. 在第一张幻灯片上添加缩放框架（包含对已创建幻灯片的引用）。  
5. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何在幻灯片上创建缩放框架：
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
    autoshape.getTextFrame().setText("Second Slide");

    // 为第三张幻灯片创建背景
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 为第三张幻灯片创建文本框
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //添加 ZoomFrame 对象
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **使用自定义图像创建缩放框架**
使用 Aspose.Slides for Java，您可以按下面的方式创建带有不同幻灯片预览图像的缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 创建要链接缩放框架的新幻灯片。  
3. 向该幻灯片添加标识文本和背景。  
4. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，用于填充框架。  
5. 在第一张幻灯片上添加缩放框架（包含对已创建幻灯片的引用）。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何使用不同图像创建缩放框架：
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
    autoshape.getTextFrame().setText("Second Slide");

    // 为缩放对象创建新图像
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //添加 ZoomFrame 对象
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **格式化缩放框架**
在前面的章节中，我们展示了如何创建简单的缩放框架。要创建更复杂的缩放框架，您需要更改简单框架的格式。您可以对缩放框架应用多种格式化选项。

您可以按下面的方式在幻灯片上控制缩放框架的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 创建要链接缩放框架的新幻灯片。  
3. 向已创建的幻灯片添加一些标识文本和背景。  
4. 在第一张幻灯片上添加缩放框架（包含对已创建幻灯片的引用）。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，用于填充框架。  
6. 为第一个缩放框架对象设置自定义图像。  
7. 更改第二个缩放框架对象的线条格式。  
8. 移除第二个缩放框架对象图像的背景。  
5. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何在幻灯片上更改缩放框架的格式：
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
    autoshape.getTextFrame().setText("Second Slide");

    // 为第三张幻灯片创建背景
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // 为第三张幻灯片创建文本框
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //添加 ZoomFrame 对象
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

    // 为 zoomFrame2 对象设置缩放框架格式
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // 设置 zoomFrame2 对象不显示背景
    zoomFrame2.setShowBackground(false);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **章节缩放**

章节缩放是链接到演示文稿中某一章节的快捷方式。您可以使用章节缩放返回需要特别强调的章节，或用来突出演示中各部分之间的关联。 

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了 [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口下的部分方法。

### **创建章节缩放框架**

您可以按下面的方式在幻灯片上添加章节缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 向已创建的幻灯片添加标识背景。  
4. 创建要链接缩放框架的新章节。  
5. 在第一张幻灯片上添加章节缩放框架（包含对已创建章节的引用）。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何在幻灯片上创建缩放框架：
``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);

    // 向演示文稿添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **使用自定义图像创建章节缩放框架**

使用 Aspose.Slides for Java，您可以按下面的方式创建带有不同幻灯片预览图像的章节缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 向已创建的幻灯片添加标识背景。  
4. 创建要链接缩放框架的新章节。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，用于填充框架。  
5. 在第一张幻灯片上添加章节缩放框架（包含对已创建章节的引用）。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何使用不同图像创建缩放框架：
``` java 
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);

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

### **格式化章节缩放框架**

要创建更复杂的章节缩放框架，您需要更改简单框架的格式。您可以对章节缩放框架应用多种格式化选项。

您可以按下面的方式在幻灯片上控制章节缩放框架的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 向已创建的幻灯片添加标识背景。  
4. 创建要链接缩放框架的新章节。  
5. 在第一张幻灯片上添加章节缩放框架（包含对已创建章节的引用）。  
6. 更改已创建章节缩放对象的大小和位置。  
7. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，用于填充框架。  
8. 为已创建的章节缩放框架对象设置自定义图像。  
9. 设置 *返回链接章节的原始幻灯片* 的功能。  
10. 移除章节缩放框架对象图像的背景。  
11. 更改第二个缩放框架对象的线条格式。  
12. 更改过渡时长。  
13. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何更改章节缩放框架的格式：
``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // 为 SectionZoomFrame 设置格式
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



## **摘要缩放**

摘要缩放类似于一个登录页，展示了演示文稿的所有片段。当您进行演示时，可以使用缩放在演示的任意位置之间跳转，顺序任意。您可以创意性地跳过或重新查看幻灯片的任何部分，而不会中断演示的流畅性。

![overview_image](sumzoomsel.png)

对于摘要缩放对象，Aspose.Slides 提供了 [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame)、[ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) 和 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) 接口以及 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 接口下的部分方法。

### **创建摘要缩放**

您可以按下面的方式在幻灯片上添加摘要缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 为新创建的幻灯片添加标识背景并创建新章节。  
3. 将摘要缩放框架添加到第一张幻灯片。  
4. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何在幻灯片上创建摘要缩放框架：
``` java 
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 2", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 3", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 4", slide);

    // 向演示文稿添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **添加和删除摘要缩放章节**

摘要缩放框架中的所有章节均由 [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) 对象表示，这些对象存储在 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) 中。您可以通过 [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) 接口按下面的方式添加或删除摘要缩放章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 为新创建的幻灯片添加标识背景并创建新章节。  
3. 将摘要缩放框架添加到第一张幻灯片。  
4. 为演示文稿添加新幻灯片和新章节。  
5. 将创建的章节添加到摘要缩放框架中。  
6. 从摘要缩放框架中移除第一章节。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何在摘要缩放框架中添加和移除章节：
``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 2", slide);

    // 向演示文稿添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // 向 Summary Zoom 添加章节
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // 从 Summary Zoom 中移除章节
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // 保存演示文稿
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **格式化摘要缩放章节**

要创建更复杂的摘要缩放章节对象，您需要更改简单框架的格式。您可以对摘要缩放章节对象应用多种格式化选项。 

您可以按下面的方式在摘要缩放框架中控制摘要缩放章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
2. 为新创建的幻灯片添加标识背景并创建新章节。  
3. 将摘要缩放框架添加到第一张幻灯片。  
4. 从 `ISummaryZoomSectionCollection` 中获取第一个章节对象。  
7. 通过向与 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象关联的 images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，用于填充框架。  
8. 为创建的章节缩放框架对象设置自定义图像。  
9. 设置 *返回链接章节的原始幻灯片* 的功能。  
11. 更改第二个缩放框架对象的线条格式。  
12. 更改过渡时长。  
13. 将修改后的演示文稿写入为 PPTX 文件。  

此 Java 代码演示了如何更改摘要缩放章节对象的格式：
``` java
Presentation pres = new Presentation();
try {
    //向演示文稿添加新幻灯片
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // 向演示文稿添加新章节
    pres.getSections().addSection("Section 2", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // 获取第一个 SummaryZoomSection 对象
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // 为 SummaryZoomSection 对象设置格式
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


## **FAQ**

**是否可以控制在显示目标后返回“父”幻灯片？**

可以。[Zoom frame](https://reference.aspose.com/slides/java/com.aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/java/com.aspose.slides/sectionzoomframe/) 具有 `ReturnToParent` 行为，启用后，观众在访问目标内容后会返回到原始幻灯片。

**是否可以调整 Zoom 过渡的“速度”或时长？**

可以。Zoom 支持设置 `TransitionDuration`，从而控制跳转动画的时长。

**演示文稿能包含多少个 Zoom 对象有限制吗？**

文档中未列出硬性的 API 限制。实际限制取决于演示文稿的整体复杂度和查看器的性能。您可以添加许多 Zoom 框架，但需考虑文件大小和渲染时间。