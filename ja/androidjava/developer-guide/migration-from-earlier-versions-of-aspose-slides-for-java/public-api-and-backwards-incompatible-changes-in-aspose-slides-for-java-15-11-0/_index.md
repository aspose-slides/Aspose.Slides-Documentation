---
title: Aspose.Slides for Java 15.11.0の公開APIと後方互換性のない変更
type: docs
weight: 190
url: /ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.11.0 API で導入されたすべての [追加された](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) または [削除された](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) クラス、メソッド、プロパティなどの変更をリストしています。

{{% /alert %}} 
## **公開APIの変更**
#### **com.aspose.slides.DataLabelCollection クラスの廃止されたメソッドが削除されました**
com.aspose.slides.DataLabelCollection クラスの廃止されたメソッドが削除されました：

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


#### **新しいメソッド getFirstSlideNumber() と setFirstSlideNumber() が Presentation クラスに追加されました**
新しいメソッド getFirstSlideNumber() と setFirstSlideNumber() は、プレゼンテーション内の最初のスライドの番号を取得または設定するために使用されます。
新しい最初のスライド番号の値が指定されると、すべてのスライド番号が再計算されます。

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```