---
title: تخصيص وسائط إيضاح المخططات في العروض التقديمية على Android
linktitle: وسيلة إيضاح المخطط
type: docs
url: /ar/androidjava/chart-legend/
keywords:
- وسيلة إيضاح المخطط
- موقع الوسيلة
- حجم الخط
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تخصيص وسائط إيضاح المخططات باستخدام Aspose.Slides for Android عبر Java لتحسين عروض PowerPoint التقديمية من خلال تنسيق وسيلة إيضاح مخصص."
---
## **نظرة عامة**

توفر مكتبة Aspose.Slides for Android via Java خيارات لتخصيص وسيلة إيضاح المخطط في عروض PowerPoint. يوضح هذا المقال كيفية تحديد موضع وسيلة الإيضاح وحجمها، وتعيين حجم الخط لكامل وسيلة الإيضاح، وتنسيق مدخل وسيلة إيضاح فردي، وإخفاء أو استعادة المدخلات المحددة.

يغطي قسم الأسئلة الشائعة السلوكيات المتعلقة، بما في ذلك حجز مساحة لوسيلة الإيضاح، وعرض تسميات متعددة الأسطر، ووراثة التنسيق من سمة العرض التقديمي.

## **تحديد موضع وسيلة الإيضاح**

استخدم أساليب وسيلة الإيضاح [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), و[setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) لتحديد موضعها وحجمها كنسب من أبعاد المخطط.

يوضح المثال التالي إنشاء عرض تقديمي وإضافة مخطط أعمدة مجمّع ببيانات افتراضية إلى الشريحة الأولى. تحويل إزاحات وسعة وسيلة الإيضاح المطلوبة إلى قيم نسبية يتم بقسمة الإزاحات والأبعاد على عرض وارتفاع المخطط: يتم إزاحة وسيلة الإيضاح 50 نقطة من الزاوية العلوية اليسرى للمخطط وتحديد حجمها بـ 100 × 100 نقطة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // عبّر عن موضع وحجم وسيلة الإيضاح بالنسبة للمخطط.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين حجم الخط لوسيلة الإيضاح**

استخدم [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) للوصول إلى تنسيق النص في وسيلة الإيضاح، ثم [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) لتعيين حجم الخط بالنقاط.

يُظهر المثال إنشاء مخطط ببيانات افتراضية وتعيين نص وسيلة الإيضاح إلى 20 نقطة. كما يتم إلغاء التحديد التلقائي للحدود للمحور الرأسي وتحديد نطاقه من -5 إلى 10.

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

## **تعيين حجم الخط لمدخل وسيلة إيضاح فردي**

استخدم المجموعة التي تُرجعها طريقة [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) في وسيلة الإيضاح للوصول إلى تنسيق مدخل معين. الفهارس تبدأ من الصفر، لذا يُشير الفهرس `1` إلى المدخل الثاني.

يُظهر المثال إنشاء مخطط أعمدة مجمّع يحتوي على بيانات افتراضية تشمل سلسلتين على الأقل. يتم تنسيق المدخل الثاني لوسيلة الإيضاح بخط غامق، مائل، ونص أزرق بحجم 20 نقطة.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **إخفاء مدخلات وسيلة الإيضاح الفردية**

لإستبعاد سلسلة مساعدة من وسيلة الإيضاح مع إبقاء بياناتها مرئية، استدعِ [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) بالقيمة `true` عبر [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). سيؤدي هذا إلى إخفاء المدخل المحدد فقط؛ لن يتم إزالة السلسلة أو نقاط بياناتها. بالمقابل، استدعاء [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) بـ `false` يُخفي وسيلة الإيضاح بأكملها.

يُنشئ المثال أدناه مخطط أعمدة مجمّع متعدد السلاسل باستخدام البيانات الافتراضية. يُخفِي مدخل وسيلة الإيضاح للسلسلة الثانية (الفهرس `1`) ويحفظ العرض التقديمي. ثم يتم استعادة المدخل عبر استدعاء [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) بـ `false` وحفظ نسخة ثانية. تظل الأعمدة مرئية في كلا الملفين.

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

    // استعادة نفس المدخل دون تغيير بيانات المخطط.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المقارنة أدناه تُظهر نفس المخطط مع جميع المدخلات مرئية ومع إخفاء المدخل الثاني. تظل أعمدة السلسلة الثانية دون تغيير.

![مقارنة مخطط مع جميع مدخلات وسيلة الإيضاح مرئية ومع إخفاء السلسلة 2 من وسيلة الإيضاح؛ جميع الأعمدة تظل مرئية.](hide-legend-entry.png)

في مخططات الأعمدة، الشرائط، والخطوط، تُعرّف مدخلات وسيلة الإيضاح السلاسل. في مخططات الفطيرة، تُعرّف المدخلات نقاط البيانات الفردية (القطاعات)، لذا استخدم [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) على الشريحة المحددة بدلاً من ذلك. توثّق الواجهة هذه الطريقة لنقاط البيانات لأنواع المخططات `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, و`BarOfPie`. لا تفترض أنها تنطبق على مخططات الدونات، حيث لا تُدرج في تلك القائمة.

## **الأسئلة المتكررة**

**هل يمكنني جعل المخطط يحجز مساحة لوسيلة الإيضاح بدلاً من تغطيتها؟**  
نعم. استدعِ [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) بـ `false` لحجز مساحة لوسيلة الإيضاح بدلاً من السماح لها بتغطية مساحة الرسم.

**هل يمكنني جعل تسميات وسيلة الإيضاح متعددة الأسطر؟**  
نعم. يمكن أن تُلتف التسميات الطويلة عندما يكون العرض المتاح غير كافٍ. يمكنك أيضًا استخدام أحرف السطر الجديد في أسماء السلاسل لطلب فواصل سطر.

**كيف أجعل وسيلة الإيضاح تتبع نظام الألوان في سمة العرض التقديمي؟**  
اترك ألوان وسيلة الإيضاح، والملئ، والخطوط غير مُحددة حتى تتمكن من وراثة تنسيق السمة. أي تنسيق صريح سيتجاوز إعدادات السمة المقابلة.