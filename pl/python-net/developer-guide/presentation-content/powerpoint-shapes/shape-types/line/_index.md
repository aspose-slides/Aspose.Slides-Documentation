---
title: Tworzenie kształtów linii w prezentacjach przy użyciu Pythona
linktitle: Linia
type: docs
weight: 50
url: /pl/python-net/line/
keywords:
- linia
- tworzenie linii
- dodawanie linii
- prosta linia
- konfigurowanie linii
- personalizacja linii
- styl kreskowania
- czubek strzałki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj manipulowanie formatowaniem linii w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides for Python via .NET obsługuje dodawanie różnych rodzajów kształtów do slajdów. W tym temacie zaczniemy pracę z kształtami poprzez dodawanie linii do slajdów. Korzystając z Aspose.Slides, programiści mogą nie tylko tworzyć proste linie, ale także rysować na slajdach niektóre ozdobne linie.

## **Tworzenie prostych linii**

Użyj Aspose.Slides, aby dodać prostą linię do slajdu jako prosty separator lub łącznik. Aby dodać prostą linię do wybranego slajdu w prezentacji, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) typu `LINE` przy użyciu metody `add_auto_shape` na obiekcie [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/).
4. Zapisz prezentację jako plik PPTX.

W poniższym przykładzie linia zostaje dodana do pierwszego slajdu prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Tworzenie linii w kształcie strzałki**

Aspose.Slides umożliwia konfigurowanie właściwości linii, aby były bardziej atrakcyjne wizualnie. Poniżej konfiguruje kilka właściwości linii, aby wyglądała jak strzałka. Wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) typu `LINE` przy użyciu metody `add_auto_shape` na obiekcie [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/).
4. Ustaw [styl linii](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linestyle/).
5. Ustaw szerokość linii.
6. Ustaw [styl kreskowania](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linedashstyle/) linii.
7. Ustaw [styl czubka strzałki](https://reference.aspose.com/slides/pl/python-net/aspose.slides/linearrowheadstyle/) oraz długość dla punktu początkowego linii.
8. Ustaw styl czubka strzałki oraz długość dla punktu końcowego linii.
9. Zapisz prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj automatyczny kształt typu LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Zastosuj formatowanie do linii.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Zapisz prezentację jako plik PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę przekonwertować zwykłą linię na łącznik, aby „przyciągała się” do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) typu [LINE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapetype/)) nie staje się automatycznie łącznikiem. Aby przyciągała się do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/python-net/aspose.slides/connector/) oraz [odpowiednich interfejsów API](/slides/pl/python-net/connector/) do połączeń.

**Co zrobić, jeśli właściwości linii są dziedziczone z motywu i trudno określić ostateczne wartości?**

[Przeczytaj skuteczne właściwości](/slides/pl/python-net/shape-effective-properties/) za pomocą klas [ILineFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ilinefillformateffectivedata/) — te już uwzględniają dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [obiekty blokady](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/auto_shape_lock/), które pozwalają [zablokować operacje edycji](/slides/pl/python-net/applying-protection-to-presentation/).