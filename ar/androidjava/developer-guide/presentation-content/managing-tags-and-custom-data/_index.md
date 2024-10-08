---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/androidjava/managing-tags-and-custom-data

---

## تخزين البيانات في ملفات العرض التقديمي

تُخزن ملفات PPTX - العناصر التي تحمل امتداد .pptx - في تنسيق PresentationML، والذي هو جزء من مواصفة Office Open XML. يُعرّف تنسيق Office Open XML الهيكل الخاص بالبيانات الموجودة في العروض التقديمية.

مع كون *الشريحة* واحدة من العناصر في العروض التقديمية، تحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون لديه علاقات صريحة مع العديد من الأجزاء – مثل علامات المستخدم المحددة – المعرفة بواسطة ISO/IEC 29500.

يمكن أن تكون البيانات المخصصة (المحددة لعروض تقديمية معينة) أو المستخدم موجودة كعلامات ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

تعد العلامات بشكل أساسي قيم أزواج المفتاح والنص.

{{% /alert %}} 

## الحصول على القيم للعلامات

في الشرائح، تتوافق علامة مع [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) و[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) طرق. يعرض هذا الكود النموذجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ Android عبر Java لـ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## إضافة علامات إلى العروض التقديمية

يسمح لك Aspose.Slides بإضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:

- اسم خاصية مخصصة - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا كنت ترغب في تصنيف أو وضع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة لأمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، والمكسيك، وكندا) كقيم.

يعرض هذا الكود النموذجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) باستخدام Aspose.Slides لـ Android عبر Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

أو أي [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) فردية:

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