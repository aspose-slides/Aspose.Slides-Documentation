---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة في PHP
linktitle: الرسوم المتحركة المخصصة
type: docs
weight: 151
url: /ar/php-java/custom-animation/
keywords:
- رسوم متحركة مخصصة
- سلوك الرسوم المتحركة
- مسار حركة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وفحص وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

تتيح لك سلوكيات الرسوم المتحركة المخصصة التحكم في عمليات فردية داخل تأثير الرسوم المتحركة، مثل تغيير اللون، تدوير الشكل، أو اتباع مسار حركة قابل للتحرير. يوضح هذا الدليل كيفية إنشاء السلوكيات ودمجها، ضبط توقيتها، فحص وتعديل الرسوم المتحركة الموجودة، والتحقق من بقاء خصائصها محفوظةً بعد حفظ وإعادة فتح العرض التقديمي.

للتعرف على التأثيرات المحددة مسبقًا ومشغلات النقر، راجع [رسوم متحركة الشكل](/slides/ar/php-java/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

تُنظم الرسوم المتحركة على النحو التالي **Timeline → Sequence → Effect → Behaviors**:

- كل شريحة تحتوي على جدول زمني يضم السلسلة الرئيسة والسلاسل التفاعلية.
- تحتوي [Sequence](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/) على تأثيرات، قد تستهدف أشكالًا مختلفة.
- يحدد [Effect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/) الشكل الهدف، النموذج المسبق، النوع الفرعي، وتوقيت التأثير.
- المجموعة التي تُرجعها [Effect::getBehaviors](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getbehaviors/) تحتوي على العمليات التي تُنفّذ التأثير: تغيير اللون، النقل، الدوران، ضبط خاصية، وما إلى ذلك.

## **إنشاء السلوكيات الفردية**

استدعِ [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) لإنشاء تأثير والوصول إلى مجموعة [getBehaviors](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getbehaviors/). يمكن أن يملأ نموذج مسبق هذه المجموعة تلقائيًا. احتفظ بعملياته عند توسيع النموذج المسبق، أو استخدم [clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorcollection/clear/) عند استبدالها عمدًا.

[BehaviorFactory](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/) تُنشئ الأنواع الثمانية للسلوكيات الموضحة أدناه. يُغطى الحركة في [إنشاء مسار حركة](#build-a-motion-path). كل مقطع يتضمن استيراداته ويفترض أنه تم تحميل جسر PHP/Java ومكتبة Aspose.Slides PHP. تُوضح أمثُل التحرير اللاحقة ملف الإخراج الذي تُستخدمه.

### **دوران**

استخدم [createRotationEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createrotationeffect/) لإنشاء دوران. تحدد [getBy](https://reference.aspose.com/slides/ar/php-java/aspose.slides/rotationeffect/getby/) زاوية نسبية بالدرجات؛ تحدد [getFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/rotationeffect/getfrom/) و[getTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/rotationeffect/getto/) نقاط النهاية.

يبدأ المثال بتأثير Spin، يستبدل عمليات النموذج المسبق بسلوك دوران واحد، ويعطي تلك العملية مدة ثانيتين. زاوية نسبية قدرها 90 درجة تمثّل ربع دورة من توجيه الشكل الابتدائي، لذا لا تحتاج إلى زاوية ابتدائية صريحة.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` يحتوي على شكل واحد وسلوك دوران واحد. تُستخدم المجموعة، التوقيت، وأمثلة تعديل الدوران أدناه هذا الملف.

### **تحجيم**

استخدم [createScaleEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createscaleeffect/) مع نسب X/Y: تصف [getFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/scaleeffect/getfrom/) و[getTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/scaleeffect/getto/) الحجم الابتدائي والنهائي، بينما تصف [getBy](https://reference.aspose.com/slides/ar/php-java/aspose.slides/scaleeffect/getby/) تغييرًا نسبيًا. هنا، 100 يعني الحجم الأصلي.

ينمو المثال البعدين من 100 % إلى 125 % على مدى ثانيتين. الحفاظ على نسب أفقية ورأسية متساوية يحافظ على نسب الشكل؛ نسب مختلفة ستمدد أحد البعدين أكثر من الآخر.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **لون**

استخدم [createColorEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createcoloreffect/) لتغيير التعبئة من الأزرق إلى البرتقالي. [getFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/coloreffect/getfrom/) و[getTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/coloreffect/getto/) هما ألوان؛ [getBy](https://reference.aspose.com/slides/ar/php-java/aspose.slides/coloreffect/getby/) هو إزاحة لون. تحدد [BehaviorPropertyCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorpropertycollection/) الخاصية التي يتم تحريكها.

تُهيّأ تعبئة الشكل الصلبة إلى اللون الأزرق لتتطابق مع اللون الابتدائي للرسوم المتحركة. اختيار خاصية تعبئة اللون يخبر السلوك أي جزء من الشكل يُغيّر؛ نقاط النهاية اللونية وحدها لا تحدد تلك الخاصية. يصف التأثير المحفوظ انتقالًا لمدة ثانيتين إلى البرتقالي.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **فلتر**

استخدم [createFilterEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createfiltereffect/) لتحديد مسح. تحدد [getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filtereffect/gettype/)، [getSubtype](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filtereffect/getsubtype/)، و[getReveal](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filtereffect/getreveal/) الفلتر، الاتجاه، وما إذا كان يُظهر أو يُخفي الشكل.

يضبط هذا المثال مسحًا لمدة ثانيتين يُظهر الشكل باستخدام نوع الاتجاه من اليمين. إعدادات الفلتر تتبع السلوك داخل التأثير، لذلك تُضبط بعد إزالة عمليات النموذج المسبق الأصلية.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **خاصية**

استخدم [createPropertyEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) لتحريك الشفافية. [getFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/propertyeffect/getfrom/)، [getTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/propertyeffect/getto/)، و[getBy](https://reference.aspose.com/slides/ar/php-java/aspose.slides/propertyeffect/getby/) هي سلاسل تُفسَّر باستخدام [getValueType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/propertyeffect/getvaluetype/) و[getCalcMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/propertyeffect/getcalcmode/). اختر نقاط النهاية أو إزاحة نسبية بدلاً من ضبط الثلاثة معًا بلا تمييز.

في هذا المثال، الخاصية المختارة هي الشفافية، وتمثل السلاسل الرقمية تغييرًا من شفافية 25 % إلى شفافية كاملة. يصف الاستيفاء الخطي تغييرًا تدريجيًا بين تلك القيم. عند تعديل هذا المثال لخاصية أخرى، اختر نوع قيمة وقيم نهائية مناسبة لتلك الخاصية.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تعيين**

استخدم [createSetEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createseteffect/) لتعيين الظهور عبر [getTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/seteffect/getto/). لا يُجري سلوك التعيين استيفاءً بين نقطتي النهاية.

يختار المثال خاصية الظهور ويُعيّن السلسلة `visible` عند تشغيل السلوك. المستطيل مرئي بالفعل في هذا العرض التقديمي الحد الأدنى، لذا قد لا ينتج عن التعيين تغيير بصري واضح بمفرده. تكون مثل هذه العملية مفيدة كجزء من تأثير أكبر يتحكم أيضًا بوقت إخفاء أو إظهار الشكل.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **أمر**

استخدم [createCommandEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createcommandeffect/) واضبط [getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/commandeffect/gettype/)، [getCommandString](https://reference.aspose.com/slides/ar/php-java/aspose.slides/commandeffect/getcommandstring/)، و[getShapeTarget](https://reference.aspose.com/slides/ar/php-java/aspose.slides/commandeffect/getshapetarget/). ضع تسجيل WAV باسم `sample.wav` في دليل العمل. يدمج هذا المثال التسجيل باستخدام [addAudioFrameEmbedded](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addaudioframeembedded/) ويُرفق أمر تشغيل لإطار الصوت.

إطار الصوت هو هدف التأثير والهدف من الأمر معًا. يربط ذلك طلب التشغيل بالتسجيل المدمج؛ لا يحدد سلسلة الأمر نفسها أي كائن وسائط يجب التحكم فيه. يُضبط التأثير للبدء بنقر أثناء العرض التقديمي.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

يُحفظ الأمر في `command.pptx`؛ ولا يُشغل التسجيل. يتطلب تشغيله مشغل عرض شرائح يدعم الأمر وهدف الوسائط الخاص به.

## **إدارة مجموعة السلوكيات**

[BehaviorCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorcollection/) تدعم [add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorcollection/add/)، [insert](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorcollection/insert/)، [remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorcollection/remove/)، و[removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorcollection/removeat/). يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، يضعه قبل الدوران، ويزيل الدوران. إزالة وإعادة إدراج نفس الكائن يغيّر موقعه المخزن دون إنشاء نسخة.

تغيّر سلسلة التعديلات المجموعة من دوران–تحجيم إلى تحجيم–دوران، ثم إلى تحجيم فقط. تُشير الفهارس إلى المجموعة الحالية، لذا يستخدم الإزالة الفهرس الجديد للدوران بعد إعادة الترتيب. يُؤكّد التعداد النهائي أي سلوك سيُحفظ.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الإخراج هو `ScaleEffect`: يبقى التحجيم فقط. ترتيب المجموعة بحد ذاته لا يحدد جدولة السلوكيات واحدةً تلو الأخرى. امسح المجموعة فقط عندما تستبدل جميع عملياتها.

## **ضبط توقيت السلوك**

للسلوك توقيته الخاص عبر [Timing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/)، مستقل عن التوقيت الذي تُرجعه [Effect::getTiming](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/gettiming/). يحدد توقيت التأثير الجدولة العامة للتأثير؛ يصف توقيت السلوك عملية داخلية.

### **تعيين المدة، التأخير، التكرار، والتسارع**

افتح `rotation.pptx` واضبط المدة عبر [getDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getduration/) وتأخير المشغّل عبر [getTriggerDelayTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/gettriggerdelaytime/) بالثواني، ثم اضبط عدد التكرارات عبر [setRepeatCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getaccelerate/) و[getDecelerate](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getdecelerate/) هما كسور من المدة؛ حافظ على مجموعهما لا يتجاوز 1.

ملف الإدخال هو ذلك الذي تم إنشاؤه في مثال الدوران، حيث يُعرف أن السلوك الأول هو دوران. يغيّر هذا المثال توقيت ذلك السلوك فقط؛ يبقى زاوية الـ 90 درجة دون تغيير. إبقاء الزاوية والتوقيت منفصلين يجعل تعديل السرعة أسهل دون الحاجة لإعادة بناء الرسوم المتحركة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يستخدم السلوك مدة ثانيتين، تأخير نصف ثانية، وعدد تكرار 3. تُستخدم أول وآخر 20 % من مدته للتسارع والتباطؤ.

تشمل سياسات التكرار الأخرى [getRepeatDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatduration/)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatuntilendslide/)، و[getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatuntilnextclick/); اختر سياسةً بدلاً من تمكينها جميعًا معًا. [getAutoReverse](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getautoreverse/) يُعيد تشغيل الرسوم المتحركة بالعكس بعد المرور الأمامي. ينطبق التسارع والتباطؤ على التغييرات المستمرة، وليس على التعيينات المتقطعة أو الأوامر.

## **إنشاء مسار حركة**

استخدم [createMotionEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorfactory/createmotioneffect/) لإنشاء حركة. تصف [getFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioneffect/getfrom/)، [getTo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioneffect/getto/)، و[getBy](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioneffect/getby/) إحداثيات أو إزاحات بنسب مئوية. لإنشاء مسار قابل للتحرير، أنشئ [MotionPath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motionpath/) وعيّنها عبر [MotionEffect::setPath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioneffect/setpath/). تُخزّن [MotionPath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motionpath/) أوامر المسار.

[MotionCommandPathType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioncommandpathtype/) يحدد العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MoveTo | واحدة | ضبط موضع البداية. |
| LineTo | واحدة | التحرك على مقطع مستقيم إلى نقطة النهاية. |
| CurveTo | ثلاث | اتباع منحنى مكعب يُحدِّده نقطتا تحكم ونقطة النهاية. |
| CloseLoop | لا شيء | العودة إلى موضع البداية. |
| End | لا شيء | إنهاء المسار. |

[MotionPathPointsType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motionpathpointstype/) يصف خصائص تحرير النقاط، مثل النقاط الزاوية أو السلسة. لا يستبدل نوع الأمر. استخدم نوع نقطة المنحنى لمثال المنحنى أدناه، ونوع نقطة الزاوية للمقاطع المستقيمة.

إحداثيات المسار تُطبع إلى أبعاد الشريحة: إزاحة X بقيمة 0.25 تمثل ربع عرض الشريحة، وليس 0.25 نقطة. Y الموجبة تتجه إلى الأسفل. الأوامر المطلقة تُحدِّد المواقع في نظام إحداثيات المسار؛ الأوامر النسبية تُحدِّد إزاحات من الموضع الحالي. هذا منفصل عن [getOrigin](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioneffect/getorigin/)، الذي يختار إطار مرجعي للمسار، و[getPathEditMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioneffect/getpatheditmode/)، الذي يتحكم في طريقة تحرك المسار عند نقل الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بداية، مقطع مستقيم واحد، وأمر إنتهاء. يأخذ [MotionPath::add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motionpath/add/) نوع الأمر، نقاطه، نوع النقطة، وعلم إحداثيات نسبية.

يُنشئ أمر البداية (0, 0)، وينتهي الخط عند (0.25, 0)، مما يوفّر إزاحة أفقية بنسبة ربع عرض الشريحة. لا يحتوي أمر النهاية على نقاط إحداثية. بمجرد تعيين المسار، يربط إضافة سلوك الحركة إلى التأثير ذلك المسار بالمستطيل.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` يحتوي على سلوك حركة واحد بثلاثة أوامر مسار. تُستخدم أمثُل تحرير الملفات التالية هذا الهيكل المعروف.

### **مقارنة الإحداثيات المطلقة والنسبية**

هاتان كائنتا المسار تصفان نفس المسار. الأمر المطلق ينتهي عند (0.3, 0.1)؛ الأمر النسبي يضيف (0.1, 0.1) إلى الموضع الحالي، (0.2, 0).

كلا المسارين يبدأان من نفس الموضع. بالنسبة للخط النسبي، أضف إزاحتي X وY إلى الموضع الحالي للحصول على نقطة النهاية؛ بالنسبة للخط المطلق، اقرأ نقطة النهاية مباشرة. تغيير العلم دون تحويل الإحداثيات سيُنتج مسارًا مختلفًا.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

عيّن أيٍ من المسارين إلى سلوك حركة لاستخدامه في عرض تقديمي. تُحدد الوسيطة البوليانية الأخيرة الإحداثيات النسبية لذلك الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى مكعب. قدّم نقطتي التحكم أولًا، ثم نقطة النهاية.

الموضع الابتدائي يُوفره الأمر السابق. تشكّل النقطتان الأوليان المنحنى، بينما تكون الثالثة هي وجهته؛ ليست ثلاث نقاط وجهة متتابعة. تحديث نوع الأمر، نوع تحرير النقاط، ومصفوفة النقاط معًا يحافظ على التناسق بين القطعة والهندسة الجديدة.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المسار في `curve.pptx` لا يزال يحتوي على ثلاث أوامر؛ أمره الأوسط يُعرّف الآن منحنى.

## **فحص وتحرير مسار محفوظ**

كل [MotionCmdPath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioncmdpath/) يُظهر [getPoints](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioncmdpath/getpoints/)، [getCommandType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioncmdpath/getcommandtype/)، [getPointsType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioncmdpath/getpointstype/)، و[isRelative](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motioncmdpath/isrelative/). تستخدم الأمثلة التالية المسار المكوَّن من ثلاثة أوامر في `motion.pptx`. بالنسبة للمدخلات العشوائية، حدد التأثير المقصود وتحقق من أنواع الأوامر وعدد النقاط قبل التحرير وفق الفهرس.

### **قراءة الأوامر والإحداثيات**

قِرَأ المسار دون تغييره. أوامر النهاية وإغلاق الحلقة لا تحتاج إلى نقاط، لذا يُسمح بمصفوفة نقاط فارغة.

تُظهر المخرجات كل نوع أمر رقمي مع علم الإحداثيات النسبية قبل سرد نقاطه. يتيح لك ذلك التمييز بين نقطة النهاية والإزاحة قبل تعديل المسار. سيُسرد المنحنى ثلاث نقاط، بينما يُظهر الخط المستقيم في هذا الملف نقطة واحدة فقط.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

القائمة تحتوي على نقطة بداية، خط مطلق ينتهي عند (0.25, 0)، وأمر إنتهاء.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في ملف الإدخال، الفهرس 0 هو أمر البداية والفهرس 1 هو الخط. استبدال النقطة الوحيدة للخط يغيّر وجهته دون تغيير نوع الأمر أو توقيته أو موضعه في المجموعة. لأن الأمر يستخدم إحداثيات مطلقة، يُحدِّد الزوج الجديد موقعًا وليس إزاحة مضافة.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ينتهي الخط في `motion-endpoint.pptx` عند (0.4, 0.1)؛ الملف الأصلي يبقى دون تغيير.

### **استبدال مقطع**

استخدم [insert](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motionpath/insert/) و[removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/motionpath/removeat/) لاستبدال الخط في `motion.pptx`. يؤدي الإدراج إلى إزاحة الخط القديم إلى الفهرس 2.

يوضح هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على أمر البداية، الخط الجديد، الخط القديم، وأمر النهاية. إزالة الفهرس 2 تُزيل الخط القديم وتبقي على المسار الجديد في مكانه.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المسار المحفوظ لا يزال يحتوي على ثلاثة أوامر، مع خط جديد ينتهي عند (0.2, 0.1) وأمر النهاية أخيره.

## **تعديل والتحقق من سلوك موجود**

عند عدم معرفة فهرس السلوك، حدده بالنوع. يفتح هذا المثال `rotation.pptx`، يجد [RotationEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/rotationeffect/)، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

تسمح فحوصات النوع بتجاوز السلوكيات التي ليست دوارات. القراءة الثانية تُحمِّل الملف المحفوظ في كائن عرض تقديمي منفصل، لذا تتحقق المقارنة من البيانات المستمرة وليس من القيمة التي لا تزال في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في السلسلة الرئيسة؛ اختيار سلوك بالنوع لا يضمن العثور على التأثير الصحيح في عرض تقديمي عشوائي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

الإخراج هو `Rotation preserved: true`. استخدم نمط فحص النوع نفسه مع سلوكيات أخرى. للتحقق الشامل من الحفظ، قارن الشكل الهدف، التأثير، أنواع السلوك وترتيبه، التوقيت، وأوامر المسار. استخدم tolerance عددية للقيم العشرية. لعرض تقديمي بترتيب رسوم متحركة غير معروف، طالع [قراءة رسوم متحركة الشكل](/slides/ar/php-java/shape-animation/#read-shape-animations) لتجوال السلاسل الرئيسة والتفاعلية.

## **ترتيب السلوكيات، النماذج المسبقة، والتشغيل**

ترتيب [BehaviorCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behaviorcollection/) هو الترتيب المخزن لعمليات التأثير. ليس قائمة تشغيل ينتظر فيها كل سلوك تلقائيًا السلوك السابق. يحدِّد التوقيت والتأثير المحيط الجدولة. يمكن أن تتداخل السلوكيات، وقد تتفاعل العمليات على نفس الخاصية عبر إعدادات [additive](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behavioradditivetype/) و[accumulation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/behavioraccumulatetype/). لا تستخدم إعادة ترتيب المجموعة وحدها لجدولة "نقل ثم دوران"؛ استخدم توقيتًا صريحًا أو تأثيرات منفصلة كما هو موضح في [رسوم متحركة الشكل](/slides/ar/php-java/shape-animation/).

يصف [getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/gettype/) و[getSubtype](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getsubtype/) للتأثير نمطه المسبق. لا يشكلان وصفًا كاملاً لشجرة سلوكيات مُعدَّلة. اختر النموذج المسبق والنوع الفرعي قبل تخصيص السلوكيات: قد يؤدي تغيير النموذج المسبق إلى إعادة بناء المجموعة وإزالة عملياتك المخصَّصة. على سبيل المثال، قد يستبدل تعديل تأثير Spin المخصَّص إلى Fade سلوك الدوران بسلوكيات تعيين وفلتر. افحص المجموعة مرة أخرى بعد تغيير نموذج مسبق أو نوع فرعي. مسح سلوكيات النموذج المسبق قد يزيل أيضًا عمليات الرؤية أو التهيئة التي يحتاجها النموذج. تستخدم الأمثلة بشكل متعمد أشكالًا مرئية وتستبدل السلوكيات؛ لا تعيد بناء تنفيذ كل نموذج مسبق.

## **توافق الصيغ**

شجرة سلوكيات محفوظة لا تضمن تشغيلًا متطابقًا في كل عارض أو مُحوِّل تصدير. اختبر البيانات المحفوظة والناتج المرسوم بشكل منفصل.

| الصيغة أو الإخراج | ما يجب التحقق منه |
| --- | --- |
| PPTX | استخدمها كالصيغة الأساسية لهذه الأمثلة. أعد فتحها للتحقق من شجرة السلوكيات القابلة للتحرير، ثم اختبر التشغيل في نسخة PowerPoint المقصودة. |
| PPT | قد تختلف التمثيل الثنائي القديم عن PPTX. اختبر دورة حفظ‑إعادة فتح منفصلة والتشغيل؛ لا تستنتج دعم كل تركيبة مخصَّصة من نجاح إخراج PPTX. |
| PDF, PNG, JPEG، وغيرها من صور الشرائح الثابتة | تحتوي على تمثيل شريحة ثابتة، لا جدول زمني قابل للتشغيل أو إطار نهائي مضمون للرسوم المتحركة. |
| [HTML5](/slides/ar/php-java/export-to-html5/) | يمكنه تشغيل الرسوم المتحركة المدعومة عندما يُفعل رسوم متحركة الشكل في خيارات التصدير. اختبر التركيبات المخصَّصة في المتصفح. |
| [GIF متحرك](/slides/ar/php-java/convert-powerpoint-to-animated-gif/) | يخزن إطارات مُرَسَّمة، لا سلوكيات قابلة للتحرير أو تفاعلات نقر. راقب الحركة المُرَسَّمة فعليًا. |
| [فيديو](/slides/ar/php-java/convert-powerpoint-to-video/) | يرسم إطارات الرسوم المتحركة ويحوِّلها إلى فيديو. الدعم محدود إلى [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)؛ لا تتحول الأوامر والأحداث التفاعلية إلى جدول زمني قابل للتحرير. |

## **الأسئلة المتكررة**

**لماذا يحتوي تأثيري على سلوكيات قبل أن أضيف أي شيء؟**

إنشاء تأثير مسبق قد يُنشئ عملياته الأساسية. افحصها قبل تقرير ما إذا كنت ستُوسِّع النموذج المسبق أو تستبدل سلوكياته.

**هل يجعل نقل سلوك إلى البداية تشغيله أولًا؟**

ليس بالضرورة. ترتيب المجموعة لا يُعدّ بديلاً للتوقيت. تحقق من التأخيرات، المدد، والتفاعلات بين العمليات على نفس الخاصية.

**لماذا لا يحتوي أمر النهاية على نقاط؟**

إنه يحدد نهاية المسار ولا يتطلب إحداثيات. تحقق من مصفوفة نقاط فارغة عند فحص مسار مقروء من ملف.

**هل يكفي جولة حفظ‑إعادة فتح ناجحة لتأكيد التشغيل؟**

لا. إعادة الفتح تؤكد حفظ الخصائص التي فحصتها. اختبر مشغل عرض الشرائح أو التصدير المتحرك منفصلًا لتأكيد سلوكه البصري.