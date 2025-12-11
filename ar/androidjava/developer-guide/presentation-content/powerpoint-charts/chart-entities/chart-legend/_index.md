---
title: تخصيص أساطير المخططات في العروض التقديمية على Android
linktitle: أسطورة المخطط
type: docs
url: /ar/androidjava/chart-legend/
keywords:
- أسطورة المخطط
- موضع الأسطورة
- حجم الخط
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "خصّص أساطير المخططات باستخدام Aspose.Slides for Android via Java لتحسين عروض PowerPoint بتنسيق أسطورة مخصص."
---

## **موضع الأسطورة**
من أجل ضبط خصائص الأسطورة. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- ضبط خصائص الأسطورة.
- كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بتعيين الموضع والحجم لأسطورة المخطط.
```java
// إنشاء نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على مرجع الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط عمود متجمع على الشريحة
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // ضبط خصائص الأسطورة
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


## **تعيين حجم الخط لأسطورة**
يسمح Aspose.Slides for Android via Java للمطورين بتعيين حجم خط الأسطورة. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
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


## **تعيين حجم الخط لأسطورة فردية**
يسمح Aspose.Slides for Android via Java للمطورين بتعيين حجم خط إدخالات الأسطورة الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- الوصول إلى إدخال الأسطورة.
- تعيين حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
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


## **الأسئلة المتكررة**

**هل يمكنني تمكين الأسطورة بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**

نعم. استخدم وضع عدم التراكب ([setOverlay(false)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); في هذه الحالة سيتقلص مساحة الرسم لتتناسب مع الأسطورة.

**هل يمكنني جعل تسميات الأسطورة متعددة الأسطر؟**

نعم. يتم لف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ كما يتم دعم فواصل السطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل الأسطورة تتبع مخطط ألوان سمة العرض التقديمي؟**

لا تقم بتعيين ألوان/ملء/خطوط صريحة للأسطورة أو نصها. سيتوارثون هذه القيم من السمة وسيتم تحديثها بشكل صحيح عند تغير التصميم.