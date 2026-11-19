---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از پایتون
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/python-net/3d-presentation/
keywords:
- پاورپوینت سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآمدگی سه‌بدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن‌های پاورپوینت در پایتون با Aspose.Slides. پیکربندی دوربین، نورپردازی، مواد، برآمدگی، پرکننده‌ها و متن سه‌بعدی."
---
## **مرور کلی**

Aspose.Slides for Python via .NET می‌تواند فرمت‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برآمدگی، bevels، نورپردازی، مواد، پرکننده‌های گرادیان یا تصویر و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله دربارهٔ اثرات فرمت‌بندی سه‌بعدی بر اشکال و متن‌های PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگامی که یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‑بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم فرمت‌بندی سه‌بعدی**

از ویژگی [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) برای اعمال فرمت‌بندی سه‌بعدی روی یک شکل استفاده کنید. این ویژگی، [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) را افشا می‌کند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از ویژگی [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) استفاده کنید. این ویژگی فرمت‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

مهم‌ترین ویژگی‌ها عبارتند از:

| ویژگی | چه چیزی را کنترل می‌کند | کی باید استفاده شود |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | نقطهٔ مشاهده، نوع دوربین پیش‌تنظیم‌شده، چرخش، زوم و دید زاویه‌ای. | چرخاندن شیء در فضای سه‌بعدی یا مطابقت با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ نمایش نورهای برجسته و سایه‌ها روی سطح سه‌بعدی. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | مواد سطح، مانند صاف، مات، پلاستیک یا فلز. | جعل ظاهر هندسه به صورت صاف‌تر، نرم‌تر، براق یا فلزی. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | میزان پیشروی شکل به سمت عقب از سطح جلویی آن. | تبدیل یک شکل صاف به شیء سه‌بعدی به‌ظاهر ضخیم. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | رنگ طرف‌های برآمده. | نشان دادن عمق یا هماهنگ‌سازی رنگ طرف‌ها با پرکنندهٔ جلویی. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | عمق سه‌بعدی اضافه که توسط فرمت‌بندی PowerPoint استفاده می‌شود. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات bevel و material. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) و [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌دار به جای سطح صاف تیز. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) و [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | خطوط دور شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌طور قانع‌کنندهٔ سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است برآمدگی را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث خوانایی سطوح می‌شود.
- تنظیمات ماده، زیرا سطح تأثیر می‌گذارد که نور چگونه رندر شود.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند و فرمت‌بندی سه‌بعدی را اعمال می‌نماید. مقادیر چرخش دوربین بر حسب درجه هستند و ارتفاع برآمدگی ۱۰۰ پوینت است. مثال اسلاید را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

تصویر رندر شدهٔ اسلاید، مستطیل را به‌صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی با متن سفید سه‌بعدی روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنل 3‑D Rotation تنظیم می‌شود. مقادیر چرخش X، Y و Z متناظر با چرخشی است که از طریق API دوربین تنظیم می‌کنید.

![پنل 3‑D Rotation در PowerPoint با مقادیر چرخش X، Y و Z هایلایت شده](img_02_01.png)

در Aspose.Slides، به دوربین از طریق [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) دسترسی پیدا کنید. این مثال یک مستطیل ایجاد می‌کند، نمای جلوی ارتوغرافیک را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب به ۲۰، ۳۰ و ۴۰ درجه تنظیم می‌نماید. شکل در حافظه پیکربندی می‌شود بدون اینکه فایلی ذخیره شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

از دوربین زمانی استفاده کنید که نیاز داشته باشید نحوهٔ دیدن شیء توسط بیننده تغییر کند. این تنظیم، هندسهٔ دو‑بعدی شکل روی اسلاید را تغییر نمی‌دهد؛ تنها نقطهٔ مشاهدهٔ سه‌بعدی که توسط PowerPoint و Aspose.Slides هنگام رندر استفاده می‌شود را تغییر می‌دهد.

### **کپی‌برداری جهت دوربین از یک شکل قالب**

برای تطبیق جهت یک شکل قالب، پیش‌تنظیم [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) آن را کپی کنید و چرخش آن را با [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/) بخوانید. مثال فایل `template.pptx` را باز می‌کند و جهت دوربین اولین شکل روی اولین اسلاید را به شکل دوم کپی می‌کند. هر دو شکل قبلاً نورپردازی سه‌بعدی دارند و شکل دوم چرخش دوربین صریحی ندارد.

اندازها به درجه هستند. ایندکس‌های `0`، `1` و `2` به ترتیب طول جغرافیایی، عرض جغرافیایی و چرخش را نگه می‌دارند. این مقادیر را به ترتیب به [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) پاس می‌دهید. اگر منبع چرخش صریحی نداشته باشد، `get_rotation` مقدار `None` برمی‌گرداند؛ بنابراین زاویه‌های مقصد را تنظیم نکنید. اگر منبع تمام سه زاویه را صریحاً برابر صفر تنظیم کرده باشد، همان صفرها را کپی کنید.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

هنگامی که `camera-copy.pptx` را در PowerPoint باز می‌کنید، هر دو شکل همان پیش‌تنظیم و چرخش دوربین را دارند. پیکان سمت راست جهت‌ای است که از مستطیل سمت چپ کپی شده است. هر دو شکل از یک نورپردازی و عمق برآمدگی استفاده می‌کنند.

![مستطیل سه‌بعدی آبی و یک پیکان راست با جهت دوربین یکسان، نمای بالا و راست](camera-orientation.png)

## **افزودن برآمدگی و عمق**

برآمدگی باعث می‌شود یک شکل به‌صورت ضخیم ظاهر شود زیرا به سمت پشت سطح جلو گسترش می‌یابد. در PowerPoint، کنترل عمق این ضخامت قابل رؤیت را تنظیم می‌کند و کنترل رنگ، رنگ طرف‌های جانبی را تنظیم می‌نماید.

![کنترل‌های عمق PowerPoint که به ویژگی‌های extrusion_color و extrusion_height نقشه می‌شوند](img_02_02.png)

برای ضخامت، از [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) استفاده کنید و برای رنگ طرف‌ها از [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) بهره بگیرید. مثال زیر یک مستطیل با برآمدگی ۱۰۰ پوینت و طرف‌های ارغوانی می‌سازد و دوربین را می‌چرخاند تا ضخامت را نشان دهد. شکل در حافظه پیکربندی می‌شود بدون ذخیرهٔ فایل:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

خاصیت [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) عمق یک شکل سه‌بعدی را تنظیم می‌کند. خاصیت [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) ارتفاع اثر برآمدگی را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکننده‌های گرادیان یا تصویر با اثرات سه‌بعدی**

فرمت‌بندی سه‌بعدی مستقل از پرکنندهٔ شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکنندهٔ تصویر را بر سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده کنید.

مثال زیر یک گرادیان آبی‑به‑نارنجی را بر سطح جلویی و یک رنگ نارنجی تیره را بر برآمدگی ۱۵۰ پوینتی اعمال می‌کند. نقاط توقف گرادیان در ۰ و ۱۰۰، آغاز و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین بر حسب درجه هستند. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

خروجی رندر شده گرادیان را بر سطح جلویی حفظ می‌کند و برآمدگی را به‌صورت جداگانه رندر می‌نماید:

![مستطیل سه‌بعدی با پرکنندهٔ گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکنندهٔ تصویر، تصویر را به ارائه اضافه کنید و به پرکنندهٔ شکل اختصاص دهید. این مثال نیاز به فایلی به نام "image.jpg" در پوشهٔ کاری دارد. تصویر را به‌گونه‌ای کش می‌کند که مستطیل را پر کند، برآمدگی ۱۵۰ پوینتی اعمال می‌کند و چرخش دوربین را بر حسب درجه تنظیم می‌کند. شکل در حافظه پیکربندی می‌شود بدون ذخیره یا رندر فایل:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

تصویر روی سطح جلویی رندر می‌شود، در حالی که برآمدگی به‌عنوان سطح جانبی سه‌بعدی رندر می‌گردد:

![مستطیل سه‌بعدی با پرکنندهٔ عکس روی سطح جلویی و برآمدگی نارنجی](img_02_04.png)

## **اعمال فرمت‌بندی سه‌بعدی به متن**

فرمت‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. فرمت‌بندی سه‌بعدی متن بر قاب متن تأثیر می‌گذارد. این برای افکت‌های مشابه WordArt مفید است، جایی که خود حروف به برآمدگی، ماده، نورپردازی و تنظیمات دوربین نیاز دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑و‑سفید ایجاد می‌کند، قوس بالایی اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) تنظیم می‌کند. ارتفاع برآمدگی و عمق بر حسب پوینت هستند و چرخش نور بر حسب درجه. پرکننده و خط دور شکل مخفی شده‌اند تا فقط متن قابل مشاهده باشد. مثال تصویر PNG را با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

متن به‌صورت حروف ۳‌بعدی منحنی و برآمده رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل قوس‌دار WordArt، پرکنندهٔ الگوی نارنجی و برآمدگی تیره](img_02_05.png)

## **حفظ متن به صورت صاف روی یک شکل سه‌بعدی**

برای حفظ قابلیت خواندن متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، از [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) از طریق [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/) استفاده کنید. وقتی مقدار `True` باشد، متن از صحنهٔ سه‌بعدی خارج می‌ماند. وقتی `False` باشد، متن در صحنه شرکت می‌کند و جهت‌گیری سه‌بعدی آن را دنبال می‌کند.

این تنظیم فرمت‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نورپردازی، ماده و برآمدگی آن همچنان از طریق [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) تنظیم شده‌اند. همچنین متفاوت از چرخش معمولی است. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) شکل را در صفحهٔ اسلاید می‌چرخاند، در حالی که [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) چرخش سفارشی متن را داخل جعبهٔ محاطی‌اش کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعدی هیچ‌یک از این زاویه‌ها را ریست نمی‌کند.

مثال زیر یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار نسخهٔ اصلی کپی می‌نماید. هر دو شکل همان فرمت‌بندی سه‌بعدی را دارند؛ تنها تنظیم متن متفاوت است: `False` در سمت چپ و `True` در سمت راست. زاویه‌های دوربین بر حسب درجه هستند و ارتفاع برآمدگی ۴۰ پوینت است. مثال ارائه را به صورت PPTX ذخیره می‌کند و اسلاید مقایسه‌ای را به PNG با دو برابر ابعاد پیش‌فرض رندر می‌نماید:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

در سمت چپ، متن جهت‌گیری سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل همان برآمدگی قابل مشاهده و جهت‌گیری سه‌بعدی را حفظ می‌کنند.

![دو مستطیل سه‌بعدی کنار هم: keep_text_flat در سمت چپ False و در سمت راست True](keep_text_flat.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX، فرمت‌بندی سه‌بعدی را حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های ثابت‑طرح، صحنهٔ سه‌بعدی به‌صورت ۲‑بعدی رستر یا رسم می‌شود. این هنگام رندر اسلایدها به [PNG](/slides/fa/python-net/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، یا تولید فریم برای [video conversion](/slides/fa/python-net/convert-powerpoint-to-video/) صادق است.

این نکات را در ذهن داشته باشید:

- تصاویر و PDFهای صادرشده تعاملی نیستند. پس از صادرات، کاربر نمی‌تواند شیء را بچرخاند.
- ظاهر نهایی به ترکیب دوربین، نورپردازی، ماده، برآمدگی، پرکننده و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر فرمت‌بندی به ارث‌برده یا مبتنی بر تم دارید، از [effective shape properties](/slides/fa/python-net/shape-effective-properties/) استفاده کنید.
- برخی فرمت‌های خروجی نمی‌توانند فرمت‌بندی سه‌بعدی PowerPoint ویرایش‌پذیر را ذخیره کنند. در این فرمت‌ها، نتیجهٔ بصری به‌جای حفظ تنظیمات قابل ویرایش رندر می‌شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصویرها، PDFها یا صفحات HTML را به صحنه‌های سه‌بعدی تعاملی تبدیل نمی‌کند که کاربر بتواند آنها را بچرخاند. در PPTX، فرمت‌بندی سه‌بعدی در PowerPoint ویرایش‌پذیر می‌ماند، به‌شرطی که قالب از این قابلیت پشتیبانی کند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که در ارائه درج می‌شود. یک اثر سه‌بعدی فرمت‌بندی اعمال‌شده به یک شکل یا متن معمولی PowerPoint است، مانند چرخش، برآمدگی، bevel، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده لازم است؟**

حداقل باید چرخش دوربین و یا برآمدگی/عمق را تنظیم کنید. در عمل، تنظیم نورپردازی و ماده نیز ضروری است تا سطوح رندرشده برجستگی‌ها و سایه‌های واضحی داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) و برای متن از [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های مورد استفاده برای تبدیل ویدئو رندر می‌کند. خروجی صادرشده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌برداری و تنظیمات تم بخوانم؟**

بله. از API‌های فرمت‌بندی مؤثر توصیف‌شده در [Shape Effective Properties](/slides/fa/python-net/shape-effective-properties/) برای خواندن دوربین نهایی، نورپردازی، bevel و سایر مقادیر سه‌بعدی استفاده کنید.