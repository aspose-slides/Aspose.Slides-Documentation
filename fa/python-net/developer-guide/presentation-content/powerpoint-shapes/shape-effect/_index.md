---
title: "اعمال افکت‌های شکل در ارائه‌ها با پایتون"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/python-net/shape-effect
keywords:
- "افکت شکل"
- "افکت سایه"
- "افکت بازتاب"
- "افکت درخشندگی"
- "افکت لبه‌های نرم"
- "قالب افکت"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Python"
- "Aspose.Slides"
description: "فایل‌های PPT، PPTX و ODP خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای پایتون تبدیل کنید—در چند ثانیه اسلایدهای برجسته و حرفه‌ای ایجاد کنید."
---
## **معرفی**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آنها با [پرکننده‌ها](/slides/fa/python-net/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های پاورپوینت، می‌توانید بازتاب‌های قابل‌اعتماد روی یک شکل ایجاد کنید، درخشندگی شکل را پخش کنید، و غیره.

<img src="shape-effect.png" alt="اثر-شکل" style="zoom:50%;" />

* پاورپوینت شش افکت را فراهم می‌کند که می‌توان بر روی اشکال اعمال کرد. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید. 

* برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، گزینه‌های پاورپوینت تحت **Preset**. گزینه‌های Preset اساساً ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. بدین ترتیب، با انتخاب یک پیش‌فرض، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی را تحت کلاس [EffectFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

این کد پایتون به شما نشان می‌دهد چگونه افکت سایه بیرونی (`outer_shadow_effect`) را به یک مستطیل اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **اعمال افکت بازتاب**

این کد پایتون به شما نشان می‌دهد چگونه افکت بازتاب را بر یک شکل اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **اعمال افکت درخشندگی**

این کد پایتون به شما نشان می‌دهد چگونه افکت درخشندگی را بر یک شکل اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **اعمال افکت لبه‌های نرم**

این کد پایتون به شما نشان می‌دهد چگونه لبه‌های نرم را بر یک شکل اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، بازتاب و درخشندگی را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد کنید.

**به چه شکل‌هایی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی اشکال مختلفی مانند اشکال خودکار، نمودارها، جداول، تصاویر، اشیای SmartArt، اشیای OLE و غیره اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنید. این افکت بر کل گروه اعمال خواهد شد.