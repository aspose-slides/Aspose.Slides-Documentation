---
title: تخطيط الشريحة
type: docs
weight: 60
url: /java/slide-layout/
keyword: "تعيين حجم الشريحة، تعيين خيارات الشريحة، تحديد حجم الشريحة، رؤية التذييل، تذييل الأطفال، قياس المحتوى، حجم الصفحة، Java، Aspose.Slides"
description: "تعيين حجم الشريحة في PowerPoint والخيارات في Java"
---

يحتوي تخطيط الشريحة على صناديق المكان والمعلومات التنسيقية لجميع المحتويات التي تظهر على الشريحة. يحدد التخطيط الأماكن المتاحة للمحتوى ومكان وضعها.

تتيح لك تخطيطات الشرائح إنشاء وتصميم العروض التقديمية بسرعة (سواء كانت بسيطة أو معقدة). هذه بعض من أشهر تخطيطات الشرائح المستخدمة في عروض PowerPoint:

* **تخطيط شريحة العنوان**. يتكون هذا التخطيط من مكانين نصيين. مكان واحد هو العنوان والمكان الآخر هو العنوان الفرعي.
* **تخطيط العنوان والمحتوى**. يحتوي هذا التخطيط على مكان نصي صغير نسبيًا في الأعلى للعناوين ومكان أكبر للمحتوى الأساسي (المخطط البياني، الفقرات، قائمة النقاط، القائمة المرقمة، الصور، إلخ).
* **تخطيط فارغ**. يفتقر هذا التخطيط إلى أماكن، مما يتيح لك إنشاء العناصر من الصفر.

نظرًا لأن مخطط الشريحة هو أعلى شريحة هرمية تخزن معلومات حول تخطيطات الشرائح، يمكنك استخدام شريحة المخطط للوصول إلى تخطيطات الشرائح وإجراء التغييرات عليها. يمكن الوصول إلى الشريحة التخطيطية بالنوع أو الاسم. بالمثل، كل شريحة لها معرف فريد يمكن استخدامه للوصول إليها.

بدلاً من ذلك، يمكنك إجراء تغييرات مباشرة على تخطيط شريحة معينة في عرض تقديمي.

* للسماح لك بالعمل مع تخطيطات الشرائح (بما في ذلك تلك الموجودة في الشرائح الرئيسية)، توفر Aspose.Slides خصائص مثل [getLayoutSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) و[getMasters()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) تحت فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
* لأداء المهام ذات الصلة، توفر Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/masterlayoutslidecollection/)، [SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/)، [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/baseslideheaderfootermanager/)، والعديد من الأنواع الأخرى.

{{% alert title="معلومات" color="info" %}}

للحصول على مزيد من المعلومات حول العمل مع شرائح المخطط بشكل خاص، انظر إلى المقالة [Slide Master](https://docs.aspose.com/slides/java/slide-master/).

{{% /alert %}}

## **إضافة تخطيط شريحة إلى العرض التقديمي**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. الوصول إلى [مجموعة MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/).
1. تصفح شرائح التخطيط الموجودة للتأكد من وجود شريحة التخطيط المطلوبة بالفعل في مجموعة الشرائح. خلاف ذلك، أضف شريحة التخطيط التي تريدها.
1. أضف شريحة فارغة بناءً على شريحة التخطيط الجديدة.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود بلغة Java كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:

```java
// إنشائي كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // يستعرض أنواع شرائح التخطيط
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // الحالة التي لا يحتوي فيها العرض التقديمي على بعض أنواع التخطيط.
        // يحتوي ملف العرض فقط على تخطيطات فارغة ومخصصة.
        // لكن شرائح التخطيط من الأنواع المخصصة لها أسماء شريحة مختلفة،
        // مثل "العنوان"، "العنوان والمحتوى"، إلخ. ومن الممكن استخدام هذه
        // الأسماء لاختيار شريحة التخطيط.
        // يمكنك أيضًا استخدام مجموعة من أنواع شكل الحاويات. على سبيل المثال،
        // يجب أن تحتوي شريحة العنوان على نوع حاوية العنوان فقط، إلخ.
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

    // يضيف شريحة فارغة باستخدام شريحة التخطيط المضافة
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // يحفظ العرض التقديمي على القرص
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إزالة شريحة التخطيط غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) من فئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) للسماح لك بحذف شرائح التخطيط غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الكود بلغة Java كيفية إزالة شريحة تخطيط من عرض PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين الحجم والنوع لشريحة التخطيط**

للسماح لك بتعيين الحجم والنوع لشريحة تخطيط محددة، توفر Aspose.Slides الخصائص [getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--) و[getSize()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getSize--) (من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)). توضح لك هذه الشفرة بلغة Java العملية:

```java
// إنشائي كائن من فئة Presentation الذي يمثل ملف العرض التقديمي
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // تعيين حجم الشريحة للعرض التقديمي الناتج ليكون مطابقًا للمصدر
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // نسخ الشريحة المطلوبة
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // يحفظ العرض التقديمي على القرص
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **تعيين رؤية التذييل داخل الشريحة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. احصل على مرجع شريحة من خلال فهرسها.
1. اضبط مكان التذييل الخاص بالشريحة ليكون مرئيًا.
1. اضبط مكان التاريخ والوقت ليكون مرئيًا.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود بلغة Java كيفية تعيين الرؤية لتذييل الشريحة (وأداء المهام ذات الصلة):

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // يتم استخدام طريقة isFooterVisible لتحديد أن مكان تذييل الشريحة مفقود
    {
        headerFooterManager.setFooterVisibility(true); // يتم استخدام طريقة setFooterVisibility لجعل مكان تذييل الشريحة مرئيًا
    }
    if (!headerFooterManager.isSlideNumberVisible()) // يتم استخدام طريقة isSlideNumberVisible لتحديد أن مكان رقم صفحة الشريحة مفقود
    {
        headerFooterManager.setSlideNumberVisibility(true); // يتم استخدام طريقة setSlideNumberVisibility لجعل مكان رقم صفحة الشريحة مرئيًا
    }
    if (!headerFooterManager.isDateTimeVisible()) // يتم استخدام طريقة isDateTimeVisible لتحديد أن مكان تاريخ ووقت الشريحة مفقود
    {
        headerFooterManager.setDateTimeVisibility(true); // يتم استخدام طريقة SetFooterVisibility لجعل مكان تاريخ ووقت الشريحة مرئيًا
    }
    headerFooterManager.setFooterText("نص التذييل"); // يتم استخدام طريقة SetFooterText لتعيين نص لمكان تذييل الشريحة.
    headerFooterManager.setDateTimeText("نص التاريخ والوقت"); // يتم استخدام طريقة SetDateTimeText لتعيين نص لمكان تاريخ ووقت الشريحة.
} finally {
    presentation.dispose();
}
```

## **تعيين رؤية تذييل الأطفال داخل الشريحة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. احصل على مرجع لشريحة المخطط من خلال فهرسها.
1. اجعل شريحة المخطط وجميع أماكن تذييل الأطفال مرئية.
1. اضبط نصًا لشريحة المخطط وجميع أماكن تذييل الأطفال.
1. اضبط نصًا لشريحة المخطط وجميع أماكن تاريخ ووقت الأطفال.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود بلغة Java العملية:

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // يتم استخدام طريقة setFooterAndChildFootersVisibility لجعل شريحة المخطط وجميع أماكن تذييل الأطفال مرئية
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // يتم استخدام طريقة setSlideNumberAndChildSlideNumbersVisibility لجعل شريحة المخطط وجميع أماكن رقم صفحة الأطفال مرئية
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // يتم استخدام طريقة setDateTimeAndChildDateTimesVisibility لجعل شريحة المخطط وجميع أماكن تاريخ ووقت الأطفال مرئية

    headerFooterManager.setFooterAndChildFootersText("نص التذييل"); // يتم استخدام طريقة setFooterAndChildFootersText لتعيين نصوص لشريحة المخطط وجميع أماكن تذييل الأطفال
    headerFooterManager.setDateTimeAndChildDateTimesText("نص التاريخ والوقت"); // يتم استخدام طريقة setDateTimeAndChildDateTimesText لتعيين نص لمخطط الشريحة وجميع أماكن تاريخ ووقت الأطفال
} finally {
    presentation.dispose();
}
```

## **تعيين حجم الشريحة بالنظر إلى قياس المحتوى**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وقم بتحميل العرض التقديمي الذي يحتوي على الشريحة التي تريد تعيين حجمها.
1. قم بإنشاء مثيل آخر من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) لإنشاء عرض تقديمي جديد.
1. احصل على مرجع للشريحة (من العرض التقديمي الأول) من خلال فهرسها.
1. اضبط مكان التذييل الخاص بالشريحة ليكون مرئيًا.
1. اضبط مكان التاريخ والوقت ليكون مرئيًا.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود بلغة Java العملية:

```java
// إنشائي كائن من فئة Presentation الذي يمثل ملف العرض التقديمي
Presentation presentation = new Presentation("demo.pptx");
try {
    // تعيين حجم الشريحة للعرض التقديمي الناتج ليكون مطابقًا للمصدر
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // يتم استخدام طريقة SetSize لتعيين حجم الشريحة مع قياس المحتوى لضمان الملاءمة
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // يتم استخدام طريقة SetSize لتعيين حجم الشريحة مع الحد الأقصى لحجم المحتوى

    // يحفظ العرض التقديمي على القرص
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين حجم الصفحة عند إنشاء PDF**

غالبًا ما يتم تحويل بعض العروض التقديمية (مثل الملصقات) إلى مستندات PDF. إذا كنت ترغب في تحويل PowerPoint إلى PDF للوصول إلى أفضل خيارات الطباعة والوصول، فإنك تريد تعيين شرائحك إلى أحجام تناسب مستندات PDF (A4، على سبيل المثال).

توفر Aspose.Slides فئة [SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/) للسماح لك بتحديد إعداداتك المفضلة للشرائح. يوضح لك هذا الكود بلغة Java كيفية استخدام خاصية [getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--) (من فئة `SlideSize`) لتعيين حجم ورق محدد للشرائح في العرض التقديمي:

```java
// إنشائي كائن من فئة Presentation الذي يمثل ملف العرض التقديمي 
Presentation presentation = new Presentation();
try {
    // تعيين خاصية SlideSize.Type  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // تعيين خصائص مختلفة لخيارات PDF
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // يحفظ العرض التقديمي على القرص
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```