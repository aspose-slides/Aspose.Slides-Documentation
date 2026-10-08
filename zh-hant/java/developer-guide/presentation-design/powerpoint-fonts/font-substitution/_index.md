---
title: 使用 Java 在簡報中設定字體替代
linktitle: 字體替代
type: docs
weight: 70
url: /zh-hant/java/font-substitution/
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
- Java
- Aspose.Slides
description: "在渲染或轉換 PowerPoint 與 OpenDocument 簡報時，於 Aspose.Slides for Java 中設定字體替代規則並檢查已替代的字體。"
---
## **概述**

字體替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字體來取代無法存取的字體。替代會影響已渲染的輸出；但不會更改簡報內容所指定的字體。

您可以定義當特定字體不可用時使用的字體，並且可以檢視 Aspose.Slides 在渲染過程中將進行的替代。這有助於在安裝字體不同的環境中保持輸出的一致性。

如果字體可用但沒有專用的粗體字形，請參閱[處理沒有專用粗體字體的字體](/slides/zh-hant/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該部分說明了在 PDF 匯出期間如何光柵化受影響的文字以及對文字選取、搜尋和縮放的影響。

## **取得字體替代**

使用[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 方法來判斷簡報渲染時會替代哪些字體。該方法回傳[FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) 物件，指出原始字體與替代字體名稱。

以下 Java 範例列出所有簡報的字體替代：

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **取得已選取投影片的字體替代**

使用帶有 `int[] slides` 參數的[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 重載，以僅檢視渲染特定投影片所需的替代。這在以下情況很有用：渲染或匯出簡報的部分內容、逐步檢查大型簡報、找出依賴不可用字體的投影片、為伺服器或容器準備最小字體套件，或在不處理不相關投影片的情況下診斷渲染差異。

`slides` 陣列使用以 1 為起點的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 集合存取子使用零基索引，因此相同的投影片須以 `presentation.getSlides().get_Item(0)` 來存取。建立陣列時請記住此差異，以免產生遺漏或多算一的錯誤。

透過[Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) 方法呼叫此重載。它僅回傳在渲染已選取投影片時決定的替代。每個結果都是包含原始與替代字體名稱的[FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) 物件。結果反映目前的字體環境、已設定的備援規則，以及[外部載入的字體](/slides/zh-hant/java/custom-font/)。存放於[IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) 的替代規則會在簡報渲染時套用，但結果不會列出它們；請改為檢查輸出檔案中的字體。

相同的替代可能會被多個已選取的投影片需求。建立字體清單或預檢報告時請去除重複結果。以下範例會列出每個回傳的替代，然後建立唯一字體對映的排序清單：

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

[IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) 介面提供兩種重載。請依據渲染操作的範圍選擇使用：

| 重載 | 使用情境 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)（無參數） | 您需要整個簡報的字體替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)（帶 `int[] slides`） | 您需要針對選取範圍、增量檢查或部分匯出的字體替代。 |

## **設定字體替代規則**

若要指定當來源字體不可用時 Aspose.Slides 應使用的字體：

1. 載入簡報。
2. 為來源字體與替代字體建立字體定義。
3. 建立帶有[WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) 條件的[FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/)。
4. 將此規則加入[FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/)。
5. 使用[FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法指派該集合。
6. 渲染或轉換簡報。

以下 Java 範例在 `SomeRareFont` 不可用時將 `Arial` 替代為 `SomeRareFont`，然後渲染第一張投影片以驗證結果。替代字體必須對 Aspose.Slides 可用。

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
若要無條件變更整個簡報中使用的字體，請參閱[字體取代](/slides/zh-hant/java/font-replacement/)。
{{% /alert %}}

## **數學方程式字體的限制**

字體替代規則是渲染與轉換過程中使用的標準字體選擇程序的一部分。當 Aspose.Slides 能以規則指定的可用字體替代無法存取的字體時，該規則對一般文字有效。

Office Math 方程式有額外的需求。如果方程式使用 **Cambria Math**，Aspose.Slides 可能需要該精確字體才能計算與渲染方程式版面。將其他數學字體（例如 **STIX Two Math**）作為替代的規則無法取代 **Cambria Math**，渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以[外部字體](/slides/zh-hant/java/custom-font/) 載入。

此限制適用於方程式版面。上述的替代規則仍適用於一般簡報文字。

## **常見問題**

**字體取代與字體替代有何差異？**

[字體取代](/slides/zh-hant/java/font-replacement/) 會有意在整個簡報中將一種字體變更為另一種字體。字體替代則在符合設定條件時（例如原始字體不可用）為已渲染的輸出選擇字體。

**什麼時候會套用替代規則？**

這些規則在渲染與轉換期間參與[字體選擇序列](/slides/zh-hant/java/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字體時使用。

**如果字體缺失且未配置替代規則，會發生什麼情況？**

Aspose.Slides 會依其字體選擇流程選取最接近的可用字體。結果取決於執行環境中可用的字體。

**我可以載入外部字體以避免替代嗎？**

可以。您可以[載入外部字體](/slides/zh-hant/java/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 會隨程式庫一起分發字體嗎？**

不會。字體須由使用者自行提供，且需遵守其授權條款。

**替代結果會在 Windows、Linux 與 macOS 之間有所不同嗎？**

會。不同作業系統的已安裝字體與字體搜尋位置不同，因此在某台機器上可用的字體，可能在其他機器上需進行替代。

**如何在批次轉換中保持字體選擇的一致性？**

在每台機器或容器上使用相同的字體檔案與版本，[載入必要的外部字體](/slides/zh-hant/java/custom-font/)，並在授權允許時[嵌入字體](/slides/zh-hant/java/embedded-font/)。亦可在匯出前呼叫[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以偵測意外的替代情況。