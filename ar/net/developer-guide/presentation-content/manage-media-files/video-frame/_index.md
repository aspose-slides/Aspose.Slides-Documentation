---
title: إ إطار الفيديو
type: docs
weight: 10
url: /ar/net/video-frame/
keywords: "إضافة فيديو، إنشاء إطار فيديو، استخراج فيديو، عرض PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "إضافة إطار فيديو إلى عرض PowerPoint باستخدام C# أو .NET"
---

يمكن للفيديو الموضوع بشكل جيد في العرض التقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك. 

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة. 

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع الشريحة عبر رقم الفهرس الخاص بها. 
1. أضف كائن [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) ومرّر مسار ملف الفيديو لتضمينه مع العرض التقديمي. 
1. أضف كائن [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
1. احفظ العرض التقديمي المعدل. 

هذا الكود بلغة C# يوضح لك كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
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

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى الطريقة [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```



## **إنشاء إطار فيديو من مصدر ويب**
Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) يدعم مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابط الويب الخاص به. 

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع الشريحة عبر رقم الفهرس الخاص بها. 
1. أضف كائن [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) ومرّر رابط الفيديو.
1. قم بتعيين صورة مصغرة لإطار الفيديو. 
1. احفظ العرض التقديمي. 

هذا الكود بلغة C# يوضح لك كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:
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

    // يحمّل الصورة المصغرة
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```


## **استخراج الفيديو من الشريحة**
إلى جانب إضافة مقاطع الفيديو إلى الشرائح، تتيح لك Aspose.Slides استخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. التجول عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. التجول عبر جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) للعثور على [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe). 
4. احفظ الفيديو على القرص.

هذا الكود بلغة C# يوضح لك كيفية استخراج الفيديو من شريحة في العرض التقديمي:
```c#
 // ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي 
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


## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تعديلها لإطار الفيديو (VideoFrame)؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُدرج البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بنسبة حجم الملف. عند إضافة فيديو عبر الإنترنت، يُضمّن رابط وصورة مصغرة فقط، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مضمّن؟**

نعم. يحتوي الفيديو المضمّن على [نوع المحتوى](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) الذي يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.