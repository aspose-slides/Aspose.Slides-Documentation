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
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in C++ in Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

## **Übersicht**

Durch die Konvertierung Ihrer PowerPoint-Präsentation in ein Video erhalten Sie 

* **Steigerung der Barrierefreiheit:** Alle Geräte (unabhängig vom Betriebssystem) verfügen standardmäßig über Videoplayer im Vergleich zu Anwendungen zum Öffnen von Präsentationen, sodass Benutzer Videos leichter öffnen oder abspielen können.
* **Größere Reichweite:** Mit Videos können Sie ein breites Publikum erreichen und es mit Informationen ansprechen, die in einer Präsentation sonst langweilig wirken könnten. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und sie im Allgemeinen bevorzugen.

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/) haben wir die Unterstützung für die Konvertierung von Präsentationen in Videos implementiert. 

* Verwenden Sie Aspose.Slides, um einen Satz von Bildern (aus den Präsentationsfolien) zu erzeugen, die einer bestimmten FPS (Bilder pro Sekunde) entsprechen
* Verwenden Sie ein Drittanbieter-Tool wie `ffmpeg`, um aus den Bildern ein Video zu erstellen.

## **PowerPoint-Präsentation in Video konvertieren**

1. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.
2. Fügen Sie den Pfad zu `ffmpeg.exe` der Umgebungsvariable `PATH` hinzu.
3. Führen Sie den PowerPoint-zu-Video-Code aus.

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

    // Fügt eine Smiley‑Form hinzu und animiert sie anschließend
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

Vielleicht möchten Sie diese Artikel sehen: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/), und [Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie bewirken dasselbe bei Videos. Fügen wir dem Code für die vorherige Präsentation eine weitere Folie und einen Übergang hinzu:
```c++
// Fügt eine Smiley-Form hinzu und animiert sie

// ...

// Fügt eine neue Folie hinzu und animierten Übergang

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides unterstützt auch Animationen für Texte. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):
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


## **Klassen für die Videokonvertierung**

Um Ihnen die Durchführung von PowerPoint-zu-Video-Konvertierungsaufgaben zu ermöglichen, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) und [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) bereit.

PresentationAnimationsGenerator ermöglicht es Ihnen, über seinen Konstruktor die Bildgröße für das später erstellte Video festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es erzeugt Animationen, die [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) nutzt.

Wenn Animationen erzeugt werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis mit dem Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) erzeugt. Letzteres ist eine Klasse, die einen Player für eine einzelne Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) zu arbeiten, werden die Eigenschaft [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und die Methode `GetFrame` gibt ein Bitmap zurück, das dem Animationszustand zu diesem Zeitpunkt entspricht.
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


Um alle Animationen in einer Präsentation gleichzeitig abzuspielen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) und FPS für die Effekte entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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


Anschließend können die erzeugten Bilder zu einem Video zusammengeführt werden. Siehe den Abschnitt [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eingang**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Erscheinen** | ![not supported](x.png) | ![supported](v.png) |
| **Einblenden** | ![supported](v.png) | ![supported](v.png) |
| **Einfliegen** | ![supported](v.png) | ![supported](v.png) |
| **Schweben herein** | ![supported](v.png) | ![supported](v.png) |
| **Teilen** | ![supported](v.png) | ![supported](v.png) |
| **Wischen** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Rad** | ![supported](v.png) | ![supported](v.png) |
| **Zufällige Balken** | ![supported](v.png) | ![supported](v.png) |
| **Wachsen & Drehen** | ![not supported](x.png) | ![supported](v.png) |
| **Zoomen** | ![supported](v.png) | ![supported](v.png) |
| **Schwenken** | ![supported](v.png) | ![supported](v.png) |
| **Abprallen** | ![supported](v.png) | ![supported](v.png) |

**Betonung**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | ![not supported](x.png) | ![supported](v.png) |
| **Farbpuls** | ![not supported](x.png) | ![supported](v.png) |
| **Wackeln** | ![supported](v.png) | ![supported](v.png) |
| **Drehen** | ![supported](v.png) | ![supported](v.png) |
| **Wachsen/Schrumpfen** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturieren** | ![not supported](x.png) | ![supported](v.png) |
| **Verdunkeln** | ![not supported](x.png) | ![supported](v.png) |
| **Aufhellen** | ![not supported](x.png) | ![supported](v.png) |
| **Transparenz** | ![not supported](x.png) | ![supported](v.png) |
| **Objektfarbe** | ![not supported](x.png) | ![supported](v.png) |
| **Komplementärfarbe** | ![not supported](x.png) | ![supported](v.png) |
| **Linienfarbe** | ![not supported](x.png) | ![supported](v.png) |
| **Füllfarbe** | ![not supported](x.png) | ![supported](v.png) |

**Ausgang**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschwinden** | ![not supported](x.png) | ![supported](v.png) |
| **Ausblenden** | ![supported](v.png) | ![supported](v.png) |
| **Ausfliegen** | ![supported](v.png) | ![supported](v.png) |
| **Schweben hinaus** | ![supported](v.png) | ![supported](v.png) |
| **Teilen** | ![supported](v.png) | ![supported](v.png) |
| **Wischen** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Zufällige Balken** | ![supported](v.png) | ![supported](v.png) |
| **Schrumpfen & Drehen** | ![not supported](x.png) | ![supported](v.png) |
| **Zoomen** | ![supported](v.png) | ![supported](v.png) |
| **Schwenken** | ![supported](v.png) | ![supported](v.png) |
| **Abprallen** | ![supported](v.png) | ![supported](v.png) |

**Bewegungswege:**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linien** | ![supported](v.png) | ![supported](v.png) |
| **Bögen** | ![supported](v.png) | ![supported](v.png) |
| **Drehungen** | ![supported](v.png) | ![supported](v.png) |
| **Formen** | ![supported](v.png) | ![supported](v.png) |
| **Schleifen** | ![supported](v.png) | ![supported](v.png) |
| **Benutzerdefinierter Pfad** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides ermöglicht die Arbeit mit [passwortgeschützten Präsentationen](/slides/de/cpp/password-protected-presentation/). Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides die Verwendung in Cloud-Lösungen?**

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Dienste integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen bei der Konvertierung?**

Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird häufig empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.