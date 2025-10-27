---
title: Python でプレゼンテーションに画像フレームを追加する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/python-net/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスタ画像
- ベクター画像
- 画像のクロップ
- クロップ領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- ralative スケール
- 画像エフェクト
- アスペクト比
- 画像の透過性
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを強化します。"
---

## **概要**

Aspose.Slides for Python の画像フレームは、ラスタ画像やベクター画像をスライド上のネイティブシェイプとして配置・管理できます。ファイルやストリームから画像を挿入し、正確な座標で位置付けやサイズ変更、回転、透過設定、他のシェイプと同様の Z 順序制御が可能です。API はクロップ、アスペクト比の維持、枠線やエフェクトの設定、レイアウトを再構築せずに画像の差し替えもサポートします。画像フレームは通常のシェイプと同様にアニメーション、ハイパーリンク、代替テキストを設定できるため、視覚的に豊かでアクセシブルなプレゼンテーションを簡単に構築できます。

## **画像フレームの作成**

このセクションでは、Aspose.Slides for Python を使用して [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成し、スライドに画像を挿入する方法を示します。画像の読み込み、スライド上への正確な配置、サイズと書式設定の制御を学びます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成します。この画像がシェイプのフィルに使用されます。  
4. フレームの幅と高さを指定します。  
5. [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドで同サイズの [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成します。  
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは画像フレームの作成方法を示しています。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成して PPTX ファイルを表します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得。
    slide = presentation.slides[0]

    # 画像をプレゼンテーションに追加。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像サイズに合わせた画像フレームを追加。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # PPTX として保存。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

画像フレームを使用すると、画像からプレゼンテーションスライドをすばやく作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像の形式変換時の I/O 操作を制御できます。以下のページも参考にしてください: 画像を [JPG に変換](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)；[JPG から画像に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)；[JPG から PNG に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)；[PNG から JPG に変換](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)；[PNG から SVG に変換](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)；[SVG から PNG に変換](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケールで画像フレームを作成する**

このセクションでは、固定サイズで画像を配置し、幅と高さに対してパーセンテージベースのスケールを個別に適用する方法を示します。パーセンテージが異なる場合、アスペクト比が変化します。スケーリングは画像の元の寸法に対して相対的に行われます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成。  
2. インデックスでスライドを取得。  
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成。  
4. スライドに [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加。  
5. 画像フレームの相対幅と高さを設定。  
6. PPTX ファイルとして保存。

以下の Python コードは相対スケーリング付き画像フレームの作成方法を示します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成して PPTX ファイルを表します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得。
    slide = presentation.slides[0]

    # プレゼンテーションの画像コレクションに画像を追加。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # スライドに画像フレームを追加。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 相対スケール幅と高さを設定。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # プレゼンテーションを保存。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は「sample.pptx」から画像を抽出し PNG 形式で保存する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **画像フレームから SVG 画像を抽出する**

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 内に配置されている場合、Aspose.Slides for Python via .NET は元のベクター画像を完全な fidelity で取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame] を特定し、基になる [PPImage] が SVG コンテンツを保持しているか確認して、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

以下のコード例は画像フレームから SVG 画像を抽出する方法を示します。

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

## **画像の透過性を取得する**

Aspose.Slides では、画像に適用された透過効果を取得できます。以下の Python コードはその操作例です。

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
画像に適用されたすべてのエフェクトは [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/) で確認できます。{{% /alert %}}

## **画像フレームの書式設定**

Aspose.Slides では、画像フレームに対して多数の書式設定オプションを適用できます。これらのオプションを使用して、特定の要件に合わせて画像フレームを調整できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成。  
2. インデックスでスライドを取得。  
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage] を作成。  
4. フレームの幅と高さを指定。  
5. スライドの [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドで同サイズの [PictureFrame] を作成。  
6. 画像フレームの線の色を設定。  
7. 画像フレームの線幅を設定。  
8. 正の値（時計回り）または負の値（反時計回り）で画像フレームを回転。  
9. 変更後のプレゼンテーションを PPTX として保存。

以下の Python コードは画像フレームの書式設定手順を示します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成して PPTX ファイルを表します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得。
    slide = presentation.slides[0]

    # プレゼンテーションの画像コレクションに画像を追加。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像サイズに合わせた画像フレームを追加。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 画像フレームに書式設定を適用。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # PPTX として保存。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose は無料の [Collage Maker](https://products.aspose.app/slides/collage) を提供しています。JPG/JPEG や PNG 画像の [結合](https://products.aspose.app/slides/collage/jpg) や、[フォトグリッド作成](https://products.aspose.app/slides/collage/photo-grid) が必要な場合にご利用ください。{{% /alert %}}

## **リンクとして画像を追加する**

プレゼンテーションファイルのサイズを小さく保つため、画像や動画を埋め込む代わりにリンクとして追加できます。以下の Python コードはプレースホルダーに画像と動画を挿入する例です。

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

## **画像のクロップ**

このセクションでは、画像フレーム内の画像の表示領域をソースファイルを変更せずにクロップする方法を学びます。スライド上でクリーンでフォーカスされた構図を作成するための基本的なクロップマージンの設定方法も解説します。

以下の Python コードはスライド上の画像をクロップする例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # プレゼンテーションの画像コレクションに画像を追加。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # スライドに画像フレームを追加。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 画像をクロップ（パーセンテージ値）。
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 結果を保存。
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **画像のクロップ領域を削除する**

フレーム内でクロップされた画像領域を削除したい場合は、[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドを使用します。このメソッドはクロップされた画像を返すか、クロップが不要な場合は元の画像を返します。

以下の Python コードはこの操作を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 最初のスライドから PictureFrame を取得。
    picture_frame = slides.shape[0]

    # クロップ領域を削除。
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 結果を保存。
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドはクロップされた画像をプレゼンテーションの画像コレクションに追加します。対象の [PictureFrame] のみで使用されている場合はプレゼンテーションサイズが縮小されますが、他のフレームでも使用されている場合は画像数が増える可能性があります。

クロップ処理中に、このメソッドは WMF/EMF メタファイルをラスタ PNG 画像に変換します。{{% /alert %}}

## **アスペクト比をロックする**

画像を含むシェイプのサイズ変更時にアスペクト比を保持したい場合は、[aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) プロパティを `True` に設定します。

以下の Python コードはシェイプのアスペクト比をロックする方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # リサイズ時にアスペクト比をロック。
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

この *アスペクト比ロック* 設定はシェイプ自体のアスペクト比のみを保持し、内部画像のアスペクト比は保持しません。{{% /alert %}}

## **Stretch Offset プロパティの使用**

[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) クラスの `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right`、`stretch_offset_bottom` プロパティを使用して、フィル矩形を定義できます。

画像のストレッチが指定されると、ソース矩形はフィル矩形に合わせて拡大縮小されます。フィル矩形の各辺はシェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義され、正の値はインセット、負の値はアウトセットを示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成。  
2. インデックスでスライド参照を取得。  
3. 長方形の [AutoShape] を追加。  
4. シェイプの塗りつぶしタイプを設定。  
5. シェイプの画像塗りつぶしモードを設定。  
6. 画像を読み込む。  
7. シェイプに画像を割り当てて塗りつぶす。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定。  
9. PPTX ファイルとして保存。

以下の Python コードは Stretch Offset プロパティの使用例です。

```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスをインスタンス化。
with slides.Presentation() as presentation:
    # 最初のスライドを取得。
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

    # シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX ファイルをディスクに保存。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose は無料のコンバータ―を提供しています — [JPEG から PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG から PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — これらを使えば画像から迅速にプレゼンテーションを作成できます。{{% /alert %}}

## **FAQ**

**画像フレームでサポートされている画像形式はどのように確認できますか？**

Aspose.Slides はラスタ画像 (PNG、JPEG、BMP、GIF など) とベクター画像 (例: SVG) の両方を、[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) に割り当てられる画像オブジェクトを通じてサポートします。サポート形式の一覧は、スライドおよび画像変換エンジンの機能と概ね一致しています。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスはどう変わりますか？**

画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加すればプレゼンテーションサイズは抑えられますが、外部ファイルへのアクセスが必要です。Aspose.Slides はリンクで画像を追加する機能を提供し、ファイルサイズ削減を支援します。

**画像オブジェクトの誤操作（移動/サイズ変更）を防ぐには？**

[shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) を使用して、[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) の移動やリサイズを無効化できます。ロック機構は別の記事「[プレゼンテーションへの保護の適用](/slides/ja/python-net/applying-protection-to-presentation/)」でも解説されており、さまざまなシェイプタイプで利用可能です。

**SVG ベクターの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) から元のベクター SVG を抽出できますが、PDF やラスタ形式へのエクスポート時はエクスポート設定に応じてラスタ化されることがあります。SVG がベクターとして保存されているかは抽出動作で確認できます。