---
title: モダン API で画像処理を強化する
linktitle: モダン API
type: docs
weight: 237
url: /ja/nodejs-java/modern-api/
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
- 画像を挿入
- Node.js
- JavaScript
- Aspose.Slides
description: "非推奨の画像 API を JavaScript のモダン API に置き換えて、スライド画像処理を最新化し、PowerPoint および OpenDocument の自動化をシームレスに実現します。"
---
## **導入**

歴史的に、Aspose Slides は java.awt に依存しており、公開APIには以下のクラスが含まれています:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

バージョン 24.4 以降、この公開APIは非推奨と宣言されています。

これらのクラスへの依存関係を解消するため、いわゆる「Modern API」を追加しました。つまり、非推奨となった API の代わりに使用すべき API で、シグネチャに [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) への依存が含まれます。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) は非推奨と宣言され、公開 Slides API からのサポートが削除されました。

現在のバージョンでは、java.awt 型に依存する公開APIはレガシー/非推奨として扱ってください。新しいコードや既存の画像処理ワークフローの移行時には Modern API を使用します。

## **モダン API**

以下のクラスと列挙型が公開APIに追加されました：

- [IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) - ラスタまたはベクタ画像を表します。
- [ImageFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imageformat/) - 画像のファイル形式を表します。
- [Images](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/images/) - [IImage] クラスのインスタンス化および操作用メソッドです。

※ [IImage] は破棄可能であり、使用後は `dispose()` 呼び出しまたはその他の適切な破棄パターンを実行してください。

単一のスライドまたはシェイプをレンダリングするには `getImage` を使用します。複数のプレゼンテーションスライドをレンダリングするには `getImages` を使用します。画像をロードするには [Images] メソッドを使用し、`addImage` と [IImage] でプレゼンテーションに画像を追加し、`replaceImage` と [IImage] で既存のプレゼンテーション画像を更新します。

新しい API の典型的な使用シナリオは以下のようになります：

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // ディスク上のファイルから IImage の破棄可能なインスタンスを作成します。
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // プレゼンテーションの画像に IImage のインスタンスを追加して PowerPoint 画像を作成します。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライド #1 に画像シェイプを追加します。
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // スライド #1 を表す IImage のインスタンスを取得します。
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // 画像をディスクに保存します。
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **古いコードを Modern API に置き換える**

一般的に、[BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) と [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) を使用する呼び出しを、[IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) を使用する新しいメソッドに置き換える必要があります。

レガシー/非推奨 API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Modern API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **スライドサムネイルの取得**

レガシー/非推奨 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **シェイプサムネイルの取得**

レガシー/非推奨 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **プレゼンテーションサムネイルの取得**

レガシー/非推奨 API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **プレゼンテーションに画像を追加する**

レガシー/非推奨 API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
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
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Modern API の置換なし |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Modern API の置換なし |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Modern API の置換なし |

### **Output**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| メソッドシグネチャ | 置換メソッドシグネチャ |
|-------------------------------------------|--------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

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

## **Graphics2D の API サポート**

Graphics2D を使用するメソッドは非推奨と宣言され、直接的な Modern API の置換はありません。

Graphics2D にレンダリングする API の代わりに Modern API の画像レンダリングメソッドを使用してください：

[Slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**[IImage] と [BufferedImage] の実用的な利点は何ですか？**

[IImage] はラスタ画像とベクタ画像の両方の操作を統合し、[ImageFormat] を介してさまざまな形式への保存を簡素化します。

**Modern API はサムネイル生成のパフォーマンスに影響しますか？**

`getThumbnail` から `getImage` への切り替えはシナリオを悪化させません。新しいメソッドはオプションやサイズ指定で画像を生成する同等の機能を提供し、レンダリングオプションのサポートも保持しています。具体的な性能向上または低下はシナリオに依存しますが、機能的には置換は等価です。