---
title: استفاده از فرمول‌های کاربرگ نمودار در ارائه‌ها در PHP
linktitle: فرمول‌های کاربرگ
type: docs
weight: 70
url: /fa/php-java/chart-worksheet-formulas/
keywords:
- نمودار صفحه‌گسترده
- کاربرگ نمودار
- فرمول نمودار
- فرمول کاربرگ
- فرمول صفحه‌گسترده
- کتاب‌کار داده‌های نمودار
- محاسبه فرمول
- فرهنگ ترجیحی
- فرمول مرتبط با فرهنگ
- DBCS
- ثابت منطقی
- ثابت عددی
- ثابت رشته‌ای
- ثابت خطا
- عملگر حسابی
- عملگر مقایسه‌ای
- سبک A1
- سبک R1C1
- توابع پیش‌تعریف‌شده
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "استفاده از فرمول‌های شبیه‌به‑Excel در Aspose.Slides برای PHP از طریق کاربرگ‌های نمودار Java، محاسبه مجدد مقادیر و استفاده از نتایج در نمودارهای PowerPoint."
---
## **نمای کلی**

نمودارهای PowerPoint معمولاً داده‌های منبع خود را در یک کاربرگ تعبیه‌شده ذخیره می‌کنند. در Aspose.Slides برای PHP از طریق Java، می‌توانید به آن کاربرگ از طریق کتاب‌کار داده‌های نمودار دسترسی پیدا کنید، مقادیر ورودی نوشته، فرمول‌ها را به سلول‌ها اختصاص دهید، فرمول‌های پشتیبانی‌شده را محاسبه کنید و از سلول‌های محاسبه‌شده به عنوان داده‌های نمودار استفاده کنید.

این مقاله جریان کامل کار با فرمول‌ها را توضیح می‌دهد: ایجاد یک نمودار، پر کردن کاربرگ آن، اختصاص فرمول‌های سبک A1 یا R1C1، محاسبه مجدد آن‌ها، خواندن مقادیر محاسبه‌شده، اتصال این سلول‌ها به یک سری نمودار و ذخیره ارائه. همچنین نحو فرمول‌های پشتیبانی‌شده، زیرمجموعه توابع داخلی، مقادیر کش‌شده، فرمول‌های پشتیبانی‌نشده و خطاهای خاص صفحه‌گسترده را شرح می‌دهد.

## **کاربرگ‌ها و فرمول‌های نمودار**

یک کاربرگ نمودار شامل دسته‌ها، نام‌های سری و مقادیری است که توسط نمودار استفاده می‌شوند. در PowerPoint می‌توانید کاربرگ را با باز کردن ویرایشگر داده‌های نمودار بررسی کنید:

![نمودار PowerPoint با کاربرگ تعبیه‌شده باز که داده‌های دسته و سری را نشان می‌دهد](chart-worksheet-formulas_1.png)

در Aspose.Slides، کاربرگ از طریق کلاس [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) باز می‌شود. برای فرمول‌های سبک A1 از [ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) و برای فرمول‌های سبک R1C1 از [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) استفاده کنید. پس از تغییر سلول‌های ورودی یا فرمول‌ها، برای محاسبه مجدد فرمول‌های پشتیبانی‌شده و به‌روزرسانی مقادیر سلول‌های مربوطه، متد [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید.

یک سلول محاسبه‌شده همچنان نتیجه خود را از طریق [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) ارائه می‌دهد. این مورد زمانی مهم است که نیاز به بررسی نتیجه فرمول در کد یا استفاده از سلول به عنوان نقطه داده نمودار داشته باشید.

## **ایجاد نمودار و محاسبه فرمول‌های کاربرگ**

مثال زیر یک جریان کاری کامل را نشان می‌دهد. این مثال یک نمودار ستونی تجمیعی ایجاد می‌کند، داده‌های نمونه را پاک می‌کند، مقادیر درآمد و هزینه فصلی را می‌نویسد، سود را با فرمول‌ها محاسبه می‌کند، نتایج را می‌خواند، سلول‌های محاسبه‌شده را به عنوان مقادیر نمودار استفاده می‌کند و ارائه را ذخیره می‌کند.

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

نقاط داده نمودار به `D2:D4` ارجاع می‌دهند، بنابراین نمودار از مقادیر سود محاسبه‌شده استفاده می‌کند. در این جریان کاری نیازی به فراخوانی جداگانه‌ی به‌روزرسانی نمودار نیست: ابتدا کتاب‌کار را محاسبه کنید، سپس داده‌های نمودار که به سلول‌های محاسبه‌شده اشاره دارند را استفاده یا ذخیره کنید.

## **استفاده از فرمول‌های سبک A1**

نشانه‌گذاری A1 ستون‌ها را با حروف و ردیف‌ها را با اعداد شناسایی می‌کند. عبارات سبک A1 را از طریق [ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) اختصاص دهید.

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

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `A2` | `$A$2` | `A$2`, `$A2` |
| ردیف | `2:2` | `$2:$2` | — |
| ستون | `A:A` | `$A:$A` | — |
| بازه | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

مراجعات نسبی ممکن است هنگام جابجایی یا کپی فرمول توسط برنامهٔ صفحه‌گسترده تغییر کنند. مراجعات مطلق هر دو مختصات را ثابت نگه می‌دارند، در حالی که مراجعات ترکیبی فقط یک ردیف یا یک ستون را ثابت می‌کنند.

## **استفاده از فرمول‌های سبک R1C1**

نشانه‌گذاری R1C1 ردیف‌ها و ستون‌ها را به‌صورت عددی شناسایی می‌کند. مراجعات نسبی از جابجایی‌ها در براکت‌های مربعی استفاده می‌کنند. این نحو را از طریق [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) اختصاص دهید.

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

| مرجع | نسبی | مطلق | ترکیبی |
|---|---|---|---|
| سلول | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| ردیف | `R[2]` | `R2` | — |
| ستون | `C[3]` | `C3` | — |
| بازه | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

به عنوان مثال، در سلول `D2`، `RC[-2]` به سلولی در همان ردیف دو ستون به سمت چپ (`B2`) اشاره دارد.

## **ثابت‌ها و عملگرهای فرمول**

ارزیاب فرمول داخلی مقادیر منطقی، عددی، رشته‌ای، مقادیر خطای صفحه‌گسترده، عملگرهای حسابی و عملگرهای مقایسه‌ای را پشتیبانی می‌کند.

### **ثابت‌ها و مقادیر ثابت**

| نوع | مثال‌ها | نکات |
|---|---|---|
| منطقی | `TRUE`, `FALSE` | می‌تواند مستقیماً در عبارات منطقی مانند `A2=TRUE` استفاده شود. |
| عددی | `1`, `0.5`, `.3`, `1E-2` | نوشتار معمولی و علمی پشتیبانی می‌شود. |
| رشته | `"abc"`, `"2/3/2020 12:00"` | مقادیر متنی درون علامت‌های کوتیشن دوگانه داخل فرمول قرار می‌گیرند. |
| نتیجه خطا | `#DIV/0!`, `#N/A`, `#REF!` | یک فرمول معتبر می‌تواند به جای نتیجهٔ عادی، مقدار خطای صفحه‌گسترده برگرداند. |

این مثال چندین نوع ثابت را به کار می‌گیرد:

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
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

از پرانتزها برای صریح کردن ترتیب ارزیابی استفاده کنید؛ برای مثال `(A2+B2)*C2`.

### **عملگرهای مقایسه‌ای**

عبارات مقایسه‌ای مقادیر منطقی برمی‌گردانند.

| عملگر | معنی | مثال |
|---|---|---|
| `=` | برابر با | `A2=3` |
| `<>` | نامساوی | `A2<>3` |
| `>` | بزرگتر از | `A2>3` |
| `>=` | بزرگتر یا مساوی با | `A2>=3` |
| `<` | کوچکتر از | `A2<3` |
| `<=` | کوچکتر یا مساوی با | `A2<=3` |

## **توابع پیش‌تعریف‌شدهٔ پشتیبانی‌شده**

Aspose.Slides یک ارزیاب فرمول داخلی برای کاربرگ‌های نمودار دارد، اما این یک موتور کامل محاسبهٔ Excel نیست. مجموعهٔ توابع مستند شده به توابع زیر محدود است. فرض نکنید که هر تابع دلخواه Excel می‌تواند توسط [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) محاسبه شود.

| تابع | هدف یا فرم پشتیبانی‌شده | مثال |
|---|---|---|
| `ABS` | مقدار مطلق | `ABS(A2)` |
| `AVERAGE` | میانگین حسابی | `AVERAGE(B2:B5)` |
| `CEILING` | گرد کردن عدد به سمت بالا به مضربی | `CEILING(A2,5)` |
| `CHOOSE` | انتخاب مقدار بر اساس شاخص | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | پیوستن مقادیر متنی | `CONCAT(A2,B2)` |
| `CONCATENATE` | پیوستن مقادیر متنی | `CONCATENATE(A2," ",B2)` |
| `DATE` | ایجاد مقدار تاریخ با استفاده از سیستم تاریخ 1900 | `DATE(2026,8,19)` |
| `DAYS` | برگرداندن تعداد روزهای بین دو تاریخ | `DAYS(B2,A2)` |
| `FIND` | یافتن یک مقدار متنی داخل مقدار دیگر | `FIND("-",A2)` |
| `FINDB` | جستجوی متنی مبتنی بر بایت | `FINDB("a",A2)` |
| `IF` | نتیجهٔ شرطی | `IF(A2>0,A2,0)` |
| `INDEX` | فرم مرجع | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | فرم برداری | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | فرم برداری | `MATCH(A2,B2:B5,0)` |
| `MAX` | بیشینه مقدار | `MAX(B2:B5)` |
| `SUM` | مجموع مقادیر | `SUM(B2:B5)` |
| `VLOOKUP` | جستجوی عمودی | `VLOOKUP(A2,B2:D10,3,FALSE)` |

محدودیت‌های نشان‌داده‌شده در جدول مهم هستند: `INDEX` به صورت فرم مرجع مستند شده است، در حالی که `LOOKUP` و `MATCH` به شکل برداری مستند هستند. `DATE` از سیستم تاریخ 1900 استفاده می‌کند. ویژگی‌ها و توابعی که در اینجا فهرست نشده‌اند باید به عنوان پشتیبانی‌نشده توسط ارزیاب فرمول Aspose.Slides در نظر گرفته شوند، مگر اینکه به‌صورت جداگانه مستند شوند.

## **محاسبهٔ فرمول‌ها با فرهنگ مورد ترجیح**

برخی توابع کتاب‌کار نمودار متن را بر اساس قوانین خاص فرهنگ تفسیر می‌کنند. این مسأله به‌ویژه برای توابعی که برای زبان‌های دارای مجموعه کاراکتر دو بایتی (DBCS) طراحی شده‌اند، اهمیت دارد. برای محاسبه صحیح چنین فرمول‌هایی، یک [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) ایجاد کنید، فرهنگ مورد ترجیح را با [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) تنظیم کنید، گزینه‌های صفحه‌گسترده را از طریق [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) اختصاص دهید و سپس ارائه را بارگذاری کنید.

مثال زیر فرهنگ ژاپنی را انتخاب می‌کند، ارائه‌ای را با گزینه‌های بارگذاری پیکربندی‌شده باز می‌کند و برای هر کتاب‌کار نمودار متد [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی می‌کند:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

فرهنگ مورد ترجیح بخشی از پیکربندی بارگذاری ارائه است، بنابراین قبل از ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) آن را مشخص کنید. از فرهنگی استفاده کنید که فرمول‌های کتاب‌کار انتظار دارند؛ برای مثال برای فرمول‌هایی که باید با قوانین محاسبهٔ DBCS ژاپنی سازگار باشند، از `ja-JP` استفاده کنید.

## **بازمحاسبه و مقادیر کش‌شده**

فایل‌های صفحه‌گسترده معمولاً هم فرمول و هم آخرین مقدار محاسبه‌شدهٔ آن را ذخیره می‌کنند. Aspose.Slides می‌تواند مقدار کش‌شده را از طریق [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) هنگام بارگذاری ارائه بخواند، مشروط بر این‌که داده‌های نمودار مربوطه تغییر نکرده باشند.

پس از تغییر سلول‌های ورودی یا فرمول‌ها، به نتیجهٔ کش‌شدهٔ قدیمی وابسته نشوید. قبل از خواندن مقادیر محاسبه‌شده یا ذخیرهٔ داده‌های نموداری که به آن‌ها وابسته‌اند، متد [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید.

برای فرمول‌هایی که خارج از زیرمجموعهٔ پشتیبانی‌شده هستند، Aspose.Slides ممکن است نتواند فرمول را تجزیه یا وابستگی‌های آن را تعیین کند. اگر کتاب‌کار تغییر کرده باشد، مقدار کش‌شدهٔ قبلی دیگر قابل اعتماد نیست. در این وضعیت، خواندن مقدار سلولی با داده‌های پشتیبانی‌نشده می‌تواند باعث بروز استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellunsupporteddataexception/) شود.

اگر نمودار شما به توابع Excel وابسته است که Aspose.Slides آن‌ها را ارزیابی نمی‌کند، آن فرمول‌ها را با یک موتور صفحه‌گسترده‌ای که پشتیبانی می‌کند محاسبه کنید و مقادیر حاصل را به کتاب‌کار نمودار بنویسید. فرمول‌های پشتیبانی‌نشده را با مقادیر تخمین‌زده جایگزین نکنید.

## **مدیریت خطاهای فرمول**

دو نوع مشکل متفاوت وجود دارد.

یک فرمول می‌تواند معتبر باشد اما نتیجهٔ خطای صفحه‌گسترده مانند `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` یا `#VALUE!` تولید کند. در این حالت، توکن خطا یک نتیجهٔ سلولی است و می‌تواند از طریق [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) بازگردانده شود.

یک فرمول ممکن است در مرحلهٔ تجزیه، مرجع، وابستگی یا سطح دادهٔ پشتیبانی‌شده شکست بخورد. Aspose.Slides برای این موارد استثنای‌های خاص صفحه‌گسترده ارائه می‌دهد: [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellcircularreferenceexception/) و [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellunsupporteddataexception/).

در PHP از طریق Java، استثنای‌های Java از طریق `JavaException` در دسترس هستند. وقتی فرمول‌ها از قالب‌ها یا ورودی کاربر می‌آیند، آن‌ها را در اطراف بازمحاسبه و دسترسی به مقدار مدیریت کنید. استثنای Java که در رد‌پاسخ (stack trace) گزارش می‌شود، نوع شکست خاص صفحه‌گسترده را شناسایی می‌کند:

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

پشتیبانی از فرمول در کاربرگ‌های نمودار برای یک زیرمجموعهٔ تعریف‌شده از محاسبات صفحه‌گسترده طراحی شده است و هدف سازگاری کامل با Excel نیست. این محدودیت‌ها را هنگام طراحی جریان کاری گزارش‌گیری در ذهن داشته باشید:

- فقط از ثابت‌ها، عملگرها، مراجعات و توابع مستند شده استفاده کنید وقتی می‌خواهید Aspose.Slides فرمول‌ها را بازمحاسبه کند.
- پس از تغییر سلول‌هایی که نتایج فرمول به آن‌ها وابسته است، بازمحاسبه کنید.
- مقادیر کش‌شدهٔ ارائه‌های بارگذاری‌شده را به‌عنوان عکس‌العمل‌های لحظه‌ای در نظر بگیرید، نه به‌عنوان جایگزین بازمحاسبه پس از ویرایش.
- قبل از اعتماد به مقادیر محاسبه‌شدهٔ قالب‌های موجود، فرمول‌ها را آزمایش کنید، به‌ویژه اگر از توابعی خارج از فهرست مستند شده استفاده می‌کنند.
- برای فرمول‌هایی که به یک موتور کامل صفحه‌گسترده نیاز دارند، آن‌ها را به‌صورت خارجی محاسبه کنید و سپس کتاب‌کار نمودار را با مقادیر نهایی بروز کنید.

## **پرسش‌های متداول**

**فرق بین [ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) و [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) چیست؟**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setFormula) یک عبارت سبک A1 مثل `B2-C2` را ذخیره می‌کند. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#setR1C1Formula) یک عبارت سبک R1C1 مثل `RC[-2]-RC[-1]` را ذخیره می‌کند. روشی را انتخاب کنید که با نحوهٔ تولید یا کپی فرمول‌هایتان هم‌خوانی داشته باشد.

**پس از محاسبه، باید سلول را بخوانم یا مقدار آن را؟**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#getCell) یک [ChartDataCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/) برمی‌گرداند. برای به دست آوردن نتیجهٔ محاسبه‌شده، پس از بازمحاسبه متد [ChartDataCell::getValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdatacell/#getValue) آن سلول را فراخوانی کنید.

**چه زمانی باید [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنم؟**

پس از تغییر مقادیر ورودی یا فرمول‌ها و پیش از اتکی بر نتایج محاسبه‌شده، متد [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) را فراخوانی کنید. این متد مقادیر فرمول‌های پشتیبانی‌شده توسط ارزیاب داخلی را به‌روز می‌کند.

**آیا Aspose.Slides از تمام توابع Excel پشتیبانی می‌کند؟**

نه. ارزیاب داخلی فقط زیرمجموعهٔ مستند شده‌ای از توابع را پشتیبانی می‌کند. توابعی که خارج از این زیرمجموعه هستند نباید انتظار داشته باشید که به‌درستی بازمحاسبه شوند. اگر سازگاری کامل با فرمول‌های Excel لازم است، محاسبه را با یک موتور صفحه‌گسترده مناسب انجام داده و مقادیر نهایی را به کتاب‌کار نمودار بنویسید.

**اگر یک ارائهٔ بارگذاری‌شده شامل فرمول پشتیبانی‌نشده باشد چه اتفاقی می‌افتد؟**

اگر داده‌های نمودار تغییر نکرده باشد، کتاب‌کار ممکن است هنوز مقدار کش‌شدهٔ قبلی را داشته باشد. پس از تغییر داده‌های مرتبط، آن مقدار کش‌شده ممکن است معتبر نباشد. دسترسی به سلولی که فرمول آن نمی‌تواند پردازش شود می‌تواند باعث بروز استثنای [CellUnsupportedDataException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellunsupporteddataexception/) شود.

**آیا مقادیر خطای فرمول همان استثنای PHP هستند؟**

نه. نتیجه‌ای مانند `#DIV/0!` یک مقدار صفحه‌گسترده است که توسط یک محاسبهٔ معتبر تولید شده. شکست‌های پردازش صفحه‌گسترده مانند [CellInvalidFormulaException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellinvalidformulaexception/) یا [CellCircularReferenceException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellcircularreferenceexception/) استثنای Java هستند که از طریق `JavaException` به PHP منتقل می‌شوند.

**آیا نمودار هنگام تغییر سلول فرمول به‌صورت خودکار به‌روز می‌شود؟**

یک سری نمودار می‌تواند به سلول‌های کتاب‌کار ارجاع دهد. ابتدا کتاب‌کار را محاسبه کنید، سپس ارائه را ذخیره یا رندر کنید. اگر نقاط دادهٔ نمودار به سلول‌های محاسبه‌شده ارجاع دهند، نمودار از مقادیر به‌روزشدهٔ آن سلول‌ها استفاده می‌کند؛ نیازی به متد به‌روزرسانی جداگانه برای این جریان کاری نیست.

**آیا نمودارها می‌توانند از یک کتاب‌کار Excel خارجی استفاده کنند؟**

بله، داده‌های نمودار می‌توانند از طریق API داده‌های نمودار به یک کتاب‌کار خارجی تنظیم شوند. با این حال، جریان کاری محاسبهٔ فرمول که در این مقاله شرح داده شده، مربوط به کتاب‌کار داده‌های نمودار و زیرمجموعهٔ فرمول‌هایی است که توسط Aspose.Slides ارزیابی می‌شود. فرض نکنید که [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) بازمحاسبهٔ کامل فرمول‌های دلخواه در یک فایل XLSX خارجی را فراهم می‌کند.

**آیا می‌توانم از فرمول‌هایی استفاده کنم که به کاربرگ یا کتاب‌کار دیگری ارجاع می‌دهند؟**

مراجعات سبک Excel ممکن است در کتاب‌کارهای نمودار وجود داشته باشند، اما ارزیابی فرمول توسط تجزیه‌گر و مجموعهٔ توابع پشتیبانی‌شده محدود است. اگر ارجاع متقاطع یا خارجی ضروری است، دقیقاً همان فرمول را با نسخهٔ هدف Aspose.Slides خود اعتبارسنجی کنید. برای جریان‌های کاری که نیاز به سازگاری گستردهٔ ارجاع‌های Excel دارند، کتاب‌کار را به‌صورت خارجی محاسبه کرده و مقادیر حل‌شده را به داده‌های نمودار بنویسید.

**آیا رشته‌های فرمول باید با `=` شروع شوند؟**

مثال‌های API Aspose.Slides عبارات مانند `B2-C2` یا `SUM(B2:B5)` را بدون پیشوند `=` اختصاص می‌دهند. استفاده از این شکل باعث می‌شود فرمول‌های تولید شده با نمونه‌های مستند API هم‌خوانی داشته باشند.