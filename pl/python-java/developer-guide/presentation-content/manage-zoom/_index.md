---
title: Zarządzanie zoomem prezentacji w Pythonie via Java
linktitle: Zarządzaj zoomem
type: docs
weight: 60
url: /pl/python-java/manage-zoom/
keywords:
- zoom
- ramka zoomu
- zoom slajdu
- zoom sekcji
- zoom podsumowujący
- dodaj zoom
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz i dostosowuj Zoom za pomocą Aspose.Slides for Python via Java — przeskakuj między sekcjami, dodawaj miniatury i przejścia w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Zoomy w programie PowerPoint pozwalają przeskakiwać do i z określonych slajdów, sekcji i fragmentów prezentacji. Podczas prezentacji ta możliwość szybkiej nawigacji po treści może okazać się bardzo przydatna.

![overview_image](overview.png)

* Aby podsumować całą prezentację na jednym slajdzie, użyj [Zoom podsumowujący](#summary-zoom).
* Aby wyświetlić tylko wybrane slajdy, użyj [Zoom slajdu](#slide-zoom).
* Aby wyświetlić tylko jedną sekcję, użyj [Zoom sekcji](#section-zoom).

## **Zoom slajdu**
Zoom slajdu może uczynić Twoją prezentację bardziej dynamiczną, pozwalając na swobodne nawigowanie pomiędzy slajdami w dowolnej kolejności bez przerywania przebiegu prezentacji. Zoomy slajdów są świetne dla krótkich prezentacji bez wielu sekcji, ale możesz ich również używać w różnych scenariuszach prezentacji.

Zoomy slajdów pomagają zagłębiać się w wiele informacji, jednocześnie dając wrażenie pracy na jednym płótnie.

![overview_image](slidezoomsel.png)

Dla obiektów zoomu slajdu, Aspose.Slides udostępnia wyliczenie [ZoomImageType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomimagetype/) , klasę [ZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomframe/) oraz niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/) .

### **Utworzenie ramek zoomu**

Możesz dodać ramkę zoomu na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowe slajdy, do których zamierzasz połączyć ramki zoomu.
3. Dodaj tekst identyfikujący i tło do utworzonych slajdów.
4. Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak utworzyć ramkę zoomu na slajdzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowe slajdy do prezentacji
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Tworzy tło dla drugiego slajdu
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Tworzy pole tekstowe dla drugiego slajdu
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Tworzy tło dla trzeciego slajdu
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Tworzy pole tekstowe dla trzeciego slajdu
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Dodaje obiekty ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Utworzenie ramek zoomu z własnymi obrazami**
Z pomocą Aspose.Slides for Python via Java możesz utworzyć ramkę zoomu z innym podglądem slajdu w następujący sposób:
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowy slajd, do którego zamierzasz połączyć ramkę zoomu.
3. Dodaj tekst identyfikujący i tło do slajdu.
4. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji obrazów powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) , który zostanie użyty do wypełnienia ramki.
5. Dodaj ramki zoomu (zawierające odwołanie do utworzonego slajdu) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak utworzyć ramkę zoomu z innym obrazem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Tworzy tło dla drugiego slajdu
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Tworzy pole tekstowe dla drugiego slajdu
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Tworzy nowy obraz dla obiektu zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Dodaje obiekt ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formatowanie ramek zoomu**
W poprzednich sekcjach pokazaliśmy, jak utworzyć proste ramki zoomu. Aby utworzyć bardziej skomplikowane ramki zoomu, trzeba zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoomu.

Możesz kontrolować formatowanie ramki zoomu na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowe slajdy, do których zamierzasz połączyć ramki zoomu.
3. Dodaj tekst identyfikujący i tło do utworzonych slajdów.
4. Dodaj ramki zoomu (zawierające odwołania do utworzonych slajdów) do pierwszego slajdu.
5. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji obrazów powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) , który zostanie użyty do wypełnienia ramki.
6. Ustaw własny obraz dla pierwszego obiektu ramki zoomu.
7. Zmień format linii dla drugiego obiektu ramki zoomu.
8. Usuń tło z obrazu drugiego obiektu ramki zoomu.
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak zmienić formatowanie ramki zoomu na slajdzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowe slajdy do prezentacji
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Tworzy tło dla drugiego slajdu
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Tworzy pole tekstowe dla drugiego slajdu
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Tworzy tło dla trzeciego slajdu
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Tworzy pole tekstowe dla trzeciego slajdu
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Dodaje obiekty ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Tworzy nowy obraz dla obiektu zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Ustawia własny obraz dla obiektu first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Ustawia format ramki zoomu dla obiektu second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Ustawienie: nie pokazuj tła dla obiektu second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom sekcji**

Zoom sekcji jest łączem do sekcji w Twojej prezentacji. Możesz używać zoomów sekcji, aby wrócić do sekcji, które chcesz szczególnie podkreślić. Albo możesz ich używać, aby uwidocznić, jak niektóre części Twojej prezentacji są ze sobą powiązane.

![overview_image](seczoomsel.png)

Dla obiektów zoomu sekcji, Aspose.Slides udostępnia klasę [SectionZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectionzoomframe/) oraz niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/) .

### **Utworzenie ramek zoomu sekcji**

Możesz dodać ramkę zoomu sekcji do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowy slajd.
3. Dodaj charakterystyczne tło do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoomu.
5. Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak utworzyć ramkę zoomu na slajdzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 1", slide)

    #  Dodaje obiekt SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Utworzenie ramek zoomu sekcji z własnymi obrazami**

Używając Aspose.Slides for Python via Java, możesz utworzyć ramkę zoomu sekcji z innym podglądem slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowy slajd.
3. Dodaj charakterystyczne tło do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoomu.
5. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji obrazów powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) , który zostanie użyty do wypełnienia ramki.
6. Dodaj ramkę zoomu sekcji (zawierającą odwołanie do utworzonej sekcji) do pierwszego slajdu.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak utworzyć ramkę zoomu z innym obrazem:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 1", slide)

    #  Tworzy nowy obraz dla obiektu zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Dodaje obiekt SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formatowanie ramek zoomu sekcji**

Aby utworzyć bardziej skomplikowane ramki zoomu sekcji, trzeba zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do ramki zoomu sekcji.

Możesz kontrolować formatowanie ramki zoomu sekcji na slajdzie w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowy slajd.
3. Dodaj charakterystyczne tło do utworzonego slajdu.
4. Utwórz nową sekcję, do której zamierzasz połączyć ramkę zoomu.
5. Dodaj ramkę zoomu sekcji (zawierającą odwołania do utworzonej sekcji) do pierwszego slajdu.
6. Zmień rozmiar i pozycję utworzonego obiektu zoomu sekcji.
7. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji obrazów powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) , który zostanie użyty do wypełnienia ramki.
8. Ustaw własny obraz dla utworzonego obiektu ramki zoomu sekcji.
9. Ustaw możliwość *powrotu do oryginalnego slajdu z połączonej sekcji*.
10. Usuń tło z obrazu obiektu ramki zoomu sekcji.
11. Zmień format linii dla obiektu ramki zoomu sekcji.
12. Zmień czas trwania przejścia.
13. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak zmienić formatowanie ramki zoomu sekcji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 1", slide)

    #  Dodaje obiekt SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Formatowanie dla SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom podsumowujący**

Zoom podsumowujący jest jak strona docelowa, na której wszystkie elementy Twojej prezentacji są wyświetlane jednocześnie. Podczas prezentacji możesz używać zoomu, aby przechodzić z jednego miejsca prezentacji do drugiego w dowolnej kolejności. Możesz być kreatywny, przeskakiwać do przodu lub wracać do fragmentów pokazu slajdów, nie przerywając płynności prezentacji.

![overview_image](sumzoomsel.png)

Dla obiektów zoomu podsumowującego, Aspose.Slides udostępnia klasy [SummaryZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomframe/) , [SummaryZoomSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomsection/) oraz [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomsectioncollection/) i niektóre metody w klasie [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/) .

### **Utworzenie zoomu podsumowującego**

Możesz dodać ramkę zoomu podsumowującego do slajdu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowe slajdy z charakterystycznym tłem i nowe sekcje dla utworzonych slajdów.
3. Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak utworzyć ramkę zoomu podsumowującego na slajdzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 1", slide)

    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 2", slide)

    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 3", slide)

    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 4", slide)

    #  Dodaje obiekt SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dodawanie i usuwanie sekcji zoomu podsumowującego**

Wszystkie sekcje w ramce zoomu podsumowującego są reprezentowane przez obiekty [SummaryZoomSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomsection/) , które są przechowywane w obiekcie [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomsectioncollection/) . Możesz dodać lub usunąć obiekt sekcji zoomu podsumowującego poprzez klasę [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomsectioncollection/) w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowe slajdy z charakterystycznym tłem i nowe sekcje dla utworzonych slajdów.
3. Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4. Dodaj nowy slajd i sekcję do prezentacji.
5. Dodaj utworzoną sekcję do ramki zoomu podsumowującego.
6. Usuń pierwszą sekcję z ramki zoomu podsumowującego.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak dodawać i usuwać sekcje w ramce zoomu podsumowującego:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 1", slide)

    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 2", slide)

    #  Dodaje obiekt SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Dodaje sekcję do podsumowania Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Usuwa sekcję z podsumowania Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formatowanie sekcji zoomu podsumowującego**

Aby utworzyć bardziej skomplikowane obiekty sekcji zoomu podsumowującego, trzeba zmienić formatowanie prostej ramki. Istnieje kilka opcji formatowania, które możesz zastosować do obiektu sekcji zoomu podsumowującego.

Możesz kontrolować formatowanie obiektu sekcji zoomu podsumowującego w ramce zoomu podsumowującego w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Utwórz nowe slajdy z charakterystycznym tłem i nowe sekcje dla utworzonych slajdów.
3. Dodaj ramkę zoomu podsumowującego do pierwszego slajdu.
4. Pobierz pierwszy obiekt sekcji zoomu podsumowującego z [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomsectioncollection/) .
5. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) przez dodanie obrazu do kolekcji obrazów powiązanej z obiektem [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) , który zostanie użyty do wypełnienia ramki.
6. Ustaw własny obraz dla obiektu sekcji zoomu podsumowującego.
7. Ustaw możliwość *powrotu do oryginalnego slajdu z połączonej sekcji*.
8. Zmień format linii dla obiektu sekcji zoomu podsumowującego.
9. Zmień czas trwania przejścia.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak zmienić formatowanie obiektu sekcji zoomu podsumowującego:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 1", slide)

    # Dodaje nowy slajd do prezentacji
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Dodaje nową sekcję do prezentacji
    presentation.getSections().addSection("Section 2", slide)

    #  Dodaje obiekt SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Pobiera pierwszy obiekt SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Formatowanie obiektu SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Zapisuje prezentację
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę kontrolować powrót do slajdu „rodzica” po wyświetleniu celu?**

Tak. [ZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomframe/) lub [SectionZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectionzoomframe/) obsługuje powrót do slajdu pochodzenia poprzez metodę [setReturnToParent](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomobject/#setReturnToParent), która po włączeniu odsyła widza po odwiedzeniu docelowej treści.

**Czy mogę dostosować „szybkość” lub czas trwania przejścia Zoom?**

Tak. Zoom obsługuje ustawienie czasu trwania przejścia za pomocą metody [setTransitionDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomobject/#setTransitionDuration), co pozwala kontrolować, jak długo trwa animacja skoku.

**Czy istnieją limity liczby obiektów Zoom, które prezentacja może zawierać?**

Nie ma udokumentowanego twardego limitu API. Praktyczne ograniczenia zależą od ogólnej złożoności prezentacji oraz wydajności odtwarzacza. Możesz dodawać wiele ramek Zoom, ale należy mieć na uwadze rozmiar pliku i czas renderowania.