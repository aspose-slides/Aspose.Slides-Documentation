---
title: Manage SmartArt
type: docs
weight: 10
url: /cpp/manage-smartart/
---

## **Get Text from SmartArt**
Now TextFrame property has been added to ISmartArtShape interface and SmartArtShape class respectively. This property allows you to get all text from SmartArt if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Change Layout Type of any SmartArt**
In order to change the layout type of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtain the reference of a slide by using its Index.
- Add SmartArt BasicBlockList.
- Change LayoutType to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Check Hidden Property of SmartArt**
Please note Method com.aspose.slides.ISmartArtNode.isHidden() returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Add SmartArt RadialCycle.
- Add node on SmartArt.
- Check isHidden property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Get or Set Organization Chart Type**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Add SmartArt on slide.
- Get or Set the organization chart type.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Get or Set State of SmartArt**
Some SmartArt diagrams does not support reversal, for example; Vertical bullet list,Vertical Process,Descending Process,Funnel,Gear,,Balance,Circle Relationship,Hexagon Cluster,Reverse List,Stacked Venn. In order to change orientation of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Add SmartArt on slide.
- Get or Set the state of SmartArt Diagram.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}


## **Create Picture Organization Chart**
Aspose.Slides for C++ provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```
