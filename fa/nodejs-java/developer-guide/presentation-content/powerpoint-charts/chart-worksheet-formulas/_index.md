---
title: اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/nodejs-java/chart-worksheet-formulas/
keywords:
- صفحه‌گشت نمودار
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گشت
- کتاب کار داده‌های نمودار
- محاسبه فرمول
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
- Node.js
- JavaScript
- Aspose.Slides
description: "فرمول‌های سبک Excel را در Aspose.Slides برای Node.js از طریق کاربرگ‌های نمودار Java اعمال کنید، مقادیر را دوباره محاسبه کنید و نتایج را در نمودارهای PowerPoint استفاده کنید."
---
## **نمای کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ توکار ذخیره می‌کنند. در Aspose.Slides for Node.js via Java می‌توانید از طریق کتاب کار داده‌های نمودار به آن کاربرگ دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کاری کامل فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار، و ذخیره ارائه. همچنین سینتکس فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر کش‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای مخصوص جدول‌محور را توصیف می‌کند.

## **کاربرگ‌های نمودار و فرمول‌ها**

یک کاربرگ نمودار شامل دسته‌ها، نام‌های سری و مقادیری است که توسط یک نمودار استفاده می‌شوند. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، کاربرگ را بررسی کنید:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق کلاس [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) و برای فرمول‌های سبک R1C1 از [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روز کردن مقادیر سلول‌های مرتبط، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) در دسترس قرار می‌دهد. این موضوع زمانی مهم است که بخواهید نتیجه فرمول را در کد بررسی کنید یا سلول را به عنوان نقطه داده‌ی نمودار استفاده کنید.

## **ایجاد یک نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک جریان کاری کامل را نشان می‌دهد. یک نمودار ستونی خوشه‌ای می‌سازد، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند، و ارائه را ذخیره می‌نماید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نقاط داده‌ی نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار وجود ندارد: ابتدا کتاب کار را بازمحاسبه کنید، سپس از داده‌های نمودار که به سلول‌های محاسبه‌شده اشاره دارند استفاده کنید یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نوتیشن A1 ستون‌ها را با حروف و سطرها را با اعداد شناسایی می‌کند. از طریق [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) عبارات سبک A1 را اختصاص دهید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

فرم‌های مرجع A1 رایج عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| سطر | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مرجع‌های نسبی می‌توانند هنگام جابه‌جا یا کپی شدن فرمول توسط برنامه‌ای جدول‌محور تغییر کنند. مراجع مطلق هر دو مختصه را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی فقط یک سطر یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نوتیشن R1C1 هر دو سطر و ستون را به صورت عددی شناسایی می‌کند. مراجع نسبی از افست‌ها در براکت‌های مربعی استفاده می‌کنند. این سینتکس را از طریق [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) اختصاص دهید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

فرم‌های مرجع R1C1 رایج عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| سطر | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به‌عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان سطر دو ستون به سمت چپ (`B2`) اشاره دارد.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، مقادیر عددی، رشته‌ها، مقادیر خطای جدول‌محور، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقادیر ثابت**

| نوع | مثال‌ها | یادداشت‌ها |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توانند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شوند. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوتیشن‌های معمولی و علمی پشتیبانی می‌شوند. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی داخل فرمول در داخل علامت‌های نقل قول دوگانه قرار می‌گیرند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای نتیجه عادی، به مقدار خطای جدول‌محور ارزیابی شود. |

این مثال چند نوع ثابت مختلف را به کار می‌برد:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // نادرست
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **عملگرهای حسابی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا علامت مثبت یکنواخت | `2+3` |
| `-` | تفریق یا منفی | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

از پرانتزها برای واضح‌سازی ترتیب ارزیابی استفاده کنید، برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی باز می‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | برابری | `A2=3` |
| `<>` | نابرابری | `A2<>3` |
| `>` | بزرگتر از | `A2>3` |
| `>=` | بزرگتر یا مساوی | `A2>=3` |
| `<` | کوچکتر از | `A2<3` |
| `<=` | کوچکتر یا مساوی | `A2<=3` |

## **توابع پیش‌تعریف‌شده پشتیبانی‌شده**

Aspose.Slides شامل یک ارزیاب فرمول داخلی برای کاربرگ‌های نمودار است، اما یک موتور محاسبه کامل Excel نیست. مجموعه توابع مستند شده به توابع زیر محدود می‌شود. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) بازمحاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضربی | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس ایندکس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ترکیب مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | ترکیب مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | برگرداندن تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی در داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی مبتنی بر بایت | `FINDB("a",A2)` |
| `IF` | نتیجه شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه مقدار | `MAX(B2:B5)` |
| `SUM` | جمع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده‌شده در جدول مهم هستند: `INDEX` به صورت مرجع مستند شده، در حالی که `LOOKUP` و `MATCH` به صورت برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند باید به‌عنوان پشتیبانی‌نشده توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند، مگر این‌که به‌صورت جداگانه مستند شوند.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های جدول‌محور معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شده آن را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند مقدار کش‌شده را از [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) هنگام بارگذاری ارائه بخواند، به‌شرطی که داده‌های نمودار مرتبط تغییر نکرده باشند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتایج کش‌شده قدیمی تکیه نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیره داده‌های نموداری که به آن‌ها وابسته‌اند، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعه پشتیبانی‌شده هستند، Aspose.Slides ممکن است نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب کار اصلاح شده باشد، مقدار کش‌شده قبلی دیگر قابل اطمینان نخواهد بود. در این وضعیت، خواندن مقدار سلولی با داده‌های پشتیبانی‌نشده می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel متکی است که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با موتور جدول‌محور که از آن‌ها پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به کتاب کار نمودار بنویسید. مقادیر حدسی به‌جای فرمول‌های پشتیبانی‌نشده جایگزین نشوند.

## **دست‌زدن به خطاهای فرمول**

دو نوع مشکل متفاوت وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجه‌ای از نوع خطای جدول‌محور مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت توکن خطا یک نتیجه سلول است و می‌تواند از طریق [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) برگردانده شود.

یک فرمول ممکن است در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثناهای مخصوص جدول‌محور ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellunsupporteddataexception/).

هنگامی که فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، خطاها را در اطراف بازمحاسبه و دسترسی به مقدار بگیرید. جزئیات خطا مشکل جدولی زیرین را شناسایی می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول در کاربرگ‌های نمودار برای زیرمجموعه‌ای تعریف‌شده از محاسبات جدول‌محور هدف‌گذاری شده است و نه برای سازگاری کامل با Excel. هنگام طراحی یک جریان کاری گزارش‌دهی این محدودیت‌ها را در نظر بگیرید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده‌ای که نیاز به بازمحاسبه توسط Aspose.Slides دارند استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شده از ارائه‌های بارگذاری‌شده را به‌عنوان تصویر瞬ی، نه به‌عنوان جایگزین برای بازمحاسبه پس از ویرایش، در نظر بگیرید.
- فرمول‌های موجود در قالب‌های قبلی را پیش از اتکا به مقادیر محاسبه‌شده تست کنید، به‌ویژه زمانی که توابعی خارج از فهرست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل جدول‌محور نیاز دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کتاب کار نمودار را با مقادیر حاصل به‌روزرسانی کنید.

## **پرسش‌های متداول**

**تفاوت بین [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) و [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) چیست؟**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) یک عبارت سبک A1 مانند `B2-C2` را ذخیره می‌کند. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` را ذخیره می‌کند. از نوتیشنی استفاده کنید که بیشترین تطابق را با نحوه تولید یا کپی فرمول‌های شما داشته باشد.

**بعد از محاسبه، باید سلول را به‌صورت خود سلول یا مقدارش بخوانم؟**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) یک [ChartDataCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/) برمی‌گرداند. برای به دست آوردن نتیجه محاسبه‌شده، پس از بازمحاسبه متد [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) آن سلول را فراخوانی کنید.

**چه زمانی باید [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را صدا بزنم؟**

بعد از تغییر مقادیر ورودی یا فرمول‌ها و پیش از اینکه به نتایج محاسبه‌شده وابسته باشید، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را فراخوانی کنید. این کار مقادیر فرمول‌هایی را که ارزیاب داخلی پشتیبانی می‌کند، به‌روز می‌کند.

**آیا Aspose.Slides هر تابع Excel را پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی تنها زیرمجموعه‌ای مستند شده از توابع را پشتیبانی می‌کند. توابع خارج از این زیرمجموعه نباید فرض شود که به‌درستی بازمحاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور جدول‌محور مناسب انجام دهید و مقادیر نهایی را به کتاب کار نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده شامل فرمول پشتیبانی‌نشده باشد چه اتفاقی می‌افتد؟**

اگر داده‌های نمودار تغییر نکرده باشد، ممکن است کتاب کار هنوز مقدار کش‌شده قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمولش قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثناها هستند؟**

خیر. مقدارهایی مانند `#DIV/0!` یک مقدار جدول‌محور هستند که توسط یک محاسبه معتبر تولید می‌شوند. استثنائاتی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellcircularreferenceexception/) نشان می‌دهند که فرمول نمی‌تواند به‌صورت معمول پردازش شود.

**آیا نمودار به‌صورت خودکار هنگام تغییر سلول فرمول به‌روزرسانی می‌شود؟**

سری‌های نمودار می‌توانند به سلول‌های کتاب کار ارجاع دهند. ابتدا کتاب کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط داده‌ی نمودار به سلول‌های محاسبه‌شده ارجاع دهند، نمودار از مقادیر به‌روز شده آن سلول‌ها استفاده می‌کند؛ نیازی به فراخوانی متد جداگانه‌ای برای به‌روزرسانی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار برای استفاده از یک کتاب کار خارجی پیکربندی شوند. اما جریان کاری محاسبه فرمول‌های توصیف‌شده در این مقاله مربوط به کتاب کار داده‌های نمودار و زیرمجموعه فرمولی ارزیاب Aspose.Slides است. فرض نکنید که [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) بازمحاسبه کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به یک کاربرگ یا کتاب کار دیگر ارجاع می‌دهند؟**

مراجع به سبک Excel ممکن است در کتاب کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول‌ها توسط تجزیه‌گر و مجموعه توابع پشتیبانی‌شده محدود است. اگر یک مرجع بین‌برگه‌ای یا خارجی ضروری است، دقیقاً آن فرمول را با نسخه Aspose.Slides هدف خود اعتبارسنجی کنید. برای جریان‌های کاری که نیاز به سازگاری گسترده مرجع‌گذاری Excel دارند، کتاب کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به داده‌های نمودار بازنویسی کنید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون پیشوند `=` اختصاص می‌دهند. استفاده از این فرم فرمول‌ها را با نمونه‌های مستند API سازگار نگه می‌دارد.