---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu Pythona via Java
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/python-java/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- aktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Tworzenie, identyfikowanie, formatowanie i aktualizowanie pól tekstowych w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via Java."
---
## **Wprowadzenie**

W Aspose.Slides for Python via Java tekst slajdu jest przechowywany w ramach tekstowych, które należą do kształtów. Klasa [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) reprezentuje najczęstszy kształt zawierający tekst i udostępnia jego tekst poprzez metodę [AutoShape.getTextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Każdy kształt automatyczny dziedziczy po [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), ale nie każdy kształt jest kształtem automatycznym ani nie obsługuje ramki tekstowej. Podczas przetwarzania istniejącej prezentacji, sprawdź, czy kształt jest instancją [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) zanim uzyskasz dostęp do jego tekstu.
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe, dodaj kształt automatyczny do slajdu, dodaj tekst do jego ramki tekstowej i zapisz prezentację. Poniższy przykład tworzy prostokątne pole tekstowe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Współrzędne i wymiary przekazywane do [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) są mierzone w punktach. [AutoShape.addTextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#addTextFrame) inicjalizuje ramkę tekstową podanym tekstem.

## **Sprawdzenie, czy kształt jest polem tekstowym**

Użyj metody [AutoShape.isTextBox](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#isTextBox), aby określić, czy kształt automatyczny jest traktowany jako pole tekstowe. Jest to przydatne, gdy prezentacja zawiera zarówno kształty automatyczne zawierające tekst, jak i czysto graficzne.

![Pole tekstowe i kształt](istextbox.png)

Poniższy przykład przegląda każdy kształt automatyczny w prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Nowo dodany kształt automatyczny nie jest uznawany za pole tekstowe, dopóki nie zawiera niepustego tekstu. Możesz dostarczyć ten tekst za pomocą [AutoShape.addTextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#addTextFrame) lub [TextFrame.setText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#setText). Dodanie lub przypisanie pustego ciągu znaków powoduje, że [AutoShape.isTextBox](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#isTextBox) zwraca `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Pierwsze dwa wywołania wypisują `True`; ostatnie dwa wypisują `False`.

## **Znajdź kształt, który jest właścicielem ramki tekstowej**

Ogólny kod przetwarzający tekst może otrzymać obiekt [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj metody tylko do odczytu [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParentShape), aby przejść z powrotem do jego właściciela, czyli [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/).

Dla ramki tekstowej będącej własnością kształtu automatycznego lub innego kształtu zawierającego tekst, [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParentShape) zwraca właściciela, a [TextFrame.getParentCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParentCell) zwraca `None`. Sprawdź zwróconą wartość przed dostępem do niej. Aby zidentyfikować zarówno właścicieli kształtów, jak i komórek tabel, w tym kształty powiązane z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/python-java/search-and-replace-text/).

## **Dodanie kolumn do pola tekstowego**

Metoda [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setColumnCount) dzieli ramkę tekstową na kolumny, natomiast [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setColumnSpacing) ustawia odstęp między kolumnami w punktach. Oba ustawienia należą do [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/) i mogą być zmienione poprzez ramkę tekstową istniejącego pola tekstowego. Tekst przepływa pomiędzy kolumnami w obrębie tego samego kształtu; nie jest kontynuowany w innym kształcie.

Poniższy przykład tworzy pole tekstowe z trzema kolumnami i odstępem 10 punktów między kolumnami, zapisuje prezentację i odczytuje zapisane ustawienia z pliku wyjściowego:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Wyodrębnianie tekstu z poszczególnych kolumn**

Użyj [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#splitTextByColumns), aby pobrać tekst przypisany do każdej widocznej kolumny w istniejącej ramce tekstowej. Metoda zwraca jeden ciąg znaków dla każdej kolumny, w kolejności odczytu opartej na kolumnach. Ramka tekstowa z jedną kolumną zwraca tablicę z jednym elementem, a pusta kolumna jest reprezentowana pustym ciągiem znaków. Ciągi zawierają wyłącznie zwykły tekst; formatowanie na poziomie fragmentów nie jest zachowywane.

To jest przydatne, gdy potrzebujesz:
- Wyodrębnić tekst zachowując jego kolejność odczytu opartą na kolumnach.
- Indeksować lub porównywać zawartość slajdów wielokolumnowych.
- Wyeksportować każdą kolumnę do osobnego pliku, pola bazy danych lub innego miejsca docelowego.
- Sprawdzić, jak tekst jest redystrybuowany po zmianie liczby kolumn za pomocą [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setColumnCount), odstępu za pomocą [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setColumnSpacing), czcionki lub rozmiaru ramki tekstowej.

Metoda zgłasza tekst rozmieszczony w bieżącej [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/); nie przepływa automatycznie tekstu pomiędzy oddzielnymi kształtami lub polami tekstowymi. Rozdzielenie kolumn może zależeć od dostępnych czcionek i innych ustawień układu tekstu, więc upewnij się, że wymagane czcionki są dostępne, gdy istotna jest spójność wyników.

Poniższy przykład ładuje prezentację, znajduje pierwszy wielokolumnowy kształt automatyczny z ramką tekstową, odczytuje jego skonfigurowaną liczbę kolumn i zapisuje tekst z każdej kolumny do osobnego pliku. Kształty, które nie posiadają ramki tekstowej, są pomijane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Aktualizacja tekstu**

Aby zaktualizować tekst w całej prezentacji, przeiteruj slajdy i kształty, wybierz kształty automatyczne, a następnie edytuj ich fragmenty tekstu. Praca na poziomie fragmentu pozwala zmienić zarówno tekst, jak i formatowanie znaków.

Poniższy przykład zamienia każde wystąpienie `years` na `months` w tekście kształtów automatycznych i pogrubia każdy zmieniony fragment:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ta iteracja aktualizuje tekst tylko w kształtach automatycznych. Tekst przechowywany w tabelach, wykresach, SmartArt lub grupowanych kształtach wymaga przeglądania własnych kolekcji tych obiektów.

## **Dodanie pola tekstowego z hiperłączem**

Hiperłącze może być przypisane do konkretnego fragmentu tekstu, więc tylko ten tekst działa jako klikany odnośnik. Użyj [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), aby powiązać fragment z zewnętrznym URL.

Poniższy przykład tworzy tekst z linkiem i zapisuje go w prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem tekstowym (placeholder) na slajdzie wzorca lub układu?**

Symbol tekstowy ([placeholder](/slides/pl/python-java/manage-placeholder/)) może dziedziczyć pozycję i formatowanie z [slajdu wzorca](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/) lub [slajdu układu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/). Zwykłe pole tekstowe jest niezależnym kształtem na slajdzie, na którym zostało utworzone i nie przejmuje zachowania placeholdera po zmianie układu.

**Jak mogę zamienić tekst bez zmieniania tekstu w wykresach, tabelach lub SmartArt?**

Ogranicz przeglądanie do kształtów będących instancjami [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/), jak pokazano w przykładzie Aktualizacja tekstu. Wykresy, tabele i SmartArt przechowują tekst w własnych modelach obiektów, więc nie są modyfikowane przez tę pętlę.