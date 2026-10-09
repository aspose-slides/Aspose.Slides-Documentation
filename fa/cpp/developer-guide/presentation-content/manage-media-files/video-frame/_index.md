---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با استفاده از C++
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/cpp/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- تعبیه ویدیو
- استخراج ویدیو
- دریافت ویدیو
- فریم ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides برای C++ امکان افزودن فریم‌های ویدیو به اسلایدها، تنظیم تنظیمات پخش، مدیریت زیرنویس‌ها و استخراج داده‌های ویدیو تعبیه‌شده را فراهم می‌کند.

PowerPoint از ویدیوهای محلی و لینک‌های به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides رابط [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) ، رابط [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدیو تعبیه‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید فریم ویدیو را برای تعبیهٔ ویدیو در ارائهٔ خود ایجاد کنید.

این مثال یک ویدیو محلی را در اسلاید اول یک ارائهٔ موجود تعبیه می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) در حین استفاده ارائه آن را قفل می‌کند.

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

همچنین می‌توانید مسیر ویدیو محلی را مستقیماً به [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) پاس بدهید. این مثال ویدیو را در اسلاید اول یک ارائهٔ جدید تعبیه می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه در دسترس بماند.

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

## **ایجاد فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدیو ایجاد کنید که به ویدیوی آنلاین، مانند یک ویدیو YouTube، لینک داشته باشد.

این مثال لینک ویدیو YouTube و تصویر بندانگشتی آن را به اسلاید اول اضافه می‌کند. برای استفاده از ویدیوی دیگر، شناسهٔ ویدیو را جایگزین کنید. متد [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) پخش خودکار را درخواست می‌کند. دانلود تصویر بندانگشتی و پخش ویدیو به دسترسی به اینترنت نیاز دارد. نمایشگر ارائه نیز باید از پخش ویدیوهای آنلاین پشتیبانی کند.

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

## **پخش ویدیو در حالت تمام‌صفحه**

در یک ارائهٔ آموزشی، می‌توانید نمایش نرم‌افزار را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) با مقدار `true` این رفتار را در طول پخش فعال می‌کند.

این مثال یک ارائه باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌کند. ارائهٔ ورودی باید حداقل یک اسلاید با فریم ویدیو موجود در اسلاید اول داشته باشد.

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

پخش تمام‌صفحه نحوهٔ نمایش ویدیو را تعیین می‌کند. به طور مستقل، [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) کنترل می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود، و [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) کنترل می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset::Auto یا VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقهٔ موجود را حفظ می‌کند.

## **بازگردانی ویدیو پس از پخش**

در یک ارائهٔ آموزشی، بازگرداندن ویدیو به ابتدای آن باعث می‌شود برای ارائه‌دهنده آمادهٔ پخش مجدد باشد. با فراخوانی [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) با مقدار `true` می‌توانید پس از پایان پخش، ویدیو را به ابتدا بازگردانید.

این مثال یک ارائه باز می‌کند، اولین [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) را در اسلاید اول پیدا می‌کند و بازگردانی را فعال می‌کند. حلقهٔ تکرار را غیرفعال می‌کند تا پخش بتواند به‌پایان برسد و پخش را روی کلیک تنظیم می‌کند. ارائهٔ ورودی باید حداقل یک اسلاید با فریم ویدیو موجود در اسلاید اول داشته باشد.

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

بازگردانی ویدیو را بدون شروع مجدد به ابتدای آن برمی‌گرداند. در مقابل، فعال‌سازی [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) پخش را به‌صورت خودکار تکرار می‌کند. هنگامی که می‌خواهید ویدیو به پایان برسد و آمادهٔ پخش مجدد بماند، حلقه را غیرفعال نگه دارید. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) به‌صورت مستقل کنترل شروع خودکار یا با کلیک را انجام می‌دهد؛ این مثال از [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را تعیین کند. همان‌طور که در مثال نشان داده شده، حالت پخش را پس از تنظیم حلقه تنظیم کنید. بازگردانی مستقل از [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) عمل می‌کند.

## **قلم‌زنی (Trim) یک فریم ویدیو**

از [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) و [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) برای حذف بخشی از ابتدا یا انتهای ویدیو در زمان پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. قلم‌زنی تنظیمات پخش را بدون تغییر دادهٔ ویدیو تعبیه‌شده تغییر می‌دهد.

**تنظیمات قلم‌زنی**

این مثال یک ویدیو محلی را تعبیه می‌کند و در زمان پخش، دو ثانیه و نیم اول و یک ثانیه آخر را نادیده می‌گیرد. از ویدیویی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا بخشی قابل پخش باقی بماند.

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

**خواندن تنظیمات قلم‌زنی**

این مثال مقادیر قلم‌زنی فریم ویدیو اول در اسلاید اول را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیو نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ تولید می‌کند.

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

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) در دسترس هستند.

**افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را تعبیه می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌بندی زیرنویس‌ها باید با ویدیو مطابقت داشته باشد. ارائهٔ ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

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

رابط [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) همچنین یک بارگذاری اضافی فراهم می‌کند که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام مسیرهای زیرنویس را از فریم‌های ویدیو در اسلاید اول به صورت فایل‌های WebVTT جداگانه ذخیره می‌کند. شماره‌های ترتیبی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به صورت رشته UTF‑8 ارائه می‌دهد.

**حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدیو باشد.

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

اگر نیاز به حذف تنها یک مسیر زیرنویس داشته باشید، به‌جای [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) می‌توانید از متدهای [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدیوهای تعبیه‌شده در ارائه‌ها را استخراج کنید.

این مثال ویدیوهای تعبیه‌شده را از هر اسلاید به فایل‌های باینری شماره‌دار جداگانه استخراج می‌کند. ویدیوهای لینک‌شده حذف می‌شوند چون دادهٔ تعبیه‌شده‌ای ندارند. کنسول MIME type هر ویدیو و تعداد کل را چاپ می‌کند. خروجی با پسوند عمومی `.bin` ذخیره می‌شود؛ در صورت نیاز می‌توانید پسوند را برای مطابقت با نوع رسانه گزارش‌شده تغییر دهید.

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

**کدام پارامترهای پخش ویدیو می‌توانند برای فریم ویدیو تغییر کنند؟**

می‌توانید [حالت پخش](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (خودکار یا با کلیک) و [حلقهٔ تکرار](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو بر اندازهٔ فایل PPTX تأثیر می‌گذارد؟**

بله. هنگامی که یک ویدیو محلی را تعبیه می‌کنید، دادهٔ باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه به نسبت اندازهٔ فایل ویدیو افزایش می‌یابد. وقتی به یک ویدیو آنلاین لینک می‌دهید و تصویر پیش‌نمایش اضافه می‌کنید، ارائه فقط لینک و تصویر پیش‌نمایش را ذخیره می‌کند، نه دادهٔ ویدیو، بنابراین افزایش اندازه معمولاً کمتر است.

**آیا می‌توان ویدیو را در یک فریم ویدیو موجود بدون تغییر موقعیت و اندازهٔ آن جایگزین کرد؟**

بله. می‌توانید محتوای [ویدیو](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) را داخل فریم تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این سناریوی رایج برای به‌روزرسانی رسانه در یک طرح‌بندی موجود است.

**آیا می‌توان نوع محتوا (MIME) ویدیو تعبیه‌شده را تعیین کرد؟**

بله. یک ویدیو تعبیه‌شده دارای [نوع محتوا](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیرهٔ آن بر روی دیسک.