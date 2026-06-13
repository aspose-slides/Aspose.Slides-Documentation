---
title: مدیریت بخش‌های اسلاید در ارائه‌ها در اندروید
linktitle: بخش اسلاید
type: docs
weight: 90
url: /fa/androidjava/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "بهینه‌سازی بخش‌های اسلاید در PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java - تقسیم، تغییر نام و ترتیب‌بندی مجدد برای بهبود جریان کاری PPTX و ODP."
---
## **Introduction**

با Aspose.Slides for Android via Java می‌توانید یک ارائه PowerPoint را به بخش‌ها سازماندهی کنید. می‌توانید بخش‌هایی ایجاد کنید که اسلایدهای خاصی را شامل می‌شوند.

ممکن است بخواهید در این موقعیت‌ها بخش‌ها را ایجاد کنید و از آن‌ها برای سازماندهی یا تقسیم اسلایدها در یک ارائه به بخش‌های منطقی استفاده کنید:

- زمانی که روی یک ارائه بزرگ با دیگران یا یک تیم کار می‌کنید و نیاز دارید برخی اسلایدها را به همکار یا اعضای تیم اختصاص دهید.  
- زمانی که با ارائه‌ای که حاوی اسلایدهای زیادی است سروکار دارید و در مدیریت یا ویرایش همزمان محتویات آن مشکل دارید.

در حالت ایده‌آل، باید بخشی ایجاد کنید که اسلایدهای مشابه را در خود جای دهد — اسلایدها چیزی مشترک دارند یا می‌توانند براساس یک قانون در یک دسته قرار بگیرند — و برای آن بخش نامی بگذارید که اسلایدهای داخل آن را توصیف کند.

## **Create Sections in Presentations**

برای افزودن بخشی که اسلایدها را در یک ارائه نگه می‌دارد، Aspose.Slides for Android via Java متد [addSection()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) را فراهم می‌کند که به شما امکان می‌دهد نام بخشی که قصد ایجاد آن را دارید و اسلایدی که بخش از آن شروع می‌شود، مشخص کنید.

این کد نمونه نشان می‌دهد که چگونه در Java یک بخش در یک ارائه ایجاد کنید:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 در newSlide2 پایان می‌یابد و پس از آن section2 شروع می‌شود   

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

## **Change the Names of Sections**

پس از ایجاد یک بخش در ارائه PowerPoint، ممکن است تصمیم بگیرید نام آن را تغییر دهید.

این کد نمونه نشان می‌دهد که چگونه نام یک بخش را در یک ارائه با Java و استفاده از Aspose.Slides تغییر دهید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**آیا بخش‌ها هنگام ذخیره‌سازی به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از متادادهٔ بخش‌ها پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از دست می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. تنها اسلایدهای تک‌تک می‌توانند پنهان شوند. یک بخش به عنوان یک موجودیت حالت «پنهان» ندارد.

**آیا می‌توانم به سرعت یک بخش را از طریق اسلاید پیدا کنم و بالعکس، اولین اسلاید یک بخش را بدست آورم؟**

بله. یک بخش به‌صورت یکتا توسط اسلاید آغازینش تعریف می‌شود؛ با داشتن یک اسلاید می‌توانید تشخیص دهید به کدام بخش تعلق دارد و برای یک بخش می‌توانید به اولین اسلاید آن دسترسی پیدا کنید.