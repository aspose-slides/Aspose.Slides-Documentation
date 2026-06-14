---
title: 在 C++ 中自訂 PowerPoint 字型
linktitle: 自訂字型
type: docs
weight: 20
url: /zh-hant/cpp/custom-font/
keywords:
- 字型
- 自訂字型
- 外部字型
- 載入字型
- 管理字型
- 字型資料夾
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 客製化 PowerPoint 投影片的字型，確保您的簡報在任何裝置上保持清晰且一致。"
---
## **概觀**

Aspose.Slides 允許您在投影片中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型、透過文件層級的字型來源為特定投影片提供字型，或直接從二進位資料載入外部字型。

載入的字型會在投影片被渲染或匯出時使用，例如匯出為 PDF、圖片及其他支援的格式。這有助於在不同環境中保持投影片輸出的前後一致性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供渲染與將字型嵌入 PPTX 檔案是兩件不同的事。如果必須將字型儲存在投影片本身，請明確使用字型嵌入功能。

{{% alert color="primary" %}} 

Aspose Slides 允許您使用 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 載入這些字型：

* TrueType（.ttf）與 TrueType Collection（.ttc）字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在投影片中使用自訂字型，而無需在系統上安裝。這會影響匯出輸出——例如 PDF、圖片及其他支援的格式——使生成的文件在不同環境中保持一致。字型從自訂目錄載入。

1. 指定一或多個包含字型檔案的資料夾。
2. 呼叫靜態 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 方法，從這些資料夾載入字型。
3. 載入並渲染/匯出投影片。
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/clearcache/) 以清除字型快取。

以下程式碼範例示範字型載入流程：

```cpp
// 定義包含自訂字型檔案的資料夾。
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 從指定的資料夾載入自訂字型。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 使用已載入的字型渲染/匯出投影片（例如 PDF、圖片或其他格式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 工作完成後清除字型快取。
FontsLoader::ClearCache();
```

{{% alert color="info" title="注意" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 會將額外資料夾加入字型搜尋路徑，但不會變更字型的初始化順序。字型的初始化順序如下：

1. 預設的作業系統字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/) 載入的路徑。

{{%/alert %}}

## **取得自訂字型資料夾**
Aspose.Slides 提供 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders/) 讓您取得字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 C++ 程式碼示範如何使用 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders/) 方法：

``` cpp
// 此行會輸出檢查字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **為投影片指定使用的自訂字型**
Aspose.Slides 提供 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性，讓您指定將在投影片中使用的外部字型。

以下 C++ 程式碼示範如何使用 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性：

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // 與投影片一起工作
    // CustomFont1、CustomFont2 以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型皆可在投影片中使用
}
```

## **在外部管理字型**
Aspose.Slides 提供 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfont/) 方法，讓您將外部字型載入為位元組陣列。

以下 C++ 程式碼示範位元組陣列的字型載入過程：

```cpp
// 文件目錄的路徑
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ；
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

**自訂字型會影響所有格式的匯出嗎（PDF、PNG、SVG、HTML）？**

是。已連結的字型會由轉譯器在所有匯出格式中使用。

**自訂字型會自動嵌入最終的 PPTX 嗎？**

否。將字型註冊供渲染使用並不等同於將其嵌入 PPTX。如果您需要字型隨投影片檔案一起保存，必須使用明確的[嵌入功能](/slides/zh-hant/cpp/embedded-font/)。

**當自訂字型缺少特定字形時，我能控制回退行為嗎？**

是。您可以設定[字型替代](/slides/zh-hant/cpp/font-substitution/)、[取代規則](/slides/zh-hant/cpp/font-replacement/)與[回退集合](/slides/zh-hant/cpp/fallback-font/)，以明確指定在請求的字形缺失時使用哪一個字型。

**我能在 Linux/Docker 容器中使用字型，而不必在系統層面安裝嗎？**

是。指向您自己的字型資料夾或從位元組陣列載入字型。這樣可消除容器映像檔對系統字型目錄的任何依賴。

**關於授權—我可以無限制地嵌入任何自訂字型嗎？**

字型授權遵循您的責任。授權條款各有不同；某些授權禁止嵌入或商業使用。在分發成果之前，請務必檢查字型的最終使用者授權協議（EULA）。