---
title: تغييرات API العامة وتغييرات غير متوافقة إلى الخلف في Aspose.Slides لـ .NET 15.5.0
linktitle: Aspose.Slides لـ .NET 15.5.0
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
description: "مراجعة تحديثات API العامة والتغييرات المكسّرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تُظهر جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [مضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/)، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.5.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم إضافة الفئة CommonSlideViewProperties والواجهة ICommonSlideViewProperties**
الفئة Aspose.Slides.CommonSlideViewProperties والواجهة Aspose.Slides.ICommonSlideViewProperties تمثل خصائص عرض الشريحة المشتركة (حاليًا خيارات مقياس العرض).

#### **تم إضافة الخاصية IAxis.LabelOffset**
الخاصية IAxis.LabelOffset تحدد المسافة بين العلامات والمحور. تُطبق على محور الفئة أو التاريخ.

#### **تم إضافة الخاصية IChartTextBlockFormat.AutofitType**
تغيير هذه الخاصية يمكن أن يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ لا تأثير في PowerPoint 2007).

#### **تم إضافة الخاصية IChartTextBlockFormat.WrapText**
تغيير هذه الخاصية يمكن أن يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2007/2013).

#### **تم إضافة خصائص الهامش إلى IChartTextBlockFormat**
تغيير هذه الخصائص يمكن أن يؤثر فقط على أجزاء المخطط التالية: DataLabel و DataLabelFormat (دعم كامل في PowerPoint 2013؛ لا تأثير في PowerPoint 2007).

#### **تم إضافة الخاصية ViewProperties.NotesViewProperties**
تمت إضافة الخاصية Aspose.Slides.ViewProperties.NotesViewProperties. تحدد الخصائص العامة للعرض المرتبطة بوضع عرض الملاحظات.

#### **تم إضافة الخاصية ViewProperties.SlideViewProperties**
تمت إضافة الخاصية Aspose.Slides.ViewProperties.SlideViewProperties. تحدد الخصائص العامة للعرض المرتبطة بوضع عرض الشريحة.