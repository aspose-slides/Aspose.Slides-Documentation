---
title: 使用 Java 配置簡報中的字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/java/font-substitution/
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
- Java
- Aspose.Slides
description: "在使用 Aspose.Slides for Java 渲染或轉換 PowerPoint 與 OpenDocument 簡報時，配置字型替代規則並檢查被替代的字型。"
---
## **概述**

字型替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可取得的字型來取代無法存取的字型。此替代僅影響渲染結果，並不會更改簡報內容中所指派的字型。

您可以在特定字型不可用時定義要使用的字型，並檢查 Aspose.Slides 在渲染過程中所做的字型替代。這有助於在安裝字型不同的環境中保持輸出一致性。

## **取得字型替代**

使用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 方法，以確定簡報渲染時將被替代的字型。此方法會回傳 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstitutioninfo/) 物件，指出原始字型與替代字型的名稱。

以下 Java 範例列出簡報的所有字型替代：

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

## **取得選取投影片的字型替代**

使用帶有 `int[] slides` 參數的 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 重載，可以只檢視特定投影片所需的替代。這在您只渲染或匯出簡報的一部分、逐步檢查大型簡報、尋找依賴未提供字型的投影片、為伺服器或容器準備最小字型套件，或在不處理無關投影片的情況下診斷渲染差異時非常有用。

`slides` 陣列使用以 1 為基礎的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlides--) 集合存取子使用 0 為基礎的索引，因此同一張投影片必須寫成 `presentation.getSlides().get_Item(0)`。在建立陣列時請留意此差異，以免產生一位錯位錯誤。

透過 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getFontsManager--) 方法呼叫此重載。它只會回傳在渲染所選投影片時決定的替代。每筆結果皆為 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstitutioninfo/) 物件，包含原始與替代字型名稱。結果會反映當前的字型環境、已設定的回退規則，以及 [外部載入的字型](/slides/zh-hant/java/custom-font/)。儲存在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsubstrulecollection/) 中的替代規則會在渲染簡報時套用，但結果不會列出這些規則；請改為檢查輸出檔案中的字型。

同一個替代可能同時被多張選取的投影片需要。建立字型清單或預檢報告時請去除重複。以下範例會列出所有回傳的替代，然後產生唯一字型對映的排序清單：

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

[IFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/) 介面同時提供兩個重載。請依渲染作業的範圍選擇適當的使用方式：

| 重載 | 使用情況 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)（無參數） | 您需要整份簡報的字型替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)（帶 `int[] slides`） | 您需要針對選取的範圍、增量檢查或部分匯出取得字型替代。 |

## **設定字型替代規則**

若要指定當來源字型無法取得時 Aspose.Slides 應使用的字型：

1. 載入簡報。
2. 為來源字型與替代字型建立字型定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstrule/)。
4. 將規則新增至 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstrulecollection/)。
5. 透過 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法指派該集合。
6. 渲染或轉換簡報。

以下 Java 範例在 `SomeRareFont` 無法取得時，使用 `Arial` 取代 `SomeRareFont`，並渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

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
若要無條件變更整份簡報所使用的字型，請參閱 [Font Replacement](/slides/zh-hant/java/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換期間標準字型選取流程的一部份，適用於一般文字，當 Aspose.Slides 能以規則指定的可用字型取代無法存取的字型時即可生效。

Office Math 方程式則有額外需求。如果方程式使用 **Cambria Math**，Aspose.Slides 可能必須正確取得該字型才能計算與渲染方程式版面。使用 **STIX Two Math** 等其他數學字型的替代規則無法取代 **Cambria Math**，渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 對 Aspose.Slides 可用。可於作業系統安裝或以 [外部字型](/slides/zh-hant/java/custom-font/) 載入。

此限制僅影響方程式版面。前述的替代規則仍適用於簡報的普通文字。

## **常見問題**

**字型取代與字型替代有何差異？**  
[Font replacement](/slides/zh-hant/java/font-replacement/) 會在整份簡報中主動將一種字型改為另一種字型。字型替代則在渲染輸出時，當符合設定條件（例如原始字型不可用）時選擇替代字型。

**何時會套用替代規則？**  
規則會在渲染與轉換期間參與 [字型選取序列](/slides/zh-hant/java/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時被採用。

**若缺少字型且未設定替代規則，會發生什麼情況？**  
Aspose.Slides 會依其字型選取程序選取最接近的可用字型，結果取決於執行環境中可用的字型。

**我可以載入外部字型以避免替代嗎？**  
可以。您可以 [載入外部字型](/slides/zh-hant/java/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起分發字型？**  
不會。字型的提供與授權遵循您自己的責任與許可。

**替代結果在 Windows、Linux、macOS 之間會不同嗎？**  
會。不同作業系統的已安裝字型與搜尋位置不同，某台機器可用的字型在另一台可能需要替代。

**如何在批次轉換中保持字型選取一致性？**  
在每台機器或容器上使用相同的字型檔案與版本、[載入所需的外部字型](/slides/zh-hant/java/custom-font/)，以及在授權允許的情況下 [內嵌字型](/slides/zh-hant/java/embedded-font/)。您亦可在匯出前呼叫 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以偵測意外的替代。