---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.6.0
type: docs
weight: 140
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [الإضافات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) من الفئات، والطرق، والخصائص، وما إلى ذلك، وأي قيود جديدة، و[التغييرات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.6.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم تغيير توقيع المُنشئ com.aspose.slides.DataLabel**
تم تغيير توقيع المُنشئ من DataLabel(com.aspose.slides.IChartSeries) إلى DataLabel(com.aspose.slides.IChartDataPoint).
#### **تم وضع الأعضاء com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) كـ Deprecated؛ وقد تم تقديم البدائل بدلاً منها**
تم وضع الطرق IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) كـ Deprecated. وتم تقديم الطرق IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name) بدلاً منها.
#### **تم إضافة الطريقة com.aspose.slides.INotesSlideManager.removeNotesSlide()**
تم إضافة الطريقة com.aspose.slides.INotesSlideManager.RemoveNotesSlide() لإزالة شريحة الملاحظات من شريحة معينة.
#### **تم إضافة الطريقة com.aspose.slides.ISlide.getNotesSlideManager(). وتم وضع الطرق ISlide.getNotesSlide() و ISlide.addNotesSlide() كـ Deprecated**
تم وضع الطرق ISlide.getNotesSlide() و ISlide.addNotesSlide() كـ Deprecated. استخدم الطريقة الجديدة ISlide.getNotesSlideManager() بدلاً منها.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - deprecated

// notes = slide.getNotesSlide(); - deprecated

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **تم إضافة الطريقة getAppVersion() إلى com.aspose.slides.IDocumentProperties**
تم إضافة الطريقة com.aspose.slides.IDocumentProperties.getAppVersion() للحصول على خاصية مستند مدمجة، والتي تمثل أرقام النسخ الداخلية المستخدمة بواسطة Microsoft PowerPoint.
#### **تم إضافة الطريقة remove() إلى com.aspose.slides.IComment**
تم إضافة الطريقة com.aspose.slides.IComment.remove() لإزالة تعليق من المجموعة.
#### **تم إضافة الطريقة remove() إلى com.aspose.slides.ICommentAuthor**
تم إضافة الطريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تمت إضافة الطريقتين clearCustomProperties() و clearBuiltInProperties() إلى com.aspose.slides.IDocumentProperties**
تمت إضافة الطريقة com.aspose.slides.IDocumentProperties.clearCustomProperties() لإزالة جميع خصائص المستند المخصصة.
تمت إضافة الطريقة com.aspose.slides.IDocumentProperties.clearBuiltInProperties() لإزالة وتعيين القيم الافتراضية لجميع خصائص المستند المدمجة (الشركة، الموضوع، المؤلف، إلخ).
#### **تمت إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape**
تمت إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape.
تحدد الطرق كيفية عرض الشكل في وضع العرض بالأبيض والأسود. القيم الممكنة محددة في فئة com.aspose.slides.BlackWhiteMode.

|**القيمة** |**المعنى** |
| :- | :- |
|Color |العودة بالتلوين العادي |
|Automatic |العودة بالتلوين التلقائي |
|Gray |العودة بالتلوين الرمادي |
|LightGray |العودة بالتلوين الرمادي الفاتح |
|InverseGray |العودة بالتلوين الرمادي المعكوس |
|GrayWhite |العودة بالتلوين الرمادي والأبيض |
|BlackGray |العودة بالتلوين الأسود والرمادي |
|BlackWhite |العودة بالتلوين الأسود والأبيض |
|Black |العودة بالتلوين الأسود فقط |
|White |العودة بالتلوين الأبيض |
|Hidden |الكائن غير مرئي |
#### **تمت إضافة الطرق removeAt(int) و remove(ICommentAuthor) و clear() إلى com.aspose.slides.ICommentAuthorCollection**
تمت إضافة الطريقة ICommentAuthorCollection.removeAt(int) لإزالة المؤلف حسب الفهرس المحدد. تمت إضافة الطريقة ICommentAuthorCollection.remove(ICommentAuthor) لإزالة المؤلف المحدد من المجموعة. تمت إضافة الطريقة ICommentAuthorCollection.clear() لإزالة جميع العناصر من المجموعة.