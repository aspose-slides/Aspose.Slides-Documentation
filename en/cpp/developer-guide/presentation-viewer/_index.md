---
title: Presentation Viewer
type: docs
weight: 50
url: /cpp/presentation-viewer/
keywords: 
- view PowerPoint presentation
- view ppt
- view PPTX
- C++
- Aspose.Slides for C++
description: "View PowerPoint presentation in C++"
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

```cpp
// Instantiate the Presentation class
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlide.pptx");

// Access the first slide
auto slide = presentation->get_Slide(0);

// Create a full scale image
auto image = slide->GetImage(1, 1);
image->Save(u"Thumbnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Create Thumbnail with User Defined Dimensions**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

```cpp
// Instantiate the Presentation class
auto presentation = MakeObject<Presentation>(u"ThumbnailWithUserDefinedDimensions.pptx");

// Access the first slide
auto slide = presentation->get_Slide(0);

// User defined dimension
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Getting scaled value of X and Y
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Create a custom scale image
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Thumbnail2_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Create Thumbnail from Slide in Notes Slides View**
To generate the thumbnail of any desired slide in Notes Slide View using Aspose.Slides for C++:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale in Notes Slide view.
1. Save the thumbnail image in any desired image format.

The code snippet below produces a thumbnail of the first slide of a presentation in Notes Slide View.

```cpp
// Instantiate the Presentation class
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlideInNotes.pptx");

// Access the first slide
auto slide = presentation->get_Slide(0);

// User defined dimension
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Getting scaled value of X and Y
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Create a full scale image
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Notes_tnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```
