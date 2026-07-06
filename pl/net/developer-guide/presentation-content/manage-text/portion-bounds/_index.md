---
title: Pobieranie granic części tekstu z prezentacji w .NET
linktitle: Granice części
type: docs
weight: 47
url: /pl/net/portion-bounds/
keywords:
- granice części tekstu
- część tekstu
- fragment tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak pobierać granice części tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Część tekstu reprezentuje konkretny fragment tekstu w obrębie akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides części mogą być używane, gdy potrzebujesz pobrać granice fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Artykuł opisuje, jak uzyskać prostokąt ograniczający część, używając [IPortion.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/getrect/). Pokazuje również, jak uzyskać współrzędne początku części, używając [IPortion.GetCoordinates](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/getcoordinates/). Dodatkowo przedstawia typowe scenariusze związane z częściami, takie jak zastosowanie hiperłącza do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest rozwiązywane przez część, akapit, ramkę tekstową i dziedziczenie motywu, oraz obsługę sytuacji, gdy określona czcionka jest niedostępna.

## **Uzyskanie granic części tekstu**

Użyj [IPortion.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/getrect/) aby pobrać prostokąt ograniczający część tekstu:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Uzyskanie współrzędnych części tekstu**

Użyj [IPortion.GetCoordinates](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/getcoordinates/) aby pobrać współrzędne początku części tekstu:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/net/manage-hyperlinks/) do pojedynczej części; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylu: co część nadpisuje, a co jest pobierane z akapitu lub ramki tekstowej?**

Właściwości na poziomie części mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [IPortion](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/), Aspose.Slides pobiera ją z [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/). Jeśli nie jest tam również ustawiona, Aspose.Slides używa stylu z [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) lub [theme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/theme/).

**Co się stanie, jeśli czcionka określona dla części nie jest dostępna na docelowym komputerze lub serwerze?**

Obowiązują [zasady zamiany czcionek](/slides/pl/net/font-selection-sequence/). Tekst może się przemieszczać: metryki, podziały wyrazów i szerokość mogą ulec zmianie, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla części, niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [IPortion](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/) mogą różnić się od sąsiednich fragmentów.