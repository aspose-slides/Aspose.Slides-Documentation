---
title: Java でプレゼンテーション チャートのプロット領域をカスタマイズ
linktitle: プロット領域
type: docs
url: /ja/java/chart-plot-area/
keywords:
- チャート
- プロット領域
- プロット領域の幅
- プロット領域の高さ
- プロット領域のサイズ
- レイアウトモード
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションのチャート プロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを手軽に向上させましょう。"
---

## **チャートプロット領域の幅と高さの取得**
Aspose.Slides for Java はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 実際の値を取得する前にメソッド [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) を呼び出します。
1. チャート要素の左上隅に対する実際の X 位置（左）を取得します。
1. チャート要素の左上隅に対する実際の上位置を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。
```java
// Presentation クラスのインスタンスを作成
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


## **チャートプロット領域のレイアウトモードの設定**
Aspose.Slides for Java はチャートプロット領域のレイアウトモードを設定するシンプルな API を提供します。[**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) と [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) メソッドが [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) クラスと [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea) インターフェイスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティはプロット領域を内部（軸と軸ラベルを除く）または外部（軸と軸ラベルを含む）でレイアウトするかを指定します。可能な値は [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType) 列挙型で定義されています。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - プロット領域のサイズがプロット領域のサイズを決定し、目盛りや軸ラベルは含まれません。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - プロット領域のサイズがプロット領域、目盛り、および軸ラベルのサイズを決定します。

サンプルコードは以下に示します。
```java
// Presentation クラスのインスタンスを作成
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


## **FAQ**

**実際の x、実際の y、実際の幅、実際の高さはどの単位で返されますか？**

ポイント単位です。1 インチ = 72 ポイント。これは Aspose.Slides の座標単位です。

**プロット領域はコンテンツの観点でチャート領域とどう異なりますか？**

プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。チャート領域には周囲の要素（タイトル、凡例など）が含まれます。3D チャートの場合、プロット領域には壁/床と軸も含まれます。

**レイアウトが手動の場合、プロット領域の x、y、幅、高さはどのように解釈されますか？**

チャート全体サイズの割合（0–1）として解釈されます。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後にプロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側にあるチャート領域に配置されますが、レイアウトと利用可能スペースに影響するため、自动配置が有効な場合にプロット領域がシフトすることがあります。（これは PowerPoint チャートの標準動作です。）