---
title: بازخوانی و به‌روزرسانی اطلاعات ارائه در .NET
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "کاوش در اسلایدها، ساختار و فراداده‌های ارائه‌های PowerPoint و OpenDocument با استفاده از .NET برای به دست آوردن بینش‌های سریع‌تر و انجام ارزیابی‌های هوشمندانه محتوا."
---
## **نمایش کلی**

این مقاله نشان می‌دهد که چگونه اطلاعات ارائه در Aspose.Slides را بازسازی کنید. توضیح می‌دهد که چگونه می‌توان فرمت فعلی یک ارائه را بدون بارگیری کامل فایل تعیین کرد، ویژگی‌های سند آن را بخوانید و در صورت نیاز این ویژگی‌ها را به‌روز کنید.

مثال‌ها بر پایه APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/) ساخته شده‌اند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی فرمت یک ارائه**

قبل از کار با یک ارائه، ممکن است بخواهید بدانید که فرمت فعلی ارائه (PPT، PPTX، ODP و ...) چیست.

می‌توانید فرمت ارائه را بدون بارگذاری آن بررسی کنید. کد C# زیر را ببینید:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **دریافت ویژگی‌های ارائه**

این کد C# نشان می‌دهد که چگونه ویژگی‌های ارائه (اطلاعات درباره ارائه) را دریافت کنید:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

ممکن است بخواهید [ویژگی‌های تحت کلاس DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/#properties) را ببینید.

## **به‌روزرسانی ویژگی‌های ارائه**

Aspose.Slides متد [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) را فراهم می‌کند که امکان اعمال تغییرات بر ویژگی‌های ارائه را می‌دهد.

فرض کنید یک ارائه PowerPoint داریم که ویژگی‌های سند آن در زیر نشان داده شده است.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد که چگونه برخی از ویژگی‌های ارائه را ویرایش کنید:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

نتایج تغییر ویژگی‌های سند در زیر نشان داده شده است.

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای دریافت اطلاعات بیشتر درباره یک ارائه و ویژگی‌های امنیتی آن، ممکن است این پیوندها مفید باشند:

- [بررسی اینکه آیا یک ارائه رمزگذاری شده است](https://docs.aspose.com/slides/fa/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [بررسی اینکه آیا یک ارائه حفاظت نوشتن (فقط‑خواندنی) دارد](https://docs.aspose.com/slides/fa/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [بررسی اینکه آیا یک ارائه قبل از بارگیری با رمز عبور محافظت می‌شود](https://docs.aspose.com/slides/fa/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأیید رمز عبور استفاده شده برای محافظت از یک ارائه](https://docs.aspose.com/slides/fa/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **پرسش‌های متداول**

**چگونه می‌توانم بررسی کنم آیا فونت‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

به دنبال [اطلاعات فونت‌های جاسازی‌شده](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts/) در سطح ارائه بگردید، سپس این ورودی‌ها را با مجموعه‌ای از [فونت‌های واقعاً استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getfonts/) مقایسه کنید تا فونت‌های مهم برای رندر را شناسایی کنید.

**چگونه می‌توانم سریعاً بفهمم آیا فایل اسلایدهای پنهان دارد و تعداد آن‌ها چقدر است؟**

در [مجموعه اسلایدها](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/) پیمایش کنید و برای هر اسلاید پرچم [قابلیت مشاهده](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/hidden/) آن را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت‌گیری سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت هستند؟**

بله. اندازه و جهت‌گیری فعلی [اسلاید](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slidesize/) را با پیش‌تنظیم‌های استاندارد مقایسه کنید؛ این کار به پیش‌بینی رفتار برای چاپ و خروجی‌گیری کمک می‌کند.

**آیا راهی سریع برای دیدن این‌که آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. تمام [نمودارها](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/) را مرور کنید، منبع داده آن‌ها را بررسی کنید و تعیین کنید که داده داخلی است یا بر پایه لینک، شامل هر لینک خراب.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیاء را شمرده و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و چندرسانه‌ای باشید؛ امتیاز پیچیدگی تقریبی اختصاص دهید تا نقاط بحرانی عملکرد را مشخص کنید.