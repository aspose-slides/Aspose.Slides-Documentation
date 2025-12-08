---
title: PythonでPowerPointプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/python-net/presentation-theme/
keywords:
- PowerPointテーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (.NET) を使用して、統一されたブランディングで PowerPoint ファイルを作成、カスタマイズ、変換するために、プレゼンテーションテーマをマスターします。"
---

## **概要**

プレゼンテーションテーマは、デザイン要素のプロパティを定義します。テーマを選択すると、視覚要素とそのプロパティの調和したセットを選んだことになります。

PowerPoint のテーマには、色、[fonts](/slides/ja/python-net/powerpoint-fonts/)、[background styles](/slides/ja/python-net/presentation-background/)、およびエフェクトが含まれます。

![theme-constituents](theme-constituents.png)

## **テーマの色を変更する**

PowerPoint のテーマは、スライド上のさまざまな要素に対して特定の色セットを使用します。デフォルトが気に入らない場合は、新しいテーマカラーを適用して変更できます。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 列挙体に値を提供しています。

この Python コードは、テーマのアクセントカラーを変更する方法を示しています：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```


結果として得られる色の有効値は次のように取得できます：
```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# 例の出力:
#
# ff8064a2 (カラー [A=255, R=128, G=100, B=162])
```


色の変更をさらに示すために、別の要素を作成し、最初の手順で取得したアクセントカラーを割り当て、テーマカラーを更新します。
```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```


新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定する**

メインテーマカラー (1) に明度変換を適用すると、追加パレット (2) から色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** — メインテーマカラー  

**2** — 追加パレットからの色  

この Python コードは、追加パレットカラーがメインテーマカラーから派生し、形状で使用される方法を示しています：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # アクセント 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # アクセント 4、明るさ 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # アクセント 4、明るさ 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # アクセント 4、明るさ 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # アクセント 4、暗く 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # アクセント 4、暗く 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **テーマのフォントを変更する**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は PowerPoint と同様の特別な識別子を使用します。

- **+mn-lt** — 本文フォント ラテン文字 (Minor Latin Font)
- **+mj-lt** — 見出しフォント ラテン文字 (Major Latin Font)
- **+mn-ea** — 本文フォント 東アジア文字 (Minor East Asian Font)
- **+mj-ea** — 見出しフォント 東アジア文字 (Major East Asian Font)

この Python コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています：
```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```


この Python の例は、プレゼンテーションのテーマフォントを変更する方法を示しています：
```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```


すべてのテキストボックスが新しいフォントに更新されます。

{{% alert color="primary" title="TIP" %}}
詳細については、[Master PowerPoint Fonts with Python](/slides/ja/python-net/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマの背景スタイルを変更する**

デフォルトでは、PowerPoint は 12 の事前定義された背景を提供しますが、一般的なプレゼンテーションはそのうちの 3 しか使用しません。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint でプレゼンテーションを保存した後、次の Python コードを実行して事前定義された背景がいくつ含まれているかを確認できます：
```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```


{{% alert color="warning" %}}
[FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) クラスの `background_fill_styles` プロパティを使用すると、PowerPoint テーマ内の背景スタイルを追加または取得できます。
{{% /alert %}}

この Python の例は、プレゼンテーションの背景を設定する方法を示しています：
```python
presentation.masters[0].background.style_index = 2  # 0 は塗りなしを表します; インデックスは 1 から始まります。
```


{{% alert color="primary" title="TIP" %}}
詳細については、[Manage Presentation Backgrounds in Python](/slides/ja/python-net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマのエフェクトを変更する**

PowerPoint のテーマは通常、各スタイル配列に 3 つの値を含みます。これらの配列は組み合わさって、微妙、標準、強度という 3 つのエフェクトレベルになります。例えば、特定の形状にこれらのエフェクトを適用した結果は次のとおりです：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) クラスの 3 つのプロパティ `FillStyles`、`LineStyles`、`EffectStyles` を使用すると、PowerPoint よりも柔軟にテーマ要素を変更できます。

この Python コードは、要素の一部を変更してテーマエフェクトを変更する方法を示しています：
```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


結果として、塗りつぶしカラー、塗りつぶしタイプ、影エフェクトなどが更新されます：

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**スライド単体にテーマを適用し、マスターを変更せずに済む方法はありますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしており、[SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) を使用して、マスターテーマはそのままにローカルテーマだけを対象スライドに適用できます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に移行する最善の方法は何ですか？**

[Clone slides](/slides/ja/python-net/clone-slides/) を使用してマスターとともにスライドをターゲットプレゼンテーションにコピーします。これにより、元のマスター、レイアウト、関連するテーマが保持され、外観が一貫します。

**すべての継承とオーバーライドを考慮した「有効」な値を確認するにはどうすればよいですか？**

テーマ/カラー/フォント/エフェクトのための API の「[effective]」ビュー (/slides/ja/python-net/shape-effective-properties/) を使用してください。これらはマスターとローカルオーバーライドを適用した後の最終的に解決されたプロパティを返します。