---
title: جدول بيانات المخطط
type: docs
url: /ar/nodejs-java/chart-data-table/
---

## **تعيين خصائص الخط لجدول بيانات المخطط**

Aspose.Slides for Node.js via Java يوفر دعمًا لتغيير لون الفئات في لون السلسلة.  

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

 مثال العينة أدناه موضح.  
```javascript
// إنشاء عرض تقديمي فارغ
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح الأسطورة الصغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [مفاتيح الأسطورة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/)، ويمكنك تشغيلها أو إيقافها.

**هل سيُحافظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. يقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن الـ[PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/ar/nodejs-java/convert-powerpoint-to-png/) المصدر يضمن المخطط مع جدول البيانات الخاص به.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط يتم تحميله من عرض تقديمي موجود أو قالب، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي لديها جدول البيانات مفعّل؟**

تحقق من خاصية كل مخطط تشير إلى ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) وتصفح الشرائح لتحديد المخططات التي يكون فيها مفعّل.