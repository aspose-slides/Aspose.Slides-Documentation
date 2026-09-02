---
title: 在 .NET 中設定簡報的字形置換
linktitle: 字形置換
type: docs
weight: 70
url: /zh-hant/net/font-substitution/
keywords:
- 字形
- 替代字形
- 字形置換
- 替換字形
- 字形取代
- 置換規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在渲染或轉換 PowerPoint 和 OpenDocument 簡報時，設定 Aspose.Slides for .NET 的字形置換規則並檢查被置換的字形。"
---
## **概觀**

字形置換允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字形來代替無法存取的字形。置換僅影響渲染輸出；不會更改簡報內容所指派的字形。

您可以定義在特定字形不可用時使用的字形，並且可以檢視 Aspose.Slides 在渲染過程中將執行的置換。這有助於在字形安裝環境不同的情況下，保持輸出的一致性。

## **取得字形置換**

使用 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/getsubstitutions/) 方法來判斷簡報渲染時將會置換哪些字形。此方法會傳回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsubstitutioninfo/) 物件，說明原始字形與置換字形的名稱。

以下 C# 範例會列出簡報的所有字形置換：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **取得特定投影片的字形置換**

使用帶有 `int[] slides` 參數的 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/getsubstitutions/) 重載，以僅檢查渲染特定投影片所需的置換。這在以下情況很有用：渲染或匯出簡報的部分內容、逐步檢查大型簡報、找出依賴不可用字形的投影片、為伺服器或容器準備最小字形套件、或在不處理其他投影片的情況下診斷渲染差異。

`slides` 陣列使用一基索引：`1` 代表第一張投影片。相較之下，[Presentation.Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slides/zh-hant/) 集合的索引子是零基的，因此同一張投影片需使用 `presentation.Slides[0]` 取得。建立陣列時請留意此差異，以免產生「少一」的錯誤。

透過 [Presentation.FontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/fontsmanager/) 屬性呼叫此重載。它只會傳回在渲染所選投影片時決定的置換。每個結果都是一個 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsubstitutioninfo/) 物件，包含原始字形與置換字形的名稱。結果會反映當前的字形環境、已設定的備援規則、存於 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsubstrulecollection/) 的置換規則，以及 [外部載入的字形](/slides/zh-hant/net/custom-font/)。

同一個置換可能同時被多個選取的投影片需求。建立字形清單或預檢報告時請去除重複項目。以下範例會報告每個回傳的置換，然後建立唯一字形對映的排序清單：

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

[IFontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/) 介面提供兩種重載。依照渲染操作的範圍選擇使用：

| Overload | 使用情境 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/getsubstitutions/)（無參數） | 需要整份簡報的置換。 |
| [GetSubstitutions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/getsubstitutions/)（`int[] slides`） | 需要選取範圍、增量檢查或部分匯出的置換。 |

## **設定字形置換規則**

若要指定當來源字形不可用時，Aspose.Slides 應使用的字形：

1. 載入簡報。  
2. 為來源與置換字形建立字形定義。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsubstrule/)。  
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsubstrulecollection/)。  
5. 將集合指派給 [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/fontsubstrulelist/) 屬性。  
6. 渲染或轉換簡報。

以下 C# 範例會在 `SomeRareFont` 不可用時，用 `Arial` 替代，並渲染第一張投影片以驗證結果。置換字形必須對 Aspose.Slides 可用。

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

若要無條件變更整份簡報所使用的字形，請參閱 [Font Replacement](/slides/zh-hant/net/font-replacement/)。

{{% /alert %}}

## **數學方程式字形的限制**

字形置換規則是渲染與轉換期間標準字形選取流程的一部分。它們可用於一般文字，讓 Aspose.Slides 以規則指定的可用字形取代無法存取的字形。

Office Math 方程式有額外需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該特定字形來計算與渲染方程式版面。將其他數學字形（例如 **STIX Two Math**）作為置換的規則無法取代 **Cambria Math**，渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以 [外部字形](/slides/zh-hant/net/custom-font/) 方式載入。

此限制僅影響方程式版面。上述置換規則仍適用於一般簡報文字。

## **常見問題**

**字形取代與字形置換有何不同？**

[Font replacement](/slides/zh-hant/net/font-replacement/) 會在整份簡報中刻意將一個字形換成另一個字形。字形置換則是在符合設定條件（例如原始字形不可用）時，為渲染輸出選擇字形。

**置換規則何時會套用？**

規則參與渲染與轉換期間的 [font selection sequence](/slides/zh-hant/net/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字形時使用。

**如果字形缺失且未設定置換規則，會發生什麼？**

Aspose.Slides 會根據其字形選取程序選取最接近的可用字形。結果取決於執行環境中可用的字形。

**我可以載入外部字形以避免置換嗎？**

可以。您可以 [load external fonts](/slides/zh-hant/net/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起分發字形？**

不會。字形的提供與授權遵循您自己的責任。

**置換結果會在 Windows、Linux、macOS 之間不同嗎？**

會。不同作業系統的已安裝字形與搜尋路徑不同，某台機器可用的字形在另一台可能需要置換。

**如何在批次轉換時保持字形選取一致？**

在每台機器或容器上使用相同的字形檔案與版本、[載入必要的外部字形](/slides/zh-hant/net/custom-font/)，以及在授權允許時 [embed fonts](/slides/zh-hant/net/embedded-font/)。您也可以在匯出前呼叫 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/getsubstitutions/) 以偵測意外的置換。