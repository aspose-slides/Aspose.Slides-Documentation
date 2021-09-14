---
title: Convert Slide
type: docs
weight: 35
url: /java/convert-slide/
keywords: "Convert slide to image, export slide as image, save slide as image, slide to image, slide to PNG, slide to JPEG, slide to Bitmap, Java, java, Aspose.Slides"
description: "Convert PowerPoint slide to image (Bitmap, PNG, or JPG) in Java"
---

Aspose.Slides for Java allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others. 

To convert a slide to an image, do this: 

1. First,
   * convert the slide to a BufferedImage first by using the [GetThumbnail](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#getThumbnail--) method or
   * render the slide to a Graphics2D object by using the [RenderToGraphics](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-) method from the [ISlide](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide) interface.

2. Second, set additional options for conversion and convertible slide objects through
   * the [ITiffOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) interface or
   * the [IRenderingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions) interface. 

## **About Bitmap and Other Image Formats**

In Java, a [BufferedImage](https://docs.oracle.com/javase/7/docs/api/java/awt/image/BufferedImage.html) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (JPG, PNG, etc.).

## **Converting Slides to Bitmap and Saving the Images in PNG**

This Java code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Converts the first slide in the presentation to a BufferedImage object
    BufferedImage bmp = pres.getSlides().get_Item(0).getThumbnail();

	// Saves the image in the PNG format
	ImageIO.write(bmp, "PNG", new File("Slide_0.png"));
} catch (Exception e) {  
} finally {
    if (pres != null) pres.dispose();
}
```

This sample code shows you how to convert the first slide of a presentation to a bitmap object using the [RenderToGraphics](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-) method:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// Gets the presentation slide size
	Dimension2D slideSize = pres.getSlideSize().getSize();

	// Creates a BufferedImage with the slide size
	BufferedImage slideImage = new BufferedImage((int) slideSize.getWidth(), (int) slideSize.getHeight(), BufferedImage.TYPE_INT_ARGB);
	java.awt.Graphics graphics = slideImage.createGraphics();

	// Renders the first slide to the Graphics object
	try {
		pres.getSlides().get_Item(0).renderToGraphics(new RenderingOptions(), (Graphics2D) graphics);
	} finally {
		if (graphics != null) graphics.dispose();
	}

	ImageIO.write(slideImage, "png", new File("Slide_0.png"));
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a BufferedImage object and then use the object directly somewhere. Or you can convert a slide to a BufferedImage and then save the image in JPEG or any other format you prefer. 

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [GetThumbnail](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#getThumbnail-com.aspose.slides.IRenderingOptions-) or [RenderToGraphics](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-) method, you can convert a slide to an image with specific dimensions (length and width). 

This sample code demonstrates the proposed conversion using the [GetThumbnail](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#getThumbnail-java.awt.Dimension-) method in Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Converts the first slide in the presentation to a Bitmap with the specified size
    BufferedImage bmp = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1820, 1040));
	
	// Saves the image in the JPEG format
	ImageIO.write(bmp, "PNG", new File("Slide_0.jpg"));
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

This Java code demonstrates how to convert the first slide to the framed image with the [RenderToGraphics](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-) method:

``` java
Presentation pres = new Presentation("Presentation.pptx");
try {
	java.awt.Dimension slideSize = new java.awt.Dimension(1820, 1040);

	// Creates a BufferedImage with the specified size (slide size + fields)
	BufferedImage slideImage = new BufferedImage(slideSize.width + 50, slideSize.height + 50, BufferedImage.TYPE_INT_ARGB);
	java.awt.Graphics2D graphics = slideImage.createGraphics();
	try {
		// Fills and translates Graphics to create a frame around the slide
		graphics.setColor(java.awt.Color.RED);
		graphics.fillRect(-1, -1, slideImage.getWidth() + 1, slideImage.getHeight() + 1);
		graphics.translate(12, 12);

		// Renders the first slide to Graphics
		pres.getSlides().get_Item(0).renderToGraphics(new RenderingOptions(), (Graphics2D) graphics, slideSize);
	} finally {
		if (graphics != null) graphics.dispose();
	}

	// Saves the image in the JPEG format
	ImageIO.write(slideImage, "png", new File("FramedSlide_0.jpg"));
} finally {
	if (pres != null) pres.dispose();
}
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces—[ITiffOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) and [IRenderingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions)—that allow you to control the rendering of presentation slides to images. Both interfaces house the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="Info" color="info" %}} 

With the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface, you get to specify your preferred position for notes and comments in the resulting image. 

{{% /alert %}} 

This Java code demonstrates the conversion process for a slide with notes and comments:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // Creates the rendering options
    IRenderingOptions options = new RenderingOptions();

    // Sets the position of the notes on the page
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // Sets the position of the comments on the page 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // Sets the width of the comment output area
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // Sets the color for the comments area
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // Converts the first slide of the presentation to a Bitmap object
    BufferedImage bmp = pres.getSlides().get_Item(0).getThumbnail(options, 2f, 2f);

    // Saves the image in the GIF format
    ImageIO.write(bmp, "GIF", new File("Slide_Notes_Comments_0.gif"));
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

This Java code demonstrates the conversion process for a slide with notes using the [RenderToGraphics](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-) method:

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// Gets the presentation notes size
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// Creates the rendering options
	IRenderingOptions options = new RenderingOptions();

	// Sets the position of the notes
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Creates a Bitmap with the notes' size
	BufferedImage slideImage = new BufferedImage((int)notesSize.getWidth(), (int)notesSize.getHeight(), BufferedImage.TYPE_INT_ARGB);
	java.awt.Graphics2D graphics = slideImage.createGraphics();
	try {
		pres.getSlides().get_Item(0).renderToGraphics(options, graphics, 
				new Dimension((int)notesSize.getWidth(), (int)notesSize.getHeight()));
	} finally {
		if (graphics != null) graphics.dispose();
	}

	// Saves the image in PNG format
	ImageIO.write(slideImage, "png", new File("Slide_Notes_0.png"));
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, the [NotesPositions](https://apireference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size. 

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [ITiffOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image. 

This Java code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// Gets a slide by its index
	ISlide slide = pres.getSlides().get_Item(0);

	// Creates a TiffOptions object
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// Set the font used in case source font is not found
	options.setDefaultRegularFont("Arial Black");

	// Set the position of the notes on the page
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Sets the pixel format (black and white)
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// Sets the resolution
	options.setDpiX(300);
	options.setDpiY(300);

	// Converts the slide to a Bitmap object
	BufferedImage bmp = slide.getThumbnail(options);

	// Saves the image in TIFF format
	ImageIO.write(bmp, "TIFF", new File("PresentationNotesComments.tiff"));
} catch (IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Tiff support is not guaranteed in versions earlier than JDK 9.

{{% /alert %}} 

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Render presentation to images array slide by slide
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // Control hidden slides (do not render hidden slides)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // Convert slide to a Bitmap object
        BufferedImage bmp = pres.getSlides().get_Item(i).getThumbnail(2f, 2f);

        // Save the image in PNG format
        ImageIO.write(bmp, "PNG", new File("Slide_" + i + ".jpg"));
    }
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
} 
```

