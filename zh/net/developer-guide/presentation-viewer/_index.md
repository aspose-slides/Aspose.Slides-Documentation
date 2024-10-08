---
title: 演示文稿查看器
type: docs
weight: 50
url: /zh/net/presentation-viewer/
keywords: 
- 查看 PowerPoint 演示文稿
- 查看 ppt
- 查看 PPTX
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中查看 PowerPoint 演示文稿"
---



Aspose.Slides for .NET 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文稿进行查看。但有时，开发人员也可能需要在他们喜欢的图像查看器中将幻灯片作为图像查看，或创建自己的演示文稿查看器。在这种情况下，Aspose.Slides for .NET 允许您将单个幻灯片导出为图像。本文将描述如何做到这一点。
## **实时示例**
您可以试用 [**Aspose.Slides 查看器**](https://products.aspose.app/slides/viewer/) 免费应用，以查看您可以使用 Aspose.Slides API 实现的功能：

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **从幻灯片生成 SVG 图像**
要使用 Aspose.Slides.PPTX for .NET 从任何所需的幻灯片生成 SVG 图像，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用其 ID 或索引获取所需幻灯片的引用。
- 在内存流中获取 SVG 图像。
- 将内存流保存到文件。

```c#
// 实例化表示演示文稿文件的 Presentation 类

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))
{

    // 访问第一个幻灯片
    ISlide sld = pres.Slides[0];

    // 创建一个内存流对象
    MemoryStream SvgStream = new MemoryStream();

    // 生成幻灯片的 SVG 图像并保存在内存流中
    sld.WriteAsSvg(SvgStream);
    SvgStream.Position = 0;

    // 将内存流保存到文件
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            fileStream.Write(buffer, 0, len);
        }

    }
    SvgStream.Close();
}
```


## **使用自定义形状 ID 生成 SVG**
Aspose.Slides for .NET 可用于从带有自定义形状 ID 的幻灯片生成 [SVG ](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用 [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape) 中的 ID 属性，该属性表示生成的 SVG 中形状的自定义 ID。可以使用 CustomSvgShapeFormattingController 设置形状 ID。

```c#
using (Presentation pres = new Presentation("pptxFileName.pptx"))
{
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))
    {
        SVGOptions svgOptions = new SVGOptions
        {
            ShapeFormattingController = new CustomSvgShapeFormattingController()
        };

        pres.Slides[0].WriteAsSvg(stream, svgOptions);
    }
}
```



```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
	private int m_shapeIndex;
	
	public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
	{
		m_shapeIndex = shapeStartIndex;
	}

	public void FormatShape(ISvgShape svgShape, IShape shape)
	{
		svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
	}
}
```


## **创建幻灯片缩略图画像**
Aspose.Slides for .NET 帮助您生成幻灯片的缩略图图像。要使用 Aspose.Slides for .NET 生成任何所需幻灯片的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过使用其 ID 或索引获取任何所需幻灯片的引用。
1. 在指定的比例下获取所引用幻灯片的缩略图图像。
1. 以任意所需的图像格式保存缩略图图像。

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))
{
    // 访问第一个幻灯片
    ISlide sld = pres.Slides[0];

    // 创建完整比例的图像
    using (IImage image = sld.GetImage(1f, 1f))
    {
        // 将图像以 JPEG 格式保存到磁盘
        image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **使用用户定义的尺寸创建缩略图**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过使用其 ID 或索引获取任何所需幻灯片的引用。
1. 在指定的比例下获取所引用幻灯片的缩略图图像。
1. 以任意所需的图像格式保存缩略图图像。

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))
{

    // 访问第一个幻灯片
    ISlide sld = pres.Slides[0];

    // 用户自定义尺寸
    int desiredX = 1200;
    int desiredY = 800;

    // 获取 X 和 Y 的缩放值
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;


    // 创建完整比例的图像
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // 将图像以 JPEG 格式保存到磁盘
        image.Save("Thumbnail2_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **从备注幻灯片视图中的幻灯片创建缩略图**
要使用 Aspose.Slides for .NET 生成任何所需幻灯片在备注幻灯片视图中的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过使用其 ID 或索引获取任何所需幻灯片的引用。
1. 在备注幻灯片视图中，在指定的比例下获取所引用幻灯片的缩略图图像。
1. 以任意所需的图像格式保存缩略图图像。

以下代码片段会在备注幻灯片视图中生成演示文稿的第一个幻灯片的缩略图。

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))
{
    // 访问第一个幻灯片
    ISlide sld = pres.Slides[0];

    // 用户自定义尺寸
    int desiredX = 1200;
    int desiredY = 800;

    // 获取 X 和 Y 的缩放值
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // 创建完整比例的图像                
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // 将图像以 JPEG 格式保存到磁盘
        image.Save("Notes_tnail_out.jpg", ImageFormat.Jpeg);
    }
}
```