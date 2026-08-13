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
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides للغة Java، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---
## **نظرة عامة**

هذا المقال يوضح كيفية العمل مع مخطط الدونات في Aspose.Slides عن طريق إضافة المخطط إلى شريحة، ضبط حجم الفتحة المركزية، وحفظ العرض التقديمي. يركز على طريقة `setDoughnutHoleSize` ويظهر الخطوات الأساسية المطلوبة لتخصيص هذا النوع من المخططات برمجيًا.

كما يتضمن أسئلة متكررة قصيرة تغطي سيناريوهات متعلقة بمخطط الدونات، مثل استخدام سلاسل متعددة لإنشاء حلقات متعددة، العمل مع مخططات الدونات المنفجرة، وتصدير المخطط كصورة نقطية أو SVG.

## **تحديد الفجوة المركزية في مخطط الدونات**
{{% alert color="info" %}} 

أصبح Aspose.Slides for Java يدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سنرى مع مثال كيفية تحديد حجم الفتحة في مخطط الدونات.

{{% /alert %}} 

للتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
2. إضافة مخطط دونات إلى الشريحة.
3. تحديد حجم الفتحة في مخطط الدونات.
4. كتابة العرض التقديمي إلى القرص.

في المثال المرفق أدناه، قمنا بتعيين حجم الفتحة في مخطط الدونات.

```java
import com.aspose.slides.*;

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

## **الأسئلة المتكررة**

### هل يمكنني إنشاء دونات متعددة المستويات مع عدة حلقات؟

نعم. أضف سلاسل متعددة إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات بناءً على ترتيب السلاسل في المجموعة.

### هل يدعم الدونات "المنفجر" (شرائح منفصلة)؟

نعم. هناك نوع مخطط [Exploded Doughnut](https://reference.aspose.com/slides/ar/java/com.aspose.slides/charttype/) وخصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

### كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟

المخطط هو شكل؛ يمكنك تصييره إلى [صورة نقطية](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getImage-int-float-float-) أو تصدير المخطط إلى [صورة SVG](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).