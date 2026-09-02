---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در Android
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/androidjava/data-points-of-treemap-and-sunburst-chart/
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
- Android
- Java
- Aspose.Slides
description: "بیاموزید چگونه داده‌های سلسله‌مراتبی ایجاد کرده و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای Android از طریق Java سفارشی کنید."
---
## **بررسی کلی**

نمودارهای Treemap و Sunburst داده‌های سلسله‌مراتبی از یک نوع را نمایش می‌دهند، اما از طرح‌بندی‌های متفاوتی استفاده می‌کنند. یک Treemap سلسله‌مراتب را به شکل مستطیل‌های تو در تو ترسیم می‌کند که مساحت آن‌ها مقدار برگ‌ها را نشان می‌دهد. یک Sunburst آن را به شکل حلقه‌های متحد‌المرکز ترسیم می‌کند: گروه‌های سطح بالایی در نزدیکی مرکز قرار دارند و دسته‌های برگ در حلقه بیرونی ظاهر می‌شوند.

در Aspose.Slides برای Android از طریق Java، هر مقدار عددی یک [IChartDataPoint](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/) است. متد [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله آن نگاشت را توضیح می‌دهد و نشان می‌دهد چگونه هر دو نوع نمودار را از همان داده‌های نمونه ایجاد و قالب‌بندی کرد.

![نمودار Treemap با شاخه‌های Consumer و Business](treemap-hierarchy.png)

![نمودار Sunburst با همان سلسله‌مراتب Consumer و Business](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

نمونه‌ای که در ادامه استفاده می‌شود شامل سه سطح دسته و یک سری عددی است:

| شاخه | شاخه‌فرعی | برگ | درآمد |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

هر ردیف یک دسته برگ و یک نقطه داده ایجاد می‌کند. سطوح گروه‌بندی دسته مسیر برگ تا والدین آن را توصیف می‌کنند. برای ردیف اول، مسیر `Consumer > Computers > Laptops` است.

شاخص‌هایی که توسط [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) برگردانده می‌شوند از برگ به سمت بالا پیش می‌روند:

| `getDataPointLevels()` شاخص | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | مستطیل مقدار | قطعه حلقه خارجی |
| `1` | شاخه‌فرعی | مستطیل یا سرآیند والد | قطعه حلقه میانی |
| `2` | شاخه | مستطیل یا سرآیند سطح بالایی | قطعه حلقه داخلی |

این ترتیب برای هر دو نوع نمودار یکسان است حتی اگر طرح‌بندی‌های بصری متفاوت باشند. یک قطعه والد بین چندین برگ مشترک است. برای قالب‌بندی آن، از سطح متناظر اولین نقطه داده در آن گروه استفاده کنید. به عنوان مثال، شاخه `Consumer` با نقطه `Laptops` شروع می‌شود، در حالی که شاخه‌فرعی `Software` با نقطه `Licenses` شروع می‌شود. نگهداری مراجع به آن نقاط واضح‌تر و ایمن‌تر از استفاده عبارات بدون توضیح مثل `dataPoints.get_Item(0)` یا `dataPoints.get_Item(6)` است.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap را در اسلاید اول و یک Sunburst را در اسلاید دوم ایجاد می‌کند. این مثال سلسله‌مراتب را می‌سازد، مقدار `Tablets` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح انتخابی اعمال می‌کند، برچسب یک شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می‌نماید.

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

        // دسته‌های برگ را اضافه کنید. یک مورد گروه‌بندی فقط زمانی تنظیم می‌شود که گروه جدیدی شروع شود;
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

        // نمایش دسته و مقدار روی برگ Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // قالب‌بندی شاخه Consumer از طریق اولین برگ در آن شاخه.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // قالب‌بندی شاخه‌فرعی Software از طریق اولین برگ در آن شاخه‌فرعی.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از قطعات حلقه‌ای استفاده می‌کند.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سلول‌های دسته و سلول‌های مقدار از همان ردیف ورق‌کاری استفاده می‌کنند، بنابراین موقعیت‌های مجموعه آن‌ها هم‌راستاست. وقتی با یک نمودار موجود کار می‌کنید نه اینکه یکی جدید بسازید، ابتدا ردیف‌های دسته را بررسی کنید و مراجع نام‌گذاری شده به نقاط داده و سطوحی که قصد قالب‌بندی آن‌ها را دارید ذخیره کنید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- یک Treemap از مساحت برای انتقال مقدار و از مستطیل‌های تو در تو برای انتقال سلسله‌مراتب استفاده می‌کند. متد [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) نحوه نمایش برچسب‌های والد را در این نوع نمودار کنترل می‌کند.
- یک Sunburst از زاویه برای انتقال مقدار و از عمق حلقه برای انتقال سلسله‌مراتب استفاده می‌کند. متد [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) برچسب‌های حلقه آن را کنترل نمی‌کند.
- هر دو نوع نمودار از یک سطوح گروه‌بندی دسته و همان ترتیب برگ‑به‑والد برگردانده شده توسط [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) استفاده می‌کنند، بنابراین می‌توان کد ساخت داده و قالب‌بندی سطح را به اشتراک گذاشت.
- مقادیر والد از برگ‌های فرعی محاسبه می‌شوند. برای شاخه‌ها یا شاخه‌فرعی‌ها نقطه عددی جداگانه اضافه نکنید.

### **مرتب‌سازی و ترتیب قطعات**

موتور طرح‌بندی نمودار مکان نهایی مستطیل‌ها و قطعات حلقه را تعیین می‌کند. ردیف‌های دسته مرتبط را قبل از افزودن کنار هم قرار دهید، اما به موقعیت خاص مستطیل یا زاویه شروع وابسته نشوید. اگر توالی معنی دارد، آن را در برچسب‌ها بگنجانید یا از نوع نموداری استفاده کنید که محور دسته صریح داشته باشد.

### **تم و رنگ‌های ثابت**

سطوح قالب‌بندی نشده نمودار رنگ‌ها را از تم ارائه به ارث می‌برند. مثال از پر کردن‌های RGB صریح برای خروجی پیش‌بینی‌پذیر استفاده می‌کند. اگر می‌خواهید نمودار با تغییرات تم سازگار باشد، به جای مقادیر ثابت RGB از رنگ‌های طرح‌بندی استفاده کنید و از بازنویسی همه سطوح خودداری کنید. همچنین پس از تغییر پر کردن یک شاخه یا شاخه‌فرعی، کنتراست برچسب را بررسی کنید.

### **برچسب‌ها و فضای موجود**

PowerPoint ممکن است برچسب‌ها را مخفی یا کوتاه کند وقتی یک قطعه خیلی کوچک باشد. افزایش اندازه نمودار، کوتاه کردن نام دسته یا نمایش تعداد کمتر فیلد برچسب معمولاً نتیجه واضح‌تری می‌دهد. یک برچسب می‌تواند نام دسته، نام سری و مقدار را از طریق [IDataLabelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat/) ترکیب کند، اما فعال‌سازی تمام فیلدها اغلب باعث می‌شود نمودارهای سلسله‌مراتبی خوانایی خود را از دست بدهند.

### **صادرات و رندرینگ**

ذخیره به قالب PPTX نمودار را ویرایش‌پذیر نگه می‌دارد. وقتی Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پر کردن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی قلم و اختلافات جزئی در فضای موجود می‌تواند ساختار خط یا نمایش برچسب را تغییر دهد، بنابراین قلم‌های مورد نیاز را نصب کنید و اهداف مهم صادرات را بررسی کنید.

## **سوالات متداول**

**چرا تغییر یک سطح والد بر چندین برگ تاثیر می‌گذارد؟**

یک شاخه یا شاخه‌فرعی یک قطعه بصری مشترک است. می‌توان از طریق یک برگ فرعی به [IChartDataPointLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapointlevel/) آن دست یافت، اما قالب‌بندی به قطعه والد مشترک تعلق دارد نه فقط به آن برگ.

**چرا برچسب داده‌ای نمایش داده نمی‌شود؟**

اول فیلدهای مورد نیاز را در شیء [IDataLabelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat/) برچسب فعال کنید. سپس بررسی کنید آیا قطعه فضای کافی دارد یا خیر. طرح‌بندی برچسب والد Treemap، ابعاد نمودار، طول برچسب، اندازه قلم و تعداد فیلدهای فعال همگی بر نمایش برچسب تاثیر دارند.

**آیا می‌توانم ترتیب یا مختصات دقیق قطعات را تنظیم کنم؟**

می‌توانید ترتیب ردیف منبع را کنترل کنید و هر گروه را به صورت متصل نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زوایای دقیق Sunburst را انتساب دهید. موتور طرح‌بندی آنها را بر اساس سلسله‌مراتب، مقادیر و فضای موجود محاسبه می‌کند.

**چرا رنگ‌ها پس از تغییر تم ارائه تغییر می‌کنند؟**

پر کردن‌های مبتنی بر تم برای پیروی از پالت ارائه طراحی شده‌اند. رنگ‌های RGB صریح را به سطوحی که باید ثابت بمانند اعمال کنید یا هنگام سازگار شدن با تم جدید از رنگ‌های طرح‌بندی استفاده کنید.

**آیا قالب‌بندی سفارشی در صادرات به PDF و تصویر حفظ می‌شود؟**

بله، پر کردن‌ها و تنظیمات برچسب پشتیبانی‌شده در هنگام رندر گنجانده می‌شوند. برای نتایج سازگار بین سیستم‌ها، قلم‌های مورد نیاز را در دسترس قرار دهید و اندازه نهایی صادرات را تست کنید، زیرا تناسب برچسب به طرح‌بندی وابسته است.

## **موارد مرتبط**

- [ایجاد نمودارهای Treemap](/slides/fa/androidjava/create-chart/#create-tree-map-charts)
- [ایجاد نمودارهای Sunburst](/slides/fa/androidjava/create-chart/#create-sunburst-charts)
- [صادرات نمودارهای ارائه](/slides/fa/androidjava/export-chart/)
- [مدیریت تم‌های ارائه](/slides/fa/androidjava/presentation-theme/)