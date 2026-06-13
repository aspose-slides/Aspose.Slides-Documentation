---
title: مدیریت نمایش اسلاید در C++
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/cpp/manage-slide-show/
keywords:
- نوع نمایش
- ارائه شده توسط گوینده
- مرور توسط شخص
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
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه نمایش اسلایدها را در Aspose.Slides برای C++ مدیریت کنید. انتقالات اسلاید، زمان‌بندی‌ها و موارد بیشتر را به‌راحتی در قالب‌های PPT، PPTX و ODP کنترل کنید."
---
## **مقدمه**

در مایکروسافت پاورپوینت، تنظیمات **Slide Show** ابزار کلیدی برای تهیه و ارائهٔ ارائه‌های حرفه‌ای هستند. یکی از مهم‌ترین قابلیت‌های این بخش **Set Up Show** است که به شما امکان می‌دهد ارائه خود را متناسب با شرایط و مخاطبان خاص تنظیم کنید و انعطاف‌پذیری و راحتی را تضمین کنید. با این قابلیت می‌توانید نوع نمایش را انتخاب کنید (مثلاً ارائه توسط گوینده، مرور توسط یک فرد، یا مرور در کیوسک)، حلقه شدن را فعال یا غیرفعال کنید، اسلایدهای خاصی را برای نمایش انتخاب کنید و از زمان‌بندی‌ها استفاده کنید. این مرحله در آماده‌سازی برای مؤثرتر و حرفه‌ای‌تر شدن ارائه شما حیاتی است.

`get_SlideShowSettings` متدی از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) است که شی‌ای از نوع [SlideShowSettings](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slideshowsettings/) برمی‌گرداند و به شما امکان مدیریت تنظیمات نمایش اسلاید در یک ارائهٔ پاورپوینت را می‌دهد. در این مقاله، نحوهٔ استفاده از این متد برای پیکربندی و کنترل جنبه‌های مختلف تنظیمات نمایش اسلاید را بررسی می‌کنیم.

## **انتخاب نوع نمایش**

`SlideShowSettings.set_SlideShowType` نوع نمایش اسلاید را تعریف می‌کند که می‌تواند نمونه‌ای از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/fa/cpp/aspose.slides/browsedbyindividual/)، یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/cpp/aspose.slides/browsedatkiosk/). استفاده از این متد به شما امکان می‌دهد ارائه را برای سناریوهای مختلف استفاده، مانند کیوسک‌های خودکار یا ارائه‌های دستی، سازگار کنید.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نوع نمایش را به «Browsed by an individual» تنظیم می‌نماید بدون نمایش نوار اسکرول.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **فعال‌سازی گزینه‌های نمایش**

`SlideShowSettings.set_Loop` تعیین می‌کند که نمایش اسلایدها آیا باید به طور حلقه‌ای تکرار شود تا به صورت دستی متوقف شود یا خیر. این برای ارائه‌های خودکاری که نیاز به اجرا مداوم دارند مفید است. `SlideShowSettings.set_ShowNarration` تعیین می‌کند که آیا روایت صوتی در طول نمایش اسلاید پخش شود یا نه. این برای ارائه‌های خودکاری که شامل راهنمایی صوتی برای مخاطبان هستند مفید است. `SlideShowSettings.set_ShowAnimation` تعیین می‌کند که آیا انیمیشن‌های اضافه شده به اشیای اسلاید پخش شوند یا نه. این برای ارائه اثر بصری کامل به کار می‌رود.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش اسلاید را به صورت حلقه‌ای تنظیم می‌نماید.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **انتخاب اسلایدهای نمایش**

متد `SlideShowSettings.set_Slides` به شما امکان می‌دهد بازه‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این زمانی مفید است که نیاز داشته باشید تنها بخشی از ارائه را به جای تمام اسلایدها نمایش دهید. مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و بازهٔ اسلایدهای نمایش را از اسلایدهای `2` تا `9` تنظیم می‌نماید.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استفاده از پیشبرد اسلایدها**

متد `SlideShowSettings.set_UseTimings` به شما امکان می‌دهد استفاده از زمان‌بندی‌های پیش‌تنظیم‌شده برای هر اسلاید را فعال یا غیرفعال کنید. این برای نمایش خودکار اسلایدها با مدت‌زمان‌های از پیش تعریف‌شده مفید است. مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌نماید.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **نمایش کنترل‌های رسانه‌ای**

متد `SlideShowSettings.set_ShowMediaControls` تعیین می‌کند که آیا کنترل‌های رسانه‌ای (مانند پخش، توقف موقت و توقف) هنگام پخش محتوای چندرسانه‌ای (مثلاً ویدئو یا صدا) در طول نمایش اسلاید نمایش داده شوند یا نه. این زمانی مفید است که بخواهید به ارائه‌دهنده امکان کنترل پخش رسانه‌ها را در طول ارائه بدهید.

مثال کد زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌نماید.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**آیا می‌توانم یک ارائه را ذخیره کنم طوری که مستقیماً در حالت نمایش اسلاید باز شود؟**

بله. فایل را به صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint به‌طور مستقیم در حالت نمایش اسلاید اجرا می‌شوند. در Aspose.Slides، فرمت ذخیره‌سازی مناسب را [در طول خروجی](/slides/fa/cpp/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای منفرد را از نمایش حذف کنم بدون این که آنها را از فایل حذف کنم؟**

بله. یک اسلاید را به‌عنوان [hidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/set_hidden/) علامت‌گذاری کنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در زمان نمایش اسلاید نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک نمایش اسلاید را پخش کند یا یک ارائه زنده را روی صفحه کنترل کند؟**

نه. Aspose.Slides فایل‌های ارائه را ویرایش، تحلیل و تبدیل می‌کند؛ پخش واقعی توسط یک برنامهٔ نمایشگر مانند PowerPoint انجام می‌شود.