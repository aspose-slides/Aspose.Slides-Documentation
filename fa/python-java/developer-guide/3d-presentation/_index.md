---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از Python
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/python-java/3d-presentation/
keywords:
- پاورپوینت سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- استخراج سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "با استفاده از Aspose.Slides در Python از طریق Java، اثرات سه‌بعدی را برای اشکال و متن‌های PowerPoint اعمال و رندر کنید. دوربین، نورپردازی، ماده، استخراج، پرکن‌ها و متن سه‌بعدی را پیکربندی کنید."
---
## **مرور کلی**

Aspose.Slides for Python via Java می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای شکل‌ها و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، استخراج، لبه‌دار کردن، نورپردازی، ماده، پرکن‌های گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="توجه" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی برای شکل‌ها و متن‌های PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام خروجی‌گیری یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides این اثرات سه‌بعدی را در خروجی دو‌بعدی رندر می‌کند.
{{% /alert %}}

پکیج را همان‌گونه که در [نصب](/slides/fa/python-java/installation/) توضیح داده شده، نصب کنید. هر مثال `asposeslides` را ایمپورت می‌کند، در صورت نیاز JVM را راه‌اندازی می‌کند، سپس API را ایمپورت می‌کند. مثال پرکن تصویر نیاز به فایل `image.jpg` در پوشهٔ کاری دارد.

## **مفاهیم قالب‌بندی سه‌بعدی**

از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. شیء قالب‌بندی بازگشتی صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این کار قالب‌بندی سه‌بعدی را به قاب متن (نه بدنهٔ شکل) اعمال می‌گذارد.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getCamera) | نقطهٔ نظر، نوع دوربین پیش‌ تنظیم‌شده، چرخش، زوم و پرسپکتیو. | برای چرخش شیء در فضای سه‌بعدی یا تطبیق با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | برای تغییر ظاهر نقاط نورانی و سایه‌ها بر روی سطح سه‌بعدی. |
| [getMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setMaterial) | مادهٔ سطح، مانند صاف، مات، پلاستیک یا فلزی. | برای ایجاد ظاهری صاف، نرم، براق یا فلزی برای همان هندسه. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setExtrusionHeight) | میزان انتشار شکل به سمت عقب از سطح جلویی آن. | تبدیل یک شکل صاف به یک شیء سه‌بعدی واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ سمت‌های استخراج‌شده. | برای نمایان‌سازی عمق یا هماهنگ‌سازی رنگ سمت‌ها با پرکن جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setDepth) | عمق سه‌بعدی اضافه که توسط قالب‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای شکل‌ها یا متن، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های برجسته یا گرد شده در سطح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به جای سطح صاف و تیز. |
| [getContourColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setContourWidth) | خط‌چین دور شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌ظاهر سه‌بعدی قانع‌کننده باشد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است استخراج را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث خوانا شدن سطوح و سمت‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تاثیر می‌گذارد.
- تنظیمات استخراج یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

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

تصویر رندر شده اسلاید، مستطیل را به صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید روی سطح جلویی](img_01_01.png)

## **چرخاندن شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z با چرخشی که از طریق API دوربین تنظیم می‌کنید، مطابقت دارد.

![پنل 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z برجسته‌شده](img_02_01.png)

در Aspose.Slides، دوربین و چرخش را از طریق قالب‌بندی سه‌بعدی بازگشتی توسط [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) تنظیم کنید:

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

از دوربین وقتی نیاز به تغییر نحوهٔ نگاه بیننده به شیء دارید استفاده کنید. این کار هندسهٔ دو‌بعدی شکل را در اسلاید تغییر نمی‌دهد؛ تنها نقطهٔ نظر سه‌بعدی استفاده‌شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **افزودن استخراج و عمق**

استخراج باعث می‌شود یک شکل به‌ظاهر ضخیم شود با گسترش به پشت سطح جلویی. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ سمت‌ها را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint که به خصوصیات رنگ استخراج و ارتفاع استخراج نگاشت می‌شوند](img_02_02.png)

ارتفاع استخراج را برای ضخامت و رنگ استخراج را برای رنگ سمت‌ها تنظیم کنید:

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

از تنظیم عمق وقتی نیاز به کار مستقیم با مقدار عمق PowerPoint دارید یا عمق را همراه با لبه، ماده و اثرات متنی ترکیب می‌کنید استفاده کنید. در بسیاری از سناریوهای شکل، ارتفاع استخراج تنظیم واضح‌تری است زیرا مستقیماً ضخامت قابل مشاهده را بیان می‌کند.

## **استفاده از پرکن‌های گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکن تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و استخراج استفاده کنید.

این مثال یک پرکن گرادیان به شکل اعمال می‌کند و یک رنگ استخراج تیره‌تر به سمت‌ها می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

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

خروجی رندر شده گرادیان را بر روی سطح جلویی حفظ می‌کند و استخراج را به‌طور جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکن گرادیان از آبی به نارنجی و استخراج نارنجی](img_02_03.png)

برای استفاده از پرکن تصویر، تصویر را به ارائه اضافه کنید و به پرکن شکل اختصاص دهید:

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

تصویر روی سطح جلویی رندر می‌شود، در حالی که استخراج به‌عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکن عکس روی سطح جلویی و استخراج نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تاثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر قاب متن تاثیر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به استخراج، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکن الگو ایجاد می‌کند، یک تبدیل WordArt اعمال می‌کند و تنظیمات سه‌بعدی را بر روی [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/) پیکربندی می‌کند:

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

متن به صورت حروف منحنی و استخراج‌شدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکن الگو نارنجی و استخراج تیره](img_02_05.png)

## **رفتار خروجی و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره‌سازی به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑چیدمان، صحنهٔ سه‌بعدی به‌صورت رستر یا به‌صورت دو‌بعدی در خروجی رسم می‌شود. این برای رندر اسلایدها به PNG، خروجی به PDF، خروجی به HTML یا تولید فریم‌ها برای تبدیل ویدیو صادق است.

نکات مهم:

- تصاویر و PDFهای خروجی تعاملی نیستند. پس از خروجی، شیء نمی‌تواند توسط بیننده چرخانده شود.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، استخراج، پرکن و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست آمده پس از ارث‌بری یا تنظیمات تم دارید، از API قالب‌بندی مؤثر استفاده کنید.
- برخی از فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی ویرایش‌پذیر PowerPoint را ذخیره کنند. در آن فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه این که به‌عنوان تنظیمات سه‌بعدی ویرایش‌پذیر حفظ شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های تعاملی سه‌بعدی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای شکل‌ها و متن‌ها ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML خروجی‌شده را به صحنه‌های تعاملی سه‌بعدی که بیننده می‌تواند چرخاند، تبدیل نمی‌کند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint که از این ویژگی پشتیبانی می‌کند، قابل ویرایش می‌ماند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی شیء جداگانه‌ای است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، استخراج، لبه‌دار کردن، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده لازم است؟**

حداقل باید چرخش دوربین و یا استخراج یا عمق را تنظیم کنید. در عمل، همچنین تنظیم نور و ماده توصیه می‌شود تا سطوح رندر شده نقاط نورانی و سایه واضحی داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم بر شکل‌ها و هم بر متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) و برای متن از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام خروجی به تصویر، PDF، HTML یا فریم‌های ویدیو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل ویدیو رندر می‌کند. خروجی صادرشده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی ویرایش‌پذیر.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getEffective) برای خواندن دوربین نهایی، نور، لبه و مقادیر مرتبط سه‌بعدی استفاده کنید.