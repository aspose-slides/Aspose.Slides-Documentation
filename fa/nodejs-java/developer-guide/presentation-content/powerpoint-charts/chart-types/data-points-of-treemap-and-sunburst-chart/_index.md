---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst با استفاده از JavaScript
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- نمودار treemap
- نمودار sunburst
- نمودار سلسله‌مراتبی
- نقطه داده
- برچسب داده
- رنگ شاخه
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه داده‌های سلسله‌مراتبی ایجاد کنید و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای Node.js از طریق Java سفارشی‌سازی کنید."
---
## **مرور کلی**

نمودارهای Treemap و Sunburst داده‌های سلسله‌مراتبی یک‌نوعی را نمایش می‌دهند، اما از چینش‌های متفاوتی استفاده می‌کنند. یک Treemap سلسله‌مراتب را به‌صورت مستطیل‌های تو در تو می‌کشد که مساحت آن‌ها مقدار برگ‌ها را نشان می‌دهد. یک Sunburst آن را به‌صورت حلقه‌های متحدمرکز نمایش می‌دهد: گروه‌های سطح بالا نزدیک به مرکز قرار دارند و دسته‌های برگ در حلقه بیرونی هستند.

در Aspose.Slides برای Node.js از طریق Java، هر مقدار عددی یک [ChartDataPoint](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/) است. متد [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله آن نگاشت را توضیح می‌دهد و نشان می‌دهد چگونه هر دو نوع نمودار را از همان داده‌های نمونه ایجاد و قالب‌بندی کنیم.

![یک نمودار Treemap با شاخه‌های Consumer و Business](treemap-hierarchy.png)

![یک نمودار Sunburst با همان سلسله‌مراتب Consumer و Business](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

نمونه زیر دارای سه سطح دسته و یک سری عددی است:

| شاخه | سرشاخه | برگ | درآمد |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

هر ردیف یک دسته برگ و یک نقطه داده ایجاد می‌کند. سطوح گروه‌بندی دسته مسیر از آن برگ تا والدینش را توصیف می‌کند. برای ردیف اول مسیر `Consumer > Computers > Laptops` است.

شاخص‌های بازگردانده‌شده توسط [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) از برگ به سمت بالا هستند:

| `getDataPointLevels()` index | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | مستطیل مقدار | بخش حلقه بیرونی |
| `1` | سرشاخه | مستطیل یا سرصفحه والد | بخش حلقه میانی |
| `2` | شاخه | مستطیل یا سرصفحه سطح بالا | بخش حلقه داخلی |

این ترتیب برای هر دو نوع نمودار یکسان است، حتی اگر چینش بصری آن‌ها متفاوت باشد. یک بخش والد توسط چندین برگ به اشتراک گذاشته می‌شود. برای قالب‌بندی آن، از سطح متناظر اولین نقطه داده در آن گروه استفاده کنید. به‌عنوان مثال، شاخه `Consumer` با نقطه `Laptops` شروع می‌شود، در حالی که سرشاخه `Software` با نقطه `Licenses` شروع می‌شود. نگهداری مراجع به این نقاط واضح‌تر و ایمن‌تر است نسبت به استفاده از عبارات بدون توضیح مانند `dataPoints.get_Item(0)` یا `dataPoints.get_Item(6)`.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap را در اسلاید اول و یک Sunburst را در اسلاید دوم می‌سازد. این مثال سلسله‌مراتب را می‌سازد، مقدار `Tablets` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح انتخابی اعمال می‌کند، برچسب شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می‌کند.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // افزودن دسته‌های برگ. یک مورد گروه‌بندی فقط زمانی تنظیم می‌شود که گروه جدیدی آغاز شود;
        // دسته‌های بعدی تا زمانی که مورد دیگری تنظیم شود در همان گروه باقی می‌مانند.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // نمایش دسته و مقدار روی برگ Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // قالب‌بندی شاخه Consumer از طریق اولین برگ در آن شاخه.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // قالب‌بندی سرشاخه Software از طریق اولین برگ در آن سرشاخه.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از بخش‌های حلقه‌ای استفاده می‌کند.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سلول‌های دسته و سلول‌های مقدار از همان ردیف کاربرگ استفاده می‌کنند، بنابراین موقعیت‌های مجموعه آن‌ها هم‌راستاست. وقتی با یک نمودار موجود کار می‌کنید نه اینکه یک نمودار جدید بسازید، ابتدا ردیف‌های دسته را بررسی کنید و مراجع نامگذاری‌شده به نقاط داده و سطوحی که قصد قالب‌بندی آن‌ها را دارید ذخیره نمایید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- Treemap برای انتقال مقدار از مساحت و برای انتقال سلسله‌مراتب از مستطیل‌های تو در تو استفاده می‌کند. متد [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) نحوه نمایش برچسب‌های والد را در این نوع نمودار کنترل می‌کند.
- Sunburst برای انتقال مقدار از زاویه و برای انتقال سلسله‌مراتب از عمق حلقه استفاده می‌کند. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) برچسب‌های حلقه آن را کنترل نمی‌کند.
- هر دو نوع نمودار از سطوح گروه‌بندی دسته یکسان و از ترتیب برگ‑به‑والد بازگردانده‌شده توسط [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) استفاده می‌کنند، بنابراین کد ساخت داده و قالب‌بندی سطوح می‌تواند به‌اشتراک گذاشته شود.
- مقدار والدها از برگ‌های فرزندشان محاسبه می‌شود. نقاط عددی جداگانه برای شاخه‌ها یا سرشاخه‌ها اضافه نکنید.

### **مرتب‌سازی و ترتیب بخش‌ها**

موتور چینش نمودار مکان نهایی مستطیل‌ها و بخش‌های حلقه را تعیین می‌کند. ردیف‌های دسته مرتبط را قبل از افزودن به هم بچینید، اما به موقعیت خاص مستطیل یا زاویه شروع وابسته نباشید. اگر ترتیب معنایی دارد، آن را در برچسب‌ها بگنجانید یا از نوع نموداری استفاده کنید که محور دسته صریح داشته باشد.

### **تم و رنگ‌های ثابت**

سطوح نمودار قالب‌ نشده رنگ‌ها را از تم ارائه می‌گیرند. مثال از پر شدن‌های RGB صریح برای خروجی پیش‌بینی‌شده استفاده می‌کند. اگر می‌خواهید نمودار تغییر تم را دنبال کند، به‌جای مقادیر RGB ثابت از رنگ‌های طرح‌بندی استفاده کنید و از بازنویسی هر سطح خودداری کنید. همچنین پس از تغییر پر شدن یک شاخه یا سرشاخه، تضاد برچسب را بررسی نمایید.

### **برچسب‌ها و فضای موجود**

PowerPoint ممکن است برچسب‌ها را هنگامیکه یک بخش خیلی کوچک باشد پنهان یا کوتاه کند. افزایش اندازه نمودار، کوتاه کردن نام‌های دسته یا نمایش تعداد کمتر فیلدهای برچسب معمولاً نتیجه واضح‌تری می‌دهد. یک برچسب می‌تواند نام دسته، نام سری و مقدار را از طریق [DataLabelFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat/) ترکیب کند، اما فعال‌سازی تمام فیلدها اغلب خوانایی نمودارهای سلسله‌مراتبی را دشوار می‌کند.

### **صادرات و رندرینگ**

ذخیره به فرمت PPTX نمودار را ویرایش‌پذیر نگه می‌دارد. وقتی Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پر شدن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی قلم‌ها و اختلافات کوچک در فضای چیدمان می‌تواند بسته‌بندی خطوط یا نمایان شدن برچسب را تغییر دهد، بنابراین قلم‌های لازم را نصب کنید و اهداف مهم صادرات را تأیید نمایید.

## **سؤالات متداول**

**چرا تغییر یک سطح والد بر چندین برگ تأثیر می‌گذارد؟**

یک شاخه یا سرشاخه یک بخش بصری مشترک است. می‌توان به [ChartDataPointLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatapointlevel/) آن از طریق یک برگ فرزند دست یافت، اما قالب‌بندی مربوط به بخش والد به‌اشتراک‌گذاری‌شده است نه فقط به آن برگ.

**چرا یک برچسب داده غائب است؟**

ابتدا فیلدهای مورد نیاز را در شیء [DataLabelFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat/) برچسب فعال کنید. سپس بررسی کنید که آیا بخش فضای کافی دارد یا نه. چیدمان برچسب والد در Treemap، ابعاد نمودار، طول برچسب، اندازه قلم و تعداد فیلدهای فعال همگی بر قابلیت نمایش برچسب تأثیر دارند.

**آیا می‌توانم ترتیب دقیق یا مختصات بخش‌ها را تنظیم کنم؟**

می‌توانید ترتیب ردیف منبع را کنترل کنید و هر گروه را به‌صورت متصل نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زاویه‌های دقیق Sunburst را اختصاص دهید. موتور چینش نمودار این مقادیر را از سلسله‌مراتب، مقادیر و فضای موجود محاسبه می‌کند.

**چرا پس از تغییر تم ارائه رنگ‌ها تغییر می‌کنند؟**

پر شدن‌های مبتنی بر تم برای پیروی از پالت ارائه طراحی شده‌اند. برای سطوحی که باید ثابت بمانند، رنگ‌های RGB صریح اعمال کنید یا هنگام انطباق با تم جدید، از رنگ‌های طرح‌بندی استفاده کنید.

**آیا قالب‌بندی سفارشی در صادرات به PDF و تصویر حفظ می‌شود؟**

بله، پر شدن‌ها و تنظیمات برچسب پشتیبانی‌شده در طول رندر گنجانده می‌شوند. برای نتایج یکدست بین سیستم‌ها، قلم‌های مورد نیاز را در دسترس قرار دهید و اندازه نهایی صادرات را آزمایش کنید، زیرا برازش برچسب به چیدمان وابسته است.

## **موارد مرتبط**

- [Create Treemap charts](/slides/fa/nodejs-java/create-chart/#creating-tree-map-charts)
- [Create Sunburst charts](/slides/fa/nodejs-java/create-chart/#creating-sunburst-charts)
- [Export presentation charts](/slides/fa/nodejs-java/export-chart/)
- [Manage presentation themes](/slides/fa/nodejs-java/presentation-theme/)