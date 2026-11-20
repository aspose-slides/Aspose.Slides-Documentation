---
title: إدارة إطارات الصوت في العروض التقديمية باستخدام C++
linktitle: إطار صوت
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
description: "إدراج صوت في الشرائح، تغيير أيقونة الصوت، ضبط تشغيله، إدارة ترجمات WebVTT، واستخراج أصوات انتقال الشرائح باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

إطار الصوت يتيح لك تشغيل صوت على الشريحة. باستخدام Aspose.Slides for C++, يمكنك تضمين مقطع صوتي، اختيار الصورة التي تمثله، ضبط التشغيل، وإرفاق الترجمات. يمكنك أيضًا استرجاع الصوت المعين لانتقال الشريحة.

## **إنشاء إطارات صوتية**

استخدم [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) لتضمين مقطع صوتي محلي على الشريحة الأولى. الإحداثيين الأوليين يحددان موضع الإطار على الشريحة، والقيمتين التاليتين تحددان عرضه وارتفاعه، جميعًا بالنقاط. هذا المثال يستدعي [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) لتشغيل المقطع تلقائيًا ويستدعي [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) لاختيار مستوى الصوت المرتفع.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **تغيير صورة مصغرة لإطار الصوت**

بشكل افتراضي، يعرض إطار الصوت أيقونة مكبر صوت. لعرض صورة مصغرة مخصصة، أضف صورة إلى العرض التقديمي باستخدام [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) وحددها كصورة الإطار عبر [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/). المثال يستخدم ملف JPEG كصورة مصغرة لمقطع صوتي مضمّن.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **تغيير خيارات تشغيل الصوت**

تحدد عناصر تحكم **Audio Options** في PowerPoint متى يبدأ المقطع، ومدى صوته، وكيفية تصرفه أثناء عرض الشرائح.

![عناصر التحكم في Audio Options في PowerPoint لإطار صوت](audio_frame_0.png)

| عنصر تحكم PowerPoint | طريقة Aspose.Slides for C++ |
| --- | --- |
| ابدأ | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| مستوى الصوت المسبق | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| تشغيل عبر الشرائح | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| تكرار حتى الإيقاف | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| إخفاء أثناء العرض | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| إعادة إلى البداية بعد التشغيل | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| تلاشي الدخول | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| تلاشي الخروج | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| تقليم بدء الصوت | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| تقليم انتهاء الصوت | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| شريط مستوى الصوت | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

يقوم المثال بالعثور على أول إطار صوت في الشريحة الأولى، ويستدعي [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) لبدء التشغيل عند النقر، ويختار مستوى الصوت المنخفض. يستمر المقطع عبر الشرائح مع تعطيل التكرار. تظل الأيقونة مخفية أثناء العرض، ويُعاد تشغيل المقطع من البداية بعد التشغيل.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

لمقطع أطول من 3.5 ثوانٍ، يتخطى هذا المثال الثواني الأولى 1.5 ثانية والأخيرة ثانيتين. المعامل في [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) يحدد المدة التي تُحذف من نهاية المقطع. للحصول على وقت النهاية المعروض في PowerPoint، اطرح هذا الإزاحة من المدة الكاملة للمقطع. المقطع المقصوص يتلاشى عند البدء خلال 200 مللي ثانية ويتلاشى عند الانتهاء خلال 500 مللي ثانية. جميع الدالات الأربعة تأخذ قيمًا بالمللي ثانية.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

لتعيين حجم التشغيل بنسبة مئوية محددة، استخدم [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/). يضبط هذا المثال أول إطار صوت في الشريحة الأولى إلى 85٪.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **إدارة الترجمات الصوتية**

كل إطار صوت يكشف عن مجموعة الترجمات الخاصة به عبر [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/). استخدمها لإرفاق ترجمات WebVTT بالمقطع، أو تصدير المسارات الموجودة، أو إزالتها.

### **إضافة ترجمات صوتية**

يقوم المثال بتضمين مقطع صوتي في الشريحة الأولى ويستخدم [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) لإرفاق مسار WebVTT محلي. المعامل الأول يزود بتسمية المسار، والثاني يحدد الملف الذي يحتوي على الترجمات الزمنية.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **استخراج ترجمات الصوت**

يقوم هذا المثال بتصدير كل مسار ترجمة مرفق بإطار صوت في الشريحة الأولى. يكتب البايتات التي تُرجعها [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) إلى ملف WebVTT ويستخدم القيمة التي تُرجعها [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) كاسم ملف بحيث يكون لكل مسار مخرج منفصل.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **إزالة ترجمات الصوت**

استخدم [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) أو [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) لحذف مسار فردي. يستخدم المثال [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) لإزالة جميع الترجمات من أول إطار صوت في الشريحة الأولى مع الحفاظ على المقطع.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **العثور على سطر في ترجمات الصوت**

للعثور على سطر في ترجمات الصوت في الشريحة الأولى، استدعِ [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) على كل مسار لقراءة نص WebVTT الخاص به في الذاكرة. في إشارة WebVTT بنص عادي، يحتوي سطر التوقيت على `-->`، وتليها سطور الترجمات، وينتهي الإشارة بسطر فارغ. يطبع هذا المثال تسمية المسار وكل سطر ترجمة يحتوي على “café”.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **استخراج الصوت**

يمكن أن يحتوي انتقال الشرائح على صوت خاص به. لاسترجاعه، استدعِ [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) على الانتقال. يسترجع المثال بايتات الصوت عبر [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) ويطبع عدد البايتات. إذا لم تحتوي الشريحة الأولى على صوت انتقال، فسيطبع رسالة بدلاً من ذلك.

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **الأسئلة المتكررة**

**هل يمكنني إعادة استخدام نفس مقطع الصوت عبر عدة شرائح دون تكراره؟**

نعم. أضف المقطع مرة واحدة إلى [مجموعة الصوت](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) الخاصة بالعرض التقديمي ومرّر نفس كائن الصوت إلى [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) لكل شريحة.

**هل يمكنني استبدال الصوت في إطار صوت موجود؟**

نعم. للحصول على صوت مرتبط، استدعِ [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) مع مسار الملف البديل. بالنسبة إلى صوت مضمّن، مرّر مقطعًا آخر من مجموعة الصوت في العرض التقديمي إلى [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/). كلا النهجين يحافظان على الإطار الموجود.

**هل يغيّر التقليم بيانات الصوت المخزنة في العرض التقديمي؟**

لا. تقوم [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) و[set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) بتحديد حدود التشغيل. لا يزال بإمكانك استرجاع المقطع الكامل عبر [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/).