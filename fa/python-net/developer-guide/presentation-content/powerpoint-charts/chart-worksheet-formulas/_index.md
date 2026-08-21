---
title: اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها با Python
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/python-net/chart-worksheet-formulas/
keywords:
- صفحه‌گشت نمودار
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گشت
- کتاب‌کار داده‌های نمودار
- محاسبه فرمول
- فرهنگ ترجیحی
- فرمول مخصوص فرهنگ
- DBCS
- ثابت منطقی
- ثابت عددی
- ثابت رشته‌ای
- ثابت خطا
- عملگر حسابی
- عملگر مقایسه‌ای
- سبک A1
- سبک R1C1
- تابع پیش‌تعریف‌شده
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "اعمال فرمول‌های سبک Excel در Aspose.Slides برای Python از طریق کتاب‌کارهای نمودار .NET، محاسبه مجدد مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **بررسی کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ توکار ذخیره می‌کنند. در Aspose.Slides برای Python از طریق .NET، می‌توانید به آن کاربرگ از طریق کتاب‌کار داده‌های نمودار دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کامل کار با فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پرکردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نموداری و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر ذخیره‌شده، فرمول‌های غیرپشتیبانی‌شده و خطاهای خاص صفحه‌گشت را توضیح می‌دهد.

## **کاربرگ‌های نمودار و فرمول‌ها**

یک کاربرگ نمودار شامل دسته‌ها، نام‌های سری و مقادیری است که توسط یک نمودار استفاده می‌شود. در PowerPoint می‌توانید کاربرگ را با باز کردن ویرایشگر داده‌های نمودار بررسی کنید:

![نمودار PowerPoint با کاربرگ توکار باز که داده‌های دسته و سری را نشان می‌دهد](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق [chart data workbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdataworkbook/) در دسترس قرار می‌گیرد. برای فرمول‌های سبک A1 از ویژگی [formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/formula/) و برای فرمول‌های سبک R1C1 از ویژگی [r1c1_formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق ویژگی [value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/value/) در دسترس می‌گذارد. این زمانی مهم است که نیاز به بازرسی نتیجه فرمول در کد داشته باشید یا سلول را به عنوان یک نقطه داده نمودار استفاده کنید.

## **ایجاد نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک جریان کار انتها‑به‑انتها را نشان می‌دهد. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

نقاط داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری هیچ فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار وجود ندارد: ابتدا کتاب‌کار را بازمحاسبه کنید، سپس از داده‌های نمودار که به سلول‌های محاسبه‌شده اشاره می‌کند استفاده یا ذخیره نمایید.

## **استفاده از فرمول‌های سبک A1**

نحو A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [IChartDataCell.formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/formula/) اختصاص دهید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # ۱۹
```

فرم‌های مرجع عمومی A1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مراجع نسبی می‌توانند هنگام جابه‌جایی یا کپی فرمول توسط یک برنامه صفحه‌گشت تغییر کنند. مراجع مطلق هر دو مختصه را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نحو R1C1 هم ردیف‌ها و هم ستون‌ها را به صورت عددی شناسایی می‌کند. مراجع نسبی از افست‌ها در کروشه‌ها استفاده می‌کنند. این نحو را از طریق [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) اختصاص دهید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

فرم‌های مرجع عمومی R1C1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به عنوان مثال، در سلول `D2`، `RC[-2]` به معنای سلولی است که در همان ردیف دو ستون به سمت چپ قرار دارد (`B2`).

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، علائم عددی، رشته‌ها، مقادیر خطای صفحه‌گشت، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و علائم عددی**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌تواند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شود. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نشانه‌گذاری اعشاری و علمی پشتیبانی می‌شود. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی داخل فرمول با علامت نقل‌قول دوگانه محصور می‌شوند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای نتیجه عادی، مقدار خطای صفحه‌گشت را برگرداند. |

این مثال چند نوع ثابت را به کار می‌برد:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # نادرست
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **عملگرهای حسابی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا مثبت یک‌بار | `2+3` |
| `-` | تفریق یا منفی یک‌بار | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای صراحت ترتیب ارزیابی، می‌توانید از پرانتز استفاده کنید، به عنوان مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی باز می‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | مساوی با | `A2=3` |
| `<>` | نامساوی با | `A2<>3` |
| `>` | بزرگتر از | `A2>3` |
| `>=` | بزرگتر یا مساوی با | `A2>=3` |
| `<` | کوچکتر از | `A2<3` |
| `<=` | کوچکتر یا مساوی با | `A2<=3` |

## **توابع پیش‌تعریف‌شده پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای کاربرگ‌های نمودار دارد، اما این یک موتور محاسبه کامل Excel نیست. مجموعه توابع مستند شده به توابع زیر محدود می‌شود. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) دوباره محاسبه شود.

| تابع | هدف یا شکل پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس اندیس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ادغام مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | ادغام مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | بازگرداندن تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک متن داخل متن دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی مبتنی بر بایت | `FINDB("a",A2)` |
| `IF` | نتیجه شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | شکل مرجعی | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شکل برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شکل برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه | `MAX(B2:B5)` |
| `SUM` | مجموع | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده‌شده در جدول مهم هستند: `INDEX` به صورت مرجع مستند شده است، در حالی که `LOOKUP` و `MATCH` به صورت برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند باید به‌عنوان غیرپشتیبانی‌شده توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند مگر اینکه به‌طور جداگانه مستند شده باشند.

## **محاسبه فرمول‌ها با فرهنگ ترجیحی**

برخی از توابع کتاب‌کار نمودار متن را بر اساس قوانین فرهنگی خاص تفسیر می‌کنند. این برای توابعی که برای زبان‌هایی با مجموعه کاراکترهای دو بایتی (DBCS) طراحی شده‌اند، به‌ویژه مهم است. برای محاسبه صحیح چنین فرمول‌هایی، یک [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) ایجاد کنید، از طریق [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/spreadsheet_options/) ویژگی [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/spreadsheetoptions/) را تنظیم کنید و سپس ارائه را بارگذاری کنید.

مثال زیر فرهنگ ژاپنی را انتخاب می‌کند، یک ارائه را با گزینه‌های بارگذاری پیکربندی‌شده باز می‌کند و برای هر کتاب‌کار نمودار متد [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) را فراخوانی می‌کند:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

فرهنگ ترجیحی بخشی از پیکربندی بارگذاری ارائه است، بنابراین قبل از ساخت نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) آن را تعیین کنید. از فرهنگی استفاده کنید که فرمول‌های کتاب‌کار انتظار دارند؛ به‌عنوان مثال برای فرمول‌هایی که باید قوانین محاسبه DBCS ژاپن را دنبال کنند، `ja-JP` را به کار ببرید.

## **بازمحاسبه و مقادیر ذخیره‌شده**

فایل‌های صفحه‌گشت معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شده آن را ذخیره می‌کنند. Aspose.Slides می‌تواند مقدار ذخیره‌شده را از [IChartDataCell.value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/value/) هنگام بارگذاری ارائه بخواند، به شرط آنکه داده‌های نمودار مربوطه تغییر نکرده باشند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتیجه ذخیره‌شده قدیمی تکیه نکنید. پیش از خواندن مقادیر محاسبه‌شده یا ذخیره داده‌های نمودار که به آن‌ها وابسته هستند، متد [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) را فراخوانی کنید.

برای فرمول‌های خارج از زیرمجموعه پشتیبانی‌شده، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار تغییر یافته باشد، مقدار ذخیره‌شده قبلی دیگر قابل اعتماد نیست. در این وضعیت، خواندن مقدار یک سلول با داده‌های پشتیبانی‌نشده می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را باعث شود.

اگر نمودار شما به توابع Excel وابسته باشد که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گشت که آن‌ها را پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. فرمول‌های پشتیبانی‌نشده را با مقادیر حدسی جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل متفاوت وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجه‌ای خطای صفحه‌گشت مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, یا `#VALUE!` تولید کند. در این حالت، توکن خطا یک نتیجه سلول است و می‌تواند از طریق `value` بازگردانده شود.

یک فرمول ممکن است در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای‌های مخصوص صفحه‌گشت ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

هنگامی که فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، این استثنائات را در هنگام بازمحاسبه و دسترسی به مقدار مدیریت کنید:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول‌ها در کاربرگ‌های نمودار برای زیرمجموعه‌ای تعریف‌شده از محاسبات صفحه‌گشت طراحی شده است، نه برای سازگاری کامل با Excel. هنگام طراحی یک جریان کاری گزارش‌دهی این محدودیت‌ها را در نظر بگیرید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده که نیاز دارید Aspose.Slides آنها را دوباره محاسبه کند استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر ذخیره‌شده از ارائه‌های بارگذاری‌شده را به‌عنوان عکس‌العمل‌های لحظه‌ای در نظر بگیرید، نه به‌عنوان جایگزین بازمحاسبه پس از ویرایش‌ها.
- قبل از اتکای به مقادیر محاسبه‌شده، فرمول‌های موجود در قالب‌های قبلی را تست کنید، به‌ویژه اگر از توابعی خارج از فهرست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل صفحه‌گشت نیاز دارند، آنها را به‌صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر حاصل بروز کنید.

## **پرسش‌های متداول**

**فرق بین `formula` و `r1c1_formula` چیست؟**

[formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/formula/) یک عبارت سبک A1 مانند `B2-C2` را ذخیره می‌کند. [r1c1_formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` را ذخیره می‌کند. از نشانه‌گذاری‌ای استفاده کنید که بهترین تطابق را با نحوه تولید یا کپی فرمول‌ها داشته باشد.

**آیا پس از محاسبه باید خود سلول یا فقط مقدار آن را بخوانم؟**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) یک `IChartDataCell` برمی‌گرداند. برای به‌دست‌آوردن نتیجه محاسبه‌شده، پس از بازمحاسبه ویژگی [value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/value/) آن سلول را بخوانید.

**چه زمانی باید `calculate_formulas` را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و قبل از اینکه به نتایج محاسبه‌شده وابسته باشید، متد [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) را فراخوانی کنید. این مقادیر فرمول‌هایی که ارزیاب داخلی پشتیبانی می‌کند را به‌روز می‌کند.

**آیا Aspose.Slides هر تابع Excel را پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی تنها زیرمجموعه‌ای مستند شده از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید فرض شود که به‌درستی دوباره محاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گشت مناسب انجام داده و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده شامل فرمول پشتیبانی‌نشده باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشد، ممکن است کتاب‌کار هنوز مقدار ذخیره‌شده قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار ذخیره‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثنای‌های Python هستند؟**

خیر. نتیجه‌ای مانند `#DIV/0!` یک مقدار صفحه‌گشت است که توسط یک محاسبه معتبر تولید شده است. استثنائاتی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) نشان می‌دهند که فرمول به‌طور عادی قابل پردازش نیست.

**آیا تغییر یک سلول فرمولی باعث به‌روزرسانی خودکار نمودار می‌شود؟**

یک سری نموداری می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط داده نمودار به سلول‌های محاسبه‌شده ارجاع دهند، نمودار از مقادیر به‌روز شده آن سلول‌ها استفاده می‌کند؛ نیازی به فراخوانی جداگانه برای به‌روزرسانی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند به‌صورت پیکربندی‌شده از یک کتاب‌کار خارجی استفاده کنند. با این حال، جریان کاری محاسبه فرمول که در این مقاله توضیح داده شده مربوط به کتاب‌کار داده‌های نمودار و زیرمجموعه فرمولی است که Aspose.Slides ارزیابی می‌کند. فرض نکنید که [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) بازمحاسبه کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم فرمول‌هایی بنویسم که به کاربرگ یا کتاب‌کار دیگری ارجاع دهند؟**

مراجع به سبک Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول توسط تجزیه‌گر و مجموعه توابع پشتیبانی‌شده محدود است. اگر یک ارجاع بین‌برگه‌ای یا خارجی ضروری است، دقیقاً با نسخه Aspose.Slides هدف خود این فرمول را تأیید کنید. برای جریان‌های کاری که به سازگاری گسترده ارجاع‌های Excel نیاز دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون `=` اولیه اختصاص می‌دهند. استفاده از این قالب باعث می‌شود فرمول‌های تولید‌شده با نمونه‌های مستند API هم‌خوانی داشته باشند.