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
description: "使用 Aspose.Slides for C++ 在 PowerPoint 投影片中自訂字型，讓您的簡報在任何裝置上都保持清晰一致。"
---
## **概觀**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

已載入的字型會在簡報呈現或匯出時使用，例如匯出為 PDF、影像以及其他支援的格式。這有助於在不同環境中保持簡報輸出的前後一致性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供呈現與將字型嵌入 PPTX 檔案是分開的作業。如果必須將字型儲存在簡報本身，請明確使用字型嵌入功能。

簡報佈景主題可以為各個書寫系統參照不同的字型系列。這些對映會儲存字型名稱，但不會安裝或載入字型檔案。請參閱 [腳本特定佈景字型](/slides/zh-hant/cpp/script-specific-font-mappings/) 以管理這些對映，並使用下列載入選項，使參照的字型可用於一致的呈現。

{{% alert color="info" title="Note" %}}
Aspose Slides 允許您使用 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 載入這些字型：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在不安裝字型至系統的情況下載入簡報中使用的字型。這會影響匯出輸出——例如 PDF、影像及其他支援的格式——使最終文件在各環境中保持一致。字型會從自訂目錄載入。

1. 指定一或多個包含字型檔案的資料夾。
2. 呼叫靜態方法 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 從這些資料夾載入字型。
3. 載入並呈現/匯出簡報。
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/clearcache/) 以清除字型快取。

以下程式碼範例示範字型載入流程：

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 定義包含自訂字型檔案的資料夾。
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 從指定的資料夾載入自訂字型。
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 使用已載入的字型呈現/匯出簡報（例如 PDF、影像或其他格式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 工作完成後清除字型快取。
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 會將額外的資料夾加入字型搜尋路徑，但不會更改字型的初始化順序。字型會依下列順序初始化：

1. 預設作業系統字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/) 載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders/) 讓您取得字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 C++ 程式碼示範如何使用 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders()) 方法：

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// 此行輸出被檢查以尋找字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **指定簡報使用的自訂字型**

Aspose.Slides 提供 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性，讓您指定將在簡報中使用的外部字型。

以下 C++ 程式碼示範如何使用 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性：

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //對簡報進行操作
    //CustomFont1、CustomFont2 以及來自 assets\fonts 和 global\fonts 資料夾及其子資料夾的字型皆可供簡報使用
}
```

## **外部管理字型**

Aspose.Slides 提供 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfont/) 方法，以將外部字型載入至位元組陣列。

以下 C++ 程式碼示範位元組陣列的字型載入流程：

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### 自訂字型會影響所有格式的匯出（PDF、PNG、SVG、HTML）嗎？

是。已註冊的字型會被渲染器在所有匯出格式中使用。

### 自訂字型會自動嵌入至產生的 PPTX 中嗎？

否。將字型註冊供呈現使用並不等同於將其嵌入 PPTX 中。如果您需要字型隨簡報檔案一起攜帶，必須使用明確的[嵌入功能](/slides/zh-hant/cpp/embedded-font/)。

### 當自訂字型缺少某些字形時，我可以控制回退行為嗎？

是。可設定[字型替代](/slides/zh-hant/cpp/font-substitution/)、[替換規則](/slides/zh-hant/cpp/font-replacement/)及[回退集合](/slides/zh-hant/cpp/fallback-font/)，以明確定義在請求的字形缺失時使用哪個字型。

### 我能在 Linux/Docker 容器中使用字型而不需在系統層面安裝嗎？

是。指向您自己的字型資料夾或從位元組陣列載入字型。這樣可消除容器映像檔對系統字型目錄的任何依賴。

### 關於授權呢——我可以在不受限制的情況下嵌入任何自訂字型嗎？

您需自行負責字型授權的合規性。授權條款各有不同；有些授權禁止嵌入或商業使用。請務必在分發輸出前查閱字型的最終使用者授權協議 (EULA)。