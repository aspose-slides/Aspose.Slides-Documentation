---
title: تخصيص وسوم المخططات في العروض التقديمية باستخدام Java
linktitle: وسمة المخطط
type: docs
url: /ar/java/chart-legend/
keywords:
- وسمة المخطط
- موضع الوسمة
- حجم الخط
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "قم بتخصيص وسوم المخططات باستخدام Aspose.Slides for Java لتحسين عروض PowerPoint مع تنسيق وسوم مخصص."
---

## **تموضع المفتاح**
لضبط خصائص المفتاح، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- احصل على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- ضبط خصائص المفتاح.
- احفظ العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، قمنا بضبط الموقع والحجم للمفتاح في المخطط.
```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط عمود مجمع إلى الشريحة
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // تعيين خصائص المفتاح
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // حفظ العرض التقديمي إلى القرص
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ضبط حجم الخط للمفتاح**
تتيح مكتبة Aspose.Slides for Java للمطورين ضبط حجم خط المفتاح. يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- إنشاء المخطط الافتراضي.
- ضبط حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
- حفظ العرض التقديمي على القرص.
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


## **ضبط حجم الخط لمفتاح فردي**
تتيح مكتبة Aspose.Slides for Java للمطورين ضبط حجم خط العناصر الفردية في المفتاح. يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- إنشاء المخطط الافتراضي.
- الوصول إلى عنصر المفتاح.
- ضبط حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
- حفظ العرض التقديمي على القرص.
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


## **الأسئلة الشائعة**

**هل يمكنني تفعيل المفتاح بحيث يخصص المخطط مساحة له تلقائيًا بدلاً من تغطيته؟**

نعم. استخدم وضع عدم التغطية ([setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)); في هذه الحالة، سيتم تقليل مساحة منطقة الرسم لتستوعب المفتاح.

**هل يمكنني إنشاء تسميات المفتاح متعددة الأسطر؟**

نعم. تُلف التسميات الطويلة تلقائيًا عندما لا تكون المساحة كافية؛ كما يتم دعم فواصل الأسطر القسرية عبر أحرف السطر الجديد داخل اسم السلسلة.

**كيف أجعل المفتاح يتبع نظام ألوان سمة العرض التقديمي؟**

لا تقم بتعيين ألوان/تعبئات/خطوط صريحة للمفتاح أو نصه. سيتوارث هذه الخصائص من السمة وسيتم تحديثها بشكل صحيح عند تغيّر التصميم.