---
title: Konwertuj prezentacje PowerPoint na animowane GIFy w C++
linktitle: PowerPoint do GIF
type: docs
weight: 65
url: /pl/cpp/convert-powerpoint-to-animated-gif/
keywords:
- animowany GIF
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do GIF
- prezentacja do GIF
- slajd do GIF
- PPT do GIF
- PPTX do GIF
- zapisz PPT jako GIF
- zapisz PPTX jako GIF
- eksportuj PPT jako GIF
- eksportuj PPTX jako GIF
- ustawienia domyślne
- ustawienia niestandardowe
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIFy za pomocą Aspose.Slides dla C++. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint na animowane pliki GIF za pomocą kilku wierszy kodu. Jest to przydatne, gdy potrzebujesz udostępnić zawartość slajdów w lekkim, powszechnie wspieranym formacie animacji, który można osadzać w stronach internetowych, komunikatorach lub dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację do formatu GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurując opcje takie jak rozmiar klatki, opóźnienie slajdu i częstotliwość klatek przejścia za pomocą [GifOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/gifoptions/).

## **Konwertuj prezentacje na animowany GIF przy użyciu ustawień domyślnych**

Poniższy przykładowy kod w C++ pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu standardowych ustawień:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Animowany GIF zostanie utworzony z domyślnymi parametrami.

{{%  alert  title="TIP"  color="info"  %}} 
Jeśli chcesz dostosować parametry GIF, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.gif_options). Zobacz przykładowy kod poniżej. 
{{% /alert %}} 

## **Konwertuj prezentacje na animowany GIF przy użyciu ustawień niestandardowych**

Poniższy przykładowy kod pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu niestandardowych ustawień w C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// rozmiar wynikowego GIF
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// jak długo każdy slajd będzie wyświetlany, aż zostanie zmieniony na kolejny
gifOptions->set_DefaultDelay(2000);
// zwiększ FPS, aby poprawić jakość animacji przejścia
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Możesz chcieć wypróbować DARMOWY konwerter [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowany przez Aspose. 
{{% /alert %}}

## **FAQ**

### Co zrobić, jeśli czcionki użyte w prezentacji nie są zainstalowane w systemie?

Zainstaluj brakujące czcionki lub [skonfiguruj czcionki zapasowe](/slides/pl/cpp/powerpoint-fonts/). Aspose.Slides podstawi brakujące, ale wygląd może się różnić. W kontekście brandingu zawsze upewnij się, że wymagane kroje są dostępne.

### Czy mogę nałożyć znak wodny na klatki GIF?

Tak. [Dodaj półprzezroczysty obiekt/logo](/slides/pl/cpp/watermark/) do slajdu master lub do poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.