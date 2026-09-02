---
title: 使用 PHP 在簡報中設定字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/php-java/font-substitution/
keywords:
- 字型
- 替代字型
- 字型替代
- 替換字型
- 字型取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 渲染或轉換 PowerPoint 與 OpenDocument 簡報時，設定字型替代規則並檢查已替代的字型。"
---
## **概觀**

字型替代允許 Aspose.Slides 在呈現或轉換簡報時，使用可用的字型來取代無法存取的字型。此替代會影響渲染輸出；不會變更簡報內容所指派的字型。

您可以在特定字型不可用時定義要使用的字型，並檢視 Aspose.Slides 在渲染期間將執行的替代。這有助於在安裝不同字型的環境間保持輸出一致。

## **取得字型替代**

使用 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getsubstitutions/) 方法來確定簡報渲染時會替代哪些字型。此方法會傳回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsubstitutioninfo/) 物件，指出原始字型與替代字型的名稱。

以下 PHP 範例會列出簡報的全部字型替代：

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

## **取得已選取投影片的字型替代**

使用帶有 `int[] slides` 參數的 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getsubstitutions/) 多載，以僅檢視特定投影片所需的替代。當您只渲染或匯出簡報的一部分、增量檢查大型簡報、找出依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理無關投影片的情況下診斷渲染差異時，這非常有用。

`slides` 陣列使用一基索引：`1` 代表第一張投影片。相較之下，[Presentation::getSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSlides) 集合存取子使用零基索引，因此同一張投影片會以 `$presentation->getSlides()->get_Item(0)` 取得。建立陣列時請記住此差異，以免產生「少一」錯誤。

透過 [Presentation::getFontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getFontsManager) 方法呼叫多載。它僅傳回在渲染所選投影片時決定的替代。每個結果都是一個 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsubstitutioninfo/) 物件，包含原始與替代字型名稱。結果會反映當前的字型環境、已設定的備援規則、儲存在 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsubstrulecollection/) 中的替代規則，以及 [外部載入的字型](/slides/zh-hant/php-java/custom-font/)。

同一個替代可能由多個選取的投影片需求。建立字型清單或檢查報告時，請去除重複結果。以下範例會回報每個取得的替代，然後產生唯一字型映射的排序清單：

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

[FontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/) 類別同時提供兩個多載。依照渲染操作的範圍選擇使用：

| 重載 | 使用時機 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getsubstitutions/)（無參數） | 需要整個簡報的替代。 |
| [getSubstitutions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getsubstitutions/)（`int[] slides`） | 需要針對選取範圍、增量檢查或部分匯出的替代。 |

## **設定字型替代規則**

若來源字型不可用，指定 Aspose.Slides 應使用的字型：

1. 載入簡報。  
2. 建立來源字型與替代字型的定義。  
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsubstcondition/) 條件建立一個 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsubstrule/)。  
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsubstrulecollection/)。  
5. 透過 [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 方法指派該集合。  
6. 渲染或轉換簡報。

以下 PHP 範例在 `SomeRareFont` 不可用時，以 `Arial` 取代，並渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

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
若要無條件變更整份簡報中使用的字型，請參閱 [Font Replacement](/slides/zh-hant/php-java/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換期間標準字型選取程序的一部分。它們適用於 Aspose.Slides 能以規則指定的可用字型取代不可存取字型的普通文字。

Office Math 方程式則有額外需求。如果方程式使用 **Cambria Math**，Aspose.Slides 可能需要該精確字型來計算與渲染方程式版面。替代其他數學字型（如 **STIX Two Math**）的規則無法取代 **Cambria Math**，渲染仍可能報告需要 **Cambria Math**。

若要渲染或轉換此類簡報，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以 [外部字型](/slides/zh-hant/php-java/custom-font/) 方式載入。

此限制僅影響方程式版面配置。上述替代規則仍適用於簡報的普通文字。

## **FAQ**

**什麼是字型取代與字型替代的差異？**

[Font replacement](/slides/zh-hant/php-java/font-replacement/) 會有意在整份簡報中將一種字型改為另一種。字型替代則在滿足設定條件（例如原始字型不可用）時，為渲染輸出選擇替代字型。

**什麼時候會套用替代規則？**

這些規則參與渲染與轉換期間的 [font selection sequence](/slides/zh-hant/php-java/font-selection-sequence/)。使用 `WhenInaccessible` 時，僅在 Aspose.Slides 無法存取來源字型時套用。

**如果缺少字型且未設定替代規則，會發生什麼？**

Aspose.Slides 會依照其字型選取程序選擇最接近的可用字型。結果取決於執行環境中可用的字型。

**我可以載入外部字型以避免替代嗎？**

可以。您可以 [載入外部字型](/slides/zh-hant/php-java/custom-font/)，讓 Aspose.Slides 在渲染與轉換時使用它們。

**Aspose 是否會隨函式庫一起分發字型？**

不會。您必須自行提供字型並遵守其授權條款。

**替代結果在 Windows、Linux 與 macOS 之間會不同嗎？**

會。不同作業系統的已安裝字型與搜尋位置各異，某台機器可用的字型在另一台可能需要替代。

**如何在批次轉換中保持字型選取的一致性？**

在每台機器或容器上使用相同的字型檔案與版本，[載入必要的外部字型](/slides/zh-hant/php-java/custom-font/)，並在授權允許時 [嵌入字型](/slides/zh-hant/php-java/embedded-font/)。您也可以在匯出前呼叫 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getsubstitutions/) 以識別意外的替代情況。