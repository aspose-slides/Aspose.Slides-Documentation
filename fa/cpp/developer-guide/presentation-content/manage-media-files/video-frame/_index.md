---
title: مدیریت چارچوب‌های ویدئویی در ارائه‌ها با استفاده از C++
linktitle: چارچوب ویدئویی
type: docs
weight: 10
url: /fa/cpp/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- بازیابی ویدئو
- چارچوب ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی‌شده، چارچوب‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

یک ویدئوی مناسب در یک ارائه می‌تواند پیام شما را جذاب‌تر کرده و سطح مشارکت مخاطبان را افزایش دهد.

PowerPoint به شما اجازه می‌دهد تا ویدئوها را به اسلایدی در یک ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدئوی محلی (ذخیره‌شده روی دستگاه شما)
* افزودن یک ویدئوی آنلاین (از منبع وب مانند YouTube).

برای این که بتوانید ویدئوها (اشیاء ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides رابط‌های [IVideo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideo/) و [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد چارچوب ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید یک چارچوب ویدئویی ایجاد کنید تا ویدئو را در ارائه‌تان جاسازی کنید.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق شاخص آن به دست آورید.
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideo/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی به ارائه پاس کنید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) اضافه کنید تا یک چارچوب برای ویدئو ایجاد شود.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد C++ به شما نشان می‌دهد که چگونه یک ویدئوی محلی را به یک ارائه اضافه کنید:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// ویدئو را بارگذاری می‌کند
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// اسلاید اول را دریافت می‌کند و یک چارچوب ویدئویی اضافه می‌کند
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// ارائه را روی دیسک ذخیره می‌کند
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

به‌جای آن می‌توانید با پاس دادن مستقیم مسیر فایل به متد [AddVideoFrame()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addvideoframe/) یک ویدئو اضافه کنید:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **ایجاد چارچوب ویدئوی با ویدئوی منبع وب**

Microsoft [PowerPoint 2013 و نسخه‌های جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که می‌خواهید استفاده کنید به صورت آنلاین موجود باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه‌تان اضافه کنید.

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق شاخص آن به دست آورید.
1. یک شیء [IVideo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideo/) اضافه کنید و لینک ویدئو را پاس کنید.
1. یک تصویر بندانگشتی برای چارچوب ویدئو تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد C++ به شما نشان می‌دهد که چگونه یک ویدئوی وب را به یک اسلاید در ارائهٔ PowerPoint اضافه کنید:

```c++
// مسیر پوشهٔ اسناد.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// یک چارچوب ویدئویی اضافه می‌کند 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// حالت پخش و حجم صدا را برای ویدئو تنظیم می‌کند
vf->set_PlayMode(VideoPlayModePreset::Auto);

//ارائه را روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **مدیریت زیرنویس‌های ویدئو**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته برای چارچوب‌های ویدئویی در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) در دسترس هستند.

**افزودن زیرنویس به یک چارچوب ویدئویی**

برای افزودن زیرنویس به یک چارچوب ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. یک ویدئو به ارائه اضافه کنید.
1. یک شیء [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) به یک اسلاید اضافه کنید.
1. از [ICaptionsCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/) که توسط [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) بازگردانده می‌شود، برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد که چگونه زیرنویس‌ها را به یک چارچوب ویدئویی اضافه کنید:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

رابط [ICaptionsCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/) همچنین یک overload فراهم می‌کند که اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از یک چارچوب ویدئویی**

برای استخراج زیرنویس‌ها از یک چارچوب ویدئویی:

1. ارائه‌ای که حاوی ویدئو است را بارگذاری کنید.
1. شیء هدف [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) را پیدا کنید.
1. بر روی مسیرهای زیرنویس بازگردانده‌شده توسط [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) پیمایش کنید.
1. هر مسیر زیرنویس را به یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد که چگونه زیرنویس‌ها را از یک چارچوب ویدئویی استخراج کنید:

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
            // مسیر زیرنویس‌ها را به یک فایل WebVTT ذخیره می‌کند.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

هر شیء [ICaptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptions/) شناسه زیرنویس، برچسب، داده‌های باینری و دادهٔ زیرنویس را به صورت یک رشته UTF-8 نشان می‌دهد.

**حذف زیرنویس‌ها از یک چارچوب ویدئویی**

برای حذف زیرنویس‌ها از یک چارچوب ویدئویی:

1. ارائه‌ای که حاوی ویدئو است را بارگذاری کنید.
1. شیء هدف [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) را به دست آورید.
1. مسیرهای زیرنویس را از مجموعه‌ای که توسط [get_CaptionTracks](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/get_captiontracks/) بازگردانده می‌شود، حذف کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد که چگونه همهٔ زیرنویس‌ها را از یک چارچوب ویدئویی حذف کنید:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// تمام زیرنویس‌ها را از چارچوب ویدئو حذف می‌کند.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

اگر فقط می‌خواهید یک مسیر زیرنویس را حذف کنید، به جای [Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/clear/) از متدهای [Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/remove/) یا [RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icaptionscollection/removeat/) استفاده کنید.

## **استخراج ویدئو از یک اسلاید**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) برای بارگذاری ارائهٔ حاوی ویدئو ایجاد کنید. 
2. بر تمام اشیاء [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) پیمایش کنید.
3. بر تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/) پیدا کنید. 
4. ویدئو را بر روی دیسک ذخیره کنید.

این کد C++ به شما نشان می‌دهد که چگونه ویدئو را از یک اسلاید ارائه استخراج کنید:

```c++
// مسیر پوشه اسناد.
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

## **سوالات متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای یک VideoFrame تغییر کنند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/set_playmode/) (خودکار یا با کلیک) و [حلقه‌گذاری](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/set_playloopmode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدئو بر اندازهٔ فایل PPTX تاثیر دارد؟**

بله. وقتی یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه متناسب با حجم فایل افزایش می‌یابد. وقتی یک ویدئوی آنلاین اضافه می‌کنید، یک لینک و یک تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایش اندازه کمتر است.

**آیا می‌توانم ویدئوی موجود در یک VideoFrame را بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [ویدئوی](https://reference.aspose.com/slides/fa/cpp/aspose.slides/videoframe/set_embeddedvideo/) داخل چارچوب را تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای [نوع محتوا](https://reference.aspose.com/slides/fa/cpp/aspose.slides/video/get_contenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، مثلا هنگام ذخیره‌سازی بر روی دیسک.