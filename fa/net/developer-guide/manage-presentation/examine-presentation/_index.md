---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در .NET
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/net/examine-presentation/
keywords:
- قالب ارائه
- خصوصیات ارائه
- خصوصیات سند
- دریافت خصوصیات
- خواندن خصوصیات
- تغییر خصوصیات
- اصلاح خصوصیات
- به‌روزرسانی خصوصیات
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدها، ساختار و فراداده‌های ارائه‌های PowerPoint و OpenDocument را با استفاده از .NET بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تر داشته باشید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه می‌توان اطلاعات ارائه (Presentation) را در Aspose.Slides بررسی کرد. توضیح می‌دهد چگونه می‌توانید فرمت فعلی یک ارائه را بدون بارگذاری کامل فایل تعیین کنید، خصوصیات سند آن را بخوانید و در صورت نیاز این خصوصیات را به‌روزرسانی کنید.

مثال‌ها بر پایه APIهای [PresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/) هستند و عملیات معمول برای کار با فراداده‌های ارائه را نشان می‌دهند.

## **بررسی فرمت یک ارائه**

قبل از کار با یک ارائه، ممکن است بخواهید فرمت (PPT، PPTX، ODP و …) فعلی ارائه را بیابید.

می‌توانید فرمت یک ارائه را بدون بارگیری آن بررسی کنید. کد C# زیر را ببینید:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **دریافت خصوصیات ارائه**

این کد C# نشان می‌دهد چگونه می‌توانید خصوصیات ارائه (اطلاعات درباره ارائه) را دریافت کنید:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

ممکن است بخواهید [خصوصیات موجود در کلاس DocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/documentproperties/#properties) را مشاهده کنید.

## **به‌روزرسانی خصوصیات ارائه**

Aspose.Slides متد [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) را ارائه می‌دهد که امکان تغییر خصوصیات ارائه را فراهم می‌کند.

فرض کنید یک ارائه PowerPoint داریم که خصوصیات سند آن در زیر نشان داده شده است.

![خصوصیات سند اصلی ارائه PowerPoint](input_properties.png)

این مثال کد نشان می‌دهد چگونه برخی از خصوصیات ارائه را ویرایش کنید:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

نتایج تغییر خصوصیات سند در زیر نشان داده شده است.

![خصوصیات سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای دریافت اطلاعات بیشتر درباره یک ارائه و ویژگی‌های امنیتی آن، ممکن است این لینک‌ها مفید باشند:

- [Password-Protect Presentations](/slides/fa/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/net/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم آیا فونت‌ها داخلی هستند و کدام‌ها؟**

در سطح ارائه به دنبال اطلاعات [embedded-font](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts/) بگردید، سپس آن ورودی‌ها را با مجموعهٔ [فونت‌های استفاده‌شده در محتوا](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getfonts/) مقایسه کنید تا فونت‌های بحرانی برای رندر را شناسایی کنید.

**چگونه می‌توانم سریعاً بفهمم آیا فایل اسلایدهای مخفی دارد و چند تا؟**

از طریق [slide collection](https://reference.aspose.com/slides/fa/net/aspose.slides/slidecollection/) پیمایش کنید و پرچم [visibility](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت اسلاید سفارشی استفاده شده‌اند و آیا از پیش‌فرض‌ها متفاوت هستند؟**

بله. اندازهٔ فعلی [slide size](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slidesize/) و جهت آن را با تنظیمات پیش‌فرض مقایسه کنید؛ این کمک می‌کند رفتار چاپ و خروجی را پیش‌بینی کنید.

**آیا راه سریع برای مشاهده این که نمودارها از منابع داده خارجی استفاده می‌کنند؟**

بله. تمام [charts](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/) را مرور کنید، نوع [data source](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) آن‌ها را بررسی کنید و ببینید داده داخلی است یا پیوندی، شامل پیوندهای خراب.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند، ارزیابی کنم؟**

برای هر اسلاید، تعداد اشیاء را شمارش کنید و به دنبال تصاویر بزرگ، شفافیت، سایه‌ها، انیمیشن‌ها و رسانه‌های چندرسانه‌ای بگردید؛ یک امتیاز تقریبی پیچیدگی اختصاص دهید تا نقاط بحرانی عملکرد را شناسایی کنید.