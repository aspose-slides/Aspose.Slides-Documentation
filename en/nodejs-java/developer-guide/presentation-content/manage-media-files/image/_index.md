---
title: Optimize Image Management in Presentations Using JavaScript
linktitle: Manage Images
type: docs
weight: 10
url: /nodejs-java/image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Streamline image management in PowerPoint and OpenDocument with Aspose.Slides for Node.js via Java, optimizing performance and automating your workflow."
---

## **Introduction**

Images make presentations more engaging and visually appealing. In Microsoft PowerPoint, you can insert pictures onto slides from files, the internet, or other sources. Similarly, Aspose.Slides allows you to add images to presentation slides in several ways.

{{% alert  title="Tip" color="info" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow you to quickly create presentations from images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

If you want to add an image as a picture frame—especially if you plan to resize it, apply effects, or use other standard formatting options—see [Picture Frame](/slides/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

You can convert images from one format to another. See the following pages: convert [image to JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), and [SVG to PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supports images in popular formats such as JPEG, PNG, BMP, GIF, and others. 

## **Add Images Stored Locally to Slides**

You can add one or more images stored on your computer to a presentation slide. The following JavaScript sample code shows how to add an image to a slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Add Images from the Web to Slides**

If the image you want to add to a slide is not stored on your computer, you can add it directly from the web. 

The following JavaScript sample code shows how to add an image from the web to a slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Add Images to Slide Masters**

A slide master stores and controls information such as the theme and layout for the slides that use it. When you add an image to a slide master, the image appears on every slide based on that master. 

The following JavaScript sample code shows how to add an image to a slide master:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Add Images as Slide Backgrounds**

You can use a picture as the background for one or more slides. For details, see *[Setting Images as Backgrounds for Slides](/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Add SVG to Presentations**

SVG content can be added to a presentation using the [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgimage/) class. The resulting SVG image object can then be added to the presentation image collection and used to create a picture frame.

The following JavaScript example imports a self-contained SVG string. All images, styles, and other resources used by this SVG are embedded directly in the SVG content.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Import SVG Content with External Resources**

SVG files exported from design tools, diagram editors, icon systems, and web pipelines may reference resources that are stored outside the SVG document. For example, an SVG can contain an image link such as `images/photo.png`, a CSS `url(...)` value, or a font URL.

To import such SVG content, provide an external resource resolver and pass it, together with a base URI, to an appropriate [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgimage/) constructor. The base URI identifies the location of the SVG document and is used to resolve relative links.

The `SvgImage` class provides access to information about the imported SVG:

- `getSvgContent()` returns the SVG markup as a string.
- `getSvgData()` returns the SVG content as a byte array.
- `getBaseUri()` returns the base URI used for relative links.
- `getExternalResourceResolver()` returns the resolver assigned to the SVG image.

### **Implement an External Resource Resolver**

The resolver has two methods:

- `resolveUri` combines the base URI and a relative resource link and returns an absolute URI. Return `null` when the link cannot be resolved or is not allowed.
- `getEntity` returns a readable Java stream for an absolute resource URI. Return `null` when the resource is missing, blocked, or unavailable. A fallback stream can also be returned when appropriate.

The following helper creates a resolver that loads linked resources only from an allowed local directory. Network resources and paths outside the allowed directory are blocked. An optional fallback image is returned for unresolved image links.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // This resolver intentionally allows local files only.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Use a fallback only for image resources. Returning an image stream
                // for a missing font or stylesheet would not be valid.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Resolve Linked Resources During SVG Import**

Assume that `assets/diagram.svg` contains a relative reference such as:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

The following JavaScript example passes the SVG file URI as the base URI and provides a custom resolver. The resolver converts the relative image link into an absolute URI and returns a stream containing the linked resource while Aspose.Slides processes the SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// The base URI represents the location of the SVG document.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The `SvgImage` class also provides overloads that accept SVG data as a byte array, as well as stream-based factory methods, together with an external resource resolver and a base URI.

{{% alert title="Important" color="warning" %}}

The resource resolver makes external resources available while Aspose.Slides processes and renders the SVG. It does not modify the original SVG markup or automatically embed the resolved resources into it.

When an SVG image is added to the presentation image collection, the PPTX file can contain both the original SVG representation and a raster fallback image. A linked resource can appear in the generated fallback image while a relative link such as `images/photo.png` remains unchanged in the stored SVG. An application that renders the native SVG representation may therefore omit the linked content when the original external resource is unavailable.

{{% /alert %}}

### **Create a Portable SVG Picture**

To create an SVG picture that does not depend on external files, make the SVG self-contained before creating the `SvgImage`. For example, replace linked image URLs with `data:` URIs that contain the image data:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

After all required resources are embedded in the SVG content, create the `SvgImage`, add it to the presentation image collection, and insert it into a picture frame as shown in the previous example.

### **Handle Missing or Blocked Resources**

Return `null` from `resolveUri` when a resource URI is invalid, prohibited, or cannot be resolved. Return `null` from `getEntity` when the resource cannot be read. Aspose.Slides continues processing the SVG without that resource when possible.

A fallback stream can be returned for a missing resource, but its content must be compatible with the requested resource type. For example, return an image stream only for a missing image, not for a font or stylesheet.

{{% alert title="Security" color="warning" %}}

Do not resolve arbitrary file paths or unrestricted network URLs from untrusted SVG files. Restrict allowed schemes, directories, and hosts. For network resources, also apply connection timeouts, response-size limits, and content validation.

{{% /alert %}}

## **Convert SVG to a Set of Shapes**

Aspose.Slides can convert an SVG into a set of shapes, similar to the corresponding functionality in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

This functionality is provided by an overload of the [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) method of the [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) class that takes an SVG image object as its first argument.

The following JavaScript sample code shows how to use this method to convert an SVG file to a set of shapes:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Source SVG file name.
const svgFileName = "sample.svg";

// Output presentation file name.
const outPptxPath = "presentation.pptx";

// Create a new presentation.
const presentation = new aspose.slides.Presentation();
try {
    // Read the SVG file content.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Create an SvgImage object.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Get the slide size.
    const slideSize = presentation.getSlideSize().getSize();

    // Convert the SVG image to a group of shapes and scale it to the slide size.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Save the presentation in PPTX format.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Add Images as EMF to Slides**

Aspose.Slides for Node.js via Java allows you to generate EMF images from Excel worksheets with Aspose.Cells and add them to presentation slides.

The following JavaScript sample code shows how to do this:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Save the workbook to a stream.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Add the file as-is so the picture stays a vector EMF instead of being rasterized.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Replace Images in the Image Collection**

Aspose.Slides lets you replace images stored in a presentation’s image collection, including images used by slide shapes. This section describes several ways to update images in the collection. You can replace an image using raw byte data, an [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) instance, or another image that already exists in the collection.

Follow the steps below:

1. Load the presentation file that contains images using the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Load a new image from a file into a byte array.
1. Replace the target image with the new image using the byte array.
1. In the second approach, load the image into an [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) object and replace the target image with that object.
1. In the third approach, replace the target image with an image that already exists in the presentation’s image collection.
1. Write the modified presentation as a PPTX file.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instantiate the Presentation class that represents a presentation file.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // The first way.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // The second way.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // The third way.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Save the presentation to a file.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

With Aspose's free [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter, you can easily animate text and create GIFs from text. 

{{% /alert %}}

## **FAQ**

**Does the original image resolution remain intact after insertion?**

Yes. The source pixels are preserved, but the final appearance depends on how the [picture](/slides/nodejs-java/picture-frame/) is scaled on the slide and any compression applied on save.

**What’s the best way to replace the same logo across dozens of slides at once?**

Place the logo on the master slide or a layout and replace it in the presentation’s image collection—updates will propagate to all elements that use that resource.

**Can an inserted SVG be converted into editable shapes?**

Yes. You can convert an SVG into a group of shapes, after which individual parts become editable with standard shape properties.

**How can I set a picture as the background for multiple slides at once?**

[Assign the image as the background](/slides/nodejs-java/presentation-background/) on the master slide or the relevant layout—any slides using that master/layout will inherit the background.

**How do I prevent a presentation from becoming too large because of many pictures?**

Reuse a single image resource instead of duplicates, choose reasonable resolutions, apply compression on save, and keep repeated graphics on the master where appropriate.
