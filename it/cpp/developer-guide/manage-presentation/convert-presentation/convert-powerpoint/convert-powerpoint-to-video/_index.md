---
title: Converti presentazioni PowerPoint in video in C++
linktitle: PowerPoint in video
type: docs
weight: 130
url: /it/cpp/convert-powerpoint-to-video/
keywords:
- converti PowerPoint
- converti presentazione
- converti PPT
- converti PPTX
- PowerPoint in video
- presentazione in video
- PPT in video
- PPTX in video
- PowerPoint in MP4
- presentazione in MP4
- PPT in MP4
- PPTX in MP4
- salva PPT come MP4
- salva PPTX come MP4
- esporta PPT in MP4
- esporta PPTX in MP4
- conversione video
- PowerPoint
- C++
- Aspose.Slides
description: "Scopri come convertire le presentazioni PowerPoint in video con C++. Scopri il codice di esempio e le tecniche di automazione per semplificare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint in video, ottieni 

* **Aumento dell'accessibilità:** Tutti i dispositivi (indipendentemente dalla piattaforma) sono dotati di lettori video di default rispetto alle applicazioni di apertura delle presentazioni, quindi gli utenti trovano più facile aprire o riprodurre i video.
* **Maggiore portata:** Attraverso i video, puoi raggiungere un ampio pubblico e indirizzarlo con informazioni che altrimenti potrebbero sembrare noiose in una presentazione. La maggior parte di sondaggi e statistiche suggerisce che le persone guardano e consumano video più di altre forme di contenuto, e generalmente preferiscono tali contenuti.

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/it/cpp/aspose-slides-for-cpp-22-11-release-notes/), abbiamo implementato il supporto per la conversione di presentazioni in video. 

* Usa Aspose.Slides per generare un insieme di fotogrammi (dalle diapositive della presentazione) che corrispondono a un determinato FPS (fotogrammi al secondo)
* Usa un'utilità di terze parti come `ffmpeg` per creare un video basato sui fotogrammi.

## **Convertire una presentazione PowerPoint in video**

1. Scarica ffmpeg [qui](https://ffmpeg.org/download.html).
2. Aggiungi il percorso di `ffmpeg.exe` alla variabile d'ambiente `PATH`.
3. Esegui il codice di conversione da PowerPoint a video.

Questo codice C++ mostra come convertire una presentazione (contenente una figura e due effetti di animazione) in un video:

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

    // Aggiunge una forma a sorriso e poi la anima
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

## **Effetti video**

Puoi applicare animazioni agli oggetti nelle diapositive e utilizzare transizioni tra le diapositive.

{{% alert color="primary" %}} 

Potresti voler consultare questi articoli: [Animazione PowerPoint](https://docs.aspose.com/slides/it/cpp/powerpoint-animation/), [Animazione forma](https://docs.aspose.com/slides/it/cpp/shape-animation/), e [Effetto forma](https://docs.aspose.com/slides/it/cpp/shape-effect/).

{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti—e fanno lo stesso per i video. Aggiungiamo un'altra diapositiva e transizione al codice per la presentazione precedente:

```c++
// Aggiunge una forma a sorriso e la anima

// ...

// Aggiunge una nuova diapositiva e una transizione animata

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides supporta anche l'animazione per i testi. Quindi animiamo i paragrafi sugli oggetti, che appariranno uno dopo l'altro (con il ritardo impostato a un secondo):

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

    // Aggiunge testo e animazioni
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

    // Converte i fotogrammi in video
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

## **Classi di conversione video**

Per consentirti di eseguire operazioni di conversione da PowerPoint a video, Aspose.Slides fornisce le classi [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.presentation_animations_generator/) e [PresentationPlayer](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator consente di impostare la dimensione del fotogramma per il video (che sarà creato in seguito) tramite il suo costruttore. Se passi un'istanza della presentazione, verrà utilizzato `Presentation.SlideSize` e genera animazioni che [PresentationPlayer](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.presentation_player/) utilizza.

Quando le animazioni vengono generate, viene generato un evento `NewAnimation` per ogni animazione successiva, che ha il parametro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.i_presentation_animation_player/). Quest'ultimo è una classe che rappresenta un lettore per un'animazione separata.

Per lavorare con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.i_presentation_animation_player/), si utilizzano la proprietà [get_Duration](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (la durata completa dell'animazione) e il metodo [SetTimePosition](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Ogni posizione dell'animazione è impostata nell'intervallo *0 a durata*, e quindi il metodo `GetFrame` restituisce un Bitmap che corrisponde allo stato dell'animazione in quel momento.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // stato iniziale dell'animazione
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap dello stato iniziale dell'animazione

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // stato finale dell'animazione
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // ultimo fotogramma dell'animazione
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Aggiunge una forma a sorriso e la anima
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

Per far riprodurre tutte le animazioni di una presentazione contemporaneamente, si utilizza la classe [PresentationPlayer](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.presentation_player/). Questa classe riceve un'istanza di [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.presentation_animations_generator/) e gli FPS per gli effetti nel suo costruttore, quindi chiama l'evento `FrameTick` per tutte le animazioni per farle riprodurre:

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

Successivamente i fotogrammi generati possono essere compilati per produrre un video. Vedi la sezione [Convert PowerPoint to Video](https://docs.aspose.com/slides/it/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animazioni e effetti supportati**

**Ingresso**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fade** | ![supportato](v.png) | ![supportato](v.png) |
| **Fly In** | ![supportato](v.png) | ![supportato](v.png) |
| **Float In** | ![supportato](v.png) | ![supportato](v.png) |
| **Split** | ![supportato](v.png) | ![supportato](v.png) |
| **Wipe** | ![supportato](v.png) | ![supportato](v.png) |
| **Shape** | ![supportato](v.png) | ![supportato](v.png) |
| **Wheel** | ![supportato](v.png) | ![supportato](v.png) |
| **Random Bars** | ![supportato](v.png) | ![supportato](v.png) |
| **Grow & Turn** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Swivel** | ![supportato](v.png) | ![supportato](v.png) |
| **Bounce** | ![supportato](v.png) | ![supportato](v.png) |

**Enfasi**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![non supportato](x.png) | ![supportato](v.png) |
| **Color Pulse** | ![non supportato](x.png) | ![supportato](v.png) |
| **Teeter** | ![supportato](v.png) | ![supportato](v.png) |
| **Spin** | ![supportato](v.png) | ![supportato](v.png) |
| **Grow/Shrink** | ![non supportato](x.png) | ![supportato](v.png) |
| **Desaturate** | ![non supportato](x.png) | ![supportato](v.png) |
| **Darken** | ![non supportato](x.png) | ![supportato](v.png) |
| **Lighten** | ![non supportato](x.png) | ![supportato](v.png) |
| **Transparency** | ![non supportato](x.png) | ![supportato](v.png) |
| **Object Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Complementary Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Line Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fill Color** | ![non supportato](x.png) | ![supportato](v.png) |

**Uscita**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fade** | ![supportato](v.png) | ![supportato](v.png) |
| **Fly Out** | ![supportato](v.png) | ![supportato](v.png) |
| **Float Out** | ![supportato](v.png) | ![supportato](v.png) |
| **Split** | ![supportato](v.png) | ![supportato](v.png) |
| **Wipe** | ![supportato](v.png) | ![supportato](v.png) |
| **Shape** | ![supportato](v.png) | ![supportato](v.png) |
| **Random Bars** | ![supportato](v.png) | ![supportato](v.png) |
| **Shrink & Turn** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Swivel** | ![supportato](v.png) | ![supportato](v.png) |
| **Bounce** | ![supportato](v.png) | ![supportato](v.png) |

**Percorsi di movimento**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supportato](v.png) | ![supportato](v.png) |
| **Arcs** | ![supportato](v.png) | ![supportato](v.png) |
| **Turns** | ![supportato](v.png) | ![supportato](v.png) |
| **Shapes** | ![supportato](v.png) | ![supportato](v.png) |
| **Loops** | ![supportato](v.png) | ![supportato](v.png) |
| **Custom Path** | ![supportato](v.png) | ![supportato](v.png) |

## **FAQ**

**È possibile convertire presentazioni protette da password?**

Sì, Aspose.Slides consente di lavorare con [presentazioni protette da password](/slides/it/cpp/password-protected-presentation/). Durante l'elaborazione di tali file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

**Aspose.Slides supporta l'utilizzo in soluzioni cloud?**

Sì, Aspose.Slides può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo elevate prestazioni e scalabilità per l'elaborazione batch di file.

**Ci sono limiti di dimensione per le presentazioni durante la conversione?**

Aspose.Slides è in grado di gestire presentazioni di dimensioni praticamente illimitate. Tuttavia, quando si lavora con file molto grandi, potrebbero essere necessarie risorse di sistema aggiuntive, e talvolta è consigliabile ottimizzare la presentazione per migliorare le prestazioni.