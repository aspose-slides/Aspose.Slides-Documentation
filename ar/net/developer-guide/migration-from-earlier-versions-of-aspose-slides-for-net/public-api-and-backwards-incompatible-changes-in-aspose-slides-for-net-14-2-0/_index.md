---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 14.2.0
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- ترحيل
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET لتسهيل ترحيل حلول عروض PowerPoint بصيغ PPT و PPTX و ODP."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة**
{{% alert color="primary" %}} 

لقد أجرينا بعض التغييرات في واجهة برمجة التطبيقات Aspose.Slides for .NET 14.2.0. تم إزالة بعض الخصائص والطرق وتم نقل بعضها إلى مساحة أسماء أخرى.

{{% /alert %}} 
### **الطرق Aspose.Slides.IPresentation.Write(…) تمت إزالتها**
هذه الطرق كانت تقوم بكتابة كائنات Presentation فقط إلى ملف بصيغة PPTX. في واجهة البرمجة الجديدة، تُستخدم فئة Presentation للعمل مع جميع الصيغ. يمكن استخدام طرق Presentation.Save(…) لحفظ كائنات Presentation إلى جميع الصيغ المدعومة.
### **الفئات المتعلقة بأنماط السمة تم نقلها إلى مساحة أسماء Aspose.Slides.Theme**
تم نقل الفئات التالية من مساحة أسماء Aspose.Slides إلى مساحة أسماء Aspose.Slides.Theme.

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
### **التغييرات من Aspose.Slides for .NET 8.X.0**
تم إضافة ميزات Aspose.Slides for .NET 8.4 إلى Aspose.Slides for .NET 14.2.0