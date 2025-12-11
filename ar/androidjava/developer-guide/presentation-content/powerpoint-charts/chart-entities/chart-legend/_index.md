---
title: تخصيص وسائم المخطط في العروض التقديمية على Android
linktitle: وسيم المخطط
type: docs
url: /ar/androidjava/chart-legend/
keywords:
- وسيم المخطط
- موضع الوسيم
- حجم الخط
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تخصيص وسائم المخطط باستخدام Aspose.Slides for Android via Java لتحسين عروض PowerPoint التقديمية مع تنسيق وسيم مخصص."
---

## **موضع وسيلة الإيضاح**
لضبط خصائص وسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- إضافة مخطط على الشريحة.
- ضبط خصائص وسيلة الإيضاح.
- كتابة العرض التقديمي كملف PPTX.

في المثال الوارد أدناه، قمنا بتعيين الموضع والحجم لوسيلة إيضاح المخطط.
```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط عمودي متجمع إلى الشريحة
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // تعيين خصائص وسيلة إيضاح
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


## **تعيين حجم الخط لوسيلة الإيضاح**
يتيح Aspose.Slides for Android via Java للمطورين تعيين حجم خط وسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء مثيل فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين قيمة الحد الأدنى للمحور.
- تعيين قيمة الحد الأقصى للمحور.
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


## **تعيين حجم الخط لوسيلة إيضاح فردية**
يتيح Aspose.Slides for Android via Java للمطورين تعيين حجم خط مدخلات وسيلة الإيضاح الفردية. يرجى اتباع الخطوات التالية:

- إنشاء مثيل فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- الوصول إلى مدخل وسيلة الإيضاح.
- تعيين حجم الخط.
- تعيين قيمة الحد الأدنى للمحور.
- تعيين قيمة الحد الأقصى للمحور.
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


## **FAQ**

**هل يمكنني تمكين وسيلة الإيضاح بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**

نعم. استخدم وضع غير التراكب ([setOverlay(false)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); في هذه الحالة، سيصغر منطقة الرسم لتستوعب وسيلة الإيضاح.

**هل يمكنني إنشاء تسميات وسيلة إيضاح متعددة الأسطر؟**

نعم. تُلف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ كما يتم دعم الفواصل القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل وسيلة الإيضاح تتبع مخطط ألوان سمة العرض التقديمي؟**

لا تقم بتعيين ألوان/تعبئات/خطوط صريحة لوسيلة الإيضاح أو نصها. سيتوارثون القيم من السمة وسيتم تحديثهم بشكل صحيح عند تغيير التصميم.