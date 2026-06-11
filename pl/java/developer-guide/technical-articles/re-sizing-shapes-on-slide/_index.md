---
title: Zmienianie rozmiaru kształtów na slajdach prezentacji
type: docs
weight: 110
url: /pl/java/re-sizing-shapes-on-slide/
keywords:
- zmień rozmiar kształtu
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Łatwo zmieniaj rozmiar kształtów na slajdach PowerPoint i OpenDocument za pomocą Aspose.Slides dla Javy — automatyzuj dostosowania układu slajdów i zwiększ wydajność."
---
## **Przegląd**

Jednym z najczęściej zadawanych pytań przez klientów Aspose.Slides for Java jest to, jak zmienić rozmiar kształtów tak, aby przy zmianie rozmiaru slajdu dane nie były obcinane. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmiana rozmiaru kształtów**

Aby zapobiec niewłaściwemu wyrównaniu kształtów po zmianie rozmiaru slajdu, zaktualizuj pozycję i wymiary każdego kształtu tak, aby odpowiadały nowemu układowi slajdu.

```java
// Załaduj plik prezentacji.
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

    // Zmien rozmiar i przesuń kształty na każdym slajdzie.
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

{{% alert color="primary" %}} 

Jeśli slajd zawiera tabelę, powyższy kod nie zadziała poprawnie. W takim przypadku każdy komórka w tabeli musi zostać przeskalowana.

{{% /alert %}} 

Użyj poniższego kodu, aby zmienić rozmiar slajdów zawierających tabele. Dla tabel ustawienie szerokości lub wysokości jest przypadkiem specjalnym: musisz dostosować wysokości poszczególnych wierszy i szerokości kolumn, aby zmienić ogólny rozmiar tabeli.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Pobierz pierwotny rozmiar slajdu.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Zmien rozmiar slajdu bez skalowania istniejących kształtów.
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
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Podczas zmiany rozmiaru slajdu kształty zachowują swoje pierwotne położenie i rozmiar, chyba że skala zostanie wyraźnie zmieniona. Może to spowodować przycięcie treści lub niewłaściwe wyrównanie kształtów.

**Czy podany kod działa dla wszystkich typów kształtów?**

Podstawowy przykład działa dla większości typów kształtów (pola tekstowe, obrazy, wykresy itp.). Jednak w przypadku tabel należy obsłużyć osobno wiersze i kolumny, ponieważ wysokość i szerokość tabeli są określane przez wymiary poszczególnych komórek.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Należy przeiterować wszystkie wiersze i kolumny tabeli oraz proporcjonalnie zmienić ich wysokość i szerokość, tak jak pokazano w drugim przykładzie kodu.

**Czy to skalowanie działa dla slajdów głównych i układów slajdów?**

Tak, ale należy również przeiterować [Mistrzowie](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getMasters--) i [Układy slajdów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getLayoutSlides--) oraz zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

**Czy mogę zmienić orientację slajdu (pionowa/pozioma) wraz ze zmianą rozmiaru?**

Tak. Możesz użyć [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidesize/#setOrientation-int-), aby zmienić orientację. Upewnij się, że odpowiednio dostosujesz logikę skalowania, aby zachować układ.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Aspose.Slides obsługuje rozmiary niestandardowe, ale bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami PowerPoint.

**Jak mogę zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?**

Możesz sprawdzić metodę `getAspectRatioLocked` kształtu przed skalowaniem. Jeśli jest ona zablokowana, dostosuj szerokość lub wysokość proporcjonalnie, zamiast skalować je osobno.