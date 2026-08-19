---
title: اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها با پایتون
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/python-net/chart-worksheet-formulas/
keywords:
- صفحه‌گسترده نمودار
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گسترده
- کتاب‌کار داده‌های نمودار
- محاسبه فرمول
- ثابت منطقی
- ثابت عددی
- ثابت رشته‌ای
- ثابت خطا
- عامل حسابی
- عامل مقایسه‌ای
- سبک A1
- سبک R1C1
- تابع پیش‌تعریف‌شده
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "اعمال فرمول‌های شبیه Excel در Aspose.Slides برای پایتون از طریق کتاب‌کارهای نموداری .NET، محاسبه مجدد مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **بررسی کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ توکار ذخیره می‌کنند. در Aspose.Slides برای Python از طریق .NET، می‌توانید به آن کاربرگ از طریق کتاب‌کار داده‌های نمودار دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به‌عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کاری کامل فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، محاسبه مجدد آنها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار، و ذخیرهٔ ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعهٔ توابع داخلی، مقادیر کش‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای خاص صفحه‌گسترده را شرح می‌دهد.

## **کاربرگ‌های نمودار و فرمول‌ها**

یک کاربرگ نمودار شامل دسته‌ها، نام‌های سری و مقادیری است که توسط یک نمودار استفاده می‌شود. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، کاربرگ را بررسی کنید:

![نمودار PowerPoint با کاربرگ توکار باز، نشان‌دهنده داده‌های دسته و سری](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق [کتاب‌کار داده‌های نمودار](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از خصوصیت [formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/formula/) و برای فرمول‌های سبک R1C1 از خصوصیت [r1c1_formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای محاسبهٔ مجدد فرمول‌های پشتیبانی‌شده و بروزرسانی مقادیر سلول‌های مربوطه، متد [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) را فراخوانی کنید.

یک سلول محاسبه‌شده هنوز نتیجهٔ خود را از طریق خصوصیت [value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/value/) در دسترس می‌گذارد. این موضوع زمانی مهم است که نیاز به بررسی نتیجهٔ فرمول در کد داشته باشید یا سلول را به‌عنوان نقطهٔ دادهٔ نمودار استفاده کنید.

## **ایجاد نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک جریان کاری انتها به انتها را نشان می‌دهد. یک نمودار ستونی خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینهٔ فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به‌عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

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

نقطه‌های دادهٔ نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری هیچ فراخوانی جداگانه‌ای برای تازه‌سازی نمودار وجود ندارد: ابتدا کتاب‌کار را محاسبه کنید، سپس داده‌های نمودار را استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نویسهٔ A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [IChartDataCell.formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/formula/) اختصاص دهید.

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

    value = cell.value  # 19
```

اشکال مرجع رایج A1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مرجع‌های نسبی وقتی فرمول جابه‌جا یا کپی شود می‌توانند تغییر کنند. مرجع‌های مطلق هر دو مختصات را ثابت می‌گذارند، در حالی که مرجع‌های مختلط فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نویسهٔ R1C1 هر دو ردیف و ستون را به‌صورت عددی شناسایی می‌کند. مراجع نسبی از افست‌ها در براکت‌های مربعی استفاده می‌کنند. این نحو را از طریق [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) اختصاص دهید.

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

اشکال مرجع رایج R1C1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به‌عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان ردیف دو ستون به‌سمت چپ (`B2`) اشاره دارد.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، مقادیر عددی، رشته‌ها، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقادیر ثابت**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توان مستقیم در عبارات منطقی مانند `A2=TRUE` استفاده کرد. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نشانه‌گذاری معمولی و علمی پشتیبانی می‌شوند. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی داخل فرمول درون علامت‌های دابل کوتیشن قرار می‌گیرند. |
| نتیجهٔ خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به‌جای نتیجهٔ عادی، مقدار خطای صفحه‌گسترده برگرداند. |

این مثال چند نوع ثابت را استفاده می‌کند:

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
| `+` | جمع یا مثبت موحد | `2+3` |
| `-` | تفریق یا منفی موحد | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای صریح کردن ترتیب ارزیابی از پرانتز استفاده کنید، برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | مساوی | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگتر | `A2>3` |
| `>=` | بزرگتر یا برابر | `A2>=3` |
| `<` | کوچکتر | `A2<3` |
| `<=` | کوچکتر یا برابر | `A2<=3` |

## **توابع پیش‌ تعریف‌شدهٔ پشتیبانی‌شده**

Aspose.Slides شامل یک ارزیاب فرمول داخلی برای کاربرگ‌های نمودار است، اما این یک موتور محاسبهٔ کامل Excel نیست. مجموعهٔ توابع مستند شده به توابع زیر محدود است. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) محاسبه شود.

| تابع | هدف یا شکل پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس شاخص | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | پیوند مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | پیوند مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | تعداد روزهای بین دو تاریخ | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی در داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی براساس بایت | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | مقدار بیشینه | `MAX(B2:B5)` |
| `SUM` | مجموع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده شده در جدول مهم هستند: `INDEX` به صورت مرجع مستند شده، در حالی که `LOOKUP` و `MATCH` به فرم‌های برداری مستند شده‌اند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند باید به‌عنوان غیرقابل پشتیبانی توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند، مگر اینکه به‌صورت جداگانه مستند شوند.

## **محاسبهٔ مجدد و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. Aspose.Slides می‌تواند مقدار کش‌شده را از [IChartDataCell.value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/value/) هنگام بارگذاری ارائه و عدم تغییر داده‌های نمودار مربوطه بخواند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتایج کش‌شدهٔ قدیمی تکیه نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیرهٔ داده‌های نموداری که به آن‌ها وابسته‌اند، متد [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعهٔ پشتیبانی‌شده هستند، Aspose.Slides ممکن است نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار اصلاح شده باشد، مقدار کش‌شدهٔ قبلی دیگر قابل اعتماد نخواهد بود. در این وضعیت، خواندن مقدار سلولی که دادهٔ پشتیبانی‌نشده دارد می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را تولید کند.

اگر نمودار شما به توابع Excel وابسته است که Aspose.Slides محاسبه نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده که آنها را پشتیبانی می‌کند محاسبه و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. فرمول‌های پشتیبانی‌نشده را با مقادیر تخمین‌زده جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل متفاوت وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجهٔ خطای صفحه‌گسترده مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت توکن خطا یک نتیجهٔ سلول است و می‌تواند از طریق `value` برگردانده شود.

یک فرمول می‌تواند در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای خاص صفحه‌گسترده ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

وقتی فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، این استثناها را در اطراف محاسبهٔ مجدد و دسترسی به مقدار مدیریت کنید:

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

پشتیبانی از فرمول در کاربرگ‌های نمودار برای زیرمجموعه‌ای تعریف‌شده از محاسبات صفحه‌گسترده هدف‌گذاری شده است و نه برای سازگاری کامل با Excel. هنگام طراحی یک جریان کاری گزارش‌گیری این محدودیت‌ها را در نظر بگیرید:

- فقط ثابت‌ها، عملگرها، مراجع و توابع مستند شده‌ای را که نیاز به محاسبهٔ مجدد توسط Aspose.Slides دارند، استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، محاسبهٔ مجدد انجام دهید.
- مقادیر کش‌شدهٔ ارائه‌های بارگذاری شده را به‌عنوان تصویر لحظه‌ای در نظر بگیرید، نه به‌عنوان جایگزین برای محاسبهٔ مجدد پس از ویرایش.
- فرمول‌های قالب‌های موجود را قبل از اتکای بر مقادیر محاسبه‌شده آزمایش کنید، به‌ویژه اگر از توابع خارج از فهرست مستند استفاده می‌کنند.
- برای فرمول‌هایی که نیاز به یک موتور کامل محاسبهٔ صفحه‌گسترده دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر حاصل به‌روزرسانی کنید.

## **پرسش‌های متداول**

**فرق بین `formula` و `r1c1_formula` چیست؟**

[formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/formula/) یک عبارت سبک A1 مانند `B2-C2` را ذخیره می‌کند. [r1c1_formula](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` را ذخیره می‌کند. نوشتاری را انتخاب کنید که بهتر با روش تولید یا کپی فرمول‌های شما منطبق باشد.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) یک `IChartDataCell` برمی‌گرداند. برای دریافت نتیجهٔ محاسبه‌شده، پس از محاسبهٔ مجدد، خصوصیت [value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/ichartdatacell/value/) آن سلول را بخوانید.

**چه زمانی باید `calculate_formulas` را صدا بزنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و پیش از تکیه بر نتایج محاسبه‌شده، متد [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) را فراخوانی کنید. این کار مقادیر فرمول‌های پشتیبانی‌شده توسط ارزیاب داخلی را به‌روزرسانی می‌کند.

**آیا Aspose.Slides هر تابع Excel را پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط زیرمجموعهٔ مستند شده‌ای از توابع را پشتیبانی می‌کند. توابع خارج از این زیرمجموعه نباید فرض شود که به‌درستی محاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام دهید و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائهٔ بارگذاری‌شده شامل فرمول غیرقابلیت پشتیبانی داشته باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشند، ممکن است کتاب‌کار هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن نمی‌تواند پردازش شود می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثنای‌های Python هستند؟**

خیر. مقادیری مانند `#DIV/0!` یک مقدار صفحه‌گسترده هستند که توسط یک محاسبهٔ معتبر تولید می‌شوند. استثنایی مثل [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) نشان می‌دهد که فرمول نمی‌تواند به‌طور معمول پردازش شود.

**آیا نمودار به‌صورت خودکار وقتی سلول فرمول تغییر کند به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را محاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده ارجاع دهند، نمودار از مقادیر به‌روز شدهٔ این سلول‌ها استفاده می‌کند؛ نیازی به متد جداگانه‌ای برای تازه‌سازی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار به یک کتاب‌کار خارجی تنظیم شوند. اما جریان کاری محاسبهٔ فرمول توضیح‌داده‌شده در این مقاله مربوط به کتاب‌کار داده‌های نمودار و زیرمجموعهٔ فرمول‌های ارزیابی‌شده توسط Aspose.Slides است. فرض نکنید که [calculate_formulas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) محاسبهٔ کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به کاربرگ یا کتاب‌کار دیگری ارجاع می‌دهند؟**

مراجع سبک Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیاب فرمول توسط پارسر و مجموعه توابع پشتیبانی‌شده محدود است. اگر مرجع بین‌برگه‌ای یا خارجی ضروری باشد، دقیقاً آن فرمول را با نسخهٔ هدف Aspose.Slides خود اعتبارسنجی کنید. برای جریان‌های کاری که نیاز به سازگاری گستردهٔ مرجع‌های Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را دوباره به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون `=` اولیه اختصاص می‌دهند. استفاده از این فرم فرمول‌ها را با نمونه‌های مستند API هماهنگ نگه می‌دارد.