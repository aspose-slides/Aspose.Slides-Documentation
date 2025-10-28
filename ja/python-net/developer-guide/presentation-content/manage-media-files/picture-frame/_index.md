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
- ラスター画像
- ベクトル画像
- 画像をトリミング
- トリミング領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透過性
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドのデザインを向上させます。"
---

## **概要**

Python 用 Aspose.Slides の画像フレームを使用すると、ラスター画像やベクトル画像をスライド上のネイティブシェイプとして配置・管理できます。ファイルまたはストリームから画像を挿入し、正確な座標で位置とサイズを指定し、回転や透過性の設定、他のシェイプと同様に Z 順序を制御できます。API はトリミング、アスペクト比の維持、枠線や効果の設定、レイアウトを再構築せずに基になる画像の置き換えもサポートします。画像フレームは通常のシェイプと同様に動作するため、アニメーション、ハイパーリンク、代替テキストを追加でき、視覚的に豊かでアクセシブルなプレゼンテーションの構築が容易になります。

## **画像フレームの作成**

このセクションでは、Aspose.Slides for Python を使用して [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成し、画像をスライドに挿入する方法を示します。画像の読み込み、スライド上への正確な配置、サイズと書式設定の制御方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成し、プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加します。この画像はシェイプのフィルに使用されます。  
4. フレームの幅と高さを指定します。  
5. [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドを使用して、そのサイズの [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成します。  
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは画像フレームの作成方法を示しています。

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Save the presentation as PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

画像フレームを使用すると、画像からプレゼンテーションスライドを迅速に作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、画像のフォーマット変換など I/O 操作を制御できます。以下のページもご覧ください: 画像を JPG に変換[image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); JPG を画像に変換[image to JPG](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); JPG を PNG に変換[image to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); PNG を JPG に変換[image to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); PNG を SVG に変換[image to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); SVG を PNG に変換[image to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケールを使用した画像フレームの作成**

このセクションでは、画像を固定サイズで配置し、幅と高さに対してパーセンテージベースのスケーリングを個別に適用する方法を示します。パーセンテージが異なる場合、アスペクト比が変化することがあります。スケーリングは画像の元の寸法を基準に行われます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成し、プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加します。  
4. スライドに [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を追加します。  
5. 画像フレームの相対的な幅と高さを設定します。  
6. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは相対スケーリングを使用した画像フレームの作成方法を示しています。

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame to the slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Set the relative scale width and height.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Save the presentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **画像フレームからラスタ画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) オブジェクトからラスタ画像を抽出し、PNG、JPG などの形式で保存できます。以下のコード例は、"sample.pptx" から画像を抽出し PNG 形式で保存する方法を示しています。

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

プレゼンテーションに SVG グラフィックが [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) シェイプ内に配置されている場合、Aspose.Slides for Python via .NET を使用して、元のベクトル画像を完全な忠実度で取得できます。スライドのシェイプコレクションを走査して各 [PictureFrame] を特定し、基になる [PPImage] が SVG コンテンツかどうかを確認し、ネイティブ SVG 形式でディスクまたはストリームに保存できます。

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

Aspose.Slides を使用すると、画像に適用された透過効果を取得できます。以下の Python コードはその操作を示しています。

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
画像に適用されたすべての効果は [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/) にあります。{{% /alert %}}

## **画像フレームの書式設定**

Aspose.Slides は画像フレームに適用できる多数の書式設定オプションを提供します。これらのオプションを使用して、画像フレームを特定の要件に合わせて調整できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を作成し、プレゼンテーションの [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) に画像を追加します。この画像はシェイプのフィルに使用されます。  
4. フレームの幅と高さを指定します。  
5. [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッドを使用して、そのサイズの [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を作成します。  
6. 画像フレームの線の色を設定します。  
7. 画像フレームの線幅を設定します。  
8. 正の値（時計回り）または負の値（反時計回り）で画像フレームを回転させます。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Apply formatting to the picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Save the presentation as PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose は無料の [Collage Maker](https://products.aspose.app/slides/collage) を提供しています。JPG/JPEG や PNG 画像を結合したり、フォトグリッドを作成したりする場合は、このサービスをご利用ください。{{% /alert %}}

## **画像をリンクとして追加する**

プレゼンテーションファイルのサイズを小さく保つために、画像や動画を直接埋め込むのではなく、リンクとして追加できます。以下の Python コードは、プレースホルダーに画像と動画を挿入する方法を示しています。

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

このセクションでは、画像フレーム内の画像の表示領域をソースファイルを変更せずにトリミングする方法を学びます。また、トリミングマージンを適用してスライド上でクリーンで焦点の合った構図を作成する基本的な方法も学びます。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Add a picture frame to the slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Crop the image (percentage values).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Save the result.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **画像のトリミング領域を削除する**

フレーム内の画像のトリミング領域を削除したい場合は、delete_picture_cropped_areas メソッドを使用します。このメソッドはトリミングされた画像を返し、トリミングが不要な場合は元の画像を返します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get the PictureFrame from the first slide.
    picture_frame = slides.shape[0]

    # Get the PictureFrame from the first slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Save the result.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

delete_picture_cropped_areas メソッドはトリミングされた画像をプレゼンテーションの画像コレクションに追加します。画像が処理された [PictureFrame] のみで使用されている場合、プレゼンテーションサイズが削減される可能性がありますが、そうでない場合は結果のプレゼンテーションの画像数が増加することがあります。

トリミング中に、このメソッドは WMF/EMF メタファイルをラスタ PNG 画像に変換します。{{% /alert %}}

## **アスペクト比のロック**

画像を含むシェイプのサイズを変更した後もアスペクト比を保持したい場合は、aspect_ratio_locked プロパティを `True` に設定します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lock the aspect ratio when resizing.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

この *Lock Aspect Ratio* 設定はシェイプ自体のアスペクト比のみを保持し、内部の画像のアスペクト比は保持しません。{{% /alert %}}

## **Stretch Offset プロパティの使用**

[PictureFillFormat] クラスの `stretch_offset_left`、`stretch_offset_top`、`stretch_offset_right`、`stretch_offset_bottom` プロパティを使用して、塗りつぶし矩形を定義できます。

画像のストレッチが指定されると、ソース矩形は塗りつぶし矩形に合わせてスケーリングされます。塗りつぶし矩形の各辺は、シェイプのバウンディングボックスの対応する辺からのパーセンテージオフセットで定義されます。正のパーセンテージはインセット（内側へ）、負のパーセンテージはアウトセット（外側へ）を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. 矩形の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
4. シェイプの塗りつぶしタイプを設定します。  
5. シェイプの画像塗りつぶしモードを設定します。  
6. 画像をロードします。  
7. シェイプの塗りつぶしに画像を割り当てます。  
8. シェイプのバウンディングボックスの対応する辺からの画像オフセットを指定します。  
9. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a rectangle AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Set the shape's fill type.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the shape's picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image and add it to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assign the image to fill the shape.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specify image offsets from the corresponding edges of the shape's bounding box.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Save the PPTX file to disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose は無料コンバータ（JPEG から PowerPoint、PNG から PowerPoint）を提供しており、画像から迅速にプレゼンテーションを作成できます。{{% /alert %}}

## **よくある質問**

**PictureFrame がサポートする画像フォーマットを確認する方法は？**

Aspose.Slides はラスタ画像 (PNG、JPEG、BMP、GIF など) とベクトル画像 (例: SVG) の両方を、[PictureFrame] に割り当てられる画像オブジェクトを通じてサポートしています。サポートされるフォーマットの一覧は、スライドおよび画像変換エンジンの機能と概ね重なります。

**多数の大きな画像を追加すると PPTX のサイズやパフォーマンスにどのような影響がありますか？**

大きな画像を埋め込むとファイルサイズとメモリ使用量が増加します。画像をリンクとして追加すればプレゼンテーションサイズを抑えることができますが、外部ファイルがアクセス可能である必要があります。Aspose.Slides はリンクによる画像追加機能を提供し、ファイルサイズ削減を支援します。

**画像オブジェクトを誤って移動・サイズ変更されないようにロックするには？**

[PictureFrame] の [shape locks] を使用して、移動やサイズ変更を無効にするなどのロックを設定できます。ロック機構は別の記事「保護の適用」（/slides/python-net/applying-protection-to-presentation/）で説明されており、様々なシェイプタイプ（[PictureFrame] を含む）でサポートされています。

**プレゼンテーションを PDF/画像にエクスポートするとき、SVG ベクトルの忠実度は保たれますか？**

Aspose.Slides は [PictureFrame] から元のベクトルとして SVG を抽出できます。[PDF]（/slides/python-net/convert-powerpoint-to-pdf/）やラスタ形式（/slides/python-net/convert-powerpoint-to-png/）へのエクスポート時、エクスポート設定により結果がラスタ化されることがあります。元の SVG がベクトルとして保存されていることは抽出動作で確認できます。