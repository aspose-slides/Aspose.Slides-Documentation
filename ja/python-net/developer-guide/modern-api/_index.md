---
title: モダン APIで画像処理を強化する
linktitle: モダン API
type: docs
weight: 280
url: /ja/python-net/modern-api/
keywords:
- モダン API
- 描画
- スライドサムネイル
- スライドを画像に変換
- シェイプサムネイル
- シェイプを画像に変換
- プレゼンテーションサムネイル
- プレゼンテーションを画像に変換
- 画像を追加
- 画像を追加
- Python
- Aspose.Slides
description: "スライド画像処理を、廃止された画像 API を Python のモダン API に置き換えることで、PowerPoint と OpenDocument の自動化をシームレスに実現します。"
---

## **はじめに**

Aspose.Slides for Python のパブリック API は現在、次の `aspose.pydrawing` 型に依存しています:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

バージョン 24.4 以降、このパブリック API は **廃止** されています。理由は [変更](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) にあります。

`aspose.pydrawing` をパブリック API から除去するために、**モダン API** を導入しました。`aspose.pydrawing.Image` と `aspose.pydrawing.Bitmap` を使用するメソッドは廃止され、モダン API の同等メソッドに置き換えられます。`aspose.pydrawing.Graphics` を使用するメソッドも廃止され、パブリック API からのサポートが削除されます。

`aspose.pydrawing` に依存する廃止予定の API の削除は **24.8** リリースで計画されています。

## **モダン API**

パブリック API に以下のクラスと列挙型が追加されました:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — ラスターまたはベクター画像を表します。
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — 画像ファイル形式を表します。
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — `IImage` の作成と操作用メソッドを提供します。

新しい API の典型的な使用例は次のとおりです:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **古いコードをモダン API に置き換える**

移行を容易にするために、新しい `IImage` インターフェイスは `Image` と `Bitmap` クラスの別個 API を鏡像化しています。ほとんどの場合、`aspose.pydrawing` を使用するメソッド呼び出しをモダン API の同等メソッドに置き換えるだけで済みます。

### **スライドサムネイルの取得**

**廃止 API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**モダン API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **シェイプサムネイルの取得**

**廃止 API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**モダン API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **プレゼンテーションサムネイルの取得**

**廃止 API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**モダン API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **プレゼンテーションに画像を追加する**

**廃止 API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**モダン API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **削除されるメソッドとプロパティ及びそのモダン置換**

### **Presentation クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|完全に削除されます|
|save(fname, format, options, response, show_inline)|完全に削除されます|
|print()|完全に削除されます|
|print(printer_settings)|完全に削除されます|
|print(printer_name)|完全に削除されます|
|print(printer_settings, pres_name)|完全に削除されます|

### **Slide クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|完全に削除されます|
|render_to_graphics(options, graphics, scale_x, scale_y)|完全に削除されます|
|render_to_graphics(options, graphics, rendering_size)|完全に削除されます|

### **Shape クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage クラス**

|メソッド/プロパティシグネチャ|置換メソッド/プロパティシグネチャ|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output クラス**

|メソッドシグネチャ|置換メソッドシグネチャ|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **aspose.pydrawing.Graphics の API サポートは廃止されます**

`aspose.pydrawing.Graphics` を使用するメソッドは廃止され、パブリック API からのサポートが削除されます。

`aspose.pydrawing.Graphics` に依存する削除対象メンバーは次のとおりです:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **よくある質問**

**なぜ aspose.pydrawing.Graphics が廃止されたのですか？**

Graphics のサポートは、レンダリングと画像処理を統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) によるクロスプラットフォームアプローチに切り替えるために削除されます。Graphics 用のすべてのレンダリングメソッドが削除されます。

**IImage は Image/Bitmap と比較して実際にどんな利点がありますか？**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) はラスター画像とベクター画像の両方を統一的に扱い、[ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) を介した多様なフォーマットへの保存を簡素化し、pydrawing への依存を減らし、環境間でのコード移植性を高めます。

**モダン API はサムネイル生成のパフォーマンスに影響しますか？**

`get_thumbnail` から `get_image` への切り替えはシナリオを劣化させません。新しいメソッドはオプションやサイズ指定で同等の機能を提供し、レンダリングオプションのサポートも保持します。具体的な性能向上または低下はシナリオ次第ですが、機能的には同等です。