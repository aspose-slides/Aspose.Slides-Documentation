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
description: "使用 Aspose.Slides for C++ 在 PowerPoint 投影片中自訂字型，讓您的簡報在任何裝置上都保持清晰且一致。"
---
## **概覽**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報渲染或匯出時使用，例如匯出為 PDF、影像及其他支援的格式。此功能有助於在不同環境中保持簡報輸出的一致性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

為渲染註冊自訂字型與將字型嵌入 PPTX 檔案是分開的步驟。若必須將字型儲存在簡報本身，請明確使用字型嵌入功能。

{{% alert color="primary" %}} 
Aspose Slides 允許您使用 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 載入這些字型：

* TrueType (.ttf) 與 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您載入簡報中使用的字型，而無需在系統上安裝它們。這會影響匯出結果——例如 PDF、影像及其他支援的格式——使產生的文件在各環境中保持一致。字型從自訂目錄載入。

1. 指定包含字型檔案的一個或多個資料夾。
2. 呼叫靜態方法 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 從這些資料夾載入字型。
3. 載入並渲染/匯出簡報。
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/clearcache/) 清除字型快取。

以下程式碼範例示範字型載入流程：

```cpp
// 定義包含自訂字型檔案的資料夾。
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 從指定的資料夾載入自訂字型。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 使用載入的字型渲染/匯出簡報（例如 PDF、影像或其他格式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 在工作完成後清除字型快取。
FontsLoader::ClearCache();
```

{{% alert color="info" title="注意" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 會將額外的資料夾加入字型搜尋路徑，但不會改變字型初始化的順序。字型會依以下順序初始化：

1. 作業系統的預設字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/) 載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**
Aspose.Slides 提供 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders/) 讓您取得字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 C++ 程式碼示範如何使用 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders/) 方法：

``` cpp
// 此行輸出檢查字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **為簡報指定使用的自訂字型**
Aspose.Slides 提供 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性，讓您指定在簡報中使用的外部字型。

以下 C++ 程式碼示範如何使用 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性：

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //處理簡報
    //CustomFont1、CustomFont2 以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型均可供簡報使用
}
```

## **外部管理字型**
Aspose.Slides 提供 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfont/) 方法，讓您將外部字型載入為位元組陣列。

以下 C++ 程式碼示範位元組陣列字型載入流程：

```cpp
// 文件目錄的路徑
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **常見問題**

**自訂字型會影響所有格式的匯出嗎（PDF、PNG、SVG、HTML）？**

是。連結的字型會由渲染器在所有匯出格式中使用。

**自訂字型會自動嵌入最終的 PPTX 嗎？**

否。為渲染註冊字型並不等同於將其嵌入 PPTX。若需要字型隨簡報檔案一起保存，必須使用明確的[嵌入功能](/slides/zh-hant/cpp/embedded-font/)。

**當自訂字型缺少某些字形時，我可以控制備援行為嗎？**

是。可設定[字型替代](/slides/zh-hant/cpp/font-substitution/)、[替換規則](/slides/zh-hant/cpp/font-replacement/)以及[備援集合](/slides/zh-hant/cpp/fallback-font/)，以明確定義在請求的字形缺失時使用哪個字型。

**我可以在 Linux/Docker 容器中使用字型而不在系統範圍內安裝嗎？**

是。只要指向自己的字型資料夾或從位元組陣列載入字型，即可在容器映像中不依賴系統字型目錄。

**關於授權呢——我可以在不受限制的情況下嵌入任何自訂字型嗎？**

您需自行負責字型授權的合規性。授權條款各有不同；某些授權禁止嵌入或商業使用。發布輸出前，請務必檢查字型的最終使用者許可協議（EULA）。