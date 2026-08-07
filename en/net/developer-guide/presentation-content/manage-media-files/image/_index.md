---
title: Optimize Image Management in Presentations in .NET
linktitle: Manage Images
type: docs
weight: 10
url: /net/image/
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
- .NET
- C#
- Aspose.Slides
description: "Streamline image management in PowerPoint and OpenDocument with Aspose.Slides for .NET, optimizing performance and automating your workflow."
---

## **Introduction**

Images make presentations more engaging and visually appealing. In Microsoft PowerPoint, you can insert pictures onto slides from files, the internet, or other sources. Similarly, Aspose.Slides allows you to add images to presentation slides in several ways.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow you to quickly create presentations from images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

If you want to add an image as a picture frame—especially if you plan to resize it, apply effects, or use other standard formatting options—see [Picture Frame](/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

You can convert images from one format to another. See the following pages: convert [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), and [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supports images in popular formats such as JPEG, PNG, BMP, GIF, and others. 

## **Add Images Stored Locally to Slides**

You can add one or more images stored on your computer to a presentation slide. The following C# sample code shows how to add an image to a slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Add Images from the Web to Slides**

If the image you want to add to a slide is not stored on your computer, you can add it directly from the web. 

The following C# sample code shows how to add an image from the web to a slide:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Add Images to Slide Masters**

A slide master stores and controls information such as the theme and layout for the slides that use it. When you add an image to a slide master, the image appears on every slide based on that master. 

The following C# sample code shows how to add an image to a slide master:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Add Images as Slide Backgrounds**

You can use a picture as the background for one or more slides. For details, see *[Setting Images as Backgrounds for Slides](/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Add SVG to Presentations**

SVG content can be added to a presentation using the [SvgImage](https://reference.aspose.com/slides/net/aspose.slides/svgimage/) class. The resulting [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage/) object can then be added to the presentation image collection and used to create a picture frame.

The following C# example imports a self-contained SVG string. All images, styles, and other resources used by this SVG are embedded directly in the SVG content.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Import SVG Content with External Resources**

SVG files exported from design tools, diagram editors, icon systems, and web pipelines may reference resources that are stored outside the SVG document. For example, an SVG can contain an image link such as `images/photo.png`, a CSS `url(...)` value, or a font URL.

To import such SVG content, create an [IExternalResourceResolver](https://reference.aspose.com/slides/net/aspose.slides.import/iexternalresourceresolver/) implementation and pass it, together with a base URI, to an appropriate `SvgImage` constructor. The base URI identifies the location of the SVG document and is used to resolve relative links.

The [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage/) interface provides access to information about the imported SVG:

- `SvgContent` returns the SVG markup as a string.
- `SvgData` returns the SVG content as a byte array.
- `BaseUri` returns the base URI used for relative links.
- `ExternalResourceResolver` returns the resolver assigned to the SVG image.

### **Implement an External Resource Resolver**

The resolver has two methods:

- [ResolveUri](https://reference.aspose.com/slides/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) combines the base URI and a relative resource link and returns an absolute URI. Return `null` when the link cannot be resolved or is not allowed.
- [GetEntity](https://reference.aspose.com/slides/net/aspose.slides.import/iexternalresourceresolver/getentity/) returns a readable stream for an absolute resource URI. Return `null` when the resource is missing, blocked, or unavailable. A fallback stream can also be returned when appropriate.

The following resolver loads linked resources only from an allowed local directory. Network resources and paths outside the allowed directory are blocked. An optional fallback image is returned for unresolved image links.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // This resolver intentionally allows local files only.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Use a fallback only for image resources. Returning an image stream
        // for a missing font or stylesheet would not be valid.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Resolve Linked Resources During SVG Import**

Assume that `assets/diagram.svg` contains a relative reference such as:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

The following C# example passes the SVG file URI as the base URI and provides a custom resolver. The resolver converts the relative image link into an absolute URI and returns a stream containing the linked resource while Aspose.Slides processes the SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// The base URI represents the location of the SVG document.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
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

Return `null` from `ResolveUri` when a resource URI is invalid, prohibited, or cannot be resolved. Return `null` from `GetEntity` when the resource cannot be read. Aspose.Slides continues processing the SVG without that resource when possible.

A fallback stream can be returned for a missing resource, but its content must be compatible with the requested resource type. For example, return an image stream only for a missing image, not for a font or stylesheet.

{{% alert title="Security" color="warning" %}}

Do not resolve arbitrary file paths or unrestricted network URLs from untrusted SVG files. Restrict allowed schemes, directories, and hosts. For network resources, also apply connection timeouts, response-size limits, and content validation.

{{% /alert %}}

## **Convert SVG to a Set of Shapes**
Aspose.Slides can convert an SVG into a set of shapes, similar to the corresponding functionality in PowerPoint:


![PowerPoint Popup Menu](img_01_01.png)

This functionality is provided by an overload of the [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) method of the [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) interface that takes an [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) object as its first argument.

The following C# sample code shows how to use this method to convert an SVG file to a set of shapes:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Source SVG file name
string svgFileName = "sample.svg";

// Output presentation file name
string outPptxPath = "presentation.pptx";

// Create a new presentation
using (IPresentation presentation = new Presentation())
{
    // Read the SVG file content
    string svgContent = File.ReadAllText(svgFileName);

    // Create an SvgImage object
    ISvgImage svgImage = new SvgImage(svgContent);

    // Get the slide size
    SizeF slideSize = presentation.SlideSize.Size;

    // Convert the SVG image to a group of shapes and scale it to the slide size
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Save the presentation in PPTX format
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Add Images as EMF to Slides**
Aspose.Slides for .NET allows you to generate EMF images from Excel worksheets with Aspose.Cells and add them to presentation slides.

The following C# sample code shows how to do this:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Save the workbook to a stream
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Replace Images in the Image Collection**

Aspose.Slides lets you replace images stored in a presentation’s image collection, including images used by slide shapes. This section describes several ways to update images in the collection. You can replace an image using raw byte data, an [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) instance, or another image that already exists in the collection.

Follow the steps below:

1. Load the presentation file that contains images using the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Load a new image from a file into a byte array.
1. Replace the target image with the new image using the byte array.
1. In the second approach, load the image into an [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) object and replace the target image with that object.
1. In the third approach, replace the target image with an image that already exists in the presentation’s image collection.
1. Write the modified presentation as a PPTX file.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate the Presentation class that represents a presentation file.
using Presentation presentation = new Presentation("sample.pptx");

// The first way.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// The second way.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// The third way.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Save the presentation to a file.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

With Aspose's free [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter, you can easily animate text and create GIFs from text. 

{{% /alert %}}

## **FAQ**

**Does the original image resolution remain intact after insertion?**

Yes. The source pixels are preserved, but the final appearance depends on how the [picture](/slides/net/picture-frame/) is scaled on the slide and any compression applied on save.

**What’s the best way to replace the same logo across dozens of slides at once?**

Place the logo on the master slide or a layout and replace it in the presentation’s image collection—updates will propagate to all elements that use that resource.

**Can an inserted SVG be converted into editable shapes?**

Yes. You can convert an SVG into a group of shapes, after which individual parts become editable with standard shape properties.

**How can I set a picture as the background for multiple slides at once?**

[Assign the image as the background](/slides/net/presentation-background/) on the master slide or the relevant layout—any slides using that master/layout will inherit the background.

**How do I prevent a presentation from becoming too large because of many pictures?**

Reuse a single image resource instead of duplicates, choose reasonable resolutions, apply compression on save, and keep repeated graphics on the master where appropriate.
