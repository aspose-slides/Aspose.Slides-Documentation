---
title: اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها در Java
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/java/chart-worksheet-formulas/
keywords:
- صفحه‌گسترده نمودار
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گسترده
- کتابچه کاری داده‌های نمودار
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
- Java
- Aspose.Slides
description: "به کارگیری فرمول‌های سبک Excel در کاربرگ‌های نمودار Aspose.Slides برای Java، بازمحاسبه مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **بررسی کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ جاسازی‌شده ذخیره می‌کنند. در Aspose.Slides برای Java می‌توانید از طریق کتابچه کاری داده‌های نمودار به آن کاربرگ دسترسی پیدا کنید، مقادیر ورودی بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به‌عنوان داده‌های نمودار استفاده کنید.

این مقاله روند کامل فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پرکردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع توکار، مقادیر کش‌شده، فرمول‌های نام پشتیبانی‌شده و خطاهای خاص صفحات گسترده را شرح می‌دهد.

## **کاربرگ‌ها و فرمول‌های نمودار**

یک کاربرگ نمودار شامل دسته‌بندی‌ها، نام سری‌ها و مقادیری است که توسط یک نمودار استفاده می‌شوند. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، کاربرگ را بررسی کنید:

![نمودار PowerPoint با کاربرگ جاسازی‌شده باز، نشان‌دهنده داده‌های دسته‌بندی و سری](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق رابط [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و برای فرمول‌های سبک R1C1 از [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های متناظر، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

یک سلول محاسبه‌شده هنوز نتیجه خود را از طریق [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) نشان می‌دهد. این موضوع زمانی مهم است که نیاز به بازرسی نتیجه فرمول در کد یا استفاده از سلول به‌عنوان نقطه داده نمودار دارید.

## **ایجاد نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک روند انتها‑به‑انتها را نمایش می‌دهد. این مثال یک نمودار ستونی خوشه‌ای می‌سازد، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به‌عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نقاط داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این روند هیچ فراخوانی جداگانه‌ای برای تازه‑سازی نمودار وجود ندارد: ابتدا کتابچه کاری را بازمحاسبه کنید، سپس داده‌های نمودار را که به سلول‌های محاسبه‌شده اشاره دارند، استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نویسه A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) اختصاص دهید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

اشکال مرجع معمول A1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مرجع‌های نسبی می‌توانند هنگام جابه‌جایی یا کپی یک فرمول توسط برنامهٔ صفحه‌گسترده تغییر کنند. مراجع مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نویسه R1C1 هر دو ردیف و ستون را به‌صورت عددی شناسایی می‌کند. مراجع نسبی از افست‌ها در براکت‌های مربعی استفاده می‌کنند. این نحو را از طریق [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) اختصاص دهید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

اشکال مرجع معمول R1C1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به‌عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان ردیف دو ستون به سمت چپ (`B2`) اشاره می‌کند.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول توکار مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقدارهای لغوی**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌تواند به‌صورت مستقیم در عبارات منطقی مانند `A2=TRUE` استفاده شود. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوشتار عادی و علمی پشتیبانی می‌شود. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی داخل علامت‌های نقل قول دوگانه در فرمول قرار می‌گیرند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به‌جای نتیجه عادی، مقدار خطای صفحه‌گسترده برگرداند. |

این مثال چند نوع ثابت را به‌کار می‌برد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **عملگرهای حسابی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا علامت مثبت یگانه | `2+3` |
| `-` | تفریق یا منفی یگانه | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای واضح‌سازی ترتیب ارزیابی از پرانتز استفاده کنید، به‌عنوان مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | مساوی | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگتر | `A2>3` |
| `>=` | بزرگتر یا مساوی | `A2>=3` |
| `<` | کوچکتر | `A2<3` |
| `<=` | کوچکتر یا مساوی | `A2<=3` |

## **توابع پیش‌تعریف‌شده پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول توکار برای کاربرگ‌های نمودار دارد، اما یک موتور کامل محاسبهٔ Excel نیست. مجموعهٔ مستند شده توابع به موارد زیر محدود می‌شود. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بازمحاسبه شود.

| تابع | هدف یا شکل پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به بالا به‌سوی مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس اندیس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | الحاق مقادیر متن | `CONCAT(A2,B2)` |
| `CONCATENATE` | الحاق مقادیر متن | `CONCATENATE(A2," ",B2)` |
| `DATE` | ساخت مقدار تاریخ با سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | برگرداندن تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی بایت‑محور متن | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | شکل مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | شکل برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | شکل برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | حداکثر مقدار | `MAX(B2:B5)` |
| `SUM` | جمع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده‌شده در جدول مهم هستند: `INDEX` به‌صورت مرجع مستند شده، در حالی که `LOOKUP` و `MATCH` در قالب‌های برداری مستند می‌شوند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. توابعی که در اینجا فهرست نشده‌اند باید به‌عنوان نامورد پشتیبانی توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند مگر اینکه جداگانه مستند شوند.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند مقدار کش‌شده را از [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) هنگام بارگذاری یک ارائه بخواند، به‌شرط آنکه دادهٔ نمودار مربوطه تغییر نکرده باشد.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به‌نتیجهٔ کش‌شدهٔ قدیمی وابسته نباشید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیرهٔ داده‌های نمودار که به آنها وابسته‌اند، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعه پشتیبانی‌شده هستند، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتابچه کاری تغییر کرده باشد، مقدار کش‌شدهٔ قبلی دیگر قابل اطمینان نیست. در این حالت، خواندن مقدار سلولی با دادهٔ نامورد می‌تواند [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel وابسته باشد که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، این فرمول‌ها را با یک موتور صفحه‌گستردهٔ پشتیبانی‌کننده محاسبه کنید و مقادیر به‌دست‌آمده را دوباره در کتابچه کاری نمودار بنویسید. از جایگزین کردن فرمول‌های نامورد با مقادیر تخمینی خودداری کنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل متفاوت باید متمایز شوند.

یک فرمول می‌تواند معتبر باشد ولی نتیجهٔ خطای صفحه‌گسترده مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت توکن خطا یک نتیجهٔ سلول است و می‌تواند از طریق [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) بازگردانده شود.

یک فرمول ممکن است در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثناهای خاص صفحه‌گسترده ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellunsupporteddataexception/).

هنگامی که فرمول‌ها از قالب‌های آماده یا ورودی کاربر می‌آیند، این استثناها را در اطراف بازمحاسبه و دسترسی به مقدار مدیریت کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول در کاربرگ‌های نمودار برای یک زیرمجموعهٔ تعریف‌شده از محاسبات صفحه‌گسترده هدف‌گذاری شده است و برای سازگاری کامل با Excel نیست. هنگام طراحی یک جریان کاری گزارش‌گیری این محدودیت‌ها را در نظر بگیرید:

- فقط ثابت‌ها، عملگرها، مراجع و توابع مستند شده را هنگامی که نیاز به بازمحاسبهٔ فرمول‌ها توسط Aspose.Slides دارید، استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آنها وابسته‌اند، بازمحاسبه کنید.
- مقادیر کش‌شدهٔ ارائه‌های بارگذاری‌شده را به‌عنوان تصویر لحظه‌ای در نظر بگیرید، نه جایگزینی برای بازمحاسبه پس از ویرایش.
- قبل از اعتماد به مقادیر محاسبه‌شدهٔ قالب‌های موجود، فرمول‌ها را آزمایش کنید، به‌ویژه اگر از توابع خارج از فهرست مستند استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل صفحه‌گسترده نیاز دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کاربرگ نمودار را با مقادیر نهایی به‌روز کنید.

## **پرسش‌های متداول**

**فرق بین [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) چیست؟**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) یک عبارت سبک A1 مثل `B2-C2` را ذخیره می‌کند. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) یک عبارت سبک R1C1 مثل `RC[-2]-RC[-1]` را ذخیره می‌کند. نشانی‌نویسی‌ای را انتخاب کنید که با روش تولید یا کپی فرمول‌های شما سازگار باشد.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) یک [IChartDataCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/) برمی‌گرداند. برای به‌دست آوردن نتیجهٔ محاسبه‌شده، پس از بازمحاسبه، متد [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) آن سلول را فراخوانی کنید.

**چه زمانی باید [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را صدا بزنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و پیش از این که به نتایج محاسبه‌شده وابسته باشید، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را صدا بزنید. این کار مقادیر فرمول‌هایی که ارزیاب داخلی از آن‌ها پشتیبانی می‌کند، به‌روز می‌کند.

**آیا Aspose.Slides از تمام توابع Excel پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط زیرمجموعهٔ مستند شده‌ای از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید فرض شود که به‌درستی بازمحاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گستردهٔ مناسب انجام داده و مقادیر نهایی را در کتابچه کاری نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده شامل فرمولی نامورد باشد چه اتفاقی می‌افتد؟**

اگر داده‌های نمودار تغییر نکرده باشند، ممکن است کتابچه کاری هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellunsupporteddataexception/) ایجاد کند.

**آیا مقادیر خطای فرمول همان استثناهای Java هستند؟**

خیر. مقداری مانند `#DIV/0!` یک مقدار صفحه‌گسترده است که توسط یک محاسبهٔ معتبر تولید می‌شود. استثناهایی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellcircularreferenceexception/) نشان می‌دهند که فرمول نمی‌تواند به‌صورت عادی پردازش شود.

**آیا نمودار به‌صورت خودکار هنگام تغییر سلول فرمول به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتابچه کاری ارجاع دهد. ابتدا کتابچه کاری را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده اشاره کنند، نمودار از مقادیر به‌روز آن سلول‌ها استفاده می‌کند؛ نیازی به متد جداگانهٔ تازه‑سازی نمودار برای این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتابچه کاری Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار برای استفاده از یک کتابچه کاری خارجی پیکربندی شوند. با این حال، روند محاسبهٔ فرمول توصیف‌شده در این مقاله به کتابچه کاری داده‌های نمودار و زیرمجموعهٔ فرمولی که توسط Aspose.Slides ارزیابی می‌شود، مربوط است. فرض نکنید که [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بازمحاسبهٔ کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم فرمول‌هایی که به کاربرگ یا کتابچه کاری دیگری ارجاع می‌دهند استفاده کنم؟**

ارجاع‌های به سبک Excel ممکن است در کتابچه‌های کاری نمودار وجود داشته باشند، اما ارزیابی فرمول توسط پارسر و مجموعهٔ توابع پشتیبانی‌شده محدود است. اگر یک مرجع متقابل شیت یا خارجی حیاتی است، دقیقاً همان فرمول را با نسخهٔ Aspose.Slides هدف خود بررسی کنید. برای جریان‌های کاری که نیاز به سازگاری گستردهٔ مرجع‌های Excel دارند، کتابچه کاری را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را باز به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون `=` پیشوندی اختصاص می‌دهند. استفاده از این فرم باعث می‌شود فرمول‌های تولیدشده با نمونه‌های مستند API هم‌خوانی داشته باشند.