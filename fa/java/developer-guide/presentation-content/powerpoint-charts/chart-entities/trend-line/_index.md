---
title: افزودن خطوط روند به نمودارهای ارائه در Java
linktitle: خط روند
type: docs
url: /fa/java/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند متوسط متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "به سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای Java اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides خطوط روند را به نمودارهای ارائه اضافه کنید. این مقاله نشان می‌دهد چگونه یک نمودار ایجاد کنید، خطوط روند را به سری‌های نمودار اضافه کنید و با انواع مختلف خطوط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، متوسط متحرک، چندجمله‌ای و توان.

همچنین توضیح می‌دهد چگونه یک خط سفارشی را به یک نمودار اضافه کنید با درج یک شکل خط، و شامل سؤالات متداول کوتاهی درباره مقادیر پیش‌برش و عقب‌برش خط روند و این که آیا خطوط روند هنگام خروجی گرفتن به PDF یا SVG یا هنگام رندر نمودارها به عنوان تصویر حفظ می‌شوند، می‌باشد.

## **افزودن خط روند**

از [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) برای افزودن یک خط روند به یک سری نمودار استفاده کنید و نوع آن را با [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/) انتخاب کنید. مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و برای هر یک از سه سری آن دو خط روند اضافه می‌نماید.

خط روند نمایی معادله و مقدار R‑squared خود را از طریق [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) و [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) مخفی می‌کند، در حالی که خط روند خطی قرمز است. خط روند لگاریتمی از [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) برای برچسب سفارشی استفاده می‌کند. متوسط متحرک از یک [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) برابر با سه نقطه داده و یک [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) سفارشی استفاده می‌کند.

خط روند چندجمله‌ای دارای یک [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) برابر با سه است و یک دسته به جلو از طریق [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-) گسترش می‌یابد. خط روند توان یک دسته به عقب از طریق [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-) گسترش می‌دهد.

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
## **تنظیم تقاطع خط روند**

از [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) برای ثابت کردن مقدار Y یک خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به عنوان مثال، یک مدل هزینه تولید ممکن است نیاز داشته باشد که از هزینه‌های ثابت شناخته‌شده‌ای برابر 100 شروع شود، حتی زمانی که اندازه‌گیری‌ها در حجم‌های تولید غیرصفر یک مبنا متفاوت را نشان می‌دهد. برای یک خط روند خطی، ثابت کردن تقاطع معادله را به `y = ax + b` به `b = 100` محدود می‌کند؛ شیب تحت آن قیود به داده‌ها برازش می‌شود. این کار فقط یک خط قبلاً برازش شده را جابه‌جا نمی‌کند. تنظیمات عبور محور، مکان تلاقی محورها را کنترل می‌کند، نه ضریب‌های خط روند برازش‌شده.

مثال زیر یک نمودار پراکنده (XY) با حجم‌های تولیدی از 1 تا 4 و هزینه‌های 170، 200، 230 و 260 ایجاد می‌کند. این نمودار را با تقاطع خودکار پیش‌فرض ذخیره می‌کند، تقاطع را به 100 تنظیم می‌کند و یک فایل PPTX دوم ذخیره می‌گردد. این دو فایل فقط در تنظیم تقاطع متفاوت هستند. خط روند معادله خود را نمایش داده و به X = 0 باز می‌گردد.

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

با محاسبه خودکار، این داده‌ها `y = 30x + 140` را تولید می‌کنند. تنظیم تقاطع به 100 به‌جای آن تقریباً `y = 43.33x + 100` را تولید می‌کند: مقدار برازش‌شده در صفر با مبنای شناخته‌شده مطابقت دارد، در حالی که خط دیگر از تمام نقاط داده عبور نمی‌کند.

| تقاطع خودکار | تقاطع ثابت 100 |
| --- | --- |
| ![خط روند خطی با تقاطع محاسبه‌شده خودکار 140](intercept-automatic.png) | ![خط روند خطی با تقاطع ثابت 100](intercept-fixed.png) |

هر دو تصویر از همان داده‌ها و مقیاس‌های محور استفاده می‌کنند. خطوط روند به X = 0 بازگردانده می‌شوند تا تقاطع‌های خود را نشان دهند.

به‌طور پیش‌فرض، [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) مقدار `Double.NaN` را برمی‌گرداند که نشان‌دهنده تقاطع نامشخص است نه صفر. سپس تقاطع به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **افزودن خط سفارشی**

خط سفارشی یک شکل است که بر روی نمودار کشیده می‌شود نه خطی که از داده‌های سری محاسبه شده باشد. این مثال از [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) برای افزودن یک خط افقی به اسلاید بر روی نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید، به واحد نقطه، مشخص می‌شود، به‌طوری‌که از لبه چپ نمودار شروع می‌شود و نصف ارتفاع نمودار را می‌پوشاند. عرض آن با عرض نمودار برابر است. [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) به خط یک رنگ ثابت قرمز می‌دهد.

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
## **سؤالات متداول**

**معنای 'forward' و 'backward' در خط روند چیست؟**

آنها طول‌های خط روندی هستند که به‌صورت پیشرو/عقب‌رو پیش‌بینی می‌شوند: برای نمودارهای پراکنده (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیرپراکنده — بر حسب تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام خروجی گرفتن ارائه به PDF یا SVG یا هنگام رندر اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند، به عنوان بخشی از نمودار، در این عملیات‌ها حفظ می‌شوند. همچنین روشی برای [صادر کردن یک تصویر از نمودار](/slides/fa/java/create-shape-thumbnails/) موجود است.