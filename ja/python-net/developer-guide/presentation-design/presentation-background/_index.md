---
title: プレゼンテーションの背景
type: docs
weight: 20
url: /ja/python-net/presentation-background/
keywords: "PowerPoint 背景, 背景を設定, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションの背景を設定"
---

単色、グラデーションカラー、画像は、スライドの背景画像としてよく使用されます。**通常のスライド**（単一スライド）または**マスタースライド**（複数スライド同時）に対して背景を設定できます。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **通常のスライドに単色を背景として設定する**

Aspose.Slidesを使用すると、プレゼンテーション内の特定のスライドに単色を背景として設定できます（そのプレゼンテーションがマスタースライドを含む場合でも）。背景の変更は選択されたスライドのみに影響します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/)列挙体を`OwnBackground`に設定します。
3. スライドの背景の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)列挙体を`Solid`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)によって公開される[SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties)プロパティを使用して、背景の単色を指定します。
5. 修正されたプレゼンテーションを保存します。

このPythonコードは、通常のスライドに単色（青）を背景として設定する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のISlideの背景色を青に設定
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # プレゼンテーションをディスクに保存
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **マスタースライドに単色を背景として設定する**

Aspose.Slidesを使用すると、プレゼンテーションのマスタースライドに単色を背景として設定できます。マスタースライドはすべてのスライドのフォーマット設定を含むテンプレートとして機能します。したがって、マスタースライドに単色を背景として選択すると、その新しい背景がすべてのスライドに使用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. マスタースライド（`Masters`）の[BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/)列挙体を`OwnBackground`に設定します。
3. マスタースライドの背景の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)列挙体を`Solid`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)によって公開される[SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties)プロパティを使用して、背景の単色を指定します。
5. 修正されたプレゼンテーションを保存します。

このPythonコードは、プレゼンテーションのマスタースライドに単色（フォレストグリーン）を背景として設定する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # マスターISlideの背景色をフォレストグリーンに設定
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # プレゼンテーションをディスクに保存
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドにグラデーションカラーを背景として設定する**

グラデーションは、色の変化に基づくグラフィカルな効果です。グラデーションカラーをスライドの背景として使用すると、プレゼンテーションがアーティスティックでプロフェッショナルに見えます。Aspose.Slidesを使用すると、プレゼンテーション内のスライドにグラデーションカラーを背景として設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/)列挙体を`OwnBackground`に設定します。
3. マスタースライドの背景の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)列挙体を`Gradient`に設定します。
4. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)によって公開される[GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties)プロパティを使用して、希望するグラデーション設定を指定します。
5. 修正されたプレゼンテーションを保存します。

このPythonコードは、スライドにグラデーションカラーを背景として設定する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # 背景にグラデーション効果を適用
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # プレゼンテーションをディスクに保存
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドに画像を背景として設定する**

単色やグラデーションカラーの他に、Aspose.Slidesはプレゼンテーション内のスライドに画像を背景として設定することも可能です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの[BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/)列挙体を`OwnBackground`に設定します。
3. マスタースライドの背景の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)列挙体を`Picture`に設定します。
4. スライドの背景に使用したい画像をロードします。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)によって公開される[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties)プロパティを使用して、画像を背景として設定します。
7. 修正されたプレゼンテーションを保存します。

このPythonコードは、スライドに画像を背景として設定する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # 背景画像の条件を設定
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 画像をロード
    img = draw.Bitmap(path + "Tulips.jpg")

    # 画像をプレゼンテーションの画像コレクションに追加
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # プレゼンテーションをディスクに保存
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたくなることがあります。このPythonコードは、スライドの背景画像の透明度を変更する方法を示しています：

```python
transparencyValue = 30 # 例えば

# 画像変換操作のコレクションを取得
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# 固定のパーセンテージの透明効果を探します。
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# 新しい透明度の値を設定します。
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **スライドの背景の値を取得する**

Aspose.Slidesは、[IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/)インターフェースを提供して、スライド背景の有効値を取得できるようにしています。このインターフェースには、有効な[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties)および有効な[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties)に関する情報が含まれています。

[BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)クラスの[Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties)プロパティを使用して、スライドの背景の有効値を取得できます。

このPythonコードは、スライドの有効背景値を取得する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("塗りつぶし色: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("塗りつぶしタイプ: " + str(effBackground.fill_format.fill_type))
```