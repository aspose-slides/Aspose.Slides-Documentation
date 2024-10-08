---
title: 管理缩放
type: docs
weight: 60
url: /zh/net/manage-zoom/
keywords: 
- 缩放
- 缩放帧
- 添加缩放
- 格式缩放帧
- 概要缩放
- PowerPoint演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在C#或.NET中向PowerPoint演示文稿添加缩放或缩放帧"
---

## **概述**
PowerPoint中的缩放功能允许你跳转到特定的幻灯片、部分和演示文稿的片段。当你在进行演示时，这种快速导航的能力可能非常有用。

![overview_image](overview.png)

* 要在单个幻灯片上总结整个演示文稿，请使用[概要缩放](#Summary-Zoom)。
* 要仅显示选定的幻灯片，请使用[幻灯片缩放](#Slide-Zoom)。
* 要仅显示单个部分，请使用[部分缩放](#Section-Zoom)。

## **幻灯片缩放**
幻灯片缩放可以使你的演示更加动态，允许你在幻灯片之间以你选择的任何顺序自由导航，而不会打断你的演示流程。幻灯片缩放非常适合没有很多部分的短演示，但你仍然可以在不同的演示场景中使用它们。

幻灯片缩放帮助你深入多个信息片段，同时让你觉得自己在单个画布上。

![overview_image](slidezoomsel.png)

对于幻灯片缩放对象，Aspose.Slides提供了[ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype)枚举、[IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe)接口，以及一些方法在[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下。

### **创建缩放帧**

你可以通过以下方式向幻灯片添加缩放帧：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建新幻灯片，以便将其链接到缩放帧。
3. 为创建的幻灯片添加标识文本和背景。
4. 将缩放帧（包含对创建的幻灯片的引用）添加到第一个幻灯片。
5. 将修改后的演示文稿写入PPTX文件。

以下C#代码向幻灯片创建缩放帧：

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
    autoshape.TextFrame.Text = "第二幻灯片";

    // 为第三张幻灯片创建背景
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 为第三张幻灯片创建文本框
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "第三幻灯片";

    //添加ZoomFrame对象
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **使用自定义图像创建缩放帧**
使用Aspose.Slides for .NET，你可以通过以下方式创建具有不同幻灯片预览图像的缩放帧：
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建你打算将缩放帧链接到的新幻灯片。
3. 向幻灯片添加标识文本和背景。
4. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，用于填充帧。
5. 将缩放帧（包含对创建的幻灯片的引用）添加到第一个幻灯片。
6. 将修改后的演示文稿写入PPTX文件。

以下C#代码显示如何创建具有不同图像的缩放帧：

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
    autoshape.TextFrame.Text = "第二幻灯片";

    // 为缩放对象创建新图像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //添加ZoomFrame对象
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **格式化缩放帧**
在前面的部分中，我们向你展示了如何创建简单的缩放帧。要创建更复杂的缩放帧，你需要修改简单帧的格式。你可以对缩放帧应用多种格式选项。

你可以通过以下方式控制幻灯片上缩放帧的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建新幻灯片以链接到你打算链接的缩放帧。
3. 为创建的幻灯片添加一些标识文本和背景。
4. 将缩放帧（包含对创建的幻灯片的引用）添加到第一个幻灯片。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，用于填充帧。
6. 为第一个缩放帧对象设置自定义图像。
7. 更改第二个缩放帧对象的线条格式。
8. 从第二个缩放帧对象的图像中删除背景。
9. 将修改后的演示文稿写入PPTX文件。

以下C#代码展示了如何更改幻灯片上缩放帧的格式：

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
    autoshape.TextFrame.Text = "第二幻灯片";

    // 为第三张幻灯片创建背景
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // 为第三张幻灯片创建文本框
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "第三幻灯片";

    //添加ZoomFrame对象
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // 为缩放对象创建新图像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 设置缩放帧对象的自定义图像
    zoomFrame1.ZoomImage = ppImage;

    // 为zoomFrame2对象设置缩放帧格式
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // 设置不显示zoomFrame2对象的背景
    zoomFrame2.ShowBackground = false;

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **部分缩放**

部分缩放是指向你演示文稿中的某个部分的链接。你可以使用部分缩放返回到你真正想强调的部分。或者，你也可以使用它们来突出显示你演示文稿中某些部分的联系。

![overview_image](seczoomsel.png)

对于部分缩放对象，Aspose.Slides提供了[ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe)接口，以及一些方法在[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下。

### **创建部分缩放帧**

你可以通过以下方式向幻灯片添加部分缩放帧：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建你打算链接到的部分。
5. 将部分缩放帧（包含对创建的部分的引用）添加到第一个幻灯片。
6. 将修改后的演示文稿写入PPTX文件。

以下C#代码展示了如何在幻灯片上创建缩放帧：

``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 1", slide);

    // 添加SectionZoomFrame对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **使用自定义图像创建部分缩放帧**

使用Aspose.Slides for .NET，你可以通过以下方式创建具有不同幻灯片预览图像的部分缩放帧：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建你打算链接到的部分。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，用于填充帧。
6. 将部分缩放帧（包含对创建的部分的引用）添加到第一个幻灯片。
7. 将修改后的演示文稿写入PPTX文件。

以下C#代码展示了如何创建具有不同图像的缩放帧：

``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 1", slide);

    // 为缩放对象创建新图像
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 添加SectionZoomFrame对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **格式化部分缩放帧**

要创建更复杂的部分缩放帧，你需要修改简单帧的格式。可以对部分缩放帧应用多种格式选项。

你可以通过以下方式控制幻灯片上部分缩放帧的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建一张新幻灯片。
3. 向创建的幻灯片添加标识背景。
4. 创建你打算链接到的部分。
5. 将部分缩放帧（包含对创建的部分的引用）添加到第一个幻灯片。
6. 更改创建的部分缩放对象的大小和位置。
7. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，用于填充帧。
8. 为创建的部分缩放帧对象设置自定义图像。
9. 设置从链接部分返回原始幻灯片的能力。
10. 从部分缩放帧对象的图像中删除背景。
11. 更改第二个缩放帧对象的线条格式。
12. 更改过渡持续时间。
13. 将修改后的演示文稿写入PPTX文件。

以下C#代码展示了如何更改部分缩放帧的格式：

``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 1", slide);

    // 添加SectionZoomFrame对象
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // 为SectionZoomFrame格式化
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


## **概要缩放**

概要缩放就像一个着陆页，所有演示文稿的部分同时显示。当你进行演示时，可以使用缩放从演示文稿中的一个地方跳转到另一个地方，顺序任你选择。你可以发挥创造力，跳到后面，或重新访问幻灯片中的部分，而不会打断你的演示流程。

![overview_image](sumzoomsel.png)

对于概要缩放对象，Aspose.Slides提供了[ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)和[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)接口，以及一些方法在[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection)接口下。

### **创建概要缩放**

你可以通过以下方式向幻灯片添加概要缩放帧：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建具有标识背景的新幻灯片，并为创建的幻灯片创建新部分。
3. 将概要缩放帧添加到第一个幻灯片。
4. 将修改后的演示文稿写入PPTX文件。

以下C#代码展示了如何在幻灯片上创建概要缩放帧：

``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 2", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 3", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 4", slide);

    // 添加SummaryZoomFrame对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **添加和移除概要缩放部分**

概要缩放帧中的所有部分通过[ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection)对象表示，这些对象存储在[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)对象中。你可以通过[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection)接口以以下方式添加或移除概要缩放部分对象：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建具有标识背景的新幻灯片，并为创建的幻灯片创建新部分。
3. 在第一个幻灯片中添加概要缩放帧。
4. 添加新幻灯片和部分到演示文稿。
5. 将创建的部分添加到概要缩放帧。
6. 从概要缩放帧中移除第一个部分。
7. 将修改后的演示文稿写入PPTX文件。

以下C#代码展示了如何在概要缩放帧中添加和移除部分：

``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 2", slide);

    // 添加SummaryZoomFrame对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    ISection section3 = pres.Sections.AddSection("部分 3", slide);

    // 将部分添加到概要缩放
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // 从概要缩放中移除部分
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // 保存演示文稿
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **格式化概要缩放部分**

要创建更复杂的概要缩放部分对象，你需要修改简单帧的格式。可以对概要缩放部分对象应用多种格式选项。

你可以通过以下方式控制概要缩放帧中的概要缩放部分对象的格式：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 创建具有标识背景的新幻灯片，并为创建的幻灯片创建新部分。
3. 将概要缩放帧添加到第一个幻灯片。
4. 从`ISummaryZoomSectionCollection`获取第一个概要缩放部分对象。
5. 通过将图像添加到与[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)对象关联的图像集合中，创建[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)对象，用于填充帧。
6. 为创建的概要缩放部分对象设置自定义图像。
7. 设置从链接部分返回原始幻灯片的能力。
8. 更改第二个缩放帧对象的线条格式。
9. 更改过渡持续时间。
10. 将修改后的演示文稿写入PPTX文件。

以下C#代码展示了如何更改概要缩放部分对象的格式：

``` csharp 
using (Presentation pres = new Presentation())
{
    //向演示文稿添加新幻灯片
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 1", slide);

    //向演示文稿添加新幻灯片
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // 向演示文稿添加新部分
    pres.Sections.AddSection("部分 2", slide);

    // 添加SummaryZoomFrame对象
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // 获取第一个SummaryZoomSection对象
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 为SummaryZoomSection对象格式化
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