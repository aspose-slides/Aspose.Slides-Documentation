---
title: Get Paragraph Bounds from Presentations in C++
linktitle: Paragraph Bounds
type: docs
weight: 43
url: /cpp/paragraph-bounds/
keywords:
- paragraph bounds
- paragraph coordinate
- paragraph size
- text frame
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to retrieve paragraph bounds in Aspose.Slides for C++ to optimize text positioning in PowerPoint presentations."
---

## **Overview**

This article explains how to get the bounds, size, and coordinates of paragraphs in Aspose.Slides. It shows how to retrieve a paragraph rectangle from an [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) by using [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/), how to get paragraph coordinates inside a table cell text frame, and highlights important details such as measurement units, the effect of text wrapping on bounds, pixel conversion, and effective paragraph formatting values.

## **Get Rectangular Coordinates of a Paragraph**

Use [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) to get the bounding rectangle of a paragraph.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

To get the size and coordinates of an [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) in a table cell text frame, use [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/). The returned rectangle is relative to the table cell text frame, so add the table position and cell offset when you need slide-level coordinates.

The following example gets paragraph bounds inside a table cell and draws rectangles on the slide to visualize those bounds:

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

**In what units are paragraph coordinates measured?**

They are measured in points, where 1 inch equals 72 points. This applies to all coordinates and dimensions on the slide.

**Does word wrapping affect a paragraph's bounds?**

Yes. If [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) is enabled for the [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), the text breaks to fit the area width, which changes the paragraph's actual bounds.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

Yes. Convert points to pixels using this formula: pixels = points x (DPI / 72). The result depends on the DPI chosen for rendering or export.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

Use the [effective paragraph formatting data structure](/slides/cpp/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.
