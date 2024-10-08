---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.2.0
type: docs
weight: 40
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
{{% alert color="primary" %}} 

لقد أجرينا بعض التغييرات في واجهة برمجة التطبيقات Aspose.Slides لـ .NET 14.2.0. تم إزالة بعض الخصائص والطرق وتم نقل البعض إلى مساحة اسم أخرى.

{{% /alert %}} 
### **طرق Aspose.Slides.IPresentation.Write(…) تمت إزالتها**
كانت هذه الطرق تكتب كائنات العرض فقط إلى ملف بتنسيق PPTX. في واجهة برمجة التطبيقات الجديدة، تعد فئة Presentation للعمل مع جميع التنسيقات. من الممكن استخدام طرق Presentation.Save(…) لحفظ كائنات العرض إلى جميع التنسيقات المدعومة.
### **الفئات المتعلقة بأنماط القالب تم نقلها إلى مساحة اسم Aspose.Slides.Theme**
تمت نقل الفئات التالية من مساحة اسم Aspose.Slides إلى مساحة اسم Aspose.Slides.Theme.

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
تمت إضافة ميزات Aspose.Slides لـ .NET 8.4 إلى Aspose.Slides لـ .NET 14.2.0