---
title: "Aspose.Slides for Java 16.1.0 的公共 API 与向后不兼容更改"
linktitle: "Aspose.Slides for Java 16.1.0"
type: docs
weight: 200
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
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
description: "审查 Aspose.Slides for Java 中的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示解决方案。"
---
{{% alert color="info" %}} 

此页面列出了所有已添加[已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)或已移除[已移除](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)的类、方法、属性等，以及在 Aspose.Slides for Java 16.1.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**


#### **已向 IChartTextBlockFormat 和 ITextFrameFormat 接口添加了 getRotationAngle() 和 setRotationAngle() 方法**
已向接口 com.aspose.slides.IChartTextBlockFormat 和 com.aspose.slides.ITextFrameFormat 添加了 getRotationAngle() 和 setRotationAngle() 方法。这些方法提供对应用于边界框中文本的自定义旋转角度的访问。

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```