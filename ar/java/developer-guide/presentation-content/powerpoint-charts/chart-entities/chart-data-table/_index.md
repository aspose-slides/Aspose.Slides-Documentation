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
- العرض التقديمي
- Java
- Aspose.Slides
description: "تخصيص خطوط جدول بيانات المخطط والحدود ومفاتيح الأسطورة في العروض التقديمية لبرنامج PowerPoint باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

يتيح لك Aspose.Slides for Java عرض جدول بيانات المخطط وتخصيص تنسيق النص والحدود ومفاتيح الأسطورة. يشرح هذا المقال كيفية تمكين الجدول وتنسيق نصه والتحكم في كل نوع من الحدود وعرض أو إخفاء مفاتيح الأسطورة. تُحفظ الأمثلة المخططات المُكوَّنة في ملفات PPTX.

## **تعيين خصائص الخط**

لعرض جدول بيانات المخطط، مرّر `true` إلى [setDataTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/#setDataTable-boolean-). استخدم [getChartDataTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/#getChartDataTable--) للوصول إلى الجدول وتكوين تنسيق النص الخاص به.

1. حمل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
1. أضف مخطط عمودي مجمع إلى الشريحة الأولى.
1. فعّل جدول بيانات المخطط.
1. فعّل النص الغامق باستخدام [setFontBold](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) ومرّر `20` إلى [setFontHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) للنص بحجم 20 نقطة.
1. احفظ العرض التقديمي المُعدل.

المثال التالي يتطلب وجود `test.pptx` في دليل العمل مع وجود شريحة واحدة على الأقل. يضيف مخططًا ببيانات افتراضية في الموضع (50, 50)، بعرض 600 نقطة وارتفاع 400 نقطة. يحتوي ملف `output.pptx` المحفوظ على المخطط مع تمكين جدول البيانات وتطبيق إعدادات الخط المحددة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تخصيص حدود جدول البيانات**

فعّل الجدول باستخدام [IChart.setDataTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#setDataTable-boolean-) وادخله عبر [IChart.getChartDataTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#getChartDataTable--). يمكنك التحكم في ثلاثة أنواع من الحدود بشكل مستقل:

- [setBorderHorizontal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) يتحكم في حدود الخلايا الأفقية.
- [setBorderVertical](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) يتحكم في حدود الخلايا العمودية.
- [setBorderOutline](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) يتحكم في الحد الخارجي للجدول.

مرّر `true` إلى كل طريقة لعرض حدودها أو `false` لإخفائها. المثال التالي ينشئ مخطط عمودي مجمع ببيانات افتراضية، يعرض الحدود الأفقية والحد الخارجي، ويخفي الحدود العمودية. لا يتطلب أي ملف إدخال. يتم تحديد موضع وحجم المخطط بالنقاط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة أدناه تستخدم نفس بيانات المخطط وإعدادات مفتاح الأسطورة في جميع الحالات الأربعة. يبدأ بتمكين جميع الحدود، ثم يعطّل كل متغيّر حد واحد فقط. المتغيّر في الأسفل الأيسر يطابق إعدادات الحدود في المثال.

![جداول بيانات المخطط مع تمكين جميع الحدود، بدون حدود أفقية، بدون حدود عمودية، وبدون حد خارجي](data-table-borders.png)

## **عرض أو إخفاء مفاتيح الأسطورة**

مفاتيح الأسطورة هي علامات ملونة صغيرة بجانب أسماء السلاسل في جدول البيانات. تساعد القارئ على مطابقة كل صف في الجدول مع سلسلة المخطط. مرّر `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) لعرض هذه العلامات أو `false` لإخفائها.

يتم التحكم في الأسطورة المنفصلة للمخطط عبر [IChart.setLegend](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#setLegend-boolean-). هذه الإعدادات مستقلة: إخفاء الأسطورة المنفصلة لا يخفي المفاتيح داخل جدول البيانات، وإخفاء مفاتيح الجدول لا يخفي الأسطورة المنفصلة.

المثال التالي ينشئ مخططًا ببيانات افتراضية، يفعّل جدول بياناته، ويظهر مفاتيح الأسطورة داخله مع إخفاء الأسطورة المنفصلة. جميع حدود الجدول مفعلة صراحةً. لا يلزم أي عرض تقديمي كمدخل. لإخفاء مفاتيح الجدول فقط، مرّر `false` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة أدناه تُظهر نفس الجدول مع تمكين مفاتيح الأسطورة وتعطيلها. تبقى جميع الحدود مفعلة، وتكون الأسطورة المنفصلة للمخطط مخفية في الحالتين.

![جداول بيانات المخطط مع إظهار مفاتيح الأسطورة على اليسار وإخفائها على اليمين](data-table-legend-keys.png)

## **الأسئلة الشائعة**

**هل يمكنني عرض مفاتيح الأسطورة في جدول بيانات المخطط؟**

نعم. مرّر `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) لعرض مفاتيح الأسطورة أو `false` لإخفائها.

**هل سيُحافظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. يقوم Aspose.Slides برندرة المخطط وجدول البيانات المعروض كجزء من الشريحة عند التصدير إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/java/convert-powerpoint-to-html/)، أو [الصور](/slides/ar/java/convert-powerpoint-to-png/).

**هل يمكنني العمل مع جداول البيانات في المخططات التي تم تحميلها من قالب؟**

نعم. بالنسبة لمخطط تم تحميله من عرض تقديمي أو قالب موجود، استخدم [hasDataTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/#hasDataTable--) و[setDataTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/#setDataTable-boolean-) للتحقق أو تغيير ما إذا كان جدول البيانات الخاص به معروضًا.

**كيف يمكنني العثور على المخططات التي لديها جدول بيانات مفعّل؟**

قم بالتكرار عبر الأشكال في كل شريحة، حدد المخططات، واستدعِ طريقة [hasDataTable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/#hasDataTable--). القيمة `true` تشير إلى أن جدول البيانات مفعَّل.