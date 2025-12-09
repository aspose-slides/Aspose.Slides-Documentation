---
title: "التغييرات العامة في واجهة برمجة التطبيقات والتغييرات غير المتوافقة للوراء في Aspose.Slides لـ .NET 15.6.0"
linktitle: "Aspose.Slides لـ .NET 15.6.0"
type: docs
weight: 170
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- "الترحيل"
- "كود قديم"
- "كود حديث"
- "نهج قديم"
- "نهج حديث"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 
تسرد هذه الصفحة جميع الفئات، والأساليب، والخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) أو [مزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) وتغييرات أخرى تم تقديمها مع Aspose.Slides for .NET 15.6.0 API.
{{% /alert %}} 
## **تغييرات API العامة**
#### **تم تغيير توقيع مُنشئ DataLabel**
تم تغيير توقيع مُنشئ DataLabel: كان: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries); الآن: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **تم وضع علامة على الأعضاء IDocumentProperties.Count، .GetPropertyName(int index)، .Remove(string name)، .Contains(string name) كمهملة وتم تقديم البدائل بدلاً منها.**
تم وضع علامة على الخاصية IDocumentProperties.Count والطرق IDocumentProperties.GetPropertyName(int index)، .Remove(string name)، .Contains(string name) كمهملة. تم إضافة الخاصية IDocumentProperties.CountOfCustomProperties والطرق IDocumentProperties.GetCustomPropertyName(int index)، .RemoveCustomProperty(string name)، .ContainsCustomProperty(string name) كبدائل.
#### **تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide()**
تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تم إضافة الطريقة Remove إلى IComment**
تم إضافة الطريقة IComment.Remove لإزالة التعليق من المجموعة.
#### **تم إضافة الطريقة Remove إلى ICommentAuthor**
تم إضافة الطريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تم إضافة الطرق ClearCustomProperties و ClearBuiltInProperties إلى IDocumentProperties**
تم إضافة الطريقة IDocumentProperties.ClearCustomProperties لإزالة جميع خصائص المستند المخصصة.
تم إضافة الطريقة IDocumentProperties.ClearBuiltInProperties لإزالة جميع خصائص المستند المدمجة وتعيين القيم الافتراضية لها (Company, Subject, Author وغيرها).
#### **تم إضافة الطرق RemoveAt و Remove و Clear إلى ICommentAuthorCollection**
تم إضافة الطريقة ICommentAuthorCollection.RemoveAt لإزالة المؤلف بحسب الفهرس المحدد.
تم إضافة الطريقة ICommentAuthorCollection.Remove لإزالة المؤلف المحدد من المجموعة.
تم إضافة الطريقة ICommentAuthorCollection.Clear لإزالة جميع العناصر من المجموعة.
#### **تم إضافة الخاصية AppVersion إلى IDocumentProperties**
تم إضافة الخاصية IDocumentProperties.AppVersion للحصول على خاصية المستند المدمجة التي تمثل أرقام الإصدارات الداخلية التي تستخدمها Microsoft أثناء التطوير.
#### **تم إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape**
تم إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape.

هذه الخاصية تحدد كيفية عرض الشكل في وضع اللونين الأسود والأبيض.

|**القيمة** |**المعنى** |
| :- | :- |
|Color |عرض بالألوان الطبيعية |
|Automatic |عرض بألوان تلقائية |
|Gray |عرض باللون الرمادي |
|LightGray |عرض بالرمادي الفاتح |
|InverseGray |عرض بالرمادي العكسي |
|GrayWhite |عرض بالرمادي والأبيض |
|BlackGray |عرض بالأسود والرمادي |
|BlackWhite |عرض بالأسود والأبيض |
|Black |عرض بالأسود فقط |
|White |عرض بالأبيض |
|Hidden |عدم العرض |
|NotDefined|يعني أن الخاصية غير مضبوطة|
#### **تم إضافة الخاصية ISlide.NotesSlideManager. تم وضع علامة على الخاصية ISlide.NotesSlide والطريقة ISlide.AddNotesSlide() كمهملة.**
تم وضع علامة على الأعضاء ISlide.NotesSlide و ISlide.AddNotesSlide() كمهملة. استخدم الخاصية الجديدة ISlide.NotesSlideManager بدلاً منها.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - مهملة

// notes = slide.NotesSlide; - مهملة

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```