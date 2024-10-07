---
title: إطار الصوت
type: docs
weight: 10
url: /php-java/audio-frame/
keywords: "إضافة صوت, إطار الصوت, خصائص الصوت, استخراج الصوت, جافا, Aspose.Slides لـ PHP عبر جافا"
description: "إضافة صوت إلى عرض PowerPoint"
---

## **إنشاء إطار صوت**
تتيح لك Aspose.Slides لـ PHP عبر جافا إضافة ملفات الصوت إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بتحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. قم بتعيين [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) و `Volume` التي يوفرها كائن [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame).
6. احفظ العرض المعدل.

يوضح لك هذا الكود PHP كيفية إضافة إطار صوت مضمن إلى شريحة:

```php
// Instantiates a Presentation class that represents a presentation file
  $pres = new Presentation();
  try {
    # Gets the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Loads the wav sound file to stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Adds the Audio Frame
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Sets the Play Mode and Volume of the Audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Writes the PowerPoint file to disk
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **تغيير الصورة المصغرة لإطار الصوت**

عندما تضيف ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير الصورة المعاينة لإطار الصوت (تعيين الصورة المفضلة لديك).

يوضح لك هذا الكود PHP كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Adds an audio frame to the slide with a specified position and size.
    $audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    $audioStream->close();
    # Adds an image to presentation resources.
    $picture;
    $image = Images->fromFile("eagle.jpeg");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Sets the image for the audio frame.
    $audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

    # Saves the modified presentation to disk
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **تغيير خيارات تشغيل الصوت**

تتيح لك Aspose.Slides لـ PHP عبر جافا تغيير الخيارات التي تتحكم في تشغيل الصوت أو الخصائص. على سبيل المثال، يمكنك ضبط مستوى الصوت للصوت، تعيين الصوت للتشغيل بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات الصوت في PowerPoint التي تتوافق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame):
- قائمة خيارات الصوت **البداية** المنسدلة تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayMode--) 
- خيارات الصوت **مستوى الصوت** تتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getVolume--)
- خيارات الصوت **التشغيل عبر الشرائح** تتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayAcrossSlides--)
- خيارات الصوت **التكرار حتى التوقف** تتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayLoopMode--)
- خيارات الصوت **الإخفاء أثناء العرض** تتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getHideAtShowing--)
- خيارات الصوت **إرجاع بعد التشغيل** تتطابق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getRewindAudio--)

إليك كيفية تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو احصل على إطار الصوت.
2. قم بتعيين قيم جديدة لخصائص إطار الصوت التي ترغب في ضبطها.
3. احفظ ملف PowerPoint المعدل.

يوضح لك هذا الكود PHP عملية يتم فيها ضبط خيارات الصوت:

```php
  $pres = new Presentation("AudioFrameEmbed_out.pptx");
  try {
    # Gets the AudioFrame shape
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Sets the Play mode to play on click
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Sets the volume to Low
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Sets the audio to play across slides
    $audioFrame->setPlayAcrossSlides(true);
    # Disables loop for the audio
    $audioFrame->setPlayLoopMode(false);
    # Hides the AudioFrame during the slide show
    $audioFrame->setHideAtShowing(true);
    # Rewinds the audio to start after playing
    $audioFrame->setRewindAudio(true);
    # Saves the PowerPoint file to disk
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج الصوت**

تتيح لك Aspose.Slides لـ PHP عبر جافا استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة محددة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وحمل العرض التقديمي مع انتقالات الشرائح.
2. الوصول إلى الشريحة المطلوبة.
3. الوصول إلى [انتقالات عرض الشرائح](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) للشريحة.
4. استخراج الصوت في بيانات بايت.

يوضح لك هذا الكود كيفية استخراج الصوت المستخدم في شريحة:

```php
  # Instantiates a Presentation class that represents a presentation file
  $pres = new Presentation("AudioSlide.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Accesses the desired slide
    $slide = $pres->getSlides()->get_Item(0);
    # Gets the slideshow transition effects for the slide
    $transition = $slide->getSlideShowTransition();
    # Extracts the sound in byte array
    $audio = $transition->getSound()->getBinaryData();
    echo("Length: " . $Array->getLength($audio));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```