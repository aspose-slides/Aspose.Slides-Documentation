---
title: مدیریت پیوندها در ارائه‌ها با Python
linktitle: مدیریت پیوند
type: docs
weight: 20
url: /fa/python-net/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- به‌روز رسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدئو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Python
description: "به‌سادگی پیوندها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET—تعامل و روند کار را در چند دقیقه ارتقا دهید."
---
## **مقدمه**

یک پیوند یکتا (Hyperlink) ارجاعی به منبع خارجی، یک شیء یا مورد داده‌ای یا مکان خاصی درون یک فایل است. انواع رایج پیوندها در ارائه‌های PowerPoint شامل:

* پیوندها به وب‌سایت‌ها که در متن، اشکال یا رسانه‌ها جاسازی شده‌اند
* پیوندها به اسلایدها

Aspose.Slides برای Python از طریق .NET امکان انجام دامنه وسیعی از عملیات مرتبط با پیوندها را در ارائه‌ها فراهم می‌کند.

## **افزودن پیوندهای URL**

این بخش توضیح می‌دهد چگونه پیوندهای URL را به عناصر اسلاید هنگام کار با Aspose.Slides اضافه کنید. این شامل اختصاص آدرس‌های پیوند به متن، اشکال و تصاویر برای اطمینان از ناوبری روان در طول ارائه‌ها است.

### **افزودن پیوندهای URL به متن**

مثال کد زیر نشان می‌دهد چگونه یک پیوند وب‌سایت به متن اضافه شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **افزودن پیوندهای URL به اشکال یا فریم‌ها**

مثال کد زیر نشان می‌دهد چگونه یک پیوند وب‌سایت به یک شکل اضافه شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **افزودن پیوندهای URL به رسانه‌ها**

Aspose.Slides به شما اجازه می‌دهد پیوندهایی به تصاویر، فایل‌های صوتی و ویدئویی اضافه کنید.

مثال کد زیر نشان می‌دهد چگونه یک پیوند به **تصویر** اضافه شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # افزودن یک تصویر به ارائه.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # ایجاد یک فریم تصویر در اسلاید 1 با استفاده از تصویر اضافه شده قبلاً.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

مثال کد زیر نشان می‌دهد چگونه یک پیوند به **فایل صوتی** اضافه شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

مثال کد زیر نشان می‌دهد چگونه یک پیوند به **ویدئو** اضافه شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
ممکن است مایل باشید تا [Manage OLE in Presentations Using Python](/slides/fa/python-net/manage-ole/) را ببینید.
{{% /alert %}}

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

از آنجا که پیوندها امکان ارجاع به اشیاء یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ساخت فهرست مطالب استفاده کنید.

کد نمونه زیر نشان می‌دهد چگونه یک فهرست مطالب با پیوندها ایجاد شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **قالب‌بندی پیوندها**

این بخش نشان می‌دهد چگونه ظاهر پیوندها را در Aspose.Slides قالب‌بندی کنید. شما یاد می‌گیرید رنگ و گزینه‌های سبک دیگر را کنترل کنید تا قالب‌بندی پیوندها در متن، اشکال و تصاویر یکسان بماند.

### **رنگ پیوند**

با استفاده از ویژگی [color_source](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/color_source/) کلاس [Hyperlink](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/) می‌توانید رنگ پیوند را تنظیم کنید و اطلاعات رنگ آن را بخوانید. این ویژگی در PowerPoint 2019 معرفی شد، بنابراین تغییرات انجام‌شده از طریق این ویژگی به نسخه‌های قبلی PowerPoint اعمال نمی‌شود.

نمونه زیر نشان می‌دهد چگونه پیوندهایی با رنگ‌های مختلف به همان اسلاید اضافه شوند:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف پیوندها از ارائه‌ها**

این بخش توضیح می‌دهد چگونه پیوندها را از ارائه‌ها هنگام کار با Aspose.Slides حذف کنید. شما یاد می‌گیرید چگونه اهداف پیوندها را از متن، اشکال و تصاویر پاک کنید در حالی که محتوای اصلی و قالب‌بندی حفظ می‌شود.

### **حذف پیوندها از متن**

کد نمونه زیر نشان می‌دهد چگونه پیوندها را از متن یک اسلاید ارائه حذف کنید:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف پیوندها از اشکال یا فریم‌ها**

کد نمونه زیر نشان می‌دهد چگونه پیوندها را از اشکال یک اسلاید ارائه حذف کنید:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **پیوندهای قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/) قابل تغییر است. با استفاده از این کلاس می‌توانید مقادیر این ویژگی‌ها را تغییر دهید:

- [target_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

کد زیر نشان می‌دهد چگونه یک پیوند به اسلاید اضافه کنید و سپس tooltip آن را ویرایش کنید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ویژگی‌های پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/) را از ارائه، اسلاید یا متنی که پیوند را شامل می‌شود دسترسی پیدا کنید.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/hyperlink_queries/)

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/) این متدها را پشتیبانی می‌کند:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
ممکن است بخواهید ویرایشگر ساده و رایگان آنلاین [PowerPoint editor](https://products.aspose.app/slides/fa/editor) Aspose را بررسی کنید.
{{% /alert %}}

## **سوالات متداول**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید، بلکه به یک «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروهی از اسلایدها هستند؛ ناوبری از نظر فنی به یک اسلاید خاص اشاره دارد. برای «رفتن به یک بخش» معمولاً به اولین اسلاید آن بخش پیوند می‌زنید.

**آیا می‌توانم پیوند را به عناصر اسلاید اصلی (master) الصاق کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید اصلی و طرح‌بندی از پیوندها پشتیبانی می‌کنند. این پیوندها در اسلایدهای فرزند ظاهر می‌شوند و در حین نمایش اسلاید قابل کلیک هستند.

**آیا پیوندها هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/python-net/convert-powerpoint-to-html/) بله—پیوندها به‌طور کلی حفظ می‌شوند. هنگام خروجی به [images](/slides/fa/python-net/convert-powerpoint-to-png/) و [video](/slides/fa/python-net/convert-powerpoint-to-video/) قابلیت کلیک کردن منتقل نمی‌شود چرا که این فرمت‌ها (فریم‌های رستری/ویدئو) از پیوندها پشتیبانی نمی‌کنند.