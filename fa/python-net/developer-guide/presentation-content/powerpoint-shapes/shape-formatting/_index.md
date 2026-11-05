---
title: قالب‌بندی اشکال PowerPoint در Python
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌نویسی
- خط طرح‌نویسی شکل
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر سیاه‌سفید شکل
- رندر خاکستری شکل
- چرخش شکل
- افکت برجسته 3 بعدی
- افکت چرخش 3 بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در Python با استفاده از Aspose.Slides قالب‌بندی کنید—پرکننده، خط و سبک افکت‌ها را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

شکل‌ها را در PowerPoint با تنظیم خطوط بیرونی، پرکننده‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی سه‌بعدی.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای Python از طریق .NET کلاس‌ها و خصوصیاتی را ارائه می‌دهد که به شما اجازه می‌دهند شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) برای کنترل خطوط بیرونی یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکننده با یک خط آبی و خط‌چین ایجاد می‌کند. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) یک خط ترکیبی ضخیم‑نازک را انتخاب می‌کند، در حالی که [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) عرض آن را روی ۷ پوینت تنظیم می‌کند و [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) الگوی خط‌چین را انتخاب می‌کند.

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

از [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) زمانی استفاده کنید که سبک‌های پیش‌تعریف‌شده طول خطوط و فاصله‌های مورد نیاز شما را فراهم نمی‌کنند، برای مثال برای خطوط برند یا نمودارهای فنی. اختصاص یک الگو به‌صورت خودکار [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) را به [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) تنظیم می‌کند.

ورودی‌های لیست به‌صورت متناوب بین طول خط‌چین و فاصله تعویض می‌شوند، شروع با یک خط‌چین. هر مقدار چندین برابر عرض خط است: `[4, 2]` با عرض ۳ پوینت یک خط‌چین ۱۲ پوینتی سپس یک فاصله ۶ پوینتی تولید می‌کند. برای تعریف بخش‌های کامل خط‌چین‑فاصله از جفت مقادیر محدود، غیرمنفی استفاده کنید. مثال از مقادیر مثبت استفاده می‌کند تا هر خط‌چین و فاصله دیدنی باشد.

این مثال پنج خط آبی با طول برابر و انتهای صاف ایجاد می‌کند. سه خط اول الگوها را با عرض ۳ پوینت مقایسه می‌کنند. خط چهارم الگوی اول را با دو برابر عرض تکرار می‌کند و طول هر دو خط‌چین و فاصله را دو برابر می‌کند. خط پنجم از یک الگوی سفارشی به خط صاف تغییر می‌دهد.

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

    # خط آخر را به سبک ثابت برگردانید.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

برای بازگشت به یک سبک خط‌چین پیش‌تعریف‌شده، [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) را به [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) اختصاص دهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی خط‌چین سفارشی، خطی پهن‌تر با استفاده از الگوی اول، و خط صاف در PowerPoint](custom-dash-patterns.png)

### **تنظیم انتهای خطوط**

از [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) برای تنظیم انتهای یک خط باز استفاده کنید. شمارش [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) سه سبک صریح انتهای خط را فراهم می‌کند:

- `FLAT`: خط در نقطه انتهایی متوقف می‌شود.
- `ROUND`: یک انتهای نیم‌دایره‌ای نیم‌عرض خط فراتر از نقطه انتها گسترش می‌یابد.
- `SQUARE`: یک انتهای مربع نیم‌عرض خط فراتر از نقطه انتها گسترش می‌یابد.

شمارش همچنین شامل `NOT_DEFINED` است که به معنای عدم اختصاص صریح یک سبک انتها می‌باشد.

انتهای خطوط متفاوت از سرهای فلش هستند که نمادهایی به انتهای خط اضافه می‌کنند، و نقاط اتصال که گوشه‌های بین قطعات خط را کنترل می‌کنند. این مثال سرهای فلش را با استفاده از [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) و [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) غیرفعال می‌کند تا فقط شکل‌های انتهای خط مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان با عرض ۲۰ پوینت ایجاد می‌کند. از بالا به پایین، آن‌ها به ترتیب از انتهای صاف، گرد و مربع استفاده می‌کنند. نقاط انتهایی آن‌ها دارای مختصات افقی یکسان هستند؛ انتهای گرد و مربع ۱۰ پوینت بیشتر از هر نقطه انتها گسترش می‌یابند.

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

![انتهای صاف، گرد، و مربع بر خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت طرح‌خط بر خطوط شکل**

یک افکت طرح‌خط باعث می‌شود خط یک شکل شبیه به دست‌نویس به‌نظر برسد. از [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) برای دسترسی به تنظیمات خط، از [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) برای دسترسی به تنظیمات طرح‌خط، و از [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) برای انتخاب یک مقدار از شمارش [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه افکت [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) را اعمال کنید، مقدار صریحاً اختصاص داده شده را بخوانید، و افکت را با [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) حذف کنید:

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

مقداری که توسط [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) برگردانده می‌شود، تنظیمی است که مستقیم به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به‌ارث برده شود، از [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) استفاده کنید، به [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) دسترسی پیدا کنید، و [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/) را بخوانید. مقدار مؤثر، قالب‌بندی واقعی پس از حل ارث‌بری را نشان می‌دهد. این مثال به ارائه‌ای موجود که حداقل یک شکل در اسلاید اول دارد نیاز دارد و هر دو مقدار را چاپ می‌کند:

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

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینه نوع اتصال آمده است:

* Round
* Miter
* Bevel

سبک اتصال کنترل می‌کند که دو قطعه خط بیرونی چگونه در یک گوشه به هم می‌رسند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter** و برای گوشه‌های صاف از **Bevel** استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط بیرونی آبی به عرض ۱۵ پوینت ایجاد می‌کند. آن [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) را به مقادیر متر، بیول و گرد شمارش [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) به ترتیب تنظیم می‌کند تا نحوه ترسیم گوشه‌ها را مقایسه کند.

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

### **محدود کردن اتصالات شکم در گوشه‌های تیز**

از [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) همراه با [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) که روی [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) تنظیم شده است، برای محدود کردن میزان گسترش یک گوشه تیز استفاده کنید.

محدودیت نسبت فاصله بین گوشه‌های داخلی و خارجی اتصال به عرض خط است. به‌عنوان مثال، مقدار `8` اجازه می‌دهد طول شکم تا هشت برابر عرض خط باشد؛ این یک واحد اندازه‌گیری در پوینت نیست. اگر گوشه از حد مجاز فراتر رود، PowerPoint در آن گوشه از اتصال بیول استفاده می‌کند. محدودیت بزرگ‌تر نقاط تیزتر را می‌سازد. این تنظیم فقط بر اتصالات شکم تاثیر می‌گذارد و تغییر آن زمانی اثر نمایان ندارد که گوشه در هر دو حد باقی بماند.

این مثال دو مثلث یکسان بدون پرکننده با خطوط بیرونی به عرض ۲۰ پوینت ایجاد می‌کند. مثلث چپ از حد `2` استفاده می‌کند و راست از `8`. هر مثلث به عرض ۸۰ پوینت و ارتفاع ۱۶۰ پوینت است که نسبت طول شکم به عرض خط در گوشه بالایی تقریباً `4.12` می‌شود. بنابراین PowerPoint رأس چپ را بیول می‌کند و رأس راست را حفظ می‌کند.

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

![یک رأس بیول با محدودیت شکم ۲ و یک رأس تیز با محدودیت شکم ۸ در PowerPoint](miter-limits.png)

## **پر کردن گرادیان**

یک پر کردن گرادیان رنگ‌ها را در سراسر یک شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی با زاویه ۴۵ درجه از قرمز به بنفش با استفاده از [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/) پر می‌کند. متد [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) نقاط توقف رنگ را در ۰ و ۱، یعنی آغاز و انتهای گرادیان قرار می‌دهد. پاک‌کردن نقاط توقف موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

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

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آنچه در PowerPoint به‌نظر می‌رسد باشد، به [Choose a Gradient Rendering Style](/slides/fa/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید سبک رندر را بدون تغییر گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویه گرادیان خطی**

از [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) برای کنترل جهت یک پر کردن [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعت‌گرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ، و `270` از پایین به بالا. زاویه‌های کسری نیز پشتیبانی می‌شوند. زاویه‌های محدود خارج از بازه `[0, 360)` به یک دور کامل نرمال‌سازی می‌شوند؛ به‌عنوان مثال `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل با نقاط توقف قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌سازی غیرفعال می‌شود تا زاویه بتواند مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زاویه‌ها، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

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

![گرادیان‌های خطی با زاویه‌های 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌بندی یک گرادیان خطی با شکل**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) یک مقدار [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) می‌پذیرد. به‌صورت صریح به `FALSE` تنظیم کنید تا زاویه هندسی گرادیان در هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `TRUE` تا گرادیان با عرض و ارتفاع شکل مقیاس‌بندی شود. با فعال‌سازی مقیاس‌بندی، زاویه قابل مشاهده می‌تواند با زاویه اختصاص داده‌شده در یک شکل غیرمربعی فرق کند.

مثال زیر از زاویه `45` درجه و همان نقاط توقف رنگی که در مقایسه زاویه استفاده شد، استفاده می‌کند. ستون چپ از `FALSE`، ستون راست از `TRUE` استفاده می‌کند. هر ستون شامل یک مستطیل پهن بالای یک مستطیل بلند است. هر دو با ابعاد پهن یکسان شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نحوه واکنش پر رنگ به تغییر اندازه را بدون تغییر تنظیمات گرادیان نشان می‌دهد.

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

نتیجه در PowerPoint، با مقیاس‌سازی غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های پهن و بلند با گرادیان 45 درجه، مقایسه linear_gradient_scaled FALSE در سمت چپ با TRUE در سمت راست](linear-gradient-scaling.png)

با مقیاس‌سازی غیرفعال، نوارهای رنگی قطری همان جهت را در هر دو مستطیل حفظ می‌کنند. با مقیاس‌سازی فعال، نوارها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا وقتی یک قالب به اندازه متفاوتی تبدیل می‌شود، گرادیان آن را بازتولید کنید. در یک مربع، فعال‌سازی مقیاس‌سازی ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس برای گرادیان‌های خطی اعمال می‌شود. آنها بر پر کردن‌های [GradientShape.RADIAL یا GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) تأثیری ندارند.

### **ترکیب زاویه با جهت گرادیان**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) یک سبک گرادیان را از شمارش [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزینی برای زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های جهت می‌توانند ناحیه توزیع رنگ‌ها را بدون تغییر [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) تغییر دهند. هنگام مقایسه زاویه‌ها یا مقیاس، جهت را ثابت نگه دارید.

مثال زیر همان تنظیمات را به ترتیب معکوس اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

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

## **پر کردن الگوی**

یک پر کردن الگو یک طرح دو رنگی مانند نقطه‌ها، نوارها یا شطرنج‌ها را اعمال می‌کند. این مثال از [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) برای انتخاب الگوی trellis استفاده می‌کند. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) پس‌زمینه خاکستری روشن را فراهم می‌کند و [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) رنگ زرد الگو را فراهم می‌کند.

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

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

یک پر کردن تصویر از یک تصویر داخل یک شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) برای بارگذاری آن در مجموعه تصاویر ارائه استفاده می‌کند. تنظیم [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) به حالت tiled تصویر را درون مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نشان داده شده است:

![تصویر لوتوس](lotus.png)

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

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌بندی را سفارشی کنید، می‌توانید از خصوصیات زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) استفاده کنید:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): حالت پرکردن تصویر را تنظیم می‌کند—یا `TILE` یا `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): تراز کاشی‌ها داخل شکل را مشخص می‌کند.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): کنترل می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): افست افقی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): افست عمودی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): مقیاس افقی کاشی به‌صورت درصد تعریف می‌شود.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): مقیاس عمودی کاشی به‌صورت درصد تعریف می‌شود.

این مثال به یک تصویر محلی نیاز دارد و [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) را طوری پیکربندی می‌کند که با اندازه ۵۰٪ از اندازه اصلی تکرار شود. افست‌های −32 پوینت کاشی‌ها را به صورت افقی و عمودی جابه‌جا می‌کند؛ تراز راست‑پایین و وارونگی در هر دو جهت نحوهٔ ترتیب بافت تکراری را تعیین می‌کند.

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

## **پر کردن رنگ ثابت**

یک پر کردن ثابت یک رنگ واحد، یکنواخت به شکل می‌دهد. این مثال [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به حالت پر کردن ثابت تنظیم می‌کند و با استفاده از [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) رنگ زرد را اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

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

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

### **کپی رنگ‌ها در حالی که ارجاعات تم حفظ می‌شود**

از [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) برای کپی یک تعریف رنگ، شامل نوع رنگ، ارجاع تم و تبدیلات استفاده کنید. این کار هنگام انتقال رنگ پرکردن بین شکل‌هایی که باید همچنان پیگیر تم ارائه باشند مفید است. این روش فقط رنگ را کپی می‌کند: نوع پرکردن، خط یا دیگر قالب‌بندی‌های شکل را کپی نمی‌کند. نوع پرکردن مقصد را به‌صورت صریح با [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) تنظیم کنید.

این مثال سه مستطیل از چپ به راست ایجاد می‌کند: منبع، یک کپی آگاه به تم و یک کپی ثابت RGB. منبع از [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) برای ارجاع به اولین رنگ تأکید استفاده می‌کند و یک رنگ تیرگی را از طریق [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/) اضافه می‌کند. کپی RGB از رنگ پرکردن مؤثر منبع استفاده می‌کند، بنابراین سه شکل ابتدا یک‌دست به‌نظر می‌رسند. اختصاص [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) یک مقدار ثابت RGB تنظیم می‌کند و هر تبدیلات رنگ موجود را پاک می‌کند.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # ارجاعات تم رنگ تأکید جدید را دنبال می‌کند؛ مقدار ثابت RGB این کار را نمی‌کند.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

قبل از تغییر تم، تمام سه پرکردن یکسان هستند:

![منبع، مقصد copy_from و مقصد ثابت RGB با پرکردن‌های آبی یکسان](color-copy-before.png)

پس از تغییر تم، منبع و کپی آگاه به تم، رنگ تاکید جدید را دنبال می‌کنند و تیرگی خود را حفظ می‌کنند. کپی ثابت RGB همچنان آبی می‌ماند:

![منبع و هدف copy_from با پرکردن‌های نارنجی، در حالی که مقصد ثابت RGB همچنان آبی است](color-copy-after.png)

تعریف کپی شده مستقل از منبع است. تغییر بعدی ارجاع تم منبع، اختصاص رنگ دیگر یا افزودن/حذف تبدیلات آن، مقصد را تغییر نمی‌دهد. تغییر تم همچنان هر دو شکل را تحت تأثیر قرار می‌دهد چون هر یک به‌ طور مستقل به همان رنگ تم ارجاع می‌دهند.

ذخیره و بازگشایی PPTX تعریف کپی شدهٔ [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/)، ارجاع تم و مجموعهٔ [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) را حفظ می‌کند؛ آن را به RGB مسطح نمی‌کند.

هنگام کپی بین زمینه‌های تم متفاوت، مانند ارائه‌هایی با پالت‌های تأکید متفاوت، ارجاع کپی‌شده نسبت به تم مقصد حل می‌شود. همان ارجاع و تبدیلات می‌توانند در نتیجه رنگ قابل مشاهده متفاوتی تولید کنند. برای اطلاعات بیشتر درباره پیکربندی رنگ‌های تم به [Presentation Theme](/slides/fa/python-net/presentation-theme/) مراجعه کنید.

## **استفاده از پس‌زمینه اسلاید به عنوان پر کردن شکل**

از [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) وقتی که یک شکل باید با پس‌زمینه اسلاید مطابقت داشته باشد، مثلاً در یک قالب ارائه، استفاده کنید. ابتدا [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) را به [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) تنظیم کنید تا هر پر کردن صریحی حذف شود. با این ترکیب، شکل از پس‌زمینهٔ اسلاید به جای پرکردن سبک خود استفاده می‌کند. فعال‌سازی این پرچم به‌تنهایی پر کردن صریح موجود را حذف نمی‌کند.

این با [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) متفاوت است: پرکردن پس‌زمینه اشیاء پشت شکل را با ناحیه متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پرکردن آن اشیاء را قابل مشاهده می‌گذارد. یک گرادیان بر روی اسلاید هم‌راستا می‌ماند و داخل هر شکل دوباره آغاز نمی‌شود.

مثال زیر یک پس‌زمینهٔ اصلی که توسط اسلاید وارث شده است ایجاد می‌کند و یک نوار ماژنتا را پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی بدون پرکردن است، و مستطیل راست از پرکردن پس‌زمینه به پرکردن صریح نارنجی سوئیچ می‌کند.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # گرادیان را از مستر به ارث می‌بریم.
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

    # این شیء را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
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

    # پیش از اعمال پر کردن صریح، پر کردن پس‌زمینه را غیرفعال کنید.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه، از چپ به راست: **background fill**، **no fill**، و **explicit fill**. نوار ماژنتا توسط مستطیل‌های چپ و راست مخفی می‌شود اما از طریق مستطیل میانی قابل مشاهده است.

![پرکردن پس‌زمینه، بدون پرکردن، و پرکردن صریح نارنجی بر روی نوار ماژنتا](background-fill.png)

رفتار مشابه برای پس‌زمینه‌ای که به‌صورت مستقیم روی اسلاید تعریف شده یا از یک چیدمان وارث می‌شود نیز اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و چیدمان را تعریف‌نشده می‌گذارد تا اصلی آنها را تأمین کند.

## **تنظیم شفافیت**

برای یک پر کردن ثابت، مؤلفهٔ آلفای رنگ اپاسیتی را کنترل می‌کند: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات است. این مثال از مقدار آلفای ۱۲۸ برای یک مستطیل زرد استفاده می‌کند، به‌طوری که تقریباً ۵۰٪ شفاف باشد تا مستطیل زیرین قابل مشاهده باقی بماند. رنگ از طریق [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) اختصاص می‌یابد.

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

## **چرخاندن شکل‌ها**

از [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعت‌گرد می‌چرخاند و ارائه را ذخیره می‌کند.

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

## **اضافه کردن افکت‌های برجسته 3 بعدی**

از [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) برای افزودن عمق و لبه‌های برجسته به یک شکل استفاده کنید. این مثال یک بیضی سبز با خط بیرونی نارنجی ایجاد می‌کند، [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) را روی ۴ پوینت تنظیم می‌کند و یک برجستهٔ بالایی دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) اعمال می‌کند. یک دوربین ارتوگرافیک روبه‌رو و روشنایی سه‌نقطه‌ای برجسته را قابل مشاهده می‌سازند.

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

![افکت برجستهٔ 3D](3D-bevel-effect.png)

## **اضافه کردن افکت‌های چرخش 3 بعدی**

یک نمای 3D شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) با زاویه‌های عرض، طول و دوران به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. یک دوربین ایزومتریک از طریق [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) و روشنایی متعادل از طریق [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) انتخاب می‌شود، سپس مستطیل قالب‌بندی‌شده ذخیره می‌شود.

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

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای شکل‌ها**

ویژگی [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) مشخص می‌کند که یک شکل فرد چگونه هنگام مشاهده یا پردازش ارائه در حالت سیاه‑سفید رندر شود. این ویژگی به‌تنهایی نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی‌های پر، خط یا دیگر ویژگی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار شمارش [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. به‌عنوان مثال، `AUTOMATIC` به برنامهٔ رندر اجازه می‌دهد تبدیل را انتخاب کند، `GRAY` و `LIGHT_GRAY` از رنگ خاکستری استفاده می‌کنند، `BLACK_WHITE` فقط سیاه و سفید را به کار می‌برد، `BLACK` و `WHITE` یک رنگ تک را اعمال می‌کنند، `COLOR` رنگ عادی را حفظ می‌کند، و `HIDDEN` شکل را در حالت سیاه‑سفید حذف می‌کند. `NOT_DEFINED` به معنای عدم تخصیص حالت در سطح شکل است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) را روی خاکستری تنظیم می‌کند. شکل ذخیره‌شده پرکردن نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، درخواست رنگ خاکستری می‌کند:

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

در حالت رنگ عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک گردش کاری نمایش سیاه‑سفید، به دلیل تنظیم حالت روی `GRAY` از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد یک اسلاید رنگی کامل را حفظ کنید در حالی که ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر گردش‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) برای بازگرداندن موقعیت، اندازه و قالب‌بندی نگه‌دارهای اسلاید از نگه‌دارهای متناظر در چیدمان استفاده کنید. این مثال به یک ارائهٔ موجود با نگه‌دارهای پیوند‌شده به چیدمان نیاز دارد و قبل از ذخیره همهٔ اسلایدها را بازنشانی می‌کند. شکل‌هایی که نگه‌دار متناظر در چیدمان ندارند بازنشانی نمی‌شوند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تاثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت عموماً داده کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پر کردن‌های تصویری می‌توانند حجم فایل را افزایش دهند چون تصاویر آنها در ارائه ذخیره می‌شود.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

هر ویژگی قالب‌بندی کلیدی یک شکل—پر کردن، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر متناظر یکسان باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقی گروه‌بندی کنید؛ این کار مدیریت سبک‌های بعدی را ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد شود؟**

بله. نمونه شکل‌ها با سبک‌های دلخواه را در یک اسلاید قالب یا فایل .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی‌شان را در هر مکانی که لازم است اعمال کنید.