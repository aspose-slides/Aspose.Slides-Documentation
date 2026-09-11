---
title: Dodawanie prostokątów do prezentacji w Pythonie przy użyciu Java
linktitle: Prostokąt
type: docs
weight: 80
url: /pl/python-java/rectangle/
keywords:
- dodaj prostokąt
- utwórz prostokąt
- kształt prostokąta
- prosty prostokąt
- sformatowany prostokąt
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zwiększ jakość swoich prezentacji PowerPoint, dodając prostokąty przy użyciu Aspose.Slides dla Pythona poprzez Java — łatwo projektuj i modyfikuj kształty programowo."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty prostokątów do slajdów PowerPoint przy użyciu Aspose.Slides. Omówiono tworzenie prostego prostokąta, tworzenie sformatowanego prostokąta oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX.  
Zobaczysz również, jak zastosować podstawowe formatowanie prostokąta, takie jak jednolity kolor wypełnienia, kolor linii i szerokość linii. Dodatkowo sekcja FAQ artykułu wskazuje powiązane zadania związane z prostokątami, w tym zaokrąglone rogi, wypełnienia obrazem, efekty wizualne, hiperlinki, blokady kształtów, opcje eksportu oraz właściwości skuteczne.

## **Dodaj prostokąt do slajdu**

Aby dodać prosty prostokąt do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj odniesienie do slajdu na podstawie jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) typu prostokąt przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy prosty prostokąt do pierwszego slajdu prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt prostokąta.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Zapisz plik PPTX na dysku.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj sformatowany prostokąt do slajdu**

Aby dodać sformatowany prostokąt do slajdu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj odniesienie do slajdu na podstawie jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) typu prostokąt przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/).
- Ustaw [typ wypełnienia](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) prostokąta na solid.
- Ustaw kolor prostokąta przy użyciu metody [setColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/colorformat/#setColor) na stałym kolorze wypełnienia obiektu [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/), powiązanego z obiektem [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/).
- Ustaw kolor obramowania prostokąta.
- Ustaw szerokość obramowania prostokąta.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Powyższe kroki zostały zaimplementowane w poniższym przykładzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt prostokąta.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Sformatuj wypełnienie prostokąta.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Sformatuj obramowanie prostokąta.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Zapisz plik PPTX na dysku.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jak dodać prostokąt z zaokrąglonymi rogami?**

Użyj typu kształtu z zaokrąglonymi rogami [shape type](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/) i dostosuj promień rogu w właściwościach kształtu; zaokrąglenie można również zastosować dla każdego rogu osobno poprzez modyfikacje geometrii.

**Jak wypełnić prostokąt obrazem (teksturą)?**

Wybierz typ wypełnienia obrazu [fill type](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/), podaj źródło obrazu i skonfiguruj tryby [stretching/tiling modes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillmode/).

**Czy prostokąt może mieć cień i poświatę?**

Tak. [Outer/inner shadow, glow, and soft edges](/slides/pl/python-java/shape-effect/) są dostępne z regulowanymi parametrami.

**Czy mogę przekształcić prostokąt w przycisk z hiperlinkiem?**

Tak. [Assign a hyperlink](/slides/pl/python-java/manage-hyperlinks/) do zdarzenia kliknięcia kształtu (przejście do slajdu, pliku, adresu internetowego lub e‑maila).

**Jak mogę zabezpieczyć prostokąt przed przemieszczeniem i zmianami?**

[Use shape locks](/slides/pl/python-java/applying-protection-to-presentation/): możesz zabronić przemieszczania, zmiany rozmiaru, zaznaczania lub edycji tekstu, aby zachować układ.

**Czy mogę przekonwertować prostokąt na obraz rastrowy lub SVG?**

Tak. Możesz [render the shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) do obrazu o określonym rozmiarze/skali lub [export it as SVG](/slides/pl/python-java/create-shape-thumbnails/) do użytku wektorowego.

**Jak szybko uzyskać rzeczywiste (skuteczne) właściwości prostokąta uwzględniając motyw i dziedziczenie?**

[Use the shape’s effective properties](/slides/pl/python-java/shape-effective-properties/): API zwraca wyliczone wartości uwzględniające style motywu, układ oraz ustawienia lokalne, upraszczając analizę formatowania.