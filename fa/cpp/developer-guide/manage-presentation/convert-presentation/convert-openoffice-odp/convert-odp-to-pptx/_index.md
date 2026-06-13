---
title: تبدیل ODP به PPTX در C++
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/cpp/convert-odp-to-pptx/
keywords:
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل ODP
- OpenDocument به PPTX
- ODP به PPTX
- ذخیره ODP به عنوان PPTX
- صدور ODP به PPTX
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ODP را با Aspose.Slides برای C++ به PPTX تبدیل کنید. مثال‌های کد تمیز، نکات پردازش دسته‌ای، و نتایج با کیفیت بالا—بدون نیاز به PowerPoint."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه یک ارائه ODP را به فرمت PPTX با استفاده از Aspose.Slides تبدیل کنید.

## **تبدیل ODP به PPTX**

Aspose.Slides برای .NET کلاس Presentation را ارائه می‌دهد که یک فایل ارائه را نشان می‌دهد. کلاس [**Presentation**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) اکنون می‌تواند از طریق سازنده Presentation به ODP دسترسی داشته باشد هنگامی که شیء ساخته می‌شود. مثال زیر نشان می‌دهد چگونه یک ارائه ODP را به ارائه PPTX تبدیل کنیم.

``` cpp
// مسیر به پوشه اسناد.
String dataDir = GetDataPath();

// فایل ODP را باز کنید
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// ذخیره ارائه ODP به فرمت PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **مثال زنده**

می‌توانید برنامه وب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) را بازدید کنید که با **Aspose.Slides API** ساخته شده است. این برنامه نشان می‌دهد چگونه تبدیل ODP به PPTX می‌تواند با Aspose.Slides API پیاده‌سازی شود.

## **سوالات متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

خیر. Aspose.Slides به صورت مستقل کار می‌کند و برای خواندن یا نوشتن ODP/PPTX به برنامه‌های شخص ثالث نیاز ندارد.

**آیا اسلایدهای اصلی، چیدمان‌ها و تم‌ها در طول تبدیل حفظ می‌شوند؟**

بله. این کتابخانه از مدل شیء کامل ارائه استفاده می‌کند و ساختار، از جمله اسلایدهای اصلی و چیدمان‌ها را حفظ می‌نماید، بنابراین طراحی پس از تبدیل صحیح باقی می‌ماند.

**آیا می‌توانم فایل‌های ODP دارای رمز عبور را تبدیل کنم؟**

بله. Aspose.Slides قابلیت تشخیص حفاظت را دارد، می‌تواند ارائه‌های [protected presentations](/slides/fa/cpp/password-protected-presentation/) (از جمله ODP) را هنگام ارائه رمز عبور باز کند و کار کند، همچنین امکان پیکربندی رمزنگاری و دسترسی به ویژگی‌های سند را فراهم می‌کند.

**آیا Aspose.Slides برای خدمات تبدیل مبتنی بر ابری یا REST مناسب است؟**

بله. می‌توانید از کتابخانه محلی در بک‌اند خود استفاده کنید یا از [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) (REST API) استفاده کنید؛ هر دو گزینه از تبدیل ODP → PPTX پشتیبانی می‌کنند.