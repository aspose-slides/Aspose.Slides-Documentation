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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. دليل سريع خطوة بخطوة."
---

يمكن للفيديو الموضوع في المكان المناسب داخل عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك. 

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) ، وواجهة [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) ، وغيرها من الأنواع ذات الصلة. 

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء كائن من الفئة [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)class.
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي. 
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.  
1. حفظ العرض التقديمي المعدل. 

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


بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرةً إلى طريقة [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) :
``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```



## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) يدعم مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابطه على الويب. 

1. إنشاء كائن من الفئة [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)class
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. حفظ العرض التقديمي. 

يعرض لك هذا الكود C++ كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint التقديمي:
```c++
// مسار دليل المستندات.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// ينشئ كائن Presentation يمثل ملف عرض تقديمي
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// يضيف إطار فيديو 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// يحدد وضع تشغيل وحجم صوت الفيديو
vf->set_PlayMode(VideoPlayModePreset::Auto);

//يحفظ العرض التقديمي إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة مقاطع فيديو إلى الشرائح، يتيح لك Aspose.Slides استخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. التكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/).
3. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/). 
4. حفظ الفيديو على القرص.

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


## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، يتم تضمين البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بنسبة حجم الملف. عندما تضيف فيديوًا عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**

نعم. يحتوي الفيديو المدمج على [نوع المحتوى](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) الذي يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.