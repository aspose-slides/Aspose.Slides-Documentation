---
title: Konwertuj prezentacje PowerPoint na animowane GIF-y w .NET
linktitle: PowerPoint do GIF
type: docs
weight: 65
url: /pl/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIF-y za pomocą Aspose.Slides dla .NET. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint na animowane pliki GIF przy użyciu kilku linijek kodu. Jest to przydatne, gdy trzeba udostępnić treść slajdów w lekkim, powszechnie obsługiwanym formacie animowanym, który można osadzić w stronach internetowych, komunikatorach lub dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację do GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurując opcje takie jak rozmiar klatki, opóźnienie slajdu i częstotliwość klatek przejścia za pośrednictwem [GifOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/gifoptions/).

## **Konwertowanie prezentacji do animowanego GIF przy użyciu ustawień domyślnych**

Ten przykładowy kod w C# pokazuje, jak konwertować prezentację do animowanego GIF przy użyciu standardowych ustawień:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Animowany GIF zostanie utworzony z parametrami domyślnymi. 

{{%  alert  title="TIP"  color="info"  %}} 
Jeśli wolisz dostosować parametry GIF, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/gifoptions). Zobacz przykładowy kod poniżej. 
{{% /alert %}} 

## **Konwertowanie prezentacji do animowanego GIF przy użyciu własnych ustawień**

Ten przykładowy kod pokazuje, jak konwertować prezentację do animowanego GIF przy użyciu własnych ustawień w C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // rozmiar wynikowego GIF-a  
        DefaultDelay = 2000, // jak długo każdy slajd będzie wyświetlany, zanim zostanie zmieniony na kolejny
        TransitionFps = 35 // zwiększ FPS, aby uzyskać lepszą jakość animacji przejścia
    });
}
```

{{% alert title="Info" color="info" %}}
Możesz zainteresować się DARMOWYM konwerterem [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowanym przez Aspose. 
{{% /alert %}}

## **FAQ**

### Co zrobić, jeśli czcionki użyte w prezentacji nie są zainstalowane w systemie?

Zainstaluj brakujące czcionki lub [skonfiguruj czcionki zapasowe](/slides/pl/net/powerpoint-fonts/). Aspose.Slides zastąpi brakujące, ale wygląd może się różnić. Dla zachowania identyfikacji wizualnej zawsze upewnij się, że wymagane kroje są explicite dostępne.

### Czy mogę nałożyć znak wodny na klatki GIF?

Tak. [Dodaj półprzezroczysty obiekt/logo](/slides/pl/net/watermark/) do slajdu głównego lub poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.