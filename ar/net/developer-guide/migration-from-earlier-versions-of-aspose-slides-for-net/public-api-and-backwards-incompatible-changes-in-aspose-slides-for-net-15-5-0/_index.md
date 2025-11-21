---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides for .NET 15.5.0
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for .NET لتسهيل ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP الخاصة بك بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تُدرج جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) لها، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.5.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة الفئة CommonSlideViewProperties والواجهة ICommonSlideViewProperties**
تمثل الفئة Aspose.Slides.CommonSlideViewProperties والواجهة Aspose.Slides.ICommonSlideViewProperties خصائص عرض الشريحة المشتركة (حالياً خيارات مقياس العرض).

#### **تم إضافة خاصية IAxis.LabelOffset**
خاصية IAxis.LabelOffset تحدد المسافة بين التسميات والمحور. تُطبق على محور الفئات أو التاريخ.

#### **تم إضافة خاصية IChartTextBlockFormat.AutofitType**
تغيير هذه الخاصية قد يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير عند العرض).

#### **تم إضافة خاصية IChartTextBlockFormat.WrapText**
تغيير هذه الخاصية قد يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2007/2013).

#### **تم إضافة خصائص الهوامش إلى IChartTextBlockFormat**
تغيير هذه الخصائص قد يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ في PowerPoint 2007 لا يوجد تأثير عند العرض).

#### **تم إضافة خاصية ViewProperties.NotesViewProperties**
تم إضافة خاصية Aspose.Slides.ViewProperties.NotesViewProperties. تحدد الخصائص العامة للعرض المرتبطة بوضع عرض الملاحظات.

#### **تم إضافة خاصية ViewProperties.SlideViewProperties**
تم إضافة خاصية Aspose.Slides.ViewProperties.SlideViewProperties. تحدد الخصائص العامة للعرض المرتبطة بوضع عرض الشريحة.