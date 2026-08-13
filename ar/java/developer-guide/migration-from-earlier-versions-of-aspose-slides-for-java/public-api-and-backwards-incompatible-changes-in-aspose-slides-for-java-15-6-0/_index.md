---
title: التغييرات في واجهة برمجة التطبيقات العامة وغير المتوافقة مع الإصدارات السابقة في Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - الهجرة
  - كود قديم
  - كود حديث
  - نهج قديم
  - نهج حديث
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - Java
  - Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for Java للقيام بترحيل سلس لحلول عروض PowerPoint (PPT، PPTX) وODP."
---
{{% alert color="info" %}}

تسرد هذه الصفحة جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/)، وأي قيود جديدة و[تغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) أخرى تم تقديمها مع API Aspose.Slides for Java 15.6.0.

{{% /alert %}}
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **تم تغيير توقيع مُنشئ com.aspose.slides.DataLabel**
تم تغيير توقيع المُنشئ من DataLabel(com.aspose.slides.IChartSeries) إلى DataLabel(com.aspose.slides.IChartDataPoint).
#### **تم وضع علامة على أعضاء com.aspose.slides.IDocumentProperties.getCount()، .getPropertyName(int index).، .remove(String name)، .contains(String name) كمهملين؛ تم تقديم بدائل بدلاً من ذلك**
تم وضع علامة على الطرق IDocumentProperties.getCount()، IDocumentProperties.getPropertyName(int index).، .remove(string name)، .contains(string name) كمهملين. تم تقديم الطرق IDocumentProperties.countOfCustomProperties()، IDocumentProperties.getCustomPropertyName(int index).، .removeCustomProperty(String name)، .containsCustomProperty(string name) بدلاً من ذلك.
#### **تم إضافة الطريقة com.aspose.slides.INotesSlideManager.removeNotesSlide()**
تم إضافة الطريقة com.aspose.slides.INotesSlideManager.RemoveNotesSlide() لإزالة شريحة ملاحظات من شريحة معينة.
#### **تم إضافة الطريقة com.aspose.slides.ISlide.getNotesSlideManager(). تم وضع علامة على الطريقتين ISlide.getNotesSlide() و ISlide.addNotesSlide() كمهملتين**
تم وضع علامة على الطريقتين ISlide.getNotesSlide() و ISlide.addNotesSlide() كمهملتين. استخدم الطريقة الجديدة ISlide.getNotesSlideManager() بدلًا من ذلك.
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - مهمل

    // notes = slide.getNotesSlide(); - مهمل

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **تم إضافة الطريقة getAppVersion() إلى com.aspose.slides.IDocumentProperties**
تم إضافة الطريقة com.aspose.slides.IDocumentProperties.getAppVersion() للحصول على خاصية المستند المدمجة، والتي تمثل أرقام الإصدارات الداخلية المستخدمة من قبل Microsoft PowerPoint.
#### **تم إضافة الطريقة remove() إلى com.aspose.slides.IComment**
تم إضافة الطريقة com.aspose.slides.IComment.remove() لإزالة التعليق من المجموعة.
#### **تم إضافة الطريقة remove() إلى com.aspose.slides.ICommentAuthor**
تم إضافة الطريقة ICommentAuthor.Remove لإزالة مؤلف التعليقات من المجموعة.
#### **تم إضافة الطريقتين clearCustomProperties() و clearBuiltInProperties() إلى com.aspose.slides.IDocumentProperties**
تم إضافة الطريقة com.aspose.slides.IDocumentProperties.clearCustomProperties() لإزالة جميع خصائص المستند المخصصة.
تم إضافة الطريقة com.aspose.slides.IDocumentProperties.clearBuiltInProperties() لإزالة وتعيين القيم الافتراضية لجميع خصائص المستند المدمجة (Company، Subject، Author، إلخ).
#### **تم إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape**
تم إضافة الطريقتين getBlackWhiteMode() و setBlackWhiteMode(byte) إلى com.aspose.slides.IShape.
تحدد هذه الطريقتان كيفية عرض الشكل في وضع العرض بالأبيض والأسود. القيم الممكنة محددة في فئة com.aspose.slides.BlackWhiteMode.

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
|Hidden |الكائن غير معروض |
#### **تم إضافة الطرائق removeAt(int) و remove(ICommentAuthor) و clear() إلى com.aspose.slides.ICommentAuthorCollection**
تم إضافة الطريقة ICommentAuthorCollection.removeAt(int) لإزالة المؤلف بواسطة الفهرس المحدد. تم إضافة الطريقة ICommentAuthorCollection.remove(ICommentAuthor) لإزالة المؤلف المحدد من المجموعة. تم إضافة الطريقة ICommentAuthorCollection.clear() لإزالة جميع العناصر من المجموعة.