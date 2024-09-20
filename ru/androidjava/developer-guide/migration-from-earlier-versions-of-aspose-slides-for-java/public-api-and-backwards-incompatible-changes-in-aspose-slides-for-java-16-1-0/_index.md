---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для Java 16.1.0
type: docs
weight: 200
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) или [удаленных](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) классов, методов, свойств и других изменений, введенных в API Aspose.Slides для Java 16.1.0.

{{% /alert %}} 
## **Изменения в публичном API**


#### **Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы IChartTextBlockFormat и ITextFrameFormat**
Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы com.aspose.slides.IChartTextBlockFormat и com.aspose.slides.ITextFrameFormat.
Они обеспечивают доступ к индивидуальному вращению, которое применяется к тексту внутри ограничивающего прямоугольника.

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