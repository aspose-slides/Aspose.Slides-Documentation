---
title: "مدیریت زوم‌ها در ارائه‌ها با پایتون"
linktitle: "زوم"
type: docs
weight: 60
url: /fa/python-net/manage-zoom/
keywords:
  - "زوم"
  - "فریم زوم"
  - "زوم اسلاید"
  - "زوم بخش"
  - "زوم خلاصه"
  - "افزودن زوم"
  - "PowerPoint"
  - "ارائه"
  - "پایتون"
  - "Aspose.Slides"
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای پایتون از طریق .NET — بین بخش‌ها پرش کنید، تصاویر بندانگشتی و انتقال‌ها را در ارائه‌های PPT، PPTX و ODP اضافه کنید."
---
## **معرفی**

زوم‌ها در PowerPoint به شما امکان می‌دهند به اسلایدها، بخش‌ها و قسمت‌های خاصی از ارائه بپرید و از آن‌ها خارج شوید. هنگام ارائه، این قابلیت برای جابجایی سریع در محتوا می‌تواند بسیار مفید باشد. 

![overview](overview.png)

* برای خلاصه‌سازی کل ارائه در یک اسلاید، از [Summary Zoom](#Summary-Zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخابی، از [Slide Zoom](#Slide-Zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از [Section Zoom](#Section-Zoom) استفاده کنید.

## **زوم اسلاید**

یک زوم اسلاید می‌تواند ارائه شما را پویاتر کند و به شما اجازه دهد بین اسلایدها به هر ترتیبی که می‌خواهید حرکت کنید بدون اینکه جریان ارائه‌تان قطع شود. زوم‌های اسلاید برای ارائه‌های کوتاه بدون بخش‌های زیاد عالی هستند، اما می‌توانید آن‌ها را در سناریوهای مختلف نیز به کار ببرید.

زوم‌های اسلاید به شما کمک می‌کنند تا به اطلاعات متعدد دسترسی پیدا کنید در حالی که حس می‌کنید روی یک بوم واحد کار می‌کنید. 

![slidezoomsel](slidezoomsel.png)

برای اشیای زوم اسلاید، Aspose.Slides فراخوانی‌های [ZoomImageType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/zoomimagetype/) ، [ZoomFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/zoomframe/) و برخی متدها در کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) را ارائه می‌دهد.

### **ایجاد فریم‌های زوم**
می‌توانید یک فریم زوم را به این شکل به اسلاید اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی که قصد لینک کردن به آن‌ها را دارید ایجاد کنید. 
3. متن شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. فریم‌های زوم (حاوی ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد نمونه نشان می‌دهد چگونه یک فریم زوم را در اسلاید ایجاد کنید:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #اسلایدهای جدید را به ارائه اضافه کنید
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # پس‌زمینه‌ای برای اسلاید دوم ایجاد کنید
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # یک جعبه متن برای اسلاید دوم ایجاد کنید
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # پس‌زمینه‌ای برای اسلاید سوم ایجاد کنید
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # یک جعبه متن برای اسلاید سوم ایجاد کنید
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #اشیای ZoomFrame را اضافه کنید
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # ارائه را ذخیره کنید
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **ایجاد فریم‌های زوم با تصاویر سفارشی**
با Aspose.Slides for Python via .NET می‌توانید فریم زومی با تصویر متفاوت از تصویر پیش‌نمایش اسلاید به این شکل ایجاد کنید: 
1. یک نمونه از کلاس `Presentation` ایجاد کنید.
2. اسلاید جدیدی که قصد لینک کردن به آن را دارید ایجاد کنید. 
3. متن شناسایی و پس‌زمینه‌ای به اسلاید ایجاد شده اضافه کنید.
4. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) با اضافه کردن یک تصویر به مجموعه Images مرتبط با شیء Presentation ایجاد کنید تا فریم را پر کند.
5. فریم‌های زوم (حاوی ارجاع به اسلاید ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد پایتون نشان می‌دهد چگونه یک فریم زوم با تصویر متفاوت ایجاد کنید:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #یک اسلاید جدید به ارائه اضافه کنید
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # پس‌زمینه‌ای برای اسلاید دوم ایجاد کنید
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # یک جعبه متن برای اسلاید سوم ایجاد کنید
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # یک تصویر جدید برای شیء زوم ایجاد کنید
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # اشیای ZoomFrame را اضافه کنید
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # ارائه را ذخیره کنید
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **قالب‌بندی فریم‌های زوم**
در بخش‌های قبلی (بالا) به شما نشان دادیم چگونه فریم‌های زوم ساده ایجاد کنید. برای ساخت فریم‌های زوم پیچیده‌تر، باید قالب‌بندی فریم‌ها را تغییر دهید. تنظیمات قالب‌بندی متعددی می‌توانید بر یک فریم زوم اعمال کنید. 

می‌توانید قالب‌بندی یک فریم زوم در اسلاید را به این شکل کنترل کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.
2. اسلایدهای جدیدی برای لینک کردن ایجاد کنید.
3. متن شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. فریم‌های زوم (حاوی ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) با اضافه کردن یک تصویر به مجموعه Images مرتبط با شیء Presentation ایجاد کنید تا فریم را پر کند.
6. تصویر سفارشی را برای اولین شیء فریم زوم تنظیم کنید.
7. قالب خط را برای شیء فریم زوم دوم تغییر دهید.
8. پس‌زمینهٔ تصویر شیء فریم زوم دوم را حذف کنید.
5. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این نمونه کد پایتون نشان می‌دهد چگونه قالب‌بندی یک فریم زوم را تغییر دهید: 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #اسلایدهای جدید را به ارائه اضافه کنید
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # پس‌زمینه‌ای برای اسلاید دوم ایجاد کنید
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # یک جعبه متن برای اسلاید دوم ایجاد کنید
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # پس‌زمینه‌ای برای اسلاید سوم ایجاد کنید
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # یک جعبه متن برای اسلاید سوم ایجاد کنید
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #اشیای ZoomFrame را اضافه کنید
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # یک تصویر جدید برای شیء زوم ایجاد کنید
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # تصویر سفارشی را برای شیء zoomFrame1 تنظیم کنید
    zoomFrame1.image = image

    # قالب فریم زوم را برای شیء zoomFrame2 تنظیم کنید
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # پس‌زمینه برای شیء zoomFrame2 نمایش داده نشود
    zoomFrame2.show_background = False

    # ارائه را ذخیره کنید
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **زوم بخش**

یک زوم بخش لینک به یک بخش در ارائهٔ شماست. می‌توانید از زوم‌های بخش برای بازگشت به بخش‌هایی استفاده کنید که می‌خواهید به‌طور ویژه تأکید کنید. یا می‌توانید از آن‌ها برای نشان دادن چگونگی ارتباط بخش‌های مختلف ارائه استفاده کنید. 

![seczoomsel](seczoomsel.png)

برای اشیای زوم بخش، Aspose.Slides کلاس [SectionZoomFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectionzoomframe/) و برخی متدها را تحت کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) ارائه می‌دهد.

### **ایجاد فریم‌های زوم بخش**

می‌توانید یک فریم زوم بخش را به اسلاید اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید. 
3. پس‌زمینهٔ شناسایی را به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید که قصد لینک کردن فریم زوم به آن را دارید ایجاد کنید. 
5. فریم زوم بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد پایتون نشان می‌دهد چگونه یک فریم زوم را بر اسلاید ایجاد کنید:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # یک بخش جدید به ارائه اضافه می‌کند
    pres.sections.add_section("Section 1", slide)

    # یک شیء SectionZoomFrame اضافه می‌کند
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **ایجاد فریم‌های زوم بخش با تصاویر سفارشی**

با استفاده از Aspose.Slides for Python می‌توانید فریم زوم بخشی با تصویر پیش‌نمایش متفاوتی از اسلاید ایجاد کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. پس‌زمینهٔ شناسایی را به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید که قصد لینک کردن فریم زوم به آن را دارید ایجاد کنید. 
5. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) با اضافه کردن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید تا فریم را پر کند.
6. فریم زوم بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
7. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد پایتون نشان می‌دهد چگونه فریم زوم با تصویر متفاوتی ایجاد کنید:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # یک بخش جدید به ارائه اضافه می‌کند
    pres.sections.add_section("Section 1", slide)

    # یک تصویر جدید برای شیء زوم ایجاد می‌کند
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # یک شیء SectionZoomFrame اضافه می‌کند
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **قالب‌بندی فریم‌های زوم بخش**

برای ساخت فریم‌های زوم بخش پیچیده‌تر باید قالب‌بندی فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر فریم زوم بخش اعمال کنید. 

می‌توانید قالب‌بندی فریم زوم بخش را بر اسلاید به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. پس‌زمینهٔ شناسایی را به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید که قصد لینک کردن فریم زوم به آن را دارید ایجاد کنید. 
5. فریم زوم بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. اندازه و موقعیت شیء زوم بخش ایجاد شده را تغییر دهید.
7. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) با اضافه کردن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید تا فریم را پر کند.
8. تصویر سفارشی را برای شیء فریم زوم بخش ایجاد شده تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش لینک شده* را تنظیم کنید. 
10. پس‌زمینهٔ تصویر شیء فریم زوم بخش را حذف کنید.
11. قالب خط را برای شیء فریم زوم دوم تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد پایتون نشان می‌دهد چگونه قالب‌بندی فریم زوم بخش را تغییر دهید:

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # یک بخش جدید به ارائه اضافه می‌کند
    pres.sections.add_section("Section 1", slide)

    # افزودن شیء SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # قالب‌بندی برای SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **زوم خلاصه**

یک زوم خلاصه مانند یک صفحهٔ فرود است که تمام بخش‌های ارائهٔ شما به‌طور همزمان نمایش داده می‌شوند. هنگام ارائه می‌توانید از زوم برای رفتن از یک نقطه به نقطه دیگری در هر ترتیبی که می‌خواهید استفاده کنید. می‌توانید خلاق باشید، جلو بپرید یا بخش‌های مختلف اسلایدشو را بدون قطع جریان ارائه‌تان بازبینی کنید.

![overview_image](summaryzoom.png)

برای اشیای زوم خلاصه، Aspose.Slides کلاس‌های [SummaryZoomFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/summaryzoomframe/) ، [SummaryZoomSection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/summaryzoomsection/) و [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/summaryzoomsectioncollection/) و برخی متدها تحت کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) ارائه می‌دهد.

### **ایجاد زوم خلاصه**

می‌توانید فریم زوم خلاصه را به اسلاید اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم زوم خلاصه را به اسلاید اول اضافه کنید.
4. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد پایتون نشان می‌دهد چگونه یک فریم زوم خلاصه را بر اسلاید ایجاد کنید:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # ایجاد آرایه اسلایدها
    for slideNumber in range(5):
        # اسلایدهای جدید را به ارائه اضافه کنید
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # پس‌زمینه‌ای برای اسلاید ایجاد کنید
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # یک جعبه متن برای اسلاید ایجاد کنید
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # ایجاد اشیای زوم برای تمام اسلایدها در اسلاید اول
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # ویژگی ReturnToParent را برای بازگشت به اسلاید اول تنظیم کنید
        zoomFrame.return_to_parent = True

    # ارائه را ذخیره کنید
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **افزودن و حذف بخش زوم خلاصه**

تمام بخش‌های یک فریم زوم خلاصه توسط اشیای [SummaryZoomSection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/summaryzoomsection/) نمایندگی می‌شوند که در شیء [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/summaryzoomsectioncollection/) ذخیره می‌شوند. می‌توانید یک شیء بخش زوم خلاصه را از طریق کلاس [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/summaryzoomsectioncollection/) به این شکل اضافه یا حذف کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم زوم خلاصه را به اسلاید اول اضافه کنید.
4. اسلاید و بخش جدیدی به ارائه اضافه کنید.
5. بخش ایجاد شده را به فریم زوم خلاصه اضافه کنید.
6. اولین بخش را از فریم زوم خلاصه حذف کنید.
7. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد پایتون نشان می‌دهد چگونه بخش‌ها را در فریم زوم خلاصه اضافه و حذف کنید:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # یک بخش جدید به ارائه اضافه می‌کند
    pres.sections.add_section("Section 1", slide)

    #یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # یک بخش جدید به ارائه اضافه می‌کند
    pres.sections.add_section("Section 2", slide)

    # شیء SummaryZoomFrame را اضافه می‌کند
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # یک بخش جدید به ارائه اضافه می‌کند
    section3 = pres.sections.add_section("Section 3", slide)

    # یک بخش به Summary Zoom اضافه می‌کند
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # بخش را از Summary Zoom حذف می‌کند
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **قالب‌بندی بخش‌های زوم خلاصه**

برای ساخت اشیای بخش زوم خلاصهٔ پیچیده‌تر باید قالب‌بندی فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر یک شیء بخش زوم خلاصه اعمال کنید. 

می‌توانید قالب‌بندی یک شیء بخش زوم خلاصه را در یک فریم زوم خلاصه به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم زوم خلاصه را به اسلاید اول اضافه کنید.
4. یک شیء بخش زوم خلاصه را از `SummaryZoomSectionCollection` برای اولین شیء دریافت کنید.
5. یک شیء `PPImage` با اضافه کردن یک تصویر به مجموعهٔ images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید تا فریم را پر کند.
6. تصویر سفارشی را برای شیء فریم زوم بخش ایجاد شده تنظیم کنید.
7. قابلیت *بازگشت به اسلاید اصلی از بخش لینک شده* را تنظیم کنید. 
8. قالب خط را برای شیء فریم زوم دوم تغییر دهید.
9. مدت زمان انتقال را تغییر دهید.
10. ارائهٔ تغییر یافته را به عنوان فایل PPTX نوشتن.

این کد پایتون نشان می‌دهد چگونه قالب‌بندی یک شیء بخش زوم خلاصه را تغییر دهید:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #اسلاید جدیدی به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # یک بخش جدید به ارائه اضافه می‌کند
    pres.sections.add_section("Section 1", slide)

    #اسلاید جدیدی به ارائه اضافه می‌کند
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # یک بخش جدید به ارائه اضافه می‌کند
    pres.sections.add_section("Section 2", slide)

    # یک شیء SummaryZoomFrame اضافه می‌کند
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # اولین شیء SummaryZoomSection را دریافت می‌کند
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # قالب‌بندی برای شیء SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا می‌توانم کنترل کنم که پس از نمایش هدف به اسلاید «والد» بازگردم؟**

بله. فریم [Zoom](https://reference.aspose.com/slides/fa/python-net/aspose.slides/zoomframe/) یا [section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectionzoomframe/) دارای رفتار `return_to_parent` است که وقتی فعال باشد، بازدیدکنندگان را پس از بازدید از محتوا هدف به اسلاید مبدأ بازمی‌گرداند.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال زوم را تنظیم کنم؟**

بله. زوم از تنظیم `transition_duration` پشتیبانی می‌کند تا بتوانید مدت زمان انیمیشن جهش را کنترل کنید.

**آیا محدودیتی برای تعداد اشیای زوم در یک ارائه وجود دارد؟**

هیچ محدودیت سخت‌گیرانه‌ای در API مستند نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد دستگاه کاربر بستگی دارد. می‌توانید فریم‌های زوم زیادی اضافه کنید، اما به حجم فایل و زمان رندرینگ فکر کنید.