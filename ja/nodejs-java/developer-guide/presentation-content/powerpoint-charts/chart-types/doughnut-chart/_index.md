---
title: ドーナツチャート
type: docs
weight: 30
url: /ja/nodejs-java/doughnut-chart/
---

## **ドーナツチャートの中心ギャップを変更する**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java は、ドーナツチャートの穴のサイズを指定できるようになりました。このトピックでは、例を使ってドーナツチャートの穴のサイズの指定方法を確認します。

{{% /alert %}} 

ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください。

1. Presentation オブジェクトをインスタンス化します。
1. スライドにドーナツチャートを追加します。
1. ドーナツチャートの穴のサイズを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツチャートの穴のサイズを設定しています。
```javascript
// Presentationクラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // プレゼンテーションを書き込む
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**複数のリングを持つマルチレベルドーナツを作成できますか？**

はい。単一のドーナツチャートに複数の系列を追加すると、各系列が個別のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**「エクスプローデッド」ドーナツ（スライスが分離されたもの）はサポートされていますか？**

はい。Exploded Doughnut（エクスプローデッドドーナツ）というチャートタイプと、データポイントに対するエクスプロージョンプロパティがあり、個々のスライスを分離できます。

**レポート用にドーナツチャートの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。ラスタ画像にレンダリングしたり、チャートをSVG画像としてエクスポートしたりできます。