---
title: Javaでプレゼンテーションチャートのプロット領域をカスタマイズ
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
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションのチャートプロット領域をカスタマイズする方法を学びましょう。スライドのビジュアルを簡単に向上させることができます。"
---

## **チャートプロット領域の幅と高さを取得**
Aspose.Slides for Java はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. 実際の値を取得する前に、[IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) メソッドを呼び出します。
5. チャート要素の実際の X 位置（左）を、チャートの左上隅からの相対位置として取得します。
6. チャート要素の実際の上位置を、チャートの左上隅からの相対位置として取得します。
7. チャート要素の実際の幅を取得します。
8. チャート要素の実際の高さを取得します。
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


## **チャートプロット領域のレイアウトモードを設定**
Aspose.Slides for Java は、チャートプロット領域のレイアウトモードを設定するシンプルな API を提供します。メソッド [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) と [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) が [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) クラスおよび [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea) インターフェイスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティはプロット領域を内部（軸や軸ラベルを含まない）でレイアウトするか、外部（軸や軸ラベルを含む）でレイアウトするかを指定します。可能な値は [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType) 列挙体で定義されています。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - プロット領域のサイズがプロット領域自体のサイズを決定し、目盛りや軸ラベルは含めないことを指定します。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - プロット領域のサイズがプロット領域、目盛り、および軸ラベルのサイズを決定することを指定します。

以下にサンプルコードを示します。
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


## **FAQ**

**実際の x、実際の y、実際の幅、実際の高さはどの単位で返されますか？**

ポイント単位です。1インチ = 72ポイントです。これらは Aspose.Slides の座標単位です。

**プロット領域はコンテンツ面でチャート領域とどのように異なりますか？**

プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。チャート領域には周囲の要素（タイトル、凡例など）が含まれます。3D チャートの場合、プロット領域には壁/床と軸も含まれます。

**レイアウトが手動の場合、プロット領域の x、y、幅、高さはどのように解釈されますか？**

それらはチャート全体サイズに対する割合（0–1）です。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後にプロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側にあるチャート領域に配置されますが、レイアウトと利用可能なスペースに影響を与えるため、Auto‑position が有効な場合にプロット領域がシフトすることがあります。（これは PowerPoint のチャートで標準的な動作です。）