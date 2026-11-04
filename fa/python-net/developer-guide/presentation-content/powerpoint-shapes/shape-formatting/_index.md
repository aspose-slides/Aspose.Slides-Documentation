---
title: قالب‌بندی اشکال PowerPoint در Python
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌دستی
- خط شکل طرح‌دستی
- قالب‌بندی سبک جوین
- پرکننده گرادیان
- پرکننده الگو
- پرکننده تصویر
- پرکننده بافت
- پرکننده رنگ ثابت
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخش شکل
- افکت Bevel سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "بیاموزید چگونه اشکال PowerPoint را در Python با استفاده از Aspose.Slides قالب‌بندی کنید—پرکننده، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

با تنظیم خطوط مرزی، پرکننده‌ها و افکت‌ها اشکال را در PowerPoint قالب‌بندی کنید. Aspose.Slides برای Python از طریق .NET به شما امکان کنترل این تنظیمات به‌صورت برنامه‌نویسی را می‌دهد، از جمله شفافیت، چرخش و قالب‌بندی سه‌بعدی.

![گزینه‌های قالب‌بندی اشکال در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای Python از طریق .NET کلاس‌ها و ویژگی‌هایی فراهم می‌کند که به شما اجازه می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) برای کنترل خطوط مرزی یک شکل استفاده کنید. این مثال یک مستطیل بدون پر‌کننده با خط مرزی آبی نقطه‌دار ایجاد می‌کند. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) یک خط ترکیبی ضخیم-نازک را انتخاب می‌کند، در حالی که [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) عرض آن را به ۷ پوینت تنظیم می‌کند و [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) الگوی خط‌چین را برمی‌گزید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای سفارشی خط‌چین**

زمانی که سبک‌های پیش‌تعریف‌شده طول و فاصله‌های خط‌چین مورد نیاز شما را فراهم نمی‌کنند، از [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) استفاده کنید، مثلاً برای خطوط مرزی برند یا نمودارهای فنی. اختصاص یک الگو به‌صورت خودکار [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) را به [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) تنظیم می‌کند.

ورودی‌های فهرست به‌صورت متناوب بین طول خط و فاصله جابجا می‌شوند و با یک خط شروع می‌شوند. هر مقدار مضربی از عرض خط است: `[4, 2]` با عرض ۳ پوینت یک خط‌چین ۱۲ پوینتی و سپس فاصله ۶ پوینتی تولید می‌کند. برای تعریف بخش‌های کامل خط‌چین‑فاصله از جفت مقادیر محدود، غیرمنفی استفاده کنید. این مثال از مقادیر مثبت استفاده می‌کند تا هر خط‌چین و فاصله‌ای قابل مشاهده باشد.

این مثال پنج خط آبی با طول یکسان و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را در عرض ۳ پوینت مقایسه می‌کنند. چهارم همان الگو را با دو برابر عرض تکرار می‌کند و هم طول خط‌چین و هم فاصله را دوبرابر می‌سازد. پنجم از الگوی سفارشی به خط صاف تغییر می‌دهد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # بازگرداندن آخرین خط به یک سبک ثابت.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

برای بازگشت به یک سبک پیش‌تعریف‌شده نقطه‌دار، مقدار [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) را به [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) اختصاص دهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی سفارشی خط‌چین، یک خط پهن‌تر با اولین الگو، و یک خط صاف در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) برای تنظیم انتهای یک خط باز استفاده کنید. شمارش [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) سه سبک سر صریح ارائه می‌دهد:

- `FLAT`: خط در نقطه انتها متوقف می‌شود.
- `ROUND`: یک سر نیم‌دایره‌ای از نقطه انتها به اندازه نصف عرض خط بیرون می‌زند.
- `SQUARE`: یک سر مربع‌ شکل از نقطه انتها به اندازه نصف عرض خط بیرون می‌زند.

این شمارش همچنین شامل `NOT_DEFINED` است که به معنای عدم اختصاص سبک سر به‌صورت صریح می‌باشد.

سرها با سرپیک‌های پیکان متفاوت هستند؛ سرپیک‌ها نمادهایی را به انتهای خطوط اضافه می‌کنند و پیوندها (joins) گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرپیک‌ها را از طریق [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) و [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) غیرفعال می‌کند تا تنها شکل سرها مقایسه شوند.

مثال زیر سه خط افقی تقریباً مشابه با عرض ۲۰ پوینت ایجاد می‌کند. از بالا به پایین، سرهای صاف، گرد و مربع استفاده می‌شوند. نقاط انتهایی آن‌ها دارای مختصات افقی یکسان هستند؛ سرهای گرد و مربع ۱۰ پوینت بیشتر از هر انتها امتداد می‌یابند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه در PowerPoint، از بالا به پایین: **Flat**, **Round**, و **Square**.

![سرهای صاف، گرد و مربعی بر روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های Sketch به خطوط شکل**

یک افکت sketch باعث می‌شود خط شکل دست‌کشیده به نظر برسد. از [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) برای دسترسی به تنظیمات خط، [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) برای دسترسی به تنظیمات sketch و [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) برای انتخاب یک مقدار از شمارش [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه یک افکت [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) اعمال شود، مقدار صریحاً تعیین‌شده بخواند و افکت را با [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) حذف کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

مقداری که توسط [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) برگردانده می‌شود، تنظیماتی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید طرح ارث‌بری شود، از [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) استفاده کنید، به [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) دسترسی پیدا کنید و [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/) را بخوانید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال می‌شود. این مثال نیاز به یک ارائه موجود دارد که حداقل یک شکل در اولین اسلاید آن باشد و هر دو مقدار را چاپ می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **قالب‌بندی سبک‌های Join**

سه گزینه نوع Join وجود دارد:

* Round
* Miter
* Bevel

سبک Join کنترل می‌کند که دو بخش مرزی چگونه در یک گوشه به‌هم می‌رسند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter** و برای گوشه‌های صاف از **Bevel** استفاده کنید.

![سبک Join در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط مرزی آبی به‌عرض ۱۵ پوینت ایجاد می‌کند. با استفاده از [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) مقدار miter، bevel و round از [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) به ترتیب تنظیم می‌شود تا مقایسه شود که گوشه‌ها چگونه ترسیم می‌شوند.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **محدود کردن Join های Miter در گوشه‌های تیز**

از [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) همراه با [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) که روی [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) تنظیم شده استفاده کنید تا محدوده‌ای که یک گوشهٔ تیز می‌تواند امتداد یابد محدود کنید.

محدودیت نسبت فاصله بین گوشهٔ داخلی و خارجی Join به عرض خط است. به‌عنوان مثال مقدار `8` اجازه می‌دهد طول miter تا هشت برابر عرض خط باشد؛ این مقدار یک اندازه در پوینت نیست. اگر گوشه از این حد فراتر رود، PowerPoint در آن گوشه از Join با bevel استفاده می‌کند. حد بزرگتر نقاط تیزتر را امکان می‌دهد. این تنظیم فقط بر Joinهای miter تأثیر می‌گذارد و تغییر آن زمانی که گوشه در هر دو حد باقی بماند، اثر قابل‌مشاهده‌ای ندارد.

این مثال دو مثلث بدون پر‌کنندهٔ یکسان با خطوط مرزی به‌عرض ۲۰ پوینت ایجاد می‌کند. مثلث چپ از حد `2` و مثلث راست از حد `8` استفاده می‌کند. هر مثلث عرض ۸۰ پوینت و ارتفاع ۱۶۰ پوینت دارد که نسبت طول miter به عرض خط در گوشه بالایی تقریباً `4.12` است. در نتیجه PowerPoint گوشهٔ چپ را bevel می‌کند و گوشهٔ راست را حفظ می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![یک رأس bevel شده با محدودیت miter 2 و یک رأس تیز با محدودیت miter 8 در PowerPoint](miter-limits.png)

## **پرکننده گرادیان**

یک پرکننده گرادیان رنگ‌ها را در طول یک شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی با زاویه ۴۵ درجه از قرمز به بنفش با استفاده از [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/) پر می‌کند. متد [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) رنگ‌ها را در ۰ و ۱، شروع و پایان گرادیان، قرار می‌دهد. حذف توقف‌های موجود تضمین می‌کند که تنها این دو رنگ استفاده شوند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بیضی با پرکننده گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر استخراج‌شده متفاوت از آنچه در PowerPoint دیده می‌شود باشد، به [Choose a Gradient Rendering Style](/slides/fa/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ را بدون تغییر پرکنندهٔ گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویهٔ گرادیان خطی**

از [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) برای کنترل جهت [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) استفاده کنید. زاویه برحسب درجه اندازه‌گیری می‌شود و ساعت‌گرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زوایای کسری هم پشتیبانی می‌شوند. زوایای محدودی خارج از `[0, 360)` به یک دور کامل نرمال می‌شوند؛ برای مثال `-45` تبدیل به `315` و `360` تبدیل به `0` می‌شود.

این مثال شش مستطیل با توقف‌های قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال است تا زاویه بدون در نظر گرفتن نسبت‌های مستطیل‌ها مقایسه شود. زوایا، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه در PowerPoint:

![گرادیان‌های خطی با زوایای 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری گرادیان خطی با شکل**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) یک مقدار [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) می‌گیرد. به‌طور صریح به `FALSE` تنظیم کنید تا زاویهٔ هندسی گرادیان هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `TRUE` تنظیم کنید تا گرادیان با عرض و ارتفاع شکل مقیاس بگیرد. با فعال شدن مقیاس‌گذاری، زاویهٔ قابل‌مشاهده می‌تواند در شکل غیرمربعی با زاویهٔ تعیین‌شده متفاوت باشد.

مثال زیر از زاویهٔ `45` درجه و همان توقف‌های رنگی که در مقایسهٔ زوایا استفاده شد، استفاده می‌کند. ستون چپ از `FALSE` استفاده می‌کند؛ ستون راست از `TRUE`. هر ستون شامل یک مستطیل پهن بالا و یک مستطیل بلند زیر آن است. هر دو با ابعاد پهن یکسان شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد که پرکننده چگونه بدون تغییر تنظیمات گرادیان به تغییر اندازه واکنش نشان می‌دهد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های پهن و بلند با گرادیان 45 درجه، مقایسهٔ linear_gradient_scaled FALSE در سمت چپ با TRUE در سمت راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌گذاری، نوارهای رنگی مورب جهت یکسانی را در هر دو مستطیل حفظ می‌کنند. با فعال شدن مقیاس‌گذاری، نوارها با نسبت‌های شکل کشیده می‌شوند. این به بازتولید گرادیان یک قالب هنگام تطبیق شکل به اندازهٔ متفاوت کمک می‌کند. در یک مربع، فعال‌سازی مقیاس‌گذاری ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس‌گذاری برای گرادیان‌های خطی اعمال می‌شوند. آنها برای پرکننده‌های [GradientShape.RADIAL یا GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) کنترل ندارند.

### **ترکیب زاویه با جهت گرادیان**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) یک سبک گرادیان را از شمارش [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزینی برای زاویهٔ عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند مساحتی که رنگ‌ها در آن توزیع می‌شوند را بدون تغییر [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) تغییر دهند. هنگام مقایسهٔ زوایا یا مقیاس‌گذاری، جهت را یکسان نگه دارید.

مثال زیر تنظیمات یکسان را به ترتیب معکوس اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **پرکننده الگو**

یک پرکنندهٔ الگو یک طرح دو‌رنگ مانند نقطه‌ها، خطوط یا شطرنجی‌ها را اعمال می‌کند. این مثال از [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) برای انتخاب الگوی trellis استفاده می‌کند. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) رنگ زرد الگو را تعیین می‌کند.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![مستطیل با پرکنندهٔ الگو](pattern-fill.png)

## **پرکننده تصویر**

یک پرکننده تصویر از یک تصویر داخل شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) برای بارگذاری آن به مجموعهٔ تصاویر ارائه استفاده می‌کند. تنظیم [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) به حالت tiled تصویر را درون مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نشان داده شده است:

![عکس لوتوس](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پرکنندهٔ تصویر](picture-fill.png)

### **کاشی‌کردن تصویر به‌صورت بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌سازی را سفارشی کنید، می‌توانید از ویژگی‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) استفاده کنید:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): حالت پرکنندهٔ تصویر را تنظیم می‌کند — یا `TILE` یا `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): تراز کاشی‌ها درون شکل را مشخص می‌کند.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): تعیین می‌کند که کاشی به صورت افقی، عمودی یا هر دو وارونه شود.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): افست افقی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): افست عمودی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) را طوری پیکربندی می‌کند که آن را با ۵۰٪ اندازهٔ اصلی خود تکرار کند. افست‌های ‑۳۲ پوینتی کاشی‌ها را به صورت افقی و عمودی حرکت می‌دهند؛ تراز راست‑پایین و وارونگی در هر دو جهت تعیین می‌کند که بافت تکراری چگونه چیده شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پرکننده رنگ ثابت**

یک پرکنندهٔ ثابت یک رنگ یگانه و یک‌دست به شکل می‌دهد. این مثال [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به حالت پرکنندهٔ ثابت تنظیم می‌کند و از طریق [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) رنگ زرد را اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پرکنندهٔ رنگ ثابت](solid-color-fill.png)

## **استفاده از پس‌زمینهٔ اسلاید به‌عنوان پرکنندهٔ شکل**

از [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) زمانی که یک شکل باید با پس‌زمینهٔ اسلاید مطابقت داشته باشد، مثلاً در یک قالب ارائه، استفاده کنید. ابتدا [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم کنید تا هر پرکنندهٔ صریحی حذف شود. با این ترکیب، شکل به جای پرکنندهٔ سبک خود از پس‌زمینهٔ اسلاید استفاده می‌کند. فعال‌سازی تنها پرچم، پرکنندهٔ صریح موجود را حذف نمی‌کند.

این متفاوت از [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) است: پرکنندهٔ پس‌زمینه اشیائی را که پشت شکل قرار دارند با ناحیهٔ متناظر از پس‌زمینهٔ اسلاید می‌پوشاند، در حالی که بدون پرکننده آن اشیا قابل مشاهده می‌مانند. یک گرادیان در این حالت با اسلاید هم‌راستا می‌ماند و داخل هر شکل دوباره شروع نمی‌شود.

مثال زیر یک پس‌زمینهٔ اصلی که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و یک نوار ماژنتا را در پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل وسط بدون پرکننده است و مستطیل راست از پرکنندهٔ پس‌زمینه به یک پرکنندهٔ نارنجی صریح تغییر می‌کند.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # گرادیان را از مستر به ارث بگیرید.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # این شی را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # پرکنندهٔ پس‌زمینه را قبل از اعمال پرکنندهٔ صریح غیرفعال کنید.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه، از چپ به راست: **پرکنندهٔ پس‌زمینه**، **بدون پرکننده** و **پرکنندهٔ صریح**. نوار ماژنتا توسط مستطیل‌های چپ و راست پنهان می‌شود اما از طریق مستطیل وسط قابل مشاهده است.

![پرکنندهٔ پس‌زمینه، بدون پرکننده و پرکنندهٔ نارنجی صریح بر روی نوار ماژنتا](background-fill.png)

رفتار مشابه برای پس‌زمینه‌ای که مستقیماً روی اسلاید تعریف شده یا از یک طرح ارث‌بری می‌شود، اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ در این مثال هر دو پس‌زمینهٔ اسلاید و طرح تعریف نشده‌اند تا پیش‌زمینهٔ اصلی تأمین شود.

## **تنظیم شفافیت**

برای یک پرکنندهٔ ثابت، مؤلفهٔ آلفای رنگ، شفافیت را کنترل می‌کند: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات است. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند، به‌طوری‌که تقریباً ۵۰٪ شفاف باشد و مستطیل زیرین قابل مشاهده بماند. رنگ از طریق [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) اختصاص می‌یابد.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

از [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) برای چرخاندن یک شکل در صفحه اسلاید استفاده کنید. زاویه برحسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعت‌گرد می‌چرخاند و ارائه را ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **اضافه کردن افکت‌های Bevel سه‌بعدی**

از [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) برای افزودن عمق و لبه‌های برجسته به شکل استفاده کنید. این مثال یک بیضی سبز با خط مرزی نارنجی ایجاد می‌کند، [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) را به ۴ پوینت تنظیم می‌کند و یک bevel بالا دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) اعمال می‌کند. یک دوربین ارتوگرافیک روبه‌رو و نورپردازی سه نقطه‌ای باعث می‌شود bevel قابل‌مشاهده باشد.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت Bevel سه‌بعدی](3D-bevel-effect.png)

## **اضافه کردن افکت‌های چرخش سه‌بعدی**

نمایش سه‌بعدی یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) با زاویه‌های عرض، طول و چرخش به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. یک دوربین ایزومتریک از طریق [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) و نورپردازی متعادل از طریق [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) انتخاب می‌شود، سپس مستطیل قالب‌بندی‌شده ذخیره می‌شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

ویژگی [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) مشخص می‌کند که یک شکل به‌صورت فردی چگونه در حالت نمایش یا پردازش سیاه‑سفید رندر شود. این ویژگی به‌تنهایی نمایش سیاه‑سفید را فعال نمی‌کند و رنگ، خط یا قالب‌بندی شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از مقدارهای شمارش [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) برای انتخاب رفتار دلخواه استفاده کنید. برای مثال، `AUTOMATIC` اجازه می‌دهد برنامه رندر خودکار تبدیل را انجام دهد، `GRAY` و `LIGHT_GRAY` رنگ‌ خاکستری اعمال می‌کنند، `BLACK_WHITE` فقط سیاه و سفید استفاده می‌کند، `BLACK` و `WHITE` یک رنگ واحد را تحمیل می‌کنند، `COLOR` رنگ عادی را حفظ می‌کند و `HIDDEN` شکل را در حالت سیاه‑سفید حذف می‌کند. `NOT_DEFINED` به این معنی است که هیچ حالت سطح‑شکل تعیین نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) را روی خاکستری تنظیم می‌کند. شکل ذخیره‌شده پرکنندهٔ نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، درخواست رنگ خاکستری می‌کند:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

در حالت رنگ عادی، مستطیل پرکنندهٔ نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به دلیل تنظیم حالت بر `GRAY`، از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد اسلاید رنگی کامل را حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‑نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) برای بازگرداندن موقعیت، اندازه و قالب‌بندی فضاهای نگهدارندهٔ اسلاید از فضاهای نگهدارندهٔ طرح‌بندی مربوطه استفاده کنید. این مثال به یک ارائه موجود با فضاهای نگهدارندهٔ مرتبط با طرح‌بندی نیاز دارد و قبل از ذخیره همه اسلایدها را بازنشانی می‌کند. اشکالی که فضاهای نگهدارندهٔ متقابل در طرح‌بندی ندارند، بازنشانی نمی‌شوند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**آیا قالب‌بندی اشکال بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت معمولاً داده کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پرکننده‌های تصویری می‌توانند اندازهٔ فایل را افزایش دهند زیرا تصاویر آن‌ها در ارائه ذخیره می‌شوند.

**چگونه می‌توانم اشکالی را در یک اسلاید شناسایی کنم که قالب‌بندی یکسانی دارند تا بتوانم آن‌ها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی شکل‌ها — پرکننده، خط و تنظیمات افکت — را مقایسه کنید. اگر همه مقادیر متناظر برابر باشند، سبک‌های آن‌ها را یکسان درنظر بگیرید و به‌صورت منطقی آن اشکال را گروه‌بندی کنید، که مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد کنم؟**

بله. اشکال نمونه با سبک‌های موردنظر را در یک اسلاید قالب یا یک فایل الگوی .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که نیاز است دوباره اعمال کنید.