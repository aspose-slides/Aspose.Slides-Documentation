---
title: مدیریت نمایش اسلاید در JavaScript
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/nodejs-java/manage-slide-show/
keywords:
- نوع نمایش
- ارائه شده توسط گوینده
- مرور توسط فرد
- مرور در کیوسک
- گزینه‌های نمایش
- حلقه‌گذاری مداوم
- نمایش بدون روایت
- نمایش بدون انیمیشن
- رنگ قلم
- نمایش اسلایدها
- نمایش سفارشی
- پیشبرد اسلایدها
- به‌صورت دستی
- استفاده از زمان‌بندی‌ها
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت نمایش اسلایدها در JavaScript با Aspose.Slides برای Node.js. کنترل انتقالات اسلاید، زمان‌بندی‌ها و موارد دیگر در فرمت‌های PPT، PPTX و ODP به سادگی."
---
## **مقدمه**

در Microsoft PowerPoint، تنظیمات **Slide Show** ابزار کلیدی برای آماده‌سازی و ارائهٔ ارائه‌های حرفه‌ای است. یکی از مهم‌ترین ویژگی‌های این بخش **Set Up Show** است که به شما امکان می‌دهد ارائه خود را مطابق با شرایط و مخاطبان خاص تنظیم کنید و انعطاف‌پذیری و راحتی را تضمین کنید. با این ویژگی می‌توانید نوع نمایش را انتخاب کنید (مثلاً PresentedBySpeaker، BrowsedByIndividual یا BrowsedAtKiosk)، حلقه‌گذاری را فعال یا غیرفعال کنید، اسلایدهای خاصی را برای نمایش انتخاب کنید و از زمان‌بندی‌ها استفاده کنید. این مرحله در آماده‌سازی برای مؤثرتر و حرفه‌ای‌تر کردن ارائه شما حیاتی است.

`getSlideShowSettings` متدی از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) است که شی‌ای از نوع [SlideShowSettings](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideshowsettings/) برمی‌گرداند و به شما امکان مدیریت تنظیمات اسلاید شو در یک ارائه PowerPoint را می‌دهد. در این مقاله نحوهٔ استفاده از این متد برای پیکربندی و کنترل جنبه‌های مختلف تنظیمات اسلاید شو بررسی می‌شود. 

## **انتخاب نوع نمایش**

`SlideShowSettings.setSlideShowType` نوع اسلاید شو را تعریف می‌کند که می‌تواند نمونه‌ای از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/browsedbyindividual/) یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/browsedatkiosk/). استفاده از این متد به شما اجازه می‌دهد ارائه را برای سناریوهای مختلفی مانند کیوسک‌های خودکار یا ارائه‌های دستی تنظیم کنید.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نوع نمایش را بر روی «Browsed by an individual» بدون نمایش نوار اسکرول تنظیم می‌نماید.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **فعال کردن گزینه‌های نمایش**

`SlideShowSettings.setLoop` تعیین می‌کند که اسلاید شو تا زمانی که به‌صورت دستی متوقف شود، به‌صورت حلقه‌ای تکرار شود. این گزینه برای ارائه‌های خودکاری که نیاز به اجرای مداوم دارند مفید است. `SlideShowSettings.setShowNarration` تعیین می‌کند که آیا روایت صوتی باید در طول اسلاید شو پخش شود. این برای ارائه‌های خودکار که شامل راهنمایی صوتی برای مخاطبان هستند مفید است. `SlideShowSettings.setShowAnimation` تعیین می‌کند که آیا انیمیشن‌های اضافه شده به اشیای اسلاید باید پخش شوند. این گزینه برای ارائهٔ کامل اثر بصری مفید است.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و اسلاید شو را به‌صورت حلقه‌ای اجرا می‌نماید.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **انتخاب اسلایدهای نمایش داده‌شده**

متد `SlideShowSettings.setSlides` به شما اجازه می‌دهد بازه‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این گزینه زمانی مفید است که بخواهید فقط بخشی از ارائه را به‌جای تمام اسلایدها نمایش دهید. مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و بازهٔ اسلایدها را از اسلایدهای `2` تا `9` تنظیم می‌نماید.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **استفاده از زمان‌بندی پیش‌فرض اسلایدها**

متد `SlideShowSettings.setUseTimings` به شما امکان می‌دهد استفاده از زمان‌بندی‌های پیش‌فرض برای هر اسلاید را فعال یا غیرفعال کنید. این گزینه برای نمایش خودکار اسلایدها با مدت زمان پیش‌تعریف‌شده مفید است. مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌کند.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **نمایش کنترل‌های رسانه‌ای**

متد `SlideShowSettings.setShowMediaControls` تعیین می‌کند که هنگام پخش محتوای چندرسانه‌ای (مانند ویدئو یا صدا) کنترل‌های رسانه‌ای (مانند پخش، توقف و ادامه) در طول اسلاید شو نمایش داده شوند یا خیر. این گزینه زمانی مفید است که بخواهید کنترل پخش رسانه برای ارائه‌دهنده در طول ارائه فراهم باشد.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌نماید.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **سؤالات متداول**

**آیا می‌توانم یک ارائه را ذخیره کنم تا مستقیماً در حالت اسلاید شو باز شود؟**

بله. فایل را به‌صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint مستقیماً در حالت اسلاید شو اجرا می‌شوند. در Aspose.Slides، فرمت ذخیره‌سازی مربوطه را [during export](/slides/fa/nodejs-java/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای جداگانه را از نمایش حذف کنم بدون اینکه آنها را از فایل حذف کنم؟**

بله. یک اسلاید را به‌عنوان [hidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/sethidden/) علامت‌گذاری کنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در طول اسلاید شو نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک اسلاید شو را پخش کند یا یک ارائهٔ زنده را بر روی صفحه کنترل کند؟**

خیر. Aspose.Slides فقط فایل‌های ارائه را ویرایش، تجزیه و تحلیل و تبدیل می‌کند؛ پخش واقعی توسط یک برنامهٔ نمایشگر مانند PowerPoint انجام می‌شود.