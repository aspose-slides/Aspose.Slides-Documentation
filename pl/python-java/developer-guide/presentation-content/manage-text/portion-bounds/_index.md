---
title: Uzyskiwanie granic fragmentu tekstu w prezentacjach w Pythonie za pośrednictwem Java
linktitle: Granice fragmentu
type: docs
weight: 47
url: /pl/python-java/portion-bounds/
keywords:
- granice fragmentu tekstu
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak pobierać granice fragmentu tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Fragment tekstu reprezentuje określony fragment tekstu w akapicie i umożliwia pracę z tym fragmentem niezależnie od otaczającej zawartości. W Aspose.Slides fragmenty mogą być używane, gdy potrzebujesz uzyskać granice fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać prostokąt ograniczający fragment, korzystając z [Portion.getRect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getRect). Pokazuje również, jak uzyskać współrzędne początku fragmentu przy użyciu [Portion.getCoordinates](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getCoordinates). Dodatkowo podkreśla typowe scenariusze związane z fragmentami, takie jak zastosowanie hiperłącza do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest dziedziczone przez fragment, akapit, ramkę tekstową i motyw, oraz obsługę przypadków, gdy określona czcionka nie jest dostępna.

## **Uzyskanie granic fragmentu tekstu**

Użyj [Portion.getRect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getRect), aby pobrać prostokąt ograniczający fragment tekstu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Uzyskanie współrzędnych fragmentu tekstu**

Użyj [Portion.getCoordinates](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getCoordinates), aby pobrać współrzędne początku fragmentu tekstu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/python-java/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylu: co fragment nadpisuje, a co jest pobierane z akapitu lub ramki tekstowej?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/), Aspose.Slides pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/). Jeśli nie jest ustawiona również tam, Aspose.Slides używa stylu z [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) lub [theme](https://reference.aspose.com/slides/pl/python-java/aspose.slides/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu jest nieobecna na docelowej maszynie lub serwerze?**

Zastosowane zostaną [zasady zastępowania czcionek](/slides/pl/python-java/font-selection-sequence/). Tekst może się przeflować: metryki, podziały wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przeźroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przeźroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.