---
title: Pythonでプレゼンテーションに画像フレームを追加する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/python-net/picture-frame/
keywords:
- 画像フレーム
- 画像フレームを追加
- 画像フレームを作成
- 画像を追加
- 画像を作成
- 画像を抽出
- ラスタ画像
- ベクタ画像
- 画像をトリミング
- トリミング領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 相対スケール
- 画像エフェクト
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---

## **概要**

Aspose.Slides for Python の画像フレームを使用すると、ラスタ画像とベクタ画像をネイティブ スライド シェイプとして配置および管理できます。ファイルまたはストリームから画像を挿入し、正確な座標で位置合わせとサイズ変更を行い、回転を適用し、透明度を設定し、他のシェイプと同様に Z オーダーを制御できます。API は画像のトリミング、アスペクト比の維持、枠線や効果の設定、レイアウトを再構築せずに基になる画像を置き換えることもサポートします。画像フレームは通常のシェイプと同様に動作するため、アニメーション、ハイパーリンク、代替テキストを追加でき、視覚的にリッチでアクセシブルなプレゼンテーションを簡単に作成できます。

## **画像フレームの作成**

このセクションでは、Aspose.Slides for Python で [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成してスライドに画像を挿入する方法を示します。画像の読み込み、スライド上への正確な配置、サイズと書式の制御を学びます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成します。この画像がシェイプのフィルに使用されます。  
4. フレームの幅と高さを指定します。  
5. [add_picture_frame](httpshttps://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドを使用してそのサイズの [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成します。  
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは画像フレームの作成方法を示しています:
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # 画像をプレゼンテーションに追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像と同サイズの画像フレームを追加します。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # プレゼンテーションを PPTX として保存します。
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" %}}
画像フレームを使用すると、画像からプレゼンテーション スライドをすばやく作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせると、画像の形式変換の I/O 操作を制御できます。次のページも参考にしてください: 画像を JPG に変換([image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)); JPG を画像に変換([JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)); JPG を PNG に変換([JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)); PNG を JPG に変換([PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)); PNG を SVG に変換([PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)); SVG を PNG に変換([SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)).
{{% /alert %}}

## **相対スケールで画像フレームを作成する**

このセクションでは、固定サイズで画像を配置し、幅と高さに対してパーセンテージ ベースのスケーリングを個別に適用する方法を示します。パーセンテージが異なる場合、アスペクト比が変化します。スケーリングは画像の元の寸法に対して相対的に行われます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成します。  
4. スライドに [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加します。  
5. 画像フレームの相対的な幅と高さを設定します。  
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは相対スケーリング付き画像フレームの作成方法を示しています:
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # 画像をプレゼンテーションの画像コレクションに追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # スライドに画像フレームを追加します。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 相対スケールの幅と高さを設定します。
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # プレゼンテーションを保存します。
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```


## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、ドキュメント「sample.pptx」から画像を抽出し、PNG 形式で保存する方法を示しています。
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

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Python via .NET を使用して元のベクタ画像をフル フィデリティで取得できます。スライドのシェイプコレクションを走査し、各 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を特定し、基になる [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) が SVG コンテンツを保持しているか確認し、ネイティブ SVG 形式でディスクまたはストリームに保存します。

以下のコード例は画像フレームから SVG 画像を抽出する方法を示しています:
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

Aspose.Slides は画像に適用された透明度エフェクトを取得できます。この Python コードはその操作を示しています:
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
画像に適用されたすべてのエフェクトは [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/) で確認できます。
{{% /alert %}}

## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、特定の要件に合わせて画像フレームを調整できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成します。この画像がシェイプのフィルに使用されます。  
4. フレームの幅と高さを指定します。  
5. スライドの [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドを使用してそのサイズの [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成します。  
6. 画像フレームの線色を設定します。  
7. 画像フレームの線幅を設定します。  
8. 正の値（時計回り）または負の値（反時計回り）を指定して画像フレームを回転させます。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは画像フレームの書式設定プロセスを示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # 画像をプレゼンテーションの画像コレクションに追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # 画像と同サイズの画像フレームを追加します。
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # 画像フレームに書式設定を適用します。
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # プレゼンテーションを PPTX として保存します。
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Tip" color="primary" %}}
Aspose は無料の [Collage Maker](https://products.aspose.app/slides/collage) を提供しています。JPG/JPEG または PNG 画像を結合したり、フォトグリッドを作成したりする場合はこのサービスをご利用ください。
{{% /alert %}}

## **リンクとして画像を追加する**

プレゼンテーション ファイルのサイズを小さく保つために、画像やビデオを埋め込む代わりにリンクとして追加できます。以下の Python コードはプレースホルダーに画像とビデオを挿入する方法を示しています:
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

このセクションでは、画像フレーム内の画像の表示領域をソース ファイルを変更せずにトリミングする方法を学びます。また、トリミング マージンを適用してスライド上でクリーンでフォーカスされた構図を作成する基本的な方法も学びます。

以下の Python コードはスライド上の画像をトリミングする方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 画像をプレゼンテーションの画像コレクションに追加します。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # スライドに画像フレームを追加します。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # 画像をトリミングします（パーセンテージ値）。
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # 結果を保存します。
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```


## **トリミング領域を削除する**

フレーム内の画像のトリミング領域を削除したい場合は、[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドを使用します。このメソッドはトリミングされた画像を返すか、トリミングが不要な場合は元の画像を返します。

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
[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) のみで使用されている場合、プレゼンテーションのサイズを削減できますが、複数の場所で使用されている場合は画像数が増える可能性があります。

トリミング中に、このメソッドは WMF/EMF メタファイルをラスタ PNG 画像に変換します。
{{% /alert %}}

## **アスペクト比をロックする**

画像のサイズを変更した後も形状のアスペクト比を保持したい場合は、[aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) プロパティを `True` に設定します。

以下の Python コードは形状のアスペクト比をロックする方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # リサイズ時にアスペクト比をロックします。
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
この *Lock Aspect Ratio* 設定はシェイプ自体のアスペクト比だけを保持し、内部の画像のアスペクト比は保持しません。
{{% /alert %}}

## **ストレッチオフセット プロパティを使用する**

[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) クラスの `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right`、`stretch_offset_bottom` プロパティを使用すると、フィル矩形を定義できます。

画像に対してストレッチが指定されると、ソース矩形はフィル矩形に合わせて拡大縮小されます。フィル矩形の各辺はシェイプのバウンディング ボックスの対応する辺からのパーセンテージ オフセットで定義されます。正のパーセンテージはインセット、負のパーセンテージはアウトセットを表します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. 長方形の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
4. シェイプの塗りつぶしタイプを設定します。  
5. シェイプの画像塗りつぶしモードを設定します。  
6. 画像をロードします。  
7. 画像をシェイプのフィルとして割り当てます。  
8. シェイプのバウンディング ボックスの対応する辺からの画像オフセットを指定します。  
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

    # シェイプの塗りつぶしタイプを設定します。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # シェイプの画像塗りつぶしモードを設定します。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 画像を読み込み、プレゼンテーションに追加します。
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # シェイプの塗りつぶしに画像を割り当てます。
    shape.fill_format.picture_fill_format.picture.image = image

    # シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX ファイルをディスクに保存します。
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert  title="Tip" color="primary" %}}
Aspose は無料のコンバータ―を提供しています—[JPEG を PowerPoint に変換](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG を PowerPoint に変換](https://products.aspose.app/slides/import/png-to-ppt) —これにより画像からプレゼンテーションをすばやく作成できます。
{{% /alert %}}

## **FAQ**

**画像フレームでサポートされている画像形式はどのように確認できますか？**

Aspose.Slides はラスタ画像 (PNG、JPEG、BMP、GIF など) とベクタ画像 (例: SVG) の両方を、[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) に割り当てられた画像オブジェクトを通じてサポートします。サポートされている形式の一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズとパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイル サイズとメモリ使用量が増加します。画像をリンクとして追加するとプレゼンテーションのサイズを抑えられますが、外部ファイルが利用可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供してファイル サイズ削減を支援します。

**画像オブジェクトが誤って移動/サイズ変更されないようにロックするには？**

[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 用の [shape locks](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) を使用します (例: 移動やサイズ変更を無効化)。ロック機構は別記事の [protection article](/slides/ja/python-net/applying-protection-to-presentation/) に記載されており、さまざまなシェイプタイプでサポートされています。

**SVG ベクタの忠実度は PDF/画像へのエクスポート時に保持されますか？**

Aspose.Slides は [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) から元のベクタとして SVG を抽出できます。[PDF にエクスポート](/slides/ja/python-net/convert-powerpoint-to-pdf/) や [ラスタ形式にエクスポート](/slides/ja/python-net/convert-powerpoint-to-png/) する際、エクスポート設定によりラスタ化されることがありますが、抽出時にベクタとして保持されていることが確認できます。