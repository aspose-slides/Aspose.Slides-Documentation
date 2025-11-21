---
title: إدارة إطارات الصوت في العروض التقديمية في .NET
linktitle: إطار صوت
type: docs
weight: 10
url: /ar/net/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- .NET
- C#
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides للـ .NET—أمثلة C# لتضمين الصوت، قصه، تشغيله بشكل متكرر، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات صوتية**

Aspose.Slides for .NET يتيح لك إضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية. 

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع الشريحة عبر فهرسها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) و `Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. حفظ العرض التقديمي المعدل.

```c#
// ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];
    
    // يحمل ملف الصوت wav إلى تدفق
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // يحدد وضع التشغيل ومستوى الصوت للملف الصوتي
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // يكتب ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```


## **تغيير صورة المصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المصغرة لإطار الصوت (تعيين الصورة المفضلة لديك).

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

    // يحدد الصورة لإطار الصوت. // <-----
	
	//يحفظ العرض التقديمي المعدل إلى القرص
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for .NET يتيح لك تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى صوت الصوت، ضبط تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- **Start** قائمة منسدلة تتطابق مع الخاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode)
- **Volume** تتطابق مع الخاصية [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume)
- **Play Across Slides** تتطابق مع الخاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides)
- **Loop until Stopped** تتطابق مع الخاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode)
- **Hide During Show** تتطابق مع الخاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing)
- **Rewind after Playing** تتطابق مع الخاصية [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio)

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe):

- **Fade In** تتطابق مع الخاصية [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/)
- **Fade Out** تتطابق مع الخاصية [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/)
- **Trim Audio Start Time** تتطابق مع الخاصية [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/)
- **Trim Audio End Time** القيمة تساوي مدة الصوت مطروحاً منها قيمة الخاصية [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/)

**Volume controll** في لوحة التحكم الصوتية في PowerPoint يتطابق مع الخاصية [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/). يسمح لك بتغيير مستوى الصوت كنسبة مئوية.

وهذا هو طريقة تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة للخصائص التي تريد تعديلها في إطار الصوت.
3. حفظ ملف PowerPoint المعدل.

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // يحدد وضع التشغيل ليتم عند النقر
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // يحدد مستوى الصوت إلى منخفض
    audioFrame.Volume = AudioVolumeMode.Low;

    // يحدد تشغيل الصوت عبر الشرائح
    audioFrame.PlayAcrossSlides = true;

    // يعطل التكرار للصوت
    audioFrame.PlayLoopMode = false;

    // يخفي AudioFrame أثناء عرض الشرائح
    audioFrame.HideAtShowing = true;

    // يعيد الصوت إلى البداية بعد التشغيل
    audioFrame.RewindAudio = true;

    // يحفظ ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يحدد إزاحة بدء القص إلى 1.5 ثانية
    audioFrame.TrimFromStart = 1500f;
    // يحدد إزاحة انتهاء القص إلى 2 ثانية
    audioFrame.TrimFromEnd = 2000f;

    // يحدد مدة التلاشي التدريجي إلى 200 مللي ثانية
    audioFrame.FadeInDuration = 200f;
    // يحدد مدة التلاشي التدريجي إلى 500 مللي ثانية
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // يحصل على شكل إطار صوت
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // يحدد مستوى الصوت إلى 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **استخراج الصوت**

Aspose.Slides for .NET يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة المطلوبة عبر فهرسها.
3. الوصول إلى انتقالات عرض الشرائح للشريحة.
4. استخراج الصوت في بيانات بايت.

```c#
string presName = "AudioSlide.pptx";

// ينشئ كائن من فئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation(presName);

// الوصول إلى الشريحة
ISlide slide = pres.Slides[0];

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
ISlideShowTransition transition = slide.SlideShowTransition;

//يستخرج الصوت في مصفوفة بايت
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) المشترك في العرض التقديمي وأنشئ إطارات صوتية إضافية تُشير إلى هذا الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لصوت مرتبط، قم بتحديث [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) للإشارة إلى الملف الجديد. بالنسبة لصوت مدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) بآخر من [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) في العرض. يبقى تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي القص إلى تغيير بيانات الصوت الأساسية المخزنة في العرض؟**

لا. القص يضبط فقط حدود التشغيل. تبقى بايتات الصوت الأصلية بدون تغيير ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الأصوات في العرض.