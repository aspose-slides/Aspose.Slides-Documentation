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
- افکت درخشندگی
- افکت لبه‌های نرم
- قالب افکت
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "فایل‌های PPT، PPTX و ODP خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای پایتون تغییر شکل دهید—در عرض ثانیه‌ها اسلایدهای چشم‌نواز و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها متفاوت از [پرکننده‌ها](/slides/fa/python-net/shape-formatting/#gradient-fill) یا خطوط پیرامون هستند. با استفاده از افکت‌های PowerPoint می‌توانید بازتاب‌های قابل‌اعتمادی روی یک شکل ایجاد کنید، نورانی شدن شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت ارائه می‌دهد که می‌توان آنها را بر روی اشکال اعمال کرد. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از بقیه به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset در واقع ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای Python از طریق .NET از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع محو شدن آنها را برای مطابقت با طراحی ارائه‌تان سفارشی کنید.

### **اعمال سایه خارجی**

از سایه خارجی برای برجسته کردن یک کارت یا پانل در پشت‌صحنه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و این تصور را ایجاد می‌کند که شکل از اسلاید بالا آمده است. رنگ، جهت، فاصله و شعاع محو شدن آن را برای تطبیق با نورپردازی و سبک قالب‌تان تنظیم کنید.

این کد پایتون نشان می‌دهد چگونه [افکت سایه خارجی](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) را بر روی یک مستطیل اعمال کنید:
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

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک قالب، از سایه داخلی برای دادن ظاهری تو خورده به کارت یا پانل استفاده کنید. سایه خارجی خارج از شکل گسترش می‌یابد و باعث ظاهر برجسته شدن می‌شود، در حالی که سایه داخلی داخل لبه‌های آن را سایه‌دار می‌کند.

Call [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), then configure [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Larger blur-radius values produce softer edges.

این مثال پایتون یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و به صورت فایل PPTX ذخیره می‌نماید:
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

برای حذف سایه داخلی، متد [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) را بر روی فرمت افکت شکل فراخوانی کنید.

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای Python از طریق .NET، می‌توانید انعکاسی شبیه آینه به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی عناصر متعدد برای داشتن طراحی یکدست را فراهم می‌کند.

این کد پایتون نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) را بر یک شکل اعمال کنید:
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

## **اعمال افکت درخشندگی**

برای اعمال افکت درخشندگی به شکلی در Aspose.Slides برای Python از طریق .NET، می‌توانید هاله‌ای نرم و روشن دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه‌تان می‌افزاید. با کد minimal می‌توان آن را به‌راحتی پیاده‌سازی کرد و ظاهر کلی اسلایدها را ارتقا داد.

این کد پایتون نشان می‌دهد چگونه [افکت درخشندگی](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) را بر یک شکل اعمال کنید:
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

![افکت درخشندگی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای Python از طریق .NET، می‌توانید انتقالی صاف و محو در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر نرم‌تر و ظریف‌تری می‌دهد که برای طرح‌هایی که به ظاهری ملایم نیاز دارند مناسب است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مطلوب را بر روی اشکال مختلف در ارائه‌تان به‌دست آورید.

این کد پایتون نشان می‌دهد چگونه [لبه‌های نرم](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) را بر یک شکل اعمال کنید:
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

از محو شدن شکل برای نرم کردن پرکننده و خطوط پیرامون یک شکل استفاده کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب نقاط (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگتر باعث محو شدن قوی‌تر می‌شوند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) محدوده قابل مشاهده افکت را کنترل می‌کند. با `False`، محو شدن به محدوده‌های نقاشی اولیه، شامل خطوط پیرامون، محدود می‌شود. با `True`، محو می‌تواند فراتر از آن محدوده‌ها گسترش یابد. هیچ‌کدام از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسه زیر از یک پرکننده، خط پیرامون و ابعاد شکل ثابت در تمام نمونه‌ها استفاده می‌کند. ردیف بالایی از `grow = False` استفاده می‌کند؛ ردیف پایین از `grow = True`.

![مستطیل اصلی مقایسه‌شده با شعاع‌های محو ۵ و ۱۵ نقطه، با grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال پایتون یک مستطیل نارنجی با خط پیرامون آبی تیره ایجاد می‌کند، محو ۵ نقطه‌ای اعمال می‌نماید و سپس با فراخوانی [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) آن را به محو ۱۵ نقطه‌ای به‌روز می‌کند. هر دو وضعیت محو‌شده را ذخیره می‌کند، سپس با فراخوانی [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) شکل را بدون محو ذخیره می‌نماید.
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

محو شکل هم بر پرکننده و هم بر خطوط پیرامون تأثیر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که محو سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر عمل می‌کنند؛ این مثال محو را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون اینکه شکل به تصویر تبدیل شود.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد کنید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر اشکال مختلفی مانند اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و غیره اعمال کنید.

**آیا می‌توانم افکت‌ها را بر اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر اشکال گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.