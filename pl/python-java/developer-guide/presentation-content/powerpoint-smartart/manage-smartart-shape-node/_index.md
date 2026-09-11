---
title: Zarządzanie węzłami kształtu SmartArt w prezentacjach przy użyciu Pythona
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/python-java/manage-smartart-shape-node/
keywords:
- węzeł SmartArt
- podwęzeł
- dodaj węzeł
- pozycja węzła
- dostęp do węzła
- usuń węzeł
- niestandardowa pozycja
- węzeł pomocniczy
- format wypełnienia
- renderowanie węzła
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT i PPTX przy użyciu Aspose.Slides for Python via Java. Otrzymaj przejrzyste przykłady kodu i wskazówki ułatwiające tworzenie prezentacji."
---
## **Przegląd**

Grafiki SmartArt w prezentacjach PowerPoint są organizowane za pomocą węzłów, które zawierają tekst i definiują strukturę diagramu. Aspose.Slides umożliwia programowe operowanie na tych węzłach SmartArt: dodawanie nowych węzłów i ich podwęzłów, wstawianie podwęzłów w określonej pozycji, dostęp do istniejących węzłów oraz odczyt ich tekstu, poziomu i pozycji.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtu SmartArt. Pokazuje, jak usuwać węzły, pracować z podwęzłami według indeksu lub pozycji, zmienić węzeł pomocniczy na węzeł zwykły, dostosować pozycję, rozmiar i obrót kształtów węzłów SmartArt, ustawić format wypełnienia węzła oraz wygenerować miniaturę podwęzła SmartArt.

## **Dodaj węzeł SmartArt**
Aspose.Slides for Python via Java udostępnia interfejs API do zarządzania kształtami SmartArt. Poniższy przykład dodaje węzeł i podwęzeł do kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Iteruj po wszystkich kształtach na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).  
5. [Dodaj nowy węzeł](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnodecollection/#addNode) do [kolekcji węzłów](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/#getAllNodes) kształtu SmartArt i ustaw jego tekst za pomocą [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/).  
6. [Dodaj](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnodecollection/#addNode) [podwęzeł](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#getChildNodes) do nowego węzła i ustaw jego tekst za pomocą [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/).  
7. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj węzeł SmartArt w określonej pozycji**
Poniższy przykład dodaje podwęzeł w określonej pozycji w węźle SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/) z układem [StackedList](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartlayouttype/#StackedList) do slajdu.  
4. Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.  
5. Dodaj podwęzeł do wybranego węzła na pozycji 2 przy użyciu [addNodeByPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) i ustaw jego tekst.  
6. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp do węzła SmartArt**
Poniższy przykład uzyskuje dostęp do węzłów w kształcie SmartArt. Układ zwracany przez [getLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/#getLayout) jest tylko do odczytu i jest ustawiany w momencie dodania kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Iteruj po wszystkich kształtach na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).  
5. Iteruj po wszystkich [węzłach](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/#getAllNodes) w kształcie SmartArt.  
6. Odczytaj i wyświetl pozycję, poziom oraz tekst każdego węzła SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Dostęp do podwęzła SmartArt**
Poniższy przykład uzyskuje dostęp do podwęzłów każdego węzła w kształcie SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Iteruj po wszystkich kształtach na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).  
5. Iteruj po wszystkich [węzłach](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/#getAllNodes) w kształcie SmartArt.  
6. Dla każdego węzła iteruj po jego [podwęzłach](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#getChildNodes).  
7. Odczytaj i wyświetl pozycję, poziom oraz tekst [podwęzła](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Dostęp do podwęzła SmartArt w określonej pozycji**
Poniższy przykład uzyskuje dostęp do podwęzła w określonym indeksie w kolekcji jego węzła nadrzędnego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Dodaj kształt SmartArt z układem [StackedList](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartlayouttype/#StackedList).  
4. Uzyskaj dostęp do dodanego kształtu SmartArt.  
5. Uzyskaj dostęp do węzła o indeksie 0 w kształcie SmartArt.  
6. Uzyskaj dostęp do podwęzła o indeksie 1 przy użyciu [get_Item](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnodecollection/#get_Item).  
7. Odczytaj i wyświetl pozycję, poziom oraz tekst [podwęzła](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Usuń węzeł SmartArt**
Poniższy przykład usuwa węzeł z kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Iteruj po wszystkich kształtach na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).  
5. Sprawdź, czy kształt [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/) zawiera co najmniej jeden węzeł.  
6. Wybierz węzeł SmartArt do usunięcia.  
7. Usuń wybrany węzeł przy użyciu [removeNode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usuń węzeł SmartArt z określonej pozycji**
Poniższy przykład usuwa podwęzeł w określonym indeksie w kolekcji węzła SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Iteruj po wszystkich kształtach na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).  
5. Uzyskaj dostęp do węzła SmartArt o indeksie 0, jeśli istnieje.  
6. Sprawdź, czy wybrany węzeł SmartArt ma co najmniej dwa podwęzły.  
7. Usuń podwęzeł o indeksie 1 przy użyciu [removeNode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw niestandardową pozycję podwęzła w obiekcie SmartArt**
Aspose.Slides for Python via Java wspiera ustawianie pozycji [SmartArtShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartshape/) przy użyciu [setX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setX) i [setY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setY). Poniższy przykład ustawia niestandardową pozycję, rozmiar i obrót kształtów węzłów SmartArt. Dodawanie nowych węzłów przelicza pozycje i rozmiary wszystkich węzłów. Niestandardowe pozycjonowanie pozwala ułożyć węzły zgodnie z wymaganiami.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sprawdź węzeł pomocniczy**
{{% alert color="info" title="Uwaga" %}} 

Ta sekcja omawia kształty SmartArt dodawane do slajdów prezentacji programowo przy użyciu Aspose.Slides for Python via Java.

{{% /alert %}} 

W tym przykładzie użyto następującego źródłowego kształtu SmartArt.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Rysunek: Źródłowy kształt SmartArt na slajdzie**|

Poniższy przykład identyfikuje węzły pomocnicze w kolekcji węzłów SmartArt i zmienia je na węzły normalne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.  
2. Pobierz pierwszy slajd według jego indeksu.  
3. Iteruj po wszystkich kształtach na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).  
5. Iteruj po wszystkich węzłach w kształcie SmartArt i sprawdź, czy są [Węzłami pomocniczymi](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartnode/#isAssistant).  
6. Zmień każdy węzeł pomocniczy na węzeł normalny.  
7. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Rysunek: Zmienione węzły pomocnicze w kształcie SmartArt na slajdzie**|

## **Ustaw format wypełnienia węzła**
Aspose.Slides for Python via Java umożliwia dodawanie własnych kształtów SmartArt i ustawianie ich formatu wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz ustawiać ich format wypełnienia przy użyciu Aspose.Slides for Python via Java.

Proszę wykonać poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .  
2. Uzyskaj slajd według jego indeksu.  
3. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/) z układem [ClosedChevronProcess](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).  
4. Ustaw [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getFillFormat) dla węzłów kształtu SmartArt.  
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wygeneruj miniaturę podwęzła SmartArt**
Aby wygenerować miniaturę podwęzła SmartArt, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .  
2. [Dodaj kształt SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addSmartArt).  
3. Uzyskaj węzeł według jego indeksu.  
4. Pobierz obraz miniatury.  
5. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Czy animacja SmartArt jest obsługiwana?**

Tak. SmartArt jest traktowany jak zwykły kształt, więc możesz [zastosować standardowe animacje](/slides/pl/python-java/shape-animation/) (wejścia, wyjścia, podkreślenia, ścieżki ruchu) i dostosować timing. Możesz także animować kształty wewnątrz węzłów SmartArt w razie potrzeby.

**Jak mogę niezawodnie zlokalizować konkretny SmartArt na slajdzie, jeśli jego wewnętrzny identyfikator jest nieznany?**

Przypisz i wyszukuj po [alternatywnym tekście](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getAlternativeText). Ustawienie charakterystycznego alternatywnego tekstu w SmartArt pozwala znaleźć go programowo bez polegania na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwertowaniu prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiarygodnością wizualną podczas [eksportu do PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?**

Tak. Możesz renderować kształt SmartArt do [formatów rastrowych](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) lub do [SVG](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#writeAsSvgToBytes), aby uzyskać skalowalny wektorowy wynik, co czyni go odpowiednim do miniatur, raportów lub użycia w sieci.