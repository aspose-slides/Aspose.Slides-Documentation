---
title: Group Presentation Shapes in C++
linktitle: Shape Group
type: docs
weight: 40
url: /cpp/group/
keywords:
- group shape
- shape group
- add group
- alternative text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn to group and ungroup shapes in PowerPoint decks using Aspose.Slides for C++ — fast, step-by-step guide with free C++ code."
---


## **Add a Group Shape**
Aspose.Slides support working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for C++ supports adding or accessing group shapes. It is possible to add shapes to an added group shape to populate it or access any property of group shape. To add a group shape to a slide using Aspose.Slides for C++:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its Index
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}


## **Access the AltText Property**
This topic shows simple steps, complete with code examples, for adding a group shape and accessing AltText property of group shapes on slides. To access AltText of a group shape in a slide using Aspose.Slides for C++:

1. Instantiate `Presentation` class that represents a PPTX file.
1. Obtain the reference of a slide by using its Index.
1. Accessing the shape collection of slides.
1. Accessing the group shape.
1. Accessing the AltText property.

The example below accesses the alternative text of group shape.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Yes. [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) has a [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/) method, which directly indicates hierarchy support (a group can be a child of another group).

**How do I control the group’s z-order relative to other objects on the slide?**

Use the [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/)’s [Z-Order position](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) to inspect its position in the display stack.

**Can I prevent moving/editing/ungrouping?**

Yes. The group’s lock section is exposed via [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/), which lets you restrict operations on the object.
