---
title: Read and add SmartArt
description: Read SmartArt diagrams and add new ones to slides.
type: docs
url: /features/smartart/
weight: 650
feature_id: smartart
feature_group: shapes
translationKey: slides-feature-smartart
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-smartart/
---

## **Overview**

Use SmartArt to build diagrams such as organization charts. Read the diagram's model, choose a layout and style, and access its nodes and text. The diagram remains structured presentation content rather than only a cached picture.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates a three-step process diagram and fills its default nodes with short labels. The saved diagram remains SmartArt with a layout and nodes, rather than only a picture.

```csharp
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var diagram = presentation.Slides[0].Shapes.AddSmartArt(60, 60, 500, 250, SmartArtLayoutType.BasicProcess);
var labels = new[] { "Plan", "Build", "Review" };
for (var i = 0; i < diagram.AllNodes.Count && i < labels.Length; i++)
{
    diagram.AllNodes[i].TextFrame.Text = labels[i];
}
presentation.Save("smartart.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I change the diagram's text and structure later?**

Yes. Use the SmartArt node APIs to edit text, add or remove nodes, and work with their shapes.

### **Can I change the layout of an existing SmartArt graphic?**

Choose the layout when creating the graphic. The existing graphic’s layout type is read-only; create a new graphic with the desired layout and transfer the required content when changing the design.

### **How do SmartArt styles affect colors and appearance?**

SmartArt has diagram-level quick styles and color styles in addition to node formatting. Use a compatible style and inspect the rendered result because the layout and theme also affect the appearance.

## **Guides**

- [Manage SmartArt in PowerPoint Presentations in .NET](/slides/net/manage-smartart/)

Related feature: [Edit SmartArt nodes](/slides/features/smartart-nodes/).
