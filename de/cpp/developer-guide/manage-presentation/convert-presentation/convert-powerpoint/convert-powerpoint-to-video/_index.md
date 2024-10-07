---
title: PowerPoint in Video konvertieren
type: docs
weight: 130
url: /cpp/convert-powerpoint-to-video/
keywords: "PowerPoint konvertieren, PPT, PPTX, Präsentation, Video, MP4, PPT in Video, PPT in MP4, C++, Aspose.Slides"
description: "Konvertieren Sie PowerPoint in Video mit der Aspose.Slides für C++ API"
---

Durch die Umwandlung Ihrer PowerPoint-Präsentation in ein Video erhalten Sie

* **Erhöhte Zugänglichkeit:** Alle Geräte (unabhängig von der Plattform) sind standardmäßig mit Video-Playern ausgestattet im Vergleich zu Anwendung, die Präsentationen öffnen, sodass es den Nutzern einfacher fällt, Videos zu öffnen oder abzuspielen.
* **Größere Reichweite:** Durch Videos können Sie ein breites Publikum erreichen und es mit Informationen ansprechen, die in einer Präsentation ansonsten möglicherweise langwierig erscheinen würden. Die meisten Umfragen und Statistiken deuten darauf hin, dass Menschen Videos mehr ansehen und konsumieren als andere Formen von Inhalten und solche Inhalte im Allgemeinen bevorzugen.

## **Konvertierung von PowerPoint in Video in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/) haben wir die Unterstützung für die Konvertierung von Präsentationen in Videos implementiert.

* Verwenden Sie Aspose.Slides, um ein Set von Frames (aus den Präsentationsfolien) zu generieren, die einer bestimmten FPS (Frames pro Sekunde) entsprechen.
* Verwenden Sie ein Drittanbieter-Tool wie `ffmpeg`, um ein Video basierend auf den Frames zu erstellen.

### **PowerPoint in Video konvertieren**

1. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.
2. Fügen Sie den Pfad zu `ffmpeg.exe` der Umgebungsvariable `PATH` hinzu.
3. Führen Sie den Code zur Konvertierung von PowerPoint in Video aus.

Dieser C++-Code zeigt Ihnen, wie Sie eine Präsentation (die eine Figur und zwei Animationseffekte enthält) in ein Video konvertieren:

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

    // Fügt eine Smiley-Form hinzu und animiert sie
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

## **Videoeffekte**

Sie können Animationen auf Objekte in Folien anwenden und Übergänge zwischen Folien verwenden.

{{% alert color="primary" %}} 

Möglicherweise möchten Sie sich diese Artikel ansehen: [PowerPoint-Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Formanimation](https://docs.aspose.com/slides/cpp/shape-animation/), und [Formeffekt](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie tun dasselbe für Videos. Fügen wir dem Code der vorherigen Präsentation eine weitere Folie und einen Übergang hinzu:

```c++
// Fügt eine Smiley-Form hinzu und animiert sie

// ...

// Fügt eine neue Folie mit animiertem Übergang hinzu

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides unterstützt auch Animationen für Texte. So animieren wir Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):

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

    // Fügt Text und Animationen hinzu
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides für C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"PowerPoint-Präsentation mit Text in Video konvertieren"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"Absatz für Absatz"));
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

    // Konvertiert Frames zu Video
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

## **Videokonvertierungsklassen**

Um Ihnen die Durchführung von Aufgaben zur Konvertierung von PowerPoint in Video zu ermöglichen, bietet Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) und [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) an.

PresentationAnimationsGenerator ermöglicht es Ihnen, die Framegröße für das Video (das später erstellt wird) über seinen Konstruktor festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es generiert Animationen, die von [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) verwendet werden.

Wenn Animationen generiert werden, wird für jede nachfolgende Animation ein `NewAnimation`-Ereignis erzeugt, das den Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) hat. Letzteres ist eine Klasse, die einen Player für eine separate Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) zu arbeiten, werden die Eigenschaften [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und dann gibt die Methode `GetFrame` ein Bitmap zurück, das dem Animationszustand zu diesem Zeitpunkt entspricht.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Gesamtdauer der Animation: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // ursprünglicher Animationszustand
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // Bitmap des ursprünglichen Animationszustands

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // endgültiger Zustand der Animation
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // letzter Frame der Animation
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Fügt eine Smiley-Form hinzu und animiert sie
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

Um alle Animationen in einer Präsentation gleichzeitig abzuspielen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) verwendet. Diese Klasse nimmt eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) und FPS für Effekte in ihrem Konstruktor und ruft dann das `FrameTick`-Ereignis für alle Animationen auf, um sie abzuspielen:

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

Dann können die generierten Frames zu einem Video zusammengestellt werden. Siehe den Abschnitt [PowerPoint in Video konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eingangsanimationen**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Erscheinen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ausblenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hineinfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hineinschweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Rad** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hüpfen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Betonung**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Farbe Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wippen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen/Schrumpfen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Entsättigen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Dunkeln** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Aufhellen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Transparenz** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Objektfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Komplementärfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Linienfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Füllfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Austrittsanimationen**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschwinden** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ausblenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausschweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schrumpfen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hüpfen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungspfad:**

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linien** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bögen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehungen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Formen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schleifen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Benutzerdefinierter Pfad** | ![unterstützt](v.png) | ![unterstützt](v.png) |