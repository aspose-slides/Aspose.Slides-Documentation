---
title: إطار الفيديو
type: docs
weight: 10
url: /ar/net/video-frame/
keywords: "إضافة فيديو، إنشاء إطار فيديو، استخراج فيديو، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة إطار فيديو إلى عرض PowerPoint في C# أو .NET"
---

يمكن أن يجعل الفيديو الموضوع بشكل جيد في عرض تقديمي رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك.

يسمح لك PowerPoint بإضافة مقاطع الفيديو إلى الشريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع الفيديو (كائنات الفيديو) إلى عرض تقديمي، تقدم Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف كائن [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) ومرر مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
1. أضف كائن [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. احفظ العرض التقديمي المعدل.

يعرض كود C# هذا كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```c#
// ينشئ مثيلًا لفئة Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // يحمل الفيديو
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // يحصل على الشريحة الأولى ويضيف إطار فيديو
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // يحفظ العرض التقديمي على القرص
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
بدلاً من ذلك، يمكنك إضافة فيديو عن طريق تمرير مسار ملفه مباشرة إلى طريقة [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**
يدعم Microsoft [PowerPoint 2013 وما فوق](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع الفيديو من YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثل على YouTube)، يمكنك إضافته إلى عرضك التقديمي من خلال ارتباطه عبر الويب.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف كائن [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) ومرر الرابط إلى الفيديو.
1. قم بتعيين صورة مصغرة لإطار الفيديو.
1. احفظ العرض التقديمي.

يعرض كود C# هذا كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```c#
public static void Run()
{
    // ينشئ كائن Presentation يمثل ملف عرض تقديمي 
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

    // يحمل الصورة المصغرة
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **استخراج الفيديو من الشريحة**
بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، يسمح Aspose.Slides لك باستخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. قم بالتكرار من خلال جميع كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. قم بالتكرار من خلال جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) للعثور على [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe).
4. احفظ الفيديو على القرص.

يعرض كود C# هذا كيفية استخراج الفيديو من شريحة عرض تقديمي:

```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي 
Presentation presentation = new Presentation("Video.pptx");

// يتكرر من خلال الشرائح
foreach (ISlide slide in presentation.Slides)
{
    // يتكرر من خلال الأشكال
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // يحفظ الفيديو على القرص بمجرد العثور على VideoFrame الذي يحتوي على الفيديو
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