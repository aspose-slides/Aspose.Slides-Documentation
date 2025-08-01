---
title: Python で PowerPoint テキストをフォーマットする
linktitle: テキストの書式設定
type: docs
weight: 50
url: /ja/python-net/text-formatting/
keywords:
- 文字のハイライト
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
- 行間
- 自動調整プロパティ
- テキストフレームアンカー
- テキストタブ
- 既定の言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定する方法を学びます。強力な Python コード例でフォント、色、配置などをカスタマイズできます。"
---

## **テキストの強調**
ITextFrameインターフェイスとTextFrameクラスに新しいHighlightTextメソッドが追加されました。

このメソッドにより、PowerPoint 2019のテキストハイライトカラーツールと同様に、テキストサンプルを使用して背景色でテキストの一部を強調表示できます。

以下のコードスニペットは、この機能の使用方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Asposeはシンプルな[無料のオンラインPowerPoint編集サービス](https://products.aspose.app/slides/editor)を提供しています。

{{% /alert %}} 


## **正規表現を使用したテキストの強調**
ITextFrameインターフェイスとTextFrameクラスに新しいHighlightRegexメソッドが追加されました。

このメソッドにより、PowerPoint 2019のテキストハイライトカラーツールと同様に、regexを使用して背景色でテキストの一部を強調表示できます。

以下のコードスニペットは、この機能の使用方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストの背景色を設定する**

Aspose.Slidesを使用すると、テキストの背景色を指定できます。

このPythonコードは、テキスト全体の背景色を設定する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("黒")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" 赤 ")
    
    portion3 = slides.Portion("黒")
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

このPythonコードは、テキストの一部の背景色を設定する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("黒")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" 赤 ")
    
    portion3 = slides.Portion("黒")
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

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if '赤' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **テキスト段落の整列**
テキストフォーマットは、あらゆる種類の文書やプレゼンテーションを作成する際の重要な要素の1つです。Aspose.Slides for Python via .NETはスライドにテキストを追加することをサポートしていますが、このトピックでは、スライド内のテキスト段落の整列を制御する方法を見ていきます。Aspose.Slides for Python via .NETを使用してテキスト段落を整列するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダーシェイプにアクセスし、AutoShapeとして型キャストします。
4. AutoShapeによって公開されたTextFrameから整列が必要な段落を取得します。
5. 段落を整列させます。段落は右、左、中央、両端に整列できます。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記手順の実装は以下の通りです。

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # スライド内の最初と2つ目のプレースホルダーにアクセスし、AutoShapeとして型キャスト
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 両方のプレースホルダーのテキストを変更
    tf1.text = "Asposeによる中央揃え"
    tf2.text = "Asposeによる中央揃え"

    # プレースホルダーの最初の段落を取得
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # テキスト段落を中央に整列
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # プレゼンテーションをPPTXファイルとして保存
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストの透明度を設定する**
この記事では、Aspose.Slides for Python via .NETを使用して任意のテキストシェイプに透明度プロパティを設定する方法を示します。テキストに透明度を設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 影の色を設定します。
4. プレゼンテーションをPPTXファイルとして書き込みます。

上記手順の実装は以下の通りです。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - 透明度は: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # 透明度をゼロパーセントに設定
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストの文字間隔を設定する**

Aspose.Slidesを使用すると、テキストボックス内の文字間のスペースを設定できます。このようにすることで、文字間のスペースを広げたり縮めたりすることにより、行やテキストブロックの視覚的な密度を調整できます。

このPythonコードは、1行のテキストの間隔を広げ、別の行の間隔を縮める方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # 拡大
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # 縮小

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落のフォントプロパティを管理する**
プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストは、特定のセクションや単語を強調表示したり、企業スタイルに適合させたりするために、さまざまな方法でフォーマットできます。テキストフォーマットは、プレゼンテーション内容の見た目を変えるのに役立ちます。この記事では、Aspose.Slides for Python via .NETを使用して、スライド上のテキスト段落のフォントプロパティを構成する方法を示します。Aspose.Slides for Python via .NETを使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内のプレースホルダーシェイプにアクセスし、AutoShapeに型キャストします。
1. AutoShapeによって公開されたTextFrameから段落を取得します。
1. 段落を両端揃えます。
1. 段落のテキストポーションにアクセスします。
1. FontDataを使用してフォントを定義し、テキストポーションのフォントを設定します。
   1. フォントを太字に設定します。
   1. フォントをイタリックに設定します。
1. Portionオブジェクトによって公開されたFillFormatを使用してフォントの色を設定します。
1. 修正されたプレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルに書き込みます。

上記手順の実装は以下の通りです。装飾のないプレゼンテーションを取り込み、スライドの1つでフォントをフォーマットします。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # スライドの位置を使用してスライドにアクセス
    slide = pres.slides[0]

    # スライド内の最初と2つ目のプレースホルダーにアクセスし、AutoShapeとして型キャスト
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 最初の段落にアクセス
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # 最初のポーションにアクセス
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # 新しいフォントを定義
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # ポーションに新しいフォントを割り当て
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # フォントを太字に設定
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # フォントを斜体に設定
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # フォントの色を設定
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    # PPTXをディスクに書き込む
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストのフォントファミリを管理する**
ポーションは、段落内で同様のフォーマットスタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for Pythonを使用してテキストボックスを作成し、特定のフォントを定義し、フォントファミリーカテゴリのさまざまなプロパティを設定する方法を示します。テキストボックスを作成し、内部のテキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに長方形のAutoShapeを追加します。
4. AutoShapeに関連付けられた塗りつぶしスタイルを削除します。
5. AutoShapeのTextFrameにアクセスします。
6. TextFrameにテキストを追加します。
7. TextFrameに関連付けられたポーションオブジェクトにアクセスします。
8. ポーションで使用するフォントを定義します。
9. ポーションオブジェクトによって公開されたプロパティを使用して、太字、イタリック、下線、色、高さなどのフォントの他のプロパティを設定します。
10. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記手順の実装は以下の通りです。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationをインスタンス化
with slides.Presentation() as presentation:
    # 最初のスライドを取得
    sld = presentation.slides[0]

    # 長方形タイプのAutoShapeを追加
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # AutoShapeに関連付けられた塗りつぶしスタイルを削除
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # AutoShapeに関連付けられたTextFrameにアクセス
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # TextFrameに関連付けられたポーションにアクセス
    port = tf.paragraphs[0].portions[0]

    # ポーションのフォントを設定
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # フォントの太字プロパティを設定
    port.portion_format.font_bold = 1

    # フォントのイタリックプロパティを設定
    port.portion_format.font_italic = 1

    # フォントの下線プロパティを設定
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # フォントの高さを設定
    port.portion_format.font_height = 25

    # フォントの色を設定
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTXをディスクに書き込む 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストのフォントサイズを設定する**

Aspose.Slidesを使用すると、段落内の既存のテキストや後で段落に追加される他のテキストに対して好みのフォントサイズを選択できます。

このPythonコードは、段落に含まれるテキストのフォントサイズを設定する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # 例えば最初のシェイプを取得
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # 例えば最初の段落を取得
        paragraph = shape.text_frame.paragraphs[0]

        # 段落内のすべてのテキストポーションに20ptのデフォルトフォントサイズを設定
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # 段落内の現在のテキストポーションに20ptのフォントサイズを設定
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **テキストの回転を設定する**
Aspose.Slides for Python via .NETでは、開発者がテキストを回転させることができます。テキストを水平、垂直、270度垂直、ワードアート垂直、東アジア垂直、モンゴル垂直、または右から左へのワードアートとして表示できるように設定することができます。任意のTextFrameのテキストを回転させるには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. TextFrameにアクセスします。
5. テキストを回転させます。
6. ファイルをディスクに保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 最初のスライドを取得 
    slide = presentation.slides[0]

    # 長方形タイプのAutoShapeを追加
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 長方形にTextFrameを追加
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # テキストフレームにアクセス
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # テキストフレームの段落オブジェクトを作成
    para = txtFrame.paragraphs[0]

    # 段落のポーションオブジェクトを作成
    portion = para.portions[0]
    portion.text = "素早い茶色の狐が怠け者の犬を飛び越えます。素早い茶色の狐が怠け者の犬を飛び越えます。"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # プレゼンテーションを保存
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **TextFrameのカスタム回転角度を設定する**
Aspose.Slides for Python via .NETでは、TextFrameのカスタム回転角度を設定することがサポートされています。このトピックでは、Aspose.SlidesでRotationAngleプロパティを設定する方法を例を使って見ていきます。新しいプロパティRotationAngleは、IChartTextBlockFormatおよびITextFrameFormatインターフェイスに追加され、テキストフレームのカスタム回転角度を設定できます。RotationAngleプロパティを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. RotationAngleプロパティを設定します。
4. プレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、RotationAngleプロパティを設定します。

```py
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("カスタムタイトル").text_frame_format.rotation_angle = -30

    # プレゼンテーションを保存
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落の行間**
Aspose.Slidesは、`paragraph_format`の下にある`space_after`、`space_before`、および`space_within`プロパティを提供し、段落の行間を管理することを可能にします。これらの3つのプロパティは次のように使用されます。

* 段落の行間をパーセンテージで指定するには、正の値を使用します。 
* 段落の行間をポイントで指定するには、負の値を使用します。

たとえば、`space_before`プロパティを-16に設定することで、段落の16ptの行間を適用できます。

特定の段落の行間を指定する方法は以下の通りです。

1. テキストを含むAutoShapeを持つプレゼンテーションを読み込みます。
2. インデックスを通じてスライドの参照を取得します。
3. TextFrameにアクセスします。
4. 段落にアクセスします。
5. 段落のプロパティを設定します。
6. プレゼンテーションを保存します。

このPythonコードは、段落の行間を指定する方法を示しています：

```py
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # インデックスを通じてスライドの参照を取得
    sld = presentation.slides[0]

    # TextFrameにアクセス
    tf1 = sld.shapes[0].text_frame

    # 段落にアクセス
    para1 = tf1.paragraphs[0]

    # 段落のプロパティを設定
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # プレゼンテーションを保存
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **TextFrameのAutofitTypeプロパティを設定する**
このトピックでは、テキストフレームのさまざまなフォーマットプロパティについて探ります。この記事は、テキストフレームのAutofitTypeプロパティ、テキストのアンカー、プレゼンテーション内でのテキストの回転を設定する方法をカバーしています。Aspose.Slides for Python via .NETを使用すると、任意のテキストフレームのAutofitTypeプロパティを設定できます。AutofitTypeはNormalまたはShapeに設定できます。Normalに設定すると、シェイプはそのまま保持され、テキストはシェイプが変わらずに調整されます。一方、AutofitTypeがShapeに設定されると、シェイプは変更され、必要なテキストのみが含まれるようになります。テキストフレームのAutofitTypeプロパティを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. TextFrameにアクセスします。
5. TextFrameのAutofitTypeを設定します。
6. ファイルをディスクに保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:

    # 最初のスライドにアクセス 
    slide = presentation.slides[0]

    # 長方形タイプのAutoShapeを追加
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 長方形にTextFrameを追加
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # テキストフレームにアクセス
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # テキストフレームの段落オブジェクトを作成
    para = txtFrame.paragraphs[0]

    # 段落のポーションオブジェクトを作成
    portion = para.portions[0]
    portion.text = "素早い茶色の狐が怠け者の犬を飛び越えます。素早い茶色の狐が怠け者の犬を飛び越えます。"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # プレゼンテーションを保存
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **TextFrameのアンカーを設定する**
Aspose.Slides for Python via .NETでは、任意のTextFrameのアンカーを設定できます。TextAnchorTypeは、シェイプ内のテキストの配置を指定します。TextAnchorTypeは、上部、中央、下部、両端揃えまたは分配に設定できます。任意のTextFrameのアンカーを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. TextFrameにアクセスします。
5. TextFrameのTextAnchorTypeを設定します。
6. ファイルをディスクに保存します。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 最初のスライドを取得 
    slide = presentation.slides[0]

    # 長方形タイプのAutoShapeを追加
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 長方形にTextFrameを追加
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # テキストフレームにアクセス
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # テキストフレームの段落オブジェクトを作成
    para = txtFrame.paragraphs[0]

    # 段落のポーションオブジェクトを作成
    portion = para.portions[0]
    portion.text = "素早い茶色の狐が怠け者の犬を飛び越えます。素早い茶色の狐が怠け者の犬を飛び越えます。"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # プレゼンテーションを保存
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テキストのタブ化を設定する**
- EffectiveTabs.ExplicitTabCount (この場合2)プロパティはTabs.Countに等しい。
- EffectiveTabsコレクションには、すべてのタブ (Tabsコレクションとデフォルトタブ) が含まれる。
- EffectiveTabs.ExplicitTabCount (この場合2)プロパティはTabs.Countに等しい。
- EffectiveTabs.DefaultTabSize (294)プロパティは、デフォルトタブの間の距離を示す (この例では3と4)。
- EffectiveTabs.GetTabByIndex(index)でindex = 0は最初の明示的なタブを返す (位置 = 731)、index = 1では2番目のタブ (位置 = 1241)を返す。index = 2を使用して次のタブを取得しようとすると、最初のデフォルトタブ (位置 = 1470)が返されるなど。
- EffectiveTabs.GetTabAfterPosition(pos)は、テキストの後に次のタブを取得するために使用される。たとえば、テキスト「Helloworld!」があるとします。このテキストを描画するには、「Hello」の長さをピクセルで計算し、この値でGetTabAfterPositionを呼び出す必要があります。これにより、「world!」を描画するための次のタブ位置が得られます。


## **デフォルトテキストスタイルを設定する**

プレゼンテーション内のすべてのテキスト要素に同じデフォルトのテキストフォーマットを一度に適用する必要がある場合、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスの`default_text_style`プロパティを使用して、希望するフォーマットを設定できます。以下のコード例は、新しいプレゼンテーション内のすべてのスライドに対してデフォルトの太字フォント (14 pt) を設定する方法を示しています。

```py
with slides.Presentation() as presentation:
    # トップレベルの段落フォーマットを取得
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```