---
title: Python を使用したプレゼンテーションでのチャート凡例のカスタマイズ
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
description: "Aspose.Slides for Python を使用し、.NET 経由でチャート凡例をカスタマイズし、PowerPoint および OpenDocument のプレゼンテーションを最適化して凡例の書式設定を調整します。"
---

## **Overview**

Aspose.Slides for Python は、チャートの凡例をフルコントロールでき、データ ラベルを明確かつプレゼンテーション向けにします。凡例の表示/非表示、スライド上での位置選択、プロット領域との重なりを防止するレイアウト調整が可能です。API を使用すると、テキストやマーカーのスタイル設定、余白や背景の微調整、テーマに合わせた枠線や塗りの書式設定が行えます。開発者は個々の凡例エントリにアクセスし、名前の変更やフィルタリングができ、最も関連性の高いシリーズのみを表示できます。これらの機能により、チャートは読みやすく、一貫性があり、プレゼンテーションのデザイン基準に合わせて整合します。

## **Legend Positioning**

Aspose.Slides を使用すると、チャート凡例の表示位置とスライドレイアウトへのフィット感を迅速に制御できます。凡例を正確に配置する方法をご紹介します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. スライドにチャートを追加します。
1. 凡例のプロパティを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

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


## **Set the Legend Font Size**

チャートの凡例は、説明するデータと同等に読みやすくあるべきです。このセクションでは、プレゼンテーションのタイポグラフィに合わせ、アクセシビリティを向上させるために凡例のフォントサイズを調整する方法を示します。

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


## **Set the Font Size for a Legend Entry**

Aspose.Slides を使用すると、個々のエントリをフォーマットしてチャート凡例の外観を細かく調整できます。以下の例では、特定の凡例項目を対象にし、他の凡例を変更せずにそのプロパティを設定する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. チャートを作成します。
1. 凡例エントリにアクセスします。
1. エントリのプロパティを設定します。
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

はい。非オーバーレイモード（[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`）を使用します。この場合、プロット領域が縮小して凡例を収めます。

**複数行の凡例ラベルを作成できますか？**

はい。スペースが不足すると長いラベルは自動的に折り返されます。シリーズ名に改行文字を入れることで強制改行もサポートされます。

**凡例をプレゼンテーションテーマのカラースキームに合わせるにはどうすればよいですか？**

凡例やテキストに明示的な色・塗り・フォントを設定しないでください。これらはテーマから継承され、デザインが変更された際に正しく更新されます。