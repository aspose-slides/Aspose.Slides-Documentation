---
title: Manage SmartArt
type: docs
weight: 10
url: /net/manage-smartart/
---

## **Get Text from SmartArt**
Now TextFrame property has been added to ISmartArtShape interface and SmartArtShape class respectively. This property allows you to get all text from SmartArt if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

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

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add SmartArt BasicBlockList.
- Change LayoutType to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

using (Presentation presentation = new Presentation())
{
    // Add SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Change LayoutType to BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Saving Presentation
    presentation.Save(dataDir + "ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **Check Hidden Property of SmartArt**
Please note Method com.aspose.slides.ISmartArtNode.isHidden() returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Add SmartArt RadialCycle.
- Add node on SmartArt.
- Check isHidden property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

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
    presentation.Save(dataDir + "CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **Get or Set Organization Chart Type**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Add SmartArt on slide.
- Get or Set the organization chart type.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

using (Presentation presentation = new Presentation())
{
    // Add SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Get or Set the organization chart type 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Saving Presentation
    presentation.Save(dataDir + "OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **Create Picture Organization Chart**
Aspose.Slides for .NET provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```c#
public static void Run()
{
	// The path to the documents directory.
	string dataDir = RunExamples.GetDataDir_Charts();
	using (Presentation pres = new Presentation(dataDir+"test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save(dataDir+"OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```



