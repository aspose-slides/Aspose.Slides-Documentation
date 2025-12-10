---
title: Absatzgrenzen aus Präsentationen in C++ abrufen
linktitle: Absatz
type: docs
weight: 60
url: /de/cpp/paragraph/
keywords:
- Absatzgrenzen
- Grenzen von Textportionen
- Absatzkoordinate
- Portionskoordinate
- Absatzgröße
- Textportionengröße
- Textfeld
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie in Aspose.Slides für C++ die Grenzen von Absätzen und Textportionen abrufen können, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---

## **Koordinaten von Absatz und Portion in einem TextFrame**
Mit Aspose.Slides für C++ können Entwickler nun die rechteckigen Koordinaten eines Paragraphs innerhalb der Absatzsammlung eines TextFrames abrufen. Es ermöglicht außerdem, die Koordinaten einer Portion innerhalb der Portionssammlung eines Absatzes zu erhalten. In diesem Thema zeigen wir anhand eines Beispiels, wie die rechteckigen Koordinaten eines Absatzes zusammen mit der Position einer Portion innerhalb eines Absatzes ermittelt werden können.

## **Rechteckige Koordinaten eines Absatzes abrufen**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Begrenzungsrechtecks eines Absatzes.
``` cpp
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```


## **Größe eines Absatzes und einer Portion innerhalb eines Tabellenzellen-TextFrames ermitteln**

Um die Größe und die Koordinaten einer [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) oder eines [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) in einem Tabellenzellen-TextFrame zu erhalten, können Sie die Methoden [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) und [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:
``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```


## **FAQ**

**In welchen Einheiten werden die Koordinaten eines Absatzes und von Textportionen zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Wirkt sich das Zeilenumbruchverhalten auf die Begrenzung eines Absatzes aus?**

Ja. Wenn das [wrapping](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/) im [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) aktiviert ist, wird der Text umgebrochen, um die Bereichsbreite zu füllen, wodurch sich die tatsächliche Begrenzung des Absatzes ändert.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Punkte können mit folgender Formel in Pixel umgerechnet werden: pixels = points × (DPI / 72). Das Ergebnis hängt vom für das Rendern/Exportieren gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/cpp/shape-effective-properties/); sie liefert die endgültigen zusammengefassten Werte für Einzüge, Abstand, Wrapping, RTL und mehr.