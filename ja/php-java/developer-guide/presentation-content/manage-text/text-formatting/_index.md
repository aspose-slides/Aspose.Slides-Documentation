---
title: PHP でプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/php-java/text-formatting/
keywords:
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
- 行間隔
- 自動フィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for PHP via Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカー、タブストップ、言語設定について解説します。

以下の例では、最初のスライドに単一のテキストボックスが含まれ、次のテキストが設定されている「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現マッチを検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/php-java/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定する**

段落のデフォルトのハイライト色を設定するには [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用し、個々のテキスト部分の色を設定するには [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#getHighlightColor) を使用します。

次のコード例は、**段落全体**の背景色を設定する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // 段落全体のハイライトカラーを設定します。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![灰色の段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の背景色を設定する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト部分のハイライトカラーを設定します。
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
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

テキストフレーム内の段落配置を設定するには [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setAlignment) を使用します。値には中央、左揃え、右揃え、両端揃えなどがあります。

次のコード例は、段落を **中央** に配置する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

## **テキストの透明度を設定する**

テキストの透明度は [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#getFillFormat) に割り当てられた色のアルファ成分で制御されます。以下の例では、`alpha = 50` は 0〜255 のスケールの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

次のコード例は、**段落全体**に透明度を適用する方法を示しています。

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // テキストの塗りつぶし色を透明な色に設定します。
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![透過した段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**に透明度を適用する方法を示しています。

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト部分の透明度を設定します。
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![透過したテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定する**

テキストボックス内の文字間隔を拡大または縮小するには [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setSpacing) を使用します。

次の PHP コードは、**段落全体**の文字間隔を拡大する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注: 文字間隔を圧縮するには負の値を使用します。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 文字間隔を拡大します。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の文字間隔を拡大する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 注: 文字間隔を圧縮するには負の値を使用します。
            $portion->getPortionFormat()->setSpacing(3); // 文字間隔を拡大します。
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

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の同じテキストよりも若干詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニング情報を無視するために起こります（フォント自体に有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても同様です）。

このようなケースで PowerPoint に近い出力にするには、影響を受けるフォントを使用したテキスト部分のカーニングを無効にします。[BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) を実際のフォントサイズよりかなり大きな値に設定してください。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

この設定により該当テキスト部分へのカーニング適用が抑制され、PowerPoint 固有の動作の影響を受けるフォントに対して Aspose.Slides のレンダリングを PowerPoint のビジュアル出力に近づけることができます。

## **テキストフォントプロパティの管理**

フォントプロパティは、[ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) を使用して個々の部分で設定できます。

次のコードは、段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // 段落のフォントプロパティを設定します。
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落のフォントプロパティ](font_properties_for_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**に同様のプロパティを適用します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // テキスト部分のフォントプロパティを設定します。
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定する**

シェイプ内のテキストの事前定義された向きを設定するには [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setTextVerticalType) を使用します。

次のコード例は、シェイプ内のテキスト向きを `Vertical270` に設定し、テキストを **反時計回りに90度** 回転させます。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![テキストの回転](text_rotation.png)

## **テキストフレームのカスタム回転を設定する**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setRotationAngle) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) のカスタム回転角度を設定します。

次のコード例は、シェイプ内のテキストフレームを時計回りに 3 度回転させます。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間隔を設定する**

Aspose.Slides は [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setSpaceAfter) 、[ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setSpaceBefore) 、および [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setSpaceWithin) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間隔を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間隔をポイントで指定します。

次のコード例は、段落内の行間隔を指定する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落内の行間隔](line_spacing.png)

## **テキストフレームの自動フィットタイプを設定する**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setAutofitType) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テキストフレームのアンカーを設定する**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setAnchoringType) は、テキストをシェイプ内で垂直に配置する位置（上部、中央、下部など）を定義します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テキストのタブ設定**

段落のタブストップを構成するには、[ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) と [ParagraphFormat::getTabs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getTabs) を使用します。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

## **校正言語を設定する**

Aspose.Slides は [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId) を提供し、テキスト部分の校正言語（スペルチェックや文法チェックに使用される言語）を設定できます。

次のコード例は、テキスト部分の校正言語を設定する方法を示しています。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // 校正言語の ID を設定します。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **デフォルト言語を設定する**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して、プレゼンテーションの読み込みまたは作成時に新規テキストに適用されるデフォルト言語を定義します。

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // テキスト付きの新しい長方形シェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 最初のテキスト部分の言語を確認します。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **デフォルトテキストスタイルを設定する**

プレゼンテーションレベルでデフォルトのテキスト書式設定を適用するには、[Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDefaultTextStyle) を使用します。

次のコード例は、新規プレゼンテーションのすべてのスライドで、太字・14 pt のフォントをデフォルトとして設定する方法を示しています。

```php
$presentation = new Presentation();
try {
    // トップレベルの段落書式を取得します。
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

## **全大文字の効果でテキストを抽出する**

PowerPoint では **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字として表示されます。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

例として、sample2.pptx の最初のスライドに次のテキストボックスがあるとします。

![全大文字効果](all_caps_effect.png)

次のコード例は、**全大文字** 効果が適用されたテキストを抽出する方法を示しています。

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

**スライド上のテーブルのテキストを変更するには？**

テーブルのテキストを変更するには [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) を使用します。セルを走査し、[Cell::getTextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/#getTextFrame) と [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getParagraphFormat) を通じて各セルと段落書式を更新してください。

**PowerPoint スライドのテキストにグラデーションカラーを適用するには？**

テキストにグラデーションカラーを適用するには [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#getFillFormat) を使用します。[FillFormat::setFillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/#setFillType) を [FillType::Gradient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成してください。