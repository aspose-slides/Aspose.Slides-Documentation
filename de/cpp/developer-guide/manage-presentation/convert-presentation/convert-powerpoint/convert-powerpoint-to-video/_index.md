---
title: PowerPoint-Präsentationen in Video konvertieren in C++
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu Video
- Präsentation zu Video
- PPT zu Video
- PPTX zu Video
- PowerPoint zu MP4
- Präsentation zu MP4
- PPT zu MP4
- PPTX zu MP4
- PPT als MP4 speichern
- PPTX als MP4 speichern
- PPT nach MP4 exportieren
- PPTX nach MP4 exportieren
- Videokonvertierung
- PowerPoint
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in C++ zu einem Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

## **Übersicht**

Durch die Umwandlung Ihrer PowerPoint‑Präsentation in ein Video erhalten Sie 

* **Erhöhte Zugänglichkeit:** Alle Geräte (unabhängig vom Betriebssystem) enthalten standardmäßig Video‑Player im Vergleich zu Anwendungen zum Öffnen von Präsentationen, sodass Benutzer Videos leichter öffnen oder abspielen können.
* **Größere Reichweite:** Mit Videos können Sie ein großes Publikum erreichen und es mit Informationen ansprechen, die in einer Präsentation sonst möglicherweise als langwierig empfunden werden. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und sie im Allgemeinen bevorzugen.

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), haben wir die Unterstützung für die Umwandlung von Präsentationen in Videos implementiert. 

* Verwenden Sie Aspose.Slides, um einen Satz von Einzelbildern (aus den Präsentationsfolien) zu erzeugen, die einer bestimmten FPS (Bilder pro Sekunde) entsprechen
* Verwenden Sie ein Drittanbieter‑Dienstprogramm wie `ffmpeg`, um basierend auf den Einzelbildern ein Video zu erstellen.

## **PowerPoint‑Präsentation in Video konvertieren**

1. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.
2. Fügen Sie den Pfad zu `ffmpeg.exe` zur Umgebungsvariable `PATH` hinzu.
3. Führen Sie den PowerPoint‑zu‑Video‑Code aus.

Dieser C++‑Code zeigt, wie Sie eine Präsentation (mit einer Figur und zwei Animationseffekten) in ein Video konvertieren:
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

    // Fügt eine Smiley-Form hinzu und animiert sie dann
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

Vielleicht möchten Sie diese Artikel ansehen: [PowerPoint‑Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Form‑Animation](https://docs.aspose.com/slides/cpp/shape-animation/), und [Form‑Effekt](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie bewirken dasselbe bei Videos. Fügen wir der vorherigen Präsentation einen weiteren Folienwechsel und Übergang zum Code hinzu:
```c++
// Fügt eine Smiley-Form hinzu und animiert sie

// ...

// Fügt eine neue Folie und einen animierten Übergang hinzu

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides unterstützt zudem Animationen für Texte. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):
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

    // Konvertiert Einzelbilder zu Video
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


## **Klassen zur Videokonvertierung**

Um Ihnen die Durchführung von PowerPoint‑zu‑Video‑Konvertierungsaufgaben zu ermöglichen, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) und [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) bereit.

PresentationAnimationsGenerator ermöglicht es Ihnen, die Bildgröße für das später zu erstellende Video über seinen Konstruktor festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es werden Animationen erzeugt, die [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) nutzt. 

Bei der Erzeugung von Animationen wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis erzeugt, das den Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) hat. Letzterer ist eine Klasse, die einen Player für eine einzelne Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) zu arbeiten, werden die Eigenschaft [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) verwendet. Jede Animationsposition wird innerhalb des Bereichs *0 bis Dauer* festgelegt, und anschließend gibt die Methode `GetFrame` ein Bitmap zurück, das dem Animationszustand zu diesem Zeitpunkt entspricht.
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // Anfangszustand der Animation
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // Bitmap des Anfangszustands der Animation

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // Endzustand der Animation
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // Letztes Bild der Animation
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


Um alle Animationen einer Präsentation gleichzeitig abspielen zu lassen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) sowie FPS für Effekte entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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


Anschließend können die erzeugten Einzelbilder zu einem Video zusammengefügt werden. Siehe den Abschnitt [PowerPoint in Video konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides unterstützt die Arbeit mit [passwortgeschützten Präsentationen](/slides/de/cpp/password-protected-presentation/). Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides die Nutzung in Cloud‑Lösungen?**

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Dienste integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen bei der Konvertierung?**

Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird häufig empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.

**Einstieg**

| Animationsart | Aspose.Slides | PowerPoint |
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

**Betonung**

| Animationsart | Aspose.Slides | PowerPoint |
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

**Ausgang**

| Animationsart | Aspose.Slides | PowerPoint |
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

**Bewegungspfade**

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |