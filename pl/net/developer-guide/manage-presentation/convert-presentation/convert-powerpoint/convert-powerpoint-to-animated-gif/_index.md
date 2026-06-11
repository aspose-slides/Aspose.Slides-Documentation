---
title: Konwertuj prezentacje PowerPoint na animowane GIF-y w .NET
linktitle: PowerPoint na GIF
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
- PowerPoint na GIF
- prezentacja na GIF
- slajd na GIF
- PPT na GIF
- PPTX na GIF
- zapisz PPT jako GIF
- zapisz PPTX jako GIF
- wyeksportuj PPT jako GIF
- wyeksportuj PPTX jako GIF
- domyślne ustawienia
- niestandardowe ustawienia
- .NET
- C#
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIF-y za pomocą Aspose.Slides dla .NET. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint na animowane pliki GIF przy użyciu kilku linijek kodu. Jest to przydatne, gdy trzeba udostępnić zawartość slajdów w lekkim, szeroko wspieranym formacie animacji, który można osadzić w stronach internetowych, komunikatorach lub dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację do formatu GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurując opcje takie jak rozmiar klatki, opóźnienie slajdu i częstotliwość klatek przejścia za pomocą [GifOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/gifoptions/).

## **Konwertuj prezentacje na animowany GIF przy użyciu ustawień domyślnych**

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Animowany GIF zostanie utworzony z domyślnymi parametrami. 

{{%  alert  title="TIP"  color="primary"  %}} 

Jeśli wolisz dostosować parametry GIF, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/gifoptions) . Zobacz przykładowy kod poniżej. 

{{% /alert %}} 

## **Konwertuj prezentacje na animowany GIF przy użyciu ustawień niestandardowych**

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // rozmiar wynikowego GIF-a  
        DefaultDelay = 2000, // czas wyświetlania każdego slajdu, zanim zostanie zmieniony na kolejny
        TransitionFps = 35 // zwiększ FPS, aby uzyskać lepszą jakość animacji przejścia
    });
}
```

{{% alert title="Info" color="info" %}}

Możesz chcieć wypróbować darmowy konwerter [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowany przez Aspose. 

{{% /alert %}}

## **FAQ**

**Co zrobić, jeśli czcionki użyte w prezentacji nie są zainstalowane w systemie?**

Zainstaluj brakujące czcionki lub [skonfiguruj czcionki zapasowe](/slides/pl/net/powerpoint-fonts/). Aspose.Slides zastąpi je, ale wygląd może się różnić. Dla identyfikacji marki zawsze upewnij się, że wymagane czcionki są dostępne.

**Czy mogę nałożyć znak wodny na klatki GIF?**

Tak. [Add a semi-transparent object/logo](/slides/pl/net/watermark/) do slajdu głównego lub poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.