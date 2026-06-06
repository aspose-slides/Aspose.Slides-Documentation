---
title: モダン API を使用した画像処理の強化
linktitle: モダン API
type: docs
weight: 280
url: /ja/python-net/modern-api/
keywords:
- モダン API
- 描画
- スライド サムネイル
- スライドから画像へ
- シェイプ サムネイル
- シェイプから画像へ
- プレゼンテーション サムネイル
- プレゼンテーションから画像へ
- 画像を追加
- 画像を挿入
- Python
- Aspose.Slides
description: "非推奨の画像 API を Python のモダン API に置き換えて、スライド画像処理を最新化し、PowerPoint および OpenDocument の自動化をシームレスに行えるようにします。"
---
## **導入**

Aspose.Slides for Python のパブリック API は現在、以下の `aspose.pydrawing` 型に依存しています。

- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

バージョン 24.4 以降、このパブリック API は Aspose.Slides for Python のパブリック API における [変更](https://releases.aspose.com/slides/ja/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) により **非推奨** となりました。

パブリック API から `aspose.pydrawing` を排除するため、**Modern API** を導入しました。`aspose.pydrawing.Image` と `aspose.pydrawing.Bitmap` を使用するメソッドは非推奨となり、Modern API の同等メソッドに置き換える必要があります。`aspose.pydrawing.Graphics` を使用するメソッドは非推奨で、直接的な Modern API の置き換えはありません。

現在のバージョンでは、`aspose.pydrawing` に依存するパブリック API をレガシー/非推奨として扱ってください。新規コードや既存の画像処理ワークフローの移行時には Modern API を使用してください。

## **Modern API**

パブリック API に以下のクラスと列挙型が追加されました。

- [aspose.slides.IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) - ラスターまたはベクター画像を表します。
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imageformat/) - 画像ファイル形式を表します。
- [aspose.slides.Images](https://reference.aspose.com/slides/ja/python-net/aspose.slides/images/) - IImage を作成および操作するためのメソッドを提供します。

単一のスライドまたはシェイプをレンダリングするには `get_image` を使用します。複数のプレゼンテーションスライドをレンダリングするには `get_images` を使用します。画像をロードするには [Images](https://reference.aspose.com/slides/ja/python-net/aspose.slides/images/) のメソッドを使用し、プレゼンテーションに画像を追加するには `add_image` と [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) を、既存のプレゼンテーション画像を更新するには `replace_image` と [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) を使用します。

新しい API の典型的な使用シナリオは以下のようになります。

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

## **古いコードを Modern API に置き換える**

移行を容易にするために、新しい [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) クラスは `aspose.pydrawing.Image` と `aspose.pydrawing.Bitmap` の個別 API を鏡像しています。ほとんどの場合、`aspose.pydrawing` を使用するメソッド呼び出しを Modern API の同等メソッドに置き換えるだけで済みます。

### **スライドのサムネイル取得**

**非推奨 API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **シェイプのサムネイル取得**

**非推奨 API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **プレゼンテーションのサムネイル取得**

**非推奨 API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **プレゼンテーションに画像を追加する**

**非推奨 API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **削除されるメソッドとプロパティ、およびその Modern 置換**

### **Presentation クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Slide クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Shape クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage クラス**

|メソッド/プロパティ シグネチャ|置換メソッド/プロパティ シグネチャ|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output クラス**

|メソッド シグネチャ|置換メソッド シグネチャ|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **aspose.pydrawing.Graphics の API サポート**

`aspose.pydrawing.Graphics` を使用するメソッドは非推奨で、直接的な Modern API の置き換えはありません。

`aspose.pydrawing.Graphics` にレンダリングする API の代わりに、Modern API の画像レンダリングメソッドを使用してください。

- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**なぜ `aspose.pydrawing.Graphics` が削除されたのですか？**

`aspose.pydrawing.Graphics` のサポートは、レンダリングと画像の処理を統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) を使用したクロスプラットフォームアプローチに切り替えるため、パブリック API で非推奨とされています。`aspose.pydrawing.Graphics` へレンダリングする代わりに `get_image` または `get_images` を使用してください。

**[IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) は `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap` と比べて実用的にどんなメリットがありますか？**

[IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) はラスタ画像とベクトル画像の両方の取り扱いを統一し、[ImageFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imageformat/) を通じてさまざまな形式への保存を簡素化し、pydrawing への依存を減らし、環境間でコードをよりポータブルにします。

**Modern API はサムネイル生成のパフォーマンスに影響しますか？**

`get_thumbnail` から `get_image` への切り替えは性能を低下させません。新しいメソッドはオプションやサイズ指定で画像を生成する同等の機能を提供し、レンダリングオプションのサポートも維持しています。具体的な利得や低下はシナリオに依存しますが、機能的には置き換えは等価です。