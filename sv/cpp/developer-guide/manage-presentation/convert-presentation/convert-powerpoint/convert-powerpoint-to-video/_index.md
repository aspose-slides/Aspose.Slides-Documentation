---
title: "Konvertera PowerPoint-presentationer till video i C++"
linktitle: "PowerPoint till video"
type: docs
weight: 130
url: /sv/cpp/convert-powerpoint-to-video/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera PPT
- konvertera PPTX
- PowerPoint till video
- presentation till video
- PPT till video
- PPTX till video
- PowerPoint till MP4
- presentation till MP4
- PPT till MP4
- PPTX till MP4
- spara PPT som MP4
- spara PPTX som MP4
- exportera PPT till MP4
- exportera PPTX till MP4
- videokonvertering
- PowerPoint
- C++
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint-presentationer till video i C++. Upptäck exempel på kod och automatiseringstekniker för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint‑presentation till video får du 

* **Ökad tillgänglighet:** Alla enheter (oavsett plattform) är som standard utrustade med videospelare jämfört med program för att öppna presentationer, så användare finner det enklare att öppna eller spela upp videor.
* **Större räckvidd:** Med videor kan du nå en stor publik och rikta dem med information som annars kan upplevas som tråkig i en presentation. De flesta undersökningar och statistik visar att människor tittar på och konsumerar videor mer än annat innehåll, och de föredrar generellt sådant material.

I [Aspose.Slides 22.11](https://docs.aspose.com/slides/sv/cpp/aspose-slides-for-cpp-22-11-release-notes/) har vi implementerat stöd för konvertering av presentation till video. 

* Använd Aspose.Slides för att generera ett set av ramar (från presentationsbilderna) som motsvarar ett visst FPS (frames per second)
* Använd ett tredjepartsverktyg som `ffmpeg` för att skapa en video baserad på ramarna.

## **Konvertera en PowerPoint‑presentation till video**

1. Ladda ner ffmpeg [här](https://ffmpeg.org/download.html).
2. Lägg till sökvägen till `ffmpeg.exe` i systemvariabeln `PATH`.
3. Kör koden för PowerPoint till video.

Denna C++‑kod visar hur du konverterar en presentation (med en figur och två animationseffekter) till en video:

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

    // Lägger till en smiley-form och animerar den sedan
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

## **Videoeffekter**

Du kan applicera animationer på objekt i bilder och använda övergångar mellan bilder.

{{% alert color="primary" %}} 

Du kanske vill läsa dessa artiklar: [PowerPoint Animation](https://docs.aspose.com/slides/sv/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/sv/cpp/shape-animation/), och [Shape Effect](https://docs.aspose.com/slides/sv/cpp/shape-effect/).

{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta—och de gör samma sak för videor. Låt oss lägga till en ny bild och övergång i koden för den föregående presentationen:

```c++
// Lägger till en smiley-form och animerar den

// ...

// Lägger till en ny bild och animerad övergång

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides stöder också animation för texter. Så vi animerar stycken på objekt, som visas ett efter ett (med en fördröjning på en sekund):

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

    // Lägger till text och animationer
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

    // Konverterar ramar till video
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

## **Klasser för videokonvertering**

För att du ska kunna utföra PowerPoint‑till‑video‑konverteringar tillhandahåller Aspose.Slides klasserna [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.presentation_animations_generator/) och [PresentationPlayer](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.presentation_player/) .

PresentationAnimationsGenerator låter dig ange bildstorlek för den video som senare kommer att skapas via sin konstruktor. Om du skickar en instans av presentationen används `Presentation.SlideSize` och den genererar animationer som [PresentationPlayer](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.presentation_player/) använder. 

När animationer genereras skapas ett `NewAnimation`‑event för varje efterföljande animation, som har parametern [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.i_presentation_animation_player/). Den senare är en klass som representerar en spelare för en separat animation.

För att arbeta med [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.i_presentation_animation_player/) används egenskapen [get_Duration](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (den totala varaktigheten för animationen) och metoden [SetTimePosition](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Varje animationsposition sätts inom intervallet *0 till varaktighet*, och sedan returnerar `GetFrame`‑metoden en Bitmap som motsvarar animationstillståndet vid det ögonblicket.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // initialt animationstillstånd
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap för initialt animationstillstånd

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // slutligt tillstånd för animationen
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // sista bildrutan av animationen
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Lägger till en smiley-form och animerar den
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

För att alla animationer i en presentation ska spelas upp samtidigt används klassen [PresentationPlayer](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.presentation_player/). Denna klass tar en [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.presentation_animations_generator/)‑instans och FPS för effekter i sin konstruktor och anropar sedan `FrameTick`‑eventet för alla animationer för att få dem spelade:

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

Därefter kan de genererade ramarna kompileras för att producera en video. Se avsnittet [Convert PowerPoint to Video](https://docs.aspose.com/slides/sv/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Stödda animationer och effekter**


**Ingång**:

| Animation Type | Aspose.Slides | PowerPoint |
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


**Betoning**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Avslut**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Rörelsebanor**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Är det möjligt att konvertera presentationer som är lösenordsskyddade?**

Ja, Aspose.Slides möjliggör arbete med [password-protected presentations](/slides/sv/cpp/password-protected-presentation/). När du bearbetar sådana filer måste du ange rätt lösenord så att biblioteket kan komma åt innehållet i presentationen.

**Stöder Aspose.Slides användning i molnlösningar?**

Ja, Aspose.Slides kan integreras i molnapplikationer och -tjänster. Biblioteket är designat för att fungera i servermiljöer och säkerställer hög prestanda och skalbarhet för batch‑behandling av filer.

**Finns det några storleksbegränsningar för presentationer vid konvertering?**

Aspose.Slides kan hantera presentationer av praktiskt taget vilken storlek som helst. Vid mycket stora filer kan dock ytterligare systemresurser behövas, och det rekommenderas ibland att optimera presentationen för att förbättra prestandan.