---
title: Manage SmartArt in PowerPoint Presentations in .NET
linktitle: Manage SmartArt
type: docs
weight: 10
url: /net/manage-smartart/
keywords:
- SmartArt
- SmartArt text
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for .NET using clear C# code samples that speed up slide design and automation."
---

## **Overview**

SmartArt is a PowerPoint diagram made from nodes, node shapes, and a layout. With Aspose.Slides for .NET, you can create SmartArt, read text from its nodes, change its layout, inspect hidden nodes, configure organization chart layouts, and create picture organization charts.

## **Get Text from a SmartArt Object**

A SmartArt node can contain one or more shapes. To read text from the node shapes, iterate through [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), then read the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) returned by [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

The example requires a presentation with at least one slide and a SmartArt object as the first shape on that slide. It prints each available text frame to the console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Change the Layout Type of a SmartArt Object**

The SmartArt layout controls how nodes are arranged and connected. The following example creates a SmartArt object with the [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` value, changes it to the `BasicProcess` value, and saves the presentation. The position and size passed to [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) are measured in points. Set [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) to change the layout.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Check Whether a SmartArt Node Is Hidden**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) indicates whether the node is hidden in the SmartArt data model. Hidden nodes can exist in the structure even when the selected layout does not display them as visible diagram elements.

The following example adds a node to a SmartArt object that uses the [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` value and checks the added node's hidden state. It prints a message if the node is hidden and saves the diagram.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Get or Set the Organization Chart Layout**

For SmartArt diagrams that use an organization chart layout, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) defines how child nodes are arranged under a parent node. For example, you can set child nodes to hang from the left, right, or both sides, depending on the selected [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

The following example creates an organization chart and sets the layout for the first node to the [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` value. The zero-based index `0` selects the first top-level node; its child nodes use the selected arrangement. The modified presentation is then saved.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Create a Picture Organization Chart**

A picture organization chart is a SmartArt layout designed for hierarchy diagrams that include image placeholders. Use the [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` value when adding the SmartArt object to a slide. This example saves a diagram with image placeholders; it does not populate the placeholders with images.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Convert Legacy Diagrams to Groups of Shapes**

When modernizing an existing presentation, you may need to update an organization chart originally created in PowerPoint 97–2003. Aspose.Slides represents these legacy diagrams as [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) objects. Use [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) to convert a diagram into a group of shapes so that you can edit individual visual elements. See the [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) for details.

Conversion adds a new group to the shape collection without removing the original diagram. After successful conversion, remove the original with [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) to avoid duplicate content. Collect the legacy diagrams into an array before converting them so that adding and removing shapes does not disrupt iteration.

The following example opens a presentation, searches every slide, converts the diagrams to groups of shapes, and saves the updated presentation as PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

The saved presentation contains editable groups of shapes in place of the converted legacy diagrams, with no original diagrams left alongside them. Open the PPTX in PowerPoint to edit individual elements within each group, such as their text, fill, or position.

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Yes. The [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) property switches the diagram direction from left-to-right to right-to-left, or back, when the selected SmartArt layout supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/net/shape-manipulations/) with [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) or [clone the whole slide](/slides/net/clone-slides/) that contains the SmartArt. Both approaches preserve size, position, and formatting.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/net/convert-powerpoint-to-png/) or the whole presentation to PNG or JPEG. SmartArt is rendered as part of the slide.

**How can I find a specific SmartArt object on a slide if there are several?**

Set a distinctive [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) or [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) value on the SmartArt shape, search for that value in [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), and then check that the matching shape is an [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).
