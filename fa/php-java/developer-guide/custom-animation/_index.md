---
title: ایجاد و اصلاح رفتارهای سفارشی انیمیشن در PHP
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/php-java/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکتی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد، بررسی و اصلاح رفتارهای سفارشی انیمیشن و مسیرهای حرکتی قابل ویرایش در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java."
---
## **نمای کلی**

رفتارهای سفارشی انیمیشن به شما امکان می‌دهند عملیات‌های فردی داخل یک اثر انیمیشن را کنترل کنید، مانند تغییر رنگ، چرخاندن یک شکل یا پیروی از مسیر حرکتی قابل ویرایش. این راهنما نشان می‌دهد چگونه رفتارها را ایجاد و ترکیب کنید، زمان‌بندی آن‌ها را تنظیم کنید، انیمیشن‌های موجود را بررسی و اصلاح کنید و اطمینان حاصل کنید که ویژگی‌های آن‌ها پس از ذخیره و بازگشایی یک ارائه حفظ می‌شوند.

برای اثرهای پیش‌تعریف‌شده و فعال‌کننده‌های کلیک، به [انیمیشن شکل](/slides/fa/php-java/shape-animation/) مراجعه کنید.

## **درک مدل انیمیشن**

یک انیمیشن به صورت **Timeline → Sequence → Effect → Behaviors** سازماندهی می‌شود:

- هر اسلاید یک جدول زمانی دارد که شامل توالی اصلی و توالی‌های تعاملی آن است.
- یک [Sequence](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/) شامل اثرهاست که ممکن است به شکل‌های مختلفی هدف‌گذاری شوند.
- یک [Effect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/) شکل هدف، پیش‌تنظیم، زیرنوع و زمان‌بندی اثر را شناسایی می‌کند.
- مجموعه‌ای که توسط [Effect::getBehaviors](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getbehaviors/) برگردانده می‌شود، عملیات‌هایی که اثر را پیاده‌سازی می‌کنند شامل تغییر رنگ، جابجایی، چرخش، تنظیم یک ویژگی و غیره را شامل می‌شود.

## **ایجاد رفتارهای فردی**

از [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) برای ایجاد یک اثر و دسترسی به مجموعه [getBehaviors](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getbehaviors/) استفاده کنید. یک پیش‌تنظیم می‌تواند این مجموعه را به‌صورت خودکار پر کند. عملیات‌های آن را هنگام گسترش پیش‌تنظیم حفظ کنید، یا هنگام جایگزینی عمدی از [clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorcollection/clear/) استفاده کنید.

[BehaviorFactory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/) هشت نوع رفتار نشان داده‌شده در زیر را ایجاد می‌کند. حرکت در بخش [ساخت مسیر حرکتی](#build-a-motion-path) پوشش داده شده است. هر قطعه کد شامل importهای لازم بوده و فرض می‌شود که PHP/Java Bridge و کتابخانه Aspose.Slides برای PHP بارگذاری شده‌اند. مثال‌های ویرایشی بعدی بیان می‌کنند که از کدام فایل خروجی استفاده می‌شود.

### **چرخش**

از [createRotationEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createrotationeffect/) برای ایجاد یک چرخش استفاده کنید. [getBy](https://reference.aspose.com/slides/fa/php-java/aspose.slides/rotationeffect/getby/) زاویه نسبی را بر حسب درجه مشخص می‌کند؛ [getFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/rotationeffect/getfrom/) و [getTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/rotationeffect/getto/) نقاط انتهایی را تعیین می‌کنند.

مثال با یک اثر Spin شروع می‌شود، عملیات‌های پیش‌تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و طول زمان این عملیات را دو ثانیه می‌گذارد. یک زاویه نسبی 90 درجه چرخش یک‌چهارم‌دور از جهت اولیه شکل را نشان می‌دهد، بنابراین نیازی به زاویه شروع صریح نیست.

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

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایشی چرخش در ادامه از این فایل استفاده می‌کنند.

### **مقیاس**

از [createScaleEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createscaleeffect/) با درصدهای X/Y استفاده کنید: [getFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/scaleeffect/getfrom/) و [getTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/scaleeffect/getto/) اندازهٔ شروع و پایان را توصیف می‌کنند، در حالی که [getBy](https://reference.aspose.com/slides/fa/php-java/aspose.slides/scaleeffect/getby/) تغییری نسبی را توصیف می‌کند. در اینجا، 100 به معنی اندازهٔ اصلی است.

مثال هر دو بعد را از 100٪ به 125٪ در طول دو ثانیه افزایش می‌دهد. استفاده از درصدهای مساوی افقی و عمودی نسبت‌ها را حفظ می‌کند؛ درصدهای متفاوت یک بعد را نسبت به دیگری کشیده می‌کند.

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

### **رنگ**

از [createColorEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createcoloreffect/) برای تغییر رنگ پر از آبی به نارنجی استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/coloreffect/getfrom/) و [getTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/coloreffect/getto/) رنگ‌ها هستند؛ [getBy](https://reference.aspose.com/slides/fa/php-java/aspose.slides/coloreffect/getby/) جابجایی رنگ است. [BehaviorPropertyCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorpropertycollection/) ویژگی انیمیشن‌شده را شناسایی می‌کند.

پر شدن جامد شکل به آبی مقداردهی اولیه می‌شود تا با رنگ شروع انیمیشن مطابقت داشته باشد. انتخاب ویژگی fill-color به رفتار می‌گوید کدام بخش از شکل تغییر کند؛ تنها نقاط انتهایی رنگ آن ویژگی را شناسایی نمی‌کند. اثر ذخیره‌شده یک تغییر دو ثانیه‌ای به نارنجی را توصیف می‌کند.

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

### **فیلتر**

از [createFilterEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createfiltereffect/) برای انتخاب یک پاک‌کن (wipe) استفاده کنید. [getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filtereffect/gettype/)، [getSubtype](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filtereffect/getsubtype/)، و [getReveal](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filtereffect/getreveal/) فیلتر، جهت و اینکه شکل آشکار یا مخفی شود را مشخص می‌کنند.

این مثال یک پاک‌کن دو ثانیه‌ای که شکل را با جهت راست آشکار می‌کند، پیکربندی می‌کند. تنظیمات فیلتر متعلق به رفتار داخل اثر هستند، بنابراین پس از حذف عملیات اصلی پیش‌تنظیم، پیکربندی می‌شوند.

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

### **ویژگی**

از [createPropertyEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) برای انیمیشن شفافیت (opacity) استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/propertyeffect/getfrom/)، [getTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/propertyeffect/getto/)، و [getBy](https://reference.aspose.com/slides/fa/php-java/aspose.slides/propertyeffect/getby/) رشته‌هایی هستند که با استفاده از [getValueType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/propertyeffect/getvaluetype/) و [getCalcMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/propertyeffect/getcalcmode/) تفسیر می‌شوند. به‌جای تنظیم همزمان هر سه مقدار، نقطهٔ انتهایی یا جابجایی نسبی را انتخاب کنید.

در اینجا ویژگی انتخاب‌شده شفافیت است و رشته‌های عددی تغییر از 25٪ شفافیت به شفافیت کامل را نشان می‌دهند. درون‌یابی خطی توصیف‌کنندهٔ تغییر تدریجی بین این مقادیر است. هنگام تطبیق این مثال با ویژگی دیگر، نوع مقدار و مقادیر نقطهٔ انتهایی متناسب با آن ویژگی را انتخاب کنید.

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

### **تنظیم**

از [createSetEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createseteffect/) برای اختصاص دیده‌شدن (visibility) از طریق [getTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/seteffect/getto/) استفاده کنید. یک رفتار تنظیم بین نقطهٔ انتهایی درون‌یابی نمی‌کند.

مثال ویژگی visibility را انتخاب می‌کند و رشتهٔ `visible` را هنگام اجرا اختصاص می‌دهد. مستطیل در این ارائهٔ حداقل هم‌اکنون قابل مشاهده است، لذا این اختصاص ممکن است تغییر بصری آشکاری ایجاد نکند. چنین عملیاتی در بخشی از یک اثر بزرگتر که همچنین زمان مخفی یا نمایان شدن شکل را کنترل می‌کند، مفید است.

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

### **دستور**

از [createCommandEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createcommandeffect/) استفاده کنید و [getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commandeffect/gettype/)، [getCommandString](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commandeffect/getcommandstring/)، و [getShapeTarget](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commandeffect/getshapetarget/) را پیکربندی کنید. فایل صوتی WAV به نام `sample.wav` را در پوشهٔ کاری قرار دهید. این مثال آن را با [addAudioFrameEmbedded](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addaudioframeembedded/) جاسازی می‌کند و یک دستور پخش به چارچوب صوتی متصل می‌سازد.

چارچوب صوتی هم هدف اثر است و هم هدف دستور. این کار درخواست پخش را به ضبط جاسازی‌شده متصل می‌کند؛ یک رشتهٔ دستور به تنهایی شی رسانه‌ای را که باید کنترل شود شناسایی نمی‌کند. اثر به‌صورت کلیک در هنگام نمایش اسلاید شروع می‌شود.

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

ذخیره‌سازی دستور را در `command.pptx` ذخیره می‌کند؛ ضبط را پخش نمی‌کند. برای پخش نیاز به پخش‌کننده اسلاید‌شو است که از این دستور و هدف رسانه‌ای آن پشتیبانی کند.

## **مدیریت مجموعه رفتارها**

[BehaviorCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorcollection/) از متدهای [add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorcollection/add/)، [insert](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorcollection/insert/)، [remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorcollection/remove/)، و [removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorcollection/removeat/) پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌بندی را اضافه می‌کند، آن را قبل از چرخش قرار می‌دهد و چرخش را حذف می‌کند. حذف و درج مجدد همان شیء موقعیت ذخیره‌شده را بدون ساختن کپی تغییر می‌دهد.

دنبالهٔ ویرایش‌ها مجموعه را از rotation–scale به scale–rotation، سپس به scale فقط تغییر می‌دهد. ایندکس‌ها به مجموعهٔ فعلی ارجاع می‌دهند، بنابراین حذف از ایندکس جدید چرخش پس از ترتیب‑دوباره صورت می‌گیرد. شمارش نهایی تأیید می‌کند که کدام رفتار ذخیره خواهد شد.

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

خروجی `ScaleEffect` است: فقط مقیاس‌بندی باقی می‌ماند. ترتیب مجموعه به‌تنهایی زمان‌بندی رفتارها را پشت سر هم تنظیم نمی‌کند. فقط زمانی که تمام عملیات را جایگزین می‌کنید، مجموعه را پاک کنید.

## **پیکربندی زمان‌بندی رفتار**

یک رفتار زمان‌بندی اختصاصی [Timing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/) خود را دارد، که مستقل از زمان‌بندی برگردانده‌شده توسط [Effect::getTiming](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/gettiming/) است. زمان‌بندی اثر، اثر محاط را زمان‌بندی می‌کند؛ زمان‌بندی رفتار، یک عملیات داخل آن را توصیف می‌کند.

### **تنظیم مدت زمان، تاخیر، تکرار و شتاب‌دهی**

`rotation.pptx` را باز کنید و مدت زمان ([getDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getduration/)) و تاخیر فعال‌ساز ([getTriggerDelayTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/gettriggerdelaytime/)) را بر حسب ثانیه تنظیم کنید، سپس تعداد تکرار را از طریق [setRepeatCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/setrepeatcount/) پیکربندی کنید. [getAccelerate](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getaccelerate/) و [getDecelerate](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getdecelerate/) کسری از مدت زمان هستند؛ مجموع آن‌ها حداکثر 1 باشد.

فایل ورودی همان فایلی است که در مثال چرخش ساخته شد، جایی که اولین رفتار شناخته‌شده یک چرخش است. این مثال فقط زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ 90 درجه دست نخورده می‌ماند. جدا نگه‌داشتن زاویه و زمان‌بندی، تنظیم سرعت را بدون بازسازی انیمیشن آسان‌تر می‌کند.

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

رفتار مدت زمان دو ثانیه، تاخیر نیم ثانیه و تعداد تکرار 3 دارد. 20٪ اول و آخر مدت زمان آن برای شتاب‌دهی و کندی استفاده می‌شود.

سیاست‌های تکرار دیگر شامل [getRepeatDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatduration/)، [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatuntilendslide/)، و [getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatuntilnextclick/) هستند؛ یک سیاست را انتخاب کنید نه اینکه همه را همزمان فعال کنید. [getAutoReverse](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getautoreverse/) پس از عبور رو به جلو، انیمیشن را به‌عکس اجرا می‌کند. شتاب‌دهی و کندی برای تغییرات پیوسته اعمال می‌شوند، نه برای اختصاص‌های گسسته یا دستورات.

## **ساخت مسیر حرکتی**

از [createMotionEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorfactory/createmotioneffect/) برای ایجاد حرکت استفاده کنید. [getFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioneffect/getfrom/)، [getTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioneffect/getto/)، و [getBy](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioneffect/getby/) مختصات یا جابجایی‌های مبتنی بر درصد را توصیف می‌کنند. برای یک مسیر قابل ویرایش، یک [MotionPath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motionpath/) ایجاد کنید و با [MotionEffect::setPath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioneffect/setpath/) انتساب دهید. [MotionPath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motionpath/) دستورات مسیر را ذخیره می‌کند.

[MotionCommandPathType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioncommandpathtype/) عملیات را انتخاب می‌کند:

| دستور | نقاط | معنی |
| --- | --- | --- |
| MoveTo | یک | تعیین موقعیت شروع. |
| LineTo | یک | حرکت در یک بخش مستقیم تا نقطهٔ انتهایی آن. |
| CurveTo | سه | پیروی از منحنی مکعبی تعریف‌شده توسط دو نقطهٔ کنترل و یک نقطهٔ انتهایی. |
| CloseLoop | هیچ | بازگشت به موقعیت شروع. |
| End | هیچ | پایان مسیر. |

[MotionPathPointsType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motionpathpointstype/) ویژگی‌های ویرایش نقطه را توصیف می‌کند، مانند نقطهٔ گوشه‌ای یا صاف. این نوع نقطه جایگزین نوع دستور نمی‌شود. برای مثال منحنی زیر از نوع نقطهٔ منحنی و برای قطعات مستقیم از نوع نقطهٔ گوشه‌ای استفاده کنید.

مختصات مسیر نسبت به ابعاد اسلاید نرمال‌سازی می‌شود: جابه‌جایی X برابر 0.25 یک‌چهارم عرض اسلاید را نشان می‌دهد، نه 0.25 پوینت. Y مثبت به سمت پایین می‌رود. دستورات مطلق موقعیت‌ها را در سیستم مختصات مسیر مشخص می‌کنند؛ دستورات نسبی جابجایی نسبت به موقعیت فعلی را تعریف می‌کنند. این به‌طور جداگانه از [getOrigin](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioneffect/getorigin/) است که چارچوب مرجع مسیر را انتخاب می‌کند و [getPathEditMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioneffect/getpatheditmode/) که نحوهٔ جابه‌جایی مسیر هنگام حرکت شکل را کنترل می‌کند.

### **ایجاد مسیر مستقیم**

یک رفتار حرکتی با نقطهٔ شروع، یک قطعه مستقیم و یک دستور پایان ایجاد کنید. [MotionPath::add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motionpath/add/) نوع دستور، نقاط آن، نوع نقطه و پرچم مختصات نسبی را می‌گیرد.

دستور شروع (0, 0) را تعیین می‌کند و خط به (0.25, 0) ختم می‌شود، که مسیر را به‌صورت افقی یک‌چهارم عرض اسلاید جابجا می‌کند. دستور پایان هیچ نقطهٔ مختصاتی ندارد. پس از انتساب مسیر، افزودن رفتار حرکتی به اثر، آن مسیر را به مستطیل وصل می‌کند.

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

`motion.pptx` شامل یک رفتار حرکتی با سه دستور مسیر است. مثال‌های ویرایشی زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **مقایسه مختصات مطلق و نسبی**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. دستور مطلق در (0.3, 0.1) پایان می‌یابد؛ دستور نسبی (0.1, 0.1) را به موقعیت فعلی (0.2, 0) اضافه می‌کند.

هر دو مسیر از همان موقعیت شروع می‌شوند. برای خط نسبی، جابجایی‌های X و Y را به موقعیت فعلی اضافه کنید تا نقطهٔ انتهایی به‌دست آید؛ برای خط مطلق، نقطهٔ انتهایی را مستقیماً بخوانید. تغییر پرچم بدون تبدیل مختصات مسیر متفاوتی توصیف می‌کند.

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

هر یک از مسیرها را به یک رفتار حرکتی انتساب دهید تا در ارائه استفاده شود. آرگومان Boolean نهایی، مختصات نسبی را برای آن دستور انتخاب می‌کند.

### **جایگزینی خط با منحنی**

`motion.pptx` را باز کنید و دستور خط را با یک منحنی مکعبی جایگزین کنید. ابتدا دو نقطهٔ کنترل و سپس نقطهٔ انتهایی را فراهم کنید.

موقعیت شروع توسط دستور قبلی تامین می‌شود. دو نقطهٔ اول شکل منحنی را تعریف می‌کنند، در حالی که نقطهٔ سوم مقصد آن است؛ آن‌ها سه مقصد متوالی نیستند. به‌روزرسانی همزمان نوع دستور، نوع ویرایش نقطه و آرایهٔ نقاط، قطعه را با هندسهٔ جدید سازگار نگه می‌دارد.

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

مسیر در `curve.pptx` هنوز سه دستور دارد؛ دستور میانی اکنون یک منحنی را تعریف می‌کند.

## **بررسی و ویرایش مسیر ذخیره‌شده**

هر [MotionCmdPath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioncmdpath/) متدهای [getPoints](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioncmdpath/getpoints/)، [getCommandType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioncmdpath/getcommandtype/)، [getPointsType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioncmdpath/getpointstype/)، و [isRelative](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motioncmdpath/isrelative/) را عرضه می‌کند. مثال‌های زیر از مسیر سه‌دستوری شناخته‌شده در `motion.pptx` استفاده می‌کنند. برای ورودی‌های دلخواه، قبل از ویرایش بر اساس ایندکس، اثر مورد نظر را پیدا کنید و انواع دستورات و تعداد نقاط را بررسی کنید.

### **خواندن دستورات و مختصات**

مسیر را بدون تغییر بخوانید. دستورات End و CloseLoop نیازی به نقاط ندارند، پس آرایهٔ نقاط می‌تواند null باشد.

خروجی هر نوع عددی دستور را همراه با پرچم مختصات نسبی قبل از فهرست کردن نقاط نشان می‌دهد. این به شما اجازه می‌دهد قبل از تغییر مسیر، نقطهٔ انتهایی را از جابجایی متمایز کنید. یک منحنی سه نقطه فهرست می‌کند، در حالی که خط مستقیم در این فایل فقط یک نقطه دارد.

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

فهرست شامل یک نقطهٔ شروع، یک خط مطلق که در (0.25, 0) پایان می‌یابد و یک دستور End است.

### **تغییر نقطهٔ انتهایی**

`motion.pptx` را باز کنید و آرایهٔ نقاط خط را جایگزین کنید تا نقطهٔ انتهایی آن جابه‌جا شود.

در فایل ورودی، ایندکس 0 دستور شروع و ایندکس 1 خط است. جایگزینی نقطهٔ تک‌نقطه‌ای خط، مقصد آن را بدون تغییر نوع دستور، زمان‌بندی یا موقعیت در مجموعه تغییر می‌دهد. از آنجایی که دستور از مختصات مطلق استفاده می‌کند، جفت جدید موقعیتی را نه یک جابجایی اضافه‌شده، مشخص می‌کند.

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

خط در `motion-endpoint.pptx` در (0.4, 0.1) پایان می‌یابد؛ فایل اصلی بدون تغییر باقی می‌ماند.

### **جایگزینی یک بخش**

از [insert](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motionpath/insert/) و [removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/motionpath/removeat/) برای جایگزینی خط در `motion.pptx` استفاده کنید. درج خط جدید، خط قدیمی را به ایندکس 2 منتقل می‌کند.

این روش نشان می‌دهد که شیء دستور را جایگزین کنید نه مختصات موجود آن را ویرایش کنید. پس از درج، مجموعه موقتاً شامل دستور شروع، خط جدید، خط قدیم و دستور End می‌شود. حذف ایندکس 2 خط قدیم را حذف می‌کند و مسیر جدید در جای خود می‌ماند.

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

مسیر ذخیره‌شده هنوز سه دستور دارد؛ خط جدید در (0.2, 0.1) پایان می‌یابد و دستور End آخرین است.

## **اصلاح و تأیید یک رفتار موجود**

وقتی ایندکس رفتار ناشناخته باشد، با نوع آن انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [RotationEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/rotationeffect/) را می‌یابد، زاویه را تغییر می‌دهد و مقدار ذخیره‌شده را پس از بازگشایی مجدد بررسی می‌کند.

بررسی نوع اجازه می‌دهد حلقه رفتارهایی که چرخش نیستند را عبور دهد. بار دوم فایل ذخیره‌شده را در یک شی ارائهٔ جداگانه می‌خواند، بنابراین مقایسه داده‌های ثابت شده را نه مقدار هنوز در حافظه را بررسی می‌کند. این مثال همچنان فرض می‌کند اثر شناخته‌شده اولین اثر در توالی اصلی است؛ انتخاب رفتار بر اساس نوع، لزوماً اثر درست را در یک ارائهٔ دلخواه پیدا نمی‌کند.

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

خروجی `Rotation preserved: true` است. الگوی بررسی نوع را برای سایر رفتارها نیز اعمال کنید. برای یک بررسی کامل حفظ، شکل هدف، اثر، انواع و ترتیب رفتارها، زمان‌بندی و دستورات مسیر را مقایسه کنید. برای مقادیر عددی با دقت شناور، از تحمل عددی استفاده کنید. برای ارائه‌ای با طرح‌بندی انیمیشن ناشناخته، به [خواندن انیمیشن‌های شکل](/slides/fa/php-java/shape-animation/#read-shape-animations) برای عبور توالی اصلی و تعاملی مراجعه کنید.

## **ترتیب رفتارها، پیش‌تنظیم‌ها و پخش**

ترتیب در [BehaviorCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behaviorcollection/) ترتیب ذخیره‌شدهٔ عملیات‌های یک اثر است. این یک فهرست پخش نیست که هر رفتار به‌طور خودکار منتظر رفتار قبلی باشد. زمان‌بندی و اثر محاط برنامه‌ریزی را تعیین می‌کنند. رفتارها می‌توانند همپوشانی داشته باشند و عملیات‌های روی یک ویژگی می‌توانند از طریق تنظیمات [additive](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behavioradditivetype/) و [accumulation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behavioraccumulatetype/) باهم تعامل داشته باشند. فقط به تغییر ترتیب مجموعه برای زمان‌بندی «حرکت، سپس چرخش» تکیه نکنید؛ از زمان‌بندی صریح یا اثرهای جداگانه همان‌طور که در [انیمیشن شکل](/slides/fa/php-java/shape-animation/) توضیح داده شده استفاده کنید.

[getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/gettype/) و [getSubtype](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getsubtype/) اثر، پیش‌تنظیم آن را توصیف می‌کنند. این توصیف کامل درخت رفتار ویرایش‌شده نیست. پیش‌تنظیم و زیرنوع را قبل از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش‌تنظیم می‌تواند مجموعه را بازسازی کند و عملیات سفارشی شما را از دست بدهد. برای مثال، تغییر یک اثر Spin سفارشی به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش‌تنظیم یا زیرنوع، مجدداً مجموعه را بررسی کنید. پاک کردن رفتارهای پیش‌تنظیم می‌تواند عملیات‌های قابل مشاهده یا مقداردهی اولیه‌ای که پیش‌تنظیم نیاز دارد حذف کند. مثال‌ها به‌صورت عمدی از اشکال قابل مشاهده استفاده می‌کنند و رفتارها را جایگزین می‌کنند؛ آن‌ها پیاده‌سازی کامل هر پیش‌تنظیم را بازسازی نمی‌کنند.

## **سازگاری فرمت‌ها**

یک درخت رفتار حفظ‌شده تضمین نمی‌کند پخش یکسانی در هر نمایشگر یا رندر کنندهٔ خروجی داشته باشد. داده‌های ذخیره‌شده و خروجی رندر شده را جداگانه بررسی کنید.

| فرمت یا خروجی | مواردی که باید بررسی شود |
| --- | --- |
| PPTX | به‌عنوان فرمت اصلی برای این مثال‌ها استفاده کنید. آن را باز کنید تا درخت رفتار ویرایشی را تأیید کنید، سپس پخش را در نسخهٔ PowerPoint هدف بررسی کنید. |
| PPT | نمایش باینری قدیمی می‌تواند متفاوت از PPTX باشد. یک دورهٔ ذخیره‑بازگشت جداگانه و پخش را تست کنید؛ از موفقیت خروجی PPTX برای استنتاج پشتیبانی از ترکیب سفارشی استفاده نکنید. |
| PDF, PNG, JPEG و سایر تصاویر ثابت اسلاید | نمایی ثابت از اسلاید را دارند، نه یک خط زمان قابل پخش یا فریم نهایی انیمیشن تضمینی. |
| [HTML5](/slides/fa/php-java/export-to-html5/) | می‌تواند انیمیشن‌های پشتیبانی‌شده را وقتی انیمیشن شکل در گزینه‌های خروجی فعال باشد، اجرا کند. ترکیب‌های سفارشی را در مرورگر تست کنید. |
| [GIF متحرک](/slides/fa/php-java/convert-powerpoint-to-animated-gif/) | فریم‌های رندر شده را ذخیره می‌کند، نه رفتارهای ویرایشی یا تعاملات کلیکی. حرکت رندر شده واقعی را بررسی کنید. |
| [ویدئو](/slides/fa/php-java/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌صورت ویدئو رمزگذاری می‌کند. پشتیبانی به‌صورت [انیمیشن‌ها و اثرهای پشتیبانی‌شده](/slides/fa/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) محدود است؛ دستورات و رویدادهای تعاملی تبدیل به خط زمان ویرایشی نمی‌شوند. |

## **سوالات متداول**

**چرا اثر من قبل از افزودن هر چیزی رفتار دارد؟**

ایجاد یک اثر پیش‌تعریف‌شده می‌تواند عملیات‌های پایه‌ای آن را ایجاد کند. قبل از تصمیم‌گیری برای گسترش پیش‌تنظیم یا جایگزینی رفتارها، آن‌ها را بررسی کنید.

**آیا جابجایی یک رفتار به ابتدا باعث می‌شود اولین بار پخش شود؟**

لزماً نه. ترتیب مجموعه جایگزین زمان‌بندی نیست. تاخیرها، مدت‌ها و تعاملات بین عملیات‌های یک ویژگی را بررسی کنید.

**چرا یک دستور End هیچ نقطه‌ای ندارد؟**

این دستور پایان مسیر را علامت‌گذاری می‌کند و نیازی به مختصات ندارد. هنگام بررسی مسیری که از فایل خوانده می‌شود، به‌دنبال آرایهٔ نقطهٔ null باشید.

**آیا یک دور کامل موفق برای تأیید پخش کافی است؟**

نه. بازگشایی حفظ ویژگی‌هایی را که بررسی کرده‌اید تأیید می‌کند. پخش‌کننده اسلایدشو یا خروجی‌های انیمیشن‌دار را جداگانه تست کنید تا رفتار بصری آن را تأیید کنید.