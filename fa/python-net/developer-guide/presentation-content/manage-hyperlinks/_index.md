---
title: مدیریت پیوندهای ابرمتن ارائه در پایتون
linktitle: مدیریت پیوندهای ابرمتن
type: docs
weight: 20
url: /fa/python-net/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند ابرمتن
- ایجاد پیوند ابرمتن
- قالب‌بندی پیوند ابرمتن
- حذف پیوند ابرمتن
- به‌روزرسانی پیوند ابرمتن
- پیوند ابرمتن متن
- پیوند ابرمتن اسلاید
- پیوند ابرمتن شکل
- پیوند ابرمتن تصویر
- پیوند ابرمتن ویدئو
- پیوند ابرمتن قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف پیوندهای ابرمتن در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET، با استفاده از مثال‌های پایتون."
---
## **مقدمه**

یک پیوند ابرمتن محتویات ارائه را به یک وب‌سایت یا یک مکان درون ارائه متصل می‌کند. در PowerPoint، پیوندهای ابرمتن معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از طریق متن، یک شکل یا یک فریم رسانه‌ای.
* ناوبری به اسلاید دیگری، برای مثال از فهرست مطالب.

Aspose.Slides for Python via .NET به شما امکان می‌دهد این پیوندها را اضافه، ظاهر و صدای آن‌ها را کنترل، ویژگی‌هایشان را به‌روز کنید و حذف نمایید. مثال‌های زیر نشان می‌دهند چگونه با پیوندهای ابرمتن در عناصر فردی کار کنید و چگونه به پیوندهای ابرمتن در سطح ارائه، اسلاید یا فریم‑متن دسترسی داشته باشید.

{{% alert color="info" title="Note" %}}
شما می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/fa/editor) ویرایش کنید.
{{% /alert %}}

## **افزودن پیوندهای ابرمتن URL**

شما می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک فریم رسانه‌ای اختصاص دهید. عنصری که به آن پیوند ابرمتن اختصاص می‌دهید، ناحیه کلیک‌پذیر را تعیین می‌کند: بخش متنی پیوند را به متن انتخابی متصل می‌کند، در حالی که یک شکل یا فریم پیوند را به شیء اسلاید متصل می‌کند.

### **افزودن پیوندهای ابرمتن URL به متن**

برای پیوند دادن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/) به ویژگی [hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/hyperlink_click/) بخش متن اختصاص دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن کلیک‌پذیر می‌شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **افزودن پیوندهای ابرمتن URL به اشکال و فریم‌های رسانه‌ای**

برای قابل کلیک کردن کردن یک شکل یا فریم، ویژگی [hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/hyperlink_click/) آن را تنظیم کنید. پیوند ابرمتن به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

رویکرد مشابه برای فریم‌های تصویر، صدا و ویدئو نیز صادق است: پیوند را به فریم اختصاص دهید و در صورت نیاز ویژگی [tooltip](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/tooltip/) پیوند را تنظیم کنید.

مثال زیر یک مستطیل را کلیک‌پذیر می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از پیوندهای ابرمتن برای ایجاد فهرست مطالب**

پیوندهای ابرمتن داخلی به خوانندگان امکان می‌دهد از فهرست مطالب به اسلاید خاصی بپرند. مثال زیر از متد [set_internal_hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) برای پیوند دادن متن «صفحه ۲» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **قالب‌بندی پیوندهای ابرمتن**

### **رنگ**

ویژگی [color_source](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/color_source/) از [Hyperlink](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/) تعیین می‌کند که آیا پیوند ابرمتن از رنگ پیوند ابرمتن ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال یک رنگ متن سفارشی، مقدار [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شده است؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند ابرمتن متنی را به همان اسلاید اضافه می‌کند. اولین پیوند از پر رنگ قرمز استفاده می‌کند، در حالی که دومین پیوند رنگ پیش‌فرض پیوند ابرمتن را حفظ می‌کند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **صدا**

یک پیوند ابرمتن می‌تواند هنگام فعال‌سازی صدایی پخش کند یا صدایی که قبلاً در حال پخش است متوقف نماید. از ویژگی‌های زیر برای پیکربندی این رفتارها استفاده کنید:

- [Hyperlink.sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/sound/) صدای مرتبط با پیوند ابرمتن را مشخص می‌کند.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/stop_sound_on_click/) کنترل می‌کند که آیا فعال‌سازی پیوند، صدای قبلی را متوقف می‌کند یا نه.

#### **افزودن صدا به پیوند ابرمتن**

مثال زیر فایل `sampleaudio.wav` را بارگذاری می‌کند و آن را به یک دکمه در اسلاید اول نسبت می‌دهد. کلیک روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌برد. یک شکل دوم در همان اسلاید، هنگام کلیک صدای قبلی را متوقف می‌کند بدون اینکه عمل ناوبری انجام دهد.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **استخراج صدا از پیوند ابرمتن**

مثال زیر ارائه‌ای که در بالا ایجاد شد را باز می‌کند و صدای پیوند ابرمتن اولین شکل را از طریق ویژگی‌های [sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/sound/) و [binary_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audio/binary_data/) به حافظه می‌خواند.

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **راهنما (Tooltip) و تنظیمات تعامل**

پس از اختصاص پیوند ابرمتن به متن یا شکل، می‌توانید ویژگی‌های زیر را به‌روزرسانی کنید:

- [tooltip](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/tooltip/) متنی که بیننده می‌تواند به عنوان راهنمایی برای لینک نمایش دهد.
- [target_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/target_frame/) چارچوب هدف را در یک فریم‌ست HTML والد، در صورت اعمال، مشخص می‌کند.
- [history](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/history/) تعیین می‌کند که آیا فعال‌سازی لینک مقصد را به فهرست پیوندهای بازدیدشده اضافه کند یا نه.
- [highlight_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/highlight_click/) کنترل می‌کند که آیا پیوند ابرمتن هنگام کلیک برجسته شود یا نه.

## **حذف پیوندهای ابرمتن از ارائه‌ها**

از متد [get_any_hyperlinks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) برای جمع‌آوری مخازن پیوند، از جمله پیوندهای بخش متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط متد [remove_hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) یا [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) را فراخوانی کنید؛ حذف عمل کلیک، عمل موس‑اور مربوطه را حذف نمی‌کند.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

برای حذف بدون شرط، متد [remove_all_hyperlinks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش دادن به مسترها، طرح‌بندی‌ها و یادداشت‌ها، به بخش [گزارش، پالایش و تأیید پیوندهای ابرمتن](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت موجودی کامل پیوندهای ابرمتن**

پیش از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. متد [get_any_hyperlinks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) اشیای [IHyperlinkContainer](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه یک لیست تخت از رشته‌های URL. هر مخزن را هم برای [hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) و هم برای [hyperlink_mouse_over](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) بررسی کنید. این دو مستقل‌اند: یک مخزن می‌تواند هر دو عمل را ارائه دهد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر مخزن نیاز داشته باشد.

اسکن تنها پیوندهای سطح شکل می‌تواند لینک‌های پیوست به بخش‌های متنی را از دست بدهد. به جای آن، محدوده مناسب را پرس‌وجو کنید و مخازن بازگشتی را نگه دارید تا بعدها بتوانید اقداماتشان را به‌روزرسانی یا حذف کنید.

### **پرس‌وجوی محدوده‌های ارائه، اسلاید و فریم‑متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/) از طریق [Presentation.hyperlink_queries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/hyperlink_queries/)، [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/hyperlink_queries/) و [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/hyperlink_queries/) در دسترس است. هر محدوده همان پرس‌وجوها را پشتیبانی می‌کند:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) مخازن با عمل کلیک را برمی‌گرداند.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) مخازن با عمل موس‑اور را برمی‌گرداند.
- [get_any_hyperlinks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) مخازن با هر یک یا هر دو عمل را برمی‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک موس‑اور فایل، ناوبری داخلی اسلاید، یک لینک موس‑اور متنی و یک عمل ماکرو است. هیچ‌کدام از این اعمال اجرا نمی‌شوند. همان سه پرس‌وجو در هر محدوده کار می‌کند؛ شمارش‌ها تعداد مخازن را نشان می‌دهند، نه مجموع اعمال. محدوده فریم‑متن پیوندهای خود شکل محاط‌کننده را مستثنی می‌کند.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

در این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه مخزن کلیک، دو مخزن موس‑اور و سه مخزن دارای هر یک از اعمال را گزارش می‌کنند. پرس‌وجو فریم‑متن در هر دسته یک مخزن را نشان می‌دهد.

### **دسته‌بندی اعمال و مقاصد**

از ویژگی [Hyperlink.action_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/action_type/) برای تفسیر یک عمل پیش از بررسی مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب شامل می‌شوند:

| مقادیر | معنی برای ممیزی |
| --- | --- |
| `HYPERLINK` | پیوند ابرمتن خارجی؛ URL و طرح‌واره آن را بررسی کنید. |
| `JUMP_SPECIFIC_SLIDE` | ناوبری داخلی به اسلاید خاص. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | ناوبری داخلی پیش‌ساخته اسلایدشوی، در زمینه اسلایدشو مفهومی می‌شود. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | پایان نمایش جاری یا آغاز یک نمایش سفارشی. |
| `START_MACRO` | اجرای یک ماکرو. |
| `START_PROGRAM` | راه‌اندازی یک برنامه. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | باز کردن فایل یا ارائه دیگر؛ جداگانه از URLهای وب بررسی کنید. |
| `START_STOP_MEDIA` | شروع یا توقف پخش رسانه. |
| `NO_ACTION`, `UNKNOWN` | بدون عمل ناوبری، یا عملی ناشناخته که نیاز به بررسی دارد. |

مقاصد خارجی را از طریق [external_url](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/external_url/) و مقاصد داخلی خاص را از طریق [target_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/target_slide/) بخوانید. اعمال داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنی نیست که مخزن هیچ عملی ندارد. هنگامی که [external_url_original](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/external_url_original/) با URL نرمال‌شده متفاوت است، آن را حفظ کنید و در صورت موجود بودن [tooltip](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlink/tooltip/) را نیز درج کنید.

### **گزارش، پالایش و تأیید پیوندهای ابرمتن**

مثال زیر به زبان Python یک ارائه موجود (فایل ایجادشده در بالا) را می‌خواند، `hyperlink-audit.json` می‌نویسد، سیاستی اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را دوباره بررسی کند. قبل از تغییر مخازن، آن‌ها را جمع‌آوری می‌کند و هر بار یک بار محدوده اسلاید را پرس‌وجو می‌کند تا از پردازش تکراری جلوگیری شود. پرس‌وجوهای ارائه اسلایدهای معمولی را پوشش می‌دهند؛ برای موجودی سراسری بسته، مثال اسلایدهای معمولی، مسترها، طرح‌بندی‌ها، یادداشت‌ها و مسترهای یادداشت و برگه‌برداری را (در صورت وجود) نیز پرس‌وجو می‌کند.

گزارش، اندیس اسلاید مبتنی بر یک‑پایه و [slide_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/slide_id/) را که در دسترس باشد، ثبت می‌کند. جمع‌کننده اسلاید مالک و محدوده را همراه هر مخزن بازگردانده نگه می‌دارد. مسترها، طرح‌بندی‌ها و یادداشت‌ها اندیس اسلاید معمولی ندارند و با محدوده‌شان شناسایی می‌شوند. مخازن شکل و مخازن قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع مخازن نام نوع زمان اجرا خود را حفظ می‌کنند. هر مخزن یک شناسه گزارش‑محلی دریافت می‌کند تا دو عمل آن بتوانند هم‌پوشانی داشته باشند.

این سیاست کاربردی محدودکننده فقط URLهای HTTPS مطلق و هدف‌های داخلی معتبر اسلاید را می‌پذیرد. ماکروها، برنامه‌ها، عمل‌های فایلی، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح‌واره‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه قضاوت ایمنی Aspose.Slides. HTTPS به‌تنهایی اعتماد را تضمین نمی‌کند: برای برنامه خود لیست‌های سفید میزبان و بررسی‌های دیگر اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال، متادیتا را بدون دنبال کردن لینک‌ها یا اجرای اعمال ممیزی می‌کند.

برای رفع نقص، [hyperlink_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) مخزن، متدهای [set_external_hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)، [remove_hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) و [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) را پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع به یک صفحه لندینگ HTTPS ثابت تبدیل می‌شوند؛ سایر کلیک‌های ممنوع و عمل‌های موس‑اور ممنوع به‌ صورت مستقل حذف می‌شوند. برای حذف تمام تخلفات سیاست، مقدار `replace_external_clicks` را روی `False` بگذارید. پیش از انتشار، صفحه جایگزین متعلق به برنامه را انتخاب کنید.

پرچم خروجی گزارش یک سیاست بررسی PDF محتاطانه را استفاده می‌کند: عمل‌های موس‑اور و هر چیزی غیر از یک لینک خارجی یا پرش اسلاید خاص را به‌عنوان احتمالا ناهمگام پرچم می‌گذارد. این یک نکته بازبینی است، نه تست قابلیت یا تضمین این‌که لینک‌های بدون پرچم در خروجی باقی می‌مانند. خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندهای ابرمتن را حفظ کنند، بسته به عمل، گزینه‌های خروجی و مرورگر. تصویرهای رستری و ویدئوهای رستری نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام ممیزی برای این خروجی‌ها هر عمل را پرچم بزنید.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # هر محدوده اسلاید را یک بار جست‌وجو کنید و مالک آن را همراه هر مخزن حفظ کنید.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

با ورودی ایجادشده در بالا، گزارش شامل پنج ردیف عمل می‌شود. لینک موس‑اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید نشان می‌دهد صفر عمل ممنوع وجود دارد. ورودی شامل یک URL کلیک خارجی ممنوع نیز مسیر جایگزینی را اجرا می‌کند. مخزنی با کلیک مجاز و موس‑اور ممنوع کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی متفاوت از [remove_all_hyperlinks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) است که هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده بدون توجه به سیاست حذف می‌کند. تأیید اینجا فقط اعمال پیوند ابرمتن را بررسی می‌کند؛ پروژه‌های VBA توکار، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و هیچ‌گونه اعتبارسنجی برای فایل PDF یا HTML خروجی انجام نمی‌دهد.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک دهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند ابرمتن داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک دهید.

**آیا می‌توانم پیوند ابرمتن را به عناصر مستر اسلاید اضافه کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و طرح‌بندی از پیوندهای ابرمتن پشتیبانی می‌کنند. این لینک‌ها در طول نمایش اسلاید برای اسلایدهایی که از مستر یا طرح‌بندی مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندهای ابرمتن هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های PDF و HTML که پشتیبانی می‌شوند ممکن است پیوندهای ابرمتن را حفظ کنند؛ تصاویر رستری و ویدئوها نمی‌توانند این پیوندها را نگه دارند. برای جزئیات بیشتر به بخش [گزارش، پالایش و تأیید پیوندهای ابرمتن](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.