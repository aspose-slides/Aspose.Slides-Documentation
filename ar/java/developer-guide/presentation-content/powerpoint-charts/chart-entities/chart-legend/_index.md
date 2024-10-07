---
title: أسطورة الرسم البياني
type: docs
url: /java/chart-legend/
---

## **تحديد موضع الأسطورة**
لتعيين خصائص الأسطورة. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- إضافة رسم بياني على الشريحة.
- تعيين خصائص الأسطورة.
- كتابة العرض التقديمي كملف PPTX.

في المثال المقدم أدناه، قمنا بتحديد الموضع والحجم لأسطورة الرسم البياني.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add a clustered column chart on the slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Set Legend Properties
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Write presentation to disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين حجم خط الأسطورة**
تتيح Aspose.Slides لجافا للمطورين إمكانية تعيين حجم خط الأسطورة. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- إنشاء الرسم البياني الافتراضي.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

```java
// Create an instance of Presentation class
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
تتيح Aspose.Slides لجافا للمطورين إمكانية تعيين حجم خط إدخالات الأسطورة الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- إنشاء الرسم البياني الافتراضي.
- الوصول إلى إدخال الأسطورة.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.

```java
// Create an instance of Presentation class
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