---
title: Konwertowanie prezentacji PowerPoint na animowane GIF‑y w C++
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
- ustawienia własne
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIF‑y przy użyciu Aspose.Slides dla C++. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint na animowane pliki GIF za pomocą kilku linijek kodu. Jest to przydatne, gdy musisz udostępnić zawartość slajdów w lekkim, szeroko wspieranym formacie animacji, który może być osadzony w stronach internetowych, komunikatorach lub dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację do formatu GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurując opcje takie jak rozmiar klatki, opóźnienie slajdu i częstotliwość przejść przy pomocy klasy [GifOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/gifoptions/).

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień domyślnych**

Poniższy przykładowy kod w C++ pokazuje, jak skonwertować prezentację do animowanego GIF przy użyciu standardowych ustawień:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Animowany GIF zostanie utworzony z parametrami domyślnymi. 

{{%  alert  title="Wskazówka"  color="primary"  %}} 
Jeśli wolisz dostosować parametry GIF, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.gif_options). Zobacz przykład kodu poniżej. 
{{% /alert %}} 

## **Konwertowanie prezentacji na animowany GIF przy użyciu własnych ustawień**

Przykładowy kod pokazuje, jak skonwertować prezentację do animowanego GIF przy użyciu własnych ustawień w C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// rozmiar wygenerowanego GIF
gifOptions->set_FrameSize(Size(960, 720));
// jak długo każdy slajd będzie wyświetlany, zanim zostanie zmieniony na następny
gifOptions->set_DefaultDelay(2000);
// zwiększ FPS, aby poprawić jakość animacji przejścia
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Informacja" color="info" %}}
Możesz zainteresować się bezpłatnym konwerterem [Tekst do GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowanym przez Aspose. 
{{% /alert %}}

## **FAQ**

**Co zrobić, gdy czcionki użyte w prezentacji nie są zainstalowane w systemie?**

Zainstaluj brakujące czcionki lub [skonfiguruj czcionki zastępcze](/slides/pl/cpp/powerpoint-fonts/). Aspose.Slides zastosuje zastępstwo, ale wygląd może się różnić. W przypadku identyfikacji marki zawsze upewnij się, że wymagane czcionki są dostępne.

**Czy mogę nałożyć znak wodny na klatki GIF-a?**

Tak. [Dodaj półprzezroczysty obiekt/logo](/slides/pl/cpp/watermark/) do slajdu głównego lub do poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.