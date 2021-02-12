---
title: Create Shape Thumbnails
type: docs
weight: 60
url: /java/create-shape-thumbnails/
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Java is used to create presentation files where each page is a slides. These slides can be viewed by opening the presentation files using Microsoft PowerPoint. But sometimes, developers may need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for Java helps you generate thumbnail images of the slide shapes. How to use this feature is described in this article.

{{% /alert %}} 

## **Generate Shape Thumbnail from Slide**
To generate a shape thumbnail from any slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the shape thumbnail image of the referenced slide on default scale.
1. Save the thumbnail image to any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingShapeThumbnailFromASlide-GeneratingShapeThumbnailFromASlide.java" >}}


## **Generate Shape Thumbnail with User Defined Scaling Factor**
To generate the shape thumbnail of any slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with user defined dimensions.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingAThumbnailFromASlideWithUserDefinedScalingFactor-GeneratingAThumbnailFromASlideWithUserDefinedScalingFactor.java" >}}

## **Generate Shape Thumbnail of Bounds**
This method for creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of any slide shape in bound of its appearance, use following sample code:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingAShapeThumbnailInTheBoundsOfAShapesAppearance-GeneratingAShapeThumbnailInTheBoundsOfAShapesAppearance.java" >}}
## **Generate Shape Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class that represents the PPTX file.
1. Add SmartArt.
1. Obtain the reference of a node by using its Index.
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingAThumbnailOfSmartArtChildNode-GeneratingAThumbnailOfSmartArtChildNode.java" >}}
