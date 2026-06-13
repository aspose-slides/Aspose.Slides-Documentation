---
title: مدیریت اسلاید شو در جاوا
linktitle: اسلاید شو
type: docs
weight: 90
url: /fa/java/manage-slide-show/
keywords:
- نوع نمایش
- ارائه توسط سخنران
- مشاهده توسط فرد
- مشاهده در کیوسک
- گزینه‌های نمایش
- حلقه‌پذیری مداوم
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
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اسلاید شوها را در Aspose.Slides برای جاوا مدیریت کنید. انتقال اسلایدها، زمان‌بندی‌ها و موارد دیگر را به‌سهولة در فرمت‌های PPT، PPTX و ODP کنترل کنید."
---
## **مقدمه**

در Microsoft PowerPoint، تنظیمات **Slide Show** ابزار کلیدی برای آماده‌سازی و ارائهٔ حرفه‌ای ارائه‌ها هستند. یکی از مهم‌ترین ویژگی‌های این بخش **Set Up Show** است که به شما امکان می‌دهد ارائهٔ خود را بر اساس شرایط و مخاطبان خاص تنظیم کنید و انعطاف‌پذیری و راحتی را تضمین نمایید. با استفاده از این ویژگی می‌توانید نوع نمایش (مثلاً presented by a speaker، browsed by an individual یا browsed at a kiosk) را انتخاب کنید، حلقه‌زدن را فعال یا غیرفعال کنید، اسلایدهای خاصی را برای نمایش انتخاب کنید و از زمان‌بندی‌ها استفاده کنید. این گام در تهیهٔ ارائه برای کارآمدتر و حرفه‌ای‌تر شدن آن بسیار حیاتی است.

`getSlideShowSettings` متدی از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) است که یک شیء از نوع [SlideShowSettings](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideshowsettings/) را برمی‌گرداند و به شما امکان مدیریت تنظیمات اسلایدشو در یک ارائهٔ PowerPoint را می‌دهد. در این مقاله نحوهٔ استفاده از این متد برای پیکربندی و کنترل جنبه‌های مختلف تنظیمات اسلایدشو را بررسی می‌کنیم.

## **انتخاب نوع نمایش**

`SlideShowSettings.setSlideShowType` نوع اسلایدشو را تعریف می‌کند که می‌تواند نمونه‌ای از یکی از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/fa/java/com.aspose.slides/browsedbyindividual/) یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/java/com.aspose.slides/browsedatkiosk/). استفاده از این متد به شما اجازه می‌دهد ارائه را برای سناریوهای مختلفی مانند کیوسک‌های خودکار یا ارائه‌های دستی تطبیق دهید.

نمونه کد زیر یک ارائهٔ جدید ایجاد می‌کند و نوع نمایش را به «Browsed by an individual» تنظیم می‌کند بدون اینکه نوار اسکرول نمایش داده شود.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **فعال‌سازی گزینه‌های نمایش**

`SlideShowSettings.setLoop` تعیین می‌کند که آیا اسلاید شو باید به‌صورت حلقه‌ای تکرار شود تا به‌صورت دستی متوقف شود. این گزینه برای ارائه‌های خودکار که نیاز به اجرا به‌صورت مداوم دارند مفید است. `SlideShowSettings.setShowNarration` تعیین می‌کند که آیا روایت صوتی باید در طول اسلاید شو پخش شود. این برای ارائه‌های خودکاری که شامل راهنمایی صوتی برای مخاطب هستند مفید است. `SlideShowSettings.setShowAnimation` تعیین می‌کند که آیا انیمیشن‌های اضافه‌شده به اشیاء اسلاید پخش شوند. این برای ارائهٔ کامل اثر بصری مفید است.

نمونه کد زیر یک ارائهٔ جدید ایجاد می‌کند و اسلاید شو را به‌صورت حلقه‌ای تنظیم می‌کند.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **انتخاب اسلایدهای نمایش داده‌شده**

متد `SlideShowSettings.setSlides` به شما اجازه می‌دهد محدوده‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این برای زمانی مفید است که می‌خواهید تنها بخشی از ارائه را نمایش دهید و نه تمام اسلایدها. نمونه کد زیر یک ارائهٔ جدید ایجاد می‌کند و محدودهٔ اسلایدها را از اسلاید `2` تا `9` تنظیم می‌نماید.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **استفاده از زمان‌بندی پیش‌فرض اسلایدها**

متد `SlideShowSettings.setUseTimings` امکان فعال یا غیرفعال کردن استفاده از زمان‌بندی‌های پیش‌فرض برای هر اسلاید را فراهم می‌کند. این برای نمایش خودکار اسلایدها با مدت زمان‌های از پیش تعریف‌شده مفید است. نمونه کد زیر یک ارائهٔ جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌کند.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **نمایش کنترل‌های رسانه‌ای**

متد `SlideShowSettings.setShowMediaControls` تعیین می‌کند که آیا کنترل‌های رسانه‌ای (مانند play، pause و stop) در هنگام پخش محتوای چندرسانه‌ای (مثلاً ویدیو یا صدا) در اسلاید شو نمایش داده شوند یا خیر. این برای زمانی مفید است که می‌خواهید به ارائه‌دهنده امکان کنترل پخش رسانه‌ها را در طول ارائه بدهید.

نمونه کد زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌نماید.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **سوالات متداول**

**آیا می‌توانم یک ارائه را به‌گونه‌ای ذخیره کنم که مستقیماً در حالت اسلاید شو باز شود؟**

بله. فایل را به‌صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint مستقیماً در حالت اسلاید شو اجرا می‌شوند. در Aspose.Slides، قالب ذخیره‌سازی مناسب را **[در طول استخراج](/slides/fa/java/save-presentation/)** انتخاب کنید.

**آیا می‌توانم اسلایدهای منفرد را از نمایش حذف کنم بدون اینکه آن‌ها را از فایل حذف کنم؟**

بله. یک اسلاید را به‌عنوان [hidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#setHidden-boolean-) علامت بزنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در طول اسلاید شو نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند اسلاید شو را پخش کند یا یک ارائهٔ زنده را روی صفحه کنترل کند؟**

خیر. Aspose.Slides فایل‌های ارائه را ویرایش، تجزیه و تبدیل می‌کند؛ پخش واقعی توسط برنامهٔ مشاهده‌کننده‌ای مانند PowerPoint انجام می‌شود.