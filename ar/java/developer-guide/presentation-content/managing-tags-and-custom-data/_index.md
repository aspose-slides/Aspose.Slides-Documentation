---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية باستخدام Java
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/java/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides for Java، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---

## تخزين البيانات في ملفات العرض التقديمي

تُخزن ملفات PPTX—العناصر ذات امتداد .pptx—بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML البنية للبيانات الموجودة في العروض التقديمية. 

مع اعتبار *الشريحة* كواحدة من عناصر العروض، تحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون له علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المُعرَّفة وفق ISO/IEC 29500. 

يمكن أن تكون البيانات المخصصة (المحددة لعرض تقديمي) أو للمستخدم موجودة كعلامات ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
العلامات هي في الأساس قيم أزواج سلسلة‑مفتاح. 
{{% /alert %}} 

## الحصول على قيم العلامات

في الشرائح، تتطابق علامة مع طريقتي [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) و[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . يظهر هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for Java لـ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## إضافة علامات إلى العروض التقديمية

يسمح Aspose.Slides لك بإضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية محددة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تصنيف أو جمع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يعرض هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) باستخدام Aspose.Slides for Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


يمكن أيضًا تعيين علامات لـ [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide):
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


أو أي [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) فردي:
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

نعم. يدعم [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح‑القيمة مرةً واحدة.  

**كيف أحذف علامة واحدة باستخدام اسمها دون التجول عبر المجموعة بأكملها؟**  

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) على [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) لحذف العلامة باستخدام مفتاحها.  

**كيف يمكنني استخراج القائمة الكاملة لأسماء العلامات لأغراض التحليل أو الفرز؟**  

استخدم [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) على [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/); تُرجع مصفوفةً تحتوي على جميع أسماء العلامات.