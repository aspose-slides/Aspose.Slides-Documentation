---
title: 管理 C++ 中腳本特定的主題字型
linktitle: 腳本特定的主題字型
type: docs
weight: 15
url: /zh-hant/cpp/script-specific-font-mappings/
keywords:
- 腳本特定字型
- 主題字型映射
- 多語言簡報
- 書寫系統
- 西里爾字型
- 阿拉伯字型
- 日文字型
- 喬治亞字型
- Thaana 字型
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "在 PowerPoint 主題中使用 Aspose.Slides for C++ 檢查、加入、取代與移除腳本特定的字型映射。"
---
## **概述**

簡報主題可以為不同的書寫系統選擇不同的字型族。這讓仍使用主題字型的多語言文字能在使用適合西里爾文、阿拉伯文、日文、喬治亞文、Thaana 以及其他文字的同時，遵循一套協調的字型方案。

主題的[IFontScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ifontscheme/)包含一個主要字型集合，通常用於標題，與一個次要字型集合，通常用於內文。除了它們的拉丁與東亞字型屬性外，兩個集合皆透過[IFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifonts/)介面公開從書寫系統標籤到字型族名稱的映射。

本文章說明如何檢查並修改簡報主題中的這些映射，以及如何驗證變更在儲存與重新載入後仍會保留。

## **了解腳本標籤**

腳本字型方法使用四個字母的 BCP 47 腳本子標籤來識別書寫系統。常見的值包括：

| 腳本標籤 | 書寫系統 |
|---|---|
| `Cyrl` | 西里爾文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 喬治亞文 |
| `Thaa` | Thaana |

這些映射屬於主題字型方案，而非個別文字區段。簡報可能為主要與次要集合定義不同的映射，亦可能省略某些腳本的映射。

## **存取與檢查腳本字型映射**

使用[Presentation::get_MasterTheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)取得簡報層級的主題。[FontScheme::get_Major](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_major/)與[FontScheme::get_Minor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_minor/)方法分別回傳兩個[IFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifonts/)集合。

呼叫[Fonts::GetScriptFontMap](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fonts/getscriptfontmap/)可取得集合中所有的映射。若要查詢單一書寫系統，請使用[Fonts::GetScriptFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fonts/getscriptfont/)並傳入其腳本標籤。當該集合未定義請求的映射時，`GetScriptFont` 會回傳 null 字串。

## **修改映射並驗證持久性**

使用[Fonts::SetScriptFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fonts/setscriptfont/)建立映射或取代現有的字型族。使用[Fonts::RemoveScriptFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fonts/removescriptfont/)可移除映射。

以下端到端範例會讀取所有現有的主要與次要映射，查詢日文的主要字型，變更西里爾文的主要字型，移除 Thaana 的次要映射，儲存簡報，然後重新開啟以驗證兩項變更。為了讓移除步驟不受初始主題影響，範例會在尚未定義 Thaana 映射時才建立它。

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

驗證使用與一般查詢相同的 null 字串行為：在移除後儲存，`GetScriptFont(u"Thaa")` 於次要集合會回傳 null 字串。

## **將主題映射與其他字型設定區分開來**

腳本特定的主題映射參與字型選擇，但它解決的問題與直接文字格式化、字型取代與回退機制不同：

| 機制 | 目的 | 更改主題映射的影響 |
|---|---|---|
| 腳本特定的主題字型映射 | 為書寫系統選取主要或次要主題字型。 | 仍使用相應主題字型的文字會解析為新的映射字型族。 |
| 明確指派給文字區段的字型 | 將請求的字型族固定在該區段上，而非依賴主題。 | 由於直接格式化會覆蓋主題選擇，該區段可能保持不變。 |
| 字型取代 | 當請求的字型不存在或符合取代規則時，取代為其他字型。 | 它在字型已被請求之後執行；不會重新定義主題的腳本映射。 |
| 字型回退 | 為選取的字型未包含的字形提供支援，通常針對特定 Unicode 範圍。 | 它填補缺少的字形，並不會改變儲存的主題映射。 |

欲取得有關最後兩種機制的更多資訊，請參閱[Font Substitution](/slides/zh-hant/cpp/font-substitution/)與[Fallback Fonts](/slides/zh-hant/cpp/fallback-font/)。

在[Presentation::get_MasterTheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/) 中變更映射，只會影響仍依賴該主題的有效格式化內容。文字可能改為從母版、版面配置或投影片繼承主題覆寫，或使用明確指派的字型。當可見結果未遵循簡報層級的映射時，請檢查這些層級。

## **讓映射的字型可用並驗證結果**

腳本映射僅儲存字型族名稱；它不會安裝或載入相應的字型檔案。為了確保一致的渲染與匯出，所有映射的字型必須已安裝於執行環境，或透過自訂來源提供給 Aspose.Slides，例如[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/loadexternalfonts/)或[LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)。請參閱[Custom Fonts](/slides/zh-hant/cpp/custom-font/)以取得可用的載入選項。

驗證已儲存的映射僅能證明主題定義已被保留，並不代表字型可用、包含所有必要字形，或能產生預期的版面配置。請將每個必需書寫系統的代表性文字渲染成影像或 PDF，並檢查輸出。此步驟可捕捉缺少字型、字形覆蓋不足、回退行為，以及在簡報分發前的版面變更。請參閱[Convert PowerPoint Presentations](/slides/zh-hant/cpp/convert-powerpoint/)以取得渲染與匯出範例。

## **常見問題**

**`GetScriptFont` 在腳本未映射時回傳什麼？**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fonts/getscriptfont/) 在請求的腳本映射未在該主要或次要字型集合中定義時，會回傳 null 字串。

**`SetScriptFont` 在腳本已存在時會新增第二筆映射嗎？**

不會。[Fonts::SetScriptFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fonts/setscriptfont/) 會在缺少映射時建立，若相同腳本標籤已存在則會取代原有的字型族。

**為什麼變更主題映射後有些文字未變化？**

該文字可能已明確指派字型、透過覆寫從其他主題繼承，或在渲染時受到取代或回退的影響。簡報層級的腳本映射僅控制仍依賴該主題字型集合的文字。

**僅儲存並重新開啟是否足以驗證多語言輸出？**

不足。重新開啟只能驗證主題資料的持久性。您還必須渲染每個必需書寫系統的代表性文字，以確認映射的字型可用且包含必要的字形。