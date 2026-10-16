---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في Java
linktitle: خط الاتجاه
type: docs
url: /ar/java/trend-line/
keywords:
- مخطط
- خط اتجاه
- خط اتجاه أسي
- خط اتجاه خطي
- خط اتجاه لوغاريتمي
- خط اتجاه متوسط متحرك
- خط اتجاه متعدد الحدود
- خط اتجاه القوة
- خط اتجاه مخصص
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "أضف خطوط الاتجاه وقم بتخصيصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides للـ Java — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العروض التقديمية باستخدام Aspose.Slides. توضح كيفية إنشاء مخطط، وإضافة خطوط الاتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسي، الخطي، اللوغاريتمي، المتوسط المتحرك، متعدد الحدود، والسلطوي.

كما تصف كيفية إضافة خط مخصص إلى المخطط عن طريق إدراج شكل خط، وتضم سؤالًا شائعًا قصيرًا حول قيم إسقاط خط الاتجاه إلى الأمام وإلى الخلف وما إذا كانت خطوط الاتجاه تُحافظ عليها أثناء التصدير إلى PDF أو SVG وعند تحويل المخططات إلى صور.

## **إضافة خط اتجاه**

استخدم [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) لإضافة خط اتجاه إلى سلسلة مخطط، مع اختيار نوعه باستخدام [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). يُنشئ المثال مخطط أعمدة مجمع ببيانات افتراضية ويضيف خطي اتجاه إلى كل واحدة من ثلاث سلاسله.

يخفي خط الاتجاه الأسي معادلته وقيمة R‑squared عبر [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) و[setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-)، بينما يكون خط الاتجاه الخطي باللون الأحمر. يستخدم خط الاتجاه اللوغاريتمي [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) لإضافة تسمية مخصصة. يستخدم المتوسط المتحرك [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) بقيمة ثلاث نقاط بيانات و[setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) مخصص.

يملك خط الاتجاه متعدد الحدود [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) بقيمة ثلاثة ويمتد فئة واحدة إلى الأمام عبر [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). يمتد خط الاتجاه السلطوي فئة واحدة إلى الخلف عبر [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تقاطع خط الاتجاه**

استخدم [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) لتثبيت قيمة Y لخط الاتجاه عندما X = 0. هذا الإعداد مدعوم لخطوط الاتجاه الخطي، الأسي، ومتعدد الحدود.

على سبيل المثال، قد تحتاج نموذج تكلفة الإنتاج إلى البدء بتكاليف ثابتة معروفة قيمتها 100، حتى عندما تشير القياسات لأحجام إنتاج غير صفرية إلى أساس مختلف. بالنسبة لخط الاتجاه الخطي، فإن تثبيت التقاطع يقيِّد المعادلة `y = ax + b` إلى `b = 100`؛ يتم ضبط المنحدر وفق البيانات تحت هذا القيد. لا يؤدي ذلك إلى تحريك خط تم ملاءمته مسبقًا فحسب. تتحكم إعدادات تقاطع المحاور في مكان التقاء محاور المخطط، وليس في معاملات خط الاتجاه الملائم.

المثال التالي ينشئ مخطط مبعثر (XY) بأحجام إنتاج من 1 إلى 4 وتكاليف 170، 200، 230، و260. يحفظ المخطط باستخدام التقاطع التلقائي الافتراضي، ثم يضبط التقاطع إلى 100، ويحفظ ملف PPTX ثاني. يختلف الملفان فقط في إعداد التقاطع. يعرض خط الاتجاه معادلته ويمتد إلى الخلف حتى X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مع الحساب التلقائي، تنتج هذه البيانات المعادلة `y = 30x + 140`. ضبط التقاطع إلى 100 ينتج تقريبًا `y = 43.33x + 100`: القيمة الملائمة عند الصفر تتطابق مع الأساس المعروف، بينما لم يعد الخط يمر عبر كل نقطة بيانات.

| التقاطع التلقائي | تقاطع ثابت بقيمة 100 |
| --- | --- |
| ![خط اتجاه خطي مع تقاطع محسوب تلقائيًا بقيمة 140](intercept-automatic.png) | ![خط اتجاه خطي مع تقاطع ثابت بقيمة 100](intercept-fixed.png) |

تستخدم الصورتان نفس البيانات ومقاييس المحاور. يتم تمديد خطوط الاتجاه إلى الخلف حتى X = 0 لإظهار تقاطعاتها.

افتراضيًا، تُعيد الدالة [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) القيمة `Double.NaN`، والتي تمثل تقاطع غير محدد بدلًا من الصفر. ثم يُحسب التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل يُرسم فوق المخطط بدلاً من كونه خط اتجاه محسوب من بيانات السلسلة. يستخدم هذا المثال [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) لإضافة خط أفقي إلى الشريحة فوق المخطط. يتم تحديد موضع الخط بإحداثيات الشريحة، مقاسة بالنقاط، بحيث يبدأ من الحافة اليسرى للمخطط ويقع في منتصف ارتفاع المخطط. يتطابق عرض الخط مع عرض المخطط. تُعطي الدالة [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) الخط لونًا أحمرًا صلبًا.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**ماذا تعني 'forward' و 'backward' لخط الاتجاه؟**

إنها أطوال خط الاتجاه المتجهة إلى الأمام أو إلى الخلف: بالنسبة لمخططات المبعثر (XY) — بوحدات المحور؛ بالنسبة للمخططات غير المبعثرة — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيتم الحفاظ على خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

Yes. Aspose.Slides converts presentations to [PDF](/slides/ar/java/convert-powerpoint-to-pdf/) or [SVG](/slides/ar/java/render-a-slide-as-an-svg-image/) and renders charts to images; trend lines, as part of the chart, are preserved during these operations. A method is also available to [تصدير صورة للمخطط](/slides/ar/java/create-shape-thumbnails/) itself.