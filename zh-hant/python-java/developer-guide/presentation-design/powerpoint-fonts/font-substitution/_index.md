---
title: 使用 Python 透過 Java 配置簡報中的字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "在使用 Python 透過 Java 渲染或轉換 PowerPoint 與 OpenDocument 簡報時，於 Aspose.Slides 中配置字型替代規則並檢查已替代的字型。"
---
## **概觀**

字型替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字型取代無法存取的字型。此替代會影響呈現的輸出；不會變更簡報內容中所指派的字型。

您可以在特定字型不可用時定義要使用的字型，亦可檢視 Aspose.Slides 在呈現過程中將執行的替代。這有助於在安裝字型不同的環境中保持輸出一致性。

## **取得字型替代**

使用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getSubstitutions) 方法來判斷簡報呈現時會替代哪些字型。該方法會傳回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstitutioninfo/) 物件，說明原始字型與替代字型名稱。

以下 Python 範例會列出簡報的所有字型替代：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **取得所選投影片的字型替代**

使用帶有 Java 整數陣列參數的 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getSubstitutions) 重載，僅檢查渲染特定投影片所需的替代。當您只渲染或匯出簡報的部分內容、逐步檢查大型簡報、尋找依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理無關投影片的情況下診斷渲染差異時，這非常有用。

`slides` 陣列使用一基索引：`1` 代表第一張投影片。相較之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 集合存取子使用零基索引，因此同一張投影片須以 `presentation.getSlides().get_Item(0)` 取得。建立陣列時請留意此差異，以免產生 off‑by‑one 錯誤。

透過 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getFontsManager) 方法呼叫此重載。它僅傳回在渲染所選投影片時決定的替代。每個結果都是一個 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstitutioninfo/) 物件，包含原始與替代字型名稱。結果會反映當前的字型環境、已配置的備援規則、存於 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstrulecollection/) 中的替代規則，以及 [外部載入的字型](/slides/zh-hant/python-java/custom-font/)。

相同的替代可能會被多個所選投影片需求。建立字型清單或預檢報告時請去除重複。以下範例會列出每筆返回的替代，然後建立唯一字型對映的排序清單：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 類別提供上述兩個重載。請依照渲染作業的範圍選擇使用：

| 重載 | 使用情境 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getSubstitutions)（不帶參數） | 需要整份簡報的替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getSubstitutions)（帶 Java 整數陣列） | 需要針對特定範圍、漸增檢查或部分匯出的替代。 |

## **設定字型替代規則**

若要指定當來源字型不可用時 Aspose.Slides 應使用的字型：

1. 載入簡報。
2. 為來源字型與替代字型建立字型定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) 條件建立一個 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstrulecollection/)。
5. 透過 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) 方法指派該集合。
6. 渲染或轉換簡報。

以下 Python 範例會在 `SomeRareFont` 無法取得時，以 `Arial` 取代該字型，並渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}}
若要無條件變更簡報中所有使用的字型，請參閱 [Font Replacement](/slides/zh-hant/python-java/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則屬於渲染與轉換期間使用的標準字型選擇流程。它們適用於 Aspose.Slides 能以規則指定的可用字型取代無法存取的字型之一般文字。

Office Math 方程式則有額外需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該字型才能計算與渲染方程式版面配置。替代為其他數學字型（例如 **STIX Two Math**）的規則無法取代 **Cambria Math**，渲染仍會回報需要 **Cambria Math**。

若要渲染或轉換此類簡報，必須讓 **Cambria Math** 對 Aspose.Slides 可用。可在作業系統中安裝，或以 [外部字型](/slides/zh-hant/python-java/custom-font/) 方式載入。

此限制僅適用於方程式版面配置。前述的替代規則仍然適用於簡報中的一般文字。

## **常見問題**

**字型取代與字型替換有何不同？**

[Font replacement](/slides/zh-hant/python-java/font-replacement/) 會在整份簡報中有意將一種字型改為另一種字型。字型替代則在符合設定條件（例如原始字型不可用）時，為渲染輸出選擇字型。

**什麼時候會套用替代規則？**

規則會參與渲染與轉換期間的 [font selection sequence](/slides/zh-hant/python-java/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時套用。

**如果缺少字型且未設定替代規則，會發生什麼？**

Aspose.Slides 會依其字型選擇流程，選取最接近的可用字型。結果取決於執行環境中可用的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以 [load external fonts](/slides/zh-hant/python-java/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起發佈字型？**

不會。字型的提供與授權必須由您自行負責。

**替代結果在 Windows、Linux、macOS 之間會不同嗎？**

會。不同作業系統的已安裝字型與搜尋路徑各異，同一台機器上可用的字型在其他機器上可能需要替代。

**如何在批次轉換時保持字型選擇一致？**

在每台機器或容器上使用相同的字型檔案與版本，[載入必要的外部字型](/slides/zh-hant/python-java/custom-font/)，並在授權允許時 [embed fonts](/slides/zh-hant/python-java/embedded-font/)。亦可在匯出前呼叫 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getSubstitutions) 以識別意外的替代。