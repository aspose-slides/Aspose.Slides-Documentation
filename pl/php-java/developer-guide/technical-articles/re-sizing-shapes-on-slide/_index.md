---
title: Przeskalowywanie kształtów na slajdach prezentacji w PHP
type: docs
weight: 130
url: /pl/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/przeskalowywanie-ksztaltow-na-slajdzie/
  - /pl/php-java/re-sizing-shapes-on-slide/
keywords:
- przeskalowanie kształtu
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Łatwo przeskaluj kształty na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java — automatyzuj dostosowanie układu slajdów i zwiększ wydajność."
---
## **Przegląd**

Kiedy zmieniasz rozmiar slajdu prezentacji, możesz także potrzebować zmienić rozmiar i przemieścić jego kształty, aby pasowały do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty i jak obsługiwać tabele na slajdach, szablonach i układach.

## **Zmiana rozmiaru kształtów**

Aby zachować względne położenie i rozmiar każdego kształtu, pomnóż jego współrzędne poziome i szerokość przez stosunek nowej szerokości slajdu do pierwotnej szerokości. Zastosuj odpowiadający stosunek wysokości do jego współrzędnych pionowych i wysokości.

Pierwszy przykład ładuje prezentację, której slajdy nie zawierają tabel, zmienia rozmiar slajdu na A4 i zapisuje wynik. Używa [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) z [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/), aby następna pętla kontrolowała skalowanie. Stosunki są bez jednostek; pozycje i wymiary kształtów są mierzone w punktach. Różne współczynniki szerokości i wysokości mogą zniekształcać kształty, a zmiana wymiarów kształtu nie skaluje rozmiarów czcionek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Oblicz niezależne współczynniki skalowania w poziomie i pionie.
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
Tabele wymagają osobnego przetwarzania: skaluj ich szerokości kolumn i wysokości wierszy zamiast przypisywać całkowitą szerokość i wysokość tabeli. Wysokości wierszy mogą pozostać większe niż żądane, jeśli zawartość komórek wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty w szablonach i układach, jak i na poszczególnych slajdach przed zapisaniem przeskalowanej prezentacji. Jego pomocnik obsługuje każdą [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) skalując szerokości kolumn za pomocą [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) oraz minimalne wysokości wierszy za pomocą [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Następnie skaluje pozycję tabeli bez oddzielnego skalowania jej całkowitych wymiarów.

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
    // Oblicz niezależne współczynniki skalowania w poziomie i pionie.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Przeskaluj kształty zdefiniowane w szablonach i układach oraz na pojedynczych slajdach.
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
Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, zachowają one pierwotne położenie i wymiary i mogą wystawać poza slajd. Skalowanie szerokości i wysokości różnymi współczynnikami może również zniekształcać kształty.

**Czy podany kod działa dla wszystkich typów kształtów?**  
Pierwszy przykład zmienia granice kształtów bezpośrednio i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele osobno. Sprawdź uzyskany układ, szczególnie tekst i tabele, ponieważ te przykłady nie skalują rozmiarów czcionek, a zawartość tabel może ograniczać wysokość wierszy.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**  
Skaluj szerokości kolumn według współczynnika szerokości i minimalne wysokości wierszy według współczynnika wysokości, a następnie skaluj pozycję tabeli, jak pokazano w drugim przykładzie.

**Czy to skalowanie działa dla slajdów szablonów i slajdów układów?**  
Tak. Drugi przykład iteruje przez [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) oraz [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) każdego szablonu i stosuje tę samą logikę zmiany rozmiaru do ich kształtów.

**Czy mogę zmienić orientację slajdu (portret/landscape) wraz ze zmianą rozmiaru?**  
Tak. Wywołaj [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) po zmianie rozmiaru slajdu i przed odczytaniem docelowych wymiarów, aby współczynniki skalowania uwzględniały ostateczną orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**  
Możesz określić niestandardowe wymiary slajdu za pomocą [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Obsługiwane wymiary zależą także od formatu prezentacji i aplikacji używanej do otwarcia pliku.

**Jak zapobiec zniekształceniu kształtów o stałym stosunku proporcji?**  
Użyj tego samego współczynnika skalowania dla szerokości i wysokości. Aby dopasować oryginalny układ do nowych wymiarów slajdu, zastosuj mniejszy z współczynników szerokości i wysokości zarówno do wymiarów, jak i pozycji. Zachowuje to proporcje, ale może pozostawić niewykorzystaną przestrzeń wzdłuż jednej krawędzi.