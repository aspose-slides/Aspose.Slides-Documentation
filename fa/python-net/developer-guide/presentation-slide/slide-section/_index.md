---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با پایتون
linktitle: بخش اسلاید
type: docs
weight: 100
url: /fa/python-net/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "بهینه‌سازی بخش‌های اسلاید در پاورپوینت و OpenDocument با Aspose.Slides برای پایتون — تقسیم، تغییر نام و ترتیب‌گذاری مجدد برای بهبود جریان کار PPTX و ODP."
---
## **مقدمه**

با Aspose.Slides برای Python می‌توانید یک ارائه PowerPoint را به بخش‌هایی که اسلایدهای خاصی را گروه‌بندی می‌کنند، سازماندهی کنید.

ممکن است بخواهید برای سازماندهی یا تقسیم یک ارائه به بخش‌های منطقی، در این موقعیت‌ها بخش‌ها را ایجاد کنید:

- وقتی بر روی یک ارائه بزرگ با تیم کار می‌کنید و نیاز دارید برخی اسلایدها را به همکاران خاصی اختصاص دهید.
- وقتی با ارائه‌ای که شامل اسلایدهای زیادی است سروکار دارید و مدیریت یا ویرایش همهٔ آنها به‌صورت همزمان برایتان دشوار است.

در ایده‌آل، بخش‌هایی ایجاد کنید که اسلایدهای مرتبط را—اسلایدهایی که تم، موضوع یا هدف مشترکی دارند—گروه‌بندی می‌کند و برای هر بخش نامی انتخاب کنید که به‌وضوح محتوای آن را بازتاب دهد. 

## **ایجاد بخش‌ها در ارائه‌ها**

برای اضافه کردن یک [Section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/) که اسلایدها را در یک ارائه گروه‌بندی می‌کند، Aspose.Slides متد [add_section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectioncollection/add_section/) را فراهم می‌کند. این متد به شما امکان می‌دهد نام بخش و اسلایدی که بخش از آن شروع می‌شود را مشخص کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه یک بخش در یک ارائه ایجاد کنید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # بخش 1 در اسلاید۲ پایان می‌یابد؛ بخش 2 در اسلاید۳ شروع می‌شود.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **تغییر نام بخش‌ها**

پس از ایجاد یک [Section](https://reference.aspose.com/slides/fa/python-net/aspose.slides/section/) در یک ارائه PowerPoint، ممکن است تصمیم به تغییر نام آن بگیرید.

مثال زیر به زبان Python نشان می‌دهد چگونه نام یک بخش را در یک ارائه تغییر دهید:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **سؤالات متداول**

**آیا بخش‌ها هنگام ذخیره به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از فرادادهٔ بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از دست می‌روند.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. تنها اسلایدهای منفرد می‌توانند پنهان شوند. یک بخش به‌عنوان یک موجودیت حالت «پنهان» ندارد.

**آیا می‌توانم به‌سرعت یک بخش را با یک اسلاید پیدا کنم و برعکس، اولین اسلاید یک بخش را بیابم؟**

بله. یک بخش به‌طور یکتا توسط اسلاید شروع‌ آن تعریف می‌شود؛ با دانستن یک اسلاید می‌توانید تعیین کنید به کدام بخش تعلق دارد، و برای یک بخش می‌توانید اسلاید اول آن را دریافت کنید.