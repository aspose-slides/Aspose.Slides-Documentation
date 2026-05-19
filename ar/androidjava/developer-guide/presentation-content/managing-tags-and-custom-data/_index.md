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
- أزواج القيم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides for Android، مع أمثلة Java لعروض PowerPoint وOpenDocument."
---
## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات الامتداد .pptx—تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يعرّف تنسيق Office Open XML البنية للبيانات الموجودة في العروض التقديمية. 

مع اعتبار *slide* أحد العناصر في العروض، يحتوي *slide part* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع أجزاء متعددة—مثل User Defined Tags—المعرَّفة وفقًا لمعيار ISO/IEC 29500. 

يمكن للبيانات المخصصة (المحدّدة لعروض تقديمية) أو للمستخدم أن توجد كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
العلامات هي أساسًا قيم أزواج مفتاح-سلسلة. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تقابل العلامة طريقة [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) وطريقة [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . يوضح هذا المثال البرمجي كيفية الحصول على قيمة العلامة باستخدام Aspose.Slides for Android عبر Java لـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة علامات إلى العروض التقديمية**

يسمح Aspose.Slides لك بإضافة علامات إلى العروض التقديمية. تتكوّن العلامة عادةً من عنصرين:

- اسم الخاصية المخصّصة - `MyTag` 
- قيمة الخاصية المخصّصة - `My Tag Value`

إذا احتجت إلى تصنيف بعض العروض وفق قاعدة أو خاصية معينة، فقد تستفيد من إضافة العلامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع كل العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة "North American" ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يوضح هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) باستخدام Aspose.Slides for Android عبر Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

أو لأي [Shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAutoShape) فردي:

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

### **القيود**

العلامات التي تُضاف عبر مجموعة بيانات العلامات المخصّصة باستخدام `getCustomData().getTags()` تُخزن فقط داخل ملف PowerPoint. ولا يتم نقلها إلى هيكل علامات PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرداد معرف مخصّص مُعيّن كعلامة من ملف PDF المُعلام.

**الحل البديل**: يمكنك تخزين معرف مخصّص في **نص بديل** للكائن (مثال، `shape.setAlternativeText("MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في هيكل علامات PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [tag collection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح–القيمة دفعة واحدة.

**كيف أحذف علامة واحدة باسمها دون التكرار عبر المجموعة بالكامل؟**

استخدم عملية [remove(name)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) على [tag collection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) على [tag collection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/)؛ تُعيد مصفوفة تحتوي على جميع أسماء العلامات.