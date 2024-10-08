---
title: 嵌入字体 - PowerPoint C# API
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/net/embedded-font/
keywords:
- 字体
- 嵌入字体
- 添加字体
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中使用 PowerPoint 演示文稿的嵌入字体"
---

**PowerPoint中的嵌入字体** 在您希望在任何系统或设备上正确打开演示文稿时非常有用。如果您使用了第三方或非标准字体，因为您在工作中进行了创造性尝试，那么您就更加需要嵌入您的字体。否则（没有嵌入字体），幻灯片上的文本或数字、布局、样式等可能会改变或变成令人困惑的矩形。

[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) 类、[FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) 类、[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类及其接口包含了您处理 PowerPoint 演示文稿中的嵌入字体所需的大部分属性和方法。

## **获取或删除演示文稿中的嵌入字体**

Aspose.Slides 提供了 [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) 方法（由 [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) 类公开），允许您获取（或查找）嵌入在演示文稿中的字体。要删除字体，可以使用 [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) 方法（由同一类公开）。

以下 C# 代码演示了如何从演示文稿中获取和删除嵌入字体：

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 渲染一个包含使用嵌入 "FunSized" 字体的文本框的幻灯片
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // 查找 "Calibri" 字体
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // 删除 "Calibri" 字体
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // 渲染演示文稿； "Calibri" 字体被替换为现有字体
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // 将没有嵌入 "Calibri" 字体的演示文稿保存到磁盘
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **向演示文稿添加嵌入字体**
使用 [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 枚举和两个重载的 [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) 方法，您可以选择您首选的（嵌入）规则来嵌入演示文稿中的字体。以下 C# 代码演示了如何向演示文稿中嵌入和添加字体：

```c#
// 加载演示文稿
Presentation presentation = new Presentation("Fonts.pptx");

// 加载要替换的源字体
IFontData sourceFont = new FontData("Arial");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// 将演示文稿保存到磁盘
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **压缩嵌入字体**

为了允许您压缩嵌入在演示文稿中的字体并减少其文件大小，Aspose.Slides 提供了 [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) 方法（由 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类公开）。

以下 C# 代码演示了如何压缩嵌入的 PowerPoint 字体：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```