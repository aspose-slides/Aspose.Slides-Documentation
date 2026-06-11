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
- szerokoekranowy
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
- Python
- Aspose.Slides
descriptions: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP przy użyciu Pythona i Aspose.Slides, optymalizować prezentacje pod dowolny ekran bez utraty jakości."
---
## **Wstęp**

Aspose.Slides zapewnia kompleksowe narzędzia do dostosowywania rozmiaru slajdu i proporcji w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie. 

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcje 4:3)**: Idealny dla starszych ekranów i urządzeń.
- **Szerokoekranowy (proporcje 16:9)**: Zalecany dla nowoczesnych projektorów i wyświetlaczy.

Zapewnij spójność w całej prezentacji, ponieważ pojedynczy rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Aby uzyskać optymalne rezultaty, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, aby uniknąć komplikacji.

{{% alert color="primary" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowych proporcji 4:3.
{{% /alert %}}

## **Zmień rozmiar slajdu w prezentacji**

Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w języku Python przy użyciu Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Określ niestandardowe rozmiary slajdów**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie są odpowiednie dla Twojej pracy, możesz zdecydować się na użycie konkretnego lub unikalnego rozmiaru slajdu. Na przykład, jeśli planujesz drukować slajdy w pełnym rozmiarze z prezentacji na niestandardowym układzie strony lub zamierzasz wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z ustawienia niestandardowego rozmiaru dla swojej prezentacji. 

Ten przykładowy kod pokazuje, jak używać Aspose.Slides dla Pythona poprzez .NET, aby określić niestandardowy rozmiar slajdu dla prezentacji w języku Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # rozmiar papieru A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Obsługa zawartości slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu w prezentacji możesz określić ustawienie, które decyduje, jak Aspose.Slides radzi sobie z zawartością slajdów.

W zależności od tego, co zamierzasz zrobić lub osiągnąć, możesz użyć dowolnego z tych ustawień:

- `DO_NOT_SCALE`

  Jeśli NIE chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `ENSURE_FIT`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszył obiekty slajdu, aby wszystkie zmieściły się na slajdach (w ten sposób unikniesz utraty zawartości), użyj tego ustawienia. 

- `MAXIMIZE`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększył obiekty slajdu, aby były proporcjonalne do nowego rozmiaru, użyj tego ustawienia. 

Ten przykładowy kod pokazuje, jak używać ustawienia `MAXIMIZE` podczas zmiany rozmiaru slajdu w prezentacji:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Czy mogę ustawić niestandardowy rozmiar slajdu używając jednostek innych niż cale (np. punkty lub milimetry)?**

Tak. Aspose.Slides używa wewnętrznie punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (np. milimetry lub centymetry) na punkty i użyć przeliczonych wartości do określenia szerokości i wysokości slajdu.

**Czy bardzo duży niestandardowy rozmiar slajdu wpływa na wydajność i zużycie pamięci podczas renderowania?**

Tak. Większe wymiary slajdu (w punktach) w połączeniu z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

**Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie łączyć slajdy z prezentacji o różnych rozmiarach?**

Nie możesz [scal prezentacje](/slides/pl/python-net/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby dopasować go do drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość będzie obsługiwana za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalać slajdy, zachowując formatowanie.

**Czy mogę generować miniatury dla poszczególnych kształtów lub konkretnych obszarów slajdu i czy będą one uwzględniać nowy rozmiar slajdu?**

Tak. Aspose.Slides może renderować miniatury zarówno dla [entire slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/), jak i dla [selected shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/). Powstałe obrazy odzwierciedlają bieżący rozmiar slajdu i proporcje, zapewniając spójne kadrowanie oraz geometrię.