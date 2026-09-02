---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با JavaScript
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
- دریافت اسلایدهای بخش
- پردازش اسلایدهای بخش
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید با Aspose.Slides برای Node.js از طریق Java: ایجاد، تغییر نام، بازآرایی، دریافت و پردازش اسلایدهای بخش در ارائه‌های PPTX."
---
## **معرفی**

بخش‌ها اسلایدهای متوالی را در گروه‌های نام‌گذاری‌شده سازماندهی می‌کنند بدون تغییر در محتوای اسلاید. با Aspose.Slides برای Node.js از طریق Java، می‌توانید با استفاده از متد [Presentation.getSections](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSections) بخش‌ها را ایجاد، دوباره ترتیب دهید، نام‌گذاری مجدد کنید، بررسی کنید و حذف کنید.

بخش‌ها به‌ویژه زمانی مفید هستند که:

- یک ارائه بزرگ نیاز به تقسیم به موضوعات یا فصول منطقی دارد؛
- گروه‌های مختلفی از اسلایدها به همکاران مختلف اختصاص داده می‌شوند؛
- اسلایدها نیاز به پردازش، جابجا شدن یا ترکیب به‌عنوان گروه‌ها دارند.

نام‌های بخش کوتاه و واضحی انتخاب کنید که هدف اسلایدهای گروه‌بندی‌شده را توصیف کنند. از آنجا که بخش‌ها بخشی از ساختار ارائه هستند، برای تعیین عضویت از APIهای بخش استفاده کنید به‌جای استخراج آن از موقعیت‌های اسلاید.

## **ایجاد و مدیریت بخش‌ها**

از [SectionCollection.addSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectioncollection/#addSection) برای ایجاد یک بخش با مشخص کردن نام و اسلاید شروع استفاده کنید. Aspose.Slides تعیین می‌کند که کدام اسلایدها به بخش تعلق دارند بر اساس ساختار فعلی بخش‌های ارائه.

همین [SectionCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectioncollection/) به شما امکان می‌دهد:

- یک بخش را به همراه اسلایدهایش با استفاده از [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) جابجا کنید؛
- تنها تعریف بخش را با [SectionCollection.removeSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectioncollection/#removeSection) حذف کنید، در حالی که اسلایدهای آن حفظ می‌شوند؛
- یک بخش و اسلایدهای آن را با [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) حذف کنید؛
- یک بخش خالی را در انتها با [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) اضافه کنید.

مثال زیر دو بخش ایجاد می‌کند، یکی از آن‌ها را جابجا می‌نماید، آن را همراه اسلایدهایش حذف می‌کند و یک بخش خالی اضافه می‌کند:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

پس از این عملیات، ارائه شامل بخش `Introduction` به همراه اسلایدهای آن و یک بخش خالی `Appendix` می‌شود. بخش `Results` و اسلایدهای آن حذف شده‌اند.

## **تغییر نام بخش‌ها**

برای تغییر نام یک بخش، متد [Section.setName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#setName) آن را فراخوانی کنید. اسلایدهای بخش و موقعیت آن بدون تغییر باقی می‌مانند.

مثال زیر یک بخش ایجاد می‌کند و نام آن را تغییر می‌دهد:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **دریافت اسلایدها از بخش‌ها**

متد [Presentation.getSections](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSections) یک [SectionCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectioncollection/) را برمی‌گرداند که می‌توانید با ایندکس به آن دسترسی داشته باشید. برای هر [Section](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/)، متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getSlidesListOfSection) را صدا بزنید تا اسلایدهای فعلی تعلق‌دار به آن را به دست آورید. این متد یک [SectionSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectionslidecollection/) را برمی‌گرداند که شمارش و دسترسی بر پایه ایندکس را فراهم می‌کند.

مثال زیر دو بخش پرشده و یک بخش خالی ایجاد می‌کند، سپس نام [name](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getName)، شناسه [identifier](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getSectionId)، اسلاید شروع [starting slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getStartedFromSlide)، شمارش اسلایدها و شماره‌های اسلاید هر بخش را چاپ می‌کند. از [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) برای خواندن هم اسلاید اول و هم هر اسلاید در مجموعه استفاده می‌شود. برای بخش خالی، مجموعه برگشتی اندازه صفر دارد، دسترسی بر پایه ایندکس رد می‌شود و حلقه عملی انجام نمی‌دهد.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

عضویت بخش بر اساس ساختار بخش‌های ارائه تعیین می‌شود. محدوده یک بخش را به‌صورت دستی از [Section.getStartedFromSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getStartedFromSlide)، ایندکس‌های اسلاید و اسلاید شروع بخش بعدی محاسبه نکنید.

ویرایش‌های ساختاری می‌توانند هم اسلایدهای بازگردانده‌شده برای یک بخش و هم شماره‌های اسلاید آن‌ها را تغییر دهند. این شامل بازآرایی اسلایدها، تکثیر یک اسلاید در یک بخش، جابجا کردن یک بخش به همراه اسلایدهای آن، حذف اسلایدها و حذف بخش‌ها می‌شود. مثال بعدی پس از هر تغییر، به جای حفظ فرضیات درباره مرزهای قبلی بخش، متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getSlidesListOfSection) را فراخوانی می‌کند.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

هر زمان اسلایدها یا بخش‌ها بازآرایی، تکثیر، جابجا یا حذف شوند، دوباره متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getSlidesListOfSection) را صدا بزنید. این کار پردازش‌های بعدی را با ساختار فعلی ارائه هم‌راستا نگه می‌دارد.

قالب PPT (PowerPoint 97–2003) متادیتای بخش‌ها را حفظ نمی‌کند. از این جریان کار با قالبی که از بخش‌ها پشتیبانی می‌کند، مانند PPTX، استفاده کنید؛ تبدیل به PPT ساختار بخش را که برای تکرارهای بعدی لازم است، حذف می‌کند.

## **سوالات متداول**

**آیا بخش‌ها هنگام ذخیره در قالب PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. قالب PPT از متادیتای بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از بین می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. یک بخش حالت visibility ندارد. برای پنهان کردن محتویات آن، برای هر اسلاید در بخش، متد [Slide.setHidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#setHidden) را فراخوانی کنید.

**چگونه می‌توانم بخشی که شامل یک اسلاید است را پیدا کنم؟**

به هر بخش در مجموعه‌ای که توسط [Presentation.getSections](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSections) برگردانده می‌شود دسترسی پیدا کنید، برای هر بخش متد [Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getSlidesListOfSection) را صدا بزنید و اسلایدهای برگشتی را با اسلاید هدف مقایسه کنید. برای یک بخش غیرخالی، [Section.getStartedFromSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getStartedFromSlide) اولین اسلاید آن را برمی‌گرداند؛ برای یک بخش خالی، `null` برمی‌گرداند.