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
description: "在使用 Python 透過 Java 渲染或轉換 PowerPoint 和 OpenDocument 簡報時，設定字型替代規則並檢查 Aspose.Slides 中的替代字型。"
---
## **概觀**

字型替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字型來取代無法存取的字型。替代會影響渲染後的輸出；它不會更改簡報內容所指派的字型。

您可以定義在特定字型無法使用時應使用的字型，並且可以檢視 Aspose.Slides 在渲染過程中將執行的替代。這有助於在安裝字型不同的環境中保持輸出一致。

如果字型可用但沒有專用的粗體字型，請參閱[處理沒有專用粗體字型的字型](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該章節說明如何在 PDF 匯出時光柵化受影響的文字，以及對文字選取、搜尋和縮放的影響。

## **取得字型替代**

使用[FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) 方法可確定在渲染簡報時會被替代的字型。此方法會傳回識別原始字型與替代字型名稱的[FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) 物件。

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

使用帶有 Java 整數陣列參數的 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) 多載，可僅檢視渲染特定投影片所需的替代。當您只渲染或匯出簡報的一部份、逐步檢查大型簡報、找出依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理其他投影片的情況下診斷渲染差異時，這會很有幫助。

`slides` 陣列使用以 1 為起點的投影片索引：`1` 表示第一張投影片。相較之下，[Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) 集合存取子使用零基索引，因此相同的投影片須以 `presentation.getSlides().get_Item(0)` 取得。建立陣列時請記住此差異，以免產生索引偏移錯誤。

透過 [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) 方法呼叫此多載。它僅傳回在渲染所選投影片時確定的替代。每個結果都是包含原始與替代字型名稱的[FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) 物件。此結果反映目前的字型環境、已設定的備援規則、儲存在[FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) 中的替代規則，以及[外部載入的字型](/slides/zh-hant/python-java/custom-font/)。

同一替代可能被多個所選投影片需求。建立字型清單或預檢報告時請去除重複。以下範例會報告每個傳回的替代，然後建立唯一字型對映的排序清單：

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

[FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) 類別提供兩種多載。請依渲染作業的範圍選擇其中一個：

| 多載 | 使用情境 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | 您需要整份簡報的字型替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | 您需要針對選取範圍、漸進檢查或部分匯出取得字型替代。 |

## **設定字型替代規則**

要指定在來源字型不可用時 Aspose.Slides 應使用的字型：

1. 載入簡報。
2. 為來源字型與替代字型建立字型定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/)。
5. 使用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) 方法指定此集合。
6. 渲染或轉換簡報。

以下 Python 範例在 `SomeRareFont` 不可用時，用 `Arial` 取代它，然後渲染第一張投影片以驗證結果。替代字型必須在 Aspose.Slides 可用。

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

{{% alert color="info" title="Note" %}}
如需無條件更改整份簡報使用的字型，請參閱[Font Replacement](/slides/zh-hant/python-java/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換過程中標準字型選擇程序的一部分。當 Aspose.Slides 能以規則指定的可用字型取代不可存取的字型時，它們適用於一般文字。

Office Math 方程式有額外需求。如果方程式使用 **Cambria Math**，Aspose.Slides 可能需要該確切字型來計算與渲染方程式版面。像 **STIX Two Math** 之類的替代數學字型規則無法取代 **Cambria Math**，渲染仍可能顯示需要 **Cambria Math**。

若要渲染或轉換此類簡報，請讓 **Cambria Math** 可供 Aspose.Slides 使用。將其安裝於作業系統或以[external font](/slides/zh-hant/python-java/custom-font/) 載入。

此限制僅適用於方程式版面。上述替代規則仍適用於一般簡報文字。

## **常見問題**

**字型取代與字型替代之間的差異是什麼？**

[Font replacement](/slides/zh-hant/python-java/font-replacement/) 會有意地將簡報中的一種字型變更為另一種。字型替代則在符合設定條件（例如原始字型不可用）時，為渲染輸出選擇字型。

**什麼時候會套用替代規則？**

這些規則在渲染與轉換過程中參與[font selection sequence](/slides/zh-hant/python-java/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時套用。

**當字型缺失且未設定替代規則時會發生什麼情況？**

Aspose.Slides 會依其字型選擇流程挑選最接近的可用字型。結果取決於執行環境中可用的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以[載入外部字型](/slides/zh-hant/python-java/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起分發字型？**

不會。您須自行提供字型並遵守其授權條款。

**字型替代結果在 Windows、Linux 與 macOS 之間會不同嗎？**

會。不同作業系統的已安裝字型與字型搜尋位置不同，導致某台機器上可用的字型在另一台上可能需要替代。

**如何在批次轉換中保持字型選擇的一致性？**

在每台機器或容器上使用相同的字型檔案與版本，[載入必要的外部字型](/slides/zh-hant/python-java/custom-font/)，並在授權允許時[嵌入字型](/slides/zh-hant/python-java/embedded-font/)。亦可在匯出前呼叫 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) 以偵測意外的替代。