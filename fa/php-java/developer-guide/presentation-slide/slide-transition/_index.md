---
title: مدیریت انتقال اسلایدها در ارائه‌ها با استفاده از PHP
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/php-java/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال پیشرفته اسلاید
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "کشف نحوه شخصی‌سازی انتقال اسلایدها در Aspose.Slides برای PHP از طریق Java، با راهنمایی گام به گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه انتقال اسلایدها را در ارائه‌ها با استفاده از Aspose.Slides مدیریت کنیم. این مقاله نشان می‌دهد چگونه انواع انتقال را به اسلایدها اعمال کنیم، رفتار انتقال را مانند پیشروی با کلیک یا پس از زمان مشخص تنظیم کنیم، پیشروی خودکار را بررسی و غیرفعال کنیم، از انتقال Morph و انواع آن استفاده کنیم، و گزینه‌های اثر انتقال را تنظیم کنیم. مثال‌ها نشان می‌دهند چگونه یک ارائه را بارگذاری یا ایجاد کنیم، تنظیمات انتقال اسلایدهای انتخاب‌شده را تغییر دهیم، و نتیجه را به‌صورت فایل PPTX ذخیره کنیم. مقاله همچنین به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال همان انتقال به چندین اسلاید، و بررسی انتقال فعلی تنظیم‌شده بر روی اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.  
1. یک نوع انتقال اسلاید را بر روی اسلاید از میان اثرهای انتقال ارائه‌شده توسط Aspose.Slides برای PHP از طریق Java با استفاده از enum TransitionType اعمال کنید.  
1. فایل ارائهٔ اصلاح‌شده را بنویسید.

```php
  # نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # اعمال انتقال نوع دایره‌ای روی اسلاید 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # اعمال انتقال نوع شانه‌ای روی اسلاید 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # نوشتن ارائه بر روی دیسک
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **افزودن انتقال پیشرفته اسلاید**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.  
1. یک نوع انتقال اسلاید را بر روی اسلاید از میان اثرهای انتقال ارائه‌شده توسط Aspose.Slides برای PHP از طریق Java اعمال کنید.  
1. می‌توانید انتقال را به پیشروی با کلیک، پس از دورهٔ زمانی مشخص یا هر دو تنظیم کنید.  
1. اگر انتقال اسلاید برای پیشروی با کلیک فعال باشد، انتقال تنها زمانی پیش می‌رود که کاربر کلیک کند. علاوه بر این، اگر ویژگی Advance After Time تنظیم شده باشد، انتقال به‌صورت خودکار پس از گذشت زمان پیشروی مشخص شده انجام می‌شود.  
1. فایل ارائهٔ اصلاح‌شده را به‌عنوان یک فایل ارائه ذخیره کنید.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # اعمال انتقال نوع دایره‌ای روی اسلاید 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # تنظیم زمان انتقال 3 ثانیه
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # اعمال انتقال نوع شانه‌ای روی اسلاید 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # تنظیم زمان انتقال 5 ثانیه
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # اعمال انتقال نوع بزرگ‌نمایی روی اسلاید 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # تنظیم زمان انتقال 7 ثانیه
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # نوشتن ارائه بر روی دیسک
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides برای PHP از طریق Java اکنون از [Morph Transition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/morphtransition/) پشتیبانی می‌کند. این‌ها نمایانگر انتقال مورف جدیدی هستند که در PowerPoint 2019 معرفی شد.

{{% /alert %}} 

انتقال Morph به شما امکان می‌دهد حرکت روانی از یک اسلاید به اسلاید بعدی را انیمیشن کنید. این مقاله مفهوم را توضیح می‌دهد و نحوه استفاده از انتقال Morph را شرح می‌دهد. برای استفاده مؤثر از انتقال Morph، به دو اسلاید با حداقل یک شیء مشترک نیاز دارید. ساده‌ترین راه این است که اسلاید را تکثیر کنید و سپس شیء را در اسلاید دوم به مکان دیگری منتقل کنید.

کد زیر نشان می‌دهد چگونه یک کپی از اسلاید را با متن اضافه کنید و یک انتقال [morph type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TransitionType) را به اسلاید دوم اختصاص دهید.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **انواع انتقال Morph**
enum جدیدی به نام [TransitionMorphType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TransitionMorphType) اضافه شده است. این enum انواع مختلف انتقال اسلاید Morph را نمایان می‌کند.

enum TransitionMorphType دارای سه عضو است:

- ByObject: انتقال Morph با در نظر گرفتن شکل‌ها به عنوان اشیاء غیرقابل تقسیم انجام می‌شود.  
- ByWord: انتقال Morph با انتقال متن بر اساس کلمات در صورت امکان انجام می‌شود.  
- ByChar: انتقال Morph با انتقال متن بر اساس حروف در صورت امکان انجام می‌شود.

کد زیر نشان می‌دهد چگونه انتقال Morph را به اسلاید اختصاص داده و نوع Morph را تغییر دهید:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **تنظیم اثرات انتقال**

Aspose.Slides برای PHP از طریق Java از تنظیم اثرات انتقال مانند از سیاه، از چپ، از راست و غیره پشتیبانی می‌کند. برای تنظیم اثر انتقال، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
- مرجع اسلاید را دریافت کنید.  
- تنظیم اثر انتقال.  
- فایل ارائه را به‌صورت [PPTX ](https://docs.fileformat.com/presentation/pptx/) بنویسید.

در مثال زیر، اثرات انتقال را تنظیم کرده‌ایم.

```php
  # ایجاد یک نمونه از کلاس Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # تنظیم اثر
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # نوشتن ارائه بر روی دیسک
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**آیا می‌توانم سرعت پخش انتقال اسلاید را کنترل کنم؟**

بله. با استفاده از تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/transitionspeed/) سرعت انتقال را تنظیم کنید (مثلاً slow/medium/fast) با استفاده از ویژگی [speed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/setspeed/).

**آیا می‌توانم صدا به یک انتقال اضافه کنم و آن را به صورت حلقه‌ای پخش کنم؟**

بله. می‌توانید صدایی برای انتقال جاسازی کنید و رفتار آن را از طریق تنظیماتی مانند حالت صدا و حلقه‌سازی کنترل کنید (مثلاً [setSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/setsound/)، [setSoundMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/setsoundmode/)، [setSoundLoop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/setsoundloop/)، به‌همراه داده‌های متا مانند [setSoundIsBuiltIn](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) و [setSoundName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**سریع‌ترین راه برای اعمال یک انتقال یکسان بر تمام اسلایدها چیست؟**

نوع انتقال موردنظر را در تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال همان نوع بر همهٔ اسلایدها نتیجهٔ یکنواختی می‌دهد.

**چگونه می‌توانم بررسی کنم که کدام انتقال در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

تنظیمات [transition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید را بررسی کنید و نوع [transition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowtransition/settype/) آن را بخوانید؛ این مقدار دقیقاً نشان می‌دهد که کدام اثر اعمال شده است.