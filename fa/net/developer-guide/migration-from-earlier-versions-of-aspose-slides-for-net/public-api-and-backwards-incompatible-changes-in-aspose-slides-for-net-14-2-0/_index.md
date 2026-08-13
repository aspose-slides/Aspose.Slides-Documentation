---
title: "API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 14.2.0"
linktitle: "Aspose.Slides برای .NET 14.2.0"
type: docs
weight: 40
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌راحتی راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
## **API عمومی و تغییرات ناسازگار با نسخه‌های قبلی**
{{% alert color="info" %}} 

ما تغییراتی در API Aspose.Slides برای .NET 14.2.0 اعمال کرده‌ایم. برخی از ویژگی‌ها و متدها حذف شده‌اند و برخی دیگر به فضای‌نام دیگری منتقل شده‌اند.

{{% /alert %}} 
### **متدهای Aspose.Slides.IPresentation.Write(…) حذف شدند**
این متدها فقط اشیای Presentation را به فایل با فرمت PPTX می‌نوشتند. در API جدید، کلاس Presentation برای کار با تمام فرمت‌ها است. می‌توانید از متدهای Presentation.Save(…) برای ذخیرهٔ اشیای Presentation به تمام فرمت‌های پشتیبانی‌شده استفاده کنید.
### **کلاس‌های مربوط به سبک‌های تم به فضای نام Aspose.Slides.Theme منتقل شدند**
کلاس‌های زیر از فضای نام Aspose.Slides به فضای نام Aspose.Slides.Theme منتقل شده‌اند.

- انواع ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **تغییرات نسبت به Aspose.Slides برای .NET 8.X.0**
ویژگی‌های Aspose.Slides برای .NET 8.4 به Aspose.Slides برای .NET 14.2.0 اضافه شده‌اند.