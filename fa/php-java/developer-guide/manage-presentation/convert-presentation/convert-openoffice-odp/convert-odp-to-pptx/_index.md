---
title: تبدیل ODP به PPTX در PHP
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/php-java/convert-odp-to-pptx/
keywords:
- تبدیل OpenDocument
- تبدیل presentation
- تبدیل slide
- تبدیل ODP
- OpenDocument به PPTX
- ODP به PPTX
- ذخیره ODP به عنوان PPTX
- صادرات ODP به PPTX
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "تبدیل ODP به PPTX با Aspose.Slides برای PHP از طریق Java. مثال‌های کد تمیز، نکات دسته‌ای و نتایج با کیفیت بالا—بدون نیاز به PowerPoint."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه یک ارائه ODP را به فرمت PPTX با استفاده از Aspose.Slides تبدیل کنید.

## **تبدیل ODP به ارائه PPTX/PPT**
Aspose.Slides برای PHP از طریق Java کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) را ارائه می‌دهد که نمایانگر یک فایل ارائه است. کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) اکنون می‌تواند از طریق سازنده [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) به ODP دسترسی داشته باشد هنگامی که شیء ساخته می‌شود. مثال زیر نشان می‌دهد که چگونه یک ارائه ODP را به ارائه PPTX تبدیل کنید.

```php
// باز کردن فایل ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # ذخیره ارائه ODP به فرمت PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **مثال زنده**
می‌توانید وب‌اپلیکیشن [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) را بازدید کنید که با **Aspose.Slides API** ساخته شده است. این برنامه نشان می‌دهد که چگونه می‌توان تبدیل ODP به PPTX را با Aspose.Slides API پیاده‌سازی کرد.

## **سوالات متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

خیر. Aspose.Slides به صورت مستقل کار می‌کند و برای خواندن یا نوشتن ODP/PPTX به برنامه‌های شخص ثالث نیاز ندارد.

**آیا اسلایدهای اصلی، چیدمان‌ها و تم‌ها در هنگام تبدیل حفظ می‌شوند؟**

بله. این کتابخانه از یک مدل شیء کامل ارائه استفاده می‌کند و ساختار را شامل اسلایدهای اصلی و چیدمان‌ها حفظ می‌کند، به‌طوری‌که طراحی پس از تبدیل صحیح باقی می‌ماند.

**آیا می‌توانم فایل‌های ODP محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله. Aspose.Slides قابلیت تشخیص حفاظت، باز کردن و کار با [protected presentations](/slides/fa/php-java/password-protected-presentation/) (از جمله ODP) را هنگام ارائه رمز عبور دارد، همچنین می‌توانید رمزگذاری و دسترسی به ویژگی‌های سند را پیکربندی کنید.

**آیا Aspose.Slides برای سرویس‌های تبدیل مبتنی بر ابر یا REST مناسب است؟**

بله. می‌توانید کتابخانه محلی را در بک‌اند خود استفاده کنید یا از [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) (REST API) بهره ببرید؛ هر دو گزینه از تبدیل ODP → PPTX پشتیبانی می‌کنند.