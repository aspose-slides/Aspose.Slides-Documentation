---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for Java لتسهيل ترحيل حلول عروض PowerPoint PPT، PPTX و ODP."
---
{{% alert color="info" %}} 

تُظهر هذه الصفحة جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) أو [مزالة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)ها، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **تمت إضافة الطرق getDoughnutHoleSize()، setDoughnutHoleSize(byte) إلى IChartSeries و ChartSeries**
يحدد حجم الفتحة في مخطط الدونات.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```