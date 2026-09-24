---
title: تخصيص جداول بيانات المخططات في العروض التقديمية باستخدام JavaScript
linktitle: جدول البيانات
type: docs
url: /ar/nodejs-java/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تخصيص خطوط جداول بيانات المخطط، الحدود، ومفاتيح الأسطورة في عروض PowerPoint باستخدام Aspose.Slides for Node.js عبر Java."
---
## **نظرة عامة**

يتيح Aspose.Slides for Node.js عبر Java عرض جدول بيانات المخطط وتخصيص تنسيق النص والحدود ومفاتيح الأسطورة. يشرح هذا المقال كيفية تمكين الجدول، تنسيق نصه، التحكم في كل نوع من الحدود، وإظهار أو إخفاء مفاتيح الأسطورة. تقوم الأمثلة بحفظ المخططات المعدلة في ملفات PPTX.

## **تعيين خصائص الخط**

لعرض جدول بيانات المخطط، مرّر `true` إلى [setDataTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/setdatatable/). استخدم [getChartDataTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/getchartdatatable/) للوصول إلى الجدول وتكوين تنسيق النص الخاص به.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
1. أضف مخطط أعمدة مجمع إلى الشريحة الأولى.
1. فعّل جدول بيانات المخطط.
1. فعّل النص الغامق باستخدام [setFontBold](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setfontbold) ومرّر `20` إلى [setFontHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setfontheight) للحصول على نص بحجم 20 نقطة.
1. احفظ العرض المعدل.

المثال التالي يتطلب وجود `input.pptx` في دليل العمل مع شريحة واحدة على الأقل. يضيف مخططًا ببيانات افتراضية في الموضع (50, 50) وعرضه 600 نقطة وارتفاعه 400 نقطة. يحتوي الملف `output.pptx` المُحفوظ على المخطط مع تمكين جدول البيانات وتطبيق إعدادات الخط المحددة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تخصيص حدود جدول البيانات**

فعّل الجدول باستخدام [Chart.setDataTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/setdatatable/) واطلبه عبر [Chart.getChartDataTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/getchartdatatable/). يمكنك التحكم في ثلاثة أنواع من الحدود بشكل مستقل:

- [setBorderHorizontal](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datatable/setborderhorizontal/) يتحكم في حدود الخلايا الأفقية.
- [setBorderVertical](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datatable/setbordervertical/) يتحكم في حدود الخلايا العمودية.
- [setBorderOutline](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datatable/setborderoutline/) يتحكم في الحد الخارجي للجدول.

مرّر `true` إلى كل طريقة لعرض حدودها أو `false` لإخفائها. المثال التالي ينشئ مخطط أعمدة مجمع ببيانات افتراضية، يعرض الحدود الأفقية والحد الخارجي، ويخفي الحدود العمودية. لا يتطلب أي ملف إدخال. يُحدد موضع المخطط وحجمه بالنقاط.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة أدناه تستخدم نفس بيانات المخطط وإعداد مفتاح الأسطورة في جميع الحالات الأربع. يبدأ الأمر بتمكين جميع الحدود، ثم يُعطل كل نسخة حد واحد فقط. النسخة السفلية اليسرى تتطابق مع إعدادات الحدود في المثال.

![جداول بيانات المخطط مع تمكين جميع الحدود، بدون حدود أفقية، بدون حدود عمودية، وبدون حد خارجي](data-table-borders.png)

## **إظهار أو إخفاء مفاتيح الأسطورة**

مفاتيح الأسطورة هي علامات ملونة صغيرة بجانب أسماء السلاسل في جدول البيانات. تساعد القارئ على مطابقة كل صف من الجدول مع سلسلة المخطط. مرّر `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datatable/setshowlegendkey/) لإظهار هذه العلامات أو `false` لإخفائها.

الأسطورة المنفصلة للمخطط يتم التحكم فيها عبر [Chart.setLegend](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/setlegend/). هذه الإعدادات مستقلة: إخفاء الأسطورة المنفصلة لا يخفي المفاتيح داخل جدول البيانات، وإخفاء مفاتيح الجدول لا يخفي الأسطورة المنفصلة.

المثال التالي ينشئ مخططًا ببيانات افتراضية، يفعّل جدول بياناته، ويظهر مفاتيح الأسطورة داخل الجدول مع إخفاء الأسطورة المنفصلة. جميع حدود الجدول مفعلة صراحة. لا يتطلب عرض تقديمي إدخالي. لإخفاء مفاتيح الجدول فقط، مرّر `false` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة أدناه تُظهر نفس الجدول مع تمكين مفاتيح الأسطورة وإيقافها. تبقى جميع الحدود مفعلة، وتكون الأسطورة المنفصلة للمخطط مخفية في الحالتين.

![جداول بيانات المخطط مع مفاتيح الأسطورة معروضة على اليسار ومخفية على اليمين](data-table-legend-keys.png)

## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح الأسطورة في جدول بيانات المخطط؟**

نعم. مرّر `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/datatable/setshowlegendkey/) لعرض مفاتيح الأسطورة أو `false` لإخفائها.

**هل سيبقى جدول البيانات محفوظًا عند تصدير العرض إلى PDF أو HTML أو صور؟**

نعم. يقوم Aspose.Slides بتصدير المخطط وجدول البيانات المعروض كجزء من الشريحة عند تصديره إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، أو [صور](/slides/ar/nodejs-java/convert-powerpoint-to-png/).

**هل يمكنني التعامل مع جداول البيانات في المخططات المحملة من قالب؟**

نعم. للمخطط المحمّل من عرض تقديمي أو قالب موجود، استخدم [hasDataTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/hasdatatable/) و[setDataTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/setdatatable/) للتحقق مما إذا كان جدول البيانات معروضًا أو لتغييره.

**كيف يمكنني العثور على المخططات التي لديها جدول بيانات ممكّن؟**

قم بالتنقل عبر الأشكال في كل شريحة، حدد المخططات، واستدعِ طريقة [hasDataTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/hasdatatable/) الخاصة بها. القيمة `true` تشير إلى أن جدول البيانات مفعّل.