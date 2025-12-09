---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للعودة في Aspose.Slides لـ .NET 14.2.0
linktitle: Aspose.Slides لـ .NET 14.2.0
type: docs
weight: 40
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "راجع تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---

## **Public API and Backwards Incompatible Changes**
{{% alert color="primary" %}} 

قمنا بإجراء بعض التغييرات في API لـ Aspose.Slides for .NET 14.2.0. تم إزالة بعض الخصائص والطرق وتم نقل بعضها إلى مساحة أسماء أخرى.

{{% /alert %}} 
### **Methods Aspose.Slides.IPresentation.Write(…) Removed**
كتبت هذه الطرق كائنات Presentation فقط إلى ملف بصيغة PPTX. في الـ API الجديد، تُستخدم فئة Presentation للعمل مع جميع الصيغ. يمكن استخدام طرق Presentation.Save(…) لحفظ كائنات Presentation إلى جميع الصيغ المدعومة.
### **Classes Related to Theme Styles Moved to the Aspose.Slides.Theme Namespace**
تم نقل الفئات التالية من مساحة الاسم Aspose.Slides إلى مساحة الاسم Aspose.Slides.Theme.

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
### **Changes from Aspose.Slides for .NET 8.X.0**
تم إضافة ميزات Aspose.Slides for .NET 8.4 إلى Aspose.Slides for .NET 14.2.0