---
title: Absatzgrenzen aus Präsentationen in C++ abrufen
linktitle: Absatzgrenzen
type: docs
weight: 43
url: /de/cpp/paragraph-bounds/
keywords:
- Absatzgrenzen
- Absatzkoordinate
- Absatzgröße
- Textfeld
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzgrenzen in Aspose.Slides für C++ abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man die Grenzen, die Größe und die Koordinaten von Absätzen in Aspose.Slides ermittelt. Er zeigt, wie man ein Absatzrechteck aus einem [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) mit Hilfe von [IParagraph::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getrect/) abruft, wie man Absatzkoordinaten in einem TextFrame einer Tabellenzelle erhält und hebt wichtige Details hervor, wie Maßeinheiten, die Auswirkung von Textumbruch auf die Grenzen, die Pixelkalkulation und effektive Absatzformatierungswerte.

## **Rechteckige Koordinaten eines Absatzes**

Verwenden Sie [IParagraph::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getrect/), um das begrenzende Rechteck eines Absatzes zu erhalten.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Größe eines Absatzes in einem TextFrame einer Tabellenzelle ermitteln**

Um die Größe und Koordinaten eines [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/) in einem TextFrame einer Tabellenzelle zu erhalten, verwenden Sie [IParagraph::GetRect](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/getrect/). Das zurückgegebene Rechteck ist relativ zum TextFrame der Tabellenzelle, sodass Sie die Tabellenposition und den Zellenoffset hinzufügen müssen, wenn Sie Folien‑ebene Koordinaten benötigen.

Das folgende Beispiel ermittelt die Absatzgrenzen in einer Tabellenzelle und zeichnet Rechtecke auf der Folie, um diese Grenzen zu visualisieren:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**In welchen Einheiten werden Absatzkoordinaten gemessen?**

Sie werden in Punkten gemessen, wobei 1 Zoll 72 Punkten entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst das Wortumbruch die Grenzen eines Absatzes?**

Ja. Wenn [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_wraptext/) für das [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) aktiviert ist, bricht der Text um, um die Breite des Bereichs zu passen, wodurch sich die tatsächlichen Grenzen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Konvertieren Sie Punkte in Pixel mit dieser Formel: pixel = points × (DPI / 72). Das Ergebnis hängt vom für die Darstellung oder den Export gewählten DPI‑Wert ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effektive Absatzformatierungsdatenstruktur](/slides/de/cpp/shape-effective-properties/); sie gibt die final konsolidierten Werte für Einzüge, Zeilenabstand, Umbruch, RTL und mehr zurück.