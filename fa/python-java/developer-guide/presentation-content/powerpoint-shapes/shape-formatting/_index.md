---
title: قالب‌بندی اشکال PowerPoint در Python از طریق Java
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌خط
- خط طرح‌خط شکل
- قالب‌بندی سبک اتصال
- پرکننده گرادیان
- پرکننده الگو
- پرکننده تصویر
- پرکننده بافت
- پرکننده رنگ جامد
- شفافیت شکل
- رندر سیاه‌سفید شکل
- رندر خاکستری شکل
- چرخش شکل
- افکت برجسته 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "بیاموزید چگونه اشکال PowerPoint را در Python از طریق Java با استفاده از Aspose.Slides قالب‌بندی کنید—پرکننده، خط و سبک‌های افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

اشکال را در PowerPoint با تنظیم خطوط مرزی، پرکننده‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides for Python via Java به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی 3D.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java کلاس‌ها و متدهایی فراهم می‌کند که به شما اجازه می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) برای کنترل مرز یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکننده با مرز آبی و خط‌چین ایجاد می‌کند. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) یک خط ترکیبی ضخیم-نازک را انتخاب می‌کند، در حالی که [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) عرض آن را به 7 پوینت تنظیم می‌کند و [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) الگوی خط‌چین را انتخاب می‌کند.

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

### **تنظیم الگوهای دلخواه خط‌چین**

از [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) وقتی سبک‌های پیش تعریف‌شده خطوط طول و فاصله‌ای که نیاز دارید را فراهم نمی‌کنند، برای مثال برای خطوط برند یا نمودارهای فنی، استفاده کنید. اختصاص یک الگو به‌طور خودکار سبک خط‌چین را به [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به‌صورت متناوب بین طول خط و فاصله جابجا می‌شوند، با یک خط شروع می‌شوند. هر مقدار مضربی از عرض خط است: `[4, 2]` با عرض 3 پوینت یک خط 12‑پونتی سپس یک فاصله 6‑پونتی تولید می‌کند. از جفت‌های مقادیر محدود، غیرمنفی برای تعریف بخش‌های کامل خط‑و‑فاصله استفاده کنید. مثال از مقادیر مثبت برای دیدنی نگه داشتن هر خط و فاصله استفاده می‌کند.

این مثال پنج خط آبی با طول یکسان و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را با عرض 3 پوینت مقایسه می‌کنند. خط چهارم الگوی اول را با دوبرابر عرض تکرار می‌کند و هر دو طول خط و فاصله را دو برابر می‌کند. خط پنجم از الگوی دلخواه به خط پیوسته تغییر می‌یابد.

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

    # خط آخر را به سبک جامد بر می‌گردانیم.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای بازگشت به یک سبک پیش‌تعریف‌ شده خط‌چین، به‌جای آن، [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) را به [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) پاس دهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی دلخواه خط‌چین، یک خط پهن‌تر با استفاده از الگوی اول، و یک خط پیوسته در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) برای تنظیم پایان‌های یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) سه سبک صریح سر خط ارائه می‌دهد:

- `Flat`: خط در نقطه انتهایی متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای به اندازه نصف عرض خط، بیرون از نقطه انتهایی گسترش می‌یابد.
- `Square`: یک سر مربعی به اندازه نصف عرض خط، بیرون از نقطه انتهایی گسترش می‌یابد.

کلاس همچنین `NotDefined` را شامل می‌شود که به این معناست که هیچ سبک سر صریحی اختصاص داده نشده است.

سرها متفاوت از سرهای پیکان هستند که نمادها را به انتهای خطوط اضافه می‌کنند، و از اتصالات که زاویه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرهای پیکان را از طریق [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) غیرفعال می‌کند تا فقط شکل‌های سر مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان، به‌عرض 20 پوینت ایجاد می‌کند. از بالا به پایین، سرهای flat، round و square استفاده می‌شوند. نقاط انتهایی آن‌ها دارای مختصات افقی یکسان هستند؛ سرهای round و square هر کدام 10 پوینت بیش‌تر از نقطه انتهایی امتداد می‌یابند.

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

نتیجه در PowerPoint، از بالا به پایین: **Flat**، **Round** و **Square**.

![سرهای صاف، گرد و مربع روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت طرح‌خط روی خطوط شکل**

یک افکت طرح‌خط باعث می‌شود خط شکل شبیه به دست‌نویس به نظر برسد. از [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) برای دسترسی به تنظیمات خط، از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) برای دسترسی به تنظیمات طرح‌خط، و از [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) برای انتخاب یک مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) استفاده کنید.

کد زیر در Python نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) اعمال شود، مقدار اختصاص‌یافته صریحاً خوانده شود، و افکت با [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) حذف شود:

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

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) بازگردانده می‌شود، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برود، از [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) استفاده کنید و نوع طرح‌خط را از قالب‌بندی مؤثر بازگردانده شده بخوانید، همان‌طور که در ادامه نشان داده شده است. مقدار مؤثر نمایانگر قالب‌بندی است که پس از حل ارث‌بری واقعاً اعمال می‌شود. این مثال نیاز به یک ارائه موجود دارد که حداقل یک شکل در اسلاید اول داشته باشد و هر دو مقدار را چاپ می‌کند:

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

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینه نوع اتصال آورده شده است:

* گرد
* نوک‌تیغی
* ناهموار

سبک اتصال کنترل می‌کند دو بخش مرز چگونه در یک گوشه به هم می‌رسند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter**، یا برای گوشه‌های مسطح از **Bevel** استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط مرزی آبی به‌عرض 15 پوینت ایجاد می‌کند. از [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) برای تنظیم مقادیر نوک‌تیغی، ناهموار و گرد کلاس [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) به‌ترتیب استفاده می‌شود تا نحوه رسم گوشه‌ها مقایسه شود.

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

### **محدود کردن نوک‌تیغی‌ها در گوشه‌های تیز**

از [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) همراه با [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) که به [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) تنظیم شده است، برای محدود کردن طول گسترش یک گوشه تیز استفاده کنید.

محدودیت نسبت‌ایی از فاصله بین گوشه‌های داخلی و خارجی اتصال به عرض خط است. برای مثال، مقدار `8` اجازه می‌دهد طول نوک‌تیغی تا هشت برابر عرض خط باشد؛ این یک اندازه‌گیری به پوینت نیست. اگر گوشه بیش از حد مجاز باشد، PowerPoint در آن گوشه از اتصال ناهموار استفاده می‌کند. محدودیت بزرگ‌تر نقاط تیزتر را امکان‌پذیر می‌سازد. این تنظیم فقط بر نوک‌تیغی‌ها اثر دارد و تغییر آن وقتی گوشه در هر دو حد باقی می‌ماند، تأثیر قابل مشاهده‌ای ندارد.

این مثال دو مثلث یکسان، بدون پرکننده، با خطوط مرزی به‌عرض 20 پوینت ایجاد می‌کند. مثلث چپ از محدودیت `2` و راست از `8` استفاده می‌کند. هر مثلث به‌عرض 80 پوینت و ارتفاع 160 پوینت است، به‌طوری که نسبت طول نوک‌تیغی به عرض خط در گوشه بالایی تقریباً `4.12` است. بنابراین، PowerPoint نوک چپ را به‌صورت ناهموار تبدیل می‌کند و نوک راست را حفظ می‌کند.

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

![یک نوک‌تیغی ناهموار با محدودیت 2 و یک نوک‌تیغی نقطه‌ای با محدودیت 8 در PowerPoint](miter-limits.png)

## **پرکننده گرادیان**

یک پرکننده گرادیان رنگ‌ها را در سراسر یک شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی با زاویه 45 درجه از قرمز به ارغوانی پر می‌کند با استفاده از [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). متد [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) نقاط رنگ را در 0 و 1، یعنی ابتدا و انتهای گرادیان قرار می‌دهد. پاک‌سازی نقاط رنگ موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

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

![بیضی با پرکننده گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادر شده متفاوت از این باشد که در PowerPoint دیده می‌شود، به [Choose a Gradient Rendering Style](/slides/fa/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندر انتخاب کنید بدون اینکه پرکننده گرادیان ذخیره‌شده در ارائه را تغییر دهید.

### **تنظیم زاویه گرادیان خطی**

از [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) برای کنترل جهت یک پرکننده [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعتگرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زوایای کسری پشتیبانی می‌شوند. زوایای محدود خارج از `[0, 360)` به یک دوره کامل نرمال می‌شوند؛ مثلا `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل با نقاط رنگ قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال است تا زاویه بتواند مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زوایا، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

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

![گرادیان‌های خطی با زاویه‌های 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری گرادیان خطی با شکل**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) یک مقدار از نوع [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) می‌گیرد. به‌صورت صریح به `False_` تنظیم کنید تا زاویه هندسی گرادیان با تغییر نسبت‌های شکل ثابت بماند، یا به `True_` تا گرادیان با عرض و ارتفاع شکل مقیاس‌گذاری شود. وقتی مقیاس فعال باشد، زاویه قابل مشاهده می‌تواند با زاویه اختصاصی در یک شکل غیر مربع متفاوت باشد.

مثال زیر از زاویه `45` درجه و همان نقاط رنگی که در مقایسه زاویه استفاده شد، استفاده می‌کند. ستون چپ از `False_`؛ ستون راست از `True_` استفاده می‌کند. هر ستون شامل یک مستطیل پهن بالای یک مستطیل بلند است. هر دو با ابعاد پهن یکسان شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پرکننده چگونه بدون تغییر تنظیمات گرادیان به تغییر اندازه واکنش نشان می‌دهد.

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

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های پهن و بلند با گرادیان 45 درجه، مقایسه LinearGradientScaled False در چپ با True در راست](linear-gradient-scaling.png)

با مقیاس‌گذاری غیرفعال، نوارهای رنگی مورب جهت یکسانی را در هر دو مستطیل حفظ می‌کنند. با مقیاس‌گذاری فعال، نوارها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا گرادیان یک قالب را هنگام تطبیق شکل با اندازه متفاوت بازتولید کنید. در یک مربع، فعال کردن مقیاس‌گذاری ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس‌گذاری برای گرادیان‌های خطی اعمال می‌شوند. آنها رنگ‌های [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) را کنترل نمی‌کنند.

### **ترکیب زاویه با جهت گرادیان**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین یک زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه‌ای که رنگ‌ها در آن توزیع می‌شوند را بدون تغییر زاویه اختصاصی توسط [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) تغییر دهند. هنگام مقایسه زوایا یا مقیاس‌گذاری، جهت را همان‌جا نگه دارید.

مثال زیر همان تنظیمات را به ترتیب مخالف اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییری نمی‌دهد.

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

## **پرکننده الگو**

یک پرکننده الگو یک طراحی دو رنگی مانند نقطه‌ها، نوارها یا شطرنجی‌ها را اعمال می‌کند. این مثال از [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) برای انتخاب الگوی توری استفاده می‌کند. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) پس‌زمینه خاکستری روشن را فراهم می‌کند و [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) رنگ زرد الگو را تامین می‌کند.

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

![مستطیل با پرکننده الگو](pattern-fill.png)

## **پرکننده تصویر**

یک پرکننده تصویر یک تصویر را داخل یک شکل استفاده می‌کند. این مثال نیاز به یک تصویر محلی دارد و از [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) برای بارگذاری آن در مجموعه تصاویر ارائه استفاده می‌کند. تنظیم [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) به حالت tiled تصویر را در داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نمایش داده شده است:

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

![شکل با پرکننده تصویر](picture-fill.png)

### **تایل کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر تایل‌شده را به‌عنوان بافت تنظیم کنید و رفتار تایلینگ را سفارشی کنید، می‌توانید از روش‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پرکننده تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): تراز تایل‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند آیا تایل به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی تایل (به پوینت) نسبت به مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی تایل (به پوینت) نسبت به مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی تایل را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی تایل را به‌صورت درصد تعریف می‌کند.

این مثال نیاز به یک تصویر محلی دارد و [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) را طوری پیکربندی می‌کند که آن را با 50٪ از اندازه اصلی تکرار کند. افست‌های ‑32 پوینت تایل‌ها را به صورت افقی و عمودی جابجا می‌کند؛ تراز پایین‑راست و وارون شدن در هر دو جهت تعیین می‌کند که بافت تکراری چگونه چیده شود.

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

## **پرکننده رنگ جامد**

یک پرکننده جامد یک رنگ یکنواخت به شکل می‌بخشد. این مثال از [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) برای تنظیم حالت پرکننده جامد استفاده می‌کند و رنگ زرد را از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

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

![شکل با پرکننده رنگ جامد](solid-color-fill.png)

## **استفاده از پس‌زمینه اسلاید به‌عنوان پرکننده شکل**

از [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) وقتی که یک شکل باید با پس‌زمینه اسلاید مطابقت داشته باشد، مثلاً در یک الگوی ارائه، استفاده کنید. ابتدا [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) را به [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) تنظیم کنید تا هر پرکننده صریحی حذف شود. با این ترکیب، شکل به جای پرکننده سبک خود، از پس‌زمینه اسلاید استفاده می‌کند. فعال‌سازی پرچم به تنهایی پرکننده صریح موجود را حذف نمی‌کند.

این رفتار با [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) متفاوت است: پرکننده پس‌زمینه اشیاء پشت شکل را با ناحیه متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پرکننده آن اشیاء قابل مشاهده می‌مانند. یک گرادیان همچنان با اسلاید هم‌راستا می‌ماند و داخل هر شکل از نو شروع نمی‌شود.

مثال زیر یک پس‌زمینه اصلی که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و یک نوار سرخ‌کمانی را پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل وسط بدون پرکننده است و مستطیل راست از پرکننده پس‌زمینه به یک پرکننده نارنجی صریح تغییر می‌کند.

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

    # ارث‌بری گرادیان از مستر.
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

    # این شیء را اول اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
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

    # غیرفعال کردن پرکننده پس‌زمینه قبل از اعمال پرکننده صریح.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه، از چپ به راست: **background fill**, **no fill**, و **explicit fill**. نوار سرخ‌کمانی توسط مستطیل‌های چپ و راست پنهان می‌شود اما از طریق مستطیل وسط قابل مشاهده باقی می‌ماند.

![پرکننده پس‌زمینه، بدون پرکننده و پرکننده نارنجی صریح روی یک نوار سرخ‌کمانی](background-fill.png)

همان رفتار برای پس‌زمینه‌ای که مستقیماً بر اسلاید تعریف شده یا از یک چیدمان به ارث می‌رسد، اعمال می‌شود. شکل از پس‌زمینه حل‌شده اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینه اسلاید و چیدمان را undefined می‌گذارد تا مستند اصلی آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پرکننده جامد، مؤلفه آلفای رنگ کنترل‌کننده شفافیت است: 0 کاملاً شفاف و 255 کاملاً مات است. این مثال از مقدار آلفا 128 برای یک مستطیل زرد استفاده می‌کند، تقریباً 50٪ شفاف می‌سازد تا مستطیل زیرین قابل رؤیت باشد. رنگ از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص داده می‌شود.

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

## **چرخاندن اشکال**

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

## **اضافه‌کردن افکت‌های برجسته 3D**

از [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) برای افزودن عمق و لبه‌های برجسته به یک شکل استفاده کنید. این مثال یک بیضی سبز با خط مرزی نارنجی ایجاد می‌کند، از [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) برای تنظیم عمق به 4 پوینت استفاده می‌کند و از [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) برای اعمال یک برجسته گرد بالا با عرض و ارتفاع 6 پوینت استفاده می‌کند. یک دوربین ارتوگرافیک روبه‌رو و نور سه‌نقطه‌ای برجسته را قابل مشاهده می‌سازند.

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

![افکت برجسته 3D](3D-bevel-effect.png)

## **اضافه‌کردن افکت‌های چرخش 3D**

نمایش 3D یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) با زوایای عرض، طول و انقلاب به ترتیب 40، 35 و 20 درجه استفاده می‌کند. یک دوربین ایزومتریک از طریق [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) و نورپردازی متعادل از طریق [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) انتخاب می‌شود، سپس مستطیل قالب‌بندی‌شده ذخیره می‌گردد.

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

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‌سفید برای اشکال**

متد [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) مشخص می‌کند یک شکل به‌طور جداگانه چگونه رندر می‌شود وقتی ارائه در حالت سیاه‌سفید مشاهده یا پردازش می‌شود. این متد به تنهایی نمایش سیاه‌سفید را فعال نمی‌کند و پرکننده، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگ طبیعی تغییر نمی‌دهد.

از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) برای انتخاب رفتار دلخواه استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندر تبدیلات را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به کار می‌برد، `Black` و `White` یک رنگ واحد را اعمال می‌کنند، `Color` رنگ نرمال را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‌سفید حذف می‌کند. `NotDefined` به این معناست که هیچ حالت سطح‑شکل اختصاص داده نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) برای تنظیم حالت به `Gray` استفاده می‌کند. شکل ذخیره‌شده پرکننده نارنجی خود را برای نمایش رنگ طبیعی حفظ می‌کند و برای برنامه‌های احترام‌گذار به تنظیمات نمایش سیاه‌سفید، درخواست رنگ خاکستری می‌کند:

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

در حالت رنگ طبیعی، مستطیل پرکننده نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‌سفید، به‌دلیل تنظیم حالت به `Gray` از رنگ خاکستری استفاده می‌کند. این به شما اجازه می‌دهد یک اسلاید رنگی کامل را حفظ کنید و در عین حال ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) برای بازگرداندن موقعیت، اندازه و قالب‌بندی مکان‑نگهدارهای اسلاید از مکان‑نگهدارهای متناظر در چیدمان استفاده کنید. این مثال نیاز به یک ارائه موجود دارد که مکان‑نگهدارهای مرتبط با چیدمان داشته باشد و قبل از ذخیره‌سازی هر اسلاید را بازنشانی می‌کند. اشکالی که مکان‑نگهدار متناظر در چیدمان ندارند، بازنشانی نمی‌شوند.

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

## **سوالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت به‌طور کلی داده کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پرکننده‌های تصویری می‌توانند حجم فایل را افزایش دهند زیرا تصاویرشان در ارائه ذخیره می‌شود.

**چگونه می‌توانم اشکالی را در یک اسلاید شناسایی کنم که قالب‌بندی یکسانی دارند تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پرکننده، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک‌های آن‌ها را یک‌سان درنظر بگیرید و منطقا آن اشکال را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در آینده ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر دوباره استفاده کنم؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را هرجا که لازم باشد مجدداً اعمال کنید.