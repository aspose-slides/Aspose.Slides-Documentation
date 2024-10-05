---
title: Aspose.Slides for PHP via Java 14.10.0の公開APIと非互換性のある変更
type: docs
weight: 90
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 14.10.0 APIで追加されたすべての[クラス](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)、メソッド、プロパティ、その他の新しい制限や[変更](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)をリストしています。

{{% /alert %}} 
## **公開APIの変更**
### **com.aspose.slides.FieldType::getFooter()メソッドが追加されました**
getFooter()メソッドは、フッターのフィールドタイプを返します。このタイプのフィールドを作成する可能性を実装し、有効なプレゼンテーションのシリアル化のために追加されました。
### **要素com.aspose.slides.ShapeElementFillSource.Ownが削除されました**
要素ShapeElementFillSource.Ownは重複のため削除されました。ShapeElementFillSource.Ownの代わりにShapeElementFillSource.Shapeを使用してください。
### **チャートのデータポイントやカテゴリを削除するメソッドが追加されました**
**次のメソッドは、チャートのデータポイントコレクションからチャートデータポイントを削除することを可能にします：**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**次のメソッドは、含まれるコレクションからチャートカテゴリを削除することを可能にします：**

IChartCategory.remove()

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 400, true);
  $chart->getChartData()->getCategories()->get_Item(0)->remove();// ChartCategory.remove()で削除

  $chart->getChartData()->getCategories()->remove($chart->getChartData()->getCategories()->get_Item(0));// ChartCategoryCollection.remove()で削除

  foreach($chart->getChartData()->getSeries() as $ser) {
    $ser->getDataPoints()->get_Item(0)->remove();// ChartDataPoint.remove()で削除

    $ser->getDataPoints()->remove($ser->getDataPoints()->get_Item(0));// ChartDataPointCollection.remove()で削除

  }
  $pres->save("presentation.pptx", SaveFormat::Pptx);

```
### **廃止されたAspose.Slides.ParagraphFormatメソッドが削除されました**
getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle()および対応するsetメソッドは削除されました。これらは長い間廃止されているとマークされていました。
### **無用で廃止されたコンストラクタが削除されました**
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
