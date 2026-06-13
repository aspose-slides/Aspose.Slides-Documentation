---
title: سفارشی‌سازی نواحی نمودارهای ارائه در Python
linktitle: ناحیه نمودار
type: docs
url: /fa/python-net/chart-plot-area/
keywords:
- نمودار
- ناحیه نمودار
- عرض ناحیه نمودار
- ارتفاع ناحیه نمودار
- اندازه ناحیه نمودار
- حالت چیدمان
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید نواحی نمودارها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET سفارشی کنید. به راحتی ظاهر اسلایدهای خود را بهبود دهید."
---
## **بررسی کلی**

این مقاله نحوه کار با ناحیه‌نمایش (Plot Area) یک نمودار در Aspose.Slides را نشان می‌دهد. توضیح می‌دهد که چگونه با اعتبارسنجی چیدمان نمودار، موقعیت و اندازهٔ واقعی ناحیه‌نمایش را به‌دست آورده و مقادیر X، Y، عرض و ارتفاع آن را بخوانید.

همچنین نشان می‌دهد چگونه حالت چیدمان ناحیه‌نمایش را هنگام تنظیم دستی چیدمان، با استفاده از `LayoutTargetType` برای تعیین اینکه ناحیه‌نمایش بر اساس ناحیه داخلی یا ناحیه بیرونی همراه با محورها و برچسب‌های محورها محاسبه شود، پیکربندی کنید.

## **دریافت عرض و ارتفاع ناحیه‌نمایش نمودار**
Aspose.Slides for Python via .NET یک API ساده برای . ارائه می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. قبل از دریافت مقادیر واقعی، متد IChart.ValidateChartLayout() را فراخوانی کنید.
1. موقعیت X واقعی (چپ) عنصر نمودار را نسبت به گوشهٔ بالای سمت چپ نمودار دریافت کنید.
1. موقعیت Y واقعی (بالا) عنصر نمودار را نسبت به گوشهٔ بالای سمت چپ نمودار دریافت کنید.
1. عرض واقعی عنصر نمودار را دریافت کنید.
1. ارتفاع واقعی عنصر نمودار را دریافت کنید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# ذخیره ارائه با نمودار
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **تنظیم حالت چیدمان ناحیه‌نمایش نمودار**
Aspose.Slides for Python via .NET یک API ساده برای تنظیم حالت چیدمان ناحیه‌نمایش نمودار ارائه می‌دهد. ویژگی **LayoutTargetType** به کلاس‌های **ChartPlotArea** و **IChartPlotArea** اضافه شده است. اگر چیدمان ناحیه‌نمایش به‌صورت دستی تعریف شود، این ویژگی مشخص می‌کند که ناحیه‌نمایش بر اساس درون‌حوزه (بدون شامل محورها و برچسب‌های محورها) یا بیرون‌حوزه (شامل محورها و برچسب‌های محورها) چیدمان شود. دو مقدار ممکن که در enum **LayoutTargetType** تعریف شده‌اند عبارتند از:

- **LayoutTargetType.Inner** - تعیین می‌کند که اندازهٔ ناحیه‌نمایش فقط توسط ناحیه داخلی تعیین شود و علامت‌های تیک و برچسب‌های محورها در محاسبه در نظر گرفته نشوند.
- **LayoutTargetType.Outer** - تعیین می‌کند که اندازهٔ ناحیه‌نمایش شامل ناحیه داخلی، علامت‌های تیک و برچسب‌های محورها باشد.

کد نمونه در زیر آورده شده است.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**واحدهای بازگردانده شده برای actual_x، actual_y، actual_width و actual_height چیست؟**

به نقطه (Points)؛ 1 اینچ = 72 نقطه. این‌ها واحدهای مختصات Aspose.Slides هستند.

**ناحیه‌نمایش چگونه با ناحیهٔ نمودار از نظر محتوا متفاوت است؟**

ناحیه‌نمایش ناحیهٔ رسم داده‌ها (سلسله‌ها، خطوط شبکه، خطوط روند و غیره) است؛ ناحیهٔ نمودار شامل عناصر اطراف (عنوان، شرح، و غیره) می‌شود. در نمودارهای سه‌بعدی، ناحیه‌نمایش همچنین شامل دیوارها/کف و محورها است.

**وقتی چیدمان به صورت دستی باشد، مقادیر X، Y، Width و Height ناحیه‌نمایش چگونه تفسیر می‌شوند؟**

این‌ها کسری (0–1) از اندازهٔ کلی نمودار هستند؛ در این حالت موقعیت‌یابی خودکار غیرفعال می‌شود و کسری که تنظیم می‌کنید مورد استفاده قرار می‌گیرد.

**چرا موقعیت ناحیه‌نمایش پس از افزودن/جابجایی شرح تغییر می‌کند؟**

شرح در ناحیهٔ نمودار خارج از ناحیه‌نمایش قرار می‌گیرد اما بر چیدمان و فضای موجود تأثیر می‌گذارد، بنابراین وقتی موقعیت‌یابی خودکار فعال است، ممکن است ناحیه‌نمایش جابجا شود. (این رفتار استاندارد برای نمودارهای PowerPoint است.)