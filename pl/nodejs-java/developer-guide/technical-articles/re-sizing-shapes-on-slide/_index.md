---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w Node.js
type: docs
weight: 130
url: /pl/nodejs-java/resizing-shapes-on-slide/
aliases:
  /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- skalowanie kształtu
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js w Javie — automatyzuj dostosowywanie układu slajdów i zwiększ wydajność."
---
## **Przegląd**

Kiedy zmieniasz rozmiar slajdu prezentacji, może być konieczne przeskalowanie i przemieszczenie jej kształtów, aby pasowały do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty i jak obsługiwać tabele na slajdach, wzorcach i układach.

## **Zmiana rozmiaru kształtów**

Aby zachować względną pozycję i rozmiar każdego kształtu, pomnóż jego współrzędne poziome i szerokość przez stosunek nowej szerokości slajdu do szerokości pierwotnej. Zastosuj odpowiadający stosunek wysokości do współrzędnych pionowych i wysokości.

Pierwszy przykład ładuje prezentację, w której slajdy nie zawierają tabel, zmienia rozmiar slajdu na A4 i zapisuje wynik. Używa [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) z [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale), aby kolejna pętla kontrolowała skalowanie. Stosunki są bez jednostek; pozycje i wymiary kształtów są mierzone w punktach. Różne współczynniki szerokości i wysokości mogą deformować kształty, a zmiana wymiarów kształtu nie skaluje rozmiarów czcionek.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Oblicz niezależne czynniki skali poziomej i pionowej.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabele wymagają oddzielnej obsługi: skaluj ich szerokości kolumn i wysokości wierszy zamiast przypisywać całkowitą szerokość i wysokość tabeli. Wysokości wierszy mogą pozostać większe niż żądane, jeśli zawartość komórek wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty na wzorcach i układach, a także na poszczególnych slajdach, przed zapisaniem przeskalowanej prezentacji. Jego pomocnik obsługuje każdą [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) skalując szerokość kolumn przy użyciu [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) oraz minimalne wysokości wierszy przy użyciu [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Następnie skaluje pozycję tabeli, nie skalując oddzielnie jej ogólnych wymiarów.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Wymiary tabeli są kontrolowane przez szerokości kolumn i wysokości wierszy.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Oblicz niezależne czynniki skali poziomej i pionowej.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Zmieniaj rozmiar kształtów zdefiniowanych na wzorcach i układach, a także na poszczególnych slajdach.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, zachowają one swoje pierwotne pozycje i wymiary, co może spowodować wyjście poza obszar slajdu. Skalowanie szerokości i wysokości przy użyciu różnych współczynników może również zniekształcić kształty.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Pierwszy przykład zmienia bezpośrednio granice kształtów i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele osobno. Sprawdź uzyskany układ, szczególnie tekst i tabele, ponieważ te przykłady nie skalują rozmiarów czcionek, a zawartość tabel może ograniczać wysokość wierszy.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Skaluj szerokości kolumn przy użyciu współczynnika szerokości i minimalne wysokości wierszy przy użyciu współczynnika wysokości, a następnie skaluj pozycję tabeli, jak pokazano w drugim przykładzie.

**Czy to skalowanie działa dla slajdów wzorcowych i slajdów układu?**

Tak. Drugi przykład iteruje przez [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) oraz [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) każdego wzorca i stosuje tę samą logikę skalowania do ich kształtów.

**Czy mogę zmienić orientację slajdu (pionowa/pozioma) wraz ze skalowaniem?**

Tak. Wywołaj [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) po zmianie rozmiaru slajdu i przed odczytaniem docelowych wymiarów, aby współczynniki skali odzwierciedlały ostateczną orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Możesz określić niestandardowe wymiary slajdu za pomocą [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Obsługiwane wymiary zależą również od formatu prezentacji oraz aplikacji używanej do otwarcia pliku.

**Jak mogę zapobiec zniekształceniu kształtów o stałym stosunku proporcji?**

Użyj tego samego współczynnika skali dla szerokości i wysokości. Aby dopasować pierwotny układ do nowych wymiarów slajdu, zastosuj mniejszy z współczynników szerokości i wysokości zarówno do wymiarów, jak i do pozycji. To zachowuje proporcje, ale może pozostawić nieużywaną przestrzeń wzdłuż jednej krawędzi.