---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لجافا 16.1.0
type: docs
weight: 200
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بإدراج جميع [الإضافات](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) أو [العمليات المحذوفة](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) من الفصول، والطرق، والخصائص، وما إلى ذلك، وأي تغييرات أخرى تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لجافا 16.1.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**


#### **تم إضافة الطرق getRotationAngle() و setRotationAngle() إلى واجهتي IChartTextBlockFormat و ITextFrameFormat**
تمت إضافة الطرق getRotationAngle() و setRotationAngle() إلى الواجهتين com.aspose.slides.IChartTextBlockFormat و com.aspose.slides.ITextFrameFormat.
توفر هذه الطرق الوصول إلى التدوير المخصص الذي يتم تطبيقه على النص داخل صندوق الحدود.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("عنوان مخصص").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```