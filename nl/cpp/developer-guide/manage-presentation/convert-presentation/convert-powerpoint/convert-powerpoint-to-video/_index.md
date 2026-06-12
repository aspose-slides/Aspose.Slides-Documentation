---
title: "PowerPoint‑presentaties naar video converteren in C++"
linktitle: "PowerPoint naar video"
type: docs
weight: 130
url: /nl/cpp/convert-powerpoint-to-video/
keywords:
- "PowerPoint converteren"
- "presentatie converteren"
- "PPT converteren"
- "PPTX converteren"
- "PowerPoint naar video"
- "presentatie naar video"
- "PPT naar video"
- "PPTX naar video"
- "PowerPoint naar MP4"
- "presentatie naar MP4"
- "PPT naar MP4"
- "PPTX naar MP4"
- "PPT opslaan als MP4"
- "PPTX opslaan als MP4"
- "PPT exporteren naar MP4"
- "PPTX exporteren naar MP4"
- "video‑conversie"
- "PowerPoint"
- "C++"
- "Aspose.Slides"
description: "Leer hoe u PowerPoint‑presentaties naar video kunt converteren in C++. Ontdek voorbeeldcode en automatisatietechnieken om uw workflow te optimaliseren."
---
## **Inleiding**

Door uw PowerPoint‑presentatie naar video te converteren, krijgt u 

* **Toename in toegankelijkheid:** Alle apparaten (ongeacht platform) hebben standaard videospelers, in tegenstelling tot presentatiesoftware, waardoor gebruikers video's gemakkelijker kunnen openen of afspelen.
* **Groter bereik:** Met video’s kunt u een groot publiek bereiken en hen van informatie voorzien die anders misschien saai overkomt in een presentatie. De meeste onderzoeken en statistieken geven aan dat mensen video’s meer bekijken en consumeren dan andere vormen van inhoud, en zij geven er over het algemeen de voorkeur aan.

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/nl/cpp/aspose-slides-for-cpp-22-11-release-notes/), hebben we ondersteuning geïmplementeerd voor het converteren van presentaties naar video. 

* Gebruik Aspose.Slides om een reeks frames (van de presentatieslides) te genereren die overeenkomen met een bepaalde FPS (frames per seconde)
* Gebruik een extern hulpprogramma zoals `ffmpeg` om een video te maken op basis van de frames.

## **Converteer een PowerPoint‑presentatie naar video**

1. Download ffmpeg [hier](https://ffmpeg.org/download.html).
2. Voeg het pad naar `ffmpeg.exe` toe aan de omgevingsvariabele `PATH`.
3. Voer de PowerPoint‑naar‑video‑code uit.

Deze C++‑code laat zien hoe u een presentatie (met een afbeelding en twee animatie‑effecten) naar een video kunt converteren:

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

    // Voegt een smiley‑vorm toe en animeert deze
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

## **Video‑effecten**

U kunt animaties toepassen op objecten op dia's en overgangen tussen dia's gebruiken.

{{% alert color="primary" %}} 

U wilt talvez deze artikelen bekijken: [PowerPoint‑animatie](https://docs.aspose.com/slides/nl/cpp/powerpoint-animation/), [Vorm‑animatie](https://docs.aspose.com/slides/nl/cpp/shape-animation/), en [Vorm‑effect](https://docs.aspose.com/slides/nl/cpp/shape-effect/).

{{% /alert %}} 

Animaties en overgangen maken diavoorstellingen boeiender en interessanter—en ze doen hetzelfde voor video’s. Laten we een extra dia en overgang toevoegen aan de code van de vorige presentatie:

```c++
// Voegt een smiley‑vorm toe en animeert deze

// ...

// Voegt een nieuwe dia toe en een geanimeerde overgang

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides ondersteunt ook animatie voor tekst. We animeren dus alinea’s op objecten, die één voor één verschijnen (met een vertraging van één seconde):

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

    // Voegt tekst en animaties toe
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

    // Converteert frames naar video
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

## **Video‑conversieklassen**

Om u PowerPoint‑naar‑video‑conversietaken te laten uitvoeren, biedt Aspose.Slides de klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.presentation_animations_generator/) en [PresentationPlayer](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.presentation_player/) aan.

PresentationAnimationsGenerator stelt u in staat de frame‑grootte voor de video (die later wordt aangemaakt) via de constructor in te stellen. Als u een instantie van de presentatie meegeeft, wordt `Presentation.SlideSize` gebruikt en genereert het animaties die [PresentationPlayer](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.presentation_player/) gebruikt. 

Wanneer animaties worden gegenereerd, wordt voor elke volgende animatie een `NewAnimation`‑gebeurtenis gegenereerd, die de parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.i_presentation_animation_player/) heeft. Deze laatste is een klasse die een speler voor een afzonderlijke animatie vertegenwoordigt.

Om met [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.i_presentation_animation_player/) te werken, worden de eigenschap [get_Duration](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (de volledige duur van de animatie) en de methode [SetTimePosition](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) gebruikt. Elke animatie‑positie wordt ingesteld binnen het bereik *0 tot duur*, waarna de `GetFrame`‑methode een Bitmap retourneert die overeenkomt met de animatiestatus op dat moment.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // initiële animatiestatus
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap van initiële animatiestatus

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // eindtoestand van de animatie
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // laatste frame van de animatie
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Voegt een smiley‑vorm toe en animeert deze
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

Om alle animaties in een presentatie tegelijk af te spelen, wordt de klasse [PresentationPlayer](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.presentation_player/) gebruikt. Deze klasse neemt in de constructor een instantie van [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.presentation_animations_generator/) en een FPS voor effecten, en roept vervolgens het `FrameTick`‑event aan voor alle animaties om ze af te spelen:

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

Vervolgens kunnen de gegenereerde frames worden samengevoegd tot een video. Zie de sectie [PowerPoint converteren naar video](https://docs.aspose.com/slides/nl/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Ondersteunde animaties en effecten**


**Ingang**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschijnen** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Vervagen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Invliegen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Inzweven** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Splitsen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Vegen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Vorm** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Wiel** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Willekeurige balken** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Groei & Draaien** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Zoomen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Draaien** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Stuiteren** | ![ondersteund](v.png) | ![ondersteund](v.png) |


**Nadruk**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulseren** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Kleurpuls** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Wiebel** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Draaien** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Groei/krimp** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Desatureren** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Donker maken** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Lichter maken** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Transparantie** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Objectkleur** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Complementaire kleur** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Lijnkleur** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Vulkleur** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |

**Uitgang**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verdwijnen** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Vervagen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Uitvliegen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Uitzweven** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Splitsen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Vegen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Vorm** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Willekeurige balken** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Krimpen & Draaien** | ![niet ondersteund](x.png) | ![ondersteund](v.png) |
| **Zoomen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Draaien** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Stuiteren** | ![ondersteund](v.png) | ![ondersteund](v.png) |

**Bewegingspaden**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lijnen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Boog** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Draaien** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Vormen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Lussen** | ![ondersteund](v.png) | ![ondersteund](v.png) |
| **Aangepast pad** | ![ondersteund](v.png) | ![ondersteund](v.png) |

## **Veelgestelde vragen**

**Is het mogelijk om presentaties die met wachtwoord beveiligd zijn te converteren?**

Ja, Aspose.Slides maakt het mogelijk om te werken met [wachtwoord‑beveiligde presentaties](/slides/nl/cpp/password-protected-presentation/). Bij het verwerken van dergelijke bestanden moet u het juiste wachtwoord opgeven zodat de bibliotheek toegang krijgt tot de inhoud van de presentatie.

**Ondersteunt Aspose.Slides gebruik in cloud‑oplossingen?**

Ja, Aspose.Slides kan worden geïntegreerd in cloud‑applicaties en -diensten. De bibliotheek is ontworpen om in serveromgevingen te werken, waarbij hoge prestaties en schaalbaarheid voor de batchverwerking van bestanden worden gegarandeerd.

**Zijn er groottebeperkingen voor presentaties tijdens de conversie?**

Aspose.Slides kan presentaties van vrijwel elke grootte verwerken. Bij zeer grote bestanden kunnen echter extra systeembronnen nodig zijn, en wordt soms aanbevolen de presentatie te optimaliseren om de prestaties te verbeteren.