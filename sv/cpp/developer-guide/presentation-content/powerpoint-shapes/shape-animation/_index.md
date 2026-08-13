---
title: Applicera formanimationer i presentationer med C++
linktitle: Formanimation
type: docs
weight: 60
url: /sv/cpp/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint-presentationer med Aspose.Slides för C++. Stick ut!"
---
## **Introduktion**

Animationer är visuella effekter som kan appliceras på texter, bilder, former eller [charts](/slides/sv/cpp/animated-charts/). De ger liv åt presentationer eller deras beståndsdelar. 

## **Varför använda animationer i presentationer?**

* styra informationsflödet
* betona viktiga punkter
* öka intresse eller engagemang bland din publik
* göra innehållet lättare att läsa, assimilera eller bearbeta
* rikta läsarens eller tittarens uppmärksamhet mot viktiga delar i en presentation

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **entrance**, **exit**, **emphasis**, och **motion paths**. 

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller klasserna och typerna du behöver för att arbeta med animationer under namnutrymmet [Aspose.Slides.Animation](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation).
* Aspose.Slides tillhandahåller över **150 animationseffekter** under uppräkningen [EffectType](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Dessa effekter är i princip samma (eller motsvarande) effekter som används i PowerPoint.

## **Applicera animation på en TextBox**

Aspose.Slides för C++ låter dig applicera animation på texten i en form. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/).
2. Hämta en referens till en bild via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape). 
4. Lägg till text till [IAutoShape.TextFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Hämta huvudsekvensen av effekter.
6. Lägg till en animationseffekt till [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape). 
7. Ställ in egenskapen [TextAnimation.BuildType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) till värdet från [BuildType Enumeration](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Skriv presentationen till disk som en PPTX-fil.

Denna C++-kod visar hur du applicerar `Fade`-effekten på AutoShape och ställer in textanimationen till värdet *By 1st Level Paragraphs*:

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

// Skapar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Lägger till en ny AutoShape med text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Hämtar huvudsekvensen för bilden.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Lägger till Fade‑animationseffekt på formen
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animera formens text efter första nivåns stycken
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Spara PPTX‑filen till disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 
Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_paragraph). Se [**Animated Text**](/slides/sv/cpp/animated-text/).
{{% /alert %}} 

## **Applicera animation på en PictureFrame**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/) klassen.
2. Hämta en referens till en bild via dess index.
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_picture_frame) på bilden. 
4. Hämta huvudsekvensen av effekter.
5. Lägg till en animationseffekt till [PictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_picture_frame).
6. Skriv presentationen till disk som en PPTX-fil.

Denna C++-kod visar hur du applicerar `Fly`-effekten på en picture frame:

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

// Skapar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Ladda bild som ska läggas till i presentationens bildsamling
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Lägger till bildram på bilden
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Hämtar huvudsekvensen för bilden.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Lägger till Fly‑animationseffekt från vänster på bildramen
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Spara PPTX‑filen till disk
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Applicera animation på en Shape**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/) klassen.
2. Hämta en referens till en bild via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape). 
4. Lägg till en `Bevel` [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape) (när detta objekt klickas spelas animationen upp).
5. Skapa en sekvens av effekter på bevelformen.
6. Skapa en anpassad `UserPath`.
7. Lägg till kommandon för att flytta till `UserPath`.
8. Skriv presentationen till disk som en PPTX-fil.

Denna C++-kod visar hur du applicerar `PathFootball` (path football)-effekten på en shape:

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

	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laddar presentationen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Öppnar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Hämtar formsamlingen för den valda bilden
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Skapar PathFootball‑effekt för befintlig form från början.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Lägger till PathFootBall‑animationseffekten
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Skapar någon form av "knapp".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Skapar en sekvens av effekter för den här knappen.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Skapar en anpassad användarstig. Vårt objekt kommer endast att flyttas efter att knappen har klickats.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Lägger till kommandon för förflyttning eftersom den skapade stigen är tom.
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
	 
	 // Skriver PPTX‑filen till disk
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hämta animationseffekterna som applicerats på en Shape**

Följande exempel visar hur du använder metoden `GetEffectsByShape` från gränssnittet [ISequence](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/) för att hämta alla animationseffekter som applicerats på en shape.

**Exempel 1: Hämta animationseffekter som applicerats på en shape på en normal bild**

Tidigare lärde du dig hur man lägger till animationseffekter på former i PowerPoint-presentationer. Följande exempel på kod visar hur du hämtar effekterna som applicerats på den första formen på den första normala bilden i presentationen `AnimExample_out.pptx`.

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

// Hämtar huvudanimationssekvensen för bilden.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Hämtar den första formen på den första bilden.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Hämtar animationseffekter som tillämpats på formen.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Exempel 2: Hämta alla animationseffekter, inklusive de som ärvs från platshållare**

Om en shape på en normal bild har platshållare som finns på layoutbilden och/eller mastern, och animationseffekter har lagts till dessa platshållare, kommer alla effekter för shape:n att spelas upp under bildspelet, inklusive de som ärvs från platshållarna.

Anta att vi har en PowerPoint-presentation `sample.pptx` med en bild som endast innehåller en fotshape med texten "Made with Aspose.Slides" och **Random Bars**-effekten är applicerad på shape:n.

![Slide shape animation effect](slide-shape-animation.png)

Låt oss också anta att **Split**-effekten är applicerad på fotplatshållaren på **layout**-bilden.

![Layout shape animation effect](layout-shape-animation.png)

Och slutligen är **Fly In**-effekten applicerad på fotplatshållaren på **master**-bilden.

![Master shape animation effect](master-shape-animation.png)

Följande exempel på kod visar hur du använder metoden `GetBasePlaceholder` från gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) för att komma åt shape-platshållarna och hämta animationseffekterna som applicerats på fotshapen, inklusive de som ärvs från platshållare som finns på layout- och mastern.

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

// Hämta animationseffekter för formen på den normala bilden.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Hämta animationseffekter för platshållaren på layoutbilden.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Hämta animationseffekter för platshållaren på mastern.
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
Type: 47, subtype: 2              // Flyg, Botten
Type: 134, subtype: 45            // Split, VertikalIn
Type: 126, subtype: 22            // RandomBars, Horisontell
```

## **Ändra tidsinställningarna för animationseffekter**

Aspose.Slides för C++ låter dig ändra tidsinställningarna för en animationseffekt.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

- PowerPoint Timing **Start**-rullgardinslistan motsvarar egenskapen [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).
- PowerPoint Timing **Duration** motsvarar egenskapen [Effect.Timing.Duration](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Varaktigheten för en animation (i sekunder) är den totala tid animationen tar för att slutföra en cykel. 
- PowerPoint Timing **Delay** motsvarar egenskapen [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Så här ändrar du egenskaperna för Effect Timing:

1. [Applicera](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in nya värden för de [Effect.Timing](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) egenskaper du behöver. 
3. Spara den modifierade PPTX-filen.

Denna C++-kod demonstrerar operationen:

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

// Instansierar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Hämtar huvudsekvensen för bilden.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Hämtar den första effekten i huvudsekvensen.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Ändrar effectens TriggerType till att starta vid klick
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Ändrar effectens varaktighet
effect->get_Timing()->set_Duration(3.f);

// Ändrar effectens TriggerDelayTime
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Sparar PPTX-filen till disk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ljud för animationseffekter**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med ljud i animationseffekter: 

- [set_Sound()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Lägg till ljud för en animationseffekt**

Denna C++-kod visar hur du lägger till ljud för en animationseffekt och stoppar det när nästa effekt startar:

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

// Lägger till ljud i presentationens ljudsamling
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Hämtar huvudsekvensen för bilden.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Hämtar den första effekten i huvudsekvensen
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Kontrollerar om effekten har "No Sound"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Lägger till ljud för den första effekten
    firstEffect->set_Sound(effectSound);
}

// Hämtar den första interaktiva sekvensen för bilden.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Ställer in flaggan "Stop previous sound" för effekten
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Skriver PPTX-filen till disk
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extrahera ljud för en animationseffekt**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en referens till en bild via dess index. 
3. Hämta huvudsekvensen av effekter. 
4. Extrahera den inbäddade [set_Sound()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effect/set_sound/) från varje animationseffekt. 

Denna C++-kod visar hur du extraherar det inbäddade ljudet i en animationseffekt:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instansierar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Hämtar huvudsekvensen för bilden.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Efter animation**

Aspose.Slides för C++ låter dig ändra egenskapen After animation för en animationseffekt.

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation**-rullgardinslistan motsvarar dessa egenskaper: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) egenskap som beskriver typen After animation:
  * PowerPoint **More Colors** motsvarar typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** motsvarar typen [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/) (standardtypen för after animation);
  * PowerPoint **Hide After Animation** motsvarar typen [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** motsvarar typen [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/);
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) egenskap som definierar ett färgformat för after animation. Denna egenskap fungerar i samband med typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/). Om du ändrar typen till en annan, kommer after animation-färgen att rensas.

Denna C++-kod visar hur du ändrar en after animation-effekt:

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

// Instansierar en presentationsklass som representerar en presentationsfil
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Hämtar den första effekten i huvudsekvensen
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändrar efteranimationstypen till Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Ställer in efteranimationens dimningsfärg
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Skriver PPTX-filen till disk
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animera text**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med en animationseffektens *Animate text*-block:

- [set_AnimateTextType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) som beskriver en animate text-typ för effekten. Formtexten kan animeras:
  - Alla på en gång ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/animatetexttype/) typ)
  - Efter ord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/animatetexttype/) typ)
  - Efter bokstav ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/animatetexttype/) typ)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) anger en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procent av effektens varaktighet. Ett negativt värde anger fördröjning i sekunder.

Så här kan du ändra egenskaperna för Effect Animate text:

1. [Applicera](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in egenskapen [set_BuildType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation.itextanimation/set_buildtype/) till värdet [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/buildtype/) för att stänga av *By Paragraphs*-animationsläget.
3. Ställ in nya värden för egenskaperna [set_AnimateTextType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) och [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Spara den modifierade PPTX-filen.

Denna C++-kod demonstrerar operationen:

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

// Instansierar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Hämtar den första effekten i huvudsekvensen
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändrar effektens Text animation-typ till "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Ändrar effektens Animate text-typ till "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Ställer in fördröjningen mellan ord till 20% av effektens varaktighet
firstEffect->set_DelayBetweenTextParts(20.0f);

// Skriver PPTX-filen till disk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Hur kan jag säkerställa att animationer bevaras vid publicering av presentationen på webben?

[Export to HTML5](/slides/sv/cpp/export-to-html5/) och aktivera de [options](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/) som ansvarar för animationer av [shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animateshapes/) och [transition](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animatetransitions/) . Ren HTML spelar inte upp bildanimationer, medan HTML5 gör det.

### Hur påverkar förändring av z-ordning (lagerordning) för former animationen?

Animation- och ritordning är oberoende: en effekt styr tidpunkt och typ för framträddning/försvinnande, medan [z-order](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/get_zorderposition/) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är det generella PowerPoint-beteendet; Aspose.Slides modell för effekter och former följer samma logik.)

### Finns det begränsningar när animationer konverteras till video för vissa effekter?

I allmänhet [animations are supported](/slides/sv/cpp/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den biblioteksversion du har.