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
- اکستروژن سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن پاورپوینت در پایتون با Aspose.Slides. پیکربندی دوربین، نوردهی، ماده، اکستروژن، پر‌کننده‌ها و متن سه‌بعدی."
---
## **بررسی کلی**

Aspose.Slides برای Python از طریق .NET می‌تواند قالب‌بندی سه‌بعدی شبیه PowerPoint برای اشکال و متن را ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، اکستروژن، برجستگی‌ها، نوردهی، مواد، پر کردن گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="primary" %}}
این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی بر اشکال و متن در PowerPoint است. دربارهٔ افزودن یا ویرایش فایل‌های مدل سه‌بعدی مستقل صحبت نمی‌کند. وقتی یک اسلاید را به تصویر، PDF یا HTML صادر می‌کنید، Aspose.Slides آن اثرات سه‌بعدی را در خروجی دو‌بعدی صادر شده رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از ویژگی [Shape.three_d_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/three_d_format/) برای اعمال قالب‌بندی سه‌بعدی بر یک شکل استفاده کنید. این ویژگی، [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) را در اختیار می‌گذارد که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از ویژگی [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/three_d_format/) استفاده کنید. این ویژگی قالب‌بندی سه‌بعدی را بر روی فریم متن اعمال می‌کند نه بر بدنهٔ شکل.

مهم‌ترین ویژگی‌ها عبارتند از:

| Property | What it controls | When to use it |
|---|---|---|
| [camera](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/camera/) | Viewpoint, preset camera type, rotation, zoom, and perspective. | Rotate the object in 3D space or match a PowerPoint 3D rotation preset. |
| [light_rig](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/light_rig/) | Light preset, direction, and light rotation. | Change how highlights and shadows appear on the 3D surface. |
| [material](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/material/) | Surface material, such as flat, matte, plastic, or metal. | Make the same geometry look flatter, softer, glossy, or metallic. |
| [extrusion_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/extrusion_height/) | How far the shape extends backward from its front face. | Turn a flat shape into a visibly thick 3D object. |
| [extrusion_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/extrusion_color/) | Color of the extruded sides. | Make depth visible or coordinate the side color with the front fill. |
| [depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/depth/) | Additional 3D depth used by PowerPoint 3D formatting. | Fine-tune depth for shapes or text, especially together with bevel and material settings. |
| [bevel_top](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/bevel_bottom/) | Raised or rounded edges on the front and back faces. | Add a softened or molded edge instead of a sharp flat face. |
| [contour_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/contour_width/) | Outline around the 3D object. | Emphasize the object boundary in rendered output. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به‌نظر قانع‌کنندهٔ سه‌بعدی برسد به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض ممکن است اکستروژن را پنهان کند.
- تنظیمات نور، زیرا نوردهی باعث می‌شود سطوح و لبه‌ها قابل مشاهده باشند.
- تنظیمات ماده، زیرا سطح بر نحوه رندر نور تأثیر می‌گذارد.
- تنظیمات اکستروژن یا عمق، زیرا شکل صاف نیاز به ضخامت دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متنی به سطح جلویی آن اضافه می‌نماید، قالب‌بندی سه‌بعدی را اعمال می‌کند، ارائه را به عنوان PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

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

تصویر رندر شدهٔ اسلاید، مستطیل را به‌عنوان یک بلوک ضخیم سه‌بعدی نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سفید سه‌بعدی بر روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل 3‑D Rotation پیکربندی می‌شود. مقادیر چرخش X، Y و Z مطابق با چرخشی است که از طریق API دوربین تنظیم می‌کنید.

![پنل چرخش 3‑D PowerPoint با مقادیر چرخش X، Y و Z برجسته‌شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق [ThreeDFormat.camera](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/camera/) تنظیم کنید:

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ مشاهدهٔ شیء توسط بیننده را تغییر دهید. این کار شکل دو‌بعدی روی اسلاید را تغییر نمی‌دهد؛ فقط نقطهٔ نظر سه‌بعدی استفاده‌شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **اضافه کردن اکستروژن و عمق**

اکستروژن باعث می‌شود یک شکل به‌نظر ضخیم برسد و از سطح جلویی به عقب گسترش یابد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ جانبی‌ها را تعیین می‌کند.

![کنترل‌های عمق PowerPoint به ویژگی‌های رنگ اکستروژن و ارتفاع اکستروژن نگاشت شده‌اند](img_02_02.png)

برای ضخامت از [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/extrusion_height/) و برای رنگ جانبی‌ها از [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/extrusion_color/) استفاده کنید:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

از [ThreeDFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/depth/) زمانی استفاده کنید که نیاز به کار مستقیم با مقدار عمق PowerPoint داشته باشید یا عمق را همراه با bevel، material و اثرات متن ترکیب کنید. در بسیاری از سناریوهای شکل، استفاده از [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/extrusion_height/) واضح‌تر است زیرا مستقیماً ضخامت قابل رؤیت را بیان می‌کند.

## **استفاده از پر کردن‌های گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پر کردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پر کردن تصویر را بر سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و اکستروژن استفاده کنید.

مثال زیر یک پر کردن گرادیان به شکل اعمال می‌کند و رنگ جانبی‌ها را تاریک‌تر می‌سازد:

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

خروجی رندر شده، گرادیان را بر روی سطح جلویی حفظ می‌کند و اکستروژن را به‌صورت جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پر کردن گرادیان آبی‑به‑نارنجی و اکستروژن نارنجی](img_02_03.png)

برای استفاده از پر کردن تصویر، تصویر را به ارائه اضافه کنید و آن را به پر کردن شکل اختصاص دهید:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که اکستروژن به عنوان سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پر کردن عکس بر روی سطح جلویی و اکستروژن نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر فریم متن اثر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به اکستروژن، ماده، نوردهی و تنظیمات دوربین دارند.

مثال زیر متنی با پر کردن الگو ایجاد می‌کند، تبدیل WordArt اعمال می‌کند و تنظیمات سه‌بعدی را بر روی [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) پیکربندی می‌کند:

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

متن به‌صورت حروف منحنی، اکستروژنی و سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پر کردن الگوی نارنجی و اکستروژن تاریک](img_02_05.png)

## **رفتار صادرات و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره‌سازی به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا صادرات به فرمت‌های ثابت‌طرح، صحنهٔ سه‌بعدی به‌صورت رستری یا به‌عنوان خروجی دو‌بعدی رسم می‌شود. این موضوع هنگام رندر اسلایدها به [PNG](/slides/fa/python-net/convert-powerpoint-to-png/)، صادرات به [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، صادرات به [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدئو](/slides/fa/python-net/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDF‌های صادرشده تعاملی نیستند. پس از خروجی، شیء نمی‌تواند توسط بیننده چرخانده شود.
- ظاهر نهایی به ترکیب دوربین، نوردهی، ماده، اکستروژن، پر کردن و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی ارث‌بری یا مبتنی بر تم دارید، [ویژگی‌های مؤثر شکل](/slides/fa/python-net/shape-effective-properties/) را بخوانید.
- برخی از فرمت‌های خروجی قادر به ذخیرهٔ قالب‌بندی سه‌بعدی ویرایش‌پذیر در PowerPoint نیستند. در این فرمت‌ها، نتیجهٔ بصری به‌جای نگهداری به‌عنوان تنظیمات سه‌بعدی ویرایش‌پذیر، رندر می‌شود.

## **سؤال‌های متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint برای اشکال و متن را ایجاد و رندر می‌کند. این ابزار تصاویر، PDF‌ها یا صفحات HTML صادرشده را صحنهٔ سه‌بعدی تعاملی نمی‌سازد که بیننده بتواند آن را بچرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint باقی می‌ماند در صورتیکه فرمت از آن پشتیبانی کند.

**تفاوت بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، اکستروژن، برجستگی، نوردهی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای یک شکل قابل مشاهدهٔ سه‌بعدی ضروری هستند؟**

حداقل باید چرخش دوربین و یا اکستروژن/عمق را تنظیم کنید. در عمل، همچنین تنظیم نوردهی و ماده را انجام دهید تا سطوح رندرشده روشنایی و سایه‌های واضح داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم بر اشکال و هم بر متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [Shape.three_d_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/three_d_format/) و برای متن از [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/three_d_format/) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام صادرات به تصاویر، PDF، HTML یا فریم‌های ویدئویی ظاهر می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل ویدئو رندر می‌کند. خروجی صادرشده شامل ظاهر رندر شده است، نه شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از APIهای قالب‌بندی مؤثر توصیف‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/python-net/shape-effective-properties/) برای خواندن دوربین نهایی، نوردهی، bevel و مقادیر سه‌بعدی مرتبط استفاده کنید.