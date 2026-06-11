---
title: Uzyskaj granice akapitu z prezentacji w Pythonie
linktitle: Akapit
type: docs
weight: 60
url: /pl/python-net/paragraph/
keywords:
- granice akapitu
- granice fragmentu tekstu
- współrzędne akapitu
- współrzędne fragmentu
- rozmiar akapitu
- rozmiar fragmentu tekstu
- ramka tekstowa
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu i fragmentu tekstu w Aspose.Slides dla Pythona poprzez .NET, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów oraz fragmentów tekstu w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu w `TextFrame` za pomocą `get_rect()`, jak uzyskać współrzędne akapitu i fragmentu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję na piksele oraz wartości efektywnego formatowania akapitu.

## **Uzyskiwanie współrzędnych akapitu i fragmentu w TextFrame**
Przy użyciu Aspose.Slides dla Pythona poprzez .NET programiści mogą teraz uzyskać prostokątne współrzędne akapitu w kolekcji akapitów TextFrame. Umożliwia to również pobranie współrzędnych fragmentu w kolekcji fragmentów akapitu. W tym temacie pokażemy na przykładzie, jak uzyskać prostokątne współrzędne akapitu wraz z pozycją fragmentu w akapicie.

## **Uzyskiwanie prostokątnych współrzędnych akapitu**
Dodano nową metodę **GetRect()**. Umożliwia ona pobranie prostokąta granic akapitu.

```py
import aspose.slides as slides

# Utwórz obiekt Presentation reprezentujący plik prezentacji
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Uzyskiwanie rozmiaru akapitu i fragmentu wewnątrz ramki tekstowej komórki tabeli** ##

Aby uzyskać rozmiar i współrzędne [Fragmentu](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/) lub [Akapitu](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) w ramce tekstowej komórki tabeli, możesz użyć metod [IPortion.GetRect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iportion/) i [IParagraph.GetRect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iparagraph/).

Poniższy kod przykładowy demonstruje opisaną operację:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **FAQ**

**W jakich jednostkach zwracane są współrzędne akapitu i fragmentów tekstu?**

W punktach, gdzie 1 cal = 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [zawijanie](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/wrap_text/) jest włączone w [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/), tekst łamie się, aby dopasować do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przekształcić na piksele w wyeksportowanym obrazie?**

Tak. Konwertuj punkty na piksele używając: pixels = points × (DPI / 72). Wynik zależy od DPI wybranego do renderowania/eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [struktury danych efektywnego formatowania akapitu](/slides/pl/python-net/shape-effective-properties/); zwraca ona ostateczne, skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.