---
title: اعمال افکت‌های شکل در ارائه‌ها با پایتون
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/python-net/shape-effect
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت تابش
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "فایل‌های PPT، PPTX و ODP خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای پایتون تبدیل کنید—در چند ثانیه اسلایدهای چشم‌نواز و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آنها با [پرکردن‌ها](/slides/fa/python-net/shape-formatting/#gradient-fill) یا خطوط بیرونی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش یک شکل را پخش کنید و غیره.

![افکت شکل](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توانند بر روی شکل‌ها اعمال شوند. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset در واقع ترکیب شناخته‌شده و زیبایی از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و روش‌هایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی شکل‌ها در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides for Python via .NET از سایه‌های خارجی و داخلی برای شکل‌ها پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو آن‌ها را برای مطابقت با طرح ارائه‌تان سفارشی کنید.

### **اعمال سایه خارجی**

از یک سایه خارجی استفاده کنید تا یک کارت یا پنل نسبت به پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل گسترش می‌یابد و احساس می‌کند شکل بالای اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع محو آن را تنظیم کنید تا با نورپردازی و استایل قالب شما سازگار باشد.

این کد Python نشان می‌دهد چگونه [افکت سایه خارجی](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) را بر روی یک مستطیل اعمال کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![افکت سایه](shadow_effect.png)

#### **کنترل جهت سایه هنگام چرخش شکل**

به‌طور پیش‌فرض، [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) برابر `True` است، بنابراین سایه همراه با شکل می‌چرخد. برای اینکه شکل‌ها با چرخش‌های مختلف از همان جهت نوردهی شوند، این ویژگی را به `False` تنظیم کنید و به سایه‌هایشان همان [جهت](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/) را بدهید.

مثال دو پیکانی با سایه‌های خاکستری که ۴۲ پوینت به سمت راست جابه‌جا شده‌اند (`direction = 0`) ایجاد می‌کند. سپس اسلاید را تکثیر کرده و هر دو پیکان را ۹۰° ساعتگرد می‌چرخاند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

در اسلاید دوم، پیکان چپ سایه خود را به سمت پایین می‌اندازد، در حالی که پیکان راست همچنان سایه‌اش به سمت راست می‌باشد. جهت تنظیم‌شده برای هر دو سایه ۰° باقی می‌ماند.

![پردازش PowerPoint قبل و بعد از چرخش 90°. هر دو سایه ابتدا سمت راست هستند. پس از چرخش، سایه زیر فلش چپ می‌آید و در سمت راست فلش راست می‌ماند.](arrow-shadow-rotation.png)

### **اعمال سایه داخلی**

هنگام بازآفرینی استایل بصری یک قالب، از یک سایه داخلی استفاده کنید تا یک کارت یا پنل ظاهر فرو رفته‌ای داشته باشد. سایه خارجی بیرون از شکل گسترش می‌یابد و شکل را بالا می‌آورد، در حالی که سایه داخلی لبه‌های داخلی را سایه‌دار می‌کند.

از [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) فراخوانی کنید، سپس [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) را پیکربندی کنید. مقادیر بزرگتر شعاع محو، لبه‌های نرم‌تری ایجاد می‌کند.

این مثال Python یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و به‌صورت فایل PPTX ذخیره می‌شود:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، به‌صورت [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) بر روی فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم**

از [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) فراخوانی کنید و ویژگی [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) سایه را به یک مقدار از نوع [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) تنظیم کنید. برای تعویض سبک‌ها، پیش‌تنظیم را بر روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرکردن و خط بیرونی حفظ می‌شوند، از [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) استفاده کنید.

این مثال چهار مرحله را به صورت کنار هم در یک اسلاید نشان می‌دهد. قبل از هر تغییر مستطیل را کپی می‌کند تا بتوانید نتایج را مقایسه کنید. هر دو سایه ۱۰ پوینت جابه‌جا شده‌اند. جهت ۲۲۵° اولین سایه را بالای سمت چپ مستطیل می‌گذارد و ۴۵° دومین سایه را پایین سمت راست می‌چسباند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| اصلی | پیش‌تنظیم اول | پیش‌تنظیم دوم | بعد از حذف |
| :---: | :---: | :---: | :---: |
| ![بدون سایه](preset_shadow_original.png) | ![سایه افت بالا-چپ](preset_shadow_top_left.png) | ![سایه افت پایین-راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides for Python via .NET، می‌توانید انعکاس مشابه آینه‌ای را به شکل‌ها اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت ظاهر ارائه‌های شما را با دادن ظاهری صیقلی و شیک به شکل‌ها ارتقا می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع در چندین عنصر برای یک طراحی یکنواخت را فراهم می‌کند.

این کد Python نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) را بر روی یک شکل اعمال کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![افکت انعکاس](reflection_effect.png)

## **اعمال افکت تابش**

برای اعمال افکت تابش به یک شکل در Aspose.Slides for Python via .NET، می‌توانید هاله‌ای نرم و درخشان دور شکل‌ها اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته‌کردن شکل‌ها کمک کرده و عنصر بصری جذابی به ارائه شما می‌آورد. پیاده‌سازی آن با حداقل کد آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد Python نشان می‌دهد چگونه [افکت تابش](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) را بر روی یک شکل اعمال کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![افکت تابش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides for Python via .NET، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهری ظریف و صیقل‌دارتر می‌بخشد، مناسب برای طرح‌هایی که به ظاهری ملایم و نرم نیاز دارند. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مطلوب را بر روی انواع مختلف شکل‌ها در ارائه خود به‌دست آورید.

این کد Python نشان می‌دهد چگونه [لبه‌های نرم](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) را بر روی یک شکل اعمال کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![افکت لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت محو**

از محو شکل استفاده کنید تا پرکردن و خط بیرونی یک شکل را نرم کنید در حالی که شکل قابل ویرایش می‌ماند. با فراخوانی [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) بر روی فرمت افکت شکل، شعاع را که بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود، تنظیم کنید؛ مقدار غیرمنفی استفاده کنید، مقادیر بزرگتر محو قوی‌تری ایجاد می‌کنند. شعاع صفر ظاهر را تغییری نمی‌دهد.

تنظیم [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) محدوده قابل مشاهده افکت را کنترل می‌کند. با `False`، محو به محدوده‌های اصلی نقاشی، شامل خط بیرونی، محدود می‌شود. با `True`، محو می‌تواند فراتر از آن محدوده‌ها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از همان پرکردن، خط بیرونی و ابعاد شکل در تمام طول استفاده می‌کند. ردیف بالایی `grow = False` دارد؛ ردیف پایین `grow = True`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو 5 و 15 پوینت، با رشد غیرفعال و فعال](shape_blur_comparison.png)

این مثال Python یک مستطیل نارنجی با خط بیرونی آبی تیره ایجاد می‌کند، محو 5 پوینتی اعمال می‌کند و سپس با فراخوانی دوباره [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) آن را به محو 15 پوینت به‌روز می‌کند. هر دو حالت محو را ذخیره می‌کند، سپس با فراخوانی [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) شکل را بدون محو ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

محو شکل همزمان بر پرکردن و خط بیرونی تاثیر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو سایه تنها سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر اعمال می‌شوند؛ این مثال محو را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون تبدیل شکل به تصویر.

## **سؤالات متداول**

**آیا می‌توانم چند افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و تابش را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد کنید.

**به چه شکل‌هایی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع شکل‌ها شامل اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی شکل‌های گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی شکل‌های گروه‌بندی‌شده اعمال کنید. افکت بر تمام گروه اعمال خواهد شد.