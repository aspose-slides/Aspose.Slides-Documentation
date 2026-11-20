---
title: مدیریت چارچوب‌های صوتی در ارائه‌ها با .NET
linktitle: چارچوب صوتی
type: docs
weight: 10
url: /fa/net/audio-frame/
keywords:
- صدا
- چارچوب صوتی
- تصویر بندانگشتی
- افزودن صدا
- ویژگی‌های صدا
- گزینه‌های صدا
- استخراج صدا
- .NET
- C#
- Aspose.Slides
description: "صدا را در اسلایدها جاسازی کنید، آیکون صوتی را تغییر دهید، تنظیمات پخش را پیکربندی کنید، زیرنویس‌های WebVTT را مدیریت کنید و صداهای انتقال اسلایدها را با Aspose.Slides برای .NET استخراج کنید."
---
## **بررسی کلی**

یک چارچوب صوتی به شما امکان می‌دهد صدایی را روی اسلاید پخش کنید. با Aspose.Slides for .NET می‌توانید یک کلیپ صوتی را جاسازی کنید، تصویری که آن را نشان می‌دهد انتخاب کنید، تنظیمات پخش را تنظیم کنید و زیرنویس‌ها را پیوست کنید. همچنین می‌توانید صدایی را که به یک انتقال اسلاید اختصاص داده شده است بازیابی کنید.

## **ایجاد چارچوب‌های صوتی**

از [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) برای جاسازی یک کلیپ صوتی محلی در اسلاید اول استفاده کنید. دو مختصه اول مکان چارچوب را روی اسلاید تعیین می‌کند و دو مقدار بعدی عرض و ارتفاع آن را بر حسب نقطه (points) تنظیم می‌کند. این مثال [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) را برای شروع خودکار کلیپ و [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) را روی پیش‌تنظیم «بلند» قرار می‌دهد.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **تغییر تصویر بندانگشتی چارچوب صوتی**

به‌طور پیش‌فرض، یک چارچوب صوتی یک آیکون بلندگو نمایش می‌دهد. برای نمایش یک تصویر بندانگشتی سفارشی، یک تصویر را با [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) به ارائه اضافه کنید و آن را به ویژگی [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) چارچوب اختصاص دهید. مثال از یک فایل JPEG به‌عنوان تصویر بندانگشتی برای یک کلیپ صوتی جاسازی‌شده استفاده می‌کند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **تغییر گزینه‌های پخش صدا**

کنترل‌های **Audio Options** در PowerPoint تعیین می‌کنند که یک کلیپ چه زمانی شروع شود، چقدر صدا داشته باشد و در طول نمایش اسلایدها چگونه رفتار کند.

![کنترل‌های گزینه‌های صدا در PowerPoint برای یک فریم صوتی](audio_frame_0.png)

| کنترل PowerPoint | خاصیت Aspose.Slides |
| --- | --- |
| Start | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Volume preset | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Play Across Slides | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Loop until Stopped | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Hide During Show | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Rewind after Playing | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Fade In | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Fade Out | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Trim Audio start time | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Trim Audio end time | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Volume slider | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

مثال اولین چارچوب صوتی را در اسلاید اول پیدا می‌کند، [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) را برای شروع پخش با کلیک تنظیم می‌کند و پیش‌تنظیم صدا کم را انتخاب می‌نماید. کلیپ در اسلایدها ادامه می‌یابد در حالی که حلقه‌زدن غیرفعال است. آیکون در طول نمایش مخفی می‌ماند و پس از پخش کلیپ بازپخش می‌شود.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

برای کلیپی که طول آن بیش از ۳.۵ ثانیه است، این مثال ۱٫۵ ثانیه اول و ۲ ثانیه آخر را حذف می‌کند. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) مدتی را که باید از انتهای کلیپ حذف شود می‌سنجد. برای به‌دست آوردن زمان پایان نشان‌داده‌شده در PowerPoint، این مقدار را از کل مدت کلیپ کم می‌کنید. کلیپ برش‌خورده در ۲۰۰ میلی‌ثانیه به‌تدریج ظاهر می‌شود و در ۵۰۰ میلی‌ثانیه به‌تدریج ناپدید می‌گردد. تمام این چهار ویژگی مقادیرشان بر حسب میلی‌ثانیه است.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

برای تنظیم حجم پخش به درصد خاصی، از [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) استفاده کنید. این مثال حجم چارچوب صوتی اول در اسلاید اول را روی ۸۵٪ تنظیم می‌کند.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **مدیریت زیرنویس‌های صوتی**

هر چارچوب صوتی دارای مجموعه‌ای به نام [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) است. از آن برای پیوست کردن زیرنویس‌های WebVTT به کلیپ، خروجی گرفتن از مسیرهای موجود یا حذف آن‌ها استفاده کنید.

### **افزودن زیرنویس صوتی**

مثال یک کلیپ صوتی را در اسلاید اول جاساز می‌کند و با [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) یک مسیر WebVTT محلی را پیوست می‌کند. آرگومان اول برچسب مسیر را تامین می‌کند و آرگومان دوم فایلی را که شامل زیرنویس‌های زمان‌دار است شناسایی می‌کند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **استخراج زیرنویس‌های صوتی**

این مثال هر مسیر زیرنویس الصاق‌شده به یک چارچوب صوتی در اسلاید اول را خروجی می‌گیرد. داده‌های باینری مسیر را با استفاده از [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) در یک فایل WebVTT می‌نویسد و از [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) به عنوان نام فایل استفاده می‌کند تا هر مسیر خروجی جداگانه داشته باشد.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **حذف زیرنویس‌های صوتی**

از [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) برای حذف یک مسیر خاص استفاده کنید. مثال با [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) تمام زیرنویس‌ها را از اولین چارچوب صوتی در اسلاید اول حذف می‌کند در حالی که کلیپ حفظ می‌شود.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **یافتن خطی در زیرنویس‌های صوتی**

برای یافتن یک خط در زیرنویس‌های صوتی اسلاید اول، هر مسیر را با استفاده از [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) در حافظه می‌خوانید. در یک Cue متنی ساده WebVTT، خط زمان شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی Cue را خاتمه می‌دهد. این مثال برچسب مسیر و هر خط زیرنویسی که حاوی «café» است را چاپ می‌کند.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **استخراج صدا**

یک انتقال اسلاید می‌تواند صدای خود را داشته باشد. برای بازیابی آن، ویژگی [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) انتقال را می‌خوانید. مثال داده‌های باینری صدا را با استفاده از [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) دسترسی می‌یابد و اندازه آن را به بایت چاپ می‌کند. اگر اسلاید اول صدای انتقال نداشته باشد، به‌جای آن یک پیام نمایش می‌دهد.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **سوالات متداول**

**آیا می‌توانم همان کلیپ صوتی را در چندین اسلاید بدون تکرار استفاده کنم؟**

بله. کلیپ را یک‌بار به [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) ارائه اضافه کنید و همان شیء صوتی را برای هر اسلاید به [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) پاس بدهید.

**آیا می‌توانم صدا را در یک چارچوب صوتی موجود جایگزین کنم؟**

بله. برای صدای پیوندی، [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) را به مسیر فایل جایگزین تغییر دهید. برای صدای جاسازی‌شده، یک کلیپ دیگر از مجموعه صوتی ارائه را به [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) اختصاص دهید. هر دو روش چارچوب موجود را حفظ می‌کنند.

**آیا برش صدا داده‌های صوتی ذخیره‌شده در ارائه را تغییر می‌دهد؟**

نه. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) و [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) فقط مرزهای پخش را تنظیم می‌کنند. همچنان می‌توانید کلیپ کامل را از [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) دریافت کنید.