---
title: Aspose.Slides for Java 16.1.0 的公共 API 與向後相容性中斷變更
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有在 Aspose.Slides for Java 16.1.0 API 中[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)或[已移除](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)的類別、方法、屬性等，以及其他變更。

{{% /alert %}} 
## **公共 API 變更**


#### **已在 IChartTextBlockFormat 與 ITextFrameFormat 介面中加入方法 getRotationAngle() 與 setRotationAngle()**
已在介面 com.aspose.slides.IChartTextBlockFormat 與 com.aspose.slides.ITextFrameFormat 中加入方法 getRotationAngle() 與 setRotationAngle()。它們提供對套用於文字框內文字的自訂旋轉角度的存取。

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