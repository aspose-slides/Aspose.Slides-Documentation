---
title: التغييرات في واجهة برمجة التطبيقات العامة وغير المتوافقة مع الإصدارات السابقة في Aspose.Slides للغة Java 15.6.0
linktitle: Aspose.Slides للغة Java 15.6.0
type: docs
weight: 140
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- ترحيل
- كود تقليدي
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات الجذرية في Aspose.Slides للغة Java لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP."
---
{{% alert color="primary" %}} 
تستعرض هذه الصفحة كل الفئات والطرق والخصائص وما إلى ذلك التي تم [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) ، وأية قيود جديدة وغيرها من [التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides للغة Java الإصدار 15.6.0.
{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **تم تغيير توقيع مُنشئ com.aspose.slides.DataLabel**
تم تغيير توقيع المُنشئ من DataLabel(com.aspose.slides.IChartSeries) إلى DataLabel(com.aspose.slides.IChartDataPoint).
#### **تم وضع علامة على الأعضاء com.aspose.slides.IDocumentProperties.getCount() و .getPropertyName(int index) و .remove(String name) و .contains(String name) كمهملين؛ تم تقديم بدائل بدلاً من ذلك**
تم وضع علامة على الطرق IDocumentProperties.getCount() و IDocumentProperties.getPropertyName(int index) و .remove(string name) و .contains(string name) كمهملين. تم تقديم الطرق IDocumentProperties.countOfCustomProperties() و IDocumentProperties.getCustomPropertyName(int index) و .removeCustomProperty(String name) و .containsCustomProperty(string name) كبدائل.
#### **تم إضافة الطريقة com.aspose.slides.INotesSlideManager.removeNotesSlide()**
تم إضافة الطريقة com.aspose.slides.INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تم إضافة الطريقة com.aspose.slides.ISlide.getNotesSlideManager(). تم وضع علامة على الطرق ISlide.getNotesSlide() و ISlide.addNotesSlide() كمهملين**
تم وضع علامة على الطرق ISlide.getNotesSlide() و ISlide.addNotesSlide() كمهملين. استخدم الطريقة الجديدة ISlide.getNotesSlideManager() بدلاً من ذلك.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - مهمل

// notes = slide.getNotesSlide(); - مهمل

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **تم إضافة الطريقة getAppVersion() إلى com.aspose.slides.IDocumentProperties**
تم إضافة الطريقة com.aspose.slides.IDocumentProperties.getAppVersion() للحصول على الخاصية المدمجة في المستند التي تمثل أرقام الإصدارات الداخلية المستخدمة بواسطة Microsoft PowerPoint.
#### **تم إضافة الطريقة remove() إلى com.aspose.slides.IComment**
تم إضافة الطريقة com.aspose.slides.IComment.remove() لإزالة التعليق من المجموعة.
#### **تم إضافة الطريقة remove() إلى com.aspose.slides.ICommentAuthor**
تم إضافة الطريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تم إضافة الطريقتين clearCustomProperties() و clearBuiltInProperties() إلى com.aspose.slides.IDocumentProperties**
تم إضافة الطريقة com.aspose.slides.IDocumentProperties.clearCustomProperties() لإزالة جميع خصائص المستند المخصصة.
تم إضافة الطريقة com.aspose.slides.IDocumentProperties.clearBuiltInProperties() لإزالة جميع خصائص المستند المدمجة (Company, Subject, Author وغيرها) وتعيين القيم الافتراضية لها.
#### **تم إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape**
تم إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape.
تحدد هذه الطرق كيفية عرض الشكل في وضع اللونين الأسود والأبيض. القيم الممكنة محددة في الفئة com.aspose.slides.BlackWhiteMode.

|**القيمة**|**المعنى**|
| :- | :- |
|Color|إرجاع بتلوين عادي|
|Automatic|إرجاع بتلوين تلقائي|
|Gray|إرجاع بتلوين رمادي|
|LightGray|إرجاع بتلوين رمادي فاتح|
|InverseGray|إرجاع بتلوين رمادي عكسي|
|GrayWhite|إرجاع بتلوين رمادي وأبيض|
|BlackGray|إرجاع بتلوين أسود ورمادي|
|BlackWhite|إرجاع بتلوين أسود وأبيض|
|Black|إرجاع بتلوين أسود فقط|
|White|إرجاع بتلوين أبيض|
|Hidden|الكائن غير معروض|
#### **تم إضافة الطريقتين removeAt(int) و remove(ICommentAuthor) والطريقة clear() إلى com.aspose.slides.ICommentAuthorCollection**
تم إضافة الطريقة ICommentAuthorCollection.removeAt(int) لإزالة المؤلف حسب الفهرس المحدد. تم إضافة الطريقة ICommentAuthorCollection.remove(ICommentAuthor) لإزالة المؤلف المحدد من المجموعة. تم إضافة الطريقة ICommentAuthorCollection.clear() لإزالة جميع العناصر من المجموعة.