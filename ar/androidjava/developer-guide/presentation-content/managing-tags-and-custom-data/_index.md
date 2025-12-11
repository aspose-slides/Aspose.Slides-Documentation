---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية على Android
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/androidjava/managing-tags-and-custom-data
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- إضافة علامة
- قِيم أزواج
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة، قراءة، تحديث، وإزالة العلامات والبيانات المخصصة في Aspose.Slides للـ Android، مع أمثلة Java لعروض PowerPoint وOpenDocument."
---

## **تخزين البيانات في ملفات العرض**

تُخزن ملفات PPTX—العناصر التي تحمل الامتداد .pptx—بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يُعرّف تنسيق Office Open XML بنية البيانات الموجودة في العروض التقديمية. 

مع اعتبار *الشريحة* أحد العناصر في العروض، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة وفقًا لـ ISO/IEC 29500. 

يمكن أن تكون البيانات المخصصة (الخاصة بعرض تقديمي) أو للمستخدم على شكل علامات ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
العلامات هي في الأساس قيم أزواج (سلسلة‑مفتاح). 
{{% /alert %}} 

## **جلب قيم العلامات**

في الشرائح، تتطابق العلامة مع طريقتي [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) و[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). يوضح هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for Android عبر Java لـ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation):
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة علامات إلى العروض**

تتيح لك Aspose.Slides إضافة علامات إلى العروض التقديمية. عادةً ما تتألف العلامة من عنصرين:

- اسم الخاصية المخصصة - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية محددة، فستستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة "North American" ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يظهر هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) باستخدام Aspose.Slides for Android عبر Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


يمكن أيضًا تعيين علامات لـ [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide):
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


أو لأي [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) فردي:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. يدعم [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) العملية [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح‑القيمة دفعة واحدة.

**كيف أحذف علامة واحدة حسب اسمها دون التجول عبر المجموعة بأكملها؟**

استخدم العملية [remove(name)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) على [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو الفلترة؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) على [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/)؛ فهي تُرجع مصفوفة بجميع أسماء العلامات.