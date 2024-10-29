---
title: Aspose.Slides for PHP via Java 15.2.0におけるパブリックAPIおよび後方互換性のない変更
type: docs
weight: 110
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.2.0 APIで追加されたすべての[追加された](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)クラス、メソッド、プロパティ、および新しい制限やその他の[変更](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)を一覧にしています。

{{% /alert %}} {{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 15.2.0では、一部の画像の箇条書きやWordArtオブジェクトに既知の問題がありますが、これらは修正される予定です。

{{% /alert %}} 
## **パブリックAPIの変更**
### **addDataPointForDoughnutSeriesメソッドが追加されました**
Doughnut型のシリーズにデータポイントを追加するために、IChartDataPointCollection.addDataPointForDoughnutSeries()メソッドの2つのオーバーロードが追加されました。
### **com.aspose.slides.SmartArtShapeクラスはcom.aspose.slides.GeometryShapeクラスから継承されました**
com.aspose.slides.SmartArtShapeクラスはcom.aspose.slides.GeometryShapeクラスから継承されました。この変更はAspose.Slidesオブジェクトモデルを改善し、SmartArtShapeクラスに新しい機能を追加します。
### **IGradientStopCollection.add(...)およびIGradientStopCollection.insert(...)メソッドが変更されました**
IGradientStop add(float position, int presetColor)のシグネチャはIGradientStop addPresetColor(float position, int presetColor)のシグネチャに置き換えられました。

IGradientStopCollectionメソッドIGradientStop add(float position, SchemeColor schemeColor)のシグネチャはIGradientStop addSchemeColor(float position, int schemeColor)のシグネチャに置き換えられました。

IGradientStopCollectionメソッドvoid insert(int index, float position, int presetColor)のシグネチャはvoid insertPresetColor(int index, float position, int presetColor)のシグネチャに置き換えられました。

IGradientStopCollectionメソッドvoid insert(int index, float position, SchemeColor schemeColor)のシグネチャはvoid insertSchemeColor(int index, float position, int schemeColor)のシグネチャに置き換えられました。
### **java.awt.Color getAutomaticSeriesColor()メソッドがcom.aspose.slides.IChartSeriesに追加されました**
getAutomaticSeriesColor()メソッドは、シリーズインデックスとチャートスタイルに基づいてシリーズの自動色を返します。この色は、FillTypeがNotDefinedの場合にデフォルトで使用されます。
﻿

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
  for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
    $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
  }
```
### **インデックスによるチャートデータポイントおよびチャートカテゴリを削除するメソッドが追加されました**
IChartDataPointCollection.removeAt(int index)メソッドが、インデックスによるチャートデータポイントを削除するために追加されました。
IChartCategoryCollection.removeAt(int index)メソッドが、インデックスによるチャートカテゴリを削除するために追加されました。
### **PptXPptY値がcom.aspose.slides.PropertyType列挙型に追加されました**
PptXPptY値がシリアル化問題の修正の範囲内でcom.aspose.slides.PropertyType列挙型に追加されました。