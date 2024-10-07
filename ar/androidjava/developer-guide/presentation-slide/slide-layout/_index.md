---
title: تخطيط الشريحة
type: docs
weight: 60
url: /androidjava/slide-layout/
keyword: "تعيين حجم الشريحة، تعيين خيارات الشريحة، تحديد حجم الشريحة، رؤية التذييل، تذييل الطفل، تعديل المحتوى، حجم الصفحة، جافا، Aspose.Slides"
description: "تعيين حجم الشريحة وخياراتها في PowerPoint باستخدام جافا"
---

يحتوي تخطيط الشريحة على صناديق العناصر النائبة ومعلومات التنسيق لجميع المحتويات التي تظهر على الشريحة. يحدد التخطيط العناصر النائبة المتاحة ومكان وضعها.

تتيح لك تخطيطات الشرائح إنشاء وتصميم العروض التقديمية بسرعة (سواء كانت بسيطة أو معقدة). هذه بعض من أكثر تخطيطات الشرائح شيوعًا المستخدمة في عروض PowerPoint:

* **تخطيط شريحة العنوان**. يتكون هذا التخطيط من عنصرين نائبيين للنص. واحد للنص الرئيسي والآخر للعناوين الفرعية.
* **تخطيط العنوان والمحتوى**. يحتوي هذا التخطيط على عنصر نائب صغير نسبيًا في الأعلى للعناوين وعنصر نائب أكبر للمحتوى الرئيسي (مثل المخططات والفقارات والقوائم النقطية والقوائم المرقمة والصور وما إلى ذلك).
* **تخطيط فارغ**. يفتقر هذا التخطيط إلى العناصر النائبة، لذا فإنه يسمح لك بإنشاء عناصر من الصفر.

نظرًا لأن الشريحة الرئيسية هي أعلى شريحة في التسلسل الهرمي التي تخزن معلومات حول تخطيطات الشرائح، يمكنك استخدام الشريحة الرئيسية للوصول إلى تخطيطات الشرائح وإجراء تغييرات عليها. يمكن الوصول إلى شريحة التخطيط عن طريق النوع أو الاسم. بالمثل، تحتوي كل شريحة على معرف فريد، يمكن استخدامه للوصول إليها.

بدلاً من ذلك، يمكنك إجراء تغييرات مباشرة على تخطيط شريحة محددة في عرض تقديمي.

* للسماح لك بالعمل مع تخطيطات الشرائح (بما في ذلك تلك الموجودة في الشرائح الرئيسية)، توفر Aspose.Slides خصائص مثل [getLayoutSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) و [getMasters()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) ضمن فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
* لأداء المهام ذات الصلة، توفر Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterlayoutslidecollection/)، [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/)، [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslideheaderfootermanager/)، والعديد من الأنواع الأخرى.

{{% alert title="معلومات" color="info" %}}

للحصول على مزيد من المعلومات حول العمل مع الشرائح الرئيسية على وجه الخصوص، انظر إلى مقالة [شريحة الرئيسية](https://docs.aspose.com/slides/androidjava/slide-master/) .

{{% /alert %}}

## **إضافة تخطيط شريحة إلى العرض التقديمي**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الوصول إلى مجموعة [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/) .
1. استعرض الشرائح التخطيطية الموجودة للتأكد من أن الشريحة التخطيطية المطلوبة موجودة بالفعل في مجموعة الشريحة التخطيطية. خلاف ذلك، أضف الشريحة التخطيطية التي تريدها.
1. أضف شريحة فارغة بناءً على الشريحة التخطيطية الجديدة.
1. احفظ العرض التقديمي.

يظهر هذا الكود Java كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف العرض
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // يستعرض أنواع الشرائح التخطيطية
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // الوضع الذي لا يحتوي فيه العرض تقديمي على بعض أنواع التخطيط.
        // يحتوي ملف العرض فقط على أنواع تخطيط فارغة ومخصصة.
        // لكن الشرائح التخطيطية ذات الأنواع المخصصة لها أسماء شرائح مختلفة،
        // مثل " عنوان "، " عنوان ومحتوى "، وما إلى ذلك. ومن الممكن استخدام هذه
        // الأسماء لاختيار الشريحة التخطيطية.
        // يمكنك أيضًا استخدام مجموعة من أنواع الأشكال النائبة. على سبيل المثال،
        // يجب أن تحتوي شريحة العنوان على نوع عنصر نائب العنوان فقط، وما إلى ذلك.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // يضيف شريحة فارغة مع الشريحة التخطيطية المضافة
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // يحفظ العرض على القرص
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إزالة الشريحة التخطيطية غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) للسماح لك بحذف الشرائح التخطيطية غير المرغوب فيها وغير المستخدمة. يوضح هذا الكود Java كيفية إزالة شريحة تخطيط من عرض PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين الحجم والنوع لتخطيط الشريحة**

للسماح لك بتعيين الحجم والنوع لشريحة تخطيط معينة، توفر Aspose.Slides الخصائص [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) و [getSize()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getSize--) (من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ). يوضح هذا Java العملية:

```java
// إنشاء مثيل من كائن Presentation الذي يمثل ملف العرض
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // تعيين حجم الشريحة للعرض المنشأ إلى حجم المصدر
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // يستنسخ الشريحة المطلوبة
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // يحفظ العرض على القرص
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تعيين رؤية التذييل داخل الشريحة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. احصل على مرجع الشريحة من خلال فهرسها.
1. قم بتعيين عنصر نائب تذييل الشريحة ليكون مرئيًا.
1. قم بتعيين عنصر نائب التاريخ والوقت ليكون مرئيًا.
1. احفظ العرض.

يظهر هذا الكود Java كيفية تعيين الرؤية لتذييل الشريحة (وأداء المهام ذات الصلة):

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // يتم استخدام طريقة isFooterVisible لتحديد أن عنصر نائب تذييل الشريحة مفقود
    {
        headerFooterManager.setFooterVisibility(true); // يتم استخدام طريقة setFooterVisibility لتعيين عنصر نائب تذييل الشريحة ليكون مرئيًا
    }
    if (!headerFooterManager.isSlideNumberVisible()) // يتم استخدام طريقة isSlideNumberVisible لتحديد أن عنصر نائب رقم الصفحة مفقود
    {
        headerFooterManager.setSlideNumberVisibility(true); // يتم استخدام طريقة setSlideNumberVisibility لتعيين عنصر نائب رقم الشريحة ليكون مرئيًا
    }
    if (!headerFooterManager.isDateTimeVisible()) // يتم استخدام طريقة isDateTimeVisible لتحديد أن عنصر نائب التاريخ والوقت مفقود
    {
        headerFooterManager.setDateTimeVisibility(true); // يتم استخدام طريقة SetFooterVisibility لتعيين عنصر نائب التاريخ والوقت ليكون مرئيًا
    }
    headerFooterManager.setFooterText("نص التذييل"); // يتم استخدام طريقة SetFooterText لتعيين نص لتذييل الشريحة.
    headerFooterManager.setDateTimeText("نص التاريخ والوقت"); // يتم استخدام طريقة SetDateTimeText لتعيين نص لعنصر نائب التاريخ والوقت للشريحة.
} finally {
    presentation.dispose();
}
```

## **تعيين رؤية تذييل الطفل داخل الشريحة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. احصل على مرجع للشريحة الرئيسية من خلال فهرسها.
1. قم بتعيين الشريحة الرئيسية وجميع العناصر النائبة للتذييل لتكون مرئية.
1. قم بتعيين نص للشريحة الرئيسية وجميع العناصر النائبة للتذييل.
1. قم بتعيين نص للشريحة الرئيسية وجميع العناصر النائبة للتاريخ والوقت.
1. احفظ العرض.

يظهر هذا الكود Java العملية:

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // يتم استخدام طريقة setFooterAndChildFootersVisibility لتعيين الشريحة الرئيسية وجميع العناصر النائبة لتذييل الطفل لتكون مرئية
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // يتم استخدام طريقة setSlideNumberAndChildSlideNumbersVisibility لتعيين الشريحة الرئيسية وجميع العناصر النائبة لرقم الصفحة لتكون مرئية
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // يتم استخدام طريقة setDateTimeAndChildDateTimesVisibility لتعيين الشريحة الرئيسية وجميع العناصر النائبة للتاريخ والوقت لتكون مرئية

    headerFooterManager.setFooterAndChildFootersText("نص التذييل"); // يتم استخدام طريقة setFooterAndChildFootersText لتعيين النصوص للشريحة الرئيسية وجميع العناصر النائبة للتذييل
    headerFooterManager.setDateTimeAndChildDateTimesText("نص التاريخ والوقت"); // يتم استخدام طريقة setDateTimeAndChildDateTimesText لتعيين نص للشريحة الرئيسية وجميع العناصر النائبة للتاريخ والوقت
} finally {
    presentation.dispose();
}
```

## **تعيين حجم الشريحة مع مراعاة تعديل المحتوى**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وقم بتحميل العرض التقديمي الذي يحتوي على الشريحة التي تريد تعيين حجمها.
1. قم بإنشاء مثيل آخر من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لإنشاء عرض تقديمي جديد.
1. احصل على مرجع الشريحة (من العرض التقديمي الأول) من خلال فهرسها.
1. قم بتعيين عنصر نائب تذييل الشريحة ليكون مرئيًا.
1. قم بتعيين عنصر نائب التاريخ والوقت ليكون مرئيًا.
1. احفظ العرض.

يظهر هذا الكود Java العملية:

```java
// إنشاء مثيل من كائن Presentation الذي يمثل ملف عرض
Presentation presentation = new Presentation("demo.pptx");
try {
    // تعيين حجم الشريحة للعرض المنشأ إلى حجم المصدر
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // يتم استخدام طريقة SetSize لتعيين حجم الشريحة مع تعديل المحتوى للتأكد من التوافق
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // يتم استخدام طريقة SetSize لتعيين حجم الشريحة بحجم محتوى أقصى

    // يحفظ العرض على القرص
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين حجم الصفحة عند إنشاء PDF**

غالبًا ما يتم تحويل عروض تقديمية معينة (مثل الملصقات) إلى مستندات PDF. إذا كنت تبحث عن تحويل PowerPoint إلى PDF للوصول إلى أفضل خيارات الطباعة والوصول، فعليك تعيين الشرائح إلى أحجام تناسب مستندات PDF (A4، على سبيل المثال).

توفر Aspose.Slides فئة [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/) للسماح لك بتحديد إعداداتك المفضلة للشرائح. يوضح هذا الكود Java كيفية استخدام خاصية [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) (من فئة `SlideSize`) لتعيين حجم ورق محدد للشرائح في عرض تقديمي:

```java
// إنشاء مثيل من كائن Presentation الذي يمثل ملف العرض 
Presentation presentation = new Presentation();
try {
    // تعيين خاصية SlideSize.Type  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // تعيين خصائص مختلفة لخيارات PDF
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // يحفظ العرض على القرص
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```