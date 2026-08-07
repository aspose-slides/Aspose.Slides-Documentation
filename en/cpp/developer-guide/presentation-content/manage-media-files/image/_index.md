---
title: Optimize Image Management in Presentations Using C++
linktitle: Manage Images
type: docs
weight: 10
url: /cpp/image/
keywords:
- add image
- add picture
- add bitmap
- replace image
- replace picture
- from web
- background
- add PNG
- add JPG
- add SVG
- external SVG resources
- SVG resolver
- linked SVG images
- SVG fonts
- add EMF
- add WMF
- add TIFF
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Streamline image management in PowerPoint and OpenDocument with Aspose.Slides for C++, optimizing performance and automating your workflow."
---

## **Introduction**

Images make presentations more engaging and visually appealing. In Microsoft PowerPoint, you can insert pictures onto slides from files, the internet, or other sources. Similarly, Aspose.Slides allows you to add images to presentation slides in several ways. 

{{% alert title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow you to quickly create presentations from images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

If you want to add an image as a picture frame—especially if you plan to resize it, apply effects, or use other standard formatting options—see [Picture Frame](/slides/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

You can convert images from one format to another. See the following pages: convert [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), and [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supports images in popular formats such as JPEG, PNG, BMP, GIF, and others. 

## **Add Images Stored Locally to Slides**

You can add one or more images stored on your computer to a presentation slide. The following C++ sample code shows how to add an image to a slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Add Images from the Web to Slides**

If the image you want to add to a slide is not stored on your computer, you can add it directly from the web. 

The following C++ sample code shows how to add an image from the web to a slide:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Add Images to Slide Masters**

A slide master stores and controls information such as the theme and layout for the slides that use it. When you add an image to a slide master, the image appears on every slide based on that master. 

The following C++ sample code shows how to add an image to a slide master:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Add Images as Slide Backgrounds**

You can use a picture as the background for one or more slides. For details, see *[Setting Images as Backgrounds for Slides](/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Add SVG to Presentations**

SVG content can be added to a presentation using the [SvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/svgimage/) class. The resulting [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) object can then be added to the presentation image collection and used to create a picture frame.

The following C++ example imports a self-contained SVG string. All images, styles, and other resources used by this SVG are embedded directly in the SVG content.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Import SVG Content with External Resources**

SVG files exported from design tools, diagram editors, icon systems, and web pipelines may reference resources that are stored outside the SVG document. For example, an SVG can contain an image link such as `images/photo.png`, a CSS `url(...)` value, or a font URL.

To import such SVG content, create an [IExternalResourceResolver](https://reference.aspose.com/slides/cpp/aspose.slides.import/iexternalresourceresolver/) implementation and pass it, together with a base URI, to an appropriate `SvgImage` constructor. The base URI identifies the location of the SVG document and is used to resolve relative links.

The [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) interface provides access to information about the imported SVG:

- `get_SvgContent()` returns the SVG markup as a string.
- `get_SvgData()` returns the SVG content as a byte array.
- `get_BaseUri()` returns the base URI used for relative links.
- `get_ExternalResourceResolver()` returns the resolver assigned to the SVG image.

### **Implement an External Resource Resolver**

The resolver has two methods:

- [ResolveUri](https://reference.aspose.com/slides/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) combines the base URI and a relative resource link and returns an absolute URI. Return a null string when the link cannot be resolved or is not allowed.
- [GetEntity](https://reference.aspose.com/slides/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) returns a readable stream for an absolute resource URI. Return `nullptr` when the resource is missing, blocked, or unavailable. A fallback stream can also be returned when appropriate.

The following resolver loads linked resources only from an allowed local directory. Network resources and paths outside the allowed directory are blocked. An optional fallback image is returned for unresolved image links.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // This resolver intentionally allows local files only.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Use a fallback only for image resources. Returning an image stream
        // for a missing font or stylesheet would not be valid.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Resolve Linked Resources During SVG Import**

Assume that `assets/diagram.svg` contains a relative reference such as:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

The following C++ example passes the SVG file URI as the base URI and provides a custom resolver. The resolver converts the relative image link into an absolute URI and returns a stream containing the linked resource while Aspose.Slides processes the SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// The base URI represents the location of the SVG document.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The `SvgImage` class also provides overloads that accept SVG data as a byte array or a stream, along with an external resource resolver and a base URI.

{{% alert title="Important" color="warning" %}}

The resource resolver makes external resources available while Aspose.Slides processes and renders the SVG. It does not modify the original SVG markup or automatically embed the resolved resources into it.

When an `ISvgImage` is added to the presentation image collection, the PPTX file can contain both the original SVG representation and a raster fallback image. A linked resource can appear in the generated fallback image while a relative link such as `images/photo.png` remains unchanged in the stored SVG. An application that renders the native SVG representation may therefore omit the linked content when the original external resource is unavailable.

{{% /alert %}}

### **Create a Portable SVG Picture**

To create an SVG picture that does not depend on external files, make the SVG self-contained before creating the `SvgImage`. For example, replace linked image URLs with `data:` URIs that contain the image data:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

After all required resources are embedded in the SVG content, create the `SvgImage`, add it to the presentation image collection, and insert it into a picture frame as shown in the previous example.

### **Handle Missing or Blocked Resources**

Return a null string from `ResolveUri` when a resource URI is invalid, prohibited, or cannot be resolved. Return `nullptr` from `GetEntity` when the resource cannot be read. Aspose.Slides continues processing the SVG without that resource when possible.

A fallback stream can be returned for a missing resource, but its content must be compatible with the requested resource type. For example, return an image stream only for a missing image, not for a font or stylesheet.

{{% alert title="Security" color="warning" %}}

Do not resolve arbitrary file paths or unrestricted network URLs from untrusted SVG files. Restrict allowed schemes, directories, and hosts. For network resources, also apply connection timeouts, response-size limits, and content validation.

{{% /alert %}}

## **Convert SVG to a Set of Shapes**
Aspose.Slides can convert an SVG into a set of shapes, similar to the corresponding functionality in PowerPoint:


![PowerPoint Popup Menu](img_01_01.png)

This functionality is provided by an overload of the [AddGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) method of the [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) interface that takes an [ISvgImage](https://reference.aspose.com/slides/cpp/aspose.slides/isvgimage/) object as its first argument.

The following C++ sample code shows how to use this method to convert an SVG file to a set of shapes:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Source SVG file name
auto svgFileName = System::String(u"sample.svg");

// Output presentation file name
auto outPptxPath = System::String(u"presentation.pptx");

// Create a new presentation
auto presentation = System::MakeObject<Presentation>();

// Read the SVG file content
auto svgContent = File::ReadAllText(svgFileName);

// Create an SvgImage object
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Get the slide size
auto slideSize = presentation->get_SlideSize()->get_Size();

// Convert the SVG image to a group of shapes and scale it to the slide size
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Save the presentation in PPTX format
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Add Images as EMF to Slides**
Aspose.Slides for C++ allows you to generate EMF images from Excel worksheets with Aspose.Cells and add them to presentation slides. 

The following C++ sample code shows how to do this:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells for C++ must be started before any of its types are used.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render the worksheet as EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells returns the rendered page as a buffer, which Aspose.Slides adds as an image.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Replace Images in the Image Collection**

Aspose.Slides lets you replace images stored in a presentation’s image collection, including images used by slide shapes. This section describes several ways to update images in the collection. You can replace an image using raw byte data, an [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) instance, or another image that already exists in the collection.

Follow the steps below:

1. Load the presentation file that contains images using the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Load a new image from a file into a byte array.
1. Replace the target image with the new image using the byte array.
1. In the second approach, load the image into an [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) object and replace the target image with that object.
1. In the third approach, replace the target image with an image that already exists in the presentation’s image collection.
1. Write the modified presentation as a PPTX file.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// The first way.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// The second way.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// The third way.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Save the presentation to a file.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

With Aspose's free [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter, you can easily animate text and create GIFs from text. 

{{% /alert %}}

## **FAQ**

**Does the original image resolution remain intact after insertion?**

Yes. The source pixels are preserved, but the final appearance depends on how the [picture](/slides/cpp/picture-frame/) is scaled on the slide and any compression applied on save.

**What’s the best way to replace the same logo across dozens of slides at once?**

Place the logo on the master slide or a layout and replace it in the presentation’s image collection—updates will propagate to all elements that use that resource.

**Can an inserted SVG be converted into editable shapes?**

Yes. You can convert an SVG into a group of shapes, after which individual parts become editable with standard shape properties.

**How can I set a picture as the background for multiple slides at once?**

[Assign the image as the background](/slides/cpp/presentation-background/) on the master slide or the relevant layout—any slides using that master/layout will inherit the background.

**How do I prevent a presentation from becoming too large because of many pictures?**

Reuse a single image resource instead of duplicates, choose reasonable resolutions, apply compression on save, and keep repeated graphics on the master where appropriate.
