---
title: تخصيص مخططات الدونات في العروض التقديمية على Android
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/androidjava/doughnut-chart/
keywords:
- مخطط الدونات
- الفجوة المركزية
- حجم الفتحة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides for Android عبر Java، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---

## **تحديد الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 
أصبح Aspose.Slides for Android عبر Java يدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سنرى من خلال مثال كيفية تحديد حجم الفتحة في مخطط الدونات.
{{% /alert %}} 

لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. إضافة مخطط دونات إلى الشريحة.
1. تحديد حجم الفتحة في مخطط الدونات.
1. كتابة العرض التقديمي إلى القرص.

في المثال الوارد أدناه، قمنا بتعيين حجم الفتحة في مخطط الدونات.
```java
// إنشاء كائن من فئة Presentation
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


## **الأسئلة المتكررة**

**هل يمكنني إنشاء دونات متعددة المستويات مع حلقات متعددة؟**

نعم. أضف عدة سلاسل إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقة بناءً على ترتيب السلاسل في المجموعة.

**هل يتم دعم دونات "مفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع المخطط [نوع المخطط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) وخصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو شكل؛ يمكنك تحويله إلى صورة [صورة نقطية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) أو تصدير المخطط إلى صورة [صورة SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).