---
title: Převod PowerPoint prezentací na video v C++
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/cpp/convert-powerpoint-to-video/
keywords:
- převést PowerPoint
- převést prezentaci
- převést PPT
- převést PPTX
- PowerPoint na video
- prezentace na video
- PPT na video
- PPTX na video
- PowerPoint na MP4
- prezentace na MP4
- PPT na MP4
- PPTX na MP4
- uložit PPT jako MP4
- uložit PPTX jako MP4
- exportovat PPT do MP4
- exportovat PPTX do MP4
- převod videa
- PowerPoint
- C++
- Aspose.Slides
description: "Zjistěte, jak převést PowerPoint prezentace na video v C++. Objevte ukázkový kód a automatizační techniky, které zjednoduší váš pracovní postup."
---
## **Úvod**

Převodem vaší PowerPoint prezentace na video získáte 

* **Zvýšení přístupnosti:** Všechna zařízení (bez ohledu na platformu) mají ve výchozím nastavení video přehrávače, na rozdíl od aplikací pro otevírání prezentací, takže uživatelům je snazší otevřít nebo přehrát videa.
* **Větší dosah:** Pomocí videí můžete oslovit široké publikum a cílit na ně s informacemi, které by jinak v prezentaci mohly působit nudně. Většina průzkumů a statistik naznačuje, že lidé sledují a konzumují videa více než jiné formy obsahu a obecně upřednostňují právě takový obsah.

V [Aspose.Slides 22.11](https://docs.aspose.com/slides/cs/cpp/aspose-slides-for-cpp-22-11-release-notes/) jsme implementovali podporu převodu prezentace na video. 

* Použijte Aspose.Slides k vygenerování sady snímků (z prezentace) odpovídajících určitému počtu FPS (snímků za sekundu).
* Použijte nástroj třetí strany jako `ffmpeg` k vytvoření videa na základě snímků.

## **Převod PowerPoint prezentace na video**

1. Stáhněte ffmpeg [zde](https://ffmpeg.org/download.html).
2. Přidejte cestu k `ffmpeg.exe` do proměnné prostředí `PATH`.
3. Spusťte kód pro převod PowerPointu na video.

Tento C++ kód vám ukazuje, jak převést prezentaci (obsahující obrázek a dva animační efekty) na video:

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

    // Přidá smajlík a následně jej animuje
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

## **Video efekty**

Můžete aplikovat animace na objekty na snímcích a použít přechody mezi snímky.

{{% alert color="primary" %}} 

Možná budete chtít zobrazit tyto články: [PowerPoint Animation](https://docs.aspose.com/slides/cs/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cs/cpp/shape-animation/), a [Shape Effect](https://docs.aspose.com/slides/cs/cpp/shape-effect/).

{{% /alert %}} 

Animace a přechody činí prezentace poutavějšími a zajímavějšími – a totéž platí i pro videa. Přidejme další snímek a přechod do kódu pro předchozí prezentaci:

```c++
// Přidá tvar smajlíka a animuje jej

// ...

// Přidá nový snímek a animovaný přechod

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides také podporuje animaci pro texty. Proto animujeme odstavce na objektech, které se objeví jeden po druhém (s prodlevou nastavenou na sekundu):

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

    // Přidá text a animace
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

    // Převede snímky na video
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

## **Třídy pro převod videa**

Aby vám umožnil provádět úkoly převodu PowerPointu na video, Aspose.Slides poskytuje třídy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.presentation_animations_generator/) a [PresentationPlayer](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator vám umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) prostřednictvím svého konstruktoru. Pokud předáte instanci prezentace, použije se `Presentation.SlideSize` a generuje animace, které používá [PresentationPlayer](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.presentation_player/). 

Když jsou animace generovány, pro každou další animaci je vytvořena událost `NewAnimation`, která má parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.i_presentation_animation_player/). Poslední představuje třídu, která představuje přehrávač pro samostatnou animaci.

Pro práci s [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.i_presentation_animation_player/) se používá vlastnost [get_Duration](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (celková délka animace) a metoda [SetTimePosition](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Každá pozice animace je nastavena v rozmezí *0 až délka*, a pak metoda `GetFrame` vrátí Bitmap odpovídající stavu animace v daném okamžiku.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // počáteční stav animace
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmapa počátečního stavu animace

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // konečný stav animace
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // poslední snímek animace
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Přidá tvar smajlíka a animuje jej
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

Pro přehrání všech animací v prezentaci najednou se používá třída [PresentationPlayer](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.presentation_player/). Tato třída přijímá v konstruktoru instanci [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.presentation_animations_generator/) a FPS pro efekty a následně volá událost `FrameTick` pro všechny animace, aby byly přehrány:

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

Poté lze vygenerované snímky sestavit do videa. Viz sekce [Convert PowerPoint to Video](https://docs.aspose.com/slides/cs/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Podporované animace a efekty**

**Vstup**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Zdůraznění**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Ukončení**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Cesty pohybu:**

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Je možné převádět prezentace chráněné heslem?**

Ano, Aspose.Slides umožňuje práci s [prezentacemi chráněnými heslem](/slides/cs/cpp/password-protected-presentation/). Při zpracování takových souborů je třeba zadat správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

**Podporuje Aspose.Slides použití v cloudových řešeních?**

Ano, Aspose.Slides lze integrovat do cloudových aplikací a služeb. Knihovna je navržena tak, aby fungovala v serverových prostředích, zajišťuje vysoký výkon a škálovatelnost při hromadném zpracování souborů.

**Existují omezení velikosti prezentací při převodu?**

Aspose.Slides dokáže zpracovat prezentace téměř jakékoli velikosti. Při práci s velmi velkými soubory však mohou být zapotřebí další systémové prostředky a někdy se doporučuje prezentaci optimalizovat pro zlepšení výkonu.