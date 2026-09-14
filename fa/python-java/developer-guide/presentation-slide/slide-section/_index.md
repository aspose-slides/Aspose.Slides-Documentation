---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با Python از طریق Java
linktitle: بخش اسلاید
type: docs
weight: 90
url: /fa/python-java/slide-section/
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
- Python
- Java
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید با Aspose.Slides برای Python از طریق Java: ایجاد، تغییر نام، دوباره‌چینش، دریافت و پردازش اسلایدهای بخش در ارائه‌های PPTX."
---
## **مقدمه**

بخش‌ها اسلایدهای متوالی را در گروه‌های نام‌گذاری‌شده بدون تغییر محتوی اسلایدها سازماندهی می‌کنند. با Aspose.Slides برای Python از طریق Java، می‌توانید با استفاده از متد [Presentation.getSections](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSections) بخش‌ها را ایجاد، دوباره‌چینش، تغییر نام، بررسی و حذف کنید.

بخش‌ها به‌ویژه زمانی مفید هستند که:

- یک ارائه بزرگ نیاز به تقسیم به موضوعات یا فصل‌های منطقی دارد؛
- گروه‌های مختلفی از اسلایدها به همکاران متفاوت اختصاص یافته‌اند؛
- اسلایدها نیاز به پردازش، جابجایی یا ادغام به‌عنوان گروه‌ها دارند.

نام‌های بخش را به‌صورت مختصر انتخاب کنید که هدف اسلایدهای گروه‌بندی‌شده را توصیف کنند. چون بخش‌ها بخشی از ساختار ارائه هستند، برای تعیین عضویت از APIهای بخش استفاده کنید نه اینکه آن را از موقعیت اسلایدها استخراج کنید.

## **ایجاد و مدیریت بخش‌ها**

از [SectionCollection.addSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectioncollection/#addSection) برای ایجاد یک بخش با مشخص کردن نام و اسلاید شروع استفاده کنید. Aspose.Slides تعیین می‌کند کدام اسلایدها به بخش متعلق هستند بر اساس ساختار فعلی بخش‌های ارائه.

همین [SectionCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectioncollection/) همچنین به شما اجازه می‌دهد:

- با استفاده از [reorderSectionWithSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) یک بخش را همراه با اسلایدهای آن جابه‌جا کنید؛  
- فقط تعریف بخش را با [removeSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectioncollection/#removeSection) حذف کنید که اسلایدهای آن را حفظ می‌کند؛  
- یک بخش و اسلایدهای آن را با [removeSectionWithSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectioncollection/#removeSectionwithslides) حذف کنید؛  
- یک بخش خالی در انتها با [appendEmptySection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectioncollection/#appendEmptySection) اضافه کنید.

مثال زیر دو بخش را ایجاد می‌کند، یکی از آن‌ها را جابه‌جا می‌کند، همراه با اسلایدهایش حذف می‌کند و یک بخش خالی اضافه می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

پس از این عملیات، ارائه شامل بخش `Introduction` به‌همراه اسلایدهایش و یک بخش خالی `Appendix` می‌شود. بخش `Results` و اسلایدهای آن حذف شده‌اند.

## **تغییر نام بخش‌ها**

برای تغییر نام یک بخش، متد [Section.setName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#setName) آن را فراخوانی کنید. اسلایدهای بخش و موقعیت آن بدون تغییر باقی می‌مانند.

مثال زیر یک بخش را ایجاد می‌کند و نام آن را تغییر می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **دریافت اسلایدها از بخش‌ها**

متد [Presentation.getSections](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSections) یک [SectionCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectioncollection/) را برمی‌گرداند که می‌توانید بر روی آن تکرار کنید. برای هر [Section](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/)، متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getSlidesListOfSection) را فراخوانی کنید تا اسلایدهایی که در حال حاضر به آن تعلق دارند دریافت شوند. این متد یک [SectionSlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectionslidecollection/) را برمی‌گرداند که شمارش، دسترسی ایندکس‌دار و تکرار را فراهم می‌کند.

مثال زیر دو بخش پرشده و یک بخش خالی ایجاد می‌کند، سپس نام [name](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getName)، شناسه [identifier](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getSectionId)، اسلاید شروع [starting slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getStartedFromSlide)، تعداد اسلایدها و شماره اسلایدهای هر بخش را چاپ می‌کند. از [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectionslidecollection/#get_Item) برای خواندن اولین اسلاید و یک عبارت `for` برای پردازش هر اسلاید استفاده می‌شود. برای بخش خالی، مجموعه برگشتی اندازه صفر دارد، متد فراخوانی نمی‌شود و تکرار هیچ عملی انجام نمی‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

عضویت در بخش توسط ساختار بخش‌های ارائه تعیین می‌شود. محدوده یک بخش را به‌صورت دستی از [Section.getStartedFromSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getStartedFromSlide)، ایندکس‌های اسلاید و اسلاید شروع بخش بعدی محاسبه نکنید.

ویرایش‌های ساختاری می‌توانند هم اسلایدهای برگشتی برای یک بخش و هم شماره اسلایدهای آن را تغییر دهند. این شامل دوباره‌چینش اسلایدها، شبیه‌سازی یک اسلاید در یک بخش، جابه‌جایی یک بخش همراه با اسلایدهایش، حذف اسلایدها و حذف بخش‌ها می‌شود. مثال بعدی پس از هر تغییر این‌چنین متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getSlidesListOfSection) را فراخوانی می‌کند به‌جای این‌که فرض‌های قبلی درباره مرزهای بخش را حفظ کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

هر زمان اسلایدها یا بخش‌ها دوباره‌چینش، شبیه‌سازی، جابه‌جایی یا حذف شدند، دوباره متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getSlidesListOfSection) را فراخوانی کنید. این کار پردازش‌های بعدی را با ساختار جاری ارائه هماهنگ نگه می‌داند.

قالب PPT (PowerPoint 97–2003) متادیتای بخش را حفظ نمی‌کند. از این جریان کار با قالبی که از بخش‌ها پشتیبانی می‌کند، مانند PPTX استفاده کنید؛ تبدیل به PPT ساختار بخش مورد نیاز برای تکرارهای بعدی را حذف می‌کند.

## **پرسش‌های متداول**

**آیا بخش‌ها هنگام ذخیره در قالب PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

نه. قالب PPT از متادیتای بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از دست می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

نه. یک بخش حالت نمایانی ندارد. برای پنهان کردن محتویات آن، برای هر اسلاید در بخش متد [Slide.setHidden](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setHidden) را فراخوانی کنید.

**چگونه می‌توانم بخشی را که شامل یک اسلاید است پیدا کنم؟**

بر روی مجموعه‌ای که توسط [Presentation.getSections](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSections) برگردانده می‌شود تکرار کنید، برای هر بخش متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getSlidesListOfSection) را فراخوانی کنید و اسلایدهای برگشتی را با اسلاید هدف مقایسه کنید. برای یک بخش غیرخالی، [Section.getStartedFromSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/section/#getStartedFromSlide) اولین اسلاید آن را برمی‌گرداند؛ برای یک بخش خالی، `None` برمی‌گرداند.