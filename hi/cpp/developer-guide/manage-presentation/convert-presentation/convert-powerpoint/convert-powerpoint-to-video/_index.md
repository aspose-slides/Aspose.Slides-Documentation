---
title: C++ में PowerPoint प्रस्तुतियों को वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- PPT को बदलें
- PPTX को बदलें
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
description: "C++ में PowerPoint प्रस्तुतियों को वीडियो में बदलना सीखें। कार्यप्रवाह को सरल बनाने के लिए नमूना कोड और स्वचालन तकनीकों की खोज करें।"
---
## **परिचय**

अपनी PowerPoint प्रस्तुति को वीडियो में बदलकर आप प्राप्त करते हैं 

* **पहुँच में वृद्धि:** सभी उपकरण (प्लेटफ़ॉर्म की परवाह किए बिना) डिफ़ॉल्ट रूप से वीडियो प्लेयर से सुसज्जित होते हैं, प्रस्तुति खोलने वाले अनुप्रयोगों की तुलना में, इसलिए उपयोगकर्ताओं के लिए वीडियो खोलना या चलाना आसान होता है।
* **अधिक पहुंच:** वीडियो के माध्यम से आप बड़ी दर्शक वर्ग तक पहुंच सकते हैं और उन्हें ऐसी जानकारी दे सकते हैं जो प्रस्तुति में बोझिल लग सकती है। अधिकांश सर्वेक्षण और आँकड़े दर्शाते हैं कि लोग अन्य सामग्री के रूपों की तुलना में वीडियो अधिक देखते और उपभोग करते हैं, और सामान्यतः वे ऐसी सामग्री को पसंद करते हैं।

[Aspose.Slides 22.11](https://docs.aspose.com/slides/hi/cpp/aspose-slides-for-cpp-22-11-release-notes/) में, हमने प्रस्तुति से वीडियो रूपांतरण के लिए समर्थन लागू किया। 

* Aspose.Slides का उपयोग करके फ्रेम (प्रेज़ेंटेशन स्लाइडों से) का एक सेट उत्पन्न करें जो एक विशेष FPS (फ़्रेम्स प्रति सेकंड) के अनुरूप हो
* `ffmpeg` जैसे तृतीय‑पक्षीय यूटिलिटी का उपयोग करके फ्रेमों से वीडियो बनाएं।

## **वीडियो रूपांतरण**

1. ffmpeg को [यहाँ](https://ffmpeg.org/download.html) डाउनलोड करें।
2. `ffmpeg.exe` का पाथ environment variable `PATH` में जोड़ें।
3. PowerPoint को वीडियो में बदलने का कोड चलाएँ।

यह C++ कोड दर्शाता है कि कैसे एक प्रस्तुति (जिसमें एक फ़िगर और दो एनीमेशन इफ़ेक्ट हैं) को वीडियो में बदला जाए:

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // एक स्माइली आकृति जोड़ता है और फिर इसे एनीमेट करता है
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **वीडियो प्रभाव**

आप स्लाइडों पर वस्तुओं पर एनीमेशन लागू कर सकते हैं और स्लाइडों के बीच ट्रांज़िशन का उपयोग कर सकते हैं।

{{% alert color="primary" %}} 

आप इन लेखों को देखना चाह सकते हैं: [PowerPoint एनीमेशन](https://docs.aspose.com/slides/hi/cpp/powerpoint-animation/), [शेप एनीमेशन](https://docs.aspose.com/slides/hi/cpp/shape-animation/), और [शेप इफ़ेक्ट](https://docs.aspose.com/slides/hi/cpp/shape-effect/)।

{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं—और वीडियो के लिए भी यही लागू होता है। चलिए पहले की प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ते हैं:

```c++
// एक स्माइली आकृति जोड़ता है और इसे एनीमेट करता है

// ...

// एक नई स्लाइड जोड़ता है और एनीमेटेड ट्रांज़िशन

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides पाठों के लिए भी एनीमेशन का समर्थन करता है। इसलिए हम वस्तुओं पर पैराग्राफ़ को एनीमेट करते हैं, जो एक‑के‑बाद‑एक दिखाई देंगे (विलंब एक सेकंड पर सेट किया गया है):

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // पाठ और एनीमेशन जोड़ता है
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **वीडियो रूपांतरण वर्ग**

PowerPoint को वीडियो में बदलने के कार्य करने के लिए, Aspose.Slides ने [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_animations_generator/) और [PresentationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_player/) क्लासेस प्रदान किए हैं।

PresentationAnimationsGenerator आपको उसके कन्स्ट्रक्टर के माध्यम से वीडियो (जो बाद में बनाया जाएगा) के फ्रेम आकार को सेट करने की अनुमति देता है। यदि आप प्रस्तुति का एक इंस्टेंस पास करते हैं, तो `Presentation.SlideSize` उपयोग किया जाएगा और यह ऐसी एनीमेशन जेनरेट करता है जिन्हें [PresentationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_player/) उपयोग करता है। 

जब एनीमेशन जेनरेट होते हैं, तो प्रत्येक क्रमिक एनीमेशन के लिए एक `NewAnimation` इवेंट जेनरेट होता है, जिसमें [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player/) पैरामीटर होता है। यह क्लास एक अलग एनीमेशन के प्लेयर का प्रतिनिधित्व करती है।

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player/) के साथ काम करने के लिए, [get_Duration](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (एनीमेशन की पूरी अवधि) प्रॉपर्टी और [SetTimePosition](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) मेथड का उपयोग किया जाता है। प्रत्येक एनीमेशन पोज़िशन को *0 से अवधि* रेंज के भीतर सेट किया जाता है, और फिर `GetFrame` मेथड उस क्षण की एनीमेशन अवस्था से मेल खाने वाला Bitmap लौटाएगा।

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // प्रारम्भिक एनीमेशन स्थिति
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // प्रारम्भिक एनीमेशन स्थिति बिटमैप

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // एनीमेशन की अंतिम स्थिति
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // एनीमेशन का अंतिम फ्रेम
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // एक स्माइली आकृति जोड़ता है और इसे एनीमेट करता है
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

सभी एनीमेशन को एक साथ चलाने के लिए, [PresentationPlayer](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_player/) क्लास का उपयोग किया जाता है। यह क्लास अपने कन्स्ट्रक्टर में एक [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.presentation_animations_generator/) इंस्टेंस और इफ़ेक्ट्स के लिए FPS लेता है और फिर सभी एनीमेशन को चलाने के लिए `FrameTick` इवेंट को कॉल करता है:

```c++
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

फिर उत्पन्न फ़्रेमों को संकलित करके एक वीडियो बनाया जा सकता है। देखें [Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) अनुभाग।

## **समर्थित एनीमेशन और इफ़ेक्ट्स**


**प्रवेश**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**जोर**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**निकास**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**मोशन पाथ्स**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या पासवर्ड‑प्रोटेक्टेड प्रस्तुतियों को रूपांतरित करना संभव है?**

हाँ, Aspose.Slides [password‑protected presentations](/slides/hi/cpp/password-protected-presentation/) के साथ काम करने की अनुमति देता है। ऐसे फ़ाइलों को प्रोसेस करने के लिए आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

**क्या Aspose.Slides क्लाउड समाधान में उपयोग का समर्थन करता है?**

हाँ, Aspose.Slides को क्लाउड एप्लिकेशन और सेवाओं में एकीकृत किया जा सकता है। यह लाइब्रेरी सर्वर वातावरण में काम करने के लिए डिज़ाइन की गई है, जिससे बैच फ़ाइल प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी मिलती है।

**रूपांतरण के दौरान प्रस्तुतियों के आकार पर कोई प्रतिबंध है क्या?**

Aspose.Slides लगभग किसी भी आकार की प्रस्तुतियों को संभाल सकता है। हालांकि, बहुत बड़े फ़ाइलों के साथ काम करने पर अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और प्रदर्शन सुधारने के लिए प्रस्तुतियों को अनुकूलित करना कभी‑कभी अनुशंसित होता है।