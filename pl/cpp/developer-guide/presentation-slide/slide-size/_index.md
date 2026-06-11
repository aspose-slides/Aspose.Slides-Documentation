---
title: Zmień rozmiar slajdu prezentacji w C++
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/cpp/slide-size/
keywords:
- rozmiar slajdu
- proporcje obrazu
- standardowy
- szeroki ekran
- 4:3
- 16:9
- ustaw rozmiar slajdu
- zmień rozmiar slajdu
- niestandardowy rozmiar slajdu
- specjalny rozmiar slajdu
- unikalny rozmiar slajdu
- slajd pełnowymiarowy
- typ ekranu
- nie skaluj
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
descriptions: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu C++ i Aspose.Slides, zoptymalizować prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wstęp**

Aspose.Slides udostępnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcje 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szeroki ekran (proporcje 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zadbaj o spójność całej prezentacji, ponieważ pojedynczy rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Aby uzyskać optymalne wyniki, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

## **Zmiana rozmiaru slajdu w prezentacjach**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w języku C++ przy użyciu Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Określanie niestandardowych rozmiarów slajdów w prezentacjach**

Jeśli uznasz standardowe rozmiary slajdów (4:3 i 16:9) za nieodpowiednie dla swojej pracy, możesz zdecydować się na użycie konkretnego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych rodzajach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji. 

Ten przykładowy kod pokazuje, jak użyć Aspose.Slides dla C++, aby określić niestandardowy rozmiar slajdu dla prezentacji w języku C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Rozmiar kartki A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Obsługa zawartości slajdów po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji, zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby dopasować je do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu w prezentacji możesz określić ustawienie, które definiuje, jak Aspose.Slides radzi sobie z zawartością slajdów.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć dowolnego z tych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszało obiekty slajdów tak, aby wszystkie zmieściły się na slajdach (w ten sposób unikasz utraty treści), użyj tego ustawienia. 

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększało obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia. 

Ten przykładowy kod pokazuje, jak użyć ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (na przykład punktów lub milimetrów)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonej wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpływa na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania powodują zwiększone zużycie pamięci i dłuższy czas przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby osiągnąć pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [scalić prezentacje](/slides/pl/cpp/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować go do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość jest obsługiwana, używając opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla pojedynczych kształtów lub określonych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/getimage/) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/). Uzyskane obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje, zapewniając spójne kadrowanie oraz geometrię.