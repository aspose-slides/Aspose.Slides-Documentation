---
title: Hello World-applikation med Aspose.Slides för C++
type: docs
weight: 80
url: /sv/cpp/hello-world-application-using-aspose-slides/
keywords:
- Hej världen
- applikation
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Skapa ditt första C++-program med Aspose.Slides, ett enkelt Hello World-exempel som förbereder dig för att automatisera PPT-, PPTX- och ODP-presentationer."
---
## **Översikt**

Denna artikel visar hur du skapar en enkel **Hello World** PowerPoint-presentation med Aspose.Slides. Exemplet demonstrerar hur du skapar en ny presentation, får åtkomst till den första bilden, lägger till en rektangel-AutoShape på en angiven position, infogar en textruta som innehåller texten **Hello World**, och justerar formens och textens formatering.

Den förklarar också hur du gör texten synlig genom att ändra dess färg till svart, döljer formens kant genom att sätta linjefärgen till vit, tar bort formens fyllning och sparar presentationen som en PPTX-fil.

## **Steg för att skapa ett Hello World-program**

Följ stegen nedan för att skapa ett **Hello World**-program med Aspose.Slides för C++-API:

- Skapa en instans av Presentation-klassen
- Hämta referensen till den första bilden i presentationen som skapas vid instansiering av Presentation.
- Lägg till en AutoShape med ShapeType som Rectangle på en angiven position på bilden.
- Lägg till en TextFrame till AutoShape som innehåller Hello World som standardtext
- Ändra textfärgen till svart eftersom den är vit som standard och inte syns på en bild med vit bakgrund
- Ändra linjefärgen på formen till vit för att dölja formens kant
- Ta bort standard-Fill-Format för formen
- Slutligen, skriv presentationen till önskat filformat med Presentation-objektet

Implementeringen av ovanstående steg demonstreras nedan i ett exempel.

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

    // hämta den första bilden
    auto slide = pres->get_Slides()->idx_get(0);

    // lägg till en AutoShape av rektangeltyp
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // lägg till en TextFrame till rektangeln
    shape->AddTextFrame(u"Hello World");

    // ändra textfärgen till svart (vilket är vitt som standard)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // ändra linjefärgen på rektangeln till vitt
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // ta bort eventuell fyllningsformatering i formen
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // spara presentationen till disk
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```