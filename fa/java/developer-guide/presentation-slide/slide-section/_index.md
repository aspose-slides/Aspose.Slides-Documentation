---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با جاوا
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
- استخراج اسلایدهای بخش
- پردازش اسلایدهای بخش
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید با Aspose.Slides برای جاوا: ایجاد، تغییر نام، بازآرایی، استخراج و پردازش اسلایدهای بخش در ارائه‌های PPTX."
---
## **معرفی**

بخش‌ها اسلایدهای متوالی را بدون تغییر محتوای اسلاید به گروه‌های نام‌دار سازماندهی می‌کنند. با Aspose.Slides برای Java، می‌توانید بخش‌ها را از طریق متد [Presentation.getSections](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSections--) ایجاد، بازآرایی، تغییر نام، بازرسی و حذف کنید.

بخش‌ها به‌ویژه زمانی مفید هستند که:

- یک ارائه بزرگ نیاز به تقسیم به موضوعات یا فصول منطقی دارد؛
- گروه‌های مختلفی از اسلایدها به مشارکت‌کنندگان مختلف اختصاص داده می‌شوند؛
- اسلایدها باید به‌عنوان گروه پردازش، جابه‌جا یا ادغام شوند.

نام‌های بخش را به‌صورت مختصر انتخاب کنید که هدف اسلایدهای گروه‌بندی‌شده را توصیف کند. چون بخش‌ها بخشی از ساختار ارائه هستند، برای تعیین عضویت از APIهای بخش استفاده کنید نه از موقعیت اسلایدها.

## **ایجاد و مدیریت بخش‌ها**

از [ISectionCollection.addSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) برای ایجاد یک بخش با تعیین نام و اسلاید شروع استفاده کنید. Aspose.Slides اسلایدهای متعلق به بخش را بر اساس ساختار فعلی بخش‌های ارائه تعیین می‌کند.

[ ISectionCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectioncollection/) همان‌طور که امکان زیر را می‌دهد:

- جابه‌جایی یک بخش همراه با اسلایدهای آن با استفاده از [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- حذف تنها تعریف بخش با [ISectionCollection.removeSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-)، که اسلایدهای آن را نگه می‌دارد;
- حذف یک بخش به همراه اسلایدهای آن با [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- افزودن یک بخش خالی در انتها با [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

مثال زیر دو بخش ایجاد می‌کند، یکی از آن‌ها را جابه‌جا می‌کند، همراه با اسلایدهایش حذف می‌کند و یک بخش خالی اضافه می‌نماید:

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

پس از این عملیات‌ها، ارائه شامل بخش `Introduction` همراه با اسلایدهای آن و یک بخش خالی `Appendix` می‌شود. بخش `Results` و اسلایدهای آن حذف شده‌اند.

## **تغییر نام بخش‌ها**

برای تغییر نام یک بخش، متد [ISection.setName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#setName-java.lang.String-) آن را فراخوانی کنید. اسلایدهای بخش و موقعیت آن بدون تغییر باقی می‌مانند.

مثال زیر یک بخش ایجاد می‌کند و نام آن را تغییر می‌دهد:

```java
import com.aspose.slides.ISection;
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

متد [Presentation.getSections](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSections--) یک [ISectionCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectioncollection/) را باز می‌گرداند که می‌توانید روی آن تکرار کنید. برای هر [ISection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/) متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#getSlidesListOfSection--) را صدا بزنید تا اسلایدهایی که در حال حاضر به آن تعلق دارند دریافت شود. این متد یک [ISectionSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectionslidecollection/) را برمی‌گرداند که شمارش، دسترسی ایندکس‌دار و تکرار را فراهم می‌کند.

مثال زیر دو بخش پر شده و یک بخش خالی ایجاد می‌کند، سپس نام هر بخش، شناسه، اسلاید شروع، تعداد اسلاید و شماره اسلایدها را چاپ می‌کند. برای خواندن اولین اسلاید از [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) استفاده می‌شود و یک عبارت `for` پیشرفته برای پردازش هر اسلاید به کار می‌رود. برای بخش خالی، مجموعه بازگردانده شده اندازه صفر دارد، متد صدا زده نمی‌شود و تکرار عملی انجام نمی‌دهد.

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

عضویت در بخش توسط ساختار بخش‌های ارائه تعیین می‌شود. محدوده یک بخش را به‌صورت دستی از [ISection.getStartedFromSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#getStartedFromSlide--)، اندیس‌های اسلاید و اسلاید شروع بخش بعدی محاسبه نکنید.

ویرایش‌های ساختاری می‌توانند هم اسلایدهای بازگردانده‌شده برای یک بخش و هم شماره اسلایدهای آن را تغییر دهند. این شامل بازآرایی اسلایدها، کلون کردن اسلاید در یک بخش، جابه‌جایی یک بخش همراه با اسلایدهایش، حذف اسلایدها و حذف بخش‌ها می‌شود. مثال بعدی پس از هر چنین تغییری متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#getSlidesListOfSection--) را فراخوانی می‌کند به‌جای اینکه فرضیات درباره مرزهای قبلی بخش حفظ شود.

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

هر زمان که اسلایدها یا بخش‌ها بازآرایی، کلون، جابه‌جا یا حذف شوند، دوباره متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#getSlidesListOfSection--) را صدا بزنید. این کار پردازش‌های بعدی را با ساختار فعلی ارائه هم‌راستا نگه می‌دارد.

قالب PPT (PowerPoint 97–2003) متادیتای بخش را حفظ نمی‌کند. این گردش کار را با فرمتی استفاده کنید که از بخش‌ها پشتیبانی می‌کند، مانند PPTX؛ تبدیل به PPT ساختار بخش را که برای تکرارهای بعدی لازم است، حذف می‌کند.

## **سوالات متداول**

**آیا بخش‌ها هنگام ذخیره‌سازی به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. قالب PPT متادیتای بخش را پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به *.ppt* از دست می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. یک بخش وضعیت قابل مشاهده ندارد. برای مخفی کردن محتویات آن، برای هر اسلاید در بخش متد [ISlide.setHidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#setHidden-boolean-) را فراخوانی کنید.

**چگونه می‌توانم بخش حاوی یک اسلاید را پیدا کنم؟**

بر روی مجموعه‌ای که توسط [Presentation.getSections](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSections--) بازگردانده می‌شود، تکرار کنید، برای هر بخش متد [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#getSlidesListOfSection--) را صدا بزنید و اسلایدهای بازگردانده‌شده را با اسلاید هدف مقایسه کنید. برای یک بخش غیرخالی، [ISection.getStartedFromSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#getStartedFromSlide--) اولین اسلاید آن را برمی‌گرداند؛ برای یک بخش خالی، `null` برمی‌گرداند.