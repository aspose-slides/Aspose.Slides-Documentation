---
title: モダン API を使用した画像処理の強化
linktitle: モダン API
type: docs
weight: 237
url: /ja/php-java/modern-api/
keywords:
- モダン API
- 描画
- スライド サムネイル
- スライドから画像へ
- シェイプ サムネイル
- シェイプから画像へ
- プレゼンテーション サムネイル
- プレゼンテーションから画像へ
- 画像の追加
- 画像の挿入
- PHP
- Aspose.Slides
description: "レガシーな画像処理 API を PHP のモダン API に置き換えて、スライド画像処理を近代化し、PowerPoint および OpenDocument の自動化をシームレスに実現します。"
---

## **イントロダクション**

歴史的に、Aspose Slides は java.awt に依存しており、公開 API には以下のクラスが含まれています:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

バージョン 24.4 以降、この公開 API は非推奨と宣言されています。

これらのクラスへの依存を排除するため、いわゆる「モダン API」―― 非推奨となった API の代わりに使用すべき API で、署名に BufferedImage の依存が含まれるもの―― を追加しました。Graphics2D は非推奨とされ、公開 Slides API からのサポートが削除されました。

System.Drawing への依存を含む非推奨の公開 API の削除は、リリース 24.8 で行われます。

## **モダン API**

公開 API に以下のクラスと列挙型を追加しました:

- IImage - ラスタまたはベクタ画像を表します。
- ImageFormat - 画像のファイル形式を表します。
- Images - IImage クラスをインスタンス化し操作するためのメソッドです。

`IImage` は disposable です（使用後は破棄してください）。

新しい API の典型的な使用シナリオは次のようになります:
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# ディスク上のファイルから IImage の破棄可能なインスタンスを作成します。
$image = Images::fromFile("image.png");

# IImage のインスタンスをプレゼンテーションの画像に追加して PowerPoint 画像を作成します。
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# スライド #1 に画像シェイプを追加します
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# スライド #1 を表す IImage のインスタンスを取得します。
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# 画像をディスクに保存します。
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```


## **古いコードをモダン API に置き換える**

一般的には、ImageIO を使用した古いメソッド呼び出しを新しいものに置き換える必要があります。

古い例:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```

新しい例:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```


### **スライドのサムネイル取得**

非推奨 API を使用したコード:
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```


モダン API:
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

非推奨 API を使用したコード:
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```


モダン API:
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

非推奨 API を使用したコード:
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


モダン API:
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


### **プレゼンテーションへの画像追加**

非推奨 API を使用したコード:
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


モダン API:
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


## **削除されるメソッドとモダン API における置換**

### **Presentation**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | 完全に削除されます |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | 完全に削除されます |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | 完全に削除されます |

### **Output**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D のサポートは終了します**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) を使用するメソッドは非推奨とされ、公開 API からのサポートが削除されます。

この API の部分は削除されます:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**なぜ java.awt.Graphics2D が削除されたのですか？**

`Graphics2D` のサポートは、レンダリングと画像操作を統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) を用いたクロスプラットフォームアプローチに切り替えるために、公開 API から削除されます。`Graphics2D` 向けのすべてのレンダリングメソッドが削除されます。

**IImage は BufferedImage と比べて実用的な利点は何ですか？**

[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) はラスタ画像とベクタ画像の両方を統一的に扱い、[ImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/) を介してさまざまな形式への保存を簡素化します。

**モダン API はサムネイル生成のパフォーマンスに影響しますか？**

`getThumbnail` から `getImage` への切り替えはシナリオを悪化させません。新しいメソッドはオプションやサイズを指定して画像を生成する同等の機能を提供し、レンダリングオプションのサポートも保持します。具体的な性能向上または低下はシナリオ次第ですが、機能的には置換は同等です。