---
title: Aspose.Slides for Java 15.2.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}}

このページは、Aspose.Slides for Java 15.2.0 APIで導入された、すべての[追加された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)クラス、メソッド、プロパティなど、新しい制限やその他の[変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)を一覧表示します。

{{% /alert %}} {{% alert color="info" %}}

一部の画像付き箇条書きとWordArtオブジェクトに既知の問題があり、これらはAspose.Slides for Java 15.2.0で修正されます。

{{% /alert %}} 
## **パブリック API の変更**
### **addDataPointForDoughnutSeries メソッドが追加されました**
IChartDataPointCollection.addDataPointForDoughnutSeries() メソッドの 2 つのオーバーロードが追加され、ドーナツ型シリーズにデータポイントを追加できるようになりました。
### **com.aspose.slides.SmartArtShape クラスが com.aspose.slides.GeometryShape クラスから継承されました**
com.aspose.slides.SmartArtShape クラスが com.aspose.slides.GeometryShape クラスから継承されました。この変更により Aspose.Slides のオブジェクトモデルが改善され、SmartArtShape クラスに新機能が追加されます。
### **IGradientStopCollection.add(...) および IGradientStopCollection.insert(...) メソッドが変更されました**
IGradientStop のシグネチャ add(float position, int presetColor) は、IGradientStop addPresetColor(float position, int presetColor) に置き換えられました。

IGradientStopCollection のメソッド IGradientStop add(float position, SchemeColor schemeColor) のシグネチャは、IGradientStop addSchemeColor(float position, int schemeColor) に置き換えられました。

IGradientStopCollection のメソッド void insert(int index, float position, int presetColor) のシグネチャは、void insertPresetColor(int index, float position, int presetColor) に置き換えられました。

IGradientStopCollection のメソッド void insert(int index, float position, SchemeColor schemeColor) のシグネチャは、void insertSchemeColor(int index, float position, int schemeColor) に置き換えられました。
### **java.awt.Color getAutomaticSeriesColor() メソッドが com.aspose.slides.IChartSeries に追加されました**
getAutomaticSeriesColor() メソッドは、シリーズのインデックスとチャートスタイルに基づく自動カラーを返します。FillType が NotDefined の場合、このカラーがデフォルトで使用されます。
 
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **インデックスでチャート データポイントとチャート カテゴリを削除するメソッドが追加されました**
IChartDataPointCollection.removeAt(int index) メソッドが追加され、インデックスでチャート データポイントを削除できるようになりました。
IChartCategoryCollection.removeAt(int index) メソッドが追加され、インデックスでチャート カテゴリを削除できるようになりました。
### **PptXPptY 値が com.aspose.slides.PropertyType 列挙体に追加されました**
シリアライズ問題の修正の一環として、PptXPptY 値が com.aspose.slides.PropertyType 列挙体に追加されました。