---
title: Picture Frame
type: docs
weight: 10
url: /cpp/picture-frame/
keywords: "Add picture frame, create picture frame, StretchOff property, picture frame formatting, picture frame properties, PowerPoint presentation, C++, CPP, Aspose.Slides for C++"
description: "Add picture frame to PowerPoint presentation in C++"
---

A picture is a shape that contains an image—it is like a picture in a frame. 

You can add an image to a slide through a picture frame. This way, you get to format the image by formatting the picture frame.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

## **Create Picture Frame**

1. Create an instance of the [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) object by adding an image to the [IImagescollection](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a [PictureFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) based on the image's width and height through the `AddPictureFrame` method exposed by the shape object associated with the referenced slide.
6. Add a picture frame (containing the picture) to the slide.
7. Write the modified presentation as a PPTX file.

This C++ code shows you how to create a picture frame:

```c++
// The path to the documents directory.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// LoadS the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accesses first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Loads the Image that will be added in presentaiton image collection
// Gets the picture
auto bitmap = MakeObject<System::Drawing::Bitmap>(filePath);

// Adds an image to presentation's images collection
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(bitmap);

// Adds a picture frame to the slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Sets relative scale width and height
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Applies some formatting to PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Writes the PPTX file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



## **Create Picture Frame with Relative Scale**
By altering an image's relative scaling, you can create a more complicated picture frame. 

1. Create an instance of the [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Get a slide's reference through its index. 
3. Add an image to the presentation image collection.
4. Create an [IPPImage](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) object by adding an image to the [IImagescollection](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associated with the presentation object that will be used to fill the shape.
5. Specify the image's relative width and height in the picture frame.
6. Write the modified presentation as a PPTX file.

This C++ code shows you how to create a picture frame with relative scale:

```c++
// The path to the documents directory.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Loads the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accesses the first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Loads the Image to be added in presentaiton image collection
// Gets the picture
auto bitmap = MakeObject<System::Drawing::Bitmap>(filePath);

// Adds an image to the presentation's images collection
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(bitmap);

// Adds a picture frame to the slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Sets relative scale width and height
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes the PPTX file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Picture Frame Formatting**
Aspose.Slides provides many formatting options that can be applied to a picture frame. Using those options, you can alter a picture frame to make it match specific requirements.

1. Create an instance of the [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) object by adding an image to the [IImagescollection](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a `PictureFrame` based on the image's width and height through the [AddPictureFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) method exposed by the [IShapes](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) object associated with the referenced slide.
6. Add the picture frame (containing the picture) to the slide.
7. Set the picture frame's line color.
8. Set the picture frame's line width.
9. Rotate the picture frame by giving it either a positive or negative value.
   * A positive value rotates the image clockwise. 
   * A negative value rotates the image anti-clockwise.
10. Add the picture frame (containing the picture) to the slide.
11. Write the modified presentation as a PPTX file.

This C++ code demonstrates the picture frame formatting process:

```c++
// The path to the documents directory.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Loads the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accesses the first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Loads the Image to be added in presentaiton image collection
// Gets the picture
auto bitmap = MakeObject<System::Drawing::Bitmap>(filePath);

// Adds the image to presentation's images collection
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(bitmap);

// Adds a picture frame to the slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Sets relative scale width and height
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes the PPTX file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Crop Image**

This C++ code shows you how to crop an existing image on a slide: 

```c++

```

## **Use StretchOff Property**

Using the [StretchOffsetLeft](https://apireference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://apireference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://apireference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) and [StretchOffsetBottom](https://apireference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) properties from the [IPictureFillFormat](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) interface and [PictureFillFormat](https://apireference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format) class, you can specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset. A negative percentage specifies an outset.

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Get a slide's reference through its index.
3. Add a rectangle `AutoShape`. 
4. Create an image.
5. Set the shape's fill type.
6. Set the shape's picture fill mode.
7. Add a set image to fill the shape.
8. Specify image offsets from the corresponding edge of the shape's bounding box
9. Write the modified presentation as a PPTX file.

This C++ code demonstrates the process:

``` cpp
// Instantiates the Presentation class that represents a PPTX file
auto pres = System::MakeObject<Presentation>();
// Gets the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Instantiates the Bitmap class
auto img = System::MakeObject<Bitmap>(u"aspose-logo.jpg");
auto imgx = pres->get_Images()->AddImage(img);

// Adds a picture frame with the picture's equivalent height and width
sld->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(imgx->get_Width()), static_cast<float>(imgx->get_Height()), imgx);

//Writes the PPTX file to disk
pres->Save(u"AddStretchOffsetForImageFill_out.pptx", SaveFormat::Pptx);
```