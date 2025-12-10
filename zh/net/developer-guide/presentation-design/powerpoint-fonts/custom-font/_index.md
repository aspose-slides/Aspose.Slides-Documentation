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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 幻灯片中自定义字体，使您的演示文稿在任何设备上保持清晰一致。"
---

{{% alert color="primary" %}} 
Aspose Slides 允许您使用 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 方法加载这些字体：

* TrueType (.ttf) 和 TrueType 集合 (.ttc) 字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您加载在演示文稿中渲染的字体，而无需安装这些字体。字体从自定义目录加载。

1. 创建 [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 类的实例并调用 [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 方法。
2. 加载将要渲染的演示文稿。
3. 在 [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 类中清除缓存。

下面的 C# 代码演示了字体加载过程：
``` csharp
// 文档目录的路径
string dataDir = "C:\\";

// 用于查找字体的文件夹
String[] folders = new String[] { dataDir };

// 加载自定义字体目录中的字体
FontsLoader.LoadExternalFonts(folders);

// 执行一些操作并进行演示文稿/幻灯片渲染
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// 清除字体缓存
FontsLoader.ClearCache();
```


## **获取自定义字体文件夹**
Aspose.Slides 提供了 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) 方法，可帮助您查找字体文件夹。此方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

下面的 C# 代码展示了如何使用 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)：
```c#
 // 此行输出检查字体文件的文件夹。
 // 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
 string[] fontFolders = FontsLoader.GetFontFolders();
```


## **为演示文稿指定使用的自定义字体**
Aspose.Slides 提供了 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性，使您能够指定将在演示文稿中使用的外部字体。

下面的 C# 代码展示了如何使用 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性：
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 对演示文稿进行操作
    // CustomFont1、CustomFont2，以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体可用于此演示文稿
}
```


## **外部管理字体**

Aspose.Slides 提供了 [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 方法，允许您从二进制数据加载外部字体。

下面的 C# 代码演示了字节数组字体加载过程：
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 演示文稿生命周期内加载的外部字体
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **常见问题**

**自定义字体会影响导出到所有格式（PDF、PNG、SVG、HTML）吗？**

是的。已连接的字体会在所有导出格式的渲染器中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**

不会。将字体注册用于渲染并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的[嵌入功能](/slides/zh/net/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**

可以。配置[字体替换](/slides/zh/net/font-substitution/)、[替换规则](/slides/zh/net/font-replacement/)和[回退集](/slides/zh/net/fallback-font/)，即可准确定义在请求的字形缺失时使用哪种字体。

**我可以在 Linux/Docker 容器中使用字体而无需系统范围安装吗？**

可以。指向您自己的字体文件夹或从字节数组加载字体，这样就消除了容器镜像对系统字体目录的任何依赖。

**关于授权—我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需自行负责字体授权合规性。条款各不相同；有些授权禁止嵌入或商业使用。分发输出前，请务必查看字体的 EULA。