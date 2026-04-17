---
title: إدارة الصوت في العروض التقديمية باستخدام C++
linktitle: إطار صوتي
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
- استخراج الصوت
- C++
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides for C++ — أمثلة شيفرة لتضمين الصوت، قصه، تشغيله بشكل متكرر، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---
## **إنشاء إطارات صوتية**

يسمح Aspose.Slides for C++ بإضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية. 

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. ضبط [PlayMode](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_audio_frame).
6. حفظ العرض المعدل.

هذا الكود C++ يوضح لك كيفية إضافة إطار صوتي مدمج إلى شريحة:

``` cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحمّل ملف الصوت wav إلى تدفق
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// يضيف إطار صوتي
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// يضبط وضع التشغيل ومستوى الصوت للصوت
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// يكتب ملف PowerPoint إلى القرص
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **تغيير الصورة المصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير الصورة المصغرة لإطار الصوت (تعيين الصورة المفضلة لديك).

هذا الكود C++ يوضح لك كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

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

يسمح Aspose.Slides for C++ بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط حجم الصوت، أو تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتطابق مع طرق Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/) :

- قائمة **Start** المنسدلة تتطابق مع طريقة [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_playmode/).
- **Volume** تتطابق مع طريقة [AudioFrame::set_Volume](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_volume/).
- **Play Across Slides** تتطابق مع طريقة [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_playacrossslides/).
- **Loop until Stopped** تتطابق مع طريقة [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_playloopmode/).
- **Hide During Show** تتطابق مع طريقة [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_hideatshowing/).
- **Rewind after Playing** تتطابق مع طريقة [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_rewindaudio/).

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/) :

- **Fade In** تتطابق مع طريقة [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_fadeinduration/).
- **Fade Out** تتطابق مع طريقة [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_fadeoutduration/).
- **Trim Audio Start Time** تتطابق مع طريقة [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_trimfromstart/).
- قيمة **Trim Audio End Time** تساوي مدة الصوت مطروحًا منها قيمة طريقة [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_trimfromend/).

متحكم **Volume** في لوحة التحكم الصوتي في PowerPoint يتطابق مع طريقة [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_volumevalue/). يتيح لك تغيير حجم الصوت كنسبة مئوية.

هذه هي الطريقة لتغيير خيارات تشغيل الصوت:

1. [Сreate](#creating-audio-frame) أو الحصول على إطار الصوت.
2. ضبط القيم الجديدة للخصائص التي تريد تعديلها في إطار الصوت.
3. حفظ ملف PowerPoint المعدل.

هذا الكود C++ يوضح عملية تعديل خيارات الصوت:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// احصل على شكل
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// يحوّل الشكل إلى شكل AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// يضبط وضع التشغيل لتشغيل عند النقر
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

هذا المثال C++ يوضح كيفية إضافة إطار صوتي جديد مع صوت مدمج، قصه، وتعيين مدة التلاشي:

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

العينة البرمجية التالية توضح كيفية استرجاع إطار صوتي مدمج وتعيين مستوى الصوت إلى 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// يحصل على شكل إطار صوت
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// يضبط مستوى الصوت إلى 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **إدارة تسميات الصوت**

يسمح Aspose.Slides بإضافة تسميات مغلقة إلى إطار صوتي عبر طريقة [get_CaptionTracks](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iaudioframe/get_captiontracks/). تُرجع هذه الطريقة كائنًا من نوع [ICaptionsCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/)، والذي يتيح لك إضافة مسارات تسمية WebVTT، والقيام بالتكرار عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة تسميات صوتية**

استخدم طريقة [get_CaptionTracks](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iaudioframe/get_captiontracks/) لإرفاق مسار أو أكثر من مسارات التسمية إلى إطار صوتي. في المثال التالي، يتم إضافة ملف صوتي إلى شريحة، ثم يتم تحميل مسار تسمية جديد من ملف `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// إضافة مسار توضيحات جديد من ملف WebVTT.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**استخراج تسميات صوتية**

يمكنك التكرار عبر مسارات التسمية المرتبطة بإطار صوتي وحفظها كملفات `.vtt`. كل مسار تسمية يكشف عن بياناته الثنائية ومعرفه الفريد، مما يمكن استخدامه عند تصدير التسميات.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // احفظ كل مسار توضيحات كملف .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**إزالة تسميات صوتية**

لإزالة التسميات من إطار صوتي، استخدم الطرق المتاحة في [ICaptionsCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/)، مثل [Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/clear/)، [Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/remove/)، أو [RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icaptionscollection/removeat/). المثال التالي يزيل جميع مسارات التسمية من إطار صوتي.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// إزالة جميع مسارات التسمية من إطار الصوت.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استخراج الصوت**
يسمح Aspose.Slides باستخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى انتقالات عرض الشرائح لتلك الشريحة.
4. استخراج الصوت كبيانات بايت.

هذا الكود C++ يوضح لك كيفية استخراج الصوت المستخدم في شريحة:

``` cpp
String presName = u"AudioSlide.pptx";

// ينشئ كائنًا من فئة Presentation التي تمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(presName);

// الوصول إلى الشريحة المطلوبة
auto slide = pres->get_Slides()->idx_get(0);

// يحصل على تأثيرات انتقال عرض الشرائح للشريحة
auto transition = slide->get_SlideShowTransition();

// يستخرج الصوت في مصفوفة بايت
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [مجموعة الصوت المشتركة](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_audios/) في العرض التقديمي وأنشئ إطارات صوتية إضافية تشير إلى ذلك الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوتي موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، قم بتحديث [مسار الرابط](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_linkpathlong/) للإشارة إلى الملف الجديد. بالنسبة للصوت المدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/cpp/aspose.slides/audioframe/set_embeddedaudio/) بآخر من [مجموعة الصوت](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_audios/) في العرض التقديمي. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي القص إلى تغيير بيانات الصوت الأصلية المخزنة في العرض التقديمي؟**

لا. يقتصر القص على تعديل حدود التشغيل. تظل بايتات الصوت الأصلية دون تغيير ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الصوت في العرض.