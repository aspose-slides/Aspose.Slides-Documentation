---
title: Presentación de Impresión
type: docs
weight: 50
url: /es/androidjava/print-presentation/
keywords: "Imprimir PowerPoint, PPT, PPTX, Presentación de impresión, Java, Impresora, PrinterJob, PrintService"
description: "Imprimir presentación de PowerPoint en Java"
---

En Aspose.Slides para Android a través de Java 24.4, hemos introducido una [API Moderna](https://docs.aspose.com/slides/androidjava/modern-api/) que limita el soporte de impresión. Sin embargo, hemos adoptado un nuevo enfoque para ayudarle a superar esta limitación. En este artículo, le mostraremos cómo imprimir una presentación utilizando la API actual.

## Presentación de Impresión

Este fragmento de código Java demuestra cómo imprimir una presentación de PowerPoint utilizando Aspose.Slides para Android a través de la API de Java.

Para imprimir una presentación, siga estos pasos:

1. Cree una instancia de `PrintRequestAttributeSet` y especifique atributos de impresión como orientación y rango de páginas.
2. Cree una instancia de `RenderingOptions` y especifique opciones para el diseño de notas de las diapositivas.
3. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) especificando el archivo de presentación.
4. Cree una instancia de `PrinterJob` para especificar la impresora deseada.
5. Genere un arreglo de imágenes de diapositivas usando el método [getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) .
6. Establezca el arreglo `IImage` como imprimible para `PrinterJob`.
7. Llame al método `print` de la clase `PrinterJob`.

Asegúrese de reemplazar **"printerName"** con el nombre de su impresora específica y de configurar `PrintRequestAttributeSet` y `RenderingOptions` de acuerdo con sus requisitos de impresión.

{{% alert color="primary" %}} 
Tenga en cuenta que la impresión de notas debe requerir cambiar la orientación de la página a `OrientationRequested.PORTRAIT`.
{{% /alert %}} 

Si encuentra algún problema o necesita más ayuda, no dude en ponerse en contacto con [nuestro equipo de soporte](https://forum.aspose.com/c/slides/11).

```java
public void print() 
{
    // Definir el nombre de la impresora
    String printerName = "Adobe PDF";
    // Definir las diapositivas a imprimir
    int[] slidesToPrint = { 2, 3, 4 };
    // Definir la orientación de la página
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // Definir el factor de escala para la representación de imágenes
    final int scaleFactor = 4;

    // Establecer atributos de impresión
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // Configurar opciones de representación para las diapositivas
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // Para imprimir notas, usar OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Cargar el archivo de presentación
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // Obtener el trabajo de impresión
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // Establecer el servicio de impresión deseado
        printerJob.setPrintService(findPrintService(printerName));

        // Obtener el formato de página predeterminado
        final PageFormat pageFormat = printerJob.defaultPage();

        // Definir dimensiones de imagen según la orientación
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // Orientación horizontal
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // Orientación vertical
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // Representar imágenes de diapositivas
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // Disponer del objeto de presentación
        pres.dispose();

        // Establecer el imprimible de múltiples imágenes para el trabajo de impresión
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // Imprimir las diapositivas con los atributos especificados
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// Método para encontrar un PrintService por su nombre
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

// Método para convertir un arreglo de objetos IImage a una lista de objetos BufferedImage
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

// Una clase estática MultiImagePrintable que implementa la interfaz Printable
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