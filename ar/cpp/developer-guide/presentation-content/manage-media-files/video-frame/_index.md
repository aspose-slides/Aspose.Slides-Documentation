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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. دليل سريع عملي."
---
## **مقدمة**

يمكن للفيديو المدمج بشكل مناسب في عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك.

يتيح لك PowerPoint إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، يوفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideo/)، والواجهة [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/)، وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)class.
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideo/) ومرّر مسار ملف الفيديو لتضمينه مع العرض التقديمي.
1. أضف كائنًا من النوع [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
1. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود C++ كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

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

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى طريقة [AddVideoFrame()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

تدعم الإصدارات الأحدث من Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثلاً على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابط الويب الخاص به.

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)class
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideo/) ومرّر رابط الفيديو.
1. حدد صورة مصغرة لإطار الفيديو.
1. احفظ العرض التقديمي.

يعرض لك هذا الكود C++ كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```c++
// مسار دليل المستندات.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// ينشئ كائن Presentation يمثل ملف عرض تقديمي
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// إضافة إطار فيديو 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// يضبط وضع التشغيل ومستوى الصوت للفيديو
vf->set_PlayMode(VideoPlayModePreset::Auto);

//يحفظ العرض التقديمي إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تقليم إطار الفيديو**

يسمح لك Aspose.Slides بالتحكم في الجزء الذي يُشغل من الفيديو عن طريق ضبط قيمتي trim-from-start و trim-from-end عبر [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/set_trimfromstart/) و[IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/set_trimfromend/). تُحدد كلُّ قيمة بالمليثانية وتحديد مقدار الوقت المستبعد من بداية الفيديو ونهايته على التوالي. هذه الإعدادات تغير إعدادات تشغيل الفيديو في العرض التقديمي؛ ولا تقص أو تعدل بيانات الفيديو المدمج الثنائية.

**ضبط إعدادات التقليم**

لإنشاء إطار فيديو وضبط إعدادات التقليم الخاصة به:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) class.
1. أضف كائنًا من النوع [IVideo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideo/) إلى العرض التقديمي.
1. أضف كائنًا من النوع [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) إلى شريحة.
1. اضبط قيمتي trim-from-start و trim-from-end عبر [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/set_trimfromstart/) و[IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/set_trimfromend/).
1. احفظ العرض التقديمي المعدل.

يتخطى المثال البرمجي التالي أول 2.5 ثانية وآخر ثانية من فيديو مدمج أثناء التشغيل:

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

**قراءة إعدادات التقليم**

لتفحص إعدادات التقليم الحالية، قم بتحميل عرض تقديمي، وابحث عن كائن [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) بين الأشكال في الشريحة الأولى، واقرأ القيم عبر [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/get_trimfromstart/) و[IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/get_trimfromend/).

يظهر لك المثال البرمجي التالي كيفية العثور على أول إطار فيديو في الشريحة الأولى وإبلاغ إعدادات التقليم بالمليثانية:

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

## **إدارة تسميات الفيديو**

يسمح لك Aspose.Slides بإدارة التعليقات التوضيحية المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ التعليقات في صيغة WebVTT وتُتاح عبر طريقة [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**إضافة تعليقات توضيحية إلى إطار الفيديو**

لإضافة تعليقات توضيحية إلى إطار فيديو:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) class.
1. أضف فيديو إلى العرض التقديمي.
1. أضف كائنًا من النوع [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) إلى شريحة.
1. استخدم [ICaptionsCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/) التي تُرجعها [get_CaptionTracks](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/get_captiontracks/) لإضافة مسار تعليق توضيحي WebVTT.
1. احفظ العرض التقديمي المعدل.

يعرض لك الكود التالي كيفية إضافة تعليقات توضيحية إلى إطار فيديو:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// يضيف مسار تعليقات جديد من ملف WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

توفر واجهة [ICaptionsCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/) أيضًا نسخة محملة تسمح لك بإضافة تعليقات توضيحية من تدفق بيانات.

**استخراج التعليقات التوضيحية من إطار الفيديو**

لاستخراج التعليقات التوضيحية من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
1. اعثر على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) المستهدف.
1. تجوّل عبر مسارات التعليقات التي تُرجعها [get_CaptionTracks](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. احفظ كل مسار تعليقات في ملف `.vtt`.

يعرض لك الكود التالي كيفية استخراج التعليقات التوضيحية من إطار فيديو:

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
            // يحفظ مسار التسميات إلى ملف WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

كل كائن من [ICaptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptions/) يعرض معرف التعليق، التسمية، البيانات الثنائية، وبيانات التعليق كسلسلة UTF-8.

**إزالة التعليقات التوضيحية من إطار الفيديو**

لإزالة التعليقات التوضيحية من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
1. احصل على كائن [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) المستهدف.
1. أزل مسارات التعليقات من المجموعة التي تُرجعها [get_CaptionTracks](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. احفظ العرض التقديمي المعدل.

يعرض لك الكود التالي كيفية إزالة جميع التعليقات التوضيحية من إطار فيديو:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// يزيل جميع التسميات من إطار الفيديو.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

إذا كنت بحاجة إلى إزالة مسار تعليق واحد فقط، استخدم الطريقتين [Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/removeat/) بدلاً من [Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/clear/).

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة مقاطع فيديو إلى الشرائح، يسمح لك Aspose.Slides باستخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) class لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. تصفح جميع كائنات [ISlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/).
3. تصفح جميع كائنات [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/videoframe/). 
4. احفظ الفيديو إلى القرص.

يعرض لك هذا الكود C++ كيفية استخراج الفيديو من شريحة عرض تقديمي:

```c++
// مسار دليل المستندات.
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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/cpp/aspose.slides/videoframe/set_playmode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/cpp/aspose.slides/videoframe/set_playloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، يتم تضمين البيانات الثنائية في المستند، وبالتالي ينمو حجم العرض التقديمي بما يتناسب مع حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/cpp/aspose.slides/videoframe/set_embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ وهذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المدمج؟**

نعم. يحتوي الفيديو المدمج على [نوع محتوى](https://reference.aspose.com/slides/ar/cpp/aspose.slides/video/get_contenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.