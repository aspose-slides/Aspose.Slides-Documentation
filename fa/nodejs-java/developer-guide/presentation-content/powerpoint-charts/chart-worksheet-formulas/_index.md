---
title: اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/nodejs-java/chart-worksheet-formulas/
keywords:
- نمودار صفحه‌گسترده
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گسترده
- کتاب‌کار داده‌های نمودار
- محاسبه فرمول
- فرهنگ مورد ترجیح
- فرمول مبتنی بر فرهنگ
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
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اعمال فرمول‌های شبیه به Excel در Aspose.Slides برای Node.js از طریق کاربرگ‌های نمودار Java، بازمحاسبه مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **نمای کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ توکار ذخیره می‌کنند. در Aspose.Slides برای Node.js از طریق Java می‌توانید به آن کاربرگ از طریق کتاب‌کار داده‌های نمودار دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به‌عنوان داده‌های نمودار استفاده کنید.

این مقاله گردش کار کامل فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سلسله‌مراتب نمودار و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر ذخیره‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای مخصوص صفحه‌گسترده را شرح می‌دهد.

## **کاربرگ‌ها و فرمول‌های نمودار**

یک کاربرگ نمودار شامل دسته‌بندی‌ها، نام‌های سلسله‌مراتب و مقادیری است که توسط یک نمودار استفاده می‌شوند. در PowerPoint می‌توانید کاربرگ را با باز کردن ویرایشگر داده‌های نمودار بررسی کنید:

![نمودار PowerPoint با کاربرگ توکار باز، نشان‌دهنده داده‌های دسته‌بندی و سلسله‌مراتب](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق کلاس [ChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) و برای فرمول‌های سبک R1C1 از [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را صدا بزنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) در دسترس می‌گذارد. این موضوع هنگام نیاز به بررسی نتیجه فرمول در کد یا استفاده از سلول به‌عنوان نقطه داده‌ای نمودار مهم است.

## **ایجاد نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک گردش کار انتها‑به‑انتها را نشان می‌دهد. یک نمودار ستونی خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به‌عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

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

نقاط داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این گردش کار هیچ فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار وجود ندارد: ابتدا کتاب‌کار را بازمحاسبه کنید، سپس از سلول‌های محاسبه‌شده استفاده کنید یا ارائه را ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نمادگذاری A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) اختصاص دهید.

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

فرم‌های مرجع رایج A1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مرجع‌های نسبی می‌توانند هنگام جابه‌جایی یا کپی فرمول توسط برنامه صفحه‌گسترده تغییر کنند. مراجع مطلق هر دو مختصه را ثابت نگه می‌دارند، در حالی که مراجع مختلط تنها ردیف یا ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نمادگذاری R1C1 هم ردیف‌ها و هم ستون‌ها را به صورت عددی شناسایی می‌کند. مراجع نسبی از افست‌ها در داخل براکت استفاده می‌کنند. این نحو را از طریق [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) اختصاص دهید.

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

فرم‌های مرجع رایج R1C1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان ردیف دو ستون به سمت چپ (`B2`) اشاره دارد.

## **ثابت‌ها و عملگرهای فرمول**

مفسر فرمول داخلی مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقدارهای اولیه**

| نوع | مثال‌ها | توضیحات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توانند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شوند. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوشتار معمولی و علمی پشتیبانی می‌شود. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | literals متنی داخل فرمول با علامت نقل قول دوگانه احاطه می‌شوند. |
| نتیجهٔ خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای نتیجهٔ عادی، مقدار خطای صفحه‌گسترده بدهد. |

این مثال چند نوع ثابت را نشان می‌دهد:

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

| عملگر | معنای آن | مثال |
|---|---|---|
| `+` | جمع یا علامت مثبت یک‌تایی | `2+3` |
| `-` | تفریق یا منفی یک‌تایی | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای صراحت ترتیب ارزیابی، از پرانتز استفاده کنید؛ به عنوان مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنای آن | مثال |
|---|---|---|
| `=` | برابر با | `A2=3` |
| `<>` | نامساوی با | `A2<>3` |
| `>` | بزرگ‌تر از | `A2>3` |
| `>=` | بزرگ‌تر یا مساوی با | `A2>=3` |
| `<` | کوچک‌تر از | `A2<3` |
| `<=` | کوچک‌تر یا مساوی با | `A2<=3` |

## **توابع پیش‌تعریف‌شدهٔ پشتیبانی‌شده**

Aspose.Slides یک مفسر فرمول داخلی برای کاربرگ‌های نمودار دارد، اما این یک موتور محاسبه کامل Excel نیست. مجموعهٔ توابع مستند شده به توابع زیر محدود می‌شود. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) بازمحاسبه شود.

| تابع | منظور یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضربی | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس شاخص | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | پیوستن مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | پیوستن مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی در داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی بایت‌محور | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه | `MAX(B2:B5)` |
| `SUM` | جمع | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

قیدهای نشان‌داده‌شده در جدول مهم هستند: `INDEX` به‌صورت فرم مرجع مستند شده، در حالی که `LOOKUP` و `MATCH` به‌صورت فرم‌های برداری مستند شده‌اند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا لیست نشده‌اند باید به‌عنوان پشتیبانی‌نشده توسط مفسر فرمول Aspose.Slides در نظر گرفته شوند، مگر اینکه جداگانه مستند شوند.

## **محاسبه فرمول‌ها با فرهنگ دلخواه**

برخی توابع کتاب‌کار نمودار متن را بر اساس قواعد خاص فرهنگ تفسیر می‌کنند. این موضوع به‌ویژه برای توابعی که برای زبان‌هایی با مجموعه کاراکترهای دو بایتی (DBCS) طراحی شده‌اند، اهمیت دارد. برای محاسبه صحیح چنین فرمول‌هایی، یک [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) ایجاد کنید، فرهنگ دلخواه را با [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) تنظیم کنید، گزینه‌های صفحه‌گسترده را از طریق [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) اختصاص دهید و سپس ارائه را بارگذاری کنید.

مثال زیر فرهنگ ژاپنی را انتخاب می‌کند، یک ارائه را با گزینه‌های بارگذاری پیکربندی‌شده باز می‌کند و برای هر کتاب‌کار نمودار [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را فراخوانی می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

فرهنگ دلخواه بخشی از پیکربندی بارگذاری ارائه است، بنابراین قبل از ساخت نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) آن را مشخص کنید. همان فرهنگی را که فرمول‌های کتاب‌کار انتظار دارند استفاده کنید؛ برای مثال برای فرمول‌های مبتنی بر قواعد محاسبه DBCS ژاپنی از `ja-JP` استفاده کنید.

## **بازمحاسبه و مقادیر ذخیره‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند هنگام بارگذاری یک ارائه و زمانی که داده‌های نمودار مربوطه تغییر نکرده‌اند، مقدار ذخیره‌شده را از طریق [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) بخواند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتایج ذخیره‌شدهٔ قدیمی وابسته نشوید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیره کردن داده‌های نموداری که به آن‌ها وابسته‌اند، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعهٔ پشتیبانی‌شده هستند، ممکن است Aspose.Slides نتواند آن فرمول را پارس کند یا وابستگی‌هایش را تعیین کند. اگر کتاب‌کار تغییر یافته باشد، مقدار ذخیره‌شدهٔ قبلی دیگر قابل اعتماد نخواهد بود. در این وضعیت، خواندن مقدار سلولی که دادهٔ پشتیبانی‌نشده دارد می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel وابسته باشد که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده که آن‌ها را پشتیبانی می‌کند محاسبه کنید و مقادیر به‌دست‌آمده را در کتاب‌کار نمودار بنویسید. فرمول‌های پشتیبانی‌نشده را با مقادیر تخمینی جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل متفاوت وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجهٔ خطای صفحه‌گسترده‌ای مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت توکن خطا یک نتیجهٔ سلول است و می‌تواند از طریق [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) برگشت داده شود.

یک فرمول ممکن است در مرحلهٔ پارس، مرجع، وابستگی یا سطح داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای‌های مخصوص صفحه‌گسترده ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellinvalidformulaexception/)، [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellinvalidreferenceexception/)، [CellCircularReferenceException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellcircularreferenceexception/) و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellunsupporteddataexception/).

هنگامی که فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، خطاها را دور بازمحاسبه و دسترسی به مقدار بپیچید. جزئیات خطا مشکل اصلی صفحه‌گسترده را شناسایی می‌کند:

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

پشتیبانی از فرمول در کاربرگ‌های نمودار برای یک زیرمجموعهٔ تعریف‌شده از محاسبات صفحه‌گسترده است، نه برای سازگاری کامل با Excel. این محدودیت‌ها را هنگام طراحی یک گردش کار گزارش‌گیری در ذهن داشته باشید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده که نیاز به بازمحاسبه توسط Aspose.Slides دارند استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول‌ها به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر ذخیره‌شدهٔ ارائه‌های بارگذاری‌شده را به‌عنوان «عکس‌اللحظه» در نظر بگیرید، نه به‌عنوان جایگزینی برای بازمحاسبه پس از ویرایش.
- فرمول‌های قالب‌های موجود را پیش از اتکا به مقادیر محاسبه‌شده تست کنید، به‌ویژه زمانی که از توابع خارج از فهرست مستند استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل صفحه‌گسترده نیاز دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر حاصل به‌روز کنید.

## **سوالات متداول**

**تفاوت بین [ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) و [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) چیست؟**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) یک عبارت سبک A1 مانند `B2-C2` را ذخیره می‌کند. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` را ذخیره می‌کند. از نمادگذاری‌ای استفاده کنید که بهترین سازگاری را با نحوهٔ تولید یا کپی فرمول‌ها داشته باشد.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) یک [ChartDataCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/) برمی‌گرداند. برای دریافت نتیجهٔ محاسبه‌شده، پس از بازمحاسبه متد [ChartDataCell.getValue](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#getValue--) آن سلول را صدا بزنید.

**چه زمانی باید [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و قبل از اینکه به نتایج محاسبه‌شده وابسته باشید، متد [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) را صدا بزنید. این کار مقادیری که مفسر داخلی پشتیبانی می‌کند به‌روز می‌کند.

**آیا Aspose.Slides از تمام توابع Excel پشتیبانی می‌کند؟**

خیر. مفسر داخلی فقط یک زیرمجموعهٔ مستند شده از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید فرض شود که به‌درستی بازمحاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام دهید و مقادیر نهایی را در کتاب‌کار نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده شامل فرمول پشتیبانی‌نشده باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشد، ممکن است کتاب‌کار هنوز مقدار ذخیره‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار ذخیره‌شده ممکن است معتبر نباشد. دسترسی به سلولی که فرمول آن توسط Aspose.Slides قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثناها هستند؟**

خیر. نتیجه‌ای مانند `#DIV/0!` یک مقدار صفحه‌گسترده است که توسط یک محاسبهٔ معتبر تولید می‌شود. استثناهایی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cellcircularreferenceexception/) نشان می‌دهند که فرمول نمی‌تواند به‌صورت معمولی پردازش شود.

**آیا هنگام تغییر سلول فرمول‌دار، نمودار به‌صورت خودکار به‌روزرسانی می‌شود؟**

سلسله‌مراتب یک نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده ارجاع دهند، نمودار از مقادیر به‌روز شدهٔ آن سلول‌ها استفاده می‌کند؛ نیازی به فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار در این گردش کار نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار برای استفاده از یک کتاب‌کار خارجی پیکربندی شوند. با این حال، گردش کار محاسبهٔ فرمول که در این مقاله توضیح داده شده به کتاب‌کار داده‌های نمودار و زیرمجموعهٔ فرمول‌های ارزیابی‌شده توسط Aspose.Slides مربوط می‌شود. فرض نکنید که [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) بازمحاسبه کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به کاربرگ یا کتاب‌کار دیگری ارجاع می‌دهند؟**

ارجاعات سبک Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول‌ها توسط پارسر و مجموعهٔ توابع پشتیبانی‌شده محدود است. اگر یک ارجاع بین‌ورق یا خارجی ضروری است، دقیقاً آن فرمول را با نسخهٔ هدف Aspose.Slides خود تأیید کنید. برای گردش‌کارهایی که نیاز به سازگاری گستردهٔ ارجاع‌های Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های کد API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون `=` پیشوندی اختصاص می‌دهند. استفاده از این فرم باعث می‌شود فرمول‌های تولیدشده با نمونه‌های مستند API هماهنگ بمانند.