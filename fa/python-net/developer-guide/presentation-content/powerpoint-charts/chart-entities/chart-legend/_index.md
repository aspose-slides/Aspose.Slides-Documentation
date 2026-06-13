---
title: سفارشی‌سازی افسانه‌های نمودار در ارائه‌ها با پایتون
linktitle: افسانه نمودار
type: docs
url: /fa/python-net/chart-legend/
keywords:
- افسانه نمودار
- موقعیت افسانه
- اندازه قلم
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "با Aspose.Slides برای Python از طریق .NET، افسانه‌های نمودار را سفارشی کنید تا ارائه‌های PowerPoint و OpenDocument را با قالب‌بندی مخصوص به افسانه بهینه کنید."
---
## **Overview**

Aspose.Slides for Python کنترل کامل روی افسانه‌های نمودار را فراهم می‌کند تا برچسب‌های داده‌ای واضح و آماده ارائه باشند. می‌توانید افسانه را نمایش یا مخفی کنید، موقعیت آن را در اسلاید انتخاب کنید و چیدمان را طوری تنظیم کنید که با ناحیه‌نمودار تداخل نداشته باشد. API به شما امکان می‌دهد متن و نشانگرها را سبک‌دهی کنید، حاشیه‌ها و پس‌زمینه را به‌دقت تنظیم کنید و حاشیه‌ها و پر کردن‌ها را مطابق تم خود فرمت‌بندی کنید. توسعه‌دهندگان همچنین می‌توانند به ورودی‌های منفرد افسانه دسترسی پیدا کنند تا آن‌ها را تغییر نام یا فیلتر کنند و اطمینان حاصل کنند که فقط سری‌های مرتبط نمایش داده شوند. با این قابلیت‌ها، نمودارهای شما خوانا، سازگار و مطابق با استانداردهای طراحی ارائه خواهند بود.

## **Legend Positioning**

با استفاده از Aspose.Slides می‌توانید به‌سرعت مکان نمایش افسانه نمودار را کنترل کنید و آن را با طرح اسلاید خود هماهنگ کنید. یاد بگیرید چگونه افسانه را دقیقاً قرار دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را دریافت کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. ویژگی‌های افسانه را تنظیم کنید.
1. ارائه را به‌عنوان فایل PPTX ذخیره کنید.

در مثال زیر، موقعیت و اندازه افسانه نمودار را تنظیم می‌کنیم:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    # مرجع اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # یک نمودار ستونی خوشه‌ای به اسلاید اضافه کنید.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # ویژگی‌های افسانه را تنظیم کنید.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Legend Font Size**

افسانه یک نمودار باید به‌اندازه داده‌های توضیحی‌اش قابل خواندن باشد. این بخش نشان می‌دهد چگونه اندازه قلم افسانه را تنظیم کنید تا با تایپوگرافی ارائه شما مطابقت داشته باشد و دسترسی‌پذیری بهبود یابد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار ایجاد کنید.
1. اندازه قلم را تنظیم کنید.
1. ارائه را بر روی دیسک ذخیره کنید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Font Size for a Legend Entry**

Aspose.Slides به شما امکان می‌دهد ظاهر افسانه‌های نمودار را با فرمت‌بندی ورودی‌های منفرد دقیقاً تنظیم کنید. مثال زیر نشان می‌دهد چگونه یک آیتم افسانه خاص را هدف بگیرید و ویژگی‌های آن را بدون تغییر بقیه افسانه تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار ایجاد کنید.
1. به یک ورودی افسانه دسترسی پیدا کنید.
1. ویژگی‌های ورودی را تنظیم کنید.
1. ارائه را بر روی دیسک ذخیره کنید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
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

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Yes. Use the non-overlay mode ([overlay](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/legend/overlay/) = `false`); in this case, the plot area will shrink to accommodate the legend.

**Can I make multi-line legend labels?**

Yes. Long labels wrap automatically when space is insufficient; forced line breaks are supported via newline characters in the series name.

**How do I make the legend follow the presentation theme’s color scheme?**

Do not set explicit colors/fills/fonts for the legend or its text. They will then inherit from the theme and update correctly when the design changes.