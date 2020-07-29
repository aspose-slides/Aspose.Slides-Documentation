---
title: Rendering a Slide
type: docs
weight: 80
url: /java/rendering-a-slide/
---

## **Creating Slides Thumbnail Image**
{{% alert color="primary" %}} 

Aspose.Slides for Java is used to create presentation files containing slides. These slides can be viewed by opening presentation files using Microsoft PowerPoint. But sometimes, developers may need to view slides as images using their favorite image viewer. In such cases, Aspose.Slides for Java help you generate thumbnail images of the slides. How to use this feature is described in this article.

{{% /alert %}} 
### **Generating a Thumbnail from a Slide**
To generate the thumbnail of any desired slide using Aspose.Slides for Java:

1. Create an instance of the Presentation class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-GeneratingThumbnailFromSlide-GeneratingThumbnailFromSlide.java" >}}
### **Generating a Thumbnail from a Slide with User Defined Dimensions**
To generate the thumbnail of any desired slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the X and Y scaling factors based on user defined X and Y dimensions.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-GeneratingThumbnailFromSlideWithUserDefinedDimensions-GeneratingThumbnailFromSlideWithUserDefinedDimensions.java" >}}
### **Generating a Thumbnail from a Slide in Notes Slides View**
To generate the thumbnail of any desired slide in Notes Slide View using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale in Notes Slide view.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-GeneratingThumbnailFromSlideInNotesSlidesView-GeneratingThumbnailFromSlideInNotesSlidesView.java" >}}
### **Generating a Thumbnail of User Defined Window from a Slide**
To generate the thumbnail of a user defined Window inside a desired slide using Aspose.Slides for Java, please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation file.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Get the desired window image inside the generate slide thumbnail using [BufferedImage.getSubImage()](http://docs.oracle.com/javase/6/docs/api/java/awt/image/BufferedImage.html#getSubimage%28int,%20int,%20int,%20int%29) method.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-GeneratingThumbnailOfUserDefinedWindowFromSlide-GeneratingThumbnailOfUserDefinedWindowFromSlide.java" >}}
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
