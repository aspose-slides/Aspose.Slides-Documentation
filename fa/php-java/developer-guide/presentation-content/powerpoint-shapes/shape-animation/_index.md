---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از PHP
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/php-java/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل انیمیشن‌شده
- متن انیمیشن‌شده
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "کشف کنید چگونه انیمیشن‌های شکل را در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java ایجاد و سفارشی‌سازی کنید. برجسته باشید!"
---
## **معرفی**

انیمیشن‌ها افکت‌های بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، اشکال یا [نمودارها](https://docs.aspose.com/slides/fa/php-java/animated-charts/) اعمال شوند. آنها به ارائه‌ها یا اجزای آن جان می‌بخشند.

## **چرا از انیمیشن‌ها در ارائه‌ها استفاده کنیم؟**

* کنترل جریان اطلاعات
* برجسته‌سازی نکات مهم
* افزایش علاقه یا مشارکت مخاطبان
* ساختن محتوا به گونه‌ای که خواندن، درک یا پردازش آن آسان‌تر باشد
* جلب توجه خوانندگان یا تماشاگران به بخش‌های مهم در یک ارائه

PowerPoint گزینه‌ها و ابزارهای متعددی برای انیمیشن‌ها و افکت‌های انیمیشن در دسته‌های **ورودی**، **خروجی**، **تاکید** و **مسیرهای حرکت** فراهم می‌کند.

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و انواع مورد نیاز برای کار با انیمیشن‌ها را در فضای نام `Aspose.Slides.Animation` فراهم می‌کند،
* Aspose.Slides بیش از **150 افکت انیمیشن** را در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttype) ارائه می‌دهد. این افکت‌ها در واقع همان (یا معادل) افکت‌های استفاده شده در PowerPoint هستند.

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد انیمیشن را بر متن یک شکل اعمال کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. از طریق اندیس، یک مرجع اسلاید به دست آورید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیل اضافه کنید.
4. متن را به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#getTextFrame) `AutoShape` اضافه کنید.
5. دنباله اصلی افکت‌ها را دریافت کنید.
6. یک افکت انیمیشن به [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) اضافه کنید.
7. از متد `TextAnimation.setBuildType` و مقدار موجود در شمارش‌گر `BuildType` استفاده کنید.
8. ارائه را به عنوان فایل PPTX روی دیسک ذخیره کنید.

این کد PHP نشان می‌دهد چگونه افکت `Fade` را به AutoShape اعمال کنید و انیمیشن متن را روی مقدار *By 1st Level Paragraphs* تنظیم کنید:

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape جدید با متن
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # دریافت دنباله اصلی اسلاید.
    $sequence = $sld->getTimeline()->getMainSequence();
    # افزودن افکت انیمیشن Fade به شکل
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # انیمیشن متن شکل را بر اساس پاراگراف‌های سطح اول انجام می‌دهد
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # ذخیره فایل PPTX روی دیسک
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

علاوه بر اعمال انیمیشن بر متن، می‌توانید انیمیشن‌ها را به یک [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) واحد نیز اعمال کنید. ببینید [**Animated Text**](/slides/fa/php-java/animated-text/).

{{% /alert %}} 

## **اعمال انیمیشن به PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق اندیس آن به دست آورید.
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe) را روی اسلاید اضافه یا دریافت کنید.
4. دنباله اصلی افکت‌ها را دریافت کنید.
5. یک افکت انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe) اضافه کنید.
6. ارائه را به عنوان فایل PPTX روی دیسک ذخیره کنید.

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
  $pres = new Presentation();
  try {
    # بارگذاری تصویر برای افزودن به مجموعه تصاویر ارائه
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # افزودن قاب تصویر به اسلاید
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # دریافت دنباله اصلی اسلاید.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # افزودن افکت انیمیشن Fly از چپ به قاب تصویر
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # ذخیره فایل PPTX روی دیسک
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اعمال انیمیشن به Shape**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق اندیس آن به دست آورید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیل اضافه کنید.
4. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) بویل اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).
5. یک دنباله افکت‌ها بر روی شکل بویل ایجاد کنید.
6. یک `UserPath` سفارشی ایجاد کنید.
7. دستورات حرکت به `UserPath` را اضافه کنید.
8. ارائه را به عنوان فایل PPTX روی دیسک ذخیره کنید.

```php
  # یک شیء Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # افکت PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # افکت انیمیشن PathFootBall را اضافه می‌کند
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # یک نوع "button" ایجاد می‌کند.
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # دنباله‌ای از افکت‌ها برای این دکمه ایجاد می‌کند.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # یک مسیر کاربری سفارشی ایجاد می‌کند. شیء ما فقط پس از کلیک شدن دکمه حرکت خواهد کرد.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # دستورات حرکت را اضافه می‌کند چون مسیر ایجاد شده خالی است.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # فایل PPTX را روی دیسک می‌نویسد
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دریافت افکت‌های انیمیشن اعمال شده بر یک Shape**

مثال‌های زیر نشان می‌دهند چگونه از متد `getEffectsByShape` کلاس [Sequence](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/) برای دریافت تمام افکت‌های انیمیشن اعمال شده بر یک shape استفاده کنید.

**مثال 1: دریافت افکت‌های انیمیشن اعمال شده بر یک shape در اسلاید عادی**

قبلاً یاد گرفته‌اید چگونه افکت‌های انیمیشن را به شکل‌ها در ارائه‌های PowerPoint اضافه کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های اعمال شده بر اولین shape در اولین اسلاید عادی ارائه `AnimExample_out.pptx` را دریافت کنید.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # دریافت دنباله اصلی انیمیشن اسلاید.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # دریافت اولین شکل در اولین اسلاید.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # دریافت افکت‌های انیمیشن اعمال شده بر شکل.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**مثال 2: دریافت تمام افکت‌های انیمیشن، شامل آنهایی که از مکان‌دارها (placeholders) ارث‌بری شده‌اند**

اگر یک shape در اسلاید عادی دارای placeholders باشد که در اسلاید چینش و/یا اسلاید اصلی قرار دارند و افکت‌های انیمیشن به این placeholders اضافه شده باشد، تمام افکت‌های shape در طول نمایش اسلاید اجرا می‌شوند، شامل آنهایی که از placeholders ارث‌بری شده‌اند.

مثلاً ما یک فایل ارائه PowerPoint به نام `sample.pptx` داریم که شامل یک اسلاید است که تنها یک shape پادنوشت با متن "Made with Aspose.Slides" دارد و افکت **Random Bars** بر روی آن اعمال شده است.

![Slide shape animation effect](slide-shape-animation.png)

همچنین فرض کنید افکت **Split** بر روی placeholder پادنوشت در اسلاید **layout** اعمال شده باشد.

![Layout shape animation effect](layout-shape-animation.png)

و در نهایت، افکت **Fly In** بر روی placeholder پادنوشت در اسلاید **master** اعمال شده باشد.

![Master shape animation effect](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `getBasePlaceholder` کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) برای دسترسی به placeholders شکل‌ها و دریافت افکت‌های انیمیشن اعمال شده بر shape پادنوشت استفاده کنید، شامل افکت‌های ارث‌بری شده از placeholders موجود در اسلایدهای layout و master.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// دریافت افکت‌های انیمیشن شکل در اسلاید عادی.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// دریافت افکت‌های انیمیشن placeholder در اسلاید layout.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// دریافت افکت‌های انیمیشن placeholder در اسلاید master.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // پرواز، پایین
Type: 134, subtype: 45            // تقسیم، عمودی به داخل
Type: 126, subtype: 22            // نوارهای تصادفی، افقی
```

## **تغییر روش‌های زمان‌بندی افکت انیمیشن**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد ویژگی‌های Timing یک افکت انیمیشن را تغییر دهید.

این پنل زمان‌بندی انیمیشن در Microsoft PowerPoint است:

![example1_image](shape-animation.png)

این‌ها تطابق‌های بین زمان‌بندی PowerPoint و ویژگی‌های [Effect Timing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#getTiming) هستند:

- منوی کشویی **Start** در زمان‌بندی PowerPoint با متد [Timing::getTriggerType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/#getTriggerType) مطابقت دارد.
- زمان‌بندی **Duration** در PowerPoint با متد [Timing::getDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/#getDuration) مطابقت دارد. مدت زمان یک انیمیشن (بر ثانیه) کل زمان لازم برای تکمیل یک چرخه انیمیشن است.
- زمان‌بندی **Delay** در PowerPoint با متد [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/#getTriggerDelayTime) مطابقت دارد.

این‌گونه می‌توانید ویژگی‌های زمان‌بندی افکت را تغییر دهید:

1. [اعمال](#apply-animation-to-shape) یا دریافت افکت انیمیشن.
2. مقادیر جدید مورد نیاز را با استفاده از متد [Effect::getTiming](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#getTiming) تنظیم کنید.
3. فایل PPTX اصلاح‌شده را ذخیره کنید.

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # دنباله اصلی اسلاید را دریافت می‌کند.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # اولین اثر دنباله اصلی را دریافت می‌کند.
    $effect = $sequence->get_Item(0);
    # TriggerType اثر را به شروع با کلیک تغییر می‌دهد
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # مدت زمان اثر را تغییر می‌دهد
    $effect->getTiming()->setDuration(3.0);
    # TriggerDelayTime اثر را تغییر می‌دهد
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # فایل PPTX را روی دیسک ذخیره می‌کند
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **صدای افکت انیمیشن**

Aspose.Slides این متدها را برای کار با صداها در افکت‌های انیمیشن فراهم می‌کند:

- [setSound(IAudio value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **اضافه‌ کردن صدای افکت انیمیشن**

این کد PHP نشان می‌دهد چگونه یک صدای افکت انیمیشن اضافه کنید و هنگام شروع افکت بعدی آن را متوقف کنید:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # افزودن صدا به مجموعه صداهای ارائه
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # دریافت دنباله اصلی اسلاید.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # دریافت اولین افکت دنباله اصلی
    $firstEffect = $sequence->get_Item(0);
    # بررسی افکت برای "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # افزودن صدا به اولین افکت
      $firstEffect->setSound($effectSound);
    }
    # دریافت اولین دنباله تعاملی اسلاید.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # تنظیم پرچم افکت "Stop previous sound"
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # نوشتن فایل PPTX روی دیسک
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **استخراج صدای افکت انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع یک اسلاید را از طریق اندیس آن به دست آورید. 
3. دنباله اصلی افکت‌ها را دریافت کنید. 
4. متد [setSound(IAudio value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) تعبیه شده در هر افکت انیمیشن را استخراج کنید.

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # دریافت دنباله اصلی اسلاید.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # استخراج صدای افکت به صورت آرایه بایتی
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **پس از انیمیشن**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد ویژگی After animation یک افکت انیمیشن را تغییر دهید.

این پنل افکت انیمیشن و منوی گسترده در Microsoft PowerPoint است:

![example1_image](shape-after-animation.png)

منوی کشویی **After animation** در PowerPoint با این متدها مطابقت دارد:

- متد [setAfterAnimationType(int value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setAfterAnimationType) که نوع After animation را توصیف می‌کند:
  * گزینه **More Colors** در PowerPoint با نوع [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/#Color) مطابقت دارد;
  * گزینه **Don't Dim** در PowerPoint با نوع [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/#DoNotDim) مطابقت دارد (نوع پیش‌فرض After animation);
  * گزینه **Hide After Animation** در PowerPoint با نوع [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) مطابقت دارد;
  * گزینه **Hide on Next Mouse Click** در PowerPoint با نوع [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) مطابقت دارد;
- متد [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setAfterAnimationColor) که یک قالب رنگ After animation را تعریف می‌کند. این متد همراه با نوع [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/#Color) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ After animation پاک می‌شود.

این کد PHP نشان می‌دهد چگونه یک افکت After animation را تغییر دهید:

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # اولین افکت دنباله اصلی را دریافت می‌کند
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # نوع after animation را به Color تغییر می‌دهد
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # رنگ after animation را تنظیم می‌کند
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # فایل PPTX را روی دیسک ذخیره می‌کند
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **انیمیشن متن**

Aspose.Slides این متدها را برای کار با بخش *Animate text* یک افکت انیمیشن فراهم می‌کند:

- متد [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setAnimateTextType) که نوع Animate text افکت را توصیف می‌کند. متن shape می‌تواند به شکل‌های زیر انیمیشن شود:
  - همه به‌صورت همزمان ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/fa/php-java/aspose.slides/animatetexttype/#AllAtOnce) type)
  - به‌صورت کلمه به کلمه ([AnimateTextType::ByWord](https://reference.aspose.com/slides/fa/php-java/aspose.slides/animatetexttype/#ByWord) type)
  - به‌صورت حرف به حرف ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/animatetexttype/#ByLetter) type)
- متد [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setDelayBetweenTextParts) که تاخیر بین بخش‌های متن انیمیشن شده (کلمات یا حروف) را تنظیم می‌کند. مقدار مثبت درصد مدت افکت را مشخص می‌کند. مقدار منفی تاخیر را بر حسب ثانیه تعیین می‌کند.

این‌گونه می‌توانید ویژگی‌های Animate text افکت را تغییر دهید:

1. [اعمال](#apply-animation-to-shape) یا دریافت افکت انیمیشن.
2. از متد [setBuildType(int value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textanimation/#setBuildType) و مقدار [BuildType::AsOneObject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/buildtype/#AsOneObject) برای غیرفعال کردن حالت *By Paragraphs* استفاده کنید.
3. مقادیر جدید را با استفاده از متدهای [setAnimateTextType(int value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setAnimateTextType) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/#setDelayBetweenTextParts) تنظیم کنید.
4. فایل PPTX اصلاح‌شده را ذخیره کنید.

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # اولین افکت دنباله اصلی را دریافت می‌کند
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # نوع انیمیشن متن افکت را به "به عنوان یک شیء" تغییر می‌دهد
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # نوع Animate text افکت را به "به کلمه" تغییر می‌دهد
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # تاخیر بین کلمات را به 20% از مدت افکت تنظیم می‌کند
    $firstEffect->setDelayBetweenTextParts(20.0);
    # فایل PPTX را روی دیسک ذخیره می‌کند
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟**

[Export to HTML5](/slides/fa/php-java/export-to-html5/) و فعال کردن [options](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/) مسئول [shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimateshapes/) و [transition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimatetransitions/) انیمیشن‌ها. HTML ساده انیمیشن اسلایدها را پخش نمی‌کند، در حالی که HTML5 این کار را انجام می‌دهد.

**تغییر ترتیب z-order (لایه) اشکال چگونه بر انیمیشن تأثیر می‌گذارد؟**

انیمیشن و ترتیب رسم مستقل هستند: یک افکت زمان‌بندی و نوع ظاهر شدن/محو شدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getzorderposition/) تعیین می‌کند چه چیزی چه را پوشش می‌دهد. نتیجه قابل مشاهده ترکیب این دو است. (این رفتار عمومی PowerPoint است؛ مدل افکت‌ها و اشکال Aspose.Slides منطق مشابه را دنبال می‌کند.)

**آیا محدودیتی در تبدیل انیمیشن‌ها به ویدیو برای برخی افکت‌ها وجود دارد؟**

به‌ طور کلی، [animations are supported](/slides/fa/php-java/convert-powerpoint-to-video/)، اما موارد نادر یا افکت‌های خاص ممکن است به شکل متفاوتی رندر شوند. توصیه می‌شود افکت‌های مورد استفاده خود و نسخه کتابخانه را تست کنید.