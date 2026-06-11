---
title: Renderowanie slajdów prezentacji jako obrazy SVG w .NET
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentacja do SVG
- slajd do SVG
- PPT do SVG
- PPTX do SVG
- zapisz PPT jako SVG
- zapisz PPTX jako SVG
- eksportuj PPT do SVG
- eksportuj PPTX do SVG
- renderuj slajd
- konwertuj slajd
- eksportuj slajd
- obraz wektorowy
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak renderować slajdy PowerPoint jako obrazy SVG przy użyciu Aspose.Slides dla .NET. Wysokiej jakości wizualizacje z prostymi przykładami kodu C#."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak renderować slajdy prezentacji jako obrazy SVG za pomocą Aspose.Slides. Opisuje format SVG oraz jego zalety, w tym skalowalność, dostępność i przydatność w tworzeniu aplikacji internetowych.

Nauczysz się, jak wczytać plik prezentacji, iterować przez jego slajdy i zapisać każdy slajd jako osobny plik SVG. Artykuł obejmuje formaty prezentacji PowerPoint i OpenDocument, w tym PPT, PPTX, ODP i PPS, oraz pokazuje, jak wykonać konwersję programowo przy użyciu klasy `Presentation` oraz metody `WriteAsSvg`.

## **Format SVG**

SVG—skrót od Scalable Vector Graphics—jest standardowym typem lub formatem grafiki używanym do renderowania dwuwymiarowych obrazów. SVG przechowuje obrazy jako wektory w XML z detalami definiującymi ich zachowanie lub wygląd.

SVG jest jednym z niewielu formatów obrazów spełniających bardzo wysokie wymagania w zakresie skalowalności, interaktywności, wydajności, dostępności, programowalności i innych. Z tych powodów jest powszechnie używany w tworzeniu aplikacji internetowych.

Możesz chcieć używać plików SVG, gdy potrzebujesz

- **wydrukować swoją prezentację w *bardzo dużym formacie*.** Obrazy SVG mogą skalować się do dowolnej rozdzielczości lub poziomu. Możesz zmieniać rozmiar obrazów SVG dowolną liczbę razy bez utraty jakości.
- **używać wykresów i diagramów ze swoich slajdów w *różnych nośnikach lub platformach*.** Większość czytników potrafi interpretować pliki SVG.
- **używać *najmniejszych możliwych rozmiarów obrazów***. Pliki SVG są zazwyczaj mniejsze niż ich wysokiej rozdzielczości odpowiedniki w innych formatach, szczególnie w formatach opartych na bitmapie (JPEG lub PNG).

## **Renderowanie slajdu jako obrazu SVG**

Aspose.Slides for .NET pozwala na eksportowanie slajdów w prezentacjach jako obrazy SVG. Przejdź przez te kroki, aby wygenerować obrazy SVG:

_Kroki: konwersje PowerPoint do SVG w C#_

Poniższy przykładowy kod wyjaśnia te konwersje przy użyciu .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Kroki: konwersja PowerPoint do SVG w C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Kroki: konwersja PPT do SVG w C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Kroki: konwersja PPTX do SVG w C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Kroki: konwersja ODP do SVG w C#</strong></a>

_Kroki kodu:_

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
   * _.ppt_ rozszerzenie do wczytania pliku **PPT** w klasie _Presentation_.
   * _.pptx_ rozszerzenie do wczytania pliku **PPTX** w klasie _Presentation_.
   * _.odp_ rozszerzenie do wczytania pliku **ODP** w klasie _Presentation_.
   * _.pps_ rozszerzenie do wczytania pliku **PPS** w klasie _Presentation_.
2. Iteruj przez wszystkie slajdy w prezentacji.
3. Zapisz każdy slajd do osobnego pliku SVG przy użyciu FileStream.

{{% alert color="primary" %}} 
Możesz wypróbować naszą [bezpłatną aplikację internetową](https://products.aspose.app/slides/pl/conversion/ppt-to-svg), w której zaimplementowaliśmy funkcję konwersji PPT do SVG z Aspose.Slides dla .NET.
{{% /alert %}} 

Ten przykładowy kod w C# pokazuje, jak konwertować PowerPoint do SVG za pomocą Aspose.Slides:

``` csharp
// Obiekt Presentation może wczytywać formaty PowerPoint takie jak PPT, PPTX, ODP itp.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **FAQ**

**Dlaczego wynikowy plik SVG może wyglądać inaczej w różnych przeglądarkach?**

Obsługa konkretnych funkcji SVG jest różnie implementowana przez silniki przeglądarek. Parametry [SVGOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/) pomagają wygładzić niezgodności.

**Czy można eksportować nie tylko slajdy, ale także poszczególne kształty do SVG?**

Tak. Każdy [kształt może być zapisany jako oddzielny SVG](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/writeassvg/), co jest wygodne dla ikon, piktogramów i ponownego użycia grafiki.

**Czy można połączyć wiele slajdów w jeden plik SVG (strip/dokument)?**

Standardowy scenariusz to jeden slajd → jeden SVG. Łączenie kilku slajdów w jedną płaszczyznę SVG jest krokiem post‑processingowym wykonywanym na poziomie aplikacji.

## **Zobacz także** 

Ten artykuł obejmuje również następujące tematy. Kody są takie same jak powyżej.

_Format_: **PowerPoint**
- [C# PowerPoint do SVG – kod](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG – API](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG – programistycznie](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG – biblioteka](#csharp-powerpoint-to-svg)
- [C# Zapisz PowerPoint jako SVG](#csharp-powerpoint-to-svg)
- [C# Generuj SVG z PowerPoint](#csharp-powerpoint-to-svg)
- [C# Utwórz SVG z PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG – konwerter](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT do SVG – kod](#csharp-ppt-to-svg)
- [C# PPT do SVG – API](#csharp-ppt-to-svg)
- [C# PPT do SVG – programistycznie](#csharp-ppt-to-svg)
- [C# PPT do SVG – biblioteka](#csharp-ppt-to-svg)
- [C# Zapisz PPT jako SVG](#csharp-ppt-to-svg)
- [C# Generuj SVG z PPT](#csharp-ppt-to-svg)
- [C# Utwórz SVG z PPT](#csharp-ppt-to-svg)
- [C# PPT do SVG – konwerter](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX do SVG – kod](#csharp-pptx-to-svg)
- [C# PPTX do SVG – API](#csharp-pptx-to-svg)
- [C# PPTX do SVG – programistycznie](#csharp-pptx-to-svg)
- [C# PPTX do SVG – biblioteka](#csharp-pptx-to-svg)
- [C# Zapisz PPTX jako SVG](#csharp-pptx-to-svg)
- [C# Generuj SVG z PPTX](#csharp-pptx-to-svg)
- [C# Utwórz SVG z PPTX](#csharp-pptx-to-svg)
- [C# PPTX do SVG – konwerter](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP do SVG – kod](#csharp-odp-to-svg)
- [C# ODP do SVG – API](#csharp-odp-to-svg)
- [C# ODP do SVG – programistycznie](#csharp-odp-to-svg)
- [C# ODP do SVG – biblioteka](#csharp-odp-to-svg)
- [C# Zapisz ODP jako SVG](#csharp-odp-to-svg)
- [C# Generuj SVG z ODP](#csharp-odp-to-svg)
- [C# Utwórz SVG z ODP](#csharp-odp-to-svg)
- [C# ODP do SVG – konwerter](#csharp-odp-to-svg)