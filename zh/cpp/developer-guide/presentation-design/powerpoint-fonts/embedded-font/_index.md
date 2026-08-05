---
title: 使用 C++ 在演示文稿中嵌入字体
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中嵌入 TrueType 字体，确保在所有平台上准确渲染。"
---
## **简介**

PowerPoint 中的嵌入字体有助于确保演示文稿在任何系统或设备上打开时保持预期的外观。 在使用自定义、第三方或非标准字体进行品牌或创意设计时，这一点尤为重要。 如果未嵌入字体，文本可能被替换，布局可能会中断，字符可能显示为不可读的符号或矩形，导致整体设计受损。

Aspose.Slides for C++ 提供了一套强大的 API，以编程方式管理嵌入字体。 您可以使用 [FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/) 和 [FontData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontdata/) 类来检查、添加或删除演示文件中的嵌入字体。 此外， [Compress](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/) 类允许您通过压缩字体数据来优化文件大小，而不会影响质量或外观。

这些工具让您能够全面控制字体嵌入，在需要时帮助您保持跨平台的一致排版，同时减小文件大小。

## **从演示文稿获取嵌入字体**

Aspose.Slides for C++ 通过 [FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/) 类提供 `GetEmbeddedFonts` 方法，可检索 PowerPoint 演示文稿中嵌入的字体列表。 这对于审计字体使用情况、确保符合品牌指南或在共享文件前验证已正确包含所有必需字体非常有用。

以下 C++ 代码演示了如何从演示文稿文件获取嵌入字体：

```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print names of the embedded fonts.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **向演示文稿添加嵌入字体**

Aspose.Slides for C++ 允许使用 [AddEmbeddedFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/addembeddedfont/) 方法将字体嵌入 PowerPoint 演示文稿，该方法提供两个重载以实现灵活使用。 您可以通过使用 [EmbedFontCharacters](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/embedfontcharacters/) 枚举来控制嵌入的字符量——例如，仅嵌入已使用的字符或整个字体集合。 此功能在准备共享或分发演示文稿时尤为有用，可确保自定义或非标准字体在所有系统上正确显示，即使这些系统未安装相应字体。

以下 C++ 代码检查演示文稿中使用的所有字体，并嵌入尚未嵌入的字体：

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

    // 检查该字体是否已嵌入。
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

Aspose.Slides for C++ 通过 [FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/) 类提供 `RemoveEmbeddedFont` 方法，允许您删除 PowerPoint 演示文稿中已嵌入的特定字体。 这有助于在嵌入的字体不再使用或不需要时减小整体文件大小。 移除未使用的字体还能提升性能，并确保演示文稿仅包含必要的资源。

以下 C++ 代码演示了如何从演示文稿中移除嵌入的字体：

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

Aspose.Slides for C++ 通过 [Compress](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/) 类提供 `CompressEmbeddedFonts` 方法，您可以通过优化嵌入的字体数据来减小演示文稿的整体文件大小。 当演示文稿包含大量或多种字体且希望在共享、存储或在线使用时保持文件轻量化而不影响视觉效果时，此功能尤为实用。

以下 C++ 代码演示了如何压缩 PowerPoint 演示文稿中的嵌入字体：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常见问题**

**如何判断即使已嵌入，演示文稿中的特定字体在渲染时仍会被替换？**

检查字体管理器中的 [替换信息](/slides/zh/cpp/font-substitution/) 以及 [回退/替换规则](/slides/zh/cpp/fallback-font/)：如果字体不可用或受限，将使用回退字体。

**是否值得嵌入像 Arial/Calibri 这样的“系统”字体？**

通常不值得——这些字体几乎总是可用。 但在“精简”环境（Docker、未预装字体的 Linux 服务器）中，为了实现完整的可移植性，嵌入系统字体可以消除意外替换的风险。