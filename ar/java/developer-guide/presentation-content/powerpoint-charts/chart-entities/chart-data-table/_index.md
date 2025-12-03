---
title: تخصيص جداول بيانات المخطط في العروض التقديمية باستخدام Java
linktitle: جدول البيانات
type: docs
url: /ar/java/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تخصيص جداول بيانات المخططات في Java لعروض PPT و PPTX باستخدام Aspose.Slides لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
تقدم Aspose.Slides for Java دعمًا لتغيير لون الفئات في لون السلسلة.  

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

فيما يلي مثال توضيحي.  
```java
// إنشاء عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إظهار مفاتيح الأسطورة الصغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [مفاتيح الأسطورة](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-)، ويمكنك تشغيلها أو إيقافها.

**هل سيتم الحفاظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تُظهر Aspose.Slides المخطط كجزء من الشريحة، لذا فإن [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/java/convert-powerpoint-to-html/)/[image](/slides/ar/java/convert-powerpoint-to-png/) المصدر يتضمن المخطط مع جدول البيانات الخاص به.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط تم تحميله من عرض تقديمي موجود أو قالب، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي لها جدول البيانات مفعّل؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) وتصفح الشرائح لتحديد المخططات التي يكون فيها مفعَّلًا.