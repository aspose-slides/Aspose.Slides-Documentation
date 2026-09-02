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
- 更換字型
- 字型取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在渲染或轉換 PowerPoint 與 OpenDocument 簡報時，透過 Java 為 Node.js 的 Aspose.Slides 設定字型替代規則並檢查替代後的字型。"
---
## **概觀**

字型替代允許 Aspose.Slides 在渲染或轉換簡報時，使用可用的字型取代無法存取的字型。替代會影響渲染的輸出；但不會更改簡報內容所指派的字型。

您可以在特定字型不可用時定義要使用的字型，並且可以檢查 Aspose.Slides 在渲染過程中將執行的字型替代。這有助於在安裝字型不同的環境之間保持輸出一致性。

## **取得字型替代**

使用 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 方法可判斷在渲染簡報時哪些字型會被替代。該方法會回傳 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsubstitutioninfo/) 物件，指出原始字型名稱與替代字型名稱。

以下 JavaScript 範例會列出簡報的所有字型替代：

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

## **取得所選投影片的字型替代**

使用帶有投影片索引陣列的 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 疊載方法，只檢查渲染特定投影片所需的替代。這在您要渲染或匯出簡報的部分內容、逐步檢查大型簡報、找出依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理無關投影片的情況下診斷渲染差異時，都非常有用。

此疊載方法需要 Java 原始型別 `int[]`。可使用 `java.newArray("int", [...])` 建立；普通的 JavaScript 陣列會被轉換為 `Integer[]`，無法符合此疊載方法。

陣列使用以 1 為起點的投影片索引：`1` 代表第一張投影片。相比之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslides/) 集合存取子使用零基索引，因此同一張投影片需以 `presentation.getSlides().get_Item(0)` 取得。在建立陣列時請注意此差異，以免產生遺漏或多算一的錯誤。

透過 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getfontsmanager/) 呼叫此疊載方法。它只回傳在渲染所選投影片時決定的替代。每個結果皆為包含原始與替代字型名稱的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsubstitutioninfo/) 物件。結果會反映當前的字型環境、已設定的備援規則、儲存在 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsubstrulecollection/) 中的替代規則，以及 [externally loaded fonts](/slides/zh-hant/nodejs-java/custom-font/)。

同一個替代可能被多個所選投影片要求。建立字型清單或預檢報告時，請去除重複結果。以下範例會列出所有回傳的替代，並產生唯一字型對應的排序清單：

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

[FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/) 類別提供兩種疊載方法。請依照渲染作業的範圍選擇使用：

| 疊載方法 | 使用情況 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | 您需要整份簡報的字型替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | 您需要針對選取範圍、逐步檢查或部分匯出時的字型替代。 |

## **設定字型替代規則**

若來源字型無法使用，指定 Aspose.Slides 應使用的字型：

1. 載入簡報。
2. 為來源字型與替代字型建立字型定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsubstrulecollection/)。
5. 使用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 方法指派此集合。
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

{{% alert color="info" title="注意" %}}
若要無條件變更整個簡報所使用的字型，請參閱 [Font Replacement](/slides/zh-hant/nodejs-java/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換過程中標準字型選擇程序的一部份。當 Aspose.Slides 能以規則指定的可用字型取代無法存取的字型時，這些規則適用於一般文字。

Office Math 方程式有額外的需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該確切字型才能計算並渲染方程式版面。使用如 **STIX Two Math** 的其他數學字型之替代規則無法取代 **Cambria Math**，渲染仍可能顯示需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以 [external font](/slides/zh-hant/nodejs-java/custom-font/) 方式載入。

此限制僅適用於方程式版面配置。上述的替代規則仍適用於簡報中的一般文字。

## **常見問題**

**字型取代與字型替代有何不同？**

[Font replacement] 故意在整份簡報中將一種字型改為另一種字型。字型替代則在符合設定條件（例如原始字型不可用）時，為渲染輸出選取字型。

**什麼時候會套用字型替代規則？**

這些規則會在渲染與轉換期間參與 [font selection sequence]。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時套用。

**如果缺少字型且未設定替代規則，會發生什麼情況？**

Aspose.Slides 會根據其字型選擇程序挑選最接近的可用字型。結果取決於執行環境中可使用的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以 [load external fonts](/slides/zh-hant/nodejs-java/custom-font/) ，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 會隨函式庫一起分發字型嗎？**

不會。您必須自行提供字型並遵守其授權條款。

**替代結果在 Windows、Linux 與 macOS 之間會不同嗎？**

會。不同作業系統的已安裝字型與字型搜尋位置各有差異，於某台機器可用的字型在另一台可能需要替代。

**如何在批次轉換中保持字型選擇的一致性？**

在每台機器或容器上使用相同的字型檔與版本，[load required external fonts](/slides/zh-hant/nodejs-java/custom-font/)，以及在授權允許時 [embed fonts](/slides/zh-hant/nodejs-java/embedded-font/)。亦可在匯出前呼叫 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 以偵測意外的替代情況。