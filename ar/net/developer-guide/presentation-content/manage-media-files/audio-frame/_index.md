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
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides for .NET—أمثلة C# لتضمين، قص، تشغيل متكرر، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات الصوت**

Aspose.Slides for .NET يسمح لك بإضافة ملفات صوتية إلى الشرائح. تُضمن ملفات الصوت في الشرائح كإطارات صوتية. 

1. إنشاء كائن من الفئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. تحميل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) و `Volume` المعروضة بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe).
6. حفظ العرض التقديمي المعدل.

هذا الكود بلغة C# يوضح كيفية إضافة إطار صوت مضمن إلى شريحة:
```c#
 // إنشاء كائن من فئة العرض التي تمثل ملف عرض تقديمي
 using (Presentation pres = new Presentation())
 {
     // الحصول على الشريحة الأولى
     ISlide sld = pres.Slides[0];
     
     // تحميل ملف صوت wav إلى دفق
     FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

     // إضافة إطار الصوت
     IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

     // تعيين وضع التشغيل ومستوى الصوت للإطار
     audioFrame.PlayMode = AudioPlayModePreset.Auto;
     audioFrame.Volume = AudioVolumeMode.Loud;

     // حفظ ملف PowerPoint إلى القرص
     pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
 }
```


## **تغيير صورة مصغرة لإطار الصوت**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار مع صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة الإطار المصغرة (ضبط الصورة المفضلة لديك).

هذا الكود بلغة C# يوضح كيفية تغيير صورة مصغرة أو صورة معاينة لإطار الصوت:
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

    // يضبط الصورة لإطار الصوت.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//يحفظ العرض التقديمي المعدل إلى القرص
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for .NET يتيح لك تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى الصوت، ضبط تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات الصوت في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) :

- **Start** قائمة منسدلة تتطابق مع خاصية [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) 
- **Volume** تتطابق مع خاصية [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) 
- **Play Across Slides** يتطابق مع خاصية [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) 
- **Loop until Stopped** يتطابق مع خاصية [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) 
- **Hide During Show** يتطابق مع خاصية [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) 
- **Rewind after Playing** يتطابق مع خاصية [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) 

خيارات التحرير في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) :

- **Fade In** يتطابق مع خاصية [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) 
- **Fade Out** يتطابق مع خاصية [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) 
- **Trim Audio Start Time** يتطابق مع خاصية [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) 
- **Trim Audio End Time** القيمة تساوي مدة الصوت مطروحاً منها قيمة خاصية [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) 

شريط التحكم في مستوى الصوت في PowerPoint **Volume controll** يتوافق مع خاصية [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) . يتيح لك تعديل مستوى الصوت كنسبة مئوية.

هذه هي طريقة تغيير خيارات تشغيل الصوت:

1. [إنشاء أو الحصول على إطار الصوت](#create-audio-frame).
2. ضبط القيم الجديدة لخصائص إطار الصوت التي ترغب في تعديلها.
3. حفظ ملف PowerPoint المعدل.

هذا الكود بلغة C# يوضح عملية تعديل خيارات الصوت:
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // يحصل على شكل AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // يضبط وضع التشغيل لتشغيله عند النقر
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // يضبط مستوى الصوت إلى منخفض
    audioFrame.Volume = AudioVolumeMode.Low;

    // يضبط تشغيل الصوت عبر الشرائح
    audioFrame.PlayAcrossSlides = true;

    // يعطل تكرار الصوت
    audioFrame.PlayLoopMode = false;

    // يخفي AudioFrame أثناء عرض الشرائح
    audioFrame.HideAtShowing = true;

    // يُعيد الصوت إلى البداية بعد التشغيل
    audioFrame.RewindAudio = true;

    // يحفظ ملف PowerPoint إلى القرص
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


هذا المثال بلغة C# يوضح كيفية إضافة إطار صوت جديد مع صوت مدمج، قصه، وتحديد فترات التلاشي:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // يضبط إزاحة بدء القص إلى 1.5 ثانية
    audioFrame.TrimFromStart = 1500f;
    // يضبط إزاحة نهاية القص إلى 2 ثانية
    audioFrame.TrimFromEnd = 2000f;

    // يضبط مدة التلاشي عند البدء إلى 200 مللي ثانية
    audioFrame.FadeInDuration = 200f;
    // يضبط مدة التلاشي عند الانتهاء إلى 500 مللي ثانية
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


العينة التالية للشفرة توضح كيفية استخراج إطار صوت مدمج وتعيين مستوى الصوت إلى 85%:
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // يحصل على شكل إطار صوتي
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // يضبط مستوى صوت الإطار إلى 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **استخراج الصوت**
Aspose.Slides for .NET يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى انتقالات عرض الشرائح لتلك الشريحة.
4. استخراج الصوت على شكل بيانات بايت.

هذا الكود بلغة C# يوضح كيفية استخراج الصوت المستخدم في شريحة:
```c#
string presName = "AudioSlide.pptx";

// ينشئ كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation(presName);

// الوصول إلى الشريحة
ISlide slide = pres.Slides[0];

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
ISlideShowTransition transition = slide.SlideShowTransition;

// استخراج الصوت كمصفوفة بايت
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى مجموعة الصوت المشتركة في العرض التقديمي ثم أنشئ إطارات صوت إضافية تشير إلى ذلك الأصل. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، حدّث مسار الرابط [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) ليشير إلى الملف الجديد. بالنسبة للصوت المدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/) بآخر من مجموعة الصوت في العرض التقديمي. يبقى تنسيق الإطار ومعظم إعدادات التشغيل كما هو.

**هل يؤدي القص إلى تغيير بيانات الصوت الأساسية المخزنة في العرض التقديمي؟**

لا. يقتصر القص على تعديل حدود التشغيل فقط. تظل بايتات الصوت الأصلية دون تغيير ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الصوت في العرض التقديمي.