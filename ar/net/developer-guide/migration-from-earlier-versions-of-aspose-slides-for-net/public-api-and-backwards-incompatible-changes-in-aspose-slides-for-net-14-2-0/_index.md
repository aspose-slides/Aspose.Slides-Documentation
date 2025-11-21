---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET 14.2.0
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- الترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---

## **واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة**
{{% alert color="primary" %}} 

لقد أجرينا بعض التغييرات في واجهة برمجة تطبيقات Aspose.Slides for .NET 14.2.0. تم إزالة بعض الخصائص والطرق وتم نقل بعضها إلى مساحة أسماء أخرى.

{{% /alert %}} 
### **الطرق Aspose.Slides.IPresentation.Write(…) تم إزالتها**
كانت هذه الطرق تقوم بكتابة كائنات Presentation فقط إلى ملف بصيغة PPTX. في الواجهة البرمجية الجديدة، فئة Presentation مخصصة للعمل مع جميع الصيغ. يمكن استخدام طرق Presentation.Save(…) لحفظ كائنات Presentation إلى جميع الصيغ المدعومة.
### **الفئات المتعلقة بأنماط السمة تم نقلها إلى مساحة الأسماء Aspose.Slides.Theme**
تم نقل الفئات التالية من مساحة الأسماء Aspose.Slides إلى مساحة الأسماء Aspose.Slides.Theme.

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