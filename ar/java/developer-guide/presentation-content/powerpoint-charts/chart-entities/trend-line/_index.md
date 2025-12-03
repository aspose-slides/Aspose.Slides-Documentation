---
title: إضافة خطوط الاتجاه إلى مخططات العرض في جافا
linktitle: خط الاتجاه
type: docs
url: /ar/java/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه المتعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض
- جافا
- Aspose.Slides
description: "أضف خطوط الاتجاه وخصّصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides for Java — دليل عملي لجذب جمهورك."
---

## **إضافة خط الاتجاه**
Aspose.Slides for Java يوفر API بسيط لإدارة خطوط الاتجاه المختلفة في المخططات:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم ChartType.ClusteredColumn).
1. إضافة خط اتجاه أسي لسلسلة المخطط 1.
1. إضافة خط اتجاه خطي لسلسلة المخطط 1.
1. إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2.
1. إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2.
1. إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3.
1. إضافة خط اتجاه قوة لسلسلة المخطط 3.
1. كتابة العرض المعدل إلى ملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط مع خطوط الاتجاه.
```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط أعمدة متجمع
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // إضافة خط اتجاه أسي للسلسلة 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // إضافة خط اتجاه خطي للسلسلة 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // إضافة خط اتجاه لوغاريتمي للسلسلة 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // إضافة خط اتجاه متوسط متحرك للسلسلة 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // إضافة خط اتجاه متعدد حدود للسلسلة 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // إضافة خط اتجاه قوة للسلسلة 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // حفظ العرض
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة خط مخصص**
Aspose.Slides for Java يوفر API بسيط لإضافة خطوط مخصصة في المخطط. لإضافة خط بسيط إلى شريحة مختارة من العرض، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 
- الحصول على مرجع الشريحة باستخدام فهرستها
- إنشاء مخطط جديد باستخدام طريقة AddChart المعروضة عبر كائن Shapes
- إضافة AutoShape من نوع Line باستخدام طريقة AddAutoShape المعروضة عبر كائن Shapes
- ضبط لون خطوط الشكل.
- كتابة العرض المعدل كملف PPTX

الكود التالي يُستخدم لإنشاء مخطط مع خطوط مخصصة.
```java
// إنشاء نسخة من فئة Presentation
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


## **الأسئلة المتكررة**

**ماذا يعني "forward" و "backward" بالنسبة لخط الاتجاه؟**

هما طولا لخط الاتجاه الممدود إلى الأمام/الخلف: للمخططات النقطية (XY) — بوحدات المحور؛ للمخططات غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السلبية.

**هل يُحفظ خط الاتجاه عند تصدير العرض إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. Aspose.Slides يحول العروض إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/java/render-a-slide-as-an-svg-image/) ويُعيد رسم المخططات كصور؛ خطوط الاتجاه، كجزء من المخطط، تُحفظ خلال هذه العمليات. هناك طريقة متاحة أيضاً لـ [تصدير صورة للمخطط](/slides/ar/java/create-shape-thumbnails/) نفسه.