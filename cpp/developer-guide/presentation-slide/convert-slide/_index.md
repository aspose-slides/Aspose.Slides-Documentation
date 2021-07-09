---
title: Convert Slide
type: docs
weight: 41
url: /cpp/convert-slide/
---

You can convert presentation slides to any graphic image formats, such as PNG, BMP, JPEG, GIF, etc., 
by using Aspose.Slides API for C++.
Use GetThumbnail method of 
[ISlide](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_slide) interface to convert slide to a [Bitmap](https://apireference.aspose.com/slides/cpp/class/system.drawing.bitmap) object.
Also, you can use [ITiffOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) or [IRenderingOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options) interfaces to set additional options for conversion and convertible slide objects.
These interfaces and their methods are described below in the specialized sections of the article.


## **Convert Slide to Bitmap**

The code example below shows how to convert the first slide of presentation to a PNG image.

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide of the presentation to a Bitmap object
System::SharedPtr<Bitmap> bmp = pres->get_Slides()->idx_get(0)->GetThumbnail();
                 
// Save the image in PNG format
bmp->Save(u"Slide_0.png", ImageFormat::get_Png());
```

## **Convert Slide to Image with Custom Size**

Sometimes you need to get an image of a slide of a certain size. 
The following example demonstrates this capability using one of the 
GetThumbnail method overloads:

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide of the presentation to a Bitmap with the specified size
System::SharedPtr<Bitmap> bmp = pres->get_Slides()->idx_get(0)->GetThumbnail(Size(1820, 1040));

// Save the image in JPEG format
bmp->Save(u"Slide_0.jpg", ImageFormat::get_Jpeg());
```

## **Convert Slide with Notes and Comments to Image**

There are two interfaces [ITiffOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) and [IRenderingOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options), used to control the rendering of presentation slides to images.
Both of these interfaces include the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) interface, which can be used to include notes and comments of a slide in an exported image.
Using this interface, you can also control the position in which notes and comments will be displayed in the image.
The following example demonstrates the usage of the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) interface with the [IRenderingOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options) interface.
An example of ITiffOptions interface usage will be provided below. 

{{% alert title="Note" color="dark" %}} 
When converting slide to an image, the 
set_NotesPosition method cannot take BottomFull to indicate the location of the notes.
This is since the text of the note can be quite large and it cannot physically fit into the specified image size.

{{% /alert %}} 

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// Create rendering options
System::SharedPtr<IRenderingOptions> options = System::MakeObject<RenderingOptions>();

// Set the position of the notes on the page
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// Set the position of the comments on the page 
options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

// Set the width of the comment output area
options->get_NotesCommentsLayouting()->set_CommentsAreaWidth(500);

// Set the color of comments area
options->get_NotesCommentsLayouting()->set_CommentsAreaColor(Color::get_AntiqueWhite());

// Convert the first slide of the presentation to a Bitmap object
System::SharedPtr<Bitmap> bmp = pres->get_Slides()->idx_get(0)->GetThumbnail(options, 2.f, 2.f);

// Save the image in GIF format
bmp->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::get_Gif());
```

## **Convert Slide to Image using ITiffOptions Options**

[ITiffOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) provides a more complete 
control over the resulting image file.
Using this interface, you can specify the size, resolution, color palette of the resulting image. 
Below is an example of using the ITiffOptions interface to get a black and white image with 300dpi resolution 
and 2160x2880 size:

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// Get a slide by its index
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Create TiffOptions object
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// Set font used in case source font is not found
options->set_DefaultRegularFont(u"Arial Black");

// Set the position of the notes on the page 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// Set pixel format (black and white)
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// Set resolution
options->set_DpiX(300);
options->set_DpiY(300);

// Convert slide to a Bitmap object
System::SharedPtr<Bitmap> bmp = slide->GetThumbnail(options);

// Save the image in BMP format
bmp->Save(u"PresentationNotesComments.bmp", ImageFormat::get_Tiff());
```

## **Convert Slide to HTML**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a18df81989014383671668617295f4297) method exposed by the [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class can be used to convert the whole presentation into a HTML document. The [HtmlOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.html_options/) class can be used to set the options. Saving an interdependent PowerPoint slide to individual HTML file per slide is a now possible using Aspose.Slides for C++ and you simply open the presentation and save it out to HTML.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertIndividualSlideToHTML-ConvertIndividualSlideToHTML.cpp" >}}

## **Convert Slide to PDF**
The following example shows how to convert a specific presentation slide to a PDF document with custom options.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Conversion-ConvertSpecificSlideToPDF-ConvertSpecificSlideToPDF.cs" >}}


## **Convert Slide to PDF with Custom Slide Size**
The following example shows how to convert a presentation to a PDF notes document with custom slide size. Where each inch equals 72.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetSlideSizeScale-SetSlideSizeScale.cpp" >}}


## **Convert Slide to PDF with Notes Slide View**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a8e91317bad4f6f5c8a999686260a9162) method exposed by [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class can be used to convert the whole presentation in Notes Slide view to PDF. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for C++ is a two-line process. You simply open the presentation and save it out to PDF notes. The code snippets below update the sample presentation to PDF in Notes Slide view.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ConvertNotesSlideViewToPDF-ConvertNotesSlideViewToPDF.cpp" >}}

## **Convert Presentation to Set of Images**

In some cases, it is necessary to convert the entire presentation into a set of images, 
the same as PowerPoint allows. The following example demonstrates this possibility:

``` cpp 
// Path to output directory
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Render presentation to images array slide by slide
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // Control hidden slides (do not render hidden slides)
    if (pres->get_Slides()->idx_get(i)->get_Hidden())
    {
        continue;
    }

    // Convert slide to a Bitmap object
    auto bmp = pres->get_Slides()->idx_get(i)->GetThumbnail(2.f, 2.f);

    // Create file name for an image
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // Save the image in PNG format
    bmp->Save(outputFilePath, ImageFormat::get_Png());
}
```
