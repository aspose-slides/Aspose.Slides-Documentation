---
title: Εξαγωγή εικόνων από σχήματα παρουσίασης σε Java
linktitle: Εικόνα από σχήμα
type: docs
weight: 100
url: /el/java/extracting-images-from-presentation-shapes/
keywords:
- εξαγωγή εικόνας
- ανάκτηση εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εξαγωγή εικόνων από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Java - γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε διάφορους τύπους σχήματος: ως συνηθισμένα πλαίσια εικόνων, ως γεμίσματα εικόνας που εφαρμόζονται σε σχήματα, ως εικόνες προεπισκόπησης αντικειμένου OLE, ως μικρογραφίες πλαισίου βίντεο ή ήχου, ως εικόνες ζουμ ή ως εικόνες ενσωματωμένες μέσα σε σχήματα πίνακα, γραφήματος και SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων παρουσίασης, η οποία εκτίθεται μέσω των αντικειμένων [IImageCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagecollection/) και [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) .

Αν χρειάζεστε μόνο να εξάγετε κάθε ενσωματωμένο πόρο εικόνας σε μια παρουσίαση, επαναλάβετε μέσω `presentation.getImages()`. Αυτό το άρθρο εστιάζει σε διαφορετική εργασία: τη διαδρομή των σχημάτων για να βρεθεί πού χρησιμοποιούνται οι εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήσται πληροφορίες όπως ο αριθμός διαφάνειας, η θέση του σχήματος και ο τύπος προέλευσης (πλαίσιο εικόνας, γεμιστική εικόνα, προεπισκόπηση πολυμέσων, προεπισκόπηση OLE ή εικόνα ζουμ).

{{% alert title="Tip" color="primary" %}}
Χρησιμοποιήστε το [IPPImage.getBinaryData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getBinaryData--) για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε το [IPPImage.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getImage--) με το [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) όταν θέλετε να κανονικοποιήσετε την έξοδο σε συγκεκριμένο μορφότυπο όπως PNG.
{{% /alert %}}

## **Κοινές Βοηθητικές Μεθόδους**

Οι παρακάτω βοηθητικές μεθόδους κρατούν τα παραδείγματα σύντομα. `saveOriginalImage` γράφει τα αρχικά ενσωματωμένα bytes, επιλέγει ασφαλή επέκταση από τον τύπο MIME, και παραλείπει διπλότυπα δυαδικά δεδομένα εικόνας με βάση το SHA‑256 hash.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Set;

private static final class ShapeReference
{
    private final IShape shape;
    private final String namePart;

    private ShapeReference(IShape shape, String namePart)
    {
        this.shape = shape;
        this.namePart = namePart;
    }
}

private static boolean saveOriginalImage(
    IPPImage image,
    String outputDirectory,
    String fileNameBase,
    Set<String> savedImageHashes) throws Exception
{
    byte[] imageData = image.getBinaryData();
    String imageHash = getSha256Hash(imageData);
    if (!savedImageHashes.add(imageHash))
    {
        return false;
    }

    String extension = getExtensionFromContentType(image.getContentType());
    String fileName = fileNameBase + "." + extension;
    File outputFile = new File(outputDirectory, fileName);

    FileOutputStream outputStream = new FileOutputStream(outputFile);
    try
    {
        outputStream.write(imageData);
    }
    finally
    {
        outputStream.close();
    }

    return true;
}

private static void saveImageAsPng(IPPImage image, String outputDirectory, String fileNameBase)
{
    String fileName = fileNameBase + ".png";
    File outputFile = new File(outputDirectory, fileName);
    String outputPath = outputFile.getPath();

    IImage outputImage = image.getImage();
    try
    {
        outputImage.save(outputPath, ImageFormat.Png);
    }
    finally
    {
        if (outputImage != null)
        {
            outputImage.dispose();
        }
    }
}

private static IPPImage getPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.getFillType() != FillType.Picture)
    {
        return null;
    }

    return fillFormat.getPictureFillFormat().getPicture().getImage();
}

private static List<ShapeReference> enumerateShapes(
    IShapeCollection shapes,
    String prefix,
    boolean includeGroupedShapes)
{
    List<ShapeReference> shapeReferences = new ArrayList<ShapeReference>();
    int shapeCount = shapes.size();
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes.get_Item(shapeIndex);
        int displayIndex = shapeIndex + 1;
        String shapeNamePart = prefix + "_shape_" + displayIndex;
        ShapeReference shapeReference = new ShapeReference(shape, shapeNamePart);
        shapeReferences.add(shapeReference);

        if (includeGroupedShapes && shape instanceof IGroupShape)
        {
            IGroupShape groupShape = (IGroupShape)shape;
            IShapeCollection childShapes = groupShape.getShapes();
            List<ShapeReference> childReferences = enumerateShapes(
                childShapes,
                shapeNamePart,
                includeGroupedShapes);
            shapeReferences.addAll(childReferences);
        }
    }

    return shapeReferences;
}

private static String getSha256Hash(byte[] data) throws Exception
{
    MessageDigest messageDigest = MessageDigest.getInstance("SHA-256");
    byte[] hashBytes = messageDigest.digest(data);
    StringBuilder hashBuilder = new StringBuilder();
    for (byte hashByte : hashBytes)
    {
        String hexValue = Integer.toHexString(hashByte & 0xff);
        if (hexValue.length() == 1)
        {
            hashBuilder.append('0');
        }

        hashBuilder.append(hexValue);
    }

    return hashBuilder.toString();
}

private static String getExtensionFromContentType(String contentType)
{
    if (contentType == null || contentType.trim().length() == 0)
    {
        return "bin";
    }

    String mediaType = contentType.split(";")[0].trim().toLowerCase(Locale.ROOT);
    if ("image/jpeg".equals(mediaType))
    {
        return "jpg";
    }

    if ("image/png".equals(mediaType))
    {
        return "png";
    }

    if ("image/gif".equals(mediaType))
    {
        return "gif";
    }

    if ("image/bmp".equals(mediaType))
    {
        return "bmp";
    }

    if ("image/tiff".equals(mediaType))
    {
        return "tiff";
    }

    if ("image/x-emf".equals(mediaType) || "image/emf".equals(mediaType))
    {
        return "emf";
    }

    if ("image/x-wmf".equals(mediaType) || "image/wmf".equals(mediaType))
    {
        return "wmf";
    }

    if ("image/svg+xml".equals(mediaType))
    {
        return "svg";
    }

    if (mediaType.startsWith("image/"))
    {
        String extension = mediaType.substring("image/".length());
        return makeSafeFileNamePart(extension);
    }

    return "bin";
}

private static String makeSafeFileNamePart(String value)
{
    return value.replaceAll("[^A-Za-z0-9._-]", "_");
}
```

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Χρησιμοποιήστε αυτήν την προσέγγιση για εικόνες που εισάγονται ως ανεξάρτητα αντικείμενα. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) αποθηκεύει την εικόνα του στο `getPictureFormat().getPicture().getImage()`, το οποίο επιστρέφει ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) .

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "extracted-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα Με Γέμισμα Εικόνας**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμισμα. Ελέγξτε πρώτα τον τύπο γεμίσματος του σχήματος: εάν δεν είναι [FillType.Picture](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/), δεν υπάρχει εικόνα για εξαγωγή από αυτό το γέμισμα. Το παρακάτω παράδειγμα διαχειρίζεται αντικείμενα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω του [IPPImage.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getImage--) .

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "shape-fill-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveImageAsPng(image, outputDirectory, shapeReference.namePart);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Αντικειμένων OLE**

Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleobjectframe/) μπορεί να έχει μια εναλλακτική εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου σε μια διαφάνεια. Αυτή η εικόνα είναι διαθέσιμη μέσω του `getSubstitutePictureFormat().getPicture().getImage()`. Η εξαγωγή αυτής της εικόνας σας δίνει την εικόνα προεπισκόπησης, όχι τα ενσωματωμένα περιεχόμενα του πακέτου OLE.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "ole-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Βίντεο**

Ένα [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) μπορεί επίσης να αποθηκεύει μια εικόνα προεπισκόπησης στο `getPictureFormat().getPicture().getImage()`. Αυτή είναι η αφίσα ή μικρογραφία που εμφανίζεται στη διαφάνεια, όχι ένα καρέ αποκωδικοποιημένο από τη ροή βίντεο.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "video-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Ήχου**

Ένα [IAudioFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudioframe/) μπορεί να αποθηκεύει μια μικρογραφία στο `getPictureFormat().getPicture().getImage()`. Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "audio-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Αντικείμενα Zoom**

Τα σχήματα [IZoomFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/izoomframe/) και [ISectionZoomFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/isectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε το `getZoomImage()` από το πλαίσιο ζουμ.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IZoomFrame)
            {
                IZoomFrame zoomFrame = (IZoomFrame)shapeReference.shape;
                IPPImage image = zoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }

            if (shapeReference.shape instanceof ISectionZoomFrame)
            {
                ISectionZoomFrame sectionZoomFrame = (ISectionZoomFrame)shapeReference.shape;
                IPPImage image = sectionZoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_section_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Πλαίσια Σύνοψης Zoom**

Ένα [ISummaryZoomFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/isummaryzoomframe/) είναι επίσης σχήμα. Τα στοιχεία της ενότητας μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, που εκτίθενται μέσω της μεθόδου `getZoomImage()` του κάθε τμήματος σύνοψης zoom.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "summary-zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISummaryZoomFrame)
            {
                ISummaryZoomFrame summaryZoomFrame = (ISummaryZoomFrame)shapeReference.shape;
                int sectionCount = summaryZoomFrame.getSummaryZoomCollection().size();
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.getSummaryZoomCollection().get_Item(sectionIndex);
                    IPPImage image = section.getZoomImage();
                    if (image != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_summary_zoom_" + displayIndex;
                        saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα Πίνακα**

Ένα [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/itable/) είναι σχήμα. Οι εικόνες σε έναν πίνακα συνήθως αποθηκεύονται ως γεμίσματα εικόνας στα κελιά του πίνακα.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "table-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ITable)
            {
                ITable table = (ITable)shapeReference.shape;
                int rowCount = table.getRows().size();
                int columnCount = table.getColumns().size();
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table.get_Item(columnIndex, rowIndex);
                        IFillFormat fillFormat = cell.getCellFormat().getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayRow = rowIndex + 1;
                            int displayColumn = columnIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_cell_" + displayRow + "_" + displayColumn;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα Γραφήματος**

Ένα [IChart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από το γέμισμα εικόνας της περιοχής του γραφήματος.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "chart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IChart)
            {
                IChart chart = (IChart)shapeReference.shape;
                IFillFormat fillFormat = chart.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_chart_area";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [ISmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκεύονται σε γεμίσματα κουκκίδων κόμβου ή στους τύπους γεμίσματος των σχημάτων κόμβου.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "smartart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISmartArt)
            {
                ISmartArt smartArt = (ISmartArt)shapeReference.shape;
                int nodeCount = smartArt.getAllNodes().size();
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    ISmartArtNode node = smartArt.getAllNodes().get_Item(nodeIndex);
                    IFillFormat bulletFillFormat = node.getBulletFillFormat();
                    IPPImage bulletImage = getPictureFillImage(bulletFillFormat);
                    if (bulletImage != null)
                    {
                        int displayNode = nodeIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_bullet";
                        saveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.getShapes().size();
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        ISmartArtShape nodeShape = node.getShapes().get_Item(nodeShapeIndex);
                        IFillFormat fillFormat = nodeShape.getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayNode = nodeIndex + 1;
                            int displayNodeShape = nodeShapeIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_shape_" + displayNodeShape;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Συμπερίληψη Εικόνων Μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχημάτων. Η κοινή βοηθητική μέθοδος `enumerateShapes` διαθέτει επιλογή `includeGroupedShapes`. Ορίστε την σε `true` όταν θέλετε να εξετάσετε σχήματα μέσα σε αντικείμενα [IGroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/igroupshape/) . Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνας, σχήματα με γέμισμα εικόνας, προεπισκοπήσεις αντικειμένων OLE, μικρογραφίες πλαισίου βίντεο και μικρογραφίες πλαισίου ήχου. Για να συμπεριλάβετε και εικόνες πίνακα, γραφήματος, SmartArt και σύνοψης zoom, επαναχρησιμοποιήστε τη εξειδικευμένη λογική εξαγωγής από τα προηγούμενα τμήματα διατηρώντας την ίδια αναδρομική διάσχιση σχημάτων.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "all-shape-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                continue;
            }

            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Περιπτώσεις Άκρων και Πρακτικές Σημειώσεις**

- **Διπλότυπες εικόνες:** Πολλά σχήματα μπορεί να αναφέρονται στην ίδια εικόνα ή σε ξεχωριστές εικόνες με ίδιες bytes. Υπολογίστε το hash με [IPPImage.getBinaryData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getBinaryData--) πριν γράψετε αρχεία αν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.
- **Αρχικά δεδομένα vs. μετατρεπόμενη έξοδος:** Η αποθήκευση του [IPPImage.getBinaryData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getBinaryData--) διατηρεί τα ενσωματωμένα δεδομένα JPEG, PNG, GIF, SVG, EMF ή WMF. Η αποθήκευση του [IPPImage.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getImage--) μέσω του [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) είναι χρήσιμη όταν θέλετε μια σταθερή μορφή εξόδου.
- **Μη υποστηριζόμενοι τύποι γεμίσματος:** Σχήματα στερεού, διαβαθμισμένου, μοτίβου και χωρίς γέμισμα δεν περιέχουν γέμισμα εικόνας. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) πριν διαβάσετε το `getPictureFillFormat()`.
- **Ομαδοποιημένα σχήματα:** Η συλλογή σχημάτων διαφάνειας του ανώτερου επιπέδου δεν εκσυμπιέζει τις ομάδες. Εξετάστε αναδρομικά το [IGroupShape.getShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/igroupshape/#getShapes--) όταν το περιεχόμενο της ομάδας έχει σημασία.
- **Προεπισκοπήσεις αντικειμένου OLE:** Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleobjectframe/) μπορεί να εκθέσει μια εικόνα προεπισκόπησης μέσω `getSubstitutePictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.
- **Μικρογραφίες πλαισίου βίντεο:** Ένα [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) μπορεί να εκθέσει μια εικόνα προεπισκόπησης μέσω `getPictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή βίντεο.
- **Μικρογραφίες πλαισίου ήχου:** Ένα [IAudioFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudioframe/) μπορεί να εκθέσει ένα εικονίδιο ή μικρογραφία μέσω `getPictureFormat()`· δεν είναι τα ενσωματωμένα δεδομένα ήχου.
- **Εικόνες ζουμ:** Τα σχήματα zoom διαφάνειας, zoom τμήματος και zoom σύνοψης μπορεί να χρησιμοποιούν προσαρμοσμένα αντικείμενα [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) μέσω του `getZoomImage()`.
- **Ενσωματωμένα μοντέλα σχήματος:** Τα αντικείμενα πίνακα, γραφήματος και SmartArt υλοποιούν το [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/), αλλά οι εικόνες τους συχνά αποθηκεύονται σε ενσωματωμένα αντικείμενα μορφοποίησης κελιού πίνακα, στοιχείου γραφήματος ή κόμβου SmartArt.
- **Κομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) σας δίνει το αποθηκευμένο πόρο εικόνας. Δεν εφαρμόζει κοπή, διαφάνεια, αλλαγή χρώματος, περιστροφή ή άλλα οπτικά εφέ που έχουν εφαρμοστεί στο σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξαχθώ την αρχική εικόνα χωρίς κοπή, εφέ ή μετασχηματισμούς σχήματος;**

Ναι. Πρόσβαση στο αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) και εγγραφή του [IPPImage.getBinaryData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getBinaryData--) στο δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που είναι αποθηκευμένη στην παρουσίαση, όχι τον τρόπο με τον οποίο η εικόνα αποτυπώνεται στη διαφάνεια.

**Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;**

Ναι. Χρησιμοποιήστε το [IPPImage.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getImage--) για να λάβετε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/) και, στη συνέχεια, καλέστε το [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) με το [ImageFormat.Png](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/). Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρήσει τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

**Πώς μπορώ να αποφύγω την αποθήκευση της ίδιας εικόνας περισσότερες από μία φορές;**

Χρησιμοποιήστε ένα hash του [IPPImage.getBinaryData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/#getBinaryData--) και διατηρήστε τα hashes σε ένα σύνολο. Εάν μια νέα εικόνα έχει hash που ήδη υπάρχει, παραλείψτε την ή καταγράψτε άλλη αναφορά στο υπάρχον αρχείο εξόδου.

**Γιατί μερικά σχήματα δεν παράγουν εικόνα;**

Τα πλαίσια εικόνας, τα σχήματα με γέμισμα εικόνας, τα πλαίσια αντικειμένων OLE, τα πλαίσια πολυμέσων, τα πλαίσια ζουμ, οι πίνακες, τα γραφήματα και τα αντικείμενα SmartArt μπορούν να αναφέρονται σε εικόνες. Ορισμένοι τύποι σχημάτων εκθέτουν εικόνες μέσω ενσωματωμένων αντικειμένων μορφοποίησης, έτσι ένας απλός έλεγχος `getPictureFormat()` ή `getFillFormat()` του σχήματος δεν είναι πάντα επαρκής.

**Μπορώ να εξάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;**

Ναι. Χρησιμοποιήστε το [IVideoFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivideoframe/) και διαβάστε το `getPictureFormat().getPicture().getImage()`. Αυτό εξάγει την εικόνα αφίσας που είναι αποθηκευμένη μαζί με το πλαίσιο βίντεο, όχι ένα καρέ που δημιουργείται από το αρχείο βίντεο.

**Πώς μπορώ να καθορίσω ποια σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων παρουσίασης;**

Το Aspose.Slides δεν αποθηκεύει αντίστροφους συνδέσμους από το [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) προς τα σχήματα. Δημιουργήστε μια αντιστοίχηση κατά τη διάσχιση: όποτε βρείτε μια αναφορά εικόνας, καταγράψτε τον αριθμό διαφάνειας, τη διαδρομή σχήματος και το hash ή το αντικείμενο της συλλογής εικόνας.

**Μπορώ να εξάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συνημμένα έγγραφα;**

Μπορείτε να εξάγετε την προεπισκόπηση διαφάνειας του αντικειμένου OLE από το [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) . Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο. Για να εξάγετε εικόνες από το εσωτερικό του ενσωματωμένου αρχείου, εξάγετε τα δεδομένα OLE και επιθεωρήστε τα με εργαλεία για τον αντίστοιχο τύπο αρχείου.