---
title: 图像
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
description: "在 PowerPoint 和 OpenDocument 中使用 Aspose.Slides for .NET 简化图像管理，优化性能并实现工作流自动化。"
---

## **演示文稿中幻灯片的图像**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他位置将图片插入幻灯片。同样，Aspose.Slides 也允许您通过多种方式向演示文稿的幻灯片中添加图像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——帮助用户快速从图像创建演示文稿。 

{{% /alert %}} 

{{% alert title="信息" color="info" %}}

如果您想将图像作为框架对象添加——尤其是计划对其使用标准格式选项来更改大小、添加效果等——请参阅 [Picture Frame](https://docs.aspose.com/slides/net/picture-frame/)。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

您可以操作涉及图像和 PowerPoint 演示文稿的输入/输出，以将图像从一种格式转换为另一种格式。请参阅以下页面：转换 [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); 转换 [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); 转换 [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); 转换 [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides 支持以下常见格式的图像操作：JPEG、PNG、BMP、GIF 等。 

## **将本地存储的图像添加到幻灯片**

您可以将计算机上的一张或多张图像添加到演示文稿的幻灯片中。下面的 C# 示例代码演示了如何向幻灯片添加图像：
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **将来自网络的图像添加到幻灯片**

如果要添加到幻灯片的图像在计算机上不可用，您可以直接从网络添加该图像。 

以下示例代码演示了如何在 C# 中将网络图像添加到幻灯片：
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


## **将图像添加到幻灯片母版**

幻灯片母版是存储并控制其下所有幻灯片信息（主题、布局等）的顶层幻灯片。因此，当您向幻灯片母版添加图像时，该图像会出现在该母版下的每一张幻灯片上。 

下面的 C# 示例代码演示了如何向幻灯片母版添加图像：
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

您可能决定将图片用作特定幻灯片或多张幻灯片的背景。在这种情况下，请参阅 *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 添加到演示文稿**
您可以使用属于 [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口的 [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) 方法，将任何图像添加或插入到演示文稿中。

要基于 SVG 图像创建图像对象，可以按以下方式操作：

1. 创建 SvgImage 对象以将其插入 ImageShapeCollection  
2. 从 ISvgImage 创建 PPImage 对象  
3. 使用 IPPImage 接口创建 PictureFrame 对象  

下面的示例代码演示了如何实现上述步骤，将 SVG 图像添加到演示文稿中：
```csharp
// 文档目录的路径
string dataDir = @"D:\Documents\";

// 源 SVG 文件名
string svgFileName = dataDir + "sample.svg";

// 输出演示文稿文件名
string outPptxPath = dataDir + "presentation.pptx";

// 创建新演示文稿
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
Aspose.Slides 将 SVG 转换为形状集合的功能类似于 PowerPoint 中处理 SVG 图像的功能：

![PowerPoint Popup Menu](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) 接口的一个重载的 [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 方法提供，该方法接受 [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) 对象作为第一个参数。

下面的示例代码演示了如何使用上述方法将 SVG 文件转换为形状集合：
``` csharp 
// 文档目录的路径
string dataDir = @"D:\Documents\";

// 源 SVG 文件名
string svgFileName = dataDir + "sample.svg";

// 输出演示文稿文件名
string outPptxPath = dataDir + "presentation.pptx";

// 创建新演示文稿
using (IPresentation presentation = new Presentation())
{
    // 读取 SVG 文件内容
    string svgContent = File.ReadAllText(svgFileName);

    // 创建 SvgImage 对象
    ISvgImage svgImage = new SvgImage(svgContent);

    // 获取幻灯片大小
    SizeF slideSize = presentation.SlideSize.Size;

    // 将 SVG 图像转换为形状组，并按幻灯片尺寸进行缩放
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 以 PPTX 格式保存演示文稿
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **将图像作为 EMF 添加到幻灯片**
Aspose.Slides for .NET 允许您使用 Aspose.Cells 从 Excel 工作表生成 EMF 图像，并将这些图像以 EMF 形式添加到幻灯片中。  

下面的示例代码演示了如何完成上述任务：
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

Aspose.Slides 允许您替换存储在演示文稿图像集合中的图像（包括幻灯片形状使用的图像）。本节展示了几种更新集合中图像的方法。API 提供了直接的方式，可使用原始字节数据、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 实例或集合中已存在的另一个图像来替换图像。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载包含图像的演示文稿文件。  
2. 将新图像从文件加载到字节数组。  
3. 使用字节数组将目标图像替换为新图像。  
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) 对象，并使用该对象替换目标图像。  
5. 在第三种方法中，将目标图像替换为演示文稿图像集合中已存在的图像。  
6. 将修改后的演示文稿写入为 PPTX 文件。  
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

使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文本添加动画、从文本创建 GIF 等。 

{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素被保留，但最终外观取决于幻灯片上 [picture](/slides/zh/net/picture-frame/) 的缩放方式以及保存时是否进行压缩。

**一次性替换数十张幻灯片上的相同徽标的最佳方法是什么？**

将徽标放在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——更改会传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，随后各个部分即可使用标准形状属性进行编辑。

**如何一次性将图片设置为多张幻灯片的背景？**

在母版幻灯片或相应布局上 [Assign the image as the background](/slides/zh/net/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积“膨胀”？**

重复使用单个图像资源而非复制，选择合理的分辨率，保存时进行压缩，并在合适的情况下将重复的图形放在母版上。