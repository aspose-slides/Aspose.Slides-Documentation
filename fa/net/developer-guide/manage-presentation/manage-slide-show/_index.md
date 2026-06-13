---
title: مدیریت نمایش اسلاید در .NET
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/net/manage-slide-show/
keywords:
- نوع نمایش
- ارائه توسط سخنران
- مرور توسط فرد
- مرور در کیوسک
- گزینه‌های نمایش
- حلقه‌زدن مداوم
- نمایش بدون روایت
- نمایش بدون انیمیشن
- رنگ قلم
- نمایش اسلایدها
- نمایش سفارشی
- پیشرفت اسلایدها
- به‌صورت دستی
- استفاده از زمان‌بندی‌ها
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نحوه مدیریت نمایش اسلایدها در Aspose.Slides برای .NET را بیاموزید. انتقالات اسلاید، زمان‌بندی‌ها و موارد دیگر را به راحتی در قالب‌های PPT، PPTX و ODP کنترل کنید."
---
## **مقدمه**

در Microsoft PowerPoint، تنظیمات **Slide Show** ابزار کلیدی برای تهیه و ارائهٔ حرفه‌ای ارائه‌ها هستند. یکی از مهم‌ترین ویژگی‌های این بخش **Set Up Show** است که به شما امکان می‌دهد ارائه خود را برای شرایط و مخاطبان خاص تنظیم کنید و باعث انعطاف‌پذیری و راحتی می‌شود. با این ویژگی می‌توانید نوع نمایش (مثلاً ارائه توسط سخنران، مرور توسط یک فرد، یا مرور در کیوسک) را انتخاب کنید، حلقه‌زدن را فعال یا غیرفعال کنید، اسلایدهای خاصی را برای نمایش انتخاب کنید و از زمان‌بندی‌ها استفاده کنید. این گام در تهیهٔ ارائه برای مؤثرتر و حرفه‌ای‌تر شدن آن بسیار مهم است.

`SlideShowSettings` یک property از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) است که از نوع [SlideShowSettings](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slideshowsettings/) می‌باشد و به شما اجازه می‌دهد تنظیمات نمایش اسلاید را در یک ارائهٔ PowerPoint مدیریت کنید. در این مقاله، نحوهٔ استفاده از این property برای پیکربندی و کنترل جنبه‌های مختلف تنظیمات نمایش اسلاید را بررسی می‌کنیم.

## **انتخاب نوع نمایش**

`SlideShowSettings.SlideShowType` نوع نمایش اسلاید را تعریف می‌کند که می‌تواند نمونه‌ای از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/net/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/fa/net/aspose.slides/browsedbyindividual/)، یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/net/aspose.slides/browsedatkiosk/). استفاده از این property به شما امکان می‌دهد ارائه را برای سناریوهای مختلف، مانند کیوسک‌های خودکار یا ارائه‌های دستی، تطبیق دهید.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نوع نمایش را به «Browsed by an individual» بدون نمایش نوار اسکرول تنظیم می‌نماید.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **فعال‌سازی گزینه‌های نمایش**

`SlideShowSettings.Loop` تعیین می‌کند آیا نمایش اسلاید باید به‌صورت حلقه‌ای ادامه یابد تا به‌صورت دستی متوقف شود یا خیر. این ویژگی برای ارائه‌های خودکاری که نیاز به اجرا به‌صورت مداوم دارند، مفید است. `SlideShowSettings.ShowNarration` مشخص می‌کند آیا روایت صوتی باید در طول نمایش اسلاید پخش شود. این گزینه برای ارائه‌های خودکاری که شامل راهنمایی صوتی برای مخاطب هستند، کاربرد دارد. `SlideShowSettings.ShowAnimation` تعیین می‌کند آیا انیمیشن‌های اضافه‌شده به اشیای اسلاید باید اجرا شوند. این ویژگی برای ارائهٔ کامل اثر بصری مفید است.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش اسلاید را به‌صورت حلقه‌ای تنظیم می‌نماید.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **انتخاب اسلایدهای نمایش داده‌شده**

property `SlideShowSettings.Slides` به شما امکان می‌دهد محدوده‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این ویژگی زمانی مفید است که بخواهید فقط بخشی از ارائه را نشان دهید و نه تمام اسلایدها. مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و محدودهٔ اسلایدها را از اسلایدهای `2` تا `9` تنظیم می‌نماید.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **استفاده از پیشرفت اسلایدها**

property `SlideShowSettings.UseTimings` به شما اجازه می‌دهد استفاده از زمان‌بندی‌های پیش‌تعریف‌شده برای هر اسلاید را فعال یا غیرفعال کنید. این ویژگی برای نمایش خودکار اسلایدها با مدت زمان نمایش از پیش تعیین‌شده مفید است. مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌نماید.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **نمایش کنترل‌های رسانه‌ای**

property `SlideShowSettings.ShowMediaControls` تعیین می‌کند آیا کنترل‌های رسانه‌ای (مانند پخش، توقف، و توقف موقت) هنگام پخش محتوای چندرسانه‌ای (مثلاً ویدئو یا صدا) در نمایش اسلاید نمایش داده شوند یا خیر. این ویژگی زمانی مفید است که بخواهید به ارائه‌دهنده امکان کنترل پخش رسانه‌ها را در طول ارائه بدهید.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌نماید.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **سوالات متداول**

**آیا می‌توانم ارائه‌ای را ذخیره کنم به‌طوری که مستقیماً در حالت نمایش اسلاید باز شود؟**

بله. فایل را به‌صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint مستقیم به حالت نمایش اسلاید می‌روند. در Aspose.Slides، فرمت ذخیره‌سازی مربوطه را در هنگام [export](/slides/fa/net/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای فردی را از نمایش حذف کنم بدون اینکه آنها را از فایل حذف کنم؟**

بله. یک اسلاید را به‌عنوان [Hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/hidden/) علامت بزنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در هنگام نمایش اسلاید نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک نمایش اسلاید را پخش کند یا یک ارائهٔ زنده را روی صفحه کنترل کند؟**

خیر. Aspose.Slides فایل‌های ارائه را ویرایش، تجزیه و تحلیل و تبدیل می‌کند؛ پخش واقعی توسط برنامهٔ نمایش‌دهنده‌ای مانند PowerPoint انجام می‌شود.