---
title: PHP におけるプレゼンテーションの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/php-java/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキストを抽出
- プレゼンテーションからテキストを抽出
- PowerPoint からテキストを抽出
- OpenDocument からテキストを抽出
- PPT からテキストを抽出
- PPTX からテキストを抽出
- ODP からテキストを抽出
- テキスト取得
- スライドからテキストを取得
- プレゼンテーションからテキストを取得
- PowerPoint からテキストを取得
- OpenDocument からテキストを取得
- PPT からテキストを取得
- PPTX からテキストを取得
- ODP からテキストを取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションからテキストを迅速に抽出します。シンプルでステップバイステップのガイドに従って、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要なタスクです。Microsoft PowerPoint の PPT や PPTX 形式、あるいは OpenDocument プレゼンテーション (ODP) を扱う場合でも、テキストデータへのアクセスと取得は、分析、 automation、インデックス作成、コンテンツ移行などの目的で不可欠です。

本稿では、Aspose.Slides for PHP via Java を使用して PPT、PPTX、ODP などさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に反復処理し、必要なテキストコンテンツを正確に取得する手順を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for PHP via Java は [SlideUtil](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/) クラスを提供します。このクラスは、プレゼンテーションまたはスライド全体からテキストを抽出するための複数のオーバーロードされた static メソッドを公開しています。スライド内のテキストを抽出するには、[getAllTextBoxes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/#getAllTextBoxes) メソッドを使用します。このメソッドは [BaseSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/) 型のオブジェクトをパラメータとして受け取ります。実行すると、メソッドはスライド全体を走査してテキストを検出し、テキスト書式情報を保持したまま [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) 型オブジェクトの配列を返します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーション全体からテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/) クラスが提供する [getAllTextFrames](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/#getAllTextFrames) static メソッドを使用します。 このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) オブジェクト。
2. 次に、プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `boolean` 値。

このメソッドは、テキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) 型オブジェクトの配列を返します。以下のコードは、マスタースライドを含めてプレゼンテーションのテキストと書式詳細を走査します。

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **分類済みかつ高速なテキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供します。

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textextractionarrangingmode/) 列挙型の引数は、テキスト抽出結果の整理モードを示し、次の値に設定できます。
- `Unarranged` - スライド上の位置を考慮しない生テキスト。
- `Arranged` - スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は、`Unarranged` モードを使用できます。こちらの方が `Arranged` モードより高速です。

[PresentationText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationtext/) は、プレゼンテーションから抽出された生テキストを表します。その `getSlidesText` メソッドは、各オブジェクトが対応するスライドのテキストを表す配列を返します。各オブジェクトは次のメソッドを提供します。

- `getText` - スライドのシェイプ内のテキスト。
- `getMasterText` - 当該スライドに関連付けられたマスタースライドのシェイプ内のテキスト。
- `getLayoutText` - 当該スライドに関連付けられたレイアウトスライドのシェイプ内