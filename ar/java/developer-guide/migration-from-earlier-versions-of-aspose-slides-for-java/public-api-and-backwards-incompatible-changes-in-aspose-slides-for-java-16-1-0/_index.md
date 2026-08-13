---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 16.1.0
linktitle: Aspose.Slides لـ Java 16.1.0
type: docs
weight: 200
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- الهجرة
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ Java لتسهيل ترحيل حلول عروض PowerPoint (PPT, PPTX) و ODP الخاصة بك."
---
{{% alert color="info" %}} 
تُدرج هذه الصفحة جميع الفئات، والطرق، والخصائص، وما إلى ذلك، التي تم [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) أو [المزالة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/)، وغيرها من التغييرات التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for Java 16.1.0 API.
{{% /alert %}} 
## **تغييرات API العامة**

#### **تم إضافة طرق getRotationAngle() و setRotationAngle() إلى واجهات IChartTextBlockFormat و ITextFrameFormat**
تم إضافة طرق getRotationAngle() و setRotationAngle() إلى الواجهات com.aspose.slides.IChartTextBlockFormat و com.aspose.slides.ITextFrameFormat.
توفر هذه الطرق إمكانية الوصول إلى الدوران المخصص الذي يُطبق على النص داخل الصندوق المحدد.

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