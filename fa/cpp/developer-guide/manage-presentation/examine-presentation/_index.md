---
title: دریافت و به‌روزرسانی اطلاعات ارائه در C++
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/cpp/examine-presentation/
keywords:
- فرمت ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اسلایدها، ساختار و فراداده‌های ارائه‌های PowerPoint و OpenDocument را با استفاده از C++ برای دریافت سریع‌تر بینش‌ها و ارزیابی هوشمندانه‌تر محتوا بررسی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه اطلاعات ارائه در Aspose.Slides را بررسی کنید. توضیح می‌دهد چگونه می‌توان فرمت فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کرد، ویژگی‌های سند آن را بخوانید و در صورت لزوم این ویژگی‌ها را به‌روزرسانی کنید.

مثال‌ها بر پایهٔ APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/documentproperties/) هستند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی فرمت ارائه**

قبل از کار با یک ارائه، ممکن است بخواهید فرمت فعلی آن (PPT، PPTX، ODP و سایرین) را بیابید.

می‌توانید فرمت یک ارائه را بدون بارگذاری آن بررسی کنید. کد C++ زیر را ببینید:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// فرمت PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// فرمت PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// فرمت ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **دریافت ویژگی‌های ارائه**

این کد C++ نشان می‌دهد چگونه ویژگی‌های ارائه (اطلاعات مربوط به ارائه) را دریافت کنید:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) را فراهم می‌کند که به شما امکان می‌دهد تغییرات در ویژگی‌های ارائه اعمال کنید.

فرض کنید یک ارائه PowerPoint داریم که ویژگی‌های سند آن در زیر نشان داده شده‌اند.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از ویژگی‌های ارائه را ویرایت کنید:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

نتایج تغییر ویژگی‌های سند در زیر نشان داده شده‌اند.

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای دریافت اطلاعات بیشتر درباره یک ارائه و ویژگی‌های امنیتی آن، ممکن است این پیوندها مفید باشند:

- [بررسی اینکه آیا یک ارائه رمزگذاری شده است](https://docs.aspose.com/slides/fa/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [بررسی اینکه آیا یک ارائه حفاظت نوشتاری (فقط خواندنی) دارد](https://docs.aspose.com/slides/fa/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [بررسی اینکه آیا یک ارائه قبل از بارگذاری آن دارای حفاظت کلمه‌عبور است](https://docs.aspose.com/slides/fa/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأیید کلمه‌عبوری که برای حفاظت از یک ارائه استفاده شده است](https://docs.aspose.com/slides/fa/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها (فونت‌ها) درج شده‌اند و کدامیک هستند؟**

به دنبال اطلاعات [embedded-font](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getembeddedfonts/) در سطح ارائه باشید، سپس آن ورودی‌ها را با مجموعهٔ [فونت‌های واقعاً استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getfonts/) مقایسه کنید تا مشخص کنید کدام فونت‌ها برای رندر کردن ضروری هستند.

**چگونه می‌توانم به سرعت تشخیص دهم که آیا فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**

از طریق [slide collection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidecollection/) مرور کنید و پرچم [visibility](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/get_hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت‌گیری سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. [اندازه و جهت‌گیری اسلاید](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slidesize/) فعلی را با پیش‌تنظیمات استاندارد مقایسه کنید؛ این به پیش‌بینی رفتار برای چاپ و خروجی کمک می‌کند.

**آیا راهی سریع وجود دارد تا ببینم نمودارها به منابع داده خارجی ارجاع می‌دهند؟**

بله. تمام [charts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/) را پیمایش کنید، [منبع داده](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) آن‌ها را بررسی کنید و مشخص کنید داده داخلی است یا مبتنی بر لینک، شامل لینک‌های معیوب.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کم‌سرعت کنند، ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیا را شمارش کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و مولتی‌مدیا باشید؛ سپس امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط بحرانی عملکردی محتمل را نشان دهد.