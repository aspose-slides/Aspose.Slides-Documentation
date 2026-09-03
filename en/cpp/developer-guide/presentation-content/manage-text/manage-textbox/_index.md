---
title: Manage Text Boxes in Presentations Using C++
linktitle: Manage Text Box
type: docs
weight: 20
url: /cpp/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Create, identify, format, and update text boxes in PowerPoint and OpenDocument presentations using Aspose.Slides for C++."
---

## **Introduction**

In Aspose.Slides for C++, slide text is stored in text frames that belong to shapes. The [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) interface represents the most common text-bearing shape and exposes its text through the [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) method.

{{% alert color="info" title="Note" %}}

Every auto shape implements [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), but not every shape is an auto shape or supports a text frame. When processing an existing presentation, check that a shape implements [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) before accessing its text.

{{% /alert %}}

## **Create a Text Box on a Slide**

To create a text box, add an auto shape to a slide, add text to its text frame, and save the presentation. The following example creates a rectangular text box:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

The coordinates and dimensions passed to [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) are measured in points. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) initializes the text frame with the supplied text.

## **Check for a Text Box Shape**

Use the [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) method to determine whether an auto shape is treated as a text box. This is useful when a presentation contains both text-bearing and purely graphical auto shapes.

![A text box and a shape](istextbox.png)

The following example inspects every auto shape in a presentation:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

A newly added auto shape is not considered a text box until it contains non-empty text. You can supply that text through [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) or [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/). Adding or assigning an empty string makes [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) return `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

The first two checks return `true`; the last two return `false`.

## **Find the Shape That Owns a Text Frame**

Generic text-processing code may receive an [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) without knowing which presentation object contains it. Use the [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) method to navigate back to its owning [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

For a text frame owned by an auto shape or another text-bearing shape, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) returns the owner and [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) returns `nullptr`. Both methods provide read-only navigation. Check the returned value for `nullptr` before accessing it. To identify both shape and table-cell owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/cpp/search-and-replace-text/).

## **Add Columns to a Text Box**

The [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_columncount/) method divides the text frame into columns, while [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_columnspacing/) sets the gap between columns in points. Both methods belong to [ITextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/) and can be called through the text frame of an existing text box. Text reflows between columns inside the same shape; it does not continue into another shape.

The following example creates a three-column text box with 10 points between columns, saves the presentation, and reads the stored settings back from the output file:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Extract Text from Individual Columns**

Use [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/splittextbycolumns/) to retrieve the text assigned to each visual column in an existing text frame. The method returns one string for each column, in column-based reading order. A single-column text frame produces an array with one element, and an empty column is represented by an empty string. The strings contain plain text only; portion-level formatting is not preserved.

This is useful when you need to:

- Extract text while preserving its column-based reading order.
- Index or compare the content of multi-column slides.
- Export each column to a separate file, database field, or other destination.
- Inspect how text is redistributed after setting the column count with [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_columncount/) or the spacing with [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_columnspacing/), or changing the font or text-frame size.

The method reports the text distributed within the current [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/); it does not automatically flow text between separate shapes or text boxes. Column distribution can depend on available fonts and other text-layout settings, so make sure that the required fonts are available when consistent results are important.

The following example loads a presentation, finds the first multi-column auto shape with a text frame on the first slide, reads its configured column count, and writes the text from every column to a separate file. Shapes that do not provide a text frame are skipped.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Update Text**

To update text throughout a presentation, iterate through the slides and shapes, select auto shapes, and then edit their text portions. Working at the portion level lets you change both text and character formatting.

The following example replaces every occurrence of `years` with `months` within individual auto-shape text portions and makes each affected portion bold:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

This traversal updates text only in auto shapes. Text stored in tables, charts, SmartArt, or grouped shapes requires traversal of those objects' own collections.

## **Add a Text Box with a Hyperlink**

A hyperlink can be assigned to a specific text portion, so only that text acts as the clickable link. Use [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) to associate the portion with an external URL.

The following example creates linked text and saves it to a presentation:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

A [placeholder](/slides/cpp/manage-placeholder/) can inherit its position and formatting from a [master slide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) or [layout slide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/). A regular text box is an independent shape on the slide where it was created and does not acquire placeholder behavior when the layout changes.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Limit the traversal to shapes that implement [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), as shown in the Update Text example. Charts, tables, and SmartArt store text in their own object models, so they are not modified by that loop.
