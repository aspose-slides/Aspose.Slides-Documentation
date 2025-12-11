---
title: 使用 С++ 在演示文稿中嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/cpp/embedded-font/
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
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++ 在 PowerPoint 和 OpenDocument 演示文稿中嵌入 TrueType 字体，确保在所有平台上准确渲染。"
---

## **概述**

**PowerPoint 中的嵌入字体** 有助于确保您的演示文稿在任何系统或设备上打开时保持预期的外观。这在使用自定义、第三方或非标准字体进行品牌或创意设计时尤为重要。如果未嵌入字体，文本可能会被替换，布局可能会中断，字符可能会显示为不可读的符号或方框，从而破坏整体设计。

Aspose.Slides for C++ 提供了一套强大的 API，以编程方式管理嵌入字体。您可以使用 [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) 和 [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) 类来检查、添加或删除演示文稿中的嵌入字体。此外， [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类允许您在不影响质量或外观的情况下，通过压缩字体数据来优化文件大小。

这些工具为您提供了对字体嵌入的完全控制，帮助您在保持跨平台一致排版的同时，在需要时降低文件大小。

## **获取演示文稿中的嵌入字体**

Aspose.Slides for C++ 通过 [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) 类提供 `GetEmbeddedFonts` 方法，允许您检索 PowerPoint 演示文稿中嵌入的字体列表。这对于审计字体使用情况、确保符合品牌指南或在共享文件前验证所有必要字体已正确包含非常有用。

下面的 C++ 代码演示如何从演示文稿文件获取嵌入字体：
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// 打印嵌入字体的名称。
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```


## **向演示文稿添加嵌入字体**

Aspose.Slides for C++ 允许您使用 [AddEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/) 方法将字体嵌入 PowerPoint 演示文稿，该方法提供两种重载以实现灵活使用。您可以通过使用 [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) 枚举来控制嵌入字体的多少——例如，仅嵌入已使用的字符或整个字体集。此功能在准备共享或分发演示文稿时尤为有用，能够确保自定义或非标准字体在所有系统上正确显示，即使这些系统未安装相应字体。

下面的 C++ 代码检查演示文稿中使用的所有字体，并嵌入任何尚未嵌入的字体。
```cpp
// 加载演示文稿文件。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // 检查字体是否已经嵌入。
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // 将字体嵌入演示文稿。
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// 将演示文稿保存到磁盘。
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **从演示文稿中移除嵌入字体**

Aspose.Slides for C++ 通过 [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) 类提供 `RemoveEmbeddedFont` 方法，使您能够移除 PowerPoint 演示文稿中特定的嵌入字体。这有助于在嵌入的字体不再使用或不需要时降低整体文件大小。移除未使用的字体还能提升性能，并确保演示文稿仅包含必要的资源。

下面的 C++ 代码演示如何从演示文稿中移除嵌入字体：
```cpp
auto fontName = u"Calibri";

// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// 获取所有嵌入的字体。
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // 移除嵌入的字体。
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```


## **压缩嵌入字体**

Aspose.Slides for C++ 通过 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类提供 `CompressEmbeddedFonts` 方法，允许您通过优化嵌入的字体数据来减小演示文稿的总体文件大小。当演示文稿包含大型或多个字体且您希望在共享、存储或在线使用时保持文件轻量，而不损失内容的视觉保真度时，此功能尤为有用。

下面的 C++ 代码演示如何压缩 PowerPoint 演示文稿中的嵌入字体：
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**如何判断演示文稿中某个特定字体在嵌入后仍会在渲染时被替换？**

检查字体管理器中的 [替换信息](/slides/zh/cpp/font-substitution/) 和 [回退/替换规则](/slides/zh/cpp/fallback-font/)：如果字体不可用或受限，系统会使用回退字体。

**嵌入像 Arial、Calibri 这样的“系统”字体值得吗？**

通常不值得——这些字体几乎始终可用。但在“精简”环境（Docker、未预装字体的 Linux 服务器）中，为了实现完全可移植性，嵌入系统字体可以消除意外替换的风险。