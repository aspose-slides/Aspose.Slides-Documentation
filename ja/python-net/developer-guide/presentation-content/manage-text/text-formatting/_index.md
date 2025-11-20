---
title: PythonでPowerPointテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/python-net/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間隔
- 自動調整プロパティ
- テキストフレームアンカー
- テキストタブ
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定する方法を学びます。フォント、色、配置などを強力な Python コード例でカスタマイズできます。"
---

## **テキストのハイライト**

`highlight_text` メソッドは、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスにあり、テキストサンプルを使用して文字列の一部を背景色でハイライトすることができます。これは PowerPoint 2019 の「テキストハイライト カラー」ツールに似ています。

以下のコードスニペットは、この機能の使用方法を示しています：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```


## **正規表現を使用したテキストのハイライト**

`highlight_regex` メソッドは、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスにあり、正規表現を使用して文字列の一部を背景色でハイライトすることができます。これは PowerPoint 2019 の「テキストハイライト カラー」ツールに似ています。

以下のコードスニペットは、この機能の使用方法を示しています：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストの背景色の設定**

Aspose.Slides では、テキストの背景色を指定できます。以下の Python コードは、テキスト全体の背景色を設定する方法を示しています：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


この Python コードは、テキストの一部だけの背景色を設定する方法を示しています：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **テキスト段落の配置**

テキストの書式設定は、文書やプレゼンテーションを作成する際の重要な要素です。Aspose.Slides for Python via .NET はスライドへのテキスト追加をサポートしており、本セクションではスライド内の段落配置の制御方法を示します。以下の手順で Aspose.Slides for Python via .NET を使用してテキスト段落を配置してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライド上のプレースホルダーシェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) にキャストします。
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) が公開する [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) から、配置する必要がある段落を取得します。
1. 段落を配置します。段落は `LEFT`、`RIGHT`、`CENTER`、`JUSTIFY`、`JUSTIFY_LOW`、`DISTRIBUTED` のいずれかに配置できます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

これらの手順の実装例を以下に示します。
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 両方のプレースホルダーのテキストを変更
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # プレースホルダーの最初の段落を取得
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # テキスト段落を中央揃えにする
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # プレゼンテーションを PPTX ファイルとして保存
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストの透明度の設定**

このセクションでは、Aspose.Slides for Python via .NET を使用して任意のテキストシェイプの透明度プロパティを設定する方法を示します。テキストの透明度を設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. 影の色を設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

これらの手順の実装例は以下です。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # 透明度をゼロパーセントに設定
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **テキスト文字間隔の設定**

Aspose.Slides では、テキストボックス内の文字間隔を調整できます。これにより、文字間の間隔を拡大または縮小して、行やブロックの視覚的な密度を制御できます。

以下の Python 例は、1 行の文字間隔を拡大し、別の行を縮小する方法を示しています：
```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # 拡張
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # 縮小

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落フォントプロパティの管理**

プレゼンテーションは通常、テキストと画像の両方を含みます。テキストはさまざまな方法で書式設定でき、特定のセクションや単語を強調したり、企業のスタイルに合わせたりできます。テキストの書式設定により、プレゼンテーション内容の外観と感覚を変更できます。

本セクションでは、Aspose.Slides for Python via .NET を使用してスライドテキスト内の段落のフォントプロパティを構成する方法を示します。段落のフォントプロパティを管理するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. スライド上のプレースホルダーシェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) にキャストします。
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) が公開する [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) から段落を取得します。
1. 段落を均等揃えにします。
1. 段落のテキスト部分にアクセスします。
1. [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) を使用してフォントを定義し、テキスト部分のフォントをそれに合わせて設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) オブジェクトが公開する [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) を使用してフォントの色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。プレーンなプレゼンテーションを取得し、スライドの 1 つにフォント書式設定を適用します。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
with slides.Presentation("FontProperties.pptx") as pres:
    # スライドの位置を使ってスライドにアクセスする
    slide = pres.slides[0]

    # スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 最初の Paragraph にアクセスする
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # 最初の portion にアクセスする
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # 新しいフォントを定義する
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # portion に新しいフォントを割り当てる
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # フォントを太字に設定する
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # フォントを斜体に設定する
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # フォントの色を設定する
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #PPTX をディスクに書き込む
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストのフォント ファミリの管理**

[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) オブジェクトは、段落内で同じ書式スタイルのテキストを保持するために使用されます。本セクションでは、Aspose.Slides for Python を使用してテキストボックスを作成し、テキストを追加し、特定のフォントとさまざまなフォント ファミリ プロパティを定義する方法を示します。

テキストボックスを作成し、内部テキストのフォントプロパティを設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに `RECTANGLE` 種類の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) に関連付けられた塗りつぶしスタイルを削除します。
1. AutoShape の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを追加します。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) に関連付けられた [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) オブジェクトにアクセスします。
1. [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) で使用するフォントを定義します。
1. [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) が公開する関連プロパティを使用して、太字、斜体、下線、色、高さなどの他のフォントプロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation をインスタンス化する
with slides.Presentation() as presentation:
    # 最初のスライドを取得
    sld = presentation.slides[0]

    # Rectangle タイプの AutoShape を追加
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # AutoShape に関連付けられた塗りつぶしスタイルを削除
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # AutoShape に関連付けられた TextFrame にアクセス
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # TextFrame に関連付けられた Portion にアクセス
    port = tf.paragraphs[0].portions[0]

    # Portion のフォントを設定
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # フォントの太字プロパティを設定
    port.portion_format.font_bold = 1

    # フォントの斜体プロパティを設定
    port.portion_format.font_italic = 1

    # フォントの下線プロパティを設定
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # フォントの高さを設定
    port.portion_format.font_height = 25

    # フォントの色を設定
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX をディスクに書き込む 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストのフォントサイズの設定**

Aspose.Slides では、段落内の既存テキストや、あとで段落に追加される可能性のあるテキストに対して、好みのフォントサイズを設定できます。

以下の Python 例は、段落内のテキストのフォントサイズを設定する方法を示しています：
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # 最初のシェイプを取得します（例）
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # 最初の段落を取得します（例）
        paragraph = shape.text_frame.paragraphs[0]

        # 段落内のすべてのテキスト部分のデフォルトフォントサイズを 20 pt に設定します
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # 段落内の現在のテキスト部分のフォントサイズを 20 pt に設定します
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **テキスト回転の設定**

Aspose.Slides for Python via .NET は開発者がテキストを回転させることを可能にします。テキストは `HORIZONTAL`、`VERTICAL`、`VERTICAL270`、`WORD_ART_VERTICAL`、`EAST_ASIAN_VERTICAL`、`MONGOLIAN_VERTICAL`、または `WORD_ART_VERTICAL_RIGHT_TO_LEFT` として表示できます。

任意の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のテキストを回転させるには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドにシェイプを追加します。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. 必要なテキスト回転を適用します。
1. ファイルをディスクに保存します。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成する
with slides.Presentation() as presentation:
    # 最初のスライドを取得する
    slide = presentation.slides[0]

    # Rectangle タイプの AutoShape を追加
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Rectangle に TextFrame を追加
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # テキストフレームにアクセスする
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # テキストフレーム用の Paragraph オブジェクトを作成する
    para = txtFrame.paragraphs[0]

    # Paragraph 用の Portion オブジェクトを作成する
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # プレゼンテーションを保存する
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **TextFrame のカスタム回転角度の設定**

Aspose.Slides for Python via .NET は [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のカスタム回転角度を設定することをサポートしています。本セクションでは、`rotation_angle` プロパティの使用方法を示します。

`rotation_angle` プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. `rotation_angle` プロパティを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では `rotation_angle` プロパティを設定しています。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成する
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # プレゼンテーションを保存する
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落の行間隔の設定**

Aspose.Slides は [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) クラスの `space_after`、`space_before`、`space_within` プロパティを提供し、段落の行間隔を制御します。これらのプロパティの動作は次のとおりです。

* 行間隔をパーセンテージで指定する場合は正の値を使用します。
* 行間隔をポイントで指定する場合は負の値を使用します。

例として、段落の前に 16 pt の行間隔を適用するには、`space_before` プロパティを `-16` に設定します。

特定の段落の行間隔を設定する手順は次のとおりです。

1. テキストを含む [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) があるプレゼンテーションをロードします。
1. インデックスでスライドへの参照を取得します。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) にアクセスします。
1. 必要な段落プロパティを設定します。
1. プレゼンテーションを保存します。

以下の Python 例は、段落の行間隔を設定する方法を示しています：
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成する
with slides.Presentation("Fonts.pptx") as presentation:

    # インデックスでスライドの参照を取得する
    sld = presentation.slides[0]

    # TextFrame にアクセスする
    tf1 = sld.shapes[0].text_frame

    # Paragraph にアクセスする
    para1 = tf1.paragraphs[0]

    # Paragraph のプロパティを設定する
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # プレゼンテーションを保存する
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **TextFrame の AutofitType プロパティの設定**

本セクションでは、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のさまざまな書式設定プロパティを調査し、`autofit_type` の設定、テキストアンカーの調整、プレゼンテーション内のテキスト回転を行う方法を紹介します。

Aspose.Slides for Python via .NET は任意の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の `autofit_type` プロパティを設定できます。`autofit_type` は `NORMAL` または `SHAPE` のいずれかに設定できます。

* `NORMAL` に設定すると、シェイプは変更されず、テキストがシェイプに合わせて調整されます。
* `SHAPE` に設定すると、テキストが収まるようにシェイプ自体がリサイズされます。

[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の `autofit_type` プロパティを設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドにシェイプを追加します。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の `autofit_type` を設定します。
1. ファイルをディスクに保存します。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成する
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスする 
    slide = presentation.slides[0]

    # Rectangle タイプの AutoShape を追加する
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Rectangle に TextFrame を追加する
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # テキストフレームにアクセスする
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # テキストフレーム用の Paragraph オブジェクトを作成する
    para = txtFrame.paragraphs[0]

    # Paragraph 用の Portion オブジェクトを作成する
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # プレゼンテーションを保存する
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **TextFrame のアンカー設定**

Aspose.Slides for Python via .NET は任意の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のアンカー位置を設定できます。[TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) プロパティは、テキストがシェイプ内のどこに配置されるかを指定します。`TOP`、`CENTER`、`BOTTOM`、`JUSTIFIED`、または `DISTRIBUTED` のいずれかに設定できます。

[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のアンカーを設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドにシェイプを追加します。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のために [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) を設定します。
1. ファイルをディスクに保存します。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成する
with slides.Presentation() as presentation:
    # 最初のスライドを取得する
    slide = presentation.slides[0]

    # Rectangle タイプの AutoShape を追加する
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Rectangle に TextFrame を追加する
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # テキストフレームにアクセスする
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # テキストフレーム用の Paragraph オブジェクトを作成する
    para = txtFrame.paragraphs[0]

    # Paragraph 用の Portion オブジェクトを作成する
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # プレゼンテーションを保存する
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **デフォルトテキストスタイルの設定**

プレゼンテーション内のすべてのテキスト要素に同じデフォルト書式を適用したい場合は、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの `default_text_style` プロパティを使用して、目的の書式を設定できます。

以下の例は、新しいプレゼンテーションのすべてのスライドに対して、デフォルトフォントを太字、サイズ 14 pt に設定する方法を示しています。
```py
with slides.Presentation() as presentation:
    # トップレベルの段落フォーマットを取得します。
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```


## **全大文字効果でテキストを抽出する**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上のテキストが大文字で表示されますが、実際に入力されたテキストは小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。これを処理するには、[TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) が `ALL` を示すか確認し、返された文字列を大文字に変換すると、スライド上に表示されているものと一致します。

以下の画像はサンプル2.pptx の最初のスライドにあるテキストボックスを示しています。

![全大文字効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示しています：
```py
with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```


出力:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


{{% alert color="primary" %}}
Aspose はシンプルな、[無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています。
{{% /alert %}}

## **FAQ**

**単一の段落内のテキストの特定部分（例：数単語だけを太字にする）に異なる書式を適用できますか？ また、レイアウトやテーマから継承されたスタイルとどのように相互作用しますか？**

はい。書式は段落内の「テキスト部分」レベルで設定され、選択したフラグメントだけがテーマ/レイアウトのスタイルを上書きします。テーマが変更された場合、明示的なローカル書式が設定されていない領域だけが更新されます。

**Linux やシステムフォントがインストールされていない Docker コンテナでフォントはどのように機能しますか？**

ライブラリはフォントの検出・置換を使用します。フォントが存在しないシステムでは、[フォント ディレクトリを指す](/slides/ja/python-net/custom-font/) か、[置換テーブルを設定](/slides/ja/python-net/font-substitution/) して、不適切なフォントへのフォールバックやレイアウトのずれを防ぐ必要があります。

**プレースホルダー内のテキスト書式設定は、通常のオートシェイプ内の書式設定とどのように異なりますか？**

プレースホルダーはスライド マスターとレイアウトからのスタイルを通常のオートシェイプより強く継承します。ローカルで変更は可能ですが、レイアウトが変更されるとテーマ スタイルに戻りやすく、テキスト部分レベルで書式をハードオーバーライドしていない限り元に戻ります。