---
title: Zmiana rozmiaru slajdu prezentacji w C++
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/cpp/slide-size/
keywords:
- rozmiar slajdu
- proporcje obrazu
- standard
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
- nie skaluj
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu C++ i Aspose.Slides, optymalizując prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides udostępnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szeroki ekran (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zachowaj spójność w całej prezentacji, ponieważ pojedynczy rozmiar slajdu i jego proporcje obowiązują wszystkie slajdy. Aby uzyskać optymalne rezultaty, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone za pomocą Aspose.Slides używają standardowej proporcji 4:3.
{{% /alert %}}

## **Zmienianie rozmiaru slajdu w prezentacjach**

Poniższy przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w języku C++ przy użyciu Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Określanie własnych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) okazują się nieodpowiednie dla Twojej pracy, możesz zdecydować się na użycie określonego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz wydrukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia własnego rozmiaru slajdu.

Poniższy przykładowy kod pokazuje, jak używać Aspose.Slides for C++ do określenia własnego rozmiaru slajdu w prezentacji w języku C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Rozmiar papieru A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Obsługa zawartości slajdów po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji, zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby dopasować je do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu w prezentacji możesz określić ustawienie, które decyduje o tym, jak Aspose.Slides obchodzi się z zawartością slajdów.

W zależności od tego, co chcesz zrobić lub osiągnąć, możesz użyć dowolnego z tych ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty slajdów, aby wszystkie zmieściły się na slajdach (w ten sposób unikniesz utraty zawartości), użyj tego ustawienia. 

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia. 

Poniższy przykładowy kod pokazuje, jak użyć ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Czy mogę ustawić własny rozmiar slajdu używając jednostek innych niż cale (na przykład punkty lub milimetry)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczone wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży własny rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać wymaganą jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalić slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [merge presentations](/slides/pl/cpp/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby pasował do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość zostanie obsłużona, używając opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalić slajdy, zachowując formatowanie.

**Czy mogę generować miniatury poszczególnych kształtów lub konkretnych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [entire slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/getimage/) oraz dla [selected shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/). Uzyskane obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje, zapewniając spójne kadrowanie i geometrię.