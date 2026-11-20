---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام .NET
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/net/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- دمج فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وجذب الجمهور. تمكنك Aspose.Slides for .NET من إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint الفيديوهات المحلية والروابط إلى الفيديوهات عبر الإنترنت، مثل فيديوهات YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمن**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لدمج الفيديو في عرضك التقديمي.

هذا المثال يدمج فيديو محلي على الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بالنقاط. يبقى التيار مفتوحًا حتى يكتمل الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) يبقيه مقفلاً أثناء استخدام العرض له.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

يمكنك أيضًا تمرير مسار فيديو محلي مباشرة إلى [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). يدمج هذا المثال الفيديو على الشريحة الأولى من عرض تقديمي جديد. يجب أن يبقى الفيديو متاحًا حتى يتم حفظ العرض.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **تعيين حجم الفيديو بدقة**

في Aspose.Slides for .NET 26.11 أو أحدث، يحدد [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) نسبة مئوية ذات نقطية عائمة من 0 إلى 100. استخدمه عندما تكون إعدادات [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) العامة غير دقيقة. على سبيل المثال، `75.5f` يطلب مستوى صوت 75.5٪.

يتطلب هذا المثال [Aspose.Slides for .NET](/slides/ar/net/installation/) 26.11 أو أحدث وفيديو محلي `video.mp4`. يدمج الفيديو، يهيئ التشغيل صراحةً، يحفظ العرض، ويقرأ النسبة المخزنة مجددًا.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

تحقق من صحة الإدخال بنفسك؛ لا تعتمد على الدالة لتقليل القيم خارج النطاق الموثق. تتطابق إعدادات Low، Medium وLoud مع 20، 50 و80 في الإصدار 26.11. قد يستبدل تعيين الإعداد المسبق نسبة مئوية سابقة، لذا عيّن النسبة في النهاية عندما تحتاج إلى قيمة دقيقة. استخدم [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) للإعداد الصامت الصريح؛ الصفر الرقمي وإعداد التعداد ليسا حالة قابلة للتبادل.

عيّن صراحةً [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) عند تكوين فيديو مرتبط أيضًا، واحرص على إتاحة ملف الوسائط للمشاهد. يتحقق الحفظ وإعادة الفتح من الإعداد المخزن؛ تعتمد جودة التشغيل ومستوى الصوت الفعلي على مشغل العرض وإعداداته الصوتية.

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) الفيديوهات عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط بفيديو عبر الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. يطلب إعداد [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) تشغيلًا تلقائيًا. يتطلب تنزيل الصورة المصغرة وتشغيل الفيديو اتصالًا بالإنترنت. يجب أن يدعم عارض العرض تشغيل الفيديو عبر الإنترنت أيضًا.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **تشغيل فيديو في وضع ملء الشاشة**

في عرض تدريبي، يمكنك تشغيل عرض توضيحي للبرمجيات في وضع ملء الشاشة حتى يرى الجمهور التفاصيل. اضبط [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) إلى `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) على الشريحة الأولى، ويفعل التشغيل بملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود على الشريحة الأولى.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

يمتحن التشغيل بملء الشاشة كيفية عرض الفيديو. بصورة مستقلة، يتحكم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) فيما إذا كان يبدأ تلقائيًا أو عند النقر، ويتحكم [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) فيما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى بدايته بعد التشغيل**

في عرض تدريبي، يعيد إرجاع فيديو العرض التوضيحي إلى بدايته جعله جاهزًا للمقدم لتشغيله مرة أخرى. اضبط [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) إلى `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) على الشريحة الأولى، ويفعل الإرجاع. يعطل التكرار حتى يكتمل التشغيل ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود على الشريحة الأولى.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

إرجاع الفيديو يعيده إلى بدايته دون تشغيله مرة أخرى. بالمقابل، يكرر تمكين [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) التشغيل تلقائيًا. أبقِ التكرار معطلًا عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. يتحكم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) بصورة مستقلة في بدء التشغيل تلقائيًا أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم في توقيت بدء التشغيل. اضبط وضع التشغيل بعد إعداد التكرار، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **قَصّ إطار فيديو**

استخدم [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) و[IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم بالمللي ثانية. يغيّر القص إعدادات التشغيل دون تعديل بيانات الفيديو المضمنة.

**تعيين إعدادات القص**

يembed هذا المثال فيديو محلي ويتخطى الثانيتين والنصف الأولى والثانية الأخيرة أثناء التشغيل. استخدم فيديوًا أطول من 3.5 ثوانٍ لتبقى مقطع قابل للتشغيل.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**قراءة إعدادات القص**

يطبع هذا المثال قيم القص لإطار الفيديو الأول على الشريحة الأولى بالمللي ثانية. يجب أن يحتوي العرض على شريحة واحدة على الأقل. إذا لم تحتوي الشريحة على إطار فيديو، لا يُطبع شيء. ينتج المثال السابق قيمًا قدرها 2500 و1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **إدارة تسميات الفيديو**

تسمح لك Aspose.Slides بإدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ التسميات بتنسيق WebVTT وتُعرض عبر خاصية [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **إضافة تسميات إلى إطار فيديو**

يembed هذا المثال فيديوًا محليًا ويضيف مسار تسمية WebVTT مسمى English. يجب أن تتطابق طوابع الوقت للتسميات مع الفيديو. يتضمن العرض المحفوظ كلًا من الفيديو وتسمياته.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) أيضًا تحميلًا يتيح لك إضافة تسميات من تدفق.

### **استخراج التسميات من إطار فيديو**

يحفظ هذا المثال جميع مسارات التسميات من إطارات الفيديو على الشريحة الأولى كملفات WebVTT منفصلة. تضمن الأرقام المتسلسلة تمييز ملفات الإخراج. يُظهر وحدة التحكم عدد المسارات المستخرجة. يجب أن يحتوي العرض على شريحة واحدة على الأقل.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

كل كائن [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) يكشف عن معرف التسمية، التسمية، البيانات الثنائية، ونص التسمية كسلسلة UTF-8.

### **إزالة التسميات من إطار فيديو**

يزيل هذا المثال جميع التسميات من إطار الفيديو في أول موضع شكل على الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

إذا كنت بحاجة لإزالة مسار تسمية واحد فقط، استخدم طرق [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) بدلًا من [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **بحث عن تسميات الفيديو**

يرجع [ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) مسار WebVTT الكامل، بما في ذلك الرأس، سطور التوقيت، ونص التسمية. للعثور على عبارة منطوقة وتوقيتها، اقرأ الإشارات في الذاكرة. على سبيل المثال، قد يحتوي مسار إنجليزي على الشريحة 2 على النص التالي:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

يزور المثال كل شريحة ويقرأ مسارات إطارات الفيديو من المستوى الأعلى عبر [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). في إشارة نصية عادية، يحتوي سطر التوقيت على `-->` وينتهي سطر فارغ الإشارة. عندما يحتوي نص التسمية على “café”، يطبع المثال رقم الشريحة، تسمية المسار، سطر التوقيت الأصلي، والتسمية الكاملة.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

ينتج البحث عن “café” تطابقًا واحدًا للمسار النموذجي. العنوان وإعداد التوقيت خارج نص الإشارة.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج فيديو من شريحة**

إلى جانب إضافة الفيديوهات إلى الشرائح، تسمح لك Aspose.Slides باستخراج الفيديوهات المضمنة في العروض التقديمية.

يextract هذا المثال الفيديوهات المضمنة من كل شريحة إلى ملفات ثنائية منفصلة مرقمة. تُهمل الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمنة. يطبع وحدة التحكم نوع MIME لكل فيديو وعددها الإجمالي. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المبلغ عنه عند الحاجة.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تعديلها لإطار الفيديو؟**

يمكنك التحكم في [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (تلقائي أو عند النقر) و[looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**هل يَؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند دمج فيديو محلي، تُضمّن البيانات الثنائية في المستند، وبالتالي ينمو حجم العرض بما يتناسب مع حجم الملف. عندما تربط فيديوًا عبر الإنترنت وتضيف صورة مصغرة، يخزن العرض الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا عادةً ما يكون الزيادة أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك تبديل [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمن؟**

نعم. يحتوي الفيديو المضمن على [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.