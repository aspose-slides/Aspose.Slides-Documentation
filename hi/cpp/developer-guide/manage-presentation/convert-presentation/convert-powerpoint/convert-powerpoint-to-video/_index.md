---
title: C++ में PowerPoint प्रस्तुतियों को वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से वीडियो
- प्रस्तुति से वीडियो
- PPT से वीडियो
- PPTX से वीडियो
- PowerPoint से MP4
- प्रस्तुति से MP4
- PPT से MP4
- PPTX से MP4
- PPT को MP4 के रूप में सहेजें
- PPTX को MP4 के रूप में सहेजें
- PPT को MP4 में निर्यात करें
- PPTX को MP4 में निर्यात करें
- वीडियो रूपांतरण
- PowerPoint
- C++
- Aspose.Slides
description: "C++ में PowerPoint प्रस्तुतियों को वीडियो में बदलना सीखें। अपने कार्यप्रवाह को सुघड़ बनाने के लिए नमूना कोड और स्वचालन तकनीकें खोजें।"
---
## **परिचय**

PowerPoint प्रस्तुति को वीडियो में बदलकर, आप प्राप्त करते हैं 

* **पहुंच में वृद्धि:** सभी उपकरण (प्लैटफ़ॉर्म की परवाह किए बिना) डिफ़ॉल्ट रूप से वीडियो प्लेयर से सुसज्जित होते हैं, जबकि प्रस्तुति‑खोलने वाले अनुप्रयोग नहीं होते, इसलिए उपयोगकर्ताओं को वीडियो खोलना या चलाना आसान लगता है।  
* **अधिक पहुंच:** वीडियो के माध्यम से आप बड़ी दर्शक संख्या तक पहुंच सकते हैं और उन्हें ऐसी जानकारी प्रदान कर सकते हैं जो प्रस्तुति में थकाऊ लग सकती है। अधिकांश सर्वेक्षण और आँकड़े दर्शाते हैं कि लोग वीडियो को अन्य सामग्री की तुलना में अधिक देखते और उपभोग करते हैं, और आम तौर पर ऐसी सामग्री को पसंद करते हैं।

[Aspose.Slides 22.11](https://docs.aspose.com/slides/hi/cpp/aspose-slides-for-cpp-22-11-release-notes/) में हमने प्रस्तुति को वीडियो में बदलने के समर्थन को लागू किया। 

* Aspose.Slides का उपयोग करके फ्रेमों का सेट उत्पन्न करें (प्रस्तुति स्लाइड्स से) जो किसी निश्चित FPS (फ़्रेम प्रति सेकंड) के अनुरूप हो।  
* `ffmpeg` जैसी थर्ड‑पार्टी यूटिलिटी का उपयोग करके फ्रेमों के आधार पर वीडियो बनाएँ।

## **PowerPoint प्रस्तुति को वीडियो में बदलें**

1. ffmpeg डाउनलोड करें [यहाँ](https://ffmpeg.org/download.html)।
2. पर्यावरण चर `PATH` में `ffmpeg.exe` का पथ जोड़ें।
3. PowerPoint से वीडियो कोड चलाएँ।

यह C++ कोड आपको दिखाता है कि कैसे एक प्रस्तुति (जिसमें एक चित्र और दो एनीमेशन इफ़ेक्ट्स हैं) को वीडियो में बदला जाए:

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // एक स्माइली आकार जोड़ता है और फिर उसे एनीमेट करता है
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **वीडियो इफ़ेक्ट्स**

आप स्लाइड्स पर वस्तुओं पर एनीमेशन लागू कर सकते हैं और स्लाइड्स के बीच ट्रांज़िशन का उपयोग कर सकते हैं।

{{% alert color="info" %}} 

आप इन लेखों को देखना चाह सकते हैं: [PowerPoint एनीमेशन](https://docs.aspose.com/slides/hi/cpp/powerpoint-animation/), [शेप एनीमेशन](https://docs.aspose.com/slides/hi/cpp/shape-animation/), और [शेप इफ़ेक्ट](https://docs.aspose.com/slides/hi/cpp/shape-effect/)।

{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं—और वीडियो के लिए भी यही करते हैं। चलिए पिछले प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ते हैं:

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// ऊपर दिखाए अनुसार एक स्माइली आकार जोड़ता है और उसे एनीमेट करता है
auto presentation = System::MakeObject<Presentation>();

// एक नई स्लाइड जोड़ता है और एनीमेटेड ट्रांज़िशन सेट करता है
System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides टेक्स्ट के लिए भी एनीमेशन समर्थन करता है। इसलिए हम वस्तुओं पर पैराग्राफ़ को एनीमेट करते हैं, जो एक के बाद एक दिखाई देंगे (विलंब एक सेकंड पर सेट किया गया है):

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // टेक्स्ट और एनीमेशन जोड़ता है
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // फ़्रेम को वीडियो में बदलता है
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **वीडियो परिवर्तन क्लासेस**

Aspose.Slides आपको PowerPoint से वीडियो परिवर्तन कार्य करने के लिए [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_animations_generator/) और [PresentationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_player/) क्लासेस प्रदान करता है।

PresentationAnimationsGenerator आपको वीडियो (जो बाद में बनाया जाएगा) के फ्रेम आकार को उसके कंस्ट्रक्टर के माध्यम से सेट करने की अनुमति देता है। यदि आप प्रस्तुति का एक इंस्टेंस पास करते हैं, तो `Presentation.SlideSize` उपयोग होगा और यह ऐसी एनीमेशन उत्पन्न करता है जिसे [PresentationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_player/) उपयोग करता है। 

जब एनीमेशन उत्पन्न होते हैं, तो प्रत्येक बाद की एनीमेशन के लिए एक `NewAnimation` इवेंट जेनरेट किया जाता है, जिसमें [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player/) पैरामीटर होता है। बाद वाला क्लास एक अलग एनीमेशन के प्लेयर को दर्शाता है।

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player/) के साथ काम करने के लिए, [get_Duration](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (एनीमेशन की कुल अवधि) प्रॉपर्टी और [SetTimePosition](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) मेथड का उपयोग किया जाता है। प्रत्येक एनीमेशन पोज़िशन *0 से duration* की रेंज में सेट किया जाता है, और फिर `GetFrame` मेथड उस क्षण की एनीमेशन स्थिति के अनुरूप एक Bitmap लौटाता है।

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // प्रारम्भिक एनीमेशन स्थिति
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // प्रारम्भिक एनीमेशन स्थिति बिटमैप

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // एनीमेशन की अंतिम स्थिति
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // एनीमेशन की अंतिम फ्रेम
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // एक स्माइली आकार जोड़ता है और उसे एनीमेट करता है
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

प्रस्तुति में सभी एनीमेशन को एक साथ चलाने के लिए, [PresentationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_player/) क्लास का उपयोग किया जाता है। यह क्लास अपने कंस्ट्रक्टर में एक [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_animations_generator/) इंस्टेंस और प्रभावों के लिए FPS लेता है और फिर सभी एनीमेशन को चलाने के लिए `FrameTick` इवेंट को कॉल करता है:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

फ़िर उत्पन्न फ्रेमों को जोड़कर एक वीडियो बनाया जा सकता है। देखें [Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) अनुभाग।

## **समर्थित एनीमेशन और इफ़ेक्ट्स**

**प्रवेश**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Fade** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Fly In** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Float In** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Split** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Wipe** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shape** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Wheel** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Random Bars** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Grow & Turn** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Zoom** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Swivel** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Bounce** | ![समर्थित](v.png) | ![समर्थित](v.png) |

**जोर**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Color Pulse** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Teeter** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Spin** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Grow/Shrink** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Desaturate** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Darken** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Lighten** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Transparency** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Object Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Complementary Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Line Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Fill Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |

**निर्गमन**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Fade** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Fly Out** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Float Out** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Split** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Wipe** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shape** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Random Bars** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shrink & Turn** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Zoom** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Swivel** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Bounce** | ![समर्थित](v.png) | ![समर्थित](v.png) |

**मोशन पाथ:**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Arcs** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Turns** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shapes** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Loops** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Custom Path** | ![समर्थित](v.png) | ![समर्थित](v.png) |

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या पासवर्ड-प्रोटेक्टेड प्रस्तुतियों को बदलना संभव है?

हाँ, Aspose.Slides आपको [password-protected presentations](/slides/hi/cpp/password-protected-presentation/) के साथ काम करने की अनुमति देता है। ऐसे फ़ाइलों को प्रोसेस करते समय आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

### क्या Aspose.Slides क्लाउड समाधान में उपयोग का समर्थन करता है?

हाँ, Aspose.Slides को क्लाउड एप्लिकेशन और सेवाओं में एकीकृत किया जा सकता है। यह लाइब्रेरी सर्वर वातावरण में काम करने के लिए डिज़ाइन की गई है, जो फ़ाइलों की बैच प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी सुनिश्चित करती है।

### क्या परिवर्तन के दौरान प्रस्तुतियों के आकार में कोई सीमा है?

Aspose.Slides लगभग किसी भी आकार की प्रस्तुतियों को संभालने में सक्षम है। हालांकि, बहुत बड़े फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और प्रदर्शन सुधारने के लिए प्रस्तुतियों को ऑप्टिमाइज़ करने की सलाह दी जाती है।