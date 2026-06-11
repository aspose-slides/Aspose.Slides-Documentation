---
title: "Zarządzanie częściami tekstu w prezentacjach przy użyciu Pythona"
linktitle: "Część tekstowa"
type: docs
weight: 70
url: /pl/python-net/portion/
keywords:
- "część tekstowa"
- "fragment tekstu"
- "współrzędne tekstu"
- "pozycja tekstu"
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać częściami tekstu w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w środowisku .NET, zwiększając wydajność i możliwości dostosowywania."
---
## **Wprowadzenie**

Część tekstowa reprezentuje określony fragment tekstu wewnątrz akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides części można używać, gdy potrzebujesz pobrać pozycję fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

## **Pobieranie współrzędnych części tekstu**

Metoda [get_coordinates](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/get_coordinates/) została dodana do klasy [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/), co umożliwia pobranie współrzędnych części tekstu:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Czy mogę zastosować hiperlink tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperlink](/slides/pl/python-net/manage-hyperlinks/) do pojedynczej części; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co nadpisuje Portion, a co jest pobierane z Paragraph/TextFrame?**

Właściwości poziomu Portion mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona w [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/), silnik pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/); jeśli nie jest tam ustawiona, pobiera ją z [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) lub ze stylu [theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/theme/).

**Co się stanie, jeśli czcionka określona dla Portion jest nieobecna na docelowej maszynie/serwerze?**

Obowiązują [zasady podstawiania czcionek](/slides/pl/python-net/font-selection-sequence/). Tekst może ulec przemieszczeniu: metryki, podział wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla Portion, niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.