---
title: Python でプレゼンテーションのチャート凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/python-net/chart-legend/
keywords:
- チャート凡例
- 凡例位置
- フォントサイズ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を .NET 経由で使用し、PowerPoint および OpenDocument のプレゼンテーションで凡例の書式設定をカスタマイズして最適化します。"
---

## **概要**

Aspose.Slides for Python は、チャート凡例を完全に制御できる機能を提供し、データラベルを明瞭でプレゼンテーションに適した形にします。凡例の表示/非表示、スライド上での位置選択、プロット領域との重なりを防ぐレイアウト調整が可能です。API ではテキストとマーカーのスタイル設定、余白や背景の微調整、テーマに合わせた境界線や塗りつぶしの書式設定が行えます。開発者は個々の凡例エントリにアクセスして名前を変更したりフィルタリングしたりでき、最も関連性の高いシリーズだけを表示できます。この機能により、チャートは読みやすく一貫性が保たれ、プレゼンテーションのデザイン基準に合わせて調整できます。

## **凡例の配置**

Aspose.Slides を使用すると、チャート凡例がスライド内のどこに表示され、レイアウトにどのように適合するかを迅速に制御できます。凡例を正確に配置する方法を学びましょう。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドへの参照を取得します。  
3. スライドにチャートを追加します。  
4. 凡例のプロパティを設定します。  
5. プレゼンテーションを PPTX ファイルとして保存します。  

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

チャートの凡例は、説明対象のデータと同等に読みやすい必要があります。このセクションでは、プレゼンテーションのタイポグラフィに合わせて凡例のフォントサイズを調整し、アクセシビリティを向上させる方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. チャートを作成します。  
3. フォントサイズを設定します。  
4. プレゼンテーションをディスクに保存します。  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **凡例エントリのフォントサイズを設定する**

Aspose.Slides では、個別の凡例エントリをフォーマットすることで、チャート凡例の外観を細かく調整できます。以下の例は、特定の凡例項目を対象にプロパティを変更し、他の凡例はそのままにする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. チャートを作成します。  
3. 凡例エントリにアクセスします。  
4. エントリのプロパティを設定します。  
5. プレゼンテーションをディスクに保存します。  

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

**凡例を有効にすると、チャートが自動的に凡例用のスペースを確保し、重なって表示されないようにできますか？**

はい。オーバーレイしないモード（[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`）を使用します。この場合、プロット領域が縮小して凡例を収容します。

**複数行の凡例ラベルを作成できますか？**

はい。ラベルが長い場合はスペースが足りないと自動的に折り返されます。また、シリーズ名に改行文字を入れることで強制改行も可能です。

**凡例をプレゼンテーションテーマのカラースキームに合わせるにはどうすればよいですか？**

凡例やテキストに対して明示的な色・塗りつぶし・フォントを設定しないでください。設定しなければテーマから継承され、デザインを変更した際にも自動的に更新されます。