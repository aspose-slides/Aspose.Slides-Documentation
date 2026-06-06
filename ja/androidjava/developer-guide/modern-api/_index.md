---
title: モダン API を使用した画像処理の強化
linktitle: モダン API
type: docs
weight: 237
url: /ja/androidjava/modern-api/
keywords:
- android.graphics
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
- Android
- Java
- Aspose.Slides
description: "非推奨の画像 API を Java のモダン API に置き換えて、スライド画像処理を近代化し、PowerPoint と OpenDocument の自動化をシームレスに実現します。"
---
## **イントロダクション**

歴史的に、Aspose Slides は `android.graphics` に依存しており、公開 API には以下のクラスが含まれています。
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

バージョン 24.4 以降、この公開 API は非推奨と宣言されています。

これらのクラスへの依存をなくすために、いわゆる「**モダン API**」を追加しました。つまり、非推奨となった API の代わりに使用すべき API で、シグネチャに [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) への依存が含まれます。[Canvas](https://developer.android.com/reference/android/graphics/Canvas) は非推奨とされ、公開 Slides API からのサポートは削除されました。

現在のバージョンでは、`android.graphics` 型に依存する公開 API をレガシー/非推奨として扱い、新規コードや既存の画像処理ワークフローの移行時にはモダン API を使用してください。

## **モダン API**

公開 API に以下のクラスと列挙型を追加しました。

- [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) - ラスタ画像またはベクター画像を表します。
- [ImageFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imageformat/) - 画像のファイル形式を表します。
- [Images](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) インターフェイスのインスタンス化と操作を提供するメソッドです。

※ [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) は破棄可能であり、使用後は `dispose()` 呼び出しまたはその他の適切な破棄パターンを実行してください。

単一のスライドまたはシェイプをレンダリングするには `getImage` を使用し、複数のプレゼンテーションスライドをレンダリングするには `getImages` を使用します。[Images](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/images/) のメソッドで画像をロードし、`addImage` と [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) を使用してプレゼンテーションに追加し、`replaceImage` と [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) で既存のプレゼンテーション画像を更新します。

新しい API の典型的な使用シナリオは次のようになります。

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // ディスク上のファイルから IImage の破棄可能なインスタンスを生成します。
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
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
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

## **古いコードをモダン API に置き換える**

一般的に、[Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) を使用した呼び出しを、[IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) を使用する新しいメソッドに置き換える必要があります。

レガシー/非推奨 API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
モダン API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **スライドサムネイルの取得**

レガシー/非推奨 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

モダン API:

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

レガシー/非推奨 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

モダン API:

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

レガシー/非推奨 API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

モダン API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

### **プレゼンテーションへの画像追加**

レガシー/非推奨 API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

モダン API:

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

## **非推奨メソッドとモダン API における置換**

### **Presentation**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| メソッド署名 | 置換メソッド署名 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| メソッド署名 | 置換メソッド署名 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Output**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| メソッド署名 | 置換メソッド署名 |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| メソッド署名 | 置換メソッド署名 |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| メソッド署名 | 置換メソッド署名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Canvas の API サポート**

[Canvas](https://developer.android.com/reference/android/graphics/Canvas) を使用したメソッドは非推奨とされ、直接的なモダン API の置換はありません。

[Canvas](https://developer.android.com/reference/android/graphics/Canvas) にレンダリングする API の代わりに、モダン API の画像レンダリングメソッドを使用してください：

[Slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**なぜ android.graphics.Canvas が削除されたのですか？**

公開 API での [Canvas](https://developer.android.com/reference/android/graphics/Canvas) のサポートは非推奨となり、レンダリングと画像処理を統一し、プラットフォーム依存の結合を排除して、[IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) によるクロスプラットフォーム アプローチへ切り替えるためです。`getImage` または `getImages` を使用し、[Canvas](https://developer.android.com/reference/android/graphics/Canvas) へのレンダリングは行わないでください。

**[IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) は [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) と比べて実用的にどのような利点がありますか？**

[IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) はラスタ画像とベクター画像の両方を統一的に扱えるため、[ImageFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imageformat/) を介したさまざまな形式への保存が簡素化されます。

**モダン API はサムネイル生成のパフォーマンスに影響しますか？**

`getThumbnail` から `getImage` への切り替えは、シナリオを劣化させることはありません。新しいメソッドはオプションやサイズ指定による画像生成機能を同等に提供し、レンダリングオプションのサポートも保持しています。具体的な性能向上または低下はシナリオ次第ですが、機能的には置換は同等です。