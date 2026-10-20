---
title: Przeskalowywanie kształtów na slajdach prezentacji w PHP
type: docs
weight: 130
url: /pl/php-java/resizing-shapes-on-slide/
aliases:
  /php-java/przeskalowywanie-ksztaltow-na-slajdzie/
keywords:
  - przeskaluj kształt
  - zmień rozmiar kształtu
  - PowerPoint
  - OpenDocument
  - prezentacja
  - PHP
  - Aspose.Slides
description: "Łatwo przeskaluj kształty na slajdach PowerPoint i OpenDocument przy pomocy Aspose.Slides dla PHP via Java — automatyzuj dostosowywanie układu slajdów i zwiększaj wydajność."
---
## **Przegląd**

Kiedy zmieniasz rozmiar slajdu prezentacji, może być konieczne również przeskalowanie i przemieszczenie jego kształtów, aby pasowały do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty oraz jak obsługiwać tabele na slajdach, wzorcach i układach.

## **Przeskalowanie kształtów**

Aby zachować względne położenie i rozmiar każdego kształtu, pomnóż jego współrzędne poziome oraz szerokość przez stosunek nowej szerokości slajdu do szerokości pierwotnej. Zastosuj odpowiedni stosunek wysokości do jego współrzędnych pionowych oraz wysokości.

Pierwszy przykład ładuje prezentację, której slajdy nie zawierają tabel, zmienia rozmiar slajdu na format A4 i zapisuje wynik. Używa [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) wraz z [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/), aby kolejna pętla kontrolowała skalowanie. Stosunki są bez wymiaru; pozycje i wymiary kształtów są mierzone w punktach. Różne współczynniki szerokości i wysokości mogą zniekształcać kształty, a zmiana wymiarów kształtu nie skaluje rozmiarów czcionek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Oblicz niezależne czynniki skali poziomej i pionowej.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabele wymagają osobnego traktowania: skaluj ich szerokości kolumn i wysokości wierszy zamiast ustawiać ogólną szerokość i wysokość tabeli. Wysokości wierszy mogą pozostać większe niż żądane, jeśli zawartość komórek wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty na wzorcach oraz układach, a także na poszczególnych slajdach przed zapisaniem przeskalowanej prezentacji. Jego pomocnicza metoda obsługuje każdą [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) poprzez skalowanie szerokości kolumn przy użyciu [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) oraz minimalnych wysokości wierszy przy użyciu [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Następnie skaluje pozycję tabeli bez oddzielnego skalowania jej ogólnych wymiarów.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Wymiary tabeli są kontrolowane przez szerokości kolumn i wysokości wierszy.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
        // Oblicz niezależne czynniki skali poziomej i pionowej.
        $originalSize = $presentation->getSlideSize()->getSize();
        $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
        $targetSize = $presentation->getSlideSize()->getSize();
        $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
        $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

        $resizer = new ShapeResizer();

        // Przeskaluj kształty zdefiniowane na slajdach wzorcowych i układach oraz na poszczególnych slajdach.
        for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
            $master = $presentation->getMasters()->get_Item($masterIndex);
            $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

            for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
                $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
                $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
            }
        }

        for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
            $slide = $presentation->getSlides()->get_Item($slideIndex);
            $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
        }

        $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, pozostaną one w pierwotnych pozycjach i wymiarach i mogą wykraczać poza obszar slajdu. Skalowanie szerokości i wysokości przy użyciu różnych współczynników może także zniekształcać kształty.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Pierwszy przykład modyfikuje granice kształtów bezpośrednio i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele osobno. Sprawdź otrzymany układ, szczególnie tekst i tabele, ponieważ te przykłady nie skalują rozmiarów czcionek, a zawartość tabel może ograniczać wysokość wierszy.

**Jak przeskalować tabele przy zmianie rozmiaru slajdu?**

Skaluj szerokości kolumn zgodnie ze współczynnikiem szerokości i minimalne wysokości wierszy zgodnie ze współczynnikiem wysokości, a następnie skaluj pozycję tabeli, jak pokazano w drugim przykładzie.

**Czy to skalowanie będzie działało dla slajdów wzorcowych i układu?**

Tak. Drugi przykład iteruje po [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) oraz po [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) każdego wzorca i stosuje tę samą logikę zmiany rozmiaru do ich kształtów.

**Czy mogę zmienić orientację slajdu (portret/poziom) wraz ze zmianą rozmiaru?**

Tak. Wywołaj [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) po zmianie rozmiaru slajdu i przed odczytaniem wymiarów docelowych, aby współczynniki skali odzwierciedlały ostateczną orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Możesz określić własne wymiary slajdu przy użyciu [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Obsługiwane wymiary zależą również od formatu prezentacji oraz aplikacji używanej do otwarcia pliku.

**Jak mogę zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?**

Użyj tego samego współczynnika skali dla szerokości i wysokości. Aby dopasować oryginalny układ do nowych wymiarów slajdu, użyj mniejszego z współczynników szerokości i wysokości zarówno dla wymiarów, jak i pozycji. To zachowuje proporcje, ale może pozostawić niewykorzystaną przestrzeń wzdłuż jednej krawędzi.