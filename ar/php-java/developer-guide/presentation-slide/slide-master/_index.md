---
title: "إدارة ماسترات شرائح العرض التقديمي في PHP"
linktitle: "ماستر الشريحة"
type: docs
weight: 70
url: /ar/php-java/slide-master/
keywords:
- ماستر الشريحة
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- خلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة ماسترات الشرائح في Aspose.Slides للـ PHP عبر Java: الوصول، التحرير، الاستنساخ، المقارنة، وإزالة ماسترات الشرائح في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

**شريحة الماستر** تُعرّف إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن تحتوي على أشكال شائعة، شعارات، خلفيات، أنماط نص، إعدادات السمة، وإعدادات التذييل. في PowerPoint، تعديل شريحة الماستر هو الطريقة المعتادة للحفاظ على اتساق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

Aspose.Slides for PHP via Java يدعم نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة ماستر واحدة أو أكثر، ويمكن لكل شريحة ماستر أن تحتوي على عدة شرائح تخطيط. الشرائح العادية عادةً لا تشير إلى شريحة ماستر مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيط تنتمي إلى شريحة ماستر.

التسلسل الهرمي هو:

1. **شريحة الماستر** - تُعرّف التصميم المشترك والسمة.
1. **شريحة التخطيط** - تُعرّف ترتيبًا محددًا للأماكن النائبة وتنسيق المستوى التخطيطي.
1. **شريحة عادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل شريحة الماستر، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تُمثَّل شريحة الماستر بواسطة الفئة [MasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/). جميع شرائح الماستر في عرض تقديمي متاحة عبر طريقة [Presentation.getMasters](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getMasters)، التي تُعيد كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة ماستر وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/php-java/slide-layout/).
{{% /alert %}}

## **الوصول إلى شرائح الماستر**

في PowerPoint، يمكنك فتح عرض شريحة الماستر من **View** > **Slide Master**.

![أمر شريحة الماستر في علامة تبويب عرض PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم طريقة `getMasters` للوصول إلى شرائح الماستر:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

يمكنك أيضًا الحصول على شريحة الماستر المستخدمة من قبل شريحة عادية عبر تخطيطها:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **ما يحتويه شريحة الماستر**

شريحة الماستر هي كائن شبيه بالشريحة. تمتد من [BaseSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/)، لذا تكشف عن العديد من خصائص الشرائح نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. يتم سرد الأعضاء الخاصة بالماستر في صفحة API الخاصة بـ [MasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/).

الأعضاء الشائعة الاستخدام في شريحة الماستر تشمل:

| العضو | الغرض |
| --- | --- |
| `getBackground` | يحدد خلفية الشريحة على مستوى الماستر. |
| `getShapes` | يخزن الأشكال الموضوعة على الماستر، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `getLayoutSlides` | يخزن شرائح التخطيط التي تنتمي إلى الماستر. |
| `getThemeManager` | يوفر الوصول إلى واجهات برمجة تطبيقات سمة الماستر. |
| `getHeaderFooterManager` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للماستر وتخطيطاته الفرعية. |
| `getDependingSlides` | يرجع الشرائح العادية التي تعتمد على الماستر عبر تخطيطاتها. |

## **إضافة صورة إلى شريحة الماستر**

عند إضافة صورة إلى شريحة ماستر، تظهر على الشرائح التي تستخدم تخطيطات من ذلك الماستر. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وعناصر بصرية متكررة أخرى.

المثال التالي يضيف شعارًا إلى شريحة الماستر الأولى:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/php-java/picture-frame/).

## **العمل مع الأماكن النائبة**

عادةً ما تُعرّف الأماكن النائبة في شرائح التخطيط. توفر شريحة الماستر النمط المشترك والسمة التي يرثها تلك التخطيطات، بينما يحدد كل تخطيط الأماكن النائبة المتاحة وموقعها.

في PowerPoint، أوامر الأماكن النائبة متاحة في عرض شريحة الماستر.

![أمر إدراج المكان النائب في عرض شريحة الماستر في PowerPoint](slide-master_5.png)

لإضافة أماكن نائبة جديدة مع Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الماستر:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يمكنك أيضًا تنسيق أشكال الأماكن النائبة الموجودة بالفعل على شريحة ماستر. المثال التالي يجد مكان العنوان ويطبق تعبئة تدرج خطية:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![مكان عنوان منسق موروث للشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق الأماكن النائبة والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/php-java/manage-placeholder/) و[Text Formatting](/slides/ar/php-java/text-formatting/).

## **تغيير خلفية شريحة الماستر**

خلفية الماستر تُورّث إلى التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدد لون خلفية صلب للشريحة الماستر الأولى:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

للمواضيع ذات الصلة، راجع [Presentation Background](/slides/ar/php-java/presentation-background/) و[Presentation Theme](/slides/ar/php-java/presentation-theme/).

## **استنساخ شريحة الماستر إلى عرض تقديمي آخر**

استخدم `addClone` من [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/) لنسخ شريحة ماستر إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الماستر المنسوخ بواسطة التخطيطات والشرائح في العرض الهدف.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

إذا كنت بحاجة لاستنساخ الشرائح العادية مع الماستر الخاص بها، راجع [Clone Slides](/slides/ar/php-java/clone-slides/).

## **إضافة عدة شرائح ماستر**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح ماستر. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية مختلفة أو بنية صفحات أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة شرائح الماستر](slide-master_9.jpg)

المثال التالي يستنسخ الماستر الافتراضي، يعطي النسخة الخلفية مختلفة، ينشئ تخطيطًا تحت ذلك الماستر المستنسخ، ويضيف شريحة جديدة تستند إلى ذلك التخطيط:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مقارنة شرائح الماستر**

يمكن مقارنة شرائح الماستر باستخدام طريقة `equals` الموروثة من [BaseSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/). المقارنة تتحقق من الهيكل والمحتوى الثابت مثل الأشكال، النص، التنسيق، الرسوم المتحركة، وإعدادات الشريحة الأخرى. لا يتم مقارنة المعرفات الفريدة مثل معرفات الشرائح، أو قيم الأماكن النائبة الديناميكية مثل التاريخ الحالي.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/php-java/compare-slides/).

## **تعيين عرض شريحة الماستر كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في عرض شريحة الماستر:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لمزيد من إعدادات العرض، راجع [Save Presentation](/slides/ar/php-java/save-presentation/).

## **إزالة شرائح الماستر غير المستخدمة**

أحيانًا يحتوي العرض التقديمي على شرائح ماستر لم تعد مستخدمة من قبل أي شرائح عادية. إزالة الماسترات غير المستخدمة يمكن أن يقلل حجم الملف ويبسط صيانة القالب.

استخدم `removeUnused` من [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/) لإزالة الماسترات غير المستخدمة من مجموعة `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يمكنك أيضًا استخدام طريقة منخفضة الكود `removeUnusedMasterSlides` من الفئة [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة الشائعة**

**ما الفرق بين شريحة الماستر وشريحة التخطيط؟**

شريحة الماستر تُعرّف إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة ماستر وتُعرّف ترتيبًا محددًا للأماكن النائبة. الشريحة العادية تستخدم شريحة تخطيط، وبالتالي ترث من كلا من التخطيط والماستر.

**هل يمكن لعرض تقديمي واحد أن يحتوي على عدة شرائح ماستر؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح ماستر. استخدم عدة ماسترات عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة الأماكن النائبة إلى شريحة ماستر أم إلى شريحة تخطيط؟**

في معظم الحالات، أضف الأماكن النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على شريحة الماستر، ثم ضع أماكن محتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف شريحة ماستر لا تزال قيد الاستخدام؟**

لا. لا يمكن حذف شريحة ماستر لديها شرائح تابعة بأمان مباشرة. يجب أولًا نقل تلك الشرائح إلى تخطيطات تحت ماستر آخر، أو استخدام طريقة تنظيف الماسترات غير المستخدمة التي تزيل فقط الماسترات غير المستخدمة.