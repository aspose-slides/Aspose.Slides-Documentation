---
title: اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها در Python از طریق Java
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/python-java/chart-worksheet-formulas/
keywords:
- صفحه‌گسترده نمودار
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گسترده
- کتاب‌کار داده‌های نمودار
- محاسبه فرمول
- فرهنگ ترجیحی
- فرمول مخصوص به فرهنگ
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
- Java
- Aspose.Slides
description: "فرمول‌های شبیه Excel را در کاربرگ‌های نمودار Aspose.Slides برای Python از طریق Java اعمال کنید، مقادیر را دوباره محاسبه کنید و نتایج را در نمودارهای PowerPoint به کار ببرید."
---
## **بررسی کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ توکار ذخیره می‌کنند. در Aspose.Slides برای Python via Java می‌توانید از طریق کتاب‌کار داده‌های نمودار به آن کاربرگ دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کار کامل فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پرکردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار، و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر کش‌شده، فرمول‌های غیرپشتیبانی‌شده، و خطاهای مخصوص به صفحه‌گسترده را توصیف می‌کند.

## **کاربرگ‌های نمودار و فرمول‌ها**

کاربرگ یک نمودار شامل دسته‌ها، نام‌های سری‌ها و مقادیری است که توسط نمودار استفاده می‌شود. در PowerPoint می‌توانید کاربرگ را با باز کردن ویرایشگر داده‌های نمودار بررسی کنید:

![نمودار پاورپوینت با کاربرگ جاسازی‌شده باز، نشان‌دهنده داده‌های دسته‌بندی و سری‌ها](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق کلاس [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setFormula) و برای فرمول‌های سبک R1C1 از [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setR1C1Formula) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#getValue) در دسترس می‌گذارد. این موضوع هنگام نیاز به بررسی نتیجه یک فرمول در کد یا استفاده از سلول به عنوان نقطه داده‌ی نمودار مهم است.

## **ایجاد یک نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک جریان کار انتها به انتها را نشان می‌دهد. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نقاط داده‌ی نمودار به `D2:D4` ارجاع می‌دهند، لذا نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری فراخوانی جداگانه‌ای برای تازه‌سازی نمودار وجود ندارد: ابتدا کتاب‌کار را بازمحاسبه کنید، سپس از داده‌های نمودار که به سلول‌های محاسبه‌شده اشاره می‌کند استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نمادگذاری A1 ستون‌ها را با حروف و سطرها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setFormula) اختصاص دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

فرم‌های مرجع متداول A1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| سطر | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| دامنه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مراجع نسبی می‌توانند هنگام جابه‌جایی یا کپی فرمول توسط یک برنامه صفحه‌گسترده تغییر کنند. مراجع مطلق همزمانی هر دو مختصه را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی فقط سطر یا ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نمادگذاری R1C1 سطرها و ستون‌ها را به‌صورت عددی شناسایی می‌کند. مراجع نسبی از جابجایی‌ها در براکت‌های مربعی استفاده می‌کنند. این نحو را از طریق [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setR1C1Formula) اختصاص دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

فرم‌های مرجع متداول R1C1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| سطر | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| دامنه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به‌عنوان مثال، در سلول `D2`، `RC[-2]` به سلولی در همان سطر دو ستون به سمت چپ (`B2`) اشاره دارد.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، مقدارهای عددی، رشته‌ها، مقادیر خطای صفحه‌گسترده، عملگرهای ریاضی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقدارهای لغت‌نامه‌ای**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توانند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شوند. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | notationهای معمول و علمی پشتیبانی می‌شوند. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقدارهای متنی داخل فرمول با علامت‌های نقل قول دوگانه محصور می‌شوند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای نتیجه عادی، به یک مقدار خطای صفحه‌گسترده ارزیابی شود. |

این مثال چندین نوع ثابت را به کار می‌برد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # غلط
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **عملگرهای ریاضی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا مثبت یک‌بار | `2+3` |
| `-` | تفریق یا منفی یک‌بار | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای صریح کردن ترتیب ارزیابی از پرانتزها استفاده کنید، برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | برابر | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگ‌تر | `A2>3` |
| `>=` | بزرگ‌تر یا مساوی | `A2>=3` |
| `<` | کوچک‌تر | `A2<3` |
| `<=` | کوچک‌تر یا مساوی | `A2<=3` |

## **توابع پیش‌تعریف‌شده پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای کاربرگ‌های نمودار شامل می‌شود، اما این یک موتور محاسبه کامل Excel نیست. مجموعه توابع مستند شده به توابع زیر محدود است. فرض نکنید هر تابع دلخواه Excel می‌تواند توسط [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) بازمحاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار براساس شاخص | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ترکیب مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | ترکیب مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخی با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | بازگرداندن تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی در مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی بایت‌محور | `FINDB("a",A2)` |
| `IF` | نتیجه شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه | `MAX(B2:B5)` |
| `SUM` | جمع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده‌شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده است، در حالی که `LOOKUP` و `MATCH` به صورت فرم‌های برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند، باید به‌عنوان غیرپشتیبانی‌شده توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند، مگر اینکه به‌طور جداگانه مستند شوند.

## **محاسبه فرمول‌ها با فرهنگ ترجیحی**

برخی توابع کتاب‌کار نمودار متن را بر اساس قوانین خاص فرهنگ تفسیر می‌کنند. این موضوع به‌ویژه برای توابعی که برای زبان‌های استفاده‌کننده از مجموعه کاراکترهای دوبایت (DBCS) طراحی شده‌اند مهم است. برای محاسبه صحیح چنین فرمول‌هایی، یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) ایجاد کنید، فرهنگ ترجیحی را با [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) تنظیم کنید، گزینه‌های صفحه‌گسترده را از طریق [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) اختصاص دهید و سپس ارائه را بارگذاری کنید.

مثال زیر فرهنگ ژاپنی را انتخاب می‌کند، یک ارائه را با گزینه‌های بارگذاری پیکربندی‌شده باز می‌کند و برای هر کتاب‌کار نمودار متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

فرهنگ ترجیحی بخشی از پیکربندی بارگذاری ارائه است، بنابراین قبل از ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) آن را مشخص کنید. از فرهنگی استفاده کنید که فرمول‌های کتاب‌کار انتظار دارد؛ به‌عنوان مثال برای فرمول‌هایی که باید قوانین محاسبه DBCS ژاپنی را دنبال کنند، `ja-JP` را به کار ببرید.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شده را ذخیره می‌کنند. Aspose.Slides می‌تواند به‌همین دلیل مقدار کش‌شده را از [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#getValue) بخواند وقتی یک ارائه بارگذاری می‌شود و داده‌های نمودار مربوطه تغییر نکرده‌اند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتایج کش‌شده قدیمی تکیه نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیره داده‌های نموداری که به آن‌ها وابسته‌اند، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعه پشتیبانی‌شده هستند، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار تغییر کرده باشد، مقدار کش‌شده قبلی دیگر قابل اعتماد نیست. در چنین وضعیتی، خواندن مقدار یک سلول با داده‌های غیرپشتیبانی‌شده می‌تواند [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellunsupporteddataexception/) را پرتاب کند.

اگر نمودار شما به توابع Excel متکی است که Aspose.Slides ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده که از آن‌ها پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. فرمول‌های غیرپشتیبانی‌شده را با مقادیر حدس‌زدنی جایگزین نکنید.

## **کنترل خطاهای فرمول**

دو نوع متفاوت از مشکلات وجود دارد که باید متمایز شوند.

یک فرمول می‌تواند معتبر باشد اما نتیجه‌ای به‌صورت خطای صفحه‌گسترده مثل `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, یا `#VALUE!` تولید کند. در این حالت، توکن خطا نتیجهٔ یک سلول است و می‌تواند از طریق [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#getValue) بازگردانده شود.

یک فرمول می‌تواند در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنائات مخصوص صفحه‌گسترده فراهم می‌کند: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellunsupporteddataexception/).

زمانی که فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، این استثنائات را هنگام بازمحاسبه و دسترسی به مقدار مدیریت کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول‌ها در کاربرگ‌های نمودار برای یک زیرمجموعه تعریف‌شده از محاسبات صفحه‌گسترده است، نه برای سازگاری کامل با Excel. این محدودیت‌ها را هنگام طراحی یک جریان کاری گزارش‌گیری در نظر بگیرید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده استفاده کنید هنگامی که نیاز دارید Aspose.Slides فرمول‌ها را بازمحاسبه کند.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شده از ارائه‌های بارگذاری‌شده را به‌عنوان لحظات زمانی در نظر بگیرید، نه به‌عنوان جایگزینی برای بازمحاسبه پس از ویرایش.
- فرمول‌های موجود در قالب‌های فعلی را پیش از وابستگی به مقادیر محاسبه‌شده آزمایش کنید، به‌ویژه اگر از توابع خارج از فهرست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل صفحه‌گسترده احتیاج دارند، آن‌ها را به‌صورت جداگانه محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر به‌دست‌آمده به‌روز کنید.

## **پرسش‌های متداول**

**تفاوت بین [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setFormula) و [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setR1C1Formula) چیست؟**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setFormula) یک عبارت سبک A1 نظیر `B2-C2` را ذخیره می‌کند. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#setR1C1Formula) یک عبارت سبک R1C1 نظیر `RC[-2]-RC[-1]` را ذخیره می‌کند. از نمادگذاری‌ای استفاده کنید که بهتر با نحوهٔ تولید یا کپی فرمول‌های شما منطبق باشد.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#getCell) یک شیء [ChartDataCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/) را برمی‌گرداند. برای به‌دست‌آوردن نتیجهٔ محاسبه‌شده، پس از بازمحاسبه متد [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatacell/#getValue) آن سلول را فراخوانی کنید.

**چه زمانی باید [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و پیش از وابستگی به نتایج محاسبه‌شده، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید. این کار مقادیر فرمول‌های پشتیبانی‌شده توسط ارزیاب داخلی را به‌روز می‌سازد.

**آیا Aspose.Slides از تمام توابع Excel پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی تنها یک زیرمجموعهٔ مستند شده از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید فرض شود به‌درستی بازمحاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام دهید و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده حاوی فرمولی غیرپشتیبانی‌شده باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشند، کتاب‌کار ممکن است هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است معتبر نباشد. دسترسی به سلولی که فرمولش قابل پردازش نیست می‌تواند [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellunsupporteddataexception/) را پرتاب کند.

**آیا مقادیر خطای فرمول همانند استثنائات هستند؟**

نه. نتیجه‌ای مانند `#DIV/0!` یک مقدار صفحه‌گسترده است که توسط یک محاسبهٔ معتبر تولید شده. استثنائاتی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellcircularreferenceexception/) نشان می‌دهند که فرمول به‌صورت معمولی نمی‌تواند پردازش شود.

**آیا یک نمودار به‌صورت خودکار هنگام تغییر سلول فرمول به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده ارجاع می‌دهند، نمودار از این مقادیر به‌روز استفاده می‌کند؛ نیازی به فراخوانی جداگانه‌ای برای تازه‌سازی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار به یک کتاب‌کار خارجی تنظیم شوند. با این حال، جریان کاری محاسبه فرمول توصیف‌شده در این مقاله مربوط به کتاب‌کار داده‌های نمودار و زیرمجموعهٔ فرمول‌های ارزیابی‌شده توسط Aspose.Slides است. فرض نکنید که [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) بازمحاسبه کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را ارائه می‌دهد.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به کاربرگ یا کتاب‌کار دیگری ارجاع می‌دهند؟**

ممکن است مراجع سبک Excel در کتاب‌کارهای نمودار وجود داشته باشد، اما ارزیاب فرمول توسط پارسر و مجموعهٔ توابع پشتیبانی‌شده محدود می‌شود. اگر ارجاع بین‌برگه‌ای یا خارجی ضروری است، دقیقاً فرمول را با نسخهٔ هدف Aspose.Slides خود تأیید کنید. برای جریان‌های کاری که نیاز به سازگاری گستردهٔ مراجع Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات نظیر `B2-C2` یا `SUM(B2:B5)` را بدون `=` پیشوندی اختصاص می‌دهند. استفاده از این فرم فرمول‌ها را با نمونه‌های مستند API منطبق نگه می‌دارد.