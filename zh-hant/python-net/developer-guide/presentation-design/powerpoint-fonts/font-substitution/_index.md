---
title: 使用 Python 在投影片中設定字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/python-net/font-substitution/
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
- 投影片
- Python
- Aspose.Slides
description: "在使用 .NET 的 Python 版 Aspose.Slides 進行 PowerPoint 與 OpenDocument 投影片的渲染或轉換時，設定字型替代規則並檢查被替代的字型。"
---
## **概觀**

字型替代允許 Aspose.Slides 在呈現或轉換投影片時，使用可用的字型來取代無法存取的字型。此替代會影響渲染的輸出；但不會更改投影片內容所指派的字型。

您可以在特定字型不可用時定義要使用的字型，並且可以檢查 Aspose.Slides 在渲染過程中將執行的替代。這有助於在安裝字型不同的環境中保持輸出的一致性。

## **取得字型替代**

使用 [FontsManager.get_substitutions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_substitutions/) 方法來確定在渲染投影片時會被替代的字型。此方法會回傳 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsubstitutioninfo/) 物件，該物件會標示原始字型與替代字型的名稱。

以下 Python 範例列出投影片的所有字型替代：

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **取得所選投影片的字型替代**

使用 [FontsManager.get_substitutions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_substitutions/) 搭配投影片索引清單，以僅檢查渲染特定投影片所需的替代。當您只渲染或匯出投影片的一部分、逐步檢查大型投影片、找出依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理其他投影片的情況下診斷渲染差異時，此功能非常有用。

清單使用從 1 起算的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation.slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 集合是從 0 起算的，因此同一張投影片需寫成 `presentation.slides[0]`。在建立清單時請記住此差異，以免產生錯誤的索引。

透過 [Presentation.fonts_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/fonts_manager/) 屬性呼叫此方法。它僅回傳在渲染所選投影片時決定的替代。每個結果都是包含原始與替代字型名稱的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsubstitutioninfo/) 物件。結果會反映目前的字型環境、已設定的備援規則、儲存在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifontsubstrulecollection/) 中的替代規則，以及 [外部載入的字型](/slides/zh-hant/python-net/custom-font/)。

同一個替代可能會被多個所選投影片需要。建立字型清單或預檢報告時請去除重複項目。以下範例會列出每個回傳的替代，然後產生唯一字型對應的排序清單：

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

[FontsManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/) 類別提供此方法的兩種形式。請根據渲染操作的範圍選擇使用：

| 方法呼叫 | 使用情境 |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_substitutions/) 不帶參數 | 您需要整份投影片的字型替代。 |
| [get_substitutions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_substitutions/) 搭配投影片索引清單 | 您需要針對選取範圍、逐步檢查或部分匯出取得字型替代。 |

## **設定字型替代規則**

指定在來源字型不可用時 Aspose.Slides 應使用的字型：

1. 載入投影片。
2. 為來源字型與替代字型建立字型定義。
3. 使用 [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsubstrulecollection/)。
5. 將集合指派給 [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) 屬性。
6. 渲染或轉換投影片。

以下 Python 範例在 `SomeRareFont` 不可用時以 `Arial` 替代，並渲染第一張投影片以驗證結果。替代字型必須在 Aspose.Slides 可取得。

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
若要無條件變更整份投影片所使用的字型，請參閱 [Font Replacement](/slides/zh-hant/python-net/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換期間使用的標準字型選擇流程的一部分。當 Aspose.Slides 能以規則指定的可用字型取代不可存取的字型時，這些規則適用於一般文字。

Office Math 方程式有額外需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該特定字型來計算與渲染方程式版面。使用其他數學字型（例如 **STIX Two Math**）的替代規則無法取代 **Cambria Math**，渲染仍可能顯示需要 **Cambria Math**。

若要渲染或轉換此類投影片，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以 [external font](/slides/zh-hant/python-net/custom-font/) 載入。

此限制僅適用於方程式版面。上述的替代規則仍然適用於一般投影片文字。

## **常見問題**

**字型置換與字型替代之間有何差異？**

[Font replacement](/slides/zh-hant/python-net/font-replacement/) 會有意地在整份投影片中將一種字型變更為另一種字型。字型替代則在符合設定條件（例如原始字型不可用）時，為渲染輸出選取字型。

**什麼時候會套用替代規則？**

這些規則會於渲染與轉換過程中參與 [font selection sequence](/slides/zh-hant/python-net/font-selection-sequence/)。使用 `WHEN_INACCESSIBLE` 時，規則僅在 Aspose.Slides 無法存取來源字型時套用。

**當字型缺失且未設定替代規則時會發生什麼情況？**

Aspose.Slides 會根據字型選擇流程挑選最接近的可用字型。結果取決於執行環境中可用的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以 [load external fonts](/slides/zh-hant/python-net/custom-font/) 讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起分發字型？**

不會。您必須自行提供字型並遵守其授權條款。

**替代結果會在 Windows、Linux 與 macOS 之間有所差異嗎？**

會。不同作業系統的已安裝字型與字型搜尋位置各異，因而某台機器可用的字型在另一台上可能需要替代。

**如何在批次轉換中保持字型選擇的一致性？**

在每台機器或容器上使用相同的字型檔案與版本，於需要時 [load required external fonts](/slides/zh-hant/python-net/custom-font/)，且在授權允許時 [embed fonts](/slides/zh-hant/python-net/embedded-font/)。您也可以在匯出前呼叫 [FontsManager.get_substitutions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_substitutions/) 以偵測意外的替代。