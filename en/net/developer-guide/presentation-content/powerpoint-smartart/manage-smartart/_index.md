---
title: Manage SmartArt
type: docs
weight: 10
url: /net/manage-smartart/
keywords: "SmartArt, text from SmartArt, Organization type chart, Picture organization chart, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "SmartArt and organization type chart in PowerPoint presentations in C# or .NET"
---

## **Get Text from SmartArt**
Now TextFrame property has been added to ISmartArtShape interface and SmartArtShape class respectively. This property allows you to get all text from SmartArt if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```



## **Change Layout Type of SmartArt**
In order to change the layout type of SmartArt. Please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Add SmartArt BasicBlockList.
- Change LayoutType to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```c#
using (Presentation presentation = new Presentation())
{
    // Add SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Change LayoutType to BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Saving Presentation
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **Check Hidden Property of SmartArt**
Please note Method com.aspose.slides.ISmartArtNode.isHidden() returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of SmartArt. Please follow the steps below:

- Create an instance of `Presentation` class.
- Add SmartArt RadialCycle.
- Add node on SmartArt.
- Check isHidden property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```c#
using (Presentation presentation = new Presentation())
{
    // Add SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Add node on SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Check isHidden property
    bool hidden = node.IsHidden; // Returns true

    if (hidden)
    {
        // Do some actions or notifications
    }
    // Saving Presentation
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **Get or Set Organization Chart Type**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of `Presentation` class.
- Add SmartArt on slide.
- Get or Set the organization chart type.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```c#
using (Presentation presentation = new Presentation())
{
    // Add SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Get or Set the organization chart type 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Saving Presentation
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **Create Picture Organization Chart**
Aspose.Slides for .NET provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the `Presentation` class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```

## **FAQ**

**Does SmartArt support mirroring/reversing for RTL languages?**

Yes. The [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) property switches the diagram direction (LTR/RTL) if the selected SmartArt type supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/net/shape-manipulations/) via the shapes collection ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) or [clone the entire slide](/slides/net/clone-slides/) containing this shape. Both approaches preserve size, position, and styling.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/net/convert-powerpoint-to-png/) (or the whole presentation) to PNG/JPEG through the API that converts slides/presentations to images—SmartArt will be drawn as part of the slide.

**How can I programmatically select a specific SmartArt on a slide if there are several?**

A common practice is to use [alternative text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) or a [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) and search for the shape by that attribute within [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), then check the type to confirm it’s [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). The documentation describes typical techniques for finding and working with shapes.
