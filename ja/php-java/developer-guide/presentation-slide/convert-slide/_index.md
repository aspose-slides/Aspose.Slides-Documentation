---
title: PHP でプレゼンテーション スライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/php-java/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像に変換
- スライドを画像として保存
- スライドを PNG に変換
- スライドを JPEG に変換
- スライドをビットマップに変換
- スライドを TIFF に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PPT、PPTX、ODP のスライドを画像に変換します — 高速で高品質なレンダリングと分かりやすいコード例を提供します。"
---
## **はじめに**

Aspose.Slides for PHP via Java は、PowerPoint および OpenDocument のプレゼンテーション スライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できるようにします。

スライドを画像に変換するには、次の手順に従ってください：

1. 目的の変換設定を定義し、エクスポートしたいスライドを次のいずれかで選択します：
    - [TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラス、または
    - [RenderingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/) クラス。
2. [getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage) メソッドを呼び出してスライド画像を生成します。

Aspose.Slides for PHP via Java では、[IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) はピクセル データで定義された画像を扱えるクラスです。このクラスを使用して、BMP、JPG、PNG などの幅広い形式で画像を保存できます。

## **スライドをビットマップに変換し、PNGで画像を保存**

スライドをビットマップ オブジェクトに変換し、アプリケーションで直接使用できます。あるいは、スライドをビットマップに変換し、JPEG や他の任意の形式で画像を保存することもできます。

このコードは、プレゼンテーションの最初のスライドをビットマップ オブジェクトに変換し、PNG 形式で画像を保存する方法を示しています：

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションの最初のスライドをビットマップに変換します。
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // 画像を PNG 形式で保存します。
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **カスタムサイズでスライドを画像に変換**

特定のサイズの画像が必要な場合があります。[getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage) のオーバーロードを使用して、幅と高さを指定した画像にスライドを変換できます。

このサンプルコードは、この操作の方法を示しています：

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // 指定されたサイズでプレゼンテーションの最初のスライドをビットマップに変換します。
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // 画像を JPEG 形式で保存します。
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **ノートとコメント付きスライドを画像に変換**

スライドによってはノートやコメントが含まれている場合があります。

Aspose.Slides は、プレゼンテーション スライドを画像にレンダリングする制御を可能にする、[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) と [RenderingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/) の 2 つのクラスを提供します。どちらのクラスも `setSlidesLayoutOptions` メソッドを含んでおり、スライドを画像に変換する際にノートやコメントのレンダリングを設定できます。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notescommentslayoutingoptions/) クラスを使用すると、生成された画像内でノートやコメントの配置位置を指定できます。

このコードは、ノートとコメント付きスライドを画像に変換する方法を示しています：

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // ノートの位置を設定します。
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // コメントの位置を設定します。
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // コメント領域の幅を設定します。
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // コメント領域の色を設定します。

    // レンダリング オプションを作成します。
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // プレゼンテーションの最初のスライドを画像に変換します。
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // 画像を GIF 形式で保存します。
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
スライドから画像への変換プロセスにおいて、[setNotesPosition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) メソッドは `BottomFull`（ノートの位置指定） を適用できません。これは、ノートのテキストが大きすぎて、指定された画像サイズに収まらない可能性があるためです。
{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換**

[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスは、サイズ、解像度、カラーパレットなどのパラメータを指定できるため、生成される TIFF 画像をより細かく制御できます。

このコードは、TIFF オプションを使用して 300 DPI の解像度と 2160 × 2800 のサイズで白黒画像を出力する変換プロセスを示しています：

```php
// プレゼンテーション ファイルを読み込みます。
$presentation = new Presentation("sample.pptx");
try {
    // プレゼンテーションから最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // 出力 TIFF 画像の設定を構成します。
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // 画像サイズを設定します。
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // ピクセル形式を設定します（白黒）。
    $options->setDpiX(300);                                              // 水平解像度を設定します。
    $options->setDpiY(300);                                              // 垂直解像度を設定します。
    
    // 指定されたオプションでスライドを画像に変換します。
    $image = $slide->getImage($options);
    try {
        // 画像を TIFF 形式で保存します。
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
JDK 9 未満のバージョンでは、TIFF のサポートは保証されません。
{{% /alert %}} 

## **すべてのスライドを画像に変換**

Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドを画像に変換でき、実質的にプレゼン全体を一連の画像に変換できます。

このサンプルコードは、PHP でプレゼンテーション内のすべてのスライドを画像に変換する方法を示しています：

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションをスライドごとに画像へレンダリングします。
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // 非表示スライドを制御します（非表示スライドはレンダリングしません）。
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // スライドを画像に変換します。
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // 画像を JPEG 形式で保存します。
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="warning" %}} 
プレゼンテーション スライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが変換を実行するシステムにインストールされ、利用可能である必要があります。例えば、プレゼンテーションが **Segoe UI Emoji** を使用しているがフォントが存在しない場合、出力画像では絵文字がモノクロで表示されることがあります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ、`getImage` メソッドはスライドの静止画像のみを保存し、アニメーションは含まれません。

**非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**画像を影やエフェクト付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に、影、透明度、その他のグラフィック効果のレンダリングをサポートしています。