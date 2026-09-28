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
description: "在渲染或轉換 PowerPoint 與 OpenDocument 簡報時，於 .NET 的 Aspose.Slides 中設定字型替代規則並檢查已替代的字型。"
---
## **概述**

字型替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字型來取代無法存取的字型。此替代會影響渲染輸出；但不會更改指派給簡報內容的字型。

您可以定義當特定字型不可用時要使用的字型，並且可以檢查 Aspose.Slides 在渲染過程中將執行的替代。這有助於在安裝字型不同的環境中保持輸出一致性。

## **取得字型替代**

使用 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 方法來判斷在渲染簡報時會被替代的字型。此方法傳回 [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) 物件，這些物件會識別原始字型和替代字型的名稱。

以下 C# 範例列出簡報的全部字型替代：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **取得所選投影片的字型替代**

使用帶有 `int[] slides` 參數的 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 多載，以僅檢查渲染特定投影片所需的替代。這在您渲染或匯出簡報的部分、逐步檢查大型簡報、定位依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理其他投影片的情況下診斷渲染差異時非常有用。

`slides` 陣列使用以 1 為起始的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合的索引子是從 0 開始，所以同一張投影片須以 `presentation.Slides[0]` 取得。建立陣列時請留意此差異，以避免產生一位錯誤。

透過 [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) 屬性呼叫此多載。它只傳回在渲染所選投影片時決定的替代。每個結果都是包含原始與替代字型名稱的 [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) 物件。結果會反映目前的字型環境以及[外部載入的字型](/slides/zh-hant/net/custom-font/)。儲存在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) 中的替代規則會變更渲染輸出，但不會在結果中顯示。

同一個替代可能被多張所選投影片需求。建立字型清單或預檢報告時請對結果去除重複。以下範例會報告每個傳回的替代，然後建立唯一字型對映的排序清單：

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

[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) 介面提供兩種多載。依照渲染操作的範圍選擇使用：

| 多載 | 使用情境 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 不帶參數的 | 需要整個簡報的替代。 |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 帶有 `int[] slides` 參數的 | 需要特定範圍、增量檢查或部分匯出的替代。 |

## **設定字型替代規則**

指定在來源字型不可用時 Aspose.Slides 應使用的字型：

1. 載入簡報。
2. 為來源字型與替代字型建立字型定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/)。
5. 將該集合指派給 [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) 屬性。
6. 渲染或轉換簡報。

以下 C# 範例在 `SomeRareFont` 不可用時，使用 `Arial` 替代 `SomeRareFont`，然後渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

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
若要無條件變更整個簡報所使用的字型，請參閱 [Font Replacement](/slides/zh-hant/net/font-replacement/)。
{{% /alert %}}

## **數學公式字型的限制**

字型替代規則是渲染與轉換期間使用的標準字型選擇流程的一部份。當 Aspose.Slides 能以規則指定的可用字型取代不可存取的字型時，這些規則可適用於一般文字。

Office Math 公式有額外需求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要該精確字型來計算與渲染公式版面。使用其他數學字型（例如 **STIX Two Math**）的替代規則無法取代 **Cambria Math**，因此渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，必須讓 **Cambria Math** 對 Aspose.Slides 可用。可在作業系統中安裝，或以 [external font](/slides/zh-hant/net/custom-font/) 方式載入。

此限制僅適用於公式版面。上述的替代規則仍適用於一般簡報文字。

## **常見問題**

**字型取代與字型替代有何不同？**

[Font replacement](/slides/zh-hant/net/font-replacement/) 會在整個簡報中刻意將一種字型變更為另一種字型。字型替代則在符合設定條件（例如原始字型不可用）時，為渲染輸出選擇一個字型。

**何時套用替代規則？**

這些規則在渲染與轉換期間參與 [font selection sequence](/slides/zh-hant/net/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時使用。

**當字型缺失且未設定替代規則時會發生什麼？**

Aspose.Slides 會依照其字型選擇流程選取最接近的可用字型。結果取決於執行環境中可用的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以 [load external fonts](/slides/zh-hant/net/custom-font/) 讓 Aspose.Slides 在渲染與轉換時使用這些字型。

**Aspose 是否隨函式庫一起發佈字型？**

不會。字型由您自行提供並遵守其授權條款。

**替代結果會在 Windows、Linux 與 macOS 之間有所不同嗎？**

會。不同作業系統的已安裝字型與字型搜尋位置不同，因此在某台機器上可用的字型，可能在另一台機器上需要替代。

**如何在批次轉換中保持字型選擇一致？**

在每台機器或容器上使用相同的字型檔案與版本，[load required external fonts](/slides/zh-hant/net/custom-font/)，並在授權允許時 [embed fonts](/slides/zh-hant/net/embedded-font/)。您也可以在匯出前呼叫 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 以偵測非預期的替代。