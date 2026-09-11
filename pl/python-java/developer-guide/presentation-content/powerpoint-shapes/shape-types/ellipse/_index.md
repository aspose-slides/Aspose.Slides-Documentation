---
title: Dodawanie elips do prezentacji w Pythonie poprzez Java
linktitle: Elipsa
type: docs
weight: 30
url: /pl/python-java/ellipse/
keywords:
- elipsa
- kształt
- dodaj elipsę
- utwórz elipsę
- rysuj elipsę
- sformatowana elipsa
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, formatować i manipulować kształtami elips w Aspose.Slides dla Pythona poprzez Javę w prezentacjach PPT i PPTX — przykłady kodu w Pythonie włączone."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać elipsy do slajdów PowerPoint przy użyciu Aspose.Slides. Omówiono tworzenie prostej elipsy, tworzenie elipsy sformatowanej oraz zapisywanie zaktualizowanej prezentacji jako plik PPTX. Poruszono również powiązane zagadnienia, takie jak praca z pozycją i rozmiarem elipsy, kontrola kolejności warstw oraz stosowanie efektów animacji.

## **Utworzenie elipsy**

Aby dodać prostą elipsę do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj odwołanie do slajdu po jego indeksie.
- Dodaj elipsę przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) obiektu [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje elipsę do pierwszego slajdu:

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

    # Dodaj kształt elipsy.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Zapisz plik PPTX na dysku.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utworzenie sformatowanej elipsy**

Aby dodać sformatowaną elipsę do slajdu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj odwołanie do slajdu po jego indeksie.
- Dodaj elipsę przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) obiektu [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/).
- Ustaw typ wypełnienia elipsy na stały.
- Ustaw kolor wypełnienia elipsy za pomocą metody [getSolidFillColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/#getSolidFillColor) na obiekcie [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/) powiązanym z obiektem [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/).
- Ustaw kolor obramowania elipsy.
- Ustaw szerokość obramowania elipsy.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje sformatowaną elipsę do pierwszego slajdu prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt elipsy.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Sformatuj wypełnienie elipsy.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Sformatuj obramowanie elipsy.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Zapisz plik PPTX na dysku.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jak ustawić dokładną pozycję i rozmiar elipsy względem jednostek slajdu?**

Współrzędne i rozmiary są zazwyczaj podawane **w punktach**. Aby uzyskać przewidywalne wyniki, oparuj obliczenia o rozmiar slajdu i przed przypisaniem wartości przelicz wymagane milimetry lub cale na punkty.

**Jak umieścić elipsę nad lub pod innymi obiektami (kontrola kolejności warstw)?**

Dostosuj kolejność rysowania obiektu, przenosząc go na wierzch lub wysyłając na spód. Dzięki temu elipsa może nakładać się na inne obiekty lub odsłonić te znajdujące się pod nią.

**Jak animować pojawienie się lub podkreślenie elipsy?**

[Zastosuj](/slides/pl/python-java/shape-animation/) efekty wejścia, podkreślenia lub wyjścia do kształtu, oraz skonfiguruj wyzwalacze i timing, aby określić, kiedy i jak animacja będzie odtwarzana.