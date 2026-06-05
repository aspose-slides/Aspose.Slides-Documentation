---
title: PHPでプレゼンテーションテキストをフォーマット
linktitle: テキストフォーマット
type: docs
weight: 50
url: /ja/php-java/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキストの回転
- 回転角度
- テキストフレーム
- 行間
- 自動フィットプロパティ
- テキストフレームのアンカー
- テキストのタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。ハイライト、背景色、透明度、文字間隔、フォントプロパティ、回転、段落の間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定などをカバーします。

以下の例では、最初のスライドに 1 つのテキスト ボックスが含まれ、次のテキストが入っている「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

テキスト フレーム内で特定のサンプルに一致するテキストをハイライトする必要がある場合は、[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)`::highlightText` メソッドを使用します。このメソッドは一致したテキスト フラグメントにハイライト色を適用し、[TextHighlightingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/texthighlightingoptions/) を使用して検索方法を制御できます。たとえば、単語全体にのみ一致させることが可能です。

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

[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)`::highlightRegex` メソッドは、正規表現で見つかったテキストの一致をハイライトします。

以下のコード例は、**7 文字以上** を含むすべての単語をハイライトします。

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

## **テキストの背景色の設定**

[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)'s デフォルト部分フォーマットを使用して段落のデフォルトハイライト色を設定するか、個々のテキスト部分には [PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) を使用します。

以下のコード例は、**段落全体** の背景色を設定する方法を示しています。

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

以下のコード例は、**太字フォントのテキスト部分** の背景色を設定する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト部分のハイライト色を設定します。
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)`::setAlignment` メソッドを使用して、テキスト フレーム内の段落配置を設定します。値は中央揃え、左揃え、右揃え、両端揃えなどが可能です。

以下のコード例は、段落を **中央** に配置する方法を示しています。

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

## **テキストの透明度の設定**

テキストの透明度は、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/)'s 塗りつぶしフォーマットに割り当てられた色のアルファ成分で制御されます。以下の例では、`alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明度のパーセンテージではありません。

以下のコード例は、**段落全体** に透明度を適用する方法を示しています。

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // テキストの塗りつぶし色を透明色に設定します。
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** に透明度を適用する方法を示しています。

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
            // テキスト部分の透明度を設定します。
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

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

[BasePortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/)`::setSpacing` メソッドを使用して、テキストボックス内の文字間隔を拡大または縮小します。

以下の PHP コードは、**段落全体** の文字間隔を拡大する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注: 文字間隔を縮めるには負の値を使用します。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 文字間隔を拡張します。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 注: 文字間隔を縮めるには負の値を使用します。
            $portion->getPortionFormat()->setSpacing(3); // 文字間隔を拡張します。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint で表示される同じテキストよりもやや詰まって見えることがあります。これは、PowerPoint が特定のフォントのカーニングデータを無視する可能性があるためで、フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっている場合でも起こります。

このような場合にレンダリング結果を PowerPoint に近づけるには、影響を受けたフォントを使用するテキスト部分のカーニングを無効にします。[BasePortionFormat] の `::setKerningMinimalSize` メソッドに、実際のフォントサイズよりかなり大きな値を設定します。

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

この設定により、一致するテキスト部分にカーニングが適用されなくなり、PowerPoint 固有の動作で影響を受けるフォントの視覚的出力を Aspose.Slides のレンダリングと合わせるのに役立ちます。

## **テキストのフォントプロパティの管理**

フォントプロパティは、[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)'s デフォルト部分フォーマットを通じて段落レベルで設定するか、個々の部分では [PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) を使用して設定できます。

以下のコードは、段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

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

![段落のフォントプロパティ](font_properties_for_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** に同様のプロパティを適用します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト部分のフォントプロパティを設定します。
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

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキストの回転設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` メソッドを使用して、シェイプ内の事前定義されたテキスト方向を設定します。

以下のコード例は、シェイプ内のテキスト方向を `Vertical270` に設定します。これによりテキストが **90 度逆時計回り** に回転します。

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

## **テキストフレームのカスタム回転設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setRotationAngle` メソッドを使用して、[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキストフレームを時計回りに 3 度回転させます。

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

## **段落の行間設定**

Aspose.Slides は、段落の間隔を制御するために [ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`、`ParagraphFormat::setSpaceBefore`、`ParagraphFormat::setSpaceWithin` メソッドを提供します。これらのメソッドは次のように使用します。

* 正の値を使用して、行間を行の高さのパーセンテージで指定します。
* 負の値を使用して、行間をポイントで指定します。

以下のコード例は、段落内の行間を指定する方法を示しています。

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

## **テキストフレームの自動調整タイプの設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setAutofitType` メソッドは、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、またはシェイプを自動的にリサイズするかを制御するために使用します。

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

## **テキストフレームのアンカー設定**

[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/)`::setAnchoringType` メソッドは、テキストがシェイプ内で垂直方向にどの位置に配置されるか（例：上部、中央、下部）を定義します。

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

[ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` メソッドとそのタブコレクションを使用して、段落内のタブストップを設定します。

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

## **校正言語の設定**

Aspose.Slides は、[BasePortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/)`::setLanguageId` メソッドを提供しており、テキスト部分の校正言語を設定できます。校正言語は、PowerPoint でのスペルチェックと文法チェックに使用される言語を決定します。

以下のコード例は、テキスト部分の校正言語を設定する方法を示しています。

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

## **デフォルト言語の設定**

[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` メソッドを使用して、プレゼンテーションの読み込みまたは作成時に生成されるテキストのデフォルト言語を定義します。

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // テキスト付きの新しい矩形シェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 最初の部分の言語をチェックします。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **デフォルトテキストスタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式設定を適用するには、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)'s デフォルトテキストスタイルを使用します。

以下のコード例は、新しいプレゼンテーションのすべてのスライドのテキストに対して、サイズ 14 pt の太字フォントをデフォルトとして設定する方法を示しています。

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

## **All-Caps 効果でテキストを抽出する**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字として表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textcaptype/) を確認し、値が `All` のときに返された文字列を大文字に変換します。

たとえば、sample2.pptx ファイルの最初のスライドに次のテキストボックスがあるとします。

![All Caps 効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示しています。

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

**スライド上のテーブルのテキストを変更する方法は？**

スライド上のテーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) を使用します。セルを反復処理し、各セルの [Cell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/) のテキストフレームと、[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/)'s 段落フォーマットを介して段落フォーマットを更新します。

**PowerPoint スライドのテキストにグラデーション色を適用する方法は？**

テキストにグラデーション色を適用するには、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/)'s 塗りつぶしフォーマットを使用します。[FillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/)'s 塗りつぶしタイプを [FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) `Gradient` に設定し、グラデーション ストップ、方向、透明度を構成します。