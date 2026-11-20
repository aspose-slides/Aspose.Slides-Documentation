---
title: مدیریت فریم‌های ویدیو در ارائه‌ها در .NET
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/net/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- جاسازی ویدیو
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
description: "یادگیری برنامه‌نویسی برای افزودن و استخراج فریم‌های ویدیو در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET. راهنمای سریع."
---
## **معرفی**

ویدیوها می‌توانند به توضیح ایده‌ها کمک کنند و مخاطب را درگیر کنند. Aspose.Slides برای .NET به شما امکان می‌دهد فریم‌های ویدیو را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدیو جاسازی‌شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایندگی داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) ، [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدئویی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید فریم ویدئویی ایجاد کنید تا ویدیو را در ارائهٔ خود جاسازی کنید.

این مثال یک ویدئوی محلی را در اسلاید اول یک ارائهٔ موجود جاسازی می‌کند و نتیجه را ذخیره می‌کند. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) در طول استفادهٔ ارائه آن را قفل می‌کند.

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

همچنین می‌توانید مسیر ویدئوی محلی را به‌صورت مستقیم به [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) پاس دهید. این مثال ویدئو را در اسلاید اول یک ارائهٔ جدید جاسازی می‌کند. ویدئو باید تا زمان ذخیره‌سازی ارائه در دسترس بماند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **تنظیم دقیق حجم ویدیو**

در Aspose.Slides برای .NET 26.11 یا نسخه‌های بعدی، [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) یک درصد شناور از 0 تا 100 تنظیم می‌کند. هنگامی که پیش‌تنظیم‌های [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) خیلی درشت هستند، از این مورد استفاده کنید. به عنوان مثال، `75.5f` مقدار 75.5٪ حجم را درخواست می‌کند.

این مثال به [Aspose.Slides برای .NET](/slides/fa/net/installation/) 26.11 یا نسخهٔ جدیدتر و یک فایل `video.mp4` محلی نیاز دارد. ویدئو را جاسازی می‌کند، به‌صورت صریح پخش را مقداردهی اولیه می‌کند، ارائه را ذخیره می‌کند و درصد ذخیره‌شده را می‌خواند.

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

ورودی را خودتان اعتبارسنجی کنید؛ به setter برای رد مقادیر خارج از بازهٔ مستند تکیه نکنید. پیش‌تنظیم‌های Low، Medium و Loud در نسخهٔ 26.11 به ترتیب برابر 20، 50 و 80 هستند. تنظیم یک پیش‌تنظیم می‌تواند درصد قبلی را جایگزین کند، بنابراین هنگام نیاز به مقدار دقیق، درصد را در انتها اختصاص دهید. برای تنظیم صریح بی‌صدا از [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) استفاده کنید؛ صفر عددی و enum پیش‌تنظیم حالت‌های متقابلاً قابل تعویض نیستند.

هنگام پیکربندی یک ویدئوی پیوندی نیز به‌صو‌ر صریح [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) را تنظیم کنید و فایل رسانه‌ای آن را برای بیننده در دسترس نگه دارید. ذخیره و بازگشایی تنظیم ذخیره‌شده را تأیید می‌کند؛ پخش واقعی و صدای بلند بستگی به پخش‌کنندهٔ ارائه و تنظیمات صوتی آن دارد.

## **ایجاد فریم ویدئویی با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدئویی ایجاد کنید که به یک ویدئوی آنلاین، مانند یک ویدئوی YouTube، لینک داشته باشد.

این مثال پیوند ویدئوی YouTube و تصویر بندانگشتی آن را به اسلاید اول اضافه می‌کند. شناسهٔ ویدئو را جایگزین کنید تا از ویدئوی دیگری استفاده شود. تنظیم [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) درخواست پخش خودکار می‌کند. دریافت تصویر بندانگشتی و پخش ویدئو نیازمند دسترسی به اینترنت است. بینندهٔ ارائه نیز باید از پخش ویدئوهای آنلاین پشتیبانی کند.

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

## **پخش ویدیو در حالت تمام‌صفحه**

در یک ارائهٔ آموزشی، می‌توانید یک دموی نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. برای فعال‌سازی این رفتار در حین پخش، [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) را به `true` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائهٔ ورودی باید حداقل یک اسلاید با یک فریم ویدئویی موجود در اسلاید اول داشته باشد.

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

پخش تمام‌صفحه نحوهٔ نمایش ویدئو را کنترل می‌کند. به‌طور مستقل، [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود، و [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto یا VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقهٔ موجود را حفظ می‌کند.

## **به عقب بردن ویدیو پس از پخش**

در یک ارائهٔ آموزشی، بازگرداندن ویدئوی دموی به ابتدای خود باعث می‌شود برای ارائه‌دهنده آمادهٔ پخش مجدد باشد. برای برگرداندن ویدئو به ابتدا پس از پایان پخش، [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) را به `true` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) را در اسلاید اول پیدا می‌کند و بازگشت را فعال می‌سازد. حلقه‌بندی غیرفعال می‌شود تا پخش بتواند تمام شود و پخش برای شروع با کلیک تنظیم می‌شود. ارائهٔ ورودی باید حداقل یک اسلاید با یک فریم ویدئویی موجود در اسلاید اول داشته باشد.

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

بازگرداندن ویدئو را بدون شروع مجدد آن به ابتدای خود برمی‌گرداند. در مقابل، فعال‌سازی [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدئو به پایان برسد و آمادهٔ پخش مجدد بماند، حلقه‌بندی را غیرفعال نگه دارید. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) به‌طور مستقل شروع خودکار یا با کلیک را کنترل می‌کند؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. همان‌طور که در مثال نشان داده شده است، حالت پخش پس از تنظیم حلقه تنظیم می‌شود. بازگرداندن به‌صورت مستقل از [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) عمل می‌کند.

## **برش فریم ویدیو**

از [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) و [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) برای رد کردن بخشی از شروع یا انتهای ویدیو هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدئوی جاسازی‌شده تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدئوی محلی را جاسازی می‌کند و در طول پخش اولین 2.5 ثانیه و آخرین یک ثانیه را رد می‌کند. از ویدئویی که طول آن بیش از 3.5 ثانیه باشد استفاده کنید تا بخشی قابل پخش باقی بماند.

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

این مثال مقادیر برش فریم ویدئوی اول در اسلاید اول را بر حسب میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدئویی نداشته باشد، چیزی چاپ نمی‌شود. مثال قبلی مقادیر 2500 و 1000 تولید می‌کند.

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

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق ویژگی [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) در دسترس هستند.

### **افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدئوی محلی را جاسازی می‌کند و یک ردیف زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌سنجی زیرنویس باید با ویدئو مطابقت داشته باشد. ارائهٔ ذخیره‌شده هم ویدئو و هم زیرنویس‌های آن را شامل می‌شود.

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

رابط [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) همچنین یک overload دارد که به شما امکان می‌دهد زیرنویس‌ها را از یک جریان اضافه کنید.

### **استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام ردیف‌های زیرنویس را از فریم‌های ویدیو در اسلاید اول به‌صورت فایل‌های جداگانهٔ WebVTT ذخیره می‌کند. شماره‌های متوالی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد ردیف‌های استخراج شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به عنوان یک رشتهٔ UTF-8 در دسترس قرار می‌دهد.

### **حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدئویی که در اولین موقعیت شکل در اسلاید اول قرار دارد حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدئویی باشد.

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

اگر فقط نیاز به حذف یک ردیف زیرنویس داشته باشید، به‌جای [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) از متدهای [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) استفاده کنید.

### **جستجوی زیرنویس‌های ویدیو**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) کل ردیف WebVTT را شامل سرآیند، خطوط زمان‌بندی و متن زیرنویس برمی‌گرداند. برای یافتن عبارت گفتاری و زمان‌سنجی آن، نشانه‌ها را در حافظه بخوانید. به عنوان مثال، یک ردیف انگلیسی در اسلاید 2 ممکن است متن زیر را داشته باشد:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

مثال هر اسلاید را بازدید می‌کند و ردیف‌های فریم‌های ویدئوی سطح بالای آن را از طریق [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) می‌خوانَد. در یک نشانهٔ متن ساده، خط زمان‌بندی شامل `-->` است و یک خط خالی پایان نشانه را نشان می‌دهد. وقتی متن زیرنویس شامل «café» باشد، مثال شمارهٔ اسلاید، برچسب ردیف، خط زمان‌بندی اصلی و کل زیرنویس را چاپ می‌کند.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

جستجو برای «café» یک مطابقت برای ردیف نمونه تولید می‌کند. سرآیند و تنظیم زمان‌بندی خارج از متن نشانه هستند.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیو به اسلایدها، Aspose.Slides به شما اجازه می‌دهد ویدیوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

این مثال ویدیوهای جاسازی‌شده را از هر اسلاید به‌صورت فایل‌های باینری شماره‌دار جداگانه استخراج می‌کند. ویدیوهای پیوندی نادیده گرفته می‌شوند چون هیچ دادهٔ جاسازی‌شده‌ای ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را به پسوند متناسب با نوع رسانهٔ گزارش‌شده تغییر دهید.

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

**کدام پارامترهای پخش ویدیو می‌توان برای فریم ویدیو تغییر داد؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto یا on click) و [حلقه‌بندی](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) در دسترس‌اند.

**آیا افزودن ویدیو بر حجم فایل PPTX تأثیر دارد؟**

بله. زمانی که یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین حجم ارائه متناسب با حجم فایل افزایش می‌یابد. وقتی به‌جای آن به یک ویدئوی آنلاین لینک می‌زنید و تصویر بندانگشتی اضافه می‌کنید، ارائه تنها پیوند و تصویر پیش‌نمایش را ذخیره می‌کند و دادهٔ ویدئو را نگه نمی‌دارد، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توان ویدئو را در یک فریم ویدئویی موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کرد؟**

بله. می‌توانید محتوای [ویدئو](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) را در داخل فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این سناریوی رایج برای به‌روزرسانی رسانه در یک چیدمان موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای [نوع محتوا](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی به دیسک.