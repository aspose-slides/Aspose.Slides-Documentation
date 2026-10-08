---
title: 使用 JavaScript 在簡報中設定字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在透過 Java 為 Node.js 的 Aspose.Slides 渲染或轉換 PowerPoint 與 OpenDocument 簡報時，設定字型替代規則並檢查已替代的字型。"
---
## **概覽**

字型替代允許 Aspose.Slides 在渲染或轉換簡報時，使用可用的字型來取代無法存取的字型。替代僅影響渲染結果；不會更改簡報內容所指定的字型。

您可以在特定字型不可用時定義要使用的字型，並檢視 Aspose.Slides 在渲染時將執行的替代。這有助於在安裝字型不同的環境中保持輸出一致。

如果字型可用但沒有專用的粗體字型，請參閱 [處理沒有專用粗體字型的字型](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該章節說明在 PDF 匯出期間如何光柵化受影響的文字，以及對文字選取、搜尋和縮放的影響。

## **取得字型替代**

使用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 方法來判斷簡報渲染時會替代哪些字型。此方法會回傳 [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) 物件，辨識原始與替代的字型名稱。

以下 JavaScript 範例列出簡報的所有字型替代：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **取得特定投影片的字型替代**

使用帶有投影片索引陣列的 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 覆載來僅檢查特定投影片所需的替代。這在您只渲染或匯出簡報的一部分、逐步檢查大型簡報、定位依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理無關投影片的情況下診斷渲染差異時非常有用。

此覆載接受 Java 基本型別 `int[]`。可使用 `java.newArray("int", [...])` 建立；普通的 JavaScript 陣列會轉換為 `Integer[]`，因此不符合此覆載。

陣列使用一基索引：`1` 代表第一張投影片。相較之下，[Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) 集合存取子索引為零基，因此相同的投影片須以 `presentation.getSlides().get_Item(0)` 取得。建立陣列時請記得此差異，以免產生「少一」錯誤。

透過 [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) 呼叫此覆載。它僅回傳在渲染所選投影片時決定的替代。每筆結果都是 [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) 物件，包含原始與替代的字型名稱。結果會反映當前的字型環境、已設定的備援規則、存於 [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) 的替代規則，以及 [外部載入的字型](/slides/zh-hant/nodejs-java/custom-font/)。

同一替代可能同時被多張選取的投影片需求。建立字型清單或前檢報告時請除重。以下範例會列出每筆回傳的替代，然後產生唯一字型對映的排序清單：

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) 類別提供兩種覆載。依據渲染操作的範圍選擇使用：

| Overload | 使用時機 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)（不帶參數） | 需要整個簡報的替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)（帶 Java `int[]` 投影片索引） | 需要特定範圍、增量檢查或部分匯出的替代。 |

## **設定字型替代規則**

若來源字型不可用，指定 Aspose.Slides 應使用的字型：

1. 載入簡報。  
2. 為來源字型與替代字型建立字型定義。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) 條件建立一個 [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/)。  
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)。  
5. 透過 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 方法指派該集合。  
6. 渲染或轉換簡報。

以下 JavaScript 範例在 `SomeRareFont` 無法使用時，以 `Arial` 替代，並渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
欲無條件變更簡報中全部使用的字型，請參閱 [字型取代](/slides/zh-hant/nodejs-java/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換期間標準字型選取流程的一部份。它們適用於普通文字，當 Aspose.Slides 能以規則指定的可用字型取代無法存取的字型時即可生效。

Office Math 方程式有額外需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該確切字型來計算與渲染方程式版面。使用其他數學字型（例如 **STIX Two Math**）的替代規則無法取代 **Cambria Math**，渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可將其安裝於作業系統，或以 [外部字型](/slides/zh-hant/nodejs-java/custom-font/) 方式載入。

此限制僅適用於方程式版面。上述的替代規則仍適用於簡報的普通文字。

## **常見問題**

**字型取代與字型替代有何不同？**

[Font replacement](/slides/zh-hant/nodejs-java/font-replacement/) 會在整個簡報中將一種字型刻意改為另一種。字型替代則在滿足設定條件（例如原始字型不可用）時，為渲染輸出選擇替代字型。

**什麼時候會套用替代規則？**

規則參與渲染與轉換期間的 [font selection sequence](/slides/zh-hant/nodejs-java/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時使用。

**當缺少字型且未設定替代規則時會發生什麼？**

Aspose.Slides 會根據其字型選取流程，選擇最接近的可用字型。結果取決於執行環境中可取得的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以 [load external fonts](/slides/zh-hant/nodejs-java/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起分發字型？**

不會。您須自行提供字型並遵守其授權條款。

**替代結果會在 Windows、Linux 與 macOS 之間不同嗎？**

會。不同作業系統的已安裝字型與搜尋路徑不同，於某台機器可用的字型在另一台可能需要替代。

**如何在批次轉換時保持字型選取一致？**

在每台機器或容器上使用相同的字型檔案與版本，[載入必要的外部字型](/slides/zh-hant/nodejs-java/custom-font/)，並在授權允許時 [embed fonts](/slides/zh-hant/nodejs-java/embedded-font/)。您也可以在匯出前呼叫 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 以偵測意外的替代。