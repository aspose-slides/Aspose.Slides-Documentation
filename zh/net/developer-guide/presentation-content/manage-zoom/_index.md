---
title: 管理 .NET 中的演示文稿缩放
linktitle: 管理缩放
type: docs
weight: 60
url: /zh/net/manage-zoom/
keywords:
- 缩放
- 缩放帧
- 幻灯片缩放
- 章节缩放
- 摘要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 创建和自定义缩放 — 在 PPT、PPTX 和 ODP 演示文稿中跨章节跳转，添加缩略图和过渡效果。"
---

## **概述**
PowerPoint 中的缩放功能允许您跳转到演示文稿的特定幻灯片、章节和部分，也可以从这些位置返回。当您进行演示时，这种快速导航内容的能力可能非常有用。

![overview_image](overview.png)

* 若要在单张幻灯片上概括整场演示，请使用[摘要缩放](#Summary-Zoom)。
* 若只显示选定的幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 若只显示单个章节，请使用[章节缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示更具动态性，让您能够按任意顺序自由在幻灯片之间切换，而不会中断演示的流程。幻灯片缩放非常适合章节不多的简短演示，但在其他演示场景中同样可用。

幻灯片缩放帮助您在感觉像在同一画布上的同时，深入多个信息片段。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了[ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype)枚举、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe)接口以及[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下的若干方法。

### **创建缩放帧**

您可以按以下方式在幻灯片上添加缩放帧：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 创建您打算链接缩放帧的新幻灯片。  
3. 为创建的幻灯片添加标识文本和背景。  
4. 将缩放帧（包含对已创建幻灯片的引用）添加到第一张幻灯片。  
5. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何在幻灯片上创建缩放帧：
``` csharp 
using (Presentation pres = new Presentation())
{
    // 向演示文稿添加新幻灯片
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 为第二张幻灯片创建背景
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 为第二张幻灯片创建文本框
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 为第三张幻灯片创建背景
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 为第三张幻灯片创建文本框
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    // 添加 ZoomFrame 对象
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **使用自定义图片创建缩放帧**
使用 Aspose.Slides for .NET，您可以按以下方式创建带有不同幻灯片预览图像的缩放帧：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 创建您打算链接缩放帧的新幻灯片。  
3. 为该幻灯片添加标识文本和背景。  
4. 通过向与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的 Images 集合添加图像，创建一个[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，以填充帧。  
5. 将缩放帧（包含对已创建幻灯片的引用）添加到第一张幻灯片。  
6. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何使用不同图片创建缩放帧：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 为第二张幻灯片创建背景
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 为第三张幻灯片创建文本框
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 为缩放对象创建新图像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //添加 ZoomFrame 对象
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **设置缩放帧的格式**
在前面的章节中，我们展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，您需要修改简单帧的格式。可以对缩放帧应用多种格式选项。

您可以按以下方式控制幻灯片上缩放帧的格式：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 创建您打算链接缩放帧的新幻灯片。  
3. 为创建的幻灯片添加一些标识文本和背景。  
4. 将缩放帧（包含对已创建幻灯片的引用）添加到第一张幻灯片。  
5. 通过向与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的 Images 集合添加图像，创建一个[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，以填充帧。  
6. 为第一个缩放帧对象设置自定义图像。  
7. 更改第二个缩放帧对象的线条格式。  
8. 移除第二个缩放帧对象图像的背景。  
5. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何在幻灯片上更改缩放帧的格式：
``` csharp 
using (Presentation pres = new Presentation())
{
    //Adds new slides to the presentation
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // 为第二张幻灯片创建背景
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // 为第二张幻灯片创建文本框
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // 为第三张幻灯片创建背景
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 为第三张幻灯片创建文本框
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Adds ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 为缩放对象创建新图像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 为 zoomFrame1 对象设置自定义图像
    zoomFrame1.ZoomImage = ppImage;

    // 为 zoomFrame2 对象设置缩放框架格式
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // 设置 zoomFrame2 对象不显示背景
    zoomFrame2.ShowBackground = false;

    // Saves the presentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **章节缩放**

章节缩放是指向演示文稿中某个章节的链接。您可以使用章节缩放返回到想要重点强调的章节，或用来突出演示文稿中各部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了[ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe)接口以及[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下的若干方法。

### **创建章节缩放帧**

您可以按以下方式在幻灯片上添加章节缩放帧：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您打算链接缩放帧的新章节。  
5. 将章节缩放帧（包含对已创建章节的引用）添加到第一张幻灯片。  
6. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何在幻灯片上创建缩放帧：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 1", slide);

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **使用自定义图片创建章节缩放帧**

使用 Aspose.Slides for .NET，您可以按以下方式创建带有不同幻灯片预览图像的章节缩放帧：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您打算链接缩放帧的新章节。  
5. 通过向与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的 Images 集合添加图像，创建一个[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，以填充帧。  
5. 将章节缩放帧（包含对已创建章节的引用）添加到第一张幻灯片。  
6. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何使用不同图片创建缩放帧：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 1", slide);

    // 为缩放对象创建新图像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **设置章节缩放帧的格式**

要创建更复杂的章节缩放帧，您需要修改简单帧的格式。可以对章节缩放帧应用多种格式选项。

您可以按以下方式控制幻灯片上章节缩放帧的格式：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您打算链接缩放帧的新章节。  
5. 将章节缩放帧（包含对已创建章节的引用）添加到第一张幻灯片。  
6. 更改已创建章节缩放对象的大小和位置。  
7. 通过向与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的 Images 集合添加图像，创建一个[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，以填充帧。  
8. 为已创建的章节缩放帧对象设置自定义图像。  
9. 设置*从链接章节返回到原始幻灯片*的功能。  
10. 移除章节缩放帧对象图像的背景。  
11. 更改第二个缩放帧对象的线条格式。  
12. 更改过渡持续时间。  
13. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何更改章节缩放帧的格式：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 1", slide);

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // SectionZoomFrame 的格式设置
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **摘要缩放**

摘要缩放类似于一个登录页，所有演示文稿的片段一次性显示。当您进行演示时，可以使用缩放在演示的任意位置之间随意跳转。您可以创意跳转、提前前进或重新查看幻灯片的某些部分，而不会打断演示的流畅性。

![overview_image](sumzoomsel.png)

对于摘要缩放对象，Aspose.Slides 提供了[ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)和[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)接口以及[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下的若干方法。

### **创建摘要缩放**

您可以按以下方式在幻灯片上添加摘要缩放帧：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 为创建的幻灯片添加标识背景并创建新章节。  
3. 将摘要缩放帧添加到第一张幻灯片。  
4. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何在幻灯片上创建摘要缩放帧：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 2", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 3", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 4", slide);

    //添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **添加和删除摘要缩放章节**

摘要缩放帧中的所有章节都由[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)对象表示，这些对象存储在[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)对象中。您可以通过[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)接口按以下方式添加或删除摘要缩放章节对象：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 为创建的幻灯片添加标识背景并创建新章节。  
3. 将摘要缩放帧添加到第一张幻灯片。  
4. 向演示文稿中添加新幻灯片和章节。  
5. 将创建的章节添加到摘要缩放帧。  
6. 从摘要缩放帧中移除第一章节。  
7. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何在摘要缩放帧中添加和删除章节：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 2", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // 向 Summary Zoom 添加章节
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // 从 Summary Zoom 中移除章节
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **设置摘要缩放章节的格式**

要创建更复杂的摘要缩放章节对象，您需要修改简单帧的格式。可以对摘要缩放章节对象应用多种格式选项。

您可以按以下方式控制摘要缩放帧中章节对象的格式：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。  
2. 为创建的幻灯片添加标识背景并创建新章节。  
3. 将摘要缩放帧添加到第一张幻灯片。  
4. 从`ISummaryZoomSectionCollection`中获取第一对象的摘要缩放章节。  
7. 通过向与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的 images 集合添加图像，创建一个[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，以填充帧。  
8. 为创建的章节缩放帧对象设置自定义图像。  
9. 设置*从链接章节返回到原始幻灯片*的功能。  
11. 更改第二个缩放帧对象的线条格式。  
12. 更改过渡持续时间。  
13. 将修改后的演示文稿写入 PPTX 文件。

下面的 C# 代码演示了如何更改摘要缩放章节对象的格式：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加一个新章节到演示文稿
    pres.Sections.AddSection("Section 2", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 获取第一个 SummaryZoomSection 对象
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SummaryZoomSection 对象的格式设置
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**我可以控制在显示目标后返回到“父”幻灯片吗？**

可以。 [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/)或[section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/)具有 `ReturnToParent` 行为，启用后会在访问目标内容后将观看者返回到来源幻灯片。

**我可以调整缩放过渡的“速度”或持续时间吗？**

可以。Zoom 支持设置 `TransitionDuration`，从而控制跳转动画的时长。

**演示文稿能够包含的 Zoom 对象数量有限制吗？**

官方文档未列出硬性 API 限制。实际限制取决于演示文稿的整体复杂度以及观看者的性能。您可以添加大量 Zoom 帧，但需考虑文件大小和渲染时间。