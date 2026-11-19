---
title: مدیریت پیوندهای فرامتن ارائه در پایتون
linktitle: مدیریت پیوندهای فرامتن
type: docs
weight: 20
url: /fa/python-net/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند فرامتن
- ایجاد پیوند فرامتن
- قالب‌بندی پیوند فرامتن
- حذف پیوند فرامتن
- به‌روز‌رسانی پیوند فرامتن
- پیوند فرامتن متن
- پیوند فرامتن اسلاید
- پیوند فرامتن شکل
- پیوند فرامتن تصویر
- پیوند فرامتن ویدیو
- پیوند فرامتن قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روز‌رسانی و حذف پیوندهای فرامتن در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET، با استفاده از مثال‌های پایتون."
---
## **معرفی**

یک پیوندهای فرامتن (hyperlink) محتویات ارائه را به یک وب‌سایت یا مکان داخل ارائه متصل می‌کند. در PowerPoint، پیوندهای فرامتن معمولاً دو هدف را دارند:

* باز کردن یک وب‌سایت از متن، شکل یا قاب رسانه‌ای.
* حرکت به اسلاید دیگر، برای مثال از یک فهرست مطالب.

Aspose.Slides for Python via .NET به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آن‌ها را کنترل کنید، خصوصیاتشان را به‌روز کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه بر روی عناصر جداگانه با پیوندهای فرامتن کار کنید و چگونه به پیوندهای فرامتن در سطح ارائه، اسلاید یا قاب متن دسترسی داشته باشید.

{{% alert color="info" title="Note" %}}
همچنین می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}}

## **افزودن پیوندهای URL**

می‌توانید یک آدرس وب‌سایت را به متن، شکل یا قاب رسانه‌ای اختصاص دهید. عنصری که پیوند فرامتن به آن اختصاص می‌دهید، ناحیه قابل کلیک را تعیین می‌کند: یک بخش متن، متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا قاب، شیء اسلاید را لینک می‌کند.

برای ارائه‌هایی که شامل پیوندهای نسبی هستند، به [مدیریت پایه پیوند فرامتن](/slides/fa/python-net/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا بتوانید پایهٔ سطح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) را به ویژگی [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) بخش متن اختصاص دهید، همان‌طور که در زیر نشان داده شده است. فقط آن بخش از متن قابل کلیک می‌شود.

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

یک URL را به ویژگی [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) مستطیل اختصاص دهید تا تمام ناحیه آن قابل کلیک شود. [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) به خوانندگان هنگام نشان‌دار کردن مستطیل، اشاراتی درباره مقصد می‌دهد. همان ویژگی‌ها برای قاب‌های تصویر، صدا و ویدیو نیز اعمال می‌شوند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از پیوندهای فرامتن برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به یک اسلاید مشخص پرش کنند. مثال زیر از [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) برای لینک کردن متن «صفحه ۲» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی پیوندهای فرامتن**

می‌توانید رنگ متن لینک‌شده را تغییر دهید، هنگام فعال‌سازی پیوند توسط خواننده صدا پخش یا متوقف کنید و tooltip ای که هنگام نشان‌دار کردن ظاهر می‌شود را تنظیم کنید.

### **رنگ**

ویژگی [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) از [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) تعیین می‌کند که آیا یک پیوند فرامتن از رنگ پیوندهای ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پرشدن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

در این مثال، تنظیم [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) برای اولین پیوند باعث می‌شود متن آن قرمز ظاهر شود. پیوند دوم رنگ پیوندهای ارائه را حفظ می‌کند.

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

یک پیوند فرامتن می‌تواند هنگام فعال‌شدن صدا پخش کند یا صدایی که در حال پخش است را متوقف کند. برای پیکربندی این رفتارها از ویژگی‌های زیر استفاده کنید:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) صدا (آهنگی) مرتبط با پیوند فرامتن را مشخص می‌کند.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) کنترل می‌کند که آیا فعال‌سازی پیوند فرامتن صدا قبلی را متوقف می‌کند یا نه.

#### **افزودن صدا به پیوند فرامتن**

دکمه در اسلاید اول از [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) برای پخش صدا از یک فایل WAV هنگام کلیک خواننده برای پیش رفتن استفاده می‌کند. در اسلاید دوم، دکمه‌ای جداگانه از [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) برای متوقف کردن پخش و نگه داشتن خواننده در آن اسلاید استفاده می‌کند.

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

#### **استخراج صدا از پیوند فرامتن**

مثال زیر ارائه‌ای که در بالا ایجاد شد باز می‌کند و صدای پیوند فرامتن اولین شکل را از طریق [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) و [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) به حافظه می‌خواند.

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

### **تنظیمات Tooltip و تعامل**

می‌توانید پس از اختصاص پیوند فرامتن به متن یا شکل، ویژگی‌های زیر [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) را به‌روزرسانی کنید:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) متنی را که بیننده می‌تواند به عنوان راهنمایی برای پیوند نمایش دهد، تنظیم می‌کند.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) قاب هدف درون یک frameset HTML والد را، در صورت امکان، مشخص می‌کند.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) کنترل می‌کند که آیا فعال‌سازی پیوند مقصد آن را به لیست پیوندهای مرور شده اضافه می‌کند یا نه.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) کنترل می‌کند که آیا پیوند هنگام کلیک برجسته می‌شود یا نه.

## **حذف پیوندهای فرامتن از ارائه‌ها**

از [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) برای جمع‌آوری مخازن پیوندهای فرامتن، از جمله پیوندهای بخش متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) یا [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) را فراخوانی کنید؛ حذف عمل کلیک، معادل mouse‑over آن را حذف نمی‌کند.

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

برای حذف بدون شرط، [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) هر دو نوع فعال‌سازی را در دامنهٔ انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، طرح‌بندی‌ها و یادداشت‌ها، به [گزارش، پاک‌سازی و تأیید پیوندهای فرامتن](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

### **پاک‌سازی پیوندهای فرامتن پیش از جایگزین کردن متن SmartArt**

هنگامی که یک پاراگراف در یک گره SmartArt موجود را جایگزین می‌کنید، پاک‌سازی بخش‌های متنی آن می‌تواند یک پیوند قبلی را باقی بگذارد. پاراگراف را از طریق [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/) بازیابی کنید. پیش از پاک‌سازی بخش‌ها، از طریق [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) روی قاب متن شکل گرهی که پاراگراف را نمایش می‌دهد، [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) را فراخوانی کنید. این کار تمام پیوندهای فرامتن در آن قاب، از جمله پیوندهای پاراگراف‌های دیگر را حذف می‌کند.

در `SmartArtHyperlink.pptx`، سومین شکل در اسلاید اول یک گرافیک SmartArt است. مثال اولین پاراگراف گرهٔ چهارم آن را جایگزین می‌کند. در این ارائه، اولین شکل گره آن پاراگراف را نمایش می‌دهد.

پس از افزودن هر دو بخش، مثال قالب‌بندی مؤثر آن‌ها را با [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) می‌خواند. ویژگی مؤثر [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) پیوند جدید را برای بخش اول و `None` را برای بخش دوم برمی‌گرداند.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **ساخت موجودی کامل پیوندهای فرامتن**

قبل از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) اشیاء [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه یک لیست صاف از رشته‌های URL. هر دو [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) و [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) را در هر مخزن بررسی کنید. آن‌ها مستقل هستند: یک مخزن می‌تواند هر دو اقدام را نشان دهد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر مخزن نیاز داشته باشد.

اسکن فقط پیوندهای سطح شکل ممکن است پیوندهای متصل به بخش‌های متن را از دست بدهد. به‌جای آن، محدوده مناسب را پرس‌وجو کنید و مخازن برگشتی را نگه دارید تا بعداً بتوانید اقدامات آن‌ها را به‌روزرسانی یا حذف کنید.

### **پرس‌وجوی محدوده‌های ارائه، اسلاید و قاب متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) از طریق [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)، [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) و [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) در دسترس است. هر محدوده همان پرس‌وجوها را پشتیبانی می‌کند:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) مخازن حاوی اقدام کلیک را برمی‌گرداند.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) مخازن حاوی اقدام mouse‑over را برمی‌گرداند.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) مخازن دارای هر یک یا هر دو اقدام را برمی‌گرداند.

این مثال اقدامات کلیک و mouse‑over را به یک شکل و متن آن اختصاص می‌دهد و یک اقدام ماکرو را به یک دکمهٔ جداگانه. مخازن برگشتی توسط [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) را با شمارش هر نوع فعال‌سازی مقایسه می‌کند. یک پرس‌وجوی قاب متن فقط پیوندهای موجود در متن را می‌شمارد. اقدامات خود شکل در پرس‌وجوهای اسلاید و ارائه ظاهر می‌شوند.

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

برای این مثال، پرس‌وجوهای ارائه و اسلاید به ترتیب سه مخزن کلیک، دو مخزن mouse‑over و سه مخزن با هر یک از اقدامات را گزارش می‌کنند. پرس‌وجوی قاب متن یک مخزن در هر دسته گزارش می‌دهد.

### **دسته‌بندی اقدامات و مقاصد**

از [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) برای تفسیر یک اقدام قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) بیش از مرور وب را شامل می‌شوند:

| Values | معنی برای یک حسابرسی |
| --- | --- |
| `HYPERLINK` | پیوند فرامتن خارجی؛ URL و طرح آن را بررسی کنید. |
| `JUMP_SPECIFIC_SLIDE` | ناوبری داخلی به اسلاید خاصی. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | ناوبری داخلی تعبیه‌شدهٔ نمایش اسلاید، در زمینهٔ نمایش اسلاید حل می‌شود. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `START_MACRO` | اجرای ماکرو. |
| `START_PROGRAM` | اجرای یک برنامه. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | باز کردن یک فایل یا ارائهٔ دیگر؛ به صورت جداگانه از URLهای وب بررسی شود. |
| `START_STOP_MEDIA` | شروع یا توقف پخش رسانه. |
| `NO_ACTION`, `UNKNOWN` | بدون اقدام ناوبری، یا اقدامی نامشخص که نیاز به بررسی دارد. |

مقاصد خارجی را از [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) و مقاصد داخلی خاص را از [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/) بخوانید. اقدامات داخلی و دستورات تعبیه‌شده ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنا نیست که مخزن بدون اقدام باشد. هنگامی که [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) با URL نرمال‌سازی‌شده متفاوت است، آن را حفظ کنید و هنگام موجود بودن، [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) را نیز بگنجانید.

### **گزارش، پاک‌سازی و تأیید پیوندهای فرامتن**

این مثال ارائه‌ای که در مثال قبلی ایجاد شد را باز می‌کند و برای هر اقدام یک رکورد JSON می‌نویسد. از [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) برای جمع‌آوری مخازن در اسلایدهای معمولی، مسترها، طرح‌بندی‌ها و یادداشت‌ها (از جمله مسترهای یادداشت و دستی) استفاده می‌کند. هر محدوده یک بار پرس‌وجو می‌شود تا پردازش تکراری جلوگیری شود، سیاست توضیح داده‌شده در ادامه اعمال می‌شود و سپس ارائهٔ ذخیره‌شده بازگشایی می‌شود تا هر دو اقدام کلیک و mouse‑over بررسی شوند.

گزارش یک ایندکس اسلاید مبتنی بر شمارش از یک و [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) (در صورت موجود بودن) را ثبت می‌کند. جمع‌کننده اسلاید مالک و محدوده را در کنار هر مخزن برگردانده‌شده نگه می‌دارد. مسترها، طرح‌بندی‌ها و یادداشت‌ها ایندکس اسلاید عادی ندارند و با محدوده‌شان شناسایی می‌شوند. مخازن شکل و مخازن قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ انواع دیگر مخازن نام نوع زمان اجرا خود را حفظ می‌کنند. به هر مخزن یک شناسهٔ محلی گزارش اختصاص داده می‌شود تا دو اقدام آن بتوانند مرتبط شوند.

این سیاست کاربردی عمداً محدود، فقط URLهای مطلق HTTPS و اهداف داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اقدامات فایل، سایر اقدامات نمایش اسلاید، اقدامات ناشناخته و سایر طرح URLها را رد می‌کند. این ردها تصمیمات سیاستی هستند، نه حکم ایمنی Aspose.Slides. صرفاً HTTPS اعتماد را برقرار نمی‌کند: فهرست‌های مجاز میزبان و بررسی‌های دیگر را برای برنامهٔ خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌سازی‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن پیوندها یا اجرای اقدامات بررسی می‌کند.

برای اصلاح، [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) مخزن از [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)، [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) و [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) پشتیبانی می‌کند. در اینجا، پیوندهای کلیک خارجی ممنوع با یک صفحهٔ فرود ثابت HTTPS جایگزین می‌شوند؛ سایر کلیک‌های ممنوع و اقدامات mouse‑over ممنوع به‌صورت مستقل حذف می‌شوند. مقدار `replace_external_clicks` را به `False` تنظیم کنید تا تمام تخلفات سیاست حذف شوند. پیش از استقرار، یک صفحهٔ جایگزین تحت مالکیت برنامه انتخاب کنید.

پرچم خروجی گزارش از یک سیاست مرور PDF محتاطانه استفاده می‌کند: اقدامات mouse‑over و هر چیز غیر از یک پیوند خارجی یا پرش اسلاید خاص را به‌عنوان احتمالا نام پشتیبانی‌شده علامت‌گذاری می‌کند. این یک نکتهٔ مرور است، نه آزمونی از قابلیت یا تضمینی که پیوندهای علامت‌نشده پس از خروجی باقی بمانند. خروجی‌های پشتیبانی‌شدهٔ [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/python-net/convert-powerpoint-to-html/) ممکن است پیوندهای فرامتن را حفظ کنند، بسته به اقدام، گزینه‌های خروجی و نمایشگر. [تصاویر](/slides/fa/python-net/convert-powerpoint-to-png/) و [ویدیو](/slides/fa/python-net/convert-powerpoint-to-video/) رستر نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام حسابرسی برای این خروجی‌ها، هر اقدام را علامت‌گذاری کنید.

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
    # یک بار حوزهٔ هر اسلاید را پرس‌وجو کنید و مالک آن را همراه هر مخزن حفظ کنید.
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

با ورودی ایجاد‌شده بالا، گزارش شامل پنج ردیف اقدام است. پیوند mouse‑over فایل و کلیک ماکرو حذف شده‌اند، در حالی که پیوندهای HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر اقدام ممنوع چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع نیز شاخهٔ جایگزینی را فعال می‌کند. مخزنی با کلیک مجاز و mouse‑over ممنوع، اقدام کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) متفاوت است، که هر دو نوع فعال‌سازی را در تمام دامنهٔ انتخاب‌شده بدون توجه به سیاست حذف می‌کند. تأیید اینجا فقط اقدامات پیوند فرامتن را بررسی می‌کند؛ پروژه‌های VBA جاسازی‌شده، اشیاء OLE یا سایر محتوای فعال را حذف نمی‌کند و فایل PDF یا HTML خروجی را نیز اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید فردی هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم پیوند فرامتن را به عناصر اسلاید مستر وصل کنم تا در همه اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و طرح‌بندی از پیوندهای فرامتن پشتیبانی می‌کنند. پیوندهای موجود در این عناصر در طول نمایش اسلاید بر روی اسلایدهایی که از مستر یا طرح‌بندی مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندهای فرامتن هنگام خروجی به PDF، HTML، تصاویر یا ویدیو حفظ می‌شوند؟**

خروجی‌های پشتیبانی‌شدهٔ PDF و HTML ممکن است پیوندهای فرامتن را حفظ کنند؛ تصاویر رستر و ویدیو نمی‌توانند. ملاحظات خروجی را در [گزارش، پاک‌سازی و تأیید پیوندهای فرامتن](#report-sanitize-and-verify-hyperlinks) ببینید.