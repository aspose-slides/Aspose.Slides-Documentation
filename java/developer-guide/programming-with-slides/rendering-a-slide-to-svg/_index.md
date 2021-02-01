---
title: Rendering a Slide to SVG
type: docs
weight: 90
url: /java/rendering-a-slide-to-svg/
---

## **Creating Slides SVG Image**
{{% alert color="primary" %}} 

Aspose.Slides for Java is used to create presentation files, complete with slides. These slides can be viewed by opening presentations using **Microsoft PowerPoint**. But sometimes, developers may also need to view slides as SVG images in their favorite image viewer. In such cases, Aspose.Slides for Java lets you export an individual slide to an SVG image. This article describes how to use this feature.

{{% /alert %}} 
### **Generating an SVG Image from a Slide**
To generate an SVG image from any desired slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the desired slide's reference by using its ID or index.
- Get the SVG image in a memory stream.
- Save the memory stream to file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-GeneratingSVGImageFromSlide-GeneratingSVGImageFromSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/5vvYtk3.png)|
| :- |
|**Figure : Sample SVG image created from a PowerPoint slide**|
## **Generating an SVG With Custom Shape IDS**
Now Aspose.Slides for Java can be used to generate SVG from slide with custom shape ID. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as SVG images in their favorite image viewer. In such cases, Aspose.Slides for Java lets you export an individual slide to an SVG image.For that purpose ID property has been added to ISvgShape to support custom IDs of shapes in generated SVG.  To implement this feature a CustomSvgShapeFormattingController has been introduced that you can use to set shape ID.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-GeneratingSVGImageWithCustomIDS-GeneratingSVGImageWithCustomIDS.java" >}}

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.java" >}}
