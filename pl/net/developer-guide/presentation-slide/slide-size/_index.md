---
title: Zmień rozmiar slajdu prezentacji w .NET
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/net/slide-size/
keywords:
- rozmiar slajdu
- proporcja obrazu
- standardowy
- szeroki ekran
- 4:3
- 16:9
- ustaw rozmiar slajdu
- zmień rozmiar slajdu
- niestandardowy rozmiar slajdu
- specjalny rozmiar slajdu
- unikalny rozmiar slajdu
- slajd pełnego rozmiaru
- typ ekranu
- nie skalować
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu .NET i Aspose.Slides, optymalizując prezentacje na dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides for .NET zapewnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie.

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szeroki ekran (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zadbaj o spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Dla optymalnych rezultatów ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

Strony notatek i materiały wydrukowe mają odrębne wymiary od zwykłych slajdów. Zobacz [Rozmiar strony notatki](/slides/pl/net/notes-size/), aby zmienić ich rozmiar i orientację.

## **Jak zmienić rozmiar slajdu w prezentacji**

Ten przykład pokazuje, jak zmienić rozmiar slajdu w prezentacji przy użyciu Aspose.Slides w C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Określ niestandardowe rozmiary slajdów**

Dostosowanie rozmiaru slajdu do konkretnych potrzeb, na przykład do unikalnych układów papieru lub specyfikacji ekranu, może być korzystne. Oto jak ustawić niestandardowy rozmiar slajdu przy użyciu Aspose.Slides for .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Rozmiar papieru A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Obsługa treści slajdu po zmianie rozmiaru**

Po zmianie rozmiaru zawartość slajdu może ulec zniekształceniu. Możesz kontrolować, jak Aspose.Slides zarządza tą zmianą rozmiaru:

- **`DoNotScale`**: Zachowaj obiekty w ich oryginalnych rozmiarach, aby uniknąć skalowania.
- **`EnsureFit`**: Skaluj obiekty, aby pasowały do mniejszych slajdów, zapobiegając utracie treści.
- **`Maximize`**: Powiększ obiekty, aby pasowały do większych slajdów, zapewniając spójność estetyczną.

Przykład użycia ustawienia `Maximize` do dostosowania rozmiaru slajdu:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (na przykład punktów lub milimetrów)?

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (taką jak milimetry lub centymetry) na punkty i użyć przeliczonych wartości do określenia szerokości i wysokości slajdu.

### Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania powodują zwiększone zużycie pamięci i dłuższy czas przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać wymaganą jakość wyjściową.

### Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?

Nie możesz [scal prezentacje](/slides/pl/net/merge-presentation/), gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować ją do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak obsługiwana jest istniejąca treść, korzystając z opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy, zachowując formatowanie.

### Czy mogę generować miniatury poszczególnych kształtów lub określonych regionów slajdu i czy będą one respektować nowy rozmiar slajdu?

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage/) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/). Powstałe obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje, zapewniając spójne kadrowanie i geometrię.