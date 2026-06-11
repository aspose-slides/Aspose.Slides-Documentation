---
title: Zmiana rozmiaru kształtów w prezentacjach przy użyciu Pythona
linktitle: Zmiana rozmiaru kształtów
type: docs
weight: 130
url: /pl/python-net/re-sizing-shapes-on-slide/
keywords:
- zmiana rozmiaru kształtu
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w .NET — automatyzuj dostosowywanie układu slajdów i zwiększaj wydajność."
---
## **Przegląd**

Jednym z najczęściej zadawanych pytań klientów Aspose.Slides dla Pythona jest to, jak zmienić rozmiar kształtów, aby przy zmianie rozmiaru slajdu dane nie były obcięte. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmiana rozmiaru kształtów**

Aby zapobiec nieprawidłowemu rozmieszczeniu kształtów przy zmianie rozmiaru slajdu, zaktualizuj pozycję i wymiary każdego kształtu, aby dopasowały się do nowego układu slajdu.

```py
import aspose.slides as slides

# Wczytaj plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    # Pobierz oryginalny rozmiar slajdu.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Pobierz nowy rozmiar slajdu.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Zmień rozmiar i pozycję kształtów na każdym slajdzie.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Skaluj rozmiar kształtu.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skaluj pozycję kształtu.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Jeśli slajd zawiera tabelę, powyższy kod nie będzie działał poprawnie. W takim przypadku każda komórka w tabeli musi zostać przeskalowana.
{{% /alert %}} 

Użyj poniższego kodu, aby zmienić rozmiar slajdów zawierających tabele. W przypadku tabel ustawianie szerokości lub wysokości jest przypadkiem specjalnym: musisz dostosować wysokości poszczególnych wierszy i szerokości kolumn, aby zmienić ogólny rozmiar tabeli.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Pobierz oryginalny rozmiar slajdu.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Pobierz nowy rozmiar slajdu.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Skaluj rozmiar kształtu.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skaluj pozycję kształtu.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Skaluj rozmiar kształtu.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Skaluj pozycję kształtu.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Skaluj rozmiar kształtu.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Skaluj pozycję kształtu.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Podczas zmiany rozmiaru slajdu kształty zachowują pierwotną pozycję i rozmiar, chyba że skala zostanie wyraźnie zmieniona. Może to spowodować przycięcie treści lub nieprawidłowe rozmieszczenie kształtów.

**Czy podany kod działa dla wszystkich typów kształtów?**

Podstawowy przykład działa dla większości typów kształtów (pola tekstowe, obrazy, wykresy itp.). Jednak w przypadku tabel należy obsługiwać wiersze i kolumny osobno, ponieważ wysokość i szerokość tabeli są określone przez wymiary poszczególnych komórek.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Należy przejść przez wszystkie wiersze i kolumny tabeli i proporcjonalnie zmienić ich wysokość oraz szerokość, jak pokazano w drugim przykładzie kodu.

**Czy to skalowanie działa dla slajdów master i layout?**

Tak, ale należy także przejść przez [Masters](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/masters/) i [Layout slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/layout_slides/) oraz zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

**Czy mogę zmienić orientację slajdu (portret/poziom) razem ze skalowaniem?**

Tak. Można użyć [presentation.slide_size.orientation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/islidesize/orientation/), aby zmienić orientację. Upewnij się, że logikę skalowania dostosowujesz odpowiednio, aby zachować układ.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Aspose.Slides obsługuje rozmiary niestandardowe, ale bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami PowerPointa.

**Jak zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?**

Można sprawdzić właściwość `aspect_ratio_locked` kształtu przed skalowaniem. Jeśli jest zablokowana, należy proporcjonalnie dostosować szerokość lub wysokość zamiast skalować je osobno.