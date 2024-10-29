---
title: إطار الصوت
type: docs
weight: 10
url: /ar/python-net/audio-frame/
keywords: "إضافة الصوت، إطار الصوت، خصائص الصوت، استخراج الصوت، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إضافة الصوت إلى عرض باوربوينت في بايثون"
---

## **إنشاء إطار الصوت**
تسمح لك Aspose.Slides لـ بايثون عبر .NET بإضافة ملفات الصوت إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوت.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع للشريحة من خلال مؤشرها.
3. تحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) و`Volume` التي يوفرها كائن [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/).
6. حفظ العرض المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية إضافة إطار صوت مضمن إلى شريحة:

```python
import aspose.slides as slides

# InstantiateS a presentation class that represents a presentation file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Loads the wav sound file to stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Adds the Audio Frame
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Sets the Play Mode and Volume of the Audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Writes the PowerPoint file to disk
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير صورة إطار الصوت**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار مع صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة إطار الصوت (تعيين الصورة المفضلة لديك).

يوضح لك هذا الكود بلغة بايثون كيفية تغيير صورة إطار الصوت أو صورة المعاينة:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adds an audio frame to the slide with a specified position and size.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Adds an image to presentation resources.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Sets the image for the audio frame.
        audioFrame.picture_format.picture.image = audioImage
        
        #Saves the modified presentation to disk
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير خيارات تشغيل الصوت**

تسمح لك Aspose.Slides لـ بايثون عبر .NET بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط حجم الصوت، تعيين الصوت للتشغيل بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في مايكروسوفت باوربوينت:

![example1_image](audio_frame_0.png)

خيارات الصوت في باوربوينت التي تتوافق مع خصائص [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/):
- قائمة المنسدلة **بدء** في خيارات الصوت تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- **حجم** خيارات الصوت تتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- **تشغيل عبر الشرائح** تتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- **التكرار حتى الإيقاف** تتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- **إخفاء أثناء العرض** تتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 
- **إعادة التشغيل بعد التشغيل** تتطابق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 

هذه هي الطريقة لتغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي ترغب في ضبطها.
3. حفظ ملف باوربوينت المعدل.

يوضح لك هذا الكود بلغة بايثون عملية يتم من خلالها ضبط خيارات الصوت:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Gets the AudioFrame shape
    audioFrame = pres.slides[0].shapes[0]

    # Sets the Play mode to play on click
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Sets the Volume to Low
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Sets the audio to play across slides
    audioFrame.play_across_slides = True

    # Disables loop for the audio
    audioFrame.play_loop_mode = False

    # Hides the AudioFrame during the slide show
    audioFrame.hide_at_showing = True

    # Rewinds the audio to start after playing
    audioFrame.rewind_audio = True

    # Saves the PowerPoint file to disk
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج الصوت**
تسمح لك Aspose.Slides لـ بايثون عبر .NET باستخراج الصوت المستخدم في انتقالات الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. احصل على مرجع الشريحة المعنية من خلال مؤشرها.
3. الوصول إلى انتقالات العرض للشرائح.
4. استخراج الصوت في بيانات البايت.

يوضح لك هذا الكود بلغة بايثون كيفية استخراج الصوت المستخدم في شريحة:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Accesses the desired slide
    slide = pres.slides[0]  

    # Gets the slideshow transition effects for the slide
    transition = slide.slide_show_transition

    #Extracts the sound in byte array
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```