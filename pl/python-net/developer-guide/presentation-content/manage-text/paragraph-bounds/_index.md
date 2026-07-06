---
title: Pobierz granice akapitu z prezentacji w Pythonie
linktitle: Granice akapitu
type: docs
weight: 43
url: /pl/python-net/paragraph-bounds/
keywords:
- granice akapitu
- współrzędne akapitu
- rozmiar akapitu
- ramka tekstowa
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu w Aspose.Slides dla Pythona przy użyciu .NET, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu z [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) przy użyciu [Paragraph.get_rect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/get_rect/), jak uzyskać współrzędne akapitu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję na piksele i efektywne wartości formatowania akapitu.

## **Pobierz prostokątne współrzędne akapitu**

Użyj [Paragraph.get_rect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/get_rect/), aby uzyskać prostokąt ograniczający akapit.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Pobierz rozmiar akapitu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) w ramce tekstowej komórki tabeli, użyj [Paragraph.get_rect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/get_rect/). Zwrócony prostokąt jest względem ramki tekstowej komórki tabeli, więc dodaj pozycję tabeli i offset komórki, gdy potrzebujesz współrzędnych na poziomie slajdu.

Poniższy przykład pobiera granice akapitu wewnątrz komórki tabeli i rysuje prostokąty na slajdzie, aby zwizualizować te granice:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**W jakich jednostkach mierzone są współrzędne akapitu?**

Są mierzone w punktach, gdzie 1 cal równa się 72 punktom. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/wrap_text/) jest włączone dla [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/), tekst łamie się, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy można wiarygodnie przemapować współrzędne akapitu na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele, używając tej formuły: piksele = punkty x (DPI / 72). Wynik zależy od wybranego DPI dla renderowania lub eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [effective paragraph formatting data structure](/slides/pl/python-net/shape-effective-properties/); zwraca ona ostateczne, skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.