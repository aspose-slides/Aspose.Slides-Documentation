---
title: Modern API による画像処理の強化
linktitle: モダン API
type: docs
weight: 237
url: /ja/java/modern-api/
keywords:
- モダン API
- 描画
- スライドサムネイル
- スライドから画像へ
- シェイプサムネイル
- シェイプから画像へ
- プレゼンテーションサムネイル
- プレゼンテーションから画像へ
- 画像の追加
- 画像の挿入
- Java
- Aspose.Slides
description: "非推奨の画像 API を Java のモダン API に置き換えることで、スライド画像処理を最新化し、PowerPoint および OpenDocument の自動化をシームレスに実現します。"
---
## **はじめに**

Historically, Aspose Slides は java.awt に依存しており、公開 API には以下のクラスが含まれています。
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

バージョン 24.4 以降、この公開 API は非推奨として宣言されています。

これらのクラスへの依存をなくすため、いわゆる「Modern API」を追加しました。これは、非推奨となった API の代わりに使用すべき API で、シグネチャに [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) への依存が含まれています。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) は非推奨と宣言され、公開 Slides API からのサポートが削除されました。

現在のバージョンでは、java.awt 型に依存する公開 API をレガシー／非推奨として扱います。新しいコードや既存の画像処理ワークフローの移行時には Modern API を使用してください。

## **Modern API**

公開 API に以下のクラスと列挙型が追加されました。

- [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) - ラスターまたはベクター画像を表します。
- [ImageFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) - 画像のファイル形式を表します。
- [Images](https://reference.aspose.com/slides/ja/java/com.aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) インターフェイスを生成および操作するためのメソッドです。

なお、[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) は破棄可能であり、使用後は `dispose()` を呼び出すか、他の適切な破棄パターンを使用する必要があります。

`getImage` を使用して単一のスライドまたはシェイプを描画します。`getImages` を使用して複数のプレゼンテーションスライドを描画します。[Images](https://reference.aspose.com/slides/ja/java/com.aspose.slides/images/) のメソッドを使用して画像をロードし、`addImage` と [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) で画像をプレゼンテーションに追加し、`replaceImage` と [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) で既存のプレゼンテーション画像を更新します。

新しい API の典型的な使用シナリオは以下のようになります：

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // ファイルシステム上のファイルから IImage の破棄可能なインスタンスを作成します。
    IImage image = Images.fromFile("image.png");
    try {
        // IImage のインスタンスをプレゼンテーションの画像コレクションに追加して PowerPoint 画像を作成します。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライド #1 に画像シェイプを追加します。
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // スライド #1 を表す IImage のインスタンスを取得します。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // 画像をディスクに保存します。
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **古いコードを Modern API に置き換える**

一般的に、[BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) と ImageIO を使用した呼び出しを、[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) を使用する新しいメソッドに置き換える必要があります。

レガシー／非推奨 API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **スライドサムネイルの取得**

レガシー／非推奨 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **シェイプサムネイルの取得**

レガシー／非推奨 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **プレゼンテーションサムネイルの取得**

レガシー／非推奨 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **プレゼンテーションに画像を追加する**

レガシー／非推奨 API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
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
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

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

## **Graphics2D の API サポート**

Graphics2D を使用するメソッドは非推奨と宣言されており、直接的な Modern API の置換はありません。

Graphics2D に描画する API の代わりに Modern API の画像描画メソッドを使用してください：

[Slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Graphics2D が廃止された理由は何ですか？**

Graphics2D のサポートは公開 API で非推奨となりました。これは、レンダリングと画像処理の作業を統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) によるクロスプラットフォームアプローチに切り替えるためです。`getImage` または `getImages` を使用し、[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) への描画は行わないでください。

**IImage は BufferedImage と比べて実用上どのような利点がありますか？**

[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) はラスタ画像とベクター画像の両方を統一的に扱い、[ImageFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) を通じてさまざまな形式での保存を簡素化します。

**Modern API はサムネイル生成のパフォーマンスに影響しますか？**

`getThumbnail` から `getImage` への切り替えでパフォーマンスが劣化することはありません。新しいメソッドはオプションやサイズ指定で画像を生成する同等の機能を提供し、レンダリングオプションもサポートします。具体的なメリットやデメリットはシナリオ次第ですが、機能的には置換は同等です。