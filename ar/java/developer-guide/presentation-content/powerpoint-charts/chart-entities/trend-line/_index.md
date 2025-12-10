---
title: إضافة خطوط الاتجاه إلى مخططات العرض التقديمي في Java
linktitle: خط الاتجاه
type: docs
url: /ar/java/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه للمتوسط المتحرك
- خط الاتجاه المتعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "أضف خطوط الاتجاه وخصصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides for Java — دليل عملي لجذب جمهورك."
---

## **إضافة خط اتجاه**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في المخططات:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم ChartType.ClusteredColumn).
1. إضافة خط اتجاه أسي للسلسلة 1 في المخطط.
1. إضافة خط اتجاه خطي للسلسلة 1 في المخطط.
1. إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط.
1. إضافة خط اتجاه متوسط متحرك للسلسلة 2 في المخطط.
1. إضافة خط اتجاه متعدد الحدود للسلسلة 3 في المخطط.
1. إضافة خط اتجاه أسّي للسلسلة 3 في المخطط.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يتم استخدام الشيفرة التالية لإنشاء مخطط مع خطوط الاتجاه.
```java
// إنشاء نسخة من فئة Presentation class
Presentation pres = new Presentation();
try {
    // إنشاء مخطط عمودي مجمع
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
    
    // إضافة خط اتجاه متعدد الحدود للسلسلة 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // إضافة خط اتجاه قوة للسلسلة 3
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
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في المخطط. لإضافة خط بسيط إلى الشريحة المحددة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام فهرستها.
- إنشاء مخطط جديد باستخدام طريقة AddChart المتوفرة في كائن Shapes.
- إضافة AutoShape من نوع خط باستخدام طريقة AddAutoShape المتوفرة في كائن Shapes.
- تعيين لون خطوط الشكل.
- كتابة العرض التقديمي المعدل كملف PPTX

يتم استخدام الشيفرة التالية لإنشاء مخطط مع خطوط مخصصة.
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


## **الأسئلة الشائعة**

**ماذا يعني 'أمام' و'خلف' بالنسبة لخط الاتجاه؟**

إنهما طولا خط الاتجاه الممتدان إلى الأمام أو الخلف: بالنسبة لمخططات التبعثر (XY) — بوحدات المحور؛ بالنسبة للمخططات غير التبعثرية — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيستمر خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل الشريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/java/render-a-slide-as-an-svg-image/) وتُظهر المخططات كصور؛ وبالتالي تُحافظ على خطوط الاتجاه كجزء من المخطط خلال هذه العمليات. وهناك طريقة متاحة أيضًا لتصدير صورة للمخطط نفسه.