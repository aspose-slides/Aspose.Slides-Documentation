---
title: 在 C++ 中嵌入演示文稿的字体
linktitle: 嵌入式字体
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
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 管理 PowerPoint 中的嵌入字体。添加、检索、移除和压缩字体，以保留文本外观并减小文件大小。"
---
## **简介**

嵌入字体会将字体数据存储在 PowerPoint 演示文稿内部。当查看器支持嵌入字体时，即使目标系统上未安装这些字体，也能使用它们显示文本。这有助于保留换行、文本间距和幻灯片布局。

Aspose.Slides for C++ 让您可以通过 [Presentation::get_FontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_fontsmanager/) 方法（该方法属于 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)）检索、添加和删除嵌入字体。您还可以通过移除演示文稿未使用的字符来缩小嵌入字体数据的大小。

下面的示例使用 PPTX 文件。在嵌入字体之前，请确保该字体的数据可供 Aspose.Slides 使用且其许可允许嵌入。

## **获取并删除嵌入字体**

使用 [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) 列出演示文稿中存储的字体。要删除某个字体，请将该列表中的字体传递给 [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/removeembeddedfont/)，然后保存演示文稿。

以下示例列出 `EmbeddedFonts.pptx` 中的嵌入字体，并在存在时删除 Calibri：
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

删除嵌入字体会移除其存储的字体数据；但不会更改文本所分配的字体。如果目标系统已安装该字体，文本仍可使用它。否则，渲染可能需要 [字体替换](/slides/zh/cpp/font-substitution/)，这可能影响布局。

## **检查字体数据和嵌入权限**

在嵌入字体之前，请使用 [IFontsManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/) 接口检查字体。调用 [IFontsManager::GetFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getfonts/) 可获取演示文稿中使用的字体。对于每个字体，将 [IFontData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontdata/) 对象和所需的 [FontStyleType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontstyletype/) 值传递给 [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getfontbytes/)。该方法返回该字体样式的二进制数据，若请求的字体或样式不可用则返回 `nullptr`。不要将 `nullptr` 结果传递给 [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/)，因为该方法需要字节数组。

[EmbeddingLevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides/embeddinglevel/) 是一个标志枚举，用于报告字体中存储的嵌入限制：

- `Installable` 允许嵌入并在另一系统上永久安装，需遵守字体许可。
- `Restricted` 禁止嵌入，除非在它是唯一使用权限标志时获得字体版权所有者的许可。
- `PreviewPrint` 允许临时用于查看和打印；包含该字体的文档必须为只读。
- `Editable` 允许临时使用，并且文档可以被编辑和保存。
- `NoSubsetting` 是一种附加限制，禁止仅嵌入部分字形。当出现此标志时必须嵌入所有字符。
- `BitmapOnly` 是一种附加限制，只允许嵌入位图字形而非轮廓数据。如果字体没有位图字形，则无法嵌入。

前四个值描述使用权限，而 `NoSubsetting` 和 `BitmapOnly` 可以与它们组合。使用位运算检查这些修饰符。由于 `Installable` 为零，请对使用权限位进行掩码并将结果与 `Installable` 比较。当前字体应最多设置一个使用权限位。为兼容设置了多个位的旧字体，下面的帮助程序会选择最宽松的权限：`Editable`、然后 `PreviewPrint`、再然后 `Restricted`。

以下示例审计 `GetFonts` 返回的每个字体的常规、粗体、斜体和粗斜体数据。它会跳过不可用的样式、受限制的字体、仅位图字体、仅限预览和打印的字体（因为输出仍保持可编辑），以及已经嵌入的字体。如果任何可用样式带有 `NoSubsetting`，则会为该字体族嵌入所有字符。
```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

此检查报告每个字体文件中编码的限制。它不授予许可、也不证明您合法获取了该字体，且不能替代在分发嵌入副本之前检查字体许可协议的过程。

## **添加嵌入字体**

使用 [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/addembeddedfont/) 可嵌入字体。其重载接受 [IFontData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontdata/) 对象或包含字体数据的字节数组。[EmbedFontCharacters](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/embedfontcharacters/) 枚举控制包含哪些字符：

- [All](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/embedfontcharacters/) 在字体中嵌入所有字符。当接收者需要编辑演示文稿并输入新文本时使用此选项。
- [OnlyUsed](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/embedfontcharacters/) 仅嵌入演示文稿中使用的字符，以减小文件大小。对于主要用于查看的已完成演示文稿请选择此选项。

以下示例使用 [IFontsManager::GetFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getfonts/) 检索 `Fonts.pptx` 中使用的字体，并嵌入尚未嵌入的字体。要添加的字体必须在运行代码的机器上可用。已有的嵌入字体会保留其当前字符集。
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **压缩嵌入字体**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) 通过移除未使用的字符来减少嵌入字体数据。它针对已经嵌入的字体进行操作，因此大小的减少取决于演示文稿中未使用的字体数据量。

以下示例压缩 `EmbeddedFonts.pptx` 中的字体，并将结果另存为单独的文件：
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

如果接收者以后可能需要添加文本，请保留原始文件。压缩过程中移除的字符将不再可从嵌入字体中获取，即使您最初已嵌入了所有字符。

## **常见问题**

**如何检查嵌入字体在渲染时是否仍会被替换？**

在渲染演示文稿的环境中调用 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 以查看 Aspose.Slides 将替换哪些字体。同时检查 [字体替换](/slides/zh/cpp/font-substitution/) 设置和 [字体回退](/slides/zh/cpp/fallback-font/) 规则。回退处理缺失字符，因此嵌入字体并不能解决字体本身不包含的字符。

**是否应该嵌入像 Arial 和 Calibri 这样的常用字体？**

应根据目标环境来决定。如果所需字体在所有打开或渲染演示文稿的机器上均可用，嵌入它们可能会导致不必要的文件增大。如果接收者或服务器可能缺少这些字体，且其许可允许，嵌入它们可以帮助保留预期的外观。