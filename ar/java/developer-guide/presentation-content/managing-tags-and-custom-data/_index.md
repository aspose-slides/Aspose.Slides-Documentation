---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية باستخدام Java
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/java/managing-tags-and-custom-data/
keywords:
- خصائص الوثيقة
- علامة
- بيانات مخصصة
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides للغة Java، مع أمثلة على عروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العرض**

تُخزن ملفات PPTX—العناصر ذات الامتداد .pptx—في تنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يعرّف تنسيق Office Open XML بنية البيانات المتضمنة في العروض التقديمية. 

مع اعتبار *الشريحة* أحد عناصر العروض التقديمية، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون له علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة في ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو المستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}}العلامات هي في الأساس قيم أزواج مفتاح‑سلسلة.{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع طرق [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) و[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). يوضح هذا النموذج البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للغة Java لــ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة علامات إلى العروض التقديمية**

يتيح لك Aspose.Slides إضافة علامات إلى العروض الت تقديمية. تتكوّن العلامة عادةً من عنصرين:
- اسم الخاصية المخصصة - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت تحتاج إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية محددة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يظهر هذا النموذج البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) باستخدام Aspose.Slides للغة Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide):
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


أو لأي شكل فردي [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape):
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


## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**  
نعم. يدعم [مجموعة العلامات](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة باسمها دون التجول عبر المجموعة بأكملها؟**  
استخدم العملية [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) على [مجموعة العلامات](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**  
استخدم [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) على [مجموعة العلامات](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/); تُرجع مصفوفة بجميع أسماء العلامات.