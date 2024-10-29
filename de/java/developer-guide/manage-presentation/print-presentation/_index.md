---
title: Druckpräsentation
type: docs
weight: 50
url: /de/java/print-presentation/
keywords: "Druck PowerPoint, PPT, PPTX, Druckpräsentation, Java, Drucker, PrinterJob, PrintService"
description: "Drucken von PowerPoint-Präsentationen in Java"
---

In Aspose.Slides für Java 24.4 haben wir eine [Moderne API](https://docs.aspose.com/slides/java/modern-api/) eingeführt, die die Druckunterstützung einschränkt. Wir haben jedoch einen neuen Ansatz verfolgt, um Ihnen zu helfen, dieses Limit zu überwinden. In diesem Artikel zeigen wir Ihnen, wie Sie eine Präsentation mit der aktuellen API drucken.

## Druckpräsentation

Dieses Java-Code-Snippet demonstriert, wie Sie eine PowerPoint-Präsentation mit der Aspose.Slides für Java API drucken.

Befolgen Sie diese Schritte, um eine Präsentation zu drucken:

1. Erstellen Sie eine Instanz von `PrintRequestAttributeSet` und geben Sie Druckattribute wie Ausrichtung und Seitenbereich an.
2. Erstellen Sie eine Instanz von `RenderingOptions` und geben Sie Optionen für das Layout der Foliennotizen an.
3. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse, wobei Sie die Präsentationsdatei angeben.
4. Erstellen Sie eine Instanz von `PrinterJob`, um den gewünschten Drucker anzugeben.
5. Generieren Sie ein Array von Folienbildern mit der Methode [getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-).
6. Setzen Sie das `IImage` Array als druckbar für den `PrinterJob`.
7. Rufen Sie die Methode `print` der Klasse `PrinterJob` auf.

Stellen Sie sicher, dass Sie **"printerName"** durch den Namen Ihres spezifischen Druckers ersetzen und das `PrintRequestAttributeSet` sowie `RenderingOptions` gemäß Ihren Druckanforderungen konfigurieren.

{{% alert color="primary" %}} 
Bitte beachten Sie, dass das Drucken von Notizen die Änderung der Seitenausrichtung auf `OrientationRequested.PORTRAIT` erfordert.
{{% /alert %}} 

Wenn Sie auf Probleme stoßen oder weitere Unterstützung benötigen, wenden Sie sich bitte an [unser Support-Team](https://forum.aspose.com/c/slides/11).

```java
public void print() 
{
    // Definieren Sie den Druckernamen
    String printerName = "Adobe PDF";
    // Definieren Sie die Folien, die gedruckt werden sollen
    int[] slidesToPrint = { 2, 3, 4 };
    // Definieren Sie die Seitenrichtung
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // Definieren Sie den Skalierungsfaktor für die Bilddarstellung
    final int scaleFactor = 4;

    // Setzen Sie Druckattribute
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // Konfigurieren Sie die Renderingoptionen für Folien
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // Um Notizen zu drucken, verwenden Sie OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Laden Sie die Präsentationsdatei
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // Holen Sie sich den Druckauftrag
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // Setzen Sie den gewünschten Druckdienst
        printerJob.setPrintService(findPrintService(printerName));

        // Holen Sie sich das Standardseitenformat
        final PageFormat pageFormat = printerJob.defaultPage();

        // Definieren Sie die Bildabmessungen basierend auf der Ausrichtung
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // Landschaftsausrichtung
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // Hochformat
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // Rendern Sie Folienbilder
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // Entsorgen Sie das Präsentationsobjekt
        pres.dispose();

        // Setzen Sie das Multi-Image-Printable für den Druckauftrag
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // Drucken Sie die Folien mit den angegebenen Attributen
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// Methode zum Finden eines PrintService nach seinem Namen
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

// Methode zum Konvertieren eines Arrays von IImage-Objekten in eine Liste von BufferedImage-Objekten
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

// Eine statische Klasse MultiImagePrintable, die das Printable-Interface implementiert
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