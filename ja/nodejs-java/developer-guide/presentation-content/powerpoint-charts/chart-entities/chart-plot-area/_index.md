---
title: チャート プロット領域
type: docs
url: /ja/nodejs-java/chart-plot-area/
---

## **Chartプロット領域の幅と高さを取得する**

Aspose.Slides for Node.js via Java はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成する。
1. 最初のスライドにアクセスする。
1. デフォルトデータでチャートを追加する。
1. 実際の値を取得する前にメソッド[Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--)を呼び出す。
1. チャート要素の左上隅に対する実際の X 位置（左）を取得する。
1. チャート要素の左上隅に対する実際の上位置を取得する。
1. チャート要素の実際の幅を取得する。
1. チャート要素の実際の高さを取得する。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Chartプロット領域のレイアウトモードを設定する**

Aspose.Slides for Node.js via Java は、チャートプロット領域のレイアウトモードを設定するシンプルな API を提供します。[**setLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) および [**getLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) メソッドが [**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea) クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティはプロット領域を内部（軸や軸ラベルを含まない）でレイアウトするか外部（軸や軸ラベルを含む）でレイアウトするかを指定します。可能な値は [**LayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType) 列挙型で定義されています。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Inner) – 軸目盛りや軸ラベルを含まないプロット領域サイズがプロット領域サイズを決定することを指定します。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Outer) – 軸目盛りと軸ラベルを含むプロット領域サイズがプロット領域サイズを決定することを指定します。

サンプルコードは以下です。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**実際の X、実際の Y、実際の幅、実際の高さはどの単位で返されますか？**

ポイント単位です。1 インチ = 72 ポイント。これは Aspose.Slides の座標単位です。

**プロット領域は内容的にチャート領域とどう違いますか？**

プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。チャート領域はタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域には壁・床と軸も含まれます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**

チャート全体サイズに対する割合（0–1）として解釈されます。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後にプロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側にあるチャート領域に配置されますが、レイアウトと利用可能スペースに影響を与えるため、自動配置が有効な場合はプロット領域がシフトすることがあります。これは PowerPoint のチャートで標準的な動作です。