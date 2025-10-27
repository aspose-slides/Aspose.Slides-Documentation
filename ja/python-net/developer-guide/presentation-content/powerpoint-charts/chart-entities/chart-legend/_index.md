---
title: Python でプレゼンテーションのチャート凡例をカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-legend/
keywords:
- チャート凡例
- 凡例位置
- フォントサイズ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに合わせた凡例書式設定でチャート凡例をカスタマイズします。"
---

## **概要**

Aspose.Slides for Python はチャート凡例を完全に制御でき、データラベルを明瞭でプレゼンテーションに適した状態にします。凡例の表示/非表示、スライド上の位置、プロット領域と重ならないようレイアウトを調整できます。API ではテキストとマーカーのスタイル設定、余白や背景の微調整、ボーダーや塗りつぶしの書式設定が可能で、テーマに合わせたデザインに統一できます。開発者は個々の凡例項目にアクセスして名前を変更したりフィルタリングしたりでき、最も重要な系列だけを表示できます。これらの機能により、チャートは読みやすく、一貫性が保たれ、プレゼンテーションのデザイン基準に沿ったものになります。

## **凡例の位置指定**

Aspose.Slides を使用すると、チャート凡例の表示場所とスライドレイアウトへの適合を素早く制御できます。凡例を正確に配置する方法をご紹介します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. スライドへの参照を取得します。  
1. スライドにチャートを追加します。  
1. 凡例のプロパティを設定します。  
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、チャート凡例の位置とサイズを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a reference to the slide.
    slide = presentation.slides[0]

    # Add a clustered column chart to the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Set the legend properties.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Save the presentation to disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **凡例のフォントサイズを設定する**

チャートの凡例は、説明対象のデータと同等に読みやすくあるべきです。このセクションでは、プレゼンテーションのタイポグラフィに合わせて凡例のフォントサイズを調整し、アクセシビリティを向上させる方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. チャートを作成します。  
1. フォントサイズを設定します。  
1. プレゼンテーションをディスクに保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **凡例項目のフォントサイズを個別に設定する**

Aspose.Slides では、個々の凡例項目をフォーマットしてチャート凡例の外観を細かく調整できます。以下の例は、特定の凡例項目だけを対象にプロパティを設定し、他の項目は変更しない方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. チャートを作成します。  
1. 凡例項目にアクセスします。  
1. 項目のプロパティを設定します。  
1. プレゼンテーションをディスクに保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**凡例を有効にすると、チャートが自動的に凡例用のスペースを確保し、重ね合わせが発生しませんか？**

はい。非重ね合わせモード（[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`）を使用します。この場合、プロット領域は凡例を収めるために縮小されます。

**複数行の凡例ラベルを作成できますか？**

はい。ラベルが長い場合はスペースが足りないと自動的に折り返されます。シリーズ名に改行文字を入れることで強制改行も可能です。

**凡例をプレゼンテーションテーマの配色に合わせるにはどうすればよいですか？**

凡例やそのテキストに対して明示的に色・塗りつぶし・フォントを設定しないでください。テーマから継承され、デザインが変更されたときに自動的に更新されます。