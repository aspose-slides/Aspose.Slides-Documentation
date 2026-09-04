---
title: チャート
type: docs
weight: 60
url: /ja/python-java/examples/elements/chart/
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
- Java
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションで、Aspose.Slides for Python via Java を使用してチャートを作成、アクセス、削除、および更新します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用してプレゼンテーションにチャートを追加、アクセス、削除、更新する方法を示します。

パッケージは[Installation](/slides/ja/python-java/installation/)に記載された手順でインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。最初に追加のサンプルを実行して、残りの例で使用する `chart.pptx` を作成してください。

## **チャートの追加**

最初のスライドにエリアチャートを追加し、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 最初のスライドにエリアチャートを追加します。
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャートへのアクセス**

最初のスライドのシェイプコレクション内で最初のチャートを見つけます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # スライド上の最初のチャートにアクセスします。
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **チャートの削除**

スライドから最初のチャートを削除し、変更されたプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # スライド上の最初のチャートを検索して削除します。
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート データの更新**

チャートのタイトルを表示し、テキストを変更して、更新されたプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # スライド上の最初のチャートを検索します。
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # チャートのタイトルを表示し、テキストを変更します。
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```