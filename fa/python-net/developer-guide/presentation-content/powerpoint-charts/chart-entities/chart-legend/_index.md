---
title: "سفارشی‌سازی راهنمای نمودار در ارائه‌ها با پایتون"
linktitle: "راهنمای نمودار"
type: docs
url: /fa/python-net/chart-legend/
keywords:
- "راهنمای نمودار"
- "موقعیت راهنما"
- "اندازه قلم"
- "پاورپوینت"
- "ارائه"
- "پایتون"
- "Aspose.Slides"
description: "راهنمای نمودارها را با Aspose.Slides برای پایتون از طریق .NET سفارشی کنید تا ارائه‌های پاورپوینت را با قالب‌بندی راهنمای متناسب بهینه کنید."
---
## **نمای کلی**

Aspose.Slides for Python via .NET گزینه‌هایی برای سفارشی‌سازی راهنماهای نمودار در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه موقعیت و اندازه یک راهنما را تنظیم کنید، اندازه قلم کل راهنما را تعیین کنید، یک ورودی تک‌تک راهنما را قالب‌بندی کنید و ورودی‌های انتخابی را مخفی یا بازگردانید.

سؤالات متداول شامل رفتارهای مرتبط می‌شود، از جمله رزرو کردن فضا برای راهنما، نمایش برچسب‌های چندخطی و ارث‌بری قالب‌بندی از تم ارائه.

## **موقعیت‌یابی راهنما**

از ویژگی‌های [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/)، [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/)، [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) و [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) راهنما برای تعیین موقعیت و اندازه آن به صورت کسرهای ابعاد نمودار استفاده کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض به اسلاید اول اضافه می‌نماید. تقسیم مقادیر مورد نیاز جابجایی و ابعاد راهنما بر عرض و ارتفاع نمودار، آن را به مقادیر نسبی تبدیل می‌کند: راهنما ۵۰ نقطه از گوشه بالا‑چپ نمودار جابجا شده و به اندازه ۱۰۰ در ۱۰۰ نقطه تنظیم می‌شود.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # موقعیت و اندازه راهنما را نسبت به نمودار بیان کنید.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم اندازه فونت راهنما**

از [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) راهنما برای دسترسی به قالب‌بندی متن آن و تنظیم [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) به واحد نقاط استفاده کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن راهنما را به ۲۰ نقطه تنظیم می‌کند. همچنین محدودیت‌های خودکار برای محور عمودی را غیرفعال کرده و دامنه آن را از ‎‑۵ تا ۱۰ تنظیم می‌نماید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم اندازه فونت یک ورودی راهنما**

از مجموعه [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) راهنما برای دسترسی به قالب‌بندی یک ورودی خاص استفاده کنید. ایندکس‌های ورودی صفر‑پایه هستند، لذا ایندکس `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند که داده‌های پیش‌فرض آن شامل حداقل دو سری است. ورودی دوم راهنما را با متن بولد، ایتالیک و با اندازه ۲۰ نقطه و رنگ آبی قالب‌بندی می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **مخفی‌سازی ورودی‌های تک‌تک راهنما**

برای حذف یک سری کمکی از راهنما در حالی که داده‌های آن دیده می‌شوند، [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) را از طریق [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/) بر `True` تنظیم کنید. این کار تنها ورودی انتخابی راهنما را مخفی می‌کند؛ سری یا نقاط داده آن حذف نمی‌شود. تنظیم [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) بر `False`، در مقابل، تمام راهنما را مخفی می‌کند.

مثال زیر یک نمودار ستونی خوشه‌ای با چندین سری با داده‌های پیش‌فرض ایجاد می‌کند. ورودی راهنمای سری دوم (ایندکس `1`) را مخفی می‌کند و ارائه را ذخیره می‌نماید. سپس با تنظیم [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) بر `False`، ورودی را باز می‌گرداند و یک نسخه دوم ذخیره می‌کند. ستون‌ها در هر دو فایل قابل مشاهده باقی می‌مانند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # ورودی همان را بدون تغییر داده‌های نمودار بازگردانید.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

![مقایسه نموداری که تمام ورودی‌های راهنما قابل مشاهده‌اند و ورودی دوم مخفی است؛ همه ستون‌ها قابل مشاهده می‌مانند.](hide-legend-entry.png)

در نمودارهای ستونی، میله‌ای و خطی، ورودی‌های راهنما سری‌ها را شناسایی می‌کنند. در نمودارهای دایره‌ای، این ورودی‌ها نقاط داده فردی (قطعات) را شناسایی می‌کنند، بنابراین باید از [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) برای قطعه منتخب استفاده کنید. API این ویژگی را برای انواع نمودار `PIE`، `PIE3D`، `EXPLODED_PIE`، `EXPLODED_PIE3D`، `PIE_OF_PIE` و `BAR_OF_PIE` مستند می‌کند. فرض نکنید که برای نمودارهای دونات نیز اعمال می‌شود، چراکه آن‌ها در این فهرست نیستند.

## **سؤالات متداول**

**آیا می‌توانم نمودار را طوری تنظیم کنم که برای راهنما فضای اختصاص دهد به جای اینکه آن را روی ناحیه نمودار قرار دهد؟**

بله. با تنظیم [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) بر `False` می‌توانید برای راهنما فضا رزرو کنید به جای اینکه اجازه دهید بر روی ناحیه‌نمودار پوشش دهد.

**آیا می‌توانم برچسب‌های چندخطی برای راهنما داشته باشم؟**

بله. برچسب‌های طولانی می‌توانند وقتی عرض موجود کافی نیست، به خطوط بعدی شکسته شوند. همچنین می‌توانید در نام‌های سری از کاراکترهای خط جدید استفاده کنید تا شکاف خط درخواست کنید.

**چگونه می‌توانم راهنما را طوری تنظیم کنم که پیروی از طرح رنگی تم ارائه باشد؟**

رنگ‌ها، پرکردن‌ها و قلم‌های راهنما را تنظیم نکنید تا بتواند قالب‌بندی تم را به ارث ببرد. قالب‌بندی صریح تنظیمات مربوط به تم را بازنویسی می‌کند.