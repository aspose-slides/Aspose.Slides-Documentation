---
title: إدارة العلامات والبيانات المخصصة في العروض باستخدام جافا سكريبت
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/nodejs-java/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides لـ Node.js، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. توضح بإيجاز كيفية تخزين البيانات في ملفات PPTX، وتذكر أن البيانات الخاصة بالعرض يمكن أن توجد كعلامات وأجزاء XML مخصصة، وتصف العلامات كأزواج سلاسل مفتاح‑قيمة.

كما تُظهر كيفية قراءة قيم العلامات وكيفية إضافة العلامات إلى عرض تقديمي أو شريحة فردية أو شكل. بالإضافة إلى ذلك، تغطي المقالة مهام إدارة العلامات الشائعة مثل مسح جميع العلامات، إزالة علامة بالاسم، واسترجاع قائمة بأسماء العلامات.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات الامتداد .pptx—مخزنة بصيغة PresentationML، وهي جزء من مواصفة Office Open XML. تُعرّف صيغة Office Open XML البنية للبيانات الموجودة في العروض.

مع اعتبار *الشريحة* أحد عناصر العروض، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة وفق ISO/IEC 29500.

يمكن أن تكون البيانات المخصصة (الخاصة بالعرض) أو المستخدم موجودة كعلامات ([TagCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TagCollection)) وأجزاء XML مخصصة ([CustomXmlPartCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
العلامات هي في الأساس أزواج قيم مفتاح‑سلسلة. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في Slides، تتوافق العلامة مع طريقتي [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) و[DocumentProperties.setKeywords()](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). يُظهر هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for Node.js via Java لـ[Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation):

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

## **إضافة علامات إلى العروض**

يتيح Aspose.Slides لك إضافة علامات إلى العروض. تتكون العلامة عادة من عنصرين:

- اسم الخاصية المخصصة - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة "North American" ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يُظهر هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) باستخدام Aspose.Slides for Node.js via Java:

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

يمكن أيضًا تعيين العلامات لـ[Slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Slide):

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

أو لأي [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/AutoShape) فردي:

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

### **القيود**

العلامات المضافة عبر مجموعة بيانات العلامات المخصصة باستخدام `getCustomData().getTags()` تُخزن فقط داخل ملف PowerPoint. وهي **لا** تُنقل إلى بنية علامات PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع معرف مخصص تم تعيينه كعلامة من ملف PDF المُوسوم.

**الحل البديل**: يمكنك تخزين معرف مخصص في **نص بديل** للكائن (مثال: `shape.setAlternativeText("MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية علامات PDF.

## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [مجموعة العلامات](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑قيمة دفعة واحدة.

**كيف أحذف علامة واحدة باسمها دون التجول عبر المجموعة بأكملها؟**

استخدم عملية [remove(name)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/); تُعيد مصفوفة تحتوي على جميع أسماء العلامات.