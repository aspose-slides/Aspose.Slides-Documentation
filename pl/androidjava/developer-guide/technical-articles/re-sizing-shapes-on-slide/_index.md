---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w Android
type: docs
weight: 130
url: /pl/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
- przeskaluj kształt
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Android w Javie — automatyzuj dostosowanie układu slajdów i zwiększ produktywność."
---
## **Omówienie**

Kiedy zmieniasz rozmiar slajdu prezentacji, możesz także potrzebować zmienić rozmiar i przemieścić jego kształty, aby pasowały do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty oraz jak obsługiwać tabele na slajdach, wzorcach i układach.

## **Zmiana rozmiaru kształtów**

Aby zachować względne położenie i rozmiar każdego kształtu, pomnóż jego współrzędne poziome oraz szerokość przez stosunek nowej szerokości slajdu do pierwotnej szerokości. Zastosuj odpowiadający stosunek wysokości do jego współrzędnych pionowych oraz wysokości.

Pierwszy przykład wczytuje prezentację, której slajdy nie zawierają tabel, zmienia rozmiar slajdu na A4 i zapisuje wynik. Używa [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) z [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale), aby pętla następująca po tym kontrolowała skalowanie. Stosunki są bezjednostkowe; pozycje i wymiary kształtów mierzone są w punktach. Różne współczynniki szerokości i wysokości mogą zniekształcać kształty, a zmiana wymiarów kształtu nie skaluje jego rozmiarów czcionki.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Oblicz niezależne współczynniki skalowania poziomego i pionowego.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabele wymagają oddzielnego traktowania: skaluj ich szerokości kolumn i wysokości wierszy zamiast przypisywać całkowitą szerokość i wysokość tabeli. Wysokości wierszy mogą pozostać większe niż zamówione, jeśli zawartość komórek wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty na wzorcach i układach, a także na poszczególnych slajdach przed zapisaniem zmienionej rozmiarowo prezentacji. Jego pomocnik obsługuje każdy [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , skalując szerokości kolumn przy użyciu [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) oraz minimalne wysokości wierszy przy użyciu [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Następnie skaluje pozycję tabeli bez osobnego skalowania jej całkowitych wymiarów.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Wymiary tabeli są kontrolowane przez szerokości kolumn i wysokości wierszy.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Oblicz niezależne współczynniki skalowania poziomego i pionowego.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Zmień rozmiar kształtów zdefiniowanych w wzorcach i układach oraz na poszczególnych slajdach.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, zachowają one swoje pierwotne pozycje i wymiary i mogą wykraczać poza slajd. Skalowanie szerokości i wysokości przy użyciu różnych współczynników może również zniekształcać kształty.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Pierwszy przykład zmienia bezpośrednio granice kształtów i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele oddzielnie. Sprawdź powstały układ, szczególnie tekst i tabele, ponieważ te przykłady nie skalują rozmiarów czcionek, a zawartość tabeli może ograniczać wysokość wierszy.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Skaluj szerokości kolumn przy użyciu współczynnika szerokości oraz minimalne wysokości wierszy przy użyciu współczynnika wysokości, a następnie skaluj pozycję tabeli, jak pokazano w drugim przykładzie.

**Czy to skalowanie zadziała dla slajdów wzorcowych i slajdów układu?**

Tak. Drugi przykład iteruje przez [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) oraz [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) każdego wzorca i stosuje tę samą logikę zmiany rozmiaru do ich kształtów.

**Czy mogę zmienić orientację slajdu (portret/poziom) wraz ze zmianą rozmiaru?**

Tak. Wywołaj [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) po zmianie rozmiaru slajdu i przed odczytaniem docelowych wymiarów, aby współczynniki skalowania odzwierciedlały ostateczną orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Możesz określić niestandardowe wymiary slajdu za pomocą [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Obsługiwane wymiary zależą również od formatu prezentacji oraz aplikacji używanej do otwarcia pliku.

**Jak mogę zapobiec zniekształceniu kształtów o stałym stosunku proporcji?**

Użyj tego samego współczynnika skalowania dla szerokości i wysokości. Aby dopasować oryginalny układ do nowych wymiarów slajdu, użyj mniejszego ze współczynników szerokości i wysokości zarówno dla wymiarów, jak i pozycji. To zachowuje proporcje, ale może pozostawić niezużyte miejsce wzdłuż jednej krawędzi.