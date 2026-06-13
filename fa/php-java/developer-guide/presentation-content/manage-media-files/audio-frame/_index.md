---
title: مدیریت صدا در ارائه‌ها با استفاده از PHP
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/php-java/audio-frame/
keywords:
- صدا
- فریم صوتی
- تصویر بندانگشتی
- اضافه کردن صدا
- ویژگی‌های صدا
- گزینه‌های صدا
- استخراج صدا
- PHP
- Aspose.Slides
description: "ایجاد و کنترل فریم‌های صوتی در Aspose.Slides برای PHP—مثال‌های کد برای جاسازی، برش، حلقه‌دار کردن و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **Overview**

این مقاله توضیح می‌دهد چگونه با فریم‌های صوتی در Aspose.Slides کار کنید. نشان می‌دهد چگونه صدا را به صورت جاسازی کرده به اسلایدها اضافه کنید، تصویر بندانگشتی فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند حجم، حلقه‌دار شدن، مخفی‌سازی، برش و مدت زمان محو شدن را تنظیم کنید و صداهای مورد استفاده در انتقال‌های نمایش اسلاید را استخراج کنید.

## **Create Audio Frames**

Aspose.Slides for PHP via Java به شما امکان می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. فایل‌های صوتی به‌صورت فریم‌های صوتی در اسلایدها جاسازی می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق اندیس آن به‌دست آورید.
3. جریان فایل صوتی مورد نظر برای جاسازی در اسلاید را بارگذاری کنید.
4. فریم صوتی جاسازی شده (حاوی فایل صوتی) را به اسلاید اضافه کنید.
5. [PlayMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/AudioPlayModePreset) و `Volume` ارائه شده توسط شیء [AudioFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/) را تنظیم کنید.
6. ارائه اصلاح شده را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک فریم صوتی جاسازی شده به یک اسلاید اضافه کنید:

```php
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
$pres = new Presentation();
try {
    # اولین اسلاید را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # فایل صوتی wav را به استریم بارگذاری می‌کند
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # فریم صوتی را اضافه می‌کند
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # حالت پخش و حجم صدا را تنظیم می‌کند
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # فایل PowerPoint را روی دیسک ذخیره می‌کند
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Change the Audio Frame Thumbnail**

هنگامی که یک فایل صوتی را به یک ارائه اضافه می‌کنید، صدا به‌صورت یک فریم با تصویر پیش‌فرض استاندارد ظاهر می‌شود (تصویر در بخش زیر). می‌توانید تصویر پیش‌نمایش فریم صوتی را (تصویر دلخواه خود را) تغییر دهید.

این کد PHP نشان می‌دهد چگونه تصویر بندانگشتی یا پیش‌نمایش فریم صوتی را تغییر دهید:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# یک فریم صوتی را به اسلاید اضافه می‌کند با موقعیت و اندازه مشخص.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# یک تصویر را به منابع ارائه اضافه می‌کند.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# تصویر فریم صوتی را تنظیم می‌کند.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# ذخیرهٔ ارائهٔ اصلاح‌شده روی دیسک
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Change Audio Play Options**

Aspose.Slides for PHP via Java به شما امکان می‌دهد گزینه‌هایی که کنترل پخش یا ویژگی‌های صدا را انجام می‌دهند، تغییر دهید. به‌عنوان مثال می‌توانید حجم صدا را تنظیم کنید، صدا را به‌صورت حلقه‌ای پخش کنید یا حتی آیکون صدا را مخفی کنید.

قاب **Audio Options** در Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

گزینه‌های **Audio Options** در PowerPoint که به خواص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/) مطابقت دارند:

- فهرست کشویی **Start** متناظر با متد [AudioFrame::setPlayMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setPlayMode) است
- **Volume** متناظر با متد [AudioFrame::setVolume](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setVolume) است
- **Play Across Slides** متناظر با متد [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) است
- **Loop until Stopped** متناظر با متد [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setPlayLoopMode) است
- **Hide During Show** متناظر با متد [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setHideAtShowing) است
- **Rewind after Playing** متناظر با متد [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setRewindAudio) است

گزینه‌های **Editing** در PowerPoint که به خواص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/) مطابقت دارند:

- **Fade In** متناظر با متد [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setFadeInDuration) است
- **Fade Out** متناظر با متد [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setFadeOutDuration) است
- **Trim Audio Start Time** متناظر با متد [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setTrimFromStart) است
- مقدار **Trim Audio End Time** برابر است با مدت زمان صدا منهای مقدار متد [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setTrimFromEnd)

کنترل **Volume** در پانل کنترل صدا در PowerPoint متناظر با متد [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#setVolumeValue) است. این متد به شما اجازه می‌دهد حجم صدا را به‌صورت درصد تغییر دهید.

این‌گونه می‌توانید گزینه‌های پخش صدا را تغییر دهید:

1. [Сreate](#create-audio-frame) یا فریم صوتی را دریافت کنید.
2. مقادیر جدید برای خواص فریم صوتی که می‌خواهید تنظیم کنید، تعیین کنید.
3. فایل PowerPoint اصلاح شده را ذخیره کنید.

این کد PHP عملی را نشان می‌دهد که در آن گزینه‌های صدا تنظیم می‌شود:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # فریم صوتی را دریافت می‌کند
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # حالت پخش را برای پخش با کلیک تنظیم می‌کند
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # حجم صدا را به کم تنظیم می‌کند
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # صدا را برای پخش در تمام اسلایدها تنظیم می‌کند
    $audioFrame->setPlayAcrossSlides(true);
    # حلقه‌پخش صدا را غیرفعال می‌کند
    $audioFrame->setPlayLoopMode(false);
    # فریم صوتی را در طول نمایش اسلاید مخفی می‌کند
    $audioFrame->setHideAtShowing(true);
    # پس از پخش صدا را به ابتدا برمی‌گرداند
    $audioFrame->setRewindAudio(true);
    # فایل PowerPoint را روی دیسک ذخیره می‌کند
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

این مثال PHP نشان می‌دهد چگونه یک فریم صوتی جدید با صداهای جاسازی‌شده اضافه، برش داده و مدت‌زمان‌های محو شدن را تنظیم کنید:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // مقدار شروع برش را به 1.5 ثانیه تنظیم می‌کند
    $audioFrame->setTrimFromStart(1500);
    // مقدار انتهای برش را به 2 ثانیه تنظیم می‌کند
    $audioFrame->setTrimFromEnd(2000);

    // مدت زمان محو شدن ورودی را به 200 میلی‌ثانیه تنظیم می‌کند
    $audioFrame->setFadeInDuration(200);
    // مدت زمان محو شدن خروجی را به 500 میلی‌ثانیه تنظیم می‌کند
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه یک فریم صوتی با صداهای جاسازی‌شده دریافت و حجم آن را به 85% تنظیم کنید:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // فریم صوتی را دریافت می‌کند
    $audioFrame = $slide->getShapes()->get_Item(0);

    // حجم صدای صدا را به 85٪ تنظیم می‌کند
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Manage Audio Captions**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته به یک فریم صوتی اضافه کنید از طریق متد [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#getCaptionTracks). این متد یک شیء [CaptionsCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/) را بر می‌گرداند که به شما اجازه می‌دهد مسیرهای زیرنویس WebVTT را اضافه کنید، بین مسیرهای موجود پیمایش کنید و در صورت نیاز آن‌ها را حذف کنید.

**Add Audio Captions**

از متد [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/#getCaptionTracks) برای پیوست یک یا چند مسیر زیرنویس به فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس یک مسیر زیرنویس جدید از یک فایل `.vtt` بارگذاری می‌شود.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // یک مسیر زیرنویس جدید از فایل WebVTT اضافه می‌کند.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extract Audio Captions**

می‌توانید بین مسیرهای زیرنویس مرتبط با فریم صوتی پیمایش کنید و آن‌ها را به‌صورت فایل‌های `.vtt` ذخیره کنید. هر مسیر زیرنویس داده‌های باینری و شناسه یکتا خود را ارائه می‌دهد که هنگام استخراج زیرنویس‌ها قابل استفاده است.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // هر مسیر زیرنویس را به عنوان یک فایل .vtt ذخیره می‌کند.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Remove Audio Captions**

برای حذف زیرنویس‌ها از فریم صوتی، از متدهای ارائه‌شده توسط [CaptionsCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/) مانند [clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#clear)، [remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#removeAt) استفاده کنید. مثال زیر تمام مسیرهای زیرنویس را از یک فریم صوتی حذف می‌کند.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // نوع: AudioFrame

    // تمام مسیرهای زیرنویس را از فریم صوتی حذف می‌کند.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extract Audio**

Aspose.Slides for PHP via Java به شما اجازه می‌دهد صدای استفاده‌شده در انتقال‌های نمایش اسلاید را استخراج کنید. به‌عنوان مثال می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید و ارائه‌ای را که حاوی صدا است بارگذاری کنید.
2. مرجع اسلاید مرتبط را از طریق اندیس آن به‌دست آورید.
3. به [slideshow transitions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getSlideShowTransition) برای اسلاید دسترسی پیدا کنید.
4. صدای مورد نظر را به‌صورت داده بایتی استخراج کنید.

این کد نشان می‌دهد چگونه صدای استفاده‌شده در یک اسلاید را استخراج کنید:

```php
# یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# اسلاید مورد نظر را دریافت می‌کند
	$slide = $pres->getSlides()->get_Item(0);
	# اثرات انتقال اسلایدشو را برای اسلاید دریافت می‌کند
	$transition = $slide->getSlideShowTransition();
	# صدا را به صورت آرایه بایتی استخراج می‌کند
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Can I reuse the same audio asset across multiple slides without inflating the file size?**

بله. صدا را یک‌بار به ‌[audio collection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getaudios/) مشترک ارائه اضافه کنید و فریم‌های صوتی اضافی ایجاد کنید که به آن دارایی موجود ارجاع دهند. این کار از تکرار داده‌های رسانه‌ای جلوگیری می‌کند و اندازه ارائه را تحت کنترل نگه می‌دارد.

**Can I replace the sound in an existing audio frame without recreating the shape?**

بله. برای صدای پیوند شده، مسیر ‎[link path](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/setlinkpathlong/) را به فایل جدید تغییر دهید. برای صدای جاسازی شده، شیء ‎[embedded audio](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audioframe/setembeddedaudio/) را با دیگری از ‎[audio collection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getaudios/) ارائه تعویض کنید. قالب‌بندی فریم و اکثر تنظیمات پخش بدون تغییر باقی می‌مانند.

**Does trimming change the underlying audio data stored in the presentation?**

خیر. برش تنها مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صدا بدون تغییر باقی می‌مانند و از طریق صدای جاسازی شده یا ‎[audio collection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getaudios/) قابل دسترسی هستند.