---
title: チャート
type: docs
weight: 60
url: /ja/python-net/examples/elements/chart/
keywords:
- チャート
- チャートの追加
- チャートへのアクセス
- チャートの削除
- チャートの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でチャートを作成・カスタマイズします。データの追加、系列・軸・ラベルの書式設定、種類の変更、エクスポートが可能で、PPT、PPTX、ODP に対応しています。"
---
**Aspose.Slides for Python via .NET** を使用して、さまざまなチャートタイプの追加、取得、削除、更新の例です。以下のスニペットは基本的なチャート操作を示します。

## **チャートの追加**

このメソッドは、最初のスライドにシンプルなエリアチャートを追加します。

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 最初のスライドにシンプルな列チャートを追加します。
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートへのアクセス**

以下のコードは、シェイプコレクションからチャートを取得します。

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # スライド上の最初のチャートにアクセスします。
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **チャートの削除**

以下のコードは、スライドからチャートを削除します。

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがチャートであると想定します。
        chart = slide.shapes[0]

        # チャートを削除します。
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートデータの更新**

タイトルなど、チャートのプロパティを変更できます。

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがチャートであると想定します。
        chart = slide.shapes[0]

        # チャートのタイトルを変更します。
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```