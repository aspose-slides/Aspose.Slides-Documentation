---
title: إدارة الصوت في العروض التقديمية باستخدام C++
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/cpp/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج صوت
- C++
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides للغة C++ — أمثلة على الشيفرة لتضمين، تقليم، تكرار، وتكوين تشغيل عبر عروض PPT و PPTX و ODP."
---

## **إنشاء إطارات الصوت**

تتيح لك Aspose.Slides للغة C++ إضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كإطارات صوتية. 

1. أنشئ كائنًا من الفئة [العرض التقديمي](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على إشارة إلى الشريحة عبر فهرسها.
3. حمِّل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمّن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. اضبط [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame).
6. احفظ العرض التقديمي المعدل.

يعرض هذا الكود بلغة C++ كيفية إضافة إطار صوت مضمّن إلى شريحة:
``` cpp
// يُنشئ كائنًا من فئة Presentation تمثّل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحمِّل ملف صوت wav إلى تدفق
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// يضيف إطار الصوت
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// يضبط وضع التشغيل ومستوى الصوت للإطار الصوتي
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// يكتب ملف PowerPoint إلى القرص
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```


## **تغيير الصورة المصغرة لإطار الصوت**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير الصورة المصغرة لإطار الصوت (تعيين صورتك المفضلة).

يعرض هذا الكود بلغة C++ كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:
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
        
// يحفظ العرض التقديمي المعدل إلى القرص
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تغيير خيارات تشغيل الصوت**

تتيح لك Aspose.Slides للغة C++ تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى صوت الصوت، ضبط تشغيله بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **خيارات الصوت** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **الصوت** في PowerPoint التي تقابل أساليب Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/):

- **ابدأ** القائمة المنسدلة تتطابق مع الأسلوب [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/)
- **الصوت** يتطابق مع الأسلوب [AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/)
- **تشغيل عبر الشرائح** يتطابق مع الأسلوب [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/)
- **التكرار حتى الإيقاف** يتطابق مع الأسلوب [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/)
- **الإخفاء أثناء العرض** يتطابق مع الأسلوب [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/)
- **إعادة الالتفاف بعد التشغيل** يتطابق مع الأسلوب [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/)

خيارات **التحرير** في PowerPoint التي تقابل خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/):

- **تلاشي داخل** يتطابق مع الأسلوب [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/)
- **تلاشي خارج** يتطابق مع الأسلوب [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/)
- **تقليم وقت بدء الصوت** يتطابق مع الأسلوب [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/)
- **تقليم وقت انتهاء الصوت** يساوي مدة الصوت مطروحًا منه قيمة الأسلوب [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/)

متحكم **الصوت** في لوحة التحكم الخاصة بالصوت في PowerPoint يتطابق مع الأسلوب [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/). يتيح لك تغيير مستوى الصوت كنسبة مئوية.

إليك كيفية تغيير خيارات تشغيل الصوت:

1. [إنشاء](#creating-audio-frame) أو الحصول على إطار الصوت.
2. اضبط القيم الجديدة لخصائص إطار الصوت التي تريد تعديلها.
3. احفظ ملف PowerPoint المعدل.

يوضح هذا الكود بلغة C++ عملية تعديل خيارات الصوت:
``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// يحصل على شكل
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// يحول الشكل إلى شكل AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// يضبط وضع التشغيل للتشغيل عند النقر
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// يضبط مستوى الصوت إلى منخفض
audioFrame->set_Volume(AudioVolumeMode::Low);

// يضبط تشغيل الصوت عبر الشرائح
audioFrame->set_PlayAcrossSlides(true);

// يعطل التكرار للصوت
audioFrame->set_PlayLoopMode(false);

// يخفي إطار الصوت أثناء عرض الشرائح
audioFrame->set_HideAtShowing(true);

// يعيد الصوت إلى البداية بعد التشغيل
audioFrame->set_RewindAudio(true);

// يحفظ ملف PowerPoint إلى القرص
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```


هذا المثال بلغة C++ يوضح كيفية إضافة إطار صوت جديد مع صوت مضمّن، تقليصه، وتعيين مدد التلاشي:
```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


يظهر الجزء التالي من الكود كيفية استرجاع إطار صوت مضمّن وتعيين مستوى صوته إلى 85%:
```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// يحصل على شكل إطار صوت
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// يضبط مستوى الصوت إلى 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


## **استخراج الصوت**
تتيح لك Aspose.Slides استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة محددة.

1. أنشئ كائنًا من الفئة [العرض التقديمي](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) وحمِّل العرض التقديمي الذي يحتوي على الصوت.
2. احصل على إشارة إلى الشريحة ذات الصلة عبر فهرسها.
3. احصل على انتقالات عرض الشرائح للشريحة.
4. استخرج الصوت في شكل بيانات بايت.

يعرض هذا الكود بلغة C++ كيفية استخراج الصوت المستخدم في شريحة:
``` cpp
String presName = u"AudioSlide.pptx";

// ينشئ كائنًا من فئة Presentation تمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(presName);

// يصل إلى الشريحة المطلوبة
auto slide = pres->get_Slides()->idx_get(0);

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
auto transition = slide->get_SlideShowTransition();

// يستخرج الصوت في مصفوفة بايت
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```


## **الأسئلة المتداولة**

**هل يمكنني إعادة استخدام ملف الصوت نفسه عبر شرائح متعددة دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [مجموعة الصوت المشتركة](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) في العرض التقديمي، ثم أنشئ إطارات صوت إضافية تشير إلى ذلك الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، حدّث [مسار الارتباط](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/) ليشير إلى الملف الجديد. بالنسبة للصوت المضمّن، استبدل كائن [الصوت المضمّن](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/) بآخر من [مجموعة الصوت](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) في العرض التقديمي. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هو.

**هل يغيّر التقليم بيانات الصوت الأصلية المخزنة في العرض التقديمي؟**

لا. يقوم التقليم بضبط حدود التشغيل فقط. تظل بايتات الصوت الأصلية دون تعديل ويمكن الوصول إليها عبر الصوت المضمّن أو مجموعة الصوت في العرض التقديمي.