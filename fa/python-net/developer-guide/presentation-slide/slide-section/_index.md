---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با پایتون
linktitle: بخش اسلاید
type: docs
weight: 100
url: /fa/python-net/slide-section/
keywords:
- ایجاد بخش
- اضافه کردن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- دریافت اسلایدهای بخش
- پردازش اسلایدهای بخش
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید با Aspose.Slides برای پایتون از طریق .NET: ایجاد، تغییر نام، دوباره‌چینش، دریافت و پردازش اسلایدهای بخش در ارائه‌های PPTX."
---
## **معرفی**

بخش‌ها اسلایدهای متوالی را بدون تغییر محتوای اسلاید به گروه‌های نام‌گذاری شده سازماندهی می‌کنند. با Aspose.Slides برای Python از طریق .NET می‌توانید با استفاده از ویژگی [Presentation.sections](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/sections/) بخش‌ها را ایجاد، دوباره ترتیب دهید، نام‌گذاری کنید، بررسی کنید و حذف کنید.

بخش‌ها به‌ویژه زمانی مفید هستند که:

- یک ارائه بزرگ نیاز به تقسیم به موضوعات یا فصل‌های منطقی دارد؛
- گروه‌های مختلفی از اسلایدها به همکاران متفاوت اختصاص داده می‌شوند؛
- اسلایدها باید به‌عنوان گروه‌ها پردازش، جابه‌جا یا ادغام شوند.

نام‌های کوتاه و واضحی برای بخش‌ها انتخاب کنید که هدف اسلایدهای گروه‌بندی‌شده را توضیح دهد. چون بخش‌ها بخشی از ساختار ارائه هستند، برای تعیین عضویت از APIهای بخش استفاده کنید نه اینکه آن را از موقعیت اسلایدها استخراج کنید.

## **ایجاد و مدیریت بخش‌ها**

از [SectionCollection.add_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/add_section/) برای ایجاد یک بخش با تعیین نام و اسلاید شروع استفاده کنید. Aspose.Slides اسلایدهایی را که به بخش تعلق دارند بر اساس ساختار فعلی بخش‌های ارائه تعیین می‌کند.

[SectionCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/) همچنین به شما امکان می‌دهد:

- با استفاده از [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) یک بخش را همراه با اسلایدهایش جابه‌جا کنید؛
- فقط تعریف بخش را با [SectionCollection.remove_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/remove_section/) حذف کنید، که اسلایدهای آن را نگه می‌دارد؛
- یک بخش و اسلایدهایش را با [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) حذف کنید؛
- یک بخش خالی در انتها با [SectionCollection.append_empty_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/append_empty_section/) اضافه کنید.

مثال زیر دو بخش ایجاد می‌کند، یکی از آن‌ها را جابه‌جا می‌کند، همراه با اسلایدهایش حذف می‌کند و یک بخش خالی اضافه می‌کند:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

پس از این عملیات، ارائه شامل بخش `Introduction` به همراه اسلایدهایش و یک بخش خالی `Appendix` می‌شود. بخش `Results` و اسلایدهای آن حذف شده‌اند.

## **تغییر نام بخش‌ها**

برای تغییر نام یک بخش، ویژگی [Section.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/name/) آن را تنظیم کنید. اسلایدهای بخش و موقعیت آن بدون تغییر باقی می‌مانند.

مثال زیر یک بخش ایجاد کرده و نام آن را تغییر می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **دریافت اسلایدها از بخش‌ها**

ویژگی [Presentation.sections](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/sections/) یک [SectionCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/) برمی‌گرداند که می‌توانید روی آن تکرار کنید. برای هر [Section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/) متد [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/get_slides_list_of_section/) را صدا بزنید تا اسلایدهایی که در حال حاضر به آن تعلق دارند دریافت شوند. این متد یک [SectionSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectionslidecollection/) برمی‌گرداند که تعداد، دسترسی ایندکس‌دار و قابلیت تکرار را فراهم می‌کند.

مثال زیر دو بخش پر و یک بخش خالی می‌سازد، سپس برای هر بخش نام، شناسه، اسلاید شروع، تعداد اسلاید و شماره اسلایدها را چاپ می‌کند. از دسترسی ایندکس‌دار برای خواندن اولین اسلاید و یک حلقه `for` برای پردازش تمام اسلایدها استفاده می‌شود. برای بخش خالی، مجموعه برگشتی شمارش صفر دارد، ایندکس دسترسی نمی‌شود و تکرار هیچ گامی انجام نمی‌دهد.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

عضویت در بخش‌ها توسط ساختار بخش‌های ارائه تعیین می‌شود. محدوده یک بخش را به‌صورت دستی از [Section.started_from_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/started_from_slide/)، شاخص‌های اسلاید و اسلاید شروع بخش بعدی محاسبه نکنید.

ویرایش‌های ساختاری می‌توانند هم اسلایدهای بازگشتی برای یک بخش و هم شماره اسلایدهایشان را تغییر دهند. این شامل دوباره‌چینش اسلایدها، کلون کردن یک اسلاید به داخل یک بخش، جابه‌جایی یک بخش همراه با اسلایدهایش، حذف اسلایدها و حذف بخش‌ها می‌شود. مثال بعدی پس از هر تغییر، به جای حفظ فرض‌های قبلی دربارهٔ مرزهای بخش، متد [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/get_slides_list_of_section/) را صدا می‌زند.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

هر زمان اسلایدها یا بخش‌ها دوباره ترتیب داده شوند، کلون شوند، جابه‌جا یا حذف شوند، دوباره متد [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/get_slides_list_of_section/) را فراخوانی کنید. این کار پردازش‌های بعدی را با ساختار فعلی ارائه هم‌راستا نگه می‌دارد.

قالب PPT (PowerPoint 97–2003) متادیتای بخش‌ها را نگه نمی‌دارد. از این جریان کار با قالبی که از بخش‌ها پشتیبانی می‌کند، مانند PPTX، استفاده کنید؛ تبدیل به PPT ساختار بخش‌ها را که برای تکرارهای بعدی لازم است، حذف می‌کند.

## **سؤالات متداول**

**آیا بخش‌ها هنگام ذخیره در قالب PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

نه. قالب PPT از متادیتای بخش‌ها پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از دست می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

نه. یک بخش وضعیت قابل مشاهده‌گری ندارد. برای پنهان کردن محتویات آن، ویژگی [Slide.hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/hidden/) را برای هر اسلاید در بخش تنظیم کنید.

**چگونه می‌توانم بخش حاوی یک اسلاید را پیدا کنم؟**

بر روی [Presentation.sections](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/sections/) تکرار کنید، برای هر بخش متد [Section.get_slides_list_of_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/get_slides_list_of_section/) را صدا بزنید و اسلایدهای برگشتی را با اسلاید هدف مقایسه کنید. برای یک بخش غیر خالی، [Section.started_from_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/started_from_slide/) اولین اسلاید آن را برمی‌گرداند؛ برای یک بخش خالی، مقدار `None` برگردانده می‌شود.