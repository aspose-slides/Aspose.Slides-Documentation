---
title: 在 Android 上設定簡報的字形替代
linktitle: 字形替代
type: docs
weight: 70
url: /zh-hant/androidjava/font-substitution/
keywords:
- 字形
- 替代字形
- 字形替代
- 取代字形
- 字形取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 透過 Java 渲染或轉換簡報時，設定字形替代規則並檢查被替代的字形。"
---
## **概述**

字形替代允許 Aspose.Slides 在渲染或轉換簡報時，使用可用的字形來取代無法存取的字形。此替代會影響渲染後的輸出；但不會更改簡報內容中所指派的字形。

您可以在特定字形不可用時定義要使用的字形，並檢查 Aspose.Slides 在渲染期間將執行的替代。這有助於在 Android 設備及字形可用性不同的環境之間保持輸出一致。

## **取得字形替代**

使用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 方法來判斷在渲染簡報時會被替代的字形。此方法返回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsubstitutioninfo/) 物件，該物件指出原始字形與替代字形的名稱。

下面的 Java 範例列出簡報的所有字形替代：

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

## **取得選取投影片的字形替代**

使用帶有 `int[] slides` 參數的 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 重載，以僅檢查渲染特定投影片所需的替代。當您要渲染或匯出簡報的一部分、逐步檢查大型簡報、找出依賴不可用字形的投影片、為 Android 應用程式準備最小字形套件，或在不處理無關投影片的情況下診斷渲染差異時，這非常有用。

`slides` 陣列使用以 1 為起始的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--) 集合存取子使用零基索引，因此相同的投影片應以 `presentation.getSlides().get_Item(0)` 取得。建立陣列時請留意此差異，以免產生遺漏或多算一的錯誤。

透過 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getFontsManager--) 方法呼叫此重載。它僅返回在渲染選取投影片時確定的替代。每個結果都是一個 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsubstitutioninfo/) 物件，包含原始與替代字形的名稱。此結果反映目前的字形環境、已設定的備援規則、儲存在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsubstrulecollection/) 中的替代規則，以及 [外部載入的字形](/slides/zh-hant/androidjava/custom-font/)。

同一個替代可能被多張選取的投影片所需要。建立字形清單或預檢報告時請去除重複結果。下面的範例會列出每個返回的替代，並產生唯一字形對映的排序清單：

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

介面 [IFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/) 提供兩個重載。請依照渲染操作的範圍選擇使用哪一個：

| Overload | 使用時機 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | 您需要整份簡報的字形替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | 您需要選取範圍、增量檢查或部分匯出的字形替代。 |

## **設定字形替代規則**

若要在來源字形不可用時，指定 Aspose.Slides 應使用的字形：

1. 載入簡報。
2. 為來源字形與替代字形建立字形定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsubstrulecollection/)。
5. 使用 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法指派該集合。
6. 渲染或轉換簡報。

下面的 Java 範例在 `SomeRareFont` 不可用時，用 `Arial` 取代 `SomeRareFont`，然後渲染第一張投影片以驗證結果。替代字形必須在 Aspose.Slides 可用。

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
若要無條件變更整份簡報所使用的字形，請參閱 [字形取代](/slides/zh-hant/androidjava/font-replacement/)。
{{% /alert %}}

## **數學方程式字形的限制**

字形替代規則是渲染與轉換期間使用的標準字形選取程序的一部分。當 Aspose.Slides 能以規則指定的可用字形替代不可存取的字形時，這些規則可適用於一般文字。

Office Math 方程式有額外需求。如果方程式使用 **Cambria Math**，Aspose.Slides 可能需要該精確字形來計算與渲染方程式版面。使用如 **STIX Two Math** 等其他數學字形的替代規則無法取代 **Cambria Math**，因此渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請讓 **Cambria Math** 可供 Aspose.Slides 使用。將其作為 [外部字形](/slides/zh-hant/androidjava/custom-font/) 載入，使應用程式在渲染與轉換期間能使用它。

此限制僅適用於方程式版面。上述的替代規則仍適用於簡報的普通文字。

## **常見問題**

**字形取代與字形替代有何差異？**

[字形取代](/slides/zh-hant/androidjava/font-replacement/) 會有意地在整份簡報中將一種字形改為另一種字形。字形替代則是在符合設定條件（例如原始字形不可用）時，為渲染輸出選取字形。

**何時套用替代規則？**

這些規則在渲染與轉換期間參與 [字形選取序列](/slides/zh-hant/androidjava/font-selection-sequence/)。使用 `WhenInaccessible` 時，僅當 Aspose.Slides 無法存取來源字形才會使用規則。

**當字形遺失且未設定替代規則時會發生什麼？**

Aspose.Slides 會依其字形選取流程選擇最接近的可用字形。結果取決於執行環境中可取得的字形。

**我可以載入外部字形以避免替代嗎？**

可以。您可以 [載入外部字形](/slides/zh-hant/androidjava/custom-font/)，讓 Aspose.Slides 在渲染與轉換期間使用它們。

**Aspose 會隨函式庫分發字形嗎？**

不會。您需自行提供字形並遵守其授權條款。

**不同 Android 設備的替代結果會不一樣嗎？**

會。不同 Android 版本、設備與供應商的系統字形可能不同，某環境可用的字形在另一環境可能需要替代。

**如何確保在 Android 設備之間的字形選取一致？**

將相同的必需字形檔案打包於應用程式中，[載入為外部字形](/slides/zh-hant/androidjava/custom-font/)，且在授權允許時 [嵌入字形](/slides/zh-hant/androidjava/embedded-font/)。亦可在匯出前呼叫 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以識別意外的替代。