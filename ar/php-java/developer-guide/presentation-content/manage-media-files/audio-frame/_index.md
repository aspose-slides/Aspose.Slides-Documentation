---
title: إدارة الصوت في العروض التقديمية باستخدام PHP
linktitle: إطار صوت
type: docs
weight: 10
url: /ar/php-java/audio-frame/
keywords:
- صوت
- إطار صوت
- مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- PHP
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides for PHP — أمثلة شفرة لتضمين، قص، تكرار، وتكوين تشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات صوتية**

Aspose.Slides for PHP via Java يتيح لك إضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء مثيل من فئة [العرض](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (المحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [وضع التشغيل](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame).
6. حفظ العرض المعدَّل.

هذا الكود PHP يوضح لك كيفية إضافة إطار صوت مدمج إلى شريحة:
```php
// ينشئ كائن من فئة Presentation التي تمثل ملف عرض تقديمي
$pres = new Presentation();
try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحمل ملف الصوت wav إلى تدفق
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # يضيف إطار الصوت
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # يضبط وضع التشغيل ومستوى الصوت للملف الصوتي
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # يكتب ملف PowerPoint إلى القرص
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **تغيير صورة إطارة الصوت المصغرة**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين الصورة التي تفضّلها).

هذا الكود PHP يوضح لك كيفية تغيير صورة المصغرة أو صورة المعاينة لإطار صوت:
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
	# يعيّن الصورة لإطار الصوت.
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

Aspose.Slides for PHP via Java يتيح لك تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط حجم الصوت، جعل الصوت يتكرر تشغيله، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**خيارات الصوت** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/):

- قائمة **Start** المنسدلة تتطابق مع الطريقة [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** يتطابق مع الطريقة [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** يتطابق مع الطريقة [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** يتطابق مع الطريقة [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** يتطابق مع الطريقة [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** يتطابق مع الطريقة [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio)

خيارات **التحرير** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/):

- **Fade In** يتطابق مع الطريقة [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** يتطابق مع الطريقة [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** يتطابق مع الطريقة [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- قيمة **Trim Audio End Time** تساوي مدة الصوت مطروحًا منها القيمة التي تُحدَّد عبر الطريقة [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd)

متحكم **حجم الصوت** في لوحة التحكم الصوتي في PowerPoint يتطابق مع الطريقة [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). يتيح لك تغيير حجم الصوت كنسبة مئوية.

هذه هي طريقة تعديل خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة للخصائص التي تريد تعديلها في إطار الصوت.
3. حفظ ملف PowerPoint المعدَّل.

هذا الكود PHP يوضح عملية ضبط خيارات الصوت:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # يحصل على شكل AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # يضبط وضع التشغيل لتشغيل عند النقر
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # يضبط مستوى الصوت إلى منخفض
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # يضبط تشغيل الصوت عبر الشرائح
    $audioFrame->setPlayAcrossSlides(true);
    # يعطل التكرار للصوت
    $audioFrame->setPlayLoopMode(false);
    # يخفي AudioFrame أثناء عرض الشرائح
    $audioFrame->setHideAtShowing(true);
    # يعيد الصوت إلى البداية بعد التشغيل
    $audioFrame->setRewindAudio(true);
    # يحفظ ملف PowerPoint إلى القرص
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


هذا المثال PHP يوضح كيفية إضافة إطار صوت جديد مع صوت مدمج، قصه، وتعيين فترات التلاشي:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // يضبط إزاحة بداية القص إلى 1.5 ثانية
    $audioFrame->setTrimFromStart(1500);
    // يضبط إزاحة نهاية القص إلى 2 ثانية
    $audioFrame->setTrimFromEnd(2000);

    // يضبط مدة التلاشي التدريجي (fade‑in) إلى 200 مللي ثانية
    $audioFrame->setFadeInDuration(200);
    // يضبط مدة التلاشي الخارجى (fade‑out) إلى 500 مللي ثانية
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


العينة البرمجية التالية توضح كيفية استرجاع إطار صوت مدمج وتعيين حجمه إلى 85 %:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // يحصل على شكل إطار صوت
    $audioFrame = $slide->getShapes()->get_Item(0);

    // يضبط حجم الصوت إلى 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **استخراج الصوت**

Aspose.Slides for PHP via Java يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من فئة [العرض](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة من خلال فهرستها.
3. الوصول إلى [انتقالات عرض الشرائح](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) لتلك الشريحة.
4. استخراج الصوت على شكل بيانات بايت.

هذا الكود يوضح لك كيفية استخراج الصوت المستخدم في شريحة:
```php
# ينشئ كائن من فئة Presentation التي تمثل ملف عرض تقديمي
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# الوصول إلى الشريحة المطلوبة
	$slide = $pres->getSlides()->get_Item(0);
	# يحصل على تأثيرات انتقال عرض الشرائح للشريحة
	$transition = $slide->getSlideShowTransition();
	# يستخرج الصوت في مصفوفة بايت
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


## **FAQ**

**هل يمكنني إعادة استخدام ملف الصوت نفسه عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى **مجموعة الصوت المشتركة** في العرض عبر [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) ثم أنشئ إطارات صوت إضافية تُشير إلى تلك الأصول الموجودة. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لصوت مرتبط، حدّث مسار [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) للإشارة إلى الملف الجديد. بالنسبة لصوت مدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) بآخر من [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) للعرض. يبقى تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يغيّر القص البيانات الصوتية الأساسية المخزَّنة في العرض؟**

لا. يقتصر القص على تعديل حدود التشغيل فقط. تبقى بايتات الصوت الأصلية دون تعديل ويمكن الوصول إليها من خلال الصوت المدمج أو مجموعة الصوت في العرض.