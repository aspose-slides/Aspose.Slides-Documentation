---
title: الواجهة العامة لبرمجة التطبيقات والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.5.0
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتعارضة في Aspose.Slides for .NET لضمان ترحيل سلس لحلول العروض التقديمية PowerPoint (PPT، PPTX) و ODP."
---

{{% alert color="primary" %}} 

تُظهر هذه الصفحة جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/)، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.5.0 API.

{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **تم إضافة فئة CommonSlideViewProperties والواجهة ICommonSlideViewProperties**
تمثل فئة Aspose.Slides.CommonSlideViewProperties والواجهة Aspose.Slides.ICommonSlideViewProperties خصائص عرض الشريحة المشتركة (حاليًا خيارات مقياس العرض).
#### **تم إضافة خاصية IAxis.LabelOffset**
تحدد خاصية IAxis.LabelOffset المسافة بين التسميات والمحور. تُطبق على محور الفئة أو التاريخ.
#### **تم إضافة خاصية IChartTextBlockFormat.AutofitType**
تغيير هذه الخاصية يمكن أن يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير على العرض).
#### **تم إضافة خاصية IChartTextBlockFormat.WrapText**
تغيير هذه الخاصية يمكن أن يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2007/2013).
#### **تم إضافة خصائص الهوامش إلى IChartTextBlockFormat**
تغيير هذه الخصائص يمكن أن يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير على العرض).
#### **تم إضافة خاصية ViewProperties.NotesViewProperties**
تمت إضافة خاصية Aspose.Slides.ViewProperties.NotesViewProperties. تحدد الخصائص العامة للعرض المرتبطة بوضع عرض الملاحظات.
#### **تم إضافة خاصية ViewProperties.SlideViewProperties**
تمت إضافة خاصية Aspose.Slides.ViewProperties.SlideViewProperties. تحدد الخصائص العامة للعرض المرتبطة بوضع عرض الشريحة.