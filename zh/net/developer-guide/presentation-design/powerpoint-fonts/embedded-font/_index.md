---
title: .NET 中的演示文稿嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/net/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取嵌入字体
- 添加嵌入字体
- 移除嵌入字体
- 压缩嵌入字体
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中嵌入 TrueType 字体，确保在所有平台上准确渲染。"
---

**Embedding fonts in PowerPoint** 确保您的演示文稿在不同系统上保持预期的外观。无论是使用独特的字体进行创意设计还是使用标准字体，嵌入字体都可以防止文本和布局被破坏。

如果您因为创意而使用了第三方或非标准字体，那么您就有更多理由嵌入该字体。否则（未嵌入字体），幻灯片上的文字或数字、布局、样式等可能会发生变化，甚至变成模糊的方块。

使用 [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) 和 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类来管理嵌入的字体。

## **获取和删除嵌入字体**

使用 [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) 和 [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) 方法，您可以轻松检索或删除演示文稿中的嵌入字体。

下面的 C# 代码演示了如何从演示文稿中获取和删除嵌入字体：
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 渲染包含使用嵌入的 "FunSized" 文本框的幻灯片
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

    // 移除 "Calibri" 字体
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // 渲染演示文稿；"Calibri" 字体被现有字体替换
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // 将演示文稿保存到磁盘，且不包含嵌入的 "Calibri" 字体
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **添加嵌入字体**

通过使用 [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 枚举以及 [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) 方法的两个重载，您可以选择首选的（嵌入）规则将字体嵌入到演示文稿中。下面的 C# 代码演示了如何嵌入并添加字体到演示文稿：
```c#
// 加载演示文稿
Presentation presentation = new Presentation("Fonts.pptx");

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

使用 [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) 对嵌入字体进行压缩，以优化文件大小。

以下示例代码演示了压缩：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**如何判断即使嵌入后，演示文稿中的特定字体在渲染时仍会被替换？**

请查看字体管理器中的 [substitution information](/slides/zh/net/font-substitution/) 以及 [fallback/substitution rules](/slides/zh/net/fallback-font/)；如果字体不可用或受限，将使用回退字体。

**是否值得嵌入诸如 Arial/Calibri 等“系统”字体？**

通常不需要——这些字体几乎总是可用。但在需要完全可移植的“精简”环境（如 Docker、未预装字体的 Linux 服务器）中，嵌入系统字体可以消除意外替换的风险。