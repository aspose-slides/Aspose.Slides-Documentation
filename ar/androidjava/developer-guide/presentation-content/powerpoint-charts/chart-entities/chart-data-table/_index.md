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
description: "تخصيص جداول بيانات المخططات في Java لملفات PPT و PPTX باستخدام Aspose.Slides لـ Android لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
Aspose.Slides للـ Android عبر Java يوفر دعمًا لتغيير لون الفئات في لون السلسلة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض المعدل.

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


## **FAQ**

**هل يمكنني إظهار مفاتيح وسام صغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [legend keys](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-)، ويمكنك تشغيلها أو إيقافها.

**هل سيتم الحفاظ على جدول البيانات عند تصدير العرض إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)/[image](/slides/ar/androidjava/convert-powerpoint-to-png/) المُصدَّر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط يتم تحميله من عرض تقديمي أو قالب موجود، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) باستخدام خصائص المخطط.

**كيف يمكنني العثور بسرعة على المخططات في ملف ما والتي تم تمكين جدول البيانات لها؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) وتكرّر عبر الشرائح لتحديد المخططات التي تم تمكينها.