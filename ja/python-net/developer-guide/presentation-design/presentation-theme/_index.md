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
- テーマ設定
- テーマ変更
- テーマ管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマ効果
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、ブランド一貫性のある PowerPoint ファイルの作成、カスタマイズ、変換を行い、プレゼンテーションテーマをマスターします。"
---
## **概要**

プレゼンテーションのテーマは、デザイン要素のプロパティを定義します。テーマを選択すると、視覚要素とそのプロパティが調和したセットを選ぶことになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/python-net/powerpoint-fonts/)、[背景スタイル](/slides/ja/python-net/presentation-background/)、および効果を含みます。

![theme-constituents](theme-constituents.png)

## **テーマの色を変更する**

PowerPoint のテーマは、スライド上のさまざまな要素に対して特定の色セットを使用します。デフォルトが気に入らない場合は、新しいテーマカラーを適用して変更できます。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/schemecolor/) 列挙体の値を提供します。

この Python コードはテーマのアクセントカラーを変更する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

結果のカラーの実効値は以下のように取得できます：

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# 例の出力:
#
# ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

色の変更をさらに示すために、別の要素を作成し、最初のステップで取得したアクセントカラーを割り当て、テーマカラーを更新します。

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

新しいカラーは両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定する**

メインテーマカラーに輝度変換を適用すると (1)、追加パレットからのカラー (2) が生成されます。そのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** — メインテーマカラー  
**2** — 追加パレットからのカラー

この Python コードは、メインテーマカラーから追加パレットのカラーを導出し、それをシェイプで使用する方法を示しています：

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

### **`SchemeColor` を `ColorScheme` のカラーにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/schemecolor/) を使用すると、以下のテーマカラー値が含まれていることに気付くかもしれません。

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, and `TEXT2`.

しかし、`Presentation.master_theme.color_scheme` は [ColorScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/colorscheme/) を返し、対応するカラーを次のように公開します：

`dark1`, `dark2`, `light1`, and `light2`.

この違いは名前だけです。これらの値は同じテーマカラーのスロットを指しており、マッピングは固定されています：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

`TEXT`/`BACKGROUND` と `dark`/`light` の間に動的な変換はありません。これらは同じテーマカラーの別名にすぎません。

この名前の違いは Microsoft Office の用語から来ています。古い Office バージョンは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` を使用していましたが、最新の UI バージョンでは同じスロットを `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示します。

## **テーマフォントを変更する**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は以下の特殊な識別子（PowerPoint のものと同様）を使用します：

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

{{% alert color="primary" title="ヒント" %}}
詳細については、[Python でのマスターパワーポイントフォント](/slides/ja/python-net/powerpoint-fonts/)をご覧ください。
{{% /alert %}}

## **テーマの背景スタイルを変更する**

デフォルトでは、PowerPoint は 12 の事前定義された背景を提供しますが、一般的なプレゼンテーションはそのうち 3 つしか保存しません。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint でプレゼンテーションを保存した後、次の Python コードを実行して、含まれる事前定義背景の数を確認できます：

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
[FormatScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/) クラスの `background_fill_styles` プロパティを使用すると、PowerPoint のテーマで背景スタイルを追加または取得できます。
{{% /alert %}}

この Python の例は、プレゼンテーションの背景を設定する方法を示しています：

```python
presentation.masters[0].background.style_index = 2  # 0 は塗りなしを示します。インデックスは 1 から始まります。
```

{{% alert color="primary" title="ヒント" %}}
詳細については、[Python でのプレゼンテーション背景の管理](/slides/ja/python-net/presentation-background/)をご覧ください。
{{% /alert %}}

## **テーマ効果を変更する**

PowerPoint のテーマは通常、各スタイル配列に 3 つの値を含みます。これらの配列は 3 つの効果レベル（微妙、適度、強烈）に結合されます。たとえば、特定のシェイプにこれらの効果を適用した結果は次のとおりです：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/) クラスの 3 つのプロパティ（`FillStyles`、`LineStyles`、`EffectStyles`）を使用すると、PowerPoint よりも柔軟にテーマ要素を変更できます。

この Python コードは、これらの要素の一部を変更してテーマ効果を変更する方法を示しています：

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

結果として、塗りつぶしカラー、塗りつぶしタイプ、影効果、その他のプロパティが更新されます：

![todo:image_alt_text](presentation-design_11.png)

## **よくある質問**

**マスターを変更せずに、単一スライドにテーマを適用できますか？**

はい。Aspose.Slides はスライド単位のテーマオーバーライドをサポートしているため、マスターテーマをそのままにして、対象スライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/slidethememanager/) を使用）。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最善の方法は何ですか？**

[スライドのクローン](/slides/ja/python-net/clone-slides/) をマスターとともにターゲットプレゼンテーションにコピーします。これにより、元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

**すべての継承とオーバーライドが適用された後の「実効」値を確認するにはどうすればよいですか？**

API の ["実効" ビュー](/slides/ja/python-net/shape-effective-properties/)（テーマ/カラー/フォント/効果）を使用します。これらは、マスターとローカルオーバーライドが適用された後の解決された最終プロパティを返します。