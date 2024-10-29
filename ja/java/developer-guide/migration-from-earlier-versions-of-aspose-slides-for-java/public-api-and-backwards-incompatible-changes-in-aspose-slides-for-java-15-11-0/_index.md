---
title: Aspose.Slides for Java 15.11.0における公開APIおよび後方互換性のない変更
type: docs
weight: 190
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}}

このページでは、Aspose.Slides for Java 15.11.0 APIで追加されたすべての[class](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/)または[削除された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/)クラス、メソッド、プロパティなど、その他の変更を一覧表示します。

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

#### **Presentationクラスに新しいメソッドgetFirstSlideNumber()とsetFirstSlideNumber()が追加されました**
新しいメソッドgetFirstSlideNumber()とsetFirstSlideNumber()は、プレゼンテーション内の最初のスライドの番号を取得または設定することを可能にします。新しい最初のスライド番号の値が指定されると、すべてのスライド番号が再計算されます。

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```