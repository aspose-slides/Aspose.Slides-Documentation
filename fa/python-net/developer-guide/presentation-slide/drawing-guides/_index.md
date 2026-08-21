---
title: مدیریت راهنماهای رسم در ارائه‌ها با پایتون
linktitle: راهنماهای رسم
type: docs
weight: 85
url: /fa/python-net/drawing-guides/
keywords:
- راهنمای رسم
- راهنمای افقی
- راهنمای عمودی
- راهنمای هم‌راستایی
- نمای اسلاید
- اسلاید مستر
- اسلاید طرح‌بندی
- مستر یادداشت
- مستر جزوه
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "راهنماهای افقی و عمودی رسم را در ارائه‌های PowerPoint اضافه، دسترسی داشته و پاک کنید با استفاده از Aspose.Slides برای پایتون از طریق .NET."
---
## **بررسی کلی**

راهنماهای رسم خطوط قابل تنظیم افقی و عمودی هستند که به کاربران کمک می‌کنند تا اشکال را به‌صورت یکنواخت در حین ویرایش یک ارائه در PowerPoint هم‌راستا کنند. این راهنماها به‌ویژه زمانی مفید هستند که یک برنامه یک ارائه را تولید می‌کند که بعداً به‌صورت دستی اصلاح می‌شود: برنامه می‌تواند همان کمک‌های هم‌راستایی را ذخیره کند تا نویسندگان هنگام افزودن یا جابه‌جایی محتوا از آن‌ها پیروی کنند.

راهنماهای رسم ابزارهای ویرایشی هستند، نه محتوای اسلاید. آن‌ها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides برای Python از طریق .NET آن‌ها را از طریق رابط [IDrawingGuidesCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguidescollection/) در دسترس قرار می‌دهد. یک راهنما توسط [IDrawingGuide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguide/) نمایش داده می‌شود و دارای جهت، موقعیت و رنگ است.

موقعیت بر حسب نقطه از گوشه بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمای عمودی از مختصات افقی استفاده می‌کند که معمولاً بین صفر و عرض اسلاید است. یک راهنمای افقی از مختصات عمودی استفاده می‌کند که معمولاً بین صفر و ارتفاع اسلاید است.

## **افزودن راهنماها به نمای اسلاید**

از [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) برای مدیریت راهنماهایی که در حین ویرایش اسلایدهای عادی نمایش داده می‌شوند استفاده کنید. با مقدار [Orientation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/orientation/) و یک موقعیت به‌واحد نقطه، [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguidescollection/add/) را فراخوانی کنید.

مثال زیر یک راهنمای عمودی را در سمت راست مرکز اسلاید و یک راهنمای افقی را در زیر آن اضافه می‌کند:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به راهنماهای رسم**

ویژگی [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguidescollection/count/) و ایندکس‌گر آن دسترسی به راهنماهای موجود را فراهم می‌کنند. ویژگی‌های [IDrawingGuide.orientation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguide/orientation/)، [IDrawingGuide.position](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguide/position/)، و [IDrawingGuide.color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguide/color/) می‌توانند خوانده یا تغییر یابند.

مثال زیر راهنماهای نمای اسلاید را از ارائه‌ای که در بالا ایجاد شد، می‌خواند:
```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **افزودن راهنماها به اسلایدهای مستر و طرح‌بندی**

یک اسلاید مستر و هر یک از اسلایدهای طرح‌بندی آن می‌توانند مجموعه‌های راهنمای رسم خود را داشته باشند. برای یک اسلاید مستر از [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterslide/drawing_guides/) و برای یک اسلاید طرح‌بندی از [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ilayoutslide/drawing_guides/) استفاده کنید.

مثال زیر یک راهنمای عمودی را به اولین اسلاید مستر و یک راهنمای افقی را به اولین اسلاید طرح‌بندی اضافه می‌کند:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن راهنماها به مسترهای یادداشت و جزوه**

مسترهای یادداشت و مسترهای جزوه نیز از راهنماهای رسم پشتیبانی می‌کنند. برای دسترسی به مجموعه‌های آن‌ها از [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasternotesslide/drawing_guides/) و [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) استفاده کنید. اگر ارائه حاوی یکی از این مسترها نباشد، [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) یا [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) مستر پیش‌فرض را ایجاد کرده و برمی‌گرداند.

مثال زیر یک راهنمای افقی را به یک مستر یادداشت و یک راهنمای عمودی را به یک مستر جزوه اضافه می‌کند:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **پاک‌سازی راهنماهای رسم**

با فراخوانی [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/idrawingguidescollection/clear/) می‌توانید تمام راهنماها را از یک مجموعه خاص حذف کنید. پاک‌سازی یک مجموعه بر راهنماهای ذخیره‌شده در حوزه دیگر تأثیر نمی‌گذارد.

مثال زیر راهنماهای نمای اسلاید و تمام راهنماهای موجود بر اسلایدهای مستر، اسلایدهای طرح‌بندی، مستر یادداشت و مستر جزوه را بدون ایجاد مسترهای گمشده پاک می‌کند:
```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا راهنماهای رسم در نمایش اسلاید یا تصاویر صادرشده ظاهر می‌شوند؟**  
خیر. راهنماهای رسم ابزارهای هم‌راستایی برای ویرایش هستند و به‌عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک راهنمای رسم را مستقیم به یک اسلاید عادی افزود؟**  
راهنماهای ویرایشی اسلاید عادی در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های راهنمای جداگانه‌ای برای اسلایدهای مستر، اسلایدهای طرح‌بندی، مسترهای یادداشت و مسترهای جزوه موجود است.

**کدام واحدها برای موقعیت راهنماها استفاده می‌شود؟**  
موقعیت‌ها بر حسب نقطه تعیین می‌شوند که ۷۲ نقطه برابر با یک اینچ است. موقعیت‌های عمودی از لبهٔ چپ اندازه‌گیری می‌شوند و موقعیت‌های افقی از لبهٔ بالا.

**آیا پاک‌سازی راهنماهای رسم شکل‌ها را حذف یا محتوای اسلاید را تغییر می‌دهد؟**  
خیر. متد `clear` تنها راهنماهای موجود در مجموعهٔ انتخاب‌شده را حذف می‌کند. شکل‌ها و سایر محتوای اسلاید بی‌تغییری می‌مانند.