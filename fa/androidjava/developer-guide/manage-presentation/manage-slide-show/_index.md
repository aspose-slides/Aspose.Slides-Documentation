---
title: مدیریت نمایش اسلاید در اندروید
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/androidjava/manage-slide-show/
keywords:
- نوع نمایش
- ارائه شده توسط سخنران
- مرور توسط فرد
- مرور در کیوسک
- گزینه‌های نمایش
- حلقه‌پذیر مداوم
- نمایش بدون روایت
- نمایش بدون انیمیشن
- رنگ قلم
- نمایش اسلایدها
- نمایش سفارشی
- پیشروی اسلایدها
- به صورت دستی
- استفاده از زمان‌بندی‌ها
- PowerPoint
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "نحوه مدیریت نمایش اسلایدها در Aspose.Slides برای اندروید از طریق جاوا را بیاموزید. انتقالات اسلاید، زمان‌بندی‌ها و موارد دیگر را در فرمت‌های PPT، PPTX و ODP به راحتی کنترل کنید."
---
## **مقدمه**

در Microsoft PowerPoint، تنظیمات **Slide Show** ابزاری کلیدی برای تهیه و ارائهٔ ارائه‌های حرفه‌ای هستند. یکی از مهم‌ترین ویژگی‌های این بخش **Set Up Show** است که به شما امکان می‌دهد ارائه خود را بر وفق شرایط و مخاطبان خاص تنظیم کنید و از انعطاف‌پذیری و راحتی برخوردار شوید. با این ویژگی می‌توانید نوع نمایش (مثلاً ارائه توسط سخنران، مرور توسط فردی، یا مرور در کیوسک) را انتخاب کنید، تکرار را فعال یا غیرفعال کنید، اسلایدهای خاصی را برای نمایش انتخاب کنید و از زمان‌بندی‌ها استفاده کنید. این گام در آماده‌سازی برای ارتقاء مؤثرتر و حرفه‌ای‌تر ارائه شما ضروری است.

`getSlideShowSettings` متدی از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) است که شیء‌ای از نوع [SlideShowSettings](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowsettings/) بازمی‌گرداند و به شما امکان مدیریت تنظیمات نمایش اسلاید در یک ارائهٔ PowerPoint را می‌دهد. در این مقاله، نحوه استفاده از این متد برای پیکربندی و کنترل جنبه‌های مختلف تنظیمات نمایش اسلاید را بررسی می‌کنیم.

## **انتخاب نوع نمایش**

`SlideShowSettings.setSlideShowType` نوع نمایش اسلاید را تعریف می‌کند که می‌تواند نمونه‌ای از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/browsedbyindividual/)، یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/browsedatkiosk/). استفاده از این متد به شما امکان می‌دهد ارائه را برای سناریوهای مختلفی مانند کیوسک‌های خودکار یا ارائه‌های دستی تطبیق دهید.

کد نمونه زیر یک ارائهٔ جدید ایجاد می‌کند و نوع نمایش را به «Browsed by an individual» بدون نمایش نوار اسکرول تنظیم می‌کند.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **فعال‌سازی گزینه‌های نمایش**

`SlideShowSettings.setLoop` تعیین می‌کند آیا نمایش اسلاید باید به صورت حلقه‌ای تا زمان متوقف شدن دستی تکرار شود یا نه. این گزینه برای ارائه‌های خودکاری که نیاز به اجرا به‌صورت مداوم دارند مفید است. `SlideShowSettings.setShowNarration` مشخص می‌کند آیا روایت صوتی باید در طول نمایش اسلاید پخش شود یا نه. این مورد برای ارائه‌های خودکاری که حاوی راهنمایی صوتی برای مخاطب هستند مفید است. `SlideShowSettings.setShowAnimation` تعیین می‌کند آیا انیمیشن‌های اضافه‌شده به اشیاء اسلاید پخش شوند یا نه. این گزینه برای نمایش کامل اثرات بصری ارائه کاربرد دارد.

کد نمونه زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش اسلاید را به صورت حلقه‌ای فعال می‌سازد.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **انتخاب اسلایدهای نمایش داده‌شده**

متد `SlideShowSettings.setSlides` به شما امکان می‌دهد بازه‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این ویژگی زمانی مفید است که بخواهید فقط بخشی از ارائه را به جای تمام اسلایدها نشان دهید. کد نمونه زیر یک ارائهٔ جدید ایجاد می‌کند و بازهٔ اسلایدهای `2` تا `9` را برای نمایش تنظیم می‌کند.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **استفاده از زمان‌بندی‌ها**

متد `SlideShowSettings.setUseTimings` امکان فعال یا غیرفعال کردن استفاده از زمان‌بندی‌های از پیش تعیین‌شده برای هر اسلاید را فراهم می‌کند. این ویژگی برای نمایش خودکار اسلایدها با مدت زمان نمایش از پیش تعریف‌شده مفید است. کد نمونه زیر یک ارائهٔ جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌کند.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **نمایش کنترل‌های چندرسانه‌ای**

متد `SlideShowSettings.setShowMediaControls` تعیین می‌کند آیا کنترل‌های چندرسانه‌ای (مانند پخش، توقف و قطع) هنگام نمایش اسلاید، وقتی محتوای چندرسانه‌ای (مثلاً ویدئو یا صدا) پخش می‌شود، نمایش داده شوند یا نه. این گزینه زمانی مفید است که بخواهید به ارائه‌دهنده امکان کنترل پخش رسانه‌ها را در طول ارائه بدهید.

کد نمونه زیر یک ارائهٔ جدید ایجاد می‌کند و فعال‌سازی نمایش کنترل‌های چندرسانه‌ای را تنظیم می‌کند.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **سوالات متداول**

**آیا می‌توانم یک ارائه را طوری ذخیره کنم که مستقیماً در حالت نمایش اسلاید باز شود؟**

بله. فایل را به عنوان PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint مستقیماً در حالت نمایش اسلاید اجرا می‌شوند. در Aspose.Slides می‌توانید فرمت ذخیره‌سازی مناسب را در [during export](/slides/fa/androidjava/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای فردی را از نمایش حذف کنم بدون اینکه آن‌ها را از فایل حذف کنم؟**

بله. یک اسلاید را به عنوان [hidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#setHidden-boolean-) علامت‌گذاری کنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در حین نمایش اسلاید نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک نمایش اسلاید را پخش کند یا یک ارائهٔ زنده را بر روی صفحه کنترل کند؟**

خیر. Aspose.Slides فایل‌های ارائه را ویرایش، تجزیه و تحلیل و تبدیل می‌کند؛ پخش واقعی توسط برنامهٔ مشاهده‌گری مانند PowerPoint انجام می‌شود.