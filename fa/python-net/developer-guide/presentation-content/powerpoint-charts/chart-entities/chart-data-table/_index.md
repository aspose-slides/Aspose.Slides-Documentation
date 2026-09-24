---
title: سفارشی‌سازی جداول داده‌های نمودار در ارائه‌های پایتون
linktitle: جدول داده
type: docs
url: /fa/python-net/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "قلم‌ها، حاشیه‌ها و کلیدهای افسانه‌ای جدول داده‌های نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای پایتون از طریق .NET سفارشی کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via .NET به شما امکان می‌دهد جدول داده‌های یک نمودار را نمایش دهید و قالب‌بندی متن، حاشیه‌ها و کلیدهای افسانه‌ای را سفارشی کنید. این مقاله توضیح می‌دهد چگونه جدول را فعال کنید، متن آن را قالب‌بندی کنید، هر نوع حاشیه را کنترل کنید و کلیدهای افسانه‌ای را نشان یا مخفی کنید. مثال‌ها نمودارهای پیکربندی‌شده را در فایل‌های PPTX ذخیره می‌کنند.

## **تنظیم ویژگی‌های قلم**

برای نمایش جدول داده‌های یک نمودار، [has_data_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/has_data_table/) را روی `True` تنظیم کنید. برای دسترسی به جدول و پیکربندی قالب‌بندی متن از [chart_data_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/chart_data_table/) استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید.
1. یک نمودار ستونی خوشه‌ای به اسلاید اول اضافه کنید.
1. جدول داده‌های نمودار را فعال کنید.
1. متن ضخیم را با [font_bold](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/font_bold/) فعال کنید و برای متن 20 پوینت، [font_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/font_height/) را روی `20` تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر به فایل `test.pptx` در پوشه کاری که حداقل یک اسلاید دارد نیاز دارد. این مثال یک نمودار با داده‌های پیش‌فرض را در موقعیت (50, 50) با عرض 600 پوینت و ارتفاع 400 پوینت اضافه می‌کند. فایل `output.pptx` ذخیره‌شده شامل نمودار با جدول داده فعال و تنظیمات قلم مشخص‌شده است.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سفارشی‌سازی حاشیه‌های جدول داده‌ها**

جدول را با [Chart.has_data_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/has_data_table/) فعال کنید و از طریق [Chart.chart_data_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/chart_data_table/) به آن دسترسی پیدا کنید. می‌توانید سه نوع حاشیه را به‌صورت مستقل کنترل کنید:

- [has_border_horizontal](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datatable/has_border_horizontal/) حاشیه‌های افقی سلول‌ها را کنترل می‌کند.
- [has_border_vertical](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datatable/has_border_vertical/) حاشیه‌های عمودی سلول‌ها را کنترل می‌کند.
- [has_border_outline](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datatable/has_border_outline/) حاشیه بیرونی جدول را کنترل می‌کند.

هر ویژگی را به `True` تنظیم کنید تا حاشیه آن نمایش داده شود یا به `False` تنظیم کنید تا مخفی شود. مثال زیر یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند، حاشیه‌های افقی و حاشیه بیرونی را نمایش می‌دهد و حاشیه‌های عمودی را مخفی می‌کند. نیازی به فایل ورودی ندارد. موقعیت و اندازه نمودار بر حسب پوینت مشخص شده‌اند.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

مقایسه زیر از همان داده‌های نمودار و تنظیم کلید افسانه‌ای در چهار حالت استفاده می‌کند. از حالت همه حاشیه‌ها فعال شروع می‌شود و هر گونه‌نامه باقی‌مانده یک ویژگی حاشیه را غیرفعال می‌کند. حالت پایین‑چپ تنظیمات حاشیه مثال را تطبیق می‌دهد.

![جداول داده‌های نمودار با تمام حاشیه‌ها فعال، بدون حاشیه‌های افقی، بدون حاشیه‌های عمودی، و بدون حاشیه بیرونی](data-table-borders.png)

## **نمایش یا مخفی‌سازی کلیدهای افسانه‌ای**

کلیدهای افسانه‌ای نشانگرهای رنگی کوچک کنار نام سری‌ها در جدول داده هستند. آنها به خوانندگان کمک می‌کنند هر ردیف جدول را به یک سری نمودار ارتباط دهند. برای نمایش این نشانگرها [show_legend_key](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datatable/show_legend_key/) را روی `True` تنظیم کنید یا برای مخفی کردن آنها به `False` تغییر دهید.

افسانه جداگانه نمودار توسط [Chart.has_legend](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/has_legend/) کنترل می‌شود. این تنظیمات مستقل هستند: مخفی کردن افسانه جداگانه کلیدهای داخل جدول داده را مخفی نمی‌کند و مخفی کردن کلیدهای جدول داده، افسانه جداگانه را مخفی نمی‌کند.

مثال زیر یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده آن را فعال می‌سازد و کلیدهای افسانه‌ای را در داخل آن نشان می‌دهد در حالی که افسانه جداگانه مخفی است. تمام حاشیه‌های جدول به‌ صراحت فعال شده‌اند. نیازی به ارائه ورودی نیست. برای مخفی کردن فقط کلیدهای جدول، `data_table.show_legend_key` را به `False` تغییر دهید.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

مقایسه زیر همان جدول را با کلیدهای افسانه‌ای فعال و غیرفعال نشان می‌دهد. تمام حاشیه‌ها فعال باقی می‌مانند و افسانه جداگانه نمودار در هر دو حالت مخفی است.

![جداول داده‌های نمودار با کلیدهای افسانه‌ای که در سمت چپ نشان داده شده‌اند و در سمت راست مخفی هستند](data-table-legend-keys.png)

## **سوالات متداول**

**آیا می‌توانم کلیدهای افسانه‌ای را در جدول داده‌های یک نمودار نشان دهم؟**

بله. برای نمایش کلیدهای افسانه‌ای، [show_legend_key](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datatable/show_legend_key/) را روی `True` تنظیم کنید یا برای مخفی کردن آنها روی `False`.

**آیا جدول داده هنگام خروجی گرفتن ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**

بله. Aspose.Slides هنگام خروجی به [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، یا [images](/slides/fa/python-net/convert-powerpoint-to-png/) نمودار و جدول داده نمایش‌داده‌شده را به‌ عنوان بخشی از اسلاید رندر می‌کند.

**آیا می‌توانم با جداول داده در نمودارهایی که از یک قالب بارگذاری شده‌اند کار کنم؟**

بله. برای نموداری که از یک ارائه یا قالب موجود بارگذاری شده است، از [has_data_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/has_data_table/) برای بررسی یا تغییر نمایش جدول داده استفاده کنید.

**چگونه می‌توانم نمودارهایی را پیدا کنم که جدول داده آنها فعال است؟**

در اشکال هر اسلاید تکرار کنید، نمودارها را شناسایی کنید و ویژگی [has_data_table](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/has_data_table/) آنها را بررسی کنید. مقدار `True` نشان می‌دهد جدول داده فعال است.