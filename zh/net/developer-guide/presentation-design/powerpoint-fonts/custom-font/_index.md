---
title: 自定义 PowerPoint 字体在 C#
linktitle: 自定义字体
type: docs
weight: 20
url: /net/custom-font/
keywords: "字体，自定义字体，PowerPoint 演示文稿，C#，Csharp，Aspose.Slides for .NET"
description: "在 C# 中的 PowerPoint 自定义字体"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 方法加载这些字体：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字体。请参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf) 字体。请参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您加载在演示文稿中呈现的字体，而无需安装这些字体。字体从自定义目录加载。

1. 创建 [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 类的实例，并调用 [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) 方法。
2. 加载将被呈现的演示文稿。
3. 清除 [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 类中的缓存。

以下 C# 代码演示了字体加载过程：

``` csharp
// 文档目录的路径
string dataDir = "C:\\";

// 寻找字体的文件夹
String[] folders = new String[] { dataDir };

// 加载自定义字体目录中的字体
FontsLoader.LoadExternalFonts(folders);

// 执行一些工作并进行演示/幻灯片渲染
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// 清除字体缓存
FontsLoader.ClearCache();
```

## **获取自定义字体文件夹**
Aspose.Slides 提供 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) 方法以允许您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹和系统字体文件夹。

以下 C# 代码显示如何使用 [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)：

```c#
// 该行输出检查字体文件的文件夹。
// 这些是通过 LoadExternalFonts 方法添加的文件夹和系统字体文件夹。
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **指定与演示文稿一起使用的自定义字体**
Aspose.Slides 提供 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性，以允许您指定将与演示文稿一起使用的外部字体。

以下 C# 代码显示如何使用 [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) 属性：

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 与演示文稿一起工作
    // CustomFont1，CustomFont2，以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体可用
}
```

## **外部管理字体**

Aspose.Slides 提供 [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 方法，以允许您从二进制数据加载外部字体。

以下 C# 代码演示了字节数组字体加载过程： 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 演示期间加载的外部字体
    }
}
finally
{
    FontsLoader.ClearCache();
}
```