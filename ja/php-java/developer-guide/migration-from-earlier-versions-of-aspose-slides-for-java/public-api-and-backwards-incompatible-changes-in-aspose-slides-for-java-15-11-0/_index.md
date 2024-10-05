---
title: Aspose.Slides for PHP via Java 15.11.0における公開APIと後方互換性のない変更
type: docs
weight: 190
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

このページには、Aspose.Slides for PHP via Java 15.11.0 APIで追加された[クラス](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/)や[削除された](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/)クラス、メソッド、プロパティなど、他の変更のリストが載っています。

{{% /alert %}} 
## **公開APIの変更**
#### **com.aspose.slides.DataLabelCollectionクラスの廃止されたメソッドが削除されました**
com.aspose.slides.DataLabelCollectionクラスの廃止されたメソッドが削除されました：

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **PresentationクラスにgetFirstSlideNumber()とsetFirstSlideNumber()の新しいメソッドが追加されました**
新しいメソッドgetFirstSlideNumber()とsetFirstSlideNumber()は、プレゼンテーション内の最初のスライドの番号を取得または設定できます。
新しい最初のスライド番号が指定されると、すべてのスライド番号が再計算されます。

```php
  $pres = new Presentation($path);
  $firstSlideNumber = $pres->getFirstSlideNumber();
  $pres->setFirstSlideNumber(10);
  $pres->save($newPath, SaveFormat::Pptx);

```