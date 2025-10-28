---
title: Python でプレゼンテーションの背景を管理する
linktitle: スライド背景
type: docs
weight: 20
url: /ja/python-net/presentation-background/
keywords:
- プレゼンテーションの背景
- スライドの背景
- 単色
- グラデーション色
- 画像背景
- 背景の透明度
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument ファイルの動的背景を設定する方法を学び、プレゼンテーションを強化するコードヒントを入手しましょう。"
---

## **概要**

単色、グラデーション、画像はスライド背景として一般的に使用されます。**通常スライド**（単一スライド）または**マスタースライド**（複数スライドに一度に適用）に対して背景を設定できます。

![PowerPoint background](powerpoint-background.png)

## **通常スライドに単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーションがマスタースライドを使用している場合でも、特定のスライドの背景を単色に設定できます。この変更は選択したスライドにのみ適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。  
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `solid_fill_color` プロパティで単色の背景色を指定します。  
5. 変更したプレゼンテーションを保存します。

以下の Python 例は、通常スライドの背景を青の単色に設定する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # スライドの背景色を青に設定します。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # プレゼンテーションをディスクに保存します。
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **マスタースライドに単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景を単色に設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートなので、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. `masters` 経由でマスタースライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. マスタースライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。  
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `solid_fill_color` プロパティで単色の背景色を指定します。  
5. 変更したプレゼンテーションを保存します。

以下の Python 例は、マスタースライドの背景をフォレストグリーンの単色に設定する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # マスタースライドの背景色をフォレストグリーンに設定します。
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # プレゼンテーションをディスクに保存します。
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドにグラデーション背景を設定する**

グラデーションは色が段階的に変化する視覚効果です。スライド背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景にグラデーション色を設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `GRADIENT` に設定します。  
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `gradient_format` プロパティで希望のグラデーション設定を構成します。  
5. 変更したプレゼンテーションを保存します。

以下の Python 例は、スライドの背景にグラデーション色を設定する方法を示しています。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 背景にグラデーション効果を適用します。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # プレゼンテーションをディスクに保存します。
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **スライド背景に画像を設定する**

単色やグラデーションの他に、Aspose.Slides では画像をスライド背景として使用できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。  
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。  
4. 背景に使用する画像をロードします。  
5. 画像をプレゼンテーションの画像コレクションに追加します。  
6. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `picture_fill_format` プロパティで画像を背景として割り当てます。  
7. 変更したプレゼンテーションを保存します。

以下の Python 例は、スライドの背景に画像を設定する方法を示しています。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 背景画像のプロパティを設定します。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 画像をロードします。
    with slides.Images.from_file("Tulips.jpg") as image:
        # 画像をプレゼンテーションの画像コレクションに追加します。
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # プレゼンテーションをディスクに保存します。
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

以下のコードサンプルは、背景の塗りつぶしタイプをタイル画像に設定し、タイルプロパティを変更する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # 背景塗りつぶしに使用する画像を設定します。
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # ピクチャーフィルモードを Tile に設定し、タイルプロパティを調整します。
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

詳しく読む: [**テクスチャとしてのタイル画像**](/slides/ja/python-net/shape-formatting/#tile-picture-as-texture)。

{{% /alert %}}

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたい場合があります。以下の Python コードは、スライド背景画像の透明度を変更する方法を示しています。

```python
transparency_value = 30  # 例

# 画像変形操作のコレクションを取得します。
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# 既存の固定パーセンテージ透明度エフェクトを探します。
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# 新しい透明度の値を設定します。
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **スライドの背景値を取得する**

Aspose.Slides は、スライドの有効な背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) クラスを提供しています。このクラスは、有効な [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) と [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) クラスの `background` プロパティを使用すると、スライドの有効な背景を取得できます。

以下の Python 例は、スライドの有効な背景値を取得する方法を示しています。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # マスター、レイアウト、テーマを考慮した有効な背景を取得します。
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**カスタム背景をリセットしてテーマ/レイアウトの背景に戻すことはできますか？**

はい。スライドのカスタム塗りつぶしを削除すれば、背景は対応する [レイアウト](/slides/ja/python-net/slide-layout/)/[マスター](/slides/ja/python-net/slide-master/) スライド（つまり [テーマ背景](/slides/ja/python-net/presentation-theme/)）から再び継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドに独自の塗りつぶしが設定されていれば変更されません。背景が [レイアウト](/slides/ja/python-net/slide-layout/)/[マスター](/slides/ja/python-net/slide-master/) から継承されている場合は、新しいテーマに合わせて更新されます。