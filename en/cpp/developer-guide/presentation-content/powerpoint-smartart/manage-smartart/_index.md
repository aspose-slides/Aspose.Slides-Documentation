---
title: Manage SmartArt in PowerPoint Presentations Using C++
linktitle: Manage SmartArt
type: docs
weight: 10
url: /cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt text
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for C++ using clear code samples that speed up slide design and automation."
---

## **Overview**

SmartArt is a PowerPoint diagram made from nodes, node shapes, and a layout. With Aspose.Slides for C++, you can create SmartArt, read text from its nodes, change its layout, inspect hidden nodes, configure organization chart layouts, and create picture organization charts.

## **Get Text from a SmartArt Object**

A SmartArt node can contain one or more shapes. To read text from the node shapes, iterate through [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), then read the [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) returned by [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

The example requires a presentation with at least one slide and a SmartArt object as the first shape on that slide. It prints each available text frame to the console.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Change the Layout Type of a SmartArt Object**

The SmartArt layout controls how nodes are arranged and connected. The following example creates a SmartArt object with the [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` value, changes it to the `BasicProcess` value, and saves the presentation. The position and size passed to [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) are measured in points. Use [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) to change the layout.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Check Whether a SmartArt Node Is Hidden**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) indicates whether the node is hidden in the SmartArt data model. Hidden nodes can exist in the structure even when the selected layout does not display them as visible diagram elements.

The following example adds a node to a SmartArt object that uses the [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` value and checks the added node's hidden state. It prints a message if the node is hidden and saves the diagram.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Get or Set the Organization Chart Layout**

For SmartArt diagrams that use an organization chart layout, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) and [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) define how child nodes are arranged under a parent node. For example, you can set child nodes to hang from the left, right, or both sides, depending on the selected [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/).

The following example creates an organization chart and sets the layout for the first node to the [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` value. The zero-based index `0` selects the first top-level node; its child nodes use the selected arrangement. The modified presentation is then saved.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Create a Picture Organization Chart**

A picture organization chart is a SmartArt layout designed for hierarchy diagrams that include image placeholders. Use the [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` value when adding the SmartArt object to a slide. This example saves a diagram with image placeholders; it does not populate the placeholders with images.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Convert Legacy Diagrams to Groups of Shapes**

When modernizing an existing presentation, you may need to update an organization chart originally created in PowerPoint 97–2003. Aspose.Slides represents these legacy diagrams as [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) objects. Use [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) to convert a diagram into a group of shapes so that you can edit individual visual elements. See the [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) for details.

Conversion adds a new group to the shape collection without removing the original diagram. After successful conversion, remove the original with [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) to avoid duplicate content. Collect the legacy diagrams into a vector before converting them so that adding and removing shapes does not disrupt iteration.

The following example opens a presentation, searches every slide, converts the diagrams to groups of shapes, and saves the updated presentation as PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The saved presentation contains editable groups of shapes in place of the converted legacy diagrams, with no original diagrams left alongside them. Open the PPTX in PowerPoint to edit individual elements within each group, such as their text, fill, or position.

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Yes. The [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) method switches the diagram direction from left-to-right to right-to-left, or back, when the selected SmartArt layout supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/cpp/shape-manipulations/) with [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) or [clone the whole slide](/slides/cpp/clone-slides/) that contains the SmartArt. Both approaches preserve size, position, and formatting.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/cpp/convert-powerpoint-to-png/) or the whole presentation to PNG or JPEG. SmartArt is rendered as part of the slide.

**How can I find a specific SmartArt object on a slide if there are several?**

Set a distinctive [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) or [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) value on the SmartArt shape, search for that value in [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), and then check that the matching shape is an [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).
