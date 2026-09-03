---
title: Zarządzaj polami tekstowymi w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/python-net/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- zaktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz, identyfikuj, formatuj i aktualizuj pola tekstowe w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w technologii .NET."
---
## **Wprowadzenie**

W Aspose.Slides for Python via .NET tekst slajdu jest przechowywany w ramkach tekstowych należących do kształtów. Klasa [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) reprezentuje najczęstszy kształt zawierający tekst i udostępnia jego tekst poprzez właściwość [AutoShape.text_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Note" %}}

Każdy kształt automatyczny dziedziczy po [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/), ale nie każdy kształt jest kształtem automatycznym ani nie obsługuje ramki tekstowej. Podczas przetwarzania istniejącej prezentacji użyj `isinstance(shape, slides.AutoShape)`, aby sprawdzić typ kształtu przed dostępem do jego tekstu.

{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe, dodaj kształt automatyczny do slajdu, dodaj do jego ramki tekstowej tekst i zapisz prezentację. Poniższy przykład tworzy prostokątne pole tekstowe:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Współrzędne i wymiary przekazywane do [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_auto_shape/) są mierzone w punktach. [AutoShape.add_text_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/add_text_frame/) inicjalizuje ramkę tekstową podanym tekstem.

## **Sprawdzenie, czy kształt jest polem tekstowym**

Użyj właściwości [AutoShape.is_text_box](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/is_text_box/), aby określić, czy kształt automatyczny jest traktowany jako pole tekstowe. Jest to przydatne, gdy prezentacja zawiera zarówno kształty z tekstem, jak i czysto graficzne kształty automatyczne.

![Pole tekstowe i kształt](istextbox.png)

Poniższy przykład sprawdza każdy kształt automatyczny w prezentacji:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Nowo dodany kształt automatyczny nie jest uznawany za pole tekstowe, dopóki nie zawiera niepustego tekstu. Możesz dostarczyć ten tekst przy pomocy [AutoShape.add_text_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/add_text_frame/) lub [TextFrame.text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/text/). Dodanie lub przypisanie pustego ciągu ustawia [is_text_box](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/is_text_box/) na `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Pierwsze dwa wywołania wypisują `True`; ostatnie dwa wypisują `False`.

## **Znajdź kształt będący właścicielem ramki tekstowej**

Ogólny kod przetwarzający tekst może otrzymać obiekt [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj właściwości tylko do odczytu [TextFrame.parent_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_shape/), aby wrócić do jego właściciela – obiektu [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/).

Dla ramki tekstowej należącej do kształtu automatycznego lub innego kształtu zawierającego tekst, [parent_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_shape/) zawiera właściciela, a [TextFrame.parent_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_cell/) ma wartość `None`. Sprawdź zwróconą wartość przed dostępem do niej. Aby zidentyfikować zarówno właścicieli kształtów, jak i komórek tabel, w tym kształty powiązane z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/python-net/search-and-replace-text/).

## **Dodaj kolumny do pola tekstowego**

Właściwość [TextFrameFormat.column_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_count/) dzieli ramkę tekstową na kolumny, natomiast [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_spacing/) ustawia przerwę między kolumnami w punktach. Oba ustawienia należą do [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) i mogą być zmieniane poprzez ramkę tekstową istniejącego pola tekstowego. Tekst przepływa pomiędzy kolumnami w obrębie tego samego kształtu; nie kontynuuje się w innym kształcie.

Poniższy przykład tworzy pole tekstowe z trzema kolumnami, oddzielonymi odstępem 10 punktów, zapisuje prezentację i odczytuje zapisane ustawienia z pliku wyjściowego:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Wyodrębnianie tekstu z poszczególnych kolumn**

Użyj [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/split_text_by_columns/), aby pobrać tekst przypisany do każdej widocznej kolumny w istniejącej ramce tekstowej. Metoda zwraca jeden ciąg znaków dla każdej kolumny, w kolejności czytania kolumnowej. Ramka tekstowa z jedną kolumną zwraca listę z jednym elementem, a pusta kolumna jest reprezentowana pustym ciągiem. Ciągi zawierają wyłącznie tekst zwykły; formatowanie na poziomie fragmentu nie jest zachowywane.

Jest to przydatne, gdy potrzebujesz:

- Wyodrębnić tekst zachowując kolejność czytania opartą na kolumnach.
- Indeksować lub porównać zawartość slajdów wielokolumnowych.
- Wyeksportować każdą kolumnę do osobnego pliku, pola bazy danych lub innego miejsca docelowego.
- Zbadać, jak tekst jest rozdzielany po zmianie [TextFrameFormat.column_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_spacing/), czcionki lub rozmiaru ramki tekstowej.

Metoda raportuje tekst rozmieszczony w bieżącym [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/); nie przepływa automatycznie tekstu pomiędzy oddzielnymi kształtami lub polami tekstowymi. Rozkład kolumn może zależeć od dostępnych czcionek i innych ustawień układu tekstu, dlatego upewnij się, że wymagane czcionki są dostępne, gdy ważne są spójne wyniki.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Aktualizacja tekstu**

Aby zaktualizować tekst w całej prezentacji, iteruj po slajdach i kształtach, wybieraj kształty automatyczne, a następnie edytuj ich fragmenty tekstu. Praca na poziomie fragmentu pozwala zmienić zarówno tekst, jak i formatowanie znaków.

Poniższy przykład zastępuje każde wystąpienie `years` przez `months` w tekście kształtów automatycznych i sprawia, że każdy zmieniony fragment jest pogrubiony:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Ten przebieg aktualizuje tekst tylko w kształtach automatycznych. Tekst przechowywany w tabelach, wykresach, SmartArt lub grupowanych kształtach wymaga przeglądu ich własnych kolekcji.

## **Dodaj pole tekstowe z hiperłączem**

Hiperłącze może być przypisane do konkretnego fragmentu tekstu, dzięki czemu tylko ten fragment działa jako klikalny odnośnik. Użyj [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), aby połączyć fragment z zewnętrznym adresem URL.

Poniższy przykład tworzy tekst z linkiem i zapisuje go w prezentacji:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a tekstowym zastępnikiem na slajdzie głównym lub układu?**

[placeholder](/slides/pl/python-net/manage-placeholder/) może dziedziczyć pozycję i formatowanie z [master slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/) lub [layout slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/). Zwykłe pole tekstowe jest niezależnym kształtem na slajdzie, na którym zostało utworzone i nie przyjmuje zachowania zastępnika po zmianie układu.

**Jak mogę zastąpić tekst bez zmiany tekstu w wykresach, tabelach lub SmartArt?**

Ogranicz przeglądanie do instancji [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/), jak pokazano w przykładzie Aktualizacja tekstu. Wykresy, tabele i SmartArt przechowują tekst w własnych modelach obiektowych, więc nie są modyfikowane przez tę pętlę.