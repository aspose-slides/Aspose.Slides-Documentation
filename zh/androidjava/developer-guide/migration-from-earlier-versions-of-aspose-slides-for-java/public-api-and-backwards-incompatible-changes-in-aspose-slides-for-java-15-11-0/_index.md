---
title: Aspose.Slides for Java 15.11.0 的公共 API 和不向后兼容的更改
type: docs
weight: 190
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.11.0 API 中 [添加的](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) 或 [删除的](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) 类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **com.aspose.slides.DataLabelCollection 类中的过时方法已被删除**
com.aspose.slides.DataLabelCollection 类中的过时方法已被删除：

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


#### **Presentation 类中新增了方法 getFirstSlideNumber() 和 setFirstSlideNumber()**
新增的方法 getFirstSlideNumber() 和 setFirstSlideNumber() 可用于获取或设置演示文稿中的第一张幻灯片的编号。
当指定一个新的第一张幻灯片编号值时，所有幻灯片编号将重新计算。

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```