---
title: Impression de Présentation
type: docs
weight: 50
url: /java/print-presentation/
keywords: "Impression PowerPoint, PPT, PPTX, Impression Présentation, Java, Imprimante, PrinterJob, PrintService"
description: "Imprimer une Présentation PowerPoint en Java"
---

Dans Aspose.Slides pour Java 24.4, nous avons introduit une [API Moderne](https://docs.aspose.com/slides/java/modern-api/) qui limite le support d'impression. Cependant, nous avons adopté une nouvelle approche pour vous aider à surmonter cette limitation. Dans cet article, nous allons vous montrer comment imprimer une présentation en utilisant l'API actuelle.

## Impression de Présentation

Ce fragment de code Java démontre comment imprimer une présentation PowerPoint en utilisant l'API Aspose.Slides pour Java.

Pour imprimer une présentation, suivez ces étapes :

1. Créez une instance de `PrintRequestAttributeSet` et spécifiez les attributs d'impression tels que l'orientation et la plage de pages.
2. Créez une instance de `RenderingOptions` et spécifiez les options pour la mise en page des notes de diapositive.
3. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) en spécifiant le fichier de présentation.
4. Créez une instance de `PrinterJob` pour spécifier l'imprimante désirée.
5. Générez un tableau d'images de diapositives en utilisant la méthode [getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-int---java.awt.Dimension-) .
6. Définissez le tableau `IImage` comme imprimable pour le `PrinterJob`.
7. Appelez la méthode `print` de la classe `PrinterJob`.

Assurez-vous de remplacer **"printerName"** par le nom de votre imprimante spécifique et de configurer le `PrintRequestAttributeSet` et `RenderingOptions` selon vos besoins en matière d'impression.

{{% alert color="primary" %}}
Veuillez noter que pour imprimer des notes, il est nécessaire de changer l'orientation de la page en `OrientationRequested.PORTRAIT`.
{{% /alert %}}

Si vous rencontrez des problèmes ou avez besoin de plus d'assistance, n'hésitez pas à contacter [notre équipe de support](https://forum.aspose.com/c/slides/11).

```java
public void print() 
{
    // Définir le nom de l'imprimante
    String printerName = "Adobe PDF";
    // Définir les diapositives à imprimer
    int[] slidesToPrint = { 2, 3, 4 };
    // Définir l'orientation de la page
    OrientationRequested pageOrientation = OrientationRequested.LANDSCAPE;

    // Définir le facteur d'échelle pour le rendu des images
    final int scaleFactor = 4;

    // Définir les attributs d'impression
    final PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(pageOrientation);

    // Configurer les options de rendu pour les diapositives
    final RenderingOptions renderingOptions = new RenderingOptions();
    final INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    // Pour imprimer des notes, utilisez OrientationRequested.PORTRAIT
    //slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    renderingOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Charger le fichier de présentation
    final Presentation pres = new Presentation("presentation.pptx");
    try {
        // Obtenir le job d'impression
        final PrinterJob printerJob = PrinterJob.getPrinterJob();
        // Définir le service d'impression désiré
        printerJob.setPrintService(findPrintService(printerName));

        // Obtenir le format de page par défaut
        final PageFormat pageFormat = printerJob.defaultPage();

        // Définir les dimensions de l'image en fonction de l'orientation
        IImage[] slideImages;
        Dimension imageSize;
        if (pres.getSlideSize().getOrientation() == SlideOrientation.Landscape &&
            slidesLayoutOptions.getNotesPosition() != NotesPositions.BottomFull) {
            // Orientation paysage
            imageSize = new Dimension(
                    (int) pageFormat.getImageableHeight() * scaleFactor,
                    (int) pageFormat.getImageableWidth() * scaleFactor);

        } else {
            // Orientation portrait
            imageSize = new Dimension(
                    (int) pageFormat.getImageableWidth() * scaleFactor,
                    (int) pageFormat.getImageableHeight() * scaleFactor);
        }
        // Rendre les images de diapositive
        slideImages = pres.getImages(renderingOptions, slidesToPrint, imageSize);
        // Libérer l'objet présentation
        pres.dispose();

        // Définir l'imprimable multi-image pour le job d'impression
        printerJob.setPrintable(new MultiImagePrintable(convertToBufferedImage(slideImages)), pageFormat);
        // Imprimer les diapositives avec les attributs spécifiés
        printerJob.print(attributes);
    } catch (PrinterException ex) {
        ex.printStackTrace();
    } catch (IOException ex) {
        ex.printStackTrace();
    }
}

// Méthode pour trouver un PrintService par son nom
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

// Méthode pour convertir un tableau d'objets IImage en une liste d'objets BufferedImage
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

// Une classe statique MultiImagePrintable qui implémente l'interface Printable
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