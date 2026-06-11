---
title: Zarządzanie fragmentami tekstu w prezentacjach na Androidzie
linktitle: Fragment tekstu
type: docs
weight: 70
url: /pl/androidjava/portion/
keywords:
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać fragmentami tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w Java, zwiększając wydajność i możliwości dostosowywania."
---
## **Wprowadzenie**

Fragment tekstu reprezentuje określony fragment tekstu wewnątrz akapitu i umożliwia pracę z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty można używać, gdy trzeba odczytać pozycję fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

## **Pobieranie współrzędnych fragmentu tekstu**
Metoda [**getCoordinates()**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPortion#getCoordinates--) została dodana do klasy [IPortion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/) i [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/), co umożliwia pobranie współrzędnych początku fragmentu.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Modyfikowanie kontekstu prezentacji
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/androidjava/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co nadpisuje fragment (Portion), a co jest pobierane z akapitu/ramki tekstowej?**

Właściwości na poziomie fragmentu (Portion) mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/), silnik pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraph/); jeśli nie jest tam ustawiona, z [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/) lub stylu [theme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu (Portion) jest nieobecna na docelowym komputerze/serwerze?**

[Zasady zastępowania czcionek](/slides/pl/androidjava/font-selection-sequence/) mają zastosowanie. Tekst może zostać ponownie ułożony: metryki, dzielenie wyrazów i szerokość mogą ulec zmianie, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu (Portion), niezależny od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.