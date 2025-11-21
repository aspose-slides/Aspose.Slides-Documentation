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
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيف تضيف وتستخرج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. دليل سريع للخطوات."
---

يمكن للفيديو الموضوع في المكان المناسب داخل العرض التقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك. 

PowerPoint يتيح لك إضافة مقاطع الفيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع الفيديو (كائنات الفيديو) إلى عرض تقديمي، توفر مكتبة Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة. 

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء كائن من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة كائن [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمينه في العرض التقديمي.  
4. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
5. حفظ العرض التقديمي المعدل.  

يعرض لك هذا الكود C# كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
```c#
// إنشاء كائن من فئة Presentation
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

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى طريقة [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي ترغب في استخدامه متاحًا على الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابطه على الويب. 

1. إنشاء كائن من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة كائن [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.  
4. تعيين صورة مصغرة لإطار الفيديو.  
5. حفظ العرض التقديمي.  

يعرض لك هذا الكود C# كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint التقديمي:
```c#
public static void Run()
{
    // يخلق كائن Presentation يمثل ملف عرض تقديمي
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

    // يحمل صورة مصغرة
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```


## **استخراج الفيديو من الشريحة**

بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، تتيح لك مكتبة Aspose.Slides استخراج مقاطع الفيديو المضمنة في العروض التقديمية.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو.  
2. التجوال عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).  
3. التجوال عبر جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe).  
4. حفظ الفيديو إلى القرص.  

يعرض لك هذا الكود C# كيفية استخراج الفيديو من شريحة في عرض تقديمي:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي 
Presentation presentation = new Presentation("Video.pptx");

// يتنقل عبر الشرائح
foreach (ISlide slide in presentation.Slides)
{
    // يتنقل عبر الأشكال
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // يحفظ الفيديو إلى القرص بمجرد العثور على إطار فيديو يحتوي على الفيديو
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


## **الأسئلة المتكررة**

**ما هي معايير تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، يتم إدراج البيانات الثنائية داخل المستند، لذا يزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين الرابط والصورة المصغرة فقط، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. يحتوي الفيديو المضمّن على [نوع المحتوى](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) الذي يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.