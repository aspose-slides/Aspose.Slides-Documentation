---
title: مدیریت بخش‌های اسلاید در ارائه‌ها در .NET
linktitle: بخش اسلاید
type: docs
weight: 100
url: /fa/net/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بهینه‌سازی بخش‌های اسلاید در PowerPoint و OpenDocument با Aspose.Slides برای .NET — تقسیم، تغییر نام و ترتیب‌گذاری مجدد برای بهبود جریان کار PPTX و ODP."
---
## **معرفی**

با Aspose.Slides برای .NET می‌توانید یک ارائه PowerPoint را به بخش‌ها سازماندهی کنید. می‌توانید بخش‌هایی ایجاد کنید که شامل اسلایدهای خاصی باشند.

ممکن است بخواهید در موقعیت‌های زیر بخش‌ها را ایجاد و برای سازماندهی یا تقسیم اسلایدهای یک ارائه به بخش‌های منطقی استفاده کنید:

- زمانی که روی یک ارائه بزرگ با افراد یا تیم دیگری کار می‌کنید و نیاز دارید برخی اسلایدها را به یک همکار یا اعضای تیم اختصاص دهید.  
- زمانی که با ارائه‌ای که شامل اسلایدهای زیادی است سروکار دارید و برای مدیریت یا ویرایش تمام محتوا به‌صورت همزمان با مشکل مواجه می‌شوید.

به‌طور ایده‌آل باید بخشی ایجاد کنید که اسلایدهای مشابه را در خود جای دهد—اسلایدها ویژگی مشترکی داشته باشند یا بر اساس قاعده‌ای بتوانند در یک گروه قرار گیرند—و برای آن بخشی نامی انتخاب کنید که توصیف‌کننده اسلایدهای داخل آن باشد.

## **ایجاد بخش‌ها در ارائه‌ها**

برای افزودن بخشی که اسلایدها را در یک ارائه در خود جای دهد، Aspose.Slides برای .NET متد AddSection را فراهم می‌کند که به شما امکان می‌دهد نام بخشی که قصد ایجاد آن را دارید و اسلایدی که بخش از آن شروع می‌شود را مشخص کنید.

این کد نمونه نشان می‌دهد چگونه در C# یک بخش در یک ارائه ایجاد کنید:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 در newSlide2 پایان می‌یابد و پس از آن section2 شروع می‌شود   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **تغییر نام بخش‌ها**

پس از ایجاد یک بخش در یک ارائه PowerPoint، ممکن است تصمیم بگیرید نام آن را تغییر دهید.

این کد نمونه نشان می‌دهد چگونه نام یک بخش را در یک ارائه با استفاده از Aspose.Slides در C# تغییر دهید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **سوالات متداول**

**آیا بخش‌ها هنگام ذخیره‌سازی به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از فراداده‌های بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از دست می‌رود.

**آیا می‌توان یک بخش کامل را «مخفی» کرد؟**

خیر. فقط اسلایدهای تک‌تک می‌توانند مخفی شوند. یک بخش به عنوان یک واحد حالت «مخفی» ندارد.

**آیا می‌توانم به‌سرعت یک بخش را بر اساس یک اسلاید پیدا کنم و بالعکس، اسلاید اول یک بخش را بیابم؟**

بله. یک بخش به‌صورت منحصربه‌فرد با اسلاید شروع‌کننده‌اش تعریف می‌شود؛ با دانستن یک اسلاید می‌توانید تعیین کنید به کدام بخش تعلق دارد و برای یک بخش می‌توانید به اسلاید اول آن دسترسی پیدا کنید.