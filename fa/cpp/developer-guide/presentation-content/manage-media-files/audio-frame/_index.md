---
title: مدیریت صدا در ارائه‌ها با استفاده از C++
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/cpp/audio-frame/
keywords:
- صدا
- فریم صوتی
- تصویر نمایه
- افزودن صدا
- ویژگی‌های صدا
- گزینه‌های صدا
- استخراج صدا
- C++
- Aspose.Slides
description: "ایجاد و کنترل فریم‌های صوتی در Aspose.Slides برای C++ — مثال‌های کد برای جاسازی، برش، حلقه‌گذاری و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با فریم‌های صوتی در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه صداهای جاسازی‌شده را به اسلایدها اضافه کنید، تصویر نمایه فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند حجم، حلقه‌کاری، مخفی‌سازی، برش و مدت زمان محو شدن را پیکربندی کنید و صداهای استفاده‌شده در انتقال‌های نمایش اسلاید را استخراج کنید.

## **ایجاد فریم‌های صوتی**

Aspose.Slides برای C++ به شما امکان می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. فایل‌های صوتی به‌صورت فریم‌های صوتی در اسلایدها جاسازی می‌شوند. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. جریان فایل صوتی که می‌خواهید در اسلاید جاسازی کنید را بارگذاری کنید.
4. فریم صوتی جاسازی‌شده (شامل فایل صوتی) را به اسلاید اضافه کنید.
5. مقدار [PlayMode](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) و `Volume` که توسط شیء [IAudioFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_audio_frame) در دسترس است را تنظیم کنید.
6. ارائه (Presentation) اصلاح‌شده را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک فریم صوتی جاسازی‌شده را به یک اسلاید اضافه کنید:

``` cpp
// نمونه‌ای از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
auto pres = System::MakeObject<Presentation>();

// اسلاید اول را می‌گیرد
auto sld = pres->get_Slides()->idx_get(0);

// فایل صوتی wav را به جریان بارگذاری می‌کند
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// فریم صوتی را اضافه می‌کند
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// حالت پخش و حجم صدا را تنظیم می‌کند
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// فایل PowerPoint را بر روی دیسک می‌نویسد
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **تغییر تصویر نمایه فریم صوتی**

زمانی که یک فایل صوتی را به یک ارائه اضافه می‌کنید، صدا به‌صورت یک فریم با تصویر پیش‌فرض استاندارد نمایش داده می‌شود (به تصویر در بخش زیر نگاه کنید). می‌توانید تصویر نمایه فریم صوتی را تغییر دهید (تصویر دلخواه خود را تنظیم کنید).

این کد C++ نشان می‌دهد چگونه تصویر نمایه یا پیش‌نمایش یک فریم صوتی را تغییر دهید:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// یک فریم صوتی را به اسلاید اضافه می‌کند با موقعیت و اندازه مشخص.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// یک تصویر به منابع ارائه اضافه می‌کند.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// تصویر را برای فریم صوتی تنظیم می‌کند.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// ارائه اصلاح‌شده را بر روی دیسک ذخیره می‌کند
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تغییر گزینه‌های پخش صدا**

Aspose.Slides برای C++ به شما امکان می‌دهد گزینه‌هایی را که کنترل پخش یا ویژگی‌های یک صدا را دارند، تغییر دهید. برای مثال، می‌توانید حجم صدا را تنظیم کنید، صدا را به‌صورت حلقه‌ای پخش کنید، یا حتی آیکون صدا را مخفی کنید.

قاب **Audio Options** در Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

گزینه‌های **Audio Options** در PowerPoint که متناظر با متدهای Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/) هستند:

- فهرست کشویی **Start** با متد [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_playmode/) مطابقت دارد
- **Volume** با متد [AudioFrame::set_Volume](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_volume/) مطابقت دارد
- **Play Across Slides** با متد [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_playacrossslides/) مطابقت دارد
- **Loop until Stopped** با متد [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_playloopmode/) مطابقت دارد
- **Hide During Show** با متد [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_hideatshowing/) مطابقت دارد
- **Rewind after Playing** با متد [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_rewindaudio/) مطابقت دارد

گزینه‌های **Editing** در PowerPoint که متناظر با ویژگی‌های Aspose.Slides [AudioFrame] هستند:

- **Fade In** با متد [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_fadeinduration/) مطابقت دارد
- **Fade Out** با متد [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_fadeoutduration/) مطابقت دارد
- **Trim Audio Start Time** با متد [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_trimfromstart/) مطابقت دارد
- مقدار **Trim Audio End Time** برابر است با طول صدا منهای مقدار متد [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_trimfromend/)

کنترل **Volume** در PowerPoint که بر روی پانل کنترل صدا قرار دارد، با متد [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_volumevalue/) متناظر است. این امکان را می‌دهد تا حجم صدا را به‌صورت درصدی تنظیم کنید.

این روش برای تغییر گزینه‌های پخش صدا است:

1. [ایجاد](#creating-audio-frame) یا فریم صوتی را دریافت کنید.
2. مقادیر جدید برای ویژگی‌های فریم صوتی که می‌خواهید تنظیم کنید را تعیین کنید.
3. فایل PowerPoint اصلاح‌شده را ذخیره کنید.

این کد C++ عملی را نشان می‌دهد که در آن گزینه‌های یک صدا تنظیم می‌شوند:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// یک شکل را دریافت می‌کند
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// شکل را به یک فریم صوتی تبدیل می‌کند
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// حالت پخش را روی کلیک تنظیم می‌کند
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// حجم را به کم تنظیم می‌کند
audioFrame->set_Volume(AudioVolumeMode::Low);

// صدای را طوری تنظیم می‌کند که در تمام اسلایدها پخش شود
audioFrame->set_PlayAcrossSlides(true);

// حلقه‌پذیری صدا را غیرفعال می‌کند
audioFrame->set_PlayLoopMode(false);

// فریم صوتی را در طول نمایش اسلاید مخفی می‌کند
audioFrame->set_HideAtShowing(true);

// پس از پخش، صدا را به شروع باز می‌گرداند
audioFrame->set_RewindAudio(true);

// فایل PowerPoint را بر روی دیسک ذخیره می‌کند
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

این مثال C++ نشان می‌دهد چگونه یک فریم صوتی جدید با صداهای جاسازی‌شده اضافه کنید، آن را برش دهید و مدت زمان محو شدن را تنظیم کنید:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

نمونه کد زیر نشان می‌دهد چگونه یک فریم صوتی با صداهای جاسازی‌شده بازیابی کنید و حجم آن را به 85 درصد تنظیم کنید:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// یک شکل فریم صوتی را دریافت می‌کند
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// حجم صدا را به 85% تنظیم می‌کند
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **مدیریت زیرنویس‌های صوتی**

Aspose.Slides به شما امکان می‌دهد تا زیرنویس‌های بسته را به یک فریم صوتی از طریق متد [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudioframe/get_captiontracks/) اضافه کنید. این متد یک شیء [ICaptionsCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/) را بر می‌گرداند که به شما اجازه می‌دهد ردیف‌های زیرنویس WebVTT را اضافه کنید، در ردیف‌های موجود پیمایش کنید و در صورت نیاز آن‌ها را حذف کنید.

### **اضافه کردن زیرنویس‌های صوتی**

از متد [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudioframe/get_captiontracks/) برای پیوست یک یا چند ردیف زیرنویس به یک فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس یک ردیف زیرنویس جدید از یک فایل `.vtt` بارگذاری می‌شود.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **استخراج زیرنویس‌های صوتی**

می‌توانید در ردیف‌های زیرنویس مرتبط با یک فریم صوتی پیمایش کنید و آن‌ها را به‌صورت فایل‌های `.vtt` ذخیره کنید. هر ردیف زیرنویس داده‌های باینری و شناسه منحصر به فرد خود را ارائه می‌دهد که می‌تواند هنگام استخراج زیرنویس‌ها استفاده شود.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // هر ردیف زیرنویس را به‌صورت فایل .vtt ذخیره کنید.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

### **حذف زیرنویس‌های صوتی**

برای حذف زیرنویس‌ها از یک فریم صوتی، از متدهای ارائه‌شده توسط [ICaptionsCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/) استفاده کنید، مانند [Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/clear/)، [Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/remove/)، یا [RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/removeat/). مثال زیر تمام ردیف‌های زیرنویس را از یک فریم صوتی حذف می‌کند.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// تمام ردیف‌های زیرنویس را از فریم صوتی حذف کنید.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استخراج صدا**

Aspose.Slides به شما اجازه می‌دهد صدای استفاده‌شده در انتقال‌های نمایش اسلاید را استخراج کنید. برای مثال، می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید و ارائه‌ای که شامل صدا است را بارگذاری کنید.
2. مرجع اسلاید مرتبط را از طریق ایندکس آن دریافت کنید.
3. به انتقال‌های نمایش اسلاید برای این اسلاید دسترسی پیدا کنید.
4. صدا را به‌صورت داده‌های بایتی استخراج کنید.

این کد C++ نشان می‌دهد چگونه صدای استفاده‌شده در یک اسلاید را استخراج کنید:

``` cpp
String presName = u"AudioSlide.pptx";

// نمونه‌ای از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
auto pres = System::MakeObject<Presentation>(presName);

// اسلاید موردنظر را دریافت می‌کند
auto slide = pres->get_Slides()->idx_get(0);

// افکت‌های انتقال نمایش اسلاید را برای اسلاید دریافت می‌کند
auto transition = slide->get_SlideShowTransition();

// صدا را به‌صورت آرایه بایتی استخراج می‌کند
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **سوالات متداول**

**آیا می‌توانم از همان دارایی صوتی در چندین اسلاید بدون افزایش حجم فایل استفاده کنم؟**

بله. صدا را یک بار به [audio collection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_audios/) مشترک ارائه اضافه کنید و فریم‌های صوتی اضافی ایجاد کنید که به آن دارایی موجود ارجاع می‌دهند. این کار از تکرار داده‌های رسانه‌ای جلوگیری می‌کند و اندازه ارائه را تحت کنترل نگه می‌دارد.

**آیا می‌توانم صدا را در یک فریم صوتی موجود بدون ایجاد دوباره شکل جایگزین کنم؟**

بله. برای صدای لینک‌دار، مسیر [link path](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_linkpathlong/) را به فایل جدید اشاره دهید. برای صدای جاسازی‌شده، شیء [embedded audio](https://reference.aspose.com/slides/fa/cpp/aspose.slides/audioframe/set_embeddedaudio/) را با دیگری از [audio collection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_audios/) ارائه تعویض کنید. قالب‌بندی فریم و اکثر تنظیمات پخش بدون تغییر باقی می‌مانند.

**آیا برش تغییرات در داده‌های صوتی اصلی که در ارائه ذخیره شده است ایجاد می‌کند؟**

خیر. برش فقط محدوده‌های پخش را تنظیم می‌کند. بایت‌های اصلی صدا دست نخورده می‌مانند و از طریق صداهای جاسازی‌شده یا [audio collection] ارائه قابل دسترسی هستند.