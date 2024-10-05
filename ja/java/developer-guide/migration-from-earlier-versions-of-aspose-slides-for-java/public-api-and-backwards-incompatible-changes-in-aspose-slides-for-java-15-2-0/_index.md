---
title: Aspose.Slides for Java 15.2.0における公開APIと後方互換性のない変更
type: docs
weight: 110
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.2.0 APIで追加されたすべての[クラス](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)、メソッド、プロパティ、および新たな制約やその他の[変更](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)を一覧表示します。

{{% /alert %}} {{% alert color="primary" %}} 

Aspose.Slides for Java 15.2.0で修正される既知の問題がいくつかの画像のバレットおよびWordArtオブジェクトにあります。

{{% /alert %}} 
## **公開APIの変更**
### **addDataPointForDoughnutSeriesメソッドが追加されました**
IChartDataPointCollection.addDataPointForDoughnutSeries()メソッドの2つのオーバーロードが追加され、ドーナツタイプの系列にデータポイントを追加できるようになりました。
### **com.aspose.slides.SmartArtShapeクラスがcom.aspose.slides.GeometryShapeクラスから継承されました**
com.aspose.slides.SmartArtShapeクラスがcom.aspose.slides.GeometryShapeクラスから継承されました。この変更により、Aspose.Slidesのオブジェクトモデルが改善され、SmartArtShapeクラスに新しい機能が追加されました。
### **IGradientStopCollection.add(...)およびIGradientStopCollection.insert(...)メソッドが変更されました**
IGradientStop add(float position, int presetColor)のシグネチャがIGradientStop addPresetColor(float position, int presetColor)のシグネチャに置き換えられました。

IGradientStopCollectionメソッドIGradientStop add(float position, SchemeColor schemeColor)のシグネチャがIGradientStop addSchemeColor(float position, int schemeColor)のシグネチャに置き換えられました。

IGradientStopCollectionメソッドvoid insert(int index, float position, int presetColor)のシグネチャがvoid insertPresetColor(int index, float position, int presetColor)のシグネチャに置き換えられました。

IGradientStopCollectionメソッドvoid insert(int index, float position, SchemeColor schemeColor)のシグネチャがvoid insertSchemeColor(int index, float position, int schemeColor)のシグネチャに置き換えられました。
### **java.awt.Color getAutomaticSeriesColor()メソッドがcom.aspose.slides.IChartSeriesに追加されました**
getAutomaticSeriesColor()メソッドは、系列インデックスとチャートスタイルに基づいた系列の自動色を返します。この色は、FillTypeがNotDefinedの場合にデフォルトで使用されます。
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **インデックスによるチャートデータポイントおよびチャートカテゴリの削除メソッドが追加されました**
IChartDataPointCollection.removeAt(int index)メソッドが追加され、インデックスによってチャートデータポイントを削除できるようになりました。
IChartCategoryCollection.removeAt(int index)メソッドが追加され、インデックスによってチャートカテゴリを削除できるようになりました。
### **PptXPptY値がcom.aspose.slides.PropertyType列挙型に追加されました**
PptXPptY値がシリアル化の問題修正の範囲内でcom.aspose.slides.PropertyType列挙型に追加されました。