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
- Video-Konvertierung
- PowerPoint
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in ein Video in C++ konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Workflow zu optimieren."
---

## **Übersicht**

Durch das Konvertieren Ihrer PowerPoint‑Präsentation in ein Video erhalten Sie 

* **Steigerung der Barrierefreiheit:** Alle Geräte (unabhängig vom Plattform) sind standardmäßig mit Videoplayern ausgestattet im Vergleich zu Präsentations‑Öffnungs‑Anwendungen, sodass Benutzer Videos leichter öffnen oder abspielen können.
* **Mehr Reichweite:** Mit Videos können Sie ein großes Publikum erreichen und es mit Informationen ansprechen, die in einer Präsentation sonst als mühselig empfunden werden könnten. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und diese allgemein bevorzugen.

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), haben wir die Unterstützung für die Konvertierung von Präsentationen in Videos implementiert. 

* Verwenden Sie Aspose.Slides, um einen Satz von Frames (aus den Präsentationsfolien) zu erzeugen, die einer bestimmten FPS (Bilder pro Sekunde) entsprechen
* Verwenden Sie ein Drittanbieter‑Tool wie `ffmpeg`, um basierend auf den Frames ein Video zu erstellen.

## **Eine PowerPoint‑Präsentation in ein Video konvertieren**

1. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.
2. Fügen Sie den Pfad zu `ffmpeg.exe` der Umgebungsvariable `PATH` hinzu.
3. Führen Sie den PowerPoint‑zu‑Video‑Code aus.

Dieser C++‑Code zeigt, wie Sie eine Präsentation (mit einer Abbildung und zwei Animationseffekten) in ein Video konvertieren:
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

    // Fügt ein Smiley-Shape hinzu und animiert es dann
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

Vielleicht möchten Sie diese Artikel lesen: [PowerPoint‑Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Form‑Animation](https://docs.aspose.com/slides/cpp/shape-animation/), und [Formeffekt](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie bewirken dasselbe bei Videos. Fügen wir dem Code der vorherigen Präsentation eine weitere Folie und einen Übergang hinzu:
```c++
// Fügt ein Smiley-Shape hinzu und animiert es

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


Aspose.Slides unterstützt auch Textanimationen. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):
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

    // Konvertiert Frames in ein Video
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

Damit Sie PowerPoint‑zu‑Video‑Konvertierungsaufgaben ausführen können, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) und [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) bereit.

PresentationAnimationsGenerator ermöglicht es Ihnen, über den Konstruktor die Frame‑Größe für das später zu erstellende Video festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es werden Animationen erzeugt, die [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) nutzt. 

Wenn Animationen erzeugt werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis erzeugt, das den Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) enthält. Letzteres ist eine Klasse, die einen Player für eine einzelne Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) zu arbeiten, werden die Eigenschaft [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und anschließend gibt die `GetFrame`‑Methode ein Bitmap zurück, das dem Animationszustand zu diesem Zeitpunkt entspricht.
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

    // Fügt ein Smiley-Shape hinzu und animiert es
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


Um alle Animationen einer Präsentation gleichzeitig abzuspielen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) und die FPS für Effekte entgegen und ruft anschließend das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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


Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eintritt**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Fly In** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Float In** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wheel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Grow & Turn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Swivel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bounce** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Hervorhebung**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Color Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Teeter** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Spin** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Grow/Shrink** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Desaturate** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Darken** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Lighten** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Transparency** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Object Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Complementary Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Line Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fill Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Verlassen**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Fly Out** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Float Out** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shrink & Turn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Swivel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bounce** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungspfade:**

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Arcs** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Turns** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shapes** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Loops** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Custom Path** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides ermöglicht die Arbeit mit [passwortgeschützten Präsentationen](/slides/de/cpp/password-protected-presentation/). Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides die Verwendung in Cloud‑Lösungen?**

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Dienste integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?**

Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird gelegentlich empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.