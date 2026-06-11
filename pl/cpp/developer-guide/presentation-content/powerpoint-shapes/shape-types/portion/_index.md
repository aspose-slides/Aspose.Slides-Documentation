---
title: Zarządzanie fragmentami tekstu w prezentacjach przy użyciu C++
linktitle: Fragment tekstu
type: docs
weight: 70
url: /pl/cpp/portion/
keywords:
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać fragmentami tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++, zwiększając wydajność i możliwości dostosowania."
---
## **Wprowadzenie**

Część tekstu reprezentuje konkretny fragment tekstu wewnątrz akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides części można używać, gdy trzeba pobrać pozycję fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

## **Pobieranie współrzędnych części tekstu**
**GetCoordinates()** metoda została dodana do IPortion i klasy Portion, co umożliwia pobranie współrzędnych początkowych części:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **FAQ**

**Czy mogę zastosować hiperłączko tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/cpp/manage-hyperlinks/) do pojedynczej części; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co nadpisuje Portion, a co pochodzi z Paragraph/TextFrame?**

Właściwości na poziomie Portion mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona w [Portion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portion/), silnik pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/paragraph/); jeśli nie jest ustawiona również tam, pobierana jest z [TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textframe/) lub stylu [theme](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/theme/).

**Co się stanie, jeśli czcionka określona dla Portion nie jest zainstalowana na docelowym komputerze/serwerze?**

[Zasady podstawiania czcionek](/slides/pl/cpp/font-selection-sequence/) mają zastosowanie. Tekst może ulec zmianie układu: metryki, dzielenie wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla Portion, niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.