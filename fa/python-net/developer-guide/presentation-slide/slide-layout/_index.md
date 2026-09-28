---
title: اعمال یا تغییر طرح‌های اسلاید در Python
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/python-net/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- مکان‌نگهدار
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌ نشده
- قابلیت نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با عنوان فرعی
- تصویر با عنوان فرعی
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "اعمال، ایجاد و اصلاح طرح‌های اسلاید در Aspose.Slides برای Python از طریق .NET، افزودن مکان‌نگهدارها، حذف طرح‌های استفاده‌نشده و کنترل نمایش پاورقی."
---
## **نمای کلی**

یک طرح اسلاید موقعیت‌ها و قالب‌بندی مکان‌نگهدارهای مختلف مانند عنوان‌ها، متن، تصاویر، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح به اسلایدها ساختاری یکدست می‌بخشد در حالی که هر اسلاید می‌تواند محتوای خاص خود را داشته باشد.

شایع‌ترین طرح‌ها عبارتند از:

- **اسلاید عنوان**: شامل مکان‌نگهدارهای عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک مکان‌نگهدار عنوان و یک مکان‌نگهدار محتوای کلی است.
- **خالی**: هیچ مکان‌نگهدار محتوایی ندارد و زمانی مفید است که هر شکل به‌صورت دستی موقعیت‌یابی شود.

## **درک ارث‌بری طرح**

یک ارائه سه سطح مرتبط دارد:

1. یک [master slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
2. یک [layout slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) متعلق به یک master است و یک ترتیب خاص از مکان‌نگهدارها را تعریف می‌کند.
3. یک [normal slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) از یک layout استفاده می‌کند و محتوای واردشده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی تم و قالب‌بندی را از layout خود به ارث می‌برد و layout نیز از master ارث می‌برد. مقداری که مستقیماً بر روی اسلاید عادی تنظیم شود، مقدار ارث‌بری را در همان سطح بازنویسی می‌کند. زمانی که یک اسلاید عادی ایجاد می‌شود، اشکال مکان‌نگهدارهای آن از layout منتخب ساخته می‌شوند و محتوای واردشده در آن مکان‌نگهدارها به اسلاید عادی تعلق دارد.

قبل از ایجاد اسلایدها، مکان‌نگهدارهای مورد نیاز را به یک layout اضافه کنید. افزودن later یک مکان‌نگهدار جدید به یک layout به‌صورت خودکار شکل مکان‌نگهدار متناظر را به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌بری یا هندسه مکان‌نگهدارهای موجود در یک layout می‌تواند تمام اسلایدهایی که به آن وابسته‌اند را به‌روزرسانی کند. پیش از ویرایش یک layout که در حال استفاده است، اسلایدهای وابسته آن را بررسی کنید و ارائهٔ حاصل را مرور نمایید.
- یک layout که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته را به layout دیگری منتقل کنید یا فقط layoutهای نامستخدمة را حذف کنید.

برای اطلاعات بیشتر دربارهٔ سطح بالایی این سلسله‌مراتب، به [Slide Master](/slides/fa/python-net/slide-master/) مراجعه کنید.

برای مخفی کردن لوگوهای ارث‌بری یا اشکال decorative master در یک اسلاید یا از طریق یک layout مشترک، به [Control the Visibility of Master Graphics](/slides/fa/python-net/slide-master/) نگاه کنید. این مثال دو اسلاید استفاده‌کننده از همان master را مقایسه می‌کند.

## **انتخاب و اعمال یک طرح اسلاید**

زمانی که ارائه از تعریف‌های استاندارد PowerPoint پیروی می‌کند، از یک نوع layout استفاده کنید. نام‌های layout قابلیت ویرایش توسط کاربر دارند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر پایه نام کمتر قابل اطمینان است مگر اینکه الگوی منبع را کنترل کنید.

مثال زیر به دنبال **Title and Content** در اولین master می‌گردد. اگر آن layout موجود نباشد، عمداً به **Blank** باز می‌گردد. بررسی دوم برای null لازم است زیرا یک ارائه ممکن است فقط شامل layoutهای سفارشی باشد. سپس layout انتخاب‌شده از طریق ویژگی [Slide.layout_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/layout_slide/) به اولین اسلاید عادی اعمال می‌شود.

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

تغییر layout یک اسلاید، اشکال عادی اضافه‌ شده مستقیم به اسلاید را حذف نمی‌کند. با این حال، موقعیت مکان‌نگهدارها، قالب‌بندی ارث‌بری و تطابق بین مکان‌نگهدارهای موجود و layout جدید ممکن است تغییر کنند، بنابراین هنگام جابجایی بین layoutهای به‌طور قابل‌تفاوت متفاوت، خروجی را بررسی کنید.

## **افزودن یک Layout Slide**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک layout موجود را انتخاب کرد؛ آن را ایجاد نکرد. برای ایجاد یک layout، متد [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterlayoutslidecollection/add/) را بر روی مجموعه layoutهای master هدف صدا بزنید.

مثال زیر همیشه یک layout جدید **Title and Content** به نام `Report Title and Content` اضافه می‌کند و سپس یک اسلاید عادی بر پایهٔ آن می‌سازد. نام‌های layout باید درون مجموعه یکتا باشند.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

فقط زمانی که الگوی قالب واقعاً به ساختار قابل‌استفادهٔ دیگری نیاز دارد، یک layout اضافه کنید. اگر یک layout مناسب از قبل وجود دارد، آن را انتخاب و مجدداً استفاده کنید به جای اینکه یک نسخهٔ تکراری ایجاد کنید.

## **افزودن مکان‌نگهدارها به یک Layout Slide**

ویژگی [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/placeholder_manager/) یک [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/) برای افزودن اشکال مکان‌نگهدار به layout فراهم می‌کند.

| مکان‌نگهدار PowerPoint | متد `LayoutPlaceholderManager` |
| ---------------------- | ------------------------------ |
| ![Content](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

مثال زیر بررسی می‌کند که آیا layout **Blank** وجود دارد، چهار مکان‌نگهدار به آن اضافه می‌کند و سپس یک اسلاید عادی که از layout اصلاح‌شده استفاده می‌کند ایجاد می‌نماید. ترتیب کار عمدی است: مکان‌نگهدارها پیش از ایجاد اسلاید عادی اضافه می‌شوند تا Aspose.Slides بتواند اشکال مکان‌نگهدار متناظر را در آن اسلاید تولید کند.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

تغییر قالب‌بندی ارث‌بری یا هندسهٔ مکان‌نگهدارهای موجود در یک layout می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک مکان‌نگهدار جدید به layout به صورت خودکار در اسلایدهای عادی موجود پر نمی‌شود. تغییرات layout را روی یک کپی از ارائه تست کنید و هر اسلاید وابسته را بررسی نمایید.

{{% /alert %}}

## **حذف Layout Slideهای نامستخدم**

از متد [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) برای حذف layoutهایی که هیچ اسلاید عادی به آن ارجاع نمی‌دهد، استفاده کنید. این متد layoutهای در‑استفاده را دست نخورده می‌گذارد.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

برای حذف یک layout خاص، ابتدا از ویژگی [has_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/has_depending_slides/) یا متد [get_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/get_depending_slides/) آن استفاده کنید. قبل از صدا زدن [LayoutSlide.remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/remove/) اسلایدهای وابسته را منتقل کنید. تلاش برای حذف یک layout استفاده‌شده منجر به پرتاب [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی در یک Layout Slide**

یک layout پاورقی، شماره اسلاید و مکان‌نگهدارهای تاریخ‑زمان خود را دارد. از ویژگی [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/header_footer_manager/) برای کنترل این مکان‌نگهدارها در یک layout استفاده کنید. این کار وقتی مفید است که مثلاً layoutهای محتوا باید پاورقی داشته باشند ولی layoutهای عنوان نباید.

مثال زیر یک layout را به‌صورت ایمن انتخاب کرده و عناصر پاورقی آن را قابل مشاهده می‌سازد:

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

## **کنترل نمایش پاورقی در یک Master و Layoutهای فرزند آن**

برای اعمال تنظیمات پایدار پاورقی در سراسر سلسله‌مراتب master، از ویژگی [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/header_footer_manager/) استفاده کنید. متدهای انتشار [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslideheaderfootermanager/) بر روی master و layoutهای وابسته و اسلایدهای عادی اعمال می‌شوند؛ آنها فقط یک اسلاید عادی را هدف نمی‌گیرند.

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

## **سوالات متداول**

**تفاوت Master Slide و Layout Slide چیست؟**

یک master slide تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. یک layout slide به یک master تعلق دارد و یک ترتیب قابل‌استفادهٔ مکان‌نگهدارها را توصیف می‌کند. اسلایدهای عادی از این layoutها استفاده می‌کنند و محتویات مخصوص به خود را ذخیره می‌نمایند.

**آیا می‌توانم یک Layout Slide را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با استفاده از متد [add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/globallayoutslidecollection/add_clone/) یک نسخه به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابع استفاده‌شده توسط layout منبع را نیز بررسی کنید.

**وقتی یک Layout که در حال استفاده است را تغییر می‌دهم چه اتفاقی می‌افتد؟**

اسلایدهای وابسته تغییرات layout را به‌ارث می‌برند مگر این‌که قالب‌بندی یا اشیای تحت‌تأثیر را به‌صورت محلی بازنویسی کنند. بنابراین هندسهٔ مکان‌نگهدارها و استایل‌های ارث‌بری می‌توانند به‌طور هم‌زمان در تعداد زیادی اسلاید تغییر کنند. قبل از ویرایش layout از [get_depending_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/get_depending_slides/) برای شناسایی اسلایدهای تحت تأثیر استفاده کنید.

**اگر یک Layout هنوز در استفاده باشد را حذف کنم چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را به layout دیگری منتقل کنید یا از [remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) برای حذف تنها layoutهای بدون ارجاع استفاده کنید.