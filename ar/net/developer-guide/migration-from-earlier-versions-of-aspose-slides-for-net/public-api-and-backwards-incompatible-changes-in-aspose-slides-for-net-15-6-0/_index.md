---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة إلى الوراء في Aspose.Slides لـ .NET 15.6.0
type: docs
weight: 170
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع [الأصناف المضافة](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) أو [المزالة](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) والأساليب والخصائص وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 15.6.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم تغيير توقيع مُنشئ DataLabel**
تم تغيير توقيع مُنشئ DataLabel:
كان: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
الآن: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **تم وضع الأعضاء IDocumentProperties.Count و .GetPropertyName(int index) و .Remove(string name) و .Contains(string name) كـ Obsolete وقد تم إدخال بدائل لها بدلاً من ذلك.**
تم وضع الخاصية IDocumentProperties.Count والأساليب IDocumentProperties.GetPropertyName(int index) و .Remove(string name) و .Contains(string name) كـ Obsolete. تم إضافة الخاصية IDocumentProperties.CountOfCustomProperties والأساليب IDocumentProperties.GetCustomPropertyName(int index) و .RemoveCustomProperty(string name) و .ContainsCustomProperty(string name) بدلاً من ذلك.
#### **تم إضافة طريقة INotesSlideManager.RemoveNotesSlide()**
تم إضافة طريقة INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تم إضافة طريقة Remove إلى IComment**
تم إضافة طريقة IComment.Remove لإزالة تعليق من المجموعة.
#### **تم إضافة طريقة Remove إلى ICommentAuthor**
تم إضافة طريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تم إضافة طرق ClearCustomProperties و ClearBuiltInProperties إلى IDocumentProperties**
تم إضافة طريقة IDocumentProperties.ClearCustomProperties لإزالة جميع الخصائص المخصصة للمستند.
تم إضافة طريقة IDocumentProperties.ClearBuiltInProperties لإزالة وتعيين القيم الافتراضية لجميع الخصائص المدمجة للمستند (الشركة، الموضوع، المؤلف، إلخ).
#### **تم إضافة طرق RemoveAt و Remove و Clear إلى ICommentAuthorCollection**
تم إضافة طريقة ICommentAuthorCollection.RemoveAt لإزالة المؤلف حسب الفهرس المحدد.
تم إضافة طريقة ICommentAuthorCollection.Remove لإزالة المؤلف المحدد من المجموعة.
تم إضافة طريقة ICommentAuthorCollection.Clear لإزالة جميع العناصر من المجموعة.
#### **تم إضافة خاصية AppVersion إلى IDocumentProperties**
تم إضافة خاصية IDocumentProperties.AppVersion للحصول على خاصية المستند المدمجة التي تمثل أرقام الإصدار الداخلية المستخدمة من قبل Microsoft خلال التطوير.
#### **تم إضافة خاصية BlackWhiteMode إلى IShape و Shape**
تم إضافة خاصية BlackWhiteMode إلى IShape و Shape.

تحدد هذه الخاصية كيفية عرض الشكل في وضع العرض بالأبيض والأسود.

|**القيمة** |**المعنى** |
| :- | :- |
|Color |عرض بألوان طبيعية |
|Automatic |عرض بتلوين تلقائي |
|Gray |عرض بتلوين رمادي |
|LightGray |عرض بتلوين رمادي فاتح |
|InverseGray |عرض بتلوين رمادي مقلوب |
|GrayWhite |عرض بتلوين رمادي وأبيض |
|BlackGray |عرض بتلوين أسود ورمادي |
|BlackWhite |عرض بتلوين أسود وأبيض |
|Black |عرض بتلوين أسود فقط |
|White |عرض بتلوين أبيض |
|Hidden |عدم العرض |
|NotDefined|يعني أن الخاصية غير محددة|
#### **تمت إضافة الخاصية ISlide.NotesSlideManager. تم وضع الخاصية ISlide.NotesSlide وطريقة ISlide.AddNotesSlide() كـ Obsolete.**
تم وضع الأعضاء ISlide.NotesSlide و ISlide.AddNotesSlide() كـ Obsolete. استخدم الخاصية الجديدة ISlide.NotesSlideManager بدلاً من ذلك.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - عفا عليه الزمن

// notes = slide.NotesSlide; - عفا عليه الزمن

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

``` 