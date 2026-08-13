---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.2.0
linktitle: Aspose.Slides لـ .NET 14.2.0
type: docs
weight: 40
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- الهجرة
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP بسلاسة."
---
## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
{{% alert color="info" %}} 
لقد قمنا بإجراء بعض التغييرات في واجهة برمجة التطبيقات Aspose.Slides لـ .NET 14.2.0. تم إزالة بعض الخصائص والطرق وتم نقل بعضها إلى مساحة أسماء أخرى.
{{% /alert %}} 
### **الطرق Aspose.Slides.IPresentation.Write(…) تم إزالتها**
هذه الطرق كانت تكتب كائنات Presentation فقط إلى ملف بصيغة PPTX. في الواجهة الجديدة، طبقة Presentation مخصصة للعمل مع جميع الصيغ. يمكن استخدام طرق Presentation.Save(…) لحفظ كائنات Presentation إلى جميع الصيغ المدعومة.
### **الصفوف المتعلقة بأنماط السمة تم نقلها إلى مساحة الأسماء Aspose.Slides.Theme**
تم نقل الصفوف التالية من مساحة الأسماء Aspose.Slides إلى مساحة الأسماء Aspose.Slides.Theme.

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
### **التغييرات من Aspose.Slides لـ .NET 8.X.0**
تم إضافة ميزات Aspose.Slides لـ .NET 8.4 إلى Aspose.Slides لـ .NET 14.2.0