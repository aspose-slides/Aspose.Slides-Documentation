---
title: Pobierz granice fragmentu tekstu z prezentacji w Pythonie
linktitle: Granice fragmentu
type: docs
weight: 47
url: /pl/python-net/portion-bounds/
keywords:
- granice fragmentu tekstu
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice fragmentu tekstu w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Fragment tekstu reprezentuje określony fragment tekstu wewnątrz akapitu i umożliwia pracę z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty można używać, gdy trzeba pobrać granice fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać prostokąt ograniczający fragment za pomocą [Portion.get_rect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/get_rect/). Pokazuje także, jak uzyskać współrzędne początku fragmentu za pomocą [Portion.get_coordinates](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/get_coordinates/). Dodatkowo omawia typowe scenariusze związane z fragmentami, takie jak zastosowanie hiperłącza do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest rozwiązywane poprzez dziedziczenie z fragmentu, akapitu, ramki tekstowej i motywu, oraz obsługę przypadków, gdy określona czcionka jest niedostępna.

## **Uzyskanie granic fragmentu tekstowego**

Użyj [Portion.get_rect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/get_rect/) aby pobrać prostokąt ograniczający fragment tekstowy:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Uzyskanie współrzędnych fragmentu tekstowego**

Użyj [Portion.get_coordinates](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/get_coordinates/) aby pobrać współrzędne początku fragmentu tekstowego:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/python-net/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylu: co fragment nadpisuje, a co jest pobierane z akapitu lub ramki tekstowej?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/), Aspose.Slides pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/). Jeśli nie jest tam również ustawiona, Aspose.Slides używa stylu z [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) lub [theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu jest nieobecna na docelowym komputerze lub serwerze?**

[Font substitution rules](/slides/pl/python-net/font-selection-sequence/) mają zastosowanie. Tekst może się przestawić: metryki, dzielenie wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.