---
title: تطبيق أو تغيير تخطيطات الشرائح في Java
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائبي
- تصميم العرض
- تصميم الشريحة
- تخطيط غير مستخدم
- إظهار التذييل
- شريحة العنوان
- العنوان والمحتوى
- رأس القسم
- محتوى مزدوج
- مقارنة
- العنوان فقط
- تخطيط فارغ
- المحتوى مع تسمية
- صورة مع تسمية
- العنوان والنص العمودي
- العنوان العمودي والنص
- PowerPoint
- OpenDocument
- عرض
- Java
- Aspose.Slides
description: "إدارة وتخصيص تخطيطات الشرائح في Aspose.Slides for Java. استكشف أنواع التخطيطات، التحكم في العناصر النائبة، وإظهار التذييل من خلال أمثلة كود Java."
---

## **نظرة عامة**

يعرف تخطيط الشريحة ترتيب صناديق العناصر النائبة وتنسيق المحتوى على الشريحة. يتحكم في العناصر النائبة المتاحة وأماكن ظهورها. تساعد تخطيطات الشرائح على تصميم العروض بسرعة وبشكل متسق—سواء كنت تنشئ شيئًا بسيطًا أو أكثر تعقيدًا. بعض أكثر تخطيطات الشرائح شيوعًا في PowerPoint تشمل:

**تخطيط شريحة العنوان** – يحتوي على عنصرين نصيين: أحدهما للعنوان والآخر للعنوان الفرعي.

**تخطيط العنوان والمحتوى** – يتضمن عنصر عنوان أصغر في الأعلى وعناصر محتوى أكبر أدناه (مثل النص، النقاط النقطية، المخططات، الصور، والمزيد).

**التخطيط الفارغ** – لا يحتوي على أي عناصر نائبة، مما يمنحك السيطرة الكاملة لتصميم الشريحة من الصفر.

تعد تخطيطات الشرائح جزءًا من ماستَر الشريحة، وهو الشريحة ذات المستوى الأعلى التي تحدد أنماط التخطيط للعرض التقديمي. يمكنك الوصول إلى تخطيطات الشرائح وتعديلها عبر ماستَر الشريحة—إما بحسب النوع أو الاسم أو المعرف الفريد. بدلاً من ذلك، يمكنك تحرير تخطيط شريحة محددة مباشرة داخل العرض التقديمي.

للعمل مع تخطيطات الشرائح في Aspose.Slides for Java، يمكنك استخدام:

- طرق مثل [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) و [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) تحت فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
- أنواع مثل [ILayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/)، [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/)، [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/)، و [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
للتعرف على المزيد حول العمل مع شرائح الماستر، اطلع على مقالة [Slide Master](/slides/ar/java/slide-master/).
{{% /alert %}}

## **إضافة تخطيطات الشرائح إلى العروض التقديمية**

لتخصيص مظهر وبنية الشرائح، قد تحتاج إلى إضافة تخطيطات شريحة جديدة إلى عرض تقديمي. يتيح لك Aspose.Slides for Java التحقق مما إذا كان تخطيط معين موجودًا بالفعل، إضافة جديد إذا لزم الأمر، واستخدامه لإدراج شرائح بناءً على ذلك التخطيط.

1. أنشئ نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. وصول إلى [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/).
1. تحقق مما إذا كان تخطيط الشريحة المطلوب موجودًا بالفعل في المجموعة. إذا لم يكن، أضف تخطيط الشريحة الذي تحتاجه.
1. أضف شريحة فارغة تعتمد على تخطيط الشريحة الجديد.
1. احفظ العرض التقديمي.

الكود التالي في Java يوضح كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // انتقل عبر أنواع شرائح التخطيط لاختيار شريحة تخطيط.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // حالة يكون فيها العرض التقديمي لا يحتوي على جميع أنواع التخطيط.
        // ملف العرض التقديمي يحتوي فقط على نوعي تخطيط Blank و Custom.
        // ومع ذلك، قد تحتوي شرائح التخطيط ذات الأنواع المخصصة على أسماء يمكن التعرف عليها،
        // مثل "Title"، "Title and Content"، إلخ، والتي يمكن استخدامها لاختيار شريحة التخطيط.
        // يمكنك أيضًا الاعتماد على مجموعة من أنواع أشكال العناصر النائبة.
        // على سبيل المثال، يجب أن تحتوي شريحة العنوان على نوع العنصر النائب Title فقط، وهكذا.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
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

    // إضافة شريحة فارغة باستخدام شريحة التخطيط المضافة.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إزالة تخطيطات الشرائح غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) في فئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) لتسمح لك بحذف تخطيطات الشرائح غير المرغوبة وغير المستخدمة.

الكود التالي في Java يوضح كيفية إزالة تخطيط شريحة من عرض PowerPoint:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إضافة عناصر نائبة إلى تخطيطات الشرائح**

توفر Aspose.Slides الطريقة [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)، التي تتيح لك إضافة عناصر نائبة جديدة إلى تخطيط الشريحة.

هذا المدير يحتوي على طرق للأنواع التالية من العناصر النائبة:

| عنصر نائبي في PowerPoint           | طريقة في [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| ![المحتوى](content.png)            | addContentPlaceholder(float x, float y, float width, float height)                                            |
| ![المحتوى (عمودي)](contentV.png)  | addVerticalContentPlaceholder(float x, float y, float width, float height)                                   |
| ![نص](text.png)                     | addTextPlaceholder(float x, float y, float width, float height)                                               |
| ![نص (عمودي)](textV.png)           | addVerticalTextPlaceholder(float x, float y, float width, float height)                                      |
| ![صورة](picture.png)               | addPicturePlaceholder(float x, float y, float width, float height)                                            |
| ![مخطط](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height)                                              |
| ![جدول](table.png)                 | addTablePlaceholder(float x, float y, float width, float height)                                              |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height)                                           |
| ![وسائط](media.png)                | addMediaPlaceholder(float x, float y, float width, float height)                                              |
| ![صورة عبر الإنترنت](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height)                                       |

الكود التالي في Java يوضح كيفية إضافة أشكال عنصر نائبة جديدة إلى تخطيط الشريحة الفارغة:
```java
Presentation presentation = new Presentation();
try {
    // احصل على شريحة التخطيط الفارغة.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // احصل على مدير العناصر النائبة لشريحة التخطيط.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // أضف عناصر نائبة مختلفة إلى شريحة التخطيط الفارغة.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // أضف شريحة جديدة باستخدام التخطيط الفارغ.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![العناصر النائبة على تخطيط الشريحة](add_placeholders.png)

## **تعيين إظهار تذييل الشريحة لتخطيط شريحة**

في عروض PowerPoint، يمكن إظهار أو إخفاء عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص وفقًا لتخطيط الشريحة. يتيح لك Aspose.Slides for Java التحكم في إظهار هذه العناصر النائبة في التذييل. هذا مفيد عندما تريد أن تعرض بعض التخطيطات معلومات التذييل بينما تظل أخرى نظيفة وبسيطة.

1. أنشئ نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. احصل على مرجع لتخطيط شريحة عبر فهرسه.
1. ضع عنصر نائبة تذييل الشريحة على وضع الإظهار.
1. ضع عنصر نائبة رقم الشريحة على وضع الإظهار.
1. ضع عنصر نائبة التاريخ/الوقت على وضع الإظهار.
1. احفظ العرض التقديمي.

الكود التالي في Java يوضح كيفية تعيين إظهار تذييل شريحة وتطبيق المهام ذات الصلة:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **تعيين إظهار تذييل الطفل لشريحة**

في عروض PowerPoint، يمكن التحكم في عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص على مستوى شريحة الماستر لضمان التناسق عبر جميع تخطيطات الشرائح. يتيح لك Aspose.Slides for Java تعيين إظهار ومحتوى هذه العناصر النائبة على شريحة الماستر ونشر هذه الإعدادات إلى جميع تخطيطات الشرائح الفرعية. يضمن هذا النهج توحيد معلومات التذييل عبر العرض التقديمي بالكامل.

1. أنشئ نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. احصل على مرجع لشريحة الماستر عبر فهرسه.
1. ضع جميع عناصر نائبة التذييل للماستر والأطفال على وضع الإظهار.
1. ضع جميع عناصر نائبة رقم الشريحة للماستر والأطفال على وضع الإظهار.
1. ضع جميع عناصر نائبة التاريخ/الوقت للماستر والأطفال على وضع الإظهار.
1. احفظ العرض التقديمي.

الكود التالي في Java يوضح هذه العملية:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتكررة**

**ما الفرق بين شريحة الماستر وشريحة التخطيط؟**

تعرف شريحة الماستر السمة العامة والتنسيق الافتراضي، بينما تحدد شرائح التخطيط ترتيبات محددة للعناصر النائبة لأنواع مختلفة من المحتوى.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم، يمكنك استنساخ شريحة تخطيط من مجموعة شرائح التخطيط في عرض تقديمي عبر طريقة [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--)، ثم إدراجها في عرض تقديمي آخر باستخدام طريقة `addClone`.

**ماذا يحدث إذا حذفت شريحة تخطيط لا يزال أحد الشرائح يستخدمها؟**

إذا حاولت حذف شريحة تخطيط لا يزال هناك شريحة واحدة على الأقل في العرض التقديمي تشير إليها، ست Throw Aspose.Slides استثناء [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/). لتجنب ذلك، استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) التي تزيل بأمان فقط تخطيطات الشرائح غير المستخدمة.