---
title: أسطورة المخطط
type: docs
url: /ar/androidjava/chart-legend/
---

## **موضع الأسطورة**
من أجل تعيين خصائص الأسطورة. يُرجى اتباع الخطوات التالية:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- إضافة مخطط على الشريحة.
- تعيين خصائص الأسطورة.
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، قمنا بتعيين الموضع والحجم لأسطورة المخطط.

```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط عمودي متراص على الشريحة
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // تعيين خصائص الأسطورة
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // كتابة العرض التقديمي إلى القرص
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين حجم خط الأسطورة**
يتيح Aspose.Slides لنظام Android عبر Java للمطورين تعيين حجم خط الأسطورة. يُرجى اتباع الخطوات التالية:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين حجم خط الأسطورة الفردية**
يتيح Aspose.Slides لنظام Android عبر Java للمطورين تعيين حجم خط إدخالات الأسطورة الفردية. يُرجى اتباع الخطوات التالية:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- الوصول إلى إدخال الأسطورة.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```