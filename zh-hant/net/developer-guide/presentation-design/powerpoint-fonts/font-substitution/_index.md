---
title: 在 .NET 中設定簡報的字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/net/font-substitution/
keywords:
- 字型
- 替代字型
- 字型替代
- 取代字型
- 字型取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在渲染或轉換 PowerPoint 與 OpenDocument 簡報時，設定 Aspose.Slides for .NET 的字型替代規則並檢查已被替代的字型。"
---
## **概觀**

字型替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字型來取代無法存取的字型。替代僅影響渲染後的輸出；它不會更改簡報內容所指派的字型。

您可以定義在特定字型無法使用時要使用的字型，並且可以檢查 Aspose.Slides 在渲染過程中將執行的替代。這有助於在安裝字型不同的環境中保持輸出的一致性。

如果字型可用卻沒有專屬的粗體字形，請參閱[處理沒有專屬粗體字形的字型](/slides/zh-hant/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該部分說明如何在 PDF 匯出時光柵化受影響的文字，以及對文字選取、搜尋與縮放的影響。

## **取得字型替代**

使用[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 方法來判斷簡報渲染時會被替代的字型。該方法會回傳描述原始字型與替代字型名稱的[FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) 物件。

以下 C# 範例列出簡報的所有字型替代：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **取得選取投影片的字型替代**

使用帶有 `int[] slides` 參數的 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 重載，以僅檢查渲染特定投影片所需的替代。這在您只渲染或匯出簡報的一部分、逐步檢查大型簡報、找出依賴無法使用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理無關投影片的情況下診斷渲染差異時都很有幫助。

`slides` 陣列使用一基索引：`1` 表示第一張投影片。相較之下，[Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合的索引器是零基的，因此同一張投影片要以 `presentation.Slides[0]` 存取。建立陣列時請留意此差異，以免發生錯位錯誤。

透過 [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) 屬性呼叫此重載。它只回傳在渲染選取投影片時決定的替代。每個結果都是包含原始與替代字型名稱的[FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) 物件。結果會反映目前的字型環境以及[外部載入的字型](/slides/zh-hant/net/custom-font/)。儲存在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) 中的替代規則會變更渲染輸出，但不會反映在結果中。

同一個替代可能會被多張選取的投影片需求。在建立字型清單或預檢報告時請去除重複結果。以下範例會報告每個回傳的替代，然後建立唯一字型對映的排序清單：

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) 介面提供兩種重載。請依照渲染作業的範圍選擇使用哪一個：

| 重載 | 使用情境 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | 您需要整份簡報的字型替代。 |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | 您需要針對選取的範圍、逐步檢查或部分匯出取得字型替代。 |

## **設定字型替代規則**

指定當來源字型不可用時 Aspose.Slides 應使用的字型：

1. 載入簡報。
2. 建立來源字型與替代字型的字型定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/)。
5. 將集合指派給 [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) 屬性。
6. 渲染或轉換簡報。

以下 C# 範例在 `SomeRareFont` 無法使用時，以 `Arial` 替代其字型，然後渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
若要無條件變更整份簡報所使用的字型，請參閱[Font Replacement](/slides/zh-hant/net/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換過程中使用的標準字型選擇流程的一部份。當 Aspose.Slides 能以規則指定的可用字型取代無法存取的字型時，這些規則適用於一般文字。

Office Math 方程式有額外的需求。如果方程式使用 **Cambria Math**，Aspose.Slides 可能需要該特定字型來計算與渲染方程式版面。將其他數學字型（如 **STIX Two Math**）作為替代的規則無法取代 **Cambria Math**，渲染時仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可將其安裝於作業系統或以[外部字型](/slides/zh-hant/net/custom-font/) 方式載入。

此限制僅適用於方程式版面。上述的替代規則仍然適用於一般簡報文字。

## **常見問題**

**字型取代與字型替代之間有何差異？**

[Font replacement](/slides/zh-hant/net/font-replacement/) 會有意地在整份簡報中將一種字型改為另一種字型。字型替代則是在符合設定條件（例如原始字型不可用）時，為渲染的輸出選擇字型。

**什麼時候會套用替代規則？**

這些規則會在渲染與轉換期間參與[字型選擇序列](/slides/zh-hant/net/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時才會使用。

**當字型缺失且未設定替代規則時會發生什麼情況？**

Aspose.Slides 會根據其字型選擇流程挑選最接近的可用字型。結果取決於執行環境中可取得的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以[載入外部字型](/slides/zh-hant/net/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 會隨函式庫一起分發字型嗎？**

不會。您須自行提供字型並遵守其授權條款。

**不同作業系統（Windows、Linux、macOS）之間的替代結果會不同嗎？**

會。不同作業系統的已安裝字型與字型搜尋位置各異，因此在某台機器上可用的字型在另一台機器上可能需要替代。

**如何在批次轉換時保持字型選擇的一致性？**

在每台機器或容器上使用相同的字型檔案與版本，[載入所需的外部字型](/slides/zh-hant/net/custom-font/)，並在授權允許時[嵌入字型](/slides/zh-hant/net/embedded-font/)。您也可以在匯出前呼叫 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 以辨識非預期的替代。