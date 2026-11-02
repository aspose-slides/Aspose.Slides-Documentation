---
title: مدیریت پیوندهای ارائه در پایتون
linktitle: مدیریت پیوندها
type: docs
weight: 20
url: /fa/python-net/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- به‌روزرسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدیو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "پیوندها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET اضافه، قالب‌بندی، به‌روزرسانی و حذف کنید، با استفاده از مثال‌های پایتون."
---
## **مقدمه**

یک پیوند (hyperlink) محتوای ارائه را به یک وب‌سایت یا مکان داخل ارائه متصل می‌کند. در PowerPoint، پیوندها معمولاً دو هدف را دنبال می‌کنند:

* باز کردن یک وب‌سایت از متن، شکل یا قاب رسانه‌ای.
* ناوبری به اسلاید دیگری، برای مثال از فهرست مطالب.

Aspose.Slides for Python via .NET به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آنها را کنترل کنید، ویژگی‌هایشان را به‌روزرسانی کنید و حذف نمایید. مثال‌های زیر نشان می‌دهند چگونه با پیوندها بر روی عناصر منفرد کار کنید و چگونه به پیوندها در سطح ارائه، اسلاید یا فریم متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
می‌توانید همچنین ارائه‌ها را با [ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}}

## **افزودن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، شکل یا قاب رسانه‌ای اختصاص دهید. عنصری که پیوند به آن اختصاص می‌یابد، ناحیه قابل کلیک را تعیین می‌کند: بخشی از متن، متن انتخاب شده را لینک می‌کند، در حالی که یک شکل یا قاب، شیء اسلاید را لینک می‌کند.

برای ارائه‌هایی که حاوی پیوندهای نسبی هستند، به [مدیریت پایه پیوند](/slides/fa/python-net/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایه سطح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) را به ویژگی [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) بخش متن اختصاص دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

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

### **افزودن پیوندهای URL به اشکال و قاب‌های رسانه‌ای**

برای قابل کلیک کردن یک شکل یا قاب، ویژگی [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) آن را تنظیم کنید. پیوند به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

این رویکرد برای قاب‌های تصویر، صدا و ویدیو نیز صدق می‌کند: پیوند را به قاب اختصاص دهید و در صورت نیاز [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) لینک را تنظیم کنید.

مثال زیر یک مستطیل را قابل کلیک می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی پیوندها**

### **رنگ**

ویژگی [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) از [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) تعیین می‌کند که آیا پیوند از رنگ پیوند ارائه یا قالب‌بندی بخشی از متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند متن به همان اسلاید اضافه می‌کند. اولین پیوند از پر کردن متن قرمز استفاده می‌کند، در حالی که دومین پیوند رنگ پیش‌فرض پیوند را حفظ می‌کند.

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

یک پیوند می‌تواند هنگام فعال شدن صدا پخش کند یا صدای در حال پخش را متوقف کند. برای پیکربندی این رفتارها از ویژگی‌های زیر استفاده کنید:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) صدا را که با پیوند مرتبط است مشخص می‌کند.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) کنترل می‌کند که آیا فعال‌سازی پیوند صدای قبلی را متوقف می‌کند یا خیر.

#### **افزودن صدای پیوند**

مثال زیر فایل `sampleaudio.wav` را بارگذاری می‌کند و آن را به دکمه‌ای در اسلاید اول مرتبط می‌سازد. کلیک روی دکمه صدای موردنظر را پخش می‌کند و به اسلاید بعدی می‌رود. شکل دوم در همان اسلاید هنگام کلیک، صدای قبلی را متوقف می‌کند بدون اینکه عمل ناوبری انجام دهد.

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

#### **استخراج صدای پیوند**

مثال زیر ارائه‌ای که در بالا ساخته شد را باز می‌کند و صدای پیوند اولین شکل را از طریق [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) و [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) به حافظه می‌خواند.

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

### **نکات راهنما و تنظیمات تعامل**

پس از اختصاص پیوند به متن یا یک شکل، می‌توانید ویژگی‌های زیر را در [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) به‌روز کنید:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) متن راهنمایی را که بیننده می‌تواند به‌عنوان نکته برای لینک نشان دهد تنظیم می‌کند.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) قاب هدف را درون یک چارچوب HTML والد، در صورت امکان، مشخص می‌کند.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) کنترل می‌کند که آیا فعال‌سازی لینک مقصد را به لیست پیوندهای مشاهده‌شده اضافه می‌کند یا خیر.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) کنترل می‌کند که آیا پس از کلیک پیوند برجسته می‌شود یا نه.

## **حذف پیوندها از ارائه‌ها**

از [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) برای جمع‌آوری کانتینرهای پیوند، شامل پیوندهای بخش متن، قبل از تغییر آنها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف فقط یک نوع، تنها [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) یا [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) را فراخوانی کنید؛ حذف عمل کلیک، معادل حذف عمل موس‌اور نیست.

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

برای حذف بدون شرط، [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) هر دو نوع فعال‌سازی را در حوزه انتخابی در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لایه‌ها و یادداشت‌ها، به [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت فهرست کامل پیوندها**

قبل از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) اشیای [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه فهرست ساده‌ای از رشته‌های URL. هر دو [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) و [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) را در هر کانتینر بررسی کنید. آنها مستقل هستند: همان کانتینر می‌تواند هر دو عمل را نشان دهد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر کانتینر نیاز داشته باشد.

اسکن تنها پیوندهای سطح شکل ممکن است پیوندهای پیوست‌شده به بخش‌های متن را از دست بدهد. به جای آن، دامنه مناسب را پرس و جو کنید و کانتینرهای برگردانده‌شده را نگه دارید تا بعداً بتوانید اعمال آنها را به‌روزرسانی یا حذف کنید.

### **پرس‌وجوی دامنه‌های ارائه، اسلاید و فریم متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) از طریق [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)، [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) و [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) در دسترس است. هر دامنه همان پرس‌وجوها را پشتیبانی می‌کند:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) کانتینرهایی که دارای عمل کلیک هستند برمی‌گرداند.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) کانتینرهایی که دارای عمل موس‌اور هستند برمی‌گرداند.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) کانتینرهایی که یکی یا هر دو عمل را دارند برمی‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک موس‌اور فایل، ناوبری اسلاید داخلی، یک لینک موس‌اور متن و یک عمل ماکرو است. این عمل‌ها اجرا نمی‌شوند. همان سه پرس‌وجو در هر دامنه کار می‌کند؛ شمارش‌ها توصیف‌کننده کانتینرها است نه مجموع اعمال. دامنه فریم متن لینک‌های خود شکل محصور کننده را مستثنی می‌کند.

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

در این مثال، پرس‌وجوهای ارائه و اسلاید هریک سه کانتینر کلیک، دو کانتینر موس‌اور و سه کانتینر با هر یک از اعمال را گزارش می‌کنند. پرس‌وجوی فریم متن یک کانتینر در هر دسته گزارش می‌دهد.

### **دسته‌بندی اقدامات و مقصدها**

از [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) برای تفسیر یک اقدام قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را شامل می‌شوند:

| مقدارها | معنی برای حسابرسی |
| --- | --- |
| `HYPERLINK` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JUMP_SPECIFIC_SLIDE` | ناوبری داخلی به اسلاید خاص. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | ناوبری داخلی پیش‌فرض نمایش اسلاید، در بافت نمایش حل می‌شود. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `START_MACRO` | اجرای یک ماکرو. |
| `START_PROGRAM` | راه‌اندازی یک برنامه. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | باز کردن یک فایل یا ارائه دیگر؛ به‌صورت جداگانه از URLهای وب بررسی کنید. |
| `START_STOP_MEDIA` | شروع یا توقف پخش رسانه. |
| `NO_ACTION`, `UNKNOWN` | بدون اقدام ناوبری، یا اقدام نامشخص که نیاز به بازبینی دارد. |

مقاصد خارجی را از [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) و مقاصد داخلی خاص را از [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/) بخوانید. اقدامات داخلی و دستورات داخلی ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنا نیست که کانتینر اقدام ندارد. وقتی [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) با URL نرمال‌شده متفاوت است، آن را حفظ کنید و هنگام موجود بودن، [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) را نیز شامل شوید.

### **گزارش، پاک‌سازی و تأیید پیوندها**

مثال زیر پایتون یک ارائه موجود را می‌خواند (از فایلی که در بالا ایجاد شد استفاده کنید)، `hyperlink-audit.json` را می‌نویسد، سیاستی را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را بررسی کند. قبل از تغییر، کانتینرها را جمع‌آوری می‌کند و هر دامنه اسلاید را یک بار پرس‌وجو می‌کند تا پردازش تکثیر نشود. پرس‌وجوهای ارائه اسلایدهای عادی را پوشش می‌دهد؛ برای فهرست‌گیری در سرتاسر بسته، مثال اسلایدهای عادی، مسترها، لایه‌ها، یادداشت‌ها و مسترهای یادداشت و توزیع‌کننده را زمانی که موجود باشند، پرس‌وجو می‌کند.

گزارش ایندکس اسلایدی یک‌پایه و [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) (در صورت وجود) را ثبت می‌کند. جمع‌کننده اسلاید مالک و دامنه را همراه هر کانتینر برگردانده نگه می‌دارد. مسترها، لایه‌ها و یادداشت‌ها ایندکس اسلاید عادی ندارند و بر اساس دامنه‌شان شناسایی می‌شوند. کانتینرهای شکل و کانتینرهای قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا خود را حفظ می‌کنند. هر کانتینر یک شناسه محلی گزارش دریافت می‌کند تا دو عمل آن هم‌راستا شوند.

این سیاست برنامه‌نویسی عمدتاً محدود، تنها URLهای مطلق HTTPS و هدف‌های داخلی اسلاید معتبر را اجازه می‌دهد. ماکروها، برنامه‌ها، اقدامات فایلی، سایر اقدامات اسلایدشو، اقدامات ناشناخته و سایر طرح‌های URL را رد می‌کند. این ردها تصمیمات سیاستی هستند، نه قضاوت ایمنی Aspose.Slides. فقط HTTPS به‌تنهایی اعتبار ایجاد نمی‌کند: فهرست‌های مجاز میزبان و سایر بررسی‌ها را برای برنامه‌تان اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال بدون دنبال کردن لینک‌ها یا اجرای اقدامات، متادیتا را حسابرسی می‌کند.

برای رفع مشکل، [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) کانتینر از [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)، [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) و [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه فرود ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و اقدامات موس‌اور ممنوع دیگر به‌طور مستقل حذف می‌شوند. برای حذف تمام تخلفات سیاست، `replace_external_clicks` را به `False` تنظیم کنید. قبل از استقرار، صفحه جایگزین دارایی برنامه را انتخاب کنید.

پرچم صادراتی گزارش از یک سیاست مرور PDF محتاطانه استفاده می‌کند: اعمال موس‌اور و هر چیز غیر از یک لینک خارجی یا پرش اسلاید خاص به‌عنوان ممکن است پشتیبانی نشود پرچم‌گذاری می‌شوند. این یک نکته مرور است، نه آزمون قابلیت یا تضمین اینکه لینک‌های بدون پرچم در صادرات باقی بمانند. صادرات‌های پشتیبانی‌شده [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/python-net/convert-powerpoint-to-html/) ممکن است پیوندها را حفظ کنند، بسته به عمل، گزینه‌های صادرات و مرورگر. [تصاویر](/slides/fa/python-net/convert-powerpoint-to-png/) و [ویدیو](/slides/fa/python-net/convert-powerpoint-to-video/) رستری نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام حسابرسی برای این خروجی‌ها، هر عمل را پرچم‌گذاری کنید.

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
    # هر دامنه اسلاید را یک‌بار پرس‌وجو کنید و مالک آن را برای هر کانتینر حفظ کنید.
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

با ورودی که در بالا ایجاد شد، گزارش شامل پنج ردیف اقدام است. لینک موس‌اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی حاوی یک URL کلیک خارجی ممنوع نیز شاخه جایگزینی را اجرا می‌کند. یک کانتینر با کلیک مجاز و موس‌اور ممنوع عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) متفاوت است که هر دو نوع فعال‌سازی را در تمام حوزه انتخابی صرف‌نظر از سیاست حذف می‌کند. تأیید در اینجا تنها اقدامات پیوند را بررسی می‌کند؛ پروژه‌های VBA تعبیه‌شده، اشیاء OLE یا سایر محتوای فعال را حذف نمی‌کند و یک فایل PDF یا HTML صادرات‌شده را نیز اعتبارسنجی نمی‌کند.

## **سؤال‌های متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن پیوند دهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش پیوند بدهید.

**آیا می‌توانم یک پیوند را به عناصر اسلاید مستر وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و لایه‌ها از پیوندها پشتیبانی می‌کنند. پیوندهای روی این عناصر در حین اجرا روی اسلایدهایی که از مستر یا لایه مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندها هنگام صادرات به PDF، HTML، تصاویر یا ویدیو حفظ می‌شوند؟**

صادرات‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند؛ تصاویر رستری و ویدیو نمی‌توانند. به ملاحظات صادرات در [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.