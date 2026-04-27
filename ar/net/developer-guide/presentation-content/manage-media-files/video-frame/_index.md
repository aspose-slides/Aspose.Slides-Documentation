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
- إطار الفيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وإستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET. دليل سريع خطوة بخطوة."
---
يمكن أن يجعل الفيديو الموضّع بشكل جيد في العرض التقديمي رسالتك أكثر إقناعًا ويزيد من مستوى التفاعل مع جمهورك. 

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) وأنواع ذات صلة أخرى. 

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class.  
2. الحصول على مرجع الشريحة من خلال فهرستها.  
3. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.  
4. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
5. حفظ العرض التقديمي المعدل.  

يعرض لك هذا الشيفرة C# كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```c#
 // إنشاء كائن من فئة Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // تحميل الفيديو
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // الحصول على الشريحة الأولى وإضافة إطار فيديو
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // حفظ العرض التقديمي إلى القرص
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى طريقة [AddVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**
تدعم إصدارات Microsoft [PowerPoint 2013 وما بعدها](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلاً على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابط الويب الخاص به. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class  
2. الحصول على مرجع الشريحة من خلال فهرستها.  
3. إضافة كائن [IVideo](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.  
4. تعيين صورة مصغرة لإطار الفيديو.  
5. حفظ العرض التقديمي.  

يظهر لك هذا الشيفرة C# كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint تقديمي:

```c#
public static void Run()
{
    // إنشاء كائن Presentation يمثل ملف عرض تقديمي 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // إضافة إطار فيديو
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // تحميل الصورة المصغرة
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **إدارة تسميات الفيديو**

تتيح لك Aspose.Slides إدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint التقديمية. تُخزن التسميات بصيغة WebVTT وتُعرض عبر خاصية [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/) .

**إضافة تسميات إلى إطار فيديو**

لإضافة تسميات إلى إطار فيديو:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) class.  
2. إضافة فيديو إلى العرض التقديمي.  
3. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) إلى شريحة.  
4. استخدام مجموعة [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/) لإضافة مسار تسميات WebVTT.  
5. حفظ العرض التقديمي المعدل.  

يعرض لك الشيفرة التالية كيفية إضافة تسميات إلى إطار فيديو:

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

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptionscollection/) أيضًا تحميلًا زائدًا يتيح لك إضافة تسميات من تدفق.

**استخراج التسميات من إطار فيديو**

لاستخراج التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.  
2. البحث عن كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) المستهدف.  
3. التكرار عبر مجموعة [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/).  
4. حفظ كل مسار تسميات إلى ملف `.vtt`.  

يعرض لك الشيفرة التالية كيفية استخراج التسميات من إطار فيديو:

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

كل كائن [ICaptions](https://reference.aspose.com/slides/ar/net/aspose.slides/icaptions/) يكشف عن معرف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

لإزالة التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.  
2. الحصول على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/) المستهدف.  
3. إزالة مسارات التسميات من مجموعة [CaptionTracks](https://reference.aspose.com/slides/ar/net/aspose.slides/ivideoframe/captiontracks/).  
4. حفظ العرض التقديمي المعدل.  

يعرض لك الشيفرة التالية كيفية إزالة جميع التسميات من إطار فيديو:

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

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طريقتي [Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/captionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/captionscollection/removeat/) بدلاً من [Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/captionscollection/clear/).

## **استخراج فيديو من شريحة**
بالإضافة إلى إضافة مقاطع فيديو إلى الشرائح، تتيح لك Aspose.Slides استخراج مقاطع الفيديو المضمنة في العروض التقديمية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) class لتحميل العرض التقديمي الذي يحتوي على الفيديو.  
2. التكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide).  
3. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe).  
4. حفظ الفيديو إلى القرص.  

يعرض لك هذا الشيفرة C# كيفية استخراج الفيديو من شريحة عرض تقديمي:

```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي 
Presentation presentation = new Presentation("Video.pptx");

// يتنقل عبر الشرائح
foreach (ISlide slide in presentation.Slides)
{
    // يتنقل عبر الأشكال
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // يحفظ الفيديو إلى القرص بمجرد العثور على VideoFrame يحتوي على الفيديو
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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تعديلها لإطار الفيديو (VideoFrame)؟**  
يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/playmode/) (تشغيل تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/playloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/).

**هل يضيف إضافة فيديو حجمًا إلى ملف PPTX؟**  
نعم. عندما تقوم بتضمين فيديو محلي، يتم تضمين البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عندما تضيف فيديوًا عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا تكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**  
نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/net/aspose.slides/videoframe/embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ وهذا سيناريو شائع لتحديث الوسائط في تنسيق موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**  
نعم. يحتوي الفيديو المضمّن على [نوع المحتوى](https://reference.aspose.com/slides/ar/net/aspose.slides/video/contenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.