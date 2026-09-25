---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها با Python
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/python-java/3d-presentation/
keywords:
- PowerPoint 3بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- استخراج سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "اعمال و رندر افکت‌های سه‌بعدی برای اشکال و متن PowerPoint در Python از طریق Java با Aspose.Slides. تنظیم دوربین، نورپردازی، ماده، استخراج، پرکن‌ها و متن سه‌بعدی."
---
## **نمای کلی**

Aspose.Slides برای Python از طریق Java می‌تواند قالب‌بندی 3بعدی سبک PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات 3بعدی مانند چرخش، خروجی، برجستگی‌ها، نورپردازی، مواد، پر کردن با گرادیان یا تصویر و متن 3بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله در مورد اثرات قالب‌بندی 3بعدی روی اشکال و متن PowerPoint است. درباره درج یا ویرایش فایل‌های مدل 3بعدی مستقل نیست. هنگامی که اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات 3بعدی را در خروجی 2بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی 3بعدی**

از متد [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) برای اعمال قالب‌بندی 3بعدی به یک شکل استفاده کنید. این متد یک شیء [ThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/) برمی‌گرداند که صحنهٔ 3بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این قالب‌بندی 3بعدی را به فریم متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | چه زمانی استفاده شود |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getCamera) | نقطهٔ دید، نوع دوربین پیش‌تنظیم، چرخش، زوم و پرسپکتیو. | برای چرخاندن شیء در فضای 3بعدی یا تطبیق با یک پیش‌تنظیم چرخش 3بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getLightRig) | تنظیم پیش‌فرض نور، جهت و چرخش نور. | برای تغییر ظاهر هایلایت‌ها و سایه‌ها روی سطح 3بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setMaterial) | مادهٔ سطح، مانند صاف، مات، پلاستیک یا فلز. | برای صاف‌تر، نرم‌تر، براق یا فلزی کردن همان هندسه. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setExtrusionHeight) | میزان پیش رفتن شکل به سمت عقب از سطح جلویی آن. | تبدیل یک شکل صاف به یک شیء 3بعدی واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ طرف‌های خروجی. | برای قابل دید شدن عمق یا هماهنگ کردن رنگ طرف‌ها با پر کردن جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setDepth) | عمق 3بعدی اضافی که توسط قالب‌بندی 3بعدی PowerPoint استفاده می‌شود. | برای تنظیم دقیق عمق اشکال یا متن، به‌ویژه همراه با تنظیمات برجستگی و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به‌جای یک سطح صاف تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setContourWidth) | خطوط مرزی اطراف شیء 3بعدی. | برجسته کردن حاشیهٔ شیء در خروجی رندر شده. |

## **ایجاد یک شکل 3بعدی**

یک شکل معمولاً قبل از اینکه به‌نظر قانع‌کنندهٔ 3بعدی باشد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلویی ممکن است خروجی را پنهان کند.
- تنظیمات نور، زیرا نورپردازی باعث قابل خواندن شدن سطوح و طرف‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوه رندر شدن نور تأثیر می‌گذارد.
- تنظیمات خروجی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند و قالب‌بندی 3بعدی را اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه است و ارتفاع خروجی 100 پوینت است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر کرده و ارائه را به صورت PPTX ذخیره می‌کند.

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

تصویر رندر شدهٔ اسلاید نشان می‌دهد که مستطیل به‌صورت یک بلوک ضخیم 3بعدی است:

![مستطیل آبی 3بعدی رندر شده با متن سفیده 3بعدی روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش 3بعدی از پنل چرخش 3‑بعدی پیکربندی می‌شود. مقادیر چرخش X، Y و Z با چرخشی که از طریق API دوربین تنظیم می‌کنید، مطابقت دارد.

![پنل چرخش 3‑بعدی PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، دوربین را از طریق [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getCamera) دسترسی می‌یابید. این مثال یک مستطیل ایجاد می‌کند، نمای جلوی ارتوگرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب به 20، 30 و 40 درجه تنظیم می‌نماید. شکل را در حافظه پیکربندی می‌کند بدون اینکه فایلی ذخیره شود:

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

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ دیدن شیء توسط بیننده را تغییر دهید. این تنظیمات هندسهٔ 2بعدی شکل روی اسلاید را تغییر نمی‌دهد؛ بلکه نقطهٔ دید 3بعدی مورد استفاده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **اضافه کردن خروجی و عمق**

خروجی باعث می‌شود شکل به‌صورت ضخیم به‌نظر برسد زیرا آن را به‌عقب از سطح جلویی می‌رساند. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ، رنگ طرف‌های جانبی را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ خروجی و ارتفاع خروجی نگاشت می‌شوند](img_02_02.png)

از [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setExtrusionHeight) برای تنظیم ضخامت و از [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionColor) برای دسترسی به رنگ جانبی استفاده کنید. این مثال به مستطیل ارتفاع خروجی 100 پوینت با طرف‌های بنفش می‌دهد و دوربین را چرخانده تا ضخامت آن را نشان دهد. شکل را در حافظه پیکربندی می‌کند بدون ذخیرهٔ فایل:

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

متد [ThreeDFormat.setDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setDepth) عمق یک شکل 3بعدی را تنظیم می‌کند. متد [setExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setExtrusionHeight) ارتفاع اثر خروجی را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پر کردن با گرادیان یا تصویر همراه با اثرات 3بعدی**

قالب‌بندی 3بعدی مستقل از پر کردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پر کردن تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و خروجی استفاده کنید.

این مثال یک گرادیان از آبی به نارنجی را به سطح جلویی اعمال می‌کند و رنگ نارنجی تیره‌ای به خروجی 150 پوینتی می‌دهد. نقاط توقف گرادیان در 0 و 100 شروع و پایان گرادیان را مشخص می‌کنند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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

خروجی رندر شده گرادیان را بر سطح جلویی حفظ می‌کند و خروجی را جداگانه رندر می‌کند:

![مستطیل 3بعدی رندر شده با پر کردن گرادیان آبی‑به‑نارنجی و خروجی نارنجی](img_02_03.png)

برای استفاده از پر کردن تصویر، تصویر را به ارائه اضافه کنید و به پر کردن شکل اختصاص دهید. این مثال نیاز به فایلی به نام «image.jpg» در پوشهٔ کاری دارد. تصویر را برای پر کردن مستطیل کشیده، خروجی 150 پوینتی اعمال و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل را در حافظه پیکربندی می‌کند بدون ذخیره یا رندر فایل:

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

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که خروجی به‌عنوان سطح جانبی 3بعدی رندر می‌شود:

![مستطیل 3بعدی رندر شده با پر کردن تصویر روی سطح جلویی و خروجی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی 3بعدی به متن**

قالب‌بندی 3بعدی شکل به بدنهٔ شکل اثر می‌گذارد. قالب‌بندی 3بعدی متن به فریم متن اثر می‌کند. این برای اثرات شبیه WordArt مفید است که حروف نیاز به خروجی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑سفید ایجاد می‌کند، یک قوس بالا را اعمال می‌کند و تنظیمات 3بعدی را از طریق [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) پیکربندی می‌نماید. ارتفاع خروجی و عمق بر حسب پوینت و چرخش نور بر حسب درجه هستند. پر کردن و خط دور شکل مخفی است تا فقط متن قابل مشاهده باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌کند:

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

متن به‌صورت حروف منحنی، خروجی‌دار 3بعدی رندر می‌شود:

![متن 3بعدی رندر شده با تبدیل کمان‌دار WordArt، پر کردن با الگوی نارنجی و خروجی تاریک](img_02_05.png)

## **متن را روی یک شکل 3بعدی صاف نگه دارید**

برای نگه داشتن متن قابل خواندن در حالی که ظاهر 3بعدی شکل حفظ می‌شود، از [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setKeepTextFlat) از طریق [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getTextFrameFormat) استفاده کنید. وقتی مقدار `True` باشد، متن خارج از صحنهٔ 3بعدی می‌ماند. وقتی `False` باشد، متن در صحنه شرکت می‌کند و جهت‌گیری 3بعدی آن را دنبال می‌کند.

این تنظیم قالب‌بندی 3بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و خروجی همچنان از طریق [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) تنظیم شده‌اند. همچنین متفاوت از چرخش معمولی است. [Shape.setRotation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setRotation) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setRotationAngle) چرخش سفارشی متن را در داخل جعبهٔ محدودش کنترل می‌کند. نگه داشتن متن خارج از صحنه 3بعدی هیچ‌یک از این زاویه‌ها را بازنمی‌گرداند.

مثال زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصلی کپی می‌نماید. هر دو شکل همان قالب‌بندی 3بعدی را دارند؛ فقط تنظیم متن متفاوت است: `False` در سمت چپ و `True` در سمت راست. زاویه‌های دوربین بر حسب درجه و ارتفاع خروجی 40 پوینت است. مثال ارائه را به صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

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

در سمت چپ، متن جهت‌گیری 3بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل همان خروجی قابل مشاهده و جهت‌گیری 3بعدی را حفظ می‌کنند.

![مستطیل‌های 3بعدی به‌صورت کنار هم: متن در سمت چپ با جهت‌گیری 3بعدی و در سمت راست صاف باقی می‌ماند](keep_text_flat.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides قالب‌بندی 3بعدی را هنگام ذخیره‌سازی به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های ثابت‑طرح، صحنهٔ 3بعدی به‌صورت raster یا به‌عنوان خروجی 2بعدی رسم می‌شود. این موضوع هنگام رندر اسلایدها به [PNG](/slides/fa/python-java/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)، یا تولید فریم برای [تبدیل ویدئو](/slides/fa/python-java/convert-powerpoint-to-video/) اعمال می‌شود.

نکات مهم:

- تصاویر و PDFهای صادرشده تعاملی نیستند. پس از صادرات، شیء توسط بیننده قابل چرخش نیست.
- ظاهر نهایی به ترکیب دوربین، نورRig, ماده، خروجی، پر کردن و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست‌آمده از ارث‌بری یا تم‌ها دارید، ویژگی‌های موثر شکل را از طریق [effective shape properties](/slides/fa/python-java/shape-effective-properties/) بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی 3بعدی PowerPoint قابل ویرایش را ذخیره کنند. در این فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه این که به‌عنوان تنظیمات 3بعدی قابل ویرایش نگهداری شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های 3بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات 3بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این کتابخانه تصاویر، PDFها یا صفحات HTML صادرشده را به صحنه‌های 3بعدی تعاملی تبدیل نمی‌کند که بیننده بتواند آن‌ها را بچرخاند. در PPTX، قالب‌بندی 3بعدی در PowerPoint قابل ویرایش باقی می‌ماند اگر فرمت آن را پشتیبانی کند.

**تفاوت بین یک مدل 3بعدی و یک اثر 3بعدی چیست؟**

یک مدل 3بعدی یک شیء 3بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر 3بعدی قالب‌بندی است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، خروجی، برجستگی، نورپردازی و ماده. این مقاله به اثرات 3بعدی می‌پردازد.

**کدام تنظیمات برای یک شکل 3بعدی قابل مشاهده ضروری هستند؟**

حداقل باید یک چرخش دوربین و یا خروجی یا عمق تنظیم شود. در عمل، معمولاً یک نورRig و ماده نیز تنظیم می‌شود تا سطوح رندر شده دارای هایلایت‌ها و سایه‌های واضح باشند.

**آیا می‌توانم اثرات 3بعدی را هم بر روی اشکال و هم بر روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) و برای متن از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا اثرات 3بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدئویی ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات 3بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدئو رندر می‌کند. خروجی صادرشده شامل ظاهر رندر شده است، نه شیء 3بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی 3بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توصیف‌شده در [Shape Effective Properties](/slides/fa/python-java/shape-effective-properties/) برای خواندن دوربین نهایی، نورRig، برجستگی و مقادیر مرتبط 3بعدی استفاده کنید.