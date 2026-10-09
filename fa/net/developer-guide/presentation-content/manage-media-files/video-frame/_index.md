---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با .NET
linktitle: فریم ویدئویی
type: docs
weight: 10
url: /fa/net/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- جاسازی ویدیو
- استخراج ویدیو
- دریافت ویدیو
- فریم ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET اضافه و استخراج کنید. راهنمای سریع عملی."
---
## **معرفی**

ویدیوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides for .NET به شما امکان می‌دهد فریم‌های ویدئویی را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدئوی جاسازی شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و لینک‌های ویدیوهای آنلاین، مانند ویدیوهای YouTube پشتیبانی می‌کند.

برای نمایش داده‌های ویدئویی و فریم‌های ویدئویی، Aspose.Slides رابط [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) و رابط [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدئویی جاسازی شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید فریم ویدئویی ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید.

این مثال یک ویدئوی محلی را در اولین اسلاید یک ارائه موجود جاسازی می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم برحسب نقاط هستند. جریان (stream) تا پایان ذخیره باز می‌ماند زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) آن را قفل می‌ماند در حالی که ارائه از آن استفاده می‌کند.

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

می‌توانید مسیر ویدئوی محلی را مستقیماً به [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) نیز پاس بدهید. این مثال ویدیو را در اولین اسلاید یک ارائه جدید جاسازی می‌کند. ویدیو باید تا زمان ذخیرهٔ ارائه دسترس‌پذیر بماند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **ایجاد یک فریم ویدئویی با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدئویی ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو YouTube، لینک دارد.

این مثال یک لینک ویدیو YouTube و تصویر کوچک آن را به اولین اسلاید اضافه می‌کند. شناسهٔ ویدیو را جایگزین کنید تا از ویدیو دیگری استفاده کنید. تنظیم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) پخش خودکار را درخواست می‌کند. دانلود تصویر کوچک و پخش ویدیو نیاز به دسترسی به اینترنت دارد. نمایشگر ارائه نیز باید پخش ویدیوهای آنلاین را پشتیبانی کند.

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

## **پخش یک ویدیو در حالت تمام‌صفحه**

در یک ارائهٔ آموزشی، می‌توانید یک نمایش نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. برای فعال‌سازی این رفتار در طول پخش، [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) را به `true` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائهٔ ورودی باید حداقل یک اسلاید با فریم ویدئویی موجود در اولین اسلاید داشته باشد.

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

پخش تمام‌صفحه کنترل می‌کند که ویدیو چگونه نمایش داده شود. به‌ طور مستقل، [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) تعیین می‌کند که آیا پخش به‌صورت خودکار یا با کلیک آغاز شود و [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto یا VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقهٔ موجود را حفظ می‌کند.

## **بازگرداندن یک ویدیو پس از پخش**

در یک ارائهٔ آموزشی، بازگرداندن یک ویدئو نمایشی به ابتدای آن باعث می‌شود برای ارائه‌کننده دوباره قابل پخش باشد. برای بازگرداندن ویدیو به ابتدای آن پس از اتمام پخش، [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) را به `true` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و بازگرداندن را فعال می‌سازد. حلقه‌گذاری را غیرفعال می‌کند تا پخش بتواند به پایان برسد و پخش را برای شروع با کلیک تنظیم می‌کند. ارائهٔ ورودی باید حداقل یک اسلاید با فریم ویدئویی موجود در اولین اسلاید داشته باشد.

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

بازگرداندن ویدیو را به ابتدای آن برمی‌گرداند بدون این‌که دوباره شروع شود. در مقابل، فعال‌سازی [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدیو به پایان برسد و آمادهٔ پخش مجدد بماند، حلقه را غیرفعال نگه دارید. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) به‌طور مستقل کنترل می‌کند که پخش به‌صورت خودکار یا با کلیک آغاز شود؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌کننده زمان شروع پخش را کنترل کند. همان‌طور که در مثال نشان داده شده، حالت پخش پس از تنظیم حلقه تنظیم می‌شود. بازگرداندن به‌طور مستقل از [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) کار می‌کند.

## **برش یک فریم ویدئویی**

از [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) و [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) برای حذف بخشی از ابتدا یا انتهای ویدیو هنگام پخش استفاده کنید. هر دو مقدار برحسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدئوی جاسازی‌شده تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدئوی محلی را جاسازی می‌کند و در طول پخش ۲.۵ ثانیهٔ اول و یک ثانیهٔ آخر را نادیده می‌گیرد. از ویدیویی طولانی‌تر از ۳.۵ ثانیه استفاده کنید تا بخشی قابل پخش باقی بماند.

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

**خواندن تنظیمات برش**

این مثال مقادیر برش اولین فریم ویدئویی در اولین اسلاید را برحسب میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدئویی نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ تولید می‌کند.

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

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها به فرم‌ت فرمت WebVTT ذخیره می‌شوند و از طریق ویژگی [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) در دسترس هستند.

**افزودن زیرنویس به فریم ویدئویی**

این مثال یک ویدئوی محلی را جاسازی می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌بندی زیرنویس باید با ویدیو همخوانی داشته باشد. ارائهٔ ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

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

رابط [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) همچنین یک بارگذاری اضافه فراهم می‌کند که به شما امکان اضافه‌کردن زیرنویس‌ها از یک جریان را می‌دهد.

**استخراج زیرنویس‌ها از فریم ویدئویی**

این مثال تمام مسیرهای زیرنویس را از فریم‌های ویدئویی در اولین اسلاید به‌صورت فایل‌های جداگانهٔ WebVTT ذخیره می‌کند. شماره‌های متوالی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به‌صورت رشتهٔ UTF-8 نمایش می‌دهد.

**حذف زیرنویس‌ها از فریم ویدئویی**

این مثال تمام زیرنویس‌ها را از فریم ویدئویی در اولین موقعیت شکل در اولین اسلاید حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌کند اسلاید و شکل وجود دارند و شکل یک فریم ویدئویی است.

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

اگر فقط نیاز به حذف یک مسیر زیرنویس دارید، به‌جای [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) از متدهای [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) استفاده کنید.

## **استخراج ویدئو از یک اسلاید**

به‌جز افزودن ویدئو به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

این مثال ویدئوهای جاسازی‌شده را از هر اسلاید به فایل‌های باینری شماره‌گذاری‌شده جداگانه استخراج می‌کند. ویدئوهای لینک‌شده به‌دلیل عدم وجود دادهٔ جاسازی‌شده نادیده گرفته می‌شوند. کنسول نوع MIME هر ویدئو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را به‌گونه‌ای تغییر دهید که با نوع رسانهٔ گزارش‌شده منطبق باشد.

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

## **سؤالات متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای یک فریم ویدئویی تغییر کنند؟**

می‌توانید حالت [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (خودکار یا با کلیک) و [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدئو بر اندازه فایل PPTX تاثیر می‌گذارد؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، دادهٔ باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه به تناسب حجم فایل افزایش می‌یابد. وقتی به یک ویدئوی آنلاین لینک می‌دهید و تصویر پیش‌نمایش اضافه می‌کنید، ارائه تنها لینک و تصویر پیش‌نمایش را ذخیره می‌کند نه دادهٔ ویدئو، بنابراین افزایش اندازه معمولاً کمتر است.

**آیا می‌توانم ویدئو را در یک فریم ویدئویی موجود بدون تغییر موقعیت و اندازهٔ آن جایگزین کنم؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) را داخل فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این سناریو برای به‌روزرسانی رسانه در یک طرح موجود رایج است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی روی دیسک.