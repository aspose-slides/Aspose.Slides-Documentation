---
title: 在 .NET 中管理演示文稿缩放
linktitle: 管理缩放
type: docs
weight: 60
url: /zh/net/manage-zoom/
keywords:
- 缩放
- 缩放框架
- 幻灯片缩放
- 章节缩放
- 摘要缩放
- 添加缩放
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 创建和自定义缩放 — 在 PPT、PPTX 和 ODP 演示文稿中在章节之间跳转，添加缩略图和过渡效果。"
---

## **概览**
PowerPoint 中的缩放功能允许您在演示文稿的特定幻灯片、章节和部分之间跳转。当您进行演示时，这种快速导航内容的能力可能非常有用。

![overview_image](overview.png)

* 若要在单张幻灯片上概括整个演示文稿，请使用[摘要缩放](#Summary-Zoom)。
* 若只显示选定的幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 若只显示单个章节，请使用[章节缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使您的演示更具动态性，允许您以任意顺序在幻灯片之间自由导航，而不会中断演示的流程。幻灯片缩放非常适合章节不多的简短演示，但也可以在不同的演示场景中使用。

幻灯片缩放帮助您在看似同一画布上深入多个信息块。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了[ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype) 枚举、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) 接口，以及在[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口下的一些方法。

### **创建缩放框架**

您可以按以下方式在幻灯片上添加缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 创建您打算链接到缩放框架的新的幻灯片。
3. 为创建的幻灯片添加标识文本和背景。
4. 将缩放框架（包含对已创建幻灯片的引用）添加到第一张幻灯片。
5. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上创建缩放框架：
``` csharp 
using (Presentation pres = new Presentation())
{
    //Adds new slides to the presentation
    // 向演示文稿添加新幻灯片
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Creates a background for the second slide
    // 为第二张幻灯片创建背景
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Creates a text box for the second slide
    // 为第二张幻灯片创建文本框
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Creates a background for the third slide
    // 为第三张幻灯片创建背景
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Create a text box for the third slide
    // 为第三张幻灯片创建文本框
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Adds ZoomFrame objects
    //添加 ZoomFrame 对象
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Saves the presentation
    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **使用自定义图像创建缩放框架**
使用 Aspose.Slides for .NET，您可以按以下方式创建具有不同幻灯片预览图像的缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 创建您打算链接到缩放框架的新幻灯片。
3. 为该幻灯片添加标识文本和背景。
4. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充框架。
5. 将缩放框架（包含对已创建幻灯片的引用）添加到第一张幻灯片。
6. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何使用不同图像创建缩放框架：
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

### **格式化缩放框架**
在前面的章节中，我们向您展示了如何创建简单的缩放框架。要创建更复杂的缩放框架，您需要更改简单框架的格式。您可以对缩放框架应用多种格式设置选项。

您可以按以下方式控制幻灯片上缩放框架的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 创建您打算链接到缩放框架的新幻灯片。
3. 为创建的幻灯片添加一些标识文本和背景。
4. 将缩放框架（包含对已创建幻灯片的引用）添加到第一张幻灯片。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充框架。
6. 为第一个缩放框架对象设置自定义图像。
7. 更改第二个缩放框架对象的线条格式。
8. 移除第二个缩放框架对象图像的背景。
9. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上更改缩放框架的格式：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
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

    //添加 ZoomFrame 对象
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 为缩放对象创建新图像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 为 zoomFrame1 对象设置自定义图像
    zoomFrame1.ZoomImage = ppImage;

    // 为 zoomFrame2 对象设置缩放框架的线条格式
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // 设置 zoomFrame2 对象不显示背景
    zoomFrame2.ShowBackground = false;

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **章节缩放**

章节缩放是指向演示文稿中某个章节的链接。您可以使用章节缩放返回您想要特别强调的章节，或用来突出展示演示文稿中某些部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了[ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) 接口以及在[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口下的一些方法。

### **创建章节缩放框架**

您可以按以下方式在幻灯片上添加章节缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建您打算链接到缩放框架的新章节。
5. 将章节缩放框架（包含对已创建章节的引用）添加到第一张幻灯片。
6. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上创建缩放框架：
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

### **使用自定义图像创建章节缩放框架**

使用 Aspose.Slides for .NET，您可以按以下方式创建具有不同幻灯片预览图像的章节缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建您打算链接到缩放框架的新章节。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充框架。
6. 将章节缩放框架（包含对已创建章节的引用）添加到第一张幻灯片。
7. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何使用不同图像创建缩放框架：
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

### **格式化章节缩放框架**

要创建更复杂的章节缩放框架，您必须更改简单框架的格式。您可以对章节缩放框架应用多种格式设置选项。

您可以按以下方式控制章节缩放框架在幻灯片上的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 创建一张新幻灯片。
3. 为创建的幻灯片添加标识背景。
4. 创建您打算链接到缩放框架的新章节。
5. 将章节缩放框架（包含对已创建章节的引用）添加到第一张幻灯片。
6. 更改已创建章节缩放对象的大小和位置。
7. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充框架。
8. 为已创建的章节缩放框架对象设置自定义图像。
9. 设置*从链接章节返回原始幻灯片*的功能。
10. 移除章节缩放框架对象图像的背景。
11. 更改第二个缩放框架对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何更改章节缩放框架的格式：
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

摘要缩放类似于登录页面，所有演示文稿的片段一次性展示。当您进行演示时，可以使用缩放在演示的任意位置之间跳转，顺序随意。您可以创意发挥，跳过或重新访问幻灯片的部分，而不会打断演示的流程。

![overview_image](sumzoomsel.png)

对于摘要缩放对象，Aspose.Slides 提供了[ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) 和[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) 接口，以及在[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口下的一些方法。

### **创建摘要缩放**

您可以按以下方式在幻灯片上添加摘要缩放框架：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 为创建的幻灯片添加标识背景并创建新章节。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上创建摘要缩放框架：
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

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **添加和删除摘要缩放章节**

摘要缩放框架中的所有章节均由[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) 对象表示，这些对象存储在[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) 对象中。您可以通过[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) 接口按以下方式添加或删除摘要缩放章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 为创建的幻灯片添加标识背景并创建新章节。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 向演示文稿中添加新幻灯片和章节。
5. 将创建的章节添加到摘要缩放框架中。
6. 从摘要缩放框架中移除第一章节。
7. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在摘要缩放框架中添加和删除章节：
``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新章节
    pres.Sections.AddSection("Section 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新章节
    pres.Sections.AddSection("Section 2", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新章节
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // 向 Summary Zoom 添加章节
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // 从 Summary Zoom 中移除章节
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **格式化摘要缩放章节**

要创建更复杂的摘要缩放章节对象，您必须更改简单框架的格式。您可以对摘要缩放章节对象应用多种格式设置选项。

您可以按以下方式控制摘要缩放框架中摘要缩放章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 为创建的幻灯片添加标识背景并创建新章节。
3. 将摘要缩放框架添加到第一张幻灯片。
4. 从 `ISummaryZoomSectionCollection` 中获取第一个章节对象。
5. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，用于填充框架。
6. 为创建的章节缩放框架对象设置自定义图像。
7. 设置*从链接章节返回原始幻灯片*的功能。
8. 更改第二个缩放框架对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何更改摘要缩放章节对象的格式：
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

    // 为 SummaryZoomSection 对象设置格式
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

**我可以控制在显示目标后返回“父”幻灯片吗？**

可以。[Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) 或 [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) 具有 `ReturnToParent` 行为，启用后会在访问目标内容后将观看者带回来源幻灯片。

**我可以调整缩放过渡的“速度”或持续时间吗？**

可以。Zoom 支持设置 `TransitionDuration`，以控制跳转动画的时长。

**演示文稿中可以包含多少个 Zoom 对象有上限吗？**

官方文档未记录硬性 API 限制。实际限制取决于整体演示的复杂度和观看者的性能。您可以添加大量 Zoom 框架，但需考虑文件大小和渲染时间。