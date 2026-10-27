---
title: Edit SmartArt nodes
description: Edit the text, shapes and hierarchy of SmartArt nodes.
type: docs
url: /features/smartart-nodes/
weight: 660
feature_id: smartart-nodes
feature_group: shapes
translationKey: slides-feature-smartart-nodes
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-smartart-shape-node/
---

## **Overview**

Work with individual nodes inside a SmartArt diagram. Add nodes, remove nodes that are no longer needed, and update their text or appearance. This lets an application update an organization chart or process diagram while keeping its SmartArt structure.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates a hierarchy, clears its default nodes and adds one parent with two children. It removes a temporary child before saving, leaving a small editable hierarchy with explicit text.

```csharp
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var diagram = presentation.Slides[0].Shapes.AddSmartArt(60, 60, 500, 300, SmartArtLayoutType.OrganizationChart);
while (diagram.AllNodes.Count > 0)
{
    diagram.AllNodes.RemoveNode(0);
}
var parent = diagram.AllNodes.AddNode();
parent.TextFrame.Text = "Lead";
parent.ChildNodes.AddNode().TextFrame.Text = "Design";
parent.ChildNodes.AddNode().TextFrame.Text = "Build";
var temporary = parent.ChildNodes.AddNode();
temporary.TextFrame.Text = "Temporary";
parent.ChildNodes.RemoveNode(temporary);
presentation.Save("smartart-nodes.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I format a node's shapes separately?**

Yes. A node exposes its shapes, so you can adjust their formatting as well as the node's text and position in the hierarchy.

### **How can I insert a child under a particular SmartArt node?**

Access the intended parent node’s child-node collection and add or insert a child there. Adding to the diagram-wide collection is a different operation and should not be used to assume a particular parent.

### **What happens to child nodes when a parent is removed?**

Removing a parent can leave its children in the graphic. If your workflow needs to delete a whole branch, remove its descendants explicitly as well, then inspect the remaining hierarchy.

## **Guides**

- [Manage SmartArt Shape Nodes in Presentations in .NET](/slides/net/manage-smartart-shape-node/)

Related feature: [Read and add SmartArt](/slides/features/smartart/).
