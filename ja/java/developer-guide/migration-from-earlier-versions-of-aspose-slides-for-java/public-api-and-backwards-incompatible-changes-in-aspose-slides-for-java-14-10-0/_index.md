---
title: Aspose.Slides for Java 14.10.0 の公開 API と後方非互換性のある変更
type: docs
weight: 90
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.10.0 API で追加されたすべての [追加された](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)クラス、メソッド、プロパティなど、新たな制約や他の [変更](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)について記載しています。

{{% /alert %}} 
## **公開 API の変更**
### **com.aspose.slides.FieldType.getFooter() メソッドが追加されました**
getFooter() メソッドはフッターフィールドタイプを返します。このタイプのフィールドを作成する可能性を実装し、有効なプレゼンテーションのシリアライズのために追加されました。
### **要素 com.aspose.slides.ShapeElementFillSource.Own が削除されました**
要素 ShapeElementFillSource.Own は重複しているため削除されました。ShapeElementFillSource.Shape を使用してください。
### **チャートデータポイント、カテゴリ削除のためのメソッドが追加されました**
**チャートデータポイントコレクションからチャートデータポイントを削除するための以下のメソッドが追加されました：**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**含まれているコレクションからチャートカテゴリを削除するための以下のメソッドが追加されました：**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ChartCategory.remove() で削除

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ChartCategoryCollection.remove() で削除

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ChartDataPoint.remove() で削除

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove() で削除

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **廃止された Aspose.Slides.ParagraphFormat メソッドが削除されました**
getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle() および対応する set メソッドが削除されました。これらは長い間廃止とされていました。
### **不要および廃止されたコンストラクタが削除されました**
以下のコンストラクタが削除されました：

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