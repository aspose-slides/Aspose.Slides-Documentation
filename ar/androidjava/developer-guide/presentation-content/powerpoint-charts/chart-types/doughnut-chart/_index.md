---
title: مخطط الدونات
type: docs
weight: 30
url: /ar/androidjava/doughnut-chart/
---

## **تغيير الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 

Aspose.Slides لـ Android عبر Java يدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سوف نرى مع مثال كيفية تحديد حجم الفتحة في مخطط الدونات.

{{% /alert %}} 

لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. إضافة مخطط دونات على الشريحة.
1. تحديد حجم الفتحة في مخطط الدونات.
1. كتابة العرض التقديمي على القرص.

في المثال المقدم أدناه، قمنا بتحديد حجم الفتحة في مخطط الدونات.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // كتابة العرض التقديمي على القرص
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```