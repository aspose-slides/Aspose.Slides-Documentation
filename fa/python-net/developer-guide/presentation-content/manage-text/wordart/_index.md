---
title: ایجاد و اعمال افکت‌های WordArt در Python
linktitle: WordArt
type: docs
weight: 110
url: /fa/python-net/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- افکت WordArt
- افکت سایه
- افکت نمایان‌سازی
- افکت درخشش
- تبدیل WordArt
- افکت 3D
- افکت سایه خارجی
- افکت سایه داخلی
- Python
- Aspose.Slides
description: "نحوه ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای Python via .NET را بیاموزید. این راهنمای قدم‌به‌قدم به توسعه‌دهندگان کمک می‌کند تا ارائه‌های خود را با متن‌های شیک و حرفه‌ای در Python ارتقاء دهند."
---
## **نمایش کلی**

افکت‌های WordArt به شما امکان می‌دهند متن‌های زیبا و استایل‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله نمای کلی کار با WordArt را ارائه می‌دهد، از جمله چگونگی اعمال تبدیل‌های متنی، سبک‌های پرکردن، خطوط بیرونی، سایه‌ها و سایر گزینه‌های قالب‌بندی برای جذاب‌تر و بیان‌گرانه‌تر کردن محتوای ارائه. WordArt به شما اجازه می‌دهد متن را به‌عنوان یک شی گرافیکی درنظر بگیرید. این شامل افکت‌ها یا تغییرات ویژه‌ای است که بر متن اعمال می‌شود تا جذاب‌تر یا قابل‌توجه‌تر باشد.

**WordArt در Microsoft PowerPoint**

برای استفاده از WordArt در Microsoft PowerPoint، باید یکی از قالب‌های از پیش تعریف‌شده WordArt را انتخاب کنید. یک قالب WordArt مجموعه‌ای از افکت‌هاست که بر متن یا شکل آن اعمال می‌گردد.

**WordArt در Aspose.Slides**

در Aspose.Slides برای Python via .NET نسخه 20.10، پشتیبانی از WordArt پیاده‌سازی شد و بهبودهایی در نسخه‌های بعدی این محصول اعمال گشت.

با Aspose.Slides برای Python via .NET، می‌توانید به‌راحتی قالب WordArt خود را (یک افکت یا ترکیبی از افکت‌ها) در Python ایجاد و به متون اعمال کنید.

## ایجاد یک قالب ساده WordArt و اعمال آن به یک متن

**استفاده از Aspose.Slides**

در ابتدا، متن ساده‌ای را با کد Python زیر می‌سازیم:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
حال، با کد زیر ارتفاع فونت متن را به مقدار بزرگ‌تری تنظیم می‌کنیم تا افکت بیشتر به چشم بیاید:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**استفاده از Microsoft PowerPoint**

به منوی افکت‌های WordArt در Microsoft PowerPoint بروید:

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک افکت WordArt از پیش تعریف‌شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید.

این‌ها برخی از پارامترها یا گزینه‌های موجود هستند:

![todo:image_alt_text](image-20200930114015-3.png)

**استفاده از Aspose.Slides**

در اینجا، رنگ الگوی SmallGrid را به متن اعمال کرده و یک حاشیه متن سیاه با عرض 1 با این کد اضافه می‌کنیم:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

متن حاصل:

![todo:image_alt_text](image-20200930114108-4.png)

## اعمال سایر افکت‌های WordArt

**استفاده از Microsoft PowerPoint**

از طریق رابط برنامه می‌توانید این افکت‌ها را بر متن، بلوک متن، شکل یا عنصر مشابهی اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به‌عنوان مثال، افکت‌های Shadow، Reflection و Glow می‌توانند بر متن اعمال شوند؛ افکت‌های 3D Format و 3D Rotation می‌توانند بر بلوک متن اعمال شوند؛ ویژگی Soft Edges می‌تواند بر یک شی Shape اعمال شود (هنوز هنگام عدم تنظیم ویژگی 3D Format اثر دارد).

### اعمال افکت‌های سایه

در اینجا قصد داریم فقط به ویژگی‌های متن مربوطه تنظیم کنیم. افکت سایه را بر متن با این کد Python اعمال می‌کنیم:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

API Aspose.Slides سه نوع سایه را پشتیبانی می‌کند: OuterShadow، InnerShadow و PresetShadow.

با PresetShadow می‌توانید سایه‌ای برای متن (با مقادیر پیش‌فرض) اعمال کنید.

**استفاده از Microsoft PowerPoint**

در PowerPoint فقط می‌توانید از یک نوع سایه استفاده کنید. مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**استفاده از Aspose.Slides**

Aspose.Slides در واقع اجازه می‌دهد دو نوع سایه را همزمان اعمال کنید: InnerShadow و PresetShadow.

**نکات:**

- وقتی OuterShadow و PresetShadow باهم استفاده شوند، فقط افکت OuterShadow اعمال می‌شود.
- اگر OuterShadow و InnerShadow به‌طور همزمان استفاده شوند، اثر نهایی بسته به نسخه PowerPoint متفاوت است. به‌عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود؛ اما در PowerPoint 2007 افکت OuterShadow اعمال می‌شود.

### اعمال Display به متون

با این نمونه کد Python به متن Display اضافه می‌کنیم:

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### اعمال افکت Glow به متون

با این کد افکت Glow را به متن اضافه می‌کنیم تا درخشان یا برجسته شود:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

می‌توانید پارامترهای سایه، Display و Glow را تغییر دهید. ویژگی‌های افکت‌ها به‌صورت جداگانه بر هر بخش از متن تنظیم می‌شوند.

{{% /alert %}} 

### استفاده از Transformations در WordArt

با این کد از ویژگی Transform (که بر کل بلوک متن اعمال می‌شود) استفاده می‌کنیم:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

نتیجه:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

هر دو Microsoft PowerPoint و Aspose.Slides برای Python via .NET تعداد معینی از انواع تبدیل‌های از پیش تعریف‌شده را ارائه می‌دهند.

{{% /alert %}} 

**استفاده از PowerPoint**

برای دسترسی به انواع تبدیل از پیش تعریف‌شده، به مسیر زیر مراجعه کنید: **Format** → **TextEffect** → **Transform**

**استفاده از Aspose.Slides**

برای انتخاب نوع تبدیل، از enum TextShapeType استفاده کنید.

### اعمال افکت‌های 3D به متون و اشکال

با این کد نمونه یک افکت 3D به شکل متن اعمال می‌کنیم:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

متن و شکل حاصل:

![todo:image_alt_text](image-20200930114816-9.png)

افکت 3D را به متن با این کد Python اعمال می‌کنیم:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

اعمال افکت‌های 3D بر متون یا اشکال آن‌ها و تعامل بین افکت‌ها براساس قواعد خاصی است.

یک صحنه برای متن و شکل حاوی آن متن در نظر بگیرید. افکت 3D شامل نمایش شیء 3D و صحنه‌ای است که شیء روی آن قرار می‌گیرد.

- زمانی که صحنه برای هر دو شکل و متن تنظیم شده باشد، صحنه شکل اولویت بالاتری دارد—صحنه متن نادیده گرفته می‌شود.
- وقتی شکل صحنه خود را ندارد اما نمایش 3D دارد، صحنه متن استفاده می‌شود.
- در غیر این صورت—زمانی که شکل در اصل هیچ افکت 3D ندارد—شكل صاف است و افکت 3D فقط بر متن اعمال می‌شود.

این توضیحات به ویژگی‌های [ThreeDFormat.LightRig](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) و [ThreeDFormat.Camera](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) مرتبط هستند.

{{% /alert %}} 

## **اعمال افکت Outer Shadow به متون**
Aspose.Slides برای Python via .NET کلاس‌های [**IOuterShadow**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/ioutershadow/) و [**IInnerShadow**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/iinnershadow/) را فراهم می‌کند که امکان اعمال افکت‌های سایه به متن درون TextFrame را می‌دهند. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، مرجع اسلاید را دریافت کنید.
3. یک AutoShape از نوع Rectangle به اسلاید اضافه کنید.
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید.
5. FillType AutoShape را به NoFill تنظیم کنید.
6. کلاس OuterShadow را نمونه‌سازی کنید.
7. BlurRadius سایه را تنظیم کنید.
8. Direction سایه را تنظیم کنید.
9. Distance سایه را تنظیم کنید.
10. RectanglelAlign را به TopLeft تنظیم کنید.
11. PresetColor سایه را به Black تنظیم کنید.
12. ارائه را به صورت فایل PPTX ذخیره کنید.

این کد نمونه در Python—پیاده‌سازی مراحل فوق—نحوه اعمال افکت Outer Shadow به یک متن را نشان می‌دهد:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # دریافت مرجع اسلاید
    sld = pres.slides[0]

    # افزودن AutoShape از نوع Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # افزودن TextFrame به Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # غیرفعال‌سازی پرکردن شکل در صورتی که بخواهیم سایه متن را دریافت کنیم
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # افزودن سایه خارجی و تنظیم تمام پارامترهای لازم
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #نوشتن ارائه در دیسک
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **اعمال افکت Inner Shadow به اشکال**
این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را دریافت کنید.
3. یک AutoShape از نوع Rectangle اضافه کنید.
4. InnerShadowEffect را فعال کنید.
5. تمام پارامترهای لازم را تنظیم کنید.
6. ColorType را به Scheme تنظیم کنید.
7. رنگ Scheme را تعیین کنید.
8. ارائه را به عنوان فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.

این کد نمونه (بر پایه مراحل فوق) نشان می‌دهد چگونه یک connector بین دو شکل در Python اضافه کنید:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # دریافت مرجع یک اسلاید
    slide = presentation.slides[0]

    # اضافه کردن AutoShape از نوع Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # اضافه کردن TextFrame به Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # فعال‌سازی inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # تنظیم تمام پارامترهای لازم
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # تنظیم ColorType به عنوان Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # تنظیم رنگ Scheme
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # ذخیره ارائه
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مثلاً عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکردن و خط حاشیه بدون توجه به زبان قابل اعمال هستند، هرچند در دسترس بودن فونت و رندرینگ ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را بر عناصر ماسเตอร์ اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را بر اشکال موجود در اسلایدهای ماسټر، از جمله جای‌دارهای عنوان، فوتر یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده بر روی قالب ماسټر در تمام اسلایدهای مرتبط بازتاب می‌یابد.

**آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارند؟**

به‌صورت جزئی. افکت‌هایی چون سایه، Glow و پرکردن گرادیانی ممکن است حجم فایل را به دلیل افزودن متادیتای قالب‌بندی کمی افزایش دهند، اما اختلاف معمولاً ناچیز است.

**آیا می‌توانم نتایج افکت‌های WordArt را بدون ذخیره‌سازی ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای حاوی WordArt را به‌صورت تصویر (مثلاً PNG یا JPEG) رندر کنید با استفاده از متد `get_image` از کلاس‌های [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) یا [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/). این امکان پیش‌نمایش نتیجه را به‌صورت در‑حافظه یا روی صفحه نمایش قبل از ذخیره یا صادرات کل ارائه می‌دهد.