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
description: "使用 Aspose.Slides for C++ 在 PowerPoint 投影片中自訂字型，讓您的簡報在任何裝置上保持清晰且一致。"
---
## **概觀**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報呈現或匯出時使用，例如匯出為 PDF、影像或其他支援的格式。這有助於在不同環境中保持簡報輸出的相容性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供呈現與將字型嵌入 PPTX 檔案是分開的動作。如果需要將字型儲存在簡報本身，請明確使用字型嵌入功能。

{{% alert color="info" %}} 
Aspose Slides 允許您使用 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 載入這些字型：

* TrueType (.ttf) 與 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在不將字型安裝至系統的情況下載入簡報中使用的字型。這會影響匯出輸出—例如 PDF、影像與其他支援的格式—使得最終文件在不同環境中保持一致。字型是從自訂目錄載入的。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態的 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 方法，從這些資料夾載入字型。
3. 載入並呈現/匯出簡報。
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/clearcache/) 以清除字型快取。

以下程式範例示範字型載入流程：

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

// 使用已載入的字型渲染/匯出簡報（例如 PDF、影像或其他格式）。
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 工作完成後清除字型快取。
FontsLoader::ClearCache();
```

{{% alert color="info" title="注意" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/) 會將額外的資料夾加入字型搜尋路徑，但不會變更字型初始化的順序。  
字型的初始化順序如下：

1. 作業系統的預設字型路徑。  
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/) 載入的路徑。  
{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders/)，讓您找出字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 C++ 程式碼示範如何使用 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/getfontfolders/) 方法：

```cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// 此行輸出被檢查以取得字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的資料夾以及系統字型資料夾。
auto fontFolders = FontsLoader::GetFontFolders();
```

## **為簡報指定使用的自訂字型**

Aspose.Slides 提供 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性，讓您指定將與簡報一起使用的外部字型。

以下 C++ 程式碼示範如何使用 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 屬性：

```cpp
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
    //與簡報互動
    //CustomFont1、CustomFont2 以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型，皆可供簡報使用
}
```

## **外部管理字型**

Aspose.Slides 提供 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfont/) 方法，讓您將外部字型載入為位元組陣列。

以下 C++ 程式碼示範位元組陣列字型的載入過程：

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

### 自訂字型是否會影響匯出至所有格式（PDF、PNG、SVG、HTML）？

是的。已連結的字型會在渲染器中於所有匯出格式使用。

### 自訂字型是否會自動嵌入至產生的 PPTX？

否。註冊字型僅供渲染使用，並不等同於將其嵌入 PPTX。若需要字型隨簡報檔案一同攜帶，必須使用明確的[嵌入功能](/slides/zh-hant/cpp/embedded-font/)。

### 當自訂字型缺少某些字形時，我能控制備援行為嗎？

可以。您可設定[字型替代](/slides/zh-hant/cpp/font-substitution/)、[替換規則](/slides/zh-hant/cpp/font-replacement/)以及[備援集合](/slides/zh-hant/cpp/fallback-font/)，以明確定義在請求的字形缺失時使用哪個字型。

### 我可以在 Linux/Docker 容器中使用字型而不必全系統安裝嗎？

可以。只要指向您自己的字型資料夾或從位元組陣列載入字型，即可在容器映像中不依賴系統字型目錄。

### 關於授權—我可以在沒有限制的情況下嵌入任何自訂字型嗎？

您須自行負責字型授權的合規性。授權條款各不相同，有些授權禁止嵌入或商業使用。發佈輸出前，務必檢視字型的最終使用者授權協議 (EULA)。