---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 14.2.0
linktitle: Aspose.Slides برای .NET 14.2.0
type: docs
weight: 40
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌راحتی راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت کنید."
---
## **API عمومی و تغییرات ناسازگار با نسخه‌های قبلی**
{{% alert color="primary" %}} 

ما برخی تغییرات را در API Aspose.Slides برای .NET 14.2.0 اعمال کرده‌ایم. برخی ویژگی‌ها و متدها حذف شده‌اند و برخی به فضای نام دیگری منتقل شده‌اند.

{{% /alert %}} 
### **متدهای Aspose.Slides.IPresentation.Write(…) حذف شده**
این متدها فقط اشیای Presentation را به فایل با فرمت PPTX می‌نوشتند. در API جدید، کلاس Presentation برای کار با تمام فرمت‌ها است. می‌توانید از متدهای Presentation.Save(…) برای ذخیرهٔ اشیای Presentation به تمام فرمت‌های پشتیبانی‌شده استفاده کنید.
### **کلاس‌های مرتبط با سبک‌ تم‌ها به فضای نام Aspose.Slides.Theme منتقل شدند**
کلاس‌های زیر از فضای نام Aspose.Slides به فضای نام Aspose.Slides.Theme منتقل شده‌اند.

- Types ColorScheme
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
### **تغییرات از Aspose.Slides برای .NET 8.X.0**
ویژگی‌های Aspose.Slides برای .NET 8.4 به Aspose.Slides برای .NET 14.2.0 اضافه شده‌اند.