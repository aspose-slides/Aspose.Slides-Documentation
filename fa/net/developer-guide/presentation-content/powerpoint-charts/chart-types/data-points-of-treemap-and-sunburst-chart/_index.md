---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در .NET
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- نمودار treemap
- نمودار sunburst
- نمودار سلسله‌مراتبی
- نقطه داده
- برچسب داده
- رنگ شاخه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه داده‌های سلسله‌مراتبی ایجاد کنید و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای .NET سفارشی کنید."
---
## **نمای کلی**

نمودارهای Treemap و Sunburst داده‌های سلسله‌مراتبی مشابهی را نشان می‌دهند، اما از چیدمان‌های متفاوتی استفاده می‌کنند. یک Treemap سلسله‌مراتب را به صورت مستطیل‌های تو در تو می‌کشد که مساحت آن‌ها مقدار برگ‌ها را نمایان می‌سازد. یک Sunburst آن را به شکل حلقه‌های هم‌مرکزی نمایش می‌دهد: گروه‌های سطح بالا در نزدیکی مرکز قرار دارند و دسته‌های برگ در حلقه بیرونی هستند.

در Aspose.Slides برای .NET، هر مقدار عددی یک [IChartDataPoint](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/) است. مجموعهٔ [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) آن، دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله این نگاشت را توضیح می‌دهد و نشان می‌دهد چگونه هر دو نوع نمودار را با استفاده از یک مجموعه دادهٔ نمونه ایجاد و قالب‌بندی کنیم.

![نمودار Treemap با شاخه‌های Consumer و Business](treemap-hierarchy.png)

![نمودار Sunburst با همان سلسله‌مراتب Consumer و Business](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

نمونهٔ زیر شامل سه سطح دسته و یک سری عددی است:

| شاخه | سرشاخه | برگ | درآمد |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

هر ردیف یک دستهٔ برگ و یک نقطه داده می‌سازد. سطوح گروه‌بندی دسته، مسیر از آن برگ به والدینش را توصیف می‌کنند. برای ردیف اول، مسیر `Consumer > Computers > Laptops` است.

شاخص‌ها در [IChartDataPoint.DataPointLevels] از برگ به سمت بالا می‌روند:

| شاخص `DataPointLevels` | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | مستطیل مقدار | بخش حلقهٔ خارجی |
| `1` | سرشاخه | مستطیل یا سرعنوان والد | بخش حلقهٔ میانی |
| `2` | شاخه | مستطیل یا سرعنوان سطح بالا | بخش حلقهٔ داخلی |

این ترتیب برای هر دو نوع نمودار یکسان است حتی اگر چیدمان‌های بصری آن‌ها متفاوت باشد. یک بخش والد توسط چندین برگ به اشتراک گذاشته می‌شود. برای قالب‌بندی آن، سطح متناظر اولین نقطه داده در آن گروه را استفاده کنید. به عنوان مثال، شاخهٔ `Consumer` با نقطهٔ `Laptops` شروع می‌شود، در حالی که سرشاخهٔ `Software` با نقطهٔ `Licenses` شروع می‌شود. نگه داشتن ارجاع به آن نقاط شفاف‌تر و ایمن‌تر از استفاده از عبارات توضیح‌نشده‌ای مانند `dataPoints[0]` یا `dataPoints[6]` است.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap را در اسلاید اول و یک Sunburst را در اسلاید دوم ایجاد می‌کند. این مثال سلسله‌مراتب را می‌سازد، مقدار `Tablets` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح انتخابی اعمال می‌کند، برچسب یک شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می نماید.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // دسته‌های برگ را اضافه کنید. یک آیتم گروه‌بندی فقط زمانی تنظیم می‌شود که یک گروه جدید آغاز شود؛
    // دسته‌های بعدی تا زمانی که آیتم دیگری تنظیم شود در همان گروه باقی می‌مانند.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // دسته و مقدار را در برگ Tablets نشان دهید.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // فرمت شاخه Consumer را از طریق اولین برگ در آن شاخه تنظیم کنید.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // فرمت سرشاخه Software را از طریق اولین برگ در آن سرشاخه تنظیم کنید.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از بخش‌های حلقه‌ای استفاده می‌کند.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

سلول‌های دسته و سلول‌های مقدار از همان ردیف برگه کاری استفاده می‌کنند، بنابراین موقعیت‌های مجموعهٔ آن‌ها هم‌راستا می‌ماند. وقتی با یک نمودار موجود کار می‌کنید به جای ایجاد آن، ابتدا ردیف‌های دسته را بررسی کنید و ارجاعات نام‌گذاری‌شده به نقاط داده و سطوحی که قصد قالب‌بندی آن‌ها را دارید ذخیره کنید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- یک Treemap برای انتقال مقدار از مساحت استفاده می‌کند و برای انتقال سلسله‌مراتب از مستطیل‌های تو در تو بهره می‌برد. خصوصیت [IChartSeries.ParentLabelLayout] نحوهٔ نمایش برچسب‌های والد را در این نوع نمودار کنترل می‌کند.
- یک Sunburst برای انتقال مقدار از زاویه استفاده می‌کند و برای انتقال سلسله‌مراتب از عمق حلقه بهره می‌گیرد. [IChartSeries.ParentLabelLayout] برچسب‌های حلقهٔ آن را کنترل نمی‌کند.
- هر دو نوع نمودار از سطوح گروه‌بندی دسته یکسان و همان ترتیب برگ‑به‑والد در `DataPointLevels` استفاده می‌کنند، بنابراین کد ساخت داده و قالب‌بندی سطح می‌تواند مشترک باشد.
- مقادیر والد از برگ‌های فرزندشان محاسبه می‌شوند. نقاط عددی جداگانه برای شاخه‌ها یا سرشاخه‌ها اضافه نکنید.

### **مرتب‌سازی و ترتیب بخش‌ها**

موتور چیدمان نمودار جای‌گذاری نهایی مستطیل‌ها و بخش‌های حلقه را تعیین می‌کند. ردیف‌های دستهٔ مرتبط را پیش از افزودن کنار هم قرار دهید، اما به موقعیت خاص مستطیل یا زاویهٔ شروع وابسته نشوید. اگر ترتیب معنایی داشته باشد، آن را در برچسب‌ها بگنجانید یا از نوع نموداری با محور دستهٔ صریح استفاده کنید.

### **تم و رنگ‌های ثابت**

سطوح قالب‌نشدهٔ نمودار رنگ‌ها را از تم ارائه به ارث می‌برند. مثال از پرکن‌های RGB صریح برای خروجی پیش‌بینی‌پذیر استفاده می‌کند. اگر نمودار باید تغییرات تم را دنبال کند، به جای مقادیر ثابت RGB از رنگ‌های طرح‌بندی استفاده کنید و از بازنویسی هر سطح جلوگیری کنید. همچنین پس از تغییر پرکن یک شاخه یا سرشاخه، کنتراست برچسب را بررسی کنید.

### **برچسب‌ها و فضای موجود**

PowerPoint ممکن است برچسب‌ها را وقتی بخش بسیار کوچک است، مخفی یا کوتاه کند. افزایش اندازهٔ نمودار، کوتاه کردن نام‌های دسته یا نمایش تعداد کمتر فیلدهای برچسب معمولاً نتیجهٔ واضح‌تری می‌دهد. یک برچسب می‌تواند نام دسته، نام سری و مقدار را از طریق [IDataLabelFormat] ترکیب کند، اما فعال‌سازی همه فیلدها اغلب باعث می‌شود نمودارهای سلسله‌مراتبی خواندن دشوار شوند.

### **صادرات و رندرینگ**

ذخیره به فرمت PPTX نمودار را قابل ویرایش نگه می‌دارد. وقتی Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پرکن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی قلم و تفاوت‌های کوچک در فضای موجود چیدمان می‌تواند شکستن خطوط یا مشاهده‌پذیری برچسب را تغییر دهد، بنابراین قلم‌های لازم را نصب کنید و اهداف صادرات مهم را بررسی کنید.

## **سؤالات متداول**

**چرا تغییر یک سطح والد بر چندین برگ تأثیر می‌گذارد؟**

یک شاخه یا سرشاخه یک بخش بصری مشترک است. [IChartDataPointLevel] آن می‌تواند از طریق یک برگ فرزند دست‌یابی شود، اما قالب‌بندی به بخش والد مشترک تعلق دارد نه تنها به آن برگ.

**چرا یک برچسب داده گم شده است؟**

اولین کار فعال‌سازی فیلدهای مورد نیاز در شیء [IDataLabelFormat] برچسب است. سپس بررسی کنید آیا بخش فضای کافی دارد یا نه. چیدمان برچسب والد Treemap، ابعاد نمودار، طول برچسب، اندازه قلم و تعداد فیلدهای فعال شده همه بر قابلیت نمایش برچسب تأثیر می‌گذارند.

**آیا می‌توانم ترتیب یا مختصات دقیق بخش‌ها را تنظیم کنم؟**

می‌توانید ترتیب ردیف‌های منبع را کنترل کنید و هر گروه را پیوسته نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زوایای Sunburst را اختصاص دهید. موتور چیدمان نمودار آن‌ها را براساس سلسله‌مراتب، مقادیر و فضای موجود محاسبه می‌کند.

**چرا رنگ‌ها پس از تغییر تم ارائه تغییر می‌کنند؟**

پرکن‌های مبتنی بر تم برای پیروی از پالت ارائه طراحی شده‌اند. رنگ‌های RGB صریح را به سطوحی که باید ثابت بمانند اعمال کنید، یا وقتی تطبیق با تم جدید ترجیح داده می‌شود، از رنگ‌های طرح‌بندی استفاده کنید.

**آیا قالب‌بندی سفارشی در صادرات PDF و تصویر حفظ می‌شود؟**

بله، پرکن‌های پشتیبانی‌شدهٔ نمودار و تنظیمات برچسب در هنگام رندر گنجانده می‌شوند. برای نتایج سازگار بین سیستم‌ها، قلم‌های مورد نیاز را در دسترس قرار دهید و اندازهٔ نهایی صادرات را آزمایش کنید؛ زیرا تناسب برچسب به چیدمان وابسته است.

## **موارد مرتبط**

- [ایجاد نمودارهای Treemap](/slides/fa/net/create-chart/#create-tree-map-charts)
- [ایجاد نمودارهای Sunburst](/slides/fa/net/create-chart/#create-sunburst-charts)
- [صادرات نمودارهای ارائه](/slides/fa/net/export-chart/)
- [مدیریت تم‌های ارائه](/slides/fa/net/presentation-theme/)