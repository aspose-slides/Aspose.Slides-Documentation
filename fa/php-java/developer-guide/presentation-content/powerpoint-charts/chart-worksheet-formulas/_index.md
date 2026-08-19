---
title: اعمال فرمول‌های ورق‌کار نمودار در ارائه‌ها در PHP
linktitle: فرمول‌های ورق‌کار
type: docs
weight: 70
url: /fa/php-java/chart-worksheet-formulas/
keywords:
- نمودار صفحه‌گسترده
- ورق‌کار نمودار
- فرمول نمودار
- فرمول ورق‌کار
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
- تابع پیش‌تعریف‌شده
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "فرمول‌های سبک Excel را در ورق‌کارهای نمودار Aspose.Slides برای PHP از طریق Java اعمال کنید، مقادیر را بازمحاسبه کنید و نتایج را در نمودارهای PowerPoint استفاده نمایید."
---
## **مرور کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک ورک‌شیت توکار ذخیره می‌کنند. در Aspose.Slides برای PHP از طریق Java می‌توانید به آن ورک‌شیت از طریق کتاب‌کار داده‌های نمودار دسترسی پیدا کنید، مقادیر ورودی را بنویسید، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کامل کار با فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن ورک‌شیت آن، اختصاص فرمول‌های سبک A1 یا R1C1، بازمحاسبه آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر کش‌شده، فرمول‌های نامعتبر و خطاهای مخصوص به صفحه‌گسترده را شرح می‌دهد.

## **ورک‌شیت‌های نمودار و فرمول‌ها**

یک ورک‌شیت نمودار شامل دسته‌بندی‌ها، نام‌های سری و مقادیری است که توسط نمودار استفاده می‌شوند. در PowerPoint می‌توانید با باز کردن ویرایشگر داده‌های نمودار، ورک‌شیت را بررسی کنید:

![نمودار PowerPoint با ورک‌شیت توکار باز که داده‌های دسته و سری را نشان می‌دهد](chart-worksheet-formulas_1.png)

در Aspose.Slides، ورک‌شیت از طریق کلاس [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) در دسترس است. برای فرمول‌های سبک A1 از [ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) و برای فرمول‌های سبک R1C1 از [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای بازمحاسبه فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) در دسترس می‌گذارد. این به‌ویژه زمانی مهم است که نیاز به بررسی نتیجه فرمول در کد داشته باشید یا سلول را به عنوان یک نقطه داده نمودار استفاده کنید.

## **ایجاد یک نمودار و محاسبه فرمول‌های ورک‌شیت**

مثال زیر یک جریان کار انتها به انتها را نشان می‌دهد. یک نمودار ستون خوشه‌ای ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌نماید.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نقاط داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری فراخوانی جداگانه‌ای برای به‌روزرسانی نمودار وجود ندارد: ابتدا ورک‌بک را بازمحاسبه کنید، سپس داده‌های نمودار که به سلول‌های محاسبه‌شده اشاره دارند را استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نویسه A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) اختصاص دهید.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

فرم‌های مرجع رایج A1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| دامنه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مراجع نسبی می‌توانند هنگام جابه‌جایی یا کپی فرمول توسط یک برنامه صفحه‌گسترده تغییر کنند. مراجع مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی که مراجع مختلط فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نویسه R1C1 ردیف‌ها و ستون‌ها را به صورت عددی شناسایی می‌کند. مراجع نسبی از جابجایی در براکت‌های مربعی استفاده می‌کنند. این نحو را از طریق [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) اختصاص دهید.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

فرم‌های مرجع رایج R1C1 عبارتند از:

| مرجع | نسبی | مطلق | مختلط |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| دامنه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به‌عنوان مثال، در سلول `D2`، `RC[-2]` به سلول همان ردیف دو ستون به سمت چپ (`B2`) اشاره می‌کند.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، اعداد ثابت، رشته‌ها، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقادیر ثابت**

| نوع | مثال‌ها | نکته |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌توان مستقیم در عبارات منطقی مانند `A2=TRUE` استفاده کرد. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نشانه‌گذاری اعشاری و علمی پشتیبانی می‌شود. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی در داخل فرمول بین کوتیشن‌های دوتایی قرار می‌گیرند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای یک نتیجه معمولی، به یک مقدار خطای صفحه‌گسترده ارزیابی شود. |

این مثال چندین نوع ثابت را استفاده می‌کند:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // نادرست
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **عملگرهای حسابی**

| عملگر | معنی | مثال |
|---|---|---|
| `+` | جمع یا مثبت یک‌پاره | `2+3` |
| `-` | تف subtraction یا منفی یک‌پاره | `2-3`, `-3` |
| `*` | ضرب | `2*3` |
| `/` | تقسیم | `2/3` |
| `%` | درصد | `30%` |
| `^` | توان | `2^3` |

برای واضح شدن ترتیب ارزیابی از پرانتز استفاده کنید، برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی بر می‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | مساوی | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگتر از | `A2>3` |
| `>=` | بزرگتر یا مساوی | `A2>=3` |
| `<` | کوچکتر از | `A2<3` |
| `<=` | کوچکتر یا مساوی | `A2<=3` |

## **توابع پیش‌تعریف‌شده پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای ورک‌شیت‌های نمودار شامل می‌شود، اما یک موتور محاسبه کامل Excel نیست. مجموعه توابع مستند شده به توابع زیر محدود می‌شود. تصور نکنید که هر تابع دلخواه Excel می‌تواند توسط [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) بازمحاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به بالا به مضرب | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس ایندکس | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ترکیب مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | ترکیب مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | تعداد روزهای بین تاریخ‌ها | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی در مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی بایت‌محور | `FINDB("a",A2)` |
| `IF` | نتیجه شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشترین مقدار | `MAX(B2:B5)` |
| `SUM` | جمع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان داده شده در جدول مهم‌اند: `INDEX` به صورت فرم مرجع مستند شده، در حالی که `LOOKUP` و `MATCH` به صورت فرم‌های برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند، باید به‌عنوان توابع غیرقابل پشتیبانی توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند، مگر اینکه به‌صورت جداگانه مستند شده باشند.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شده را ذخیره می‌کنند. بنابراین Aspose.Slides می‌تواند مقدار کش‌شده را از [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) بخواند زمانی که ارائه بارگذاری شده و داده‌های نمودار مربوطه تغییر نکرده‌اند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتیجه کش‌شده قدیمی تکیه نکنید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیره داده‌های نمودار که به آن‌ها وابسته‌اند، متد [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعه پشتیبانی‌شده هستند، ممکن است Aspose.Slides نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر ورک‌بک اصلاح شده باشد، مقدار کش‌شده قبلی دیگر قابل اعتماد نیست. در این وضعیت، خواندن مقدار سلولی با داده‌های پشتیبانی‌نشده می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

اگر نمودار شما به توابع Excel وابسته باشد که Aspose.Slides ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده که آن‌ها را پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. فرمول‌های نامعتبر را با مقادیر حدس‌زده جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع متفاوت مشکل وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجه‌ای خطای صفحه‌گسترده مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` بدهد. در این حالت توکن خطا یک نتیجه سلول است و می‌تواند از طریق [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) بازگردانده شود.

یک فرمول می‌تواند در سطح تجزیه، مرجع، وابستگی یا داده‌های پشتیبانی‌شده نیز شکست بخورد. Aspose.Slides برای این موارد استثنای‌های مخصوص صفحه‌گسترده ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellcircularreferenceexception/) و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellunsupporteddataexception/).

در PHP از طریق Java، استثنای‌های Java از طریق `JavaException` در دسترس می‌شوند. هنگام دریافت فرمول‌ها از قالب‌ها یا ورودی کاربر، آن‌ها را در اطراف بازمحاسبه و دسترسی به مقدار مدیریت کنید. استثنای Java که در ردیاب خطا گزارش می‌شود، نوع خاص شکست صفحه‌گسترده را شناسایی می‌کند:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **محدودیت‌های عملی**

پشتیبانی از فرمول در ورک‌شیت‌های نمودار برای یک زیرمجموعه تعریف‌شده از محاسبات صفحه‌گسترده است و نه برای سازگاری کامل با Excel. این محدودیت‌ها را هنگام طراحی یک جریان کاری گزارش‌گیری در نظر بگیرید:

- فقط از ثابت‌ها، عملگرها، مراجع و توابع مستند شده استفاده کنید که می‌خواهید Aspose.Slides آن‌ها را بازمحاسبه کند.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شده از ارائه‌های بارگذاری‌شده را به‌عنوان یک تصویر لحظه‌ای در نظر بگیرید، نه به‌عنوان جایگزینی برای بازمحاسبه پس از ویرایش.
- فرمول‌های قالب‌های موجود را پیش از اعتماد به مقادیر محاسبه‌شده تست کنید، به‌ویژه اگر از توابع خارج از لیست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور محاسبه کامل صفحه‌گسترده نیاز دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس مقادیر نهایی را در کتاب‌کار نمودار به‌روزرسانی کنید.

## **سوالات متداول**

**فرق بین [ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) و [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) چیست؟**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) یک عبارت سبک A1 مانند `B2-C2` را ذخیره می‌کند. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) یک عبارت سبک R1C1 مانند `RC[-2]-RC[-1]` را ذخیره می‌کند. از نوشتار متناسب با نحوه تولید یا کپی فرمول‌های خود استفاده کنید.

**آیا پس از محاسبه باید خود سلول یا مقدار آن را بخوانم؟**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getCell) یک [ChartDataCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/) برمی‌گرداند. برای دریافت نتیجه محاسبه‌شده، پس از بازمحاسبه متد [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) آن سلول را فراخوانی کنید.

**چه زمانی باید [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را صدا بزنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و قبل از اینکه به نتایج محاسبه‌شده وابسته باشید، متد [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید. این متد مقدار فرمول‌های پشتیبانی‌شده توسط ارزیاب داخلی را به‌روز می‌کند.

**آیا Aspose.Slides از تمام توابع Excel پشتیبانی می‌کند؟**

خیر. ارزیاب داخلی فقط زیرمجموعه‌ای مستند شده از توابع را پشتیبانی می‌کند. توابع خارج از این زیرمجموعه نباید انتظار داشته باشید به‌درستی بازمحاسبه شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام داده و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائه بارگذاری‌شده شامل فرمول نامعتبر باشد چه می‌شود؟**

اگر داده‌های نمودار تغییر نکرده باشد، ممکن است کتاب‌کار هنوز مقدار کش‌شده قبلی محاسبه‌شده را داشته باشد. پس از اصلاح داده‌های مرتبط، آن مقدار کش‌شده ممکن است دیگر معتبر نباشد. دسترسی به سلولی که فرمول آن قابل پردازش نیست می‌تواند استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellunsupporteddataexception/) را ایجاد کند.

**آیا مقادیر خطای فرمول همان استثنای‌های PHP هستند؟**

خیر. مقداری مانند `#DIV/0!` یک مقدار صفحه‌گسترده است که توسط یک محاسبه معتبر تولید می‌شود. خطاهای پردازش صفحه‌گسترده مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellcircularreferenceexception/) استثنای Java هستند که از طریق `JavaException` به PHP منتقل می‌شوند.

**آیا نمودار به‌صورت خودکار هنگام تغییر سلول فرمول به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را بازمحاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط داده نمودار به سلول‌های محاسبه‌شده ارجاع دارند، نمودار از مقادیر به‌روز شده استفاده می‌کند؛ نیازی به فراخوانی متد جداگانه برای به‌روزرسانی نمودار در این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک ورک‌بوک Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار به یک ورک‌بوک خارجی متصل شوند. با این حال، جریان کاری محاسبه فرمول توضیح داده شده در این مقاله به کتاب‌کار داده‌های نمودار و زیرمجموعه فرمول‌های ارزیابی‌شده توسط Aspose.Slides مربوط می‌شود. فرض نکنید که [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) بازمحاسبه کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به ورق یا ورک‌بوک دیگری ارجاع می‌دهند؟**

ارجاعات سبک Excel ممکن است در کتاب‌کارهای نمودار موجود باشد، اما ارزیابی فرمول توسط تجزیه‌کننده و مجموعه توابع پشتیبانی‌شده محدود است. اگر یک ارجاع میان‌ورقی یا خارجی ضروری است، دقیقاً همان فرمول را با نسخه هدف Aspose.Slides خود تأیید کنید. برای جریان‌های کاری که به سازگاری گسترده ارجاع‌های Excel نیاز دارند، کتاب‌کار را به‌صورت خارجی محاسبه کرده و مقادیر حل‌شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

مثال‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون `=` پیشی می‌نویسند. استفاده از این شکل باعث می‌شود فرمول‌های تولیدشده با مثال‌های مستند API هماهنگ باشد.