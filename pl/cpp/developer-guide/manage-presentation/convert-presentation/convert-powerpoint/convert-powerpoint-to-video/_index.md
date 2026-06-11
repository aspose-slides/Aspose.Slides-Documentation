---
title: Konwertuj prezentacje PowerPoint na wideo w C++
linktitle: PowerPoint na wideo
type: docs
weight: 130
url: /pl/cpp/convert-powerpoint-to-video/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na wideo
- prezentacja na wideo
- PPT na wideo
- PPTX na wideo
- PowerPoint do MP4
- prezentacja do MP4
- PPT do MP4
- PPTX do MP4
- zapisz PPT jako MP4
- zapisz PPTX jako MP4
- eksportuj PPT do MP4
- eksportuj PPTX do MP4
- konwersja wideo
- PowerPoint
- C++
- Aspose.Slides
description: "Dowiedz się, jak konwertować prezentacje PowerPoint na wideo w C++. Odkryj przykładowy kod i techniki automatyzacji ułatwiające twój proces pracy."
---
## **Wprowadzenie**

Konwertując prezentację PowerPoint na wideo, zyskujesz  

* **Zwiększenie dostępności:** Wszystkie urządzenia (bez względu na platformę) mają domyślnie odtwarzacze wideo, w przeciwieństwie do aplikacji otwierających prezentacje, więc użytkownikom łatwiej jest otworzyć lub odtworzyć wideo.  
* **Większy zasięg:** Dzięki wideo możesz dotrzeć do dużej publiczności i przedstawić informacje, które w tradycyjnej prezentacji mogą wydać się nużące. Większość badań i statystyk wskazuje, że ludzie częściej oglądają i konsumują wideo niż inne formy treści i zazwyczaj wolą właśnie taką formę.

W [Aspose.Slides 22.11](https://docs.aspose.com/slides/pl/cpp/aspose-slides-for-cpp-22-11-release-notes/) wprowadziliśmy obsługę konwersji prezentacji na wideo.  

* Użyj Aspose.Slides do wygenerowania zestawu klatek (z slajdów prezentacji) odpowiadających określonemu FPS (klatki na sekundę)  
* Użyj zewnętrznego narzędzia, takiego jak `ffmpeg`, aby stworzyć wideo na podstawie klatek.

## **Konwersja prezentacji PowerPoint na wideo**

1. Pobierz ffmpeg [tutaj](https://ffmpeg.org/download.html).  
2. Dodaj ścieżkę do `ffmpeg.exe` do zmiennej środowiskowej `PATH`.  
3. Uruchom kod konwertujący PowerPoint na wideo.

Poniższy kod C++ pokazuje, jak przekonwertować prezentację (z figurą i dwoma efektami animacji) na wideo:

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

    // Dodaje kształt uśmiechu, a następnie animuje go
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

## **Efekty wideo**

Możesz stosować animacje do obiektów na slajdach oraz przejścia między slajdami.

{{% alert color="primary" %}} 

Możesz chcieć zobaczyć te artykuły: [Animacja PowerPoint](https://docs.aspose.com/slides/pl/cpp/powerpoint-animation/), [Animacja kształtu](https://docs.aspose.com/slides/pl/cpp/shape-animation/), oraz [Efekt kształtu](https://docs.aspose.com/slides/pl/cpp/shape-effect/).

{{% /alert %}} 

Animacje i przejścia czynią pokazy slajdów bardziej angażującymi i interesującymi — tak samo jest z wideo. Dodajmy kolejny slajd i przejście do kodu poprzedniej prezentacji:

```c++
// Dodaje kształt uśmiechu i animuje go

// ...

// Dodaje nowy slajd i animowane przejście

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides obsługuje również animację tekstu. Animujemy więc akapity na obiektach, które pojawią się kolejno (z opóźnieniem ustawionym na sekundę):

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

    // Dodaje tekst i animacje
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

    // Konwertuje klatki na wideo
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

## **Klasy konwersji wideo**

Aby umożliwić konwersję PowerPoint na wideo, Aspose.Slides udostępnia klasy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_animations_generator/) oraz [PresentationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator pozwala ustawić rozmiar klatek wideo (które zostanie później utworzone) poprzez konstruktor. Jeśli przekażesz instancję prezentacji, zostanie użyty `Presentation.SlideSize` i zostaną wygenerowane animacje, które wykorzystuje [PresentationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_player/).  

Podczas generowania animacji dla każdej kolejnej animacji wywoływane jest zdarzenie `NewAnimation` z parametrem [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player/). To ostatnia klasa reprezentująca odtwarzacz pojedynczej animacji.

Do pracy z [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player/) używa się właściwości [get_Duration](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (pełny czas trwania animacji) oraz metody [SetTimePosition](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Każda pozycja animacji jest ustawiana w zakresie *0‑do‑czas trwania*, a metoda `GetFrame` zwraca bitmapę odpowiadającą stanowi animacji w danym momencie.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // początkowy stan animacji
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmapa początkowego stanu animacji

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // ostateczny stan animacji
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // ostatnia klatka animacji
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Dodaje kształt uśmiechu i animuje go
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

Aby wszystkie animacje w prezentacji odtwarzały się jednocześnie, używa się klasy [PresentationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_player/). Klasa ta przyjmuje w konstruktorze instancję [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_animations_generator/) oraz FPS dla efektów, a następnie wywołuje zdarzenie `FrameTick` dla wszystkich animacji, aby je odtworzyć:

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

Wygenerowane klatki można następnie złożyć w wideo. Zobacz sekcję [Convert PowerPoint to Video](https://docs.aspose.com/slides/pl/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Obsługiwane animacje i efekty**

**Wejście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pojawienie się** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Zanikanie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Przelot** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Unoszenie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Rozdzielenie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Zetrzycie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Kształt** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Koło** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Losowe paski** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Rozrastaj i obróć** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Zbliżenie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Obrót w miejscu** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Odbicie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |

**Nacisk**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulsowanie** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Pulsowanie koloru** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Drżenie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Obrót** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Rozrastaj/kurcz** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Desaturacja** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Przyciemnianie** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Rozjaśnianie** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Przezroczystość** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Kolor obiektu** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Kolor dopełniający** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Kolor linii** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Kolor wypełnienia** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |

**Wyjście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Zniknięcie** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Zanikanie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Wylot** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Unoszenie na zewnątrz** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Rozdzielenie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Zetrzycie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Kształt** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Losowe paski** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Kurcz i obróć** | ![nieobsługiwane](x.png) | ![obsługiwane](v.png) |
| **Zbliżenie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Obrót w miejscu** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Odbicie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |

**Ścieżki ruchu**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linie** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Łuki** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Skręty** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Kształty** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Pętle** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |
| **Ścieżka niestandardowa** | ![obsługiwane](v.png) | ![obsługiwane](v.png) |

## **FAQ**

**Czy możliwe jest konwertowanie prezentacji chronionych hasłem?**

Tak, Aspose.Slides umożliwia pracę z [prezentacjami chronionymi hasłem](/slides/pl/cpp/password-protected-presentation/). Podczas przetwarzania takich plików należy podać właściwe hasło, aby biblioteka mogła uzyskać dostęp do zawartości prezentacji.

**Czy Aspose.Slides wspiera zastosowanie w rozwiązaniach chmurowych?**

Tak, Aspose.Slides może być integrowany w aplikacjach i usługach chmurowych. Biblioteka jest zaprojektowana do pracy w środowiskach serwerowych, zapewniając wysoką wydajność i skalowalność przy przetwarzaniu plików wsadowo.

**Czy istnieją ograniczenia rozmiaru prezentacji podczas konwersji?**

Aspose.Slides radzi sobie z prezentacjami praktycznie każdego rozmiaru. Jednak przy bardzo dużych plikach mogą być potrzebne dodatkowe zasoby systemowe i czasami zaleca się optymalizację prezentacji w celu poprawy wydajności.