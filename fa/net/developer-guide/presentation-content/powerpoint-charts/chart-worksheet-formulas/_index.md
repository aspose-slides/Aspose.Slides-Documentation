---
title: "اعمال فرمول‌های ورک‌شیت نمودار در ارائه‌ها در .NET"
linktitle: "فرمول‌های ورک‌شیت"
type: docs
weight: 70
url: /fa/net/chart-worksheet-formulas/
keywords:
- "صفحه‌گسترده نمودار"
- "ورک‌شیت نمودار"
- "فرمول نمودار"
- "فرمول ورک‌شیت"
- "فرمول صفحه‌گسترده"
- "کتاب‌کار داده‌های نمودار"
- "محاسبه فرمول"
- "فرهنگ ترجیحی"
- "فرمول مختص به فرهنگ"
- "DBCS"
- "ثابت منطقی"
- "ثابت عددی"
- "ثابت رشته‌ای"
- "ثابت خطا"
- "عملگر حسابی"
- "عملگر مقایسه‌ای"
- "سبک A1"
- "سبک R1C1"
- "تابع پیش‌تعریف‌شده"
- "PowerPoint"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "فرمول‌های سبک اکسل را در ورک‌شیت‌های نمودار Aspose.Slides برای .NET اعمال کنید، مقادیر را بازمحاسبه کنید و نتایج را در نمودارهای PowerPoint به‌کار ببرید."
---
## **نمای کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک ورک‌شیت جاسازی شده ذخیره می‌کنند. در Aspose.Slides برای .NET می‌توانید از طریق کتاب‌کار داده‌های نمودار به آن ورک‌شیت دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‑شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کامل کار با فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن ورک‌شیت آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر کش‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای خاص صفحات‌گسترده را شرح می‌دهد.

## **ورک‌شیت‌ها و فرمول‌های نمودار**

یک ورک‌شیت نمودار شامل دسته‌ها، نام‌های سری و مقادیری است که توسط نمودار استفاده می‌شوند. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، ورک‌شیت را بررسی کنید:

![نمودار PowerPoint با ورک‌شیت جاسازی‌شده باز که داده‌های دسته و سری را نشان می‌دهد](chart-worksheet-formulas_1.png)

در Aspose.Slides، ورک‌شیت از طریق [chart data workbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از ویژگی [Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/formula/) و برای فرمول‌های سبک R1C1 از ویژگی [R1C1Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/r1c1formula/) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‑شده و به‑روزرسانی مقادیر سلول‌های مربوطه، متد [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق ویژگی [Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) در اختیار می‌گذارد. این نکته زمانی مهم است که می‌خواهید نتیجه فرمول را در کد بررسی کنید یا سلول را به عنوان یک نقطه داده نمودار استفاده کنید.

## **ایجاد نمودار و محاسبه فرمول‌های ورک‌شیت**

مثال زیر یک جریان کاری انتها‑به‑انتها را نشان می‌دهد. این مثال یک نمودار ستونی خوشه‌ای می‌سازد، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

نقاط داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری فراخوانی جداگانه‌ای برای تازه‑سازی نمودار وجود ندارد: ابتدا ورک‑بوک را بازمحاسبه کنید، سپس داده‌های نمودار را که به سلول‌های محاسبه‌شده اشاره دارند، استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نمادگذاری A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. برای اختصاص عبارات سبک A1 از [IChartDataCell.Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/formula/) استفاده کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

فرم‌های مرجع متداول A1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مرجع‌های نسبی ممکن است هنگام جابه‌جایی یا کپی شدن فرمول توسط برنامه صفحه‌گسترده تغییر کنند. مراجع مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نمادگذاری R1C1 ردیف‌ها و ستون‌ها را به صورت عددی شناسایی می‌کند. مراجع نسبی با افست‌ها در براکت‌های مربعی نشان داده می‌شوند. این نحو را از طریق [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/r1c1formula/) اختصاص دهید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

فرم‌های مرجع متداول R1C1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان ردیف دو ستون به سمت چپ (`B2`) اشاره می‌کند.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب داخلی فرمول‌ها مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و Literals**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توان به صورت مستقیم در عبارات منطقی مانند `A2=TRUE` استفاده کرد. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوشتارهای معمولی و علمی پشتیبانی می‌شوند. |
| رشته‌ای | `"abc"`, `"2/3/2020 12:00"` | متون داخل فرمول با علامت نقل‌قول دوتایی محصور می‌شوند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای نتیجه عادی، به یک مقدار خطای صفحه‌گسترده ارزیابی شود. |

این مثال چند نوع ثابت را به کار می‌گیرد:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // نادرست
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **عملگرهای حسابی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا علامت مثبت یک‌تایی | `2+3` |
| `-` | تفریق یا منفی یک‌تایی | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای واضح کردن ترتیب ارزیابی می‌توانید از پرانتز استفاده کنید؛ مثال: `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | مساوی | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگ‌تر | `A2>3` |
| `>=` | بزرگ‌تر یا مساوی | `A2>=3` |
| `<` | کوچک‌تر | `A2<3` |
| `<=` | کوچک‌تر یا مساوی | `A2<=3` |

## **توابع پیش‌تعریف‌شده پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای ورک‌شیت‌های نمودار فراهم می‌کند، اما یک موتور محاسبه کامل Excel نیست. مجموعه مستند توابع به توابع زیر محدود می‌شود. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بازمحاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن به سمت بالا به مضربی | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس اندیس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ترکیب مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | ترکیب مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | تعداد روزهای بین دو تاریخ | `DAYS(B2,A2)` |
| `FIND` | یافتن یک متن داخل متن دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی بایت‑محور | `FINDB("a",A2)` |
| `IF` | نتیجه شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه | `MAX(B2:B5)` |
| `SUM` | جمع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان داده شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده است، در حالی که `LOOKUP` و `MATCH` به صورت فرم‌های برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. توابع و ویژگی‌هایی که در اینجا فهرست نشده‌اند باید به عنوان غیرقابل پشتیبانی توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند، مگر این که به‌صورت جداگانه مستند شده باشند.

## **محاسبه فرمول‌ها با فرهنگ ترجیحی**

برخی از توابع کتاب‌کار نمودار متن را بر اساس قوانین خاص فرهنگ تفسیر می‌کنند. این مسئله بخصوص برای توابعی که برای زبان‌های دارای مجموعه کاراکتر دو بایتی (DBCS) طراحی شده‌اند مهم است. برای محاسبه صحیح این فرمول‌ها، یک [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید، از طریق [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/spreadsheetoptions/) ویژگی [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/fa/net/aspose.slides/ispreadsheetoptions/preferredculture/) را تنظیم کنید و سپس ارائه را بارگذاری کنید.

مثال زیر فرهنگ ژاپنی را انتخاب می‌کند، ارائه‌ای را با گزینه‌های بارگذاری تنظیم‌شده باز می‌کند و برای هر کتاب‌کار نمودار متد [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی می‌کند:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

فرهنگ ترجیحی بخشی از پیکربندی بارگذاری ارائه است، بنابراین قبل از ایجاد نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) این مقدار را تنظیم کنید. از فرهنگی استفاده کنید که فرمول‌های کتاب‌کار انتظار دارد؛ به عنوان مثال برای فرمول‌های ماجرای DBCS ژاپنی از `ja-JP` استفاده کنید.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شده آن را ذخیره می‌کنند. Aspose.Slides می‌تواند مقدار کش‌شده را از ویژگی [IChartDataCell.Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) هنگام بارگذاری ارائه بخواند، به‌شرط این‌که داده‌های نمودار مربوطه تغییر نکرده باشند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتایج کش‌شده قدیمی تکیه نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیره داده‌های نموداری که به آن‌ها وابسته‌اند، متد [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

برای فرمول‌های خارج از زیرمجموعه پشتیبانی‌شده، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار تغییر کرده باشد، مقدار کش‌شده قبلی دیگر قابل اطمینان نیست. در چنین موقعیتی، خواندن مقدار سلول با داده‌های غیرقابل پشتیبانی می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel وابسته باشد که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده که از آن‌ها پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. فرمول‌های غیرقابل پشتیبانی را با مقادیر تخمینی جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل مختلف وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجه‌ای از نوع خطای صفحه‌گسترده مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت توکن خطا یک نتیجه سلول است و می‌تواند از طریق `Value` بازگردانده شود.

یک فرمول ممکن است در زمان تجزیه، ارجاع، وابستگی یا سطح داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای خاص صفحه‌گسترده فراهم می‌کند: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

وقتی فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، این استثناها را دور بازمحاسبه و دسترسی به مقدار به‌کاربرید:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول در ورک‌شیت‌های نمودار برای یک زیرمجموعه تعریف‌شده از محاسبات صفحه‌گسترده هدف‌گذاری شده است و نه برای سازگاری کامل با Excel. هنگام طراحی جریان کار گزارش‌دهی این محدودیت‌ها را در نظر بگیرید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده استفاده کنید تا Aspose.Slides بتواند فرمول‌ها را بازمحاسبه کند.
- پس از تغییر سلول‌هایی که نتایج فرمول به آنها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شده از ارائه‌های بارگذاری‌شده را به‌عنوان «عکس‌برداری» در نظر بگیرید، نه به‌عنوان جایگزین برای بازمحاسبه پس از ویرایش.
- فرمول‌های قالب‌های موجود را پیش از اتکا به مقادیر محاسبه‌شده آزمایش کنید، به‌ویژه وقتی از توابعی خارج از فهرست مستند استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل صفحه‌گسترده نیاز دارند، آنها را به‌صورت خارجی محاسبه کنید و سپس مقادیر نهایی را در کتاب‌کار نمودار به‌روزرسانی کنید.

## **سوالات متداول**

**فرق بین `Formula` و `R1C1Formula` چیست؟**

[Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/formula/) یک عبارت سبک A1 مثل `B2-C2` را ذخیره می‌کند. [R1C1Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/r1c1formula/) یک عبارت سبک R1C1 مثل `RC[-2]-RC[-1]` را ذخیره می‌کند. از نمادگذاری‌ای استفاده کنید که بهترین تطابق را با نحوهٔ تولید یا کپی فرمول‌ها داشته باشد.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/getcell/) یک `IChartDataCell` برمی‌گرداند. برای دریافت نتیجه محاسبه‌شده، بعد از بازمحاسبه ویژگی [Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) آن سلول را بخوانید.

**چه زمانی باید `CalculateFormulas` را صدا بزنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و قبل از اینکه به نتایج محاسبه‌شده وابسته باشید، متد [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید. این کار مقادیر فرمول‌های پشتیبانی‑شده توسط ارزیاب داخلی را به‌روز می‌کند.

**آیا Aspose.Slides تمام توابع Excel را پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط یک زیرمجموعهٔ مستند از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید انتظار داشته باشید که به‌درستی بازمحاسبه شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام دهید و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده حاوی فرمول غیرقابل پشتیبانی باشد چه اتفاقی می‌افتد؟**

اگر داده‌های نمودار تغییر نکرده باشند، ممکن است کتاب‌کار هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول با استثنای‌های .NET یکسان هستند؟**

خیر. مقداری مانند `#DIV/0!` یک مقدار صفحه‌گسترده است که توسط یک محاسبهٔ معتبر تولید شده است. استثنایی مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) نشان می‌دهد که فرمول نمی‌تواند به‌صورت عادی پردازش شود.

**آیا تغییر مقدار سلول فرمولی باعث به‌روزرسانی خودکار نمودار می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده اشاره داشته باشند، نمودار از مقادیر به‌روز شده استفاده می‌کند؛ نیازی به متد جداگانه‌ای برای تازه‑سازی نمودار در این جریان کاری نیست.

**آیا نمودار می‌تواند از یک کتاب‌کار Excel خارجی استفاده کند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار به یک کتاب‌کار خارجی متصل شوند. با این حال، جریان کاری محاسبه فرمول که در این مقاله توضیح داده شده مربوط به کتاب‌کار داده‌های نمودار و زیرمجموعهٔ فرمول‌های ارزیاب Aspose.Slides است. فرض نکنید که [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) بازمحاسبه کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی که به ورک‌شیت یا کتاب‌کار دیگری ارجاع می‌دهند استفاده کنم؟**

ارجاع‌های سبک‑Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیاب فرمول به‌دلیل محدودیت‌های پارسر و مجموعهٔ توابع، تنها این ارجاع‌ها را پشتیبانی می‌کند. اگر ارجاع متقاطع یا خارجی حیاتی است، دقیقاً همان فرمول را با نسخه هدف Aspose.Slides خود اعتبارسنجی کنید. برای جریان‌های کاری که به سازگاری گستردهٔ ارجاع Excel نیاز دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‑شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

مثال‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون `=` پیش‌وند می‌دهند. استفاده از این شکل باعث می‌شود فرمول‌های تولیدشده با مثال‌های مستند API هماهنگ باشد.