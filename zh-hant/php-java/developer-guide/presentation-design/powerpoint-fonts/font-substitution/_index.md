---
title: 使用 PHP 在簡報中設定字體替代
linktitle: 字體替代
type: docs
weight: 70
url: /zh-hant/php-java/font-substitution/
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
- PHP
- Aspose.Slides
description: "在渲染或轉換 PowerPoint 與 OpenDocument 簡報時，於 Aspose.Slides for PHP (透過 Java) 設定字體替代規則並檢查被替代的字體。"
---
## **概觀**

字體替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字體來取代無法存取的字體。替代會影響渲染的輸出；但不會更改簡報內容所指定的字體。

您可以在特定字體不可用時定義要使用的字體，並且可以檢查 Aspose.Slides 在渲染過程中將執行的替代。這有助於在安裝字體不同的環境間保持輸出一致。

如果字體可用但沒有專用粗體字型，請參閱 [處理沒有專用粗體字型的字體](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該章節說明在 PDF 匯出期間如何將受影響的文字光柵化，以及對文字選取、搜尋和縮放的影響。

## **取得字體替代**

使用 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) 方法來確定在簡報渲染時會被替代的字體。此方法會回傳 [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) 物件，指出原始字體與替代字體的名稱。

以下 PHP 範例會列出簡報的所有字體替代：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **取得所選投影片的字體替代**

使用帶有 `int[] slides` 參數的 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) 重載，以僅檢查渲染特定投影片所需的替代。這在您要渲染或匯出簡報的一部分、逐步檢查大型簡報、定位依賴不存在字體的投影片、為伺服器或容器準備最小字體套件，或在不處理無關投影片的情況下診斷渲染差異時，非常有用。

`slides` 陣列使用以 1 為起點的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) 集合存取器使用零基索引，因此同一張投影片的存取方式為 `$presentation->getSlides()->get_Item(0)`。在建立陣列時請記住此差異，以避免因索引錯位而產生錯誤。

透過 [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) 方法呼叫此重載。它僅回傳在渲染所選投影片時決定的替代。每個結果都是包含原始與替代字體名稱的 [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) 物件。此結果反映了目前的字體環境、已配置的回退規則、儲存在 [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) 中的替代規則，以及 [externally loaded fonts](/slides/zh-hant/php-java/custom-font/)。

同一個替代可能被多張所選投影片需要。建立字體清單或預檢報告時，請對結果去除重複。以下範例會列出每個返回的替代，然後建立唯一字體對應的排序清單：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) 類別提供兩種重載。請依照渲染操作的範圍選擇使用哪一個：

| 重載 | 何時使用 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | 您需要整個簡報的字體替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | 您需要在選定範圍、逐步檢查或部分匯出時的字體替代。 |

## **設定字體替代規則**

若來源字體不可用，指定 Aspose.Slides 應使用的字體：

1. 載入簡報。
2. 為來源字體與替代字體建立字體定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/)。
5. 使用 [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 方法指派此集合。
6. 渲染或轉換簡報。

以下 PHP 範例在 `SomeRareFont` 不可用時，以 `Arial` 替代 `SomeRareFont`，然後渲染第一張投影片以驗證結果。替代字體必須對 Aspose.Slides 可用。

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
若要無條件變更簡報中使用的所有字體，請參閱 [Font Replacement](/slides/zh-hant/php-java/font-replacement/)。
{{% /alert %}}

## **數學方程式字體的限制**

字體替代規則是渲染與轉換期間使用的標準字體選擇流程的一部分。當 Aspose.Slides 能以規則指定的可用字體取代無法存取的字體時，這些規則適用於一般文字。

Office Math 方程式有額外需求。如果方程式使用 **Cambria Math**，Aspose.Slides 可能需要該確切字體來計算與渲染方程式版面。使用其他數學字體（例如 **STIX Two Math**）的替代規則無法取代 **Cambria Math**，渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以 [external font](/slides/zh-hant/php-java/custom-font/) 載入。

此限制僅適用於方程式版面。上述的替代規則仍適用於一般簡報文字。

## **常見問題**

**字體替換與字體替代有何不同？**  
[Font replacement](/slides/zh-hant/php-java/font-replacement/) 會有意地在整個簡報中將一種字體變更為另一種字體。字體替代則在符合設定條件（例如原始字體不可用）時，為渲染輸出選擇字體。

**何時套用替代規則？**  
這些規則在渲染與轉換期間參與 [font selection sequence](/slides/zh-hant/php-java/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字體時使用。

**當字體缺失且未配置替代規則時會發生什麼情況？**  
Aspose.Slides 會根據其字體選擇流程挑選最接近的可用字體。結果取決於執行環境中可用的字體。

**我可以載入外部字體以避免替代嗎？**  
可以。您可以 [load external fonts](/slides/zh-hant/php-java/custom-font/) 讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否隨函式庫一起分發字體？**  
不會。您需自行提供字體，並遵守其授權條款。

**字體替代結果會在 Windows、Linux 與 macOS 之間有所不同嗎？**  
會。不同作業系統的已安裝字體與字體搜尋位置不同，於一台機器可用的字體在另一台機器上可能需要替代。

**如何在批次轉換中保持字體選擇一致？**  
在每台機器或容器上使用相同的字體檔案與版本，[load required external fonts](/slides/zh-hant/php-java/custom-font/)，並在授權允許時 [embed fonts](/slides/zh-hant/php-java/embedded-font/)。此外，匯出前可呼叫 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) 以辨識意外的替代。