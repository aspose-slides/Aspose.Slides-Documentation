---
title: ایجاد افکت‌های 3D در ارائه‌ها با استفاده از پایتون
linktitle: ارائه 3D
type: docs
weight: 232
url: /fa/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- ارائه 3D
- چرخش 3D
- عمق 3D
- برآمدگی 3D
- گرادیان 3D
- متن 3D
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "افکت‌های 3D را برای اشکال و متن PowerPoint در پایتون از طریق جاوا با Aspose.Slides اعمال و رندر کنید. دوربین، نورپردازی، ماده، برآمدگی، پرکن‌ها و متن 3D را پیکربندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via Java می‌تواند فرمت‌بندی 3D شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به افکت‌های 3D مانند چرخش، برآمدگی، برجسته‌سازی‌ها، نورپردازی، مواد، پرکن‌های گرادیان یا تصویر و متن 3D می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله درباره افکت‌های فرمت‌بندی 3D روی اشکال و متن‌های PowerPoint است. در مورد افزودن یا ویرایش فایل‌های مدل 3D جداگانه نیست. هنگامی که یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این افکت‌های 3D را در خروجی 2D صادرشده رندر می‌کند.
{{% /alert %}}

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال `asposeslides` را وارد می‌کند، در صورت نیاز JVM را راه‌اندازی می‌کند و سپس API را وارد می‌نماید. مثال پرکن تصویر به یک فایل `image.jpg` در پوشه کاری احتیاج دارد.

## **مفاهیم فرمت‌بندی 3D**

از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) برای اعمال فرمت‌بندی 3D به یک شکل استفاده کنید. شیء فرمت بازگردانده‌شده صحنه 3D آن شکل را کنترل می‌کند.

برای متن، از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این روش فرمت‌بندی 3D را به فریم متن اعمال می‌کند نه به بدنه شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | آن چه را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getCamera) | نقطه دید، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای 3D یا تطبیق با یک پیش‌تنظیم چرخش 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهر نورهای برجسته و سایه‌ها روی سطح 3D. |
| [getMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setMaterial) | ماده سطح، مانند صاف، مات، پلاستیک یا فلز. | جعل چسبناکی، نرمی، براقیت یا فلزی بودن همان شکل هندسی. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setExtrusionHeight) | میزان پیشروی شکل به سمت عقب از سطح جلو. | تبدیل یک شکل صاف به یک شیء 3D دارای ضخامت قابل مشاهده. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ اضلاع برآمده. | نشان دادن عمق یا هماهنگ‌سازی رنگ سمت با پرکن جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setDepth) | عمق 3D اضافی که توسط فرمت‌بندی 3D PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌خصوص همراه با تنظیمات برجسته و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های بالا یا پایین گرد یا برجسته روی سطوح جلویی و پشتی. | افزودن لبه‌ای نرم یا قالب‌دار به‌جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setContourWidth) | مرز اطراف شیء 3D. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد شکل 3D**

یک شکل معمولاً قبل از اینکه به‌طور قانع‌کننده‌ای 3D به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض می‌تواند برآمدگی را پنهان کند.
- تنظیمات نور، چون نورپردازی سطوح و اضلاع را قابل مشاهده می‌سازد.
- تنظیمات ماده، زیرا سطح تأثیر می‌گذارد که نور چگونه رندر شود.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی به سطح جلویی آن اضافه می‌کند، فرمت‌بندی 3D را اعمال می‌نماید، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

تصویر رندر شده اسلاید، مستطیل را به‌عنوان یک بلوک ضخیم 3D نشان می‌دهد:

![مستطیل آبی 3D رندرشده با متن سفید 3D روی سطح جلویی](img_01_01.png)

## **چرخاندن شکل با دوربین**

در PowerPoint، چرخش 3D از پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنل 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z برجسته‌شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق فرمت 3D بازگردانده‌شده توسط [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) تنظیم کنید:

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

وقتی نیاز دارید نمایندهٔ مشاهده‌گر چگونه شیء را می‌بیند تغییر یابد، از دوربین استفاده کنید. این کار هندسهٔ 2D شکل روی اسلاید را تغییر نمی‌دهد؛ بلکه نقطه دید 3D مورد استفاده PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **اضافه کردن برآمدگی و عمق**

برآمدگی باعث می‌شود یک شکل با افزودن طول به پشت سطح جلویی ضخیم به‌نظر برسد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ، رنگ اضلاع جانبی را تعیین می‌نماید.

![کنترل‌های عمق PowerPoint مرتبط با ویژگی‌های رنگ برآمدگی و ارتفاع برآمدگی](img_02_02.png)

ارتفاع برآمدگی را برای ضخامت و رنگ برآمدگی را برای رنگ سمت تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

وقتی نیاز داشته باشید مقدار عمق PowerPoint را به‌صورت مستقیم استفاده کنید یا عمق را همراه با برجسته، ماده و افکت‌های متنی ترکیب کنید، از تنظیم عمق استفاده کنید. در بسیاری از سناریوهای شکل، ارتفاع برآمدگی تنظیم واضح‌تری است چون مستقیماً ضخامت قابل مشاهده را بیان می‌کند.

## **استفاده از پرکن‌های گرادیان یا تصویر با افکت‌های 3D**

فرمت‌بندی 3D مستقلاً از پرکن شکل عمل می‌کند. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکن تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده نمایید.

این مثال یک پرکن گرادیان به شکل اعمال می‌کند و برای اضلاع رنگ برآمدگی تیره‌تری تنظیم می‌نماید:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

خروجی رندر شده گرادیان را روی سطح جلویی حفظ می‌کند و برآمدگی را به‌صورت جداگانه رندر می‌کند:

![مستطیل 3D رندرشده با پرکن گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکن تصویر، تصویر را به ارائه اضافه کنید و آن را به پرکن شکل تخصیص دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

تصویر روی سطح جلویی رندر می‌شود، در حالی که برآمدگی به‌عنوان سطح جانبی 3D رندر می‌شود:

![مستطیل 3D رندرشده با پرکن عکسی روی سطح جلویی و برآمدگی نارنجی](img_02_04.png)

## **اعمال فرمت‌بندی 3D به متن**

فرمت‌بندی 3D شکل بر بدنهٔ شکل تأثیر می‌گذارد. فرمت‌بندی 3D متن بر فریم متنی تأثیر می‌گذارد. این برای افکت‌های شبیه WordArt مفید است، جایی که حروف خود نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکن الگو ایجاد می‌کند، یک تبدیل WordArt اعمال می‌نماید و تنظیمات 3D را بر [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/) پیکربندی می‌کند:

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

متن به‌صورت حروف منحنی 3D برآمده رندر می‌شود:

![متن 3D رندرشده با تبدیل WordArt قوسی، پرکن الگوی نارنجی و برآمدگی تیره](img_02_05.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX، فرمت‌بندی 3D را حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑طرح، صحنه 3D به‌صورت رستر یا کشیده‌شده در خروجی 2D تبدیل می‌شود. این در زمان رندر اسلایدها به PNG، صادرات به PDF، صادرات به HTML یا تولید فریم برای تبدیل به ویدیو صادق است.

نکات مهم:

- تصاویر و PDFهای صادرشده تعامل‌پذیر نیستند. پس از صادرات، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، برآمدگی، پرکن و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر فرمت‌بندی به‌دست آمده از ارث‌بری یا تم دارید، از API فرمت‌بندی مؤثر استفاده کنید.
- برخی فرمت‌های خروجی قادر به ذخیره‌سازی فرمت‌بندی 3D قابل ویرایش PowerPoint نیستند؛ در آن‌ها نتیجه بصری رندر می‌شود نه به‌عنوان تنظیمات 3D قابل ویرایش.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های 3D تعاملی ایجاد کند؟**

Aspose.Slides افکت‌های 3D PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. اما تصاویر، PDFها یا صفحات HTML صادرشده را به‌عنوان صحنه‌های 3D تعاملی که کاربر بتواند آن‌ها را بچرخاند، تبدیل نمی‌کند. در PPTX، فرمت‌بندی 3D در PowerPoint که از این فرمت پشتیبانی می‌کند، قابل ویرایش باقی می‌ماند.

**فرق بین مدل 3D و افکت 3D چیست؟**

یک مدل 3D یک شیء 3D جداگانه است که در ارائه وارد می‌شود. یک افکت 3D فرمت‌بندی‌ای است که روی یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، برجسته‌سازی، نورپردازی و ماده. این مقاله به افکت‌های 3D می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل 3D قابل مشاهده لازم است؟**

حداقل باید یک چرخش دوربین و یا برآمدگی یا عمق تنظیم کنید. در عمل، همچنین تنظیم نور و ماده توصیه می‌شود تا سطوح رندرشده دارای برجستگی‌ها و سایه‌های واضح باشند.

**آیا می‌توانم افکت‌های 3D را هم روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) و برای متن از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا افکت‌های 3D هنگام صادرات به تصویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides افکت‌های 3D را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل به ویدیو رندر می‌کند. خروجی صادرشده شامل ظاهر رندرشده است، نه یک شیء 3D قابل ویرایش.

**آیا می‌توانم مقادیر نهایی 3D را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getEffective) برای خواندن مقادیر نهایی دوربین، نور، برجسته‌سازی و مقادیر 3D مرتبط استفاده کنید.