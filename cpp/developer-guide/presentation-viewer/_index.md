---
title: Presentation Viewer
type: docs
weight: 50
url: /cpp/presentation-viewer/
keywords: "PowerPoint PPT Viewer"
description: "PowerPoint PPT Viewer in C++"
---

## **Generate SVG Image from Slide**
Aspose.Slides for C++ is used to create presentation files, complete with slides. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as SVG images in their favorite image viewer. In such cases, Aspose.Slides for C++ lets you export an individual slide to an SVG image. This article describes how to use this feature. To generate an SVG image from any desired slide with Aspose.Slides.Pptx for C++, please follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Obtain the desired slide's reference by using its ID or index.
- Get the SVG image in a memory stream.
- Save the memory stream to file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **Generate SVG with Custom Shape IDS**
Now Aspose.Slides for C++ can be used to generate SVG from slide with custom shape ID. These slides can be viewed by opening presentations using Microsoft PowerPoint. But sometimes, developers may also need to view slides as SVG images in their favorite image viewer. In such cases, Aspose.Slides for C++ lets you export an individual slide to an SVG image.For that purpose ID property has been added to ISvgShape to support custom IDs of shapes in generated SVG.  To implement this feature a CustomSvgShapeFormattingController has been introduced that you can use to set shape ID.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}


## **Create Slide Thumbnail Image**
Aspose.Slides for C++ is used to create presentation files containing slides. These slides can be viewed by opening presentation files using Microsoft PowerPoint. But sometimes, developers may need to view slides as images using their favorite image viewer. In such cases, Aspose.Slides for C++ help you generate thumbnail images of the slides. To generate the thumbnail of any desired slide using Aspose.Slides for C++:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RenderSlides-ThumbnailFromSlide.cpp" >}}

## **Create Thumbnail with User Defined Dimensions**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ThumbnailWithUserDefinedDimensions-ThumbnailWithUserDefinedDimensions.cpp" >}}

## **Create Thumbnail from Slide in Notes Slides View**
To generate the thumbnail of any desired slide in Notes Slide View using Aspose.Slides for C++:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale in Notes Slide view.
1. Save the thumbnail image in any desired image format.

The code snippet below produces a thumbnail of the first slide of a presentation in Notes Slide View.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ThumbnailFromSlideInNotes-ThumbnailFromSlideInNotes.cpp" >}}