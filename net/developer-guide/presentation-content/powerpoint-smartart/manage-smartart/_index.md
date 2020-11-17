---
title: Manage SmartArt
type: docs
weight: 10
url: /net/manage-smartart/
---

## **Get Text from SmartArt**
Now TextFrame property has been added to ISmartArtShape interface and SmartArtShape class respectively. This property allows you to get all text from SmartArt if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cs" >}}

## **Change Layout Type of SmartArt**
In order to change the layout type of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add SmartArt BasicBlockList.
- Change LayoutType to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-ChangeSmartArtLayout-ChangeSmartArtLayout.cs" >}}

## **Check Hidden Property of SmartArt**
Please note Method com.aspose.slides.ISmartArtNode.isHidden() returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Add SmartArt RadialCycle.
- Add node on SmartArt.
- Check isHidden property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cs" >}}

## **Get or Set Organization Chart Type**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Add SmartArt on slide.
- Get or Set the organization chart type.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-OrganizeChartLayoutType-OrganizeChartLayoutType.cs" >}}


## **Create Picture Organization Chart**
Aspose.Slides for .NET provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-OrganizationChart-OrganizationChart.cs" >}}




