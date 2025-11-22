---
title: "إدارة الصوت في العروض التقديمية باستخدام C#"
linktitle: "إطار صوتي"
type: docs
weight: 10
url: /ar/net/audio-frame/
keywords:
- "صوت"
- "إطار صوت"
- "صورة مصغرة"
- "إضافة صوت"
- "خصائص الصوت"
- "خيارات الصوت"
- "استخراج الصوت"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لـ .NET — أمثلة C# لتضمين الصوت، قصه، تشغيله بصورة حلقيّة، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات صوتية**

Aspose.Slides for .NET يتيح لك إضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. ضبط [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) و `Volume` المعروضة من قبل كائن [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. حفظ العرض التقديمي المعدل.

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];
    
    // تحميل ملف الصوت wav إلى الدفق
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // إضافة إطار الصوت
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // تعيين Play Mode و Volume للصوت
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // كتابة ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **تغيير صورة إطار الصوت المصغرة**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار يحمل صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المصغرة لإطار الصوت (تعيين الصورة المفضلة لديك).

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // يضيف إطار صوت إلى الشريحة بموقع وحجم محددين.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // يضيف صورة إلى موارد العرض التقديمي.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Sets the image for the audio frame.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----

    // يحفظ العرض التقديمي المعدل على القرص
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for .NET يتيح لك تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط مستوى صوت الصوت، أو ضبط تشغيل الصوت بشكل حلقي، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![مثال_صورة](audio_frame_0.png)

خيارات **الصوت** في PowerPoint التي تتCorrespond مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- **ابدأ** القائمة المنسدلة تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode)
- **الحجم** يتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume)
- **تشغيل عبر الشرائح** يتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides)
- **حلقة حتى الإيقاف** يتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode)
- **إخفاء أثناء العرض** يتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing)
- **إعادة التقديم بعد التشغيل** يتطابق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio)

خيارات **تحرير** في PowerPoint التي تتCorrespond مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- **تلاشي الدخول** يتطابق مع خاصية [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) 
- **تلاشي الخروج** يتطابق مع خاصية [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) 
- **تقليم وقت بدء الصوت** يتطابق مع خاصية [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) 
- **تقليم وقت انتهاء الصوت** يساوي مدة الصوت ناقص قيمة خاصية [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/)

متحكم **مستوى الصوت** في لوحة التحكم الصوتية في PowerPoint يتCorrespond مع خاصية [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) . يتيح لك تغيير مستوى الصوت كنسبة مئوية.

هذه هي الطريقة التي يمكنك بها تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. ضبط القيم الجديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

```csharp
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // الحصول على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // تعيين وضع التشغيل للتشغيل عند النقر
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // تعيين مستوى الصوت إلى منخفض
    audioFrame.Volume = AudioVolumeMode.Low;

    // تعيين الصوت للتشغيل عبر الشرائح
    audioFrame.PlayAcrossSlides = true;

    // تعطيل الحلقة للصوت
    audioFrame.PlayLoopMode = false;

    // إخفاء AudioFrame أثناء عرض الشرائح
    audioFrame.HideAtShowing = true;

    // إرجاع الصوت إلى البداية بعد تشغيله
    audioFrame.RewindAudio = true;

    // حفظ ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


هذا المثال في C# يوضح عملية تعديل خيارات الصوت:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يضبط إزاحة بداية التقليم إلى 1.5 ثانية
    audioFrame.TrimFromStart = 1500f;
    // يضبط إزاحة نهاية التقليم إلى 2 ثانية
    audioFrame.TrimFromEnd = 2000f;

    // يضبط مدة التلاشي التدريجي إلى 200 مللي ثانية
    audioFrame.FadeInDuration = 200f;
    // يضبط مدة التلاشي التدريجي للخروج إلى 500 مللي ثانية
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


العينة التالية تُظهر كيفية استرداد إطار صوت مدمج وتعيين مستواه إلى 85٪:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // الحصول على شكل إطار صوت
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // ضبط مستوى صوت الإطار إلى 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **استخراج الصوت**

Aspose.Slides for .NET يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة محددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة المعنية عبر فهرستها.
3. الوصول إلى انتقالات عرض الشرائح لتلك الشريحة.
4. استخراج الصوت على شكل بيانات بايت.

```c#
string presName = "AudioSlide.pptx";

// ينشئ كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation(presName);

// يصل إلى الشريحة
ISlide slide = pres.Slides[0];

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
ISlideShowTransition transition = slide.SlideShowTransition;

//يستخرج الصوت في مصفوفة بايت
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام ملف الصوت نفسه عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [مجموعة الصوت المشتركة](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) في العرض التقديمي وأنشئ إطارات صوتية إضافية تشير إلى هذا الأصل الموجود. هذا يجنب تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لصوت مرتبط، قم بتحديث [مسار الارتباط](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) للإشارة إلى الملف الجديد. بالنسبة لصوت مدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) بآخر من [مجموعة الصوت](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) في العرض التقديمي. تظل تنسيقات الإطار ومعظم إعدادات التشغيل دون تغيير.

**هل يؤدي التقليم إلى تغيير بيانات الصوت الأساسية المخزنة في العرض؟**

لا. يقتصر التقليم على تعديل حدود التشغيل فقط. تظل بايتات الصوت الأصلية دون تغيير وتكون متاحة عبر الصوت المدمج أو مجموعة الصوت في العرض التقديمي.