---
title: 使用 C++ 在簡報中嵌入字型
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 簡報中嵌入 TrueType 字型，確保在所有平台上正確呈現。"
---
## **簡介**

**PowerPoint 中的嵌入字型** 可確保您的簡報在任何系統或裝置上開啟時，仍保留原本的外觀。這在使用自訂、第三方或非標準字型進行品牌或創意設計時尤為重要。若未嵌入字型，文字可能被替代、版面配置會出錯，甚至出現無法辨識的符號或方塊，進而破壞整體設計。

Aspose.Slides for C++ 提供一組強大的 API，讓您以程式方式管理嵌入字型。您可以使用 [FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 與 [FontData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontdata/) 類別來檢視、加入或移除簡報檔案中的嵌入字型。此外， [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別可在不影響品質或外觀的前提下，壓縮字型資料以優化檔案大小。

這些工具讓您完整掌控字型嵌入，協助在跨平台時維持一致的排版，同時在需要時降低檔案大小。

## **從簡報中取得嵌入字型**

Aspose.Slides for C++ 透過 [FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 類別提供 `GetEmbeddedFonts` 方法，讓您取得 PowerPoint 簡報中已嵌入的字型清單。這對於稽核字型使用情形、確保符合品牌指南，或在共享檔案前驗證所有必要字型已正確包含，都非常有幫助。

以下 C++ 程式碼示範如何從簡報檔案取得嵌入字型：

```cpp
// 實例化表示簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// 取得所有嵌入的字型。
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// 列印已嵌入字型的名稱。
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **將字型嵌入簡報**

Aspose.Slides for C++ 允許您使用 [AddEmbeddedFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/addembeddedfont/) 方法將字型嵌入 PowerPoint 簡報，此方法提供兩個重載以供彈性使用。您可透過 [EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/embedfontcharacters/) 列舉控制嵌入的字元量——例如，只嵌入實際使用的字元或整個字型集。此功能在準備分享或分發簡報時特別有用，能確保自訂或非標準字型即使在未安裝的系統上也能正確顯示。

以下 C++ 程式碼會檢查簡報中使用的所有字型，並將尚未嵌入的字型加入嵌入。

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
        // 將字型嵌入簡報中。
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// 將簡報儲存至磁碟。
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **從簡報中移除嵌入字型**

Aspose.Slides for C++ 透過 [FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 類別提供 `RemoveEmbeddedFont` 方法，讓您移除 PowerPoint 簡報中特定的嵌入字型。這可協助減少整體檔案大小，特別是當嵌入的字型已不再使用或不再需要時。移除未使用的字型亦能提升效能，確保簡報僅包含必要的資源。

以下 C++ 程式碼示範如何從簡報中移除嵌入字型：

```cpp
auto fontName = u"Calibri";

// 實例化表示簡報檔案的 Presentation 類別。
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

Aspose.Slides for C++ 透過 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別提供 `CompressEmbeddedFonts` 方法，您可以藉由最佳化嵌入字型資料來減少簡報的整體檔案大小。當簡報包含大型或多種字型，需要保持檔案輕量以便共享、儲存或線上使用時，這項功能特別有用，且不會影響內容的視覺忠實度。

以下 C++ 程式碼示範如何壓縮 PowerPoint 簡報中的嵌入字型：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問與答**

**如何判斷即使已嵌入，簡報中的特定字型在渲染時仍會被替代？**

檢查字型管理員中的 [substitution information](/slides/zh-hant/cpp/font-substitution/) 以及 [fallback/substitution rules](/slides/zh-hant/cpp/fallback-font/)：若字型不可用或受限，系統會使用備援字型。

**嵌入「系統」字型（如 Arial、Calibri）值得嗎？**

通常不需要——這些字型幾乎在所有環境中皆已安裝。但在「瘦」環境（Docker、未預裝字型的 Linux 伺服器）中為了確保完整可移植性，嵌入系統字型可避免意外的替代情況。