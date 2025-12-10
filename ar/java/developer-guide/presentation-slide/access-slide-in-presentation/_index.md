---
title: الوصول إلى الشرائح في العرض التقديمي باستخدام Java
linktitle: الوصول إلى الشريحة
type: docs
weight: 20
url: /ar/java/access-slide-in-presentation/
keywords:
- الوصول إلى الشريحة
- فهرس الشريحة
- معرف الشريحة
- موضع الشريحة
- تغيير الموضع
- خصائص الشريحة
- رقم الشريحة
- PowerPoint
- OpenDocument
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة Java. زد الإنتاجية مع أمثلة الشيفرة."
---

Aspose.Slides تتيح لك الوصول إلى الشرائح بطريقتين: حسب الفهرس أو حسب المعرف.

## **الوصول إلى شريحة حسب الفهرس**

يتم ترتيب جميع الشرائح في العرض التقديمي رقمياً بناءً على موضع الشريحة بدءًا من 0. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ الشريحة الثانية عبر الفهرس 1؛ إلخ.

الفئة Presentation، التي تمثل ملف عرض تقديمي، تعرض جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)). يوضح لك هذا الكود Java كيفية الوصول إلى شريحة عبر فهرستها:
```java
// يقوم بإنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // يصل إلى شريحة باستخدام فهرسها
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **الوصول إلى شريحة حسب المعرف**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-) (المتاحة في الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)) لتحديد ذلك المعرف. يوضح لك هذا الكود Java كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-):
```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // يحصل على معرف الشريحة
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // يصل إلى الشريحة عبر معرفها
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **تغيير موضع الشريحة**

تسمح لك Aspose.Slides بتغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن تصبح الشريحة الأولى هي الشريحة الثانية.

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع الشريحة (التي تريد تغيير موقعها) عبر فهرستها
3. عيّن موضعًا جديدًا للشريحة عبر الخاصية [setSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#setSlideNumber-int-) .
4. احفظ العرض التقديمي المعدل.

يعرض هذا الكود Java عملية يتم فيها نقل الشريحة في الموضع 1 إلى الموضع 2:
```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // يحصل على الشريحة التي سيتم تغيير موضعها
    ISlide sld = pres.getSlides().get_Item(0);
    
    // يضبط الموضع الجديد للشريحة
    sld.setSlideNumber(2);
    
    // يحفظ العرض التقديمي المعدل
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع شريحة، يتم تعديل الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام الخاصية [setFirstSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (المتاحة في الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. تتسبب هذه العملية في إعادة حساب أرقام الشرائح الأخرى.

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على رقم الشريحة.
3. عيّن رقم الشريحة.
4. احفظ العرض التقديمي المعدل.

يعرض هذا الكود Java عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:
```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // يحصل على رقم الشريحة
    int firstSlideNumber = pres.getFirstSlideNumber();

    // يضبط رقم الشريحة
    pres.setFirstSlideNumber(10);
	
    // يحفظ العرض التقديمي المعدل
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:
```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // يحدد رقم الشريحة الأولى في العرض التقديمي
    presentation.setFirstSlideNumber(0);

    // يعرض أرقام الشرائح لجميع الشرائح
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // يخفي رقم الشريحة الأولى
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // يحفظ العرض التقديمي المعدل
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الأسئلة المتكررة**

**هل رقم الشريحة الذي يراه المستخدم يطابق فهرس المجموعة القائم على الصفر؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثلاً 10) ولا يشترط أن يطابق الفهرس؛ يتم التحكم في العلاقة عبر إعداد [first slide number](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) للعرض التقديمي.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. تبقى الشريحة المخفية في المجموعة وتحسب في الفهرسة؛ "المخفية" تشير إلى العرض، وليس إلى موقعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. تعكس الفهارس دائمًا الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإضافة أو الحذف أو النقل.