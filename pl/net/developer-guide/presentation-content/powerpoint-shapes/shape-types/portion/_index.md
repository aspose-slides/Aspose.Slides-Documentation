---
title: Zarządzanie fragmentami tekstu w prezentacjach w .NET
linktitle: Fragment tekstu
type: docs
weight: 70
url: /pl/net/portion/
keywords:
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać fragmentami tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET, zwiększając wydajność i możliwości dostosowywania."
---
## **Przegląd**

Fragment tekstu reprezentuje określony fragment tekstu wewnątrz akapitu i umożliwia pracę z tym fragmentem niezależnie od otaczającej zawartości. W Aspose.Slides fragmenty mogą być używane, gdy trzeba pobrać pozycję fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać współrzędne początku fragmentu używając metody `GetCoordinates()`. Pokazuje również typowe scenariusze związane z fragmentami, takie jak zastosowanie hiperłącza do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest rozwiązywane poprzez dziedziczenie w poziomie fragmentu, akapitu, ramki tekstowej i motywu oraz obsługę przypadków, gdy określona czcionka jest niedostępna. Dodatkowo zauważa, że wypełnienie tekstu, kolor i przezroczystość mogą być ustawione inaczej dla poszczególnych fragmentów w tym samym akapicie.

## **Uzyskanie współrzędnych fragmentu tekstu**
**GetCoordinates()** metoda została dodana do IPortion i klasy Portion, co umożliwia pobranie współrzędnych początku fragmentu:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [assign a hyperlink](/slides/pl/net/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylu: co nadpisuje Portion, a co jest pobierane z Paragraph/TextFrame?**

Właściwości na poziomie [Portion](https://reference.aspose.com/slides/pl/net/aspose.slides/portion/) mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona w [Portion](https://reference.aspose.com/slides/pl/net/aspose.slides/portion/), silnik pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/); jeśli nie jest ustawiona również tam, z [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) lub stylu [theme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/theme/).

**Co się stanie, jeśli czcionka określona dla Portion jest nieobecna na docelowym komputerze/serwerze?**

[Font substitution rules](/slides/pl/net/font-selection-sequence/) mają zastosowanie. Tekst może się przepłynąć: metryki, dzielenie wyrazów i szerokość mogą się zmienić, co ma znaczenie dla precyzyjnego pozycjonowania.

**Czy mogę ustawić przezroczystość lub gradient wypełnienia tekstu specyficzny dla Portion, niezależny od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/net/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.