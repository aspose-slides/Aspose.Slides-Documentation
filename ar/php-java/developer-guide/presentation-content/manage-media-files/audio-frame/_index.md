---
title: إدارة الصوت في العروض التقديمية باستخدام PHP
linktitle: إطار صوت
type: docs
weight: 10
url: /ar/php-java/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- PHP
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لـ PHP—أمثلة على الشيفرة لتضمين الصوت، قصه، تشغيله بشكل متكرر، وتكوين تشغيله عبر عروض PPT و PPTX و ODP."
---
## **إنشاء إطارات صوتية**

يتيح لك Aspose.Slides for PHP عبر Java إضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرستها.
3. حمّل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمّن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. عيّن [PlayMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/AudioPlayModePreset) و `Volume` المعروضين من قبل كائن [AudioFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/) .
6. احفظ العرض المعدّل.

يعرض هذا الكود PHP كيفية إضافة إطار صوت مضمّن إلى شريحة:

```php
// ينشئ كائن من فئة Presentation يمثل ملف عرض تقديمي
$pres = new Presentation();
try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحمل ملف الصوت wav إلى تدفق
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # يضيف إطار الصوت
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # يحدد وضع التشغيل ومستوى الصوت
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # يكتب ملف PowerPoint إلى القرص
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **تغيير الصورة المصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار مع صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة معاينة إطار الصوت (تعيين الصورة المفضلة لديك).

يعرض هذا الكود PHP كيفية تغيير صورة مصغرة أو صورة معاينة لإطار الصوت:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# يضيف إطار صوت إلى الشريحة بموقع وحجم محددين.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# يضيف صورة إلى موارد العرض التقديمي.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# يحدد الصورة لإطار الصوت.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# يحفظ العرض التقديمي المعدل إلى القرص
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **تغيير خيارات تشغيل الصوت**

يتيح لك Aspose.Slides for PHP عبر Java تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى صوت الصوت، تعيين تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **خيارات الصوت** التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/) :

- **Start** قائمة منسدلة تتطابق مع طريقة [AudioFrame::setPlayMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setPlayMode) .
- **Volume** تتطابق مع طريقة [AudioFrame::setVolume](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setVolume) .
- **Play Across Slides** تتطابق مع طريقة [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) .
- **Loop until Stopped** تتطابق مع طريقة [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setPlayLoopMode) .
- **Hide During Show** تتطابق مع طريقة [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setHideAtShowing) .
- **Rewind after Playing** تتطابق مع طريقة [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setRewindAudio) .

PowerPoint **تحرير** التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/) :

- **Fade In** تتطابق مع طريقة [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setFadeInDuration) .
- **Fade Out** تتطابق مع طريقة [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setFadeOutDuration) .
- **Trim Audio Start Time** تتطابق مع طريقة [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setTrimFromStart) .
- **Trim Audio End Time** قيمة تساوي مدة الصوت مطروحًا منها قيمة طريقة [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setTrimFromEnd) .

تحكم **التحكم في مستوى الصوت** في PowerPoint على لوحة التحكم الصوتية يتطابق مع طريقة [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#setVolumeValue) . يتيح لك تعديل مستوى الصوت كنسبة مئوية.

هذه هي الطريقة التي يمكنك من خلالها تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. عيّن قيمًا جديدة للخصائص التي تريد تعديلها في إطار الصوت.
3. احفظ ملف PowerPoint المعدل.

هذا الكود PHP يوضح عملية تعديل خيارات الصوت:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # يحصل على شكل AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # يحدد وضع التشغيل لتشغيل عند النقر
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # يحدد مستوى الصوت إلى منخفض
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # يحدد تشغيل الصوت عبر الشرائح
    $audioFrame->setPlayAcrossSlides(true);
    # يعطل التكرار للصوت
    $audioFrame->setPlayLoopMode(false);
    # يخفِ إطار الصوت أثناء عرض الشرائح
    $audioFrame->setHideAtShowing(true);
    # يُعيد تشغيل الصوت من البداية بعد الانتهاء
    $audioFrame->setRewindAudio(true);
    # يحفظ ملف PowerPoint إلى القرص
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

هذا مثال PHP يوضح كيفية إضافة إطار صوت جديد مع صوت مضمّن، قصه، وتعيين مدة التلاشي:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // يحدد إزاحة بداية القص إلى 1.5 ثانية
    $audioFrame->setTrimFromStart(1500);
    // يحدد إزاحة نهاية القص إلى ثانيتين
    $audioFrame->setTrimFromEnd(2000);

    // يحدد مدة التلاشي التدريجي في البداية إلى 200 مللي ثانية
    $audioFrame->setFadeInDuration(200);
    // يحدد مدة التلاشي التدريجي في النهاية إلى 500 مللي ثانية
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

العينة التالية من الشيفرة توضح كيفية استرجاع إطار صوت مضمّن وتعيين مستوى صوته إلى 85٪:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // يحصل على شكل إطار صوتي
    $audioFrame = $slide->getShapes()->get_Item(0);

    // يحدد مستوى صوت الإطار إلى 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **إدارة تسميات الصوت**

يتيح لك Aspose.Slides إضافة تسميات توضيحية مغلقة إلى إطار الصوت عبر الطريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#getCaptionTracks) . تُعيد هذه الطريقة كائن [CaptionsCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/)، الذي يتيح لك إضافة مسارات تسميات WebVTT، والتجول عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة تسميات صوتية**

استخدم الطريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/#getCaptionTracks) لإرفاق مسار أو أكثر من مسارات التسميات إلى إطار الصوت. في المثال التالي، يُضاف ملف صوت إلى شريحة، ثم يُحمَّل مسار تسمية جديد من ملف `.vtt` .

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // أضف مسار تسمية توضيحية جديد من ملف WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**استخراج تسميات الصوت**

يمكنك التجول عبر مسارات التسميات المرتبطة بإطار الصوت وحفظها كملفات `.vtt` . كل مسار تسمية يكشف عن بياناته الثنائية والمعرف الفريد الخاص به، ويمكن استخدامهما عند تصدير التسميات.

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
                // احفظ كل مسار تسمية توضيحية كملف .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**إزالة تسميات الصوت**

لإزالة التسميات من إطار الصوت، استخدم الطرق المتوفرة في [CaptionsCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/) مثل [clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#clear) ، [remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#removeAt) . المثال التالي يزيل جميع مسارات التسميات من إطار الصوت.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // النوع: AudioFrame

    // إزالة جميع مسارات التسمية التوضيحية من إطار الصوت.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استخراج الصوت**

يتيح لك Aspose.Slides for PHP عبر Java استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. احصل على مرجع الشريحة ذات الصلة من خلال فهرستها.
3. الوصول إلى [slideshow transitions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#getSlideShowTransition) الخاصة بالشريحة.
4. استخراج الصوت على شكل بيانات بايت.

هذا الكود يوضح كيفية استخراج الصوت المستخدم في شريحة:

```php
# ينشئ كائنًا من فئة Presentation يمثل ملف عرض تقديمي
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# الوصول إلى الشريحة المطلوبة
	$slide = $pres->getSlides()->get_Item(0);
	# يحصل على تأثيرات انتقال عرض الشرائح للشريحة
	$transition = $slide->getSlideShowTransition();
	# يستخرج الصوت كمصفوفة بايت
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام ملف الصوت نفسه عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getaudios/) المشترك للعرض، ثم أنشئ إطارات صوت إضافية تشير إلى ذلك العنصر الموجود. وهذا يمنع تكرار بيانات الوسائط ويُحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، قم بتحديث [link path](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/setlinkpathlong/) للإشارة إلى الملف الجديد. بالنسبة للصوت المضمّن، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audioframe/setembeddedaudio/) بآخر من [audio collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getaudios/) للعرض. ستظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي القص إلى تغيير بيانات الصوت الأصلية المخزنة في العرض؟**

لا. يقتصر قص الصوت على تعديل حدود التشغيل فقط. تظل بايتات الصوت الأصلية سليمّة ويمكن الوصول إليها عبر الصوت المضمّن أو مجموعة أصوات العرض.