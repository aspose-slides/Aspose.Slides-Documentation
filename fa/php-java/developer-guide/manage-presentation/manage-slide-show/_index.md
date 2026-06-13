---
title: مدیریت نمایش اسلاید در PHP
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/php-java/manage-slide-show/
keywords:
- نوع نمایش
- ارائه شده توسط گوینده
- مرور توسط فرد
- مرور در کیوسک
- گزینه‌های نمایش
- حلقه مداوم
- نمایش بدون روایت
- نمایش بدون انیمیشن
- رنگ قلم
- نمایش اسلایدها
- نمایش سفارشی
- پیشبرد اسلایدها
- به صورت دستی
- استفاده از زمان‌بندی‌ها
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "نحوهٔ مدیریت نمایش‌های اسلاید در Aspose.Slides برای PHP از طریق Java را بیاموزید. انتقال‌های اسلاید، زمان‌بندی‌ها و موارد دیگر را به‌راحتی در قالب‌های PPT، PPTX و ODP کنترل کنید."
---
## **مقدمه**

در مایکروسافت پاورپوینت، تنظیمات **Slide Show** ابزار کلیدی برای آماده‌سازی و ارائهٔ ارائه‌های حرفه‌ای هستند. یکی از مهم‌ترین ویژگی‌های این بخش **Set Up Show** است که به شما امکان می‌دهد ارائهٔ خود را بر اساس شرایط و مخاطبان خاص تنظیم کنید و انعطاف‌پذیری و راحتی را فراهم می‌کند. با این ویژگی می‌توانید نوع نمایش (مثلاً ارائه به‌دست سخنران، مرور توسط یک فرد، یا مرور در کیوسک) را انتخاب کنید، حلقه‌دار شدن را فعال یا غیرفعال کنید، اسلایدهای خاصی را برای نمایش انتخاب کنید و از زمان‌بندی‌ها استفاده کنید. این مرحله در آماده‌سازی برای مؤثرتر و حرفه‌ای‌تر کردن ارائهٔ شما بسیار حیاتی است.

`getSlideShowSettings` متد `getSlideShowSettings` از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) است که یک شی از نوع [SlideShowSettings](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideshowsettings/) بر می‌گرداند و به شما امکان مدیریت تنظیمات اسلاید شو در یک ارائهٔ PowerPoint را می‌دهد. در این مقاله، نحوهٔ استفاده از این متد برای پیکربندی و کنترل جنبه‌های مختلف تنظیمات اسلاید شو بررسی می‌شود. 

## **انتخاب نوع نمایش**

`SlideShowSettings->setSlideShowType` نوع اسلاید شو را تعریف می‌کند که می‌تواند نمونه‌ای از یکی از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/fa/php-java/aspose.slides/browsedbyindividual/)، یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/php-java/aspose.slides/browsedatkiosk/). استفاده از این متد به شما امکان می‌دهد ارائه را برای سناریوهای استفاده مختلف، مانند کیوسک‌های خودکار یا ارائه‌های دستی، سازگار کنید.

کد مثال زیر یک ارائهٔ جدید ایجاد می‌کند و نوع نمایش را به «Browsed by an individual» تنظیم می‌نماید بدون اینکه نوار اسکرول نمایش داده شود.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **فعال‌سازی گزینه‌های نمایش**

`SlideShowSettings->setLoop` تعیین می‌کند که آیا اسلاید شو باید به‌صورت حلقه‌دار تا زمان توقف دستی تکرار شود یا نه. این برای ارائه‌های خودکار که نیاز به اجرا مداوم دارند مفید است. `SlideShowSettings->setShowNarration` تعیین می‌کند که آیا روایت صوتی باید در طول اسلاید شو پخش شود یا نه. این برای ارائه‌های خودکاری که شامل راهنمای صوتی برای مخاطبان هستند مفید است. `SlideShowSettings->setShowAnimation` تعیین می‌کند که آیا انیمیشن‌های اضافه‌شده به اشیای اسلاید باید اجرا شوند یا نه. این برای ارائهٔ کامل اثرات بصری ارائه مفید است.

کد مثال زیر یک ارائهٔ جدید ایجاد می‌کند و اسلاید شو را به‌صورت حلقه‌ای تنظیم می‌نماید.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **انتخاب اسلایدهای نمایش داده‌شده**

متد `SlideShowSettings->setSlides` به شما امکان می‌دهد یک بازه‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این زمانی مفید است که نیاز دارید فقط بخشی از ارائه را نمایش دهید نه تمام اسلایدها.

کد مثال زیر یک ارائهٔ جدید ایجاد می‌کند و بازهٔ اسلایدها را برای نمایش از اسلاید `2` تا `9` تنظیم می‌نماید.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **استفاده از پیشروی اسلایدها**

متد `SlideShowSettings->setUseTimings` به شما امکان می‌دهد استفاده از زمان‌بندی‌های پیش‌تنظیم‌شده برای هر اسلاید را فعال یا غیرفعال کنید. این برای نمایش خودکار اسلایدها با مدت زمان نمایش از پیش تعریف‌شده مفید است.

کد مثال زیر یک ارائهٔ جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌سازد.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **نمایش کنترل‌های رسانه‌ای**

متد `SlideShowSettings->setShowMediaControls` تعیین می‌کند که آیا کنترل‌های رسانه‌ای (مانند پخش، مکث و توقف) هنگام پخش محتوای چندرسانه‌ای (مثلاً ویدئو یا صدا) در طول اسلاید شو نمایش داده شوند یا نه. این زمانی مفید است که می‌خواهید به ارائه‌دهنده امکان کنترل پخش رسانه‌ها را در طول ارائه بدهید.

کد مثال زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌سازد.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **پرسش‌های متداول**

**آیا می‌توانم یک ارائه را طوری ذخیره کنم که مستقیماً در حالت اسلاید شو باز شود؟**

بله. فایل را به‌صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint مستقیماً در حالت اسلاید شو اجرا می‌شوند. در Aspose.Slides، فرمت ذخیره‌سازی مربوطه را در [during export](/slides/fa/php-java/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای جداگانه را از نمایش حذف کنم بدون اینکه آن‌ها را از فایل حذف کنم؟**

بله. یک اسلاید را به‌عنوان [hidden](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/sethidden/) علامت‌گذاری کنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در طول اسلاید شو نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک اسلاید شو را پخش کند یا یک ارائه زنده را روی صفحه کنترل کند؟**

خیر. Aspose.Slides فایل‌های ارائه را ویرایش، تجزیه و تحلیل و تبدیل می‌کند؛ پخش واقعی توسط برنامه‌ای مانند PowerPoint انجام می‌شود.