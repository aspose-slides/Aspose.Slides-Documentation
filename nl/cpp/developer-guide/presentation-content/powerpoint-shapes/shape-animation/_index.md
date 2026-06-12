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
description: "Ontdek hoe u vormanimaties kunt maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor C++. Val op!"
---
## **Inleiding**

Animaties zijn visuele effecten die toegepast kunnen worden op tekst, afbeeldingen, vormen of [grafieken](/slides/nl/cpp/animated-charts/). Ze geven leven aan presentaties of hun onderdelen. 

## **Waarom animaties gebruiken in presentaties?**

Met animaties kun je 

* de informatiestroom beheersen
* belangrijke punten benadrukken
* interesse of deelname van je publiek vergroten
* de inhoud makkelijker leesbaar, begrijpelijk of verwerkbaar maken
* de aandacht van lezers of kijkers richten op belangrijke delen in een presentatie

PowerPoint biedt vele opties en hulpmiddelen voor animaties en animatie‑effecten in de categorieën **invoer**, **verwijdering**, **accent**, en **bewegingspaden**. 

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en types die je nodig hebt om met animaties te werken onder de [Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation) namespace,
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de [EffectType](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeratie. Deze effecten zijn in wezen dezelfde (of equivalente) effecten die in PowerPoint worden gebruikt.

## **Animatie toepassen op een TextBox**

Aspose.Slides for C++ maakt het mogelijk om animatie toe te passen op de tekst in een vorm. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) toe. 
4. Voeg tekst toe aan [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Haal de hoofdreeks van effecten op.
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape). 
7. Stel de eigenschap [TextAnimation.BuildType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) in op de waarde uit de [BuildType Enumeratie](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze C++‑code laat zien hoe je het `Fade`‑effect toepast op AutoShape en de tekstanimatie instelt op de *By 1st Level Paragraphs*‑waarde:

```c++
// Instantiëert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voegt een nieuwe AutoShape met tekst toe
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Voegt een Fade‑animatie‑effect toe aan de vorm
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animeert de vormtekst per alinea op het eerste niveau
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Sla het PPTX‑bestand op schijf
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Naast het toepassen van animaties op tekst, kun je ook animaties toepassen op een enkel [Paragraph](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_paragraph). Zie [**Geanimeerde tekst**](/slides/nl/cpp/animated-text/).

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_picture_frame) toe of haal er een op van de dia. 
4. Haal de hoofdreeks van effecten op.
5. Voeg een animatie‑effect toe aan de [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_picture_frame).
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze C++‑code toont hoe je het `Fly`‑effect toepast op een afbeelding‑frame:

```c++
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Laad afbeelding die wordt toegevoegd aan de afbeeldingscollectie van de presentatie
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Voegt een afbeelding‑frame toe aan de dia
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Voegt een Fly‑van‑links animatie‑effect toe aan het afbeelding‑frame
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Sla het PPTX‑bestand op schijf
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animatie toepassen op een Shape**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) toe. 
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).
5. Maak een reeks effecten op de bevel‑shape.
6. Maak een aangepaste `UserPath`.
7. Voeg opdrachten toe om naar de `UserPath` te bewegen.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze C++‑code laat zien hoe je het `PathFootball` (path football)‑effect toepast op een shape:

```c++
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

	// Maak een soort "knop".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Maakt een reeks effecten voor deze knop.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Maakt een aangepast gebruikerspad. Ons object wordt alleen verplaatst nadat de knop is aangeklikt.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Voegt opdrachten toe om te verplaatsen omdat het aangemaakte pad leeg is.
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

## **Animatie‑effecten ophalen die op een Shape zijn toegepast**

De volgende voorbeelden laten zien hoe je de methode `GetEffectsByShape` van de [ISequence](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/) interface gebruikt om alle animatie‑effecten op een shape op te halen.

**Voorbeeld 1: Animatie‑effecten ophalen die op een shape op een normale dia zijn toegepast**

Eerder heb je geleerd hoe je animatie‑effecten kunt toevoegen aan shapes in PowerPoint‑presentaties. De volgende voorbeeldcode laat zien hoe je de effecten die op de eerste shape van de eerste normale dia in de presentatie `AnimExample_out.pptx` zijn toegepast, kunt ophalen.

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

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief die van placeholders**

Als een shape op een normale dia placeholders heeft die zich op de layout‑dia en/of master‑dia bevinden, en er animatie‑effecten aan deze placeholders zijn toegevoegd, dan worden alle effecten van de shape afgespeeld tijdens de diavoorstelling, inclusief die geërfd van de placeholders.

Stel dat we een PowerPoint‑presentatie `sample.pptx` hebben met één dia die alleen een footer‑shape bevat met de tekst “Made with Aspose.Slides” en het **Random Bars**‑effect op de shape is toegepast.

![Dia‑shape animatie‑effect](slide-shape-animation.png)

Stel bovendien dat het **Split**‑effect op de footer‑placeholder van de **layout**‑dia is toegepast.

![Layout‑shape animatie‑effect](layout-shape-animation.png)

En tenslotte dat het **Fly In**‑effect op de footer‑placeholder van de **master**‑dia is toegepast.

![Master‑shape animatie‑effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe je de methode `GetBasePlaceholder` van de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) interface gebruikt om via de shape‑placeholders de animatie‑effecten op de footer‑shape op te halen, inclusief die geërfd van placeholders op de layout‑ en master‑dia’s.

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

// Haal animatie‑effecten op van de shape op de normale dia.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Haal animatie‑effecten op van de placeholder op de layout‑dia.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Haal animatie‑effecten op van de placeholder op de master‑dia.
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
Type: 47, subtype: 2              // Vliegen, Onderkant
Type: 134, subtype: 45            // Splitsen, VerticaalIn
Type: 126, subtype: 22            // WillekeurigeBalken, Horizontaal
```

## **Timing‑eigenschappen van animatie‑effecten wijzigen**

Aspose.Slides for C++ maakt het mogelijk om de timing‑eigenschappen van een animatie‑effect te wijzigen.

Dit is het Animation Timing‑paneel in Microsoft PowerPoint:

![voorbeeld1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint‑Timing en de eigenschappen van [Effect.Timing](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- De keuzelijst **Start** in PowerPoint‑Timing komt overeen met de eigenschap [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** in PowerPoint‑Timing komt overeen met de eigenschap [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). De duur van een animatie (in seconden) is de totale tijd die nodig is om één cyclus te voltooien. 
- **Delay** in PowerPoint‑Timing komt overeen met de eigenschap [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Zo wijzig je de Effect‑Timing‑eigenschappen:

1. [Pas](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel nieuwe waarden in voor de [Effect.Timing](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) eigenschappen die je nodig hebt. 
3. Sla het gewijzigde PPTX‑bestand op.

Deze C++‑code demonstreert de bewerking:

```c++
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Haalt het eerste effect van de hoofdreeks op.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Verandert het TriggerType van het effect naar starten bij klikken
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Verandert de duur van het effect
effect->get_Timing()->set_Duration(3.f);

// Verandert de TriggerDelayTime van het effect
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Slaat het PPTX‑bestand op schijf
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Geluid bij animatie‑effect**

Aspose.Slides biedt deze eigenschappen om met geluiden in animatie‑effecten te werken: 

- [set_Sound()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Geluid aan een animatie‑effect toevoegen**

Deze C++‑code laat zien hoe je een geluid aan een animatie‑effect toevoegt en stopt wanneer het volgende effect start:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Voegt audio toe aan de audio‑collectie van de presentatie
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Haalt het eerste effect van de hoofdreeks op
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Controleert of het effect geen geluid heeft
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Voeg geluid toe aan het eerste effect
    firstEffect->set_Sound(effectSound);
}

// Haalt de eerste interactieve reeks van de dia op.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Zet de vlag "Stop previous sound" voor het effect
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Schrijft het PPTX‑bestand naar schijf
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Geluid uit een animatie‑effect extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar een dia via de index. 
3. Haal de hoofdreeks van effecten op. 
4. Extraheer de ingebedde [set_Sound()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effect/set_sound/) van elk animatie‑effect. 

Deze C++‑code laat zien hoe je het ingebedde geluid in een animatie‑effect kunt extraheren:

```c++
// Instantiëert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Haalt de hoofdreeks van de dia op.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **After Animation**

Aspose.Slides for C++ maakt het mogelijk om de After‑animation‑eigenschap van een animatie‑effect te wijzigen.

Dit is het Animation Effect‑paneel en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De keuzelijst **After animation** in PowerPoint komt overeen met deze eigenschappen: 

- Eigenschap [set_AfterAnimationType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) die het type After‑animation beschrijft :
  * **More Colors** in PowerPoint komt overeen met type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/) ;
  * **Don't Dim** in PowerPoint komt overeen met type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/) (standaard after‑animation‑type);
  * **Hide After Animation** in PowerPoint komt overeen met type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/) ;
  * **Hide on Next Mouse Click** in PowerPoint komt overeen met type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/) ;
- Eigenschap [set_AfterAnimationColor()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) die een kleurformaat voor after‑animation definieert. Deze eigenschap werkt samen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/). Als je het type wijzigt, wordt de after‑animation‑kleur gewist.

Deze C++‑code laat zien hoe je een after‑animation‑effect wijzigt:

```c++
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Haalt het eerste effect van de hoofdreeks op
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Wijzigt het after‑animation type naar Kleur
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Stelt de dim‑kleur na animatie in
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Schrijft het PPTX‑bestand naar schijf
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Tekst animeren**

Aspose.Slides biedt deze eigenschappen om met het *Animate text*‑blok van een animatie‑effect te werken:

- [set_AnimateTextType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) die het type animatietekst van het effect beschrijft. De shape‑tekst kan geanimeerd worden:
  - In één keer ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/animatetexttype/) type)
  - Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/animatetexttype/) type)
  - Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/animatetexttype/) type)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) stelt een vertraging in tussen de geanimeerde tekstonderdelen (woorden of letters). Een positieve waarde geeft het percentage van de effectduur aan. Een negatieve waarde geeft de vertraging in seconden aan.

Zo kun je de eigenschappen van Effect Animate text wijzigen:

1. [Pas](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel de eigenschap [set_BuildType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation.itextanimation/set_buildtype/) in op de waarde [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/buildtype/) om de *By Paragraphs*‑animatiemodus uit te schakelen.
3. Stel nieuwe waarden in voor de eigenschappen [set_AnimateTextType()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) en [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Sla het gewijzigde PPTX‑bestand op.

Deze C++‑code demonstreert de bewerking:

```c++
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Haalt het eerste effect van de hoofdreeks op
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Wijzigt het type tekstanimatie van het effect naar "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Wijzigt het type animatietekst van het effect naar "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Stelt de vertraging tussen woorden in op 20% van de effectduur
firstEffect->set_DelayBetweenTextParts(20.0f);

// Slaat het PPTX‑bestand op schijf
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Hoe kan ik ervoor zorgen dat animaties behouden blijven bij het publiceren van de presentatie naar het web?**

[Export to HTML5](/slides/nl/cpp/export-to-html5/) en schakel de [opties](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/) in die verantwoordelijk zijn voor animaties van [shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animateshapes/) en [transition](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animatetransitions/). Plain HTML speelt geen slide‑animaties af, HTML5 wel.

**Hoe beïnvloedt het wijzigen van de z‑order (lagenvolgorde) van shapes de animatie?**

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt de timing en het type verschijnen/verdwijnen, terwijl [z-order](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/get_zorderposition/) bepaalt wat wat bedekt. Het zichtbare resultaat wordt bepaald door hun combinatie. (Dit is het algemene gedrag van PowerPoint; het Aspose.Slides‑effect‑en‑shape‑model volgt dezelfde logica.)

**Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?**

In het algemeen worden [animaties ondersteund](/slides/nl/cpp/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders worden gerenderd. Het wordt aanbevolen de gebruikte effecten en de bibliotheekversie te testen.