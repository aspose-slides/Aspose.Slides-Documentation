---
title: قالب‌بندی اشکال PowerPoint در Python از طریق Java
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک جوین
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن تکسچر
- پرکردن رنگ جامد
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر مقیاس خاکستری شکل
- چرخاندن شکل
- افکت برش 3بعدی
- افکت چرخش 3بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در Python از طریق Java با استفاده از Aspose.Slides قالب‌بندی کنید — پر، خط و سبک‌های افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

شکل‌ها را در PowerPoint با تنظیم خطوط خارجی، پرکردن‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides for Python via Java به شما امکان کنترل این تنظیمات به صورت برنامه‌نویسی را می‌دهد، از جمله شفافیت، چرخش و قالب‌بندی 3بعدی.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) برای کنترل خطوط خارجی یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکردن با خط بیرونی آبی و خطچین ایجاد می‌کند. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) یک خط ترکیبی ضخیم‌نازک را انتخاب می‌کند، در حالی که [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) عرض آن را به 7 پوینت تنظیم می‌کند و [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) الگوی نقطه‌چینی را انتخاب می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای دلخواه نقطه‌چین خط**

از [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) زمانی که سبک‌های پیش‌فرض نقطه‌چین طول‌ها و فواصل مورد نیاز شما را فراهم نمی‌کنند، استفاده کنید؛ برای مثال برای خطوط برند یا نمودارهای فنی. اختصاص یک الگو به‌صورت خودکار سبک نقطه‌چین را به [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به‌صورت متناوب بین طول خط و فاصله جفت می‌شوند، با یک خط شروع می‌شوند. هر مقدار چندبرابر عرض خط است: `[4, 2]` با عرض 3 پوینت یک خط 12‑پوینتی سپس فاصله 6‑پوینتی تولید می‌کند. از جفت‌های مقادیر مثبت نه‌منفی برای تعریف بخش‌های کامل خط‑و‑فاصله استفاده کنید. این مثال از مقادیر مثبت برای قابل رؤیت بودن هر خط و فاصله استفاده می‌کند.

این مثال پنج خط آبی با طول یکسان و سرهای صاف ایجاد می‌کند. سه خط اول الگوهای با عرض 3 پوینت را مقایسه می‌کنند. خط چهارم همان الگو را با دو برابر عرض (6 پوینت) تکرار می‌کند و هر دو طول خط و فاصله را دو برابر می‌کند. خط پنجم از الگوی دلخواه به خط پیوسته تغییر می‌یابد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # آخرین خط را به سبک ثابت برمی‌گردانیم.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای بازگشت به سبک پیش‌فرض نقطه‌چین، به‌جای آن [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) را به [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) بدهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی دلخواه نقطه‌چین، خطی عریض‌تر با الگوی اول، و خط پیوسته در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) سه سبک صریح سر را فراهم می‌کند:

- `Flat`: کشیدگی در نقطه انتها متوقف می‌شود.
- `Round`: سر نیم‌دایره‌ای نیم‌عرض خط به بیرون ادامه می‌دهد.
- `Square`: سر مربعی نیم‌عرض خط به بیرون ادامه می‌دهد.

کلاس همچنین `NotDefined` را دارد که به معنای عدم اختصاص صریح یک سبک سر است.

سرها متفاوت از سرهای پیکانی هستند که نمادهایی به انتهای خط اضافه می‌کنند، و از جوین‌ها که گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرهای پیکانی را با استفاده از [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) غیرفعال می‌کند تا فقط شکل‌های سر مقایسه شوند.

مثال زیر سه خط افقی تقریباً مشابه، به‌عرض 20 پوینت، ایجاد می‌کند. از بالا به پایین، سرهای صاف، گرد و مربعی استفاده می‌شوند. نقطه‌های انتهایی آنها مختصات افقی یکسان دارند؛ سرهای گرد و مربعی 10 پوینت بیشتر از هر انتها امتداد می‌یابند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه در PowerPoint، از بالا به پایین: **Flat**, **Round**, و **Square**.

![سرهای صاف، گرد و مربعی روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های اسکچ بر خطوط شکل**

یک افکت اسکچ باعث می‌شود خط شکل دست‌نویس به‌نظر برسد. از [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) برای دسترسی به تنظیمات خط، از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) برای دسترسی به تنظیمات اسکچ، و از [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) برای انتخاب یک مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه اثر [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاصی شده را بخوانید، و اثر را با [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) حذف کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) برگردانده می‌شود، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از تم، اسلاید اصلی یا اسلاید چیدمان به ارث برسد، از [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) استفاده کنید و نوع اسکچ را از قالب‌بندی خط موثر برگردانده شده بخوانید، همان‌طور که در زیر نشان داده شده است. مقدار موثر نشان‌دهنده قالب‌بندی‌ای است که پس از حل ارث‌بری واقعاً اعمال می‌شود. این مثال به یک ارائه موجود با حداقل یک شکل در اسلاید اول نیاز دارد و هر دو مقدار را چاپ می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **قالب‌بندی سبک‌های جوین**

سه گزینه نوع جوین موجود است:

* Round
* Miter
* Bevel

سبک جوین کنترل می‌کند که دو بخش خط در یک گوشه چگونه به‌هم وصل شوند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter**، و برای گوشه‌های مسطح از **Bevel** استفاده کنید.

![سبک جوین در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط بیرونی آبی به‌عرض 15 پوینت ایجاد می‌کند. از [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) برای تنظیم مقادیر miter، bevel و round کلاس [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) به ترتیب استفاده می‌کند تا مقایسه کند چگونه گوشه‌ها رسم می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **محدود کردن جوین‌های Miter در گوشه‌های تیز**

از [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) همراه با [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) تنظیم‌شده به [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) برای محدود کردن اندازه‌ای که یک گوشه تیز می‌تواند امتداد یابد استفاده کنید.

محدودیت نسبت فاصله بین گوشه داخلی و خارجی جوین به عرض خط است. برای مثال مقدار `8` اجازه می‌دهد طول مایتر تا هشت برابر عرض خط باشد؛ این یک اندازه به پوینت نیست. اگر گوشه از این حد عبور کند، PowerPoint در آن گوشه یک جوین bevel استفاده می‌کند. مقدار بزرگتر نقاط تیزتر را اجازه می‌دهد. این تنظیم فقط بر جوین‌های مایتر تأثیر دارد و وقتی گوشه در هر دو حد باقی بماند هیچ اثر ظاهری قابل مشاهده‌ای ندارد.

این مثال دو مثلث بدون پر، به‌عرض 20 پوینت، ایجاد می‌کند. مثلث چپ با محدودیت `2` و راست با `8` استفاده می‌کند. هر مثلث 80 پوینت عرض و 160 پوینت ارتفاع دارد که نسبت طول مایتر به عرض خط تقریباً `4.12` است. بنابراین PowerPoint آرسیس چپ را bevel می‌کند و آرسیس راست را حفظ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![آرسیس bevel با محدودیت مایتر 2 و آرسیس تیز با محدودیت مایتر 8 در PowerPoint](miter-limits.png)

## **پرکردن گرادیان**

پرکردن گرادیان رنگ‌ها را در یک شکل ترکیب می‌کند. این مثال یک بیضی را با گرادیان خطی با زاویه 45 درجه از قرمز به بنفش پر می‌کند با استفاده از [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). متد [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) رنگ‌ها را در موقعیت 0 و 1 (آغاز و پایان گرادیان) قرار می‌دهد. پاک کردن نقاط توقف موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آن در PowerPoint به‌نظر برسد، به [Choose a Gradient Rendering Style](/slides/fa/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندر انتخاب کنید بدون تغییر گرادیان ذخیره‌شده در ارائه.

### **تنظیم زاویه گرادیان خطی**

از [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) برای کنترل جهت یک پرکردن [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعتگرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ، و `270` از پایین به بالا. زوایا به صورت کسری نیز پشتیبانی می‌شوند. زوایای خارج از `[0, 360)` به یک دور نرمال می‌شوند؛ برای مثال `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل با نقاط توقف قرمز، سبز و آبی در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال است تا زاویه مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زوایا از چپ به راست در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه در PowerPoint:

![گرادیان‌های خطی با زوایای 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری یک گرادیان خطی با شکل**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) یک مقدار [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) می‌گیرد. آن را صراحتاً به `False_` تنظیم کنید تا زاویه هندسی گرادیان هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `True_` تا گرادیان با عرض و ارتفاع شکل مقیاس‌گذاری شود. با فعال‌سازی مقیاس‌گذاری، زاویه قابل رؤیت می‌تواند در یک شکل غیرمربع متفاوت از زاویه تخصیص‌یافته باشد.

مثال زیر از زاویه `45` درجه و همان نقاط توقف رنگی استفاده می‌کند. ستون چپ `False_` و ستون راست `True_` دارد. هر ستون شامل یک مستطیل عریض بالای یک مستطیل بلند است. هر دو با همان ابعاد عریض شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پرکردن چگونه به تغییر اندازه پاسخ می‌دهد بدون تغییر تنظیمات گرادیان.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در چپ و فعال در راست:

![مستطیل‌های عریض و بلند با گرادیان 45 درجه، مقایسه LinearGradientScaled False در چپ با True در راست](linear-gradient-scaling.png)

با مقیاس‌گذاری غیرفعال، نوارهای رنگی قطری جهت یکسانی در هر دو مستطیل حفظ می‌شوند. با مقیاس‌گذاری فعال، نوارها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا گرادیان یک قالب را هنگام تغییر اندازه شکل بازتولید کنید. در یک مربع، فعال‌سازی مقیاس‌گذاری ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس برای گرادیان‌های خطی اعمال می‌شوند. آن‌ها برای پرکردن‌های [GradientShape.Radial یا GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) کنترل ندارند.

### **ترکیب زاویه با جهت گرادیان**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزینی برای زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه توزیع رنگ‌ها را بدون تغییر زاویه‌ای که از طریق [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) اختصاص داده شده، تغییر دهند. هنگام مقایسه زوایا یا مقیاس‌گذاری، جهت را ثابت نگه دارید.

مثال زیر همان تنظیمات را در ترتیب مخالف اعمال می‌کند. دو مستطیل همان ظاهر را دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرکردن الگو**

یک پرکردن الگو یک طرح دو‌رنگی مانند نقطه‌ها، خط‌ها یا جدول‌ها اعمال می‌کند. این مثال از [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) برای انتخاب الگوی trellis استفاده می‌کند. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) پس‌زمینه خاکستری روشن را فراهم می‌کند و [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) رنگ زرد الگو را می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

یک پرکردن تصویر از یک تصویر داخل شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) برای بارگذاری آن در مجموعه تصویر ارائه استفاده می‌کند. تنظیم [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) به حالت tiled تصویر را درون مستطیل تکرار می‌کند. تصویر منبع در زیر نشان داده شده است:

![تصویر لوتوس](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![شکل با پرکردن تصویر](picture-fill.png)

### **تایل تصویر به‌عنوان تکسچر**

اگر می‌خواهید یک تصویر تایل‌شده را به‌عنوان تکسچر تنظیم کنید و رفتار تایل را سفارشی کنید، می‌توانید از متدهای زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پرکردن تصویر—`Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): هم‌ترازی تایل‌ها درون شکل.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): کنترل چرخش افقی، عمودی یا هر دو.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): تنظیم افست افقی تایل (به پوینت) از مبداء شکل.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): تنظیم افست عمودی تایل (به پوینت) از مبداء شکل.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): تعریف مقیاس افقی تایل به درصد.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): تعریف مقیاس عمودی تایل به درصد.

این مثال به یک تصویر محلی نیاز دارد و [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) را طوری تنظیم می‌کند که با 50٪ اندازه اصلی تکرار شود. افست‌های ‑32 پوینت تایل‌ها را به صورت افقی و عمودی جابجا می‌کند؛ هم‌ترازی پایین‑راست و چرخش در هر دو جهت تعیین می‌کند که تکسچر تکراری چگونه چیدمان شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![گزینه‌های تایل](tile-options.png)

## **پر کردن رنگ جامد**

یک پرکردن جامد به شکل یک رنگ یکنواخت می‌دهد. این مثال از [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) برای تنظیم حالت پرکردن جامد استفاده می‌کند و رنگ زرد را از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![شکل با پرکردن رنگ جامد](solid-color-fill.png)

### **کپی رنگ‌ها با حفظ ارجاع به تم**

از [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) برای کپی یک تعریف رنگ، شامل نوع رنگ، ارجاع به تم و تبدیلات استفاده کنید. این برای انتقال رنگ پرکردن بین شکل‌هایی که باید پیگیر تم ارائه باشند مفید است. این متد فقط رنگ را کپی می‌کند؛ نوع پر، خط یا سایر قالب‌بندی‌های شکل را کپی نمی‌کند. نوع پر مقصد را صراحتاً با [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) تنظیم کنید.

این مثال سه مستطیل از چپ به راست ایجاد می‌کند: منبع، کپی آگاهی‑از‑تم، و کپی RGB ثابت. منبع با استفاده از [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) به اولین رنگ تاکید ارجاع می‌دهد و یک تیره با [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add) اضافه می‌کند. کپی RGB از رنگ پر موثر منبع استفاده می‌کند تا هر سه در ابتدا یک‌سان به‌نظر برسند. فراخوانی [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) یک مقدار RGB ثابت تنظیم می‌کند و هر تبدیلات رنگ موجود را پاک می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # ارجاعات تم رنگ تأکید جدید را دنبال می‌کنند؛ مقدار ثابت RGB این‌گونه نیست.
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

قبل از تغییر تم، هر سه پر یکسان هستند:

![منبع، مقصد copyFrom و مقصد RGB ثابت با پرهای آبی یکسان](color-copy-before.png)

بعد از تغییر تم، منبع و کپی آگاهی‑از‑تم رنگ تأکید جدید را دنبال می‌کنند و تیره خود را حفظ می‌کنند. کپی ثابت RGB آبی می‌ماند:

![منبع و مقصد copyFrom با پرهای نارنجی، در حالی که مقصد RGB ثابت آبی می‌ماند](color-copy-after.png)

تعریف کپی‌شده مستقل از منبع است. تغییر پس‌آن ارجاع تم منبع، تخصیص رنگ دیگر، یا اضافه/حذف تبدیلات آن، مقصد را تغییر نمی‌دهد. تغییر تم همچنان هر دو شکل را تحت تأثیر قرار می‌دهد چون هر کدام به طور مستقل به همان رنگ تم ارجاع می‌دهند.

ذخیره و بازخوانی PPTX نوع رنگ کپی‌شده برگردانده شده توسط [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType)، ارجاع تم و مجموعه تبدیلات برگردانده‌شده توسط [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform) را حفظ می‌کند؛ آن را به RGB مسطح نمی‌کند.

زمانی که بین زمینه‌های تم مختلف (مانند ارائه‌های با پالت تأکید متفاوت) کپی می‌کنید، ارجاع کپی‌شده نسبت به تم مقصد حل می‌شود. بنابراین همان ارجاع و تبدیلات می‌تواند رنگ قابل مشاهده متفاوتی تولید کند. برای اطلاعات بیشتر درباره پیکربندی رنگ‌های تم به [Presentation Theme](/slides/fa/python-java/presentation-theme/) مراجعه کنید.

## **استفاده از پس‌زمینه اسلاید به‌عنوان پرشدگی شکل**

از [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) زمانی که یک شکل باید با پس‌زمینه اسلاید مطابقت داشته باشد، برای مثال در یک قالب ارائه، استفاده کنید. ابتدا نوع پر را با [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) به [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) تنظیم کنید تا هر پر صریحی حذف شود. با این ترکیب، شکل به‌جای سبک پر خود، از پس‌زمینه اسلاید استفاده می‌کند. فعال‌سازی پرچم به تنهایی پر صریح موجود را حذف نمی‌کند.

این با [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) متفاوت است: پر پس‌زمینه اشیائی که پشت شکل هستند را با ناحیه متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پر آن اشیاء قابل رؤیت می‌مانند. یک گرادیان در این حالت با اسلاید هم‌راستا می‌ماند نه داخل هر شکل مجدداً شروع می‌شود.

مثال زیر یک پس‌زمینهٔ اصلی که به اسلاید ارث می‌رسد ایجاد می‌کند و یک نوار سرخ‌نمسار را پشت سه مستطیل قرار می‌دهد. مستطیل سمت چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی هیچ پر ندارند، و مستطیل سمت راست از پر پس‌زمینه به پر صریح نارنجی تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # گرادیان را از مستر به‌ارث ببرید.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # این شیء را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # قبل از اعمال پر کردن صریح، پر کردن پس‌زمینه را غیرفعال کنید.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه، از چپ به راست: **پر پس‌زمینه**، **بدون پر** و **پر صریح**. نوار سرخ‌نمسار توسط مستطیل چپ و راست مخفی می‌شود اما از طریق مستطیل میانی قابل رؤیت است.

![پر پس‌زمینه، بدون پر و پر صریح نارنجی روی نوار سرخ‌نمسار](background-fill.png)

رفتار مشابه برای پس‌زمینه‌ای که مستقماً بر روی اسلاید تعریف شده یا از یک طرح ارث می‌گیرد اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شده اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و طرح را تعریف‌نشده رها می‌کند تا اصلی آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پر کردن جامد، مؤلفه آلفای رنگ، شفافیت را کنترل می‌کند: 0 کاملاً شفاف و 255 کاملاً کدر است. این مثال از مقدار آلفا 128 برای یک مستطیل زرد استفاده می‌کند که تقریباً 50٪ شفاف است تا مستطیل زیرین قابل رؤیت بماند. رنگ از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن شکل‌ها**

از [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) برای چرخاندن یک شکل در صفحه اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را 5 درجه ساعتگرد می‌چرخاند و ارائه را ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برش 3‑بعدی**

از [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) برای افزودن عمق و لبه‌های برش‌دار به یک شکل استفاده کنید. این مثال یک بیضی سبز با خط بیرونی نارنجی ایجاد می‌کند، از [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) برای تنظیم عمق به 4 پوینت استفاده می‌کند و از [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) برای اعمال یک برش بالای دایره‌ای با عرض و ارتفاع 6 پوینت بهره می‌گیرد. یک دوربین ارتوگرافیک به سمت جلو و نور سه‌نقطه‌ای برش را قابل رؤیت می‌سازند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![افکت برش 3‑بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3‑بعدی**

نمای 3‑بعدی یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) با زاویه‌های عرض، طول و چرخش به ترتیب 40، 35 و 20 درجه استفاده می‌کند. یک دوربین ایزومتریک را از طریق [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) و نور متعادل را از طریق [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) انتخاب می‌کند، سپس مستطیل قالب‌بندی‌شده را ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![افکت چرخش 3‑بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای شکل‌ها**

متد [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) تعیین می‌کند که یک شکل به‌صورت فردی چگونه در حالت سیاه‑سفید رندر شود هنگامی که ارائه در حالت سیاه‑سفید مشاهده یا پردازش می‌شود. این خود به‌تنهایی نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی پر، خط یا سایر ویژگی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال `Automatic` اجازه می‌دهد برنامه رندر انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت، `Color` رنگ طبیعی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به معنای عدم تخصیص حالت در سطح شکل است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) برای تنظیم حالت به خاکستری استفاده می‌کند. شکل ذخیره‌شده پر نارنجی خود را برای نمایش رنگی عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، درخواست رنگ خاکستری می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در حالت رنگ عادی، مستطیل پر نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray` از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد اسلاید رنگ کامل را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا دیگر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) برای بازگرداندن موقعیت، اندازه و قالب‌بندی مکان‌گیرهای اسلاید از مکان‌گیرهای متناظر در چیدمان استفاده کنید. این مثال به یک ارائه موجود با مکان‌گیرهای لینک‌شده به چیدمان نیاز دارد و قبل از ذخیره، هر اسلاید را بازنشانی می‌کند. شکل‌هایی که مکان‌گیر متناظر در چیدمان ندارند بازنشانی نمی‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت عموماً داده کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پرکردن‌های تصویری می‌توانند حجم فایل را افزایش دهند زیرا تصاویرشان در ارائه ذخیره می‌شود.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسان دارند شناسایی کنم تا آنها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی شکل‌ها—پر، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر مربوطه یکسان باشند، سبک آنها را یکسان در نظر بگیرید و آن شکل‌ها را منطقیاً گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. شکل‌های نمونه با سبک‌های موردنظر را در یک دک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، شکل‌های سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آنها را در هر مکانی که لازم است اعمال کنید.