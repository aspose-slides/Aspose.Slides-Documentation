---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها در .NET
linktitle: فریم ویدئویی
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
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

یک ویدئوی به‌جا در یک ارائه می‌تواند پیام شما را قانع‌کننده‌تر کرده و سطح تعامل با مخاطبان را افزایش دهد.

PowerPoint به شما امکان می‌دهد ویدئوها را به اسلایدی در یک ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدئوی محلی (ذخیره‌شده در دستگاه شما)
* افزودن یک ویدئوی آنلاین (از منبع وبی مانند YouTube).

برای این که بتوانید ویدئوها (شیءهای ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی برای جاسازی ویدئو در ارائه خود ایجاد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. از طریق اندیس آن، مرجع اسلاید را دریافت کنید.
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه پاس بدهید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) اضافه کنید تا فریمی برای ویدئو ایجاد شود.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده محلی را به یک ارائه اضافه کنید:

```c#
// نمونه‌سازی کلاس Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // ویدئو را بارگذاری می‌کند
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // اسلاید اول را دریافت می‌کند و فریم ویدئویی اضافه می‌کند
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // ارائه را در دیسک ذخیره می‌کند
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
به‌علاوه می‌توانید با پاس دادن مسیر فایل مستقیماً به روش [AddVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addvideoframe/) ویدئو را اضافه کنید:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **ایجاد یک فریم ویدئویی با ویدئوی منبع وب**
نسخه‌های جدید Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) پشتیبانی از ویدئوهای آنلاین در ارائه‌ها را ارائه می‌دهند. اگر ویدئویی که می‌خواهید استفاده کنید به صورت آنلاین (مثلاً در YouTube) در دسترس باشد، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. از طریق اندیس آن، مرجع اسلاید را دریافت کنید.
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideo/) اضافه کنید و لینک ویدئو را پاس بدهید.
1. یک تصویر بندانگشتی برای فریم ویدئو تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک ویدئوی وب را به اسلایدی در ارائهٔ PowerPoint اضافه کنید:

```c#
public static void Run()
{
    // یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل ارائه است 
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

    // تصویر بندانگشتی را بارگذاری می‌کند
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **قص فریم ویدئو**

Aspose.Slides به شما امکان می‌دهد که بخش‌های مختلف یک ویدئو را با تنظیم مقادیر trim-from-start و trim-from-end از طریق [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/trimfromstart/) و [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/trimfromend/) کنترل کنید. هر دو مقدار بر حسب میلی‌ثانیه مشخص می‌شوند و نشان می‌دهند چه مقدار زمان از ابتداء و انتهای ویدئو صرف‌نظر شود. این تنظیمات فقط رفتار پخش ویدئو را در ارائه تغییر می‌دهند؛ دادهٔ باینری ویدئوی جاسازی‌شده را قطع یا تغییر نمی‌دهند.

**تنظیمات برش**

برای ایجاد یک فریم ویدئویی و تنظیم مقادیر برش آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideo/) به ارائه اضافه کنید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.
1. مقادیر trim-from-start و trim-from-end را از طریق [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/trimfromstart/) و [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/trimfromend/) تنظیم کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال کد زیر ۲٫۵ ثانیهٔ اول و یک ثانیهٔ آخر ویدئوی جاسازی‌شده را هنگام پخش حذف می‌کند:

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

**خواندن تنظیمات برش**

برای بررسی تنظیمات برش موجود، یک ارائه بارگیری کنید، یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) را در میان شکل‌های اسلاید اول پیدا کنید و مقادیر را از طریق [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/trimfromstart/) و [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/trimfromend/) بخوانید.

مثال کد زیر اولین فریم ویدئویی در اسلاید اول را پیدا کرده و تنظیمات برش آن را برحسب میلی‌ثانیه گزارش می‌دهد:

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

## **مدیریت زیرنویس‌های ویدئو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق ویژگی [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) در دسترس هستند.

**افزودن زیرنویس به فریم ویدئو**

برای افزودن زیرنویس به فریم ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک ویدئو به ارائه اضافه کنید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.
1. از مجموعه [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) برای افزودن یک ردیف زیرنویس WebVTT استفاده کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به فریم ویدئویی اضافه کنید:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // یک مسیر زیرنویس جدید از یک فایل WebVTT اضافه می‌کند.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptionscollection/) همچنین یک overload فراهم می‌کند که امکان افزودن زیرنویس‌ها از یک جریان (stream) را می‌دهد.

**استخراج زیرنویس‌ها از فریم ویدئو**

برای استخراج زیرنویس‌ها از فریم ویدئویی:

1. ارائه حاوی ویدئو را بارگیری کنید.
1. شیء هدف [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) را پیدا کنید.
1. در مجموعه [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) حلقه بزنید.
1. هر ردیف زیرنویس را در یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از فریم ویدئویی استخراج کنید:

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
                // ردیف زیرنویس‌ها را به یک فایل WebVTT ذخیره می‌کند.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به‌صورت رشتهٔ UTF-8 در دسترس می‌گذارد.

**حذف زیرنویس‌ها از فریم ویدئو**

برای حذف زیرنویس‌ها از فریم ویدئویی:

1. ارائهٔ شامل ویدئو را بارگیری کنید.
1. شیء هدف [IVideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/) را دریافت کنید.
1. ردیف‌های زیرنویس را از مجموعه [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/ivideoframe/captiontracks/) حذف کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از فریم ویدئویی حذف کنید:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // تمام زیرنویس‌ها را از فریم ویدئویی حذف می‌کند.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

اگر می‌خواهید فقط یک ردیف زیرنویس را حذف کنید، به جای متد [Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/captionscollection/clear/) از متدهای [Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/captionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/captionscollection/removeat/) استفاده کنید.

## **استخراج ویدئو از اسلاید**
علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدئوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا ارائهٔ حاوی ویدئو را بارگیری کنید. 
2. در تمام اشیای [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide) حلقه بزنید.
3. در تمام اشیای [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) حلقه بزنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/videoframe) پیدا کنید. 
4. ویدئو را روی دیسک ذخیره کنید.

این کد C# نشان می‌دهد چگونه ویدئوی موجود در اسلاید یک ارائه را استخراج کنید:

```c#
 // یک شیء Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل ارائه است 
 Presentation presentation = new Presentation("Video.pptx");

 // از اسلایدها عبور می‌کند
 foreach (ISlide slide in presentation.Slides)
 {
     // از اشکال عبور می‌کند
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // وقتی VideoFrame حاوی ویدئو پیدا شد، ویدئو را روی دیسک ذخیره می‌کند
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

## **سوالات متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای VideoFrame تغییر یابند؟**

می‌توانید حالت پخش (خودکار یا با کلیک) و حالت حلقه‌دار شدن را از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/videoframe/) کنترل کنید.

**آیا افزودن ویدئو بر حجم فایل PPTX تأثیر می‌گذارد؟**

بله. هنگامی که یک ویدئوی محلی را جاسازی می‌کنید، دادهٔ باینری در سند گنجانده می‌شود، بنابراین حجم ارائه متناسب با حجم فایل رشد می‌کند. وقتی یک ویدئوی آنلاین اضافه می‌کنید، فقط لینک و تصویر بندانگشتی جاسازی می‌شود؛ لذا افزایش حجم کمتر است.

**آیا می‌توانم ویدئو را در یک VideoFrame موجود بدون تغییر موقعیت و اندازه آن جایگزین کنم؟**

بله. می‌توانید محتویات ویدئوی [embeddedvideo](https://reference.aspose.com/slides/fa/net/aspose.slides/videoframe/embeddedvideo/) را درون فریم تعویض کنید و شکل هندسی آن را حفظ کنید؛ این یک وضعیت رایج برای بروز رسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/net/aspose.slides/video/contenttype/) است که می‌توانید آن را بخوانید و مثلاً هنگام ذخیره‌سازی روی دیسک استفاده کنید.