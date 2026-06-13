---
title: تبدیل ODP به PPTX در اندروید
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/androidjava/convert-odp-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "ODP را با Aspose.Slides برای اندروید به PPTX تبدیل کنید. مثال‌های کد تمیز جاوا، نکات دسته‌ای، و نتایج با کیفیت بالا—بدون نیاز به PowerPoint."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه یک ارائه ODP را به فرمت PPTX با استفاده از Aspose.Slides تبدیل کنید.

## **تبدیل ODP به ارائه PPTX/PPT**
Aspose.Slides for Android via Java کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) را ارائه می‌دهد که یک فایل ارائه را نمایندگی می‌کند. کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) اکنون می‌تواند از طریق سازنده [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) ODP را نیز دسترسی داشته باشد وقتی شیء ساخته می‌شود. مثال زیر نشان می‌دهد چگونه یک ارائه ODP را به ارائه PPTX تبدیل کنیم.

```java
// فایل ODP را باز کنید
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ذخیره ارائه ODP به فرمت PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال زنده**
می‌توانید برنامه وب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) را بازدید کنید که با **Aspose.Slides API** ساخته شده است. این برنامه نشان می‌دهد که تبدیل ODP به PPTX چگونه می‌تواند با Aspose.Slides API پیاده‌سازی شود.

## **سوالات متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

خیر. Aspose.Slides به صورت مستقل کار می‌کند و برای خواندن یا نوشتن ODP/PPTX به برنامه‌های شخص ثالث نیاز ندارد.

**آیا اسلایدهای اصلی، چیدمان‌ها و قالب‌ها در طول تبدیل حفظ می‌شوند؟**

بله. کتابخانه از یک مدل شیء کامل ارائه استفاده می‌کند و ساختار، از جمله اسلایدهای اصلی و چیدمان‌ها را حفظ می‌کند، بنابراین طراحی پس از تبدیل صحیح می‌ماند.

**آیا می‌توانم فایل‌های ODP محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله. Aspose.Slides قابلیت تشخیص حفاظت، باز کردن و کار با [protected presentations](/slides/fa/androidjava/password-protected-presentation/) (از جمله ODP) را هنگام ارائه رمز عبور دارد و همچنین امکان پیکربندی رمزگذاری و دسترسی به ویژگی‌های سند را فراهم می‌کند.

**آیا Aspose.Slides برای خدمات تبدیل ابری یا مبتنی بر REST مناسب است؟**

بله. می‌توانید کتابخانه محلی را در پشت‌انتظام خود یا [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) (REST API) استفاده کنید؛ هر دو گزینه از تبدیل ODP → PPTX پشتیبانی می‌کنند.