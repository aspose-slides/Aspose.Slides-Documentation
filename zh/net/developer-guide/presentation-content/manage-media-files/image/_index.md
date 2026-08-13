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
- 外部 SVG 资源
- SVG 解析器
- 链接的 SVG 图像
- SVG 字体
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 简化 PowerPoint 和 OpenDocument 中的图像管理，优化性能并自动化工作流程。"
---
## **介绍**

图片使演示更具吸引力和视觉冲击力。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源将图片插入幻灯片。同样，Aspose.Slides 也提供多种方式将图像添加到演示幻灯片中。

{{% alert  title="Tip" color="info" %}} 
Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可帮助您快速从图像创建演示文稿。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想将图像作为图片框插入——尤其是在计划调整大小、应用效果或使用其他标准格式化选项时——请参阅 [图片框](/slides/zh/net/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以将图像从一种格式转换为另一种格式。请参阅以下页面：转换 [image to JPG](https://products.aspose.com/slides/zh/net/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/zh/net/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/zh/net/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/zh/net/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/zh/net/conversion/png-to-svg/)、以及 [SVG to PNG](https://products.aspose.com/slides/zh/net/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides 支持 JPEG、PNG、BMP、GIF 等常见格式的图像。 

## **将本地存储的图像添加到幻灯片**

您可以将一张或多张保存在计算机上的图像添加到演示幻灯片。下面的 C# 示例代码展示了如何向幻灯片添加图像：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **将网络上的图像添加到幻灯片**

如果要添加的图像未保存在本地，您可以直接从网络加载。下面的 C# 示例代码展示了如何从网络将图像添加到幻灯片：

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **将图像添加到母版幻灯片**

母版幻灯片存储并控制主题和布局等信息。当您向母版幻灯片添加图像时，该图像会出现在基于该母版的所有幻灯片上。下面的 C# 示例代码展示了如何向母版幻灯片添加图像：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

您可以使用图片作为一个或多个幻灯片的背景。详情请参阅 *[将图像设置为幻灯片背景](/slides/zh/net/presentation-background/#setting-images-as-background-for-slides)*。 

## **将 SVG 添加到演示文稿**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/svgimage/) 类将 SVG 内容添加到演示文稿。生成的 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 对象随后可以添加到演示文稿的图像集合，并用于创建图片框。

下面的 C# 示例导入了一个自包含的 SVG 字符串。所有图像、样式以及 SVG 使用的其他资源都直接嵌入在 SVG 内容中。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **导入带有外部资源的 SVG 内容**

从设计工具、图表编辑器、图标系统和 Web 流程导出的 SVG 文件可能会引用存储在 SVG 文档之外的资源。例如，SVG 可以包含 `images/photo.png` 链接、CSS `url(...)` 值或字体 URL。

要导入此类 SVG 内容，请实现 [IExternalResourceResolver](https://reference.aspose.com/slides/zh/net/aspose.slides.import/iexternalresourceresolver/) 并将其与基 URI 一起传递给相应的 `SvgImage` 构造函数。基 URI 标识 SVG 文档的位置，用于解析相对链接。

[ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 接口提供对已导入 SVG 信息的访问：

- `SvgContent` 返回 SVG 标记的字符串形式。  
- `SvgData` 返回 SVG 内容的字节数组。  
- `BaseUri` 返回用于相对链接的基 URI。  
- `ExternalResourceResolver` 返回分配给 SVG 图像的解析器。  

### **实现外部资源解析器**

解析器包含两个方法：

- [ResolveUri](https://reference.aspose.com/slides/zh/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) 将基 URI 与相对资源链接组合，返回绝对 URI。无法解析或不允许的链接返回 `null`。  
- [GetEntity](https://reference.aspose.com/slides/zh/net/aspose.slides.import/iexternalresourceresolver/getentity/) 为绝对资源 URI 返回可读取的流。资源缺失、被阻止或不可用时返回 `null`，必要时也可返回回退流。  

下面的解析器仅从允许的本地目录加载链接资源。网络资源和超出允许目录的路径将被阻止。对于无法解析的图像链接，可返回可选的回退图像。

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // 此解析器专门只允许本地文件。
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // 仅在图像资源时使用回退。返回图像流
        // 对于缺失的字体或样式表则无效。
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **在 SVG 导入期间解析链接资源**

假设 `assets/diagram.svg` 包含如下相对引用：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

下面的 C# 示例将 SVG 文件 URI 作为基 URI 并提供自定义解析器。解析器将相对图像链接转换为绝对 URI，并在 Aspose.Slides 处理 SVG 时返回包含链接资源的流。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// 基本 URI 表示 SVG 文档的位置。
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

`SvgImage` 类还提供接受 SVG 数据字节数组或流的重载方法，可同时指定外部资源解析器和基 URI。

{{% alert title="Important" color="warning" %}}
资源解析器在 Aspose.Slides 处理和渲染 SVG 时使外部资源可用。它不会修改原始 SVG 标记，也不会自动将解析后的资源嵌入其中。

当 `ISvgImage` 被添加到演示文稿的图像集合时，PPTX 文件可以同时包含原始 SVG 表示和栅格回退图像。链接资源可能出现在生成的回退图像中，而相对链接如 `images/photo.png` 在存储的 SVG 中保持不变。渲染原生 SVG 表示的应用程序在原始外部资源不可用时可能会忽略该链接内容。 
{{% /alert %}}

### **创建可移植的 SVG 图片**

要创建不依赖外部文件的 SVG 图片，请在创建 `SvgImage` 前使 SVG 自包含。例如，用包含图像数据的 `data:` URI 替换链接的图像 URL：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必需资源嵌入 SVG 内容后，创建 `SvgImage`，将其添加到演示文稿图像集合，并按前述示例插入到图片框中。

### **处理缺失或被阻止的资源**

当资源 URI 无效、被禁止或无法解析时，在 `ResolveUri` 中返回 `null`。当资源无法读取时，在 `GetEntity` 中返回 `null`。Aspose.Slides 会在可能的情况下继续处理 SVG 而不使用该资源。

可以为缺失的资源返回回退流，但其内容必须与请求的资源类型兼容。例如，仅为缺失的图像返回图像流，而不是为字体或样式表返回图像流。

{{% alert title="Security" color="warning" %}}
不要从不可信的 SVG 文件解析任意文件路径或不受限制的网络 URL。请限制允许的协议、目录和主机。针对网络资源，还应设置连接超时、响应大小限制以及内容验证。 
{{% /alert %}}

## **将 SVG 转换为形状集合**
Aspose.Slides 可以将 SVG 转换为形状集合，类似于 PowerPoint 中的相应功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection) 接口的 [AddGroupShape](https://reference.aspose.com/slides/zh/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 方法的重载提供，该重载接受一个 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage) 对象作为第一个参数。

下面的 C# 示例代码展示了如何使用此方法将 SVG 文件转换为形状集合：

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 源 SVG 文件名
string svgFileName = "sample.svg";

// 输出演示文稿文件名
string outPptxPath = "presentation.pptx";

// 创建一个新演示文稿
using (IPresentation presentation = new Presentation())
{
    // 读取 SVG 文件内容
    string svgContent = File.ReadAllText(svgFileName);

    // 创建 SvgImage 对象
    ISvgImage svgImage = new SvgImage(svgContent);

    // 获取幻灯片尺寸
    SizeF slideSize = presentation.SlideSize.Size;

    // 将 SVG 图像转换为形状组并按幻灯片尺寸缩放
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 以 PPTX 格式保存演示文稿
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **将图像以 EMF 形式添加到幻灯片**
Aspose.Slides for .NET 允许您使用 Aspose.Cells 从 Excel 工作表生成 EMF 图像并将其添加到演示幻灯片。

下面的 C# 示例代码展示了具体操作：

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // 将工作簿保存到流
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **替换图像集合中的图像**

Aspose.Slides 允许您替换演示文稿图像集合中存储的图像，包括幻灯片形状使用的图像。本节描述了更新集合中图像的多种方式。您可以使用原始字节数据、[IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 实例或集合中已经存在的其他图像来替换图像。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类加载包含图像的演示文件。  
2. 从文件加载新图像到字节数组。  
3. 使用字节数组将目标图像替换为新图像。  
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对象，并使用该对象替换目标图像。  
5. 在第三种方法中，使用演示文稿图像集合中已存在的图像替换目标图像。  
6. 将修改后的演示文稿保存为 PPTX 文件。  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件的 Presentation 类。
using Presentation presentation = new Presentation("sample.pptx");

// 第一种方式。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 第二种方式。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 第三种方式。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// 将演示文稿保存到文件。
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器，您可以轻松为文本添加动画并生成 GIF。 
{{% /alert %}}

## **常见问题解答**

**插入后原始图像分辨率是否保持不变？**  
是的。源像素会被保留，但最终显示效果取决于 [图片](/slides/zh/net/picture-frame/) 在幻灯片上的缩放方式以及保存时是否进行压缩。

**如何一次性替换数十张幻灯片中的相同徽标？**  
将徽标放置在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——所有使用该资源的元素都会自动更新。

**插入的 SVG 能否转换为可编辑的形状？**  
可以。您可以将 SVG 转换为一组形状，之后即可对各个部件使用标准形状属性进行编辑。

**如何一次性为多张幻灯片设置相同的背景图片？**  
在母版幻灯片或相应布局上 [将图像设为背景](/slides/zh/net/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积过大？**  
复用单一图像资源而不是重复复制，选择合适的分辨率，保存时进行压缩，并在适当情况下将重复图形放在母版上。