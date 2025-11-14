---
title: Python Modern API で画像処理を強化する
linktitle: モダン API
type: docs
weight: 280
url: /ja/python-net/modern-api/
keywords:
- モダン API
- 描画
- スライド サムネイル
- スライドを画像に
- 図形サムネイル
- 図形を画像に
- プレゼンテーション サムネイル
- プレゼンテーションを画像に
- 画像を追加
- ピクチャを追加
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "廃止されたイメージング API を Python の Modern API に置き換えてスライドの画像処理をモダン化し、PowerPoint および OpenDocument の自動化をシームレスに行う方法をご紹介します。"
---

## はじめに

現在、Aspose.Slides for Python via .NETライブラリは、`aspose.pydrawing`の以下のクラスに依存しています：
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

バージョン24.4以降、この公開APIは、Aspose.Slides for .NETの公開APIにおける[変更](https://releases.aspose.com/slides/net/release-notes/2024/aspose-slides-for-net-24-4-release-notes/#introducing-a-new-modern-api)により非推奨とされています。

公開APIの`aspose.pydrawing`への依存を取り除くために、いわゆる「モダンAPI」を追加しました。`aspose.pydrawing.Image`および`aspose.pydrawing.Bitmap`を使用するメソッドは非推奨とされ、モダンAPIの対応するメソッドに置き換えられます。`aspose.pydrawing.Graphics`を使用するメソッドは非推奨となり、公開APIからそのサポートが削除されます。

`aspose.pydrawing`への依存を持つ非推奨の公開APIは、リリース24.8で削除される予定です。

## モダンAPI

以下のクラスと列挙型が公開APIに追加されました：

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage) - ラスタまたはベクター画像を表します。
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat) - 画像のファイル形式を表します。
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images) - `IImage`インターフェースをインスタンス化して操作するためのメソッド。

新しいAPIを使用する典型的なシナリオは次のようになります：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
    with pres.slides[0].get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## 古いコードをモダンAPIに置き換える

移行を容易にするために、新しい`IImage`インターフェースは`Image`および`Bitmap`クラスの個別のシグネチャを繰り返すようになっています。一般には、`aspose.pydrawing`を使用した古いメソッドの呼び出しを新しいものに置き換える必要があります。

### スライドのサムネイルを取得する

非推奨APIを使用したコード：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_thumbnail().save("slide1.png")
```

モダンAPI：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].get_image() as image:
        image.save("slide1.png")
```

### 形状のサムネイルを取得する

非推奨APIを使用したコード：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_thumbnail().save("shape.png")
```

モダンAPI：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].shapes[0].get_image() as image:
        image.save("shape.png")
```

### プレゼンテーションのサムネイルを取得する

非推奨APIを使用したコード：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", drawing.imaging.ImageFormat.png)
```

モダンAPI：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", slides.ImageFormat.PNG)
```

### プレゼンテーションに画像を追加する

非推奨APIを使用したコード：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = drawing.Image.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

モダンAPI：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

## 削除されるメソッド/プロパティとモダンAPIでの置き換え

### プレゼンテーションクラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
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

### スライドクラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|完全に削除されます|
|render_to_graphics(options, graphics, scale_x, scale_y)|完全に削除されます|
|render_to_graphics(options, graphics, rendering_size)|完全に削除されます|

### 形状クラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### ImageCollectionクラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### PPImageクラス
|メソッド/プロパティシグネチャ|置き換えメソッド/プロパティシグネチャ|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### ImageWrapperFactoryクラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### PatternFormatクラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### IPatternFormatEffectiveDataクラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### Outputクラス
|メソッドシグネチャ|置き換えメソッドシグネチャ|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## `aspose.pydrawing.Graphics`に対するAPIサポートは終了します

`aspose.pydrawing.Graphics`を使用するメソッドは非推奨とされ、公開APIからそのサポートが削除されます。

それを使用するAPIの部分は削除されます：
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`