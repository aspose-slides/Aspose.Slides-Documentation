---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از C++
linktitle: فریم ویدئویی
type: docs
weight: 10
url: /fa/cpp/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- دریافت ویدئو
- فریم ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **معرفی**

ویدئوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides برای C++ به شما امکان می‌دهد فریم‌های ویدئویی را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدئوی جاسازی‌شده را استخراج کنید.

PowerPoint از ویدئوهای محلی و پیوندهای به ویدئوهای آنلاین، مانند ویدئوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدئویی و فریم‌های ویدئویی، Aspose.Slides رابط [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)، رابط [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد فریم ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید فریم ویدئویی ایجاد کنید تا ویدئو را در ارائه‌تان جاسازی کنید.

این مثال یک ویدئوی محلی را بر روی اولین اسلاید یک ارائه موجود جاسازی کرده و نتیجه را ذخیره می‌کند. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) آن را قفل نگه می‌دارد تا زمانی که ارائه از آن استفاده می‌کند.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

شما همچنین می‌توانید مسیر ویدئوی محلی را به‌طور مستقیم به [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) پاس دهید. این مثال ویدئو را بر روی اولین اسلاید یک ارائه جدید جاسازی می‌کند. ویدئو باید تا زمان ذخیره‌سازی ارائه در دسترس بماند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ایجاد فریم ویدئویی با ویدئویی از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدئوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. شما می‌توانید فریم ویدئویی ایجاد کنید که به یک ویدئوی آنلاین، مانند یک ویدئوی YouTube، لینک می‌دهد.

این مثال یک لینک ویدئوی YouTube و تصویر پیش‌نمایش را به اولین اسلاید اضافه می‌کند. شناسه ویدئو را تغییر دهید تا از ویدئوی دیگری استفاده کنید. متد [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) درخواست پخش خودکار را می‌کند. دانلود تصویر پیش‌نمایش و پخش ویدئو نیاز به دسترسی به اینترنت دارد. نمایشگر ارائه نیز باید از پخش ویدئوهای آنلاین پشتیبانی کند.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پخش ویدئو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک دموی نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطبان جزئیات را ببینند. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) مقدار `true` را می‌پذیرد تا این رفتار را در هنگام پخش فعال کند.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول فریم ویدئویی موجود باشد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

پخش تمام‌صفحه تعیین می‌کند ویدئو چگونه نمایش داده شود. به‌طور مستقل، [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) کنترل می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود، و [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) کنترل می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدئو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدئوی دموی به ابتدای خود آن را برای پخش مجدد توسط ارائه‌دهنده آماده می‌کند. با فراخوانی [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) مقدار `true` را تنظیم کنید تا پس از پایان پخش، ویدئو به ابتدا بازگردد.

این مثال یک ارائه را باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) را در اولین اسلاید پیدا می‌کند و بازگرداندن را فعال می‌سازد. حلقه‌زدن را غیرفعال می‌کند تا پخش بتواند به پایان برسد و پخش را برای شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول فریم ویدئویی موجود باشد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

بازگرداندن ویدئو را به ابتدا برمی‌گرداند بدون اینکه دوباره شروع شود. در مقابل، فعال‌سازی [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدئو به پایان برسد و آمادهٔ بازپخش بماند، حلقه‌زدن را غیرفعال نگه دارید. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) به‌صورت مستقل کنترل می‌کند که شروع به‌صورت خودکار یا با کلیک باشد؛ این مثال از [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمانی که پخش آغاز می‌شود را کنترل کند. همان‌طور که در مثال نشان داده شده، حالت پخش را پس از تنظیم حلقه تنظیم کنید. بازگرداندن به‌صورت مستقل از [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) کار می‌کند.

## **برش فریم ویدئویی**

از [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) و [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) استفاده کنید تا بخشی از ابتدای یا انتهای ویدئو را در طول پخش رد کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را تغییر می‌دهد بدون اینکه دادهٔ ویدئوی جاسازی‌شده را تغییر دهد.

**تنظیمات برش**

این مثال یک ویدئوی محلی را جاسازی می‌کند و در طول پخش ۲٫۵ ثانیه اول و ۱ ثانیه آخر را رد می‌کند. از ویدئویی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا یک بخش قابل پخش باقی بماند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**خواندن تنظیمات برش**

این مثال مقادیر برش اولین فریم ویدئویی در اسلاید اول را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدئویی نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) در دسترس هستند.

### **افزودن زیرنویس به فریم ویدئویی**

این مثال یک ویدئوی محلی را جاسازی می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌سنجی زیرنویس باید با ویدئو مطابقت داشته باشد. ارائه ذخیره‌شده شامل هر دو ویدئو و زیرنویس‌های آن است.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) همچنین یک overload فراهم می‌کند که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان اضافه کنید.

### **استخراج زیرنویس‌ها از فریم ویدئویی**

این مثال تمام مسیرهای زیرنویس از فریم‌های ویدئویی در اسلاید اول را به‌صورت فایل‌های جداگانهٔ WebVTT ذخیره می‌کند. اعداد متوالی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

هر شیء [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده باینری و متن زیرنویس را به‌صورت رشتهٔ UTF-8 ارائه می‌دهد.

### **حذف زیرنویس‌ها از فریم ویدئویی**

این مثال همه زیرنویس‌ها را از فریم ویدئویی در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می نماید. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک فریم ویدئویی است.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

اگر فقط یک مسیر زیرنویس را می‌خواهید حذف کنید، به‌جای [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/)، از متدهای [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) استفاده کنید.

### **جستجوی زیرنویس‌های ویدئویی**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) مسیر کامل WebVTT را باز می‌گرداند، شامل سرصفحه، خطوط زمان‌بندی و متن زیرنویس. برای یافتن عبارت گفتاری و زمان‌سنجی آن، نشانه‌ها را در حافظه بخوانید. برای مثال، یک مسیر انگلیسی در اسلاید ۲ ممکن است متن زیر را داشته باشد:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

مثال فایل `captioned_media.pptx` را باز می‌کند و مسیرهای زیرنویس هر فریم ویدئویی سطح بالا در هر اسلاید را با استفاده از [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) می‌خواند. در یک cue متن ساده، خط زمان‌بندی شامل `-->` است و یک خط خالی cue را خاتمه می‌دهد. وقتی زیرنویس شامل “café” باشد، مثال شماره اسلاید، برچسب مسیر، خط زمان‌بندی اصلی و کل زیرنویس را چاپ می‌کند. جستجو به حروف بزرگ/کوچک حساس نیست.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"captioned_media.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        auto videoFrame = AsCast<IVideoFrame>(shape);
        if (!videoFrame)
            continue;

        for (auto&& track : IterateOver(videoFrame->get_CaptionTracks()))
        {
            auto reader = MakeObject<StringReader>(track->get_DataAsString());
            for (auto timing = reader->ReadLine(); !timing.IsNull(); timing = reader->ReadLine())
            {
                if (!timing.Contains(u"-->"))
                    continue;

                String caption;
                for (auto line = reader->ReadLine(); !String::IsNullOrEmpty(line); line = reader->ReadLine())
                {
                    if (!String::IsNullOrEmpty(caption))
                        caption += u"\n";
                    caption += line;
                }

                if (caption.IndexOf(u"caf\u00E9", StringComparison::OrdinalIgnoreCase) >= 0)
                {
                    Console::WriteLine(String::Format(u"Slide {0} | {1} | {2}", slide->get_SlideNumber(), track->get_Label(), timing));
                    Console::WriteLine(caption);
                }
            }
        }
    }
}
presentation->Dispose();
```

جستجوی “café” یک مطابقت برای مسیر نمونه تولید می‌کند. جستجو سرصفحه را رد می‌کند و تنظیم زمان‌بندی را در خروجی حفظ می نماید.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدئو از اسلاید**

به‌جز افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

این مثال ویدئوهای جاسازی‌شده را از هر اسلاید به فایل‌های باینری جداگانه و شماره‌دار استخراج می‌کند. ویدئوهای لینک‌شده رد می‌شوند چون دادهٔ جاسازی‌شده‌ای ندارند. کنسول نوع MIME هر ویدئو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را مطابق با نوع رسانه گزارش‌شده تغییر دهید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **سوالات متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای فریم ویدئویی تغییر کنند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (خودکار یا با کلیک) و [حلقه‌زدن](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدئو بر حجم فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، دادهٔ باینری در سند گنجانده می‌شود، بنابراین حجم ارائه به نسبت حجم فایل بزرگ می‌شود. وقتی به یک ویدئوی آنلاین لینک می‌دهید و تصویر پیش‌نمایش اضافه می‌کنید، ارائه فقط پیوند و تصویر پیش‌نمایش را ذخیره می‌کند نه دادهٔ ویدئو، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توانم ویدئو را در فریم ویدئوی موجود بدون تغییر موقعیت و اندازه آن جایگزین کنم؟**

بله. می‌توانید [محتوای ویدئو](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) را درون فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک چیدمان موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [نوع محتوا](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.