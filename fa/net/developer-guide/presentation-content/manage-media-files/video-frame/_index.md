---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها در .NET
linktitle: فریم ویدئو
type: docs
weight: 10
url: /fa/net/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- بازیابی ویدئو
- فریم ویدئو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET اضافه و استخراج کنید. راهنمای سریع."
---
## **مقدمه**

یک ویدئوی قرار داده شده به‌خوبی در یک ارائه می‌تواند پیام شما را جذاب‌تر کرده و سطح تعامل با مخاطبان را افزایش دهد. 

PowerPoint به شما امکان می‌دهد تا ویدئوها را به یک اسلاید در یک ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدئوی محلی (ذخیره‌شده بر روی دستگاه شما)
* افزودن یک ویدئوی آنلاین (از منبع وبی مانند YouTube).

برای اینکه بتوانید ویدئوها (اشیاء ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideo/) ، [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) و سایر انواع مرتبط را ارائه می‌دهد. 

## **ایجاد یک فریم ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئوی ایجاد کنید تا ویدئو را در ارائه خود جاسازی کنید. 

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. از طریق شمارهٔ ایندکس، مرجع یک اسلاید را بدست آورید. 
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه بدهید. 
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) اضافه کنید تا یک فریم برای ویدئو ایجاد کنید.  
1. ارائهٔ تغییر یافته را ذخیره کنید. 

این کد C# نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده به‌صورت محلی را به یک ارائه اضافه کنید:

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
using (Presentation pres = new Presentation("pres.pptx"))
{
    // ویدئو را بارگیری می‌کند
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // اسلاید اول را دریافت می‌کند و یک فریم ویدئویی اضافه می‌کند
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // ارائه را روی دیسک ذخیره می‌کند
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
به‌علاوه، می‌توانید با عبور مسیر فایل مستقیم به روش [AddVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addvideoframe/) یک ویدئو اضافه کنید:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **ایجاد فریم ویدئویی با ویدئویی از منبع وب**

Microsoft [PowerPoint 2013 و جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئوی مورد نظر شما به‌صورت آنلاین موجود باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید. 

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید
1. از طریق شمارهٔ ایندکس، مرجع یک اسلاید را بدست آورید. 
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideo/) اضافه کنید و لینک ویدئو را بدهید.
1. یک تصویر بندانگشتی برای فریم ویدئو تنظیم کنید. 
1. ارائه را ذخیره کنید. 

این کد C# نشان می‌دهد چگونه یک ویدئوی وب را به یک اسلاید در ارائه PowerPoint اضافه کنید:

```c#
public static void Run()
{
    // یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // یک VideoFrame اضافه می‌کند
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // تصویر بندانگشتی را بارگیری می‌کند
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **مدیریت زیرنویس‌های ویدئو**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها در فرمت WebVTT ذخیره شده و از طریق ویژگی [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) در دسترس هستند.

**اضافه کردن زیرنویس به فریم ویدئو**

برای اضافه کردن زیرنویس به فریم ویدئو:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک ویدئو به ارائه اضافه کنید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.
1. از مجموعه‌ی [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) برای اضافه کردن یک مسیر زیرنویس WebVTT استفاده کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به فریم ویدئو اضافه کنید:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // یک مسیر زیرنویس جدید از یک فایل WebVTT اضافه می‌کند.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptionscollection/) همچنین یک overload فراهم می‌کند که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس از فریم ویدئو**

برای استخراج زیرنویس‌ها از فریم ویدئو:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) هدف را پیدا کنید.
1. در مجموعه‌ی [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) پیمایش کنید.
1. هر مسیر زیرنویس را در یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از فریم ویدئو استخراج کنید:

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
                // مسیر زیرنویس را به یک فایل WebVTT ذخیره می‌کند.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به‌صورت رشته UTF-8 نمایش می‌دهد.

**حذف زیرنویس‌ها از فریم ویدئو**

برای حذف زیرنویس‌ها از فریم ویدئو:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) هدف را دریافت کنید.
1. مسیرهای زیرنویس را از مجموعه‌ی [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) حذف کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از فریم ویدئو حذف کنید:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // تمامی زیرنویس‌ها را از فریم ویدئو حذف می‌کند.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

اگر نیاز دارید تنها یک مسیر زیرنویس را حذف کنید، به‌جای [Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/captionscollection/clear/)، از متدهای [Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/captionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/captionscollection/removeat/) استفاده کنید.

## **استخراج ویدئو از یک اسلاید**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا ارائه‌ای که حاوی ویدئو است را بارگذاری کنید. 
2. در تمام اشیاء [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide) پیمایش کنید.
3. در تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/videoframe) پیدا کنید. 
4. ویدئو را روی دیسک ذخیره کنید.

این کد C# نشان می‌دهد چگونه ویدئوی یک اسلاید در ارائه را استخراج کنید:

```c#
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
Presentation presentation = new Presentation("Video.pptx");

// از اسلایدها عبور می‌کند
foreach (ISlide slide in presentation.Slides)
{
    // از اشکال عبور می‌کند
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // ویدئو را روی دیسک ذخیره می‌کند هنگامی که VideoFrame حاوی ویدئو پیدا می‌شود
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

## **پرسش‌های متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای VideoFrame تغییر کنند؟**

شما می‌توانید حالت پخش (auto یا on click) و حلقه‌گذاری ([looping](https://reference.aspose.com/slides/fa/net/aspose.slides/videoframe/playloopmode/)) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدئو بر حجم فایل PPTX تأثیر می‌گذارد؟**

بله. هنگامی که یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شوند، بنابراین حجم ارائه به نسبت اندازهٔ فایل افزایش می‌یابد. وقتی یک ویدئوی آنلاین اضافه می‌کنید، فقط یک لینک و تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایش حجم کمتر است.

**آیا می‌توانم ویدئوی موجود در یک VideoFrame را بدون تغییر موقعیت و اندازه‌ی آن جایگزین کنم؟**

بله. می‌توانید محتوای ویدئویی ([video content](https://reference.aspose.com/slides/fa/net/aspose.slides/videoframe/embeddedvideo/)) را درون فریم جایگزین کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این یک وضعیت رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/net/aspose.slides/video/contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی روی دیسک.