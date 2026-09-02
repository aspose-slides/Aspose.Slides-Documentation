---
title: 在 PHP 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/php-java/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言 ID
- 多語言文字
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 為 PowerPoint 和 OpenDocument 簡報文字設定校對語言，包括預設語言與多語言段落。"
---
## **概述**

Aspose.Slides for PHP via Java 讓您能夠為單個文字部分配置校對中繼資料。使用 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 來指定校對語言，使用 [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setSpellCheck) 來允許或抑制拼寫檢查，並使用 [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setProofDisabled) 來控制更廣泛的「不校對」狀態。由於這些設定在文字部分層級套用，一個段落可以包含多種語言和不同的校對規則。

本篇說明如何將語言指派給特定文字、使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 為新文字設定預設語言、建立多語言段落、在 `SpellCheck` 與 `ProofDisabled` 之間作選擇，並在使用 [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 時保留預期的設定。這些屬性儲存供簡報應用程式使用的中繼資料；它們不會翻譯文字、執行基於字典的拼寫檢查，或回傳拼寫錯誤的單字。

## **設定文字的校對語言**

建立或載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，透過 [Portion::getPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getPortionFormat) 取得需要的文字部分，並指派其語言識別碼。以下範例建立一個圖形、將校對語言設為英式英文，並使用 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 儲存結果：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定新文字的預設語言**

使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 來指定 Aspose.Slides 為新建立的文字指派的校對語言。當簡報中大部分或全部新文字使用相同語言時，此設定很有用。它不會變更已具備明確語言的文字的語言中繼資料。

以下範例建立一個簡報，其新文字使用德文校對規則：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在同一段落中使用多種語言**

一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 包含文字部分的集合。為每種語言建立單獨的 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/)，並獨立設定其 `LanguageId`。

此範例建立一個段落，內含英文與法文的文字部分：

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **為單一文字部分啟用或抑制拼寫檢查**

[PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 繼承自 [BasePortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/) 定義的通用文字屬性。透過 [Portion::getPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getPortionFormat) 取得文字部分的格式，並使用 [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setSpellCheck) 來控制簡報應用程式是否對該部分執行拼寫檢查。預設值為 `false`：`true` 允許拼寫檢查，`false` 則抑制檢查。

此設定套用於單一文字部分。因此，同一段落中的不同部分可以使用不同的值。[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 與 `setSpellCheck` 具有互補的功能：`setLanguageId` 用於識別校對語言，而 `setSpellCheck` 決定是否允許對該部分執行拼寫檢查。

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setProofDisabled) 亦可控制校對，但它以 [NullableBool](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/nullablebool/) 形式表示更廣泛的「不校對」狀態。當您需要針對拼寫檢查的直接布林切換時，請使用 `setSpellCheck`。當您需要保留或明確控制簡報的「不校對」中繼資料（包括其 `NotDefined` 狀態）時，請使用 `setProofDisabled`。若同時設定兩個屬性，請保持其值一致；不要將 `setSpellCheck(true)` 與 `setProofDisabled(NullableBool::True)` 結合使用。

這些屬性用於設定 PowerPoint 及其他簡報應用程式使用的校對中繼資料。Aspose.Slides 不會利用它們執行基於字典的拼寫檢查或回傳錯字清單。

以下完整範例建立一個輸入簡報、載入它、在同一段落的兩個文字部分指派不同的拼寫檢查設定與校對語言、儲存結果、重新開啟並驗證儲存的值：

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 會合併相鄰且格式相同的文字部分。僅 `SpellCheck` 的差異不會使這些部分保持分離；合併後，產生的文字部分會保留第一個部分的 `SpellCheck` 值。若各部分需要不同的拼寫檢查設定，請在指派這些設定之前呼叫 `joinPortionsWithSameFormatting`，或在合併後檢查產生的部分邊界並重新套用設定。具有不同 `LanguageId` 值的部分會保持分離，因為其校對語言格式不同。

## **FAQ**

**語言 ID 會翻譯文字嗎？**

不會。 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId) 只儲存供拼寫與文法校對使用的中繼資料，並不會改變文字內容。請先自行翻譯文字，然後為每個已翻譯的部分設定適當的語言識別碼。

**校對語言會控制字型、連字或換行嗎？**

不會。語言識別碼僅供校對使用。文字的呈現與版面配置主要取決於可用的 [fonts](/slides/zh-hant/php-java/powerpoint-fonts/)、書寫系統以及文字框設定。為確保正確呈現，請提供所需字型、設定 [font substitution](/slides/zh-hant/php-java/font-substitution/)，或在簡報中 [embed fonts](/slides/zh-hant/php-java/embedded-font/)。

**一個段落可以使用多種校對語言嗎？**

可以。將每種語言指派給單獨的文字部分，如多語言段落範例所示。

**我應該使用 `setDefaultTextLanguage` 還是 `setLanguageId`？**

當您想為新建立的文字設定預設語言時，請使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage)。當特定文字部分需要明確的校對語言，或段落包含多種語言時，請使用 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId)。