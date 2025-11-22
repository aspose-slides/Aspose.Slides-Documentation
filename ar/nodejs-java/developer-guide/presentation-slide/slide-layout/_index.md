---
title: تطبيق أو تغيير تخطيط الشريحة في JavaScript
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/nodejs-java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة العنوان
- العنوان والمحتوى
- رأس القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع تسمية
- صورة مع تسمية
- العنوان والنص العمودي
- عنوان عمودي ونص
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرّف على كيفية إدارة وتخصيص تخطيطات الشرائح في Aspose.Slides لـ Node.js. استكشف أنواع التخطيطات، التحكم في العناصر النائبة، رؤية التذييل، ومعالجة التخطيطات من خلال أمثلة برمجية بلغة JavaScript."
---

## **نظرة عامة**

يحدد تخطيط الشريحة ترتيب مربعات العناصر النائبة وتنسيق المحتوى على الشريحة. يتحكم في العناصر النائبة المتاحة وأماكن ظهورها. تساعد تخطيطات الشرائح في تصميم العروض التقديمية بسرعة وبشكل متسق — سواء كنت تنشئ شيئًا بسيطًا أو أكثر تعقيدًا. بعض أكثر تخطيطات الشرائح شيوعًا في PowerPoint تشمل:

**تخطيط شريحة العنوان** – يتضمن عنصرين نائبين للنص: أحدهما للعنوان والآخر للعنوان الفرعي.

**تخطيط العنوان والمحتوى** – يحتوي على عنصر نائب للعنوان أصغر في الأعلى وآخر أكبر أسفله للمحتوى الرئيسي (مثل النص، النقاط، المخططات، الصور، والمزيد).

**تخطيط فارغ** – لا يحتوي على أي عناصر نائبة، مما يمنحك السيطرة الكاملة لتصميم الشريحة من الصفر.

تعد تخطيطات الشرائح جزءًا من نموذج الشريحة (Slide Master)، وهو الشريحة العليا التي تحدد أنماط التخطيط للعرض التقديمي. يمكنك الوصول إلى تخطيطات الشرائح وتعديلها عبر نموذج الشريحة — إما حسب النوع أو الاسم أو المعرف الفريد. بدلاً من ذلك، يمكنك تحرير تخطيط شريحة محدد مباشرة داخل العرض التقديمي.

للتعامل مع تخطيطات الشرائح في Aspose.Slides لـ Node.js، يمكنك استخدام:

- طرق مثل [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) و[getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) ضمن فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
- أنواع مثل [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/)، [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/)، و[LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
للتعرف على المزيد حول التعامل مع نماذج الشرائح، راجع مقالة [Slide Master](/slides/ar/nodejs-java/slide-master/).
{{% /alert %}}

## **إضافة تخطيطات شرائح إلى العروض التقديمية**

لتخصيص مظهر وهيكل الشرائح الخاصة بك، قد تحتاج إلى إضافة تخطيطات شرائح جديدة إلى العرض التقديمي. يتيح لك Aspose.Slides لـ Node.js التحقق مما إذا كان تخطيط معين موجودًا بالفعل، إضافة تخطيط جديد إذا لزم الأمر، واستخدامه لإدراج شرائح بناءً على ذلك التخطيط.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. احصل على مجموعة [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. تحقق مما إذا كان تخطيط الشريحة المطلوب موجودًا بالفعل في المجموعة. إذا لم يكن موجودًا، أضف تخطيط الشريحة الذي تحتاجه.
1. أضف شريحة فارغة تعتمد على تخطيط الشريحة الجديد.
1. احفظ العرض التقديمي.

الكود JavaScript التالي يوضح كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:
```js
// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // المرور عبر أنواع شرائح التخطيط لاختيار شريحة تخطيط.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // حالة حيث لا يحتوي العرض التقديمي على جميع أنواع التخطيط.
        // ملف العرض التقديمي يحتوي فقط على نوعي التخطيط Blank و Custom.
        // ومع ذلك، قد تحتوي شرائح التخطيط ذات الأنواع المخصصة على أسماء يمكن التعرف عليها،
        // مثل "Title"، "Title and Content"، إلخ، والتي يمكن استخدامها لاختيار شريحة التخطيط.
        // يمكنك أيضًا الاعتماد على مجموعة من أنواع الأشكال النائبة.
        // على سبيل المثال، يجب أن تحتوي شريحة العنوان فقط على نوع العنصر النائب Title، وما إلى ذلك.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // إضافة شريحة فارغة باستخدام شريحة التخطيط المضافة.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إزالة تخطيطات الشرائح غير المستخدمة**

يوفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) من فئة [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) للسماح لك بحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة.

الكود JavaScript التالي يوضح كيفية إزالة تخطيط شريحة من عرض PowerPoint:
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إضافة عناصر نائبة إلى تخطيطات الشرائح**

يوفر Aspose.Slides الطريقة [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) التي تتيح لك إضافة عناصر نائبة جديدة إلى تخطيط الشريحة.

هذا المدير يحتوي على طرق لأنواع العناصر النائبة التالية:

| عنصر نائب في PowerPoint | طريقة [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

الكود JavaScript التالي يوضح كيفية إضافة أشكال عناصر نائبة جديدة إلى تخطيط الشريحة الفارغة:
```js
let presentation = new aspose.slides.Presentation();
try {
    // احصل على شريحة التخطيط الفارغة.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // احصل على مدير العناصر النائبة لشريحة التخطيط.
    let placeholderManager = layout.getPlaceholderManager();

    // أضف عناصر نائبة مختلفة إلى شريحة التخطيط الفارغة.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // أضف شريحة جديدة باستخدام التخطيط الفارغ.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


النتيجة:

![العناصر النائبة على تخطيط الشريحة](add_placeholders.png)

## **تعيين رؤية تذييل الشريحة لتخطيط معين**

في عروض PowerPoint، يمكن إظهار أو إخفاء عناصر التذييل مثل التاريخ ورقم الشريحة والنص المخصص اعتمادًا على تخطيط الشريحة. يتيح لك Aspose.Slides لـ Node.js التحكم في رؤية هذه العناصر النائبة للتذييل. هذا مفيد عندما تريد أن تعرض بعض التخطيطات معلومات التذييل بينما تبقى أخرى نظيفة وبسيطة.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. احصل على مرجع لتخطيط الشريحة عبر فهرسته.
1. اضبط عنصر التذييل في الشريحة ليكون مرئيًا.
1. اضبط عنصر رقم الشريحة ليكون مرئيًا.
1. اضبط عنصر التاريخ والوقت ليكون مرئيًا.
1. احفظ العرض التقديمي.

الكود JavaScript التالي يوضح كيفية تعيين رؤية تذييل الشريحة وتنفيذ المهام المرتبطة:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **تعيين رؤية تذييل العنصر الفرعي لشريحة**

​في عروض PowerPoint، يمكن التحكم في عناصر التذييل مثل التاريخ ورقم الشريحة والنص المخصص على مستوى نموذج الشريحة لضمان التناسق عبر جميع تخطيطات الشرائح. يتيح لك Aspose.Slides لـ Node.js تعيين رؤية ومحتوى هذه العناصر النائبة للتذييل على نموذج الشريحة ونشر هذه الإعدادات إلى جميع تخطيطات الشرائح الفرعية. يضمن هذا النهج توحيد معلومات التذييل في جميع أنحاء العرض التقديمي.​

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. احصل على مرجع لنموذج الشريحة عبر فهرسته.
1. اضبط جميع عناصر التذييل في النموذج وجميع التخطيطات الفرعية لتكون مرئية.
1. اضبط جميع عناصر رقم الشريحة في النموذج وجميع التخطيطات الفرعية لتكون مرئية.
1. اضبط جميع عناصر التاريخ والوقت في النموذج وجميع التخطيطات الفرعية لتكون مرئية.
1. احفظ العرض التقديمي.

الكود JavaScript التالي يوضح هذه العملية:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتداولة**

**ما الفرق بين نموذج الشريحة وتخطيط الشريحة؟**

يحدد نموذج الشريحة السمة العامة وتنسيق القيم الافتراضية، بينما تحدد تخطيطات الشرائح ترتيبًا محددًا للعناصر النائبة لأنواع المحتوى المختلفة.

**هل يمكنني نسخ تخطيط شريحة من عرض تقديمي إلى آخر؟**

نعم، يمكنك استنساخ تخطيط شريحة من مجموعة تخطيطات عرض تقديمي باستخدام طريقة [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides)، ثم إدراجها في عرض تقديمي آخر باستخدام الطريقة `addClone`.

**ماذا يحدث إذا حذفت تخطيط شريحة لا يزال مستخدمًا بواسطة شريحة؟**

إذا حاولت حذف تخطيط شريحة لا يزال مُشارًًا إليه من قبل شريحة واحدة على الأقل في العرض التقديمي، سيُطلق Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/). لتجنب ذلك، استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) التي تزيل بأمان فقط تخطيطات الشرائح غير المستخدمة.