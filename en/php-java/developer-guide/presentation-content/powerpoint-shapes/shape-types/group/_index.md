---
title: Group Presentation Shapes in PHP
linktitle: Shape Group
type: docs
weight: 40
url: /php-java/group/
keywords:
- group shape
- shape group
- add group
- alternative text
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn to group and ungroup shapes in PowerPoint decks using Aspose.Slides for PHP via Java — fast, step-by-step guide with free code."
---

## **Add a Group Shape**
Aspose.Slides support working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for PHP via Java supports adding or accessing group shapes. It is possible to add shapes to an added group shape to populate it or access any property of group shape. To add a group shape to a slide using Aspose.Slides for PHP via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```php
  # Instantiate Presentation class
  $pres = new Presentation();
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Accessing the shape collection of slides
    $slideShapes = $sld->getShapes();
    # Adding a group shape to the slide
    $groupShape = $slideShapes->addGroupShape();
    # Adding shapes inside Added group shape
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Adding group shape frame
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Write the PPTX file to disk
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Access the AltText Property**
This topic shows simple steps, complete with code examples, for adding a group shape and accessing AltText property of group shapes on slides. To access AltText of a group shape in a slide using Aspose.Slides for PHP via Java:

1. Instantiate [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class that represents PPTX file.
1. Obtain the reference of a slide by using its Index.
1. Access the shape collection of slides.
1. Access the group shape.
1. Access the [Alternative Text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getAlternativeText) property.

The example below accesses alternative text of group shape.

```php
  # Instantiate Presentation class that represents PPTX file
  $pres = new Presentation("AltText.pptx");
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Accessing the shape collection of slides
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Accessing the group shape.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Accessing the AltText property
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Yes. [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) has a [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) method, which directly indicates hierarchy support (a group can be a child of another group).

**How do I control the group’s z-order relative to other objects on the slide?**

Use the [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)’s [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) method to inspect its position in the display stack.

**Can I prevent moving/editing/ungrouping?**

Yes. The group’s lock section is exposed via [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/), which lets you restrict operations on the object.
