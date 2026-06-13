---
title: مدیریت بالا و پایین‌نویس در ارائه‌ها با PHP
linktitle: بالا و پایین‌نویس
type: docs
weight: 80
url: /fa/php-java/superscript-and-subscript/
keywords:
- بالا‌نویس
- پایین‌نویس
- افزودن بالا‌نویس
- افزودن پایین‌نویس
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "در Aspose.Slides برای PHP از طریق Java، بر پردازش بالا و پایین‌نویس مسلط شوید و ارائه‌های خود را با قالب‌بندی متن حرفه‌ای برای حداکثر تاثیر ارتقاء دهید."
---
## **بررسی کلی**

Aspose.Slides ویژگی‌هایی برای ادغام متن بالا و پایین‌نویس (superscript و subscript) در ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) شما فراهم می‌کند. چه بخواهید فرمول‌های شیمیایی، معادلات ریاضی را برجسته کنید یا محتوا را با پاورنوت‌ها توضیح دهید، این گزینه‌های قالب‌بندی تخصصی به حفظ وضوح و دقت کمک می‌کند. در این مقاله، نحوه اعمال بدون درز سبک‌های بالا و پایین‌نویس را یاد می‌گیرید و نتایج حرفه‌ای در هر اسلاید تضمین می‌شود.

## **مدیریت متن بالا و پایین‌نویس**
می‌توانید متن بالا یا پایین‌نویس را در هر بخش پاراگراف اضافه کنید. برای افزودن متن Superscript یا Subscript در قاب متن Aspose.Slides باید از متد [**setEscapement**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setEscapement) کلاس [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PortionFormat) استفاده کنید.

این ویژگی مقدار متن بالا یا پایین‌نویس را برمی‌گرداند یا تنظیم می‌کند (مقدار از -100٪ (پایین‌نویس) تا 100٪ (بالا‌نویس)). برای مثال:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را با استفاده از Index آن به دست آورید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) از نوع [Rectangle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ShapeType#Rectangle) را به اسلاید اضافه کنید.
- به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) دسترسی پیدا کنید.
- پاراگراف‌های موجود را پاک کنید.
- یک شیء پاراگراف جدید برای نگهداری متن بالا‌نویس ایجاد کنید و آن را به [IParagraphs collection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParagraphs) از [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) اضافه کنید.
- یک شیء portion جدید ایجاد کنید.
- ویژگی Escapement را برای portion بین 0 تا 100 تنظیم کنید تا بالا‌نویس اضافه شود. (0 به معنای عدم وجود بالا‌نویس)
- متنی برای [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Portion) تنظیم کنید و سپس آن را به مجموعه portionهای پاراگراف اضافه کنید.
- یک شیء پاراگراف جدید برای نگهداری متن پایین‌نویس ایجاد کنید و آن را به IParagraphs collection از ITextFrame اضافه کنید.
- یک شیء portion جدید ایجاد کنید.
- برای افزودن پایین‌نویس، ویژگی Escapement را برای portion بین 0 تا -100 تنظیم کنید. (0 به معنای عدم وجود پایین‌نویس)
- متنی برای [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Portion) تنظیم کنید و سپس آن را به مجموعه portionهای پاراگراف اضافه کنید.
- ارائه را به عنوان فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در زیر ارائه شده است.

```php
  # نمونه‌ای از کلاس Presentation که یک فایل PPTX را نشان می‌دهد
  $pres = new Presentation();
  try {
    # دریافت اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # ایجاد جعبه متن
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # ایجاد پاراگراف برای متن بالا‌نویس
    $superPar = new Paragraph();
    # ایجاد بخش (portion) با متن عادی
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # ایجاد بخش با متن بالا‌نویس
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # ایجاد پاراگراف برای متن پایین‌نویس
    $paragraph2 = new Paragraph();
    # ایجاد بخش با متن عادی
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # ایجاد بخش با متن پایین‌نویس
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # افزودن پاراگراف‌ها به جعبه متن
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا بالا‌نویس و پایین‌نویس هنگام صادرات به PDF یا فرمت‌های دیگر حفظ می‌شوند؟**

بله، Aspose.Slides قالب‌بندی بالا‌نویس و پایین‌نویس را به‌درستی هنگام صادرات ارائه‌ها به PDF، PPT/PPTX، تصاویر و سایر فرمت‌های پشتیبانی‌شده حفظ می‌کند. این قالب‌بندی تخصصی در تمام فایل‌های خروجی ثابت می‌ماند.

**آیا می‌توان بالا‌نویس و پایین‌نویس را با سبک‌های قالب‌بندی دیگر مانند بولد یا ایتالیک ترکیب کرد؟**

بله، Aspose.Slides به شما امکان می‌دهد سبک‌های مختلف متن را در یک بخش متن ترکیب کنید. می‌توانید بولد، ایتالیک، زیرخط را فعال کنید و به‌طور همزمان بالا‌نویس یا پایین‌نویس را با تنظیم ویژگی‌های مربوطه در [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) اعمال کنید.

**آیا قالب‌بندی بالا‌نویس و پایین‌نویس برای متنی که داخل جدول‌ها، نمودارها یا SmartArt قرار دارد کار می‌کند؟**

بله، Aspose.Slides قالب‌بندی را در اکثر اشیاء، از جمله جدول‌ها و عناصر نمودارها پشتیبانی می‌کند. هنگام کار با SmartArt، باید به عناصر مناسب (مانند [SmartArtNode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/)) و کانتینرهای متنی آن‌ها دسترسی پیدا کنید و سپس ویژگی‌های [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) را به‌صورت مشابه تنظیم کنید.