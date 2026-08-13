---
title: "Konwertuj prezentacje PowerPoint na wideo w C++"
linktitle: "PowerPoint na wideo"
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
- PowerPoint na MP4
- prezentacja na MP4
- PPT na MP4
- PPTX na MP4
- zapisz PPT jako MP4
- zapisz PPTX jako MP4
- eksportuj PPT do MP4
- eksportuj PPTX do MP4
- konwersja wideo
- PowerPoint
- C++
- Aspose.Slides
description: "Dowiedz się, jak konwertować prezentacje PowerPoint na wideo w C++. Odkryj przykładowy kod i techniki automatyzacji, aby usprawnić swój przepływ pracy."
---
## **Wstęp**

Konwertując prezentację PowerPoint na wideo, uzyskujesz  

* **Zwiększoną dostępność:** Wszystkie urządzenia (niezależnie od platformy) mają domyślnie odtwarzacze wideo, w przeciwieństwie do aplikacji otwierających prezentacje, więc użytkownikom łatwiej jest otworzyć lub odtworzyć wideo.  
* **Większy zasięg:** Dzięki wideo możesz dotrzeć do szerokiej publiczności i przedstawić informacje, które w prezentacji mogłyby wydawać się nużące. Większość ankiet i statystyk wskazuje, że ludzie częściej oglądają i konsumują wideo niż inne formy treści i zazwyczaj wolą taki format.

W [Aspose.Slides 22.11](https://docs.aspose.com/slides/pl/cpp/aspose-slides-for-cpp-22-11-release-notes/), wprowadziliśmy obsługę konwersji prezentacji na wideo.  

* Użyj Aspose.Slides do wygenerowania zestawu klatek (z slajdów prezentacji), które odpowiadają określonej liczbie FPS (klatek na sekundę)  
* Skorzystaj z narzędzia zewnętrznego, takiego jak `ffmpeg`, aby utworzyć wideo na podstawie tych klatek.

## **Konwertuj prezentację PowerPoint na wideo**

1. Pobierz ffmpeg [tutaj](https://ffmpeg.org/download.html).  
2. Dodaj ścieżkę do `ffmpeg.exe` do zmiennej środowiskowej `PATH`.  
3. Uruchom kod konwertujący PowerPoint na wideo.

Poniższy kod C++ pokazuje, jak skonwertować prezentację (zawierającą rysunek i dwa efekty animacji) na wideo:

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Dodaje kształt uśmiechu i następnie animuje go
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
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Efekty wideo**

Możesz stosować animacje do obiektów na slajdach oraz używać przejść między slajdami.

{{% alert color="info" %}} 

Może Cię zainteresować: [PowerPoint Animation](https://docs.aspose.com/slides/pl/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/pl/cpp/shape-animation/), oraz [Shape Effect](https://docs.aspose.com/slides/pl/cpp/shape-effect/).

{{% /alert %}} 

Animacje i przejścia sprawiają, że pokazy slajdów są bardziej wciągające i interesujące — to samo dotyczy wideo. Dodajmy kolejny slajd i przejście do kodu poprzedniej prezentacji:

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// Dodaje kształt uśmiechu i animuje go, jak pokazano powyżej
auto presentation = System::MakeObject<Presentation>();

// Dodaje nowy slajd i animowane przejście

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides obsługuje także animację tekstu. Animujemy więc akapity na obiektach, które będą pojawiały się kolejno (z opóźnieniem ustawionym na jedną sekundę):

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

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
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Klasy konwersji wideo**

Aby umożliwić wykonywanie zadań konwersji PowerPoint na wideo, Aspose.Slides udostępnia klasy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_animations_generator/) i [PresentationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator pozwala ustawić rozmiar klatki wideo (które zostanie później utworzone) poprzez konstruktor. Jeśli przekażesz instancję prezentacji, zostanie użyty `Presentation.SlideSize`, a generowane animacje będą wykorzystywane przez [PresentationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.presentation_player/).  

Podczas generowania animacji generowane jest zdarzenie `NewAnimation` dla każdej kolejnej animacji, które przyjmuje parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player/). Klasa ta reprezentuje odtwarzacz pojedynczej animacji.

Aby pracować z [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player/), używa się właściwości [get_Duration](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (pełny czas trwania animacji) oraz metody [SetTimePosition](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Każda pozycja animacji jest ustawiana w zakresie *0 do duration*, a następnie metoda `GetFrame` zwróci bitmapę odpowiadającą stanowi animacji w danym momencie.

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // początkowy stan animacji
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // bitmapa początkowego stanu animacji

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // końcowy stan animacji
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // ostatnia klatka animacji
    lastImage->Save(u"last.png");
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Wygenerowane klatki mogą następnie zostać skompilowane w celu utworzenia wideo. Zobacz sekcję [Convert PowerPoint to Video](https://docs.aspose.com/slides/pl/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Obsługiwane animacje i efekty**


**Wejście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pojawienie się** | ![not supported](x.png) | ![supported](v.png) |
| **Zanik** | ![supported](v.png) | ![supported](v.png) |
| **Przylot** | ![supported](v.png) | ![supported](v.png) |
| **Unoszenie się** | ![supported](v.png) | ![supported](v.png) |
| **Podział** | ![supported](v.png) | ![supported](v.png) |
| **Zmazywanie** | ![supported](v.png) | ![supported](v.png) |
| **Kształt** | ![supported](v.png) | ![supported](v.png) |
| **Koło** | ![supported](v.png) | ![supported](v.png) |
| **Losowe paski** | ![supported](v.png) | ![supported](v.png) |
| **Rozwijanie i obrót** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Obrót** | ![supported](v.png) | ![supported](v.png) |
| **Odbicie** | ![supported](v.png) | ![supported](v.png) |


**Podkreślenie**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | ![not supported](x.png) | ![supported](v.png) |
| **Puls kolorystyczny** | ![not supported](x.png) | ![supported](v.png) |
| **Kołysanie** | ![supported](v.png) | ![supported](v.png) |
| **Obrót** | ![supported](v.png) | ![supported](v.png) |
| **Rozrastanie/Zmniejszanie** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturacja** | ![not supported](x.png) | ![supported](v.png) |
| **Przyciemnianie** | ![not supported](x.png) | ![supported](v.png) |
| **Rozjaśnianie** | ![not supported](x.png) | ![supported](v.png) |
| **Przezroczystość** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor obiektu** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor uzupełniający** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor linii** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor wypełnienia** | ![not supported](x.png) | ![supported](v.png) |

**Wyjście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Zniknięcie** | ![not supported](x.png) | ![supported](v.png) |
| **Zanik** | ![supported](v.png) | ![supported](v.png) |
| **Wylot** | ![supported](v.png) | ![supported](v.png) |
| **Unoszenie się na zewnątrz** | ![supported](v.png) | ![supported](v.png) |
| **Podział** | ![supported](v.png) | ![supported](v.png) |
| **Zmazywanie** | ![supported](v.png) | ![supported](v.png) |
| **Kształt** | ![supported](v.png) | ![supported](v.png) |
| **Losowe paski** | ![supported](v.png) | ![supported](v.png) |
| **Kurczenie i obrót** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Obrót** | ![supported](v.png) | ![supported](v.png) |
| **Odbicie** | ![supported](v.png) | ![supported](v.png) |

**Ścieżki ruchu**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linie** | ![supported](v.png) | ![supported](v.png) |
| **Łuki** | ![supported](v.png) | ![supported](v.png) |
| **Zwroty** | ![supported](v.png) | ![supported](v.png) |
| **Kształty** | ![supported](v.png) | ![supported](v.png) |
| **Pętle** | ![supported](v.png) | ![supported](v.png) |
| **Ścieżka niestandardowa** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Czy można konwertować prezentacje zabezpieczone hasłem?

Tak, Aspose.Slides umożliwia pracę z [prezentacjami zabezpieczonymi hasłem](/slides/pl/cpp/password-protected-presentation/). Przy przetwarzaniu takich plików należy podać poprawne hasło, aby biblioteka mogła uzyskać dostęp do zawartości prezentacji.

### Czy Aspose.Slides obsługuje użycie w rozwiązaniach chmurowych?

Tak, Aspose.Slides może być integrowany z aplikacjami i usługami w chmurze. Biblioteka jest zaprojektowana do pracy w środowiskach serwerowych, zapewniając wysoką wydajność i skalowalność przy przetwarzaniu partii plików.

### Czy istnieją ograniczenia rozmiaru prezentacji podczas konwersji?

Aspose.Slides radzi sobie z prezentacjami praktycznie dowolnego rozmiaru. Jednak przy bardzo dużych plikach mogą być potrzebne dodatkowe zasoby systemowe i czasami zaleca się optymalizację prezentacji w celu poprawy wydajności.