---
title: Pythonでプレゼンテーションのチャート凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/python-net/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: Aspose.Slides for Python (.NET 経由) を使用してチャート凡例をカスタマイズし、PowerPoint と OpenDocument のプレゼンテーションを最適化し、凡例の書式を自在に調整します。
---

## **概要**

Aspose.Slides for Python はチャート凡例を完全にコントロールできる機能を提供し、データラベルを明瞭でプレゼンテーション向きにします。凡例の表示/非表示を切り替え、スライド上の位置を選択し、プロット領域との重なりを防ぐようレイアウトを調整できます。API を使ってテキストとマーカーのスタイル設定、余白や背景の微調整、テーマに合わせた枠線や塗りつぶしの書式設定が可能です。開発者は個々の凡例項目にアクセスして名前を変更したりフィルタリングしたりでき、最も関連性の高い系列だけを表示できます。この機能により、チャートは読みやすく、一貫性が保たれ、プレゼンテーションのデザイン基準に沿ったものになります。

## **凡例の位置指定**

Aspose.Slides を使用すると、チャート凡例がスライドレイアウトのどこに表示され、どのように配置されるかをすばやく制御できます。凡例を正確に配置する方法を学びましょう。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにチャートを追加します。
1. 凡例のプロパティを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、チャート凡例の位置とサイズを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # スライドへの参照を取得します。
    slide = presentation.slides[0]

    # スライドにクラスター化された縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # 凡例のプロパティを設定します。
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # プレゼンテーションをディスクに保存します。
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **凡例のフォントサイズを設定する**

チャートの凡例は、説明対象のデータと同様に読みやすくあるべきです。このセクションでは、プレゼンテーションのタイポグラフィに合わせて凡例のフォントサイズを調整し、アクセシビリティを向上させる方法を示します。

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

## **凡例項目のフォントサイズを設定する**

Aspose.Slides は、個別の凡例項目をフォーマットすることでチャート凡例の外観を細かく調整する機能を提供します。以下の例では、特定の凡例項目を対象にプロパティを設定し、他の凡例には影響を与えません。

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

**凡例を有効にして、チャートが自動的に凡例用のスペースを確保し、重ね合わせないようにできますか？**

はい。非重ね合わせモード（[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`）を使用してください。この場合、プロット領域は凡例を収めるために縮小されます。

**複数行の凡例ラベルを作成できますか？**

はい。ラベルが長い場合はスペースが足りないと自動的に折り返されます。改行文字を系列名に含めることで強制的な改行もサポートされます。

**凡例をプレゼンテーションのテーマカラーに合わせるにはどうすればよいですか？**

凡例やテキストに対して明示的な色・塗りつぶし・フォントを設定しないでください。テーマから自動的に継承され、デザインが変更された際にも正しく更新されます。