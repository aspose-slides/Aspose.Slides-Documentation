---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با PHP
linktitle: بخش اسلاید
type: docs
weight: 90
url: /fa/php-java/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "بخش‌های اسلاید را در PowerPoint و OpenDocument با Aspose.Slides برای PHP via Java بهینه کنید — تقسیم، تغییر نام و ترتیب مجدد برای بهینه‌سازی گردش کارهای PPTX و ODP."
---
## **مقدمه**

با Aspose.Slides for PHP via Java می‌توانید یک ارائهٔ PowerPoint را به بخش‌ها سازماندهی کنید. شما می‌توانید بخش‌هایی ایجاد کنید که اسلایدهای خاصی را در بر می‌گیرند.

ممکن است در این شرایط بخواهید بخش‌ها ایجاد کنید و از آن‌ها برای سازماندهی یا تقسیم اسلایدها در یک ارائه به قسمت‌های منطقی استفاده کنید:

- وقتی در حال کار بر روی یک ارائهٔ بزرگ با دیگران یا یک تیم هستید و نیاز دارید اسلایدهای خاصی را به همکار یا برخی اعضای تیم اختصاص دهید.  
- وقتی با ارائه‌ای که شامل اسلایدهای بسیاری است مواجه هستید و برای مدیریت یا ویرایش محتوای آن به طور همزمان دچار مشکل می‌شوید.

به‌طور ایده‌آل باید یک بخش ایجاد کنید که اسلایدهای مشابه را در خود جای دهد—اسلایدها چیزی مشترک دارند یا می‌توانند بر پایهٔ یک قانون در یک گروه قرار گیرند—و برای بخش نامی انتخاب کنید که توصیف‌کنندهٔ اسلایدهای داخل آن باشد.

## **ایجاد بخش‌ها در ارائه‌ها**

برای افزودن بخشی که اسلایدها را در یک ارائه دربر گیرد، Aspose.Slides for PHP via Java متد [addSection()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sectioncollection/#addSection) را فراهم می‌کند که به شما امکان می‌دهد نام بخشی که قصد ایجاد آن را دارید و اسلایدی که بخش از آن شروع می‌شود را مشخص کنید.

این کد نمونه نشان می‌دهد چگونه یک بخش در یک ارائه ایجاد کنید :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// بخش 1 در اسلاید newSlide2 پایان می‌یابد و پس از آن بخش 2 شروع می‌شود

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر نام بخش‌ها**

پس از ایجاد یک بخش در یک ارائهٔ PowerPoint، ممکن است تصمیم بگیرید نام آن را تغییر دهید.

این کد نمونه نشان می‌دهد چگونه نام یک بخش را در یک ارائه با استفاده از Aspose.Slides تغییر دهید :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا بخش‌ها هنگام ذخیره‌سازی به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از متادیتای بخش‌ها پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به‌صورت .ppt از دست می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. فقط اسلایدهای جداگانه می‌توانند پنهان شوند. یک بخش به عنوان یک موجودیت وضعیت «پنهان» ندارد.

**آیا می‌توانم به‌سرعت یک بخش را بر اساس یک اسلاید پیدا کنم و برعکس، اولین اسلاید یک بخش را پیدا کنم؟**

بله. یک بخش به‌طور یکتا توسط اسلاید شروع‌کنندهٔ آن تعریف می‌شود؛ با داشتن یک اسلاید می‌توانید تشخیص دهید به کدام بخش متعلق است و برای یک بخش می‌توانید به اولین اسلاید آن دسترسی پیدا کنید.