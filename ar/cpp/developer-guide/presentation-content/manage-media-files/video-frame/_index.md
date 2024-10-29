---
title: إطار الفيديو
type: docs
weight: 10
url: /ar/cpp/video-frame/
keywords: "إضافة فيديو، إنشاء إطار فيديو، استخراج فيديو، عرض تقديمي على PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "إضافة إطار فيديو إلى عرض تقديمي على PowerPoint بلغة C++"

---

يمكن أن يساهم الفيديو الموضوعة بشكل جيد في عرض تقديمي في جعل رسالتك أكثر جاذبية وزيادة مستوى تفاعل الجمهور معك.

يسمح لك PowerPoint بإضافة مقاطع الفيديو إلى الشريحة في عرض تقديمي بطريقتين:

* إضافة فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل يوتيوب).

لتتيح لك إضافة مقاطع الفيديو (كائنات الفيديو) إلى العرض التقديمي، توفر Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) وأنواع ذات صلة أخرى.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لدمج الفيديو في عرضك التقديمي.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال مؤشرها.
1. أضف كائن [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) ومرر مسار ملف الفيديو لدمج الفيديو مع العرض التقديمي.
1. أضف كائن [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. احفظ العرض التقديمي المعدل.

تظهر لك الكود التالي في C++ كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// تحميل الفيديو
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// الحصول على الشريحة الأولى وإضافة إطار فيديو
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// حفظ العرض التقديمي على القرص
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

بدلاً من ذلك، يمكنك إضافة فيديو عن طريق تمرير مسار ملفه مباشرة إلى طريقة [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع الفيديو من يوتيوب في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثل يوتيوب)، يمكنك إضافته إلى عرضك التقديمي من خلال رابط الويب الخاص به.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
1. احصل على مرجع الشريحة من خلال مؤشرها.
1. أضف كائن [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) ومرر الرابط إلى الفيديو.
1. قم بتعيين صورة مصغرة لإطار الفيديو.
1. احفظ العرض التقديمي.

تظهر لك الكود التالي في C++ كيفية إضافة فيديو من الويب إلى شريحة في عرض تقديمي على PowerPoint:

```c++
// المسار إلى دليل الوثائق.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// إنشاء كائن Presentation الذي يمثل ملف العرض التقديمي
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// إضافة إطار فيديو 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// تعيين وضع التشغيل والصوت للفيديو
vf->set_PlayMode(VideoPlayModePreset::Auto);

// حفظ العرض التقديمي على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استخراج الفيديو من الشريحة**

بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، يسمح Aspose.Slides لك باستخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. قم بالتكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/).
3. قم بالتكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).
4. احفظ الفيديو على القرص.

تظهر لك الكود التالي في C++ كيفية استخراج الفيديو من شريحة عرض تقديمي:

```c++
// المسار إلى دليل الوثائق.
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