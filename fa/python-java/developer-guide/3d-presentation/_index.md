---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از پایتون
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/python-java/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآمدگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن‌های PowerPoint در پایتون از طریق جاوا با Aspose.Slides. پیکربندی دوربین، نورپردازی، ماده، برآمدگی، پرکننده‌ها و متن سه‌بعدی."
---
## **نمای کلی**

Aspose.Slides برای Python از طریق Java می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برآمدگی، لبه‌دار کردن، نورپردازی، مواد، پرکننده‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی بر اشکال و متن‌های PowerPoint است. این دربارهٔ وارد کردن یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگامی که اسلایدی را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides آن اثرات سه‌بعدی را به خروجی دو‌بعدی صادرشده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از متد [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) برای اعمال قالب‌بندی سه‌بعدی بر یک شکل استفاده کنید. این متد یک [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این قالب‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

**مهم‌ترین اعضای API عبارتند از:**

| عضو API | آنچه را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | نقطهٔ دید، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا مطابقت با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهر برجسته‌ها و سایه‌ها روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | مواد سطح، مانند صاف، مات، پلاستیک یا فلز. | صاف‌تر، نرم‌تر، براق یا فلزی کردن یک هندسهٔ مشابه. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | میزان برآمدگی شکل از سطح جلویی به عقب. | تبدیل یک شکل مسطح به یک شیء سه‌بعدی قابل مشاهده. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ طرف‌های برآمده. | نمایش عمق یا هماهنگی رنگ طرف با پرکردن جلویی. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | عمق سه‌بعدی اضافی که توسط قالب‌بندی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های بالا یا پایین گرد یا برجسته بر روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) و [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | خطوط دور شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌طور قانع‌کننده‌ای سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلویی ممکن است برآمدگی را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث می‌شود سطوح و کناره‌ها قابل مشاهده باشند.
- تنظیمات مواد، زیرا سطح بر نحوه رندر نور تأثیر می‌گذارد.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل مسطح به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌نماید و قالب‌بندی سه‌بعدی را اعمال می‌کند. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع برآمدگی ۱۰۰ پوینт است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![تصویر رندر شدهٔ مستطیل سه‌بعدی آبی با متن سه‌بعدی سفید بر روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z مطابق با چرخشی است که از طریق API دوربین تنظیم می‌کنید.

![پنل چرخش 3‑بعدی PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، از طریق [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) به دوربین دسترسی پیدا کنید. این مثال یک مستطیل ایجاد می‌کند، نمای جلویی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌نماید. شکل را در حافظه پیکربندی می‌کند بدون اینکه فایلی ذخیره شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ مشاهدهٔ شیء توسط بیننده تغییر کند. این کار هندسهٔ دو‌بعدی شکل را در اسلاید تغییر نمی‌دهد؛ تنها نقطهٔ مشاهدهٔ سه‌بعدی که PowerPoint و Aspose.Slides هنگام رندر استفاده می‌کنند، تغییر می‌کند.

### **کپی جهت دوربین از شکل الگو**

برای مطابقت جهت یک شکل الگو، پیش‌تنظیم دوربین آن را با [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) خوانده و زوایای چرخش آن را با [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) به دست آورید. مثال فایل `template.pptx` را باز می‌کند و جهت دوربین اولین شکل در اولین اسلاید را به شکل دوم کپی می‌نماید. هر دو شکل قبلاً نور سه‌بعدی دارند و شکل دوم چرخش دوربین صریحی ندارد.

زاویه‌ها بر حسب درجه‌اند. اندیس `0` عرض جغرافیایی، اندیس `1` طول جغرافیایی و اندیس `2` دورانی است. آنها را به ترتیب به [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) پاس می‌دهید. اگر منبع `None` برگرداند، یعنی چرخش صریحی ندارد، بنابراین زاویه‌های شکل دوم تنظیم نمی‌شوند. یک چرخش صریح `(0, 0, 0)` سه صفر بر‌می‌گرداند و باید کپی شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هنگامی که `camera-copy.pptx` را در PowerPoint باز می‌کنید، پیکان سمت راست همان پیش‌تنظیم و چرخش دوربین را دارد که مستطیل سمت چپ دارد. هر دو شکل از نور و عمق برآمدگی یکسان استفاده می‌کنند.

![یک مستطیل سه‌بعدی آبی و یک پیکان راست با جهت دوربین هماهنگ، نمای بالا و راست](camera-orientation.png)

## **افزودن برآمدگی و عمق**

برآمدگی باعث می‌شود شکل از پشت سطح جلویی ضخیم شود. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌های جانبی را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint به رنگ برآمدگی و ویژگی‌های ارتفاع برآمدگی متناظر شده‌اند](img_02_02.png)

از [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) برای تعیین ضخامت و از [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) برای دسترسی به رنگ طرف‌ها استفاده کنید. این مثال به مستطیل ارتفاع برآمدگی ۱۰۰ پوینت با طرف‌های بنفش می‌دهد و دوربین را برای نمایش ضخامت می‌چرخاند. شکل را در حافظه پیکربندی می‌کند بدون ذخیرهٔ فایل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

متد [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) عمق یک شکل سه‌بعدی را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) ارتفاع اثر برآمدگی را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکننده‌های گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پر کردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکننده تصویر را بر سطح جلویی اعمال کنید و همچنان از همان دوربین، نور، ماده و تنظیمات برآمدگی استفاده کنید.

این مثال یک گرادیان از آبی به نارنجی را بر سطح جلویی اعمال می‌کند و رنگ نارنجی تیره‌ای به برآمدگی ۱۵۰ پوینت می‌دهد. نقاط توقف گرادیان در ۰ و ۱۰۰ نشان‌دهندهٔ شروع و پایان گرادیان هستند. مقادیر چرخش دوربین بر حسب درجه‌اند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

خروجی رندر شده گرادیان را بر روی سطح جلویی حفظ می‌کند و برآمدگی را به‌ طور جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکنندهٔ گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکنندهٔ تصویر، تصویر را به ارائه اضافه کنید و به پر کردن شکل اختصاص دهید. این مثال به فایلی به نام «image.jpg» در پوشهٔ کاری نیاز دارد. تصویر را برای پر کردن مستطیل کش می‌کند، برآمدگی ۱۵۰ پوینت اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل را در حافظه پیکربندی می‌کند بدون ذخیره یا رندر فایل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که برآمدگی به عنوان سطح جانبی سه‌بعدی رندر می‌گردد:

![مستطیل سه‌بعدی رندر شده با پرکنندهٔ عکس بر روی سطح جلویی و برآمدگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی بر متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر قاب متن تأثیر می‌گذارد. این برای اثراتی مشابه WordArt مفید است که حروف خود به برآمدگی، ماده، نور و تنظیمات دوربین نیاز دارند.

مثال زیر متنی با الگوی مشبک نارنجی‑سفید ایجاد می‌کند، یک قوس رو به بالا اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) پیکربندی می‌کند. ارتفاع برآمدگی و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه. پر کردن و خط دور شکل مخفی هستند تا تنها متن قابل رؤیت باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

متن به‌صورت حروف منحنی و برآمدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیلی قوسی WordArt، پرکنندهٔ الگوی نارنجی و برآمدگی تیره](img_02_05.png)

## **متن را بر روی شکل سه‌بعدی صاف نگه دارید**

برای حفظ خوانایی متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، از [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) از طریق [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) فراخوانی کنید. وقتی مقدار `True` باشد، متن از صحنهٔ سه‌بعدی خارج می‌ماند. وقتی `False` باشد، متن در صحنه شرکت می‌کند و جهت سه‌بعدی آن را دنبال می‌کند.

این تنظیم قالب‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و برآمدگی آن همچنان از طریق [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) تنظیم شده‌اند. این متفاوت از چرخش معمولی است. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) چرخش سفارشی متن را در داخل جعبه‌محیطی‌اش کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زوایا را بازنویسی نمی‌کند.

مثال زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار نسخهٔ اصلی کپی می‌کند. هر دو شکل همان قالب‌بندی سه‌بعدی را دارند؛ تنها تنظیم متن متفاوت است: `False` در سمت چپ و `True` در سمت راست. زاویه‌های دوربین بر حسب درجه‌اند و ارتفاع برآمدگی ۴۰ پوینت است. مثال ارائه را به صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

در سمت چپ، متن جهت سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواناتر است. هر دو مستطیل همان برآمدگی قابل مشاهده و جهت سه‌بعدی را حفظ کرده‌اند.

![مستطیل‌های سه‌بعدی کنار هم: متن در سمت چپ جهت سه‌بعدی را دنبال می‌کند و در سمت راست صاف می‌ماند](keep_text_flat.png)

## **رفتار صادرات و رندر**

Aspose.Slides هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX قالب‌بندی سه‌بعدی را حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های ثابت، صحنهٔ سه‌بعدی به‌صورت دو‌بعدی رستر یا رسم می‌شود. این موضوع هنگام رندر اسلایدها به [PNG](/slides/fa/python-java/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)، یا تولید فریم برای [تبدیل ویدیو](/slides/fa/python-java/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDF‌های صادرشده تعاملی نیستند. پس از صادرات، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، برآمدگی، پرکننده و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر قالب‌بندی به ارث‌برده یا مبتنی بر تم دارید، ویژگی‌های مؤثر شکل‌ها را از طریق [effective shape properties](/slides/fa/python-java/shape-effective-properties/) بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی PowerPoint را به‌صورت قابل ویرایش ذخیره کنند؛ در آن‌ها نتیجهٔ بصری رندر می‌شود نه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش.

## **سؤالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصویری، PDF یا صفحات HTML تعاملی سه‌بعدی تولید نمی‌کند که کاربر بتواند آن را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint قابل ویرایش باقی می‌ماند، مشروط بر اینکه فرمت از این قابلیت پشتیبانی کند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که به ارائه افزوده می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، لبه، نورپردازی و ماده. این مقاله به اثرهای سه‌بعدی می‌پردازد.

**کدام تنظیمات برای یک شکل سه‌بعدی قابل مشاهده ضروری هستند؟**

حداقل باید یک چرخش دوربین و یا برآمدگی/عمق تنظیم شود. در عمل، همچنین تنظیم نور و ماده توصیه می‌شود تا سطوح رندر شده برجستگی‌ها و سایه‌های واضحی داشته باشند.

**آیا می‌توانم اثرهای سه‌بعدی را هم به اشکال و هم به متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) و برای متن از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا اثرهای سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل به ویدیو، اثرهای سه‌بعدی را رندر می‌کند. خروجی صادرشده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌برداری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر که در [Shape Effective Properties](/slides/fa/python-java/shape-effective-properties/) توضیح داده شده‌اند، برای خواندن دوربین، نور، لبه و سایر مقادیر سه‌بعدی نهایی استفاده کنید.