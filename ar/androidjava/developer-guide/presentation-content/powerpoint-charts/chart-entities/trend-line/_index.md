---
title: خط الاتجاه
type: docs
url: /androidjava/trend-line/
---

## **إضافة خط اتجاه**
تقدم Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في المخطط:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة مخطط مع بيانات افتراضية مع أي نوع مطلوب (هذا المثال يستخدم ChartType.ClusteredColumn).
1. إضافة خط اتجاه أسي لسلسلة المخطط 1.
1. إضافة خط اتجاه خطي لسلسلة المخطط 1.
1. إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2.
1. إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2.
1. إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3.
1. إضافة خط اتجاه قوى لسلسلة المخطط 3.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

الشفرة التالية تستخدم لإنشاء مخطط مع خطوط الاتجاه.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط عمودي متجمع
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // إضافة خط اتجاه أسّي لسلسلة المخطط 1
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
    tredLineLog.addTextFrameForOverriding("خط الاتجاه اللوغاريتمي الجديد");
    
    // إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("اسم خط الاتجاه الجديد");
    
    // إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // إضافة خط اتجاه قوى لسلسلة المخطط 3
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
تقدم Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في المخطط. لإضافة خط بسيط على الشريحة المحددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- الحصول على مرجع شريحة باستخدام فهرسها
- إنشاء مخطط جديد باستخدام طريقة AddChart المقدمة من كائن Shapes
- إضافة شكل تلقائي من نوع الخط باستخدام طريقة AddAutoShape المقدمة من كائن Shapes
- تعيين لون خطوط الشكل.
- كتابة العرض التقديمي المعدل كملف PPTX

الشفرة التالية تستخدم لإنشاء مخطط مع خطوط مخصصة.

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