---
title: Aspose.Slides for Java 15.2.0 におけるパブリック API および後方互換性のない変更
type: docs
weight: 110
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

このページには、Aspose.Slides for Java 15.2.0 API で追加されたすべての [追加された](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)クラス、メソッド、プロパティなど、新たに導入された制限やその他の [変更](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)がリストされています。

{{% /alert %}} {{% alert color="primary" %}} 

Aspose.Slides for Java 15.2.0では、一部の画像の箇条書きやWordArtオブジェクトに既知の問題があります。これらは修正されます。

{{% /alert %}} 
## **パブリック API の変更**
### **addDataPointForDoughnutSeries メソッドが追加されました**
Doughnut タイプのシリーズにデータポイントを追加するための IChartDataPointCollection.addDataPointForDoughnutSeries() メソッドの 2 つのオーバーロードが追加されました。
### **com.aspose.slides.SmartArtShape クラスは com.aspose.slides.GeometryShape クラスから継承されました**
com.aspose.slides.SmartArtShape クラスは com.aspose.slides.GeometryShape クラスから継承されました。この変更により、Aspose.Slides オブジェクトモデルが改善され、SmartArtShape クラスに新しい機能が追加されます。
### **IGradientStopCollection.add(...) および IGradientStopCollection.insert(...) メソッドが変更されました**
IGradientStop add(float position, int presetColor) の署名は IGradientStop addPresetColor(float position, int presetColor) 署名に置き換えられます。

IGradientStopCollection メソッドの IGradientStop add(float position, SchemeColor schemeColor) の署名は IGradientStop addSchemeColor(float position, int schemeColor) 署名に置き換えられます。

IGradientStopCollection メソッド void insert(int index, float position, int presetColor) の署名は void insertPresetColor(int index, float position, int presetColor) 署名に置き換えられます。

IGradientStopCollection メソッド void insert(int index, float position, SchemeColor schemeColor) の署名は void insertSchemeColor(int index, float position, int schemeColor) 署名に置き換えられます。
### **java.awt.Color getAutomaticSeriesColor() メソッドが com.aspose.slides.IChartSeries に追加されました**
getAutomaticSeriesColor() メソッドは、シリーズインデックスとチャートスタイルに基づいた自動的なシリーズカラーを返します。この色は、FillType が NotDefined の場合にデフォルトで使用されます。
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **インデックスによるチャートデータポイントおよびチャートカテゴリを削除するためのメソッドが追加されました**
IChartDataPointCollection.removeAt(int index) メソッドが、インデックスによるチャートデータポイントを削除するために追加されました。
IChartCategoryCollection.removeAt(int index) メソッドが、インデックスによるチャートカテゴリを削除するために追加されました。
### **PptXPptY 値が com.aspose.slides.PropertyType 列挙型に追加されました**
PptXPptY 値が、シリアリゼーション問題の修正の範囲内で com.aspose.slides.PropertyType 列挙型に追加されました。