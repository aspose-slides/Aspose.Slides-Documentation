---
title: تطبيق أو تغيير تخطيطات الشرائح على Android
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/androidjava/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- العنصر النائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة العنوان
- العنوان والمحتوى
- عنوان القسم
- محتويان
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع تسمية
- صورة مع تسمية
- العنوان والنص العمودي
- عنوان و نص عمودي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة وتخصيص تخطيطات الشرائح في Aspose.Slides for Android. استكشاف أنواع التخطيطات، التحكم في العناصر النائبة، ورؤية التذييل من خلال أمثلة كود Java."
---

## **نظرة عامة**

يحدد تخطيط الشريحة ترتيب صناديق العنصر النائب والتنسيق للمحتوى على الشريحة. يتحكم في العناصر النائبة المتاحة ومكان ظهورها. تساعد تخطيطات الشرائح على تصميم العروض بسرعة وبشكل متسق—سواءً كنت تنشئ شيئًا بسيطًا أو أكثر تعقيدًا. بعض أكثر تخطيطات الشرائح شيوعًا في PowerPoint تشمل:

**تخطيط شريحة العنوان** – يتضمن عنصرين نائبيْن للنص: أحدهما للعنوان والآخر للعنوان الفرعي.

**تخطيط العنوان والمحتوى** – يحتوي على عنصر عنوان أصغر في الأعلى وآخر أكبر أدناه للمحتوى الرئيسي (مثل النص، النقاط، المخططات، الصور، وأكثر).

**التخطيط الفارغ** – لا يحتوي على عناصر نائبة، مما يمنحك التحكم الكامل لتصميم الشريحة من الصفر.

تعد تخطيطات الشرائح جزءًا من الشريحة الرئيسية (slide master)، وهي الشريحة العليا التي تُعرّف أنماط التخطيط للعرض التقديمي. يمكنك الوصول إلى تخطيطات الشرائح وتعديلها عبر الشريحة الرئيسية—إما بحسب النوع أو الاسم أو المعرف الفريد. بدلاً من ذلك، يمكنك تعديل تخطيط شريحة معينة مباشرةً داخل العرض التقديمي.

للعمل مع تخطيطات الشرائح في Aspose.Slides for Android، يمكنك استخدام:

- طرق مثل [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) و[getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) ضمن فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
- أنواع مثل [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/)، [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/)، [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/)، و[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
للتعلم المزيد حول العمل مع الشرائح الرئيسية، اطلع على مقال [Slide Master](/slides/ar/androidjava/slide-master/).
{{% /alert %}}

## **إضافة تخطيطات شرائح إلى العروض التقديمية**

لتخصيص مظهر وبنية الشرائح الخاصة بك، قد تحتاج إلى إضافة تخطيطات شرائح جديدة إلى العرض التقديمي. يتيح لك Aspose.Slides for Android التحقق مما إذا كان تخطيط معين موجودًا بالفعل، إضافة واحد جديد إذا لزم الأمر، واستخدامه لإدراج شرائح بناءً على ذلك التخطيط.

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. وصول إلى [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. تحقق مما إذا كان تخطيط الشريحة المطلوب موجودًا بالفعل في المجموعة. إذا لم يكن موجودًا، أضف تخطيط الشريحة الذي تحتاجه.
1. أضف شريحة فارغة بناءً على تخطيط الشريحة الجديد.
1. احفظ العرض التقديمي.

يعرض الكود Java التالي كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // التنقل عبر أنواع شرائح التخطيط لاختيار شريحة تخطيط.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // حالة لا يحتوي فيها العرض التقديمي على جميع أنواع التخطيط.
        // ملف العرض التقديمي يحتوي فقط على أنواع التخطيط Blank و Custom.
        // مع ذلك، قد تحتوي شرائح التخطيط ذات الأنواع المخصصة على أسماء يمكن التعرف عليها،
        // مثل "Title" و "Title and Content" وغيرها، والتي يمكن استخدامها لاختيار شريحة التخطيط.
        // يمكنك أيضًا الاعتماد على مجموعة من أنواع أشكال العنصر النائب.
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

يوفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) لتسمح لك بحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة.

يعرض الكود Java التالي كيفية إزالة تخطيط شريحة من عرض PowerPoint:
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

يوفر Aspose.Slides الطريقة [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)، والتي تسمح لك بإضافة عناصر نائبة جديدة إلى تخطيط الشريحة.

يحتوي هذا المدير على طرق للأنواع التالية من العناصر النائبة:

| عنصر نائب في PowerPoint | طريقة [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| ![Content](content.png) | addContentPlaceholder(float x,float y,float width,float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x,float y,float width,float height) |
| ![Text](text.png) | addTextPlaceholder(float x,float y,float width,float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x,float y,float width,float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x,float y,float width,float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x,float y,float width,float height) |
| ![Table](table.png) | addTablePlaceholder(float x,float y,float width,float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x,float y,float width,float height) |
| ![Media](media.png) | addMediaPlaceholder(float x,float y,float width,float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x,float y,float width,float height) |

يعرض الكود Java التالي كيفية إضافة أشكال عنصر نائب جديدة إلى تخطيط الشريحة الفارغة:
```java
Presentation presentation = new Presentation();
try {
    // احصل على شريحة التخطيط الفارغ.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // احصل على مدير العنصر النائب لشريحة التخطيط.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // أضف عناصر نائبة مختلفة إلى شريحة التخطيط الفارغ.
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

![The placeholders on the layout slide](add_placeholders.png)

## **ضبط رؤية تذييل الشريحة لتخطيط معين**

في عروض PowerPoint، يمكن إظهار أو إخفاء عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص اعتمادًا على تخطيط الشريحة. يتيح لك Aspose.Slides for Android التحكم في رؤية هذه العناصر النائبة في التذييل. هذا مفيد عندما تريد أن تعرض بعض التخطيطات معلومات التذييل بينما تظل أخرى نظيفة وبسيطة.

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. احصل على مرجع لتخطيط الشريحة عبر فهرسه.
1. عيّن عنصر نائب تذييل الشريحة إلى مرئي.
1. عيّن عنصر نائب رقم الشريحة إلى مرئي.
1. عيّن عنصر نائب التاريخ/الوقت إلى مرئي.
1. احفظ العرض التقديمي.

يعرض الكود Java التالي كيفية ضبط رؤية تذييل الشريحة وأداء المهام المرتبطة:
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


## **ضبط رؤية تذييل الشرائح الفرعية**

​في عروض PowerPoint، يمكن التحكم في عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص على مستوى الشريحة الرئيسية لضمان الاتساق عبر جميع تخطيطات الشرائح. يتيح لك Aspose.Slides for Android ضبط رؤية ومحتوى هذه العناصر النائبة على الشريحة الرئيسية ونشر هذه الإعدادات إلى جميع تخطيطات الشرائح الفرعية. يضمن هذا النهج توحيد معلومات التذييل طوال العرض التقديمي.​

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة الرئيسية عبر فهرستها.
1. عيّن جميع عناصر تذييل الشريحة الرئيسية والفرعية إلى مرئية.
1. عيّن جميع عناصر رقم الشريحة الرئيسية والفرعية إلى مرئية.
1. عيّن جميع عناصر التاريخ/الوقت الرئيسية والفرعية إلى مرئية.
1. احفظ العرض التقديمي.

يعرض الكود Java التالي هذا العملية:
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


## **الأسئلة الشائعة**

**ما الفرق بين الشريحة الرئيسية وتخطيط الشريحة؟**

تحدد الشريحة الرئيسية السمة العامة والتنسيق الافتراضي، بينما تحدد تخطيطات الشرائح ترتيبات محددة للعناصر النائبة لأنواع مختلفة من المحتوى.

**هل يمكنني نسخ تخطيط شريحة من عرض تقديمي إلى آخر؟**

نعم، يمكنك استنساخ تخطيط شريحة من مجموعة تخطيطات عرض تقديمي باستخدام طريقة [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--)، وإدراجه في عرض تقديمي آخر باستخدام طريقة `addClone`.

**ماذا يحدث إذا حذفت تخطيط شريحة لا يزال مستخدمًا من قبل شريحة أخرى؟**

إذا حاولت حذف تخطيط شريحة لا يزال مُشارًا إليه من قبل شريحة واحدة على الأقل في العرض التقديمي، سيطرح Aspose.Slides استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/). لتجنب ذلك، استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) التي تزيل بأمان فقط تخطيطات الشرائح غير المستخدمة.