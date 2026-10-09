---
title: اعمال افکت‌های شکل در ارائه‌ها با Python
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/python-net/shape-effect
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت نورانی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "فایل‌های PPT، PPTX و ODP خود را با افکت‌های پیشرفته شکل با استفاده از Aspose.Slides برای Python—اسلایدهای جذاب و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آنها با [پرکننده‌ها](/slides/fa/python-net/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده‌ای بر روی یک شکل ایجاد کنید، روشنایی (glow) شکل را پخش کنید و غیره.

![Shape effect](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توان بر روی اشکال اعمال کرد. می‌توانید یک یا چند افکت را به یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset در واقع ترکیب معروف و زیبا از دو یا چند افکت هستند. بدین ترتیب با انتخاب یک پیش‌تنظیم، نیازی به صرف وقت برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن یک ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و روش‌هایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال اثر سایه**

Aspose.Slides for Python via .NET از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آنها را برای مطابقت با طراحی ارائه خود تنظیم کنید.

### **اعمال سایه بیرونی**

از یک سایه بیرونی استفاده کنید تا یک کارت یا پنل در برابر پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل امتداد می‌یابد و این تصور را ایجاد می‌کند که شکل بالای اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع تاری آن را برای مطابقت با نورپردازی و سبک قالب خود تنظیم کنید.

این کد پایتون نشان می‌دهد چگونه [اثر سایه بیرونی](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) را بر روی یک مستطیل اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Shadow effect](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری یک قالب، از یک سایه داخلی استفاده کنید تا به یک کارت یا پنل ظاهر فرو رفته بدهید. یک سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بالا برمی‌دارد، در حالی که یک سایه داخلی لبه‌های داخلی آن را سایه می‌اندازد.

متد [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) را فراخوانی کنید، سپس [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تاری، لبه‌های نرم‌تری تولید می‌کنند.

این مثال پایتون یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) را بر روی فرمت افکت شکل فراخوانی کنید.

## **اعمال اثر انعکاس**

برای اعمال اثر انعکاس در Aspose.Slides for Python via .NET، می‌توانید انعکاس مشابه آینه را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این اثر ظاهر زیبایی به ارائه‌های شما می‌بخشد و شکل‌ها را براق و شیک می‌کند. پیاده‌سازی آن با کد ساده‌ای امکان‌پذیر است و به شما اجازه می‌دهد به سرعت این اثر را بر روی عناصر متعدد برای یک طراحی یکنواخت اعمال کنید.

این کد پایتون نشان می‌دهد چگونه [اثر انعکاس](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) را بر روی یک شکل اعمال کنید:

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

![Reflection effect](reflection_effect.png)

## **اعمال اثر نورانی**

برای اعمال اثر نورانی (glow) بر روی یک شکل در Aspose.Slides for Python via .NET، می‌توانید هاله‌ای نرم و درخشان در اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این اثر به شکل‌ها کمک می‌کند تا برجسته شوند و به ارائه شما جلوه‌ای جذاب و چشم‌نوازی می‌بخشد. پیاده‌سازی آن با کد کمینه‌ای امکان‌پذیر است و ظاهر کلی اسلایدهای شما را ارتقا می‌دهد.

این کد پایتون نشان می‌دهد چگونه [اثر نورانی](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) را بر روی یک شکل اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Glow effect](glow_effect.png)

## **اعمال اثر لبه‌های نرم**

برای اعمال اثر لبه‌های نرم در Aspose.Slides for Python via .NET، می‌توانید انتقال صاف و مبهمی در اطراف لبه‌های یک شکل ایجاد کنید. این اثر ظاهر ملایم‌تر و ظریف‌تری می‌بخشد که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند مناسب است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر دلخواه را بر روی اشکال مختلف در ارائه خود به‌دست آورید.

این کد پایتون نشان می‌دهد چگونه [لبه‌های نرم](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) را بر روی یک شکل اعمال کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Soft edges effect](soft_edges_effect.png)

## **سوالات متداول**

**آیا می‌توانم چندین اثر را به یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و نورانی را بر روی یک شکل ترکیب کنید تا ظاهر پویاتری ایجاد شود.

**به چه شکل‌هایی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع شکل‌ها، از جمله اشکال خودکار، نمودارها، جداول، تصاویر، اشیاء SmartArt، اشیاء OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی شکل‌های گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی شکل‌های گروهی اعمال کنید. افکت بر کل گروه اعمال می‌شود.