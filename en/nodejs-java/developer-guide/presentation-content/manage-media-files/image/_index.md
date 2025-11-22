---
title: Image
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
- add EMF
- add WMF
- add TIFF
- PowerPoint
- OpenDocument
- presentation
- EMF
- SVG
- Node.js
- Aspose.Slides
description: "Streamline image management in PowerPoint and OpenDocument with Aspose.Slides for Node.js, optimizing performance and automating your workflow."
---

## **Images in Slides In Presentations**

Images make presentations more engaging and interesting. In Microsoft PowerPoint, you can insert pictures from a file, the internet, or other locations onto slides. Similarly, Aspose.Slides allows you to add images to slides in your presentations through different procedures. 

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

If you want to add an image as a frame object—especially if you plan to use standard formatting options on it to change its size, add effects, and so on—see [Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

You can manipulate input/output operations involving images and PowerPoint presentations to convert an image from one format to another. See these pages: convert [image to JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides supports operations with images in these popular formats: JPEG, PNG, GIF, and others. 

## **Adding Images Stored Locally to Slides**

You can add one or several images on your computer onto a slide in a presentation. This sample code in JavaScript shows you how to add an image to a slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adding Images From the Stream to Slides**

If the image you want to add to a slide is unavailable on your computer, you can add the image directly from the web. 

This sample code shows you how to add an image from the web to a slide in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accesses the first slide
    var sld = pres.getSlides().get_Item(0);
    // Loads an excel file to stream
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Creates a data object for embedding
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Adds an Ole Object Frame shape
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Writes the PPTX file to disk
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adding Images to Slide Masters**

A slide master is the top slide that stores and controls information (theme, layout, etc.) about all slides under it. So, when you add an image to a slide master, that image appears on every slide under that slide master. 

This JavaScript sample code shows you how to add an image to a slide master:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adding Images as Slide Background**

You may decide to use a picture as the background for a specific slide or several slides. In that case, you have to see *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Adding SVG to Presentations**
You can add or insert any image into a presentation by using the [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) method that belongs to the [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) class.

To create an image object based on SVG image, you can do it this way:

1. Create SvgImage object to insert it to ImageShapeCollection
2. Create PPImage object from ISvgImage
3. Create PictureFrame object using PPImage class

This sample code shows you how to implement the steps above to add an SVG image into a presentation:
```javascript
// Instantiate Presentation class that represents PPTX file
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converting SVG to a Set of Shapes**
Aspose.Slides' conversion of SVG to a set of shapes is similar to the PowerPoint functionality used to work with SVG images:

![PowerPoint Popup Menu](img_01_01.png)

The functionality is provided by one of the overloads of the [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) method of the [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) class that takes an [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) object as the first argument.

This sample code shows you how to use the described method to convert an SVG file to a set of shapes:

```javascript
// Create new presentation
var presentation = new aspose.slides.Presentation();
try {
    // Read SVG file content
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Create SvgImage object
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Get slide size
    var slideSize = presentation.getSlideSize().getSize();
    // Convert SVG image to group of shapes scaling it to slide size
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Save presentation in PPTX format
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Adding Images as EMF in Slides**
Aspose.Slides for Node.js via Java allows you to generate EMF images from excel sheets and add the images as EMF in slides with Aspose.Cells. 

This sample code shows you how to perform the described task:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Replacing Images in the Image Collection**

Aspose.Slides lets you replace images stored in a presentation’s image collection (including those used by slide shapes). This section shows several approaches to updating images in the collection. The API provides straightforward methods to replace an image using raw byte data, an [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) instance, or another image that already exists in the collection.

Follow the steps below:

1. Load the presentation file that contains images using the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Load a new image from a file into a byte array.
1. Replace the target image with the new image using the byte array.
1. In the second approach, load the image into an [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) object and replace the target image with that object.
1. In the third approach, replace the target image with an image that already exists in the presentation’s image collection.
1. Write the modified presentation as a PPTX file.

```js
// Instantiate the Presentation class that represents a presentation file.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // The first way.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // The second way.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
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

Using Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter, you can easily animate texts, create GIFs from texts, etc. 

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

**How do I prevent the presentation from "ballooning" in size because of many pictures?**

Reuse a single image resource instead of duplicates, choose reasonable resolutions, apply compression on save, and keep repeated graphics on the master where appropriate.
