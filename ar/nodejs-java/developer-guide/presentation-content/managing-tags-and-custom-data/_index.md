---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/nodejs-java/managing-tags-and-custom-data
---

## **تخزين البيانات في ملفات العروض التقديمية**

ملفات PPTX—العناصر ذات الامتداد .pptx—يتم تخزينها بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML البنية للبيانات المحتواة في العروض التقديمية. 

مع كون *الشريحة* واحدة من عناصر العروض التقديمية، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يجوز لجزء الشريحة أن يكون له علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المعرفة وفقًا لـ ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو المستخدم كعلامات ([TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)) وCustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
العلامات هي في الأساس قيم أزواج مفتاح-سلسلة. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع طريقتي [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) و[DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) . يُظهر هذا الكود العيني كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for Node.js عبر Java لـ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation):
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة علامات إلى العروض التقديمية**

Aspose.Slides يسمح لك بإضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تصنيف جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة “North American” ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

هذا الكود العيني يوضح كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) باستخدام Aspose.Slides for Node.js عبر Java:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide):
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


أو أي [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) فردي:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. مجموعة العلامات ([tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/)) تدعم عملية [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرةً واحدة.

**كيف أحذف علامة واحدة باسمها دون التكرار عبر المجموعة بأكملها؟**

استخدم عملية [remove(name)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) على مجموعة العلامات ([tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/))؛ تُرجع مصفوفة بجميع أسماء العلامات.