---
title: プレゼンテーションに画像枠を追加（Python）
linktitle: 画像枠
type: docs
weight: 10
url: /ja/python-net/developer-guide/presentation-content/manage-media-files/picture-frame/
keywords:
- 画像枠
- 画像枠を追加
- 画像枠を作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスター画像
- ベクター画像
- 画像をトリミング
- トリミング領域
- StretchOff プロパティ
- 画像枠の書式設定
- 画像枠のプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像枠を追加します。ワークフローを効率化し、スライドデザインを向上させます。"
---

## **概要**

Aspose.Slides for Python の画像枠を使用すると、ラスター画像やベクター画像をスライドのネイティブシェイプとして配置・管理できます。ファイルまたはストリームから画像を挿入し、正確な座標で位置合わせやサイズ変更、回転、透明度設定、他のシェイプとの Z オーダー制御が可能です。API はトリミング、アスペクト比の保持、枠線やエフェクトの設定、レイアウトを再構築せずに基になる画像を置き換える機能もサポートしています。画像枠は通常のシェイプと同様に扱えるため、アニメーションやハイパーリンク、代替テキストの追加が容易で、視覚的に豊かでアクセシブルなプレゼンテーションの作成が簡単になります。

## **画像枠の作成**

このセクションでは、Aspose.Slides for Python で [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成し、スライドに画像を挿入する方法を示します。画像の読み込み、スライド上への正確な配置、サイズと書式の制御を学びます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. 画像をプレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成します。この画像がシェイプのフィルとして使用されます。  
4. 枠の幅と高さを指定します。  
5. [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドを使用して、指定サイズの [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成します。  
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは画像枠の作成例です。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを生成し、PPTX ファイルを表します。
with slides.Presentation() as presentation:
    # 1 番目のスライドを取得。
    slide = presentation.slides[0]

    # 画像をプレゼンテーションに追加。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像サイズに合わせた画像枠を追加。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # PPTX として保存。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

画像枠を使用すると、画像から迅速にスライドを作成できます。Aspose.Slides の保存オプションと組み合わせることで、画像形式の変換時の I/O 操作を制御できます。以下のページも参照してください: 画像を [JPG に変換](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)；[JPG から画像に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)；[JPG から PNG に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)；[PNG から JPG に変換](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)；[PNG から SVG に変換](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)；[SVG から PNG に変換](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケールを使用した画像枠の作成**

このセクションでは、固定サイズで画像を配置し、その後幅と高さに対して独立したパーセンテージベースのスケーリングを適用する方法を示します。パーセンテージが異なる場合、アスペクト比が変わることがあります。スケーリングは画像の元サイズを基準に行われます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. 画像をプレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成します。  
4. スライドに [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加します。  
5. 画像枠の相対幅と高さを設定します。  
6. PPTX として保存します。

以下の Python コードは相対スケーリング付き画像枠の作成例です。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを生成し、PPTX ファイルを表します。
with slides.Presentation() as presentation:
    # 1 番目のスライドを取得。
    slide = presentation.slides[0]

    # 画像コレクションに画像を追加。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # スライドに画像枠を追加。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 相対スケール幅と高さを設定。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # プレゼンテーションを保存。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **画像枠からラスター画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコードは「sample.pptx」から画像を抽出し PNG 形式で保存する例です。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **画像枠から SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが画像枠に配置されている場合、Aspose.Slides for Python via .NET を使用して元のベクター画像を完全に取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存します。

以下のコードは画像枠から SVG 画像を抽出する例です。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **画像の透明度を取得する**

Aspose.Slides では画像に適用された透明度効果を取得できます。以下の Python コードはその操作例です。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
画像に適用されたすべての効果は [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/) で確認できます。  
{{% /alert %}}

## **画像枠の書式設定**

Aspose.Slides は画像枠に対して多彩な書式設定オプションを提供します。これらのオプションを使用して、画像枠を特定の要件に合わせて調整できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. 画像をプレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に追加し、[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成します。  
4. 枠の幅と高さを指定します。  
5. スライドの [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドで同サイズの [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成します。  
6. 画像枠の線色を設定します。  
7. 画像枠の線幅を設定します。  
8. 正の値（時計回り）または負の値（反時計回り）で画像枠を回転させます。  
9. 修正後のプレゼンテーションを PPTX として保存します。

以下の Python コードは画像枠の書式設定プロセスを示しています。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを生成し、PPTX ファイルを表します。
with slides.Presentation() as presentation:
    # 1 番目のスライドを取得。
    slide = presentation.slides[0]

    # 画像コレクションに画像を追加。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像サイズに合わせた画像枠を追加。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 画像枠に書式設定を適用。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # PPTX として保存。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose が提供する無料の [Collage Maker](https://products.aspose.app/slides/collage) を利用できます。JPG/JPEG や PNG 画像を結合したり、フォトグリッドを作成したりしたい場合に便利です。  
{{% /alert %}}

## **リンクとして画像を追加する**

プレゼンテーションファイルのサイズを小さく保つために、画像やビデオを埋め込むのではなくリンクとして追加できます。以下の Python コードはプレースホルダーに画像とビデオを挿入する例です。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **画像のトリミング**

このセクションでは、画像枠内の画像の表示領域をソースファイルを変更せずにトリミングする方法を学びます。また、トリミングマージンを適用してスライド上にクリーンで焦点の合った構図を作成する基本的な手順も紹介します。

以下の Python コードはスライド上の画像をトリミングする例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 画像をプレゼンテーションの画像コレクションに追加。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # スライドに画像枠を追加。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 画像をトリミング（パーセンテージ値）。
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 結果を保存。
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **トリミング領域を削除する**

画像枠内でトリミングされた領域を削除したい場合は、[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドを使用します。このメソッドはトリミングされた画像、またはトリミングが不要な場合は元画像を返します。

以下のコードはその操作例です。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 最初のスライドから PictureFrame を取得。
    picture_frame = slides.shape[0]

    # トリミング領域を削除。
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 結果を保存。
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。対象の [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) のみで使用されている場合はプレゼンテーションサイズの削減につながりますが、他のスライドでも使用されている場合は画像数が増える可能性があります。

トリミング時にこのメソッドは WMF/EMF メタファイルをラスター PNG 画像に変換します。  
{{% /alert %}}

## **アスペクト比の固定**

画像のサイズを変更した後でも、画像を含むシェイプのアスペクト比を保持したい場合は、[aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) プロパティを `True` に設定します。

以下のコードはシェイプのアスペクト比を固定する例です。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # サイズ変更時にアスペクト比をロック。
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

この *アスペクト比ロック* 設定はシェイプ全体の比率のみを保持し、シェイプ内部の画像の比率は保持しません。  
{{% /alert %}}

## **Stretch Offset プロパティの使用**

[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) クラスの `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right`, `stretch_offset_bottom` プロパティを使用して、塗りつぶし矩形を定義できます。

画像のストレッチが指定されると、ソース矩形が塗りつぶし矩形に合わせて拡大縮小されます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで決まります。正のパーセンテージはインセット、負のパーセンテージはアウトセットを意味します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成。  
2. インデックスでスライドへの参照を取得。  
3. 長方形の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加。  
4. シェイプの塗りつぶしタイプを設定。  
5. シェイプの画像塗りつぶしモードを設定。  
6. 画像を読み込み。  
7. 画像をシェイプの塗りつぶしに割り当て。  
8. 画像のオフセットをシェイプのバウンディングボックスの対応辺から指定。  
9. PPTX として保存。

以下のコードは Stretch Offset プロパティの使用例です。

```py
import aspose.slides as slides

# Presentation クラスのインスタンス（PPTX ファイルを表す）を生成。
with slides.Presentation() as presentation:
    # 1 番目のスライドを取得。
    slide = presentation.slides[0]

    # 長方形 AutoShape を追加。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # シェイプの塗りつぶしタイプを設定。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # シェイプの画像塗りつぶしモードを設定。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 画像を読み込み、プレゼンテーションに追加。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # 画像をシェイプの塗りつぶしに割り当て。
    shape.fill_format.picture_fill_format.picture.image = image

    # シェイプのバウンディングボックスの対応辺から画像オフセットを指定。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX ファイルをディスクに保存。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose が提供する無料コンバータ — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — を利用すれば、画像からすばやくプレゼンテーションを作成できます。  
{{% /alert %}}

## **FAQ**

**画像枠でサポートされている画像形式はどのように確認できますか？**

Aspose.Slides はラスター画像（PNG、JPEG、BMP、GIF など）とベクター画像（例: SVG）を、[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じてサポートします。サポート形式の一覧は、スライドおよび画像変換エンジンの機能と概ね一致しています。

**多数の大サイズ画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？**

画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加すればプレゼンテーションのサイズは抑えられますが、外部ファイルへのアクセスが必要です。Aspose.Slides はリンクで画像を追加する機能を提供しており、ファイルサイズ削減に役立ちます。

**画像オブジェクトを誤って移動・サイズ変更しないようにロックするには？**

[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) を使用します（例: 移動やサイズ変更の無効化）。ロック機構は別記事の [保護の適用](/slides/ja/python-net/applying-protection-to-presentation/) に記載されており、さまざまなシェイプタイプ（画像枠を含む）でサポートされています。

**SVG ベクターの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) から元のベクター SVG を抽出できます。PDF へエクスポートする場合やラスター形式へ変換する場合は、エクスポート設定に応じてラスター化されることがありますが、元の SVG がベクターとして保存されていることは抽出動作で確認できます。