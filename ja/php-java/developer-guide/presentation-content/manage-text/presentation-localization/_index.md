---
title: "PHPでプレゼンテーションのローカライゼーションを自動化"
linktitle: "プレゼンテーション ローカライゼーション"
type: docs
weight: 100
url: /ja/php-java/presentation-localization/
keywords:
- "言語を変更"
- "スペルチェック"
- "スペルチェックを抑制"
- "校正言語"
- "言語 ID"
- "多言語テキスト"
- "PowerPoint"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides を使用して PHP で PowerPoint および OpenDocument のプレゼンテーションテキストの校正言語を設定し、既定値や多言語段落も含めます。"
---
## **概要**

Aspose.Slides for PHP via Java を使用すると、個々のテキスト部分に対して校正メタデータを構成できます。校正言語を指定するには[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId)を使用し、スペルチェックを許可または抑制するには[BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setSpellCheck)を、より広範な「校正しない」状態を制御するには[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setProofDisabled)を使用します。これらの設定は部分レベルで適用されるため、1つの段落に複数の言語や異なる校正ルールを含めることができます。

この記事では、特定のテキストに言語を割り当てる方法、[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage)で新規テキストの既定言語を設定する方法、複数言語の段落を作成する方法、`SpellCheck` と `ProofDisabled` の選択、および[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)を使用する際に意図した設定を保持する方法について説明します。これらのプロパティはプレゼンテーションアプリケーション用のメタデータを保存しますが、テキストの翻訳や辞書ベースのスペルチェック、誤字リストの取得は行いません。

## **テキストの校正言語を設定する**

[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) を作成または読み込み、[Portion::getPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getPortionFormat) で対象のテキスト部分にアクセスし、言語識別子を割り当てます。以下の例はシェイプを作成し、校正言語としてイギリス英語を設定し、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save)で結果を保存します。

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

## **新規テキストの既定言語を設定する**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して、Aspose.Slides が新しく作成するテキストに割り当てる校正言語を指定します。この設定は、プレゼンテーション内のほとんどまたはすべての新規テキストが同じ言語を使用する場合に便利です。既に明示的な言語が設定されているテキストのメタデータは変更されません。

以下の例は、新規テキストがドイツ語の校正ルールを使用するプレゼンテーションを作成します。

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

## **1つの段落で複数言語を使用する**

[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) はテキスト部分のコレクションを保持します。各言語ごとに別々の[Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/) を作成し、`LanguageId` を個別に設定します。

この例は、英語とフランス語の部分を含む段落を作成します。

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

## **個別の部分のスペルチェックを有効または無効にする**

[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) は、[BasePortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/) で定義された共通テキストプロパティを継承します。[Portion::getPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getPortionFormat) で部分の書式にアクセスし、[BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setSpellCheck) を使用してプレゼンテーションアプリケーションがその部分のスペルチェックを行うかどうかを制御します。デフォルトは `false` で、`true` にするとチェックを許可し、`false` にすると抑制します。

この設定は個々のテキスト部分に適用されます。同じ段落内の異なる部分で異なる値を使用できます。[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId) と `setSpellCheck` は補完的な目的を持ちます：`setLanguageId` は校正言語を識別し、`setSpellCheck` はその部分でスペルチェックを許可するかどうかを決定します。

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setProofDisabled) も校正を制御しますが、これは [NullableBool](https://reference.aspose.com/slides/ja/php-java/aspose.slides/nullablebool/) として「校正しない」状態全体を表します。スペルチェック専用のブールスイッチが必要な場合は `setSpellCheck` を使用し、プレゼンテーションの「校正しない」メタデータ（`NotDefined` 状態を含む）を保持または明示的に制御したい場合は `setProofDisabled` を使用します。両方のプロパティを設定する場合は値を整合させ、`setSpellCheck(true)` と `setProofDisabled(NullableBool::True)` を組み合わせないでください。

これらのプロパティは PowerPoint などのプレゼンテーションアプリケーションで使用される校正メタデータを構成しますが、Aspose.Slides が辞書ベースのスペルチェックを実行したり、誤字リストを返したりすることはありません。

以下の完全な例は、入力プレゼンテーションを作成し読み込み、同じ段落内の 2 つの部分に異なるスペルチェック設定と校正言語を割り当て、結果を保存して再度開き、保存された値を検証します。

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

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) は、同じ書式を持つ隣接する部分を結合します。`SpellCheck` の違いだけでは部分を別々に保つことはできません。結合後の部分は最初の部分の `SpellCheck` 値を保持します。異なるスペルチェック設定が必要な場合は、設定を割り当てる前に `joinPortionsWithSameFormatting` を呼び出すか、結合後の部分境界を確認して設定を再適用してください。`LanguageId` の値が異なる部分は、校正言語の書式が異なるため別々に保たれます。

## **FAQ**

**言語 ID はテキストを翻訳しますか？**

いいえ。[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId) はスペルチェックや文法チェック用の校正メタデータを保存するだけで、テキスト内容は変更しません。テキストは別途翻訳し、翻訳後の各部分に適切な言語識別子を設定してください。

**校正言語はフォント、ハイフネーション、行折り返しを制御しますか？**

いいえ。言語識別子は校正用です。テキストの描画とレイアウトは主に利用可能な[フォント](/slides/ja/php-java/powerpoint-fonts/)、文字体系、テキストフレームの設定に依存します。正確な表示のためには必要なフォントを提供し、[フォント置換](/slides/ja/php-java/font-substitution/)や[フォント埋め込み](/slides/ja/php-java/embedded-font/) を構成してください。

**1つの段落で複数の校正言語を使用できますか？**

はい。例に示すように、各言語を別々の部分に割り当てることで実現できます。

**`setDefaultTextLanguage` と `setLanguageId` のどちらを使うべきですか？**

新規作成テキストに既定の言語を設定したい場合は[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用します。特定の部分に明示的な校正言語を設定したい、または段落に複数言語が混在する場合は[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId) を使用してください。