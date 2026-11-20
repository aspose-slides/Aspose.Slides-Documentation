---
title: مدیریت قاب‌های صوتی در ارائه‌ها با C++
linktitle: قاب صوتی
type: docs
weight: 10
url: /fa/cpp/audio-frame/
keywords:
- صوت
- قاب صوتی
- تصویر بندانگشتی
- اضافه کردن صدا
- ویژگی‌های صوتی
- گزینه‌های صوتی
- استخراج صدا
- C++
- Aspose.Slides
description: "صوت را در اسلایدها جاسازی کنید، آیکون صوتی را تغییر دهید، پخش را پیکربندی کنید، زیرنویس‌های WebVTT را مدیریت کنید، و صداهای انتقال اسلاید را با Aspose.Slides برای C++ استخراج کنید."
---
## **مرور کلی**

یک قاب صوتی به شما امکان می‌دهد صدایی را در یک اسلاید پخش کنید. با Aspose.Slides for C++ می‌توانید یک کلیپ صوتی را جاسازی کنید، تصویر نمایانگر آن را انتخاب کنید، پخش را تنظیم کنید و زیرنویس‌ها را ضمیمه کنید. همچنین می‌توانید صدایی که به یک انتقال اسلاید اختصاص داده شده است را دریافت کنید.

## **ایجاد قاب‌های صوتی**

از [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) برای جاسازی یک کلیپ صوتی محلی در اسلاید اول استفاده کنید. دو مختصات اول مکان قاب را بر روی اسلاید تعیین می‌کنند و دو مقدار بعدی عرض و ارتفاع آن را، همگی به واحد نقطه، تنظیم می‌کنند. این مثال متد [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) را برای شروع خودکار کلیپ فراخوانی می‌کند و متد [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) را برای انتخاب پیش‌تنظیم صدای بلند صدا می‌کند.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **تغییر تصویر بندانگشتی قاب صوتی**

به‌صورت پیش‌فرض، یک قاب صوتی آیکون بلندگو را نمایش می‌دهد. برای نمایش یک تصویر بندانگشتی سفارشی، یک تصویر را با [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) به ارائه اضافه کنید و آن را به عنوان تصویر قاب با [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) تنظیم کنید. مثال از یک فایل JPEG به‌عنوان تصویر بندانگشتی برای کلیپ صوتی جاسازی‌شده استفاده می‌کند.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **تغییر گزینه‌های پخش صوت**

کنترل‌های گزینه‌های صوتی PowerPoint تعیین می‌کنند که کلیپ چه زمانی شروع شود، صدای آن چقدر باشد و در طول نمایش اسلاید چگونه رفتار کند.

![کنترل‌های گزینه‌های صوتی PowerPoint برای یک قاب صوتی](audio_frame_0.png)

| کنترل PowerPoint | متد Aspose.Slides برای C++ |
| --- | --- |
| شروع | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| پیش‌تنظیم صدا | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| پخش در سراسر اسلایدها | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| حلقه تا متوقف شود | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| مخفی‌سازی در حین نمایش | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| پخش مجدد پس از پخش | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| محو شدن ورودی | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| محو شدن خروجی | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| زمان شروع برش صوت | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| زمان پایان برش صوت | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| کشنگر صدا | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

این مثال اولین قاب صوتی را در اسلاید اول پیدا می‌کند، متد [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) را برای شروع پخش با کلیک فراخوانی می‌کند و پیش‌تنظیم صدا کم را انتخاب می‌کند. کلیپ در اسلایدها ادامه می‌یابد در حالی که حلقه‌گذاری غیرفعال است. آیکون در طول نمایش مخفی می‌ماند و پس از پخش کلیپ دوباره به ابتدا باز می‌گردد.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

برای یک کلیپ طولانی‌تر از ۳٫۵ ثانیه، این مثال ۱٫۵ ثانیهٔ اول و ۲ ثانیهٔ آخر را حذف می‌کند. آرگومان متد [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) مدت زمانی را که باید از انتهای کلیپ حذف شود مشخص می‌کند. برای به‌دست آوردن زمان انتهایی نشان‌داده‌شده در PowerPoint، این مقدار جبرانی را از مدت کلیپ کامل کم کنید. کلیپ برش‌دهی‌شده در طول ۲۰۰ میلی‌ثانیه محو ورود می‌شود و در ۵۰۰ میلی‌ثانیه محو خروج. هر چهار متد مقدارها را بر حسب میلی‌ثانیه می‌پذیرند.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

برای تنظیم حجم پخش به درصد مشخص، از [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) استفاده کنید. این مثال اولین قاب صوتی را در اسلاید اول به ۸۵٪ تنظیم می‌کند.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **مدیریت زیرنویس‌های صوتی**

هر قاب صوتی مجموعهٔ زیرنویس‌های خود را از طریق [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/) در اختیار قرار می‌دهد. از آن برای ضمیمه کردن زیرنویس‌های WebVTT به کلیپ، صادرات Trackهای موجود یا حذف آنها استفاده کنید.

### **افزودن زیرنویس‌های صوتی**

مثال یک کلیپ صوتی را در اسلاید اول جاسازی می‌کند و از [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) برای ضمیمه کردن یک Track محلی WebVTT استفاده می‌کند. آرگومان اول برچسب Track را فراهم می‌کند و دوم فایل حاوی زیرنویس‌های زمان‌بندی‌شده را مشخص می‌کند.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **استخراج زیرنویس‌های صوتی**

این مثال هر Track زیرنویس پیوست‌شده به یک قاب صوتی در اسلاید اول را صادر می‌کند. بایت‌های بازگردانده‌شده توسط [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) را در یک فایل WebVTT می‌نویسد و مقدار بازگردانده‌شده توسط [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) را به‌عنوان نام فایل استفاده می‌کند تا هر Track خروجی جداگانه‌ای داشته باشد.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **حذف زیرنویس‌های صوتی**

از [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) برای حذف یک Track جداگانه استفاده کنید. مثال از [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) برای حذف تمام زیرنویس‌ها از اولین قاب صوتی در اسلاید اول استفاده می‌کند در حالی که کلیپ را حفظ می‌کند.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **یافتن یک خط در زیرنویس‌های صوتی**

برای یافتن یک خط در زیرنویس‌های صوتی اسلاید اول، برای هر Track متد [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) را فراخوانی کنید تا متن WebVTT آن در حافظه خوانده شود. در یک cue متنی ساده WebVTT، خط زمان شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی cue را پایان می‌دهد. این مثال برچسب Track و هر خط زیرنویس حاوی «café» را چاپ می‌کند.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **استخراج صوت**

یک انتقال اسلاید می‌تواند صدای خاص خود را داشته باشد. برای بازیابی آن، متد [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) را بر روی انتقال فراخوانی کنید. مثال بایت‌های صوتی را با [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) دریافت می‌کند و تعداد بایت‌ها را چاپ می‌کند. اگر اسلاید اول صدأ انتقال نداشته باشد، به‌جای آن پیام چاپ می‌کند.

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **پرسش‌های متداول**

**آیا می‌توانم همان کلیپ صوتی را در اسلایدهای متعدد بدون تکرار استفاده کنم؟**

بله. کلیپ را یک‌بار به [مجموعه صداهای](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) ارائه اضافه کنید و همان شیء صوتی را برای هر اسلاید به [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) منتقل کنید.

**آیا می‌توانم صدای یک قاب صوتی موجود را جایگزین کنم؟**

بله. برای صدای لینک‌شده، متد [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) را با مسیر فایل جایگزین فراخوانی کنید. برای صدای جاسازی‌شده، کلیپ دیگری از مجموعه صداهای ارائه را به متد [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/) پاس بدهید. هر دو روش قاب موجود را حفظ می‌کنند.

**آیا برش داده‌های صوتی ذخیره‌شده در ارائه را تغییر می‌دهد؟**

خیر. متدهای [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) و [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) مرزهای پخش را تعیین می‌کنند. شما همچنان می‌توانید کلیپ کامل را از [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/) دریافت کنید.