---
title: افزودن خطوط روند به نمودارهای ارائه در جاوا اسکریپت
linktitle: خط روند
type: docs
url: /fa/nodejs-java/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توانی
- خط روند سفارشی
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای پاورپوینت با جاوااسکریپت و Aspose.Slides برای Node.js via Java اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides خطوط روند را به نمودارهای ارائه اضافه کنید. نشان می‌دهد چگونه یک نمودار ایجاد کنید، خطوط روند را به سری‌های نمودار اضافه کنید و با چندین نوع خط روند کار کنید، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توانی.

همچنین توصیف می‌کند چگونه یک خط سفارشی را با افزودن شکل خط به نمودار اضافه کنید و شامل بخش پرسش‌وپاسخ کوتاهی درباره مقادیر پیش‌بینی شده خط روند به سمت جلو و عقب و اینکه آیا خطوط روند هنگام خروجی به PDF یا SVG و هنگام رندر نمودارها به تصویر حفظ می‌شوند یا خیر.

## **افزودن خط روند**

از [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) برای افزودن خط روند به یک سری نمودار استفاده کنید و نوع آن را با [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/) انتخاب کنید. مثال یک نمودار میله‌ای خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و به هر یک از سه سری‌اش دو خط روند اضافه می‌کند.

خط روند نمایی معادله و مقدار R‑squared خود را از طریق [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) و [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue) مخفی می‌کند، در حالی که خط روند خطی به رنگ قرمز است. خط روند لگاریتمی از [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) برای برچسب سفارشی استفاده می‌کند. میانگین متحرک از یک [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) برابر با سه نقطه داده و یک [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) سفارشی استفاده می‌کند.

خط روند چندجمله‌ای یک [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) برابر با سه دارد و از طریق [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward) یک دسته به سمت جلو گسترش می‌یابد. خط روند توانی از طریق [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward) یک دسته به سمت عقب گسترش می‌یابد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم مقطع خط روند**

از [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) برای ثابت کردن مقدار Y خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به عنوان مثال، یک مدل هزینه تولید ممکن است نیاز داشته باشد از هزینه‌های ثابت شناخته‌شده 100 شروع شود، حتی اگر اندازه‌گیری‌ها در حجم‌های تولید غیرصفر نشان‌دهنده پایه‌ای متفاوت باشند. برای یک خط روند خطی، ثابت کردن مقطع معادله `y = ax + b` را به `b = 100` محدود می‌کند؛ شیب تحت آن محدودیت به داده‌ها برازش می‌شود. این کار به سادگی خطی که قبلاً برازش شده را جابه‌جا نمی‌کند. تنظیمات تقاطع محور، محل تلاقی محورها را کنترل می‌کند، نه ضرایب خط روند برازش‌شده.

مثال زیر یک نمودار پراکنده (XY) با حجم‌های تولید از 1 تا 4 و هزینه‌های 170، 200، 230 و 260 ایجاد می‌کند. نمودار را با مقطع خودکار پیش‌فرض ذخیره می‌کند، مقطع را به 100 تنظیم می‌کند و یک PPTX دوم ذخیره می‌کند. دو فایل تنها در تنظیم مقطع با هم متفاوت هستند. خط روند معادله خود را نمایش می‌دهد و به X = 0 بازمی‌گردد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

با محاسبه خودکار، این داده‌ها `y = 30x + 140` را تولید می‌کند. تنظیم مقطع به 100 به‌جای آن تقریباً `y = 43.33x + 100` می‌شود: مقدار برازش‌شده در صفر با پایه شناخته‌شده مطابقت دارد، در حالی که خط دیگر از هر نقطه داده عبور نمی‌کند.

| مقطع خودکار | مقطع ثابت 100 |
| --- | --- |
| ![خط روند خطی با مقطع محاسبه‌شده خودکار 140](intercept-automatic.png) | ![خط روند خطی با مقطع ثابت 100](intercept-fixed.png) |

هر دو تصویر از همان داده‌ها و مقیاس‌های محور استفاده می‌کنند. خطوط روند تا X = 0 بازگشت داده شده‌اند تا مقاطعشان نشان داده شود.

به‌طور پیش‌فرض، [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) مقدار `NaN` را برمی‌گرداند که نشان‌دهنده مقطع نامشخص است، نه صفر. سپس مقطع به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **افزودن خط سفارشی**

یک خط سفارشی شکلی است که بر روی نمودار کشیده می‌شود نه خط روندی که از داده‌های سری محاسبه می‌شود. این مثال از [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) برای افزودن یک خط افقی به اسلاید بالای نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید، بر حسب پوینت، مشخص می‌شود، بنابراین از لبه چپ نمودار شروع می‌شود و در نیمه‌سوی پایین نمودار قرار می‌گیرد. عرض آن برابر با عرض نمودار است. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) به خط رنگ ثابت قرمز می‌دهد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌وپاسخ**

**«پیشرو» و «عقب‌رو» برای یک خط روند به چه معناست؟**

اینها طول‌های خط روند هستند که به سمت جلو/عقب پیش‌بینی می‌شوند: برای نمودارهای پراکنده (XY) — به واحدهای محور؛ برای نمودارهای غیرپراکنده — به تعداد دسته‌ها. فقط مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام خروجی ارائه به PDF یا SVG یا هنگام رندر اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند به‌عنوان بخشی از نمودار در این عملیات‌ها حفظ می‌شوند. همچنین روشی برای [صدور تصویر نمودار](/slides/fa/nodejs-java/create-shape-thumbnails/) وجود دارد.