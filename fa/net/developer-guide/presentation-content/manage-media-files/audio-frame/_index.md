---
title: مدیریت فریم‌های صوتی در ارائه‌ها در .NET
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/net/audio-frame/
keywords:
- صدا
- فریم صوتی
- تصویر بندانگشتی
- افزودن صدا
- ویژگی‌های صدا
- گزینه‌های صدا
- استخراج صدا
- .NET
- C#
- Aspose.Slides
description: "ایجاد و کنترل فریم‌های صوتی در Aspose.Slides برای .NET — مثال‌های C# برای توکار کردن، برش، حلقه‌دار کردن و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با فریم‌های صوتی در Aspose.Slides کار کنید. نشان می‌دهد چگونه صدا را به صورت توکار به اسلایدها اضافه کنید، تصویر بندانگشتی فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند حجم، حلقه، مخفی‌سازی، برش و مدت زمان محو شدن را تنظیم کنید و صداهای استفاده‌شده در انتقال‌های اسلایدشو را استخراج کنید.

## **ایجاد فریم‌های صوتی**

Aspose.Slides برای .NET به شما امکان می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. این فایل‌های صوتی به صورت فریم‌های صوتی در اسلایدها توکار می‌شوند.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.
3. جریان فایل صوتی مورد نظر برای توکار کردن در اسلاید را بارگذاری کنید.
4. فریم صوتی توکار (شامل فایل صوتی) را به اسلاید اضافه کنید.
5. مقدارهای [PlayMode](https://reference.aspose.com/slides/fa/net/aspose.slides/audioplaymodepreset) و `Volume` را که توسط شیء [IAudioFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe) در دسترس است، تنظیم کنید.
6. ارائه‌ی اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک فریم صوتی توکار به یک اسلاید اضافه کنید:

```c#
// یک نمونه از کلاس ارائه ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد
using (Presentation pres = new Presentation())
{
    // اسلاید اول را دریافت می‌کند
    ISlide sld = pres.Slides[0];
    
    // فایل صوتی wav را به صورت جریان بارگذاری می‌کند
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // فریم صوتی را اضافه می‌کند
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // حالت پخش و حجم صدا را تنظیم می‌کند
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // فایل PowerPoint را روی دیسک می‌نویسد
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **تغییر تصویر بندانگشتی فریم صوتی**

زمانی که یک فایل صوتی به ارائه اضافه می‌شود، صدا به شکل فریمی با تصویر پیش‌فرض استاندارد ظاهر می‌شود (نگاه کنید به تصویر در بخش زیر). می‌توانید تصویر بندانگشتی فریم صوتی را به تصویر دلخواه خود تغییر دهید.

این کد C# نشان می‌دهد چگونه تصویر بندانگشتی یا پیش‌نمایش فریم صوتی را تغییر دهید:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // یک فریم صوتی به اسلاید اضافه می‌کند با موقعیت و اندازهٔ مشخص.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // یک تصویر را به منابع ارائه اضافه می‌کند.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // تصویر را برای فریم صوتی تنظیم می‌کند.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//ارائهٔ اصلاح‌شده را روی دیسک ذخیره می‌کند
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **تغییر گزینه‌های پخش صوتی**

Aspose.Slides برای .NET به شما امکان می‌دهد گزینه‌هایی که رفتار پخش صدا را کنترل می‌کنند تغییر دهید. به عنوان مثال می‌توانید حجم صدا را تنظیم کنید، صدا را به صورت حلقه‌ای پخش کنید یا حتی نماد صدا را مخفی کنید.

قاب **Audio Options** در Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

گزینه‌های **Audio Options** در PowerPoint که به ویژگی‌های Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe) مربوط می‌شوند:

- منوی کشویی **Start** به ویژگی [AudioFrame.PlayMode](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/properties/playmode) مطابقت دارد
- **Volume** به ویژگی [AudioFrame.Volume](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/properties/volume) مطابقت دارد
- **Play Across Slides** به ویژگی [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/properties/playacrossslides) مطابقت دارد
- **Loop until Stopped** به ویژگی [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/properties/playloopmode) مطابقت دارد
- **Hide During Show** به ویژگی [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/properties/hideatshowing) مطابقت دارد
- **Rewind after Playing** به ویژگی [AudioFrame.RewindAudio](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/properties/rewindaudio) مطابقت دارد

گزینه‌های **Editing** در PowerPoint که به ویژگی‌های Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe) مربوط می‌شوند:

- **Fade In** به ویژگی [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/fadeinduration/) مطابقت دارد
- **Fade Out** به ویژگی [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/fadeoutduration/) مطابقت دارد
- **Trim Audio Start Time** به ویژگی [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/trimfromstart/) مطابقت دارد
- مقدار **Trim Audio End Time** برابر است با مدت زمان صدا منهای مقدار ویژگی [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/trimfromend/)

کنترل **Volume** در پنل کنترل صوتی PowerPoint به ویژگی [AudioFrame.VolumeValue](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/volumevalue/) مرتبط است و به شما امکان تغییر حجم صدا به صورت درصدی را می‌دهد.

این روش برای تغییر گزینه‌های پخش صوتی است:

1. **Create** یا فریم صوتی را دریافت کنید.
2. مقادیر جدید برای ویژگی‌های فریم صوتی که می‌خواهید تنظیم کنید، اعمال کنید.
3. فایل PowerPoint اصلاح‌شده را ذخیره کنید.

این کد C# عملی را نشان می‌دهد که در آن گزینه‌های صدا تنظیم می‌شوند:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // شکل AudioFrame را دریافت می‌کند
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // حالت پخش را روی کلیک تنظیم می‌کند
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // حجم را روی کم تنظیم می‌کند
    audioFrame.Volume = AudioVolumeMode.Low;

    // صدا را تنظیم می‌کند تا در تمام اسلایدها پخش شود
    audioFrame.PlayAcrossSlides = true;

    // حلقه‌سازی صدا را غیرفعال می‌کند
    audioFrame.PlayLoopMode = false;

    // فریم صوتی را در حین نمایش اسلاید مخفی می‌کند
    audioFrame.HideAtShowing = true;

    // صدا را پس از پخش به شروع باز می‌گرداند
    audioFrame.RewindAudio = true;

    // فایل PowerPoint را روی دیسک ذخیره می‌کند
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

این مثال C# نشان می‌دهد چگونه یک فریم صوتی جدید با صدا توکار اضافه کنید، آن را برش دهید و مدت زمان محو شدن را تنظیم کنید:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // آفست شروع برش را به ۱٫۵ ثانیه تنظیم می‌کند
    audioFrame.TrimFromStart = 1500f;
    // آفست پایان برش را به ۲ ثانیه تنظیم می‌کند
    audioFrame.TrimFromEnd = 2000f;

    // مدت زمان محو شدن ورودی را به ۲۰۰ میلی‌ثانیه تنظیم می‌کند
    audioFrame.FadeInDuration = 200f;
    // مدت زمان محو شدن خروجی را به ۵۰۰ میلی‌ثانیه تنظیم می‌کند
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

نمونه کد زیر نمایش می‌دهد چگونه یک فریم صوتی توکار را بازیابی کرده و حجم آن را روی ۸۵٪ تنظیم کنید:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // یک شکل فریم صوتی را دریافت می‌کند
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // حجم صدا را به ۸۵٪ تنظیم می‌کند
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **مدیریت زیرنویس‌های صوتی**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته به یک فریم صوتی از طریق ویژگی [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudioframe/captiontracks/) اضافه کنید. این ویژگی یک [ICaptionsCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptionscollection/) را برمی‌گرداند که به شما اجازه می‌دهد پیوندهای زیرنویس WebVTT را اضافه کنید، در میان پیوندهای موجود مرور کنید و در صورت نیاز آن‌ها را حذف کنید.

**افزودن زیرنویس صوتی**

از ویژگی [CaptionTracks](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudioframe/captiontracks/) برای پیوست یک یا چند پیوند زیرنویس به فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس یک پیوند زیرنویس جدید از یک فایل `.vtt` بارگذاری می‌شود.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // یک مسیر زیرنویس جدید از فایل WebVTT اضافه می‌کند.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**استخراج زیرنویس‌های صوتی**

می‌توانید در میان پیوندهای زیرنویس مرتبط با یک فریم صوتی مرور کنید و آن‌ها را به صورت فایل‌های `.vtt` ذخیره کنید. هر پیوند زیرنویس داده‌های باینری و شناسهٔ یکتای خود را در اختیار می‌گذارد که هنگام خروجی‌گیری زیرنویس‌ها قابل استفاده است.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // مسیر زیرنویس را به عنوان یک فایل .vtt ذخیره می‌کند.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**حذف زیرنویس‌های صوتی**

برای حذف زیرنویس‌ها از یک فریم صوتی، از متدهای ارائه‌شده توسط [ICaptionsCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptionscollection/) مانند [Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptionscollection/clear/)، [Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptionscollection/remove/)، یا [RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/icaptionscollection/removeat/) استفاده کنید. مثال زیر تمام پیوندهای زیرنویس را از یک فریم صوتی حذف می‌کند.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // تمام مسیرهای زیرنویس را از فریم صوتی حذف می‌کند.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **استخراج صدا**

Aspose.Slides برای .NET به شما امکان می‌دهد صدای استفاده‌شده در انتقال‌های اسلایدشو را استخراج کنید. به عنوان مثال می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید و ارائه‌ای که حاوی صدا است را بارگذاری کنید.
2. مرجع اسلاید مربوطه را از طریق شاخص آن دریافت کنید.
3. به انتقال‌های اسلایدشو برای این اسلاید دسترسی پیدا کنید.
4. صدا را به صورت داده بایت استخراج کنید.

این کد C# نشان می‌دهد چگونه صدای استفاده‌شده در یک اسلاید را استخراج کنید:

```c#
string presName = "AudioSlide.pptx";

// یک نمونه از کلاس Presentation ایجاد می‌کند که یک فایل ارائه را نشان می‌دهد
Presentation pres = new Presentation(presName);

// Accesses the slide
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**آیا می‌توانم همان دارایی صوتی را در چندین اسلاید استفاده کنم بدون اینکه حجم فایل افزایش یابد؟**

بله. صدا را یک‌بار به [audio collection](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/audios/) مشترک ارائه اضافه کنید و فریم‌های صوتی اضافه‌ای که به آن دارایی موجود ارجاع می‌دهند ایجاد کنید. این کار از تکرار داده‌های رسانه‌ای جلوگیری کرده و اندازه ارائه را تحت کنترل نگه می‌دارد.

**آیا می‌توانم صدا را در یک فریم صوتی موجود بدون بازسازی شکل جایگزین کنم؟**

بله. برای صداهای پیوندی مسیر [link path](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/linkpathlong/) را به فایل جدید تغییر دهید. برای صداهای توکار، شیء [embedded audio](https://reference.aspose.com/slides/fa/net/aspose.slides/audioframe/embeddedaudio/) را با صوت دیگری از [audio collection](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/audios/) تعویض کنید. قالب‌بندی فریم و اکثر تنظیمات پخش دست نخورده باقی می‌مانند.

**آیا برش صدا داده‌های صوتی زیرین ذخیره‌شده در ارائه را تغییر می‌دهد؟**

خیر. برش فقط مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صوت بدون تغییر باقی می‌مانند و از طریق صداهای توکار یا مجموعهٔ صوتی ارائه در دسترس هستند.