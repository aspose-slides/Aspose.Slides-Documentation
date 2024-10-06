---
title: Aspose.Slides for Java 14.10.0における公開APIと後方互換性のない変更
type: docs
weight: 90
url: /ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.10.0 APIで追加されたすべての[クラス](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)、メソッド、プロパティなど、新しい制限事項やその他の[変更](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)を一覧表示しています。

{{% /alert %}} 
## **公開APIの変更**
### **com.aspose.slides.FieldType.getFooter()メソッドが追加されました**
getFooter()メソッドは、フッターのフィールドタイプを返します。このタイプのフィールドを作成する可能性の実装と、有効なプレゼンテーションシリアル化のために追加されました。
### **要素com.aspose.slides.ShapeElementFillSource.Ownが削除されました**
ShapeElementFillSource.Own要素は重複として削除されました。ShapeElementFillSource.Ownの代わりにShapeElementFillSource.Shapeを使用してください。
### **チャートデータポイント、カテゴリ削除のためのメソッドが追加されました**
**チャートデータポイントコレクションからチャートデータポイントを削除するための次のメソッドが追加されました：**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()  

**含まれるコレクションからチャートカテゴリを削除するための次のメソッドが追加されました：**

IChartCategory.remove()  

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ChartCategory.remove()を使用して削除

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ChartCategoryCollection.remove()を使用して削除

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ChartDataPoint.remove()を使用して削除

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()を使用して削除

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **廃止されたAspose.Slides.ParagraphFormatメソッドが削除されました**
getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle()および対応するsetメソッドが削除されました。これらは長い間廃止としてマークされていました。
### **不要で廃止されたコンストラクタが削除されました**
次のコンストラクタが削除されました：

com.aspose.slides.AlphaBiLevel(float)  
com.aspose.slides.AlphaModulateFixed(float)  
com.aspose.slides.AlphaReplace(float)  
com.aspose.slides.BiLevel(float)  
com.aspose.slides.Blur(double, boolean)  
com.aspose.slides.HSL(float, float, float)  
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)  
com.aspose.slides.Luminance(float, float)  
com.aspose.slides.Tint(float, float)  
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)  
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)  
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)  