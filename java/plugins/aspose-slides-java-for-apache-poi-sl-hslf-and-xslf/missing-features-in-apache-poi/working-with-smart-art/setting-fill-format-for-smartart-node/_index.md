---
title: Setting Fill Format for SmartArt Node using Aspose.Slides
type: docs
weight: 50
url: /java/setting-fill-format-for-smartart-node-using-aspose-slides/
---

## **Aspose.Slides - Setting Fill Format for SmartArt Shapes**
Aspose.Slides for Java provides a simple API for creating SmartArt shapes and set their node fill format. Please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/docs/display/slidesjava/com.aspose.slides.Presentation+class) class.
1. Obtain the reference of a slide using its index.
1. Add a SmartArt shape by setting its LayoutType.
1. Set the FillFormat for the SmartArt shape nodes.
1. Write the modified presentation as a PPTX file.

**Java**

{{< highlight java >}}

 //Instantiate the presentation

Presentation pres = new Presentation();

//Accessing the slide

ISlide slide = pres.getSlides().get_Item(0);

//Adding SmartArt shape and nodes

ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, com.aspose.slides.SmartArtLayoutType.ClosedChevronProcess);

ISmartArtNode node = chevron.getAllNodes().addNode();

node.getTextFrame().setText("Some text");

//Setting node fill color

for (IShape item : node.getShapes())

{

  item.getFillFormat().setFillType(FillType.Solid);

  item.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

//Save the presentation

pres.save(dataDir + "AsposeTestSmart.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/smartart/settingfillformat/AsposeSettingFillFormatForSmartArtNodes.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/smartart/settingfillformat/AsposeSettingFillFormatForSmartArtNodes.java)

{{% alert color="primary" %}} 

For more details, visit [Setting Fill Format For SmartArt Node](http://www.aspose.com/docs/display/slidesjava/Setting+Fill+Format+for+SmartArt+Node).

{{% /alert %}}
