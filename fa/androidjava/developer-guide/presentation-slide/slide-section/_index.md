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
- دریافت اسلایدهای بخش
- پردازش اسلایدهای بخش
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید با Aspose.Slides برای اندروید از طریق Java: ایجاد، تغییر نام، دوباره‌چینش، دریافت و پردازش اسلایدهای بخش در ارائه‌های PPTX."
---
## **معرفی**

بخش‌ها اسلایدهای متوالی را در گروه‌های نام‌گذاری‌شده سازماندهی می‌کنند بدون تغییر محتوای اسلاید. با Aspose.Slides برای Android از طریق Java، می‌توانید بخش‌ها را ایجاد، دوباره‌چینش، تغییر نام، بررسی و حذف کنید از طریق متد [Presentation.getSections](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSections--) .

بخش‌ها به‌ویژه وقتی مفید هستند که:

- یک ارائه بزرگ نیاز به تقسیم به موضوعات یا فصل‌های منطقی دارد؛
- گروه‌های مختلف اسلاید به همکاران مختلف اختصاص داده شوند؛
- اسلایدها نیاز به پردازش، جابجایی یا ادغام به‌صورت گروهی داشته باشند.

نام‌های کوتاه و توصیفی برای بخش‌ها انتخاب کنید که هدف اسلایدهای گروه‌بندی‌شده را توضیح دهد. از آنجا که بخش‌ها بخشی از ساختار ارائه هستند، برای تعیین عضویت از APIهای بخش استفاده کنید نه از موقعیت اسلایدها.

## **ایجاد و مدیریت بخش‌ها**

از [ISectionCollection.addSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) برای ایجاد یک بخش با مشخص کردن نام و اسلاید شروع استفاده کنید. Aspose.Slides تعیین می‌کند کدام اسلایدها به بخش تعلق دارند بر اساس ساختار بخش‌های کنونی ارائه.

[ISectionCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectioncollection/) همان‌طور که امکان زیر را می‌دهد:

- یک بخش را به همراه اسلایدهایش با استفاده از [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) جابه‌جا کنید؛
- فقط تعریف بخش را با [ISectionCollection.removeSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) حذف کنید که اسلایدهای آن را نگه می‌دارد؛
- یک بخش و اسلایدهای آن را با [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) حذف کنید؛
- یک بخش خالی در انتها با [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) اضافه کنید.

مثال زیر دو بخش ایجاد می‌کند، یکی از آن‌ها را جابه‌جا می‌کند، همراه با اسلایدهایش حذف می‌کند و یک بخش خالی اضافه می‌کند:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

بعد از این عملیات‌ها، ارائه شامل بخش `Introduction` به همراه اسلایدهای آن و یک بخش خالی `Appendix` می‌شود. بخش `Results` و اسلایدهای آن حذف شده‌اند.

## **تغییر نام بخش‌ها**

برای تغییر نام یک بخش، متد [ISection.setName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) آن را فراخوانی کنید. اسلایدهای بخش و موقعیت آن بدون تغییر باقی می‌مانند.

مثال زیر یک بخش ایجاد کرده و نام آن را تغییر می‌دهد:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **دریافت اسلایدها از بخش‌ها**

متد [Presentation.getSections](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSections--) یک [ISectionCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectioncollection/) برمی‌گرداند که می‌توانید روی آن تکرار کنید. برای هر [ISection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/) متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) را فراخوانی کنید تا اسلایدهای فعلی آن را دریافت کنید. این متد یک [ISectionSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectionslidecollection/) برمی‌گرداند که شمارش، دسترسی ایندکسی و تکرار را فراهم می‌کند.

مثال زیر دو بخش پرشده و یک بخش خالی ایجاد می‌کند، سپس برای هر بخش نام، شناسه، اسلاید شروع، شمارش اسلاید و شماره اسلایدها را چاپ می‌کند. برای خواندن اولین اسلاید از [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) استفاده می‌شود و از یک حلقه `for` پیشرفته برای پردازش همه اسلایدها بهره می‌گیرد. برای بخش خالی، مجموعه بازگشتی اندازه صفر دارد، متد فراخوانی نمی‌شود و تکرار هیچ عملی انجام نمی‌دهد.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

عضویت در بخش توسط ساختار بخش‌های ارائه تعیین می‌شود. بازه یک بخش را به‌صورت دستی از [ISection.getStartedFromSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) ، ایندکس‌های اسلاید و اسلاید شروع بخش بعدی محاسبه نکنید.

ویرایش‌های ساختاری می‌توانند هم اسلایدهای بازگشتی برای یک بخش و هم شماره اسلایدهای آن‌ها را تغییر دهند. این شامل دوباره‌چینش اسلایدها، کلون کردن یک اسلاید به داخل یک بخش، جابه‌جایی یک بخش همراه اسلایدهایش، حذف اسلایدها و حذف بخش‌ها می‌شود. مثال بعدی پس از هر چنین تغییری متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) را صدا می‌زند به‌جای اینکه فرضیات قبلی درباره مرزهای بخش را حفظ کند.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

هر زمان که اسلایدها یا بخش‌ها دوباره‌چینش، کلون، جابه‌جا یا حذف شوند، مجدداً متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) را فراخوانی کنید. این کار پردازش‌های بعدی را با ساختار جاری ارائه هماهنگ نگه می‌دارد.

فرمت PPT (PowerPoint 97–2003) متادیتای بخش‌ها را حفظ نمی‌کند. این جریان کار را با فرمت‌هایی که از بخش‌ها پشتیبانی می‌کنند، مانند PPTX، استفاده کنید؛ تبدیل به PPT ساختار بخش‌ها را که برای تکرارهای بعدی لازم است، حذف می‌کند.

## **سوالات متداول**

**آیا بخش‌ها هنگام ذخیره به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT متادیتای بخش‌ها را پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از دست می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. یک بخش وضعیت نمایانی ندارد. برای پنهان کردن محتویات آن، برای هر اسلاید در بخش متد [ISlide.setHidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#setHidden-boolean-) را صدا بزنید.

**چگونه می‌توانم بخش حاوی یک اسلاید را پیدا کنم؟**

بر روی مجموعه‌ای که توسط [Presentation.getSections](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSections--) برگردانده می‌شود تکرار کنید، برای هر بخش متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) را فراخوانی کنید و اسلایدهای بازگردانده‌شده را با اسلاید هدف مقایسه کنید. برای یک بخش غیرخالی، [ISection.getStartedFromSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) اولین اسلاید آن را برمی‌گرداند؛ برای یک بخش خالی، `null` برمی‌گرداند.