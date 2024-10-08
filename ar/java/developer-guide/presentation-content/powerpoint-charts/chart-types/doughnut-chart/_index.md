---
title: مخطط الدونات
type: docs
weight: 30
url: /ar/java/doughnut-chart/
---

## **تغيير الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 

يدعم Aspose.Slides ل Java الآن تحديد حجم الثقب في مخطط الدونات. في هذا الموضوع، سنرى مع المثال كيفية تحديد حجم الثقب في مخطط الدونات.

{{% /alert %}} 

لتحديد حجم الثقب في مخطط الدونات، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. إضافة مخطط دونات على الشريحة.
1. تحديد حجم الثقب في مخطط الدونات.
1. كتابة العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتعيين حجم الثقب في مخطط الدونات.

```java
// إنشاء مثيل لفئة Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // كتابة العرض التقديمي إلى القرص
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```