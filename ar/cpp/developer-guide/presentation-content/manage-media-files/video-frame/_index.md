---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام C++
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/cpp/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- تضمين فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وجذب انتباه الجمهور. يتيح Aspose.Slides للـ C++ إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمّنة.

يدعم PowerPoint الفيديوهات المحلية والروابط إلى الفيديوهات عبر الإنترنت، مثل فيديوهات يوتيوب.

لتمثيل بيانات الفيديو وإطارات الفيديو، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) وغيرها من الأنواع ذات الصلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي.

هذا المثال يقوم بتضمين فيديو محلي على الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدات النقاط. يبقى تدفق البيانات مفتوحًا حتى يكتمل الحفظ لأن [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) يبقيه مقفلًا أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار فيديو محلي مباشرة إلى [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). يضمّن هذا المثال الفيديو على الشريحة الأولى من عرض تقديمي جديد. يجب أن يبقى الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

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

## **إنشاء إطار فيديو بفيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) الفيديوهات عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يرتبط بفيديو عبر الإنترنت، مثل فيديو يوتيوب.

يضيف هذا المثال رابط فيديو يوتيوب وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. طريقة [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) تطلب تشغيلًا تلقائيًا. تحتاج عملية تنزيل الصورة المصغرة وتشغيل الفيديو إلى اتصال إنترنت. يجب أن يدعم مشاهد العرض التقديمي تشغيل الفيديو عبر الإنترنت أيضًا.

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

## **تشغيل الفيديو في وضع ملء الشاشة**

في عرض تقديمي تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. تقبل [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) القيمة `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) على الشريحة الأولى، ويُفعّل التشغيل بملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود على الشريحة الأولى.

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

يتحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، تتحكم [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) في ما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تقديمي تدريبي، إرجاع فيديو العرض إلى بدايته يجعله جاهزًا للمُقدِّم لتشغيله مرة أخرى. استدعِ [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) مع القيمة `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) على الشريحة الأولى، ويُفعل الإرجاع. يقوم بإلغاء التكرار حتى يمكن انتهاء التشغيل ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود على الشريحة الأولى.

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

إرجاع الفيديو يعيد الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، تمكين [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) يكرر التشغيل تلقائيًا. احفظ حالة التكرار معطلة عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة تشغيله. تتحكم [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) بشكل مستقل في بدء التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) لكي يتحكم المقدم في توقيت بدء التشغيل. اضبط وضع التشغيل بعد ضبط التكرار، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **قطع جزء من إطار الفيديو**

استخدم [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) و[IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. كلا القيمتين بالمليثانية. يُغيّر القطع إعدادات التشغيل دون تعديل بيانات الفيديو المضمَّنة.

**ضبط إعدادات القطع**

يضمّن هذا المثال فيديوًا محليًا ويتخطى أول 2.5 ثانية وآخر ثانية أثناء التشغيل. استخدم فيديوً أطول من 3.5 ثانية لضمان بقاء مقطع قابل للتشغيل.

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

**قراءة إعدادات القطع**

يطبع هذا المثال قيم القطع للإطار الفيديو الأول على الشريحة الأولى بالمليثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لن يُطبع أي شيء. المثال السابق ينتج قيم 2500 و1000.

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

## **إدارة تسميات الفيديو**

يتيح Aspose.Slides لك إدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint التقديمية. تُحفظ التسميات بصيغة WebVTT وتُتاح عبر طريقة [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) .

**إضافة تسميات إلى إطار الفيديو**

يضمّن هذا المثال فيديوًا محليًا ويضيف مسار تسميات WebVTT معنّى بـ English. يجب أن تتطابق طوابع الوقت للتسمية مع الفيديو. يتضمن العرض التقديمي المحفوظ كلاً من الفيديو وتسمياته.

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

توفر الواجهة [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) أيضًا تحميلًا يتيح لك إضافة تسميات من تدفق بيانات.

**استخراج التسميات من إطار الفيديو**

يقوم هذا المثال بحفظ جميع مسارات التسميات من إطارات الفيديو على الشريحة الأولى كملفات WebVTT منفصلة. تضمن الأرقام المتسلسلة تمييز ملفات الإخراج. يعرض الطرفية عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) يُظهر معرف التسمية، والعنوان، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار الفيديو**

يزيل هذا المثال جميع التسميات من إطار الفيديو الموجود في أول موضع شكل على الشريحة الأولى ويحفظ النتيجة. يفترض أن الشريحة والشكل موجودان وأن الشكل هو إطار فيديو.

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

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طرق [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) بدلاً من [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) .

## **استخراج الفيديو من الشريحة**

بالإضافة إلى إضافة الفيديوهات إلى الشرائح، يتيح Aspose.Slides استخراج الفيديوهات المضمَّنة في العروض التقديمية.

يستخرج هذا المثال الفيديوهات المضمَّنة من كل شريحة إلى ملفات ثنائية منفصلة مرقَّمة. تُتخطى الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمَّنة. تطبع الطرفية نوع MIME لكل فيديو والعدد الإجمالي. يستخدم الناتج امتداد `.bin` العام؛ عدل الامتداد ليتطابق مع نوع الوسائط المبلغ عنه عند الحاجة.

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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (auto or on click) و[التكرار](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). هذه الخيارات متاحة عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، تُضاف البيانات الثنائية إلى المستند، لذا يزداد حجم العرض التقديمي بنسبة حجم الملف. عندما ترتبط بفيديو عبر الإنترنت وتضيف صورة مصغرة، يقوم العرض التقديمي بتخزين الرابط وصورة المعاينة بدلًا من بيانات الفيديو، وبالتالي يكون الزيادة في الحجم عادةً أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. للفيديو المضمّن [نوع المحتوى](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.