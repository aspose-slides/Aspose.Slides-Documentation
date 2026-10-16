---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية على Android
linktitle: خط الاتجاه
type: docs
url: /ar/androidjava/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسّي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه المتعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة وتخصيص خطوط الاتجاه بسرعة في مخططات PowerPoint باستخدام Aspose.Slides لنظام Android عبر Java — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العروض التقديمية باستخدام Aspose.Slides. تُظهر كيفية إنشاء مخطط، وإضافة خطوط الاتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسية، والخطية، واللوغاريتمية، والمتوسط المتحرك، والمتعدد الحدود، والقدرة.

كما تصف كيفية إضافة خط مخصص إلى المخطط عن طريق إدراج شكل خط، وتضم أسئلة شائعة قصيرة حول قيم إسقاط خط الاتجاه إلى الأمام وإلى الخلف وما إذا كانت خطوط الاتجاه تُحفظ أثناء التصدير إلى PDF أو SVG وعند عرض المخططات كصور.

## **إضافة خط اتجاه**

استخدم [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) لإضافة خط اتجاه إلى سلسلة مخطط، مع تحديد نوعه باستخدام [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/). المثال ينشئ مخطط أعمدة مجموعة مع بيانات افتراضية ويضيف خطي اتجاه إلى كل من سلاسله الثلاثة.

يخفي خط الاتجاه الأسّي معادلته وقيمة R‑squared عبر [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) و[setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-)، بينما يكون خط الاتجاه الخطي أحمر. يستخدم خط الاتجاه اللوغاريتمي [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) لتسمية مخصصة. يستخدم المتوسط المتحرك [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) لثلاث نقاط بيانات و[setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) لتسمية مخصصة.

يحتوى خط الاتجاه المتعدد الحدود على [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) للدرجة ثلاثة ويُمد فئة واحدة إلى الأمام عبر [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). يُمد خط الاتجاه القوي فئة واحدة إلى الخلف عبر [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **تعيين نقطة تقاطع خط الاتجاه**

استخدم [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) لتثبيت قيمة Y لخط الاتجاه عند X = 0. هذا الإعداد مدعوم لخطوط الاتجاه الخطية، والأسية، والمتعددة الحدود.

على سبيل المثال، قد يحتاج نموذج تكلفة الإنتاج إلى البدء بتكاليف ثابتة معروفة مقدارها 100، حتى عندما تشير القياسات عند أحجام إنتاج غير صفرية إلى خط أساس مختلف. بالنسبة لخط الاتجاه الخطي، يُقيد تثبيت نقطة التقاطع المعادلة `y = ax + b` لتصبح `b = 100`؛ يتم ملاءمة الميل للبيانات تحت هذا القيد. لا يتم نقل الخط المملوئ مسبقًا ببساطة. تتحكم إعدادات تقاطع المحاور في مكان التقاء محاور المخطط، وليس في معاملات خط الاتجاه المملوئ.

المثال التالي ينشئ مخطط مبعثر (XY) بأحجام إنتاج من 1 إلى 4 وتكاليف 170، 200، 230، و260. يحفظ المخطط باستخدام نقطة التقاطع التلقائية الافتراضية، ثم يضبط نقطة التقاطع إلى 100 ويحفظ ملف PPTX ثاني. الملفان يختلفان فقط في إعداد نقطة التقاطع. يعرض خط الاتجاه معادلته ويمتد إلى الخلف حتى X = 0.

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

مع الحساب التلقائي، تُنتج هذه البيانات `y = 30x + 140`. ضبط نقطة التقاطع إلى 100 ينتج تقريبًا `y = 43.33x + 100`: القيمة المملوئة عند الصفر تتطابق مع خط الأساس المعروف، بينما لم يعد الخط يمر عبر كل نقطة بيانات.

| تقاطع تلقائي | تقاطع ثابت بقيمة 100 |
| --- | --- |
| ![خط الاتجاه الخطي مع تقاطع محسوب تلقائيًا بقيمة 140](intercept-automatic.png) | ![خط الاتجاه الخطي مع تقاطع ثابت بقيمة 100](intercept-fixed.png) |

تستخدم الصورتان نفس البيانات ومقاييس المحاور. يتم تمديد خطوط الاتجاه إلى الخلف حتى X = 0 لإظهار نقاط تقاطعها.

افتراضيًا، تُعيد [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) القيمة `Double.NaN`، التي تمثل تقاطعًا غير محدد بدلاً من الصفر. ثم يتم حساب التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل يُرسم فوق المخطط بدلاً من كونه خط اتجاه يُحسب من بيانات السلسلة. يستخدم هذا المثال [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) لإضافة خط أفقي إلى الشريحة فوق المخطط. يتم تحديد موضع الخط بإحداثيات الشريحة، مقاسة بالنقاط، لذا يبدأ عند الحافة اليسرى للمخطط ويقع في منتصف ارتفاع المخطط. يتطابق عرضه مع عرض المخطط. تُعطي [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) للخط لونًا أحمرًا صلبًا.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

**ماذا يعني “forward” و “backward” بالنسبة لخط الاتجاه؟**

هما طولي خط الاتجاه المُسقط إلى الأمام/إلى الخلف: بالنسبة للمخططات المبعثرة (XY) — بوحدات المحور؛ بالنسبة للمخططات غير المبعثرة — بعدد الفئات. يُسمح فقط بالقيم غير السلبية.

**هل يُحفظ خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند عرض الشريحة كصورة؟**

نعم. يقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) أو [SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/) ويعرض المخططات كصور؛ تُحفظ خطوط الاتجاه كجزء من المخطط خلال هذه العمليات. طريقة أيضًا متاحة لـ[export an image of the chart](/slides/ar/androidjava/create-shape-thumbnails/) نفسها.