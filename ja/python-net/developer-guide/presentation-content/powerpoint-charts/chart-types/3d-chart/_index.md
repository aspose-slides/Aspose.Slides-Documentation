---
title: Pythonでプレゼンテーションの3Dチャートをカスタマイズ
linktitle: 3Dチャート
type: docs
url: /ja/python-net/3d-chart/
keywords:
- 3Dチャート
- 回転
- 深さ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で 3-D チャートの作成とカスタマイズ方法を学び、PPT、PPTX、ODP ファイルに対応し、プレゼンテーションを今すぐ強化しましょう。"
---

## **3D チャートの RotationX、RotationY および DepthPercents プロパティを設定する**
Aspose.Slides for Python via .NET は、これらのプロパティを設定するためのシンプルな API を提供します。以下の記事では、X、Y の回転や **DepthPercents** などのさまざまなプロパティの設定方法を説明します。サンプルコードは、前述のプロパティを設定する方法を示しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 既定データでチャートを追加します。
1. Rotation3D プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成する
with slides.Presentation() as presentation:
            
    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # デフォルトデータでチャートを追加
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # チャート データ シートのインデックスを設定
    defaultWorksheetIndex = 0

    # チャート データ ワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # 系列を追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # カテゴリを追加
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Rotation3D プロパティを設定
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # 2 番目のチャート系列を取得
    series = chart.chart_data.series[1]

    # 系列データを現在設定
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Overlap 値を設定
    series.parent_series_group.overlap = 100         

    # プレゼンテーションをディスクに保存
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、柱状チャートの 3D バリアントと、[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で公開されている関連 3D タイプをサポートしています。正確で最新の一覧については、インストール済みバージョンの API リファレンス内の [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスター画像を取得できますか？**

はい。チャートを画像としてエクスポートするには、[chart API](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) を使用するか、[スライド全体をレンダリング](/slides/ja/python-net/convert-powerpoint-to-png/) して PNG や JPEG 形式で出力できます。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにチャートをドキュメント、ダッシュボード、ウェブページに埋め込む場合に便利です。

**大規模な 3D チャートの作成およびレンダリングのパフォーマンスはどの程度ですか？**

パフォーマンスはデータ量やビジュアルの複雑さに依存します。最適な結果を得るには、3D エフェクトは最小限に抑え、壁やプロット領域への重いテクスチャの使用を避け、可能であればシリーズあたりのデータ点数を制限し、対象の表示や印刷要件に合わせた解像度とサイズの出力にレンダリングしてください。