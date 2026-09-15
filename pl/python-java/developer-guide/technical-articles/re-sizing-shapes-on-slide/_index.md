---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w Pythonie via Java
type: docs
weight: 110
url: /pl/python-java/re-sizing-shapes-on-slide/
keywords:
- przeskaluj kształt
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via Java — automatyzuj dostosowywanie układu slajdów i zwiększ produktywność."
---
## **Przegląd**

Jednym z najczęściej zadawanych pytań klientów Aspose.Slides for Python via Java jest to, jak zmienić rozmiar kształtów, aby przy zmianie rozmiaru slajdu dane nie były obcinane. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmiana rozmiaru kształtów**

Aby zapobiec nieprawidłowemu rozmieszczeniu kształtów przy zmianie rozmiaru slajdu, zaktualizuj pozycję i wymiary każdego kształtu tak, aby pasowały do nowego układu slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Wczytaj plik prezentacji.
presentation = Presentation("sample.ppt")
try:
    # Pobierz oryginalny rozmiar slajdu.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Pobierz nowy rozmiar slajdu.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Zmień rozmiar i pozycję kształtów na każdym slajdzie.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Skaluj rozmiar kształtu.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skaluj pozycję kształtu.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Uwaga" %}} 
Tablice nie wymagają specjalnego traktowania: ustawienie szerokości i wysokości tablicy przeskalowuje jej kolumny i wiersze proporcjonalnie, więc ponowne skalowanie wysokości wierszy i szerokości kolumn spowodowałoby podwojenie współczynnika.
{{% /alert %}} 

Powyższy kod zmienia tylko kształty na slajdach. Slajdy master i slajdy układu mają własne kształty, więc skaluj je również, gdy chcesz, aby cała prezentacja dostosowała się do nowego rozmiaru slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Pobierz oryginalny rozmiar slajdu.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Pobierz nowy rozmiar slajdu.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Skaluj rozmiar kształtu.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skaluj pozycję kształtu.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Skaluj rozmiar kształtu.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Skaluj pozycję kształtu.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Skaluj rozmiar kształtu.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skaluj pozycję kształtu.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Najczęściej zadawane pytania**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Podczas zmiany rozmiaru slajdu kształty zachowują pierwotną pozycję i rozmiar, chyba że skalowanie zostanie wyraźnie zmienione. Może to skutkować przycięciem treści lub nieprawidłowym rozmieszczeniem kształtów.

**Czy podany kod działa dla wszystkich typów kształtów?**

Tak. Ustawianie wysokości i szerokości działa zarówno dla pól tekstowych, obrazów, wykresów, jak i tabel.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Skaluj samą tabelę, dokładnie tak jak każdy inny kształt. Jej wiersze i kolumny skalują się proporcjonalnie, więc nie skaluj ich ponownie później.

**Czy to skalowanie działa dla slajdów master i slajdów układu?**

Tak, ale powinieneś również przejść przez [Presentation.getMasters](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getMasters) i [Presentation.getLayoutSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getLayoutSlides) i zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

**Czy mogę zmienić orientację slajdu (pionowo/poziomo) wraz ze skalowaniem?**

Tak. Możesz użyć [SlideSize.setOrientation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#setOrientation), aby zmienić orientację. Upewnij się, że logikę skalowania dostosujesz odpowiednio, aby zachować układ.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Aspose.Slides obsługuje rozmiary niestandardowe, ale bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami PowerPointa.

**Jak zapobiec zniekształceniu kształtów o stałym stosunku proporcji?**

Możesz sprawdzić metodę [getAspectRatioLocked](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) blokady kształtu przed skalowaniem. Jeśli jest zablokowany, dostosuj szerokość lub wysokość proporcjonalnie, zamiast skalować je osobno.