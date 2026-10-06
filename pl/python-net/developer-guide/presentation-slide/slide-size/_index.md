---
title: Zmienianie rozmiaru slajdu w prezentacjach przy użyciu Pythona
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/python-net/slide-size/
keywords:
- rozmiar slajdu
- proporcje
- standard
- szerokokątny
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
- Python
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Pythona i Aspose.Slides, optymalizować prezentacje na dowolny ekran bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides udostępnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcje 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szerokokątny (proporcje 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zapewnij spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Aby uzyskać optymalne wyniki, ustaw wymiary slajdów na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="info" title="Uwaga" %}}
Domyślnie prezentacje tworzone za pomocą Aspose.Slides używają standardowych proporcji 4:3.
{{% /alert %}}

Strony notatek i materiały rozdawane mają odrębne wymiary w porównaniu do zwykłych slajdów. Zobacz [Rozmiar strony notatek](/slides/pl/python-net/notes-size/), aby zmienić ich rozmiar i orientację.

## **Zmienianie rozmiaru slajdu w prezentacji**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w języku Python przy użyciu Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Określanie niestandardowych rozmiarów slajdów**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) są nieodpowiednie dla Twojej pracy, możesz zdecydować się na użycie określonego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz wydrukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji. 

Ten przykładowy kod pokazuje, jak używać Aspose.Slides dla Pythona poprzez .NET, aby określić niestandardowy rozmiar slajdu dla prezentacji w języku Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby dopasować się do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu w prezentacji możesz określić ustawienie, które decyduje, jak Aspose.Slides radzi sobie z zawartością na slajdach.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć jednego z następujących ustawień:

- `DO_NOT_SCALE`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `ENSURE_FIT`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty slajdów, aby wszystkie zmieściły się na slajdach (w ten sposób unikniesz utraty zawartości), użyj tego ustawienia. 

- `MAXIMIZE`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty slajdów, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia. 

Ten przykładowy kod pokazuje, jak używać ustawienia `MAXIMIZE` przy zmianie rozmiaru slajdu w prezentacji:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (na przykład punkty lub milimetry)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczone wartości do zdefiniowania szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie łączyć slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [łączyć prezentacji](/slides/pl/python-net/merge-presentation/) mając różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować ją do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość jest obsługiwana, korzystając z opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz łączyć slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla poszczególnych kształtów lub określonych obszarów slajdu i czy będą one uwzględniały nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury zarówno dla [całych slajdów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/), jak i dla [wybranych kształtów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/). Powstałe obrazy odzwierciedlają bieżący rozmiar i proporcje slajdu, zapewniając spójne kadrowanie i geometrię.