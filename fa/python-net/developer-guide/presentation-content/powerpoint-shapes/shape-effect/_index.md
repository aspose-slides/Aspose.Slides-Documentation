---
title: "اعمال افکت‌های شکل در ارائه‌ها با پایتون"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/python-net/shape-effect
keywords:
- "افکت شکل"
- "افکت سایه"
- "افکت انعکاس"
- "افکت درخششی"
- "افکت لبه‌های نرم"
- "قالب افکت"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Python"
- "Aspose.Slides"
description: "فایل‌های PPT، PPTX و ODP خود را با استفاده از افکت‌های پیشرفتهٔ شکل در Aspose.Slides برای پایتون تبدیل کنید - در چند ثانیه اسلایدهای چشم‌نواز و حرفه‌ای بسازید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها متفاوت از [fills](/slides/fa/python-net/shape-formatting/#gradient-fill) یا خطوط مرزی هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، درخشانی شکل را پخش کنید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت فراهم می‌کند که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset در واقع ترکیب شناخته‌شده‌ای از دو یا چند افکت زیبا هستند. به این ترتیب، با انتخاب یک preset، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) فراهم می‌کند که به شما اجازه می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال اثر سایه**

Aspose.Slides برای Python از طریق .NET از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو شدن آن‌ها را مطابق با طراحی ارائه خود تنظیم کنید.

### **اعمال سایه خارجی**

از سایه خارجی استفاده کنید تا یک کارت یا پنل نسبت به پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل گسترش می‌یابد و این تصور را ایجاد می‌کند که شکل بالای اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع محو شدن آن را مطابق با نورپردازی و سبک قالب خود تنظیم کنید.

این کد Python نشان می‌دهد چگونه [outer shadow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) را بر روی یک مستطیل اعمال کنید:

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

![اثر سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک قالب، از سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهر فرو رفته بدهید. سایه خارجی در خارج از شکل گسترش می‌یابد و آن را بالا می‌آورد، در حالی که سایه داخلی لبه‌های داخلی را سایه می‌کند.

متد [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) را فراخوانی کنید، سپس [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) را پیکربندی کنید. مقادیر بزرگتر شعاع محو، لبه‌های نرم‌تری تولید می‌کند.

این مثال Python یک کارت آبی‑سفید با سایه داخلی خاکستری‑تیره ایجاد می‌کند و آن را به عنوان فایل PPTX ذخیره می‌گرداند:

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

![مستطیل آبی‑سفید با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) را بر روی فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف سایهٔ پیش‌فرض**

متد [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) را فراخوانی کنید و ویژگی [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) سایه را به مقدار یک [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) تنظیم کنید. برای تغییر سبک‌ها، پیش‌فرض را روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرش و مرز حفظ می‌شود، متد [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) را فراخوانی کنید.

این مثال چهار مرحله را به‌صورت کنار هم در یک اسلاید نشان می‌دهد. قبل از هر تغییر، مستطیل کپی می‌شود تا بتوانید نتایج را مقایسه کنید. هر دو سایه با ۱۰ نقطه جابجا شده‌اند. جهت ۲۲۵° سایهٔ اول را بالای سمت چپ مستطیل قرار می‌دهد و ۴۵° سایهٔ دوم را پایین سمت راست.

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

| اصلی | اولین پیش‌فرض | دومین پیش‌فرض | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![بدون سایه](preset_shadow_original.png) | ![سایهٔ قطره‌ای بالا‑چپ](preset_shadow_top_left.png) | ![سایهٔ قطره‌ای پایین‑راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال اثر انعکاس**

برای اعمال اثر انعکاس در Aspose.Slides برای Python از طریق .NET، می‌توانید انعکاس شبیه آینه را به اشکال اضافه کنید و پارامترهایی نظیر فاصله، شفافیت و اندازه را تنظیم کنید. این اثر ظاهر ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته بهبود می‌بخشد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی عناصر متعدد برای داشتن طراحی یکنواخت را فراهم می‌کند.

این کد Python نشان می‌دهد چگونه [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) را بر روی یک شکل اعمال کنید:

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

![اثر انعکاس](reflection_effect.png)

## **اعمال اثر درخششی**

برای اعمال اثر درخششی به یک شکل در Aspose.Slides برای Python از طریق .NET، می‌توانید اطراف شکل‌ها هالهٔ نرم و تابان اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این اثر به برجسته شدن شکل‌ها کمک می‌کند و عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. پیاده‌سازی آن با حداقل کد ساده است و ظاهر کلی اسلایدهای شما را ارتقا می‌بخشد.

این کد Python نشان می‌دهد چگونه [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) را بر روی یک شکل اعمال کنید:

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

![اثر درخششی](glow_effect.png)

## **اعمال اثر لبه‌های نرم**

برای اعمال اثر لبه‌های نرم در Aspose.Slides برای Python از طریق .NET، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این اثر ظاهر ملایم‌تری می‌بخشد که برای طراحی‌هایی که به ظاهری لطیف و نرم نیاز دارند، ایده‌آل است. می‌توانید پارامترهایی مانند شعاع را به‌راحتی تنظیم کنید تا اثر دلخواه را بر روی اشکال مختلف در ارائه‌تان به دست آورید.

این کد Python نشان می‌دهد چگونه [soft edges](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) را بر روی یک شکل اعمال کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![اثر لبه‌های نرم](soft_edges_effect.png)

## **اعمال اثر محو شدن**

از محو شدن شکل استفاده کنید تا پرش و خط مرزی شکل را نرم کنید در حالی که شکل ویرایش‌پذیر می‌ماند. متد [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب نقطه (۱/۷۲ اینچ) اندازه‌گیری می‌شود: از مقدار غیر منفی استفاده کنید؛ مقادیر بزرگتر محو شدن قوی‌تری تولید می‌کند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) محدوده قابل مشاهدهٔ اثر را کنترل می‌کند. با `False`، محو شدن به محدودهٔ رنگ شدهٔ اصلی، شامل خط مرزی، محدود می‌شود. با `True`، محو شدن می‌تواند فراتر از این محدوده گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسهٔ زیر از همان پرش، خط مرزی و ابعاد شکل در تمام مراحل استفاده می‌کند. ردیف بالایی `grow = False` است؛ ردیف پایین `grow = True`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو ۵ و ۱۵ نقطه، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال Python یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، محو ۵ نقاط را اعمال می‌نماید و سپس با فراخوانی مجدد [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) به محو ۱۵ نقطه ارتقا می‌دهد. هر دو وضعیت محو شده را ذخیره می‌کند، سپس با فراخوانی [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) شکل را بدون محو ذخیره می‌کند.

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

محو شدن شکل هم پرش و هم خط مرزی را به‌طور همزمان تحت تأثیر قرار می‌دهد. اثر لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو شدن سایه فقط سایه را نرم می‌کند. اثرات تبدیل تصویر بر محتوای تصویر عمل می‌کند؛ این مثال محو را مستقیماً بر فرمت افکت شکل بدون تبدیل به تصویر اعمال می‌کند.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخششی را روی یک شکل ترکیب کنید تا ظاهر پویاتری به دست آورید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع شکل‌ها، از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی‌شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی‌شده اعمال کنید. افکت به کل گروه اعمال خواهد شد.