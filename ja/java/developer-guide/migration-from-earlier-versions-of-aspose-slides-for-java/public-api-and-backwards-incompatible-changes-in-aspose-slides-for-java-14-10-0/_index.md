---
title: Aspose.Slides for Java 14.10.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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
description: Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、および ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。
---
{{% alert color="info" %}} 

このページでは、[added](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) クラス、メソッド、プロパティなど、すべての新しい制限やその他の[changes](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) が Aspose.Slides for Java 14.10.0 APIで導入されたことを一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **com.aspose.slides.FieldType.getFooter() メソッドが追加されました**
getFooter() メソッドはフッターフィールドのタイプを返します。このメソッドは、このタイプのフィールドを作成できるようにする実装と、有効なプレゼンテーションのシリアライズのために追加されました。
### **要素 com.aspose.slides.ShapeElementFillSource.Own が削除されました**
要素 ShapeElementFillSource.Own は重複しているため削除されました。ShapeElementFillSource.Own の代わりに ShapeElementFillSource.Shape を使用してください。
### **チャート データ ポイントやカテゴリの削除に関するメソッドが追加されました**
**チャート データ ポイント コレクションからチャート データ ポイントを削除できる次のメソッドが追加されました:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**含まれるコレクションからチャート カテゴリを削除できる次のメソッドが追加されました:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ChartCategory.remove() を使用して削除

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ChartCategoryCollection.remove() を使用して削除

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ChartDataPoint.remove() を使用して削除

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove() を使用して削除

}

pres.save("presentation.pptx", SaveFormat.Pptx);
```
### **廃止された Aspose.Slides.ParagraphFormat メソッドが削除されました**
メソッド getBulletChar()、getBulletColor()、getBulletColorFormat()、getBulletFont()、getBulletHeight()、getBulletType()、isBulletHardColor()、isBulletHardFont()、getNumberedBulletStartWith()、getNumberedBulletStyle() および対応する set メソッドは削除されました。これらは以前から廃止済みとしてマークされていました。
### **不要かつ廃止されたコンストラクタが削除されました**
以下のコンストラクタが削除されました:

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