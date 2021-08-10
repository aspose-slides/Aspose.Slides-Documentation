---
title: Picture Frame
type: docs
weight: 10
url: /cpp/picture-frame/
---


## **Create Picture Frame**
Picture frame is also one of the shapes offered by Aspose.Slides for C++. Adding picture frame to a slide is bit trickier than simple shapes. A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.
This article explains how picture frames can be used in different ways:

- Adding Simple Picture Frames to Slides.
- Controlling Picture Frame Formatting.
- Adding Picture Frame with Relative Scale.

To add a simple picture frame to your slide, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its index.
- Create an Image object by adding an image to the Images collection associated with the Presentation object that will be used to fill the Shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the AddPictureFrame method exposed by the Shapes object associated with the referenced slide.
- Add a picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PictureFrameFormatting-PictureFrameFormatting.cpp" >}}

## **Create Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its index.
- Add an image to the presentation image collection.
- Create an [IPPImage](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Set the relative width and height of the image in the picture frame.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddRelativeScaleHeightPictureFrame-AddRelativeScaleHeightPictureFrame.cpp" >}}


## **Picture Frame Formatting**
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the [AddPictureFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) method exposed by the [IShapes](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) object associated with the referenced slide.
- Add the picture frame (containing the picture) to the slide.
- Set the picture frame's line color.
- Set the picture frame's line width.
- Rotate the picture frame by giving it either a positive or negative value.
- A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
- Add the picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PictureFrameFormatting-PictureFrameFormatting.cpp" >}}


## **Add StretchOff Property**
The methods get(set)_StretchOffsetLeft(), get(set)_StretchOffsetTop(), get(set)_StretchOffsetRight() and get(set)_StretchOffsetBottom() has been added to IPictureFillFormat interface and PictureFillFormat class respectively. These methods specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

- Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtain the reference of a slide by using its index.
- Add an AutoShape of Rectangle type.
- Create Image.
- Set shape's fill type.
- Set shape's picture fill mode.
- Add Set image to fill the shape.
- Specify image offsets from the corresponding edge of the shape's bounding box
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

``` cpp
// Instantiate Prseetation class that represents the PPTX
auto pres = System::MakeObject<Presentation>();
// Get the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Instantiate the Bitmap class
auto img = System::MakeObject<Bitmap>(u"aspose-logo.jpg");
auto imgx = pres->get_Images()->AddImage(img);

// Add Picture Frame with height and width equivalent of Picture
sld->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(imgx->get_Width()), static_cast<float>(imgx->get_Height()), imgx);

//Write the PPTX file to disk
pres->Save(u"AddStretchOffsetForImageFill_out.pptx", SaveFormat::Pptx);
```