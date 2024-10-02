---
title: Print Presentation
type: docs
weight: 50
url: /java/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, Java, Printer, PrinterJob, PrintService"
description: "Print PowerPoint Presentation in Java"
---

In Aspose.Slides for Java 24.4, we have introduced a [Modern API](https://docs.aspose.com/slides/java/modern-api/) that limits print support. However, we have taken a new approach to help you overcome this limitation. In this article, we will show you how to print a presentation using the current API.

## Print Presentation

This Java code snippet demonstrates how to print a PowerPoint presentation using Aspose.Slides for Java API. 

To print a presentation, follow these steps:

1. Create an instance of the `PrintRequestAttributeSet` and specify printing attributes such as orientation and page range.
2. Create an instance of the `RenderingOptions` and specify options for slide notes layout.
3. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class, specifying the presentation file.
4. Create an instance of the `PrinterJob` to specify the desired printer.
5. Generate an array of Slide Images using the [getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) method.
6. Set the `IImage` array as Printable for `PrinterJob`.
7. Call the `print` method of the `PrinterJob` class.

Ensure to replace **"printerName"** with the name of your specific printer and configure the `PrintRequestAttributeSet` and `RenderingOptions` according to your printing requirements.

{{% alert color="primary" %}} 
Please note that printing Notes must require changing the page orientation to `OrientationRequested.PORTRAIT`.
{{% /alert %}} 

If you encounter any issues or need further assistance, feel free to reach out to [our support team](https://forum.aspose.com/c/slides/11).

```java
public void print() 
{
    // Define the printer name
    String printerName = "Adobe PDF";
    // Define the slides to print
    int[] slidesToPrint = { 2, 3, 4 };
    // Define the page orientation
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // Define the scale factor for image rendering
    final int scaleFactor = 4;

    // Set printing attributes
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // Configure rendering options for slides
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // To print Notes, use OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Load the presentation file
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // Get the printer job
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // Set the desired print service
        printerJob.setPrintService(findPrintService(printerName));

        // Get the default page format
        final PageFormat pageFormat = printerJob.defaultPage();

        // Define image dimensions based on orientation
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // Landscape orientation
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // Portrait orientation
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // Render slide images
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // Dispose of the presentation object
        pres.dispose();

        // Set the multi-image printable for the printer job
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // Print the slides with specified attributes
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// Method to find a PrintService by its name
static PrintService findPrintService(String printerName)
{
    PrintService[] printServices = PrintServiceLookup.lookupPrintServices(null, null);
    for (PrintService service : printServices) {
        if (service.getName().equals(printerName)) {
            return service;
        }
    }
    return null;
}

// Method to convert an array of IImage objects to a list of BufferedImage objects
static List<BufferedImage> convertToBufferedImage(IImage[] images) throws IOException {
    List<BufferedImage> result = new ArrayList<>();
    for (IImage img : images)
    {
        final ByteArrayOutputStream baos = new ByteArrayOutputStream();
        img.save(baos, ImageFormat.Png);
        img.dispose();

        result.add(ImageIO.read(new ByteArrayInputStream(baos.toByteArray())));
    }
    return result;
}

// A static class MultiImagePrintable that implements the Printable interface
static class MultiImagePrintable implements Printable
{
    private java.util.List<BufferedImage> images;

    public MultiImagePrintable(java.util.List<BufferedImage> images)
    {
        this.images = images;
    }

    @Override
    public int print(Graphics g, PageFormat pf, int pageIndex)
    {
        if (pageIndex >= images.size())
            return Printable.NO_SUCH_PAGE;

        Graphics2D g2d = (Graphics2D) g;
        g2d.translate(pf.getImageableX(), pf.getImageableY());

        Image image = images.get(pageIndex);

        double scaleX = pf.getImageableWidth() / image.getWidth(null);
        double scaleY = pf.getImageableHeight() / image.getHeight(null);
        double scale = Math.min(scaleX, scaleY);

        int width = (int) (image.getWidth(null) * scale);
        int height = (int) (image.getHeight(null) * scale);

        g.drawImage(image, 0, 0, width, height, null);

        return Printable.PAGE_EXISTS;
    }
}
```
