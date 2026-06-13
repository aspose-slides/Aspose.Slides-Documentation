---
title: تبدیل ODP به PPTX در JavaScript
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/nodejs-java/convert-odp-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل ODP به PPTX با Aspose.Slides برای Node.js. مثال‌های کد تمیز JavaScript، نکات دسته‌ای، و نتایج با کیفیت بالا—بدون نیاز به PowerPoint."
---
## **بررسی کلی**

این مقاله نحوه تبدیل یک ارائه ODP به فرمت PPTX را با استفاده از Aspose.Slides توضیح می‌دهد.

## **تبدیل ODP به ارائه PPTX/PPT**
Aspose.Slides برای Node.js از طریق Java کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) را ارائه می‌دهد که یک فایل ارائه را نمایندگی می‌کند. کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) اکنون می‌تواند از طریق سازنده [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) به ODP دسترسی داشته باشد وقتی شیء ساخته می‌شود. مثال زیر نشان می‌دهد چگونه یک ارائه ODP را به ارائه PPTX تبدیل کنیم.

```javascript
// باز کردن فایل ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// ذخیرهٔ ارائه ODP به فرمت PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **مثال زنده**
می‌توانید وب‌اپلیکیشن [**تبدیل Aspose.Slides**](https://products.aspose.app/slides/fa/conversion/) را بازدید کنید که با **Aspose.Slides API** ساخته شده است. این برنامه نشان می‌دهد چگونه می‌توان تبدیل ODP به PPTX را با Aspose.Slides API پیاده‌سازی کرد.

## **سوالات متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

خیر. Aspose.Slides به صورت مستقل کار می‌کند و برای خواندن یا نوشتن ODP/PPTX به برنامه‌های شخص ثالث نیاز ندارد.

**آیا اسلایدهای اصلی، طرح‌بندی‌ها و تم‌ها در طول تبدیل حفظ می‌شوند؟**

بله. این کتابخانه از یک مدل شیء کامل برای ارائه استفاده می‌کند و ساختار، از جمله اسلایدهای اصلی و طرح‌بندی‌ها را حفظ می‌کند، بنابراین طراحی پس از تبدیل به درستی باقی می‌ماند.

**آیا می‌توانم فایل‌های ODP محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله. Aspose.Slides قابلیت شناسایی حفاظت، باز کردن و کار با [ارائه‌های محافظت‌شده](/slides/fa/nodejs-java/password-protected-presentation/) (از جمله ODP) را زمانی که رمز عبور را فراهم می‌کنید، دارد و همچنین امکان پیکربندی رمزنگاری و دسترسی به خصوصیات سند را فراهم می‌کند.

**آیا Aspose.Slides برای خدمات تبدیل مبتنی بر ابر یا REST مناسب است؟**

بله. می‌توانید کتابخانه محلی را در بک‌اند خود استفاده کنید یا از [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) (REST API) بهره‌گیرید؛ هر دو گزینه از تبدیل ODP → PPTX پشتیبانی می‌کنند.