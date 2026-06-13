---
title: प्रस्तुतियों में C++ का उपयोग करके आकार एनीमेशन लागू करना
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/cpp/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनीमेटेड आकार
- एनीमेटेड टेक्स्ट
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव आवाज
- एनीमेशन लागू करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में आकार एनीमेशन बनाने और अनुकूलित करने का तरीका जानें। अलग दिखें!"
---
## **परिचय**

एनिमेशन वे दृश्य प्रभाव हैं जिन्हें टेक्स्ट, छवियां, आकार, या [चार्ट](/slides/hi/cpp/animated-charts/) पर लागू किया जा सकता है। वे प्रस्तुतियों या उनकी घटकों को जीवन देते हैं। 

## **प्रस्तुतीकरण में एनिमेशन का उपयोग क्यों करें?**

एनिमेशन का उपयोग करके आप 

* सूचना के प्रवाह को नियंत्रित करें
* महत्वपूर्ण बिंदुओं पर जोर दें
* आपके दर्शकों की रुचि या भागीदारी बढ़ाएं
* सामग्री को पढ़ने, समझने या संसाधित करने में आसान बनाएं
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुतीकरण के महत्वपूर्ण भागों की ओर आकर्षित करें

PowerPoint एनिमेशन और एनिमेशन प्रभावों के लिए कई विकल्प और उपकरण प्रदान करता है, जो **प्रवेश**, **निकास**, **जोर**, और **गति पथ** श्रेणियों में विभाजित हैं। 

## **Aspose.Slides में एनिमेशन**

* Aspose.Slides उन क्लासेज़ और प्रकारों को प्रदान करता है जिनकी आपको एनिमेशन के साथ काम करने के लिए आवश्यकता है, जो [Aspose.Slides.Animation](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation) नेमस्पेस के अंतर्गत हैं,
* Aspose.Slides [EffectType](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) एन्यूमरेशन के तहत **150 से अधिक एनिमेशन प्रभाव** प्रदान करता है। ये प्रभाव मूल रूप से PowerPoint में उपयोग किए जाने वाले समान (या समकक्ष) प्रभाव हैं। 

## **टेक्स्टबॉक्स पर एनीमेशन लागू करें**

Aspose.Slides for C++ आपको आकृति में टेक्स्ट पर एनीमेशन लागू करने की अनुमति देता है। 

1. एक नया [Presentation] क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. `rectangle` प्रकार का एक [IAutoShape] जोड़ें। 
4. [IAutoShape.TextFrame] में टेक्स्ट जोड़ें। 
5. इफ़ेक्ट्स की मुख्य अनुक्रम प्राप्त करें। 
6. [IAutoShape] में एक एनीमेशन इफ़ेक्ट जोड़ें। 
7. [TextAnimation.BuildType] प्रॉपर्टी को [BuildType Enumeration] के मान पर सेट करें। 
8. प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें। 

यह C++ कोड दर्शाता है कि कैसे `Fade` इफ़ेक्ट को AutoShape पर लागू किया जाए और टेक्स्ट एनीमेशन को *By 1st Level Paragraphs* मान पर सेट किया जाये:

```c++
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

टेक्स्ट पर एनीमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_paragraph) पर भी एनीमेशन लागू कर सकते हैं। देखें [**एनिमेटेड टेक्स्ट**](/slides/hi/cpp/animated-text/).

{{% /alert %}} 

## **PictureFrame पर एनीमेशन लागू करें**

1. एक नया [Presentation] क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड पर एक [PictureFrame] जोड़ें या प्राप्त करें। 
4. इफ़ेक्ट्स की मुख्य अनुक्रम प्राप्त करें। 
5. [PictureFrame] में एनीमेशन इफ़ेक्ट जोड़ें। 
6. प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें। 

यह C++ कोड दर्शाता है कि कैसे `Fly` इफ़ेक्ट को picture frame पर लागू किया जाए:

```c++
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// प्रस्तुति इमेज संग्रह में जोड़ने के लिए इमेज लोड करता है
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// स्लाइड में पिक्चर फ्रेम जोड़ता है
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// पिक्चर फ्रेम पर बाएं से फ़्लाइ एनीमेशन प्रभाव जोड़ता है
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **आकृति पर एनीमेशन लागू करें**

1. एक नया [Presentation] क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. `rectangle` प्रकार का एक [IAutoShape] जोड़ें। 
4. एक `Bevel` [IAutoShape] जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाता है, तो एनीमेशन चलाया जाता है)। 
5. Bevel आकार पर इफ़ेक्ट्स का अनुक्रम बनाएं। 
6. एक कस्टम `UserPath` बनाएं। 
7. `UserPath` पर चलने के लिए कमांड जोड़ें। 
8. प्रेजेंटेशन को डिस्क पर PPTX फ़ाइल के रूप में लिखें। 

यह C++ कोड दर्शाता है कि कैसे `PathFootball` (पाथ फुटबॉल) इफ़ेक्ट को आकृति पर लागू किया जाए:

```c++
	// दस्तावेज़ निर्देशिका का पथ।
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// प्रस्तुति लोड करता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// पहली स्लाइड तक पहुंचता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// चयनित स्लाइड के लिए आकार संग्रह तक पहुंचता है
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// मौजूदा आकार के लिए शुरू से PathFootball इफ़ेक्ट बनाता है।
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// कुछ प्रकार का "बटन" बनाता है।
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// इस बटन के लिए इफ़ेक्ट्स का अनुक्रम बनाता है।
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // कस्टम उपयोगकर्ता पाथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक होने के बाद ही स्थानांतरित होगा।
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// चूंकि बनाया गया पाथ खाली है, इसलिए स्थानांतरण कमांड जोड़ता है।
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // PPTX फ़ाइल को डिस्क पर लिखता है
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **आकृति पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

निम्नलिखित उदाहरण दर्शाते हैं कि कैसे [ISequence] इंटरफ़ेस की `GetEffectsByShape` मेथड का उपयोग करके किसी आकृति पर लागू सभी एनीमेशन इफ़ेक्ट्स प्राप्त किए जाएँ।

**उदाहरण 1: सामान्य स्लाइड पर आकृति पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

पहले आप सीख चुके थे कि कैसे PowerPoint प्रस्तुतियों में आकृतियों पर एनीमेशन इफ़ेक्ट्स जोड़ें। निम्नलिखित नमूना कोड दिखाता है कि कैसे प्रस्तुतीकरण `AnimExample_out.pptx` की पहली सामान्य स्लाइड में पहली आकृति पर लागू इफ़ेक्ट्स प्राप्त किए जाएँ।

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**उदाहरण 2: सभी एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स शामिल हैं**

यदि किसी सामान्य स्लाइड की आकृति में ऐसे प्लेसहोल्डर हैं जो लेआउट स्लाइड या मास्टर स्लाइड पर हैं, और इन प्लेसहोल्डरों पर एनीमेशन इफ़ेक्ट्स जोड़े गए हैं, तो स्लाइड शो के दौरान आकृति के सभी इफ़ेक्ट्स, जिसमें प्लेसहोल्डरों से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं, चलेंगे।

मान लीजिए हमारे पास `sample.pptx` नामक PowerPoint प्रस्तुतीकरण फ़ाइल है जिसमें केवल एक फुटर आकृति है जिसका टेक्स्ट "Made with Aspose.Slides" है और आकृति पर **Random Bars** इफ़ेक्ट लागू है।

![स्लाइड आकार एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

इसके अलावा मान लीजिए कि लेआउट स्लाइड पर फुटर प्लेसहोल्डर पर **Split** इफ़ेक्ट लागू है।

![लेआउट आकार एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

और अंत में मास्टर स्लाइड पर फुटर प्लेसहोल्डर पर **Fly In** इफ़ेक्ट लागू है।

![मास्टर आकार एनीमेशन इफ़ेक्ट](master-shape-animation.png)

निम्नलिखित नमूना कोड दर्शाता है कि कैसे [IShape] इंटरफ़ेस की `GetBasePlaceholder` मेथड का उपयोग करके आकृति प्लेसहोल्डर तक पहुंचें और फुटर आकृति पर लागू एनीमेशन इफ़ेक्ट्स, जिसमें लेआउट और मास्टर स्लाइड पर स्थित प्लेसहोल्डरों से विरासत में मिले इफ़ेक्ट्स शामिल हैं, प्राप्त करें।

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// सामान्य स्लाइड पर आकार के एनीमेशन इफ़ेक्ट प्राप्त करें।
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// लेआउट स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट प्राप्त करें।
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// मास्टर स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट प्राप्त करें।
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // फ़्लाइ, नीचे
Type: 134, subtype: 45            // स्प्लिट, वर्टिकलइन
Type: 126, subtype: 22            // रैंडमबार्स, क्षैतिज
```

## **एनीमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for C++ आपको एनीमेशन इफ़ेक्ट की टाइमिंग प्रॉपर्टीज़ बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पैन है:

![example1_image](shape-animation.png)

PowerPoint Timing और [Effect.Timing] प्रॉपर्टीज़ के बीच यह मिलान है:

- PowerPoint Timing **Start** ड्रॉप‑डाउन सूची [Effect.Timing.TriggerType] प्रॉपर्टी से मेल खाती है। 
- PowerPoint Timing **Duration** [Effect.Timing.Duration] प्रॉपर्टी से मेल खाती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जो एनीमेशन को एक चक्र पूरा करने में लेता है। 
- PowerPoint Timing **Delay** [Effect.Timing.TriggerDelayTime] प्रॉपर्टी से मेल खाती है। 

यह है कि आप Effect Timing प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें। 
2. आवश्यक [Effect.Timing] प्रॉपर्टीज़ के नए मान सेट करें। 
3. संशोधित PPTX फ़ाइल सहेजें। 

यह C++ कोड यह कार्य दर्शाता है:

```c++
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है।
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// इफ़ेक्ट के TriggerType को क्लिक पर शुरू करने के लिए बदलता है
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// इफ़ेक्ट की अवधि बदलता है
effect->get_Timing()->set_Duration(3.f);

// इफ़ेक्ट के TriggerDelayTime को बदलता है
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **एनीमेशन इफ़ेक्ट साउंड**

Aspose.Slides एनीमेशन इफ़ेक्ट्स में साउंड के साथ काम करने के लिए निम्नलिखित प्रॉपर्टीज़ प्रदान करता है: 

- [set_Sound()] 
- [set_StopPreviousSound()] 

### **एनीमेशन इफ़ेक्ट साउंड जोड़ें**

यह C++ कोड दर्शाता है कि कैसे एनीमेशन इफ़ेक्ट साउंड जोड़ें और अगला इफ़ेक्ट शुरू होने पर उसे बंद करें:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// इफ़ेक्ट के लिए "No Sound" जांचता है
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // पहले इफ़ेक्ट के लिए ध्वनि जोड़ता है
    firstEffect->set_Sound(effectSound);
}

// स्लाइड का पहला इंटरैक्टिव अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// इफ़ेक्ट "Stop previous sound" फ़्लैग सेट करता है
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **एनीमेशन इफ़ेक्ट साउंड निकालें**

1. एक नया [Presentation] क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. इफ़ेक्ट्स की मुख्य अनुक्रम प्राप्त करें। 
4. प्रत्येक एनीमेशन इफ़ेक्ट में एम्बेडेड [set_Sound()] को निकालें। 

यह C++ कोड दर्शाता है कि कैसे एनीमेशन इफ़ेक्ट में एम्बेडेड साउंड निकाला जाये:

```c++
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **एनीमेशन के बाद**

Aspose.Slides for C++ आपको एनीमेशन इफ़ेक्ट की After animation प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन इफ़ेक्ट पैन और विस्तारित मेनू है:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप‑डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है: 

- [set_AfterAnimationType()] प्रॉपर्टी जो After animation प्रकार को वर्णित करती है :
  * PowerPoint **More Colors** [AfterAnimationType.Color] प्रकार से मेल खाती है;
  * PowerPoint **Don't Dim** सूची आइटम [AfterAnimationType.DoNotDim] प्रकार से मेल खाती है (डिफ़ॉल्ट after animation प्रकार);
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType.HideAfterAnimation] प्रकार से मेल खाती है;
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType.HideOnNextMouseClick] प्रकार से मेल खाती है;
- [set_AfterAnimationColor()] प्रॉपर्टी जो after animation रंग स्वरूप को परिभाषित करती है। यह प्रॉपर्टी [AfterAnimationType.Color] प्रकार के साथ मिलकर कार्य करती है। यदि आप प्रकार बदलते हैं, तो after animation रंग साफ़ हो जाएगा।

यह C++ कोड दर्शाता है कि कैसे after animation इफ़ेक्ट बदलें:

```c++
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// after animation प्रकार को Color में बदलता है
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// after animation डिम रंग सेट करता है
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **टेक्स्ट को एनीमेट करें**

Aspose.Slides एनीमेट टेक्स्ट ब्लॉक के साथ काम करने के लिए निम्नलिखित प्रॉपर्टीज़ प्रदान करता है:

- [set_AnimateTextType()] जो इफ़ेक्ट के एनीमेट टेक्स्ट प्रकार को वर्णित करता है। आकृति का टेक्स्ट एनीमेट किया जा सकता है:
  - All at once ([AnimateTextType.AllAtOnce] प्रकार)
  - By word ([AnimateTextType.ByWord] प्रकार)
  - By letter ([AnimateTextType.ByLetter] प्रकार)
- [set_DelayBetweenTextParts()] जो एनीमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच देरी सेट करता है। सकारात्मक मान प्रभाव अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में देरी दर्शाता है।

यह है कि आप Effect Animate text प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें। 
2. [set_BuildType()] प्रॉपर्टी को [BuildType.AsOneObject] मान पर सेट करें ताकि *By Paragraphs* एनीमेशन मोड बंद हो जाये। 
3. आवश्यक अनुसार [set_AnimateTextType()] और [set_DelayBetweenTextParts()] प्रॉपर्टीज़ के नए मान सेट करें। 
4. संशोधित PPTX फ़ाइल सहेजें। 

यह C++ कोड यह कार्य प्रदर्शित करता है:

```c++
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// इफ़ेक्ट के Text animation type को "As One Object" में बदलता है
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// इफ़ेक्ट के Animate text type को "By word" में बदलता है
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// शब्दों के बीच देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं वेब पर प्रस्तुति प्रकाशित करते समय एनीमेशन को कैसे संरक्षित रखूँ?**

[HTML5 में निर्यात](/slides/hi/cpp/export-to-html5/) करें और उन [विकल्पों]https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/ को सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animateshapes/) और [transition](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animatetransitions/) एनीमेशन के लिए ज़िम्मेदार हैं। साधारण HTML स्लाइड एनीमेशन नहीं चलाता, जबकि HTML5 करता है।

**आकृतियों के z‑order (लेयर क्रम) को बदलने से एनीमेशन पर क्या प्रभाव पड़ता है?**

एनीमेशन और ड्राइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट प्रकट/गायब होने का समय और प्रकार नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/get_zorderposition/) तय करता है कि क्या क्या ढकता है। दृश्य परिणाम उनके संयोजन से निर्धारित होता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides प्रभाव‑और‑आकृति मॉडल भी यही तर्क अपनाता है।)

**क्या कुछ विशेष इफ़ेक्ट्स के लिए एनीमेशन को वीडियो में बदलते समय सीमाएँ हैं?**

सामान्यतः, [एनीमेशन समर्थित](/slides/hi/cpp/convert-powerpoint-to-video/) हैं, लेकिन दुर्लभ मामलों या विशेष प्रभावों में अलग रेंडरिंग हो सकती है। उपयोग किए गए प्रभावों और लाइब्रेरी संस्करण के साथ परीक्षण करने की सलाह दी जाती है।