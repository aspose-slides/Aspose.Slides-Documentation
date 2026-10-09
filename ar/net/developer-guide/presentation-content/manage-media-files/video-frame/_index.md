---
title: إدارة إطارات الفيديو في العروض التقديمية في .NET
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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وجذب الجمهور. يتيح Aspose.Slides لـ .NET إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة الترجمات، واستخراج بيانات الفيديو المضمّن.

يدعم PowerPoint مقاطع الفيديو المحلية والروابط إلى مقاطع الفيديو عبر الإنترنت، مثل مقاطع فيديو YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزّناً محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

يقوم هذا المثال بتضمين فيديو محلي في الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدة النقاط. يبقى التدفق مفتوحًا حتى انتهاء الحفظ لأن [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) يبقيه مقفلاً أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرةً إلى [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). يقوم هذا المثال بتضمين الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يبقى الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يرتبط بفيديو عبر الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. يطلب إعداد [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) تشغيلًا تلقائيًا. يتطلب تنزيل الصورة المصغرة وتشغيل الفيديو اتصالًا بالإنترنت. يجب أن يدعم عارض العرض التقديمي تشغيل الفيديو عبر الإنترنت أيضًا.

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

في عرض تقديمي تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. اضبط [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) إلى `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعّل تشغيل ملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

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

يتحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، يتحكم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) فيما إذا كان يبدأ تلقائيًا أو عند النقر، ويتحكم [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) فيما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تقديمي تدريبي، إرجاع فيديو العرض التوضيحي إلى بدايته يجعله جاهزًا للمقدم لتشغيله مرة أخرى. اضبط [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) إلى `true` لإعادة الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) في الشريحة الأولى، ويفعّل الإرجاع. يقوم بتعطيل التكرار حتى يتمكن التشغيل من الانتهاء ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

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

إرجاع الفيديو يعيده إلى بدايته دون تشغيله مرة أخرى. بالمقابل، يؤدي تفعيل [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) إلى تكرار التشغيل تلقائيًا. احتفظ بتعطيل التكرار عندما تريد أن ينتهي الفيديو ويبقى جاهزًا لإعادة التشغيل. يتحكم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) بشكل مستقل في بدء التشغيل إما تلقائيًا أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم في توقيت بدء التشغيل. اضبط وضع التشغيل بعد ضبط إعداد التكرار، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **قَصُّ إطار فيديو**

استخدم [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) و [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. كلا القيمتين بوحدة الميللي ثانية. يؤدي القص إلى تغيير إعدادات التشغيل دون تعديل بيانات الفيديو المضمّن.

**ضبط إعدادات القص**

يقوم هذا المثال بتضمين فيديو محلي ويتخطي الثواني 2.5 الأولى والثانية الأخيرة أثناء التشغيل. استخدم فيديوً أطول من 3.5 ثانية حتى يبقى جزء قابل للتشغيل.

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

يقوم هذا المثال بطباعة قيم القص لإطار الفيديو الأول في الشريحة الأولى بوحدة الميللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لن يتم طباعة شيء. ينتج المثال السابق قيمًا 2500 و 1000.

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

## **إدارة ترجمات الفيديو**

يتيح Aspose.Slides لك إدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint التقديمية. تُخزن الترجمات بتنسيق WebVTT وتُعرض عبر الخاصية [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**إضافة ترجمات إلى إطار فيديو**

يقوم هذا المثال بتضمين فيديو محلي ويضيف مسار ترجمات WebVTT مسمى English. يجب أن تتطابق طوابع الوقت للترجمات مع الفيديو. يتضمن العرض المحفوظ كلًا من الفيديو وترجماته.

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

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) أيضًا نسخة م overloaded تسمح لك بإضافة ترجمات من تدفق.

**استخراج الترجمات من إطار فيديو**

يقوم هذا المثال بحفظ جميع مسارات الترجمات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. الأرقام المتسلسلة تحافظ على تميز ملفات الإخراج. يوضح وحدة التحكم عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) يعرض معرف الترجمة، والوسم، والبيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

**إزالة الترجمات من إطار فيديو**

يقوم هذا المثال بإزالة جميع الترميزات من إطار الفيديو في أول موضع شكل في الشريحة الأولى ويحفظ النتيجة. يفترض أن الشريحة والشكل موجودان وأن الشكل هو إطار فيديو.

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

إذا كنت بحاجة إلى إزالة مسار ترجمة واحد فقط، استخدم طرق [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) بدلاً من [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **استخراج فيديو من شريحة**

إلى جانب إضافة مقاطع الفيديو إلى الشرائح، يتيح Aspose.Slides استخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

يستخرج هذا المثال مقاطع الفيديو المضمّنة من كل شريحة إلى ملفات ثنائية منفصلة ومرقّمة. يتم تخطي مقاطع الفيديو المرتبطة لأنها لا تحتوي على بيانات مضمّنة. يطبع سطر الأوامر نوع MIME لكل فيديو وإجمالي العدد. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المُبلغ عنه عند الحاجة.

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

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُدرج البيانات الثنائية في المستند، وبالتالي ينمو حجم العرض التقديمي بنسبة حجم الملف. عند الربط بفيديو عبر الإنترنت وإضافة صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة في الحجم أصغر عادة.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك تبديل [محتوى الفيديو](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. يحتوي الفيديو المضمّن على [نوع المحتوى](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) الذي يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.