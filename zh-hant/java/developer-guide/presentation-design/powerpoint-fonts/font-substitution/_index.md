---
title: 使用 Java 配置投影片中的字型替代
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
- 投影片
- Java
- Aspose.Slides
description: "在渲染或轉換 PowerPoint 與 OpenDocument 投影片時，於 Aspose.Slides for Java 中設定字型替代規則並檢查被替代的字型。"
---
## **概述**

字型替代允許 Aspose.Slides 在呈現或轉換投影片時，使用可用的字型來取代無法存取的字型。此替代會影響渲染後的輸出；不會更改投影片內容所指派的字型。

您可以在特定字型不可用時定義要使用的字型，並且可以檢視 Aspose.Slides 在渲染過程中將會進行的替代。這有助於在安裝字型不同的環境中保持輸出的一致性。

## **取得字型替代**

使用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 方法來判斷在渲染投影片時會替代哪些字型。該方法會回傳 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstitutioninfo/) 物件，說明原始字型與替代字型的名稱。

以下 Java 範例會列出投影片的所有字型替代：

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

使用帶有 `int[] slides` 參數的 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) 之多載，僅檢查特定投影片所需的替代。這在您僅渲染或匯出投影片的一部分、逐步檢查大型投影片、找出依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理無關投影片的情況下診斷渲染差異時非常有用。

`slides` 陣列採用一位基底的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlides--) 集合存取子使用零基底索引，因此同一張投影片須寫成 `presentation.getSlides().get_Item(0)`。建立陣列時請留意此差異，以免產生錯誤的索引。

透過 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getFontsManager--) 方法呼叫此多載。它僅回傳在渲染所選投影片時確定的替代。每個結果都是包含原始與替代字型名稱的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstitutioninfo/) 物件。結果會反映目前的字型環境、已設定的備援規則、儲存在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsubstrulecollection/) 中的替代規則，以及 [外部載入的字型](/slides/zh-hant/java/custom-font/)。

相同的替代可能被多個選取投影片所需要。在建立字型清單或前置檢查報告時，請去除重複項目。以下範例會報告每個回傳的替代，然後產生唯一字型映射的排序清單：

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

[IFontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/) 介面同時提供兩種多載，請依渲染作業的範圍選擇使用：

| 重載 | 使用時機 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)（無參數） | 需要取得整份投影片的字型替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)（`int[] slides`） | 需取得選取範圍、增量檢查或部分匯出的字型替代。 |

## **設定字型替代規則**

若要指定 Aspose.Slides 在來源字型不可用時應使用的字型：

1. 載入投影片檔案。  
2. 為來源字型與替代字型建立字型定義。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstcondition/) 條件建立一個 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstrule/)。  
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstrulecollection/)。  
5. 透過 [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 方法指派該集合。  
6. 渲染或轉換投影片。

以下 Java 範例在 `SomeRareFont` 不可用時以 `Arial` 替代，並渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

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
若要無條件變更整份投影片所使用的字型，請參閱 [字型取代](/slides/zh-hant/java/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換過程中標準字型選擇程序的一部分。它們適用於一般文字，當 Aspose.Slides 能以規則指定的可用字型取代無法存取的字型時即可運作。

Office Math 方程式則有額外需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該精確字型才能計算與渲染方程式版面。將 **Cambria Math** 替代為其他數學字型（例如 **STIX Two Math**）的規則無法取代 **Cambria Math**，渲染仍可能顯示需要 **Cambria Math**。

若要渲染或轉換此類投影片，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝或作為 [外部字型](/slides/zh-hant/java/custom-font/) 載入。

此限制僅針對方程式版面。上述替代規則仍適用於一般投影片文字。

## **常見問題**

**字型取代與字型替代有何不同？**  
[字型取代](/slides/zh-hant/java/font-replacement/) 會刻意將整份投影片的某個字型改為另一個字型。字型替代則在渲染輸出時，根據條件（例如原始字型不可用）選擇可用字型。

**替代規則何時套用？**  
規則參與渲染與轉換期間的 [字型選擇序列](/slides/zh-hant/java/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時才會被使用。

**若缺少字型且未設定替代規則會發生什麼？**  
Aspose.Slides 會依照其字型選擇程序挑選最接近的可用字型。結果取決於執行環境中可用的字型。

**我可以載入外部字型以避免替代嗎？**  
可以。您可以 [載入外部字型](/slides/zh-hant/java/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫分發字型？**  
不會。字型的提供與授權須由您自行負責。

**替代結果會在 Windows、Linux 與 macOS 之間不同嗎？**  
會。不同作業系統的已安裝字型與搜尋位置各異，某台機器可用的字型在另一台機器上可能需要替代。

**如何在大量批次轉換時保持字型選擇一致？**  
在每台機器或容器上使用相同的字型檔案與版本，[載入必要的外部字型](/slides/zh-hant/java/custom-font/)，並在授權允許時 [嵌入字型](/slides/zh-hant/java/embedded-font/)。也可以在匯出前呼叫 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 以偵測意外的替代情況。