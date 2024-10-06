---
title: ドーナツチャート
type: docs
weight: 30
url: /ja/androidjava/doughnut-chart/
---

## **ドーナツチャートの中心の隙間を変更する**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Javaでは、ドーナツチャートの穴のサイズを指定することがサポートされるようになりました。このトピックでは、ドーナツチャートの穴のサイズを指定する方法を例を用いて示します。

{{% /alert %}} 

ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)オブジェクトをインスタンス化します。
1. スライドにドーナツチャートを追加します。
1. ドーナツチャートの穴のサイズを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツチャートの穴のサイズを設定しています。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // プレゼンテーションをディスクに書き込む
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```