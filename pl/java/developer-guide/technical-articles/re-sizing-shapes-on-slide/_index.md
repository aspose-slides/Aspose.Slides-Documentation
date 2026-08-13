---
title: Zmiana rozmiaru kształtów na slajdach prezentacji
type: docs
weight: 110
url: /pl/java/re-sizing-shapes-on-slide/
keywords:
- zmień rozmiar kształtu
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Łatwo zmieniaj rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Java — automatyzuj dostosowywanie układu slajdów i zwiększaj wydajność."
---
## **Przegląd**

Jednym z najczęstszych pytań klientów Aspose.Slides for Java jest, jak zmienić rozmiar kształtów, aby gdy rozmiar slajdu się zmieni, dane nie zostały obcięte. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmienianie rozmiaru kształtów**

Aby zapobiec niewłaściwemu położeniu kształtów po zmianie rozmiaru slajdu, zaktualizuj pozycję i wymiary każdego kształtu, aby pasowały do nowego układu slajdu.

```java
import com.aspose.slides.*;

// Wczytaj plik prezentacji.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Pobierz pierwotny rozmiar slajdu.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Pobierz nowy rozmiar slajdu.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Zmień rozmiar i przemieść kształty na każdym slajdzie.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Skaluj rozmiar kształtu.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skaluj pozycję kształtu.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Tabele nie wymagają specjalnego traktowania: ustawienie szerokości i wysokości tabeli skaluje jej kolumny i wiersze proporcjonalnie, więc ponowne skalowanie wysokości wierszy i szerokości kolumn spowodowałoby podwojenie współczynnika.
{{% /alert %}} 

Powyższy kod zmienia tylko kształty na slajdach. Slajdy wzorcowe i slajdy układu posiadają własne kształty, więc skaluj je również, gdy chcesz, aby cała prezentacja dostosowała się do nowego rozmiaru slajdu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Pobierz oryginalny rozmiar slajdu.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Pobierz nowy rozmiar slajdu.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Skaluj rozmiar kształtu.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skaluj pozycję kształtu.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Skaluj rozmiar kształtu.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Skaluj pozycję kształtu.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Skaluj rozmiar kształtu.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skaluj pozycję kształtu.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?

Podczas zmiany rozmiaru slajdu kształty zachowują swoją pierwotną pozycję i rozmiar, chyba że skala zostanie wyraźnie zmieniona. Może to spowodować przycięcie zawartości lub niewłaściwe wyrównanie kształtów.

### Czy dostarczony kod działa dla wszystkich typów kształtów?

Tak. Ustawianie wysokości i szerokości działa tak samo dla pól tekstowych, obrazów, wykresów i tabel.

### Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?

Skaluj sam kształt tabeli, dokładnie tak jak każdy inny kształt. Jego wiersze i kolumny skalują się proporcjonalnie, więc nie skaluj ich ponownie później.

### Czy to skalowanie działa dla slajdów wzorcowych i slajdów układu?

Tak, ale powinieneś także przeiterować przez [Masters](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getMasters--) i [Layout slides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getLayoutSlides--) oraz zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

### Czy mogę zmienić orientację slajdu (pionowa/pozioma) wraz ze zmianą rozmiaru?

Tak. Możesz użyć [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidesize/#setOrientation-int-), aby zmienić orientację. Upewnij się, że odpowiednio dostosujesz logikę skalowania, aby zachować układ.

### Czy istnieje limit rozmiaru slajdu, który mogę ustawić?

Aspose.Slides obsługuje rozmiary niestandardowe, ale bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami programu PowerPoint.

### Jak zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?

Możesz sprawdzić metodę `getAspectRatioLocked` kształtu przed skalowaniem. Jeśli jest zablokowana, dostosuj szerokość lub wysokość proporcjonalnie, zamiast skaliować je osobno.