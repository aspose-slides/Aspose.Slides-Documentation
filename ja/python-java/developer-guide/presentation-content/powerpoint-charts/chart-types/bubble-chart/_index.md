---
title: Python を使用してプレゼンテーションのバブルチャートをカスタマイズ
linktitle: バブルチャート
type: docs
url: /ja/python-java/bubble-chart/
keywords:
- バブルチャート
- バブルサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint で強力なバブルチャートを作成・カスタマイズし、データの可視化を簡単に向上させましょう。"
---
## **概要**

この項目では Aspose.Slides でバブルチャートを操作する方法を示します。主に、[setBubbleSizeScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) メソッドによるバブルサイズのスケーリングと、[setBubbleSizeRepresentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) メソッドによるバブルサイズ値の表現方法の制御という 2 つのカスタマイズオプションをカバーします。

例では、バブルチャートの作成、サイズスケーリングの調整、バブルサイズの表現を幅に切り替える方法を示しています。また、記事の最後には「3-D バブル」チャートタイプのサポートに関する簡単な FAQ、実用的なチャートの上限はパフォーマンスと対象 PowerPoint バージョンに依存すること、エクスポート時は Aspose.Slides のレンダリングエンジンによりチャートの外観が維持されることを説明しています。

## **バブルチャートのサイズスケーリング**
Aspose.Slides for Python via Java は、[ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getBubbleSizeScale)、[ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale)、および [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) メソッドを通じてバブルチャートのサイズスケーリングをサポートします。以下の例はバブルサイズをスケーリングする方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **データをバブルチャートのサイズとして表す**
[**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) と [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) は [ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/) クラスで利用可能です。バブルサイズ表現は、バブルチャート内でバブルサイズ値をどのように表すかを指定します。可能な値は [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bubblesizerepresentationtype/#Area) と [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bubblesizerepresentationtype/#Width) です。[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/ja/python-java/aspose.slides/bubblesizerepresentationtype/) 列挙型は、データをバブルチャートのサイズとして表す方法を定義します。以下の例は幅を使用してバブルサイズを表す方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**「3-D エフェクト付きバブルチャート」はサポートされていますか？ 通常のバブルチャートとどのように異なりますか？**

はい。"Bubble with 3-D" という別のチャートタイプが用意されています。バブルに 3-D スタイルが適用されますが、追加の軸は追加されません。データは X‑Y‑S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/) クラスで利用できます。

**バブルチャートの系列数やポイント数に上限はありますか？**

API レベルでのハードな上限はありません。制限はパフォーマンスと対象 PowerPoint バージョンによって決まります。可読性と描画速度を考慮して、ポイント数は適切な範囲に抑えることが推奨されます。

**エクスポート（PDF、画像など）はバブルチャートの外観にどのように影響しますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが実行します。ラスタ/ベクタ形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されるため、印刷用には十分な DPI を選択してください。