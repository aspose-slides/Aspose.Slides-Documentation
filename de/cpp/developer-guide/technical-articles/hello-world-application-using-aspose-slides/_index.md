---
title: Hello World Anwendung mit Aspose.Slides für C++
type: docs
weight: 80
url: /de/cpp/hello-world-application-using-aspose-slides/
keywords:
- Hallo Welt
- Anwendung
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen Sie Ihre erste C++-Anwendung mit Aspose.Slides, ein einfaches Hello-World-Beispiel, das Sie bereit macht, PPT-, PPTX- und ODP-Präsentationen zu automatisieren."
---

## **Schritte zum Erstellen einer Hello World Anwendung**
In dieser einfachen Anwendung erstellen wir eine PowerPoint‑Präsentation, die den Text **Hello World** an einer angegebenen Position einer Folie enthält. Bitte folgen Sie den untenstehenden Schritten, um eine **Hello World**‑Anwendung mit der Aspose.Slides für C++ API zu erstellen:

- Eine Instanz der Klasse Presentation erstellen
- Die Referenz der ersten Folie in der Präsentation erhalten, die bei der Instanziierung von Presentation erstellt wird
- Ein AutoShape mit ShapeType Rectangle an einer angegebenen Position der Folie hinzufügen
- Einen TextFrame zum AutoShape hinzufügen, der Hello World als Standardtext enthält
- Die Textfarbe zu Schwarz ändern, da sie standardmäßig weiß ist und auf einer Folie mit weißem Hintergrund nicht sichtbar ist
- Die Linienfarbe der Form zu Weiß ändern, um den Formrand zu verbergen
- Das Standard‑Füllformat der Form entfernen
- Abschließend die Präsentation mit dem Presentation‑Objekt in das gewünschte Dateiformat schreiben

Die Implementierung der obigen Schritte wird im nachfolgenden Beispiel gezeigt.
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

    // die erste Folie abrufen
    auto slide = pres->get_Slides()->idx_get(0);

    // ein AutoShape vom Typ Rechteck hinzufügen
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // TextFrame zum Rechteck hinzufügen
    shape->AddTextFrame(u"Hello World");

    // die Textfarbe zu Schwarz ändern (standardmäßig ist sie Weiß)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // die Linienfarbe des Rechtecks zu Weiß ändern
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // jegliche Füllformatierung der Form entfernen
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // die Präsentation auf die Festplatte speichern
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
