---
title: تغييرات API العامة وغير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.6.0
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- ترحيل
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات API العامة والتغييرات المكسرة في Aspose.Slides for .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، والطرق، والخصائص، وما إلى ذلك التي تم [مضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) أو [محذوف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) عنها، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم تغيير توقيع منشئ DataLabel**
تم تغيير توقيع منشئ DataLabel:
كان: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
الآن: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **تم وضع علامة على الأعضاء IDocumentProperties.Count، .GetPropertyName(int index)، .Remove(string name)، .Contains(string name) كمهمل وتم تقديم بدائل لها.**
تم وضع علامة على الخاصية IDocumentProperties.Count والطرق IDocumentProperties.GetPropertyName(int index)، .Remove(string name)، .Contains(string name) كمهمل. تم إضافة الخاصية IDocumentProperties.CountOfCustomProperties والطرق IDocumentProperties.GetCustomPropertyName(int index)، .RemoveCustomProperty(string name)، .ContainsCustomProperty(string name) بدلاً منها.
#### **تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide()**
تمت إضافة الطريقة INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تم إضافة الطريقة Remove إلى IComment**
تمت إضافة الطريقة Remove إلى IComment لإزالة التعليق من المجموعة.
#### **تم إضافة الطريقة Remove إلى ICommentAuthor**
تمت إضافة الطريقة Remove إلى ICommentAuthor لإزالة مؤلف التعليقات من المجموعة.
#### **تم إضافة الطريقتين ClearCustomProperties و ClearBuiltInProperties إلى IDocumentProperties**
تمت إضافة الطريقة IDocumentProperties.ClearCustomProperties لإزالة جميع خصائص المستند المخصصة.
تمت إضافة الطريقة IDocumentProperties.ClearBuiltInProperties لإزالة جميع خصائص المستند المدمجة وتعيين القيم الافتراضية لها (Company، Subject، Author وغيرها).
#### **تم إضافة الطريقتين RemoveAt و Remove و Clear إلى ICommentAuthorCollection**
تمت إضافة الطريقة ICommentAuthorCollection.RemoveAt لإزالة المؤلف وفق الفهرس المحدد.
تمت إضافة الطريقة ICommentAuthorCollection.Remove لإزالة المؤلف المحدد من المجموعة.
تمت إضافة الطريقة ICommentAuthorCollection.Clear لإزالة جميع العناصر من المجموعة.
#### **تم إضافة الخاصية AppVersion إلى IDocumentProperties**
تمت إضافة الخاصية IDocumentProperties.AppVersion للحصول على خاصية المستند المدمجة التي تمثل أرقام الإصدارات الداخلية التي تستخدمها Microsoft أثناء التطوير.
#### **تم إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape**
تمت إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape.

هذه الخاصية تحدد كيف سيظهر الشكل في وضع العرض بالأبيض والأسود.

|**القيمة**|**المعنى**|
| :- | :- |
|Color|عرض بألوان طبيعية|
|Automatic|عرض بألوان تلقائية|
|Gray|عرض باللون الرمادي|
|LightGray|عرض بالرمادي الفاتح|
|InverseGray|عرض بالرمادي العكسي|
|GrayWhite|عرض بالرمادي والأبيض|
|BlackGray|عرض بالأسود والرمادي|
|BlackWhite|عرض بالأسود والأبيض|
|Black|عرض باللون الأسود فقط|
|White|عرض باللون الأبيض|
|Hidden|عدم العرض|
|NotDefined|يعني أن الخاصية غير مضبوطة|
#### **تم إضافة الخاصية ISlide.NotesSlideManager. تم وضع علامة على الخاصية ISlide.NotesSlide والطريقة ISlide.AddNotesSlide() كمهمل.**
تم وضع علامة على الأعضاء ISlide.NotesSlide و ISlide.AddNotesSlide() كمهمل. استخدم الخاصية الجديدة ISlide.NotesSlideManager بدلاً من ذلك.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - مهمل

// notes = slide.NotesSlide; - مهمل

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```