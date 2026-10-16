---
title: افزودن خطوط روند به نمودارهای ارائه در اندروید
linktitle: خط روند
type: docs
url: /fa/androidjava/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای Android از طریق Java اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کنید. این مقاله نشان می‌دهد چگونه یک نمودار ایجاد کنید، خطوط روند را به سِری‌های نمودار اضافه کنید، و با چندین نوع خط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان.

همچنین توصیف می‌کند چگونه یک خط سفارشی به نمودار اضافه شود با قرار دادن یک شکل خط، و شامل یک سؤال‑پاسخ کوتاه درباره مقادیر پیش‌رو و بازگشتی پیش‌بینی خطوط روند و اینکه آیا خطوط روند هنگام خروجی به PDF یا SVG و هنگام رندر نمودارها به عنوان تصویر حفظ می‌شوند یا نه.

## **افزودن یک خط روند**

از [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) برای افزودن یک خط روند به یک سِری نمودار استفاده کنید و نوع آن را با [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/) انتخاب کنید. مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و دو خط روند به هر یک از سه سِری آن اضافه می‌کند.

خط روند نمایی معادله و مقدار R‑squared خود را با استفاده از [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) و [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) مخفی می‌کند، در حالی که خط روند خطی به‌صورت قرمز است. خط روند لگاریتمی از [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) برای برچسب سفارشی استفاده می‌کند. میانگین متحرک با یک [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) برابر با سه نقطه داده و یک [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) سفارشی ساخته می‌شود.

خط روند چندجمله‌ای دارای [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) برابر با سه است و یک دسته به‑صورت پیشرو از طریق [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-) گسترش می‌یابد. خط روند توان یک دسته به‑صورت بازگشتی از طریق [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-) گسترش می‌یابد.

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

## **تنظیم تقاطع خط روند**

از [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) برای ثابت کردن مقدار Y یک خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به عنوان مثال، مدل هزینه تولید ممکن است نیاز داشته باشد که از هزینه ثابت شناخته‌شده ۱۰۰ شروع شود، حتی اگر اندازه‌گیری‌ها در حجم‌های تولید غیر صفر نشانگر یک پایه متفاوت باشند. برای یک خط روند خطی، ثابت کردن تقاطع معادله `y = ax + b` را به `b = 100` محدود می‌کند؛ شیب تحت این محدودیت به داده‌ها برازش می‌شود. این کار به سادگی یک خط قبلاً برازش‌شده را جابه‌جا نمی‌کند. تنظیمات عبور محور مکان تقاطع محورها را تعیین می‌کند، نه ضریب‌های خط روند برازش‌شده.

مثال زیر یک نمودار پراکندگی (XY) با حجم‌های تولید ۱ تا ۴ و هزینه‌های ۱۷۰، ۲۰۰، ۲۳۰ و ۲۶۰ ایجاد می‌کند. این نمودار را با تقاطع خودکار پیش‌فرض ذخیره می‌کند، تقاطع را به ۱۰۰ تنظیم می‌کند و یک PPTX دوم ذخیره می‌نماید. دو فایل تنها در تنظیم تقاطع متفاوت هستند. خط روند معادله خود را نمایش می‌دهد و به X = 0 بازمی‌گردد.

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

با محاسبه خودکار، این داده‌ها `y = 30x + 140` تولید می‌کنند. تنظیم تقاطع به ۱۰۰ به‌جای آن تقریباً `y = 43.33x + 100` می‌دهد: مقدار برازش‌شده در صفر با پایه شناخته‌شده مطابقت دارد، در حالی که خط دیگر از هر نقطه داده عبور نمی‌کند.

| تقاطع خودکار | تقاطع ثابت 100 |
| --- | --- |
| ![خط روند خطی با تقاطع محاسبه‌شده خودکار 140](intercept-automatic.png) | ![خط روند خطی با تقاطع ثابت 100](intercept-fixed.png) |

هر دو تصویر از همان داده‌ها و مقیاس‌های محورها استفاده می‌کنند. خطوط روند به X = 0 بازگشته‌اند تا تقاطع‌هایشان نشان داده شود.

به‌صورت پیش‌فرض، [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) مقدار `Double.NaN` را برمی‌گرداند که نمایانگر تقاطع نامشخص است نه صفر. سپس تقاطع به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **افزودن یک خط سفارشی**

یک خط سفارشی یک شکل است که بر فراز نمودار کشیده می‌شود نه یک خط روند محاسبه‌شده از داده‌های سِری. این مثال از [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) برای افزودن یک خط افقی به اسلاید بر فراز نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید، بر حسب پوینت، مشخص می‌شود، بنابراین از لبهٔ چپ نمودار شروع می‌شود و نیمهٔ ارتفاع نمودار را می‌پوشاند. عرض آن با عرض نمودار مطابقت دارد. [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) خط را به رنگ قرمز ثابت می‌دهد.

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

## **سؤال‑پاسخ**

**مقدارهای «پیش‌رو» و «بازگشتی» برای یک خط روند چه معنایی دارند؟**

اینها طول‌های خط روند هستند که به‌صورت پیش‌رو یا بازگشتی پیش‌بینی می‌شوند: برای نمودارهای پراکندگی (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیر پراکندگی — بر حسب تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام خروجی ارائه به PDF یا SVG یا هنگام رندر اسلاید به یک تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند، به‌عنوان بخشی از نمودار، در طول این عملیات‌ها حفظ می‌شوند. همچنین روشی برای [export an image of the chart](/slides/fa/androidjava/create-shape-thumbnails/) وجود دارد.