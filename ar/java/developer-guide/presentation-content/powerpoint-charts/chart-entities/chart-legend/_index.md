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
- عرض تقديمي
- Java
- Aspose.Slides
description: "خصص وسوم المخططات باستخدام Aspose.Slides للغة Java لتحسين عروض PowerPoint التقديمية من خلال تنسيق وسوم مخصص."
---
## **نظرة عامة**

Aspose.Slides for Java يوفر خيارات لتخصيص وسوم المخطط في عروض PowerPoint التقديمية. توضح هذه المقالة كيفية تحديد موضع وحجم الوسم، ضبط حجم الخط للوسم بالكامل، تنسيق إدخال وسمة فردي، وإخفاء أو استعادة الإدخالات المحددة.

تغطي الأسئلة الشائعة السلوكيات المتعلقة، بما في ذلك حجز مساحة للوسم، عرض تسميات متعددة الأسطر، وراثة التنسيق من سمة العرض التقديمي.

## **تحديد موضع الوسم**

استخدم طرق [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), و[setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) للوسم لتحديد موضعه وحجمه ككسر من أبعاد المخطط.

ينشئ هذا المثال عرضًا تقديميًا ويضيف مخطط أعمدة مجمع مع بيانات افتراضية إلى الشريحة الأولى. تقسيم إزاحات وأبعاد الوسم المطلوبة على عرض وارتفاع المخطط يحولها إلى قيم نسبية: يُبعد الوسم 50 نقطة عن زاوية المخطط العليا اليسرى ويكون حجمه 100 × 100 نقطة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // عبّر عن موضع وحجم الوسم بالنسبة إلى المخطط.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط حجم الخط للوسم**

استخدم [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) للوسم للوصول إلى تنسيق النص الخاص به واستخدم [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) لتعيين حجم الخط بالنقاط.

ينشئ هذا المثال مخططًا ببيانات افتراضية ويضبط نص الوسم إلى 20 نقطة. كما يقوم بتعطيل الحدود التلقائية للمحور العمودي ويحدد نطاقه من -5 إلى 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط حجم الخط لإدخال وسمة فردي**

استخدم المجموعة التي تُعيدها طريقة [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) للوسم للوصول إلى تنسيق إدخال معين. مؤشرات الإدخالات تبدأ من الصفر، لذا فإن الفهرس `1` يشير إلى الإدخال الثاني.

ينشئ هذا المثال مخطط أعمدة مجمع تكون بياناته الافتراضية تشمل سلسلتين على الأقل. يقوم بتنسيق الإدخال الثاني للوسم بخط غامق ومائل ونص أزرق بحجم 20 نقطة.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إخفاء إدخالات وسمة فردية**

لإستبعاد سلسلة مساعدة من الوسم مع إبقاء بياناتها مرئية، استدعِ [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) بقيمة `true` عبر [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). هذا يخفي فقط الوسم المحدد؛ ولا يزيل السلسلة أو نقاط بياناتها. في المقابل، استدعاء [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) بقيمة `false` يخفي الوسم بالكامل.

ينشئ المثال أدناه مخطط أعمدة مجمع مع عدة سلاسل باستخدام بيانات افتراضية. يخفى إدخال وسمة السلسلة الثانية (الفهرس `1`) ويحفظ العرض التقديمي. ثم يعيد الإدخال عن طريق استدعاء [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) بـ `false` ويحفظ نسخة ثانية. تبقى الأعمدة مرئية في كلا الملفين.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // استعادة نفس الإدخال دون تغيير بيانات المخطط.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة أدناه تظهر المخطط نفسه مع جميع الإدخالات مرئية ومع إخفاء الإدخال الثاني. تبقى أعمدة السلسلة الثانية دون تغيير.

![مقارنة مخطط مع جميع إدخالات الوسم مرئية ومع إخفاء السلسلة 2 من الوسم؛ جميع الأعمدة تبقى مرئية.](hide-legend-entry.png)

في المخططات العمودية، الشريطية، وخطية، تُعرِّف إدخالات الوسم السلاسل. بالنسبة لمخططات الفطيرة، تُعرِّف نقاط البيانات الفردية (الشرائح)، لذا استخدم [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) على الشريحة المختارة بدلاً من ذلك. توثِّق الواجهة البرمجية هذه الطريقة لنقاط البيانات لأنواع المخططات `Pie`، `Pie3D`، `ExplodedPie`، `ExplodedPie3D`، `PieOfPie`، و`BarOfPie`. لا تفترض أنها تنطبق على مخططات الدونات، التي لا تُدرج في تلك القائمة.

## **FAQ**

**هل يمكنني جعل المخطط يخصص مساحة للوسم بدلاً من تراكبه؟**

نعم. استدعِ [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) بقيمة `false` لحجز مساحة للوسم بدلاً من السماح له بالتراكب على منطقة الرسم.

**هل يمكنني إنشاء تسميات وسمة متعددة الأسطر؟**

نعم. يمكن أن تُلف التسميات الطويلة عندما يكون العرض المتاح غير كافٍ. يمكنك أيضًا استخدام أحرف السطر الجديد في أسماء السلاسل لطلب فواصل سطر.

**كيف أجعل الوسم يتبع نظام ألوان سمة العرض التقديمي؟**

اترك ألوان الوسم، وتعبئاته، وخطوطه غير مُحددة بحيث يمكنه وراثة تنسيق السمة. التنسيق الصريح يتجاوز إعدادات السمة المقابلة.