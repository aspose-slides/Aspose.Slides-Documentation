---
title: سفارشی‌سازی نقاط داده در نمودارهای Treemap و Sunburst در Python
linktitle: نقاط داده در نمودارهای Treemap و Sunburst
type: docs
url: /fa/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- نمودار treemap
- نمودار sunburst
- نمودار سلسله‌مراتبی
- نقطه داده
- برچسب داده
- رنگ شاخه
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه داده‌های سلسله‌مراتبی را ایجاد کنید و سطوح، برچسب‌ها و رنگ‌ها را در نمودارهای Treemap و Sunburst با Aspose.Slides برای Python از طریق .NET سفارشی کنید."
---
## **نمای کلی**

نمودارهای Treemap و Sunburst داده‌های سلسله‌مراتبی مشابهی را نمایش می‌دهند، اما از چیدمان‌های متفاوتی استفاده می‌کنند. یک Treemap سلسله‌مراتب را به‌صورت مستطیل‌های تو در تو می‌کشد که مساحت آن‌ها مقدار برگ‌ها را نشان می‌دهد. یک Sunburst آن را به‌صورت حلقه‌های متحدالمرکز می‌کشد: گروه‌های سطح بالا نزدیک به مرکز هستند و دسته‌های برگ در حلقه بیرونی قرار می‌گیرند.

در Aspose.Slides برای Python از طریق .NET، هر مقدار عددی یک [ChartDataPoint](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/) است. مجموعه‌ی [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) دسترسی به برگ و گروه‌های والد آن را فراهم می‌کند. این مقاله آن نگاشت را توضیح می‌دهد و نشان می‌دهد چگونه هر دو نوع نمودار را از داده‌های نمونه یکسان ایجاد و قالب‌بندی کنیم.

![نمودار Treemap با شاخه‌های Consumer و Business](treemap-hierarchy.png)

![نمودار Sunburst با همان سلسله‌مراتب Consumer و Business](sunburst-hierarchy.png)

## **درک دسته‌ها، نقاط داده و سطوح**

نمونه‌ای که در ادامه استفاده می‌شود شامل سه سطح دسته و یک سری عددی است:

| شاخه | پایه | برگ | درآمد |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

هر ردیف یک دسته برگ و یک نقطه داده ایجاد می‌کند. سطوح گروه‌بندی دسته مسیر از آن برگ به والدینش را توصیف می‌کند. برای ردیف اول، مسیر `Consumer > Computers > Laptops` است.

شاخص‌ها در [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) از برگ به سمت بالا شمارش می‌شوند:

| `data_point_levels` شاخص | سطح منطقی | نمایش Treemap | نمایش Sunburst |
| ---: | --- | --- | --- |
| `0` | برگ | مستطیل مقدار | بخش حلقه بیرونی |
| `1` | پایه | مستطیل والد یا سرصفحه | بخش حلقه میانی |
| `2` | شاخه | مستطیل سطح‑بالا یا سرصفحه | بخش حلقه داخلی |

این ترتیب برای هر دو نوع نمودار یکسان است، حتی اگر چیدمان بصری آن‌ها متفاوت باشد. یک بخش والد توسط چندین برگ به‌اشتراک گذاشته می‌شود. برای قالب‌بندی آن، از سطح مربوط به اولین نقطه داده در آن گروه استفاده کنید. به‌عنوان مثال، شاخه `Consumer` با نقطه `Laptops` آغاز می‌شود، در حالی که پایه `Software` با نقطه `Licenses` شروع می‌شود. نگهداری مراجع به این نقاط، واضح‌تر و ایمن‌تر از استفاده از عبارات نامفهوم مانند `data_points[0]` یا `data_points[6]` است.

## **ایجاد و سفارشی‌سازی هر دو نوع نمودار**

مثال کامل زیر یک Treemap در اسلاید اول و یک Sunburst در اسلاید دوم ایجاد می‌کند. سلسله‌مراتب را می‌سازد، مقدار `Tablets` را نمایش می‌دهد، رنگ‌های ثابت را به سطوح انتخابی اعمال می‌کند، برچسب یک شاخه را قالب‌بندی می‌کند و ارائه را ذخیره می‌کند.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # دسته‌های برگ را اضافه کنید. یک آیتم گروه‌بندی تنها وقتی یک گروه جدید آغاز می‌شود تنظیم می‌شود؛ دسته‌های بعدی تا زمانی که آیتم دیگری تنظیم شود در همان گروه باقی می‌مانند.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # دسته‌بندی و مقدار را در برگ Tablets نمایش دهید.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # شاخه Consumer را از طریق اولین برگ در آن شاخه قالب‌بندی کنید.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # قالب‌بندی پایه Software از طریق اولین برگ در آن پایه.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout بر برچسب‌های والد Treemap تأثیر می‌گذارد؛ Sunburst از بخش‌های حلقه‌ای استفاده می‌کند.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

سلول‌های دسته و سلول‌های مقدار از همان ردیف کاربرگ استفاده می‌کنند، بنابراین موقعیت‌های مجموعه آن‌ها هم‌راستا می‌ماند. وقتی با یک نمودار موجود کار می‌کنید نه اینکه یک نمودار جدید بسازید، ابتدا ردیف‌های دسته را بررسی کنید و مراجع نام‌دار به نقاط داده و سطوحی که قصد قالب‌بندی آن‌ها را دارید، ذخیره کنید.

## **رفتار و ملاحظات عملی**

### **تفاوت‌های Treemap و Sunburst**

- یک Treemap برای انتقال مقدار از مساحت و برای انتقال سلسله‌مراتب از مستطیل‌های تو در تو استفاده می‌کند. ویژگی [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/parent_label_layout/) نحوه نمایش برچسب‌های والد را در این نوع نمودار کنترل می‌کند.
- یک Sunburst برای انتقال مقدار از زاویه و برای انتقال سلسله‌مراتب از عمق حلقه استفاده می‌کند. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/parent_label_layout/) برچسب‌های حلقهٔ آن را کنترل نمی‌کند.
- هر دو نوع نمودار از سطوح گروه‌بندی دسته یکسان و از ترتیب برگ‑به‑والد در `data_point_levels` استفاده می‌کنند، بنابراین کد ساخت داده و قالب‌بندی سطح می‌تواند مشترک باشد.
- مقادیر والد از برگ‌های فرزندشان محاسبه می‌شود. نقاط عددی جداگانه برای شاخه‌ها یا پایه‌ها اضافه نکنید.

### **مرتب‌سازی و ترتیب بخش‌ها**

موتور چیدمان نمودار مکان نهایی مستطیل‌ها و بخش‌های حلقه را تعیین می‌کند. ردیف‌های دسته مرتبط را قبل از افزودن به‌هم بچسبانید، اما به موقعیت خاص مستطیل یا زاویه شروع تکیه نکنید. اگر توالی معنایی دارد، آن را در برچسب‌ها بگنجانید یا از یک نوع نمودار با محور دسته صریح استفاده کنید.

### **تم و رنگ‌های ثابت**

سطوح نمودار بدون قالب‌بندی، رنگ‌ها را از تم ارائه به ارث می‌برند. مثال از پرکردن‌های RGB صریح برای خروجی پیش‌بینی‌شده استفاده می‌کند. اگر نمودار باید تغییرات تم را دنبال کند، به‌جای مقادیر ثابت RGB از رنگ‌های طرح‌بندی استفاده کنید و از بازنویسی هر سطح جلوگیری کنید. همچنین پس از تغییر پر کردن یک شاخه یا پایه، تضاد برچسب را بررسی کنید.

### **برچسب‌ها و فضای موجود**

PowerPoint ممکن است برچسب‌ها را زمانی که یک بخش خیلی کوچک باشد، مخفی یا کوتاه کند. بزرگ‌کردن اندازه نمودار، کوتاه کردن نام‌های دسته یا نمایش فیلدهای برچسب کمتر معمولاً نتیجهٔ واضح‌تری می‌دهد. یک برچسب می‌تواند ترکیبی از نام دسته، نام سری و مقدار باشد از طریق [DataLabelFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabelformat/)، اما فعال‌سازی هر فیلد اغلب نمودارهای سلسله‌مراتی را سخت‌خوان می‌کند.

### **صادرات و رندرینگ**

ذخیره به PPTX نمودار را قابل ویرایش نگه می‌دارد. هنگامی که Aspose.Slides ارائه را به PDF یا تصویر رندر می‌کند، پرکردن‌ها و تنظیمات برچسب پشتیبانی‌شده همراه با نمودار رندر می‌شوند. جایگزینی قلم و اندکی اختلاف در فضای چیدمان موجود می‌تواند شکست خطوط یا قابلیت نمایش برچسب را تغییر دهد، بنابراین قلم‌های مورد نیاز را نصب کنید و هدف‌های مهم صادرات را تأیید کنید.

## **سوالات متداول**

**چرا تغییر یک سطح والد بر چندین برگ تأثیر می‌گذارد؟**

یک شاخه یا پایه یک بخش بصری مشترک است. می‌توان به [ChartDataPointLevel](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapointlevel/) آن از طریق یک برگ فرزند دست یافت، اما قالب‌بندی به بخش والد مشترک تعلق دارد نه فقط به همان برگ.

**چرا یک برچسب داده‌ای گم شده است؟**

اولین کار فعال‌سازی فیلدهای مورد نیاز در شیء [DataLabelFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabelformat/) برچسب است. سپس بررسی کنید آیا بخش فضای کافی دارد یا نه. چینش برچسب والد در Treemap، ابعاد نمودار، طول برچسب، اندازه قلم و تعداد فیلدهای فعال همگی بر نمایش برچسب تأثیر می‌گذارند.

**آیا می‌توانم ترتیب یا مختصات دقیق بخش‌ها را تنظیم کنم؟**

می‌توانید ترتیب ردیف منبع را کنترل کنید و هر گروه را متوالی نگه دارید، اما نمی‌توانید مستطیل‌های دقیق Treemap یا زوایای دقیق Sunburst را اختصاص دهید. موتور چیدمان نمودار آن‌ها را از سلسله‌مراتب، مقادیر و فضای موجود محاسبه می‌کند.

**چرا پس از تغییر تم ارائه رنگ‌ها تغییر می‌کنند؟**

پرکردن‌های مبتنی بر تم برای پیروی از پالت ارائه طراحی شده‌اند. رنگ‌های RGB صریح را برای سطوحی که باید ثابت بمانند اعمال کنید یا هنگام سازگار شدن با تم جدید از رنگ‌های طرح‌بندی استفاده کنید.

**آیا قالب‌بندی سفارشی در صادرات PDF و تصویر حفظ می‌شود؟**

بله، پرکردن‌ها و تنظیمات برچسب پشتیبانی‌شده در زمان رندر گنجانده می‌شوند. برای نتایج سازگار بین سیستم‌ها، قلم‌های مورد نیاز را در دسترس قرار دهید و اندازهٔ نهایی صادرات را تست کنید، زیرا قرارگیری برچسب به چیدمان وابسته است.

## **مراجعات مرتبط**

- [ایجاد نمودارهای Treemap](/slides/fa/python-net/create-chart/#create-tree-map-charts)
- [ایجاد نمودارهای Sunburst](/slides/fa/python-net/create-chart/#create-sunburst-charts)
- [صادرات نمودارهای ارائه](/slides/fa/python-net/export-chart/)
- [مدیریت تم‌های ارائه](/slides/fa/python-net/presentation-theme/)