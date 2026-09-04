---
title: "Python のモダン API で画像処理を強化する"
linktitle: "モダン API"
type: docs
weight: 237
url: /ja/python-java/modern-api/
keywords:
- "モダン API"
- "描画"
- "スライド サムネイル"
- "スライドから画像へ"
- "シェイプ サムネイル"
- "シェイプから画像へ"
- "プレゼンテーション サムネイル"
- "プレゼンテーションから画像へ"
- "画像を追加"
- "画像を挿入"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Python（Java 経由）で画像処理をモダナイズし、スライドやシェイプをレンダリング、画像を追加、非推奨の画像呼び出しを Aspose.Slides のモダン API に移行します。"
---
## **はじめに**

Aspose.Slides for Python via Java は JPype を介して Java ライブラリにアクセスします。レガシーな画像処理 API は `java.awt` の [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) と [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) を使用していました。

Java ライブラリはバージョン 24.4 からこれらの画像 API を非推奨にしました。モダン API は画像の読み込み、レンダリング、保存に [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) を使用します。新しい Python コードや既存の画像処理ワークフローの移行時に使用してください。

{{% alert color="info" title="注" %}}

以下の古いメソッド名は移行参照用です。現在のリリースでは利用できません。実行例はモダン API を使用しています。

この変更ですべての `java.awt` 型が廃止されるわけではありません。画像サイズやパターンカラーのオーバーロードは引き続き [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) と [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) を受け取ります。

{{% /alert %}}

## **モダン API**

主な画像処理型は次のとおりです。

- [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) — ラスタ画像またはベクタ画像を表します。
- [ImageFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/) — 画像ファイル形式の定数を提供します。
- [Images](https://reference.aspose.com/slides/ja/python-java/aspose.slides/images/) — たとえば [Images.fromFile](https://reference.aspose.com/slides/ja/python-java/aspose.slides/images/#fromFile) で画像を作成します。

スライドまたはシェイプをレンダリングするには [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) または [Shape.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) を使用します。複数のスライドをレンダリングするにはオプション付きの [Presentation.getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) を使用します。引数なしのオーバーロードはプレゼンテーションの画像コレクションを返します。

画像は [Images.fromFile](https://reference.aspose.com/slides/ja/python-java/aspose.slides/images/#fromFile) で読み込み、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/#addImage) で追加するか、[PPImage.replaceImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#replaceImage) で既存のプレゼンテーション画像を更新します。画像コレクションの操作はすべて [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) を受け取ります。

読み込んだりレンダリングした画像は `finally` ブロック内で `dispose` メソッドを呼び出して解放してください。プレゼンテーションは [Presentation.dispose](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#dispose) で解放します。

### **Python 環境の準備**

[Installation](/slides/ja/python-java/installation/) に記載の手順でパッケージをインストールします。各例では JVM を起動した後に `asposeslides` をインポートし、API をインポートします。例は JVM を終了せずに再利用できるようにしています。ノートブックと JVM のライフサイクルに関するガイダンスは [Limitations and API Differences](/slides/ja/python-java/limitations-and-api-differences/#import-the-library) を参照してください。

`pres.pptx` を開く例は作業ディレクトリにプレゼンテーションが必要です。`image.png` を読み込む例は既存の画像ファイルが必要です。

### **画像を読み込みスライドをレンダリングする**

この例は最初のスライドに画像を追加し、スライドを JPEG 画像として保存します。[IImage.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/#save) は指定した形式でレンダリング画像を書き出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **古いコードをモダン API に置き換える**

レガシーなサムネイル呼び出しを [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) を返すメソッドに置き換え、結果を [IImage.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/#save) で保存します。これにより [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) にレンダリング画像を渡す必要がなくなります。

### **指定サイズでスライドをレンダリングする**

レガシーな `slide.getThumbnail(image_size)` 呼び出しを同じ画像サイズで [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) に置き換えます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **スライドのサムネイルを取得する**

レガシーな `slide.getThumbnail()` 呼び出しを引数なしの [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) に置き換えます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **シェイプのサムネイルを取得する**

レガシーな `shape.getThumbnail()` 呼び出しを [Shape.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) に置き換えます。シェイプが存在することを確認してからアクセスしてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **プレゼンテーションのサムネイルを取得する**

レガシーな `presentation.getThumbnails(options, image_size)` 呼び出しを [Presentation.getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) に置き換えます。レンダリング設定は [RenderingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/) で構成します。

Python の `enumerate` を使用して返された配列を直接反復処理します。保存失敗時に残りの画像が解放されないよう、`finally` ブロックで返されたすべての画像を破棄してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **プレゼンテーションに画像を追加する**

[ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) の代わりに [Images.fromFile](https://reference.aspose.com/slides/ja/python-java/aspose.slides/images/#fromFile) を使用し、得られた画像を [ImageCollection.addImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/#addImage) に渡します。画像をスライドに追加し、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **非推奨メソッドとモダン API における置換**

テーブルは Python 呼び出し表記を使用しています。レガシー列の名前は削除された API を示し、リンクされた置換メソッドを使用してください。モダンな画像レンダリングメソッドは Java のバッファ画像ではなく [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) オブジェクトを返します。

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) はレンダリングオプション付きで呼び出すとレンダリングされた画像の配列を返します。

| Legacy call | Modern replacement |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) with `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) with `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) with `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) with `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) with `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) with `options, image_size` |

ここで `slides` は 1 ベースのスライド番号の Java `int[]` で、`jpype.JArray(jpype.JInt)([1, 3])` のように作成してスライド 1 と 3 を選択します。`image_size` は [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) です。

### **Shape**

| Legacy call | Modern replacement |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) with no arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) with `bounds, scale_x, scale_y` |

### **Slide**

| Legacy call | Modern replacement |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) with no arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) with `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) with `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) with `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) with `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) with `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) with `image_size` |
| `slide.renderToGraphics(options, graphics)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, image_size)` | No direct replacement; render to an image instead |

ここで `options` は [RenderingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/) 、`tiff_options` は [TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) です。

### **Output**

| Legacy call | Modern replacement |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/output/#add) with `path, image`, where `image` is [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Legacy call | Modern replacement |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/#addImage) with an [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) |

### **PPImage**

| Legacy call | Modern replacement |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#getImage) |

既存のプレゼンテーション画像の内容を置き換えるには、[PPImage.replaceImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#replaceImage) に [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) を渡してください。

### **PatternFormat**

| Legacy call | Modern replacement |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ja/python-java/aspose.slides/patternformat/#getTile) with `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/ja/python-java/aspose.slides/patternformat/#getTile) with `background, foreground` |

カラー引数は Java の [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) オブジェクトのままです。

### **PatternFormatEffectiveData**

Java API から JPype 経由で返される有効なパターン データに対しては、置換メソッド名は `getTileIImage` のままです。

| Legacy call | Modern replacement |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, returning [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) |

## **Graphics2D の API サポート**

レガシーの `renderToGraphics` オーバーロードは呼び出し元が提供した [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) コンテキストへ描画していました。モダン API にはそのコンテキストへ直接描画する置換はありません。

スライドをレンダリングするには [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) を、複数スライドをレンダリングするには [Presentation.getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) を使用し、返された画像を [IImage.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/#save) で保存します。スライドレンダリングとカスタム Java 描画を組み合わせていたアプリケーションは、合成ステップを適応する必要があります。

## **FAQ**

**なぜ古い Java 画像 API が置き換えられたのですか？**

モダン API は画像の読み込み、レンダリング、保存を [IImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/iimage/) に移行しました。これにより、ワークフローは Java のバッファ画像やグラフィックス コンテキストに依存せず、共通の画像抽象化を利用できます。

**まだ Java と JPype が必要ですか？**

はい。Aspose.Slides for Python via Java は JVM 上で動作します。モダン API は画像処理呼び出しを変更するだけで、実行環境の要件は変わりません。[System Requirements](/slides/ja/python-java/system-requirements/) を参照してください。

**Python で画像をどのように解放しますか？**

`finally` ブロック内で各画像の `dispose` を呼び出します。複数スライドをレンダリングした場合は、返された配列内のすべての画像を解放してください。プレゼンテーションは別途 [Presentation.dispose](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#dispose) で解放します。

**モダン API に切り替えてサムネイル生成が速くなる保証はありますか？**

性能向上が保証されるわけではありません。置換メソッドはレンダリングオプション、スケーリング、画像サイズをサポートしますので、実際のプレゼンテーションと出力設定で性能を測定してください。

**なぜ画像取得がコレクションを返すことがあるのですか？**

引数なしの [Presentation.getImages](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getImages) は埋め込みプレゼンテーション画像を返します。レンダリングオプション付きのオーバーロードはレンダリングされたスライド画像を返します。