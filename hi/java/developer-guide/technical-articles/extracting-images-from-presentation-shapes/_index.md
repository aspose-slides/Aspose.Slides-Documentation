---
title: Java में प्रेजेंटेशन आकारों से छवियों को निकालें
linktitle: आकार से छवि
type: docs
weight: 100
url: /hi/java/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियाँ निकालें - तेज़, कोड‑मित्र समाधान।"
---
## **अवलोकन**

प्रेजेंटेशन में छवियाँ कई प्रकार के आकारों में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम के रूप में, आकारों पर लागू चित्र भराव के रूप में, OLE ऑब्जेक्ट प्रीव्यू छवियों के रूप में, वीडियो या ऑडियो फ्रेम थंबनेल के रूप में, ज़ूम छवियों के रूप में, या तालिका, चार्ट और SmartArt आकारों के भीतर नेस्टेड छवियों के रूप में। Aspose.Slides उन छवियों को प्रेजेंटेशन इमेज कलेक्शन में संग्रहीत करता है, जो [IImageCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) ऑब्जेक्ट्स के माध्यम से उपलब्ध हैं।

यदि आपको केवल प्रेजेंटेशन में एम्बेडेड प्रत्येक छवि संसाधन को एक्सपोर्ट करने की आवश्यकता है, तो `presentation.getImages()` के माध्यम से इटररेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स में जहाँ छवियों का उपयोग किया गया है, उन आकारों को ट्रैवर्स करना, ताकि सहेजी गई फ़ाइलों में स्लाइड संख्या, आकार स्थिति, और स्रोत प्रकार (चित्र फ्रेम, भराव छवि, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम छवि) जैसी उपयोगी जानकारी बनी रहे।

{{% alert title="Tip" color="primary" %}}
[IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getBinaryData--) का उपयोग करके मूल एन्कोडेड छवि डेटा और फ़ाइल प्रकार को संरक्षित रखें। जब आप आउटपुट को PNG जैसे विशिष्ट प्रारूप में सामान्यीकृत करना चाहते हैं, तो [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) के साथ उपयोग करें।
{{% /alert %}}

## **साझा सहायक विधियां**

नीचे दी गई सहायक विधियां उदाहरणों को छोटा रखती हैं। `saveOriginalImage` मूल एम्बेडेड बाइट्स लिखता है, MIME प्रकार से सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट छवि बाइनरी को छोड़ देता है।

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

## **चित्र फ्रेम से छवियों को निकालें**

यह विधि उन चित्रों के लिए उपयोग करें जो स्वतंत्र ऑब्जेक्ट के रूप में डाली गई हैं। एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) अपनी चित्र को `getPictureFormat().getPicture().getImage()` में रखता है, जो एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) ऑब्जेक्ट लौटाता है।

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

## **चित्र-भरे शैलियों से छवियों को निकालें**

आकार चित्र को अपने भराव के रूप में उपयोग कर सकते हैं। सबसे पहले आकार के भराव प्रकार की जांच करें: यदि वह [FillType.Picture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) नहीं है, तो उस भराव से कोई चित्र नहीं निकाला जा सकता। नीचे का उदाहरण [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) ऑब्जेक्ट्स को संभालता है और प्रत्येक छवि को PNG के रूप में [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getImage--) द्वारा सेव करता है।

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

## **OLE ऑब्जेक्ट फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleobjectframe/) के पास एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह चित्र `getSubstitutePictureFormat().getPicture().getImage()` के माध्यम से उपलब्ध है। इस चित्र को निकालने से आपको प्रीव्यू छवि मिलती है, न कि एम्बेडेड OLE पैकेज की सामग्री।

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

## **वीडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) भी `getPictureFormat().getPicture().getImage()` में प्रीव्यू छवि रख सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, न कि वीडियो स्ट्रीम से डिकोड किया गया फ्रेम।

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

## **ऑडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IAudioFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudioframe/) `getPictureFormat().getPicture().getImage()` में थंबनेल रख सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखायी गयी छवि है।

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

## **ज़ूम ऑब्जेक्ट्स से छवियों को निकालें**

[IZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/izoomframe/) और [ISectionZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `getZoomImage()` पढ़ें।

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

## **समरी ज़ूम फ्रेम से छवियों को निकालें**

एक [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isummaryzoomframe/) भी एक आकार है। इसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जिन्हें प्रत्येक समरी ज़ूम सेक्शन की `getZoomImage()` मेथड के माध्यम से एक्सपोज़ किया जाता है।

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

## **टेबल शैलियों से छवियों को निकालें**

एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itable/) एक आकार है। तालिका में छवियाँ आमतौर पर तालिका कोशिकाओं में चित्र भराव के रूप में संग्रहीत होती हैं।

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

## **चार्ट शैलियों से छवियों को निकालें**

एक [IChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/) एक आकार है। नीचे का उदाहरण चार्ट क्षेत्र के चित्र भराव से छवि निकालता है।

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

## **स्मार्टआर्ट शैलियों से छवियों को निकालें**

एक [ISmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट के आधार पर, छवियाँ नोड बुलेट भराव में या नोड आकारों के भराव फॉर्मैट में संग्रहीत हो सकती हैं।

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

## **समूहित शैलियों के अंदर छवियों को शामिल करें**

समूहित आकार अपनी स्वयं की आकार संग्रह रखते हैं। साझा `enumerateShapes` सहायक में `includeGroupedShapes` विकल्प होता है। जब आप [IGroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igroupshape/) ऑब्जेक्ट्स के भीतर आकारों का निरीक्षण करना चाहते हैं, तो इसे `true` सेट करें। नीचे का उदाहरण चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल और ऑडियो फ्रेम थंबनेल से छवियों को निकालता है। तालिका, चार्ट, SmartArt और समरी ज़ूम छवियों को भी शामिल करने के लिए, पिछले सेक्शन की विशेषीकृत एक्सट्रैक्शन लॉजिक को पुनः उपयोग करें और उसी पुनरावर्ती आकार ट्रैवर्सल को रखें।

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

## **किनारे के केस और व्यावहारिक नोट्स**

- **Duplicate images:** कई आकार एक ही छवि का संदर्भ दे सकते हैं या अलग-अलग छवियाँ जिनके बाइट समान हों। फ़ाइलें लिखने से पहले [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getBinaryData--) का हैश लें यदि आप प्रत्येक विशिष्ट छवि के लिए एक आउटपुट फ़ाइल चाहते हैं।
- **Original data vs. converted output:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getBinaryData--) को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF या WMF डेटा संरक्षित रहता है। [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) के साथ सहेजना उपयोगी है जब आप एकसमान आउटपुट फ़ॉर्मेट चाहते हैं।
- **Unsupported fill types:** सॉलिड, ग्रेडिएंट, पैटर्न और नो-फ़िल आकार में चित्र भराव नहीं होता। `getPictureFillFormat()` पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) की जाँच करें।
- **Grouped shapes:** शीर्ष‑स्तर स्लाइड आकार संग्रह समूहों को फ्लैट नहीं करता। जब समूहित सामग्री महत्वपूर्ण हो, तब [IGroupShape.getShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igroupshape/#getShapes--) को पुनरावर्ती रूप से निरीक्षण करें।
- **OLE object previews:** एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleobjectframe/) `getSubstitutePictureFormat()` के माध्यम से एक प्रीव्यू छवि उजागर कर सकता है, लेकिन यह केवल स्लाइड प्रीव्यू है। यह OLE ऑब्जेक्ट के भीतर एम्बेडेड फ़ाइल नहीं है।
- **Video frame thumbnails:** एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) `getPictureFormat()` के माध्यम से प्रीव्यू छवि उजागर कर सकता है, लेकिन यह केवल स्लाइड पर दिखाया गया पोस्टर है। यह वीडियो स्ट्रीम से निकाली गई फ्रेम नहीं है।
- **Audio frame thumbnails:** एक [IAudioFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudioframe/) `getPictureFormat()` के माध्यम से एक आइकन या थंबनेल उजागर कर सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **Zoom images:** स्लाइड ज़ूम, सेक्शन ज़ूम और समरी ज़ूम आकार कस्टम [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) ऑब्जेक्ट्स का उपयोग कर सकते हैं, जिन्हें `getZoomImage()` से प्राप्त किया जाता है।
- **Nested shape models:** टेबल, चार्ट और SmartArt ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) को इम्प्लीमेंट करते हैं, लेकिन उनकी छवियाँ अक्सर नेस्टेड टेबल सेल, चार्ट एलिमेंट या SmartArt नोड फॉर्मैटिंग ऑब्जेक्ट्स में संग्रहीत होती हैं।
- **Cropped or transformed pictures:** [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) तक पहुँचने से आपको संग्रहीत मूल छवि संसाधन मिलता है। यह आकार द्वारा लागू क्रॉपिंग, ट्रांसपैरेंसी, री‑कलरिंग, रोटेशन या अन्य विज़ुअल इफ़ेक्ट्स को रेंडर नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मूल छवि को बिना क्रॉपिंग, प्रभाव या आकार परिवर्तन के निकाल सकता हूँ?**

हाँ। [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) ऑब्जेक्ट तक पहुँचें और [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getBinaryData--) को डिस्क पर लिखें। यह प्रेजेंटेशन में संग्रहीत मूल एन्कोडेड छवि को संरक्षित करता है, न कि स्लाइड पर छवि के रेंडर किए जाने के तरीके को।

**क्या मैं प्रत्येक निकाली गई छवि को PNG के रूप में एक्सपोर्ट कर सकता हूँ?**

हाँ। [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getImage--) का उपयोग करके एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट प्राप्त करें, और फिर [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) को [ImageFormat.Png](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/) के साथ कॉल करें। यह आउटपुट को परिवर्तित करता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं कर सकता।

**मैं कैसे सुनिश्चित करूँ कि एक ही छवि को कई बार सहेजा न जाए?**

[IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/#getBinaryData--) का हैश बनाएँ और उसे एक सेट में रखें। यदि नई छवि का हैश पहले से मौजूद है, तो उसे स्किप करें या मौजूदा आउटपुट फ़ाइल का दूसरा संदर्भ रिकॉर्ड करें।

**कुछ आकारों से छवि क्यों नहीं निकाली जा सकती?**

चित्र फ्रेम, चित्र‑भरे आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, टेबल, चार्ट और SmartArt ऑब्जेक्ट्स छवियों का संदर्भ दे सकते हैं। कुछ आकार प्रकार नेस्टेड फॉर्मैटिंग ऑब्जेक्ट्स के माध्यम से छवियों को उजागर करते हैं, इसलिए केवल `getPictureFormat()` या आकार का `getFillFormat()` जाँचना हमेशा पर्याप्त नहीं हो सकता।

**क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?**

हाँ। [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) का उपयोग करके `getPictureFormat().getPicture().getImage()` पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर छवि को निकालता है, न कि वीडियो फ़ाइल से उत्पन्न कोई फ्रेम।

**मैं कैसे निर्धारित करूँ कि कौन से आकार प्रेजेंटेशन इमेज कलेक्शन की विशिष्ट छवि का उपयोग करते हैं?**

Aspose.Slides में [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) से आकारों की रिवर्स लिंक नहीं रखी जाती। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप कोई छवि संदर्भ पाएँ, स्लाइड संख्या, आकार पाथ और छवि के हैश या कलेक्शन आइटम को रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट्स के भीतर एम्बेडेड छवियों, जैसे जुड़ी हुई दस्तावेज़ों, को निकाल सकता हूँ?**

आप [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ स्वयं नहीं है। एम्बेडेड फ़ाइल के भीतर की छवियों को निकालने के लिए, OLE डेटा को एक्सट्रैक्ट करें और उस फ़ाइल प्रकार के लिए उपयुक्त टूल्स से जांचें।