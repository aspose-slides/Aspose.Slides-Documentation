---
title: Zarządzanie fragmentami tekstu w prezentacjach przy użyciu Javy
linktitle: Fragment tekstu
type: docs
weight: 70
url: /pl/java/portion/
keywords:
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać fragmentami tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy, zwiększając wydajność i możliwości dostosowywania."
---
## **Przegląd**

Fragment tekstu reprezentuje konkretny fragment tekstu wewnątrz akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty można wykorzystać, gdy trzeba pobrać pozycję fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać współrzędne początku fragmentu przy użyciu metody `getCoordinates()`. Przedstawia także typowe scenariusze związane z fragmentami, takie jak dodawanie hiperłącza do pojedynczego fragmentu tekstu, rozumienie, jak formatowanie jest rozwiązywane poprzez dziedziczenie z fragmentu, akapitu, ramki tekstowej i motywu oraz obsługę sytuacji, gdy określona czcionka jest niedostępna. Dodatkowo zaznacza, że wypełnienie tekstu, kolor i przezroczystość mogą być ustawione inaczej dla poszczególnych fragmentów w tym samym akapicie.

## **Pobieranie współrzędnych fragmentu tekstu**
[**getCoordinates()**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortion#getCoordinates--) metoda została dodana do klasy [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/) i [Portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portion/), co umożliwia pobranie współrzędnych początku fragmentu.

```java
// Utwórz klasę Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Przekształcanie kontekstu prezentacji
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

**Czy mogę zastosować hiperlink tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperlink](/slides/pl/java/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co nadpisuje fragment (Portion), a co jest dziedziczone z akapitu (Paragraph) lub ramki tekstowej (TextFrame)?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [Portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portion/), silnik pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/paragraph/); jeśli nie jest tam ustawiona, z [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframe/) lub stylu [theme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu (Portion) nie jest dostępna na docelowym komputerze/serwerze?**

[Reguły podstawiania czcionek](/slides/pl/java/font-selection-sequence/) mają zastosowanie. Tekst może ulec przeflowaniu: metryki, dzielenie wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu, niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.