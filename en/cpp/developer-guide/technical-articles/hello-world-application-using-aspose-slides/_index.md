---
title: Hello World Application using Aspose.Slides for C++
type: docs
weight: 80
url: /cpp/hello-world-application-using-aspose-slides/
keywords:
- hello world
- application
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Create your first C++ app with Aspose.Slides, a simple Hello World example that gets you ready to automate PPT, PPTX and ODP presentations."
---

## **Steps to Create Hello World Application**
In this simple application, we will create a PowerPoint presentation having **Hello World** text at a specified position of a slide. Please follow the steps below to create **Hello World** application by using Aspose.Slides for C++ API:

- Create an instance of Presentation class
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide.
- Add a TextFrame to the AutoShape containing Hello World as default text
- Change the Text Color to Black as it is white by default and is not visible on the slide with white background
- Change the Line Color of the shape to white in order to hide the shape border
- Remove the default Fill Format of the shape
- Finally, write the presentation to desired file format using the Presentation object

The implementation of above steps is demonstrated below in an example.

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

    // get the first slide
    auto slide = pres->get_Slides()->idx_get(0);

    // add an AutoShape of Rectangle type
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // add TextFrame to the Rectangle
    shape->AddTextFrame(u"Hello World");

    // change the text color to Black (which is White by default)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // change the line color of the rectangle to White
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // remove any fill formatting in the shape
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // save the presentation to disk
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
