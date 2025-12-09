---
title: إزالة شريحة من العرض التقديمي
type: docs
weight: 30
url: /ar/nodejs-java/remove-slide-from-presentation/
keywords: "إزالة شريحة, حذف شريحة, PowerPoint, عرض تقديمي, Java, Aspose.Slides"
description: "إزالة شريحة من PowerPoint عن طريق المرجع أو الفهرس في JavaScript"
---

إذا أصبحت شريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) التي تضمن [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/)، وهي مستودع لجميع الشرائح في العرض التقديمي. باستخدام المؤشرات (مرجع أو فهرس) لكائن [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة الشريحة عن طريق المرجع**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. احصل على مرجع الشريحة التي تريد إزالتها عبر معرفها أو فهرسها.
1. إزالة الشريحة المرجعية من العرض التقديمي.
1. حفظ العرض التقديمي المعدل. 

```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // الوصول إلى شريحة عبر فهرستها في مجموعة الشرائح
    var slide = pres.getSlides().get_Item(0);
    // إزالة شريحة عبر مرجعها
    pres.getSlides().remove(slide);
    // حفظ العرض التقديمي المعدل
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إزالة الشريحة عن طريق الفهرس**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. إزالة الشريحة من العرض التقديمي عبر موقع الفهرس الخاص بها.
1. حفظ العرض التقديمي المعدل. 

```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // إزالة شريحة عبر فهرس الشريحة
    pres.getSlides().removeAt(0);
    // حفظ العرض التقديمي المعدل
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إزالة شريحة التخطيط غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) للسماح لك بحذف شرائح التخطيط غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الكود JavaScript كيفية إزالة شريحة تخطيط من عرض PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة شريحة الماستر غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) للسماح لك بحذف شرائح الماستر غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الكود JavaScript كيفية إزالة شريحة ماستر من عرض PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**ماذا يحدث لمؤشرات الشرائح بعد حذف شريحة؟**

بعد الحذف، يعيد [collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) فهرسة الشرائح: كل شريحة لاحقة تُزاح إلى اليسار بموقع واحد، وبالتالي تصبح أرقام الفهارس السابقة قديمة. إذا كنت بحاجة إلى مرجع ثابت، استخدم المعرف الدائم لكل شريحة بدلاً من فهرسها.

**هل معرف الشريحة يختلف عن فهرستها، وهل يتغير عندما تُحذف الشرائح المجاورة؟**

نعم. الفهرس هو موضع الشريحة ويتغير عندما تُضاف أو تُحذف شرائح. معرف الشريحة هو معرف دائم ولا يتغير عندما تُحذف الشرائح الأخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة جزءًا من قسم، سيحتوي ذلك القسم الآن على شريحة أقل. يظل هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [إزالة أو إعادة تنظيم الأقسام](/slides/ar/nodejs-java/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرفقة بشريحة عند حذفها؟**

[الملاحظات](/slides/ar/nodejs-java/presentation-notes/) و[التعليقات](/slides/ar/nodejs-java/presentation-comments/) مرتبطان بهذه الشريحة المحددة ويتم إزالتهما معها. المحتوى في الشرائح الأخرى لا يتأثر.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/الماسترات غير المستخدمة؟**

يؤدي الحذف إلى إزالة شرائح عادية محددة من العرض. يزيل تنظيف التخطيطات/الماسترات غير المستخدمة شرائح التخطيط أو الماستر التي لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هاتان العمليتان تكملان بعضهما: عادةً ما يتم الحذف أولاً، ثم التنظيف.