---
title: Get Paragraph Bounds from Presentations in C++
linktitle: Paragraph
type: docs
weight: 60
url: /cpp/paragraph/
keywords:
- paragraph bounds
- text portion bounds
- paragraph coordinate
- portion coordinate
- paragraph size
- text portion size
- text frame
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to retrieve paragraph and text-portion bounds in Aspose.Slides for C++ to optimize text positioning in PowerPoint presentations."
---

## **Get Paragraph and Portion Coordinates in a TextFrame**
Using Aspose.Slides for C++, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with the position of portion inside a paragraph.

## **Get Rectangular Coordinates of a Paragraph**
The new method **GetRect()** has been added. It allows to get paragraph bounds rectangle.

``` cpp
// Instantiate a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Get the Size of a Paragraph and Portion Inside a Table Cell TextFrame**

To get the [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) or [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) size and coordinates in a table cell text frame, you can use the [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) and [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) methods.

This sample code demonstrates the described operation:

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

**In what units are the coordinates returned for a paragraph and text portions measured?**

In points, where 1 inch = 72 points. This applies to all coordinates and dimensions on the slide.

**Does word wrapping affect a paragraph’s bounds?**

Yes. If [wrapping](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/) is enabled in the [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/), the text breaks to fit the area width, which changes the paragraph’s actual bounds.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

Yes. Convert points to pixels using: pixels = points × (DPI / 72). The result depends on the DPI chosen for rendering/export.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

Use the [effective paragraph formatting data structure](/slides/cpp/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.
