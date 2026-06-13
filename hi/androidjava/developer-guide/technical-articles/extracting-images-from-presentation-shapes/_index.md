---
title: Android के लिए Java के माध्यम से प्रस्तुति आकारों से छवियों को निकालें
linktitle: आकार से छवि
type: docs
weight: 100
url: /hi/androidjava/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियों को Aspose.Slides for Android के माध्यम से Java में निकालें - तेज़, कोड-मैत्री समाधान।"
---
## **Overview**

प्रेजेंटेशन में छवियाँ कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम के रूप में, आकारों पर लागू चित्र भराव के रूप में, OLE ऑब्जेक्ट प्रीव्यू छवियों के रूप में, वीडियो या ऑडियो फ्रेम थंबनेल के रूप में, ज़ूम छवियों के रूप में, या तालिका, चार्ट और SmartArt आकारों के भीतर नेस्टेड छवियों के रूप में। Aspose.Slides इन छवियों को प्रेजेंटेशन इमेज कलेक्शन में संग्रहीत करता है, जिसे [IImageCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट के माध्यम से एक्सपोज़ किया गया है।

यदि आपको केवल प्रेजेंटेशन में एम्बेड की गई प्रत्येक छवि संसाधन को निर्यात करने की आवश्यकता है, तो `presentation.getImages()` पर इटररेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स में जहाँ छवियों का उपयोग किया गया है, उन आकारों को ट्रैवर्स करना, ताकि सहेजी गई फाइलें स्लाइड नंबर, आकार की स्थिति, और स्रोत प्रकार (चित्र फ्रेम, भराव चित्र, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम चित्र) जैसे उपयोगी संदर्भ रख सकें।

{{% alert title="Tip" color="primary" %}}

ओरिजिनल एन्कोडेड इमेज डेटा और फ़ाइल प्रकार को संरक्षित करने के लिए [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getBinaryData--) का उपयोग करें। यदि आप आउटपुट को PNG जैसे विशिष्ट फ़ॉर्मेट में नॉर्मलाइज़ करना चाहते हैं, तो [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) के साथ उपयोग करें।

{{% /alert %}}

## **Shared Helper Methods**

नीचे दिखाए गए हेल्पर मेथड्स उदाहरणों को संक्षिप्त रखते हैं। `saveOriginalImage` मूल एम्बेडेड बाइट्स को लिखता है, MIME टाइप से एक सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट इमेज बाइनरी को स्किप करता है।

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

## **Extract Images from Picture Frames**

स्टैंडअलोन ऑब्जेक्ट के रूप में डाली गई तस्वीरों के लिए इस दृष्टिकोण का उपयोग करें। एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) अपनी तस्वीर `getPictureFormat().getPicture().getImage()` में संग्रहीत करता है, जो एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट लौटाता है।

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

## **Extract Images from Picture-Filled Shapes**

आकार एक तस्वीर को उनके भराव के रूप में उपयोग कर सकते हैं। पहले आकार के भराव प्रकार को जांचें: यदि यह [FillType.Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) नहीं है, तो उस भराव से निकालने के लिये कोई तस्वीर नहीं है। नीचे दिया गया उदाहरण [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) ऑब्जेक्ट्स को संभालता है और प्रत्येक छवि को PNG के रूप में [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getImage--) के माध्यम से सहेजता है।

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

## **Extract Preview Images from OLE Object Frames**

एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleobjectframe/) के पास एक प्रतिस्थापन तस्वीर हो सकती है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह छवि `getSubstitutePictureFormat().getPicture().getImage()` के माध्यम से उपलब्ध है। इस तस्वीर को निकालना आपको प्रीव्यू इमेज देता है, एम्बेडेड OLE पैकेज की सामग्री नहीं।

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

## **Extract Preview Images from Video Frames**

एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) भी `getPictureFormat().getPicture().getImage()` में प्रीव्यू इमेज संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, वीडियो स्ट्रीम से डिकोड किया गया फ्रेम नहीं।

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

## **Extract Preview Images from Audio Frames**

एक [IAudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudioframe/) `getPictureFormat().getPicture().getImage()` में थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखायी जाने वाली छवि है।

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

## **Extract Images from Zoom Objects**

[IZoomFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/izoomframe/) और [ISectionZoomFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `getZoomImage()` पढ़ें।

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

## **Extract Images from Summary Zoom Frames**

एक [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isummaryzoomframe/) भी एक आकार है। इसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक सारांश ज़ूम सेक्शन की `getZoomImage()` मेथड द्वारा एक्सपोज़ किया जाता है।

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

## **Extract Images from Table Shapes**

एक [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itable/) एक आकार है। तालिका में छवियों को आमतौर पर तालिका कोशिकाओं में चित्र भराव के रूप में संग्रहीत किया जाता है।

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

## **Extract Images from Chart Shapes**

एक [IChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/) एक आकार है। नीचे दिया गया उदाहरण चार्ट क्षेत्र के चित्र भराव से एक छवि निकालता है।

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

## **Extract Images from SmartArt Shapes**

एक [ISmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट के आधार पर, छवियों को नोड बुलेट भराव या नोड आकारों के भराव फॉर्मेट में संग्रहीत किया जा सकता है।

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

## **Include Images Inside Grouped Shapes**

ग्रुप्ड शैप्स अपने स्वयं के आकार कलेक्शन को रखती हैं। साझा `enumerateShapes` हेल्पर में `includeGroupedShapes` विकल्प होता है। जब आप [IGroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igroupshape/) ऑब्जेक्ट्स के भीतर के आकारों का निरीक्षण करना चाहते हैं, तो इसे `true` सेट करें। नीचे दिया गया उदाहरण चित्र फ्रेम, चित्र‑भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल तथा ऑडियो फ्रेम थंबनेल से छवियों को निकालता है। तालिका, चार्ट, SmartArt और सारांश ज़ूम छवियों को भी शामिल करने के लिये, पिछले सेक्शनों से विशिष्ट एक्सट्रैक्शन लॉजिक को पुनः उपयोग करें जबकि वही रेकर्सिव आकार ट्रैवर्सल बनाये रखें।

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

## **Edge Cases and Practical Notes**

- **Duplicate images:** कई आकार एक ही छवि का संदर्भ दे सकते हैं या समान बाइट्स वाली अलग छवियां। यदि आप प्रत्येक अनोखी छवि के लिए एक आउटपुट फ़ाइल चाहते हैं, तो फाइल लिखने से पहले [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getBinaryData--) का हैश बनाएँ।
- **Original data vs. converted output:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getBinaryData--) को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) के साथ उपयोग करना उपयोगी है जब आप एकसमान आउटपुट फ़ॉर्मेट चाहते हैं।
- **Unsupported fill types:** ठोस, ग्रेडिएंट, पैटर्न और नो‑फ़िल आकारों में चित्र भराव नहीं होता। `getPictureFillFormat()` पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) की जाँच करें।
- **Grouped shapes:** टॉप‑लेवल स्लाइड आकार कलेक्शन समूहों को फ्लैट नहीं करता। जब समूहित कंटेंट मायने रखता हो, तो रेकर्सिवली [IGroupShape.getShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igroupshape/#getShapes--) को निरीक्षण करें।
- **OLE object previews:** एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleobjectframe/) प्रीव्यू छवि को `getSubstitutePictureFormat()` के माध्यम से एक्सपोज़ कर सकता है, लेकिन वह केवल स्लाइड प्रीव्यू है, एम्बेडेड फ़ाइल नहीं।
- **Video frame thumbnails:** एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) प्रीव्यू छवि को `getPictureFormat()` के माध्यम से एक्सपोज़ कर सकता है, लेकिन वह केवल स्लाइड पर दिखाया गया पोस्टर है, वीडियो स्ट्रीम से निकाला नहीं गया।
- **Audio frame thumbnails:** एक [IAudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudioframe/) आइकन या थंबनेल को `getPictureFormat()` के माध्यम से एक्सपोज़ कर सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **Zoom images:** स्लाइड ज़ूम, सेक्शन ज़ूम, और सारांश ज़ूम आकार कस्टम [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट्स को `getZoomImage()` के माध्यम से उपयोग कर सकते हैं।
- **Nested shape models:** तालिका, चार्ट और SmartArt ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) को लागू करते हैं, लेकिन उनकी छवियाँ अक्सर नेस्टेड तालिका सेल, चार्ट एलिमेंट, या SmartArt नोड फ़ॉर्मेटिंग ऑब्जेक्ट में संग्रहीत होती हैं।
- **Cropped or transformed pictures:** [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) तक पहुँचने से आपको स्टोर की गई मूल छवि मिलती है। यह आकार द्वारा लागू क्रॉपिंग, ट्रांसपेरेंसी, पुनः‑रंगना, घुमाव या अन्य दृश्य प्रभावों को नहीं दर्शाती।

## **FAQ**

**क्या मैं मूल छवि को बिना क्रॉप, इफ़ेक्ट या आकार ट्रांसफॉर्मेशन के एक्सट्रैक्ट कर सकता हूँ?**

हाँ। [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) ऑब्जेक्ट तक पहुँचें और [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getBinaryData--) को डिस्क पर लिखें। यह प्रेजेंटेशन में संग्रहीत मूल एन्कोडेड इमेज को संरक्षित करता है, ना कि स्लाइड पर चित्र कैसे रेंडर हुआ है।

**क्या मैं हर एक्सट्रैक्ट की गई छवि को PNG के रूप में निर्यात कर सकता हूँ?**

हाँ। [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getImage--) का उपयोग करके एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) ऑब्जेक्ट प्राप्त करें, फिर [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) को [ImageFormat.Png](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/) के साथ कॉल करें। यह आउटपुट को परिवर्तित करता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं करता।

**मैं एक ही छवि को बार‑बार सहेजने से कैसे बचूँ?**

[IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/#getBinaryData--) का हैश बनाकर उसे एक सेट में रखें। यदि नया छवि का हैश पहले से मौजूद है, तो उसे स्किप करें या मौजूदा आउटपुट फ़ाइल के लिए एक अतिरिक्त रेफ़रेंस रिकॉर्ड करें।

**कुछ आकारों से छवि क्यों नहीं बनती?**

चित्र फ्रेम, चित्र‑भरे आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, तालिका, चार्ट और SmartArt ऑब्जेक्ट छवियों का संदर्भ दे सकते हैं। कुछ आकार प्रकार नेस्टेड फ़ॉर्मेटिंग ऑब्जेक्ट्स के माध्यम से छवियों को एक्सपोज़ करते हैं, इसलिए केवल `getPictureFormat()` या आकार का `getFillFormat()` जांचना काफी नहीं हो सकता।

**क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को एक्सट्रैक्ट कर सकता हूँ?**

हाँ। [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) का उपयोग करें और `getPictureFormat().getPicture().getImage()` पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर इमेज को निकालता है, न कि वीडियो फ़ाइल से उत्पन्न किसी फ्रेम को।

**मैं कैसे निर्धारित करूँ कि प्रस्तुति इमेज कलेक्शन की कौन सी छवि किन आकारों द्वारा उपयोग की जा रही है?**

Aspose.Slides [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) से आकारों की रिवर्स लिंक नहीं रखता। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप किसी इमेज रेफ़रेंस को पाएँ, स्लाइड नंबर, आकार पाथ और इमेज हैश या कलेक्शन आइटम को रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट के भीतर एम्बेडेड छवियों, जैसे संलग्न दस्तावेज़, को एक्सट्रैक्ट कर सकता हूँ?**

आप [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) के माध्यम से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालाँकि, वह प्रीव्यू स्वयं एम्बेडेड दस्तावेज़ नहीं है। एम्बेडेड फ़ाइल के भीतर से छवियों को निकालने के लिये, OLE डेटा को एक्सट्रैक्ट करें और उस फ़ाइल प्रकार के उपयुक्त उपकरणों से उसका विश्लेषण करें।