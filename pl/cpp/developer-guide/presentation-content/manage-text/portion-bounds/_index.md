---
title: Pobieranie granic fragmentu tekstu z prezentacji w C++
linktitle: Granice fragmentu
type: docs
weight: 47
url: /pl/cpp/portion-bounds/
keywords:
- granice fragmentu tekstu
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice fragmentu tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Część tekstowa reprezentuje określony fragment tekstu wewnątrz akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty mogą być używane, gdy potrzebujesz pobrać granice fragmentu tekstowego, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać prostokąt ograniczający fragment, używając [IPortion::GetRect](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/getrect/). Pokazuje także, jak uzyskać współrzędne początku fragmentu, używając [IPortion::GetCoordinates](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/getcoordinates/). Dodatkowo podkreśla typowe scenariusze związane z fragmentami, takie jak dodawanie hiperłącza do pojedynczego fragmentu tekstu, rozumienie, jak formatowanie jest rozwiązywane przez dziedziczenie fragmentu, akapitu, ramki tekstowej i motywu oraz obsługa sytuacji, gdy określona czcionka jest niedostępna.

## **Pobierz granice fragmentu tekstowego**

Użyj [IPortion::GetRect](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/getrect/), aby pobrać prostokąt ograniczający fragment tekstowy:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Pobierz współrzędne fragmentu tekstowego**

Użyj [IPortion::GetCoordinates](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/getcoordinates/), aby pobrać współrzędne początku fragmentu tekstowego:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/cpp/manage-hyperlinks/); tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co nadpisuje fragment, a co jest pobierane z akapitu lub ramki tekstowej?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona na [IPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/), Aspose.Slides pobiera ją z [IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/). Jeśli nie jest tam ustawiona, Aspose.Slides korzysta ze stylu [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) lub [theme](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu jest nieobecna na docelowej maszynie lub serwerze?**

[Zasady zamiany czcionek](/slides/pl/cpp/font-selection-sequence/) mają zastosowanie. Tekst może się zmienić: metryka, dzielenie wyrazów i szerokość mogą ulec zmianie, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [IPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/) mogą różnić się od sąsiednich fragmentów.