---
title: تخصيص مخططات الدونات في العروض التقديمية على Android
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/androidjava/doughnut-chart/
keywords:
- مخطط دونات
- الفجوة المركزية
- حجم الفتحة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides لأندرويد عبر جافا، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---
## **نظرة عامة**

تظهر هذه المقالة كيفية العمل مع مخطط الدونات في Aspose.Slides عن طريق إضافة المخطط إلى شريحة، وتحديد حجم الفتحة المركزية، وحفظ العرض التقديمي. تركز على طريقة `setDoughnutHoleSize` وتوضح الخطوات الأساسية المطلوبة لتخصيص هذا النوع من المخططات في الكود.

وتتضمن أيضاً قسم أسئلة شائعًا قصيرًا يغطي سيناريوهات مخطط الدونات ذات الصلة، مثل استخدام سلاسل متعددة لإنشاء حلقات متعددة، والعمل مع مخططات الدونات المتفجرة، وتصدير المخطط كصورة نقطية أو SVG.

## **تحديد الفجوة المركزية في مخطط الدونات**
{{% alert color="info" %}} 
أصبح Aspose.Slides لـ Android عبر Java يدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سنرى مع مثال كيفية تحديد حجم الفتحة في مخطط الدونات.
{{% /alert %}} 

لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) .
1. إضافة مخطط دونات إلى الشريحة.
1. تحديد حجم الفتحة في مخطط الدونات.
1. حفظ العرض التقديمي إلى القرص.

في المثال المرفق أدناه، قمنا بتحديد حجم الفتحة في مخطط الدونات.

```java
import com.aspose.slides.*;

// إنشاء مثيل من فئة Presentation
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

### هل يمكنني إنشاء دونات متعددة المستويات مع حلقات متعددة؟

نعم. أضف سلاسل متعددة إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات وفقًا لترتيب السلاسل في المجموعة.

### هل يتم دعم الدونات “المتفجرة” (الشرائح المفصولة)؟

نعم. هناك نوع مخطط [Exploded Doughnut](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/charttype/) وخاصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

### كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟

المخطط هو شكل؛ يمكنك تحويله إلى صورة [raster image](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) أو تصدير المخطط إلى صورة [SVG image](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).