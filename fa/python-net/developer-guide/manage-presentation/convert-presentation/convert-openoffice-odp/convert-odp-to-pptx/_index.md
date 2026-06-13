---
title: تبدیل ODP به PPTX در Python
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/python-net/convert-odp-to-pptx/
keywords:
- تبدیل OpenDocument
- تبدیل ODP
- OpenDocument به PPTX
- ODP به PPTX
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ODP را با Aspose.Slides برای Python از طریق .NET به PPTX تبدیل کنید. نمونه‌های کد تمیز، نکات دسته‌ای و نتایج با کیفیت بالا—بدون نیاز به PowerPoint."
---
## **نمای کلی**

این مقاله نحوه تبدیل یک ارائه ODP به فرمت PPTX را با استفاده از Aspose.Slides توضیح می‌دهد.

## **صادر کردن ODP به PPTX**

Aspose.Slides برای Python از طریق .NET کلاس Presentation را ارائه می‌دهد که نمایانگر یک فایل ارائه است. [**Presentation**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) کلاس هم‌اکنون می‌تواند از طریق سازنده Presentation به ODP دسترسی پیدا کند. مثال زیر نشان می‌دهد چگونه یک ارائه ODP را به ارائه PPTX تبدیل کنیم.

```py
# وارد کردن Aspose.Slides برای Python از طریق .NET
# باز کردن فایل ODP
# ذخیرهٔ ارائه ODP به فرمت PPTX
import aspose.slides as slides

pres = slides.Presentation("AccessOpenDoc.odp")

pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مثال زنده**

می‌توانید به برنامه وب [**تبدیل Aspose.Slides**](https://products.aspose.app/slides/fa/conversion/) مراجعه کنید که با **Aspose.Slides API** ساخته شده است. این برنامه نشان می‌دهد چطور تبدیل ODP به PPTX می‌تواند با Aspose.Slides API پیاده‌سازی شود.

## **سوالات متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

خیر. Aspose.Slides به‌صورت مستقل کار می‌کند و برای خواندن یا نوشتن ODP/PPTX به برنامه‌های شخص ثالث نیاز ندارد.

**آیا اسلایدهای اصلی، چیدمان‌ها و تم‌ها در طول تبدیل حفظ می‌شوند؟**

بله. کتابخانه از یک مدل شیء کامل ارائه استفاده می‌کند و ساختار، از جمله اسلایدهای اصلی و چیدمان‌ها را حفظ می‌کند، بنابراین طراحی پس از تبدیل صحیح باقی می‌ماند.

**آیا می‌توانم فایل‌های ODP محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله. Aspose.Slides قادر به تشخیص حفاظت، باز کردن و کار با [ارائه‌های محافظت‌شده](/slides/fa/python-net/password-protected-presentation/) (از جمله ODP) هنگامی که رمز عبور ارائه شود، همچنین پیکربندی رمزگذاری و دسترسی به ویژگی‌های سند را دارد.

**آیا Aspose.Slides برای خدمات تبدیل ابری یا مبتنی بر REST مناسب است؟**

بله. می‌توانید از کتابخانه محلی در بک‌اند خود استفاده کنید یا از [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) (REST API) بهره ببرید؛ هر دو گزینه از تبدیل ODP → PPTX پشتیبانی می‌کنند.