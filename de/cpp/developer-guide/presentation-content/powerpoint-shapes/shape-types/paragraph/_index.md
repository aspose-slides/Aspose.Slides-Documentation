---
title: Absatz
type: docs
weight: 60
url: /cpp/paragraph/
---

## **Abholen von Absatz- und Portionskoordinaten im TextFrame**
Mit Aspose.Slides für C++ können Entwickler jetzt die rechteckigen Koordinaten für Absätze innerhalb der Absatzsammlung eines TextFrames abrufen. Es ermöglicht auch, die Koordinaten von Portionen innerhalb der Portionssammlung eines Absatzes zu erhalten. In diesem Thema werden wir mit Hilfe eines Beispiels demonstrieren, wie man die rechteckigen Koordinaten für einen Absatz zusammen mit der Position von Portionen innerhalb eines Absatzes erhält.

## **Rechteckige Koordinaten des Absatzes abrufen**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht es, das Rechteck der Absatzgrenzen zu erhalten.

``` cpp
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Größe von Absatz und Portion im Tabellenzellen-TextFrame abrufen** ##

Um die [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) oder [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) Größe und Koordinaten in einem Tabellenzellen-TextFrame zu erhalten, können Sie die [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) und [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) Methoden verwenden.

Dieser Beispieldcode demonstriert die beschriebene Operation:

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