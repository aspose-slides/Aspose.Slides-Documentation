---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/java/managing-tags-and-custom-data

---

## تخزين البيانات في ملفات العرض

تُخزن ملفات PPTX - العناصر ذات امتداد .pptx - بصيغة PresentationML، والتي هي جزء من مواصفة Office Open XML. تحدد صيغة Office Open XML الهيكل البياني للبيانات الموجودة في العروض التقديمية.

مع كون *الشريحة* إحدى العناصر في العروض التقديمية، تحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون له علاقات صريحة مع العديد من الأجزاء - مثل العلامات المعرفة من قبل المستخدم - المعرفة بواسطة ISO/IEC 29500.

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو المستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) وأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

العلامات أساسًا هي قيم من نوع زوج مفتاح-سلسلة. 

{{% /alert %}} 

## الحصول على قيم العلامات

في الشرائح، تت correspond علامة إلى [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) و [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) الطرق. يظهر لك هذا الشيفرة النموذجية كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ Java لعروض تقديمية ([Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## إضافة علامات إلى العروض التقديمية

تسمح لك Aspose.Slides بإضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:

- اسم خاصية مخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض التقديمية. على سبيل المثال، إذا كنت تريد تصنيف أو جمع جميع العروض التقديمية من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكية شمالية ثم تعيين البلدان ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

تظهر لك هذه الشيفرة النموذجية كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) باستخدام Aspose.Slides لـ Java:

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

أو لأي [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) فردية:

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