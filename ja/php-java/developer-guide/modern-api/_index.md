---
title: モダン API で画像処理を強化する
linktitle: モダン API
type: docs
weight: 237
url: /ja/php-java/modern-api/
keywords:
- モダン API
- 描画
- スライドサムネイル
- スライドから画像へ
- シェイプサムネイル
- シェイプから画像へ
- プレゼンテーションサムネイル
- プレゼンテーションから画像へ
- 画像を追加
- 画像を追加
- PHP
- Aspose.Slides
description: "非推奨の画像 API を PHP モダン API に置き換えて、スライド画像処理を近代化し、PowerPoint および OpenDocument の自動化をシームレスに実現します。"
---
## **はじめに**

歴史的に、Aspose Slides は `java.awt` に依存しており、公開 API には以下のクラスが含まれています。
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

バージョン 24.4 以降、この公開 API は非推奨と宣言されています。

これらのクラスへの依存をなくすために、いわゆる「Modern API」（非推奨 API の代わりに使用すべき API）を追加しました。この API のシグネチャは [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) への依存を含みます。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) は非推奨とされ、公開 Slides API からのサポートは削除されました。

現在のバージョンでは、`java.awt` 型に依存する公開 API をレガシー/非推奨として扱います。新しいコードや既存の画像処理ワークフローを移行する際は Modern API を使用してください。

## **モダン API**

公開 API に以下のクラスと列挙型を追加しました。

- [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) - ラスタ画像またはベクタ画像を表します。
- [ImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imageformat/) - 画像のファイル形式を表します。
- [Images](https://reference.aspose.com/slides/ja/php-java/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) クラスのインスタンス化および操作用メソッドです。

なお、[IImage] は破棄可能であり、使用後は破棄する必要があります。

`getImage` を使用して単一のスライドまたはシェイプをレンダリングします。`getImages` を使用して複数のプレゼンテーションスライドをレンダリングします。[Images] のメソッドで画像をロードし、`addImage` と [IImage] を組み合わせてプレゼンテーションに追加し、`replaceImage` と [IImage] を組み合わせて既存のプレゼンテーション画像を更新します。

新しい API の典型的な使用シナリオは次のとおりです。

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# ディスク上のファイルから破棄可能な IImage のインスタンスを作成する。
$image = Images::fromFile("image.png");

# IImage のインスタンスをプレゼンテーションの画像に追加して PowerPoint 画像を作成する。
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# スライド #1 に画像シェイプを追加する。
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# スライド #1 を表す IImage のインスタンスを取得する。
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# 画像をディスクに保存する。
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **古いコードを Modern API に置き換える**

一般に、[BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) および [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) を使用した呼び出しを、[IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) を使用する新しいメソッドに置き換える必要があります。

レガシー/非推奨 API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modern API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **スライドのサムネイル取得**

レガシー/非推奨 API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **シェイプのサムネイル取得**

レガシー/非推奨 API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **プレゼンテーションのサムネイル取得**

レガシー/非推奨 API:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **プレゼンテーションへ画像を追加する**

レガシー/非推奨 API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **非推奨メソッドと Modern API における置換**

### **Presentation**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Modern API の代替なし |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Modern API の代替なし |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Modern API の代替なし |

### **Output**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D 用 API サポート**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) を使用したメソッドは非推奨とされ、直接的な Modern API の置換はありません。

代わりに Modern API の画像レンダリングメソッドを使用してください。

[Slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**なぜ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) が廃止されたのですか？**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) のサポートは、レンダリングと画像処理の統合、プラットフォーム固有の依存性の排除、そして [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) を使用したクロスプラットフォームアプローチへの切り替えのために非推奨となりました。`getImage` または `getImages` を使用し、[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) へのレンダリングは行わないでください。

**[IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) は [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) と比べて実用的にどんな利点がありますか？**

[IImage] はラスタ画像とベクタ画像の両方を統一的に扱えるようにし、[ImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imageformat/) を介してさまざまな形式へ簡単に保存できるようにします。

**Modern API はサムネイル生成のパフォーマンスに影響しますか？**

`getThumbnail` から `getImage` への切り替えでパフォーマンスが低下することはありません。新しいメソッドはオプションやサイズ指定で同等の画像生成機能を提供し、レンダリングオプションのサポートも維持しています。具体的な性能向上または低下はシナリオに依存しますが、機能的には置換は同等です。