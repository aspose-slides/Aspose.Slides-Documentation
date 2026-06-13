---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با استفاده از JavaScript
linktitle: بخش اسلاید
type: docs
weight: 90
url: /fa/nodejs-java/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بهینه‌سازی بخش‌های اسلاید در PowerPoint و OpenDocument با Aspose.Slides برای Node.js — تقسیم، تغییر نام و ترتیب‌دهی مجدد برای بهبود گردش کار PPTX و ODP."
---
## **مقدمه**

با Aspose.Slides برای Node.js از طریق Java می‌توانید یک ارائه PowerPoint را به بخش‌ها تقسیم کنید. می‌توانید بخش‌هایی ایجاد کنید که شامل اسلایدهای خاصی باشند.

ممکن است بخواهید بخش‌ها را ایجاد کنید و از آن‌ها برای سازماندهی یا تقسیم اسلایدهای یک ارائه به قسمت‌های منطقی در این موارد استفاده کنید:

- هنگامی که روی یک ارائه بزرگ با دیگران یا یک تیم کار می‌کنید و نیاز دارید برخی اسلایدها را به همکار یا برخی اعضای تیم اختصاص دهید.  
- هنگامی که با یک ارائه حاوی اسلایدهای بسیار زیاد سرو کار دارید و در مدیریت یا ویرایش محتوای آن به صورت کلی دچار مشکل می‌شوید.

در ایده‌آل، باید یک بخشی ایجاد کنید که اسلایدهای مشابه را در خود جای دهد — اسلایدها چیزی مشترک دارند یا می‌توانند بر اساس یک قانون در یک گروه قرار بگیرند — و برای آن بخش نامی انتخاب کنید که اسلایدهای داخل آن را توصیف کند.

## **ایجاد بخش‌ها در ارائه‌ها**

برای افزودن بخشی که اسلایدها را در یک ارائه در بر می‌گیرد، Aspose.Slides برای Node.js از طریق Java متد [addSection()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) را فراهم می‌کند که به شما امکان می‌دهد نام بخشی که قصد ایجاد آن را دارید و اسلایدی که بخش از آن آغاز می‌شود را مشخص کنید.

این کد نمونه نشان می‌دهد چگونه در JavaScript یک بخش در یک ارائه ایجاد کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 در newSlide2 پایان می‌یابد و پس از آن section2 شروع می‌شود
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر نام بخش‌ها**

پس از ایجاد یک بخش در یک ارائه PowerPoint، ممکن است تصمیم بگیرید نام آن را تغییر دهید.

این کد نمونه نشان می‌دهد چگونه با استفاده از Aspose.Slides در JavaScript نام یک بخش در یک ارائه را تغییر دهید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا بخش‌ها هنگام ذخیره در فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از متادیتای بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از دست می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. فقط می‌توان اسلایدهای فردی را پنهان کرد. یک بخش به عنوان یک موجودیت وضعیت «پنهان» ندارد.

**آیا می‌توانم به سرعت یک بخش را با یک اسلاید پیدا کنم و بالعکس، اولین اسلاید یک بخش را پیدا کنم؟**

بله. یک بخش به‌طور یکتا توسط اسلاید شروع‌کننده‌اش تعریف می‌شود؛ با داشتن یک اسلاید می‌توانید تعیین کنید که به کدام بخش تعلق دارد و برای یک بخش می‌توانید به اولین اسلاید آن دسترسی پیدا کنید.