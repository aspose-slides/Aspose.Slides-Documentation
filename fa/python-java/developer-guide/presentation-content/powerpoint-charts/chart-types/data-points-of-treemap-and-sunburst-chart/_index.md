---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در پایتون
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/python-java/data-points-of-treemap-and-sunburst-chart/
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
- پایتون
- جاوا
- Aspose.Slides
description: "بیاموزید چگونه داده‌های سلسله‌مراتبی ایجاد کرده و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای پایتون از طریق جاوا سفارشی کنید."
---
## **مروری کلی**

نمودارهای Treemap و Sunburst داده‌های سلسله‌مراتبی یک‌نوعی را نشان می‌دهند، اما از طرح‌بندی‌های متفاوتی استفاده می‌کنند. یک Treemap سلسله‌مراتب را به‌صورت مستطیل‌های تو در تو می‌کشد که مساحت آن‌ها نشانگر مقادیر برگ‌ها است. یک Sunburst آن را به‌صورت حلقه‌های متحدمرکزی نمایش می‌دهد: گروه‌های سطح‑بالا نزدیک به مرکز قرار می‌گیرند و دسته‌های برگ در حلقهٔ خارجی هستند.

در Aspose.Slides برای Python از طریق Java، هر مقدار عددی یک [ChartDataPoint](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/) است. متد [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) آن دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله آن نگاشت را توضیح می‌دهد و نشان می‌دهد چگونه هر دو نوع نمودار را از همان دادهٔ نمونه ایجاد و قالب‌بندی کنیم.

![نمودار Treemap با شاخه‌های Consumer و Business](treemap-hierarchy.png)

![نمودار Sunburst با همان سلسله‌مراتبی Consumer و Business](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

نمونهٔ زیر دارای سه سطح دسته‌بندی و یک سری عددی است:

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

هر ردیف یک دستهٔ برگ و یک نقطه داده ایجاد می‌کند. سطوح گروه‌بندی دسته مسیر از آن برگ تا والدینش را توصیف می‌کنند. برای اولین ردیف، مسیر `Consumer > Computers > Laptops` است.

شاخص‌های بازگردانده‌شده توسط [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) از برگ به سمت بالا محاسبه می‌شوند:

| شاخص `getDataPointLevels()` | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | مستطیل مقدار | قطعهٔ حلقهٔ خارجی |
| `1` | سرشاخه | مستطیل والد یا سرعنوان | قطعهٔ حلقهٔ میانی |
| `2` | شاخه | مستطیل سطح‑بالا یا سرعنوان | قطعهٔ حلقهٔ داخلی |

این ترتیب برای هر دو نوع نمودار یکسان است حتی اگر طرح‌های بصری آن‌ها متفاوت باشد. یک بخش والد توسط چندین برگ به‌اشتراک گذاشته می‌شود. برای قالب‌بندی آن، از سطح متناظر اولین نقطه داده در آن گروه استفاده کنید. به‌عنوان مثال، شاخهٔ `Consumer` با نقطهٔ `Laptops` آغاز می‌شود، در حالی که سرشاخهٔ `Software` با نقطهٔ `Licenses` شروع می‌شود. نگهداری ارجاع به آن نقاط واضح‌تر و ایمن‌تر است نسبت به استفاده از عبارات توضیح‌نداشته مانند `data_points.get_Item(0)` یا `data_points.get_Item(6)`.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap را در اسلاید اول و یک Sunburst را در اسلاید دوم ایجاد می‌کند. این مثال سلسله‌مراتب را می‌سازد، مقدار `Tablets` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح انتخابی اعمال می‌کند، برچسب یک شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # دسته‌های برگ را اضافه کنید. یک مورد گروه‌بندی فقط زمانی تنظیم می‌شود که یک گروه جدید آغاز شود؛ دسته‌های بعدی تا زمانی که مورد دیگری تنظیم شود در همان گروه باقی می‌مانند.
        # the following categories remain in that group until another item is set.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # دسته و مقدار را بر روی برگ Tablets نشان دهید.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # شاخه Consumer را از طریق اولین برگ در آن شاخه قالب‌بندی کنید.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # سرشاخه Software را از طریق اولین برگ در آن سرشاخه قالب‌بندی کنید.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از قطعات حلقه‌ای استفاده می‌کند.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

سلول‌های دسته و سلول‌های مقدار از همان ردیف شیت استفاده می‌کنند، بنابراین موقعیت‌های مجموعهٔ آن‌ها هم‌راستا می‌ماند. وقتی با یک نمودار موجود کار می‌کنید نه اینکه ایجاد کنید، ابتدا ردیف‌های دسته را بررسی کنید و ارجاع‌های نام‌گذاری‌شده به نقاط داده و سطوحی که قصد قالب‌بندی آن‌ها را دارید ذخیره کنید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- یک Treemap از مساحت برای انتقال مقدار و از مستطیل‌های تو در تو برای انتقال سلسله‌مراتب استفاده می‌کند. متد [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setParentLabelLayout) نحوه نمایش برچسب‌های والد در این نوع نمودار را کنترل می‌کند.
- یک Sunburst از زاویه برای انتقال مقدار و از عمق حلقه برای انتقال سلسله‌مراتب استفاده می‌کند. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#setParentLabelLayout) برچسب‌های حلقهٔ آن را کنترل نمی‌کند.
- هر دو نوع نمودار از سطوح گروه‌بندی دسته یکسان و همان ترتیب برگ‑به‑والد بازگردانده‌شده توسط [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) استفاده می‌کنند، بنابراین می‌توان کد ساخت داده و قالب‌بندی سطوح را به‌اشتراک گذاشت.
- مقادیر والد از برگ‌های فرزندشان محاسبه می‌شوند. نقاط عددی جداگانه برای شاخه‌ها یا سرشاخه‌ها اضافه نکنید.

### **مرتب‌سازی و ترتیب قطعات**

موتور چینش نمودار مکان نهایی مستطیل‌ها و قطعات حلقه را تعیین می‌کند. ردیف‌های دستهٔ مرتبط را قبل از افزودن آنها کنار هم قرار دهید، اما به موقعیت خاص مستطیل یا زاویهٔ شروع وابسته نباشید. اگر توالی معنایی داشته باشد، آن را در برچسب‌ها بگنجانید یا از نوع نموداری استفاده کنید که محور دسته صریح دارد.

### **زمینه و رنگ‌های ثابت**

سطوح فورمت‌نشدهٔ نمودار رنگ‌ها را از تم ارائه به ارث می‌برند. مثال از پر کردن RGB صریح برای خروجی پیش‌بینی‌شدنی استفاده می‌کند. اگر نمودار باید تغییرات تم را دنبال کند، به‌جای مقادیر RGB ثابت از رنگ‌های طرح‌بندی استفاده کنید و از بازنویسی هر سطح خودداری کنید. همچنین پس از تغییر پر کردن یک شاخه یا سرشاخه، تضاد برچسب را بررسی کنید.

### **برچسب‌ها و فضای موجود**

PowerPoint ممکن است برچسب‌ها را مخفی یا کوتاه کند وقتی یک قطعه خیلی کوچک باشد. افزایش اندازهٔ نمودار، کوتاه کردن نام‌های دسته یا نمایش فیلدهای برچسب کمتر معمولاً نتیجهٔ واضح‌تری می‌دهد. می‌توانید برچسب را ترکیب نام دسته، نام سری و مقدار از طریق [DataLabelFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datalabelformat/) کنید، اما فعال‌سازی تمام فیلدها اغلب نمودارهای سلسله‌مراتبی را دشوار می‌کند.

### **صادرات و رندرینگ**

ذخیره به‌صورت PPTX نمودار را قابل ویرایش نگه می‌دارد. زمانی که Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پرکردن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی قلم و تفاوت‌های کوچک در فضای چیدمان موجود می‌تواند بسته‌بندی خطوط یا نمایش برچسب را تغییر دهد، بنابراین قلم‌های لازم را نصب کنید و اهداف صادرات مهم را بررسی کنید.

## **پرسش‌های متداول**

**چرا تغییر سطح والد بر چندین برگ تأثیر می‌گذارد؟**

یک شاخه یا سرشاخه یک بخش بصری مشترک است. [ChartDataPointLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatapointlevel/) آن می‌تواند از طریق یک برگ فرزند دسترسی پیدا شود، اما قالب‌بندی به بخش والد مشترک تعلق دارد نه فقط به آن برگ.

**چرا یک برچسب داده وجود ندارد؟**

اولین کار فعال‌سازی فیلدهای مورد نیاز در شیء [DataLabelFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datalabelformat/) برچسب است. سپس بررسی کنید که آیا قطعه فضای کافی دارد یا نه. چیدمان برچسب والد در Treemap، ابعاد نمودار، طول برچسب، اندازه قلم و تعداد فیلدهای فعال همه بر این که آیا برچسب قابل نمایش است یا نه تأثیر دارند.

**آیا می‌توانم ترتیب یا مختصات دقیق قطعات را تنظیم کنم؟**

می‌توانید ترتیب ردیف منبع را کنترل کنید و هر گروه را به‌صورت پیوسته نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زوایای Sunburst را اختصاص دهید. موتور چیدمان نمودار آن‌ها را از سلسله‌مراتب، مقادیر و فضای موجود محاسبه می‌کند.

**چرا رنگ‌ها بعد از تغییر تم ارائه تغییر می‌کنند؟**

پرکردن‌های مبتنی بر تم برای پیروی از پالت ارائه طراحی شده‌اند. برای سطوحی که باید ثابت بمانند، رنگ‌های RGB صریح اعمال کنید، یا هنگام سازگار شدن با تم جدید، از رنگ‌های طرح‌بندی استفاده کنید.

**آیا قالب‌بندی سفارشی در صادرات PDF و تصویر حفظ می‌شود؟**

بله، پرکردن‌ها و تنظیمات برچسب پشتیبانی‌شده در طول رندر گنجانده می‌شوند. برای نتایج سازگار در سیستم‌های مختلف، قلم‌های مورد نیاز را در دسترس بگذارید و اندازهٔ نهایی صادرات را تست کنید زیرا تناسب برچسب به چیدمان وابسته است.

## **موارد مرتبط**

- [ایجاد نمودارهای Treemap](/slides/fa/python-java/create-chart/#create-tree-map-charts)
- [ایجاد نمودارهای Sunburst](/slides/fa/python-java/create-chart/#create-sunburst-charts)
- [صادر کردن نمودارهای ارائه](/slides/fa/python-java/export-chart/)
- [مدیریت تم‌های ارائه](/slides/fa/python-java/presentation-theme/)