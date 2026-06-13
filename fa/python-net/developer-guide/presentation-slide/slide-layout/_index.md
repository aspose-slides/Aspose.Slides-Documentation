---
title: اعمال یا تغییر طرح اسلاید در پایتون
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/python-net/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- جای‌دار
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- نمایان بودن پانوشت
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با کپشن
- تصویر با کپشن
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه طرح‌های اسلاید را در Aspose.Slides برای پایتون از طریق .NET مدیریت و سفارشی کنید. انواع طرح‌ها، کنترل جای‌دارها، نمایان بودن پانوشت و دستکاری طرح‌ها را از طریق مثال‌های کد در پایتون بررسی کنید."
---
## **مقدمه**

یک طرح اسلاید نحوهٔ چیدمان جعبه‌های جای‌دار و قالب‌بندی محتوا را در یک اسلاید تعریف می‌کند. این طرح کنترل می‌کند که کدام جای‌دارها در دسترس هستند و در کجا ظاهر می‌شوند. طرح‌های اسلاید به شما کمک می‌کنند تا ارائه‌ها را به‌سرعت و به‌صورت یکنواخت طراحی کنید — چه چیزی ساده باشد و چه چیزی پیچیده‌تر. برخی از رایج‌ترین طرح‌های اسلاید در PowerPoint شامل موارد زیر هستند:

**طرح اسلاید عنوان** – شامل دو جای‌دار متن است: یکی برای عنوان و دیگری برای زیرعنوان.

**طرح عنوان و محتوا** – شامل یک جای‌دار عنوان کوچکتر در بالای اسلاید و یک جای‌دار بزرگتر در زیر آن برای محتوای اصلی (مانند متن، نکات بولت‌دار، نمودارها، تصاویر و غیره) است.

**طرح خالی** – هیچ جای‌داری ندارد و به شما اجازه می‌دهد اسلاید را از ابتدا طراحی کنید.

طرح‌های اسلاید بخشی از اسلاید اصلی (slide master) هستند، که اسلاید سطح بالایی است که سبک‌های طرح را برای ارائه تعریف می‌کند. می‌توانید طرح‌های اسلاید را از طریق اسلاید اصلی دسترسی و ویرایش کنید — چه بر اساس نوع، نام یا شناسهٔ یکتا. به‌علاوه، می‌توانید یک طرح اسلاید خاص را مستقیماً داخل ارائه ویرایش کنید.

برای کار با طرح‌های اسلاید در Aspose.Slides for Python، می‌توانید از:

- ویژگی‌هایی مانند [layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/layout_slides/) و [masters](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/masters/) در زیر کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) 
- انواعی مانند [LayoutSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterlayoutslidecollection/)، [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/)، و [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

To learn more about working with master slides, check out the [Manage PowerPoint Slide Masters in Python](/slides/fa/python-net/slide-master/) article.

{{% /alert %}}

## **افزودن طرح‌های اسلاید به ارائه‌ها**

برای سفارشی‌سازی ظاهر و ساختار اسلایدهای خود، ممکن است نیاز داشته باشید طرح‌های اسلاید جدیدی به یک ارائه اضافه کنید. Aspose.Slides for Python به شما امکان می‌دهد بررسی کنید که آیا یک طرح خاص از قبل وجود دارد یا نه، در صورت نیاز یک طرح جدید اضافه کنید و از آن برای درج اسلایدهای مبتنی بر آن طرح استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. به [MasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterlayoutslidecollection/) دسترسی پیدا کنید.  
3. بررسی کنید که آیا طرح اسلاید مطلوب در مجموعه وجود دارد یا خیر. اگر وجود نداشته باشد، طرح اسلاید مورد نیاز را اضافه کنید.  
4. یک اسلاید خالی بر پایهٔ طرح اسلاید جدید اضافه کنید.  
5. ارائه را ذخیره کنید.

کد زیر به زبان Python نشان می‌دهد که چگونه یک طرح اسلاید را به یک ارائه PowerPoint اضافه کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای باز کردن فایل ارائه ایجاد می‌کند.
with slides.Presentation("sample.pptx") as presentation:
    # از انواع اسلایدهای طرح عبور می‌کند تا یک اسلاید طرح را انتخاب کند.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # موقعیتی که در آن ارائه همهٔ انواع طرح را شامل نمی‌شود.
        # فایل ارائه فقط شامل انواع طرح Blank و Custom است.
        # اما اسلایدهای طرح با انواع سفارشی ممکن است نام‌های قابل تشخیصی داشته باشند,
        # مانند "Title", "Title and Content", etc., که می‌توان برای انتخاب اسلاید طرح استفاده کرد.
        # می‌توانید به مجموعه‌ای از انواع شکل‌های جای‌دار نیز تکیه کنید.
        # برای مثال، یک اسلاید Title باید فقط نوع جای‌دار Title را داشته باشد و به همین ترتیب.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # یک اسلاید خالی با استفاده از اسلاید طرح اضافه‌شده اضافه کنید.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # ارائه را به دیسک ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف طرح‌های اسلاید استفاده‌نشده**

Aspose.Slides متد [remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) را از کلاس [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) فراهم می‌کند تا به شما اجازه دهد طرح‌های اسلاید ناخواسته و استفاده‌نشده را حذف کنید.

کد زیر به زبان Python نشان می‌دهد که چگونه یک طرح اسلاید را از یک ارائه PowerPoint حذف کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن جای‌دارها به طرح‌های اسلاید**

Aspose.Slides ویژگی [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/placeholder_manager/) را فراهم می‌کند که به شما اجازه می‌دهد جای‌دارهای جدیدی به یک طرح اسلاید اضافه کنید.

این مدیر شامل روش‌هایی برای انواع جای‌دارهای زیر است:

| جای‌دار PowerPoint | روش [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutplaceholdermanager/) |
| ------------------ | ------------------------------------------------------------ |
| ![Content](content.png)             | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png)                   | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png)       | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png)             | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png)                 | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png)                 | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)           | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png)                 | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png)    | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

کد زیر به زبان Python نشان می‌دهد که چگونه اشکال جای‌دار جدیدی به طرح اسلاید Blank اضافه کنید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # دریافت اسلاید طرح خالی.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # دریافت مدیر جای‌دار اسلاید طرح.
    placeholder_manager = layout.placeholder_manager

    # اضافه کردن جای‌دارهای مختلف به اسلاید طرح خالی.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # اضافه کردن اسلاید جدید با طرح خالی.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![جای‌دارها بر روی اسلاید طرح](add_placeholders.png)

## **تنظیم نمایان بودن پانوشت برای یک طرح اسلاید**

در ارائه‌های PowerPoint، عناصر پانوشت مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند بسته به طرح اسلاید نشان داده شوند یا مخفی. Aspose.Slides for Python به شما امکان می‌دهد نمایان بودن این جای‌دارهای پانوشت را کنترل کنید. این کار زمانی مفید است که بخواهید برخی طرح‌ها اطلاعات پانوشت را نمایش دهند و دیگران تمیز و ساده باقی بمانند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. یک مرجع به طرح اسلاید را بر اساس اندیس آن دریافت کنید.  
3. جای‌دار پانوشت اسلاید را به حالت قابل مشاهده تنظیم کنید.  
4. جای‌دار شماره اسلاید را به حالت قابل مشاهده تنظیم کنید.  
5. جای‌دار تاریخ‑زمان را به حالت قابل مشاهده تنظیم کنید.  
6. ارائه را ذخیره کنید.

کد زیر به زبان Python نشان می‌دهد که چگونه نمایان بودن پانوشت اسلاید را تنظیم کنید و کارهای مرتبط را انجام دهید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **تنظیم نمایان بودن پانوشت فرزند برای یک اسلاید**

در ارائه‌های PowerPoint، عناصر پانوشت مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند در سطح اسلاید اصلی کنترل شوند تا سازگاری در تمام طرح‌های اسلاید حفظ شود. Aspose.Slides for Python به شما امکان می‌دهد نمایان بودن و محتوای این جای‌دارهای پانوشت را در اسلاید اصلی تنظیم کنید و این تنظیمات را به تمام طرح‌های اسلاید فرزند اعمال کنید. این رویکرد اطلاعات پانوشت یکسانی را در سراسر ارائه تضمین می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. یک مرجع به اسلاید اصلی را بر اساس اندیس آن دریافت کنید.  
3. جای‌دارهای پانوشت اسلاید اصلی و همه فرزندان آن را به حالت قابل مشاهده تنظیم کنید.  
4. جای‌دارهای شماره اسلاید اسلاید اصلی و همه فرزندان آن را به حالت قابل مشاهده تنظیم کنید.  
5. جای‌دارهای تاریخ‑زمان اسلاید اصلی و همه فرزندان آن را به حالت قابل مشاهده تنظیم کنید.  
6. ارائه را ذخیره کنید.

کد زیر این عملیات را به زبان Python نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**تفاوت بین اسلاید اصلی و طرح اسلاید چیست؟**

اسلاید اصلی تم کلی و قالب‌بندی پیش‌فرض را تعریف می‌کند، در حالی که طرح‌های اسلاید چیدمان‌های خاص جای‌دارها برای انواع مختلف محتوا را مشخص می‌کنند.

**آیا می‌توانم یک طرح اسلاید را از یک ارائه به ارائه دیگر کپی کنم؟**

بله، می‌توانید یک طرح اسلاید را از مجموعه [layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/layout_slides/) یک ارائه کپی کنید و با استفاده از متد `add_clone` آن را در ارائه دیگر درج کنید.

**اگر یک طرح اسلاید را حذف کنم که هنوز توسط اسلایدی استفاده می‌شود چه می‌شود؟**

اگر سعی کنید یک طرح اسلاید را حذف کنید که هنوز توسط حداقل یک اسلاید در ارائه ارجاع داده شده است، Aspose.Slides یک استثنای [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) را صادر می‌کند. برای جلوگیری از این وضعیت، از متد [remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) استفاده کنید که به‌صورت ایمن تنها طرح‌های اسلایدی را که استفاده نمی‌شوند حذف می‌کند.