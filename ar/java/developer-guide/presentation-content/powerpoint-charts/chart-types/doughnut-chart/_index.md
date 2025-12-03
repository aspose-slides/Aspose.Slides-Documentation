---
title: تخصيص مخططات الدونات في العروض التقديمية باستخدام Java
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/java/doughnut-chart/
keywords:
- مخطط الدونات
- الفجوة المركزية
- حجم الثقب
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides for Java، مع دعم تنسيقات PowerPoint للعروض التقديمية الديناميكية."
---

## **تغيير الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 

أصبح Aspose.Slides for Java يدعم الآن تحديد حجم الثقب في مخطط الدونات. في هذا الموضوع، سنرى من خلال مثال كيفية تحديد حجم الثقب في مخطط الدونات.

{{% /alert %}} 

لتحديد حجم الثقب في مخطط الدونات، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. إضافة مخطط الدونات إلى الشريحة.
3. تحديد حجم الثقب في مخطط الدونات.
4. كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه، قمنا بتعيين حجم الثقب في مخطط الدونات.
```java
// إنشاء كائن من فئة Presentation
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


## **الأسئلة الشائعة**

**هل يمكنني إنشاء دونات متعددة المستويات ذات عدة حلقات؟**

نعم. أضف عدة سلاسل إلى مخطط دونات واحد—تصبح كل سلسلة حلقة منفصلة. يتم تحديد ترتيب الحلقات وفقًا لترتيب السلاسل في المجموعة.

**هل يتم دعم دونات "مُنفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع المخطط [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) وخصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو شكل؛ يمكنك ترسيبه إلى [صورة نقطية](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) أو تصدير المخطط إلى [صورة SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).