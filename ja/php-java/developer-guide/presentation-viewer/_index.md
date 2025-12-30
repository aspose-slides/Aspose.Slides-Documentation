---
title: PHPでプレゼンテーションビューアを作成する
linktitle: プレゼンテーションビューア
type: docs
weight: 50
url: /ja/php-java/presentation-viewer/
keywords:
- プレゼンテーションを表示
- プレゼンテーション ビューア
- プレゼンテーションビューアを作成
- PPT を表示
- PPTX を表示
- ODP を表示
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してカスタム プレゼンテーションビューアを作成します。Microsoft PowerPoint を使用せずに、PowerPoint および OpenDocument ファイルを簡単に表示できます。"
---

Aspose.Slides for PHP via Java は、スライドを含むプレゼンテーションファイルの作成に使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者が好みの画像ビューアでスライドを画像として表示したり、独自のプレゼンテーションビューアを作成したりする必要がある場合があります。そのようなケースでは、Aspose.Slides を使用して個々のスライドを画像としてエクスポートできます。本記事ではその方法を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides でプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. ファイルストリームを開きます。
1. スライドを SVG 画像としてファイルストリームに保存します。
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```


## **カスタム シェイプ ID で SVG を生成する**

Aspose.Slides を使用して、カスタム シェイプ ID を持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。これを行うには、[SvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/) の `setId` メソッドを使用します。`CustomSvgShapeFormattingController` を使用してシェイプ ID を設定できます。
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```

```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```


## **スライド サムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像を生成するのに役立ちます。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 定義したスケールで参照したスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。
```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **ユーザー定義サイズでスライド サムネイルを作成する**

ユーザーが定義したサイズでスライド サムネイル画像を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 定義した寸法で参照したスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。
```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **スピーカーノート付きスライド サムネイルを作成する**

Aspose.Slides を使用してスピーカーノート付きスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) クラスのインスタンスを作成します。
1. `RenderingOptions.setSlidesLayoutOptions` メソッドを使用してスピーカーノートの位置を設定します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. レンダリング オプションを使用して参照したスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。
```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```


## **ライブ例**

Aspose.Slides API で実装できることを確認するには、無料アプリの [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) をお試しください:

![オンライン PowerPoint ビューア](online-PowerPoint-viewer.png)

## **FAQ**

**Web アプリケーションにプレゼンテーションビューアを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを画像や HTML にレンダリングし、ブラウザーで表示できます。ナビゲーションやズーム機能は JavaScript で実装してインタラクティブな体験を提供できます。

**カスタムビューア内でスライドを表示する最適な方法は何ですか？**

推奨されるアプローチは、各スライドを画像（例: PNG または SVG）としてレンダリングするか、Aspose.Slides を使用して HTML に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナに出力を表示することです。

**多数のスライドを含む大規模なプレゼンテーションはどのように扱いますか？**

大規模なデッキの場合は、スライドの遅延ロードまたはオンデマンドレンダリングを検討してください。これは、ユーザーがスライドへ移動したときにのみそのコンテンツを生成することで、メモリ使用量とロード時間を削減します。