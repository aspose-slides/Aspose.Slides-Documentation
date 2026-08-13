---
title: Java में प्रेजेंटेशन आकारों से चित्र निकालें
linktitle: आकार से चित्र
type: docs
weight: 100
url: /hi/java/extracting-images-from-presentation-shapes/
keywords:
- चित्र निकालें
- चित्र प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रेजेंटेशन में आकारों से चित्र निकालें Aspose.Slides for Java के साथ - तेज, कोड‑मैत्रीपूर्ण समाधान।"
---
## **Overview**

प्रेजेंटेशन में छवियां कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम के रूप में, आकारों पर लागू चित्र फ़िल्स के रूप में, OLE ऑब्जेक्ट प्रीव्यू छवियों के रूप में, वीडियो या ऑडियो फ्रेम थंबनेल के रूप में, ज़ूम छवियों के रूप में, या तालिका, चार्ट और SmartArt आकारों के भीतर नेस्टेड छवियों के रूप में। Aspose.Slides इन छवियों को प्रेजेंटेशन इमेज कलेक्शन में संग्रहीत करता है, जिसे [IImageCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iimagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/) ऑब्जेक्ट्स के माध्यम से एक्सपोज़ किया गया है।

यदि आपको केवल प्रेजेंटेशन में एम्बेडेड प्रत्येक इमेज रिसोर्स को एक्सपोर्ट करना है, तो `presentation.getImages()` पर इटरेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स पर जहाँ छवियां उपयोग की गई हैं, उन आकारों को ट्रैवर्स करना, ताकि सेव की गई फ़ाइलें स्लाइड नंबर, आकार की स्थिति और स्रोत प्रकार (चित्र फ्रेम, फ़िल इमेज, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम इमेज) जैसे उपयोगी संदर्भ रख सकें।

{{% alert title="Tip" color="info" %}}
मूल एन्कोडेड इमेज डेटा और फ़ाइल प्रकार को संरक्षित करने के लिए [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getBinaryData--) का उपयोग करें। विशिष्ट फ़ॉर्मेट जैसे PNG में आउटपुट को सामान्यीकृत करने के लिए [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iimage/#save-java.lang.String-int-) के साथ उपयोग करें।
{{% /alert %}}

## **Shared Helper Methods**

नीचे दिए गए हेल्पर मेथड्स उदाहरणों को संक्षिप्त रखते हैं। `saveOriginalImage` मूल एम्बेडेड बाइट्स को लिखता है, MIME प्रकार से एक सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश के द्वारा डुप्लिकेट इमेज बाइनरी को छोड़ देता है।

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

जब चित्र स्वतंत्र ऑब्जेक्ट के रूप में सम्मिलित किए गए हों, इस दृष्टिकोण का उपयोग करें। एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ipictureframe/) अपनी चित्र को `getPictureFormat().getPicture().getImage()` में संग्रहीत करता है, जो एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/) ऑब्जेक्ट लौटाता है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

आकार चित्र को फ़िल के रूप में उपयोग कर सकते हैं। पहले आकार के फ़िल प्रकार की जाँच करें: यदि यह [FillType.Picture](https://reference.aspose.com/slides/hi/java/com.aspose.slides.filltype/) नहीं है, तो उस फ़िल से निकालने के लिए कोई चित्र नहीं है। नीचे का उदाहरण [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iautoshape/) ऑब्जेक्ट्स को संभालता है और प्रत्येक छवि को PNG के रूप में [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getImage--) के माध्यम से सेव करता है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;

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

एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ioleobjectframe/) में एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह चित्र `getSubstitutePictureFormat().getPicture().getImage()` के माध्यम से उपलब्ध है। इस चित्र को निकालने से आपको प्रीव्यू इमेज मिलती है, एम्बेडेड OLE पैकेज की सामग्री नहीं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ivideoframe/) भी `getPictureFormat().getPicture().getImage()` में प्रीव्यू चित्र संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, वीडियो स्ट्रीम से डिकोड किया गया फ्रेम नहीं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

एक [IAudioFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iaudioframe/) `getPictureFormat().getPicture().getImage()` में थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया चित्र है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

[IZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.izoomframe/) और [ISectionZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.isectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `getZoomImage()` पढ़ें।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

एक [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.isummaryzoomframe/) भी एक आकार है। इसकी सेक्शन आइटम्स कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक सारांश ज़ूम सेक्शन के `getZoomImage()` मेथड द्वारा एक्सपोज़ किया जाता है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides.itable/) एक आकार है। तालिका में छवियां आमतौर पर तालिका सेल में चित्र फ़िल के रूप में संग्रहीत होती हैं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

एक [IChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ichart/) एक आकार है। नीचे का उदाहरण चार्ट एरिया की चित्र फ़िल से छवि निकालता है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

एक [ISmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ismartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट के अनुसार, छवियां नोड बुलेट फ़िल्स या नोड आकारों के फ़िल फॉर्मेट्स में संग्रहीत हो सकती हैं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

ग्रुप्ड शेप्स अपनी स्वयं की आकार कलेक्शन रखती हैं। साझा `enumerateShapes` हेल्पर में `includeGroupedShapes` विकल्प है। इसे `true` सेट करें जब आप [IGroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides.igroupshape/) ऑब्जेक्ट्स के भीतर आकारों की जाँच करना चाहते हैं। नीचे का उदाहरण चित्र फ्रेम, चित्र-फ़िल्ड आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल और ऑडियो फ्रेम थंबनेल से छवियां निकालता है। तालिका, चार्ट, SmartArt और सारांश ज़ूम छवियों को भी शामिल करने के लिए, पिछले सेक्शनों से विशिष्ट एक्सट्रैक्शन लॉजिक को पुन: उपयोग करें जबकि वही रीकर्सिव आकार ट्रैवर्सल बनाए रखें।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

- **Duplicate images:** कई आकार एक ही छवि का संदर्भ दे सकते हैं या अलग-अलग छवियां हो सकती हैं जिनके बाइट्स समान हों। यदि आप प्रत्येक अद्वितीय छवि के लिए एक आउटपुट फ़ाइल चाहते हैं तो फ़ाइल लिखने से पहले [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getBinaryData--) का हैश लें।
- **Original data vs. converted output:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getBinaryData--) को सेव करने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF या WMF डेटा बना रहता है। [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iimage/#save-java.lang.String-int-) के साथ सेव करने से एकसमान आउटपुट फ़ॉर्मेट जैसे PNG प्राप्त होता है।
- **Unsupported fill types:** सॉलिड, ग्रेडिएंट, पैटर्न और नो-फ़िल आकारों में चित्र फ़िल नहीं होता। पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides.filltype/) की जाँच करें कि `getPictureFillFormat()` लागू है या नहीं।
- **Grouped shapes:** शीर्ष‑स्तरीय स्लाइड आकार कलेक्शन समूहों को फ्लैट नहीं करता। जब समूहित सामग्री महत्वपूर्ण हो तो [IGroupShape.getShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides.igroupshape/#getShapes--) को रीकर्सिवली.inspect करें।
- **OLE object previews:** एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ioleobjectframe/) `getSubstitutePictureFormat()` के माध्यम से प्रीव्यू चित्र प्रदान कर सकता है, लेकिन वह केवल स्लाइड प्रीव्यू है, एम्बेडेड फ़ाइल नहीं।
- **Video frame thumbnails:** एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ivideoframe/) `getPictureFormat()` के माध्यम से प्रीव्यू चित्र दे सकता है, लेकिन वह केवल स्लाइड पर दिखाया गया पोस्टर है, वीडियो स्ट्रीम से निकालना नहीं।
- **Audio frame thumbnails:** एक [IAudioFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iaudioframe/) `getPictureFormat()` के माध्यम से आइकन या थंबनेल प्रदान कर सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **Zoom images:** स्लाइड ज़ूम, सेक्शन ज़ूम और सारांश ज़ूम आकार कस्टम [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/) ऑब्जेक्ट्स को `getZoomImage()` के माध्यम से उपयोग कर सकते हैं।
- **Nested shape models:** तालिका, चार्ट और SmartArt ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ishape/) को इम्प्लीमेंट करते हैं, लेकिन उनकी छवियां अक्सर नेस्टेड तालिका सेल, चार्ट एलीमेंट या SmartArt नोड फॉर्मेटिंग ऑब्जेक्ट्स में संग्रहीत होती हैं।
- **Cropped or transformed pictures:** [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/) तक पहुंचने से आपको संग्रहीत इमेज रिसोर्स मिलता है। यह आकार द्वारा लागू क्रॉपिंग, ट्रांसपैरेंसी, री‑कलरिंग, रोटेशन या अन्य विज़ुअल इफ़ेक्ट को रेंडर नहीं करता।

## **FAQ**

### Can I extract the original image without cropping, effects, or shape transformations?

Yes. Access the [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/) object and write [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getBinaryData--) to disk. This preserves the original encoded image stored in the presentation, not the way the image is rendered on the slide.

### Can I export every extracted image as PNG?

Yes. Use [IPPImage.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getImage--) to get an [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iimage/) object, and then call [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides.iimage/#save-java.lang.String-int-) with [ImageFormat.Png](https://reference.aspose.com/slides/hi/java/com.aspose.slides.imageformat/). This converts the output and may not preserve the original file type or vector data.

### How do I avoid saving the same image more than once?

Use a hash of [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/#getBinaryData--) and keep the hashes in a set. If a new image has a hash that already exists, skip it or record another reference to the existing output file.

### Why do some shapes not produce an image?

Picture frames, picture-filled shapes, OLE object frames, media frames, zoom frames, tables, charts, and SmartArt objects can reference images. Some shape types expose images through nested formatting objects, so a simple `getPictureFormat()` or shape `getFillFormat()` check is not always enough.

### Can I extract the thumbnail shown for a video frame?

Yes. Use [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ivideoframe/) and read `getPictureFormat().getPicture().getImage()`. This extracts the poster image stored with the video frame, not a frame generated from the video file.

### How can I determine which shapes use a specific image from the presentation image collection?

Aspose.Slides does not store reverse links from [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ippimage/) to shapes. Build a mapping during traversal: whenever you find an image reference, record the slide number, shape path, and image hash or collection item.

### Can I extract images embedded inside OLE objects, such as attached documents?

You can extract the OLE object's slide preview from [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--). However, that preview is not the embedded document itself. To extract images from inside the embedded file, extract the OLE data and inspect it with tools for that file type.