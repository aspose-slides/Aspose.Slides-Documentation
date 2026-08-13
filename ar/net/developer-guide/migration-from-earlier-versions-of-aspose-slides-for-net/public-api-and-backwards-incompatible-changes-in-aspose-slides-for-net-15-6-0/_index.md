---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.6.0
linktitle: Aspose.Slides for .NET 15.6.0
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسّرة في Aspose.Slides for .NET للقيام بعملية ترحيل سلسة لحلول عروض PowerPoint (PPT، PPTX) و ODP."
---
{{% alert color="info" %}} 

هذه الصفحة تُسرد جميع [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) الفئات، والطرق، والخصائص وما إلى ذلك، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تم تغيير توقيع مُنشئ DataLabel**
تم تغيير توقيع مُنشئ DataLabel: السابق: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries); الآن: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).

#### **تم وضع العلامة Obsolete على الأعضاء IDocumentProperties.Count، .GetPropertyName(int index)، .Remove(string name)، .Contains(string name) وتم تقديم بدائل لها**
تم وضع العلامة Obsolete على الخاصية IDocumentProperties.Count والطرق IDocumentProperties.GetPropertyName(int index)، .Remove(string name)، .Contains(string name). تم إضافة الخاصية IDocumentProperties.CountOfCustomProperties والطرق IDocumentProperties.GetCustomPropertyName(int index)، .RemoveCustomProperty(string name)، .ContainsCustomProperty(string name) كبدائل.

#### **تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide()**
تم إضافة الطريقة INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات لشريحة معينة.

#### **تم إضافة طريقة Remove إلى IComment**
تم إضافة الطريقة IComment.Remove لإزالة التعليق من المجموعة.

#### **تم إضافة طريقة Remove إلى ICommentAuthor**
تم إضافة الطريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.

#### **تم إضافة الطريقتين ClearCustomProperties و ClearBuiltInProperties إلى IDocumentProperties**
تم إضافة الطريقة IDocumentProperties.ClearCustomProperties لإزالة جميع خصائص المستند المخصصة.
تم إضافة الطريقة IDocumentProperties.ClearBuiltInProperties لإزالة وتعيين القيم الافتراضية لجميع خصائص المستند المدمجة (Company، Subject، Author وغيرها).

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
|لون |عرض بتلوين طبيعي |
|تلقائي |عرض بتلوين تلقائي |
|رمادي |عرض بتلوين رمادي |
|رمادي فاتح |عرض بتلوين رمادي فاتح |
|رمادي عكسي |عرض بتلوين رمادي عكسي |
|رمادي-أبيض |عرض بتلوين رمادي وأبيض |
|أسود-رمادي |عرض بتلوين أسود ورمادي |
|أسود-أبيض |عرض بتلوين أسود وأبيض |
|أسود |عرض بتلوين أسود فقط |
|أبيض |عرض بتلوين أبيض |
|مخفي |عدم العرض |
|NotDefined |يعني أن الخاصية غير مُحددة |

#### **تم إضافة الخاصية ISlide.NotesSlideManager. تم وضع علامة Obsolete على الخاصية ISlide.NotesSlide والطريقة ISlide.AddNotesSlide()**
تم وضع علامة Obsolete على الأعضاء ISlide.NotesSlide و ISlide.AddNotesSlide(). استخدم الخاصية الجديدة ISlide.NotesSlideManager بدلاً من ذلك.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - مهمل
    // notes = slide.NotesSlide; - مهمل

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```