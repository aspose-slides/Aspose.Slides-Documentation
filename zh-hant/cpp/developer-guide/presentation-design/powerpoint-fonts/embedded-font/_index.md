---
title: 使用 С++ 在簡報中嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/cpp/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得已嵌入的字型
- 新增已嵌入的字型
- 移除已嵌入的字型
- 壓縮已嵌入的字型
- PowerPoint
- OpenDocument
- 簡報
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++ 將 TrueType 字型嵌入 PowerPoint 與 OpenDocument 簡報，確保在所有平台上精確渲染。"
---
## **介紹**

**Embedded fonts in PowerPoint** 有助於確保您的簡報在任何系統或裝置上開啟時，都能保留預期的外觀。這在使用自訂、第三方或非標準字型進行品牌或創意設計時尤為重要。若未嵌入字型，文字可能會被取代、版面配置會中斷，甚至顯示為不可讀的符號或方塊，從而破壞整體設計。

Aspose.Slides for C++ 提供一組功能強大的 API，讓您能以程式方式管理嵌入字型。您可以使用[FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 與 [FontData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontdata/) 類別來檢查、加入或移除簡報檔案中的嵌入字型。此外，[Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別可在不影響品質或外觀的前提下，壓縮字型資料以優化檔案大小。

這些工具讓您全面掌控字型嵌入，協助在各平台上維持一致的排版，同時在需要時減少檔案體積。

## **取得簡報中的嵌入字型**

Aspose.Slides for C++ 透過[FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 類別提供 `GetEmbeddedFonts` 方法，讓您取得 PowerPoint 簡報中嵌入的字型清單。此功能可用於稽核字型使用情況、確保符合品牌指引，或在分享檔案前驗證所有必要字型是否已正確包含。

以下 C++ 程式碼示範如何從簡報檔案取得嵌入字型：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// 取得所有嵌入的字型。
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// 列印嵌入字型的名稱。
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **將嵌入字型加入簡報**

Aspose.Slides for C++ 允許您使用[AddEmbeddedFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/addembeddedfont/) 方法將字型嵌入 PowerPoint 簡報，該方法提供兩個重載以符合彈性需求。您可以透過[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/embedfontcharacters/) 列舉控制嵌入字型的範圍——例如僅嵌入已使用的字符或完整的字型集合。此功能在準備分享或發佈簡報時特別有用，確保自訂或非標準字型在所有系統上正確顯示，即使目標機器未安裝該字型。

以下 C++ 程式碼會檢查簡報中使用的所有字型，並將未嵌入的字型加入嵌入：

```cpp
// 載入簡報檔案。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // 檢查字型是否已嵌入。
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // 將字型嵌入簡報。
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// 儲存簡報至磁碟。
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **從簡報中移除嵌入字型**

Aspose.Slides for C++ 透過[FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 類別提供 `RemoveEmbeddedFont` 方法，讓您移除 PowerPoint 簡報中特定的嵌入字型。此功能可協助減少整體檔案大小，特別是在嵌入的字型已不再使用或不需要時。移除未使用的字型亦能提升效能，確保簡報僅包含必要的資源。

以下 C++ 程式碼示範如何從簡報中移除嵌入字型：

```cpp
auto fontName = u"Calibri";

// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// 取得所有嵌入的字型。
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // 移除已嵌入的字型。
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **壓縮嵌入字型**

Aspose.Slides for C++ 透過[Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別提供 `CompressEmbeddedFonts` 方法，讓您透過優化嵌入字型資料來減少簡報的總體檔案大小。當簡報包含大型或多個字型，且您希望在分享、儲存或線上使用時保持檔案輕量化——而不犧牲內容的視覺忠實度，此功能特別實用。

以下 C++ 程式碼示範如何壓縮 PowerPoint 簡報中的嵌入字型：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**如何判斷即使已嵌入，簡報中的特定字型在渲染時仍會被取代？**

檢查字型管理員中的[取代資訊](/slides/zh-hant/cpp/font-substitution/)以及[備用/取代規則](/slides/zh-hant/cpp/fallback-font/)：若該字型不可用或受限，系統會使用備用字型。

**是否值得嵌入像 Arial、Calibri 這類「系統」字型？**

通常不需要——因為這些字型幾乎總是可用。但在「瘦」環境（Docker、未預裝字型的 Linux 伺服器）中，嵌入系統字型可排除意外取代的風險，確保完整可攜性。