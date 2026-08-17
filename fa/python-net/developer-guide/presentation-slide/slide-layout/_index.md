---
title: اعمال یا تغییر طرح اسلایدها در پایتون
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/python-net/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- محل‌نگهدار
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- قابلیت مشاهده پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با کپشن
- عکس با کپشن
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "اعمال، ایجاد و اصلاح طرح‌های اسلاید در Aspose.Slides برای پایتون از طریق .NET، افزودن محل‌نگهدارها، حذف طرح‌های استفاده‌نشده و کنترل نمایش پاورقی."
---
## **بررسی کلی**

طرح اسلاید موقعیت‌ها و قالب‌بندی مکان‌گذاردهای مختلف مانند عنوان‌ها، متن، تصاویر، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح، ساختار یکسانی به اسلایدها می‌بخشد در حالی که هر اسلاید می‌تواند محتوای خودش را داشته باشد.

متداول‌ترین طرح‌ها عبارتند از:

- **اسلاید عنوان**: شامل مکان‌گذارهای عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک مکان‌گذار عنوان و یک مکان‌گذار محتوا عمومی است.
- **خالی**: هیچ مکان‌گذار محتوایی ندارد و زمانی مفید است که همهٔ اشکال به‌صورت دستی موقعیت‌یابی شوند.

## **درک وراثت طرح**

یک ارائه سه سطح مرتبط دارد:

1. یک [اسلاید اصلی](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
1. یک [اسلاید طرح](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) به یک اسلاید اصلی تعلق دارد و ترتیب خاصی از مکان‌گذاردها را تعریف می‌کند.
1. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) از یک طرح استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی تم و قالب‌بندی را از طرح خود به‌ارث می‌برد و طرح نیز از اسلاید اصلی. مقدار تعریف‌شده به‌صورت مستقیم روی اسلاید عادی، مقدار وراثت‌شده را در همان سطح بازنویسی می‌کند. هنگام ایجاد یک اسلاید عادی، اشکال مکان‌گذار آن از طرح انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده در آن مکان‌گذاردها متعلق به اسلاید عادی است.

قبل از ایجاد اسلایدها، مکان‌گذاردهای لازم را به یک طرح اضافه کنید. افزودن یک مکان‌گذار جدید به طرح بعداً، به‌طور خودکار یک شکل مربوطه به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی وراثت‌شده یا هندسه مکان‌گذارهای موجود در یک طرح می‌تواند همهٔ اسلایدهایی را که به آن وابسته‌اند به‌روز کند. قبل از ویرایش طرحی که قبلاً استفاده شده، اسلایدهای وابسته را بررسی و ارائهٔ نهایی را بازبینی کنید.
- طرحی که هنوز توسط یک اسلاید استفاده می‌شود قابل حذف نیست. قبل از حذف، اسلایدهای وابسته را به طرح دیگری اختصاص دهید یا فقط طرح‌های استفاده‌نشده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالای این سلسله مراتب، به [Slide Master](/slides/fa/python-net/slide-master/) مراجعه کنید.

## **انتخاب و اعمال یک طرح اسلاید**

هنگامی که ارائه از تعاریف استاندارد طرح PowerPoint پیروی می‌کند، از نوع طرح استفاده کنید. نام‌های طرح قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر پایه نام تا زمانی که قالب منبع را کنترل کنید، کمتر قابل اطمینان است.

مثال زیر به دنبال **Title and Content** در اولین اسلاید اصلی می‌گردد. اگر آن طرح موجود نباشد، عمداً به **Blank** بازمی‌گردد. بررسی دوم برای مقدار null ضروری است چون یک ارائه می‌تواند فقط شامل طرح‌های سفارشی باشد. سپس طرح انتخاب‌شده از طریق ویژگی [Slide.layout_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/layout_slide/) به اولین اسلاید عادی اعمال می‌شود.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

تغییر طرح یک اسلاید، اشکال عادی اضافه‌شده مستقیم به اسلاید را حذف نمی‌کند. با این حال، موقعیت مکان‌گذاردها، قالب‌بندی وراثت‌شده و تطابق بین مکان‌گذاردهای موجود و طرح جدید می‌تواند تغییر کند، بنابراین هنگام جابجایی بین طرح‌های به‌طور قابل‌توجه متفاوت، خروجی را بررسی کنید.

## **افزودن یک اسلاید طرح**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح موجود را انتخاب می‌کرد؛ آن را ایجاد نمی‌کرد. برای ایجاد یک طرح، روش [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterlayoutslidecollection/add/) را بر روی مجموعهٔ طرح‌های اسلاید اصلی هدف فراخوانی کنید.

مثال زیر همیشه یک طرح جدید **Title and Content** با نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید عادی بر پایهٔ آن می‌سازد. نام‌های طرح باید در داخل مجموعه منحصر به‌فرد باشند.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

فقط زمانی که قالب واقعاً به ساختار قابل‌استفاده دیگری نیاز دارد، یک طرح اضافه کنید. اگر یک طرح مناسب از پیش موجود باشد، آن را انتخاب و دوباره استفاده کنید نه اینکه نسخهٔ تکراری بسازید.

## **افزودن مکان‌گذاردها به یک اسلاید طرح**

ویژگی [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/placeholder_manager/) یک [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/) برای افزودن اشکال مکان‌گذار به طرح فراهم می‌کند.

| مکان‌گذار PowerPoint               | روش `LayoutPlaceholderManager` |
| ----------------------------------- | ------------------------------ |
| ![Content](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

مثال زیر بررسی می‌کند که آیا طرح **Blank** وجود دارد، چهار مکان‌گذار به آن اضافه می‌کند و سپس اسلاید عادی‌ای می‌سازد که از طرح اصلاح‌شده استفاده می‌کند. ترتیب کار عمدی است: مکان‌گذاردها قبل از ایجاد اسلاید عادی اضافه می‌شوند تا Aspose.Slides بتواند اشکال مکان‌گذار مربوطه را در آن اسلاید تولید کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![مکان‌گذاردهای موجود در اسلاید طرح](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی وراثت‌شده یا هندسهٔ مکان‌گذارهای موجود در طرح می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک مکان‌گذار جدید به طرح، به‌صورت خودکار در اسلایدهای عادی موجود پر نمی‌شود. تغییرات طرح را روی یک کپی از ارائه تست کنید و هر اسلاید وابسته را بازبینی کنید.
{{% /alert %}}

## **حذف اسلایدهای طرح بلااستفاده**

از روش [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) برای حذف طرح‌هایی که هیچ اسلاید عادی به آن ارجاع نمی‌دهد استفاده کنید. این روش طرح‌های هنوز در استفادهٔ فعال را دست نخورده می‌گذارد.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

برای حذف یک طرح خاص، ابتدا ویژگی [has_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/has_depending_slides/) یا روش [get_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/get_depending_slides/) آن را بررسی کنید. پیش از فراخوانی [LayoutSlide.remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/remove/)، هر اسلاید وابسته را به طرح دیگری اختصاص دهید. تلاش برای حذف یک طرح استفاده‌شده منجر به بروز [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی در یک اسلاید طرح**

هر طرح فوتر، شماره اسلاید و مکان‌گذار تاریخ‑زمان خود را دارد. برای کنترل این مکان‌گذاردها در یک طرح، از ویژگی [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/header_footer_manager/) استفاده کنید. این مفید است زمانی که به عنوان مثال، طرح‌های محتوا باید فوتر داشته باشند ولی طرح‌های عنوان نه.

مثال زیر یک طرح را به‌صورت ایمن انتخاب می‌کند و عناصر فوتر آن را قابل مشاهده می‌سازد:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **کنترل نمایش پاورقی در یک اسلاید اصلی و طرح‌های فرزند آن**

برای اعمال تنظیمات فوتر یکسان در سلسله مراتب یک اسلاید اصلی، از ویژگی [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/header_footer_manager/) استفاده کنید. روش‌های انتشار [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslideheaderfootermanager/) بر روی اسلاید اصلی، طرح‌های وابستهٔ آن و اسلایدهای عادی عمل می‌کند؛ نه فقط بر یک اسلاید عادی.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**تفاوت اسلاید اصلی و اسلاید طرح چیست؟**

اسلاید اصلی تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح به یک اسلاید اصلی تعلق دارد و یک ترتیب قابل استفاده مجدد از مکان‌گذاردها را تعریف می‌کند. اسلایدهای عادی از این طرح‌ها استفاده می‌کنند و محتویات خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با روش [add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/globallayoutslidecollection/add_clone/) یک کپی به مجموعهٔ مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و دیگر منابع مورد استفادهٔ طرح مبدا را نیز بررسی کنید.

**اگر یک طرح که در حال استفاده است را تغییر دهم چه می‌شود؟**

اسلایدهای وابسته تغییرات طرح را وراثت می‌کنند مگر آنکه قالب‌بندی یا اشیای تحت تأثیر را به‌صورت محلی بازنویسی کرده باشند. بنابراین هندسهٔ مکان‌گذاردها و سبک‌های وراثت‌شده ممکن است در بسیاری از اسلایدها یک‌باره تغییر کند. قبل از ویرایش طرح، با استفاده از [get_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/get_depending_slides/) اسلایدهای تحت تأثیر را شناسایی کنید.

**اگر یک طرح هنوز استفاده می‌شود را حذف کنم چه اتفاقی می‌افتد؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) پرتاب می‌کند. پیش از حذف، اسلایدهای وابسته را به طرح دیگری اختصاص دهید یا از [remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) فقط طرح‌های بدون ارجاع را حذف کنید.