---
title: 管理缩放
type: docs
weight: 60
url: /zh/net/manage-zoom/
keywords:
- 缩放
- 缩放帧
- 添加缩放
- 格式化缩放帧
- 汇总缩放
- PowerPoint 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加缩放或缩放帧"
---

## **概述**
PowerPoint 中的缩放功能可让您在演示文稿的特定幻灯片、章节和部分之间跳转。演示时，这种快速导航的能力可能非常有用。

![overview_image](overview.png)

* 若要在单张幻灯片上概述整个演示文稿，请使用[汇总缩放](#Summary-Zoom)。
* 若仅显示选定的幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 若仅显示单个章节，请使用[章节缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可让您的演示更具动态性，使您能够自由选择任意顺序在幻灯片之间切换，而不会中断演示流程。幻灯片缩放非常适合章节不多的短篇演示，但也可在其他演示场景中使用。

幻灯片缩放帮助您在单一画布上深入多条信息。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides 提供了[ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype)枚举、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe)接口以及[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下的若干方法。

### **创建缩放帧**

您可以按以下方式在幻灯片上添加缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 创建您希望链接到缩放帧的新幻灯片。  
3. 为创建的幻灯片添加标识文本和背景。  
4. 将缩放帧（包含对已创建幻灯片的引用）添加到第一张幻灯片。  
5. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上创建缩放帧：
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
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **使用自定义图像创建缩放帧**
使用 Aspose.Slides for .NET，您可以按以下方式创建带有不同幻灯片预览图像的缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 创建您希望链接到缩放帧的新幻灯片。  
3. 为该幻灯片添加标识文本和背景。  
4. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，以填充帧。  
5. 将缩放帧（包含对已创建幻灯片的引用）添加到第一张幻灯片。  
6. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何使用不同图像创建缩放帧：
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

    // 添加 ZoomFrame 对象
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **格式化缩放帧**
在前面的章节中，我们展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，您需要修改简单帧的格式。缩放帧可以应用多种格式化选项。

您可以按以下方式控制幻灯片上缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 创建您希望链接到缩放帧的新幻灯片。  
3. 为创建的幻灯片添加一些标识文本和背景。  
4. 将缩放帧（包含对已创建幻灯片的引用）添加到第一张幻灯片。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，以填充帧。  
6. 为第一个缩放帧对象设置自定义图像。  
7. 更改第二个缩放帧对象的线条格式。  
8. 移除第二个缩放帧对象图像的背景。  
9. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上更改缩放帧的格式：
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

    // 为 zoomFrame2 对象设置缩放帧格式
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

章节缩放是指向演示文稿中某个章节的链接。您可以使用章节缩放返回您想要强调的章节，或用于突出演示文稿中各部分之间的关联。

![overview_image](seczoomsel.png)

对于章节缩放对象，Aspose.Slides 提供了[ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe)接口以及[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下的若干方法。

### **创建章节缩放帧**

您可以按以下方式将章节缩放帧添加到幻灯片：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您希望链接到缩放帧的新章节。  
5. 将章节缩放帧（包含对已创建章节的引用）添加到第一张幻灯片。  
6. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上创建缩放帧：
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

    // 添加一个 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **使用自定义图像创建章节缩放帧**

使用 Aspose.Slides for .NET，您可以按以下方式创建带有不同幻灯片预览图像的章节缩放帧：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您希望链接到缩放帧的新章节。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，以填充帧。  
6. 将章节缩放帧（包含对已创建章节的引用）添加到第一张幻灯片。  
7. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何使用不同图像创建缩放帧：
``` csharp 
using (Presentation pres = new Presentation())
{
    //添加新幻灯片到演示文稿
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新章节
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

### **格式化章节缩放帧**

要创建更复杂的章节缩放帧，您需要修改简单帧的格式。章节缩放帧可应用多种格式化选项。

您可以按以下方式控制章节缩放帧的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 创建一张新幻灯片。  
3. 为创建的幻灯片添加标识背景。  
4. 创建您希望链接到缩放帧的新章节。  
5. 将章节缩放帧（包含对已创建章节的引用）添加到第一张幻灯片。  
6. 更改已创建章节缩放对象的大小和位置。  
7. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 Images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，以填充帧。  
8. 为已创建的章节缩放帧对象设置自定义图像。  
9. 设置*从链接章节返回到原始幻灯片*的功能。  
10. 移除章节缩放帧对象图像的背景。  
11. 更改第二个缩放帧对象的线条格式。  
12. 更改过渡持续时间。  
13. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何更改章节缩放帧的格式：
``` csharp 
using (Presentation pres = new Presentation())
{
    //添加新幻灯片到演示文稿
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 添加新章节到演示文稿
    pres.Sections.AddSection("Section 1", slide);

    // 添加 SectionZoomFrame 对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // 为 SectionZoomFrame 设置格式
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


## **汇总缩放**

汇总缩放类似于登录页，展示演示文稿的所有部分。当您进行演示时，可使用缩放在演示文稿的任意位置之间随意跳转。您可以发挥创意，提前跳过或重新访问幻灯片的某些部分，而不会打断演示流畅性。

![overview_image](sumzoomsel.png)

对于汇总缩放对象，Aspose.Slides 提供了[ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)以及[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)接口，并在[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下提供若干方法。

### **创建汇总缩放**

您可以按以下方式将汇总缩放帧添加到幻灯片：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 为创建的幻灯片添加标识背景并创建新章节。  
3. 将汇总缩放帧添加到第一张幻灯片。  
4. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在幻灯片上创建汇总缩放帧：
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

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新章节
    pres.Sections.AddSection("Section 3", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新章节
    pres.Sections.AddSection("Section 4", slide);

    // 添加 SummaryZoomFrame 对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **添加和移除汇总缩放章节**

汇总缩放帧中的所有章节均由[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)对象表示，这些对象存储在[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)中。您可以通过[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)接口按以下方式添加或移除汇总缩放章节对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 为创建的幻灯片添加标识背景并创建新章节。  
3. 将汇总缩放帧添加到第一张幻灯片。  
4. 向演示文稿中添加新幻灯片和章节。  
5. 将创建的章节添加到汇总缩放帧。  
6. 从汇总缩放帧中移除第一章节。  
7. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何在汇总缩放帧中添加和移除章节：
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

    // 向汇总缩放添加章节
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // 从汇总缩放中移除章节
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **格式化汇总缩放章节**

要创建更复杂的汇总缩放章节对象，您需要修改简单帧的格式。汇总缩放章节对象可应用多种格式化选项。

您可以按以下方式控制汇总缩放帧中章节对象的格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 为创建的幻灯片添加标识背景并创建新章节。  
3. 将汇总缩放帧添加到第一张幻灯片。  
4. 从 `ISummaryZoomSectionCollection` 中获取第一章节对象。  
5. 通过向与 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象关联的 images 集合中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) 对象，以填充帧。  
6. 为创建的章节缩放帧对象设置自定义图像。  
7. 设置*从链接章节返回到原始幻灯片*的功能。  
8. 更改第二个缩放帧对象的线条格式。  
9. 更改过渡持续时间。  
10. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何更改汇总缩放章节对象的格式：
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


## **FAQ**

**是否可以控制在显示目标后返回“父”幻灯片？**

可以。[Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/)或[section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/)具有 `ReturnToParent` 行为，启用后可在浏览目标内容后返回原始幻灯片。

**是否可以调整 Zoom 过渡的“速度”或持续时间？**

可以。Zoom 支持设置 `TransitionDuration`，从而控制跳转动画的时长。

**演示文稿中可以包含多少个 Zoom 对象有限制吗？**

官方文档未列出硬性 API 限制。实际限制取决于演示文稿的整体复杂度以及观看者的性能。您可以添加大量 Zoom 帧，但需考虑文件大小和渲染时间。