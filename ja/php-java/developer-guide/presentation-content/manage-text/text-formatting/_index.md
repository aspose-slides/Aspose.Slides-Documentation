---
title: PHPでプレゼンテーションのテキストをフォーマット
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
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **Overview**

この記事では、Aspose.Slides for PHP via Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキスト書式設定方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカー、タブ位置、言語設定などを扱います。

特に記載がない限り、例は [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキストボックスで、最初の段落に以下のテキストが含まれています。スライドとシェイプのインデックスはゼロベースです。太字部分を選択する例は、継承された太字書式を含む実効書式を使用します。

![Sample text](sample_text.png)

文字列や正規表現マッチを検索してハイライトする方法については、[Search and Replace Text](/slides/ja/php-java/search-and-replace-text/) を参照してください。

## **Set Text Background Color**

段落のデフォルトハイライト色を設定するには [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用し、個々のテキスト部分のハイライト色を設定するには [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#getHighlightColor) を使用します。

以下の例は、最初の段落のデフォルトハイライトを薄いグレーに設定します。個々の部分で明示的にハイライト色を指定した場合は、このデフォルトより優先されます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![The gray paragraph](gray_paragraph.png)

以下のコード例は、**太字フォント**のテキスト部分の背景色を設定する方法を示します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![The gray text portions](gray_text_portions.png)

## **Align Text Paragraphs**

テキストフレーム内の段落配置を設定するには [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setAlignment) を使用します。値は中央揃え、左揃え、右揃え、均等揃えなどがあります。

以下のコード例は、段落を **中央** に揃える方法を示します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

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

![The aligned paragraph](aligned_paragraph.png)

## **Set Transparency for Text**

テキストの透明度は、[BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#getFillFormat) に割り当てられる色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明度パーセンテージではありません。

以下のコード例は、**段落全体** に透明度を適用する方法を示します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![The transparent paragraph](transparent_paragraph.png)

以下のコード例は、**太字フォント**のテキスト部分に透明度を適用する方法を示します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![The transparent text portions](transparent_text_portions.png)

## **Set Character Spacing for Text**

テキストボックス内の文字間隔を拡大または縮小するには [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setSpacing) を使用します。例では 3 ポイントの間隔を追加しています。負の値を指定すると文字が詰まります。

以下の PHP コードは、**段落全体** の文字間隔を拡大する方法を示します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意: 文字間隔を圧縮するには負の値を使用します。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 文字間隔を広げます。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォント**のテキスト部分の文字間隔を拡大する方法を示します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // 注意: 文字間隔を圧縮するには負の値を使用します。
            $portion->getPortionFormat()->setSpacing(3); // 文字間隔を広げます。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

場合によっては、Aspose.Slides がレンダリングするテキストが PowerPoint の表示よりわずかに狭く見えることがあります。これは、PowerPoint が特定のフォントに対してカーニング情報を無視するためです（フォントに有効なカーニング情報があり、PowerPoint の設定でカーニングが有効になっていても）。

このような場合に PowerPoint に近い出力にするには、該当フォントを使用するテキスト部分のカーニングを無効にします。実際のフォントサイズより大きい値を [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) に設定します。この例は、最初のスライドの最初のシェイプがテキストボックスである "presentation.pptx" を前提としています。実効フォント名（継承されたフォントも含む）をチェックし、Roboto を使用する部分に対して 100 ポイントのしきい値を設定します。これにより、フォントサイズが 100 ポイント未満の該当部分のカーニングが無効になります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

しきい値未満の該当テキストについては、この設定によりカーニングが抑制され、PowerPoint 固有の動作で影響を受けるフォントの表示を Aspose.Slides と合わせることができます。

## **Manage Text Font Properties**

フォントプロパティは、[ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を介して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) を介して個々の部分で設定できます。

以下の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、イタリック、点線下線を適用します。個々の部分で明示的に書式設定した場合は、これらのデフォルトより優先されます。

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

以下の例は、実効書式が太字である部分に対して、13 ポイントの Times New Roman、イタリック、点線下線を適用します。

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Set Text Rotation**

テキストの向きを事前定義されたものに設定するには、[TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setTextVerticalType) を使用します。

以下のコード例は、シェイプ内のテキスト向きを [TextVerticalType::Vertical270](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textverticaltype/) に設定し、テキストを **反時計回りに 90 度** 回転させます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

![The text rotation](text_rotation.png)

## **Set Custom Rotation for Text Frames**

[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setRotationAngle) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) のカスタム回転角度を設定できます。

以下のコード例は、シェイプ内のテキストフレームを時計回りに 3 度回転させます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![The custom text rotation](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

Aspose.Slides は、[ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setSpaceBefore)、[ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setSpaceWithin) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行高さのパーセンテージとして行間隔を指定します。
* 負の値はポイント数で行間隔を指定します。

以下の例は、最初の段落の内部間隔を行高さの 200%（倍行間）に設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![The line spacing within the paragraph](line_spacing.png)

## **Control Line Breaking**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで役立ちます。以下のメソッドは [ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

- [setLatinLineBreak](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) はラテン文字の改行規則を制御します。混在テキストでは、隣接する東アジア文字や句読点の折り返し位置にも影響します。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) は東アジア文字の改行規則を制御し、行頭・行末の文字制限を含みます。

これらの規則は [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setWrapText) の代わりになるものではなく、テキストフレーム内の自動折り返しを有効にします。折り返しが発生したときのレイアウトに影響を与え、改行文字を挿入するわけではありません。明示的な改行は、利用可能幅に関係なく段落内に新しい行を強制します。

以下の自己完結型サンプルは、中文とラテン文字を含む狭いテキストブロックを作成し、両方の改行オプションを明示的に設定して "line_breaking.pptx" として保存します。どちらか一方の規則を試す場合は、もう一方の設定はそのままにして値を変更してください。例は 24 ポイントの Arial と SimSun、フレーム幅 160 ポイント、水平マージン 0 の設定です。[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setAutofitType) には [TextAutofitType::None](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textautofittype/) を指定し、テキストサイズとフレームサイズを固定しています。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Control Hanging Punctuation**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) を使用すると、対象となる句読点が右端を超えて表示され、次の行に占有されないようになります。段落全体に適用され、ハングインデントとは異なります。

以下の自己完結型サンプルは、幅 100 ポイントのテキストフレームでハング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイントの Arial と水平マージン 0 の設定で、最後の句点は「sentence」の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool::False](https://reference.aspose.com/slides/ja/php-java/aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しは有効、オートフィットは無効にして幅を固定しています。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

すべての句読点がハングできるわけではありません。表示結果はフォントの有無やレイアウトに依存し、フォント、幅、余白、オートフィット設定を変更すると差異が消えることがあります。

## **Set Autofit Type for Text Frames**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setAutofitType) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプ自体を自動でリサイズするかを制御できます。以下の例は、シェイプをテキストに合わせてリサイズするよう構成し、結果を "autofit_type.pptx" として保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

自動折り返し後の行数をカウントし、テキストやシェイプ幅の変化が結果に与える影響を確認するには、[Count Rendered Lines](/slides/ja/php-java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかどうかは判断できません。

## **Set Anchor of Text Frames**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setAnchoringType) は、シェイプ内でテキストを縦方向に配置する方法（上部、中央、下部など）を定義します。以下の例は、テキストを最初のシェイプの下部にアンカーし、結果を "text_anchor.pptx" として保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

## **Set Text Tabulation**

[ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) と [ParagraphFormat::getTabs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getTabs) を使用して段落のタブ位置を構成できます。以下の例は、デフォルトタブ間隔を 100 ポイントに設定し、30 ポイントに左揃えタブ位置を追加します。これらの設定はタブ文字を含むテキストに影響します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

![The paragraph tabs](paragraph_tabs.png)

## **Set Proofing Language**

Aspose.Slides は [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId) を提供し、テキスト部分の校閲言語を設定できます。校閲言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

以下の例は、最初のスライドの最初のシェイプがテキストボックスである "presentation.pptx" を前提とし、最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語校閲言語 (`zh-CN`) を割り当てます。結果は "proofing_language.pptx" として保存されます。

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

    // 校閲言語の ID を設定します。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Set Default Language**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義できます。以下の例は、デフォルトテキスト言語を米国英語に設定してプレゼンテーションを作成し、テキストボックスを追加し、最初のテキスト部分の言語として `en-US` を出力します。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // テキスト付きの新しい矩形シェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 最初のポーションの言語を確認します。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Set Default Text Style**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDefaultTextStyle) を使用します。

以下の例は、新しいプレゼンテーションのトップレベル段落に 14 ポイントの太字フォントをデフォルトとして設定し、"default_text_style.pptx" として保存します。テキストは、より具体的な書式が上書きしない限り、これらのデフォルトを継承できます。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Extract Text with the All-Caps Effect**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、実際に入力された文字列は小文字のままです。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは元の入力通りの文字列を返します。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は取得した文字列を大文字に変換します。

この例は、最初のスライドの最初のシェイプがテキストボックスである "sample2.pptx" を前提とし、最初の段落の最初の部分に **All Caps** 効果が適用された "Hello, Aspose!" が含まれています。

![The All Caps effect](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

**How do I modify text in a table on a slide?**

スライド上のテーブル内のテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) を使用します。セルを走査し、各セルを [Cell::getTextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/#getTextFrame) で取得し、[Paragraph::getParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getParagraphFormat) で段落書式を更新します。

**How do I apply a gradient color to text on a PowerPoint slide?**

テキストにグラデーションカラーを適用するには、[BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#getFillFormat) を使用します。[FillFormat::setFillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/#setFillType) を [FillType::Gradient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成します。