---
title: "اعمال فرمول‌های Worksheet نمودار در ارائه‌ها در .NET"
linktitle: "فرمول‌های Worksheet"
type: docs
weight: 70
url: /fa/net/chart-worksheet-formulas/
keywords:
- "صفحه‌گسترده نمودار"
- "worksheet نمودار"
- "فرمول نمودار"
- "فرمول worksheet"
- "فرمول صفحه‌گسترده"
- "Workbook داده‌های نمودار"
- "محاسبه فرمول"
- "ثابت منطقی"
- "ثابت عددی"
- "ثابت رشته‌ای"
- "ثابت خطا"
- "عملگر حسابی"
- "عملگر مقایسه‌ای"
- "سبک A1"
- "سبک R1C1"
- "تابع از پیش تعریف‌شده"
- "PowerPoint"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "استفاده از فرمول‌های شبیه به Excel در worksheetهای نمودار Aspose.Slides برای .NET، دوباره محاسبه مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **نمای کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک worksheet جاسازی‌شده ذخیره می‌کنند. در Aspose.Slides for .NET می‌توانید از طریق کتاب‌کار داده‌های نمودار به آن worksheet دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کامل کار با فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن worksheet آن، اختصاص فرمول‌های سبک A1 یا R1C1، دوباره‌محاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار و ذخیره ارائه. همچنین سینتکس فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر ذخیره‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای خاص spreadsheet را شرح می‌دهد.

## **Worksheetهای نمودار و فرمول‌ها**

یک worksheet نمودار شامل دسته‌بندی‌ها، نام‌های سری و مقادیری است که توسط نمودار استفاده می‌شوند. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، worksheet را بررسی کنید:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

در Aspose.Slides، worksheet از طریق [chart data workbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از ویژگی [Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/formula/) و برای فرمول‌های سبک R1C1 از ویژگی [R1C1Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/r1c1formula/) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای دوباره‌محاسبه فرمول‌های پشتیبانی‌شده و بروزرسانی مقادیر سلول‌های مربوطه، متد [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

یک سلول محاسبه‌شده هنوز نتیجه خود را از طریق ویژگی [Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) در دسترس می‌گذارد. این نکته زمانی مهم است که نیاز به بررسی نتیجه فرمول در کد یا استفاده از سلول به عنوان نقطه داده نمودار داشته باشید.

## **ایجاد یک نمودار و محاسبه فرمول‌های Worksheet**

مثال زیر یک جریان کار انتها به انتها را نشان می‌دهد. این مثال یک نمودار ستونی خوشه‌ای می‌سازد، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌نماید.

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

نقطه‌های داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری هیچ فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار وجود ندارد: ابتدا workbook را دوباره محاسبه کنید، سپس از داده‌های نموداری که به سلول‌های محاسبه‌شده اشاره می‌کند استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نشانگذاری A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [IChartDataCell.Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/formula/) اختصاص دهید.

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

فرم‌های مرجع A1 رایج عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مراجعات نسبی ممکن است هنگام جابجا یا کپی شدن فرمول توسط برنامه spreadsheet تغییر کنند. مراجعات مطلق هر دو مختصه را ثابت نگه می‌دارند، در حالی‌که مراجعات ترکیبی فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نشانگذاری R1C1 هر دو ردیف و ستون را به صورت عددی شناسایی می‌کند. مراجعات نسبی با افست‌ها در براکت‌های مربع مشخص می‌شوند. این سینتکس را از طریق [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/r1c1formula/) اختصاص دهید.

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

فرم‌های مرجع R1C1 رایج عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان ردیف دو ستون به سمت چپ (`B2`) اشاره دارد.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی از مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای spreadsheet، عملگرهای ریاضی و عملگرهای مقایسه‌ای پشتیبانی می‌کند.

### **ثابت‌ها و مقادیر ثابت**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توان به‌صورت مستقیم در عبارات منطقی مانند `A2=TRUE` استفاده کرد. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | هر دو نمایه دهی عمومی و علمی پشتیبانی می‌شود. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | متغیرهای متنی در داخل فرمول با علامت‌های نقل‌قول دوگانه محصور می‌شوند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای نتیجه عادی، مقدار خطای spreadsheet را برگرداند. |

این مثال چندین نوع ثابت را استفاده می‌کند:

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

### **عملگرهای ریاضی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا علامت مثبت یک‌تایی | `2+3` |
| `-` | تفریق یا منفی یک‌تایی | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای صریح‌سازی ترتیب ارزیابی از پرانتز استفاده کنید، برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | برابر | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگتر | `A2>3` |
| `>=` | بزرگتر یا مساوی | `A2>=3` |
| `<` | کوچکتر | `A2<3` |
| `<=` | کوچکتر یا مساوی | `A2<=3` |

## **توابع از پیش تعریف‌شده پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای worksheetهای نمودار دارد، اما یک موتور محاسبه کامل Excel نیست. مجموعه توابع مستند شده محدود به توابع زیر است. فرض نکنید که هر تابع Excel می‌تواند توسط [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) دوباره محاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن به بالا تا مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس شاخص | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | اتصال مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | اتصال مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ساخت مقدار تاریخ با سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی مبتنی بر بایت | `FINDB("a",A2)` |
| `IF` | نتیجه شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | مقدار حداکثری | `MAX(B2:B5)` |
| `SUM` | مجموع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان داده‌شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده است، در حالی که `LOOKUP` و `MATCH` به صورت فرم‌های برداری مستند شده‌اند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند باید به‌عنوان غیرقابل پشتیبانی توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند مگر اینکه جداگانه مستند شده باشند.

## **دوباره‌محاسبه و مقادیر ذخیره‌شده**

پرونده‌های spreadsheet معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شده را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند هنگام بارگذاری ارائه، مقدار ذخیره‌شده را از [IChartDataCell.Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) بخواند، به شرطی که داده‌های نمودار مرتبط تغییر نکرده باشند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتیجه ذخیره‌شده قدیمی اعتماد نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیره داده‌های نموداری که به آن‌ها وابسته‌اند، متد [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعه پشتیبانی‌شده هستند، Aspose.Slides ممکن است نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر workbook تغییر کرده باشد، مقدار ذخیره‌شده قبلی دیگر قابل اعتماد نخواهد بود. در این وضعیت، خواندن مقدار سلولی که دادهٔ پشتیبانی‌نشده دارد می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel متکی است که Aspose.Slides ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور spreadsheet که آن‌ها را پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به workbook نمودار بنویسید. فرمول‌های پشتیبانی‌نشده را با مقادیر تخمین‌شده جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل مختلف وجود دارد.

یک فرمول می‌تواند معتبر باشد ولی نتیجهٔ خطای spreadsheet مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, یا `#VALUE!` تولید کند. در این حالت توکن خطا یک نتیجهٔ سلولی است و می‌تواند از طریق `Value` بازگردانده شود.

یک فرمول می‌تواند در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای مخصوص spreadsheet ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

وقتی فرمول‌ها از قالب‌های از پیش تعریف‌شده یا ورودی کاربر می‌آیند، این استثناها را در اطراف دوباره‌محاسبه و دسترسی به مقدار مدیریت کنید:

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

پشتیبانی از فرمول در worksheetهای نمودار برای یک زیرمجموعه تعریف‌شده از محاسبات spreadsheet طراحی شده است و نه برای سازگاری کامل با Excel. این محدودیت‌ها را هنگام طراحی یک جریان کار گزارش‌گیری در نظر بگیرید:

- فقط ثابت‌ها، عملگرها، مراجع و توابع مستند شده را زمانی که نیاز دارید Aspose.Slides فرمول‌ها را دوباره محاسبه کند، استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، دوباره محاسبه کنید.
- مقادیر ذخیره‌شده از ارائه‌های بارگذاری‌شده را به‌عنوان عکس‌برداری در نظر بگیرید، نه به‌عنوان جایگزین برای دوباره‌محاسبه پس از ویرایش‌ها.
- فرمول‌های قالب‌های موجود را پیش از اتکای بر مقادیر محاسبه‌شده تست کنید، به‌ویژه وقتی از توابعی خارج از لیست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل spreadsheet نیاز دارند، آن‌ها را به‌صورت خارجی محاسبه کرده و سپس مقادیر نهایی را به workbook نمودار به‌روزرسانی کنید.

## **سوالات متداول**

**تفاوت بین `Formula` و `R1C1Formula` چیست؟**

[Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/formula/) یک عبارت سبک A1 مانند `B2-C2` ذخیره می‌کند. [R1C1Formula](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/r1c1formula/) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` ذخیره می‌کند. از نشانه‌گذاری‌ای استفاده کنید که با نحوهٔ تولید یا کپی فرمول‌های شما بیشتر منطبق باشد.

**پس از محاسبه آیا باید خود سلول یا مقدار آن را بخوانم؟**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/getcell/) یک `IChartDataCell` برمی‌گرداند. برای به‌دست آوردن نتیجهٔ محاسبه‌شده، پس از دوباره‌محاسبه ویژگی [Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) آن سلول را بخوانید.

**چه وقت باید `CalculateFormulas` را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و قبل از اینکه به نتایج محاسبه‌شده وابسته شوید، متد [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) را فراخوانی کنید. این کار مقادیر فرمول‌های پشتیبانی‌شده توسط ارزیاب داخلی را به‌روز می‌کند.

**آیا Aspose.Slides از تمام توابع Excel پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط یک زیرمجموعهٔ مستند شده از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید فرض شود که به‌درستی دوباره محاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور spreadsheet مناسب انجام داده و مقادیر نهایی را به workbook نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده شامل فرمول پشتیبانی‌نشده باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشند، ممکن است workbook هنوز مقدار ذخیره‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار ذخیره‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همانند استثنای‌های .NET هستند؟**

خیر. نتیجه‌ای مانند `#DIV/0!` یک مقدار spreadsheet است که توسط یک محاسبهٔ معتبر تولید شده. استثنائاتی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) نشان می‌دهند که فرمول به‌طور عادی قابل پردازش نیست.

**آیا نمودار به‌صورت خودکار وقتی یک سلول فرمولی تغییر می‌کند به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های workbook ارجاع دهد. ابتدا workbook را دوباره محاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط داده نمودار به سلول‌های محاسبه‌شده اشاره داشته باشند، نمودار از مقادیر به‌روزرسانی‌شدهٔ آن سلول‌ها استفاده می‌کند؛ نیازی به فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار در این جریان کار نیست.

**آیا نمودارها می‌توانند از یک workbook Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار برای استفاده از یک workbook خارجی پیکربندی شوند. با این حال، جریان کاری محاسبهٔ فرمول که در این مقاله توصیف شده مربوط به workbook داده‌های نمودار و زیرمجموعهٔ فرمول ارزیابی‌شده توسط Aspose.Slides است. فرض نکنید که [CalculateFormulas](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) محاسبهٔ کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به worksheet یا workbook دیگری ارجاع می‌دهند؟**

مراجعات به سبک Excel ممکن است در workbookهای نمودار وجود داشته باشند، اما ارزیابی فرمول توسط پارسر و مجموعهٔ توابع پشتیبانی‌شده محدود است. اگر یک مرجع بین‑sheet یا خارجی ضروری باشد، دقیقاً همان فرمول را با نسخهٔ هدف Aspose.Slides خود بررسی کنید. برای جریان‌های کاری که نیاز به سازگاری وسیع ارجاعات Excel دارند، workbook را به‌صورت خارجی محاسبه کرده و مقادیر حل‌شده را به داده‌های نمودار بازگردانید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون پیشوند `=` اختصاص می‌دهند. استفاده از این فرم باعث می‌شود فرمول‌های تولیدشده با مثال‌های مستند شده در API هماهنگ باشند.