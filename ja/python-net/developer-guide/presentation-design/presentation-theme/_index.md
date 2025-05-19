---
title: Python で PowerPoint プレゼンテーションのテーマを管理する
linktitle: プレゼンテーション テーマ
type: docs
weight: 10
url: /ja/python-net/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーション テーマ
- スライド テーマ
- テーマを設定
- テーマを変更
- テーマを管理
- テーマの色
- 追加パレット
- テーマのフォント
- テーマのスタイル
- テーマの効果
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してプレゼンテーション テーマを習得し、ブランドを一貫させた PowerPoint ファイルの作成、カスタマイズ、変換を行いましょう。"
---

プレゼンテーションテーマは、デザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、実際には特定の視覚要素のセットとそのプロパティを選択していることになります。

PowerPointでは、テーマは色、[フォント](/slides/ja/python-net/powerpoint-fonts/)、[背景スタイル](/slides/ja/python-net/presentation-background/)、および効果で構成されています。

![theme-constituents](theme-constituents.png)

## **テーマ色の変更**

PowerPointテーマは、スライド上の異なる要素に対して特定の色のセットを使用します。色が気に入らない場合は、テーマの新しい色を適用することで色を変更します。新しいテーマ色を選択できるようにするために、Aspose.Slidesは[SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/)列挙型の値を提供します。

このPythonコードは、テーマのアクセントカラーを変更する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

次のようにして、結果の色の効果的な値を決定できます：

```python
fillEffective = shape.fill_format.get_effective()
print("{0} ({1})".format(fillEffective.solid_fill_color.name, fillEffective.solid_fill_color)) # ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

色変更操作をさらに示すために、別の要素を作成し、初期操作から取得したアクセントカラーをそれに割り当てます。続いて、テーマ内の色を変更します：

```python
otherShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
otherShape.fill_format.fill_type = slides.FillType.SOLID
otherShape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

pres.master_theme.color_scheme.accent4.color = draw.Color.red
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマ色を設定**

メインテーマ色（1）に明度変換を適用すると、追加パレット（2）から色が形成されます。これらのテーマ色を設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1**- メインテーマ色

**2** - 追加パレットの色。

このPythonコードは、追加パレットの色をメインテーマ色から取得し、図形で利用する操作を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # アクセント4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # アクセント4、明るい80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # アクセント4、明るい60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # アクセント4、明るい40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # アクセント4、濃い25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # アクセント4、濃い50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **テーマフォントの変更**

テーマや他の目的のためにフォントを選択できるように、Aspose.Slidesは次の特別な識別子を使用します（PowerPointで使用されるものと似ています）：

* **+mn-lt** - ボディフォントラテン（マイナーラテンフォント）
* **+mj-lt** - 見出しフォントラテン（メジャーラテンフォント）
* **+mn-ea** - ボディフォント東アジア（マイナー東アジアフォント）
* **+mj-ea** - ボディフォント東アジア（メジャー東アジアフォント）

このPythonコードは、テーマ要素にラテンフォントを割り当てる方法を示しています：

```python
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)

paragraph = slides.Paragraph()
portion = slides.Portion("テーマテキストフォーマット")
paragraph.portions.add(portion)
shape.text_frame.paragraphs.add(paragraph)
portion.portion_format.latin_font = slides.FontData("+mn-lt")
```

このPythonコードは、プレゼンテーションテーマフォントを変更する方法を示しています：

```python
pres.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="ヒント" %}} 

[PowerPointフォント](/slides/ja/python-net/powerpoint-fonts/)を参照することをお勧めします。

{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPointアプリは12の事前定義された背景を提供しますが、そのうちの3つだけが典型的なプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPointアプリでプレゼンテーションを保存した後、以下のPythonコードを実行して、プレゼンテーション内の事前定義された背景の数を確認できます：

```python
with slides.Presentation() as pres:
    numberOfBackgroundFills = len(pres.master_theme.format_scheme.background_fill_styles)
    print("テーマの背景フィルスタイルの数は {0} です".format(numberOfBackgroundFills))
```

{{% alert color="warning" %}} 

[FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/)クラスの`BackgroundFillStyles`プロパティを使用することで、PowerPointテーマの背景スタイルを追加またはアクセスできます。 

{{% /alert %}}

このPythonコードは、プレゼンテーションの背景を設定する方法を示しています：

```python
pres.masters[0].background.style_index = 2
```

**インデックスガイド**: 0は塗りつぶしなしに使用されます。インデックスは1から始まります。

{{% alert color="primary" title="ヒント" %}} 

[PowerPoint背景](/slides/ja/python-net/presentation-background/)を参照することをお勧めします。

{{% /alert %}}

## **テーマ効果の変更**

PowerPointテーマには、通常、各スタイル配列に対して3つの値が含まれています。それらの配列は、これらの3つの効果に組み合わされます：微妙、適度、および強烈。たとえば、効果が特定の図形に適用されたときの結果は次のとおりです：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/)クラスの3つのプロパティ（`FillStyles`、`LineStyles`、`EffectStyles`）を使用することで、テーマ内の要素を変更できます（PowerPointのオプションよりも柔軟に）。

このPythonコードは、要素の一部を変更することでテーマ効果を変更する方法を示しています：

```python
with slides.Presentation("combined_with_master.pptx") as pres:
    pres.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    pres.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    pres.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    pres.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", slides.export.SaveFormat.PPTX)
```

塗りつぶし色、塗りつぶしタイプ、影効果などの結果の変更：

![todo:image_alt_text](presentation-design_11.png)