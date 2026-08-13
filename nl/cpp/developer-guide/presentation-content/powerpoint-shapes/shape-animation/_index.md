---
title: Vormanimaties toepassen in presentaties met C++
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/cpp/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe je vormanimaties kunt maken en aanpassen in PowerPoint presentaties met Aspose.Slides voor C++. Val op!"
---
## **Inleiding**

Animaties zijn visuele effecten die kunnen worden toegepast op tekst, afbeeldingen, vormen of [grafieken](/slides/nl/cpp/animated-charts/). Ze geven leven aan presentaties of hun onderdelen. 

## **Waarom animaties gebruiken in presentaties?**

Met animaties kun je  

* de stroom van informatie beheersen  
* belangrijke punten benadrukken  
* de interesse of deelname van je publiek vergroten  
* inhoud makkelijker leesbaar, verteerbaar of verwerkbaar maken  
* de aandacht van je lezers of kijkers vestigen op belangrijke delen in een presentatie  

PowerPoint biedt veel opties en hulpmiddelen voor animaties en animatie‑effecten binnen de categorieën **entrance**, **exit**, **emphasis** en **motion paths**. 

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en types die je nodig hebt om met animaties te werken in de namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation)  
* Aspose.Slides biedt meer dan **150 animatie‑effecten** in de enumeratie [EffectType](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Deze effecten zijn in wezen dezelfde (of equivalente) effecten die in PowerPoint worden gebruikt.  

## **Animatie toepassen op een tekstvak**

Aspose.Slides voor C++ stelt je in staat om animatie toe te passen op de tekst in een vorm. 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) aan.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) toe.  
4. Voeg tekst toe aan [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).  
5. Haal de hoofd‑reeks van effecten op.  
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape).  
7. Stel de eigenschap [TextAnimation.BuildType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) in op de waarde uit de [BuildType‑enumeratie](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze C++‑code laat zien hoe je het `Fade`‑effect op een AutoShape toepast en de tekstanimatie instelt op de *By 1st Level Paragraphs*‑waarde:

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

// Instantieert een presentatieklasse die een presentatiebestand voorstelt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voegt een nieuwe AutoShape met tekst toe
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Voegt het Fade‑animatie‑effect toe aan de vorm
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animeert de vormtekst per alinea van het eerste niveau
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Sla het PPTX‑bestand op schijf
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}}  

Naast het toepassen van animaties op tekst, kun je ook animaties toepassen op een enkele [Paragraph](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_paragraph). Zie **Animated Text**.  

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) aan.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_picture_frame) toe aan de dia of haal er een op.  
4. Haal de hoofd‑reeks van effecten op.  
5. Voeg een animatie‑effect toe aan de [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_picture_frame).  
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze C++‑code laat zien hoe je het `Fly`‑effect op een picture frame toepast:

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

// Instantieert een presentatieklasse die een presentatiebestand voorstelt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Laad afbeelding die moet worden toegevoegd aan de afbeeldingscollectie van de presentatie
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Voegt een picture frame toe aan de dia
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Voegt het Fly‑van‑links‑animatie‑effect toe aan het picture frame
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Sla het PPTX‑bestand op schijf
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animatie toepassen op een vorm**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) aan.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) toe.  
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).  
5. Maak een reeks effecten aan op de bevel‑vorm.  
6. Maak een aangepaste `UserPath`.  
7. Voeg commando's toe om naar de `UserPath` te bewegen.  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze C++‑code laat zien hoe je het `PathFootball` (pad football)‑effect op een vorm toepast:

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

	// Het pad naar de documentmap.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laadt de presentatie
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Benadert de eerste dia
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Benadert de vormcollectie voor de geselecteerde dia
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Maakt PathFootball‑effect voor bestaande vorm vanaf nul.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Voegt het PathFootBall‑animatie‑effect toe
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Creëer een soort "button".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Maakt een reeks effecten voor deze knop.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Maakt een aangepaste gebruikerspad. Ons object wordt alleen verplaatst nadat de knop is aangeklikt.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Voegt opdrachten toe om te verplaatsen aangezien het gemaakte pad leeg is.
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
	 
	 // Schrijft het PPTX‑bestand naar schijf
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animatie‑effecten ophalen die op een vorm zijn toegepast**

De volgende voorbeelden laten zien hoe je de methode `GetEffectsByShape` van de interface [ISequence](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/) gebruikt om alle animatie‑effecten op te halen die op een vorm zijn toegepast.  

**Voorbeeld 1: Animatie‑effecten ophalen die op een vorm op een normale dia zijn toegepast**

Eerder heb je geleerd hoe je animatie‑effecten aan vormen in PowerPoint‑presentaties kunt toevoegen. De volgende voorbeeldcode laat zien hoe je de effecten opvraagt die op de eerste vorm op de eerste normale dia in de presentatie `AnimExample_out.pptx` zijn toegepast.

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

// Haalt de hoofd‑animatiereeks van de dia op.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Haalt de eerste vorm op van de eerste dia.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Haalt de animatie‑effecten op die op de vorm zijn toegepast.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief die geërfd zijn van tijdelijke aanduidingen**

Als een vorm op een normale dia tijdelijke aanduidingen heeft die zich op de layout‑dia en/of master‑dia bevinden, en er animatie‑effecten zijn toegevoegd aan deze tijdelijke aanduidingen, dan worden alle effecten van de vorm afgespeeld tijdens de diavoorstelling, inclusief diegenen die van de tijdelijke aanduidingen zijn geërfd.  

Stel dat we een PowerPoint‑presentatiebestand `sample.pptx` hebben met één dia die alleen een voettekst‑vorm bevat met de tekst "Made with Aspose.Slides" en waarop het **Random Bars**‑effect is toegepast.

![Dia‑vormanimatie‑effect](slide-shape-animation.png)

Laten we ook aannemen dat het **Split**‑effect is toegepast op de voettekst‑placeholder op de **layout**‑dia.

![Layout‑vormanimatie‑effect](layout-shape-animation.png)

En tenslotte is het **Fly In**‑effect toegepast op de voettekst‑placeholder op de **master**‑dia.

![Master‑vormanimatie‑effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe je de methode `GetBasePlaceholder` van de interface [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) gebruikt om toegang te krijgen tot de vorm‑placeholders en de animatie‑effecten op te halen die op de voettekst‑vorm zijn toegepast, inclusief diegenen die geërfd zijn van placeholders op de layout‑ en master‑dia's.

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

// Haal de animatie‑effecten op van de vorm op de normale dia.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Haal de animatie‑effecten op van de tijdelijke aanduiding op de layout‑dia.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Haal de animatie‑effecten op van de tijdelijke aanduiding op de master‑dia.
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
Type: 47, subtype: 2              // Vliegen, Onder
Type: 134, subtype: 45            // Split, VerticaalIn
Type: 126, subtype: 22            // RandomBars, Horizontaal
```

## **Timing‑eigenschappen van animatie‑effecten wijzigen**

Aspose.Slides voor C++ stelt je in staat om de Timing‑eigenschappen van een animatie‑effect te wijzigen.  

Dit is het paneel Animatie‑Timing in Microsoft PowerPoint:

![Paneel Animatie‑Timing](shape-animation.png)

- De vervolgkeuzelijst **Start** van PowerPoint Timing komt overeen met de eigenschap [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).  
- PowerPoint Timing **Duration** komt overeen met de eigenschap [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). De duur van een animatie (in seconden) is de totale tijd die nodig is om één cyclus van de animatie te voltooien.  
- PowerPoint Timing **Delay** komt overeen met de eigenschap [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).  

Zo wijzig je de Timing‑eigenschappen van het effect:

1. Pas toe (zie #apply-animation-to-shape) of haal het animatie‑effect op.  
2. Stel nieuwe waarden in voor de [Effect.Timing](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c)‑eigenschappen die je nodig hebt.  
3. Sla het aangepaste PPTX‑bestand op.  

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

// Instantieert een presentatieklasse die een presentatiebestand voorstelt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Haalt het eerste effect van de hoofdreeks op.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Wijzigt effect TriggerType zodat het start bij klik
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Wijzigt effect Duur
effect->get_Timing()->set_Duration(3.f);

// Wijzigt effect TriggerDelayTime
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Slaat het PPTX‑bestand op schijf
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Geluid voor animatie‑effect**

Aspose.Slides biedt deze eigenschappen om met geluiden in animatie‑effecten te kunnen werken:  

- [set_Sound()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effect/set_stopprevioussound/)  

### **Een geluid aan een animatie‑effect toevoegen**

Deze C++‑code laat zien hoe je een geluid aan een animatie‑effect toevoegt en het stopt wanneer het volgende effect start:

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

// Voegt audio toe aan de audio-collectie van de presentatie
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Haal de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Haal het eerste effect van de hoofdreeks op
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Controleert het effect op "Geen geluid"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Voegt geluid toe aan het eerste effect
    firstEffect->set_Sound(effectSound);
}

// Haal de eerste interactieve reeks van de dia op.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Stelt de vlag "Stop vorig geluid" van het effect in
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Schrijft het PPTX-bestand naar schijf
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Geluid uit een animatie‑effect extraheren**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) aan.  
2. Haal een referentie naar een dia op via de index.  
3. Haal de hoofd‑reeks van effecten op.  
4. Extraheer de ingebedde [set_Sound()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effect/set_sound/) van elk animatie‑effect.  

Deze C++‑code laat zien hoe je het geluid dat in een animatie‑effect is ingebed, kunt extraheren:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instantieert een presentatieklasse die een presentatiebestand voorstelt.
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

## **Na animatie**

Aspose.Slides voor C++ stelt je in staat om de After‑animation‑eigenschap van een animatie‑effect te wijzigen.  

Dit is het paneel Animatie‑Effect in Microsoft PowerPoint:

![Paneel Animatie‑Effect](shape-after-animation.png)

De vervolgkeuzelijst **After animation** van PowerPoint Effect komt overeen met de volgende eigenschappen:  

- Eigenschap [set_AfterAnimationType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) die het type After animation beschrijft:  
  * PowerPoint **More Colors** komt overeen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/).  
  * PowerPoint **Don't Dim** komt overeen met het type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/) (standaard after animation‑type).  
  * PowerPoint **Hide After Animation** komt overeen met het type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/).  
  * PowerPoint **Hide on Next Mouse Click** komt overeen met het type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/).  
- Eigenschap [set_AfterAnimationColor()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) die een after‑animation‑kleurformaat definieert. Deze eigenschap werkt samen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/). Als je het type wijzigt, wordt de after‑animation‑kleur gewist.  

Deze C++‑code laat zien hoe je een after‑animation‑effect wijzigt:

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

// Instantieert een presentatieklasse die een presentatiebestand voorstelt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Haalt het eerste effect van de hoofdreeks op
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Wijzigt het type after‑animation naar Kleur
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Stelt de dimkleur van after‑animation in
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Schrijft het PPTX‑bestand naar schijf
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Tekst animeren**

Aspose.Slides biedt deze eigenschappen om met het *Animate text*‑blok van een animatie‑effect te kunnen werken:  

- [set_AnimateTextType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) die het type van de te animeren tekst van het effect beschrijft. De vormtekst kan worden geanimeerd:  
  * Alles tegelijk ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/animatetexttype/) type)  
  * Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/animatetexttype/) type)  
  * Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/animatetexttype/) type)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) stelt een vertraging in tussen de geanimeerde tekstonderdelen (woorden of letters). Een positieve waarde geeft het percentage van de effectduur aan. Een negatieve waarde geeft de vertraging in seconden aan.  

Zo kun je de Eigenschappen van Effect Animate text wijzigen:

1. Pas toe (zie #apply-animation-to-shape) of haal het animatie‑effect op.  
2. Stel de eigenschap [set_BuildType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itextanimation/set_buildtype/) in op de waarde [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/buildtype/) om de *By Paragraphs*‑animatiemodus uit te schakelen.  
3. Stel nieuwe waarden in voor de eigenschappen [set_AnimateTextType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) en [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).  
4. Sla het aangepaste PPTX‑bestand op.  

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

// Instantieert een presentatieklasse die een presentatiebestand voorstelt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Haalt het eerste effect van de hoofdreeks op
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Wijzigt het tekstanimatietype van het effect naar "Als één object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Wijzigt het type Animate text van het effect naar "Per woord"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Stelt de vertraging tussen woorden in op 20% van de effectduur
firstEffect->set_DelayBetweenTextParts(20.0f);

// Schrijft het PPTX-bestand naar schijf
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Hoe kan ik ervoor zorgen dat animaties behouden blijven bij het publiceren van de presentatie op het web?

[Export to HTML5](/slides/nl/cpp/export-to-html5/) en schakel de [options](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/) in die verantwoordelijk zijn voor animaties van [shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animateshapes/) en [transition](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animatetransitions/) . Gewone HTML speelt dia‑animaties niet af, terwijl HTML5 dat wel doet.  

### Hoe beïnvloedt het wijzigen van de z‑order (lagenvolgorde) van vormen de animatie?

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt de timing en het type van verschijnen/verdwijnen, terwijl [z-order](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/get_zorderposition/) bepaalt wat wat bedekt. Het zichtbare resultaat wordt bepaald door hun combinatie. (Dit is het algemene gedrag in PowerPoint; het Aspose.Slides‑model voor effecten en vormen volgt dezelfde logica.)  

### Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?

In het algemeen worden [animaties ondersteund](/slides/nl/cpp/convert-powerpoint-to-video/), maar in zeldzame gevallen of bij specifieke effecten kunnen ze anders worden gerenderd. Het wordt aanbevolen om te testen met de door jou gebruikte effecten en met de bibliotheekversie.