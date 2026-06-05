---
title: PHPでプレゼンテーションテキストをフォーマット
linktitle: テキスト フォーマット
type: docs
weight: 50
url: /ja/php-java/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキスト背景
- テキスト透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィット プロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、カラー、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for PHP via Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。ハイライト、背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカー、タブストップ、言語設定について説明します。

以下の例では、最初のスライドに 1 つのテキスト ボックスがあり、次のテキストが含まれる「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

テキスト フレーム内で特定のサンプルに一致するテキストをハイライトする必要がある場合は、[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)`::highlightText` メソッドを使用します。このメソッドは一致したテキスト フラグメントにハイライト色を適用し、[TextHighlightingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/texthighlightingoptions/) と組み合わせて検索方法（たとえば単語全体のみを対象）を制御できます。

以下のコード例は、文字列 **"try"** のすべての出現箇所をハイライトし、続いて単語全体 **"to"** のみをハイライトします。

```php
$presentation = new Presentation("sample.pptx");
try {
    // 最初のスライドから最初のシェイプを取得します。
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // シェイプ内の単語 "try" をハイライトします。
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // シェイプ内の単語 "to" をハイライトします。
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)`::highlightRegex` メソッドは、正規表現で見つかったテキストの一致箇所をハイライトします。

以下のコード例は、**7 文字以上の単語**すべてをハイライトします。

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 7文字以上の単語すべてをハイライトします。
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **テキストの背景色を設定**

[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/) のデフォルト ポーション フォーマットを使用して段落全体のデフォルト ハイライト色を設定するか、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) を使用して個々のテキスト ポーションの背景色を設定します。

次のコード例は、**段落全体**の背景色を設定する方法を示します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 段落全体のハイライト色を設定します。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![灰色の段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション**の背景色を設定する方法を示します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト ポーションのハイライト色を設定します。
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![灰色のテキスト ポーション](gray_text_portions.png)

## **テキスト段落の配置**

[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)`::setAlignment` メソッドを使用して、テキスト フレーム内の段落配置を設定します。値は中央寄せ、左寄せ、右寄せ、両端揃えなどが指定できます。

次のコード例は、段落を **中央** に配置する方法を示します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 段落の配置を中央に設定します。
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![配置された段落](aligned_paragraph.png)

## **テキストの透明度を設定**

テキストの透明度は、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) の塗りつぶしフォーマットに割り当てられた色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0〜255 のスケールでの ARGB アルファ チャネル値であり、透明度のパーセンテージではありません。

次のコード例は、**段落全体**に透明度を適用する方法を示します。

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // テキストの塗りつぶし色を透明な色に設定します。
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション**に透明度を適用する方法を示します。

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト ポーションの透明度を設定します。
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![透明なテキスト ポーション](transparent_text_portions.png)

## **テキストの文字間隔を設定**

[BasePortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/)`::setSpacing` メソッドを使用して、テキスト ボックス内の文字間隔を拡大または縮小します。

次の PHP コードは、**段落全体**の文字間隔を拡大する方法を示します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意: 文字間隔を圧縮するには負の値を使用します。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 文字間隔を拡張します。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション**の文字間隔を拡大する方法を示します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 注意: 文字間隔を圧縮するには負の値を使用します。
            $portion->getPortionFormat()->setSpacing(3); // 文字間隔を拡張します。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![テキスト ポーション内の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の表示と比較してやや詰まって見えることがあります。これは、PowerPoint が特定のフォントに対してカーニング データを無視することが原因です（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっている場合でも）。

このような場合、該当フォントを使用するテキスト ポーションのカーニングを無効にすることで、PowerPoint に近い表示にできます。[BasePortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` メソッドに、実際のフォント サイズよりはるかに大きい値を設定します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この設定により、一致するテキスト ポーションへのカーニング適用が抑制され、PowerPoint 固有の動作の影響を受けるフォントで Aspose.Slides のレンダリングを PowerPoint の視覚出力に合わせることができます。

## **テキスト フォント プロパティの管理**

フォント プロパティは、[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/) のデフォルト ポーション フォーマットを介して段落レベルで、または個々のポーションに対して [PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) を介して設定できます。

次のコードは、段落全体のフォントとテキスト スタイルを設定します。フォント サイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべてのポーションに適用します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // 段落のフォントプロパティを設定します。
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落のフォント プロパティ](font_properties_for_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション**に同様のプロパティを適用します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト ポーションのフォントプロパティを設定します。
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![テキスト ポーションのフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` メソッドを使用して、シェイプ内のテキストの事前定義された向きを設定します。

次のコード例は、シェイプ内のテキストの向きを `Vertical270` に設定し、テキストを **90 度反時計回り** に回転させます。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![テキストの回転](text_rotation.png)

## **テキスト フレームのカスタム回転を設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setRotationAngle` メソッドを使用して、[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキスト フレームを時計回りに 3 度回転させます。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間を設定**

Aspose.Slides は、[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`、`ParagraphFormat::setSpaceBefore`、`ParagraphFormat::setSpaceWithin` メソッドを提供し、段落間隔を制御します。これらのメソッドは次のように使用します。

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイント単位で指定します。

次のコード例は、段落内の行間を指定する方法を示します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落内の行間](line_spacing.png)

## **テキスト フレームのオートフィット タイプを設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setAutofitType` メソッドは、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、オーバーフローさせるか、シェイプを自動的にサイズ変更するかを制御できます。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テキスト フレームのアンカーを設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setAnchoringType` メソッドは、シェイプ内でテキストが垂直方向に配置される位置（上部、中央、下部など）を定義します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テキストのタブ設定**

[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` メソッドとそのタブ コレクションを使用して、段落内のタブストップを構成します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落のタブ](paragraph_tabs.png)

## **校正言語を設定**

Aspose.Slides は [BasePortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/)`::setLanguageId` メソッドを提供し、テキスト ポーションの校正言語を設定できます。校正言語は PowerPoint でのスペルチェックと文法チェックに使用される言語を決定します。

次のコード例は、テキスト ポーションの校正言語を設定する方法を示します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // 校正言語の ID を設定します。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **デフォルト言語を設定**

[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` メソッドを使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // テキスト付きの新しい四角形シェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 最初のポーションの言語を確認します。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **デフォルト テキスト スタイルを設定**

プレゼンテーション レベルでデフォルトのテキスト書式設定を適用するには、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) のデフォルト テキスト スタイルを使用します。

次のコード例は、新しいプレゼンテーションのすべてのスライドで、フォント サイズ 14 pt の太字フォントをデフォルトとして設定する方法を示します。

```php
$presentation = new Presentation();
try {
    // トップレベルの段落フォーマットを取得します。
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **全大文字効果でテキストを抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字で表示されます。Aspose.Slides でそのテキスト ポーションを取得すると、ライブラリは入力されたままのテキストを返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

サンプル ファイル **sample2.pptx** の最初のスライドにある次のテキスト ボックスを例にします。

![全大文字効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

出力:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブル内のテキストを変更するには？**

テーブル内のテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) を使用します。セルを走査し、各セルの [Cell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/) のテキスト フレームと [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) の段落書式を通じて更新します。

**PowerPoint スライドのテキストにグラデーション色を適用するには？**

グラデーション色を適用するには、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) の塗りつぶしフォーマットを使用します。[FillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) の塗りつぶしタイプを [FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) `Gradient` に設定し、グラデーション ストップ、方向、透明度を構成します。