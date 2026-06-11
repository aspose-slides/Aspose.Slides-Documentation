---
title: "Zmień rozmiar slajdu prezentacji w .NET"
linktitle: "Rozmiar slajdu"
type: docs
weight: 70
url: /pl/net/slide-size/
keywords:
- "rozmiar slajdu"
- "proporcja obrazu"
- "standardowy"
- "szerokokątny"
- "4:3"
- "16:9"
- "ustaw rozmiar slajdu"
- "zmień rozmiar slajdu"
- "niestandardowy rozmiar slajdu"
- "specjalny rozmiar slajdu"
- "unikalny rozmiar slajdu"
- "slajd pełnoekranowy"
- "typ ekranu"
- "nie skaluj"
- "zapewnij dopasowanie"
- "maksymalizuj"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- ".NET"
- "C#"
- "Aspose.Slides"
descriptions: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu .NET i Aspose.Slides, optymalizując prezentacje na dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides for .NET udostępnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szerokokątny (proporcja 16:9)**: Polecany dla nowoczesnych projektorów i wyświetlaczy.

Zapewnij spójność w całej prezentacji, ponieważ pojedynczy rozmiar slajdu i proporcja obrazu obowiązują wszystkie slajdy. Aby uzyskać optymalne rezultaty, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides korzystają ze standardowej proporcji 4:3.
{{% /alert %}}

## **Jak zmienić rozmiar slajdu w prezentacji**

Ten przykład demonstruje zmianę rozmiaru slajdu w prezentacji przy użyciu Aspose.Slides w języku C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Określ niestandardowe rozmiary slajdów**

Dostosowanie rozmiaru slajdu do konkretnych potrzeb, np. unikatowych układów papieru lub specyfikacji ekranu, może być korzystne. Oto jak ustawić niestandardowy rozmiar slajdu przy użyciu Aspose.Slides dla .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Rozmiar papieru A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru zawartość slajdu może ulec zniekształceniu. Możesz kontrolować, jak Aspose.Slides zarządza tą zmianą rozmiaru:

- **`DoNotScale`**: Zachowaj obiekty w ich pierwotnych rozmiarach, aby uniknąć skalowania.
- **`EnsureFit`**: Skaluj obiekty, aby pasowały do mniejszych slajdów, zapobiegając utracie zawartości.
- **`Maximize`**: Powiększ obiekty, aby pasowały do większych slajdów, zapewniając spójność estetyczną.

Przykład użycia ustawienia `Maximize` do dostosowania rozmiaru slajdu:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (na przykład punkty lub milimetry)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przekonwertować dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć otrzymanych wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i wydłużonych czasów przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalać slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [scal prezentacje](/slides/pl/net/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby pasował do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak obsługiwana jest istniejąca treść, używając opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/net/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalać slajdy, zachowując formatowanie.

**Czy mogę generować miniatury pojedynczych kształtów lub wybranych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/getimage/) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/). Powstałe obrazy odzwierciedlają aktualny rozmiar i proporcję slajdu, zapewniając spójne kadrowanie i geometrię.