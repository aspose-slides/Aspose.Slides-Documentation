---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.8.0
type: docs
weight: 160
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [الإضافات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) أو [الإزالة](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) للفئات والطرق والخصائص وما إلى ذلك، والتغييرات الأخرى التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة الأساليب getDoughnutHoleSize() و setDoughnutHoleSize(byte) إلى IChartSeries و ChartSeries**
يحدد حجم الثقب في مخطط الدونات.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```