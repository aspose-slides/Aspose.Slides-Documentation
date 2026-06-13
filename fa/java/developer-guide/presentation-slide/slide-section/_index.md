---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با استفاده از جاوا
linktitle: بخش اسلاید
type: docs
weight: 90
url: /fa/java/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "بخش‌های اسلاید را در PowerPoint و OpenDocument با Aspose.Slides برای Java به‌صورت یکپارچه کنید — تقسیم، تغییر نام و ترتیب مجدد برای بهینه‌سازی جریان کار PPTX و ODP."
---
## **مقدمه**

با Aspose.Slides for Java می‌توانید یک ارائه PowerPoint را به بخش‌ها سازماندهی کنید. می‌توانید بخش‌هایی ایجاد کنید که شامل اسلایدهای خاصی باشند.

ممکن است بخواهید بخش‌ها را ایجاد کنید و از آن‌ها برای سازماندهی یا تقسیم اسلایدها در یک ارائه به بخش‌های منطقی در این موقعیت‌ها استفاده کنید:

- وقتی روی یک ارائه بزرگ با افراد دیگر یا یک تیم کار می‌کنید — و نیاز دارید برخی اسلایدها را به همکار یا اعضای تیم اختصاص دهید. 
- وقتی با ارائه‌ای که شامل اسلایدهای زیادی است سرو کار دارید — و برای مدیریت یا ویرایش محتوای آن به‌صورت یکباره دچار مشکل می‌شوید.

در حالت ایده‌آل باید بخشی ایجاد کنید که اسلایدهای مشابه را در خود جای دهد — اسلایدها ویژگی مشترکی دارند یا می‌توانند بر اساس یک قاعده در یک گروه قرار گیرند — و به آن بخش یک نام بدهید که اسلایدهای داخل آن را توصیف کند.

## **ایجاد بخش‌ها در ارائه‌ها**

برای افزودن بخشی که اسلایدها را در یک ارائه در خود جای دهد، Aspose.Slides for Java روش [addSection()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) را فراهم می‌کند که به شما امکان می‌دهد نام بخشی که قصد ایجاد آن را دارید و اسلایدی که بخش از آن شروع می‌شود، مشخص کنید.

این کد نمونه نشان می‌دهد چگونه در یک ارائه در Java یک بخش ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // بخش 1 در اسلاید newSlide2 پایان می‌یابد و پس از آن بخش 2 آغاز می‌شود   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر نام بخش‌ها**

پس از ایجاد یک بخش در یک ارائه PowerPoint، ممکن است تصمیم بگیرید نام آن را تغییر دهید.

این کد نمونه نشان می‌دهد چگونه نام یک بخش را در یک ارائه در Java با استفاده از Aspose.Slides تغییر دهید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا بخش‌ها هنگام ذخیره‌سازی به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از متادیتای بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از بین می‌رود.

**آیا می‌توان یک کل بخش را "پنهان" کرد؟**

خیر. فقط اسلایدهای منفرد می‌توانند پنهان شوند. یک بخش به‌عنوان موجودیت حالت "پنهان" ندارد.

**آیا می‌توانم به‌سرعت یک بخش را بر اساس اسلاید پیدا کنم و بالعکس، اولین اسلاید یک بخش را؟**

بله. یک بخش به‌طور یکتا توسط اسلاید آغازین خود تعریف می‌شود؛ با داشتن یک اسلاید می‌توانید تشخیص دهید به کدام بخش تعلق دارد، و برای یک بخش می‌توانید به اولین اسلاید آن دسترسی داشته باشید.