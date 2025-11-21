---
title: وسيلة إيضاح المخطط
type: docs
url: /ar/nodejs-java/chart-legend/
---

## **تحديد موضع وسيلة الإيضاح**

لتعيين خصائص وسيلة الإيضاح، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- ضبط خصائص وسيلة الإيضاح.
- حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بتعيين الموضع والحجم لوسيلة إيضاح المخطط.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على مرجع الشريحة
    var slide = pres.getSlides().get_Item(0);
    // إضافة مخطط عمودي مُجَمّع إلى الشريحة
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // ضبط خصائص وسيلة الإيضاح
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // حفظ العرض التقديمي إلى القرص
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحديد حجم الخط لوسيلة الإيضاح**

تتيح Aspose.Slides for Node.js via Java للمطورين ضبط حجم خط وسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- ضبط حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- حفظ العرض التقديمي على القرص.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحديد حجم خط كل مدخل في وسيلة الإيضاح**

تتيح Aspose.Slides for Node.js via Java للمطورين ضبط حجم خط كل مدخل في وسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- الوصول إلى مدخل وسيلة الإيضاح.
- ضبط حجم الخط.
- تعيين القيمة الدنيا للمحور.
- تعيين القيمة القصوى للمحور.
- حفظ العرض التقديمي على القرص.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يمكنني تمكين وسيلة الإيضاح بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**

نعم. استخدم وضع عدم التغطية ([setOverlay(false)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)); في هذه الحالة، سيُصغر منطقة الرسم لتستوعب وسيلة الإيضاح.

**هل يمكنني إنشاء تسميات وسيلة إيضاح متعددة الأسطر؟**

نعم. تُلف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ وتدعم فواصل الأسطر القسرية عبر أحرف السطر الجديد داخل اسم السلسلة.

**كيف أجعل وسيلة الإيضاح تتبع مخطط ألوان سمة العرض التقديمي؟**

لا تقم بتعيين ألوان/تعبئات/خطوط صريحة لوسيلة الإيضاح أو نصها. سيتوارثون القيم من السمة وسيتم تحديثهم بشكل صحيح عند تغيير التصميم.  
---
title: وسيلة إيضاح المخطط
type: docs
url: /ar/nodejs-java/chart-legend/
---
