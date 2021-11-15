---
title: Adding Media Player using Aspose.Slides
type: docs
weight: 20
url: /java/adding-media-player-using-aspose-slides/
---

## **Aspose.Slides - Adding Media Player**
ActiveX control are used in presentations. Aspose.Slides for Java lets you add and manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. The support for adding Media Player ActiveX control has been added in Aspose.Slides. Remember, ActiveX controls are not shapes and are not part of the presentation's IShapeCollection but the separate IControlExCollection. This article shows how to work with them.

**Java**

{{< highlight java >}}

 //Create empty presentation instance

Presentation newPptx = new Presentation();

//Adding the Media Player ActiveX control

newPptx.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 550, 300);

//Access the Media Player ActiveX control and set the video path

newPptx.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "C:\\Wildlife.wmv");

//Save the Presentation

newPptx.save(dataDir + "AsposeMediaPlayer.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/mediacontrols/addingmediaplayer/AsposeAddMediaPlayer.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/mediacontrols/addingmediaplayer/AsposeAddMediaPlayer.java)

{{% alert color="primary" %}} 

For more details, visit [Adding Media Player ActiveX Controls in Slide](http://docs.aspose.com:8082/docs/display/slidesjava/Adding+Media+Player+ActiveX+Controls+in+Slide).

{{% /alert %}}
