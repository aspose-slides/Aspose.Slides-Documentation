---
title: Python via Java を使用したプレゼンテーションのドーナツ グラフのカスタマイズ
linktitle: ドーナツ グラフ
type: docs
weight: 30
url: /ja/python-java/doughnut-chart/
keywords:
- ドーナツ グラフ
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でドーナツ グラフを作成・カスタマイズする方法を紹介します。PowerPoint 形式に対応した動的なプレゼンテーションをサポートします。"
---
## **概要**

この記事では、Aspose.Slides でドーナツ グラフをスライドに追加し、中心の穴のサイズを設定し、プレゼンテーションを保存する方法を示します。`setDoughnutHoleSize` メソッドに焦点を当て、コードでこのグラフ タイプをカスタマイズするために必要な基本手順を示します。

また、複数の系列を使用して複数のリングを作成する、分割されたドーナツ グラフを扱う、グラフをラスタ画像または SVG としてエクスポートするなど、関連するドーナツ グラフのシナリオをカバーした簡単な FAQ も含まれています。

## **ドーナツ グラフの中心ギャップを指定する方法**

{{% alert color="info" title="Note" %}}
Python via Java 用 Aspose.Slides は、ドーナツ グラフの穴のサイズを指定することをサポートしています。このセクションでは、例を使って穴のサイズを指定する方法を示します。
{{% /alert %}}

ドーナツ グラフの穴のサイズを指定するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトをインスタンス化します。
1. スライドにドーナツ グラフを追加します。
1. ドーナツ グラフの穴のサイズを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例は、ドーナツ グラフの穴のサイズを設定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # プレゼンテーションをディスクに保存します。
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**複数のリングを持つマルチレベルのドーナツを作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**「分割」されたドーナツ（スライスが分離された状態）はサポートされていますか？**

はい。分割ドーナツの [chart type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/) があり、データポイントに対して爆発プロパティを設定できるため、個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するには？**

グラフは [shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) です。`[raster image](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage)` にレンダリングするか、SVG 画像としてエクスポートできます。