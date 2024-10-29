---
title: ピクチャーフレーム
type: docs
weight: 10
url: /ja/python-net/picture-frame/
keywords: "ピクチャーフレームの追加, ピクチャーフレームの作成, 画像の追加, 画像の作成, 画像の抽出, StretchOffプロパティ, ピクチャーフレームのフォーマット, ピクチャーフレームのプロパティ, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにピクチャーフレームを追加する"
---

ピクチャーフレームは画像を含むシェイプで、フレームに入った写真のようなものです。

ピクチャーフレームを通じてスライドに画像を追加できます。この方法で、ピクチャーフレームをフォーマットすることで画像のフォーマットも行えます。

{{% alert  title="ヒント" color="primary" %}} 

Asposeは無料のコンバーターを提供しています—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) および [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—これにより、ユーザーは画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

## **ピクチャーフレームの作成**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。 
2. インデックスを通じてスライドの参照を取得します。 
3. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)に画像を追加することで[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトを作成します。 
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連するシェイプオブジェクトが公開する`AddPictureFrame`メソッドを通じて、画像の幅と高さに基づいて[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)を作成します。
6. スライドに画像を含むピクチャーフレームを追加します。
7. 変更されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードはピクチャーフレームの作成方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスをインスタンス化します
with slides.Presentation() as pres:
    # 最初のスライドを取得します
    sld = pres.slides[0]

    # ImageExクラスをインスタンス化します
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # 画像の等価な高さと幅でフレームを追加します
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # PictureFrameExにいくつかのフォーマットを適用します
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # PPTXファイルをディスクに書き込みます
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}} 

ピクチャーフレームを使用すると、画像に基づいてプレゼンテーションスライドを迅速に作成できます。Aspose.Slidesの保存オプションと組み合わせることで、画像のフォーマットを他の形式に変換するための入出力操作を操作できます。以下のページも参照することをお勧めします: [画像をJPGに変換](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); [JPGを画像に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); [JPGをPNGに変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), [PNGをJPGに変換](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); [PNGをSVGに変換](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), [SVGをPNGに変換](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **相対スケールでピクチャーフレームを作成する**

画像の相対スケーリングを変更することで、より複雑なピクチャーフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. プレゼンテーション画像コレクションに画像を追加します。
4. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)に画像を追加することで[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトを作成します。
5. ピクチャーフレーム内で画像の相対的な幅と高さを指定します。
6. 変更されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは相対スケールでのピクチャーフレームの作成方法を示しています：

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスをインスタンス化します
with slides.Presentation() as presentation:
    # プレゼンテーション画像コレクションに追加される画像を読み込みます
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # スライドにピクチャーフレームを追加します
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 相対スケールの幅と高さを設定します
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # プレゼンテーションを保存します
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ピクチャーフレームから画像を抽出する**

[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)オブジェクトから画像を抽出し、PNG、JPGなどの形式で保存することができます。以下のコード例は、「sample.pptx」というドキュメントから画像を抽出し、PNG形式で保存する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **画像の透過性を取得する**

Aspose.Slidesを使用すると、画像の透過性を取得できます。このPythonコードはその操作を示しています：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("画像の透過性: " + str(transparencyValue))
```

## **ピクチャーフレームのフォーマット**

Aspose.Slidesは、ピクチャーフレームに適用できる多くのフォーマットオプションを提供しています。これらのオプションを使用することで、特定の要件に合ったピクチャーフレームを変更できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. プレゼンテーションオブジェクトに関連付けられた[IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)に画像を追加することで[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage)オブジェクトを作成します。
4. 画像の幅と高さを指定します。
5. 参照されたスライドに関連する[IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection)オブジェクトが公開する[AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)メソッドを使用して、画像の幅と高さに基づいて`PictureFrame`を作成します。
6. 画像を含むピクチャーフレームをスライドに追加します。
7. ピクチャーフレームの線の色を設定します。
8. ピクチャーフレームの線の幅を設定します。
9. ピクチャーフレームを回転させ、正または負の値を与えます。
   * 正の値は画像を時計回りに回転させます。 
   * 負の値は画像を反時計回りに回転させます。
10. 画像を含むピクチャーフレームをスライドに追加します。
11. 変更されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、ピクチャーフレームのフォーマットプロセスを示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスをインスタンス化します
with slides.Presentation() as pres:
    # 最初のスライドを取得します
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

         # 画像の等価な高さと幅でピクチャーフレームを追加します
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # PictureFrameExにいくつかのフォーマットを適用します
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # PPTXファイルをディスクに書き込みます
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ヒント" color="primary" %}}

Asposeは最近[無料のコラージュメーカー](https://products.aspose.app/slides/collage)を開発しました。JPG/JPEGやPNG画像を[マージ](https://products.aspose.app/slides/collage/jpg)したり、[写真からグリッドを作成](https://products.aspose.app/slides/collage/photo-grid)したりする必要がある場合は、このサービスを利用できます。 

{{% /alert %}}

## **リンクとして画像を追加**

大きなプレゼンテーションファイルサイズを避けるために、画像（または動画）をプレゼンテーションに直接埋め込むのではなく、リンクを通じて追加することができます。このPythonコードは、プレースホルダーに画像と動画を追加する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)
        
    

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **画像のトリミング**

このPythonコードは、スライド上の既存の画像をトリミングする方法を示しています：

``` py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 新しい画像オブジェクトを作成します
    newImage = presentation.images.add_image(slides.Images.from_file(imagePath))

    # スライドにPictureFrameを追加します
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # 画像をトリミングします（パーセンテージ値）
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # 結果を保存します
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)

```

## ピクチャーのトリミングされた領域を削除する

フレーム内の画像のトリミングされた領域を削除したい場合は、[delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/)メソッドを使用できます。このメソッドは、トリミングされた画像またはトリミングが不要な場合は元の画像を返します。

このPythonコードはその操作を示しています：

```python
import aspose.slides as slides

with slides.Presentation(path + "PictureFrameCrop.pptx") as pres:
    slide = pres.slides[0]

    # 最初のスライドからPictureFrameを取得します
    picture_frame = slides.shape[0]

    # PictureFrame画像のトリミングされた領域を削除し、トリミングされた画像を返します
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 結果を保存します
    pres.save(path + "PictureFrameDeleteCroppedAreas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

delete_picture_cropped_areasメソッドは、トリミングされた画像をプレゼンテーション画像コレクションに追加します。画像が処理された[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)でのみ使用されている場合、この設定はプレゼンテーションのサイズを減らすことができます。そうでない場合、結果として得られるプレゼンテーションの画像数は増加します。

このメソッドは、トリミング操作中にWMF/EMFメタファイルをラスタPNG画像に変換します。 

{{% /alert %}}

## **アスペクト比を固定する**

画像を含むシェイプが画像の寸法を変更してもアスペクト比を保持する必要がある場合、*aspect_ratio_locked*プロパティを使用して*アスペクト比を固定*の設定を行うことができます。

このPythonコードは、シェイプのアスペクト比を固定する方法を示しています： 

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # 形状のリサイズ時にアスペクト比を保持する設定をします
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="注意" color="warning" %}} 

この*アスペクト比を固定*の設定は、シェイプのアスペクト比を保持するのみで、含まれている画像のアスペクト比は保持されません。

{{% /alert %}}

## **StretchOffプロパティを使用する**

[IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/)インターフェースおよび[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)クラスからの`StretchOffsetLeft`、`StretchOffsetTop`、`StretchOffsetRight`および`StretchOffsetBottom`プロパティを使用して、フィル矩形を指定できます。 

画像のストレッチが指定されると、ソース矩形が指定されたフィル矩形に合わせてスケーリングされます。フィル矩形の各辺は、形状のバウンディングボックスの対応する辺からのパーセンテージオフセットによって定義されます。正のパーセンテージはインセットを指定し、負のパーセンテージはアウトセットを指定します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 四角形の`AutoShape`を追加します。 
4. 画像を作成します。
5. 形状のフィルタイプを設定します。
6. 形状の画像フィルモードを設定します。
7. 形状を満たす画像を追加します。
8. 形状のバウンディングボックスの対応する辺からの画像オフセットを指定します。
9. 変更されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、StretchOffプロパティを使用するプロセスを示しています：

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスをインスタンス化します
with slides.Presentation() as pres:

    # 最初のスライドを取得します
    slide = pres.slides[0]

    # ImageExクラスをインスタンス化します
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # 画像の等価な高さと幅でピクチャーフレームを追加します
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # 形状のフィルタイプを設定します
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # 形状の画像フィルモードを設定します
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # 形状を満たす画像を設定します
        shape.fill_format.picture_fill_format.picture.image = imgx

        # 形状のバウンディングボックスの対応する辺からの画像オフセットを指定します
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # PPTXファイルをディスクに書き込みます
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```