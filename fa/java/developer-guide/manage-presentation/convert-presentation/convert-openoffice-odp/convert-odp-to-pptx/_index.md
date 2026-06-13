---
title: تبدیل ODP به PPTX در جاوا
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/java/convert-odp-to-pptx/
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
- جاوا
- Aspose.Slides
description: "تبدیل ODP به PPTX با Aspose.Slides برای جاوا. مثال‌های کد تمیز جاوا، نکات دسته‌ای، و نتایج با کیفیت بالا—بدون نیاز به PowerPoint."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه یک ارائه ODP را به فرمت PPTX با استفاده از Aspose.Slides تبدیل کنیم.

## **تبدیل ODP به نمایش‌نامه PPTX/PPT**
Aspose.Slides for Java کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) را ارائه می‌دهد که نماینده یک پرونده ارائه است. کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) اکنون می‌تواند از طریق سازنده [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) به ODP دسترسی پیدا کند وقتی شیء ساخته می‌شود. مثال زیر نشان می‌دهد چگونه یک ارائه ODP را به ارائه PPTX تبدیل کنیم.

```java
// باز کردن فایل ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ذخیرهٔ ارائه ODP به فرمت PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال زنده**
می‌توانید به برنامه وب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) مراجعه کنید که با **Aspose.Slides API** ساخته شده است. این برنامه نشان می‌دهد چطور تبدیل ODP به PPTX می‌تواند با Aspose.Slides API پیاده‌سازی شود.

## **سوالات متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

نه. Aspose.Slides به‌صورت مستقل کار می‌کند و برای خواندن یا نوشتن ODP/PPTX به برنامه‌های شخص ثالث نیازی ندارد.

**آیا اسلایدهای اصلی، طرح‌بندی‌ها و تم‌ها در طول تبدیل حفظ می‌شوند؟**

بله. کتابخانه از یک مدل شیء کامل برای ارائه استفاده می‌کند و ساختار شامل اسلایدهای اصلی و طرح‌بندی‌ها را حفظ می‌کند، بنابراین طراحی پس از تبدیل صحیح باقی می‌ماند.

**آیا می‌توانم فایل‌های ODP محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله. Aspose.Slides قابلیت شناسایی حفاظت، باز کردن و کار با [protected presentations](/slides/fa/java/password-protected-presentation/) (از جمله ODP) را هنگامی که رمز عبور را ارائه می‌دهید، پشتیبانی می‌کند و همچنین امکان پیکربندی رمزگذاری و دسترسی به خصوصیات سند را فراهم می‌کند.

**آیا Aspose.Slides برای خدمات تبدیل مبتنی بر ابر یا REST مناسب است؟**

بله. می‌توانید از کتابخانه محلی در بک‌اند خود استفاده کنید یا از [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) (REST API) بهره ببرید؛ هر دو گزینه پشتیبانی از تبدیل ODP → PPTX را دارند.