---
title: 在 .NET 中优化演示文稿的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/net/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 中简化图像管理，优化性能并自动化工作流。"
---

## **演示文稿幻灯片中的图像**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他位置向幻灯片插入图片。同样，Aspose.Slides 允许您通过不同的方法向演示文稿的幻灯片添加图像。

{{% alert  title="提示" color="primary" %}} 
Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——可帮助用户快速从图像创建演示文稿。 
{{% /alert %}} 

{{% alert title="信息" color="info" %}}
如果您想将图像作为框架对象添加，特别是计划使用标准格式选项来更改其大小、添加效果等，请参阅 [图片框架](https://docs.aspose.com/slides/net/picture-frame/)。 
{{% /alert %}} 

{{% alert title="注意" color="warning" %}}
您可以操作涉及图像和 PowerPoint 演示文稿的输入/输出，以将图像从一种格式转换为另一种格式。请参阅以下页面：转换 [图像转 JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；转换 [JPG 转图像](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；转换 [JPG 转 PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)，转换 [PNG 转 JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/)，转换 [PNG 转 SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)，转换 [SVG 转 PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。
{{% /alert %}}

Aspose.Slides 支持对这些常用格式的图像进行操作：JPEG、PNG、BMP、GIF 等。

## **向幻灯片添加本地存储的图像**

您可以将计算机上的一个或多个图像添加到演示文稿的幻灯片中。以下 C# 示例代码展示了如何向幻灯片添加图像：
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

如果您要添加的图像在计算机上不可用，您可以直接从网络添加该图像。

以下示例代码展示了如何在 C# 中从网络向幻灯片添加图像：
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


## **向母版幻灯片添加图像**

母版幻灯片是存储并控制其下所有幻灯片信息（主题、布局等）的顶层幻灯片。因此，当您向母版幻灯片添加图像时，该图像会出现在该母版下的每一张幻灯片中。

以下 C# 示例代码展示了如何向母版幻灯片添加图像：
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


## **将图像设置为幻灯片背景**

您可能决定将图片用作特定幻灯片或多张幻灯片的背景。在这种情况下，请参阅 *[将图像设置为幻灯片背景](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿添加 SVG**
您可以使用属于 [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口的 [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) 方法向演示文稿中添加或插入任意图像。

要基于 SVG 图像创建图像对象，可以按以下方式操作：

1. 创建 SvgImage 对象以将其插入 ImageShapeCollection  
2. 从 ISvgImage 创建 PPImage 对象  
3. 使用 IPPImage 接口创建 PictureFrame 对象  

以下示例代码展示了如何实现上述步骤，将 SVG 图像添加到演示文稿中：
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

    // 创建新的 PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // 以 PPTX 格式保存演示文稿
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **将 SVG 转换为形状集合**
Aspose.Slides 将 SVG 转换为形状集合的功能类似于 PowerPoint 用于处理 SVG 图像的功能：

![PowerPoint 弹出菜单](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口的 [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 方法的其中一个重载提供，该重载接受一个 [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) 对象作为第一个参数。

以下示例代码展示了如何使用上述方法将 SVG 文件转换为形状集合：
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

    // 获取幻灯片尺寸
    SizeF slideSize = presentation.SlideSize.Size;

    // 将 SVG 图像转换为形状组并缩放至幻灯片尺寸
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 以 PPTX 格式保存演示文稿
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **将图像作为 EMF 添加到幻灯片**
Aspose.Slides for .NET 允许您从 Excel 工作表生成 EMF 图像，并使用 Aspose.Cells 将这些图像作为 EMF 添加到幻灯片中。  

以下示例代码展示了如何执行上述任务：
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


## **替换图像集合中的图像**

Aspose.Slides 使您能够替换存储在演示文稿图像集合中的图像（包括幻灯片形状使用的图像）。本节展示了更新集合中图像的几种方法。API 提供了直接使用原始字节数据、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 实例或集合中已存在的另一图像来替换图像的简便方法。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载包含图像的演示文稿文件。  
2. 将新图像从文件加载到字节数组中。  
3. 使用该字节数组将目标图像替换为新图像。  
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 对象中，并使用该对象替换目标图像。  
5. 在第三种方法中，将目标图像替换为演示文稿图像集合中已存在的图像。  
6. 将修改后的演示文稿写出为 PPTX 文件。  
```cs
// 实例化表示演示文稿文件的 Presentation 类。
using Presentation presentation = new Presentation("sample.pptx");

// 第一种方法。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 第二种方法。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 第三种方法。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// 将演示文稿保存到文件。
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="信息" color="info" %}}
使用 Aspose 免费的 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文字添加动画、从文字创建 GIF 等。 
{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素会被保留，但最终显示效果取决于幻灯片上 [picture](/slides/zh/net/picture-frame/) 的缩放方式以及保存时是否进行了压缩。

**如何一次性在数十张幻灯片上替换相同的徽标？**

将徽标放在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——更改会传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为形状组，之后各个部件即可使用标准形状属性进行编辑。

**如何一次性为多张幻灯片设置相同的背景图片？**

在母版幻灯片或相应布局上 [将图像设置为背景](/slides/zh/net/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积激增？**

重复使用单一图像资源而非复制多个副本，选择合适的分辨率，保存时进行压缩，并在适当情况下将重复图形保留在母版中。