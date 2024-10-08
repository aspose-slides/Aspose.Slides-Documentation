---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.8.0
type: docs
weight: 160
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع [الفئات المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) أو [المزالة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) وطرقها وخصائصها وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة الطرق getDoughnutHoleSize() و setDoughnutHoleSize(byte) إلى IChartSeries و ChartSeries**
تحدد حجم الثقب في مخطط الكعكة.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```