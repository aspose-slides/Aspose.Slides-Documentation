---
title: اعمال فرمول‌های برگه‌کار نمودار در ارائه‌های اندروید
linktitle: فرمول‌های برگه‌کار
type: docs
weight: 70
url: /fa/androidjava/chart-worksheet-formulas/
keywords:
- صفحه‌گسترده نمودار
- برگه‌کار نمودار
- فرمول نمودار
- فرمول برگه‌کار
- فرمول صفحه‌گسترده
- کتاب‌کار داده‌های نمودار
- محاسبه فرمول
- ثابت منطقی
- ثابت عددی
- ثابت رشته‌ای
- ثابت خطا
- عملگر حسابی
- عملگر مقایسه‌ای
- سبک A1
- سبک R1C1
- تابع از پیش تعریف‌شده
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "اعمال فرمول‌های مشابه اکسل در Aspose.Slides برای اندروید از طریق برگه‌های کار نمودار جاوا، بازمحاسبه مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **بررسی کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک برگه کار جاسازی شده ذخیره می‌کنند. در Aspose.Slides برای Android از طریق Java می‌توانید به آن برگه کار از طریق کتاب‌کار داده‌های نمودار دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کار کامل فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن برگه کاری آن، تخصیص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر کش‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای خاص صفحه‌گسترده را توصیف می‌کند.

## **ورق‌های کاری نمودار و فرمول‌ها**

یک ورق کاری نمودار شامل دسته‌ها، نام‌های سری و مقادیر استفاده شده توسط یک نمودار است. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، برگه کاری را بررسی کنید:

![نمودار PowerPoint با برگه کاری جاسازی شده باز که داده‌های دسته و سری را نشان می‌دهد](chart-worksheet-formulas_1.png)

در Aspose.Slides، ورق کاری از طریق رابط [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و برای فرمول‌های سبک R1C1 از [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

یک سلول محاسبه‌شده هنوز نتیجه خود را از طریق [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#getValue--) در دسترس می‌گذارد. این مهم است وقتی که نیاز دارید نتیجه یک فرمول را در کد بررسی کنید یا سلول را به عنوان نقطه داده‌ای نمودار استفاده کنید.

## **ایجاد یک نمودار و محاسبه فرمول‌های برگه کاری**

مثال زیر یک جریان کار انتها به انتها را نشان می‌دهد. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

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

نقاط داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار وجود ندارد: ابتدا کتاب‌کار را بازمحاسبه کنید، سپس داده‌های نمودار که به سلول‌های محاسبه‌شده اشاره دارند را استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نمادگذاری A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) اختصاص دهید.

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

فرم‌های مرجع رایج A1 به صورت زیر هستند:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مرجع‌های نسبی هنگام جابه‌جایی یا کپی کردن فرمول توسط برنامه صفحه‌گسترده تغییر می‌کنند. مراجع مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی تنها یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نمادگذاری R1C1 هم ردیف‌ها و هم ستون‌ها را به صورت عددی شناسایی می‌کند. مراجع نسبی از جابجایی‌ها در براکت‌های مربعی استفاده می‌کنند. این نحو را از طریق [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) اختصاص دهید.

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

فرم‌های مرجع رایج R1C1 به صورت زیر هستند:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به‌عنوان مثال، در سلول `D2`، `RC[-2]` به سلولی در همان ردیف دو ستون به سمت چپ (`B2`) اشاره دارد.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقادیر ثابت**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌تواند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شود. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوشتارهای اعشاری و علمی پشتیبانی می‌شوند. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی داخل فرمول با علامت نقل قول دوگانه محصور می‌شوند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به مقدار خطای صفحه‌گسترده به جای نتیجهٔ معمولی ارزیابی شود. |

این مثال از چندین نوع ثابت استفاده می‌کند:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // نادرست
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
| `+` | جمع یا علامت مثبت تک‌تایی | `2+3` |
| `-` | تفاضل یا علامت منفی تک‌تایی | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

از پرانتزها برای واضح‌سازی ترتیب ارزیابی استفاده کنید، برای مثال `(A2+B2)*C2`.

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

## **توابع پیش‌تعریف‌شده پشتیبانی‌شده**

Aspose.Slides شامل یک ارزیاب فرمول داخلی برای برگه‌های کاری نمودار است، اما این یک موتور محاسبهٔ کامل Excel نیست. مجموعهٔ توابع مستند شده به توابع زیر محدود است. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بازمحاسبه شود.

| تابع | هدف یا شکل پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس شاخص | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ترکیب مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | ترکیب مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | برگرداندن تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی در داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی بایت‑محور | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه | `MAX(B2:B5)` |
| `SUM` | جمع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده‌شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده است، در حالی که `LOOKUP` و `MATCH` در فرم‌های برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند باید به‌عنوان پشتیبانی‌نشده توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند مگر اینکه به‌طور جداگانه مستند شوند.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند مقدار کش‌شده را از [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#getValue--) هنگام بارگذاری ارائه بخواند، به‌شرط آنکه داده‌های نمودار مربوطه تغییر نکرده باشند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتیجهٔ کش‌شدهٔ قدیمی تکیه نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیرهٔ داده‌های نموداری که به آن‌ها وابسته‌اند، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

برای فرمول‌های خارج از زیرمجموعهٔ پشتیبانی‌شده، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار تغییر یافته باشد، مقدار کش‌شدهٔ قبلی دیگر قابل اعتماد نیست. در این وضعیت، خواندن مقدار یک سلول با دادهٔ پشتیبانی‌نشده می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel وابسته باشد که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده‌ای که از آن‌ها پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. از جایگزین کردن فرمول‌های پشتیبانی‌نشده با مقادیر حدس‌زده خودداری کنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل متفاوت وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجهٔ خطای صفحه‌گسترده‌ای مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت، توکن خطا یک نتیجهٔ سلول است و می‌تواند از طریق [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#getValue--) بازگردانده شود.

یک فرمول همچنین می‌تواند در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای‌های خاص صفحه‌گسترده ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellcircularreferenceexception/), و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellunsupporteddataexception/).

زمانی که فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، این استثنای‌ها را در اطراف بازمحاسبه و دسترسی به مقدار مدیریت کنید:

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

پشتیبانی از فرمول در برگه‌های کاری نمودار برای زیرمجموعه‌ای تعریف‌شده از محاسبات صفحه‌گسترده است، نه برای سازگاری کامل با Excel. هنگام طراحی یک جریان کار گزارش‌گیری این محدودیت‌ها را در نظر داشته باشید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده استفاده کنید وقتی که نیاز دارید Aspose.Slides فرمول‌ها را بازمحاسبه کند.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شده از ارائه‌های بارگذاری‌شده را به‌عنوان تصویر لحظه‌ای در نظر بگیرید، نه به‌عنوان جایگزین برای بازمحاسبه پس از ویرایش.
- فرمول‌های موجود در قالب‌های پیشین را پیش از اطمینان از مقادیر محاسبه‌شده تست کنید، به‌ویژه عندما از توابع خارج از فهرست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبهٔ کامل صفحه‌گسترده نیاز دارند، آن‌ها را به صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر به‌دست آمده به‌روزرسانی کنید.

## **سوالات متداول**

**تفاوت بین [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) چیست؟**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) یک عبارت سبک A1 مانند `B2-C2` را ذخیره می‌کند. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` را ذخیره می‌کند. نوشتاری را که بهتر با نحوهٔ تولید یا کپی فرمول‌هایتان همخوانی دارد انتخاب کنید.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) یک [IChartDataCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/) باز می‌گرداند. برای به‌دست آوردن نتیجهٔ محاسبه‌شده، پس از بازمحاسبه متد [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#getValue--) آن سلول را فراخوانی کنید.

**چه زمانی باید [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنم؟**

بعد از تغییر مقادیر ورودی یا فرمول‌ها و پیش از تکیه بر نتایج محاسبه‌شده، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید. این متد مقادیر فرمول‌هایی را که ارزیاب داخلی پشتیبانی می‌کند به‌روز می‌کند.

**آیا Aspose.Slides از هر تابع Excel پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی تنها زیرمجموعهٔ مستند شده‌ای از توابع را پشتیبانی می‌کند. توابع خارج از این زیرمجموعه نباید به‌صورت بازمحاسبه صحیح فرض شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام دهید و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائهٔ بارگذاری‌شده شامل فرمول پشتیبانی‌نشده باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشند، ممکن است کتاب‌کار هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثنای‌های جاوا هستند؟**

خیر. مقداری مانند `#DIV/0!` یک مقدار صفحه‌گسترده است که توسط یک محاسبهٔ معتبر تولید می‌شود. استثنای‌های مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellcircularreferenceexception/) نشان می‌دهند که فرمول به‌صورت عادی قابل پردازش نیست.

**آیا نمودار به‌صورت خودکار هنگام تغییر سلول فرمول به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده ارجاع دهند، نمودار از مقادیر به‌روزشدهٔ آن سلول‌ها استفاده می‌کند؛ روش جداگانه‌ای برای به‌روزرسانی نمودار در این جریان کار لازم نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار برای استفاده از کتاب‌کار خارجی پیکربندی شوند. با این حال، جریان کاری محاسبه فرمول توضیح داده‌شده در این مقاله مربوط به کتاب‌کار داده‌های نمودار و زیرمجموعه فرمول‌های ارزیابی‌شده توسط Aspose.Slides است. فرض نکنید که [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) محاسبهٔ کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به برگه یا کتاب‌کار دیگری ارجاع می‌دهند؟**

مراجعات به سبک Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول توسط پارسر و مجموعهٔ توابع پشتیبانی‌شده محدود می‌شود. اگر یک مرجع بین برگه‌ای یا خارجی ضروری است، دقیقاً همان فرمول را با نسخهٔ هدف Aspose.Slides خود اعتبارسنجی کنید. برای جریان‌های کاری که نیاز به سازگاری گستردهٔ مراجع Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

نمونه‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون پیشوند `=` اختصاص می‌دهند. استفاده از این شکل فرمول‌ها باعث می‌شود که فرمول‌های تولیدشده با نمونه‌های مستند API همخوانی داشته باشند.