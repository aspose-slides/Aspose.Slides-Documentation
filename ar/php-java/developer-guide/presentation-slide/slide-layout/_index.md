---
title: تطبيق أو تغيير تخطيطات الشرائح في PHP
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/php-java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
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
- محتوى مع توضيح
- صورة مع توضيح
- العنوان والنص العمودي
- العنوان العمودي والنص
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة وتخصيص تخطيطات الشرائح في Aspose.Slides لـ PHP عبر Java. استكشاف أنواع التخطيطات، التحكم في العناصر النائبة، وإظهار التذييل من خلال أمثلة الشيفرة."
---

## **نظرة عامة**

تعرّف تخطيط الشريحة ترتيب صناديق العناصر النائبة وتنسيق المحتوى على الشريحة. يتحكم في العناصر النائبة المتاحة ومكان ظهورها. تساعد تخطيطات الشرائح في تصميم العروض التقديمية بسرعة وبشكل متسق — سواء كنت تنشئ شيئًا بسيطًا أو أكثر تعقيدًا. بعض أكثر تخطيطات الشرائح شيوعًا في PowerPoint تشمل:

**Title Slide layout** – يتضمن عنصرين نصيين نائبين: واحد للعنوان وآخر للعنوان الفرعي.

**Title and Content layout** – يحتوي على عنصر عنوان أصغر في الأعلى وآخر أكبر أدناه للمحتوى الرئيسي (مثل النص، النقاط النقطية، الرسوم البيانية، الصور، وغير ذلك).

**Blank layout** – لا يحتوي على أي عناصر نائبة، مما يمنحك التحكم الكامل لتصميم الشريحة من الصفر.

تعد تخطيطات الشرائح جزءًا من شريحة رئيسية (slide master)، وهي الشريحة العليا التي تحدد أنماط التخطيط للعرض التقديمي. يمكنك الوصول إلى تخطيطات الشرائح وتعديلها عبر الشريحة الرئيسية — إما حسب نوعها أو اسمها أو معرّفها الفريد. بدلاً من ذلك، يمكنك تحرير تخطيط شريحة محدد مباشرة داخل العرض التقديمي.

للعمل مع تخطيطات الشرائح في Aspose.Slides لـ PHP، يمكنك استخدام:
- طرق مثل [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides) و[getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) ضمن الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
- أنواع مثل [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)،[MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)،[LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/)،و[LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
لتعلم المزيد حول العمل مع الشرائح الرئيسية، اطلع على مقالة [Slide Master](/slides/ar/php-java/slide-master/) .
{{% /alert %}}

## **إضافة تخطيطات الشرائح إلى العروض التقديمية**

لتخصيص مظهر هيكل الشرائح الخاصة بك، قد تحتاج إلى إضافة تخطيطات شرائح جديدة إلى عرض تقديمي. يتيح لك Aspose.Slides لـ PHP التحقق مما إذا كان تخطيط معين موجودًا بالفعل، وإضافة واحد جديد إذا لزم الأمر، واستخدامه لإدراج شرائح بناءً على ذلك التخطيط.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الوصول إلى [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/) .
3. التحقق مما إذا كان تخطيط الشريحة المطلوب موجودًا بالفعل في المجموعة. إذا لم يكن كذلك، أضف تخطيط الشريحة الذي تحتاجه.
4. إضافة شريحة فارغة تعتمد على تخطيط الشريحة الجديد.
5. حفظ العرض التقديمي.

يعرض الكود PHP التالي كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:
```php
// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // التنقل عبر أنواع شرائح التخطيط لاختيار شريحة تخطيط.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // حالة لا يحتوي فيها العرض التقديمي على جميع أنواع التخطيط.
        // ملف العرض التقديمي يحتوي فقط على أنواع التخطيط Blank و Custom.
        // ومع ذلك، قد تحتوي شرائح التخطيط ذات الأنواع المخصصة على أسماء يمكن التعرف عليها،
        // مثل "Title", "Title and Content", وما إلى ذلك، والتي يمكن استخدامها لاختيار شريحة التخطيط.
        // يمكنك أيضًا الاعتماد على مجموعة من أنواع أشكال العناصر النائبة.
        // على سبيل المثال، يجب أن تحتوي شريحة العنوان فقط على نوع العنصر النائب Title، وما إلى ذلك.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // إضافة شريحة فارغة باستخدام شريحة التخطيط المضافة.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // حفظ العرض التقديمي إلى القرص.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **إزالة تخطيطات الشرائح غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) من الفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) لتتيح لك حذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة.

يعرض الكود PHP التالي كيفية إزالة تخطيط شريحة من عرض PowerPoint:
```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **إضافة عناصر نائبة إلى تخطيطات الشرائح**

توفر Aspose.Slides الطريقة [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getPlaceholderManager) التي تتيح لك إضافة عناصر نائبة جديدة إلى تخطيط شريحة.

يحتوي هذا المدير على طرق للأنواع التالية من العناصر النائبة:

| PowerPoint Placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) Method |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

يعرض الكود PHP التالي كيفية إضافة أشكال عناصر نائبة جديدة إلى تخطيط الشريحة الفارغة (Blank):
```php
$presentation = new Presentation();
try {
    // احصل على شريحة التخطيط الفارغة.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // احصل على مدير العناصر النائبة لشريحة التخطيط.
    $placeholderManager = $layout->getPlaceholderManager();

    // أضف عناصر نائبة مختلفة إلى شريحة التخطيط الفارغة.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // أضف شريحة جديدة باستخدام التخطيط الفارغ.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


النتيجة:
![العناصر النائبة على تخطيط الشريحة](add_placeholders.png)

## **تعيين ظهور التذييل لتخطيط الشريحة**

في عروض PowerPoint التقديمية، يمكن إظهار أو إخفاء عناصر التذييل مثل التاريخ ورقم الشريحة والنص المخصص اعتمادًا على تخطيط الشريحة. يتيح لك Aspose.Slides لـ PHP التحكم في ظهور هذه العناصر النائبة للتذييل. هذا مفيد عندما تريد لتخطيطات معينة عرض معلومات التذييل بينما تظل الأخرى نظيفة وبسيطة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع لتخطيط الشريحة بواسطة فهرسها.
3. تعيين عنصر التذييل في الشريحة ليكون مرئيًا.
4. تعيين عنصر رقم الشريحة ليكون مرئيًا.
5. تعيين عنصر التاريخ والوقت ليكون مرئيًا.
6. حفظ العرض التقديمي.

يعرض الكود PHP التالي كيفية تعيين ظهور تذييل الشريحة وتنفيذ المهام المرتبطة:
```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```


## **تعيين ظهور تذييل الفروع لشريحة**

في عروض PowerPoint التقديمية، يمكن التحكم في عناصر التذييل مثل التاريخ ورقم الشريحة والنص المخصص على مستوى الشريحة الرئيسة لضمان التناسق عبر جميع تخطيطات الشرائح. يتيح لك Aspose.Slides لـ PHP تعيين ظهور ومحتوى هذه العناصر النائبة للتذييل على الشريحة الرئيسة ونشر هذه الإعدادات إلى جميع تخطيطات الشرائح التابعة. يضمن هذا النهج توحيد معلومات التذييل عبر العرض التقديمي كله.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة الرئيسة بواسطة فهرسها.
3. تعيين عناصر التذييل في الشريحة الرئيسة وجميع الشرائح الفرعية لتكون مرئية.
4. تعيين عناصر رقم الشريحة في الشريحة الرئيسة وجميع الشرائح الفرعية لتكون مرئية.
5. تعيين عناصر التاريخ والوقت في الشريحة الرئيسة وجميع الشرائح الفرعية لتكون مرئية.
6. حفظ العرض التقديمي.

يعرض الكود PHP التالي هذه العملية:
```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **الأسئلة المتكررة**

**ما الفرق بين الشريحة الرئيسة (master slide) والشريحة التخطيطية (layout slide)؟**

تحدد الشريحة الرئيسة المظهر العام والتنسيق الافتراضي، بينما تحدد شرائح التخطيط ترتيبات محددة للعناصر النائبة لأنواع مختلفة من المحتوى.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم، يمكنك استنساخ شريحة تخطيط من مجموعة شرائح التخطيط في عرض تقديمي، والتي يمكن الوصول إليها عبر طريقة [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides)، وإدراجها في عرض تقديمي آخر باستخدام طريقة `addClone` .

**ماذا يحدث إذا قمت بحذف شريحة تخطيط لا تزال مستخدمة من قبل شريحة أخرى؟**

إذا حاولت حذف شريحة تخطيط لا يزال أحد الشرائح في العرض التقديمي يشير إليها، ستقوم Aspose.Slides برمي استثناء [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/). لتجنب ذلك، استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) التي تزيل بأمان فقط شرائح التخطيط غير المستخدمة.