---
title: 使用 Python 在簡報中設定字體替代
linktitle: 字體替代
type: docs
weight: 70
url: /zh-hant/python-net/font-substitution/
keywords:
- 字體
- 替代字體
- 字體替代
- 取代字體
- 字體取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在使用 .NET 的 Python 版 Aspose.Slides 渲染或轉換 PowerPoint 與 OpenDocument 簡報時，設定字體替代規則並檢查已替代的字體。"
---
## **概觀**

字體替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字體來取代無法存取的字體。此替代會影響渲染的輸出；但不會變更簡報內容所指派的字體。

您可以在特定字體不可用時定義要使用的字體，並且可以檢查 Aspose.Slides 在渲染過程中將執行的替代。這有助於在安裝字體不同的環境中保持輸出一致。

如果字體可用但沒有專用的粗體字形，請參閱 [處理沒有專用粗體字形的字體](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該章節說明如何在 PDF 匯出期間對受影響的文字進行光柵化，以及對文字選取、搜尋和縮放的影響。

## **取得字體替代**

使用 [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) 方法可判斷在渲染簡報時哪些字體會被替代。此方法會回傳 [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) 物件，這些物件會標示原始字體名稱與替代字體名稱。

以下 Python 範例列出簡報的所有字體替代：

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **取得選取投影片的字體替代**

使用帶有投影片索引清單的 [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) 來僅檢查渲染特定投影片所需的替代。當您要渲染或匯出簡報的一部分、逐步檢查大型簡報、找出依賴不可用字體的投影片、為伺服器或容器準備最小字體套件，或在不處理無關投影片的情況下診斷渲染差異時，這非常有用。

清單包含以 1 為起始的投影片索引：`1` 代表第一張投影片。相比之下，[Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合是以 0 為起點，因此同一張投影片需透過 `presentation.slides[0]` 取得。建立清單時請注意此差異，以免產生索引錯誤。

透過 [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) 屬性呼叫此方法。它僅回傳在渲染所選投影片時確定的替代。每個結果都是一個包含原始與替代字體名稱的 [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) 物件。結果會反映當前的字體環境、已設定的備援規則、存於 [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/) 的替代規則，以及 [外部載入的字體](/slides/zh-hant/python-net/custom-font/)。

同一個替代可能被多張選取的投影片需求。建立字體清單或預檢報告時，請將結果去除重複。以下範例會報告每個回傳的替代，然後建立唯一字體映射的排序清單：

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) 類別提供此方法的兩種形式。請依照渲染作業的範圍選擇使用：

| 方法呼叫 | 使用情境 |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | 您需要整份簡報的字體替代。 |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | 您需要針對選取範圍、逐步檢查或部分匯出取得字體替代。 |

## **設定字體替代規則**

若要指定 Aspose.Slides 在來源字體不可用時應使用的字體：

1. 載入簡報。
2. 為來源字體與替代字體建立字體定義。
3. 使用 [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) 條件建立一個 [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/)。
4. 將規則新增至 [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/)。
5. 將集合指定給 [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) 屬性。
6. 渲染或轉換簡報。

以下 Python 範例在 `SomeRareFont` 不可用時，用 `Arial` 取代 `SomeRareFont`，然後渲染第一張投影片以驗證結果。替代字體必須對 Aspose.Slides 可用。

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
若要對整份簡報使用的字體進行無條件變更，請參閱 [字體取代](/slides/zh-hant/python-net/font-replacement/)。
{{% /alert %}}

## **數學公式字體的限制**

字體替代規則是渲染與轉換過程中使用的標準字體選擇流程的一部分。當 Aspose.Slides 能以規則指定的可用字體取代無法存取的字體時，這些規則適用於一般文字。

Office Math 公式有額外需求。如果公式使用 **Cambria Math**，Aspose.Slides 可能需要該精確字體才能計算並渲染公式版面。使用其他數學字體（例如 **STIX Two Math**）的替代規則無法取代 **Cambria Math**，渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以 [外部字體](/slides/zh-hant/python-net/custom-font/) 載入。

此限制僅影響公式版面。上述的替代規則仍適用於簡報的普通文字。

## **常見問題**

**字體取代與字體替代之間的差異是什麼？**

[字體取代](/slides/zh-hant/python-net/font-replacement/) 會有意地在整份簡報中將一種字體更換為另一種字體。字體替代則在符合設定條件時（例如原始字體不可用），為渲染輸出選擇字體。

**什麼時候會套用替代規則？**

這些規則會在渲染與轉換期間參與 [字體選擇序列](/slides/zh-hant/python-net/font-selection-sequence/)。使用 `WHEN_INACCESSIBLE` 時，規則僅在 Aspose.Slides 無法存取來源字體時套用。

**當字體缺失且未設定替代規則時會發生什麼情況？**

Aspose.Slides 會依照字體選擇程序選取最接近的可用字體。結果取決於執行環境中可用的字體。

**我可以載入外部字體以避免替代嗎？**

可以。您可以 [載入外部字體](/slides/zh-hant/python-net/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 會隨函式庫一起分發字體嗎？**

不會。您需自行提供字體並遵守其授權條款。

**字體替代結果在 Windows、Linux 與 macOS 之間會有所不同嗎？**

會。不同作業系統的已安裝字體與字體搜尋位置不同，因此在某台機器上可用的字體，可能在另一台機器上需要替代。

**如何在批次轉換中使字體選擇保持一致？**

在每台機器或容器上使用相同的字體檔案與版本，[載入所需的外部字體](/slides/zh-hant/python-net/custom-font/)，並在授權允許時 [嵌入字體](/slides/zh-hant/python-net/embedded-font/)。您也可以在匯出前呼叫 [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) 以偵測意外的替代。