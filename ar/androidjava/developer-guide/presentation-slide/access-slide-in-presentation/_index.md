---
title: الوصول إلى الشريحة في العرض التقديمي
type: docs
weight: 20
url: /ar/androidjava/access-slide-in-presentation/
keywords: "الوصول إلى عرض PowerPoint، الوصول إلى الشريحة، تعديل خصائص الشريحة، تغيير موضع الشريحة، تعيين رقم الشريحة، الفهرس، المعرف، الموضع Java، Aspose.Slides"
description: "الوصول إلى شريحة PowerPoint بواسطة الفهرس أو المعرف أو الموضع في Java. تعديل خصائص الشريحة"
---

يتيح لك Aspose.Slides الوصول إلى الشرائح بطريقتين: عن طريق الفهرس و عن طريق المعرف.

## **الوصول إلى الشريحة بواسطة الفهرس**

جميع الشرائح في العرض التقديمي مرتبة ترتيباً رقمياً بناءً على موضع الشريحة بدءًا من 0. يمكنك الوصول إلى الشريحة الأولى من خلال الفهرس 0؛ الشريحة الثانية يمكن الوصول إليها من خلال الفهرس 1؛ وهكذا.

تقوم فئة Presentation، التي تمثل ملف العرض التقديمي، بتعريض جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)). يوضح هذا الكود بلغة Java كيفية الوصول إلى شريحة من خلال فهرسها:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // يصل إلى شريحة باستخدام فهرس الشريحة
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **الوصول إلى الشريحة بواسطة المعرف**

لكل شريحة في العرض التقديمي معرف فريد مرتبط بها. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (الملاحة بواسطة فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)) لاستهداف هذا المعرف. يوضح هذا الكود بلغة Java كيفية تقديم معرف شريحة صالح والوصول إلى تلك الشريحة من خلال طريقة [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // يحصل على معرف الشريحة
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // يصل إلى الشريحة من خلال معرفها
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **تغيير موضع الشريحة**

يتيح لك Aspose.Slides تغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى يجب أن تصبح الشريحة الثانية.

1. أنشئ مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. احصل على مرجع الشريحة (التي تريد تغيير موضعها) من خلال فهرسها
1. عيّن موضعًا جديدًا للشريحة من خلال خاصية [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
1. احفظ العرض التقديمي المعدل.

هذا الكود بلغة Java يوضح عملية يتم فيها نقل الشريحة في الموضع 1 إلى الموضع 2:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // يحصل على الشريحة التي سيتم تغيير موضعها
    ISlide sld = pres.getSlides().get_Item(0);
    
    // يعين الموضع الجديد للشريحة
    sld.setSlideNumber(2);
    
    // يحفظ العرض التقديمي المعدل
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع شريحة ما، يتم ضبط الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (الملاحة بواسطة فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. تؤدي هذه العملية إلى إعادة حساب أرقام الشرائح الأخرى.

1. أنشئ مثيل لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. احصل على رقم الشريحة.
1. عيّن رقم الشريحة.
1. احفظ العرض التقديمي المعدل.

هذا الكود بلغة Java يوضح عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:

```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // يحصل على رقم الشريحة
    int firstSlideNumber = pres.getFirstSlideNumber();

    // يعين رقم الشريحة
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

    // يعين الرقم للشريحة الأولى في العرض التقديمي
    presentation.setFirstSlideNumber(0);

    // يظهر أرقام الشرائح لجميع الشرائح
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // يخفي رقم الشريحة للشريحة الأولى
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // يحفظ العرض التقديمي المعدل
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```