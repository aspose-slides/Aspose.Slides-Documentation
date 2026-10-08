---
title: 在 Android 上於簡報中配置字體置換
linktitle: 字體置換
type: docs
weight: 70
url: /zh-hant/androidjava/font-substitution/
keywords:
- 字體
- 替代字體
- 字體置換
- 替換字體
- 字體取代
- 置換規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在使用 Java 渲染或轉換簡報時，於 Aspose.Slides for Android 配置字體置換規則並檢查已置換的字體。"
---
## **概觀**

字體置換允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字體取代無法存取的字體。置換僅影響已渲染的輸出；它不會更改簡報內容所指派的字體。

您可以定義在特定字體不可用時使用的字體，並可檢查 Aspose.Slides 在渲染過程中將執行的置換。這有助於在 Android 裝置與不同可用字體的環境中保持輸出的一致性。

如果字體可用但沒有專用的粗體字型，請參閱[處理沒有專用粗體字型的字體](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該部分說明如何在 PDF 匯出期間光柵化受影響的文字，以及對文字選取、搜尋和縮放的影響。

## **取得字體置換**

使用[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--)方法來判斷簡報渲染時將被置換的字體。此方法會傳回[FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/)物件，用以識別原始字體與置換後的字體名稱。

以下 Java 範例列出簡報的所有字體置換：

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

## **取得選取投影片的字體置換**

使用[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)的重載，並傳入 `int[] slides` 參數，以僅檢查渲染特定投影片所需的置換。當您渲染或匯出簡報的部分內容、逐步檢查大型簡報、定位依賴不可用字體的投影片、為 Android 應用程式準備最小字體套件，或在不處理無關投影片的情況下診斷渲染差異時，這非常有用。

`slides` 陣列包含以 1 為基礎的投影片索引：`1` 代表第一張投影片。相比之下，[Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) 集合存取子使用零基索引，因此同一張投影片可透過 `presentation.getSlides().get_Item(0)` 取得。建立陣列時請留意此差異，以免產生一位錯誤。

透過[Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) 方法呼叫此重載。它僅回傳在渲染選取投影片時決定的置換。每個結果都是一個[FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) 物件，包含原始字體與置換字體名稱。結果會反映目前的字體環境、已設定的備援規則、存於[IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) 的置換規則，以及[外部載入的字體](/slides/zh-hant/androidjava/custom-font/)。

同一個置換可能由多個選取的投影片需求。建立字體清單或預檢報告時，請去除重複的結果。以下範例會報告每個回傳的置換，然後建立唯一字體對映的排序清單：

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

[IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) 介面提供兩個重載。請根據渲染作業的範圍選擇使用：

| 重載 | 使用時機 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 無參數 | 需要整份簡報的字體置換。 |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 搭配 `int[] slides` | 需要針對選取範圍、逐步檢查或部分匯出的字體置換。 |

## **設定字體置換規則**

指定當來源字體不可用時 Aspose.Slides 應使用的字體：

1. 載入簡報。
2. 建立來源字體與置換字體的字體定義。
3. 使用[WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/)條件建立一個[FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/)。
4. 將規則加入[FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/)。
5. 使用[FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法指派該集合。
6. 渲染或轉換簡報。

以下 Java 範例在 `SomeRareFont` 不可用時，用 `Arial` 取代 `SomeRareFont`，然後渲染第一張投影片以驗證結果。置換字體必須對 Aspose.Slides 可用。

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
若要無條件變更整個簡報中使用的字體，請參閱[字體取代](/slides/zh-hant/androidjava/font-replacement/)。
{{% /alert %}}

## **數學方程式字體的限制**

字體置換規則是渲染與轉換過程中標準字體選擇流程的一部分。當 Aspose.Slides 能以規則指定的可用字體取代無法存取的字體時，這些規則對一般文字有效。

Office Math 方程式有額外需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該特定字體來計算與渲染方程式版面。將其他數學字體（例如 **STIX Two Math**）作為置換的規則無法取代 **Cambria Math**，因此渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。將其作為[外部字體](/slides/zh-hant/androidjava/custom-font/)載入，讓應用程式在渲染與轉換時能使用它。

此限制僅適用於方程式版面。上述的置換規則仍適用於簡報的普通文字。

## **常見問題**

**字體取代與字體置換有何差異？**

[字體取代](/slides/zh-hant/androidjava/font-replacement/) 會有意地將簡報中所有的某個字體改為另一個字體。字體置換則是在符合設定條件（例如原始字體不可用）時，為已渲染的輸出選擇一個字體。

**什麼時候會套用置換規則？**

這些規則會在渲染與轉換過程中參與[字體選擇序列](/slides/zh-hant/androidjava/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字體時套用。

**當字體缺失且未設定置換規則時會發生什麼？**

Aspose.Slides 會根據其字體選擇流程選取最接近的可用字體。結果取決於執行環境中可取得的字體。

**我可以載入外部字體以避免置換嗎？**

可以。您可以[載入外部字體](/slides/zh-hant/androidjava/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起發佈字體？**

不會。您需自行提供字體並遵守其授權條款。

**置換結果會在不同 Android 裝置間不一致嗎？**

會。不同 Android 版號、裝置與供應商的系統字體可能不同，於某環境可用的字體在另一環境可能需要置換。

**如何在 Android 裝置間保持字體選擇的一致性？**

將相同的必要字體檔案隨應用程式一起打包、[載入為外部字體](/slides/zh-hant/androidjava/custom-font/)，並在授權允許時[嵌入字體](/slides/zh-hant/androidjava/embedded-font/)。您亦可在匯出前呼叫[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以偵測意外的置換情形。