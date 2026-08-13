---
title: Aspose.Slides for Java 15.11.0 的公共 API 及向后不兼容更改
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- 迁移
- 传统代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审查 Aspose.Slides for Java 中的公共 API 更新和重大更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出了所有 [已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) 或 [已删除](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) 类、方法、属性等，以及 Aspose.Slides for Java 15.11.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已删除 com.aspose.slides.DataLabelCollection 类中的过时方法**
已删除 com.aspose.slides.DataLabelCollection 类中的过时方法：

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


#### **已在 Presentation 类中添加了新方法 getFirstSlideNumber() 和 setFirstSlideNumber()**
新方法 getFirstSlideNumber() 和 setFirstSlideNumber() 允许获取或设置演示文稿中第一张幻灯片的编号。
当指定新的第一张幻灯片编号时，所有幻灯片的编号将重新计算。

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```