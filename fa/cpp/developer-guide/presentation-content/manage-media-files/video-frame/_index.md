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
- بازیابی ویدئو
- فریم ویدئو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ اضافه و استخراج کنید. راهنمای سریع نحوه انجام کار."
---
## **معرفی**

یک ویدئوی مناسب در یک ارائه می‌تواند پیام شما را جذاب‌تر کند و سطح درگیری مخاطبان را افزایش دهد.

PowerPoint به شما اجازه می‌دهد تا ویدئوها را به یک اسلاید در یک ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدئوی محلی (ذخیره شده بر روی دستگاه شما)
* افزودن یک ویدئوی آنلاین (از یک منبع وب مانند YouTube).

برای اینکه بتوانید ویدئوها (اشیای ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideo/)، [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی ایجاد کنید تا ویدئو را در ارائه خود جاسازی کنید.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک شیء [IVideo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه پاس بدهید.
4. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) اضافه کنید تا فریمی برای ویدئو ایجاد شود.
5. ارائه اصلاح‌شده را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده به صورت محلی را به یک ارائه اضافه کنید:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

به‌طور جایگزین، می‌توانید ویدئو را با پاس کردن مستقیم مسیر فایل آن به متد [AddVideoFrame()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addvideoframe/) اضافه کنید:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **ایجاد فریم ویدئو با ویدئو از منبع وب**

نسخه‌های جدیدتر Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدئوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که می‌خواهید استفاده کنید به صورت آنلاین در دسترس باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک شیء [IVideo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideo/) اضافه کنید و لینک ویدئو را پاس بدهید.
4. یک تصویر بندانگشتی برای فریم ویدئو تنظیم کنید.
5. ارائه را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک ویدئوی وب را به یک اسلاید در یک ارائه PowerPoint اضافه کنید:

```c++
 // مسیر پوشهٔ اسناد.
 const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
 const String filePath = u"../templates/video1.avi";

 // یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
 SharedPtr<Presentation> pres = MakeObject<Presentation>();

 // به اسلاید اول دسترسی می‌یابد
 SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

 // یک فریم ویدئویی اضافه می‌کند 
 System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

 // حالت پخش و حجم صدا را برای ویدئو تنظیم می‌کند
 vf->set_PlayMode(VideoPlayModePreset::Auto);

 //ارائه را روی دیسک ذخیره می‌کند
 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **برش فریم ویدئویی**

Aspose.Slides به شما امکان می‌دهد تا بخشی از ویدئو که پخش می‌شود را با تنظیم مقادیر trim-from-start و trim-from-end از طریق [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/set_trimfromstart/) و [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/set_trimfromend/) کنترل کنید. هر دو مقدار بر حسب میلی‌ثانیه مشخص می‌شوند و تعیین می‌کنند چه مقدار زمان از ابتدای و انتهای ویدئو به‌طور متوالی حذف شود. این تنظیمات تنظیمات پخش ویدئو در ارائه را تغییر می‌دهند؛ آن‌ها ویدئوی جاسازی‌شده را قطع یا به‌صورت دیگری تغییر نمی‌دهند.

**تنظیمات برش**

برای ایجاد یک فریم ویدئویی و تنظیمات برش آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. یک شیء [IVideo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideo/) را به ارائه اضافه کنید.
3. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) را به یک اسلاید اضافه کنید.
4. مقادیر trim-from-start و trim-from-end را از طریق [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/set_trimfromstart/) و [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/set_trimfromend/) تنظیم کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال کد زیر 2.5 ثانیه اول و یک ثانیه آخر یک ویدئوی جاسازی‌شده را در طول پخش نادیده می‌گیرد:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**خواندن تنظیمات برش**

برای بررسی تنظیمات برش موجود، یک ارائه را بارگذاری کنید، شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) را میان اشکال اسلاید اول پیدا کنید، و مقادیر را از طریق [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_trimfromstart/) و [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_trimfromend/) بخوانید.

مثال کد زیر اولین فریم ویدئویی را در اسلاید اول پیدا کرده و تنظیمات برش آن را بر حسب میلی‌ثانیه گزارش می‌دهد:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان می‌دهد تا زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) در دسترس هستند.

**افزودن زیرنویس به فریم ویدئویی**

برای افزودن زیرنویس به فریم ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. یک ویدئو به ارائه اضافه کنید.
3. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) را به یک اسلاید اضافه کنید.
4. از [ICaptionsCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/) که توسط [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) بازگردانده می‌شود استفاده کنید تا یک ترک زیرنویس WebVTT اضافه کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به فریم ویدئویی اضافه کنید:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// یک ترک زیرنویس جدید از فایل WebVTT اضافه می‌کند.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/) همچنین یک overload فراهم می‌کند که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدئویی**

برای استخراج زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
2. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) هدف را پیدا کنید.
3. در میان ترک‌های زیرنویس بازگردانده شده توسط [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) تکرار کنید.
4. هر ترک زیرنویس را به یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از فریم ویدئویی استخراج کنید:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // ترک زیرنویس را در یک فایل WebVTT ذخیره می‌کند.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری و داده‌های زیرنویس را به‌صورت یک رشته UTF-8 نمایش می‌دهد.

**حذف زیرنویس‌ها از فریم ویدئویی**

برای حذف زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
2. شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) هدف را به‌دست آورید.
3. ترک‌های زیرنویس را از مجموعه‌ای که توسط [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) بازگردانده می‌شود حذف کنید.
4. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از فریم ویدئویی حذف کنید:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// تمام زیرنویس‌ها را از فریم ویدئو حذف می‌کند.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

اگر فقط نیاز به حذف یک ترک زیرنویس دارید، به‌جای [Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/clear/) از متدهای [Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/removeat/) استفاده کنید.

## **استخراج ویدئو از اسلاید**

علاوه بر افزودن ویدئو به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید تا ارائه حاوی ویدئو را بارگذاری کنید.
2. در میان تمام اشیاء [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) تکرار کنید.
3. در میان تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) تکرار کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/) پیدا کنید.
4. ویدئو را روی دیسک ذخیره کنید.

این کد C++ نشان می‌دهد چگونه ویدئوی یک اسلاید ارائه را استخراج کنید:

```c++
// مسیر پوشهٔ اسناد.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **پرسش‌های متداول**

**کدام پارامترهای پخش ویدئو می‌توان برای VideoFrame تغییر داد؟**

شما می‌توانید حالت پخش ([playback mode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/set_playmode/)) (خودکار یا با کلیک) و تکرار ([looping](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/set_playloopmode/)) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدئو بر اندازه فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شوند و بنابراین اندازه ارائه به نسبت حجم فایل افزایش می‌یابد. وقتی یک ویدئوی آنلاین را اضافه می‌کنید، یک لینک و تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایشت اندازه کمتر است.

**آیا می‌توانم ویدئوی موجود در یک VideoFrame را بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/set_embeddedvideo/) را داخل فریم تعویض کنید در حالی که شمایل (shape) را حفظ می‌کنید؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/video/get_contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی آن بر روی دیسک.