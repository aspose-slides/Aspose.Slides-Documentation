---
title: تبدیل ODP به PPTX در .NET
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/net/convert-odp-to-pptx/
keywords:
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل ODP
- OpenDocument به PPTX
- ODP به PPTX
- ذخیره ODP به عنوان PPTX
- صادرات ODP به PPTX
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ODP را به PPTX با Aspose.Slides برای .NET تبدیل کنید. مثال‌های کد تمیز C#، نکات پردازش دسته‌ای، و نتایج با کیفیت بالا—بدون نیاز به PowerPoint."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه یک ارائه ODP را به فرمت PPTX با استفاده از Aspose.Slides تبدیل کنید.

## **تبدیل ODP به PPTX**

Aspose.Slides برای .NET کلاس Presentation را ارائه می‌دهد که نمایانگر یک فایل ارائه است. کلاس [**Presentation**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) اکنون می‌تواند از طریق سازنده Presentation به ODP دسترسی پیدا کند هنگامی که شیء ساخته می‌شود. مثال زیر نشان می‌دهد چگونه یک ارائه ODP را به ارائه PPTX تبدیل کنید.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>مراحل: تبدیل ODP به PPTX در C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>مراحل: تبدیل ODP به PowerPoint در C#</strong></a>

```c#
// فایل ODP را باز کنید
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ذخیره ارائه ODP به فرمت PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **مثال زنده**

شما می‌توانید وب‌اپلیکیشن [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) را بازدید کنید که با **Aspose.Slides API** ساخته شده است. این اپلیکیشن نشان می‌دهد چگونه می‌توان تبدیل ODP به PPTX را با Aspose.Slides API پیاده‌سازی کرد.

## **سوالات متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

نه. Aspose.Slides به طور مستقل کار می‌کند و برای خواندن یا نوشتن ODP/PPTX به برنامه‌های شخص ثالث نیاز ندارد.

**آیا اسلایدهای اصلی، چیدمان‌ها و تم‌ها در طول تبدیل حفظ می‌شوند؟**

بله. این کتابخانه از یک مدل شیء کامل ارائه استفاده می‌کند و ساختار، از جمله اسلایدهای اصلی و چیدمان‌ها، را حفظ می‌کند، بنابراین طراحی پس از تبدیل درست باقی می‌ماند.

**آیا می‌توانم فایل‌های ODP محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله. Aspose.Slides قابلیت شناسایی حفاظت را دارد، می‌تواند ارائه‌های [ارائه‌های محافظت‌شده](/slides/fa/net/password-protected-presentation/) (از جمله ODP) را هنگامی که رمز عبور را فراهم می‌کنید باز کرده و با آنها کار کند، همچنین می‌توانید رمزنگاری و دسترسی به خصوصیات سند را پیکربندی کنید.

**آیا Aspose.Slides برای خدمات تبدیل مبتنی بر ابر یا REST مناسب است؟**

بله. می‌توانید کتابخانه محلی را در بک‌اند خود استفاده کنید یا از [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) (REST API) استفاده کنید؛ هر دو گزینه از تبدیل ODP → PPTX پشتیبانی می‌کنند.