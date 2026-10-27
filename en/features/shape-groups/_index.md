---
title: Group shapes
description: Organize shapes into groups and nested groups.
type: docs
url: /features/shape-groups/
weight: 560
feature_id: shape-groups
feature_group: shapes
translationKey: slides-feature-shape-groups
feature_catalogue_version: 3
feature_guides:
- /slides/net/group/
---

## **Overview**

Group related shapes so your application can manage them as a unit. Groups can contain other groups, allowing a larger diagram to keep a useful internal structure. Move the group while keeping the relationships among its child shapes.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates two rectangles inside a group and moves the group to a new frame. The two child shapes keep their names and remain accessible as separate editable objects.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var group = presentation.Slides[0].Shapes.AddGroupShape();
group.Name = "Diagram pair";
var first = group.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 80, 60);
first.Name = "Left item";
var second = group.Shapes.AddAutoShape(ShapeType.Rectangle, 140, 20, 80, 60);
second.Name = "Right item";
group.Frame = new ShapeFrame(100, 160, 200, 60, NullableBool.False, NullableBool.False, 0);
presentation.Save("shape-groups.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I still edit a shape inside a group?**

Yes. The group's child shapes remain accessible. You can change an individual item as well as operate on the group.

### **How do child coordinates relate to the group coordinate system?**

A group has an outer frame and an internal coordinate system for its children. Moving or resizing the outer frame transforms the group as a unit; use the child coordinates when editing its internal arrangement.

### **Can groups contain other groups?**

Yes. A group’s child-shape collection can contain another group. Traverse groups recursively when processing every descendant shape.

## **Guides**

- [Group Presentation Shapes in .NET](/slides/net/group/)

Related feature: [Change shape stacking order](/slides/features/shape-order/).
