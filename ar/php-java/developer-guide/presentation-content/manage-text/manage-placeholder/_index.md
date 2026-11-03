---
title: إدارة العناصر النائبة في العروض التقديمية باستخدام PHP
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/php-java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص موجه
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية فحص وتعديل عناصر النائب للنص والصورة والمخطط والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

العنصر النائب هو شكل يحفظ موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. الأمثلة الشائعة هي العنونة، النص الأساسي، الصورة، المخطط، والعناصر النائبة للمحتوى ذات الاستخدام العام. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موضعه وحجمه وتنسيقه وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides تُظهر معلومات العنصر النائب عبر طريقة [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) . تُرجع الطريقة كائنًا من نوع [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) أو `null` لشكل عادي. استخدم [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) لتحديد ما يُقصد أن يحتويه العنصر النائب.

ما زال فصل الشكل مهمًا بعد معرفة نوع العنصر النائب:

- عادةً ما يُمثَّل العنصر النائب الفارغ للنص أو الصورة أو المخطط أو المحتوى بواسطة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- يمكن تمثيل عنصر نائب الصورة المعبأ بـ [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- يمكن تمثيل عنصر نائب المخطط المعبأ بـ [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- يمكن للعنصر النائب للمحتوى أن يحتوي عدة أنواع من المحتوى. تحقق من كلٍ من [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) وفصل الشكل أثناء التنفيذ بدلاً من الافتراض أن كل عنصر نائب هو [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) يصف دور العنصر النائب؛ فهو لا يضمن فصل الشكل أثناء التنفيذ. يجب دائمًا إجراء فحص للنوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تُكوّن تسلسلًا هرميًا:

1. تحدد الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، العناصر النائبة على مستوى الرئيسي.
2. تحدد شريحة التخطيط الترتيب المستخدم من قبل شريحة أو أكثر عادية ويمكنها وراثة ذلك من الشريحة الرئيسية.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكنها وراثة ذلك من تخطيطها.

استدعِ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) للانتقال مستوىً واحدًا أعلى في هذا التسلسل. عادةً ما تُعيد العنصر النائب للشريحة عنصره النائب في التخطيط؛ ويمكن لعنصر النائب في التخطيط أن يُعيد عنصره النائب في الشريحة الرئيسية. تُرجع الطريقة `null` عندما لا يمتلك الشكل عنصرًا نائبا أساسيًا.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويعرض عناصرها النائبة الأساسية:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

تحرير عنصر نائب على شريحة عادية ينشئ أو يغير تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الشريحة الرئيسية المرتبط يمكن أن يؤثر على جميع الشرائـح التي لا تزال وراثة تلك الإعدادات. الشكل العادي المحلي ليس له عنصر نائب أساسي ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **إزالة حالة العنصر النائب**

عند تعديل قالب، استخدم [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) لإبقاء كائن موجود كشكل عادي. تُرجع طريقة [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) القيمة `null`، لكن الشكل يبقى في مجموعة الشرائح. وعلى النقيض من ذلك، يقوم [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) بحذف الشكل من تلك المجموعة.

المثال التالي يتطلب `template.pptx` يحتوي على شريحة واحدة على الأقل وعنصر نائب نص غير فارغ في الشريحة الأولى. استخدم عنصرًا نائبًا مع تنسيق موروث من تخطيطه أو رئيسه لملاحظة تأثير إزالة تلك العلاقة. يتحقق المثال من بقاء نفس الشكل، ثم يستدعي الطريقة مرة أخرى على الشكل العادي الآن، ويحفظ النتيجة.

{{% alert color="warning" title="Warning" %}}
إزالة حالة العنصر النائب لا تحافظ تلقائيًا على إعدادات المظهر الموروثة. المثال أدناه يترك تلك الإعدادات دون تغيير عمدًا، لذا قد يبدو الناتج مختلفًا. الشكل الذي يتم وراثة موضعه وحجمه بالكامل قد يصبح إحداثياته وأبعادها صفرًا بعد الاستدعاء ويصبح غير مرئي رغم أنه لا يزال في المجموعة.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // استدعاء الطريقة على شكل عادي لا يؤثر.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

بالنسبة إلى عنصر نائب مطابق، جميع الفحوصات الثلاثة تطبع `true`. يبقى النص، لكن الموضع والحجم والدوران والخط ومحاذاة الفقرة وهوامش إطار النص والتثبيت العمودي وتعبئة الخط وإعدادات الخط قد تتغير عند إزالة علاقة العنصر النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق النص العادي. راجع [Slide Layout](/slides/ar/php-java/slide-layout/) للمزيد حول التخطيطات.

للحفاظ على المظهر المقصود، احفظ الموضع والحجم والدوران المحلولين قبل الاستدعاء، وانسخ قيم التنسيق الفعّال المطلوبة إلى متغيرات منفصلة. استرجع تلك القيم عبر [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), و[LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). لا تعتمد على الاحتفاظ فقط بكائنات التنسيق الفعّال، لأن قيم تنسيق النص قد تتغير بعد إزالة العلاقة. طبّق القيم المحفوظة صراحةً على الشكل العادي بعد ذلك، بما في ذلك عائلة الخط، الحجم، النمط، اللون، إعدادات الفقرة، إعدادات إطار النص، التعبئة، والخط المستخدم في القالب.

قد تحتاج هندسة الشكل الموروثة إلى تعيين صريح عبر [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). بالنسبة إلى عنصر نائب نصي مستطيل، يعني ذلك تعيين [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); قد لا يعيد استعادة التعبئة والخط فقط المستطيل المرئي. القوالب التي تحتوي على تأثيرات إضافية أو تنسيقات أكثر تعقيدًا تتطلب معالجة تلك الإعدادات كذلك.

## **تغيير النص في عنصر نائب**

عادةً ما تدعم عناصر النائب للعنوان، والعنوان المركزي، والعنوان الفرعي، والنص الأساسي، والعناصر النائبة للنص النص. تحقق من وجود [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/).

يقوم هذا المثال بتحديث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

هذا النمط يتجنب معاملة العناصر النائبة للصور أو المخططات أو الجداول أو الوسائط ككائنات [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). كما أنه يحدد العنصر النائب وفقًا للغرض بدلاً من الاعتماد على فهرس شكل ضعيف.

## **تعيين نص الموجه في التخطيط**

نص الموجه هو التعليمات المعروضة في مرحلة التصميم داخل عنصر نائب فارغ، مثل *انقر لإضافة عنوان*. عيّن نص موجه مخصص على عنصر النائب في التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال شريحة عادية. يمكن الوصول إلى التخطيط عبر [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) وتكرار المجموعة التي تُعيدها [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes).

المثال التالي يغيّر نصوص الموجه للعنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نص الموجه ليس محتوى شريحة عادي. فهو مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى حقيقي، لا يُعرض الموجه بعد ذلك. تغيير الموجه لا يستبدل أيضًا النص الموجود في الشرائح التي تستخدم التخطيط.

## **تحديث عنصر نائب الصورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر نائب الصورة مُعبأ بالفعل ومُمثَّلاً بـ [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), استبدل الصورة عبر [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) و[Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة في إحداثيات العنصر النائب باستخدام [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) ثم احذف العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض التقديمي:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الاستبدال الذي يُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) لا يوفر مُحدِّدًا. يحتفظ بالموقع المحجوز لكنه لم يعد يورّث سلوك العنصر النائب. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، فقم بإعداد وتعبئة العنصر النائب في PowerPoint أولاً، ثم حدّث [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، والقص، وغيرها من التأثيرات الخاصة بالصورة، راجع [Manage Picture Frames](/slides/ar/php-java/picture-frame/). تلك العمليات تتعلق بإطار الصورة أو تعبئة الصورة، وليس ببيانات العنصر النائب.

## **العمل مع العناصر النائبة للمخطط والمحتوى**

يمكن تمثيل عنصر نائب المخطط المعبأ بـ [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). يجد هذا المثال مثل هذا المخطط حسب نوع العنصر النائب وفصل أثناء التنفيذ، يغيّر عنوانه، ويحفظ الملف:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

عادةً ما يكون للعنصر النائب للمحتوى العام [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). في PowerPoint يعمل كمانِّـل للعديد من أنواع المحتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد أن يتم تعبئته، فحص فصل الشكل الفعلي لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تعرض [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), أو [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/).

لا يقوم Aspose.Slides بتحويل عنصر نائب فارغ من نوع [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) مجرد تغيير [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/); لا يمكن تغيير النوع عبر الفصل. لتعبئة مخطط فارغ أو منطقة محتوى برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم احذف العنصر النائب الفارغ. المثال التالي يوضح ذلك لمخطط:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر نائب التخطيط. استخدم مقالات إدارة المخططات المخصصة [chart management articles](/slides/ar/php-java/powerpoint-charts/) عندما تحتاج إلى استبدال فئاته أو سلاسله أو بيانات المصنف.

## **مثال كامل: تحديث محتوى النص أو الصورة**

المثال الشامل التالي يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، يتحقق من نوع العنصر النائب والشكل، يحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال عمدًا افتراض فهرس شكل أو معاملة كل عنصر نائب كذات الفصل.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل في التخطيط أو الشريحة الرئيسية الذي يرث منه عنصر نائب آخر. استخدم [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) لاسترجاعه. الشكل العادي المحلي يُعيد `null` لأنه ليس جزءًا من تسلسل العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص الموجه عبر التخطيط، لكن محتوى العنوان الحالي يُخزن في الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض التقديمي، كرّر عبر الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف أُدِير عناصر النائب لل تاريخ، ورقم الشريحة، والرأس، وتذييل الصفحة؟**

استخدم مديرات الرأس والتذييل في نطاق الشريحة، التخطيط، الرئيسي، الملاحظات أو النسخة المطبوعة المناسب. راجع [Manage Presentation Header and Footer](/slides/ar/php-java/presentation-header-and-footer/) للأمثلة الكاملة.