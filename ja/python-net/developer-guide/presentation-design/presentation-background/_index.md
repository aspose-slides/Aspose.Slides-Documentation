---
title: Pythonでプレゼンテーションの背景を管理
linktitle: スライド背景
type: docs
weight: 20
url: /ja/python-net/presentation-background/
keywords:
- プレゼンテーション背景
- スライド背景
- 単色
- グラデーションカラー
- 画像背景
- 背景の透明性
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint および OpenDocument ファイルに動的な背景を設定する方法を学び、プレゼンテーションを強化するコードヒントを紹介します。"
---

## **概要**

単色、グラデーション、画像はスライド背景によく使用されます。**通常スライド**（単一スライド）または**マスタースライド**（複数スライドに同時に適用）に対して背景を設定できます。

![PowerPoint の背景](powerpoint-background.png)

## **通常スライドの単色背景を設定**

Aspose.Slides を使用すると、プレゼンテーションがマスタースライドを使用している場合でも、特定のスライドの背景を単色に設定できます。変更は選択したスライドにのみ適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。  
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `solid_fill_color` プロパティを使用して単色背景の色を指定します。  
5. 変更されたプレゼンテーションを保存します。

以下の Python 例は、通常スライドの背景を青の単色に設定する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set the background color of the slide to blue.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **マスタースライドの単色背景を設定**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景を単色に設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートなので、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. `masters` 経由でマスタースライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. マスタースライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。  
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `solid_fill_color` プロパティで単色背景の色を指定します。  
5. 変更されたプレゼンテーションを保存します。

以下の Python 例は、マスタースライドの背景をフォレストグリーンの単色に設定する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Set the background color for the Master slide to Forest Green.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドのグラデーション背景を設定**

グラデーションは色が徐々に変化する視覚効果です。スライド背景として使用すると、プレゼンテーションがより芸術的かつプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景にグラデーションカラーを設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `GRADIENT` に設定します。  
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `gradient_format` プロパティで好みのグラデーション設定を構成します。  
5. 変更されたプレゼンテーションを保存します。

以下の Python 例は、スライドの背景にグラデーションカラーを設定する方法を示しています。

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Apply a gradient effect to the background.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the presentation to disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **画像をスライド背景として設定**

単色やグラデーションに加えて、Aspose.Slides では画像をスライド背景として使用できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。  
4. 背景に使用する画像を読み込みます。  
5. 画像をプレゼンテーションの画像コレクションに追加します。  
6. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `picture_fill_format` プロパティで画像を背景として割り当てます。  
7. 変更されたプレゼンテーションを保存します。

以下の Python 例は、スライドの背景に画像を設定する方法を示しています。

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set background image properties.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Add the image to the presentation's image collection.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

以下のコードサンプルは、背景の塗りつぶしタイプをタイル状画像に設定し、タイル属性を変更する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Set the image used for the background fill.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Set the picture fill mode to Tile and adjust the tile properties.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Read more: [**Tile Picture As Texture**](/slides/ja/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **背景画像の透明度を変更**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたい場合があります。以下の Python コードは、スライド背景画像の透明度を変更する方法を示しています。

```python
transparency_value = 30  # For example.

# Get the collection of picture transform operations.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Find an existing fixed-percentage transparency effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Set the new transparency value.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **スライドの背景値を取得**

Aspose.Slides は、スライドの有効な背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) クラスを提供します。このクラスは、有効な [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) と [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) クラスの `background` プロパティを使用すると、スライドの有効な背景を取得できます。

以下の Python 例は、スライドの有効な背景値を取得する方法を示しています。

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Retrieve the effective background, taking into account master, layout, and theme.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **よくある質問**

**カスタム背景をリセットして、テーマ/レイアウトの背景に戻すことはできますか？**

はい。スライドのカスタム塗りつぶしを削除すれば、対応する [レイアウト](/slides/ja/python-net/slide-layout/)/[マスタ](/slides/ja/python-net/slide-master/) スライド（つまり [テーマ背景](/slides/ja/python-net/presentation-theme/)）から再び継承されます。

**プレゼンテーションのテーマを後で変更した場合、背景はどうなりますか？**

スライドに独自の塗りつぶしが設定されている場合、その背景は変更されません。背景が [レイアウト](/slides/ja/python-net/slide-layout/)/[マスタ](/slides/ja/python-net/slide-master/) から継承されている場合は、新しいテーマに合わせて更新されます。