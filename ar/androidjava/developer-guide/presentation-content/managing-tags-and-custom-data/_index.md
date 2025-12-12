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
- قيم مزدوجة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides لنظام Android، مع أمثلة Java لعروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات امتداد .pptx—تُخزن بصيغة PresentationML، التي هي جزء من مواصفات Office Open XML. تُحدد صيغة Office Open XML بنية البيانات الموجودة في العروض التقديمية.  

مع اعتبار *الشريحة* كأحد عناصر العروض التقديمية، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون له علاقات صريحة مع أجزاء متعددة—مثل العلامات المعرفة من قبل المستخدم—المحددة في ISO/IEC 29500.  

يمكن أن توجد بيانات مخصصة (محددة لعروض تقديمية) أو مستخدم على شكل علامات ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
العلامات هي في الأساس قيم أزواج سلسلة-مفتاح. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع طريقتي [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) و[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . يوضح هذا الشيفرة النموذجية كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ Android عبر Java ل‍[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation):
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة علامات إلى العروض التقديمية**

تتيح لك Aspose.Slides إضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:
- اسم الخاصية المخصصة - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض التقديمية من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

توضح هذه الشيفرة النموذجية كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) باستخدام Aspose.Slides لـ Android عبر Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


يمكن أيضًا ضبط العلامات لـ [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide):
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

نعم. يدعم [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة باسمها دون التكرار عبر المجموعة بأكملها؟**

استخدم عملية [remove(name)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) على [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) على [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/); تُعيد مصفوفة بجميع أسماء العلامات.