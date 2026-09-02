---
title: 在 .NET 中管理腳本特定的主題字型
linktitle: 腳本特定主題字型
type: docs
weight: 15
url: /zh-hant/net/script-specific-font-mappings/
keywords:
- 腳本特定字型
- 主題字型映射
- 多語言簡報
- 書寫系統
- 西里爾字型
- 阿拉伯字型
- 日文字型
- 格魯吉亞字型
- 塔安那字型
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 檢查、加入、取代與移除 PowerPoint 主題中的腳本特定字型映射。"
---
## **概覽**

簡報主題可以為不同的書寫系統選擇不同的字型族。這讓仍使用主題字型的多語言文字，能在使用適合西里爾文、阿拉伯文、日文、格魯吉亞文、塔安那文等腳本的同時，遵循一致的字型配色。

主題的[IFontScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/ifontscheme/)包含一個主要字型集合（通常用於標題）與一個次要字型集合（通常用於內文）。除了它們的拉丁與東亞字型屬性外，兩個集合皆透過[IFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifonts/)介面暴露從書寫系統標籤到字型族名稱的對應關係。

本文說明如何檢查與修改簡報母片主題中的這些對應，並驗證變更在儲存與重新載入後仍會保留。

## **了解腳本標籤**

腳本字型方法使用四字母 BCP 47 腳本子標籤來識別書寫系統。常見值包括：

| 腳本標籤 | 書寫系統 |
|---|---|
| `Cyrl` | 西里爾字母 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 格魯吉亞文 |
| `Thaa` | 塔安那文 |

這些對應屬於主題字型方案，而非個別文字片段。簡報可為主要與次要集合定義不同的對應，亦可對某些腳本省略對應。

## **存取與檢查腳本字型對應**

使用[Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/)可取得簡報層級的主題。[FontScheme.Major](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/major/)與[FontScheme.Minor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/minor/)屬性回傳兩個[IFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifonts/)集合。

呼叫[IFonts.GetScriptFontMap](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fonts/getscriptfontmap/)可取得集合中的全部對應。若要查詢單一書寫系統，傳入其腳本標籤呼叫[IFonts.GetScriptFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fonts/getscriptfont/)即可。若該集合未定義請求的對應，`GetScriptFont` 會傳回 `null`。

## **修改對應並驗證持久性**

使用[IFonts.SetScriptFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fonts/setscriptfont/)可建立對應或取代現有字型族。使用[IFonts.RemoveScriptFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fonts/removescriptfont/)可移除對應。

以下端對端範例會讀取全部既有的主要與次要對應，查詢日文主要字型，變更西里爾主要字型，移除塔安那次要對應，儲存簡報，並重新開啟驗證兩項變更。為使移除步驟不受初始主題影響，範例會在尚未定義塔安那對應時先建立一筆。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

驗證的行為與普通查詢相同：移除後儲存，`GetScriptFont("Thaa")` 於次要集合會傳回 `null`。

## **將主題對應與其他字型設定區分開來**

腳本特定的主題對應會參與字型選取，但它解決的問題與直接的文字格式設定、字型替換與備援字型不同：

| 機制 | 目的 | 變更主題映射的影響 |
|---|---|---|
| 腳本特定主題字型映射 | 為特定書寫系統選取主要或次要主題字型。 | 仍使用對應主題字型的文字會解析為新映射的字型族。 |
| 明確指派給文字片段的字型 | 在該片段上固定請求的字型族，而非依賴主題。 | 直接格式會覆蓋主題選擇，文字可能保持不變。 |
| 字型替換 | 當請求的字型不存在或符合替換規則時，取代之。 | 替換發生在字型已被請求之後，並不會重新定義主題的腳本對應。 |
| 備援字型 | 為選取的字型未涵蓋的特定 Unicode 範圍提供字形。 | 只填補缺少的字形，並不會更改已儲存的主題對應。 |

欲了解最後兩種機制，請參閱[字型替換](/slides/zh-hant/net/font-substitution/)與[備援字型](/slides/zh-hant/net/fallback-font/)。

在[Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/)中變更對應，只會影響仍依賴該主題的內容。文字也可能從母片、版面配置或投影片繼承主題覆寫，或使用明確指派的字型。當可見結果未遵循簡報層級對應時，請檢查這些層級。

## **確保映射字型可用並驗證結果**

腳本映射僅儲存字型族名稱，並不會安裝或載入相對應的字型檔案。為了在渲染與匯出時保持一致，每一個映射字型必須已安裝於執行環境，或透過自訂來源（例如[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/)或[LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/documentlevelfontsources/)）提供給 Aspose.Slides。請參閱[自訂字型](/slides/zh-hant/net/custom-font/)了解可用的載入選項。

驗證已儲存的映射僅能確認主題定義已保留，無法證明字型是否可用、是否包含所有必要字形，或是否會產生預期的版面配置。建議把每個必需書寫系統的代表文字渲染成影像或 PDF，然後檢查輸出。這可在簡報分發前捕捉缺字、字形覆蓋不足、備援行為與版面變更等問題。請參閱[轉換 PowerPoint 簡報](/slides/zh-hant/net/convert-powerpoint/)了解渲染與匯出範例。

## **常見問題**

**當腳本未映射時，`GetScriptFont` 會回傳什麼？**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fonts/getscriptfont/) 在請求的腳本對應未在該主要或次要字型集合中定義時，會傳回 `null`。

**`SetScriptFont` 在腳本已存在時會新增第二筆對應嗎？**

不會。[IFonts.SetScriptFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fonts/setscriptfont/) 只會在缺少對應時建立，若相同腳本標籤已存在則會取代該映射的字型族。

**為什麼變更主題映射後部份文字沒有變化？**

該文字可能已明確指派字型、繼承自其他主題覆寫，或在渲染時受到字型替換或備援的影響。簡報層級的腳本映射僅控制仍以該主題字型集合為有效格式的文字。

**僅儲存並重新開啟就能驗證多語言輸出嗎？**

不能。重新開啟只能驗證主題資料的持久性。還需要渲染每個必需書寫系統的代表文字，確認映射字型已安裝且包含必要字形。