---
title: Manage SmartArt
type: docs
weight: 10
url: /java/manage-smartart/
---

## **Get Text from SmartArt**
Now TextFrame method has been added to [ISmartArtShape](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) interface and [SmartArtShape](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) class respectively. This property allows you to get all text from [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt) if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change Layout Type of SmartArt**
In order to change the layout type of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Change [LayoutType](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```java
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Change LayoutType to BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Saving Presentation
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Check Hidden Property of SmartArt**
Please note: method [ISmartArtNode.isHidden()]((https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)) returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Add [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Add node on SmartArt.
- Check [isHidden](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```java
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Add node on SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Check isHidden property
    boolean hidden = node.isHidden(); // Returns true

    if (hidden)
    {
        // Do some actions or notifications
    }
    // Saving Presentation
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get or Set Organization Chart Type**
Methods [ISmartArtNode.getOrganizationChartLayout()](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Add [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
- Get or [set the organization chart type](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```java
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Get or Set the organization chart type
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Saving Presentation
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create Picture Organization Chart**
Aspose.Slides for Java provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get or Set SmartArt State**
In order to change the layout type of [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArt). Please follow the steps below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Add [SmartArt](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
1. [Get](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) or [Set](https://apireference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) the state of SmartArt Diagram.
1. Write the presentation as a PPTX file.

The following code is used to create a chart.

```java
// Instantiate Presentation class that represents the PPTX file
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Get or Set the state of SmartArt Diagram
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Saving Presentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


