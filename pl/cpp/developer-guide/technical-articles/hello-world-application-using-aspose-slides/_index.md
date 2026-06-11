---
title: Aplikacja Hello World przy użyciu Aspose.Slides dla C++
type: docs
weight: 80
url: /pl/cpp/hello-world-application-using-aspose-slides/
keywords:
- Witaj świecie
- aplikacja
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Utwórz swoją pierwszą aplikację w C++ z Aspose.Slides, prosty przykład Hello World, który przygotuje Cię do automatyzacji prezentacji PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prostą prezentację PowerPoint **Hello World** przy użyciu Aspose.Slides. Przykład demonstruje, jak stworzyć nową prezentację, uzyskać dostęp do pierwszego slajdu, dodać prostokątną AutoShape w określonej pozycji, wstawić ramkę tekstową zawierającą tekst **Hello World** oraz dostosować formatowanie kształtu i tekstu.

Wyjaśnia także, jak sprawić, aby tekst był widoczny, zmieniając jego kolor na czarny, ukryć obramowanie kształtu, ustawiając kolor linii na biały, usunąć wypełnienie kształtu i zapisać prezentację jako plik PPTX.

## **Kroki tworzenia aplikacji Hello World**

Postępuj zgodnie z poniższymi krokami, aby utworzyć aplikację **Hello World** przy użyciu Interfejsu API Aspose.Slides dla C++:

- Utwórz instancję klasy Presentation
- Uzyskaj referencję do pierwszego slajdu w prezentacji, który jest tworzony przy instancjacji klasy Presentation.
- Dodaj AutoShape z ShapeType ustawionym na Rectangle w określonej pozycji slajdu.
- Dodaj TextFrame do AutoShape zawierający domyślny tekst Hello World
- Zmień kolor tekstu na czarny, ponieważ domyślnie jest biały i nie jest widoczny na slajdzie z białym tłem
- Zmień kolor linii kształtu na biały, aby ukryć obramowanie kształtu
- Usuń domyślny format wypełnienia kształtu
- Na koniec zapisz prezentację w żądanym formacie pliku przy użyciu obiektu Presentation

Implementacja powyższych kroków jest przedstawiona poniżej w przykładzie.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // pobierz pierwszy slajd
    auto slide = pres->get_Slides()->idx_get(0);

    // dodaj AutoShape typu Rectangle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // dodaj TextFrame do Rectangle
    shape->AddTextFrame(u"Hello World");

    // zmień kolor tekstu na czarny (który jest domyślnie biały)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // zmień kolor linii prostokąta na biały
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // usuń wszelkie formatowanie wypełnienia w kształcie
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // zapisz prezentację na dysk
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```