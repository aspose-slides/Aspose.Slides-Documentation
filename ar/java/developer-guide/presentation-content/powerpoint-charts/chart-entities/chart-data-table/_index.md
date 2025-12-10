---
title: تخصيص جداول بيانات المخططات في العروض التقديمية باستخدام Java
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
description: "قم بتخصيص جداول بيانات المخططات في Java لملفات PPT و PPTX باستخدام Aspose.Slides لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides for Java دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) من فئة.
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


## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح وسيلة إيضاح صغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [legend keys](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-)، ويمكنك تشغيلها أو إيقافها.

**هل سيتم حفظ جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذلك يتضمن [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/java/convert-powerpoint-to-html/)/[image](/slides/ar/java/convert-powerpoint-to-png/) المخطط مع جدول بياناته.

**هل تدعم جداول البيانات المخططات المستخرجة من ملف قالب؟**

نعم. لأي مخطط تم تحميله من عرض تقديمي موجود أو قالب، يمكنك التحقق من وإجراء تعديل ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات التي لديها جدول بيانات مفعّل في ملف؟**

تحقق من خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) وتصفح الشرائح لتحديد المخططات التي يكون فيها مفعلاً.