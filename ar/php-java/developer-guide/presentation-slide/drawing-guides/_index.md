---
title: إدارة أدلة الرسم في العروض التقديمية بلغة PHP
linktitle: أدلة الرسم
type: docs
weight: 85
url: /ar/php-java/drawing-guides/
keywords:
- دليل رسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض الشريحة
- شريحة القالب
- شريحة التخطيط
- قالب الملاحظات
- قالب النسخة المطبوعة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إضافة، الوصول إلى، ومسح أدلة الرسم الأفقية والعمودية في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

دليل الرسم عبارة عن خطوط أفقية وعمودية قابلة للتعديل تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تحرير عرض تقديمي في PowerPoint. تكون مفيدة بشكل خاص عندما يولد تطبيق عرضاً تقديمياً سيتم تحسينه يدوياً لاحقاً: يمكن للتطبيق حفظ نفس أدوات المحاذاة التي يجب على المؤلفين اتباعها عند إضافة أو تحريك المحتوى.

دليل الرسم هو أداة تحرير، وليس محتوىً لشريحة. لا يظهر في عرض الشرائح أو في المخرجات المعروضة. Aspose.Slides for PHP via Java تعرضها عبر الفئة [DrawingGuidesCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguidescollection/). تمثل الدليل بواسطة الفئة [DrawingGuide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguide/) ويحتوي على اتجاه وموقع ولون.

الموقع يُقاس بالنقاط من الزاوية العلوية اليسرى للشفرة أو القالب ذات الصلة. الدليل العمودي يستخدم إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. الدليل الأفقي يستخدم إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة أدلة إلى عرض الشريحة**

استخدم الطريقة [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) لإدارة الأدلة المعروضة أثناء تحرير الشرائح العادية. استدعِ الطريقة [DrawingGuidesCollection::add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguidescollection/#add) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/orientation/) وموقع بالنقاط.

المثال التالي يضيف دليلًا عموديًا واحدًا إلى يمين مركز الشريحة ودليلًا أفقيًا واحدًا أسفله:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الوصول إلى أدلة الرسم**

توفر الطريقتان [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguidescollection/#getCount) و[DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguidescollection/#get_Item) إمكانية الوصول إلى الأدلة الموجودة. تعيد الطُرق [DrawingGuide::getOrientation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguide/#getOrientation)، [DrawingGuide::getPosition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguide/#getPosition) و[DrawingGuide::getColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguide/#getColor) قيمًا يمكن أيضًا تعديلها عبر طرق setter المقابلة.

المثال التالي يقرأ أدلة عرض الشريحة من العرض التقديمي الذي تم إنشاؤه أعلاه:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **إضافة أدلة إلى القوالب والشرائح التخطيطية**

يمكن لقالب الشريحة وكل من شرائحه التخطيطية أن يحتوي على مجموعات أدلة رسم خاصة به. استخدم الطريقة [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/#getDrawingGuides) للقالب و[LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getDrawingGuides) للشرائح التخطيطية.

المثال التالي يضيف دليلًا عموديًا إلى القالب الأول ودليلًا أفقيًا إلى الشريحة التخطيطية الأولى:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إضافة أدلة إلى ملاحظات القالب ونسخ المناشير**

تدعم ملاحظات القالب ونسخ المناشير أيضًا أدلة الرسم. استخدم الطريقة [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslide/#getDrawingGuides) والطريقة [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) للوصول إلى مجموعاتهما. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، احصل على المدير المناسب عبر الطريقة [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) أو [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager)، ثم أنشئ القالب الافتراضي باستخدام `setDefaultMasterNotesSlide` أو `setDefaultMasterHandoutSlide`.

المثال التالي يضيف دليلًا أفقيًا إلى قالب الملاحظات ودليلًا عموديًا إلى قالب النسخة المطبوعة:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مسح أدلة الرسم**

استدعِ الطريقة [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguidescollection/#clear) لإزالة كل دليل من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الأدلة المخزنة في نطاق آخر.

المثال التالي يمسح أدلة عرض الشريحة وكل الأدلة على قوالب الشرائح، الشرائح التخطيطية، قالب الملاحظات، وقالب النسخة المطبوعة دون إنشاء قوالب مفقودة:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل تظهر أدلة الرسم في عرض الشرائح أو الصور المصدَّرة؟**

لا. أدلة الرسم هي أدوات محاذاة للتحرير ولا تُعرض كجزء من محتوى العرض التقديمي.

**هل يمكن إضافة دليل رسم مباشرةً إلى شريحة عادية فردية؟**

تُخزن أدلة تحرير الشرائح العادية في خصائص عرض الشريحة للعرض التقديمي. تتوفر مجموعات أدلة منفصلة لقوالب الشرائح، الشرائح التخطيطية، قوالب الملاحظات، وقوالب النسخة المطبوعة.

**ما الوحدات المستخدمة لمواقع الأدلة؟**

يتم تحديد المواقع بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. تُقاس المواقع العمودية من الحافة اليسرى، وتُقاس المواقع الأفقية من الحافة العليا.

**هل يزيل مسح أدلة الرسم الأشكال أو يغيّر محتوى الشريحة؟**

لا. الطريقة [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/drawingguidescollection/#clear) تُزيل الأدلة فقط في المجموعة المحددة. تبقى الأشكال ومحتوى الشريحة الآخر دون تغيير.