---
title: Tillämpa formanimationer i presentationer med C++
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
- lägg till animation
- hämta animation
- extrahera animation
- lägg till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint‑presentationer med Aspose.Slides för C++. Stick ut!"
---
## **Introduktion**

Animationer är visuella effekter som kan tillämpas på texter, bilder, former eller [diagram](/slides/sv/cpp/animated-charts/). De ger liv åt presentationer eller deras beståndsdelar. 

## **Varför använda animationer i presentationer?**

* kontrollera informationsflödet
* betona viktiga punkter
* öka intresse eller engagemang bland din publik
* göra innehållet lättare att läsa, assimilera eller bearbeta
* rikta läsarens eller tittarens uppmärksamhet mot viktiga delar i en presentation

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **entré**, **utgång**, **betoning** och **rörelsebanor**. 

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer under namnrymden [Aspose.Slides.Animation](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation).
* Aspose.Slides erbjuder över **150 animationseffekter** under uppräkningen [EffectType](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Dessa effekter är i huvudsak samma (eller motsvarande) effekter som används i PowerPoint.

## **Tillämpa animation på en textruta**

Aspose.Slides för C++ låter dig tillämpa animation på texten i en form. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/).
2. Hämta en slides referens via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape). 
4. Lägg till text till [IAutoShape.TextFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Hämta huvudsekvensen av effekter.
6. Lägg till en animationseffekt på [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape). 
7. Ställ in egenskapen [TextAnimation.BuildType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) till värdet från [BuildType Enumeration](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Skriv presentationen till disk som en PPTX‑fil.

Denna C++‑kod visar hur du tillämpar `Fade`‑effekten på AutoShape och sätter textanimationen till värdet *Efter första nivåns stycken*:

```c++
// Skapar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Lägger till en ny AutoShape med text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Hämtar huvudsekvensen för sliden.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Lägger till Fade‑animationseffekt till formen
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animera formens text efter första nivåns stycken
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Spara PPTX‑filen till disk
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_paragraph). Se [**Animera text**](/slides/sv/cpp/animated-text/).

{{% /alert %}} 

## **Tillämpa animation på en bildram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/).
2. Hämta en slides referens via dess index.
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_picture_frame) på sliden. 
4. Hämta huvudsekvensen av effekter.
5. Lägg till en animationseffekt på [PictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_picture_frame).
6. Skriv presentationen till disk som en PPTX‑fil.

Denna C++‑kod visar hur du applicerar `Fly`‑effekten på en bildram:

```c++
// Skapar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Ladda bild som ska läggas till i presentationens bildsamling
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Lägger till bildram på sliden
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Hämtar huvudsekvensen för sliden.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Lägger till Fly‑animationseffekt från vänster till bildramen
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Spara PPTX‑filen till disk
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Tillämpa animation på en form**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/).
2. Hämta en slides referens via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape). 
4. Lägg till en `Bevel` [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape) (när detta objekt klickas på spelas animationen).
5. Skapa en sekvens av effekter på bevel‑formen.
6. Skapa en anpassad `UserPath`.
7. Lägg till kommandon för att flytta till `UserPath`.
8. Skriv presentationen till disk som en PPTX‑fil.

Denna C++‑kod visar hur du applicerar `PathFootball`‑effekten (path football) på en form:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Laddar presentationen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar första sliden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Hämtar samlingen av former för den valda sliden
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Skapar PathFootball‑effekt för befintlig form från grunden.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Lägger till PathFootBall‑animationseffekt
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Skapar någon form av "button".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Skapar en sekvens av effekter för denna knapp.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Skapar en anpassad användarväg. Vårt objekt kommer bara att förflyttas efter att knappen har klickats.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Lägger till kommandon för förflyttning eftersom den skapade vägen är tom.
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
	 
	 // Skriver PPTX‑filen till disken
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hämta animationseffekterna som tillämpats på en form**

Följande exempel visar hur du använder metoden `GetEffectsByShape` från gränssnittet [ISequence](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/) för att hämta alla animationseffekter som tillämpats på en form.

**Exempel 1: Hämta animationseffekter som tillämpats på en form på en normal slide**

Tidigare lärde du dig hur du lägger till animationseffekter på former i PowerPoint‑presentationer. Följande exempel­kod visar hur du hämtar effekterna som tillämpats på den första formen på den första normala sliden i presentationen `AnimExample_out.pptx`.

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

**Exempel 2: Hämta alla animationseffekter, inklusive de som ärvs från platshållare**

Om en form på en normal slide har platshållare som finns på layout‑sliden och/eller huvud‑sliden, och animationseffekter har lagts till dessa platshållare, då kommer alla effekter för formen att spelas upp under bildspelet, inklusive de som ärvs från platshållarna.

Låt oss säga att vi har en PowerPoint‑presentation `sample.pptx` med en slide som endast innehåller en sidfot­sform med texten "Made with Aspose.Slides" och effekten **Random Bars** är tillämpad på formen.

![Bildform animationseffekt](slide-shape-animation.png)

Låt oss också anta att effekten **Split** är tillämpad på sidfotens platshållare på **layout**‑sliden.

![Layout form animationseffekt](layout-shape-animation.png)

Och slutligen är effekten **Fly In** tillämpad på sidfotens platshållare på **master**‑sliden.

![Master form animationseffekt](master-shape-animation.png)

Följande exempel­kod visar hur du använder metoden `GetBasePlaceholder` från gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) för att komma åt formens platshållare och hämta animationseffekterna som är tillämpade på sidfotens form, inklusive de som ärvs från platshållare på layout‑ och master‑slides.

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

// Get animation effects of the shape on the normal slide.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
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
Type: 47, subtype: 2              // Fly, Botten
Type: 134, subtype: 45            // Split, VertikalIn
Type: 126, subtype: 22            // RandomBars, Horisontell
```

## **Ändra timing‑egenskaper för animationseffekt**

Aspose.Slides för C++ låter dig ändra timing‑egenskaperna för en animationseffekt.

Detta är Animation Timing‑panelen i Microsoft PowerPoint:

![exempel1_bild](shape-animation.png)

Dessa är motsvarigheterna mellan PowerPoint Timing och [Effect.Timing](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) egenskaper:

- PowerPoint Timing **Start** rullgardinslistan matchar egenskapen [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- PowerPoint Timing **Duration** matchar egenskapen [Effect.Timing.Duration](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Tidslängden för en animation (i sekunder) är den totala tid som animationen tar för att fullfölja en cykel. 
- PowerPoint Timing **Delay** matchar egenskapen [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Så här ändrar du egenskaperna för Effect Timing:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in nya värden för de [Effect.Timing](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c)‑egenskaper du behöver. 
3. Spara den modifierade PPTX‑filen.

```c++
// Skapar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Hämtar huvudsekvensen för sliden.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Hämtar den första effekten i huvudsekvensen.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Ändrar effektens TriggerType till att starta vid klick
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Ändrar effektens varaktighet
effect->get_Timing()->set_Duration(3.f);

// Ändrar effektens TriggerDelayTime
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Sparar PPTX‑filen till disk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ljud för animationseffekt**

Aspose.Slides tillhandahåller dessa egenskaper för att du ska kunna arbeta med ljud i animationseffekter: 

- [set_Sound()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Lägg till ljud för en animationseffekt**

Denna C++‑kod visar hur du lägger till ett ljud för en animationseffekt och stoppar det när nästa effekt startar:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Lägger till ljud i presentationens ljudsamling
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Hämtar huvudsekvensen för sliden.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Hämtar den första effekten i huvudsekvensen
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Kontrollerar om effekten har "Ingen ljud"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Lägger till ljud för den första effekten
    firstEffect->set_Sound(effectSound);
}

// Hämtar den första interaktiva sekvensen för sliden.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Sätter flaggan "Stoppa föregående ljud" för effekten
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Skriver PPTX‑filen till disk
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extrahera ljud för en animationseffekt**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en slides referens via dess index. 
3. Hämta huvudsekvensen av effekter. 
4. Extrahera den inbäddade [set_Sound()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effect/set_sound/) för varje animationseffekt. 

Denna C++‑kod visar hur du extraherar ljudet som är inbäddat i en animationseffekt:

```c++
// Skapar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Hämtar huvudsekvensen för sliden.
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

Aspose.Slides för C++ låter dig ändra egenskapen Efter animation för en animationseffekt.

Detta är Animation Effect‑panelen och den utökade menyn i Microsoft PowerPoint:

![exempel1_bild](shape-after-animation.png)

PowerPoint‑effekten **After animation** rullgardinslistan matchar dessa egenskaper: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) egenskap som beskriver typen för Efter animation:
  * PowerPoint **More Colors** motsvarar typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Don't Dim** motsvarar typen [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/) (standardtyp för efter animation);
  * PowerPoint **Hide After Animation** motsvarar typen [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** motsvarar typen [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/) ;
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) egenskap som definierar ett färgformat för efter animation. Denna egenskap fungerar tillsammans med typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/). Om du ändrar typen till en annan, kommer färgen för efter animation att rensas.

Denna C++‑kod visar hur du ändrar en efter‑animationseffekt:

```c++
// Skapar en presentationsklass som representerar en presentationsfil
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Hämtar den första effekten i huvudsekvensen
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändrar typen för efteranimation till Färg
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Ställer in färgen för efteranimationens dimning
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Skriver PPTX‑filen till disk
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animera text**

Aspose.Slides tillhandahåller dessa egenskaper för att du ska kunna arbeta med en animationseffekts *Animera text*-block:

- [set_AnimateTextType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) som beskriver vilken typ av animering som effekten har. Formens text kan animera:
  - Alla på en gång ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/animatetexttype/) typ)
  - Ord för ord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/animatetexttype/) typ)
  - Bokstav för bokstav ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/animatetexttype/) typ)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) anger en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procentandelen av effektens varaktighet. Ett negativt värde anger fördröjning i sekunder.

Så här kan du ändra egenskaperna för Effect Animate text:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in egenskapen [set_BuildType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itextanimation/set_buildtype/) till värdet [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/buildtype/) för att stänga av *By Paragraphs*-animationsläget.
3. Ställ in nya värden för egenskaperna [set_AnimateTextType()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) och [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Spara den modifierade PPTX‑filen.

```c++
// Skapar en presentationsklass som representerar en presentationsfil.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Hämtar den första effekten i huvudsekvensen
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Ändrar effektens Text‑animations‑typ till "Som ett objekt"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Ändrar effektens Animate text‑typ till "Efter ord"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Ställer in fördröjning mellan ord till 20 % av effektens varaktighet
firstEffect->set_DelayBetweenTextParts(20.0f);

// Skriver PPTX‑filen till disk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Hur kan jag säkerställa att animationer bevaras när jag publicerar presentationen på webben?**

[Exportera till HTML5](/slides/sv/cpp/export-to-html5/) och aktivera de [alternativ](/reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/) som ansvarar för animationer av [form](/reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animateshapes/) och [övergång](/reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animatetransitions/). Vanlig HTML spelar inte upp bildanimationer, medan HTML5 gör det.

**Hur påverkar förändring av z-ordning (lagersordning) för former animation?**

Animation och ritordning är oberoende: en effekt styr timing och typ av att dyka upp/försvinna, medan [z-order](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/get_zorderposition/) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är det generella PowerPoint‑beteendet; Aspose.Slides‑modellen för effekter och former följer samma logik.)

**Finns det begränsningar vid konvertering av animationer till video för vissa effekter?**

I allmänhet [stödjs animationer](/slides/sv/cpp/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den biblioteksversion du har.