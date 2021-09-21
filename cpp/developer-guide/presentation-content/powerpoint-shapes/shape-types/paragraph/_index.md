---
title: Paragraph
type: docs
weight: 60
url: /cpp/paragraph/
---

## **Get Paragraph and Portion Coordinates in TextFrame**
Using Aspose.Slides for C++, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with the position of portion inside a paragraph.

## **Get Rectangular Coordinates of Paragraph**
The new method **GetRect()** has been added. It allows to get paragraph bounds rectangle.

``` cpp
// Instantiate a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::DynamicCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Get size of paragraph and portion inside table cell text frame** ##

To get the [Portion](https://apireference.aspose.com/slides/cpp/class/aspose.slides.portion) or [Paragraph](https://apireference.aspose.com/slides/cpp/class/aspose.slides.paragraph) size and coordinates in a table cell text frame, you can use the [IPortion::GetRect](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) and [IParagraph::GetRect](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) methods.

This sample code demonstrates the described operation:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::DynamicCast_noexcept<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

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