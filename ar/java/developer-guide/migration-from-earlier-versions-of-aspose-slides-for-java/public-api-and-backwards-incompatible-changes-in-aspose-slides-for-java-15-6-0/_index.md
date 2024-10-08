---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.6.0
type: docs
weight: 140
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المضافات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) من الفئات، والطرق، والخصائص وما إلى ذلك، وأي قيود جديدة وتغييرات أخرى [تم تقديمها](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.6.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم تغيير توقيع مُنشئ com.aspose.slides.DataLabel**
تم تغيير توقيع المُنشئ من DataLabel(com.aspose.slides.IChartSeries) إلى DataLabel(com.aspose.slides.IChartDataPoint).
#### **تم وضع علامات على الأعضاء com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) على أنها مهجورة; وقد تم تقديم بدائل بدلاً منها**
تم وضع علامات على الطرق IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) على أنها مهجورة. تم تقديم طرق IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) بدلاً منها.
#### **تمت إضافة طريقة com.aspose.slides.INotesSlideManager.removeNotesSlide()**
تمت إضافة طريقة com.aspose.slides.INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تمت إضافة طريقة com.aspose.slides.ISlide.getNotesSlideManager(). تم وضع علامات على الطرق ISlide.getNotesSlide() و ISlide.addNotesSlide() على أنها مهجورة**
تم وضع علامات على الطرق ISlide.getNotesSlide(), ISlide.addNotesSlide() على أنها مهجورة. استخدم الطريقة الجديدة ISlide.getNotesSlideManager() بدلاً منها.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - مهجورة

// notes = slide.getNotesSlide(); - مهجورة

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **تمت إضافة طريقة getAppVersion() إلى com.aspose.slides.IDocumentProperties**
تمت إضافة طريقة com.aspose.slides.IDocumentProperties.getAppVersion() لاسترجاع خاصية الوثيقة المدمجة، والتي تمثل أرقام الإصدارات الداخلية المستخدمة من قبل Microsoft PowerPoint.
#### **تمت إضافة طريقة remove() إلى com.aspose.slides.IComment**
تمت إضافة طريقة com.aspose.slides.IComment.remove() لإزالة التعليق من المجموعة.
#### **تمت إضافة طريقة remove() إلى com.aspose.slides.ICommentAuthor**
تمت إضافة طريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تمت إضافة طريقتين clearCustomProperties() و clearBuiltInProperties() إلى com.aspose.slides.IDocumentProperties**
تمت إضافة طريقة com.aspose.slides.IDocumentProperties.clearCustomProperties() لإزالة جميع خصائص الوثيقة المخصصة.
تمت إضافة طريقة com.aspose.slides.IDocumentProperties.clearBuiltInProperties() لإزالة وتعيين القيم الافتراضية لجميع خصائص الوثيقة المدمجة (الشركة، الموضوع، المؤلف، إلخ).
#### **تمت إضافة طريقتين getBlackWhiteMode(), setBlackWhiteMode(byte) إلى com.aspose.slides.IShape**
تمت إضافة الطريقتين getBlackWhiteMode(), setBlackWhiteMode(byte) إلى com.aspose.slides.IShape.
تحدد الطريقتان كيفية عرض الشكل في وضع العرض بالأبيض والأسود. القيم الممكنة محددة في فئة com.aspose.slides.BlackWhiteMode.

|**القيمة** |**المعنى** |
| :- | :- |
|Color |الإرجاع مع تلوين طبيعي |
|Automatic |الإرجاع مع تلوين تلقائي |
|Gray |الإرجاع مع تلوين رمادي |
|LightGray |الإرجاع مع تلوين رمادي فاتح |
|InverseGray |الإرجاع مع تلوين رمادي مقلوب |
|GrayWhite |الإرجاع مع تلوين رمادي وأبيض |
|BlackGray |الإرجاع مع تلوين أسود ورمادي |
|BlackWhite |الإرجاع مع تلوين أسود وأبيض |
|Black |الإرجاع فقط مع تلوين أسود |
|White |الإرجاع مع تلوين أبيض |
|Hidden |الشيء غير مرئي |
#### **تمت إضافة الطريقتين removeAt(int), remove(ICommentAuthor) و clear() إلى com.aspose.slides.ICommentAuthorCollection**
تمت إضافة طريقة ICommentAuthorCollection.removeAt(int) لإزالة المؤلف بواسطة الفهرس المحدد. تمت إضافة طريقة ICommentAuthorCollection.remove(ICommentAuthor) لإزالة المؤلف المحدد من المجموعة. تمت إضافة طريقة ICommentAuthorCollection.clear() لإزالة جميع العناصر من المجموعة.