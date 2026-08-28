---
title: PHPでプレゼンテーション スライドを画像に変換する
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/php-java/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像に変換
- スライドを画像として保存
- スライドをEMFに変換
- スライドをPNGに変換
- スライドをJPEGに変換
- スライドをビットマップに変換
- スライドをTIFFに変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して、PPT、PPTX、ODP プレゼンテーションのスライドを PHP で PNG、JPEG、GIF、TIFF、EMF などの画像形式に変換します。"
---
## **概要**

Aspose.Slides for PHP via Java は、PowerPoint および OpenDocument プレゼンテーションの個々のスライドを PNG、JPEG、GIF、TIFF、その他の画像形式としてレンダリングできます。

スライドを画像に変換するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. レンダリングしたいスライドを選択します。
3. 必要に応じて、[RenderingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/) または [TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスでレンダリングを構成します。
4. [Slide::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage) メソッドを呼び出します。これにより [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) オブジェクトが返されます。
5. [IImage::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/#save) メソッドを呼び出し、[ImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imageformat/) の値で出力形式を指定します。

## **スライドを PNG 画像に変換する**

最も簡単な変換はデフォルトのレンダリング設定を使用します。結果として得られる [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) オブジェクトはメモリ内で処理するか、ファイルに保存できます。

以下の PHP サンプルは、最初のスライドをレンダリングし、PNG 画像として保存します。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **カスタムサイズでスライドを画像に変換する**

[Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 値を受け取る [Slide::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage) のオーバーロードを使用して、正確なピクセル寸法でスライドをレンダリングします。

以下の例は 1820 × 1040 の JPEG 画像を作成します。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **ノートとコメント付きのスライドを画像に変換する**

デフォルトでは、スライド画像にノートやコメントは含まれません。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notescommentslayoutingoptions/) オブジェクトを [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) メソッドに渡して、ノートとコメントの表示位置を制御します。

以下の例では、切り捨てられたノートをスライドの下に、コメントを右側に配置します。

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
スライドから画像への変換では、[NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) メソッドに [BottomFull](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notespositions/) を渡さないでください。ノートは固定画像サイズが収容できる以上のテキストを含む可能性があります。その代わりに [BottomTruncated](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notespositions/) を使用してください。
{{% /alert %}}

## **TIFF オプションを使用してスライドを画像に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、その他のプロパティを制御できます。

以下の例は、最初のスライドを 2160 × 2880 の TIFF 画像（300 DPI）としてレンダリングします。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Java JDK 9 未満のバージョンでは TIFF のサポートが保証されません。
{{% /alert %}}

## **すべてのスライドを画像に変換する**

スライドコレクションを反復処理して、プレゼンテーション全体を一連の画像に変換します。明示的に除外しない限り、非表示スライドも含まれます。

以下の例は、すべてのスライドを横方向と縦方向のスケール係数 2 の JPEG 画像としてレンダリングします。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **拡張メタファイル出力を作成する**

拡張メタファイル (EMF) は、ベクターベースのグラフィックを Microsoft Office や Windows メタファイルをサポートするその他の Windows アプリケーションとやり取りする必要がある場合に便利です。ピクセルベースの画像とは異なり、EMF はベクター描画操作を保持でき、拡大縮小してもシャープさが失われません。ただし、EMF は主に Windows メタファイルサポートを持つアプリケーション向けの互換性形式であり、汎用の交換フォーマットではありません。さらに、ビットマップ画像や一部のエフェクトなど、複雑なスライドコンテンツはベクターコンテナ内でラスタライズされた要素として格納されることがあります。

### **スライドを EMF にエクスポートする**

[Slide::writeAsEmf](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#writeAsEmf) メソッドはスライドを EMF 形式で対象ストリームに書き込みます。以下の例はプレゼンテーションをロードし、最初のスライドを選択して、EMF ファイルストリームに書き込むものです。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

呼び出し側は [Slide::writeAsEmf](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#writeAsEmf) に渡されたストリームの所有権を持ち、上記のようにストリームを閉じる責任があります。

### **SVG 画像を EMF に変換し、プレゼンテーションに追加する**

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/#writeAsEmf) を使用して SVG コンテンツを EMF に変換します。生成されたバイト列は [ImageCollection::addImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagecollection/#addImage) を介してプレゼンテーションに追加でき、[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/#addPictureFrame) でスライドに配置できます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/#writeAsEmf) は宛先ストリームの所有権を取得しません。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) は生成されたすべてのデータをメモリに格納するため、`toByteArray` を呼び出す前に位置リセットは不要です。返されたバイト配列はストリームを閉じた後も有効です。

EMF の生成は、選択された Aspose.Slides for PHP via Java と JDK 設定がサポートするオペレーティングシステムで利用可能ですが、フォントやグラフィック依存関係が利用できない場合、プラットフォーム間でレンダリング結果が異なることがあります。ソースコンテンツで使用されているフォントをインストールするか、適切な代替フォントを設定し、Aspose.Slides for PHP via Java の [platform requirements](/slides/ja/php-java/system-requirements/) に従って、対象の EMF 消費アプリケーションで結果を検証してください。Linux および macOS のアプリケーションは、Windows メタファイルの表示・編集サポートが限定的または一貫性がないことが多いです。

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="info" %}}
プレゼンテーション スライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが変換を実行するシステムにインストールされ、利用可能である必要があります。たとえば、プレゼンテーションが **Segoe UI Emoji** を使用していてこのフォントが欠如している場合、出力画像の絵文字はモノクロで表示されることがあります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[Slide::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage) メソッドはスライドの静的画像をレンダリングし、アニメーションはエクスポートしません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示スライドも通常のスライドと同様にレンダリングできます。上記の例のように処理ループに含めてください。

**スライド画像に影やその他のエフェクトは保持されますか？**

はい。Aspose.Slides は影、透明度、その他のサポートされているグラフィック効果をスライド画像にレンダリングします。