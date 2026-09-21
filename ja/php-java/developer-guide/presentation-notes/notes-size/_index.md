---
title: PHPでノートページのサイズと向きを変更する
linktitle: ノートページサイズ
type: docs
weight: 10
url: /ja/php-java/notes-size/
keywords:
- ノートページサイズ
- ノートの向き
- 横向きノート
- 縦向きノート
- ハンドアウトサイズ
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Java経由でPHP向けAspose.Slidesのノートページ寸法を読み取り、変更し、向きを切り替えて、保存されたサイズを検証し、ノートまたはハンドアウトをPDFや画像にエクスポートします。"
---
## **概要**

[Presentation::getNotesSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getnotessize/) を使用して、プレゼンテーションのノートページ設定にアクセスします。これは [NotesSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notessize/) オブジェクトを返し、その [setSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notessize/setsize/) メソッドでページの寸法を設定します。設定オブジェクト自体は置き換えられませんが、このメソッドを使用して新しい寸法を割り当てることができます。

幅と高さは **ポイント** で指定され、1インチは 72 ポイントです。たとえば 900 × 600 ポイントは 12.5 × 8⅓ インチに相当します。これらの設定はプレゼンテーション全体に適用され、個々のスライドのノートには適用されません。

| 設定 | 目的 |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getnotessize/) | ノートページの寸法とハンドアウトエクスポートに使用されるページ寸法を制御します。 |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getslidesize/) | [SlideSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesize/) を介して、通常のプレゼンテーションスライドの寸法を制御します。 |

いずれかの設定を変更しても、もう一方が自動的に変更されることはありません。ノートページの向きを変更しても、通常のスライドは回転しません。[Slide Size](/slides/ja/php-java/slide-size/) を参照して、通常のスライドのサイズを変更してください。

## **ノートページのサイズと向きの読み取り**

幅と高さを読み取り、比較して向きを判断します。幅が大きければ横向き、縦が大きければ縦向き、サイズが等しければ正方形です。この例では、標準用紙サイズを仮定せずにポイント単位の実際の寸法を出力します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **用紙サイズを変更せずに横向きに切り替える**

向きだけを変更したい場合は、既存の幅と高さを入れ替えます。これにより、カスタム用紙サイズを含む両側の長さが保持されます。以下の条件は、すでに横向きのページが縦向きに戻されることや、正方形ページが変更されないようにします。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

縦向きの場合は、`java_values($size->getWidth()) > java_values($size->getHeight())` のときに同様の代入を行います。A4 や Letter の寸法に置き換える場合は、用紙サイズも変更したいときに限ります。

## **カスタムノートページサイズの設定と検証**

両方の寸法を同時に割り当て、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/save/) でプレゼンテーションを書き出します。この例では 900 × 600 ポイントの横向きページを設定し、PPTX として保存した後に再度開いて永続化された値を確認します。比較では浮動小数点値に対して 0.01 ポイントの許容誤差を設けていますが、すべてのファイル形式での精度を保証するものではありません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

期待される結果は `900 x 600 points` と `Size preserved: true` です。新しく開いたプレゼンテーションを確認することで、保存されたファイルが正しく保存されたことを検証します。

## **ノートとハンドアウトのエクスポート**

ページ寸法はノートやハンドアウトレイアウトの利用可能領域を定義しますが、これだけでレイアウトが有効になるわけではありません。エクスポートオプションも構成してください。通常のスライドエクスポートはスライド寸法を引き続き使用します。

### **ノートを PDF と PNG にエクスポートする**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notescommentslayoutingoptions/) を [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) に割り当てて PDF にノートを含めます。この例では [Slide::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage) と [RenderingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングします。

[BottomTruncated](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notespositions/) モードはノートを 1 ページに収め、収まりきらない場合は切り捨てます。PDF は 900 × 600 ポイントのページを使用します。以下の例の 1 × 1 の画像スケールでは PNG は 900 × 600 ピクセルになります。ポイントはページの幾何形状を示し、ピクセルはレンダリングスケールに依存するラスタ出力の寸法を示します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

長いノートを含む PDF エクスポートの場合は、[BottomFull](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notespositions/) を使用して必要に応じて追加ページを生成できます。ただし、上記の単一スライド画像呼び出しはこのモードをサポートしていません。サイズ変更後は、クリップされたノートや既存の notes‑master オブジェクトの配置を確認してください。ページ寸法だけを変更しても、すべてのコンテンツが収まる保証にはなりません。詳細は [Convert PowerPoint to PDF with Notes](/slides/ja/php-java/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **ハンドアウトを PDF にエクスポートする**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handoutlayoutingoptions/) を使用して、1 ページに複数のスライドサムネイルを配置します。以下の例では 900 × 600 ポイントのページを設定し、[HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handouttype/) を使用して最大 4 スライドを横向きに並べます。横向きプリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

ページサイズを変更すると、ハンドアウトグリッドの利用可能領域が変わりますが、元スライドの寸法は変わりません。ハンドアウト画像を取得するには、個々のスライドの画像メソッドではなく、ハンドアウトレイアウトを指定して [Presentation::getImages](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getimages/) を使用します。Aspose.Slides では、プレゼンテーションレベルのハンドアウトレンダリングがノートページ寸法を使用し、個別スライドの画像呼び出しはハンドアウトページを生成しません。[Handout Mode](/slides/ja/php-java/convert-powerpoint-in-handout-mode/) でレイアウトオプションを確認してください。

## **ビューア、エクスポート、印刷におけるページサイズ**

保存されたプレゼンテーションサイズ、エクスポートされたページサイズ、印刷時の用紙サイズはそれぞれ別物として扱います：

- **プレゼンテーション ビューア:** ビューアは独自のレイアウト規則でノートを表示または印刷できます。他のアプリケーションがファイルを保存した場合は再度開いて寸法を確認してください。そのアプリケーションの形式変換が寸法を正規化することがあります。
- **エクスポート形式:** 上記のノートおよびハンドアウト PDF の例は設定されたページ寸法を使用します。ラスタ画像は整数ピクセル寸法とレンダリングスケールを使用するため、端数のポイント値は画像出力時に丸められることがあります。通常のスライドのエクスポートはノートページサイズを適用しません。
- **プリンタ ドライバ:** 用紙選択、自動回転、ページに合わせて拡大縮小の設定により、物理的な出力が変わることがありますが、プレゼンテーションや PDF に保存された寸法は変わりません。特定の用紙サイズを使用する場合は、プリンタ設定を合わせて印刷プレビューを確認してください。

## **FAQ**

**1枚のスライドだけのノートサイズを設定できますか？**

ノートページサイズはプレゼンテーションレベルの設定です。個々のスライドは異なるノート内容を持てますが、このプロパティでスライドごとに別々のページサイズを指定することはできません。

**ノートの向きを変更してもスライドが変わらなかったのはなぜですか？**

ノートページと通常のスライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常のスライドサイズ設定を使用してください。

**保存または印刷した結果のサイズが異なるのはなぜですか？**

まず保存したプレゼンテーションを再度開き、ノートの寸法を比較してください。変更されている場合は、別のアプリケーションで保存または変換した際にページ設定が変わった可能性があります。変更されていない場合は、エクスポートレイアウト、画像スケール、ビューア設定、プリンタの用紙選択を確認してください。