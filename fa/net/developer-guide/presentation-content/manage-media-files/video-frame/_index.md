---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با .NET
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/net/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- تعبیه ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- فریم ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها کمک کرده و مخاطبان را جذب کنند. Aspose.Slides for .NET به شما امکان اضافه کردن فریم‌های ویدیو به اسلایدها، تنظیم تنظیمات پخش، مدیریت زیرنویس‌ها و استخراج داده‌های ویدیوهای تعبیه‌شده را می‌دهد.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) و انواع مرتبط دیگر را فراهم می‌کند.

## **ایجاد یک فریم ویدیو تعبیه‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود تعبیه کنید.

این مثال یک ویدیو محلی را در اولین اسلاید یک ارائه موجود تعبیه می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان (stream) تا پایان ذخیره باز می‌ماند چون [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) آن را در هنگام استفاده ارائه قفل نگه می‌دارد.

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

همچنین می‌توانید مسیر ویدیو محلی را مستقیماً به [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) پاس دهید. این مثال ویدیو را در اولین اسلاید یک ارائه جدید تعبیه می‌کند. ویدیو باید تا زمان ذخیره ارائه در دسترس بماند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **تنظیم دقیق حجم ویدیو**

در Aspose.Slides for .NET نسخه 26.11 یا بعد از آن، [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) درصدی با مقدار شناور از 0 تا 100 تنظیم می‌کند. وقتی پیش‌تنظیم‌های [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) بیش از حد کلی هستند، از آن استفاده کنید. برای مثال، `75.5f` حجم 75.5٪ را درخواست می‌کند.

این مثال به [Aspose.Slides for .NET](/slides/fa/net/installation/) نسخه 26.11 یا بعد از آن و یک فایل `video.mp4` محلی نیاز دارد. ویدیو را تعبیه می‌کند، به صراحت پخش را مقداردهی اولیه مینماید، ارائه را ذخیره می‌کند و درصد ذخیره‌شده را برمی‌خواند.

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

ورودی را خودتان اعتبارسنجی کنید؛ به تنظیم‌کننده برای رد مقادیر خارج از دامنه مستند شده تکیه نکنید. پیش‌تنظیم‌های کم، متوسط و بلند در نسخه 26.11 مطابق با 20، 50 و 80 هستند. تنظیم یک پیش‌تنظیم می‌تواند درصد قبلی را جایگزین کند، بنابراین وقتی به مقدار دقیق نیاز دارید، درصد را در انتها اختصاص دهید. برای تنظیم صریح بی‌صدا از [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) استفاده کنید؛ صفر عددی و مقدار enum پیش‌تنظیم حالت‌های قابل تعویض نیستند.

همچنین هنگام پیکربندی یک ویدیو پیوندی، [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) را به‌صورت صریح تنظیم کنید و فایل رسانه‌ای آن را برای بیننده در دسترس نگه دارید. ذخیره و بازگشایی تنظیم ذخیره‌شده را تأیید می‌کند؛ پخش واقعی و صدای آن به پخش‌کننده ارائه و تنظیمات صوتی آن بستگی دارد.

## **ایجاد فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ویدیوهای آنلاین را در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدیو ایجاد کنید که به یک ویدیو آنلاین مانند یک ویدیو YouTube پیوند دارد.

این مثال پیوند ویدیو YouTube و تصویر بندانگشتی را به اولین اسلاید اضافه می‌کند. شناسه ویدیو را تغییر دهید تا از ویدیو دیگری استفاده کنید. تنظیم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) درخواست پخش خودکار می‌کند. دانلود تصویر بندانگشتی و پخش ویدیو نیاز به دسترسی به اینترنت دارد. نمایشگر ارائه نیز باید از پخش ویدیوهای آنلاین پشتیبانی کند.

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

## **پخش ویدیو در حالت تمام صفحه**

در یک ارائه آموزشی، می‌توانید یک نمایش نرم‌افزار را در حالت تمام صفحه پخش کنید تا مخاطبان جزئیات را ببینند. برای فعال کردن این رفتار در طول پخش، [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) را روی `true` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام صفحه را فعال می‌نماید. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اولین اسلاید یک فریم ویدیو موجود داشته باشد.

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

پخش تمام صفحه نحوه نمایش ویدیو را کنترل می‌کند. به‌صورت مستقل، [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود و [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) تعیین می‌کند که آیا تکرار شود. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **پس از پخش، ویدیو را به ابتدا برگردانید**

در یک ارائه آموزشی، بازگرداندن ویدیو نمایش به ابتدای خود آن را برای اجرا دوباره توسط ارائه‌دهنده آماده می‌کند. برای بازگرداندن ویدیو به ابتدا پس از اتمام پخش، [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) را روی `true` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و بازگرداندن را فعال می‌سازد. حلقه را غیرفعال می‌کند تا پخش بتواند تمام شود و پخش را برای شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اولین اسلاید یک فریم ویدیو موجود داشته باشد.

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

بازگرداندن ویدیو را به ابتدا برمی‌گرداند بدون اینکه دوباره شروع شود. برعکس، فعال‌سازی [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدیو تمام شود و آماده اجرای مجدد بماند، حلقه را غیرفعال نگه دارید. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) به‌صورت مستقل کنترل می‌کند که پخش به‌صورت خودکار یا با کلیک آغاز شود؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. همان‌طور که در مثال نشان داده شده، حالت پخش را پس از تنظیم حلقه اعمال کنید. بازگرداندن به‌صورت مستقل از [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) عمل می‌کند.

## **برش یک فریم ویدیو**

از [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) و [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) برای حذف بخشی از ابتدای یا انتهای ویدیو هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدیو تعبیه‌شده تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدیو محلی را تعبیه می‌کند و در حین پخش ۲٫۵ ثانیه اول و یک ثانیه آخر را حذف می‌کند. از ویدئویی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا یک بخش قابل پخش باقی بماند.

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

این مثال مقادیر برش اولین فریم ویدیو در اولین اسلاید را بر حسب میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیو نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها در قالب WebVTT ذخیره شده و از طریق ویژگی [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) در دسترس هستند.

**اضافه کردن زیرنویس‌ها به فریم ویدیو**

این مثال یک ویدیو محلی را تعبیه می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌نماید. زمان‌برچسب‌های زیرنویس باید با ویدیو مطابقت داشته باشند. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

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

رابط [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) همچنین یک overload دارد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام مسیرهای زیرنویس از فریم‌های ویدیو در اولین اسلاید را به صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. شماره‌های ترتیبی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به صورت رشته UTF-8 نشان می‌دهد.

**حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل روی اولین اسلاید حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک فریم ویدیو است.

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

اگر نیاز به حذف فقط یک مسیر زیرنویس دارید، به‌جای [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) از متدهای [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر اضافه کردن ویدیوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای تعبیه‌شده در ارائه‌ها را می‌دهد.

این مثال ویدیوهای تعبیه‌شده را از هر اسلاید استخراج کرده و به فایل‌های باینری جداگانه و شماره‌دار ذخیره می‌کند. ویدیوهای پیوندی نادیده گرفته می‌شوند زیرا داده تعبیه‌شده ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را با نوع رسانه گزارش‌شده مطابقت دهید.

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

## **سوالات متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای یک فریم ویدیو تغییر کنند؟**

می‌توانید [حالت پخش](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (خودکار یا با کلیک) و [حلقه‌سازی](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) قابل دسترسی هستند.

**آیا اضافه کردن یک ویدیو بر اندازه فایل PPTX تاثیر می‌گذارد؟**

بله. وقتی یک ویدیو محلی را تعبیه می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه متناسب با حجم فایل افزایش می‌یابد. وقتی به یک ویدیو آنلاین پیوند می‌دهید و تصویر بندانگشتی اضافه می‌کنید، ارائه فقط پیوند و تصویر پیش‌نمایش را ذخیره می‌کند و نه داده‌های ویدیو، لذا افزایش اندازه معمولاً کمتر است.

**آیا می‌توانم ویدیو را در یک فریم ویدیو موجود بدون تغییر موقعیت و اندازه آن جایگزین کنم؟**

بله. می‌توانید [محتوای ویدیو](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) را درون فریم جابجا کنید در حالی که شکل هندسه آن حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو تعبیه‌شده را تعیین کرد؟**

بله. یک ویدیو تعبیه‌شده دارای یک [نوع محتوا](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی به دیسک.