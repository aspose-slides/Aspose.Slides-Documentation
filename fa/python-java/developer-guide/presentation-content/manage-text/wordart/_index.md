---
title: ایجاد و اعمال افکت‌های WordArt در Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /fa/python-java/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- افکت WordArt
- افکت سایه
- افکت بازتاب
- افکت تابش
- تبدیل WordArt
- افکت 3D
- افکت سایه خارجی
- افکت سایه داخلی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Python via Java. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در Python via Java بهبود دهند."
---
## **بررسی کلی**

افکت‌های WordArt به شما امکان می‌دهد متن‌های بصری جذاب و استایل‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله نمای کلی کار با WordArt را ارائه می‌دهد، از جمله نحوه اعمال تبدیلات متن، سبک‌های پرکردن، خطوط حاشیه، سایه‌ها و دیگر گزینه‌های قالب‌بندی برای جذاب‌تر و بی‌نظیرتر کردن محتوای ارائه. WordArt به شما اجازه می‌دهد متن را به‌عنوان یک شیء گرافیکی در نظر بگیرید. این افکت‌ها یا تغییرات خاصی هستند که بر متن اعمال می‌شوند تا جذاب‌تر یا قابل‌توجه‌تر باشد.

## **ایجاد الگوی ساده WordArt و اعمال آن بر متن**

**استفاده از Aspose.Slides**

در ابتدا، متن ساده‌ای را با این کد Python ایجاد می‌کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
سپس برای واضح‌تر شدن افکت، اندازه قلم را افزایش می‌دهیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**استفاده از Microsoft PowerPoint**

به منوی افکت‌های WordArt در Microsoft PowerPoint بروید:

![منوی افکت‌های WordArt در PowerPoint](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک افکت WordArt پیش‌فرض را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات WordArt جدید را مشخص کنید.

برخی از پارامترها یا گزینه‌های موجود عبارتند از:

![گزینه‌های قالب‌بندی WordArt](image-20200930114015-3.png)

**استفاده از Aspose.Slides**

در اینجا، با کد زیر پرکنش الگوی [PatternStyle.SmallGrid](https://reference.aspose.com/slides/fa/python-java/aspose.slides/patternstyle/#SmallGrid) را به متن اعمال می‌کنیم و یک حاشیه متن سیاه اضافه می‌کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

متن حاصل:

![متن با پرکنش الگو و حاشیه سیاه](image-20200930114108-4.png)

## **اعمال سایر افکت‌های WordArt**

**استفاده از Microsoft PowerPoint**

از طریق رابط برنامه می‌توانید این افکت‌ها را بر متن، بلوک متن، شکل یا عنصر مشابه اعمال کنید:

![افکت‌های متن و شکل در PowerPoint](image-20200930114129-5.png)

به‌عنوان مثال، افکت‌های سایه، بازتاب و تابش را می‌توانید بر متن اعمال کنید؛ افکت‌های قالب 3D و چرخش 3D را می‌توانید بر بلوک متن اعمال کنید؛ افکت لبه‌های نرم را می‌توانید بر یک شکل اعمال کنید (در نبود افکت قالب 3D نیز اثر خود را دارد).

### **اعمال افکت‌های سایه**

کد Python زیر فقط یک افکت سایه را بر متن اعمال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

API Aspose.Slides از سه نوع سایه پشتیبانی می‌کند: [OuterShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/outershadow/)، [InnerShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/innershadow/) و [PresetShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presetshadow/).

با استفاده از [PresetShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presetshadow/)، می‌توانید یک سایه با مقادیر پیش‌نشانده شده بر متن اعمال کنید.

**استفاده از Microsoft PowerPoint**

در PowerPoint می‌توانید فقط از یک نوع سایه استفاده کنید. در زیر یک مثال آورده شده است:

![تنظیمات سایه در PowerPoint](image-20200930114225-6.png)

**استفاده از Aspose.Slides**

Aspose.Slides در واقع اجازه می‌دهد دو نوع سایه را همزمان اعمال کنید: [InnerShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/innershadow/) و [PresetShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presetshadow/).

**نکات:**

- هنگام استفاده همزمان از [OuterShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/outershadow/) و [PresetShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presetshadow/)، فقط افکت [OuterShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/outershadow/) اعمال می‌شود.
- اگر [OuterShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/outershadow/) و [InnerShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/innershadow/) به‌طور همزمان استفاده شوند، اثر نهایی یا اعمال‌شده به نسخه PowerPoint بستگی دارد. به‌عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود؛ اما در PowerPoint 2007 فقط افکت [OuterShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/outershadow/) اعمال می‌شود.

### **اعمال بازتاب بر متن**

ما با این نمونه کد Python از طریق Java یک بازتاب به متن اضافه می‌کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **اعمال افکت تابش بر متن**

ما با این کد افکت تابش را به متن اعمال می‌کنیم تا بدرخشد یا برجسته شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

نتیجه عملیات:

![متن با افکت تابش](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}

شما می‌توانید پارامترهای سایه، بازتاب و تابش را تغییر دهید. ویژگی‌های افکت‌ها به‌صورت جداگانه بر هر بخش از متن تنظیم می‌شوند.

{{% /alert %}}

### **استفاده از تبدیلات در WordArt**

با استفاده از [TextFrameFormat.setTransform](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setTransform) می‌توانید کل بلوک متن را تبدیل کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

نتیجه:

![متن با تبدیل قوسی](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}

هر دو Microsoft PowerPoint و Aspose.Slides برای Python via Java تعدادی از انواع تبدیلات پیش‌نشانده را ارائه می‌دهند.

{{% /alert %}}

**استفاده از PowerPoint**

برای دسترسی به انواع تبدیلات پیش‌نشانده، به مسیر بروید: **Format** → **TextEffect** → **Transform**

**استفاده از Aspose.Slides**

برای انتخاب نوع تبدیل، از شمارش [TextShapeType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textshapetype/) استفاده کنید.

### **اعمال افکت‌های 3D بر متن و اشکال**

ما با این نمونه کد یک افکت 3D را بر یک شکل متن اعمال می‌کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

متن و شکل حاصل:

![شکل متن با افکت‌های 3D](image-20200930114816-9.png)

ما با این کد Python یک افکت 3D را بر متن اعمال می‌کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

نتیجه عملیات:

![متن با افکت‌های 3D](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}

اعمال افکت‌های 3D بر متن یا شکل‌های آن و تعامل بین افکت‌ها براساس قوانین خاصی انجام می‌شود.

یک صحنه برای متن و شکلی که متن را در بر می‌گیرد در نظر بگیرید. افکت 3D شامل یک نمایش شیء 3D و صحنه‌ای است که شیء در آن قرار دارد.

- وقتی صحنه برای هر دو شکل و متن تنظیم شده باشد، صحنه شکل اولویت دارد—صحنه متن نادیده گرفته می‌شود.
- وقتی شکل صحنه خود را ندارد ولی نمای 3D دارد، صحنه متن استفاده می‌شود.
- در غیر این صورت—وقتی شکل در اصل افکت 3D ندارد—شکل صاف است و افکت 3D فقط بر متن اعمال می‌شود.

این قوانین به متدهای [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getLightRig) و [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getCamera) مرتبط هستند.

{{% /alert %}}

## **اعمال افکت سایه خارجی بر متن**

Aspose.Slides برای Python via Java کلاس‌های [OuterShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/outershadow/) و [InnerShadow](https://reference.aspose.com/slides/fa/python-java/aspose.slides/innershadow/) را فراهم می‌کند که به شما اجازه می‌دهد افکت‌های سایه را بر متن در یک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) اعمال کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به اسلاید ارجاع پیدا کنید.
3. یک شکل مستطیلی به اسلاید اضافه کنید.
4. فریم متن مرتبط با شکل را دسترسی پیدا کنید.
5. پر کردن شکل را غیرفعال کنید.
6. افکت سایه خارجی را فعال کنید.
7. شعاع محو شدن سایه را تنظیم کنید.
8. جهت سایه را تنظیم کنید.
9. فاصله سایه را تنظیم کنید.
10. سایه را در بالا‑چپ تراز کنید.
11. رنگ سایه را به مشکی تنظیم کنید.
12. ارائه را به‌صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.

این کد نمونه در Python via Java—پیاده‌سازی مراحل فوق—نشان می‌دهد چگونه افکت سایه خارجی را بر متن اعمال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # دریافت مرجع اسلاید
    slide = presentation.getSlides().get_Item(0)

    # اضافه کردن AutoShape از نوع Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # اضافه کردن TextFrame به Rectangle
    auto_shape.addTextFrame("Aspose TextBox")

    # غیرفعال کردن پرکردن شکل در صورتی که بخواهیم سایه متن را دریافت کنیم
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # اضافه کردن سایه بیرونی و تنظیم تمام پارامترهای لازم
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # ذخیره ارائه در دیسک
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اعمال افکت سایه داخلی بر اشکال**

مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. ارجاع اسلاید را دریافت کنید.
3. یک شکل مستطیلی اضافه کنید.
4. افکت سایه داخلی را فعال کنید.
5. تمام پارامترهای ضروری را تنظیم کنید.
6. نوع رنگ سایه را برای استفاده از رنگ تم تنظیم کنید.
7. رنگ تم را تنظیم کنید.
8. ارائه را به‌صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.

این کد نمونه (بر پایه مراحل بالا) نشان می‌دهد چگونه افکت سایه داخلی را بر متن داخل یک شکل در Python via Java اعمال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # دریافت مرجع اسلاید
    slide = presentation.getSlides().get_Item(0)

    # اضافه کردن AutoShape از نوع Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # اضافه کردن TextFrame به Rectangle
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # فعال‌سازی InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # تنظیم تمام پارامترهای لازم
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # تنظیم ColorType به عنوان Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # تنظیم Scheme Color
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # ذخیره ارائه
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم افکت‌های WordArt را با قلم‌ها یا اسکریپت‌های متفاوت (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام قلم‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکنش و حاشیه بدون توجه به زبان قابل اعمال هستند، هرچند دسترسی به قلم و رندر ممکن است به قلم‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را بر عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را بر شکل‌های مستر اسلاید، از جمله نگهدارنده‌های عنوان، فوتر یا متن پس‌زمینه اعمال کنید. تغییرات انجام‌شده در طرح مستر در تمام اسلایدهای مرتبط منعکس می‌شود.

**آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارند؟**

به‌صورت کمی. افکت‌های WordArt مانند سایه‌ها، تابش‌ها و پرکنش‌های گرادیان می‌توانند به‌طور جزئی حجم فایل را به دلیل افزودن فراداده‌های قالب‌بندی افزایش دهند، اما تفاوت معمولاً ناچیز است.

**آیا می‌توانم پیش‌نمایش نتیجه افکت‌های WordArt را بدون ذخیره ارائه ببینم؟**

بله، می‌توانید اسلایدهای شامل WordArt را به تصاویر (مثلاً PNG، JPEG) رندر کنید با استفاده از [Shape.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) یا [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage). این امکان پیش‌نمایش نتایج را به‌صورت در‑حافظه یا روی صفحه قبل از ذخیره یا استخراج کل ارائه فراهم می‌کند.