---
title: Aspose.Slides for Java 15.8.0 の公開 API および後方互換性のない変更
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java の公開 API の更新および破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---
{{% alert color="info" %}} 
このページでは、Aspose.Slides for Java 15.8.0 APIで導入された、[追加](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) または [削除](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) クラス、メソッド、プロパティなど、その他の変更を一覧表示します。
{{% /alert %}} 
## **公開 API の変更**
#### **IChartSeries と ChartSeries にメソッド getDoughnutHoleSize()、setDoughnutHoleSize(byte) が追加されました**
ドーナツ グラフの穴のサイズを指定します。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```