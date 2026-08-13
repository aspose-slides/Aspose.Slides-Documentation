---
title: Zmienianie rozmiaru slajdów prezentacji w .NET
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
- slajd w pełnym rozmiarze
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
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu .NET i Aspose.Slides, optymalizować prezentacje dla dowolnego ekranu bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides for .NET zapewnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szeroki ekran (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zadbaj o spójność w całej prezentacji, ponieważ pojedynczy rozmiar slajdu i proporcja obrazu obowiązują wszystkie slajdy. Aby uzyskać najlepsze rezultaty, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" %}} 
Domyślnie prezentacje utworzone za pomocą Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

## **Jak zmienić rozmiar slajdu w prezentacji**

Ten przykład pokazuje, jak zmienić rozmiar slajdu w prezentacji za pomocą Aspose.Slides w C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Określanie niestandardowych rozmiarów slajdów**

Dopasowanie rozmiaru slajdu do konkretnych potrzeb, takich jak unikalne układy papieru lub specyfikacje ekranu, może być korzystne. Oto jak ustawić niestandardowy rozmiar slajdu w Aspose.Slides dla .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // rozmiar papieru A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru zawartość slajdu może ulec zniekształceniu. Możesz kontrolować, jak Aspose.Slides zarządza tą zmianą rozmiaru:

- **`DoNotScale`**: Zachowaj obiekty w oryginalnych rozmiarach, aby uniknąć skalowania.
- **`EnsureFit`**: Skaluj obiekty, aby dopasować je do mniejszych slajdów, zapobiegając utracie treści.
- **`Maximize`**: Powiększ obiekty, aby pasowały do większych slajdów, zapewniając spójność estetyczną.

Przykład użycia ustawienia `Maximize` przy dostosowywaniu rozmiaru slajdu:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Czy mogę ustawić niestandardowy rozmiar slajdu, używając jednostek innych niż cale (na przykład punktów lub milimetrów)?

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczone wartości do określenia szerokości i wysokości slajdu.

### Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby osiągnąć pożądaną jakość wyjścia.

### Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalać slajdy z prezentacji o różnych rozmiarach?

Nie możesz [scalanie prezentacji](/slides/pl/net/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby pasował do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość ma być obsługiwana za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalać slajdy, zachowując formatowanie.

### Czy mogę generować miniatury pojedynczych kształtów lub konkretnych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage/) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/). Uzyskane obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje obrazu, zapewniając spójne kadrowanie i geometrię.