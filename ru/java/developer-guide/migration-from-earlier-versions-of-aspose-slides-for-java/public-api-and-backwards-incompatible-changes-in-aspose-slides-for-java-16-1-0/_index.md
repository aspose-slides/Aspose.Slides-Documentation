---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для Java 16.1.0
type: docs
weight: 200
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) или [удаленные](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) классы, методы, свойства и так далее, а также другие изменения, внесенные в API Aspose.Slides для Java 16.1.0.

{{% /alert %}} 
## **Изменения в публичном API**


#### **Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы IChartTextBlockFormat и ITextFrameFormat**
Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы com.aspose.slides.IChartTextBlockFormat и com.aspose.slides.ITextFrameFormat.
Они предоставляют доступ к пользовательскому вращению, применяемому к тексту в пределах ограничивающего прямоугольника.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Пользовательский заголовок").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);

```