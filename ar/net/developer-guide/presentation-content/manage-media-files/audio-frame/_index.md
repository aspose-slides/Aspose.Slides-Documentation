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
description: "تضمين الصوت في الشرائح، تغيير أيقونة الصوت، تكوين تشغيل الصوت، إدارة تسميات WebVTT، واستخراج أصوات انتقال الشرائح باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

إطار صوتي يتيح لك تشغيل صوت على الشريحة. باستخدام Aspose.Slides for .NET، يمكنك تضمين مقطع صوتي، اختيار الصورة التي تمثله، تعديل التشغيل، وإرفاق التسميات التوضيحية. يمكنك أيضًا استرجاع الصوت المخصص لانتقال الشريحة.

## **إنشاء إطارات صوتية**

استخدم [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) لتضمين مقطع صوتي محلي على الشريحة الأولى. الإحداثيين الأوليين يحددان موضع الإطار على الشريحة، والقيمتين التاليتين تحددان عرضه وارتفاعه، كل ذلك بالنقاط. يضبط هذا المثال [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) لتشغيل المقطع تلقائيًا و[Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) إلى الإعداد العالي.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **تغيير الصورة المصغرة لإطار الصوت**

افتراضيًا، يعرض إطار الصوت أيقونة مكبر صوت. لعرض صورة مصغرة مخصصة، أضف صورة إلى العرض التقديمي باستخدام [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) وعيّنها لخاصية [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) للإطار. يستخدم المثال ملف JPEG كالصورة المصغرة للمقطع الصوتي المضمّن.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **تغيير خيارات تشغيل الصوت**

تتحكم عناصر **Audio Options** في PowerPoint في متى يبدأ المقطع، مستوى صوته، وكيفية سلوكه أثناء عرض الشرائح.

![عناصر تحكم خيارات الصوت في PowerPoint لإطار صوتي](audio_frame_0.png)

| عنصر تحكم PowerPoint | خاصية Aspose.Slides |
| --- | --- |
| بدء | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| إعداد مستوى الصوت | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| تشغيل عبر الشرائح | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| التكرار حتى الإيقاف | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| الإخفاء أثناء العرض | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| إعادة التشغيل بعد التشغيل | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| تلاشي الدخول | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| تلاشي الخروج | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| قص وقت بدء الصوت | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| قص وقت انتهاء الصوت | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| شريط مستوى الصوت | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

يبحث المثال عن أول إطار صوت على الشريحة الأولى، يضبط [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) لبدء التشغيل عند النقر، ويختار إعداد مستوى صوت منخفض. يستمر المقطع عبر الشرائح مع تعطيل التكرار. تظل الأيقونة مخفية أثناء العرض، ويُعاد تشغيل المقطع بعد الانتهاء.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

لمقاطع أطول من 3.5 ثانية، يتخطى هذا المثال الثواني 1.5 الأولى والثانيتين الأخيرة. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) يقيس المدة التي يجب حذفها من نهاية المقطع. للحصول على وقت النهاية المعروض في PowerPoint، اطرح هذا الإزاحة من مدة المقطع الكاملة. يُطبق التلاشي عند الدخول على مدى 200 مللي ثانية ويُطبق التلاشي عند الخروج على مدى 500 مللي ثانية. جميع القيم الأربعة تُقاس بالمللي ثانية.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

لتعيين حجم التشغيل إلى نسبة مئوية معينة، استخدم [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). يضبط هذا المثال أول إطار صوت على الشريحة الأولى إلى 85%.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **إدارة التسميات التوضيحية الصوتية**

كل إطار صوت يحتوي على مجموعة [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). استخدمها لإرفاق تسميات WebVTT بالمقطع، تصدير المسارات الموجودة، أو إزالتها.

### **إضافة تسميات توضيحية صوتية**

يضمّن المثال مقطعًا صوتيًا على الشريحة الأولى ويستخدم [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) لإرفاق مسار WebVTT محلي. الوسيط الأول يزود بالتصنيف، والوسيط الثاني يحدد ملف التسميات الموقوتة.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **استخراج التسميات التوضيحية الصوتية**

يصدّر هذا المثال كل مسار تسمية مرفق بإطار صوت على الشريحة الأولى. يكتب [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) للمسار إلى ملف WebVTT ويستخدم [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) كاسم للملف بحيث يكون لكل مسار مخرجات منفصلة.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **إزالة التسميات التوضيحية الصوتية**

استخدم [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) لحذف مسار فردي. يستخدم المثال [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) لإزالة جميع التسميات من أول إطار صوت على الشريحة الأولى مع الحفاظ على المقطع.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **البحث عن سطر في التسميات التوضيحية الصوتية**

للبحث عن سطر في التسميات على الشريحة الأولى، اقرأ [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) لكل مسار في الذاكرة. في إشارة WebVTT نصية، يحتوي سطر التوقيت على `-->`، تتبعه سطور التسميات، ويُنهي السطر الفارغ الإشارة. يطبع المثال تصنيف المسار وكل سطر تسمية يحتوي على كلمة “café”.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **استخراج الصوت**

يمكن لانتقال الشريحة أن يحتوي على صوت خاص به. لاسترجاعه، اقرأ خاصية [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) للانتقال. يصل المثال إلى [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) للصوت ويطبع حجمه بالبايت. إذا لم تكن الشريحة الأولى تحتوي على صوت للانتقال، يطبع رسالة بدلاً من ذلك.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس المقطع الصوتي عبر عدة شرائح دون تكراره؟**

نعم. أضف المقطع مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) للعرض التقديمي، ومرّر كائن الصوت نفسه إلى [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) لكل شريحة.

**هل يمكنني استبدال الصوت في إطار صوت موجود؟**

نعم. بالنسبة لصوت مرتبط، حدّث [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) لتشير إلى الملف البديل. بالنسبة لصوت مضمّن، عيّن مقطعًا آخر من مجموعة أصوات العرض التقديمي إلى [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). كلا النهجين يحافظان على الإطار الموجود.

**هل يؤدي القص إلى تعديل بيانات الصوت المخزنة في العرض التقديمي؟**

لا. يحدد [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) و[TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) حدود التشغيل. لا يزال بإمكانك استرجاع المقطع الكامل من [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).