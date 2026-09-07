---
title: ایجاد افکت‌های 3D در ارائه‌ها با استفاده از پایتون
linktitle: ارائه 3D
type: docs
weight: 232
url: /fa/python-java/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- اکستروژن سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "اعمال و رندر افکت‌های 3D برای اشکال و متن PowerPoint در پایتون از طریق جاوا با Aspose.Slides. تنظیم دوربین، نورپردازی، ماده، اکستروژن، پرشدن‌ها و متن 3D."
---
## **بررسی کلی**

Aspose.Slides for Python via Java می‌تواند قالب‌بندی 3D شبیه PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به افکت‌های 3D مانند چرخش، اکس‌تریژن، بریدگی، نورپردازی، ماده، پرشدن گرادیان یا تصویر و متن 3D می‌پردازد.

{{% alert color="info" title="توجه" %}}
این مقاله درباره افکت‌های قالب‌بندی 3D بر روی اشکال و متن PowerPoint است. درباره وارد کردن یا ویرایش فایل‌های مدل 3D مستقل نیست. هنگام خروجی گرفتن اسلاید به تصویر، PDF یا HTML، Aspose.Slides این افکت‌های 3D را به خروجی 2D رندر می‌کند.
{{% /alert %}}

پکیج را همان‌طور که در [نصب](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال `asposeslides` را ایمپورت می‌کند، در صورت نیاز JVM را راه‌اندازی می‌کند و سپس API را ایمپورت می‌کند. مثال پرشدن‑تصویر به یک فایل `image.jpg` در پوشه کاری نیاز دارد.

## **مفاهیم قالب‌بندی 3D**

از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) برای اعمال قالب‌بندی 3D به یک شکل استفاده کنید. شیء قالب‌بندی بازگشتی صحنه 3D آن شکل را کنترل می‌کند.

برای متن، از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید. این قالب‌بندی 3D را به فریم متن اعمال می‌کند نه به بدنه شکل.

مهم‌ترین اعضای API عبارتند از:

| عضو API | چه چیزی را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getCamera) | نقطه نظر، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای 3D یا مطابقت با پیش‌تنظیم چرخش 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getLightRig) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهر هایلایت‌ها و سایه‌ها روی سطح 3D. |
| [getMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getMaterial) و [setMaterial](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setMaterial) | ماده سطح، مانند صاف، مات، پلاستیک یا فلز. | ایجاد حس صاف‌تر، نرم‌تر، براق یا فلزی برای همان هندسه. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionHeight) و [setExtrusionHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setExtrusionHeight) | میزان گسترش شکل به سمت عقب از سطح جلویی. | تبدیل یک شکل صاف به شیء 3D واضحاً ضخیم. |
| [getExtrusionColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getExtrusionColor) | رنگ طرف‌های اکستروژن. | نمایان کردن عمق یا هماهنگ‌سازی رنگ طرف‌ها با پرشدن جلویی. |
| [getDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getDepth) و [setDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setDepth) | عمق 3D اضافی که توسط قالب‌بندی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات بریج و ماده. |
| [getBevelTop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getBevelBottom) | لبه‌های بالا یا پایین گرد یا برجسته روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به جای سطح صاف و تند. |
| [getContourColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourColor)، [getContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getContourWidth) و [setContourWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#setContourWidth) | خط مرزی اطراف شیء 3D. | برجسته کردن مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل 3D**

یک شکل معمولاً برای داشتن ظاهر معتبر 3D به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است اکستروژن را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث خوانایی سطوح و طرف‌ها می‌شود.
- تنظیمات ماده، زیرا سطح تأثیر می‌گذارد که نور چگونه رندر شود.
- تنظیمات اکستروژن یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی اضافه می‌نماید، قالب‌بندی 3D اعمال می‌کند، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

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

تصویر رندر شده اسلاید، مستطیل را به عنوان بلوک ضخیم 3D نشان می‌دهد:

![مستطیل آبی 3D رندر شده با متن 3D سفید روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش 3D از پنل 3‑D Rotation پیکربندی می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنل 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z هایلایت شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق قالب‌بندی 3D بازگشتی توسط [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) تنظیم کنید:

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

از دوربین وقتی نیاز دارید نحوهٔ دیدن شیء توسط بیننده را تغییر دهید استفاده کنید. این کار هندسهٔ 2D شکل را روی اسلاید تغییر نمی‌دهد؛ بلکه نقطهٔ مشاهدهٔ 3D را که PowerPoint و Aspose.Slides برای رندر استفاده می‌کنند، تغییر می‌دهد.

## **افزودن اکستروژن و عمق**

اکستروژن باعث می‌شود شکل به‌وسیلهٔ گسترش به پشت سطح جلویی ضخیم به نظر برسد. در PowerPoint، کنترل عمق این ضخامت قابل رؤیت را تعیین می‌کند و کنترل رنگ رنگ طرف‌ها را تنظیم می‌کند.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ اکستروژن و ارتفاع اکستروژن نگاشت می‌شوند](img_02_02.png)

ارتفاع اکستروژن را برای ضخامت و رنگ اکستروژن را برای رنگ طرف تنظیم کنید:

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

از تنظیم عمق وقتی نیاز دارید مقدار عمق PowerPoint را مستقیماً استفاده کنید یا عمق را با بریج، ماده و افکت‌های متن ترکیب کنید. در بسیاری از سناریوهای شکل، ارتفاع اکستروژن تنظیم واضح‌تری است زیرا به‌صورت مستقیم ضخامت قابل رؤیت را بیان می‌کند.

## **استفاده از پرشدن گرادیان یا تصویر با افکت‌های 3D**

قالب‌بندی 3D مستقل از پرشدن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرشدن تصویر را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و اکستروژن استفاده کنید.

این مثال یک پرشدن گرادیان به شکل و رنگ اکستروژن تیره‌تر به طرف‌ها اعمال می‌کند:

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

خروجی رندر شده گرادیان را روی سطح جلویی حفظ می‌کند و اکستروژن را به‌صورت جداگانه رندر می‌کند:

![مستطیل 3D رندر شده با پرشدن گرادیان آبی‑به‑نارنجی و اکستروژن نارنجی](img_02_03.png)

برای استفاده از پرشدن تصویر، تصویر را به ارائه اضافه کنید و آن را به پرشدن شکل اختصاص دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

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

تصویر روی سطح جلویی رندر می‌شود، در حالی که اکستروژن به‌عنوان سطح جانبی 3D رندر می‌شود:

![مستطیل 3D رندر شده با پرشدن عکس روی سطح جلویی و اکستروژن نارنجی](img_02_04.png)

## **اعمال قالب‌بندی 3D به متن**

قالب‌بندی 3D برای شکل بدنهٔ شکل را تحت تأثیر قرار می‌دهد. قالب‌بندی 3D برای متن فریم متن را تحت تأثیر قرار می‌دهد. این برای افکت‌های شبیه WordArt مفید است، جایی که حروف خود نیاز به اکستروژن، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرشدن الگو ایجاد می‌کند، تبدیل WordArt اعمال می‌کند و تنظیمات 3D را بر روی [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/) پیکربندی می‌کند:

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

متن به‌صورت حروف 3D منحنی و اکستروژن‌دار رندر می‌شود:

![متن 3D رندر شده با تبدیل WordArt قوسی، پرشدن الگوی نارنجی و اکستروژن تیره](img_02_05.png)

## **رفتار خروجی و رندرینگ**

Aspose.Slides قالب‌بندی 3D را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت‑طرح، صحنه 3D به‌صورت رستر یا ترسیم در خروجی به‌عنوان نتیجهٔ 2D تبدیل می‌شود. این برای رندر اسلایدها به PNG، خروجی به PDF، خروجی به HTML یا تولید فریم برای تبدیل ویدئو اعمال می‌شود.

نکات مهم:

- تصاویر و PDFهای خروجی تعاملی نیستند. پس از خروجی، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نور، ماده، اکستروژن، پرشدن و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر قالب‌بندی به ارث‌برده یا مبتنی بر تم دارید، از API قالب‌بندی مؤثر استفاده کنید.
- برخی از فرمت‌های خروجی نمی‌توانند قالب‌بندی 3D ویرایش‌پذیر PowerPoint را ذخیره کنند. در آن‌ها نتیجهٔ بصری رندر می‌شود نه اینکه به‌صورت تنظیمات 3D ویرایش‌پذیر باقی بماند.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های 3D تعاملی ایجاد کند؟**

Aspose.Slides افکت‌های 3D PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDF یا صفحه‌های HTML تعاملی 3D تولید نمی‌کند که کاربر بتواند آنها را بچرخاند. در PPTX، قالب‌بندی 3D در PowerPoint ویرایش‌پذیر می‌ماند، مشروط بر این‌که فرمت آن را پشتیبانی کند.

**تفاوت بین مدل 3D و افکت 3D چیست؟**

یک مدل 3D یک شیء 3D جداگانه است که به ارائه اضافه می‌شود. یک افکت 3D قالب‌بندی است که بر روی یک شکل یا متن PowerPoint معمولی اعمال می‌شود، مانند چرخش، اکستروژن، بریج، نورپردازی و ماده. این مقاله به افکت‌های 3D می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل 3D قابل مشاهده ضروری است؟**

حداقل باید یک چرخش دوربین و یا اکستروژن/عمق تنظیم کنید. در عمل، همچنین تنظیم نور و ماده توصیه می‌شود تا سطوح رندر شده دارای هایلایت و سایه واضح باشند.

**آیا می‌توانم افکت‌های 3D را هم روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getThreeDFormat) استفاده کنید و برای متن از [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#getThreeDFormat) استفاده کنید.

**آیا افکت‌های 3D هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides افکت‌های 3D را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل ویدئو رندر می‌کند. خروجی حاوی ظاهر رندر شده است، نه یک شیء 3D قابل ویرایش.

**آیا می‌توانم مقادیر نهایی 3D را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/threedformat/#getEffective) برای خواندن مقادیر نهایی دوربین، نور، بریج و مقادیر مرتبط 3D استفاده کنید.