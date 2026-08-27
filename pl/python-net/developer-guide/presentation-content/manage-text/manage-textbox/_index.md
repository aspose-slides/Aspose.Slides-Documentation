---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/python-net/manage-textbox/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ułatwia tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając automatyzację Twoich prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe, a następnie umieścić w nim tekst. Aspose.Slides for Python udostępnia klasę [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) , która pozwala dodać kształt zawierający tekst.

{{% alert title="Info" color="info" %}}
Aspose.Slides udostępnia także klasę [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) , jednak nie wszystkie kształty mogą zawierać tekst.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Dlatego przy pracy z kształtem, do którego chcesz dodać tekst, możesz chcieć sprawdzić i potwierdzić, że został on rzutowany przez klasę [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) . Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) , które jest właściwością klasy [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) . Zobacz sekcję [Aktualizuj tekst](/slides/pl/python-net/manage-textbox/#update-text) na tej stronie.
{{% /alert %}}

## **Utwórz pola tekstowe na slajdach**

Aby utworzyć pole tekstowe na slajdzie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2. Pobierz odwołanie do pierwszego slajdu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) z `ShapeType.RECTANGLE` w żądanej pozycji na slajdzie.
4. Ustaw tekst w [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu.
5. Zapisz prezentację jako plik PPTX.

Poniższy przykład w Pythonie implementuje te kroki:

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd w prezentacji.
    slide = presentation.slides[0]

    # Dodaj AutoShape typu RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Zapisz prezentację na dysku.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Sprawdź, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia właściwość [is_text_box](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/is_text_box/) na klasie [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) , która pozwala określić, czy kształt jest polem tekstowym.

![Pole tekstowe i kształt](istextbox.png)

Ten przykład w Pythonie pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Zauważ, że jeśli dodasz [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) przy użyciu klasy [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/) , właściwość `is_text_box` zwraca `False`. Jednak po dodaniu tekstu — przy użyciu metody `add_text_frame` lub ustawiając właściwość `text` — `is_text_box` zwraca `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box jest fałsz
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box jest prawda

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box jest fałsz
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box jest prawda

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box jest fałsz
    shape3.add_text_frame("")
    # shape3.is_text_box jest fałsz

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box jest fałsz
    shape4.text_frame.text = ""
    # shape4.is_text_box jest fałsz
```

## **Znajdź kształt będący właścicielem ramki tekstowej**

W ogólnym kodzie przetwarzania tekstu możesz otrzymać obiekt [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj właściwości [TextFrame.parent_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_shape/) , aby przejść z powrotem do właściciela, czyli [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) .

Dla ramki tekstowej należącej do [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) lub innego kształtu zawierającego tekst, właściwość [TextFrame.parent_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_shape/) jest ustawiona, a [TextFrame.parent_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_cell/) ma wartość `None`. Obie właściwości są tylko do odczytu, więc ich odczyt nie zmienia własności. Zawsze sprawdzaj zwróconą wartość pod kątem `None` przed dostępem do kształtu.

Pełny przykład identyfikujący właścicieli kształtów i komórek tabel, w tym kształty powiązane z węzłami SmartArt, znajdziesz w sekcji [Wyszukaj i zamień tekst](/slides/pl/python-net/search-and-replace-text/) .

## **Dodaj kolumny do pól tekstowych**

Aspose.Slides udostępnia właściwości [column_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_count/) oraz [column_spacing](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_spacing/) na klasie [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) , aby dodać kolumny do pól tekstowych. Możesz określić liczbę kolumn oraz ustawić odstęp (w punktach) między kolumnami.

Poniższy kod w Pythonie demonstruje tę operację:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Pobierz pierwszy slajd w prezentacji.
	slide = presentation.slides[0]

	# Dodaj AutoShape typu RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Dodaj TextFrame do prostokąta.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Pobierz format tekstu TextFrame.
	format = shape.text_frame.text_frame_format

	# Określ liczbę kolumn w TextFrame.
	format.column_count = 3

	# Określ odstęp między kolumnami.
	format.column_spacing = 10

	# Zapisz prezentację.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Zaktualizuj tekst**

Aspose.Slides umożliwia aktualizację tekstu w pojedynczym polu tekstowym lub w całej prezentacji.

Poniższy przykład w Pythonie pokazuje, jak zaktualizować cały tekst w prezentacji:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Zapisz zmodyfikowaną prezentację.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj pola tekstowe z hiperłączami**

Możesz wstawić odnośnik w polu tekstowym. Po kliknięciu pola tekstowego odnośnik się otwiera.

Aby dodać pole tekstowe zawierające hiperłącze, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2. Pobierz odwołanie do pierwszego slajdu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) z `ShapeType.RECTANGLE` w żądanej pozycji na slajdzie.
4. Ustaw tekst w [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu.
5. Pobierz odwołanie do [HyperlinkManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/) .
6. Użyj właściwości `hyperlink_manager`, aby ustawić zewnętrzne hiperłącze kliknięcia.
7. Zapisz prezentację jako plik PPTX.

Ten przykład w Pythonie pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    # Pobierz pierwszy slajd w prezentacji.
    slide = presentation.slides[0]

    # Dodaj AutoShape typu RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Dodaj tekst do ramki.
    text_portion.text = "Aspose.Slides"

    # Ustaw hiperłącze dla tekstu fragmentu.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Zapisz prezentację jako plik PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a placeholderem tekstu przy pracy z głównymi slajdami?**

Symbol zastępczy [placeholder](/slides/pl/python-net/manage-placeholder/) dziedziczy styl/pozycję z [master](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/) i może być nadpisany na [layouts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/) , podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się przy przełączaniu układów.

**Jak mogę przeprowadzić masową zamianę tekstu w całej prezentacji, nie modyfikując tekstu wewnątrz wykresów, tabel i SmartArt?**

Ogranicz iterację do auto‑kształtów posiadających ramki tekstowe i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/) , [tables](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) , [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/) ) poprzez osobne przeglądanie ich kolekcji lub pomijanie tych typów obiektów.