---
title: Zarządzanie tabelami prezentacji w Pythonie
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/python-net/manage-table/
keywords:
- dodaj tabelę
- utwórz tabelę
- dostęp do tabeli
- proporcje
- wyrównaj tekst
- formatowanie tekstu
- styl tabeli
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona w środowisku .NET. Odkryj proste przykłady kodu, aby usprawnić swoje procesy pracy z tabelami."
---
## **Wprowadzenie**

Tabele w programie PowerPoint organizują informacje w wierszach i kolumnach, ułatwiając odczytywanie i porównywanie wartości.

Aspose.Slides udostępnia klasy [Tabela](https://reference.aspose.com/slides/python-net/aspose.slides/table/) i [Komórka](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) oraz inne typy, które pozwalają tworzyć, aktualizować i zarządzać tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

Utwórz tabelę, określając jej pozycję, szerokości kolumn i wysokości wierszy. Po dodaniu jej do slajdu możesz formatować obramowania komórek, scalać komórki i wstawiać tekst.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Zdefiniuj listę szerokości kolumn w punktach.
4. Zdefiniuj listę wysokości wierszy w punktach.
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) do slajdu za pomocą metody [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Iteruj po każdej [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/), aby zastosować formatowanie do górnego, dolnego, prawego i lewego obramowania.
7. Scal pierwsze dwie komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do scalonej komórki poprzez jej właściwość [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Ustaw tekst w scalonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład tworzy tabelę z trzema kolumnami i pięcioma wierszami w punkcie (100, 50). Nakłada czerwone obramowania o szerokości 5 punktów, scala pierwsze dwie komórki w pierwszym wierszu i zapisuje wynik jako `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli indeksy komórek są zerowe i używają kolejności (kolumna, wiersz). Pierwsza komórka ma indeks (0, 0). W języku Python dostęp do komórki uzyskuje się za pomocą `table.rows[row_index][column_index]`; indeks wiersza występuje jako pierwszy w tym wyrażeniu.

Na przykład, komórki w tabeli z 4 kolumnami i 4 wierszami są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten przykład tworzy powyższą tabelę 4 × 4, z szerokościami kolumn i wysokościami wierszy wynoszącymi 70 punktów oraz czerwonymi obramowaniami komórek o szerokości 5 punktów. Współrzędne ilustrują indeksy komórek; przykład pozostawia komórki puste i zapisuje tabelę jako `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do istniejącej tabeli**

Tabele są przechowywane w kolekcji kształtów slajdu. Przejdź przez kształty, aby zlokalizować tabelę, a następnie użyj klasy [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) aby odczytać lub zaktualizować jej komórki.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu zawierającego tabelę, używając jego indeksu.
3. Iteruj po obiektach [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) i zatrzymuj się, gdy zostanie znaleziona tabela. Jeśli slajd zawiera kilka tabel, użyj [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) , aby zidentyfikować potrzebną.
4. Zaktualizuj tekst w docelowej komórce.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `UpdateExistingTable.pptx` i znajduje pierwszą tabelę na pierwszym slajdzie. Ustawia komórkę w kolumnie 0, wierszu 1 na `New` i zapisuje wynik jako `table1_out.pptx`. Wejście musi zawierać co najmniej jeden slajd, a pierwsza tabela na tym slajdzie musi mieć co najmniej jedną kolumnę i dwa wiersze.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Aby zmienić rozmiar wiersza w istniejącej tabeli i zrozumieć, dlaczego jej rzeczywista wysokość może przekraczać żądaną minimalną, zobacz [Kontrola wysokości wiersza](/slides/pl/python-net/manage-rows-and-columns/#control-row-height).

## **Znajdowanie komórki będącej właścicielem ramki tekstowej**

Gdy ogólny kod przetwarzający tekst otrzymuje [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) z tabeli, użyj właściwości [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/), aby uzyskać właścicielską [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Dla ramki tekstowej komórki tabeli, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) jest ustawione, a [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) ma wartość `None`, pomimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne za pośrednictwem właściwości tylko do odczytu [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) i [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) jest również tylko do odczytu: umożliwia nawigację do właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `None` przed jej użyciem.

Dla pełnego przykładu identyfikującego właścicieli komórek tabel i kształtów, w tym kształtów powiązanych z węzłami SmartArt, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/python-net/search-and-replace-text/).

## **Wyrównywanie tekstu w tabeli**

Możesz kontrolować pionowe zakotwiczenie i kierunek tekstu pojedynczych komórek tabeli. Przykład w tej sekcji wyśrodkowuje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) do slajdu.
4. Uzyskaj dostęp do obiektu [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) i ustaw jego tekst oraz kolor.
6. Ustaw w komórce właściwości [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) i [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/).
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 o szerokościach kolumn 120 punktów i wysokościach wierszy 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek w pierwszym wierszu i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

Użyj [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) , aby zastosować formatowanie tekstu do wszystkich komórek w tabeli. Jego przeciążenia akceptują formatowanie fragmentu, akapitu i ramki tekstowej, dzięki czemu możesz ustawić te właściwości bez iteracji po poszczególnych komórkach.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do obiektu [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) z slajdu.
4. Ustaw [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) dla tekstu.
5. Ustaw [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) oraz [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Ustaw [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, wyrównuje akapity do prawej z prawym marginesem 20 punktów i ustawia tekst pionowo. Sformatowana prezentacja jest zapisywana jako `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobieranie właściwości stylu tabeli**

Użyj [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) , aby odczytać lub przypisać wstępny styl tabeli. Ten przykład stosuje [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) do jednej tabeli, wypisuje nazwę presetu i przypisuje ten sam preset do drugiej tabeli. Obie tabele są zapisane w `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Zablokowanie proporcji tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) , aby zablokować ten stosunek dla tabeli.

Poniższy przykład otwiera `pres.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje bieżący stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`True`) i zapisuje wynik jako `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę włączyć kierunek odczytu od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia właściwość [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), a akapity mają [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Użycie obu zapewnia prawidłowy kolejność RTL i renderowanie wewnątrz komórek.

**Jak mogę zapobiec przenoszeniu lub zmianie rozmiaru tabeli w finalnym pliku?**

Użyj [blokady kształtów](/slides/pl/python-net/applying-protection-to-presentation/), aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady mają zastosowanie również do tabel.

**Czy wstawianie obrazu jako tła wewnątrz komórki jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/), aby wypełnić komórkę obrazem; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).