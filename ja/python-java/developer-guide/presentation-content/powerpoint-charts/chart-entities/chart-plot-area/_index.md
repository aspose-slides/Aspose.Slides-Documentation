---
title: Python でプレゼンテーション チャートのプロット領域をカスタマイズ
linktitle: プロット領域
type: docs
url: /ja/python-java/chart-plot-area/
keywords:
- チャート
- プロット領域
- プロット領域の幅
- プロット領域の高さ
- プロット領域のサイズ
- レイアウト モード
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションのチャート プロット領域をカスタマイズする方法を紹介します。スライドのビジュアルを簡単に向上させましょう。"
---
## **概要**

この記事では、Aspose.Slidesでチャートのプロット領域を操作する方法を示します。チャートのレイアウトを検証し、その後 X、Y、幅、高さの値を読み取ることで、プロット領域の実際の位置とサイズを取得する方法を説明します。

また、レイアウトが手動で設定されている場合に、[LayoutTargetType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layouttargettype/) を使用してプロット領域のレイアウトモードを構成する方法も示します。これにより、プロット領域が内部領域のみで計算されるか、軸と軸ラベルを含む外部領域で計算されるかを定義できます。

## **チャートのプロット領域の幅と高さを取得する方法**

Aspose.Slides for Python via Java は、チャートのプロット領域の実際の位置とサイズを取得するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルト データでチャートを追加します。
4. [Chart.validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout) メソッドを、実際の値を取得する前に呼び出します。
5. チャート要素の左端（X 位置）を、チャートの左上隅に対する実際の位置として取得します。
6. チャート要素の上端（Y 位置）を、チャートの左上隅に対する実際の位置として取得します。
7. チャート要素の実際の幅を取得します。
8. チャート要素の実際の高さを取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **チャートのプロット領域のレイアウトモードを設定する**

Aspose.Slides for Python via Java は、チャートのプロット領域のレイアウトモードを設定するためのシンプルな API を提供します。[ChartPlotArea](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/) クラスで [setLayoutTargetType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) および [getLayoutTargetType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) メソッドが利用可能です。プロット領域のレイアウトが手動で定義されている場合、この設定は内部（軸と軸ラベルを除く）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。[LayoutTargetType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layouttargettype/) 列挙体で定義されている 2 つの値があります。

- [Inner](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layouttargettype/#Inner) は、目盛りと軸ラベルを除いたプロット領域のサイズであることを指定します。
- [Outer](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layouttargettype/#Outer) は、目盛りと軸ラベルを含むプロット領域のサイズであることを指定します。

以下にサンプルコードを示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**実際の X、実際の Y、実際の幅、実際の高さはどの単位で返されますか？**  
ポイント単位です。1 インチ = 72 ポイントです。これは Aspose.Slides の座標単位です。

**プロット領域はコンテンツ的にチャート領域とどう違いますか？**  
プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。一方、チャート領域はそれを取り巻く要素（タイトル、凡例など）を含みます。3D チャートの場合、プロット領域は壁・床および軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**  
チャート全体サイズに対する比率（0〜1）として解釈されます。このモードでは自動配置が無効になり、設定した比率が使用されます。

**凡例を追加または移動した後にプロット領域の位置が変わったのはなぜですか？**  
凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトや利用可能なスペースに影響するため、自動配置が有効な場合はプロット領域が移動することがあります。（これは PowerPoint のチャートで標準的な動作です。）