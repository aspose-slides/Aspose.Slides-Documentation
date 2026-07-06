---
title: Uzyskaj granice fragmentu tekstu w prezentacjach w Javie
linktitle: Granice fragmentu
type: docs
weight: 47
url: /pl/java/portion-bounds/
keywords:
- granice fragmentu tekstu
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice fragmentu tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Fragment tekstu reprezentuje konkretny fragment tekstu wewnątrz akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty mogą być używane, gdy trzeba pobrać granice fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać prostokąt ograniczający fragment, używając [IPortion.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortion#getRect--). Pokazuje również, jak uzyskać współrzędne początku fragmentu, używając [IPortion.getCoordinates](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortion#getCoordinates--). Ponadto podkreśla typowe scenariusze związane z fragmentami, takie jak zastosowanie hiperłącza do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest rozwiązywane przez dziedziczenie fragmentu, akapitu, ramki tekstowej i motywu oraz obsługę przypadków, gdy określona czcionka jest niedostępna.

## **Pobranie granic fragmentu tekstu**

Użyj [IPortion.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortion#getRect--) aby pobrać prostokąt ograniczający fragment tekstu:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Pobranie współrzędnych fragmentu tekstu**

Użyj [IPortion.getCoordinates](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortion#getCoordinates--) aby pobrać współrzędne początku fragmentu tekstu:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/java/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co fragment nadpisuje, a co jest pobierane z akapitu lub ramki tekstowej?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/), Aspose.Slides pobiera ją z [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/). Jeśli nie jest ustawiona również tam, Aspose.Slides używa stylu z [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) lub [theme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/theme/).

**Co się dzieje, jeśli czcionka określona dla fragmentu jest nieobecna na docelowym komputerze lub serwerze?**

[Zasady podstawiania czcionek](/slides/pl/java/font-selection-sequence/) mają zastosowanie. Tekst może się przemieszczać: metryki, hyphenacja i szerokość mogą ulec zmianie, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/) mogą różnić się od sąsiednich fragmentów.