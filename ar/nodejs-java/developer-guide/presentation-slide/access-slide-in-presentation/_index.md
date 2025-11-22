---
title: "الوصول إلى الشريحة في العرض التقديمي"
type: docs
weight: 20
url: /ar/nodejs-java/access-slide-in-presentation/
keywords: "الوصول إلى عرض PowerPoint, الوصول إلى الشريحة, تحرير خصائص الشريحة, تغيير موضع الشريحة, تعيين رقم الشريحة, الفهرس, المعرف, الموضع Java, Aspose.Slides"
description: "الوصول إلى شريحة PowerPoint حسب الفهرس أو المعرف أو الموضع في JavaScript. تحرير خصائص الشريحة"
---

Aspose.Slides يسمح لك بالوصول إلى الشرائح بطريقتين: عبر الفهرس وعبر المعرف.

## **الوصول إلى الشريحة عبر الفهرس**

جميع الشرائح في عرض تقديمي مرتبة عددياً بناءً على موضع الشريحة بدءًا من 0. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ الشريحة الثانية يتم الوصول إليها عبر الفهرس 1؛ إلخ.

فئة Presentation، التي تمثل ملف عرض تقديمي، تكشف جميع الشرائح كمجموعة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) (مجموعة من كائنات [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)). يوضح لك هذا الكود JavaScript كيفية الوصول إلى شريحة عبر فهرستها:
```javascript
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // الوصول إلى شريحة باستخدام الفهرس الخاص بها
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **الوصول إلى الشريحة عبر المعرف**

كل شريحة في عرض تقديمي لديها معرف فريد مرتبط بها. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (المعروضة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)) لاستهداف هذا المعرف. يبين لك هذا الكود JavaScript كيفية تقديم معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-):
```javascript
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // يحصل على معرف الشريحة
    var id = pres.getSlides().get_Item(0).getSlideId();
    // يصل إلى الشريحة عبر معرفها
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **تغيير موضع الشريحة**

Aspose.Slides تتيح لك تغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى تصبح الشريحة الثانية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة (التي تريد تغيير موضعها) عبر فهرسها
3. تعيين موضع جديد للشريحة عبر الخاصية [setSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
4. حفظ العرض التقديمي المعدل.

يظهر هذا الكود JavaScript عملية نقل الشريحة الموجودة في الموضع 1 إلى الموضع 2:
```javascript
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // يحصل على الشريحة التي سيتم تغيير موضعها
    var sld = pres.getSlides().get_Item(0);
    // يعيّن الموضع الجديد للشريحة
    sld.setSlideNumber(2);
    // يحفظ العرض التقديمي المعدل
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


أصبحت الشريحة الأولى هي الشريحة الثانية؛ وأصبحت الشريحة الثانية هي الشريحة الأولى. عند تغيير موضع شريحة، يتم تعديل باقي الشرائح تلقائيًا.

## **تحديد رقم الشريحة**

باستخدام الخاصية [setFirstSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (المعروضة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في عرض تقديمي. هذه العملية تؤدي إلى إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. الحصول على رقم الشريحة.
3. تعيين رقم الشريحة.
4. حفظ العرض التقديمي المعدل.

يظهر هذا الكود JavaScript عملية تعيين رقم الشريحة الأولى إلى 10:
```javascript
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // يحصل على رقم الشريحة
    var firstSlideNumber = pres.getFirstSlideNumber();
    // يعيّن رقم الشريحة
    pres.setFirstSlideNumber(10);
    // يحفظ العرض التقديمي المعدل
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // يعيّن رقم الشريحة الأولى للعرض التقديمي
    presentation.setFirstSlideNumber(0);
    // يعرض أرقام الشرائح لجميع الشرائح
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // يخفي رقم الشريحة للشريحة الأولى
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // يحفظ العرض التقديمي المعدل
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل رقم الشريحة الذي يراه المستخدم يطابق الفهرس الصفري للمجموعة؟**

يمكن أن يبدأ الرقم الظاهر على الشريحة من قيمة عشوائية (مثلاً 10) ولا يلزم أن يطابق الفهرس؛ يتم التحكم في العلاقة بواسطة إعداد [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/).

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. تظل الشريحة المخفية ضمن المجموعة وتُحسب في الفهرسة؛ "مخفي" يشير إلى العرض، وليس إلى موضعها في المجموعة.

**هل يتغير فهرس الشريحة عندما يتم إضافة أو إزالة شرائح أخرى؟**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج والحذف والنقل.