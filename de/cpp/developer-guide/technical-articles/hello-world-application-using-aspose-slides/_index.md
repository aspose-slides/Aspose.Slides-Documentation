---
title: Hello World-Anwendung mit Aspose.Slides
type: docs
weight: 80
url: /cpp/hello-world-anwendung-mit-aspose-slides/
---

## **Schritte zur Erstellung einer Hello World-Anwendung**
In dieser einfachen Anwendung erstellen wir eine PowerPoint-Präsentation mit dem Text **Hello World** an einer bestimmten Position auf einer Folie. Bitte folgen Sie den nachstehenden Schritten, um die **Hello World** Anwendung mit der Aspose.Slides C++ API zu erstellen:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Erhalten Sie die Referenz zur ersten Folie der Präsentation, die bei der Instanziierung der Präsentation erstellt wird.
- Fügen Sie eine AutoShape mit dem ShapeType als Rechteck an einer bestimmten Position auf der Folie hinzu.
- Fügen Sie der AutoShape ein TextFrame hinzu, das "Hello World" als Standardtext enthält.
- Ändern Sie die Textfarbe in Schwarz, da sie standardmäßig weiß ist und auf der Folie mit weißem Hintergrund nicht sichtbar ist.
- Ändern Sie die Linienfarbe der Form in Weiß, um den Formrand zu verbergen.
- Entfernen Sie das Standard-Fill-Format der Form.
- Schreiben Sie schließlich die Präsentation im gewünschten Dateiformat mit dem Präsentationsobjekt.

Die Umsetzung der oben genannten Schritte wird im Folgenden anhand eines Beispiels demonstriert.

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

    // Erhalten Sie die erste Folie
    auto slide = pres->get_Slides()->idx_get(0);

    // Fügen Sie eine AutoShape des Rechtecktyps hinzu
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // Fügen Sie dem Rechteck ein TextFrame hinzu
    shape->AddTextFrame(u"Hello World");

    // Ändern Sie die Textfarbe in Schwarz (die standardmäßig Weiß ist)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // Ändern Sie die Linienfarbe des Rechtecks in Weiß
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // Entfernen Sie alle Füllformatierungen in der Form
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // Speichern Sie die Präsentation auf der Festplatte
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```