---
title: 在 PHP 中管理腳本特定主題字型
linktitle: 腳本特定主題字型
type: docs
weight: 15
url: /zh-hant/php-java/script-specific-font-mappings/
keywords:
- 腳本特定字型
- 主題字型對應
- 多語言簡報
- 書寫系統
- 西里爾字型
- 阿拉伯字型
- 日文字型
- 喬治亞字型
- 塔安那字型
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP (透過 Java) 檢視、加入、取代與移除 PowerPoint 主題中的腳本特定字型對應。"
---
## **概覽**

簡報主題可以為不同的書寫系統選擇不同的字型族。這讓仍使用主題字型的多語言文字，能在使用適合西里爾文、阿拉伯文、日文、喬治亞文、塔安那文等腳本的同時，遵循同一套協調的字型方案。

主題的[FontScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/)包含主要字型集合（通常用於標題）與次要字型集合（通常用於內文）。除了拉丁與東亞字型設定外，兩個[Fonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/)集合還提供從書寫系統標籤到字型族名稱的對應關係。

本文示範如何檢查與修改簡報母版主題中的這些對應關係，並驗證變更在儲存與重新載入的週期中仍然存在。

## **了解腳本標籤**

腳本字型方法使用四字母 BCP 47 腳本子標籤來識別書寫系統。常見值包括：

| 腳本標籤 | 書寫系統 |
|---|---|
| `Cyrl` | 西里爾文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 喬治亞文 |
| `Thaa` | 塔安那文 |

這些對應關係屬於主題字型方案，而非個別文字片段。簡報可能為主要與次要集合定義不同的對應，亦可能省略某些腳本的對應。

## **存取與檢查腳本字型對應關係**

使用[Presentation::getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getMasterTheme)取得簡報層級的主題。再透過[MasterTheme::getFontScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/#getFontScheme)、[FontScheme::getMajor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/#getMajor)與[FontScheme::getMinor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/#getMinor)取得兩個[Fonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/)集合。

呼叫[Fonts::getScriptFontMap](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/#getScriptFontMap)可取得集合中所有對應關係。若要查詢單一書寫系統，使用其腳本標籤呼叫[Fonts::getScriptFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/#getScriptFont)。當該集合未定義所請求的對應時，`Fonts::getScriptFont` 會回傳 `null`。

## **修改對應關係並驗證持久性**

使用[Fonts::setScriptFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/#setScriptFont)建立對應或取代現有的字型族。使用[Fonts::removeScriptFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/#removeScriptFont)移除對應。

以下端對端範例會讀取所有現有的主要與次要對應，查詢日文主要字型，變更西里爾文主要字型，移除塔安那文次要對應，儲存簡報，並重新開啟以驗證兩項變更。為使移除步驟不受初始主題影響，範例會在尚未定義塔安那文對應時先建立該對應。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

驗證使用與普通查詢相同的 `null` 行為：在移除並儲存後，`Fonts::getScriptFont("Thaa")` 於次要集合會回傳 `null`。

## **區分主題對應關係與其他字型設定**

腳本特定的主題對應參與字型選取，但它解決的問題與直接文字格式化、字型替換與回退不同：

| 機制 | 目的 | 變更主題對應關係的影響 |
|---|---|---|
| Script-specific theme font mapping | 為書寫系統選取主要或次要的主題字型。 | 仍使用相應主題字型的文字會解析為新的對應字型族。 |
| Font assigned explicitly to a text portion | 在該段落上固定所請求的字型族，而不依賴主題。 | 該段落可能保持不變，因為直接格式化會覆寫主題選擇。 |
| Font substitution | 當請求的字型不可用或符合替換規則時，會替換該字型。 | 它在字型被請求之後執行；不會重新定義主題的腳本對應關係。 |
| Font fallback | 提供所選字型未包含的字形，通常針對特定 Unicode 範圍。 | 它填補缺少的字形覆蓋；不會更改已存儲的主題對應關係。 |

更多關於後兩種機制的資訊，請參閱[Font Substitution](/slides/zh-hant/php-java/font-substitution/)與[Fallback Fonts](/slides/zh-hant/php-java/fallback-font/)。

在[Presentation::getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getMasterTheme)中變更對應，僅會影響仍依賴該主題的有效格式化內容。文字可能改為從母版、版面配置或投影片繼承主題覆寫，或使用明確指派的字型。當可見結果未遵循簡報層級的對應時，請檢查這些層級。

## **使對應字型可用並驗證結果**

腳本對應僅儲存字型族名稱；它不會安裝或載入對應的字型檔案。為了確保一致的渲染與匯出，必須在環境中安裝每個對應的字型，或透過自訂來源（例如[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/#loadExternalFonts)或[LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)）提供給 Aspose.Slides。請參閱[Custom Fonts](/slides/zh-hant/php-java/custom-font/)了解可用的載入選項。

驗證已儲存的對應僅證明主題定義已被保留，並不代表字型已可用、包含所有必要字形，或產生預期的版面配置。請將每個必要書寫系統的代表性文字渲染為影像或 PDF，並檢查輸出。此步驟可捕捉缺少字型、字形覆蓋不完整、回退行為與版面變更，避免在簡報發佈前出現問題。請參閱[Convert PowerPoint Presentations](/slides/zh-hant/php-java/convert-powerpoint/)取得渲染與匯出範例。

## **常見問題**

**當腳本未對應時，`Fonts::getScriptFont` 會回傳什麼？**

[Fonts::getScriptFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/#getScriptFont) 在所請求的腳本對應未在該主要或次要字型集合中定義時，回傳 `null`。

**當腳本已存在時，`Fonts::setScriptFont` 會新增第二個對應嗎？**

不會。[Fonts::setScriptFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fonts/#setScriptFont) 會在缺少對應時建立，若相同腳本標籤已存在則會取代原有的字型族。

**為何變更主題對應關係未改變某些文字？**

該文字可能已明確指派了字型、透過覆寫從其他母版或版面繼承了不同的主題，或在渲染時受到字型替換或回退的影響。簡報層級的腳本對應僅控制仍依賴該主題字型集合的文字。

**僅儲存再開啟是否足以驗證多語言輸出？**

不足。重新開啟只能驗證主題資料的持久性。仍需將每個必要書寫系統的代表性文字渲染出來，確認對應字型已安裝且包含所需字形，才能保證輸出的正確性。