---
title: Optimize Image Management in Presentations on Android
linktitle: Manage Images
type: docs
weight: 10
url: /androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "Streamline image management in PowerPoint and OpenDocument with Aspose.Slides for Android via Java, optimizing performance and automating your workflow."
---

## **Images in Presentation Slides**

Images make presentations more engaging and interesting. In Microsoft PowerPoint, you can insert pictures from a file, the internet, or other locations onto slides. Similarly, Aspose.Slides allows you to add images to slides in your presentations through different procedures. 

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

If you want to add an image as a frame object—especially if you plan to use standard formatting options on it to change its size, add effects, and so on—see [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides supports operations with images in these popular formats: JPEG, PNG, GIF, and others. 

## **Add Images Stored Locally to Slides**

You can add one or several images on your computer onto a slide in a presentation. This sample code in Java shows you how to add an image to a slide:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Add Images from the Web to Slides**

If the image you want to add to a slide is unavailable on your computer, you can add the image directly from the web. 

This sample code shows you how to add an image from the web to a slide in Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Add Images to Slide Masters**

A slide master is the top slide that stores and controls information (theme, layout, etc.) about all slides under it. So, when you add an image to a slide master, that image appears on every slide under that slide master. 

This Java sample code shows you how to add an image to a slide master:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Add Images as Slide Backgrounds**

You may decide to use a picture as the background for a specific slide or several slides. In that case, you have to see *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Add SVG to Presentations**
You can add or insert any image into a presentation by using the [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) method that belongs to the [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) interface.

To create an image object based on SVG image, you can do it this way:

1. Create SvgImage object to insert it to ImageShapeCollection
2. Create PPImage object from ISvgImage
3. Create PictureFrame object using IPPImage interface

This sample code shows you how to implement the steps above to add an SVG image into a presentation:
```java 
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert SVG to a Set of Shapes**
Aspose.Slides' conversion of SVG to a set of shapes is similar to the PowerPoint functionality used to work with SVG images:

![PowerPoint Popup Menu](img_01_01.png)

The functionality is provided by one of the overloads of the [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) method of the [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) interface that takes an [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) object as the first argument.

This sample code shows you how to use the described method to convert an SVG file to a set of shapes:

```java 
// Create new presentation
IPresentation presentation = new Presentation();
try {
    // Read SVG file content
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Create SvgImage object
    ISvgImage svgImage = new SvgImage(svgContent);

    // Get slide size
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Convert SVG image to group of shapes scaling it to slide size
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Save presentation in PPTX format
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Add Images as EMF to Slides**
Aspose.Slides for Android via Java allows you to generate EMF images from excel sheets and add the images as EMF in slides with Aspose.Cells. 

This sample code shows you how to perform the described task:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Save the workbook to stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Replace Images in the Image Collection**

Aspose.Slides lets you replace images stored in a presentation’s image collection (including those used by slide shapes). This section shows several approaches to updating images in the collection. The API provides straightforward methods to replace an image using raw byte data, an [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) instance, or another image that already exists in the collection.

Follow the steps below:

1. Load the presentation file that contains images using the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Load a new image from a file into a byte array.
1. Replace the target image with the new image using the byte array.
1. In the second approach, load the image into an [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) object and replace the target image with that object.
1. In the third approach, replace the target image with an image that already exists in the presentation’s image collection.
1. Write the modified presentation as a PPTX file.

```java
// Instantiate the Presentation class that represents a presentation file.
Presentation presentation = new Presentation("sample.pptx");
try {
    // The first way.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // The second way.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // The third way.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Save the presentation to a file.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Using Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter, you can easily animate texts, create GIFs from texts, etc. 

{{% /alert %}}

## **FAQ**

**Does the original image resolution remain intact after insertion?**

Yes. The source pixels are preserved, but the final appearance depends on how the [picture](/slides/androidjava/picture-frame/) is scaled on the slide and any compression applied on save.

**What’s the best way to replace the same logo across dozens of slides at once?**

Place the logo on the master slide or a layout and replace it in the presentation’s image collection—updates will propagate to all elements that use that resource.

**Can an inserted SVG be converted into editable shapes?**

Yes. You can convert an SVG into a group of shapes, after which individual parts become editable with standard shape properties.

**How can I set a picture as the background for multiple slides at once?**

[Assign the image as the background](/slides/androidjava/presentation-background/) on the master slide or the relevant layout—any slides using that master/layout will inherit the background.

**How do I prevent the presentation from "ballooning" in size because of many pictures?**

Reuse a single image resource instead of duplicates, choose reasonable resolutions, apply compression on save, and keep repeated graphics on the master where appropriate.
