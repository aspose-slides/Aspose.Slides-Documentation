---
title: チャートプロットエリア
type: docs
url: /androidjava/chart-plot-area/
---


## **チャートプロットエリアの幅と高さを取得する**
Aspose.Slides for Android via Javaは、簡単なAPIを提供します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを使用してチャートを追加します。
1. 実際の値を取得する前に[**IChart.validateChartLayout()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--)メソッドを呼び出します。
1. チャートの左上隅に対するチャート要素の実際のX位置（左）を取得します。
1. チャートの左上隅に対するチャート要素の実際の上端を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。

```java
// Presentationクラスのインスタンスを作成
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
Aspose.Slides for Android via Javaは、チャートプロットエリアのレイアウトモードを設定するための簡単なAPIを提供します。メソッド[**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-)および[**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--)が[**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea)クラスおよび[**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea)インターフェイスに追加されました。プロットエリアのレイアウトが手動で定義されている場合、このプロパティはプロットエリアの内部（軸および軸ラベルを含まない）または外部（軸および軸ラベルを含む）によってプロットエリアをレイアウトするかどうかを指定します。 [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType)列挙体で定義されている2つの可能な値があります。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - プロットエリアのサイズは、目盛りと軸ラベルを含まないプロットエリアのサイズを決定することを指定します。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - プロットエリアのサイズは、プロットエリアのサイズ、目盛り、および軸ラベルを決定することを指定します。

サンプルコードは以下の通りです。

```java
// Presentationクラスのインスタンスを作成
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