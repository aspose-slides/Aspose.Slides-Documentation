---
title: تخصيص مخططات الدونات في العروض التقديمية باستخدام Java
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/java/doughnut-chart/
keywords:
- مخطط الدونات
- الفجوة المركزية
- حجم الفتحة
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides for Java، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---

## **تحديد الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 

أصبحت Aspose.Slides for Java تدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سنرى من خلال مثال كيفية تحديد حجم الفتحة في مخطط الدونات.

{{% /alert %}} 

للتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. إضافة مخطط دونات إلى الشريحة.
1. تحديد حجم الفتحة في مخطط الدونات.
1. كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه، قمنا بتعيين حجم الفتحة في مخطط الدونات.
```java
// إنشاء مثيل لفئة Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // حفظ العرض التقديمي إلى القرص
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني إنشاء دونات متعدد المستويات مع حلقات متعددة؟**

نعم. يمكن إضافة سلاسل متعددة إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات بناءً على ترتيب السلاسل في المجموعة.

**هل يتم دعم الدونات "المتفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط Donut متفجر [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) وخاصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) للتقرير؟**

المخطط هو شكل؛ يمكنك تصييره إلى [raster image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) أو تصدير المخطط إلى صورة [SVG image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).