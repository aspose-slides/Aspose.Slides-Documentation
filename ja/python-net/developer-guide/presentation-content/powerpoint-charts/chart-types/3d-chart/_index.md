---
title: Python を使用したプレゼンテーションの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/python-net/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET で PPT、PPTX、ODP ファイルをサポートした 3D チャートの作成とカスタマイズ方法を学び、プレゼンテーションを強化しましょう。
---

## **3D チャートの RotationX、RotationY、DepthPercents プロパティの設定**
Aspose.Slides for Python via .NET はこれらのプロパティを設定するためのシンプルな API を提供します。以下の記事では X、Y の回転や **DepthPercents** などのさまざまなプロパティの設定方法を説明します。サンプルコードは前述のプロパティの設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. Rotation3D プロパティを設定します。
5. 変更されたプレゼンテーションを PPTX ファイルに保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成します
with slides.Presentation() as presentation:
            
    # 最初のスライドにアクセスします
    slide = presentation.slides[0]

    # デフォルトデータでチャートを追加します
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # チャート データシートのインデックスを設定します
    defaultWorksheetIndex = 0

    # チャート データ ワークシートを取得します
    fact = chart.chart_data.chart_data_workbook

    # 系列を追加します
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # カテゴリを追加します
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Rotation3D プロパティを設定します
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # 2 番目のチャート系列を取得します
    series = chart.chart_data.series[1]

    # 系列データを入力します
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # OverLap 値を設定します
    series.parent_series_group.overlap = 100         

    # プレゼンテーションをディスクに保存します
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの 3D バリエーションをサポートし、[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で関連する 3D タイプが公開されています。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像としてエクスポートするには [chart API](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) を使用するか、スライド全体を PNG や JPEG などの形式で [スライドを PNG に変換](/slides/ja/python-net/convert-powerpoint-to-png/) してください。ピクセル単位で正確なプレビューが必要な場合や、ドキュメント、ダッシュボード、ウェブページにチャートを埋め込む際に便利です。

**大規模な 3D チャートの構築とレンダリングのパフォーマンスはどの程度ですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最適な結果を得るには、3D エフェクトは最小限に抑え、壁やプロット領域への重いテクスチャを避け、可能な限り系列あたりのデータポイント数を制限し、ターゲットの表示または印刷要件に合わせた解像度とサイズで出力してください。