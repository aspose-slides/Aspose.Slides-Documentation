---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للخلف في Aspose.Slides for .NET 15.6.0
linktitle: Aspose.Slides لـ .NET 15.6.0
type: docs
weight: 170
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لضمان ترحيل سلس لحلول عروض PowerPoint (PPT, PPTX) و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) أو [محذوفة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) ، والطرق ، والخصائص وما إلى ذلك ، وأية تغييرات أخرى تم تقديمها مع Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم تغيير توقيع منشئ DataLabel**
تم تغيير توقيع منشئ DataLabel:
كان: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
الآن: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **تم وضع الأعضاء IDocumentProperties.Count و .GetPropertyName(int index) و .Remove(string name) و .Contains(string name) كمهمل وتم إدخال بدائلها.**
تم وضع الخاصية IDocumentProperties.Count والطرق IDocumentProperties.GetPropertyName(int index) و .Remove(string name) و .Contains(string name) كمهمل. تم إضافة الخاصية IDocumentProperties.CountOfCustomProperties والطرق IDocumentProperties.GetCustomPropertyName(int index) و .RemoveCustomProperty(string name) و .ContainsCustomProperty(string name) كبدائل.
#### **تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide()**
تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تم إضافة الطريقة Remove إلى IComment**
تم إضافة الطريقة IComment.Remove لإزالة التعليق من المجموعة.
#### **تم إضافة الطريقة Remove إلى ICommentAuthor**
تم إضافة الطريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تم إضافة الطرق ClearCustomProperties و ClearBuiltInProperties إلى IDocumentProperties**
تم إضافة الطريقة IDocumentProperties.ClearCustomProperties لإزالة جميع خصائص المستند المخصصة.
تم إضافة الطريقة IDocumentProperties.ClearBuiltInProperties لإزالة وتعيين القيم الافتراضية لجميع خصائص المستند المدمجة (Company, Subject, Author إلخ).
#### **تم إضافة الطرق RemoveAt و Remove و Clear إلى ICommentAuthorCollection**
تم إضافة الطريقة ICommentAuthorCollection.RemoveAt لإزالة المؤلف حسب الفهرس المحدد.
تم إضافة الطريقة ICommentAuthorCollection.Remove لإزالة المؤلف المحدد من المجموعة.
تم إضافة الطريقة ICommentAuthorCollection.Clear لإزالة جميع العناصر من المجموعة.
#### **تم إضافة الخاصية AppVersion إلى IDocumentProperties**
تم إضافة الخاصية IDocumentProperties.AppVersion للحصول على خاصية المستند المدمجة التي تمثل أرقام الإصدار الداخلية المستخدمة من قبل Microsoft أثناء التطوير.
#### **تم إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape**
تم إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape.

هذه الخاصية تحدد كيفية عرض الشكل في وضع العرض بالأبيض والأسود.

|**القيمة**|**المعنى**|
| :- | :- |
|Color|عرض بألوان طبيعية|
|Automatic|عرض بألوان تلقائية|
|Gray|عرض باللون الرمادي|
|LightGray|عرض باللون الرمادي الفاتح|
|InverseGray|عرض باللون الرمادي العكسي|
|GrayWhite|عرض باللون الرمادي والأبيض|
|BlackGray|عرض باللون الأسود والرمادي|
|BlackWhite|عرض باللون الأسود والأبيض|
|Black|عرض باللون الأسود فقط|
|White|عرض باللون الأبيض|
|Hidden|عدم العرض|
|NotDefined|يعني أن الخاصية غير محددة|
#### **تم إضافة الخاصية ISlide.NotesSlideManager. تم وضع الخاصية ISlide.NotesSlide والطريقة ISlide.AddNotesSlide() كمهمل.**
تم وضع الأعضاء ISlide.NotesSlide و ISlide.AddNotesSlide() كمهمل. استخدم الخاصية الجديدة ISlide.NotesSlideManager بدلاً من ذلك.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```