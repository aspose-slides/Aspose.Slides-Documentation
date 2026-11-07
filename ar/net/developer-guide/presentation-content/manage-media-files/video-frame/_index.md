---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام .NET
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/net/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- تضمين فيديو
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

يمكن للفيديوهات المساعدة في توضيح الأفكار وجذب الجمهور. يتيح Aspose.Slides for .NET إضافة إطارات الفيديو إلى الشرائح، وتعديل إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint مقاطع الفيديو المحلية والروابط إلى مقاطع الفيديو على الإنترنت، مثل مقاطع فيديو YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

هذا المثال يضمّن فيديوًا محليًا في الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بالنقاط. يبقى التدفق مفتوحًا حتى ينتهي الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) يبقيه مقفلاً أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرة إلى [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). هذا المثال يضمّن الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو قابلاً للوصول حتى يتم حفظ العرض التقديمي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **ضبط حجم الفيديو بدقة**

في Aspose.Slides for .NET 26.11 أو أحدث، يضبط [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) نسبةً عائمة من 0 إلى 100. استخدمه عندما تكون إعدادات [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) الافتراضية صحيحة جدًا. على سبيل المثال، `75.5f` يطلب حجمًا بنسبة 75.5%.

هذا المثال يتطلب [Aspose.Slides for .NET](/slides/ar/net/installation/) 26.11 أو أحدث وفيديوًا محليًا `video.mp4`. يضمّن الفيديو، يهيئ التشغيل صراحةً، يحفظ العرض التقديمي، ويقرأ النسبة المخزنة مرة أخرى.

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

تحقق من صحة الإدخال بنفسك؛ لا تعتمد على المعدِّل لرفض القيم خارج النطاق الموثّق. تمثّل إعدادات منخفض، متوسط وعالي القيم 20 و50 و80 في الإصدار 26.11. قد يستبدل ضبط إعداد مسبق النسبة السابقة، لذا قم بتعيين النسبة في النهاية عندما تحتاج إلى قيمة دقيقة. استخدم [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) لتفعيل كتم صريح؛ الصفر الرقمي وإعداد enum المسبق ليست حالات قابلة للتبادل.

اضبط صراحةً [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) عند تكوين فيديو مرتبط أيضًا، وحافظ على توفر ملف الوسائط للمشاهد. يضمن الحفظ وإعادة الفتح الإعداد المخزن؛ يعتمد التشغيل الفعلي ومستوى الصوت على مشغل العرض التقديمي وإعدادات الصوت الخاصة به.

## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط إلى فيديو على الإنترنت، مثل فيديو YouTube.

هذا المثال يضيف رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. يطلب إعداد [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) تشغيلًا تلقائيًا. تنزيل الصورة المصغرة وتشغيل الفيديو يتطلبان اتصالًا بالإنترنت. يجب أن يدعم مشاهد العرض التقديمي تشغيل الفيديو عبر الإنترنت أيضًا.

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

## **تشغيل فيديو في وضع الشاشة الكاملة**

في عرض تقديمي تعليمي، يمكنك تشغيل توضيح برمجي في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. اضبط [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) إلى `true` لتمكين هذا السلوك أثناء التشغيل.

هذا المثال يفتح عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعل تشغيل ملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

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

تحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، يتحكم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) فيما إذا كان يبدأ تلقائيًا أو عند النقر، ويتحكم [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) فيما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إعادة الفيديو إلى البداية بعد التشغيل**

في عرض تقديمي تعليمي، إرجاع فيديو التوضيح إلى بدايته يجعله جاهزًا للمُقدِّم لتشغيله مرة أخرى. اضبط [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) إلى `true` لإعادة الفيديو إلى البداية بعد انتهاء التشغيل.

هذا المثال يفتح عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعل الإرجاع. يعطل التكرار حتى يتمكن التشغيل من الانتهاء ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

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

الإرجاع يعيد الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، تمكين [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) يكرر التشغيل تلقائيًا. حافظ على تعطيل التكرار عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. يتحكم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) بشكل مستقل في بدء التشغيل تلقائيًا أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) لتحديد متى يبدأ المشغِّل. اضبط وضع التشغيل بعد ضبط الإعداد التكراري، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **قَصُّ إطار فيديو**

استخدم [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) و[IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم بالملليثانية. يغيّر القص إعدادات التشغيل دون تعديل بيانات الفيديو المضمّنة.

**ضبط إعدادات القص**

هذا المثال يضمّن فيديوًا محليًا ويتخطى الثواني 2.5 الأولى والثانية الأخيرة أثناء التشغيل. استخدم فيديوًا أطول من 3.5 ثوانٍ لضمان بقاء جزء قابل للتشغيل.

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

هذا المثال يطبع قيم القص لأول إطار فيديو في الشريحة الأولى بالملليثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لا يُطبع شيء. ينتج المثال السابق القيم 2500 و1000.

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

تسمح Aspose.Slides لك بإدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بتنسيق WebVTT وتتاح عبر خاصية [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**إضافة تسميات إلى إطار فيديو**

هذا المثال يضمّن فيديوًا محليًا ويضيف مسار تسمية WebVTT مُعنونًا بـ English. يجب أن تتطابق طوابع الوقت للتسمية مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًا من الفيديو وتسمياته.

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

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) أيضًا نسخة إضافية تسمح لك بإضافة التسميات من تدفق بيانات.

**استخراج التسميات من إطار فيديو**

هذا المثال يحفظ جميع مسارات التسميات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. الأرقام المتتالية تحافظ على تمييز ملفات الإخراج. يوضح وحدة التحكم عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) يكشف عن معرف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

هذا المثال يزيل جميع التسميات من إطار الفيديو في أول موضع شكل في الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

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

إذا احتجت إلى إزالة مسار تسمية واحد فقط، استخدم طريقتي [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) بدلًا من [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **استخراج الفيديو من شريحة**

إلى جانب إضافة فيديوهات إلى الشرائح، تتيح Aspose.Slides استخراج الفيديوهات المضمنة في العروض التقديمية.

هذا المثال يستخرج الفيديوهات المضمَّنة من كل شريحة إلى ملفات ثنائية منفصلة مرقَّمة. يتم تخطي الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمَّنة. تطبع وحدة التحكم نوع MIME لكل فيديو والإجمالي. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المبلغ عنه عند الحاجة.

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

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). هذه الخيارات متوفرة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُضاف البيانات الثنائية إلى المستند، لذا يزيد حجم العرض التقديمي بما يتناسب مع حجم الملف. عندما تربط إلى فيديو على الإنترنت وتضيف صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة في الحجم أصغر عادةً.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. يحتوي الفيديو المضمّن على [نوع محتوى](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.