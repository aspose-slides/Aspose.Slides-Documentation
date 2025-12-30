---
title: 在 .NET 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/net/custom-font/
keywords:
- 字体
- 自定义字体
- 外部字体
- 加载字体
- 管理字体
- 字体文件夹
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 幻灯片中自定义字体，使您的演示文稿在任何设备上都保持清晰一致。"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 方法加载以下字体：

* TrueType (.ttf) 和 TrueType 集合 (.ttc) 字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf) 字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿中使用的字体。这会影响导出输出——例如 PDF、图像及其他受支持的格式——从而使生成的文档在不同环境中保持一致。字体从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用 [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) 清除字体缓存。

以下代码示例演示了字体加载过程：
```cs
// 定义包含自定义字体文件的文件夹。
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// 从指定的文件夹加载自定义字体。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 使用已加载的字体渲染/导出演示文稿（例如，导出为 PDF、图像或其他格式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 工作完成后清除字体缓存。
FontsLoader.ClearCache();
```


{{% alert color="info" title="注意" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 会向字体搜索路径添加额外的文件夹，但不会更改字体初始化顺序。  
字体按以下顺序初始化：

1. 默认操作系统字体路径。
1. 通过 [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**
Aspose.Slides 提供了 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) 方法，允许您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

以下 C# 代码演示了如何使用 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)：
```c#
// 该行输出检查字体文件的文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **为演示文稿指定使用的自定义字体**
Aspose.Slides 提供了 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性，允许您指定将在演示文稿中使用的外部字体。

以下 C# 代码演示了如何使用 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性：
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 处理演示文稿
    // CustomFont1、CustomFont2 以及来自 assets\fonts 与 global\fonts 文件夹及其子文件夹的字体均可供演示文稿使用
}
```


## **外部管理字体**

Aspose.Slides 提供了 [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 方法，允许您从二进制数据加载外部字体。

以下 C# 代码演示了字节数组字体加载过程： 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 演示文稿生命周期期间加载的外部字体
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **常见问题**

**自定义字体会影响所有格式的导出吗（PDF、PNG、SVG、HTML）？**

是的。已连接的字体会被渲染器在所有导出格式中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**

不会。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的 [嵌入功能](/slides/zh/net/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**

可以。配置 [字体替代](/slides/zh/net/font-substitution/)、[替换规则](/slides/zh/net/font-replacement/) 和 [回退集合](/slides/zh/net/fallback-font/)，即可精准定义在请求的字形缺失时使用哪种字体。

**我可以在 Linux/Docker 容器中使用字体而无需系统范围安装吗？**

可以。指向您自己的字体文件夹或从字节数组加载字体，这样就消除了容器镜像中对系统字体目录的任何依赖。

**关于许可——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需自行负责字体许可合规。许可证条款各不相同，有些禁止嵌入或商业使用。发布输出前，请务必查阅字体的最终用户许可协议（EULA）。