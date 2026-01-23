---
title: إدارة الصوت في العروض التقديمية باستخدام PHP
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/php-java/audio-frame/
keywords:
- الصوت
- إطار الصوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- PHP
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides للـ PHP — أمثلة على الشيفرات لتضمين الصوت، تقليمه، تشغيله بتكرار، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات صوتية**

Aspose.Slides لـ PHP عبر Java يسمح لك بإضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. حمّل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. عيّن [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) و`Volume` من الكائن [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/).
6. احفظ العرض المعدل.

هذا الكود PHP يوضح لك كيفية إضافة إطار صوت مدمج إلى شريحة:
```php
// ينشئ كائنًا من فئة Presentation تمثل ملف عرض تقديمي
$pres = new Presentation();
try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحمل ملف الصوت wav إلى دفق
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # يضيف إطار الصوت
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # يحدد وضع التشغيل وحجم الصوت للإطار الصوتي
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

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار يحمل صورة قياسية افتراضية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تعيين الصورة المفضلة لديك).

هذا الكود PHP يوضح لك كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:
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

Aspose.Slides لـ PHP عبر Java يسمح لك بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط مستوى الصوت، تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![صورة_مثال1](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/):

- **بدء** القائمة المنسدلة تتطابق مع طريقة [AudioFrame::setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode).
- **حجم** يتطابق مع طريقة [AudioFrame::setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume).
- **تشغيل عبر الشرائح** يتطابق مع طريقة [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **تكرار حتى الإيقاف** يتطابق مع طريقة [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode).
- **إخفاء أثناء العرض** يتطابق مع طريقة [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing).
- **إعادة اللف بعد التشغيل** يتطابق مع طريقة [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio).

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/):

- **تلاشي الدخول** يتطابق مع طريقة [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration).
- **تلاشي الخروج** يتطابق مع طريقة [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration).
- **تقليم وقت بدء الصوت** يتطابق مع طريقة [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart).
- **تقليم وقت انتهاء الصوت** يساوي مدة الصوت ناقص القيمة التي تم ضبطها عبر طريقة [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd).

التحكم **في حجم الصوت** في PowerPoint على لوحة التحكم الصوتية يتطابق مع طريقة [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). يتيح لك تعديل حجم الصوت كنسبة مئوية.

هذه هي الطريقة التي يمكنك من خلالها تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. عيّن قيمًا جديدة للخصائص الخاصة بإطار الصوت التي تريد تعديلها.
3. احفظ ملف PowerPoint المعدل.

هذا الكود PHP يوضح عملية ضبط خيارات الصوت:
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


هذا المثال PHP يوضح كيفية إضافة إطار صوت جديد مع صوت مدمج، تقليم الصوت، وتعيين مدة التلاشي:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // يضبط إزاحة بداية القطع إلى 1.5 ثانية
    $audioFrame->setTrimFromStart(1500);
    // يضبط إزاحة نهاية القطع إلى 2 ثانية
    $audioFrame->setTrimFromEnd(2000);

    // يضبط مدة التلاشي التدريجي إلى 200 مللي ثانية
    $audioFrame->setFadeInDuration(200);
    // يضبط مدة التلاشي الخارج إلى 500 مللي ثانية
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


العينة التالية توضح كيفية استرداد إطار صوت مدمج وتعيين مستوى الصوت إلى 85٪:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // يحصل على شكل إطار صوتي
    $audioFrame = $slide->getShapes()->get_Item(0);

    // يضبط حجم الصوت إلى 85٪
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **استخراج الصوت**

Aspose.Slides لـ PHP عبر Java يسمح لك باستخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. احصل على مرجع الشريحة المطلوبة عبر فهرستها.
3. الوصول إلى [انتقالات عرض الشرائح](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) لتلك الشريحة.
4. استخراج الصوت على شكل بيانات بايت.

هذا الكود يوضح لك كيفية استخراج الصوت المستخدم في شريحة:
```php
# ينشئ كائنًا من فئة Presentation تمثل ملف عرض تقديمي
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# يقوم بالوصول إلى الشريحة المطلوبة
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


## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى مجموعة الصوت المشتركة في العرض التقديمي ثم أنشئ إطارات صوت إضافية تشير إلى ذلك العنصر. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، حدّث مسار الرابط للإشارة إلى الملف الجديد. بالنسبة للصوت المدمج، استبدل كائن الصوت المدمج بآخر من مجموعة الصوت في العرض التقديمي. سيبقى تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي تقليم الصوت إلى تغيير البيانات الصوتية الأساسية المخزنة في العرض التقديمي؟**

لا. يقوم التقليم بتعديل حدود التشغيل فقط. تبقى بايتات الصوت الأصلية دون تعديل ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الصوت في العرض.