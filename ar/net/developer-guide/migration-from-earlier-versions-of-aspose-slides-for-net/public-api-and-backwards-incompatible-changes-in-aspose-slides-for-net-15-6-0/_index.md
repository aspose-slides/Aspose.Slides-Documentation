---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.6.0
linktitle: Aspose.Slides لـ .NET 15.6.0
type: docs
weight: 170
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- الترحيل
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 
تسرد هذه الصفحة جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/)، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.6.0 API.
{{% /alert %}} 
## **التغييرات العامة في API**
#### **تم تغيير توقيع منشئ DataLabel**
تم تغيير توقيع منشئ DataLabel:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **تم وضع العلامة Obsolete على الأعضاء IDocumentProperties.Count، .GetPropertyName(int index)، .Remove(string name)، .Contains(string name) وتم تقديم بدائل لها.**
تم وضع العلامة Obsolete على الخاصية IDocumentProperties.Count وعلى الطرق IDocumentProperties.GetPropertyName(int index)، .Remove(string name)، .Contains(string name). تم إضافة الخاصية IDocumentProperties.CountOfCustomProperties وعلى الطرق IDocumentProperties.GetCustomPropertyName(int index)، .RemoveCustomProperty(string name)، .ContainsCustomProperty(string name) كبدائل.
#### **تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide()**
تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تم إضافة الطريقة Remove إلى IComment**
تم إضافة الطريقة IComment.Remove لإزالة التعليق من المجموعة.
#### **تم إضافة الطريقة Remove إلى ICommentAuthor**
تم إضافة الطريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تم إضافة الطريقتين ClearCustomProperties و ClearBuiltInProperties إلى IDocumentProperties**
تم إضافة الطريقة IDocumentProperties.ClearCustomProperties لإزالة جميع خصائص المستند المخصصة.
تم إضافة الطريقة IDocumentProperties.ClearBuiltInProperties لإزالة جميع خصائص المستند المدمجة وتعيين القيم الافتراضية لها (Company, Subject, Author وغيرها).
#### **تم إضافة الطرق RemoveAt و Remove و Clear إلى ICommentAuthorCollection**
تم إضافة الطريقة ICommentAuthorCollection.RemoveAt لإزالة المؤلف وفق الفهرس المحدد.
تم إضافة الطريقة ICommentAuthorCollection.Remove لإزالة المؤلف المحدد من المجموعة.
تم إضافة الطريقة ICommentAuthorCollection.Clear لإزالة جميع العناصر من المجموعة.
#### **تم إضافة الخاصية AppVersion إلى IDocumentProperties**
تم إضافة الخاصية IDocumentProperties.AppVersion للحصول على خاصية المستند المدمجة التي تمثل أرقام الإصدارات الداخلية التي تستخدمها Microsoft أثناء التطوير.
#### **تم إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape**
تم إضافة الخاصية BlackWhiteMode إلى IShape وإلى Shape.

تحدد هذه الخاصية كيفية عرض الشكل في وضع العرض بالأبيض والأسود.

|**القيمة** |**المعنى** |
| :- | :- |
|Color |عرض بالألوان الطبيعية |
|Automatic |عرض بألوان تلقائية |
|Gray |عرض باللون الرمادي |
|LightGray |عرض باللون الرمادي الفاتح |
|InverseGray |عرض باللون الرمادي المعكوس |
|GrayWhite |عرض باللون الرمادي والأبيض |
|BlackGray |عرض باللون الأسود والرمادي |
|BlackWhite |عرض باللون الأسود والأبيض |
|Black |عرض باللون الأسود فقط |
|White |عرض باللون الأبيض |
|Hidden |عدم العرض |
|NotDefined|يعني أن الخاصية غير مضبوطة|
#### **تم إضافة الخاصية ISlide.NotesSlideManager. تم وضع علامة Obsolete على الخاصيتين ISlide.NotesSlide و ISlide.AddNotesSlide().**
تم وضع علامة Obsolete على الأعضاء ISlide.NotesSlide و ISlide.AddNotesSlide(). استخدم الخاصية الجديدة ISlide.NotesSlideManager بدلاً منها.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```