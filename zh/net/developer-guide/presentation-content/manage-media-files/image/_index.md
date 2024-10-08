---
title: 图像
type: docs
weight: 10
url: /zh/net/image/
keywords: "添加图像, 添加图片, PowerPoint 演示文稿, EMF, SVG, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 幻灯片或演示文稿添加图像"
---

## **演示文稿中的幻灯片图像**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他位置将图片插入到幻灯片中。同样，Aspose.Slides 允许您通过不同的程序向演示文稿中的幻灯片添加图像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器—[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—可以快速从图像创建演示文稿。 

{{% /alert %}} 

{{% alert title="信息" color="info" %}}

如果您想将图像作为框架对象添加——特别是如果您计划使用标准格式选项来更改其大小、添加效果等——请参见 [图片框](https://docs.aspose.com/slides/net/picture-frame/)。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

您可以处理涉及图像和 PowerPoint 演示文稿的输入/输出操作，以便将图像从一种格式转换为另一种格式。请参见以下页面：转换 [图像为 JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；转换 [JPG 为图像](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；转换 [JPG 为 PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)，转换 [PNG 为 JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/)；转换 [PNG 为 SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)，转换 [SVG 为 PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides 支持这些流行格式的图像操作：JPEG、PNG、BMP、GIF 等。 

## **将本地存储的图像添加到幻灯片**

您可以将计算机上的一张或多张图像添加到演示文稿的幻灯片中。下面的 C# 示例代码演示了如何将图像添加到幻灯片：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **从网络向幻灯片添加图像**

如果您想要添加到幻灯片上的图像在您的计算机上不可用，您可以直接从网络添加图像。 

以下示例代码演示了如何从网络向幻灯片添加图像：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **向幻灯片母版添加图像**

幻灯片母版是存储和控制有关其下所有幻灯片的信息（主题、布局等）的顶部幻灯片。因此，当您向幻灯片母版添加图像时，该图像会出现在该幻灯片母版下的每一张幻灯片上。 

以下 C# 示例代码演示了如何向幻灯片母版添加图像：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **将图像作为幻灯片背景添加**

您可能希望将图片用作特定幻灯片或多个幻灯片的背景。在这种情况下，您需要参见 *[设置幻灯片的背景图像](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿添加 SVG 图像**
您可以通过使用属于 [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口的 [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) 方法将任何图像添加或插入到演示文稿中。

要基于 SVG 图像创建图像对象，可以这样做：

1. 创建 SvgImage 对象以插入到 ImageShapeCollection
2. 从 ISvgImage 创建 PPImage 对象
3. 使用 IPPImage 接口创建 PictureFrame 对象

以下示例代码演示了如何实现上述步骤以将 SVG 图像添加到演示文稿：
``` csharp 
// 文档目录的路径
string dataDir = @"D:\Documents\";

// 源 SVG 文件名
string svgFileName = dataDir + "sample.svg";

// 输出演示文稿文件名
string outPptxPath = dataDir + "presentation.pptx";

// 创建新的演示文稿
using (var p = new Presentation())
{
    // 读取 SVG 文件内容
    string svgContent = File.ReadAllText(svgFileName);

    // 创建 SvgImage 对象
    ISvgImage svgImage = new SvgImage(svgContent);

    // 创建 PPImage 对象
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // 创建一个新的 PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // 以 PPTX 格式保存演示文稿
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **将 SVG 转换为一组形状**
Aspose.Slides 对 SVG 的转换为一组形状的功能与 PowerPoint 处理 SVG 图像的功能相似：

![PowerPoint 弹出菜单](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口的 [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 方法的一个重载提供，该方法将 [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) 对象作为第一个参数。

以下示例代码演示了如何使用描述的方法将 SVG 文件转换为一组形状：

``` csharp 
// 文档目录的路径
string dataDir = @"D:\Documents\";

// 源 SVG 文件名
string svgFileName = dataDir + "sample.svg";

// 输出演示文稿文件名
string outPptxPath = dataDir + "presentation.pptx";

// 创建新的演示文稿
using (IPresentation presentation = new Presentation())
{
    // 读取 SVG 文件内容
    string svgContent = File.ReadAllText(svgFileName);

    // 创建 SvgImage 对象
    ISvgImage svgImage = new SvgImage(svgContent);

    // 获取幻灯片大小
    SizeF slideSize = presentation.SlideSize.Size;

    // 将 SVG 图像转换为形状组，缩放至幻灯片大小
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 以 PPTX 格式保存演示文稿
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **将图像作为 EMF 添加到幻灯片**
Aspose.Slides for .NET 允许您从 Excel 表生成 EMF 图像，并将图像作为 EMF 添加到幻灯片中。

以下示例代码演示了如何执行上述任务：

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // 将工作簿保存到流
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

{{% alert title="信息" color="info" %}}

使用 Aspose 免费的 [文本到 GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松地动画文本、从文本创建 GIF 等。 

{{% /alert %}}