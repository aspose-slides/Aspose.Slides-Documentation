---
title: إدارة الشرائح الرئيسية للعرض التقديمي في PHP
linktitle: الشريحة الرئيسية
type: docs
weight: 70
url: /ar/php-java/slide-master/
keywords:
- الشريحة الرئيسية
- شريحة رئيسية
- شريحة رئيسية PPT
- شرائح رئيسية متعددة
- مقارنة الشرائح الرئيسية
- خلفية
- عنصر نائب
- استنساخ شريحة رئيسية
- نسخ شريحة رئيسية
- تكرار شريحة رئيسية
- شريحة رئيسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة الشرائح الرئيسية في Aspose.Slides للـ PHP عبر Java: الوصول، التحرير، الاستنساخ، المقارنة، وإزالة الشرائح الرئيسية في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

**الشريحة الرئيسية** (slide master) تُعرّف إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن تحتوي على أشكال شائعة، شعارات، خلفيات، أنماط نص، إعدادات سمة، وإعدادات تذييل. في PowerPoint، يُعد تحرير الشريحة الرئيسية هو الطريقة المعتادة للحفاظ على تناسق العرض دون تكرار نفس التنسيق على كل شريحة.

Aspose.Slides for PHP via Java يدعم نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. الشرائح العادية عادةً لا تشير مباشرةً إلى شريحة رئيسية. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتابعة لتلك الشريحة التخطيطية التي تنتمي إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **الشريحة الرئيسية** - تُعرّف التصميم والسمة المشتركة.  
1. **شريحة التخطيط** - تُعرّف ترتيبًا محددًا للعناصر النائبة وتنسيقًا على مستوى التخطيط.  
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل الشرائح الرئيسية، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تمثّل الشريحة الرئيسية الفئة [MasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/). جميع الشرائح الرئيسية في عرض تقديمي متاحة عبر طريقة [Presentation.getMasters](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getMasters)، التي تُعيد كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى هذا التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/php-java/slide-layout/).
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح عرض الشريحة الرئيسية من **عرض** > **الشريحة الرئيسية**.

![أمر الشريحة الرئيسية في علامة تبويب عرض PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم طريقة `getMasters` للوصول إلى الشرائح الرئيسية:

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

يمكنك أيضًا الحصول على الشريحة الرئيسية المستخدمة بواسطة شريحة عادية من خلال تخطيطها:

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

## **ما الذي تحتويه الشريحة الرئيسية**

الشريحة الرئيسية هي كائن شبيه بالشريحة. إنها ترث من [BaseSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/)، وبالتالي تُظهر العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. يتم سرد الأعضاء الخاصة بالشريحة الرئيسية في صفحة API لـ [MasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/).

من بين الأعضاء الشائعة المستخدمة في الشريحة الرئيسية:

| العضو | الغرض |
| --- | --- |
| `getBackground` | يحدد خلفية الشريحة على مستوى الرئيس. |
| `getShapes` | يخزن الأشكال الموضوعة على الرئيس، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `getLayoutSlides` | يخزن شرائح التخطيط التي تابعة للرئيس. |
| `getThemeManager` | يوفّر وصولاً إلى واجهات برمجة تطبيقات سمة الرئيس. |
| `getHeaderFooterManager` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للرئيس وتخطيطاته الفرعية. |
| `getDependingSlides` | يُعيد الشرائح العادية التي تعتمد على الرئيس عبر تخطيطاتها. |

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى شريحة رئيسية، تظهر على الشرائح التي تستخدم تخطيطات من ذلك الرئيس. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

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

## **التحكم في إظهار رسومات الرئيس**

استخدم [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#setShowMasterShapes) لإخفاء الرسومات الموروثة من الرئيس، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من الرئيس. مرّر `false` إلى [Slide::setShowMasterShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#setShowMasterShapes) على الشريحة التي يجب أن تُغفل هذه الرسومات واحتفظ بـ `true` على الشرائح التي يجب أن تُظهرها.

المثال التالي المستقل يُنشئ شريطًا زخرفيًا أزرق على الرئيس وشريحتين تستخدمان نفس التخطيط الفارغ. الشريط مرئي على الشريحة الأولى ومخفي على الثانية. لا يلزم أي عرض تقديمي أو صورة كمدخل.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يستخدم المثال تخطيط **Blank** المرفق مع عرض تقديمي جديد ويزيل العناصر النائبة للشفرة الأولية.

### **اختيار نطاق الإعداد**

الشريحة العادية تستخدم رئيسها عبر [Slide::getLayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getLayoutSlide) و[LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getMasterSlide). ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. تمرير `false` إلى [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#setShowMasterShapes) يخفي رسومات الرئيس للشرائح التي تستخدم ذلك التخطيط المشترك، حتى وإن كان إعدادها الخاص `true`. لإخفاء الرسومات على شريحة واحدة فقط، غير خاصية الشريحة واترك التخطيط المشترك دون تغيير.

الإعداد غير مدعوم كتحكم في الرؤية على الشريحة الرئيسية نفسها. على الرئيس، تُعيد [getShowMasterShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/#getShowMasterShapes) دائمًا `false`، وتمرير `true` إلى [setShowMasterShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/#setShowMasterShapes) يثير استثناءً. طبّقها على شريحة عادية أو على تخطيط بدلاً من ذلك.

### **تمييز الرسومات عن الخلفية**

| العملية | التأثير |
| --- | --- |
| إخفاء رسومات الرئيس | يتحكم في رؤية الأشكال الموروثة من الرئيس دون حذفها أو تعديل أشكال الشريحة الخاصة. |
| تغيير ملء خلفية الشريحة | يغيّر لون الخلفية أو التدرج أو الصورة. رسومات الرئيس هي أشكال منفصلة ويمكن أن تظل مرئية فوق الخلفية. راجع [Presentation Background](/slides/ar/php-java/presentation-background/). |
| حذف شكل من الرئيس | يزيل الشكل المصدر المشترك، وبالتالي لا يصبح متاحًا لأي شريحة تستخدم ذلك الرئيس. |

## **العمل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة على شرائح التخطيط. توفر الشريحة الرئيسية النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين تُوضع.

في PowerPoint، أوامر العنصر النائب متوفرة في عرض الشريحة الرئيسية.

![أمر إدراج عنصر نائب في عرض الشريحة الرئيسية في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة مع Aspose.Slides، اعمل على شريحة التخطيط التابعة للرئيس:

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

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على شريحة رئيسية. المثال التالي يجد العنصر النائب للعنوان ويطبق ملءً متدرجًا خطيًا:

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

![العنوان النائب المُنسق الموروث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/php-java/manage-placeholder/) و[Text Formatting](/slides/ar/php-java/text-formatting/).

## **تغيير خلفية الشريحة الرئيسية**

خلفية الرئيس تُورّث إلى التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدد لون خلفية صلبة للشريحة الرئيسية الأولى:

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

لموضوعات ذات صلة، راجع [Presentation Background](/slides/ar/php-java/presentation-background/) و[Presentation Theme](/slides/ar/php-java/presentation-theme/).

## **استنساخ شريحة رئيسية إلى عرض تقديمي آخر**

استخدم `addClone` من [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/) لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الرئيس المنسوخ في التخطيطات والشرائح في العرض الهدف.

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

إذا احتجت إلى استنساخ الشرائح العادية مع رئيسها، راجع [Clone Slides](/slides/ar/php-java/clone-slides/).

## **إضافة عدة شرائح رئيسية**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب أقسام مختلفة علامة تجارية مختلفة أو بنية صفحات أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسية](slide-master_9.jpg)

المثال التالي يستنسخ الرئيس الافتراضي، يمنح النسخة المنسوخة خلفية مختلفة، ينشئ تخطيطًا تحت ذلك الرئيس المستنسخ، ويضيف شريحة جديدة مستندة إلى ذلك التخطيط:

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

## **مقارنة الشرائح الرئيسية**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة `equals` الموروثة من [BaseSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/). تتحقق المقارنة من البنية والمحتوى الثابت، مثل الأشكال والنص والتنسيق والحركات وإعدادات الشريحة الأخرى. لا تقارن المعرفات الفريدة، مثل معرفات الشرائح، أو قيم العناصر النائبة الديناميكية، مثل التاريخ الحالي.

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

## **تعيين عرض الشريحة الرئيسية كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتح PowerPoint أولاً. المثال التالي يفتح العرض في وضع الشريحة الرئيسية:

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

## **إزالة الشرائح الرئيسية غير المستخدمة**

أحيانًا يحتوي العرض على شرائح رئيسية لم تعد تُستخدم من قبل أي شرائح عادية. إزالة الرؤساء غير المستخدمين يمكن أن يقلل من حجم الملف ويسهل صيانة القالب.

استخدم `removeUnused` من [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/) لإزالة الرؤساء غير المستخدمين من مجموعة `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يمكنك أيضًا استخدام طريقة منخفضة الشيفرة `removeUnusedMasterSlides` من فئة [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

الشريحة الرئيسية تُعرّف إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة رئيسية وتُعرّف ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة تخطيط، لذا فإنها ترث من كلٍ من التخطيط والرئيس.

**هل يمكن أن يحتوي عرض تقديمي على عدة شرائح رئيسية؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. استخدم رؤساء متعددين عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى شريحة رئيسية أم شريحة تخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على الشريحة الرئيسية، ثم ضع عناصر النائب للمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف شريحة رئيسية لا زالت مستخدمة؟**

لا. لا يمكن حذف شريحة رئيسية لها شرائح معتمدة بأمان مباشرةً. انقل تلك الشرائح إلى تخطيطات تحت رئيس آخر، أو استخدم طريقة تنظيف الرؤساء غير المستخدمة التي تحذف فقط الرؤساء غير المستعملة.