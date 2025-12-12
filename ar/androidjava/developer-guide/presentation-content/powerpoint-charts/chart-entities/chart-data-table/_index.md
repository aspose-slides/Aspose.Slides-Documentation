---
title: تخصيص جداول بيانات المخططات في العروض التقديمية على Android
linktitle: جدول البيانات
type: docs
url: /ar/androidjava/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تخصيص جداول بيانات المخططات في Java لملفات PPT و PPTX باستخدام Aspose.Slides for Android لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides for Android via Java دعمًا لتغيير لون الفئات في لون السلسلة. 

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class object.
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

**هل يمكنني عرض مفاتيح أسطر توضيحية صغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [legend keys](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-)، ويمكنك تشغيلها أو إيقافها.

**هل سيتم الحفاظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)/[image](/slides/ar/androidjava/convert-powerpoint-to-png/) المُصدَّر يتضمن المخطط مع جدول البيانات الخاص به.

**هل تدعم جداول البيانات المخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط تم تحميله من عرض تقديمي موجود أو قالب، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي لديها جدول البيانات مفعَّل؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) وكرر عبر الشرائح لتحديد المخططات التي يكون فيها مفعَّلًا.