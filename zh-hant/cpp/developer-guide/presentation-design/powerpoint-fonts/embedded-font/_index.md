---
title: 在 C++ 簡報中嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/cpp/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得嵌入字型
- 新增嵌入字型
- 移除嵌入字型
- 壓縮嵌入字型
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 管理 PowerPoint 中的嵌入字型。新增、取得、移除與壓縮字型，以保留文字外觀並減少檔案大小。"
---
## **簡介**

嵌入字型會將字型資料儲存在 PowerPoint 簡報內。當檢視程式支援嵌入字型時，即使目標系統未安裝該字型，也能使用這些字型顯示文字。這有助於保留換行、文字間距與投影片版面配置。

Aspose.Slides for C++ 允許您透過 [Presentation::get_FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/) 方法（屬於 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)）取得、加入與移除嵌入字型。您亦可透過移除簡報未使用的字元來縮減嵌入字型資料的大小。

以下範例使用 PPTX 檔案。嵌入字型之前，請確保其字型資料可供 Aspose.Slides 使用且其授權允許嵌入。

## **取得與移除嵌入字型**

使用 [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) 可列出簡報中已儲存的字型。若要移除某個字型，將該清單中的字型傳遞給 [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/removeembeddedfont/)，然後儲存簡報。

以下範例列出 `EmbeddedFonts.pptx` 中的嵌入字型，並在出現時移除 Calibri：
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

移除嵌入字型會刪除其儲存的字型資料；不會變更文字所指定的字型。若該字型已安裝於目標系統，文字仍可使用它。否則，渲染可能需要 [font substitution](/slides/zh-hant/cpp/font-substitution/)，這可能影響版面配置。

## **檢查字型資料與嵌入許可**

使用 [IFontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/) 介面可在嵌入前檢查字型。呼叫 [IFontsManager::GetFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getfonts/) 以取得簡報中使用的字型。對於每一個字型，傳入 [IFontData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontdata/) 物件與相應的 [FontStyleType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontstyletype/) 值至 [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getfontbytes/)。此方法回傳該字型樣式的二進位資料，若請求的字型或樣式不存在則回傳 `nullptr`。請勿將 `nullptr` 結果傳遞給 [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/)，因為該方法需要位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/embeddinglevel/) 是一個旗標列舉，報告字型中儲存的嵌入限制：
- `Installable` 允許嵌入且可在其他系統永久安裝，須遵守字型授權。
- `Restricted` 禁止嵌入，除非取得字型合法所有者的許可（當它是唯一的使用許可旗標時）。
- `PreviewPrint` 允許暫時使用以供檢視與列印；包含該字型的文件必須為唯讀。
- `Editable` 允許暫時使用，且文件可編輯與儲存。
- `NoSubsetting` 為額外限制，禁止只嵌入字形子集。若出現此旗標，必須嵌入所有字元。
- `BitmapOnly` 為額外限制，只允許嵌入點陣字形（bitmap），不允許嵌入輪廓資料。如果字型沒有點陣字形，則無法嵌入。

前四個值描述使用許可，而 `NoSubsetting` 與 `BitmapOnly` 可以與其組合。請以位元運算檢查這些修飾子。因為 `Installable` 為零，需遮罩使用許可位元並與 `Installable` 比較結果。現行字型應僅設定最多一個使用許可位元。為相容於設定了多個位元的舊字型，以下輔助程式會挑選最寬鬆的許可：先選 `Editable`，其後是 `PreviewPrint`，最後是 `Restricted`。

以下範例審核由 `GetFonts` 回傳之每個字型的常規、粗體、斜體與粗斜體資料。它會略過不可用的樣式、受限字型、僅點陣字型、因輸出仍可編輯而受限於預覽與列印的字型，以及已嵌入的字型。若任何可用樣式具備 `NoSubsetting`，則會為該字型家族嵌入所有字元。
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

此檢查會回報每個字型檔案中編碼的限制。它不會授予授權、證明您合法取得該字型，也無法取代在分發嵌入副本前檢查字型授權協議的必要程序。

## **新增嵌入字型**

使用 [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/addembeddedfont/) 可嵌入字型。其多載接受 [IFontData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontdata/) 物件或包含字型資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/embedfontcharacters/) 列舉控制包括哪些字元：
- [All](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/embedfontcharacters/) 將字型中的所有字元嵌入。當接收者需要編輯簡報並輸入新文字時使用此選項。
- [OnlyUsed](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/embedfontcharacters/) 只嵌入簡報中使用的字元以減少檔案大小。對於主要用於觀看的完成簡報，請選擇此選項。

以下範例使用 [IFontsManager::GetFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getfonts/) 取得 `Fonts.pptx` 中使用的字型，並嵌入尚未嵌入的字型。要加入的字型必須在執行程式的機器上可用。已存在的嵌入字型將保留其目前的字元集合。
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

## **壓縮嵌入字型**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) 透過移除未使用的字元來縮減嵌入字型資料。它作用於已嵌入的字型，因此大小的減少取決於簡報中未使用的字型資料量。

以下範例壓縮 `EmbeddedFonts.pptx` 中的字型，並將結果另存為單獨的檔案：
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

若接收者日後可能需要加入文字，請保留原始檔案。壓縮過程中移除的字元將不再可從嵌入字型取得，即使最初已嵌入所有字元。

## **常見問題**

**我該如何檢查嵌入字型在渲染時是否仍會被取代？**

在執行簡報渲染的環境中呼叫 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getsubstitutions/)，以查看 Aspose.Slides 會取代哪個字型。亦請檢查 [font substitution](/slides/zh-hant/cpp/font-substitution/) 設定與 [font fallback](/slides/zh-hant/cpp/fallback-font/) 規則。Fallback 處理缺少的字元，因此嵌入字型無法解決字型本身不包含的字元。

**我應該嵌入如 Arial 與 Calibri 等常見字型嗎？**

應根據目標環境來決定。如果所有開啟或渲染簡報的機器皆已安裝所需字型，嵌入這些字型可能只會增加不必要的檔案大小。若接收者或伺服器可能缺少這些字型，則嵌入它們可協助保留預期的外觀，前提是其授權允許嵌入。