---
title: Zmienianie rozmiaru slajdu prezentacji w PHP
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/php-java/slide-size/
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
- PHP
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu PHP i Aspose.Slides, optymalizuj prezentacje na dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides zapewnia kompleksowe narzędzia do dopasowywania rozmiaru slajdu i proporcji obrazu w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcja 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szeroki ekran (proporcja 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zadbaj o spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i jedna proporcja obowiązują wszystkie slajdy. Aby uzyskać optymalne rezultaty, ustaw wymiary slajdu na początku tworzenia prezentacji, aby uniknąć problemów.

{{% alert color="info" title="Uwaga" %}}
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowego stosunku 4:3.
{{% /alert %}}

Strony notatek i materiały rozdawnicze mają inne wymiary niż zwykłe slajdy. Zobacz [Rozmiar strony notatek](/slides/pl/php-java/notes-size/) aby zmienić ich rozmiar i orientację.

## **Zmienianie rozmiaru slajdu w prezentacjach**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji przy użyciu Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Określanie niestandardowych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie spełniają Twoich wymagań, możesz zdecydować się na użycie specyficznego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze na niestandardowym układzie strony lub wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru.

Ten przykładowy kod pokazuje, jak używać Aspose.Slides for PHP via Java, aby określić niestandardowy rozmiar slajdu w prezentacji:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// Rozmiar papieru A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obsługa treści slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu możesz określić ustawienie, które decyduje, jak Aspose.Slides radzi sobie z zawartością slajdów.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć jednego z następujących ustawień:

- `DoNotScale`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszył obiekty, aby wszystkie zmieściły się na slajdzie (w ten sposób unikasz utraty treści), użyj tego ustawienia.

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększył obiekty, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia.

Ten przykładowy kod pokazuje, jak używać ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę ustawić niestandardowy rozmiar slajdu przy użyciu jednostek innych niż cale (np. punktów lub milimetrów)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonej wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie łączyć slajdy z prezentacji o innych rozmiarach?**

Nie możesz [łączyć prezentacji](/slides/pl/php-java/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować go do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość ma być obsłużona za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz łączyć slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla pojedynczych kształtów lub określonych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury dla [całych slajdów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage) oraz dla [wybranych kształtów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage). Powstałe obrazy odzwierciedlają aktualny rozmiar slajdu i proporcje, zapewniając spójne kadrowanie i geometrię.