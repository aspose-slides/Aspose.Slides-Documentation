---
title: Manage SmartArt in PowerPoint Presentations on Android
linktitle: Manage SmartArt
type: docs
weight: 10
url: /androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt text
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for Android using clear Java code samples that speed up slide design and automation."
---

## **Overview**

SmartArt is a PowerPoint diagram made from nodes, node shapes, and a layout. With Aspose.Slides for Android via Java, you can create SmartArt, read text from its nodes, change its layout, inspect hidden nodes, configure organization chart layouts, and create picture organization charts.

## **Get Text from a SmartArt Object**

A SmartArt node can contain one or more shapes. To read text from the node shapes, iterate through [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), then read the [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) returned by [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

The example requires a presentation with at least one slide and a SmartArt object as the first shape on that slide. It prints each available text frame to the console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Change the Layout Type of a SmartArt Object**

The SmartArt layout controls how nodes are arranged and connected. The following example creates a SmartArt object with the [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList` value, changes it to the `BasicProcess` value, and saves the presentation. The position and size passed to [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) are measured in points. Use [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) to change the layout.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Check Whether a SmartArt Node Is Hidden**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) indicates whether the node is hidden in the SmartArt data model. Hidden nodes can exist in the structure even when the selected layout does not display them as visible diagram elements.

The following example adds a node to a SmartArt object that uses the [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` value and checks the added node's hidden state. It prints a message if the node is hidden and saves the diagram.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Get or Set the Organization Chart Layout**

For SmartArt diagrams that use an organization chart layout, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) and [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) define how child nodes are arranged under a parent node. For example, you can set child nodes to hang from the left, right, or both sides, depending on the selected [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

The following example creates an organization chart and sets the layout for the first node to the [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` value. The zero-based index `0` selects the first top-level node; its child nodes use the selected arrangement. The modified presentation is then saved.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Create a Picture Organization Chart**

A picture organization chart is a SmartArt layout designed for hierarchy diagrams that include image placeholders. Use the [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` value when adding the SmartArt object to a slide. This example saves a diagram with image placeholders; it does not populate the placeholders with images.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Convert Legacy Diagrams to Groups of Shapes**

When modernizing an existing presentation, you may need to update an organization chart originally created in PowerPoint 97–2003. Aspose.Slides represents these legacy diagrams as [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) objects. Use [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) to convert a diagram into a group of shapes so that you can edit individual visual elements. See the [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) for details.

Conversion adds a new group to the shape collection without removing the original diagram. After successful conversion, remove the original with [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) to avoid duplicate content. Collect the legacy diagrams into a list before converting them so that adding and removing shapes does not disrupt iteration.

The following example opens a presentation, searches every slide, converts the diagrams to groups of shapes, and saves the updated presentation as PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The saved presentation contains editable groups of shapes in place of the converted legacy diagrams, with no original diagrams left alongside them. Open the PPTX in PowerPoint to edit individual elements within each group, such as their text, fill, or position.

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Yes. The [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) method switches the diagram direction from left-to-right to right-to-left, or back, when the selected SmartArt layout supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/androidjava/shape-manipulations/) with [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) or [clone the whole slide](/slides/androidjava/clone-slides/) that contains the SmartArt. Both approaches preserve size, position, and formatting.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/androidjava/convert-powerpoint-to-png/) or the whole presentation to PNG or JPEG. SmartArt is rendered as part of the slide.

**How can I find a specific SmartArt object on a slide if there are several?**

Use [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) or [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) to assign a distinctive alternative text or name to the SmartArt shape, search for that value in [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), and then check that the matching shape is an [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).
