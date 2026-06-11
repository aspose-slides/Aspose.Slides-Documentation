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
description: "Aspose.Slides for Python via .NET ułatwia tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając możliwości automatyzacji prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe, a następnie umieścić w nim tekst. Aspose.Slides for Python udostępnia klasę [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) umożliwiającą dodanie kształtu zawierającego tekst.

{{% alert title="Info" color="info" %}}
Aspose.Slides udostępnia również klasę [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/). Jednak nie wszystkie kształty mogą zawierać tekst.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Dlatego, pracując z kształtem, któremu chcesz dodać tekst, warto sprawdzić i potwierdzić, że został on rzutowany przy użyciu klasy [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/). Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/), które jest właściwością klasy [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/). Zobacz sekcję [Aktualizuj tekst](/slides/pl/python-net/manage-textbox/#update-text) na tej stronie.
{{% /alert %}}

## **Tworzenie pól tekstowych na slajdach**

Aby utworzyć pole tekstowe na slajdzie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do pierwszego slajdu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) z `ShapeType.RECTANGLE` w wybranej pozycji na slajdzie.
4. Ustaw tekst w [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu.
5. Zapisz prezentację jako plik PPTX.

Poniższy przykład w języku Python implementuje te kroki:

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

## **Sprawdzenie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia właściwość [is_text_box](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/is_text_box/) klasy [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/), która pozwala określić, czy kształt jest polem tekstowym.

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

Zwróć uwagę, że jeśli dodasz [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) przy użyciu klasy [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/), właściwość `is_text_box` kształtu zwraca `False`. Jednak po dodaniu tekstu — za pomocą metody `add_text_frame` lub ustawiając właściwość `text` — `is_text_box` zwraca `True`.

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

## **Dodawanie kolumn do pól tekstowych**

Aspose.Slides udostępnia właściwości [column_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_count/) i [column_spacing](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/column_spacing/) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/) umożliwiające dodawanie kolumn do pól tekstowych. Możesz określić liczbę kolumn oraz ustawić odstęp (w punktach) pomiędzy kolumnami.

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

## **Aktualizacja tekstu**

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
                        portion.portion_format.font_bold = 1
  
    # Zapisz zmodyfikowaną prezentację.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodawanie pól tekstowych z hiperłączami**

Możesz wstawić odnośnik w polu tekstowym. Po kliknięciu pola tekstowego odnośnik zostanie otwarty.

Aby dodać pole tekstowe zawierające hiperłącze, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do pierwszego slajdu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) z `ShapeType.RECTANGLE` w wybranej pozycji na slajdzie.
4. Ustaw tekst w [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) kształtu.
5. Uzyskaj odwołanie do [HyperlinkManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkmanager/).
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

    # Ustaw hiperłącze dla tekstu części.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Zapisz prezentację jako plik PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a tekstowym placeholderem przy pracy z slajdami‑mistrzami?**

Placeholder ([placeholder](/slides/pl/python-net/manage-placeholder/)) dziedziczy styl/pozycję z [master](/slides/pl/python-net/aspose.slides/masterslide/) i może być nadpisany w [layouts](/slides/pl/python-net/aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się po przełączeniu układów.

**Jak wykonać masową zamianę tekstu w całej prezentacji bez modyfikacji tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do auto‑kształtów posiadających ramki tekstowe i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/)) poprzez przeglądanie ich kolekcji oddzielnie lub pomijanie tych typów obiektów.