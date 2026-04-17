---
title: إدارة إطارات الصوت في العروض التقديمية في .NET
linktitle: إطار الصوت
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
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لـ .NET—أمثلة C# للدمج والقص والتكرار وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---
## **إنشاء إطارات صوتية**

تمكنك Aspose.Slides for .NET من إضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/ar/net/aspose.slides/audioplaymodepreset) و `Volume` المعروضة بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe).
6. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود C# كيفية إضافة إطار صوت مدمج إلى شريحة:

```c#
// يُنشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];
    
    // يحمل ملف الصوت wav إلى تيار
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // يضيف إطار الصوت
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // يعيّن وضع التشغيل وحجم الصوت للإطار الصوتي
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // يكتب ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **تغيير صورة مصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير الصورة المصغرة لإطار الصوت (تعيين الصورة المفضلة لديك).

يظهر لك هذا الكود C# كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

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

    // يحدد الصورة لإطار الصوت.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// يحفظ العرض التقديمي المعدل إلى القرص
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **تغيير خيارات تشغيل الصوت**

تمكنك Aspose.Slides for .NET من تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل حجم الصوت، تعيين تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe) :

- **Start** القائمة المنسدلة تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/properties/playmode).
- **Volume** تتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/properties/volume).
- **Play Across Slides** تتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/properties/playacrossslides).
- **Loop until Stopped** تتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/properties/playloopmode).
- **Hide During Show** تتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/properties/hideatshowing).
- **Rewind after Playing** تتطابق مع خاصية [AudioFrame.RewindAudio](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/properties/rewindaudio).

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe) :

- **Fade In** تتطابق مع خاصية [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/fadeinduration/).
- **Fade Out** تتطابق مع خاصية [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/fadeoutduration/).
- **Trim Audio Start Time** تتطابق مع خاصية [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/trimfromstart/).
- **Trim Audio End Time** القيمة تساوي مدة الصوت مطروحًا منها قيمة خاصية [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/trimfromend/).

تحكم **Volume** في PowerPoint على لوحة التحكم الصوتية يتطابق مع خاصية [AudioFrame.VolumeValue](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/volumevalue/). يتيح لك تغيير مستوى الصوت كنسبة مئوية.

هذه هي طريقة تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

يعرض لك هذا الكود C# عملية تعديل خيارات الصوت:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // يعيّن وضع التشغيل للتشغيل عند النقر
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // يعيّن مستوى الصوت إلى منخفض
    audioFrame.Volume = AudioVolumeMode.Low;

    // يعيّن الصوت للتشغيل عبر الشرائح
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

يظهر لك هذا المثال C# كيفية إضافة إطار صوت جديد مع صوت مدمج، قصه، وتعيين مدة التلاشي:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يعيّن إزاحة بدء القص إلى 1.5 ثانية
    // يعيّن إزاحة نهاية القص إلى 2 ثانية
    // يعيّن مدة التلاشي التدريجي للظهور إلى 200 مللي ثانية
    // يعيّن مدة التلاشي التدريجي للاختفاء إلى 500 مللي ثانية

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

يعرض الكود التالي كيفية استرداد إطار صوت مع صوت مدمج وتعيين حجمه إلى 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // يحصل على شكل إطار صوت
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // يضبط حجم الصوت إلى 85٪
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **إدارة تسميات الصوت**

تسمح لك Aspose.Slides بإضافة تسميات توضيحية مغلقة إلى إطار الصوت عبر خاصية [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudioframe/captiontracks/) . تُعيد هذه الخاصية كائنًا من نوع [ICaptionsCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptionscollection/), مما يتيح لك إضافة مسارات تسميات WebVTT، التنقل عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة تسميات صوتية**

استخدم خاصية [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudioframe/captiontracks/) لإرفاق مسار أو أكثر من مسارات التسميات إلى إطار الصوت. في المثال التالي، يتم إضافة ملف صوت إلى شريحة، ثم يتم تحميل مسار تسميات جديد من ملف `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // أضف مسار توضيحات جديد من ملف WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**استخراج تسميات الصوت**

يمكنك التنقل عبر مسارات التسميات المرتبطة بإطار الصوت وحفظها كملفات `.vtt`. كل مسار تسميات يكشف عن بياناته الثنائية ومعرفه الفريد، والذي يمكن استخدامه عند تصدير التسميات.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // احفظ مسار التوضيح كملف .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**إزالة تسميات الصوت**

لإزالة التسميات من إطار الصوت، استخدم الأساليب المتوفرة في [ICaptionsCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptionscollection/) مثل [Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptionscollection/remove/), أو [RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptionscollection/removeat/). يوضح المثال التالي كيفية إزالة جميع مسارات التسميات من إطار الصوت.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // إزالة جميع مسارات التوضيح من إطار الصوت.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **استخراج الصوت**
تمكنك Aspose.Slides for .NET من استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى انتقالات عرض الشرائح لتلك الشريحة.
4. استخراج الصوت على شكل بيانات بايت.

يظهر لك هذا الكود C# كيفية استخراج الصوت المستخدم في شريحة:

```c#
string presName = "AudioSlide.pptx";

// ينشئ فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation(presName);

// يحصل على الشريحة
ISlide slide = pres.Slides[0];

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
ISlideShowTransition transition = slide.SlideShowTransition;

//استخراج الصوت كمصفوفة بايت
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام ملف الصوت نفسه عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/audios/) المشترك في العرض التقديمي، ثم أنشئ إطارات صوتية إضافية تشير إلى هذا الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض التقديمي تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، قم بتحديث [link path](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/linkpathlong/) للإشارة إلى الملف الجديد. بالنسبة للصوت المدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/net/aspose.slides/audioframe/embeddedaudio/) بآخر من [audio collection](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/audios/) الخاص بالعرض التقديمي. يبقى تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يغيّر القص البيانات الصوتية الأساسية المخزنة في العرض التقديمي؟**

لا. يقتصر القص على تعديل حدود تشغيل الصوت فقط. تبقى بايتات الصوت الأصلية دون تغيير ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الصوت الخاصة بالعرض التقديمي.