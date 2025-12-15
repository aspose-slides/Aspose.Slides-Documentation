---
title: إضافة خطوط اتجاه إلى مخططات العرض التقديمي على Android
linktitle: خط الاتجاه
type: docs
url: /ar/androidjava/trend-line/
keywords:
- مخطط
- خط اتجاه
- خط اتجاه أسي
- خط اتجاه خطي
- خط اتجاه لوغاريتمي
- خط اتجاه متوسط متحرك
- خط اتجاه متعدد الحدود
- خط اتجاه أسّي
- خط اتجاه مخصص
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "أضف وعدل خطوط الاتجاه بسرعة في مخططات PowerPoint باستخدام Aspose.Slides لنظام Android عبر Java — دليل عملي لجذب جمهورك."
---

## **إضافة خط اتجاه**
توفر Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة للرسوم البيانية:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة رسم بياني ببيانات افتراضية وأحد الأنواع المطلوبة (هذا المثال يستخدم ChartType.ClusteredColumn).
1. إضافة خط اتجاه أسي للسلسلة 1 من الرسم البياني.
1. إضافة خط اتجاه خطي للسلسلة 1 من الرسم البياني.
1. إضافة خط اتجاه لوغاريتمي للسلسلة 2 من الرسم البياني.
1. إضافة خط اتجاه متوسط متحرك للسلسلة 2 من الرسم البياني.
1. إضافة خط اتجاه متعدد الحدود للسلسلة 3 من الرسم البياني.
1. إضافة خط اتجاه أسّي للسلسلة 3 من الرسم البياني.
1. حفظ العرض التقديمي المعدل كملف PPTX.

يتم استخدام الشيفرة التالية لإنشاء رسم بياني مع خطوط الاتجاه.
```java
// إنشاء مثيل من الفئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط عمودي مجمع
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // إضافة خط اتجاه أسي لسلسلة المخطط 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // إضافة خط اتجاه خطي لسلسلة المخطط 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // إضافة خط اتجاه أسّي لسلسلة المخطط 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // حفظ العرض التقديمي
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة خط مخصص**
توفر Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في الرسم البياني. لإضافة خط بسيط مستوي إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- الحصول على مرجع الشريحة باستخدام فهرستها
- إنشاء رسم بياني جديد باستخدام طريقة AddChart المتاحة عبر كائن Shapes
- إضافة AutoShape من نوع الخط باستخدام طريقة AddAutoShape المتاحة عبر كائن Shapes
- تعيين لون خطوط الشكل.
- حفظ العرض التقديمي المعدل كملف PPTX

يتم استخدام الشيفرة التالية لإنشاء رسم بياني مع خطوط مخصصة.
```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**ماذا يعني 'forward' و 'backward' بالنسبة لخط الاتجاه؟**

إنها أطوال خط الاتجاه الممتدة إلى الأمام أو الخلف: بالنسبة للرسوم البيانية النقطية (XY) — بوحدات المحور؛ بالنسبة للرسوم غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيظل خط الاتجاه محفوظًا عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل الشريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/) وتُصوّر الرسوم البيانية إلى صور؛ خطوط الاتجاه، كجزء من الرسم البياني، تُحافظ عليها هذه العمليات. هناك طريقة متاحة أيضًا لـ [تصدير صورة للرسم البياني](/slides/ar/androidjava/create-shape-thumbnails/) نفسه.