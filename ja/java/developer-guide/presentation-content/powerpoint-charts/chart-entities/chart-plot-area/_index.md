---
title: チャートプロットエリア
type: docs
url: /java/chart-plot-area/
---


## **チャートプロットエリアの幅と高さを取得する**
Aspose.Slides for Java は、シンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータのチャートを追加します。
1. 実際の値を取得する前に [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) メソッドを呼び出します。
1. チャートの左上隅に対するチャート要素の実際の X 位置（左）を取得します。
1. チャートの左上隅に対するチャート要素の実際の上部を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。

```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **チャートプロットエリアのレイアウトモードを設定する**
Aspose.Slides for Java は、チャートプロットエリアのレイアウトモードを設定するためのシンプルな API を提供します。[**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) と [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) メソッドが [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) クラスと [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea) インターフェースに追加されました。プロットエリアのレイアウトが手動で定義された場合、このプロパティは軸および軸ラベルを含まない内部によってプロットエリアをレイアウトするか、外部（軸および軸ラベルを含む）によってレイアウトするかを指定します。[**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType) 列挙型では、2つの可能な値が定義されています。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - プロットエリアのサイズは、ティックマークおよび軸ラベルを含まないプロットエリアのサイズを決定することを指定します。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - プロットエリアのサイズは、ティックマークおよび軸ラベルを含むプロットエリアのサイズを決定することを指定します。

サンプルコードは以下に示します。

```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```