---
title: Pythonでプレゼンテーションの背景を管理する
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
- 背景の透明度
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument ファイルの動的な背景設定方法を学び、プレゼンテーションを強化するコードのコツをご紹介します。"
---

## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**普通のスライド**（単一スライド）または**マスター スライド**（複数のスライドに同時に適用）に背景を設定できます。

![PowerPoint の背景](powerpoint-background.png)

## **普通のスライドの単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーションでマスター スライドが使用されている場合でも、特定のスライドの背景を単色に設定できます。この変更は選択したスライドのみに適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `solid_fill_color` プロパティを使用して、単色の背景色を指定します。
5. 変更したプレゼンテーションを保存します。

次の Python の例は、普通のスライドの背景を青の単色に設定する方法を示しています。
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


## **マスター スライドの単色背景を設定する**

Aspose.Slides を使用すると、プレゼンテーションのマスター スライドの背景を単色に設定できます。マスター スライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスター スライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. `masters` 経由でマスター スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。
3. マスター スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `solid_fill_color` プロパティを使用して、単色の背景色を指定します。
5. 変更したプレゼンテーションを保存します。

次の Python の例は、マスター スライドの背景をフォレスト グリーンの単色に設定する方法を示しています。
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


## **スライドのグラデーション背景を設定する**

グラデーションは、色が徐々に変化することで作られる視覚効果です。スライド背景として使用すると、プレゼンテーションがより芸術的かつプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景をグラデーションカラーに設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `GRADIENT` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `gradient_format` プロパティを使用して、希望するグラデーション設定を構成します。
5. 変更したプレゼンテーションを保存します。

次の Python の例は、スライドの背景をグラデーションカラーに設定する方法を示しています。
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


## **画像をスライド背景に設定する**

単色やグラデーションのフィルだけでなく、Aspose.Slides を使用して画像をスライド背景として使用することもできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) を `OWN_BACKGROUND` に設定します。
3. スライド背景の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。
4. 背景に使用する画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) の `picture_fill_format` プロパティを使用して、画像を背景として割り当てます。
7. 変更したプレゼンテーションを保存します。

次の Python の例は、スライドの背景に画像を設定する方法を示しています。
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


次のコードサンプルは、背景塗りタイプをタイル状の画像に設定し、タイル化プロパティを変更する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # 背景塗りに使用する画像を設定します。
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # ピクチャーフィルモードをタイルに設定し、タイルプロパティを調整します。
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

詳しくは、[**タイル画像をテクスチャとして**](/slides/ja/python-net/shape-formatting/#tile-picture-as-texture)をご覧ください。

{{% /alert %}}

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたい場合があります。次の Python コードは、スライド背景画像の透明度を変更する方法を示しています。
```python
transparency_value = 30  # 例として。

# ピクチャー変換操作のコレクションを取得します。
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# 既存の固定パーセンテージ透明度効果を見つけます。
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


## **スライド背景の値を取得する**

Aspose.Slides は、スライドの実際の背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) クラスを提供します。このクラスは、実際の [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) と [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) クラスの `background` プロパティを使用すると、スライドの実際の背景を取得できます。

次の Python の例は、スライドの実際の背景値を取得する方法を示しています。
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # マスター、レイアウト、テーマを考慮した実効背景を取得します。
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```


## **FAQ**

**カスタム背景をリセットしてテーマ/レイアウトの背景に戻すことはできますか？**

はい。スライドのカスタム塗りを削除すると、対応する[レイアウト](/slides/ja/python-net/slide-layout/)/[マスター](/slides/ja/python-net/slide-master/) スライド（すなわち[テーマ背景](/slides/ja/python-net/presentation-theme/)）から再び背景が継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドに独自の塗りが設定されている場合は変更されません。背景が[レイアウト](/slides/ja/python-net/slide-layout/)/[マスター](/slides/ja/python-net/slide-master/) から継承されている場合は、新しいテーマに合わせて更新されます。