---
title: إطار الصوت
type: docs
weight: 10
url: /ar/cpp/audio-frame/
keywords: "إضافة صوت, إطار الصوت, خصائص الصوت, استخراج الصوت, C++, CPP, Aspose.Slides لـ C++"
description: "إضافة صوت إلى عرض PowerPoint في C++"
---

## **إنشاء إطار الصوت**
تتيح لك Aspose.Slides لـ C++ إضافة ملفات الصوت إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية. 

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. حمّل دفق ملف الصوت الذي ترغب في تضمينه في الشريحة.
4. أضف إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. اضبط [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. احفظ العرض التقديمي المعدل.

يظهر لك هذا الرمز في C++ كيفية إضافة إطار صوتي مضمن إلى شريحة:

``` cpp
// ينشئ مثيلاً لفئة Presentation تمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحمل ملف الصوت wav إلى دفق
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// يضيف إطار الصوت
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// يضبط وضع التشغيل وحجم الصوت
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// يكتب ملف PowerPoint إلى القرص
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **تغيير صورة مصغرة لإطار الصوت**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير الصورة المصغرة لإطار الصوت (تعيين الصورة المفضلة لديك).

يظهر لك هذا الرمز في C++ كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// يضيف إطار صوت إلى الشريحة بموقع وحجم محددين.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// يضيف صورة إلى موارد العرض التقديمي.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// يضبط الصورة لإطار الصوت.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//يحفظ العرض التقديمي المعدل إلى القرص
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تغيير خيارات تشغيل الصوت**

تتيح لك Aspose.Slides لـ C++ تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط حجم الصوت، تعيين الصوت للتشغيل في حلقة، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات صوت PowerPoint التي تتوافق مع طرق [AudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame) في Aspose.Slides:
- خيارات الصوت **ابدأ** قائمة منسدلة تطابق طريقة [AudioFrame::get_PlayMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b) 
- خيارات الصوت **حجم الصوت** تطابق طريقة [AudioFrame::get_Volume()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3)  
- خيارات الصوت **التشغيل عبر الشرائح** تطابق طريقة [AudioFrame::get_PlayAcrossSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0)  
- خيارات الصوت **تكرار حتى التوقف** تطابق طريقة [AudioFrame::get_PlayLoopMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b)  
- خيارات الصوت **إخفاء أثناء العرض** تطابق  طريقة [AudioFrame::get_HideAtShowing() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082)  
- خيارات الصوت **ارجاع بعد التشغيل** تطابق طريقة [AudioFrame::get_RewindAudio() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637) 

هذه هي كيفية تغيير خيارات تشغيل الصوت:

1. [إنشاء](#creating-audio-frame) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. احفظ ملف PowerPoint المعدل.

يوضح هذا الرمز في C++ عملية يتم فيها ضبط خيارات الصوت:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// الحصول على شكل
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// تحويل الشكل إلى شكل AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// يضبط وضع التشغيل للتشغيل عند النقر
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// يضبط الحجم على منخفض
audioFrame->set_Volume(AudioVolumeMode::Low);

// يضبط الصوت للتشغيل عبر الشرائح
audioFrame->set_PlayAcrossSlides(true);

// يعطل تكرار الصوت
audioFrame->set_PlayLoopMode(false);

// يخفي AudioFrame أثناء عرض الشرائح
audioFrame->set_HideAtShowing(true);

// يعيد الصوت إلى البداية بعد التشغيل
audioFrame->set_RewindAudio(true);

// يحفظ ملف PowerPoint إلى القرص
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **استخراج الصوت**
تسمح لك Aspose.Slides لـ .NET باستخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وقم بتحميل العرض التقديمي الذي يحتوي على الصوت.
2. احصل على مرجع الشريحة ذات الصلة من خلال مؤشرها.
3. اضبط انتقالات عرض الشرائح للشريحة.
4. استخراج الصوت في بيانات بايت.

يوضح هذا الرمز في C++ كيفية استخراج الصوت المستخدم في شريحة:

``` cpp
String presName = u"AudioSlide.pptx";

// ينشئ مثيلاً لفئة Presentation تمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(presName);

// يصل إلى الشريحة المطلوبة
auto slide = pres->get_Slides()->idx_get(0);

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
auto transition = slide->get_SlideShowTransition();

// يستخرج الصوت في مصفوفة بايت
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"الطول: ") + audio->get_Length());
```