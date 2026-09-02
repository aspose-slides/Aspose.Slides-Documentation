---
title: إدارة أماكن العنصر النائب في العرض التقديمي باستخدام PHP
linktitle: إدارة الأماكن النائبة
type: docs
weight: 10
url: /ar/php-java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نص
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص إرشادي
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية فحص وتحرير أماكن النص، الصورة، المخطط، والمحتوى وفهم وراثة الأماكن النائبة باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

المكان المخصص هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. أمثلة شائعة هي العنوان، النص الأساسي، الصورة، المخطط، ومواقع محتوى عامة. على عكس الشكل العادي، يمكن للمكان المخصص أن يرث موقعه، حجمه، تنسيقه، وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides تُظهر معلومات المكان المخصص من خلال طريقة [Shape::getPlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getplaceholder/) . تُرجع الطريقة كائنًا من نوع [Placeholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholder/) أو `null` للشكل العادي. استخدم [Placeholder::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholder/gettype/) لتحديد ما يُقصد أن يحتويه المكان المخصص.

فئة الشكل لا تزال مهمة بعد معرفة نوع المكان المخصص:

- عادةً ما يُمثَّل مكان مخصص فارغ للنص أو الصورة أو المخطط أو المحتوى بواسطة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/).
- يمكن تمثيل مكان مخصص للصورة المملوء بواسطة [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/).
- يمكن تمثيل مكان مخصص للمخطط المملوء بواسطة [Chart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/).
- يمكن لمكان مخصص للمحتوى أن يحتوي على عدة أنواع من المحتوى. تحقق من كلٍ من [Placeholder::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholder/gettype/) وفئة الشكل وقت التشغيل بدلاً من افتراض أن كل مكان مخصص هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholder/gettype/) يصف دور المكان المخصص؛ لكنه لا يضمن فئة الشكل وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى الأعضاء الخاصة بالنص أو الصورة أو المخطط أو الجدول أو الوسائط.
{{% /alert %}}

## **فهم وراثة الأماكن المخصصة**

تشكّل الأماكن المخصصة تسلسلاً هرميًا:

1. تحدد الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، الأماكن المخصصة على مستوى الرئيسي.
2. تحدد شريحة التخطيط الترتيب المستخدم بواسطة شريحة أو أكثر عادية ويمكنها أن ترث من الرئيسي.
3. تحتوي الشريحة العادية على الأماكن المخصصة لتلك الشريحة ويمكنها أن ترث من تخطيطها.

استدعِ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getbaseplaceholder/) للانتقال مستوى واحد أعلى في هذا التسلسل. عادةً ما تُعيد شريحة المكان المخصص مكان التخطيط الخاص بها؛ يمكن لمكان التخطيط أن يُعيد مكان الرئيسي. تُرجع الطريقة `null` عندما لا يكون للشكل مكان أساسي.

القائمة التالية تُظهر الأماكن المخصصة في الشريحة الأولى وتُبلغ عن أماكنها الأساسية:

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

تعديل مكان مخصص في شريحة عادية يخلق أو يغيّر تجاوزًا محليًا لتلك الشريحة. تعديل التخطيط أو الرئيسي المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث ذلك الإعداد. الشكل العادي المحلي ليس له مكان أساسي ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في مكان مخصص**

عادةً ما تدعم أماكن العنوان، العنوان‑المتمركز، العنوان الفرعي، النص الأساسي، والنصوص النصية النص. تحقق من وجود [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/gettextframe/).

يقوم هذا المثال بتحديث أول مكان مخصص للعنوان في الشريحة الأولى ويُحفظ النتيجة:

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

هذا النمط يتجنب معالجة أماكن الصورة، المخطط، الجدول، أو الوسائط على أنها كائنات [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/). كما يحدد المكان المخصص حسب الغرض بدلاً من الاعتماد على فهرس الشكل الهش.

## **تعيين نص إرشادي على التخطيط**

نص الإرشاد هو التعليمات التي تُظهر عند التصميم في مكان مخصص فارغ، مثل *انقر لإضافة عنوان*. عيّن نصًا إرشاديًا مخصصًا على مكان المخصص في التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة الأشكال في الشريحة العادية. احصل على التخطيط عبر [Slide::getLayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getLayoutSlide) وتكرَّر عبر المجموعة التي تُعيدها [BaseSlide::getShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#getShapes).

المثال التالي يغيّر نصوص الإرشاد للعنوان والعنوان الفرعي في التخطيط المُستخدم من قبل الشريحة الأولى:

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

نص الإرشاد ليس محتوى شريحة عادية. يُقصد به الأماكن المخصصة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوىً حقيقيًا، لا يُظهر الإرشاد بعد ذلك. تغيير الإرشاد لا يستبدل النص الموجود على الشرائح التي تستخدم التخطيط أيضًا.

## **تحديث مكان مخصص للصورة**

هناك حالتان يجب التعامل معهما:

- إذا كان مكان المخصص للصورة مُملوءًا بالفعل ومُمثلًا بـ [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/)، استبدل الصورة عبر [PictureFillFormat::getPicture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/getpicture/) و[SlidesPicture::setImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidespicture/setimage/).
- إذا كان لا يزال مكانًا مخصصًا فارغًا، أضف إطار صورة في إحداثيات المكان المخصص باستخدام [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addpictureframe/) واحذف المكان المخصص الفارغ.

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

البديل المُنشأ لمكان مخصص فارغ هو إطار صورة محلي، ليس مكانًا مخصصًا جديدًا، لأن [Shape::getPlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getplaceholder/) لا يوفر مُحددًا. يحتفظ بالموقع المحجوز لكن لا يرث سلوك المكان المخصص بعد الآن. إذا كان الحفاظ على علاقة المكان المخصص أمرًا أساسيًا، فاحضر واملأ المكان المخصص في PowerPoint أولاً، ثم حدّث [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، الاقتصاص، وتأثيرات الصورة الأخرى، انظر [Manage Picture Frames](/slides/ar/php-java/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة، لا إلى بيانات تعريف المكان المخصص.

## **العمل مع أماكن مخصصة للمخططات والمحتوى**

يمكن تمثيل مكان مخصص للمخطط المملوء بـ [Chart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/). هذا المثال يجد مثل هذا المخطط من خلال نوع المكان المخصص وفئة الشكل وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

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

عادةً ما يكون للمكان المخصص العام للمحتوى القيمة [PlaceholderType::Object](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholdertype/). في PowerPoint يعمل كقائمة تشغيل لعدة أنواع من المحتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد ملئه، افحص فئة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType::Chart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholdertype/)، [PlaceholderType::Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholdertype/), أو [PlaceholderType::Diagram](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholdertype/).

Aspose.Slides لا تُحوِّل مكانًا مخصصًا فارغًا من نوع [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى [Chart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/) بمجرد تغيير [Placeholder::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/placeholder/gettype/); لا يمكن تغيير النوع عبر الفئة. لملء مخطط أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب في إحداثيات المكان المخصص ثم احذف المكان المخصص الفارغ. المثال التالي يفعل ذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة المكان المخصص لكنه لا يرث من مكان التخطيط. استخدم مقالات إدارة المخططات المتخصصة [/slides/ar/php-java/powerpoint-charts/] عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث نص أو محتوى صورة**

المثال التالي من الطرف إلى الطرف يفتح قالبًا، يبحث في الشريحة الأولى عن مكان مخصص للعنوان أو الصورة، يتحقق من نوعي المكان المخصص والشكل، يحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال افتراض فهرس شكل أو معالجة كل مكان مخصص كفئة واحدة:

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

## **الأسئلة المتداولة**

**ما هو المكان المخصص الأساسي؟**

المكان المخصص الأساسي هو الشكل المقابل على التخطيط أو الرئيسي الذي يرث منه مكان مخصص آخر. استخدم [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getbaseplaceholder/) لاسترداده. الشكل المحلي العادي يُعيد `null` لأنه ليس جزءًا من تسلسل الأماكن المخصصة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تعديل مكان مخصص في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص الإرشاد من خلال التخطيط، لكن محتوى العنوان الموجود يُحفظ على الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض بأكمله، ينبغي iterate (التكرار) على الشرائح وتحديث كل مكان مخصص للعنوان.

**كيف أدير أماكن المخصصة للتاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم أدوات إدارة الرأس والتذييل في النطاق المناسب—الشريحة، التخطيط، الرئيسي، الملاحظات، أو الملخص. راجع [Manage Presentation Header and Footer](/slides/ar/php-java/presentation-header-and-footer/) للحصول على أمثلة كاملة.