---
title: واجهة API العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 15.6.0
type: docs
weight: 140
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المضافات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) من الفئات، والطرق، والخصائص وما إلى ذلك، وأي قيود جديدة والتغييرات الأخرى [المقدمة](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) التي تم تقديمها مع واجهة API Aspose.Slides لـ PHP عبر Java 15.6.0.

{{% /alert %}} 
## **تغييرات واجهة API العامة**
#### **تم تغيير توقيع منشئ com.aspose.slides.DataLabel**
تم تغيير توقيع المنشئ من DataLabel(com.aspose.slides.IChartSeries) إلى DataLabel(com.aspose.slides.IChartDataPoint).
#### **تم وضع الأعضاء com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) كـ Deprecated؛ تم تقديم بدائل بدلاً من ذلك**
تم وضع الطرق IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) كـ Deprecated. تم تقديم الطرق IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name) بدلاً من ذلك.
#### **تمت إضافة طريقة com.aspose.slides.INotesSlideManager.removeNotesSlide()**
تمت إضافة طريقة com.aspose.slides.INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تمت إضافة طريقة com.aspose.slides.ISlide.getNotesSlideManager(). وتم وضع الطرق ISlide.getNotesSlide() و ISlide.addNotesSlide() كـ Deprecated**
تم وضع الطرق ISlide.getNotesSlide() و ISlide.addNotesSlide() كـ Deprecated. استخدم الطريقة الجديدة ISlide.getNotesSlideManager() بدلاً من ذلك.

```php
  $slide = $$missing$;
  $notes;
  # notes = slide.addNotesSlide(); - deprecated
  # notes = slide.getNotesSlide(); - deprecated
  $notes = $slide->getNotesSlideManager()->getNotesSlide();
  $notes = $slide->getNotesSlideManager()->addNotesSlide();
  $slide->getNotesSlideManager()->removeNotesSlide();

```
#### **تمت إضافة طريقة getAppVersion() إلى com.aspose.slides.IDocumentProperties**
تمت إضافة طريقة com.aspose.slides.IDocumentProperties.getAppVersion() للحصول على خاصية المستند المدمجة، والتي تمثل أرقام الإصدارات الداخلية المستخدمة بواسطة Microsoft PowerPoint.
#### **تمت إضافة طريقة remove() إلى com.aspose.slides.IComment**
تمت إضافة طريقة com.aspose.slides.IComment.remove() لإزالة التعليق من المجموعة.
#### **تمت إضافة طريقة remove() إلى com.aspose.slides.ICommentAuthor**
تمت إضافة طريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تمت إضافة الطريقتين clearCustomProperties() و clearBuiltInProperties() إلى com.aspose.slides.IDocumentProperties**
تمت إضافة طريقة com.aspose.slides.IDocumentProperties.clearCustomProperties() لإزالة جميع خصائص المستند المخصصة.
تمت إضافة طريقة com.aspose.slides.IDocumentProperties.clearBuiltInProperties() لإزالة وتعيين القيم الافتراضية لجميع خصائص المستند المدمجة (الشركة، الموضوع، المؤلف، إلخ).
#### **تمت إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape**
تمت إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape.
تشير الطرق إلى كيفية عرض الشكل في وضع العرض بالأبيض والأسود. القيم الممكنة تم تحديدها في فئة com.aspose.slides.BlackWhiteMode.

|**القيمة** |**المعنى** |
| :- | :- |
|Color |إرجاع مع تلوين عادي |
|Automatic |إرجاع مع تلوين تلقائي |
|Gray |إرجاع مع تلوين رمادي |
|LightGray |إرجاع مع تلوين رمادي فاتح |
|InverseGray |إرجاع مع تلوين رمادي عكسي |
|GrayWhite |إرجاع مع تلوين رمادي وأبيض |
|BlackGray |إرجاع مع تلوين أسود ورمادي |
|BlackWhite |إرجاع مع تلوين أسود وأبيض |
|Black |إرجاع فقط مع تلوين أسود |
|White |إرجاع مع تلوين أبيض |
|Hidden |الشيء غير مدرج |
#### **تمت إضافة الطريقتين removeAt(int) و remove(ICommentAuthor) و clear() إلى com.aspose.slides.ICommentAuthorCollection**
تمت إضافة طريقة ICommentAuthorCollection.removeAt(int) لإزالة المؤلف حسب الفهرس المحدد. تمت إضافة طريقة ICommentAuthorCollection.remove(ICommentAuthor) لإزالة المؤلف المحدد من المجموعة. وتمت إضافة طريقة ICommentAuthorCollection.clear() لإزالة جميع العناصر من المجموعة.