---
title: Tabela
type: docs
weight: 120
url: /pl/python-net/examples/elements/table/
keywords:
- tabela
- dodaj tabelę
- dostęp do tabeli
- usuń tabelę
- scal komórki
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i formatuj tabele w Pythonie przy użyciu Aspose.Slides: wstawiaj dane, scalaj komórki, stylizuj krawędzie, wyrównuj zawartość oraz importuj/eksportuj pliki PPT, PPTX i ODP."
---
Przykłady dodawania tabel, uzyskiwania do nich dostępu, usuwania ich oraz scalania komórek przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj tabelę**

Utwórz prostą tabelę z dwoma wierszami i dwoma kolumnami.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Określ szerokości kolumn i wysokości wierszy.
        widths = [80, 80]
        heights = [30, 30]

        # Dodaj kształt tabeli do slajdu.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do tabeli**

Pobierz pierwszy kształt tabeli na slajdzie.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszej tabeli na slajdzie.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Usuń tabelę**

Usuń tabelę ze slajdu.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest tabelą.
        table = slide.shapes[0]

        # Usuń tabelę ze slajdu.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Scal komórki tabeli**

Scal sąsiadujące komórki tabeli w jedną komórkę.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest tabelą.
        table = slide.shapes[0]

        # Scal komórki.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```