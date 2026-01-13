---
title: Manage SmartArt in PowerPoint Presentations Using PHP
linktitle: Manage SmartArt
type: docs
weight: 10
url: /php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt text
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for PHP via Java using clear code samples that speed up slide design and automation."
---

## **Get Text from a SmartArt Object**
Now TextFrame method has been added to [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) class respectively. This property allows you to get all text from [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Change the Layout Type of a SmartArt Object**
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) BasicBlockList.
- Change [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```php
  $pres = new Presentation();
  try {
    # Add SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # Change LayoutType to BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # Saving Presentation
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Check the Hidden Property of a SmartArt Object**
Please note: method [SmartArtNode::isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) returns `true` if this node is a hidden node in the data model. In order to check the hidden property of any node of [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) RadialCycle.
- Add node on SmartArt.
- Check the [visibility](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```php
  $pres = new Presentation();
  try {
    # Add SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Add node on SmartArt
    $node = $smart->getAllNodes()->addNode();
    # Check isHidden property
    $hidden = $node->isHidden();// Returns true

    if ($hidden) {
      # Do some actions or notifications
    }
    # Saving Presentation
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get or Set the Organization Chart Type**
Methods [SmartArtNode::getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) and [SmartArtNode::setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) on slide.
- Get or [set the organization chart type](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/).
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```php
  $pres = new Presentation();
  try {
    # Add SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Get or Set the organization chart type
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Saving Presentation
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Create a Picture Organization Chart**
Aspose.Slides for PHP via Java provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType::PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get or Set SmartArt State**
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Add [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) on slide.
1. [Get](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/isreversed/) or [Set](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) the state of SmartArt Diagram.
1. Write the presentation as a PPTX file.

The following code is used to create a chart.

```php
  # Instantiate Presentation class that represents the PPTX file
  $pres = new Presentation();
  try {
    # Add SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Get or Set the state of SmartArt Diagram
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # Saving Presentation
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Does SmartArt support mirroring/reversing for RTL languages?**

Yes. The [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) method switches the diagram direction (LTR/RTL) if the selected SmartArt type supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/php-java/shape-manipulations/) via the shapes collection ([ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) or [clone the entire slide](/slides/php-java/clone-slides/) containing this shape. Both approaches preserve size, position, and styling.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/php-java/convert-powerpoint-to-png/) (or the whole presentation) to PNG/JPEG through the API that converts slides/presentations to images—SmartArt will be drawn as part of the slide.

**How can I programmatically select a specific SmartArt on a slide if there are several?**

A common practice is to use [alternative text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt Text) or a [name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) and search for the shape by that attribute within [slide shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), then check the type to confirm it’s [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). The documentation describes typical techniques for finding and working with shapes.
