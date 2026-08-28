---
title: Convert Presentation Slides to Images in C++
linktitle: Slide to Image
type: docs
weight: 41
url: /cpp/convert-slide/
keywords: 
- convert slide
- export slide
- slide to image
- save slide as image
- slide to EMF
- slide to PNG
- slide to JPEG
- slide to bitmap
- slide to TIFF
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Convert slides from PPT, PPTX, and ODP presentations to PNG, JPEG, GIF, TIFF, EMF, and other image formats in C++ with Aspose.Slides for C++."
---

## **Introduction**

Aspose.Slides for C++ can render individual slides from PowerPoint and OpenDocument presentations as PNG, JPEG, GIF, TIFF, and other image formats.

To convert a slide into an image, follow these steps:

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Select the slide that you want to render.
3. If necessary, configure rendering with the [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) or [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) class.
4. Call the [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) method. It returns an [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) object.
5. Call the [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) method and specify the output format with an [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) value.

## **Convert a Slide to a PNG Image**

The simplest conversion uses the default rendering settings. The resulting [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) object can be processed in memory or saved to a file.

The following C++ example renders the first slide and saves it as a PNG image:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convert Slides to Images with Custom Sizes**

Use the [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) overload that accepts a [Size](https://reference.aspose.com/slides/cpp/system.drawing/size/) value to render a slide with exact pixel dimensions.

The following example creates a 1820 × 1040 JPEG image:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convert Slides with Notes and Comments to Images**

By default, slide images do not include notes or comments. Assign a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) object to the [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) method to control where notes and comments appear.

The following example places truncated notes below the slide and comments to its right:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}

For slide-to-image conversion, do not set the [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) method to [BottomFull](https://reference.aspose.com/slides/cpp/aspose.slides.export/notespositions/). Notes can contain more text than the fixed image size can accommodate. Use [BottomTruncated](https://reference.aspose.com/slides/cpp/aspose.slides.export/notespositions/) instead.

{{% /alert %}}

## **Convert Slides to Images Using TIFF Options**

The [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) class lets you control the size, resolution, and other properties of the rendered TIFF image.

The following example renders the first slide as a 2160 × 2880 TIFF image at 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convert All Slides to Images**

Iterate through the slide collection to convert the entire presentation into a series of images. Hidden slides are included unless you explicitly skip them.

The following example renders every slide as a JPEG image with horizontal and vertical scale factors of 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Create Enhanced Metafile Output**

Enhanced Metafile (EMF) is useful when vector-based graphics must be exchanged with Microsoft Office or other Windows applications that support Windows metafiles. Unlike a pixel-based image, an EMF can retain vector drawing operations that scale without the same loss of sharpness. However, EMF is primarily a compatibility format for applications with Windows metafile support, not a universal interchange format. In addition, complex slide content, such as bitmap images and some effects, may be stored as rasterized elements inside the vector metafile container.

### **Export a Slide to EMF**

The [ISlide::WriteAsEmf](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeasemf/) method writes an [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) to a target stream in EMF format. The following example loads a presentation, selects the first slide, and writes it to an EMF file stream:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

The caller owns the stream passed to [ISlide::WriteAsEmf](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeasemf/) and must close or dispose it. Aspose.Slides writes at the stream's current position and leaves the stream open.

### **Convert an SVG Image to EMF and Add It to a Presentation**

Use [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/writeasemf/) to convert SVG content to EMF. The resulting bytes can be added to the presentation through [IImageCollection::AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) and placed on a slide with [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/).

The following example creates an [SvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/svgimage/) from SVG markup, converts it to an in-memory EMF, inserts the metafile on the first slide, and saves the presentation:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/writeasemf/) does not take ownership of the destination stream. After writing, the stream position is at the end of the generated data. The example calls [MemoryStream::ToArray](https://reference.aspose.com/slides/cpp/system.io/memorystream/toarray/) to obtain the complete buffer regardless of the current stream position, then passes that byte array to [IImageCollection::AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Keep the stream open until the consumer has finished reading it, and close it afterward.

EMF generation is available on the operating systems supported by Aspose.Slides for C++, but rendering can differ across platforms when fonts or native graphics dependencies are unavailable. Install the fonts used by the source content or configure suitable substitutions, follow the [platform requirements](/slides/cpp/system-requirements/) for Aspose.Slides for C++, and validate the result in the target EMF-consuming application. Linux and macOS applications often have limited or inconsistent support for displaying and editing Windows metafiles.

## **Color Emoji Rendering**

{{% alert title="Note" color="info" %}}
To render color emojis correctly when converting presentation slides to images, the emoji fonts used in the presentation must be installed and available on the system performing the conversion. For example, if the presentation uses **Segoe UI Emoji** and this font is missing, emojis may appear in monochrome in the output images.
{{% /alert %}}

## **FAQ**

**Does Aspose.Slides support rendering slides with animations?**

No. The [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) method renders a static image of the slide and does not export animations.

**Can hidden slides be exported as images?**

Yes. Hidden slides can be rendered like regular slides. Include them in the processing loop, as shown in the example above.

**Are shadows and other effects preserved in slide images?**

Yes. Aspose.Slides renders shadows, transparency, and other supported graphical effects in slide images.
