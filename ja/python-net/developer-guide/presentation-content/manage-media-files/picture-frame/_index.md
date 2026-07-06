---
title: Python でプレゼンテーションにピクチャーフレームを追加する
linktitle: ピクチャーフレーム
type: docs
weight: 10
url: /ja/python-net/picture-frame/
keywords:
- ピクチャーフレーム
- ピクチャーフレームを追加
- ピクチャーフレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスター画像
- ベクター画像
- 画像をクロップ
- クロップ領域
- StretchOff プロパティ
- ピクチャーフレームの書式設定
- ピクチャーフレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透過性
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションにピクチャーフレームを追加します。ワークフローを効率化し、スライドデザインを強化します。"
---
## **はじめに**

Aspose.Slides for Python のピクチャーフレームは、ラスター画像とベクター画像をネイティブなスライド形状として配置および管理できます。ファイルまたはストリームから画像を挿入し、正確な座標で位置やサイズを変更し、回転を適用し、透過性を設定し、他の形状と同様に Z オーダーを制御できます。API はクロッピング、アスペクト比の維持、枠線や効果の設定、レイアウトを再構築せずに基になる画像を置き換えることもサポートします。ピクチャーフレームは通常の形状と同様に動作するため、アニメーション、ハイパーリンク、代替テキストを追加でき、視覚的に豊かでアクセシブルなプレゼンテーションの作成が容易になります。

## **ピクチャーフレームの作成**

このセクションでは、Aspose.Slides for Python を使用して [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) を作成し、スライドに画像を挿入する方法を示します。画像の読み込み、スライド上への正確な配置、サイズと書式の制御方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) を作成します。この画像が形状の塗りに使用されます。
4. フレームの幅と高さを指定します。
5. [add_picture_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドを使用して、指定したサイズの [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) を作成します。
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードはピクチャーフレームの作成方法を示しています:

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # プレゼンテーションに画像を追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像サイズのピクチャーフレームを追加します。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # プレゼンテーションを PPTX として保存します。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
ピクチャーフレームを使用すると、画像からプレゼンテーションスライドを素早く作成できます。ピクチャーフレームと Aspose.Slides の保存オプションを組み合わせることで、画像を別フォーマットに変換する I/O 操作を制御できます。次のページも参照してください: 変換 [image to JPG](https://products.aspose.com/slides/ja/python-net/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/ja/python-net/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/ja/python-net/conversion/jpg-to-png/); 変換 [PNG to JPG](https://products.aspose.com/slides/ja/python-net/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/ja/python-net/conversion/png-to-svg/); 変換 [SVG to PNG](https://products.aspose.com/slides/ja/python-net/conversion/svg-to-png/)。
{{% /alert %}}

## **相対スケールを使用したピクチャーフレームの作成**

このセクションでは、固定サイズで画像を配置し、幅と高さに対して独立したパーセンテージベースのスケーリングを適用する方法を示します。パーセンテージが異なる場合、アスペクト比が変化する可能性があります。スケーリングは画像の元のサイズに対して相対的に行われます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) を作成します。
4. スライドに [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) を追加します。
5. ピクチャーフレームの相対幅と相対高さを設定します。
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは相対スケーリング付きピクチャーフレームの作成方法を示しています:

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # プレゼンテーションの画像コレクションに画像を追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # スライドにピクチャーフレームを追加します。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 相対スケールの幅と高さを設定します。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # プレゼンテーションを保存します。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **ピクチャーフレームからラスター画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) オブジェクトからラスター画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **ピクチャーフレームから SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) 内に配置されている場合、Aspose.Slides for Python via .NET を使用して、元のベクター画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、必要に応じて SVG 形式でディスクまたはストリームに保存します。

以下のコード例は、ピクチャーフレームから SVG 画像を抽出する方法を示しています:

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

Aspose.Slides では、画像に適用された透明度効果を取得できます。以下の Python コードはその操作を示しています:

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
画像に適用されたすべての効果は [aspose.slides.effects](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/) で確認できます。
{{% /alert %}}

## **画像の明るさとコントラストを取得する**

Aspose.Slides では、画像に適用された明るさとコントラストの効果を取得できます。[Luminance](https://reference.aspose.com/slides/ja/python-net/aspose.slides.effects/luminance/) クラスがこの画像変換効果を表します。

以下の Python コードはピクチャーフレームから明るさとコントラストの設定を取得する方法を示しています:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **ピクチャーフレームの書式設定**

Aspose.Slides はピクチャーフレームに適用できる多数の書式設定オプションを提供しています。これらのオプションを使用すると、特定の要件を満たすようにピクチャーフレームを調整できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) を作成します。この画像が形状の塗りに使用されます。
4. フレームの幅と高さを指定します。
5. スライドの [add_picture_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドを使用して、指定したサイズの [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) を作成します。
6. ピクチャーフレームの線の色を設定します。
7. ピクチャーフレームの線の幅を設定します。
8. 正の値（時計回り）または負の値（反時計回り）を指定してピクチャーフレームを回転させます。
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードはピクチャーフレームの書式設定プロセスを示しています:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # プレゼンテーションの画像コレクションに画像を追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像サイズのピクチャーフレームを追加します。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # ピクチャーフレームに書式設定を適用します。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # プレゼンテーションを PPTX として保存します。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose が提供する無料の [Collage Maker](https://products.aspose.app/slides/ja/collage) を利用できます。JPG/JPEG または PNG 画像を [結合](https://products.aspose.app/slides/ja/collage/jpg) したり、[フォトグリッドを作成](https://products.aspose.app/slides/ja/collage/photo-grid) したりする場合に便利です。
{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションファイルのサイズを小さく保つために、画像や動画を埋め込むのではなくリンクとして追加できます。以下の Python コードはプレースホルダーに画像と動画を挿入する方法を示しています:

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

## **画像をクロップする**

このセクションでは、元のファイルを変更せずにピクチャーフレーム内の画像の表示領域をクロップする方法を学びます。また、クロップマージンを適用してスライド上でクリーンで焦点の合った構図を作成する基本的な手順も紹介します。

以下の Python コードはスライド上の画像をクロップする方法を示しています:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # プレゼンテーションの画像コレクションに画像を追加します。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # スライドにピクチャーフレームを追加します。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 画像をクロップします（パーセンテージ値）。
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 結果を保存します。
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **クロップされた画像領域を削除する**

フレーム内の画像のクロップ領域を削除したい場合は、[delete_picture_cropped_areas](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドを使用します。このメソッドはクロップされた画像を返し、クロップが不要な場合は元の画像を返します。

以下の Python コードはその操作を示しています:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 最初のスライドから PictureFrame を取得します。
    picture_frame = slides.shape[0]

    # 最初のスライドから PictureFrame を取得します。
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 結果を保存します。
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
[delete_picture_cropped_areas](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドはクロップされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) のみで使用されている場合、プレゼンテーションサイズが削減される可能性がありますが、そうでない場合は結果のプレゼンテーション内の画像数が増加することがあります。

クロップ処理中に、このメソッドは WMF/EMF メタファイルをラスター PNG 画像に変換します。
{{% /alert %}}

## **画像を圧縮する**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/compress_image/) メソッドを使用して、プレゼンテーション内の画像を圧縮できます。このメソッドは形状のサイズと指定した解像度に基づいて画像サイズを縮小し、必要に応じてクロップ領域を削除するオプションを提供します。

PowerPoint の **Picture Format → Compress Pictures → Resolution** 機能と同様に、画像のサイズと解像度を調整します。

以下の Python 例は、対象解像度を指定し、オプションでクロップ領域を削除して画像を圧縮する方法を示しています:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 画像を目標解像度 150 DPI（Web 解像度）で圧縮し、クロップされた領域を削除します。
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # 圧縮の結果を確認します。
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

またはカスタム DPI 値を直接指定する方法:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 画像を 150 DPI（ウェブ解像度）に圧縮し、クロップされた領域を削除します。
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
このメソッドは、形状のサイズと指定された DPI に基づいて画像を低解像度に変換します。クロップ領域も削除でき、ファイルサイズの最適化が可能です。画像がメタファイル（WMF/EMF）または SVG の場合、圧縮は適用されません。また、JPEG の品質は解像度に応じて維持またはわずかに低下します（PowerPoint の高解像度 JPEG 処理と同様）。
{{% /alert %}}

## **アスペクト比をロックする**

画像のサイズを変更した後でも、画像を含む形状がアスペクト比を保持するようにするには、[aspect_ratio_locked](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) プロパティを `True` に設定します。

以下の Python コードは形状のアスペクト比をロックする方法を示しています:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # サイズ変更時にアスペクト比をロックします。
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
この *Lock Aspect Ratio* 設定は形状自体のアスペクト比のみを保持し、内部の画像のアスペクト比は保持しません。
{{% /alert %}}

## **Stretch Offset プロパティを使用する**

[PictureFillFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/) クラスの `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right`、`stretch_offset_bottom` プロパティを使用して、塗り矩形を定義できます。

画像のストレッチが指定されると、ソース矩形は塗り矩形に合わせて拡大縮小されます。塗り矩形の各辺は、形状のバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. 形状の塗りタイプを設定します。
5. 形状の画像塗りモードを設定します。
6. 画像をロードします。
7. 画像を形状の塗りに割り当てます。
8. 形状のバウンディングボックスの対応する辺からの画像オフセットを指定します。
9. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは Stretch Offset プロパティの使用方法を示しています:

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # 四角形の AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # 形状の塗りタイプを設定します。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 形状の画像塗りモードを設定します。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 画像を読み込み、プレゼンテーションに追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # 画像を形状の塗りに割り当てます。
    shape.fill_format.picture_fill_format.picture.image = image

    # 形状のバウンディングボックスの対応する辺からの画像オフセットを指定します。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX ファイルをディスクに保存します。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose は無料のコンバータを提供しています — [JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) および [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) — これらを使用すれば画像から迅速にプレゼンテーションを作成できます。
{{% /alert %}}

## **FAQ**

**PictureFrame でサポートされている画像形式はどれですか？**

Aspose.Slides は、ラスター画像 (PNG、JPEG、BMP、GIF など) とベクター画像 (例: SVG) の両方を、[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じてサポートします。サポートされる形式の一覧は、スライドおよび画像変換エンジンの機能と概ね一致します。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加すればプレゼンテーションのサイズは抑えられますが、外部ファイルへのアクセスが必要です。Aspose.Slides はリンクによる画像追加機能を提供し、ファイルサイズ削減を支援します。

**画像オブジェクトを誤って移動・サイズ変更しないようにロックするには？**

[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/picture_frame_lock/) を使用します (例: 移動やサイズ変更を無効化)。ロック機構は別の記事 **[protection article](/slides/ja/python-net/applying-protection-to-presentation/)** で説明されており、[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) を含むさまざまな形状タイプでサポートされています。

**SVG ベクターの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) から SVG を元のベクターとして抽出できます。[PDF にエクスポート](/slides/ja/python-net/convert-powerpoint-to-pdf/) や [ラスター形式にエクスポート](/slides/ja/python-net/convert-powerpoint-to-png/) する際、エクスポート設定に応じてラスタライズされる可能性がありますが、抽出動作により元の SVG がベクターとして保持されていることが確認できます。