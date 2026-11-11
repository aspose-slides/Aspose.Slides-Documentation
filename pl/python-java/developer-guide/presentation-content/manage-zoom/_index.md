---
title: Zarządzanie zoomem prezentacji w Pythonie via Java
linktitle: Zarządzanie Zoomem
type: docs
weight: 60
url: /pl/python-java/manage-zoom/
keywords:
- zoom
- ramka zoomu
- zoom slajdu
- zoom sekcji
- zoom podsumowania
- dodaj zoom
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz i dostosowuj Zoom przy użyciu Aspose.Slides for Python via Java — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PowerPoint."
---
## **Wprowadzenie**

PowerPoint zoomy pozwalają nawigować pomiędzy określonymi slajdami i sekcjami podczas pokazu slajdów. Dzięki Aspose.Slides for Python via Java można tworzyć zoomy slajdów, sekcji i podsumowania oraz dostosowywać ich miniatury, obramowania i przejścia.

![Przegląd zoomów PowerPoint](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Podsumowanie Zoomu](#summary-zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Zoom slajdu](#slide-zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Zoom sekcji](#section-zoom).

## **Zoom slajdu**

Zoom slajdu może uczynić Twoją prezentację bardziej dynamiczną, pozwalając na swobodne nawigowanie pomiędzy slajdami w dowolnej kolejności bez przerywania przepływu prezentacji. Zoomy slajdów są świetne dla krótkich prezentacji bez wielu sekcji, ale można ich używać w różnych scenariuszach.

Zoomy slajdów pozwalają na eksplorację powiązanych informacji z jednego slajdu podsumowującego.

![Wybieranie slajdów do zoomu slajdu](slidezoomsel.png)

Dla obiektów zoomu slajdu, Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/), klasę [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) oraz metody na klasie [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Utwórz ramki zoomu**

Użyj [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame), aby umieścić odnośniki do poszczególnych slajdów na slajdzie podsumowującym. Ten przykład tworzy dwa docelowe slajdy z odmiennymi tłami i etykietami, a następnie dodaje podgląd każdego z nich do pierwszego slajdu i zapisuje prezentację jako PPTX. Pozycje i rozmiary ramek podawane są w punktach.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz ramki zoomu z własnymi obrazami**

Przekaż własny obraz do [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame), aby zastąpić domyślny podgląd docelowego slajdu. Ten przykład wymaga lokalnego obrazu, ładuje go metodą [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) i dodaje go do prezentacji przy użyciu [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Wynikowa ramka wyświetla ten obraz, jednocześnie odwołując się do drugiego slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formatuj ramki zoomu**

Ten przykład dostosowuje dwie ramki zoomu slajdu. Przypisuje lokalny obraz do pierwszej ramki za pomocą [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) oraz nadaje drugiej ramce różowy obramowanie o grubości pięciu punktów, kreskowo-kropkowane, przy użyciu [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat). Przekazanie `False` do [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) ukrywa tło drugiej ramki. Do własnego podglądu wymagana jest lokalna grafika; obie ramki zachowują swoje docelowe slajdy w zapisanym pliku PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom sekcji**

Zoom sekcji odwołuje się do sekcji w Twojej prezentacji. Użyj go, aby ponownie odwiedzić temat lub pokazać, jak różne części prezentacji są ze sobą powiązane.

![Wybieranie sekcji do zoomu sekcji](seczoomsel.png)

Dla obiektów zoomu sekcji, Aspose.Slides udostępnia klasę [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) oraz metody na klasie [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Utwórz ramki zoomu sekcji**

Utwórz sekcję za pomocą [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection), a następnie przekaż zwróconą sekcję do [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame). Ten przykład umieszcza zoom sekcji na pierwszym slajdzie i łączy go z sekcją rozpoczynającą się od slajdu o określonym kolorze. Pozycje i rozmiary ramki podawane są w punktach, a prezentacja zapisywana jest jako PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utwórz ramki zoomu sekcji z własnymi obrazami**

Przeciążenie z obrazem metody [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) umożliwia wyświetlenie własnego podglądu bez zmiany docelowej sekcji. Ten przykład wymaga lokalnego obrazu, który jest ładowany przy pomocy [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) i dodawany za pomocą [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Zapisana prezentacja zawiera zoom sekcji na pierwszym slajdzie, połączony z nowo utworzoną sekcją.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zmień docelową sekcję zoomu sekcji**

Użyj [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection), aby przekierować istniejący zoom sekcji bez konieczności jego ponownego tworzenia. Wybierz wypełnioną sekcję z kolekcji [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) tej samej prezentacji. Przypisanie pustej sekcji pozostawia bieżący cel niezmieniony, więc przed przypisaniem sprawdź [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection). Zobacz [Manage Slide Sections](/slides/pl/python-java/slide-section/) po więcej informacji o sekcjach.

Poniższy przykład ładuje plik prezentacji, który musi zawierać wiele wypełnionych sekcji, istniejący zoom sekcji o nazwie `Section navigation` oraz sekcję o unikalnej nazwie `Results`. Przeszukuje wszystkie slajdy w poszukiwaniu zoomu i znajduje docelowy element po nazwie, a nie po indeksie kolekcji, który może się zmienić po przestawieniu sekcji. Jeśli nazwy nie są unikalne, użyj [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId), aby zidentyfikować docelowy element.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formatuj ramki zoomu sekcji**

Ten przykład przesuwa i zmienia rozmiar zoomu sekcji do 100 × 75 punktów, przypisuje lokalny obraz za pomocą [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) oraz stosuje brązowe obramowanie o grubości 2,5 punktu, kreskowo-kropkowane. Włącza [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent), aby po sekcji wrócić do slajdu źródłowego, wyłącza [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) oraz ustawia [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) na 1,5 sekundy. Do własnego podglądu wymagana jest lokalna grafika.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom podsumowania**

Zoom podsumowania zapewnia przegląd sekcji prezentacji. Podczas pokazu slajdów możesz go używać, aby przejść do sekcji, przeskoczyć do przodu lub powrócić do tematu bez podążania za kolejnością slajdów.

![Wybieranie sekcji do zoomu podsumowania](sumzoomsel.png)

Dla obiektów zoomu podsumowania, Aspose.Slides udostępnia klasy [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) oraz [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) oraz metody na klasie [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Utwórz zoom podsumowania**

Użyj [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame), aby stworzyć podgląd sekcji prezentacji. Ten przykład tworzy cztery sekcje z odmiennymi tłami slajdów i dodaje zoom podsumowania do pierwszego slajdu. Pozycje i rozmiary ramki podawane są w punktach, a wynikowy podgląd zapisywany jest w prezentacji PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dodaj i usuń sekcję zoomu podsumowania**

Zoom podsumowania przechowuje obiekty [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) w kolekcji zwracanej przez [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Ten przykład tworzy podgląd dwóch sekcji, dodaje trzecią sekcję przy użyciu [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) i usuwa wpis pierwszej sekcji przy użyciu [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Usunięcie wpisu pozostawia sekcję prezentacji i jej slajdy nietknięte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formatuj sekcje zoomu podsumowania**

Ten przykład formatuje pierwszy wpis w [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), korzystając z indeksu zerowego `0`. Wymaga lokalnego obrazu dla [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), stosuje czarne obramowanie o grubości 1,5 punktu, kreskowo-kropkowane oraz ustawia [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) na 1,5 sekundy. Przekazanie `False` do [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) wyłącza automatyczny powrót do slajdu podsumowującego dla tego wpisu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu 'nadrzędnego' po wyświetleniu celu?**

Tak. Wywołaj [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) z `True`, aby po wyświetleniu treści docelowej powrócić do slajdu źródłowego.

**Czy mogę dostosować 'szybkość' lub czas trwania przejścia Zoom?**

Tak. Użyj [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration), aby kontrolować czas trwania przejścia w sekundach.

**Czy istnieją ograniczenia co do liczby obiektów Zoom w jednej prezentacji?**

Nie ma udokumentowanego sztywnego limitu API. Ograniczenia praktyczne zależą od ogólnej złożoności prezentacji i wydajności urządzenia odtwarzającego. Można dodać wiele ramek Zoom, ale warto rozważyć rozmiar pliku i czas renderowania.