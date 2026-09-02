---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در PHP
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- نمودار Treemap
- نمودار Sunburst
- نمودار سلسله‌مراتبی
- نقطه داده
- برچسب داده
- رنگ شاخه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه داده‌های سلسله‌مراتبی ایجاد کنید و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای PHP از طریق Java سفارشی کنید."
---
## **نمای کلی**

نمودارهای Treemap و Sunburst داده‌های سلسله‌مراتبی یک نوع را نمایش می‌دهند، اما از چیدمان‌های متفاوتی استفاده می‌کنند. یک Treemap سلسله‌مراتب را به صورت مستطیل‌های تو در تو رسم می‌کند که مساحت آن‌ها مقدار برگ‌ها را نشان می‌دهد. یک Sunburst آن را به صورت حلقه‌های متحدالمرکز نمایش می‌دهد: گروه‌های سطح بالا نزدیک به مرکز هستند و دسته‌های برگ در حلقهٔ خارجی قرار می‌گیرند.

در Aspose.Slides for PHP via Java، هر مقدار عددی یک [نقطه‌داده‌نمودار]({{guid}}) است. متد [ChartDataPoint.getDataPointLevels]({{guid}}) دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله آن نگاشت را توضیح می‌دهد و نشان می‌دهد چگونه هر دو نوع نمودار را از داده‌های نمونهٔ یکسان ایجاد و قالب‌بندی کنیم.

![نمودار Treemap با شاخه‌های مصرف‌کننده و تجاری](treemap-hierarchy.png)

![نمودار Sunburst با همان سلسله‌مراتب مصرف‌کننده و تجاری](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

دیتاست نمونهٔ زیر دارای سه سطح دسته‌بندی و یک سری عددی است:

| شاخه | سرشاخه | برگ | درآمد |
| --- | --- | --- | ---: |
| مصرف‌کننده | کامپیوترها | لپ‌تاپ‌ها | 12 |
| مصرف‌کننده | کامپیوترها | دسکتاپ‌ها | 8 |
| مصرف‌کننده | موبایل | تلفن‌ها | 15 |
| مصرف‌کننده | موبایل | تبلت‌ها | 6 |
| تجاری | خدمات | مشاوره | 10 |
| تجاری | خدمات | پشتیبانی | 7 |
| تجاری | نرم‌افزار | لایسنس‌ها | 11 |
| تجاری | نرم‌افزار | اشتراک‌ها | 14 |

هر ردیف یک دستهٔ برگ و یک نقطه داده ایجاد می‌کند. سطوح گروه‌بندی دسته مسیر از آن برگ به والدینش را توصیف می‌کند. برای ردیف اول مسیر `مصرف‌کننده > کامپیوترها > لپ‌تاپ‌ها` است.

ایندکس‌های برگردانده‌شده توسط [ChartDataPoint.getDataPointLevels]({{guid}}) از برگ به سمت بالا شمارش می‌شوند:

| ایندکس `getDataPointLevels()` | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | مستطیل مقدار | بخش حلقهٔ خارجی |
| `1` | سرشاخه | مستطیل یا سرآیند والد | بخش حلقهٔ میانی |
| `2` | شاخه | مستطیل یا سرآیند سطح بالا | بخش حلقهٔ داخلی |

این ترتیب برای هر دو نوع نمودار یکسان است، اگرچه چیدمان بصری آن‌ها متفاوت است. یک بخش والد توسط چندین برگ به اشتراک گذاشته می‌شود. برای قالب‌بندی آن، از سطح متناظر اولین نقطه دادهٔ آن گروه استفاده کنید. به‌عنوان مثال، شاخهٔ `مصرف‌کننده` با نقطهٔ `لپ‌تاپ‌ها` شروع می‌شود، در حالی که سرشاخهٔ `نرم‌افزار` با نقطهٔ `لایسنس‌ها` آغاز می‌شود. نگهداری ارجاع به این نقاط واضح‌تر و ایمن‌تر از استفاده از عبارات نامشخصی مثل `$dataPoints->get_Item(0)` یا `$dataPoints->get_Item(6)` است.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap را در اسلاید اول و یک Sunburst را در اسلاید دوم می‌سازد. این مثال سلسله‌مراتب را می‌سازد، مقدار `تبلت‌ها` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح انتخاب‌شده اختصاص می‌دهد، برچسب یک شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می‌کند.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // افزودن دسته‌های برگ. یک مورد گروه‌بندی فقط زمانی تنظیم می‌شود که یک گروه جدید شروع شود;
        // دسته‌های بعدی تا زمانی که مورد دیگری تنظیم شود، در همان گروه باقی می‌مانند.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // نمایش دسته و مقدار در برگ Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // قالب‌بندی شاخه Consumer از طریق اولین برگ در آن شاخه.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // قالب‌بندی سرشاخه Software از طریق اولین برگ در آن سرشاخه.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از بخش‌های حلقه‌ای استفاده می‌کند.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

سلول‌های دسته و سلول‌های مقدار از یک ردیف همان کاربرگ استفاده می‌کنند، بنابراین موقعیت‌های مجموعهٔ آن‌ها هم‌راستا می‌ماند. وقتی با یک نمودار موجود کار می‌کنید نه اینکه یک نمودار جدید بسازید، ابتدا ردیف‌های دسته را بررسی کنید و ارجاع‌های نام‌گذاری‌شده به نقاط داده و سطوحی که قصد قالب‌بندی آن‌ها را دارید ذخیره کنید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- یک Treemap از مساحت برای انتقال مقدار و مستطیل‌های تو در تو برای انتقال سلسله‌مراتبی استفاده می‌کند. متد [ChartSeries.setParentLabelLayout]({{guid}}) کنترل می‌کند برچسب‌های والد در این نوع نمودار چگونه ظاهر شوند.
- یک Sunburst از زاویه برای انتقال مقدار و عمق حلقه برای انتقال سلسله‌مراتبی استفاده می‌کند. [ChartSeries.setParentLabelLayout]({{guid}}) برچسب‌های حلقهٔ آن را کنترل نمی‌کند.
- هر دو نوع نمودار از سطوح گروه‌بندی دسته یکسان و از همان ترتیب برگ‑به‑والد برگردانده‌شده توسط [ChartDataPoint.getDataPointLevels]({{guid}}) استفاده می‌کنند، بنابراین می‌توان کد ساخت داده‌ها و قالب‌بندی سطوح را به اشتراک گذاشت.
- مقادیر والد از برگ‌های فرزندشان محاسبه می‌شود. برای شاخه‌ها یا سرشاخه‌ها نقطهٔ عددی جداگانه اضافه نکنید.

### **مرتب‌سازی و ترتیب بخش‌ها**

موتور چیدمان نمودار مکان نهایی مستطیل‌ها و بخش‌های حلقه را تعیین می‌کند. ردیف‌های دستهٔ مرتبط را قبل از افزودن کنار هم قرار دهید، اما به موقعیت خاص یک مستطیل یا زاویهٔ شروع تکیه نکنید. اگر ترتیب معنی دارد، آن را در برچسب‌ها بگنجانید یا از نوع نموداری استفاده کنید که محور دستهٔ صریح داشته باشد.

### **تم و رنگ‌های ثابت**

سطوح قالب‌بندی‌نشدهٔ نمودار رنگ‌های خود را از تم ارائه می‌گیرند. مثال از پر کردن‌های RGB صریح برای خروجی پیش‌بینی‌پذیر استفاده می‌کند. اگر می‌خواهید نمودار با تغییرات تم سازگار باشد، به جای مقادیر ثابت RGB از رنگ‌های طرح‌بندی (scheme colors) استفاده کنید و از اورراید کردن هر سطح خودداری کنید. همچنین پس از تغییر پر کردن یک شاخه یا سرشاخه، کنتراست برچسب را بررسی کنید.

### **برچسب‌ها و فضای موجود**

PowerPoint ممکن است برچسب‌ها را مخفی یا کوتاه کند وقتی یک بخش خیلی کوچک باشد. افزایش اندازهٔ نمودار، کوتاه کردن نام‌های دسته یا نمایش کمتر فیلدهای برچسب معمولاً نتیجهٔ واضح‌تری می‌دهد. یک برچسب می‌تواند ترکیبی از نام دسته، نام سری و مقدار باشد از طریق [DataLabelFormat]({{guid}})، اما فعال‌سازی همه فیلدها اغلب نمودارهای سلسله‌مراتبی را خواندن دشوار می‌کند.

### **صادر کردن و رندرینگ**

ذخیره به‌صورت PPTX نمودار را قابل ویرایش نگه می‌دارد. زمانی که Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پر کردن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی قلم و اختلافات کوچک در فضای چیدمان موجود می‌تواند شکست خط یا قابلیت مشاهده برچسب را تغییر دهد، بنابراین قلم‌های مورد نیاز را نصب کنید و هدف‌های مهم خروجی را بررسی کنید.

## **سؤالات متداول**

**چرا تغییر سطح پدر (والد) بر چندین برگ تأثیر می‌گذارد؟**  
یک شاخه یا سرشاخه بخشی بصری مشترک است. می‌توان به [ChartDataPointLevel]({{guid}}) آن از طریق یک برگ فرزند دست یافت، اما قالب‌بندی به بخش والد مشترک تعلق دارد نه فقط به آن برگ.

**چرا یک برچسب داده‌ای گم شده است؟**  
اولین‌بار فیلدهای مورد نیاز را روی شیء [DataLabelFormat]({{guid}}) فعال کنید. سپس بررسی کنید که آیا بخش فضای کافی دارد یا نه. چیدمان برچسب والد در Treemap، ابعاد نمودار، طول برچسب، اندازه قلم و تعداد فیلدهای فعال همگی تأثیرگذارند.

**آیا می‌توانم ترتیب دقیق یا مختصات بخش‌ها را تعیین کنم؟**  
می‌توانید ترتیب ردیف‌های منبع را کنترل کنید و هر گروه را به‌صورت پیوسته نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زاویه‌های دقیق Sunburst را اختصاص دهید. موتور چیدمان نمودار این مقادیر را از سلسله‌مراتب، مقادیر و فضای موجود محاسبه می‌کند.

**چرا پس از تغییر تم ارائه رنگ‌ها تغییر می‌کند؟**  
پر کردن‌های مبتنی بر تم برای پیروی از پالت ارائه طراحی شده‌اند. برای سطوحی که باید ثابت بمانند، رنگ‌های RGB صریح اعمال کنید یا هنگام سازگاری با تم جدید، از رنگ‌های طرح‌بندی استفاده کنید.

**آیا قالب‌بندی سفارشی در خروجی‌های PDF و تصویر حفظ می‌شود؟**  
بله، پر کردن‌ها و تنظیمات برچسب پشتیبانی‌شده هنگام رندر درج می‌شوند. برای نتایج ثابت در سیستم‌های مختلف، قلم‌های مورد نیاز را در دسترس قرار دهید و اندازهٔ خروجی نهایی را آزمایش کنید، زیرا جای‌گیری برچسب‌ها بستگی به چیدمان دارد.

## **مراجعه کنید**

- [ایجاد نمودارهای Treemap](/slides/fa/php-java/create-chart/#create-tree-map-charts)
- [ایجاد نمودارهای Sunburst](/slides/fa/php-java/create-chart/#create-sunburst-charts)
- [صادر کردن نمودارهای ارائه](/slides/fa/php-java/export-chart/)
- [مدیریت تم‌های ارائه](/slides/fa/php-java/presentation-theme/)