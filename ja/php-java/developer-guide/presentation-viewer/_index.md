---
title: プレゼンテーションビューア
type: docs
weight: 50
url: /php-java/presentation-viewer/
keywords: "PowerPoint PPT ビューア"
description: "PowerPoint PPT ビューア "
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Javaは、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションを開くことで表示できます。しかし、時には開発者が好みの画像ビューアでスライドを画像として表示したり、独自のプレゼンテーションビューアを作成したりする必要がある場合があります。そのような場合、Aspose.Slides for PHP via Javaを使用すると、個々のスライドを画像としてエクスポートできます。この記事では、これを行う方法を説明します。

{{% /alert %}} 

## **ライブ例**
[**Aspose.Slides ビューア**](https://products.aspose.app/slides/viewer/)の無料アプリを試して、Aspose.Slides APIで実装できることを確認できます：

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **スライドからSVG画像を生成**
Aspose.Slides for PHP via Javaを使用して、任意のスライドからSVG画像を生成するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- IDまたはインデックスを使用して、必要なスライドの参照を取得します。
- メモリストリームにSVG画像を取得します。
- メモリストリームをファイルに保存します。

```php
  # プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
  $pres = new Presentation("CreateSlidesSVGImage.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # メモリストリームオブジェクトを作成
    $svgStream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    # スライドのSVG画像を生成し、メモリストリームに保存
    $sld->writeAsSvg($svgStream);
    $svgStream->close();
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **カスタムシェイプIDでSVGを生成**
Aspose.Slides for PHP via Javaを使用して、カスタムシェイプIDを持つスライドから[SVG](https://docs.fileformat.com/page-description-language/svg/)を生成できます。そのためには、生成されたSVG内のシェイプのカスタムIDを表す[ISvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgShape)のIDプロパティを使用します。CustomSvgShapeFormattingControllerを使用してシェイプIDを設定できます。

```php

  class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    function __construct() {
      $this->m_shapeIndex = 0;
    }

    function __construct($shapeStartIndex) {
      $this->m_shapeIndex = $shapeStartIndex;
    }

    function formatShape($svgShape, $shape) {
      $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
  }

  $pres = new Presentation("pptxFileName.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    try {
      $svgOptions = new SVGOptions();
      $shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(), null, java("com.aspose.slides.ISvgShapeFormattingController"));
      $svgOptions->setShapeFormattingController($shapeFormattingController);
      $pres->getSlides()->get_Item(0)->writeAsSvg($stream, $svgOptions);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **スライドのサムネイル画像を作成**
Aspose.Slides for PHP via Javaは、スライドのサムネイル画像を生成するのを助けます。Aspose.Slides for PHP via Javaを使用して任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. 指定したスケールで参照されるスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```php
  # プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
  $pres = new Presentation("ThumbnailFromSlide.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # フルスケール画像を作成
    $slideImage = $sld->getImage(1.0, 1.0);
    # JPEG形式でディスクに画像を保存
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **ユーザー定義の寸法でサムネイルを作成**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. 指定したスケールで参照されるスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```php
  # プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # ユーザー定義の寸法
    $desiredX = 1200;
    $desiredY = 800;
    # XおよびYのスケール値を取得
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    # フルスケール画像を作成
    $slideImage = $sld->getImage($ScaleX, $ScaleY);
    # JPEG形式でディスクに画像を保存
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **ノートスライドビューのスライドからサムネイルを作成**
Aspose.Slides for PHP via Javaを使用して、ノートスライドビューで任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. ノートスライドビューの指定したスケールで、参照されるスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

以下のコードスニペットは、ノートスライドビューでプレゼンテーションの最初のスライドのサムネイルを生成します。

```php
  # プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # ユーザー定義の寸法
    $desiredX = 1200;
    $desiredY = 800;
    # XおよびYのスケール値を取得
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    $opts = new RenderingOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # フルスケール画像を作成
    $slideImage = $sld->getImage($opts, $ScaleX, $ScaleY);
    # JPEG形式でディスクに画像を保存
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```