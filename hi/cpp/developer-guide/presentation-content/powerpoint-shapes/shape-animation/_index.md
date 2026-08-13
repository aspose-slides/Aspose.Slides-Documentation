---
title: C++ का उपयोग करके प्रस्तुतियों में शैप एनीमेशन लागू करना
linktitle: शैप एनीमेशन
type: docs
weight: 60
url: /hi/cpp/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनिमेटेड आकार
- एनिमेटेड पाठ
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनीमेशन लागू करें
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में शैप एनीमेशन बनाने और अनुकूलित करने का तरीका जानें। भीड़ से अलग दिखें!"
---
## **परिचय**

Animations are visual effects that can be applied to texts, images, shapes, or [चार्ट](/slides/hi/cpp/animated-charts/). They give life to presentations or its constituents.

## **प्रस्तुतियों में एनीमेशन क्यों उपयोग करें?**

Using animations, you can 

* सूचनाओं के प्रवाह को नियंत्रित करें
* महत्वपूर्ण बिंदुओं को उजागर करें
* अपने दर्शकों की रुचि या भागीदारी बढ़ाएँ
* सामग्री को पढ़ने, समझने या प्रक्रिया करने में आसान बनाएं
* प्रस्तुति में महत्वपूर्ण हिस्सों पर पाठकों या दर्शकों का ध्यान आकर्षित करें

PowerPoint provides many options and tools for animations and animation effects across the **entrance**, **exit**, **emphasis**, and **motion paths** categories. 

## **Aspose.Slides में एनीमेशन**

* Aspose.Slides provides the classes and types you need to work with animations under the [Aspose.Slides.Animation](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation) namespace,
* Aspose.Slides provides over **150 animation effects** under the [EffectType](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeration. These effects are essentially the same (or equivalent) effects used in PowerPoint.

## **टेक्स्टबॉक्स पर एनीमेशन लागू करना**

Aspose.Slides for C++ allows you to apply animation to the text in a shape. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) class.
2. Get a slide's reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape). 
4. Add text to [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Get a main sequence of effects.
6. Add an animation effect to [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape). 
7. Set the [TextAnimation.BuildType](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) property to the value from [BuildType Enumeration](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Write the presentation to disk as a PPTX file.

This C++ code shows you how to apply the `Fade` effect to AutoShape and set the text animation to the *By 1st Level Paragraphs* value:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// टेक्स्ट के साथ नया ऑटोशेप जोड़ता है
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// शेप पर Fade एनीमेशन इफ़ेक्ट जोड़ता है
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// शेप के टेक्स्ट को पहले स्तर के पैराग्राफ़ द्वारा एनीमेट करता है
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Besides applying animations to text, you can also apply animations to a single [Paragraph](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_paragraph). See [**Animated Text**](/slides/hi/cpp/animated-text/).

{{% /alert %}} 

## **पिक्चरफ़्रेम पर एनीमेशन लागू करना**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) class.
2. Get a slide's reference through its index.
3. Add or get a [PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_picture_frame) on the slide. 
4. Get the main sequence of effects.
5. Add an animation effect to the [PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_picture_frame).
6. Write the presentation to disk as a PPTX file.

This C++ code shows you how to apply the `Fly` effect to a picture frame:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// प्रस्तुति की इमेज संग्रह में जोड़ने के लिए इमेज लोड करता है
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// स्लाइड में पिक्चर फ्रेम जोड़ता है
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// पिक्चर फ्रेम पर बाएँ से फ़्लाई एनीमेशन इफ़ेक्ट जोड़ता है
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **शेप पर एनीमेशन लागू करना**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) class.
2. Get a slide's reference through its index.
3. Add a `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape). 
4. Add a `Bevel` [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape) (when this object is clicked, the animation gets played).
5. Create a sequence of effects on the bevel shape.
6. Create a custom `UserPath`.
7. Add commands for moving to the `UserPath`.
8. Write the presentation to disk as a PPTX file.

This C++ code shows you how to apply the `PathFootball` (path football) effect to a shape:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// दस्तावेज़ निर्देशिका का पथ।
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// प्रस्तुति लोड करता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// पहली स्लाइड तक पहुँचता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// चयनित स्लाइड के लिए शैप्स संग्रह तक पहुँचता है
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// मौजूदा शैप के लिए स्क्रैच से PathFootball इफ़ेक्ट बनाता है।
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// किसी प्रकार का "बटन" बनाता है।
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// इस बटन के लिए इफ़ेक्ट्स की अनुक्रम बनाता है।
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // कस्टम उपयोगकर्ता पथ बनाता है। हमारा वस्तु केवल बटन क्लिक करने के बाद ही हिलेगा।
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// हिलने के लिए कमांड जोड़ता है क्योंकि बनाया गया पथ खाली है।
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
	 
	 // PPTX फ़ाइल को डिस्क पर सहेजता है
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **शेप पर लागू किए गए एनीमेशन इफ़ेक्ट्स प्राप्त करना**

The following examples show you how to use the `GetEffectsByShape` method from the [ISequence](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/) interface to get all animation effects applied to a shape.

**Example 1: Get animation effects applied to a shape on a normal slide**

Previously, you learned how to add animation effects to shapes in PowerPoint presentations. The following sample code shows you how to get the effects applied to the first shape on the first normal slide in the presentation `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

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

**Example 2: Get all animation effects, including those inherited from placeholders**

If a shape on a normal slide has placeholders that are on the layout slide and/or master slide, and animation effects have been added to these placeholders, then all effects of the shape will be played during the slide show, including those inherited from the placeholders.

Let's say we have a PowerPoint presentation file `sample.pptx` with one slide containg only a footer shape with the text "Made with Aspose.Slides" and the **Random Bars** effect is applied to the shape.

![Slide shape animation effect](slide-shape-animation.png)

Let's also assume that the **Split** effect is applied to the footer placeholder on the **layout** slide.

![Layout shape animation effect](layout-shape-animation.png)

And finally, the **Fly In** effect is applied to the footer placeholder on the **master** slide.

![Master shape animation effect](master-shape-animation.png)

The following sample code shows you how to use the `GetBasePlaceholder` method from the [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) interface to access the shape placeholders and get the animation effects applied to the footer shape, including those inherited from placeholders located on the layout and master slides.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// सामान्य स्लाइड पर शैप के एनीमेशन इफ़ेक्ट्स प्राप्त करें.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// लेआउट स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// मास्टर स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें.
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
Type: 47, subtype: 2              // फ़्लाई, नीचे
Type: 134, subtype: 45            // स्प्लिट, ऊर्ध्वाधर में
Type: 126, subtype: 22            // रैंडमबार्स, क्षैतिज
```

## **एनीमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for C++ allows you to change the Timing properties of an animation effect.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) properties:

- PowerPoint Timing **Start** ड्रॉप-डाउण सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) प्रॉपर्टी से मेल खाती है। 
- PowerPoint Timing **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) प्रॉपर्टी से मेल खाती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जो एनीमेशन को एक चक्र पूरा करने में लगता है। 
- PowerPoint Timing **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) प्रॉपर्टी से मेल खाती है। 

This is how you change the Effect Timing properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set new values for the [Effect.Timing](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) properties you need. 
3. Save the modified PPTX file.

This C++ code demonstrates the operation:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है।
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// इफ़ेक्ट का TriggerType क्लिक पर शुरू करने के लिए बदलता है
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// इफ़ेक्ट की अवधि बदलता है
effect->get_Timing()->set_Duration(3.f);

// इफ़ेक्ट का TriggerDelayTime बदलता है
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **एनीमेशन इफ़ेक्ट साउंड**

Aspose.Slides provides these properties to allow you to work with sounds in animation effects: 

- [set_Sound()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **एनीमेशन इफ़ेक्ट साउंड जोड़ें**

This C++ code shows you how to add an animation effect sound and stop it when the next effect starts:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// स्लाइड की मुख्य अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// इफ़ेक्ट में "No Sound" की जाँच करता है
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // पहले इफ़ेक्ट के लिए ध्वनि जोड़ता है
    firstEffect->set_Sound(effectSound);
}

// स्लाइड की पहली इंटरैक्टिव अनुक्रम प्राप्त करता है।
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// इफ़ेक्ट "Stop previous sound" फ़्लैग सेट करता है
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **एनीमेशन इफ़ेक्ट साउंड निकालें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class.
2. Get a slide’s reference through its index. 
3. Get the main sequence of effects. 
4. Extract the [set_Sound()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/effect/set_sound/) embedded to each animation effect. 

This C++ code shows you how to extract the sound embedded in an animation effect:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
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

Aspose.Slides for C++ allows you to change the After animation property of an animation effect.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप-डाउण सूची इन प्रॉपर्टीज़ से मेल खाती है: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) प्रॉपर्टी जो After animation टाइप का वर्णन करती है :
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) टाइप से मेल खाती है;
  * PowerPoint **Don't Dim** सूची आइटम [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) टाइप से मेल खाती है (डिफ़ॉल्ट After animation टाइप);
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) टाइप से मेल खाती है;
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) टाइप से मेल खाती है;
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) प्रॉपर्टी जो After animation कलर फ़ॉर्मेट को परिभाषित करती है। यह प्रॉपर्टी [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) टाइप के साथ मिलकर काम करती है। यदि आप टाइप को बदलेंगे, तो After animation कलर साफ़ हो जाएगा।

This C++ code shows you how to change an after animation effect:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// After animation प्रकार को Color में बदलता है
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// After animation डिम रंग सेट करता है
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **टेक्स्ट एनीमेट करें**

Aspose.Slides provides these properties to allow you to work with an animation effect's *Animate text* block:

- [set_AnimateTextType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) जो एनीमेशन इफ़ेक्ट के टेक्स्ट एनीमेट टाइप का वर्णन करती है। शैप टेक्स्ट को एनीमेट किया जा सकता है:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/animatetexttype/) टाइप)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/animatetexttype/) टाइप)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/animatetexttype/) टाइप)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) एनीमेटेड टेक्स्ट पार्ट्स (शब्द या अक्षर) के बीच देरी सेट करती है। सकारात्मक मान प्रभाव की अवधि का प्रतिशत दर्शाता है। नकारात्मक मान देरी को सेकंड में दर्शाता है।

This is how you can change the Effect Animate text properties:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set the [set_BuildType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation.itextanimation/set_buildtype/) property to [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/buildtype/) value to turn off the *By Paragraphs* animation mode.
3. Set new values for the [set_AnimateTextType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) and [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) properties.
4. Save the modified PPTX file.

This C++ code demonstrates the operation:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// मुख्य अनुक्रम का पहला इफ़ेक्ट प्राप्त करता है
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// इफ़ेक्ट के टेक्स्ट एनीमेशन प्रकार को "As One Object" में बदलता है
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// इफ़ेक्ट के एनीमेट टेक्स्ट प्रकार को "By word" में बदलता है
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// शब्दों के बीच देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### प्रस्तुति को वेब पर प्रकाशित करते समय एनीमेशन को कैसे सुरक्षित रखें?

[Export to HTML5](/slides/hi/cpp/export-to-html5/) and enable the [options](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/) responsible for [shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animateshapes/) and [transition](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animatetransitions/) animations. Plain HTML does not play slide animations, whereas HTML5 does.

### शेप की z-order (लेयर ऑर्डर) बदलने से एनीमेशन पर क्या असर पड़ता है?

Animation and drawing order are independent: an effect controls the timing and type of appearing/disappearing, while [z-order](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/get_zorderposition/) determines what covers what. The visible result is defined by their combination. (This is the general PowerPoint behavior; the Aspose.Slides effects-and-shapes model follows the same logic.)

### कुछ इफ़ेक्ट्स के लिए एनीमेशन को वीडियो में बदलते समय सीमाएँ हैं क्या?

In general, [animations are supported](/slides/hi/cpp/convert-powerpoint-to-video/), but rare cases or specific effects may be rendered differently. It is recommended to test with the effects you use and with the library version.