---
title: "اعمال فرمول‌های کاربرگ نمودار در ارائه‌ها با جاوا"
linktitle: "فرمول‌های کاربرگ"
type: docs
weight: 70
url: /fa/java/chart-worksheet-formulas/
keywords:
- "صفحه‌گسترده نمودار"
- "کاربرگ نمودار"
- "فرمول نمودار"
- "فرمول کاربرگ"
- "فرمول صفحه‌گسترده"
- "کتاب‌کار داده‌های نمودار"
- "محاسبه فرمول"
- "فرهنگ ترجیحی"
- "فرمول مخصوص به فرهنگ"
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
- "جاوا"
- "Aspose.Slides"
description: "اعمال فرمول‌های سبک Excel در کاربرگ‌های نمودار Aspose.Slides برای جاوا، بازمحاسبه مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **بررسی کلی**

نمودارهای PowerPoint معمولاً داده منبع خود را در یک کاربرگ توکار ذخیره می‌کنند. در Aspose.Slides for Java می‌توانید از طریق کتاب‌کار داده‌های نمودار به آن کاربرگ دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کامل کار با فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال آن سلول‌ها به یک سری نمودار و ذخیرهٔ ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعهٔ توابع داخلی، مقادیر کش‌شده، فرمول‌های غیرقابل پشتیبانی و خطاهای خاص صفحه‌گسترده را شرح می‌دهد.

## **کاربرگ‌های نمودار و فرمول‌ها**

یک کاربرگ نمودار شامل دسته‌ها، نام‌های سری و مقادیری است که توسط یک نمودار استفاده می‌شود. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، کاربرگ را بازرسی کنید:

![نمودار PowerPoint با کاربرگ توکار باز که داده‌های دسته و سری را نشان می‌دهد](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق رابط [IChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و برای فرمول‌های سبک R1C1 از [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبهٔ فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های متناظر، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجهٔ خود را از طریق [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) در دسترس می‌گذارد. این موضوع زمانی مهم است که نیاز به بررسی نتیجهٔ فرمول در کد یا استفاده از سلول به عنوان نقطه دادهٔ نمودار دارید.

## **ایجاد یک نمودار و محاسبهٔ فرمول‌های کاربرگ**

مثال زیر یک جریان کاری انتها‑به‑انتها را نشان می‌دهد. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینهٔ فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

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

نقاط دادهٔ نمودار به `D2:D4` اشاره می‌کنند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری نیازی به فراخوانی جداگانه برای تازه‌سازی نمودار نیست: ابتدا کتاب‌کار را بازمحاسبه کنید، سپس داده‌های نمودار را که به سلول‌های محاسبه‌شده اشاره می‌کنند، استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نمادگذاری A1 ستون‌ها را با حروف و سطرها را با اعداد شناسایی می‌کند. برای اختصاص عبارات سبک A1 از [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) استفاده کنید.

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

فرم‌های مرجع رایج A1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| سطر | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مراجع نسبی زمانی که فرمول جابه‌جا یا کپی شود توسط برنامهٔ صفحه‌گسترده ممکن است تغییر کنند. مراجع مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی که مراجع ترکیبی فقط یک سطر یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نمادگذاری R1C1 هر دو سطر و ستون را به صورت عددی شناسایی می‌کند. مراجع نسبی از افست‌ها در براکت‌های مربعی استفاده می‌کنند. برای اختصاص این نحو از [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) استفاده کنید.

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

فرم‌های مرجع رایج R1C1 عبارتند از:

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| سطر | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به‌عنوان مثال، در سلول `D2`، `RC[-2]` به سلولی در همان سطر دو ستون به سمت چپ (`B2`) اشاره می‌کند.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای صفحه‌گسترده، عملگرهای ریاضی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقدارهای اولیه**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توان مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده کرد. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | قالب‌های عادی و علمی پشتیبانی می‌شوند. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی داخل فرمول در داخل کوتیشن‌های دوگانه قرار می‌گیرند. |
| نتیجهٔ خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به‌جای نتیجهٔ معمولی، مقدار خطای صفحه‌گسترده برگرداند. |

این مثال چندین نوع ثابت را استفاده می‌کند:

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

### **عملگرهای ریاضی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا مثبت تک‌تایی | `2+3` |
| `-` | تفریق یا منفی تک‌تایی | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای صریح کردن ترتیب ارزیابی می‌توانید از پرانتز استفاده کنید، برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | برابر با | `A2=3` |
| `<>` | نامساوی با | `A2<>3` |
| `>` | بزرگتر از | `A2>3` |
| `>=` | بزرگتر یا مساوی با | `A2>=3` |
| `<` | کوچکتر از | `A2<3` |
| `<=` | کوچکتر یا مساوی با | `A2<=3` |

## **توابع پیش‌تعریف شدهٔ پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای کاربرگ‌های نمودار دارد، اما یک موتور محاسبهٔ کامل Excel نیست. مجموعهٔ مستند شده توابع محدود به موارد زیر است. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بازمحاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس شاخص | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ترکیب مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | ترکیب مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | بازگرداندن تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی مبتنی بر بایت | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشترین مقدار | `MAX(B2:B5)` |
| `SUM` | مجموع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان داده‌شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده است، در حالی که `LOOKUP` و `MATCH` به صورت فرم‌های برداری مستند شده‌اند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. توابع و ویژگی‌های غیرقید شده در اینجا باید به‌عنوان غیرقابل پشتیبانی توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند مگر این‌که به‌صورت جداگانه مستند شده باشند.

## **محاسبهٔ فرمول‌ها با فرهنگ ترجیحی**

برخی توابع کتاب‌کار نمودار متن را بر اساس قواعد خاص فرهنگ تفسیر می‌کنند. این مورد به‌ویژه برای توابعی که برای زبان‌های استفاده‌کننده از مجموعه کاراکترهای دوتایی (DBCS) هدف‌گذاری شده‌اند مهم است. برای محاسبهٔ صحیح چنین فرمول‌هایی، یک [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید، فرهنگ ترجیحی را با [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) تنظیم کنید، گزینه‌های صفحه‌گسترده را از طریق [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) اختصاص دهید و سپس ارائه را بارگذاری کنید.

مثال زیر فرهنگ ژاپنی را انتخاب می‌کند، یک ارائه را با گزینه‌های بارگذاری پیکربندی‌شده باز می‌کند و برای هر کتاب‌کار نمودار متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی می‌کند:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

فرهنگ ترجیحی بخشی از پیکربندی بارگذاری ارائه است، بنابراین قبل از ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) آن را مشخص کنید. از فرهنگی استفاده کنید که فرمول‌های کتاب‌کار انتظار دارند؛ برای مثال برای فرمول‌هایی که باید با قوانین محاسبهٔ DBCS ژاپنی سازگار باشند، از `ja-JP` استفاده کنید.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند هنگام بارگذاری یک ارائه، مقدار کش‌شده را از طریق [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) بخواند، به شرطی که داده‌های مرتبط نمودار تغییر نکرده باشند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به مقدار کش‌شدهٔ قدیمی اعتماد نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیرهٔ داده‌های نموداری که به آن‌ها وابسته‌اند، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید.

برای فرمول‌های خارج از زیرمجموعهٔ پشتیبانی‌شده، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار تغییر یافته باشد، مقدار کش‌شده قبلی دیگر قابل اعتماد نیست. در این وضعیت، خواندن مقدار یک سلول با دادهٔ غیرقابل پشتیبانی می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellunsupporteddataexception/) را تولید کند.

اگر نمودار شما به توابع Excel وابسته باشد که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گستردهٔ پشتیبانی‌کننده محاسبه کنید و مقادیر به‌دست‌آمده را به کتاب‌کار نمودار بنویسید. فرمول‌های غیرقابل پشتیبانی را با مقدارهای حدسی جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل مختلف وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجهٔ خطای صفحه‌گسترده‌ای مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, یا `#VALUE!` تولید کند. در این حالت توکن خطا یک نتیجهٔ سلولی است و می‌تواند از طریق [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) بازگردانده شود.

یک فرمول ممکن است در سطح تجزیه، مرجع، وابستگی یا دادهٔ پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای‌های خاص صفحه‌گسترده ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellinvalidformulaexception/)، [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellinvalidreferenceexception/)، [CellCircularReferenceException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellcircularreferenceexception/)، و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellunsupporteddataexception/).

هنگامی که فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، این استثنای‌ها را در اطراف بازمحاسبه و دسترسی به مقدار مدیریت کنید:

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

پشتیبانی از فرمول در کاربرگ‌های نمودار برای زیرمجموعه‌ای تعریف‌شده از محاسبات صفحه‌گسترده هدف‌گذاری شده است و نه برای سازگاری کامل با Excel. هنگام طراحی یک جریان کاری گزارش‌گیری این محدودیت‌ها را در نظر بگیرید:

- فقط ثابت‌ها، عملگرها، مراجع و توابع مستند شده را در زمانی که نیاز به بازمحاسبهٔ فرمول‌ها توسط Aspose.Slides دارید، استفاده کنید.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته‌اند، بازمحاسبه کنید.
- مقادیر کش‌شدهٔ ارائه‌های بارگذاری‌شده را به‌عنوان snapshots در نظر بگیرید، نه به‌عنوان جایگزینی برای بازمحاسبه پس از ویرایش.
- فرمول‌های موجود در قالب‌های پیشین را قبل از اعتماد به مقادیر محاسبه‌شدهٔ آن‌ها تست کنید، به‌ویژه اگر از توابع خارج از لیست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که نیاز به یک موتور محاسبهٔ کامل صفحه‌گسترده دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر نهایی به‌روز کنید.

## **سوالات متداول**

**تفاوت بین [IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) و [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) چیست؟**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) یک عبارت سبک A1 نظیر `B2-C2` را ذخیره می‌کند. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) یک عبارت سبک R1C1 نظیر `RC[-2]-RC[-1]` را ذخیره می‌کند. از نمادگذاری‌ای استفاده کنید که با نحوهٔ تولید یا کپی کردن فرمول‌های خود بیشترین تطابق را دارد.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) یک [IChartDataCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/) برمی‌گرداند. برای به‌دست‌آوردن نتیجهٔ محاسبه‌شده، پس از بازمحاسبه متد [IChartDataCell.getValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#getValue--) را فراخوانی کنید.

**چه زمانی باید [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و قبل از اینکه به نتایج محاسبه‌شده وابسته باشید، متد [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) را فراخوانی کنید. این کار مقادیر فرمول‌هایی را که ارزیاب داخلی پشتیبانی می‌کند بروز می‌کند.

**آیا Aspose.Slides تمام توابع Excel را پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط زیرمجموعهٔ مستند شده‌ای از توابع را پشتیبانی می‌کند. توابع خارج از این زیرمجموعه نباید فرض شود که به‌طور صحیح بازمحاسبه می‌شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام دهید و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر ارائهٔ بارگذاری‌شده شامل فرمول غیرقابل پشتیبانی باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشند، کتاب‌کار ممکن است هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همانند استثنای‌های Java هستند؟**

خیر. نتیجه‌ای مانند `#DIV/0!` یک مقدار صفحه‌گسترده تولید شده توسط یک محاسبهٔ معتبر است. استثنای‌هایی مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellcircularreferenceexception/) نشان می‌دهند که فرمول به‌طور عادی نمی‌تواند پردازش شود.

**آیا هنگام تغییر سلول فرمولی، نمودار به‌طور خودکار به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده اشاره کنند، نمودار از مقادیر به‌روزشدهٔ آن سلول‌ها استفاده می‌کند؛ نیازی به فراخوانی جداگانهٔ تازه‌سازی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار به یک کتاب‌کار خارجی تنظیم شوند. با این حال، جریان کاری محاسبهٔ فرمول توضیح‌داده‌شده در این مقاله به کتاب‌کار داده‌های نمودار و زیرمجموعهٔ فرمول‌های ارزیابی‌شده توسط Aspose.Slides مربوط می‌شود. فرض نکنید که [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) بازمحاسبهٔ کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به کاربرگ یا کتاب‌کار دیگری ارجاع می‌دهند؟**

مراجع به سبک Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول توسط پارسر و مجموعهٔ توابع پشتیبانی‌شده محدود است. اگر یک ارجاع عبور‑صفحه یا خارجی ضروری است، دقیقاً آن فرمول را با نسخهٔ هدف Aspose.Slides خود اعتبارسنجی کنید. برای جریان‌های کاری که نیاز به سازگاری گستردهٔ مراجع Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کنید و مقادیر حل‌شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

مثال‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون `=` پیش‌فرض می‌دهند. استفاده از این شکل، فرمول‌های تولید‌شده را با نمونه‌های مستند شده سازگار نگه می‌دارد.