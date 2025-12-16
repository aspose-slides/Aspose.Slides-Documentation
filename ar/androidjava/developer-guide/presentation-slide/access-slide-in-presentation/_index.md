---
title: "الوصول إلى شرائح العرض التقديمي على Android"
linktitle: "الوصول إلى الشريحة"
type: docs
weight: 20
url: /ar/androidjava/access-slide-in-presentation/
keywords:
- "الوصول إلى الشريحة"
- "فهرس الشريحة"
- "معرف الشريحة"
- "موضع الشريحة"
- "تغيير الموضع"
- "خصائص الشريحة"
- "رقم الشريحة"
- "PowerPoint"
- "OpenDocument"
- "العرض التقديمي"
- "Android"
- "Java"
- "Aspose.Slides"
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides لنظام Android. عزز الإنتاجية مع أمثلة كود Java."
---

Aspose.Slides يتيح لك الوصول إلى الشرائح بطريقتين: عن طريق الفهرس وعن طريق المعرف.

## **الوصول إلى الشريحة عن طريق الفهرس**

جميع الشرائح في العرض التقديمي مُرتبة رقمياً بناءً على موضع الشريحة بدءاً من 0. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ الشريحة الثانية يمكن الوصول إليها عبر الفهرس 1؛ وهكذا.

فئة Presentation، التي تمثل ملف عرض تقديمي، تُظهر جميع الشرائح كـ [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)). يوضح هذا الكود Java طريقة الوصول إلى شريحة عبر فهرسها:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // الوصول إلى شريحة باستخدام فهرس الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **الوصول إلى الشريحة عن طريق المعرف**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (المُعَرَّضة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)) لاستهداف ذلك المعرف. يوضح هذا الكود Java كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-):
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // الحصول على معرف الشريحة
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // الوصول إلى الشريحة من خلال معرفها
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **تغيير موضع الشريحة**

Aspose.Slides يسمح لك بتغيير موضع شريحة. على سبيل المثال، يمكنك تحديد أن تصبح الشريحة الأولى هي الشريحة الثانية.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الحصول على مرجع الشريحة (التي تريد تغيير موضعها) عبر فهرسها
3. تعيين موضع جديد للشريحة عبر الخاصية [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
4. حفظ العرض التقديمي المعدَّل.

يُظهر هذا الكود Java عملية نقل الشريحة الموجودة في الموضع 1 إلى الموضع 2:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // الحصول على الشريحة التي سيتم تغيير موقعها
    ISlide sld = pres.getSlides().get_Item(0);
    
    // تعيين الموقع الجديد للشريحة
    sld.setSlideNumber(2);
    
    // حفظ العرض التقديمي المعدل
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع الشريحة، يتم تعديل باقي الشرائح تلقائياً.

## **تعيين رقم الشريحة**

باستخدام الخاصية [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (المُعَرَّضة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)) يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. تؤدي هذه العملية إلى إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. الحصول على رقم الشريحة.
3. تعيين رقم الشريحة.
4. حفظ العرض التقديمي المعدَّل.

يُظهر هذا الكود Java عملية تعيين رقم الشريحة الأولى إلى 10:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // الحصول على رقم الشريحة
    int firstSlideNumber = pres.getFirstSlideNumber();

    // تعيين رقم الشريحة
    pres.setFirstSlideNumber(10);
	
    // حفظ العرض التقديمي المعدل
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


إذا رغبت في تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (واخفاء الترقيم عن الشريحة الأولى) بهذه الطريقة:
```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // تعيين الرقم للشرحة الأولى في العرض التقديمي
    presentation.setFirstSlideNumber(0);

    // إظهار أرقام الشرائح لجميع الشرائح
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // إخفاء رقم الشريحة للشرحة الأولى
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // حفظ العرض التقديمي المعدل
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الأسئلة الشائعة**

**هل رقم الشريحة الذي يراه المستخدم يطابق فهرس المجموعة القائم على الصفر؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثل 10) ولا يلزم أن يطابق الفهرس؛ العلاقة تتحكم فيها إعداد [رقم الشريحة الأولى](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) للعرض التقديمي.

**هل تؤثر الشرائح المخفيّة على الفهرسة؟**

نعم. الشريحة المخفيّة تبقى في المجموعة وتحسب في الفهرسة؛ "مخفي" يشير إلى العرض فقط، وليس إلى موقعها في المجموعة.

**هل يتغيّر فهرس الشريحة عندما تُضاف أو تُزال شرائح أخرى؟**

نعم. الفهارس دائماً تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج، الحذف، والنقل.