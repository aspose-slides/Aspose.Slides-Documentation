---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در جاوا
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/java/data-points-of-treemap-and-sunburst-chart/
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
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه داده‌های سلسله‌مراتبی ایجاد کنید و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای جاوا سفارشی کنید."
---
## **بررسی کلی**

نمودارهای Treemap و Sunburst هر دو داده‌های سلسله‌مراتبی یک نوع را نمایش می‌دهند، اما از چیدمان‌های متفاوتی استفاده می‌کنند. یک Treemap ساختار سلسله‌مراتبی را به‌صورت مستطیل‌های تو در تو می‌کشد که مساحت آن‌ها مقدار برگ‌ها را نشان می‌دهد. یک Sunburst این ساختار را به‌صورت حلقه‌های هم‌محور نشان می‌دهد: گروه‌های سطح بالایی نزدیک مرکز هستند و دسته‌های برگ در حلقهٔ بیرونی قرار می‌گیرند.

در Aspose.Slides for Java، هر مقدار عددی یک [IChartDataPoint](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/) است. متد [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله این نگاشت را توضیح داده و نشان می‌دهد چگونه هر دو نوع نمودار را از داده‌های نمونهٔ یکسان ایجاد و قالب‌بندی کنیم.

![نمودار Treemap با شاخه‌های Consumer و Business](treemap-hierarchy.png)

![نمودار Sunburst با همان سلسله‌مراتبی از Consumer و Business](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

نمونهٔ زیر دارای سه سطح دسته و یک سری عددی است:

| شاخه | شاخه فرعی | برگ | درآمد |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

هر ردیف یک دستهٔ برگ و یک نقطه داده ایجاد می‌کند. سطوح گروه‌بندی دسته مسیر از همان برگ تا والدینش را توصیف می‌کند. برای ردیف اول، مسیر `Consumer > Computers > Laptops` است.

شاخص‌های برگردانده‌شده توسط [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) از برگ به سمت بالا می‌باشند:

| شاخص `getDataPointLevels()` | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | مستطیل مقدار | قسمت حلقهٔ بیرونی |
| `1` | شاخه فرعی | مستطیل یا سرصفحهٔ والد | قسمت حلقهٔ متوسط |
| `2` | شاخه | مستطیل یا سرصفحهٔ سطح‑بالا | قسمت حلقهٔ داخلی |

این ترتیب برای هر دو نوع نمودار یکسان است، حتی اگر چیدمان بصری آن‌ها متفاوت باشد. یک بخش والد توسط چندین برگ به اشتراک گذاشته می‌شود. برای قالب‌بندی آن، از سطح مربوط به اولین نقطه دادهٔ آن گروه استفاده کنید. به عنوان مثال، شاخهٔ `Consumer` با نقطهٔ `Laptops` شروع می‌شود، در حالی که شاخهٔ `Software` با نقطهٔ `Licenses` آغاز می‌شود. نگهداری مراجع به این نقاط واضح‌تر و ایمن‌تر از استفاده از عبارات نامشخصی مثل `dataPoints.get_Item(0)` یا `dataPoints.get_Item(6)` است.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap را در اسلاید اول و یک Sunburst را در اسلاید دوم ایجاد می‌کند. این مثال سلسله‌مراتب را می‌سازد، مقدار `Tablets` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح منتخب اعمال می‌کند، برچسب یک شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می‌کند.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // دسته‌های برگ را اضافه کنید. یک مورد گروه‌بندی فقط زمانی تنظیم می‌شود که یک گروه جدید شروع شود;
        // دسته‌های بعدی تا زمانی که مورد دیگری تنظیم شود در همان گروه باقی می‌مانند.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // دسته و مقدار را در برگ Tablets نمایش دهید.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // فرمت شاخه Consumer را از طریق اولین برگ در آن شاخه تنظیم کنید.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // فرمت شاخه Software را از طریق اولین برگ در آن شاخه تنظیم کنید.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از بخش‌های حلقه‌ای استفاده می‌کند.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سلول‌های دسته و سلول‌های مقدار از یک ردیف شیت یکسان استفاده می‌کنند، بنابراین موقعیت‌های مجموعهٔ آن‌ها همچنان هم‌راستا می‌ماند. وقتی به جای ایجاد نمودار جدید، با یک نمودار موجود کار می‌کنید، ابتدا ردیف‌های دسته را بررسی کنید و مراجع نام‌دار به نقاط داده و سطوحی که قصد قالب‌بندی آن‌ها را دارید، ذخیره کنید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- Treemap از مساحت برای انتقال مقدار و مستطیل‌های تو در تو برای انتقال سلسله‌مراتب استفاده می‌کند. متد [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) کنترل می‌کند که برچسب‌های والد در این نوع نمودار چگونه نمایش داده شوند.
- Sunburst از زاویه برای انتقال مقدار و عمق حلقه برای انتقال سلسله‌مراتب استفاده می‌کند. متد [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) برچسب‌های حلقهٔ آن را کنترل نمی‌کند.
- هر دو نوع نمودار از سطوح گروه‌بندی دسته یکسان و همان ترتیب برگ‑به‑والد برگردانده‌شده توسط [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) استفاده می‌کنند، بنابراین کد ساخت داده و قالب‌بندی سطح می‌تواند به اشتراک گذاشته شود.
- مقادیر والد از برگ‌های فرعی محاسبه می‌شوند. نقاط عددی جداگانه برای شاخه‌ها یا شاخه‌های فرعی اضافه نکنید.

### **مرتب‌سازی و ترتیب قطعه‌ها**

موتور چیدمان نمودار مکان نهایی مستطیل‌ها و قطعه‌های حلقه را تعیین می‌کند. قبل از افزودن ردیف‌ها، ردیف‌های مرتبط را کنار هم قرار دهید، اما به موقعیت خاص مستطیل یا زاویهٔ شروع وابسته نباشید. اگر ترتیب معنایی داشته باشد، آن را در برچسب‌ها بگنجانید یا از نوع نموداری استفاده کنید که محور دستهٔ صریح داشته باشد.

### **قالب و رنگ‌های ثابت**

سطوح قالب‌بندی‌نشدهٔ نمودار رنگ‌ها را از تم ارائه به ارث می‌برند. مثال از پر کردن‌های RGB صریح برای خروجی پیش‌بینی‌شدنی استفاده می‌کند. اگر نیاز دارید نمودار با تغییر تم‌ها هم‌راستا باشد، به‌جای مقادیر RGB ثابت از رنگ‌های طرح‌بندی (scheme) استفاده کنید و از بازنویسی هر سطح خودداری کنید. پس از تغییر رنگ یک شاخه یا شاخهٔ فرعی، کنتراست برچسب را نیز بررسی کنید.

### **برچسب‌ها و فضای موجود**

PowerPoint ممکن است هنگام کوچک بودن یک قطعه، برچسب‌ها را مخفی یا کوتاه کند. افزایش سایز نمودار، کوتاه‌کردن نام دسته‌ها یا نمایش کمترین فیلد برچسب معمولاً نتیجهٔ واضح‌تری می‌دهد. می‌توان با استفاده از [IDataLabelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabelformat/) نام دسته، نام سری و مقدار را ترکیب کرد، اما فعال‌سازی همه فیلدها معمولاً نمودارهای سلسله‌مراتبی را خواندنی نمی‌کند.

### **خروجی و رندرینگ**

ذخیره به‌صورت PPTX نمودار را قابل ویرایش نگه می‌دارد. وقتی Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پر کردن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی فونت و تفاوت‌های جزئی در فضای موجود می‌تواند بسته‌بندی خطوط یا نمایان شدن برچسب را تغییر دهد، بنابراین فونت‌های مورد نیاز را نصب کنید و هدف‌های خروجی مهم را تأیید نمایید.

## **پرسش‌های متداول**

**چرا تغییر یک سطح والد بر چندین برگ تأثیر می‌گذارد؟**

یک شاخه یا شاخهٔ فرعی بخش بصری مشترکی است. می‌توان از طریق برگ فرعی به [IChartDataPointLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatapointlevel/) آن دست یافت، اما قالب‌بندی به بخش والد مشترک تعلق دارد نه تنها به همان برگ.

**چرا یک برچسب داده غیب است؟**

ابتدا فیلدهای مورد نیاز را در شیء [IDataLabelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabelformat/) برچسب فعال کنید. سپس بررسی کنید که آیا قطعه فضای کافی دارد یا خیر. چیدمان برچسب والد در Treemap، ابعاد نمودار، طول برچسب، اندازهٔ فونت و تعداد فیلدهای فعال 모두 بر نمایش برچسب تأثیر می‌گذارند.

**آیا می‌توان ترتیب یا مختصات دقیق قطعه‌ها را تنظیم کرد؟**

می‌توانید ترتیب ردیف‌های منبع را کنترل کنید و هر گروه را متصل نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زوایای دقیق Sunburst را اختصاص دهید. موتور چیدمان این مقادیر را از سلسله‌مراتب، مقادیر و فضای موجود محاسبه می‌کند.

**چرا پس از تغییر تم ارائه رنگ‌ها تغییر می‌کنند؟**

پر کردن‌های مبتنی بر تم برای پیروی از پالتی ارائه طراحی شده‌اند. برای سطوحی که باید ثابت بمانی، رنگ‌های RGB صریح اعمال کنید یا هنگام سازگاری با تم جدید، از رنگ‌های scheme استفاده کنید.

**آیا قالب‌بندی سفارشی در خروجی‌های PDF و تصویر حفظ می‌شود؟**

بله، پر کردن‌ها و تنظیمات برچسب پشتیبانی‌شده در طول رندر گنجانده می‌شوند. برای نتایج سازگار بین سیستم‌ها، فونت‌های مورد نیاز را در دسترس قرار دهید و اندازهٔ نهایی خروجی را تست کنید، زیرا تناسب برچسب به چیدمان وابسته است.

## **موارد مرتبط**

- [Create Treemap charts](/slides/fa/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/fa/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/fa/java/export-chart/)
- [Manage presentation themes](/slides/fa/java/presentation-theme/)