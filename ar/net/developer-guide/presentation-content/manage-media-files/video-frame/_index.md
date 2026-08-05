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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET. دليل سريع عملي."
---
## **المقدمة**

يمكن للفيديو الموضوع في موضع مناسب داخل عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك. 

يتيح لك PowerPoint إضافة مقاطع الفيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع الفيديو (كائنات الفيديو) إلى عرض تقديمي، توفر Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة. 

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمينه مع العرض التقديمي. 
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
1. حفظ العرض التقديمي المعدل. 

هذا الكود C# يوضح لك كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```c#
 // ينشئ فئة Presentation
 using (Presentation pres = new Presentation("pres.pptx"))
 {
     // يقوم بتحميل الفيديو
     using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
     {
         IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
         
         // يحصل على الشريحة الأولى ويضيف إطار فيديو
         pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
         
         // يحفظ العرض التقديمي إلى القرص
         pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
     }
 }
```
بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة [AddVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

الإصدارات الأحدث من Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) تدعم مقاطع الفيديو عبر الإنترنت في العروض التقديمية. إذا كان الفيديو الذي ترغب في استخدامه متاحًا على الويب (مثلاً على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الإلكتروني الخاص به.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. حفظ العرض التقديمي. 

هذا الكود C# يوضح لك كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```c#
public static void Run()
{
    // ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // يضيف إطار فيديو
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // يقوم بتحميل الصورة المصغرة
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **اقتطاع إطار فيديو**

تتيح لك Aspose.Slides التحكم في الجزء الذي يتم تشغيله من الفيديو عن طريق تعيين قيمتي trim-from-start و trim-from-end عبر [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/trimfromstart/) و[IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/trimfromend/). تُحدد القيمتان بالميلي ثانية وتُحدد مقدار الوقت المتخطى من بداية الفيديو ونهايته على التوالي. تُغيّر هذه الإعدادات إعدادات تشغيل الفيديو في العرض التقديمي؛ لا تقوم بقص أو تعديل بيانات الفيديو المضمّنة.

**تعيين إعدادات القص**

لإنشاء إطار فيديو وتعيين إعدادات القص الخاصة به:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideo/) إلى العرض التقديمي.
3. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) إلى شريحة.
4. تعيين قيمتي trim-from-start و trim-from-end عبر [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/trimfromstart/) و[IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/trimfromend/) .
5. حفظ العرض التقديمي المعدل.

يُظهر المثال التالي كودًا يتخطى أول 2.5 ثانية وآخر ثانية من فيديو مضمّن أثناء التشغيل:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**قراءة إعدادات القص**

لتفقد إعدادات القص الحالية، قم بتحميل عرض تقديمي، وابحث عن كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) بين الأشكال في الشريحة الأولى، واقرأ القيم عبر [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/trimfromstart/) و[IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/trimfromend/) .

يظهر المثال التالي كودًا يعثر على أول إطار فيديو في الشريحة الأولى ويبلغ عن إعدادات القص الخاصة به بالميلي ثانية:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **إدارة توضيحات الفيديو**

تتيح لك Aspose.Slides إدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بتنسيق WebVTT وتُعرض عبر خاصية [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/) .

**إضافة تسميات إلى إطار فيديو**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. إضافة فيديو إلى العرض التقديمي.
3. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) إلى شريحة.
4. استخدام مجموعة [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/) لإضافة مسار تسمية WebVTT.
5. حفظ العرض التقديمي المعدل.

يعرض الكود التالي كيفية إضافة تسميات إلى إطار فيديو:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // يضيف مسار تسميات جديد من ملف WebVTT.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

توفر واجهة [ICaptionsCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptionscollection/) أيضًا نسخة محملة تتيح لك إضافة تسميات من تدفق بيانات.

**استخراج التسميات من إطار فيديو**

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
2. العثور على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) المستهدف.
3. التكرار عبر مجموعة [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/) .
4. حفظ كل مسار تسمية إلى ملف `.vtt` .

يعرض الكود التالي كيفية استخراج التسميات من إطار فيديو:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // يحفظ مسار التسميات إلى ملف WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

كل كائن [ICaptions](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptions/) يكشف عن معرّف التسمية، والوسم، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
2. الحصول على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) المستهدف.
3. إزالة مسارات التسميات من مجموعة [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/) .
4. حفظ العرض التقديمي المعدل.

يعرض الكود التالي كيفية إزالة جميع التسميات من إطار فيديو:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // يزيل جميع التسميات من إطار الفيديو.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طرق [Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/captionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/captionscollection/removeat/) بدلاً من [Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/captionscollection/clear/) .

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، تتيح لك Aspose.Slides استخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. التكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide) .
3. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe) .
4. حفظ الفيديو على القرص.

يعرض هذا الكود C# كيفية استخراج الفيديو الموجود على شريحة عرض تقديمي:

```c#
// ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي 
Presentation presentation = new Presentation("Video.pptx");

// يتنقل عبر الشرائح
foreach (ISlide slide in presentation.Slides)
{
    // يتنقل عبر الأشكال
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // يحفظ الفيديو إلى القرص بمجرد العثور على VideoFrame يحتوي على فيديو
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار فيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/playmode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/playloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُدرج البيانات الثنائية في المستند، لذا ينمو حجم العرض التقديمي بما يتناسب مع حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مضمّن؟**

نعم. يحتوي الفيديو المضمن على [نوع محتوى](https://reference.aspose.com/slides/ar/net/aspose.slides/video/contenttype/) يمكنك قراءته واستخدامه، مثلاً عند حفظه على القرص.