---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با استفاده از C++
linktitle: بخش اسلاید
type: docs
weight: 100
url: /fa/cpp/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "بخش‌های اسلاید را در PowerPoint و OpenDocument با Aspose.Slides برای C++ بهینه کنید — تقسیم، تغییر نام و بازچینش برای بهبود جریان کار فایل‌های PPTX و ODP."
---
## **مقدمه**

با Aspose.Slides برای C++ می‌توانید یک ارائه PowerPoint را به بخش‌ها سازماندهی کنید. می‌توانید بخش‌هایی را ایجاد کنید که اسلایدهای خاصی را شامل می‌شوند.

ممکن است بخواهید بخش‌هایی ایجاد کنید و از آن‌ها برای سازماندهی یا تقسیم اسلایدهای یک ارائه به بخش‌های منطقی در این شرایط استفاده کنید:

- هنگامی که بر روی یک ارائه بزرگ با افراد دیگر یا یک تیم کار می‌کنید—و نیاز دارید اسلایدهای خاصی را به همکار یا برخی اعضای تیم اختصاص دهید. 
- هنگامی که با ارائه‌ای که دارای اسلایدهای بسیاری است سروکار دارید—و در مدیریت یا ویرایش محتوای آن به‌صورت یک‌جا دچار مشکل می‌شوید.

به‌طور ایده‌آل باید بخشی ایجاد کنید که اسلایدهای مشابه را در خود جای دهد—اسلایدها ویژگی مشترکی دارند یا می‌توانند بر اساس یک قانون در یک گروه قرار بگیرند—و به آن بخش نامی بدهید که اسلایدهای داخل آن را توصیف کند. 

## **ایجاد بخش‌ها در ارائه‌ها**

برای افزودن بخشی که اسلایدها را در یک ارائه در خود جای دهد، Aspose.Slides برای C++ متد AddSection را ارائه می‌دهد که به شما امکان می‌دهد نام بخشی که قصد ایجاد آن را دارید و اسلایدی که بخش از آن شروع می‌شود را مشخص کنید. 

این کد نمونه نشان می‌دهد چگونه در یک ارائه به زبان C++ یک بخش ایجاد کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 در newSlide2 پایان خواهد یافت و پس از آن section2 شروع خواهد شد   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **تغییر نام بخش‌ها**

پس از ایجاد یک بخش در ارائه PowerPoint، ممکن است تصمیم بگیرید نام آن را تغییر دهید. 

این کد نمونه نشان می‌دهد چگونه نام یک بخش را در یک ارائه به زبان C++ با استفاده از Aspose.Slides تغییر دهید:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **سوالات متداول**

**آیا بخش‌ها هنگام ذخیره در فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از متادیتای بخش پشتیبانی نمی‌کند، به‌طوری که گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از بین می‌روند.

**آیا می‌توان یک بخش کامل را «مخفی» کرد؟**

خیر. فقط اسلایدهای منفرد می‌توانند مخفی شوند. یک بخش به عنوان یک موجودیت وضعیت «مخفی» ندارد.

**آیا می‌توانم به‌سرعت یک بخش را بر اساس اسلاید پیدا کنم و بالعکس، اولین اسلاید یک بخش را بدست آورم؟**

بله. یک بخش به‌ طور یکتا توسط اسلاید شروع آن تعریف می‌شود؛ با دانستن یک اسلاید می‌توانید بخش مربوطه را مشخص کنید و برای یک بخش می‌توانید به اولین اسلاید آن دسترسی پیدا کنید.