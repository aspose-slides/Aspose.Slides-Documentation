---
title: تخصيص وسيلة إيضاح المخطط في العروض التقديمية باستخدام Java
linktitle: وسيلة إيضاح المخطط
type: docs
url: /ar/java/chart-legend/
keywords:
- وسيلة إيضاح المخطط
- موضع الوسيلة
- حجم الخط
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "قم بتخصيص وسائط مخططات الرسم البياني باستخدام Aspose.Slides for Java لتحسين العروض التقديمية في PowerPoint من خلال تنسيق وسيلة إيضاح مخصص."
---

## **موضع وسيلة الإيضاح**
لتعيين خصائص وسيلة الإيضاح، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- تعيين خصائص وسيلة الإيضاح.
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، قمنا بتعيين الموضع والحجم لوسيلة إيضاح المخطط.
```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط عمود مجمع إلى الشريحة
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // تعيين خصائص وسيلة الإيضاح
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


## **تحديد حجم خط وسيلة الإيضاح**
تتيح Aspose.Slides for Java للمطورين تعيين حجم خط وسيلة الإيضاح. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.
```java
// إنشاء مثيل من فئة Presentation
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


## **تحديد حجم خط وسيلة الإيضاح الفردية**
تتيح Aspose.Slides for Java للمطورين تعيين حجم الخط لمدخلات وسيلة الإيضاح الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- إنشاء المخطط الافتراضي.
- الوصول إلى مدخل وسيلة الإيضاح.
- تعيين حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- كتابة العرض التقديمي إلى القرص.
```java
// إنشاء مثيل من فئة Presentation
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


## **الأسئلة الشائعة**

**هل يمكنني تمكين وسيلة الإيضاح بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**
نعم. استخدم وضع عدم التغطية ([setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)); في هذه الحالة، سيتقلص منطقة الرسم لتتناسب مع وسيلة الإيضاح.

**هل يمكنني إنشاء تسميات وسيلة إيضاح متعددة الأسطر؟**
نعم. تُلف التسميات الطويلة تلقائيًا عندما لا تكون المساحة كافية؛ وتدعم فواصل السطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل وسيلة الإيضاح تتبع نظام ألوان سمة العرض التقديمي؟**
لا تقم بتعيين ألوان/ملء/خطوط صريحة لوسيلة الإيضاح أو نصها. سيتوارثون ذلك من السمة وسيتم تحديثهم بشكل صحيح عند تغيير التصميم.