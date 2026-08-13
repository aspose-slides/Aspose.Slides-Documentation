---
title: Android में Java के माध्यम से प्रस्तुति शैप्स से छवियों को निकालें
linktitle: शैप से छवि
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
description: "PowerPoint और OpenDocument प्रस्तुतियों में शैप्स से छवियों को Aspose.Slides for Android के साथ Java के द्वारा निकालें - तेज, कोड-मैत्री समाधान।"
---
## **Overview**

प्रेजेंटेशन में छवियाँ कई प्रकार के शapest में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम, शैप्स पर लागू चित्र फ़िल, OLE ऑब्जेक्ट प्रीव्यू छवियाँ, वीडियो या ऑडियो फ़्रेम थंबनेल, ज़ूम इमेज, या टेबल, चार्ट, और SmartArt शैप्स के अंदर नेस्टेड छवियाँ। Aspose.Slides इन छवियों को प्रेजेंटेशन इमेज कलेक्शन में स्टोर करता है, जिसे [IImageCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iimagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/) ऑब्जेक्ट्स के माध्यम से एक्सपोज़ किया जाता है।

यदि आप केवल प्रेजेंटेशन में एम्बेडेड प्रत्येक इमेज रिसोर्स को एक्सपोर्ट करना चाहते हैं, तो `presentation.getImages()` पर इटरेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स में जहाँ छवियों का उपयोग किया गया है, ऐसे शैप्स को ट्रैवर्स करना, ताकि सहेजी गई फ़ाइलें स्लाइड नंबर, शैप पोजीशन, और स्रोत प्रकार (पिक्चर फ्रेम, फ़िल इमेज, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम इमेज) जैसे उपयोगी संदर्भ रख सकें।

{{% alert title="Tip" color="info" %}}
[IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getBinaryData--) का उपयोग करके मूल एन्कोडेड इमेज डेटा और फ़ाइल प्रकार को संरक्षित रखें। जब आप आउटपुट को किसी विशिष्ट फ़ॉर्मेट जैसे PNG में सामान्य बनाना चाहते हैं, तो [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iimage/#save-java.lang.String-int-) के साथ उपयोग करें।
{{% /alert %}}

## **Shared Helper Methods**

नीचे दिए गए सहायक मेथड्स उदाहरणों को छोटा रखते हैं। `saveOriginalImage` मूल एम्बेडेड बाइट्स लिखता है, MIME टाइप से एक सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट इमेज बायनरीज़ को स्किप करता है।

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

इस विधि का उपयोग उन चित्रों के लिए करें जो स्टैंडअलोन ऑब्जेक्ट्स के रूप में डाले गए हैं। एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ipictureframe/) अपनी तस्वीर को `getPictureFormat().getPicture().getImage()` में स्टोर करता है, जो एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/) ऑब्जेक्ट लौटाता है। ध्यान दें कि [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ivideoframe/) और [IAudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iaudioframe/) दोनों [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ipictureframe/) से डेराइव्ड हैं, इसलिए यह `instanceof` चेक मीडिया फ़्रेम्स को भी मिलाता है और उनके प्रीव्यू इमेज एक्सपोर्ट करता है; जब आप उन्हें अलग से हैंडल करना चाहते हैं तो पहले उन टाइप्स की जाँच करें, जैसा कि इस पेज के अंतिम उदाहरण में दिखाया गया है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

शैप्स एक चित्र को फ़िल के रूप में उपयोग कर सकते हैं। पहले शैप के फ़िल टाइप की जाँच करें: यदि यह [FillType.Picture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.filltype/) नहीं है, तो उस फ़िल से निकालने के लिए कोई चित्र नहीं है। नीचे दिया गया उदाहरण [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iautoshape/) ऑब्जेक्ट्स को हैंडल करता है और प्रत्येक इमेज को [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getImage--) के माध्यम से PNG के रूप में सहेजता है।

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

एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ioleobjectframe/) के पास एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह इमेज `getSubstitutePictureFormat().getPicture().getImage()` के माध्यम से उपलब्ध है। इस चित्र को एक्सट्रैक्ट करने से आपको प्रीव्यू इमेज मिलता है, एम्बेडेड OLE पैकेज सामग्री नहीं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ivideoframe/) भी `getPictureFormat().getPicture().getImage()` में एक प्रीव्यू इमेज स्टोर कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, वीडियो स्ट्रिम से डिकोड किया गया फ्रेम नहीं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

एक [IAudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iaudioframe/) `getPictureFormat().getPicture().getImage()` में थंबनेल स्टोर कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया इमेज है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

[IZoomFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.izoomframe/) और [ISectionZoomFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.isectionzoomframe/) शैप्स कस्टम इमेज का उपयोग कर सकते हैं। ज़ूम फ्रेम से `getZoomImage()` पढ़ें।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

एक [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.isummaryzoomframe/) भी एक शैप है। इसके सेक्शन आइटम्स कस्टम इमेज का उपयोग कर सकते हैं, जो प्रत्येक समरी ज़ूम सेक्शन की `getZoomImage()` मेथड द्वारा एक्सपोज़ होते हैं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

एक [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.itable/) एक शैप है। टेबल में छवियाँ सामान्यतः टेबल सेल्स में पिक्चर फ़िल के रूप में स्टोर की जाती हैं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

एक [IChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ichart/) एक शैप है। नीचे दिया गया उदाहरण चार्ट एरिया की पिक्चर फ़िल से इमेज एक्सट्रैक्ट करता है।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

एक [ISmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ismartart/) ऑब्जेक्ट एक शैप है। स्मार्टआर्ट लेआउट के आधार पर, इमेजेस नोड बुलेट फ़िल्स या नोड शैप फ़िल फॉर्मैट्स में स्टोर हो सकती हैं।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

ग्रुप्ड शैप्स अपने स्वयं के शैप कलेक्शन रखती हैं। शेयर किया गया `enumerateShapes` हेल्पर में `includeGroupedShapes` विकल्प होता है। इसे `true` सेट करें जब आप [IGroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.igroupshape/) ऑब्जेक्ट्स के अंदर शैप्स की जाँच करना चाहते हों। नीचे दिया गया उदाहरण पिक्चर फ्रेम, पिक्चर-फ़िल्ड शैप्स, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ़्रेम थंबनेल, और ऑडियो फ़्रेम थंबनेल से इमेजेस एक्सट्रैक्ट करता है। टेबल, चार्ट, SmartArt, और समरी ज़ूम इमेजेस को भी शामिल करने के लिए, पिछले सेक्शन्स से विशेषीकृत एक्सट्रैक्शन लॉजिक को पुनः उपयोग करें जबकि वही रीकर्सिव शैप ट्रैवर्सल रखें।

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

- **Duplicate images:** कई शैप्स एक ही इमेज को रेफ़र कर सकते हैं या अलग-अलग इमेजेज जिनमें समान बाइट्स होते हैं। यदि आप यूनिक इमेज के लिए एक आउटपुट फाइल चाहते हैं तो फ़ाइल लिखने से पहले [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getBinaryData--) को हैश करें।
- **Original data vs. converted output:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getBinaryData--) को सेव करने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getImage--) को [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iimage/#save-java.lang.String-int-) के साथ इस्तेमाल करने से जब आप एकसमान आउटपुट फ़ॉर्मेट चाहते हैं तो उपयोगी होता है।
- **Unsupported fill types:** सॉलिड, ग्रेडिएंट, पैटर्न, और नो-फ़िल शैप्स में पिक्चर फ़िल नहीं होता। पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.filltype/) की जाँच करें।
- **Grouped shapes:** टॉप-लेवल स्लाइड शैप कलेक्शन ग्रुप्स को फ्लैट नहीं करता। जब ग्रुप्ड कंटेंट मायने रखता हो, तो [IGroupShape.getShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.igroupshape/#getShapes--) को रीकर्सिवली इंस्पेक्ट करें।
- **OLE object previews:** एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ioleobjectframe/) `getSubstitutePictureFormat()` के माध्यम से प्रीव्यू इमेज प्रदान कर सकता है, लेकिन यह केवल स्लाइड प्रीव्यू है, एम्बेडेड फ़ाइल नहीं।
- **Video frame thumbnails:** एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ivideoframe/) `getPictureFormat()` के माध्यम से प्रीव्यू इमेज दे सकता है, लेकिन यह केवल स्लाइड पर दिखाया गया पोस्टर है, वीडियो स्ट्रिम से निकाला नहीं गया।
- **Audio frame thumbnails:** एक [IAudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iaudioframe/) `getPictureFormat()` के माध्यम से आइकन या थंबनेल दे सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **Zoom images:** स्लाइड ज़ूम, सेक्शन ज़ूम, और समरी ज़ूम शैप्स कस्टम [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/) ऑब्जेक्ट्स को `getZoomImage()` के माध्यम से उपयोग कर सकते हैं।
- **Nested shape models:** टेबल, चार्ट, और SmartArt ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ishape/) को इम्प्लीमेंट करते हैं, लेकिन उनकी इमेजेस अक्सर नेस्टेड टेबल सेल, चार्ट एलिमेंट, या SmartArt नोड फॉर्मैटिंग ऑब्जेक्ट्स में स्टोर होती हैं।
- **Cropped or transformed pictures:** [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/) को एक्सेस करने से आपको स्टोर किया गया इमेज रिसोर्स मिलता है। यह शैप द्वारा लागू क्रॉपिंग, ट्रांसपेरेंसी, रीकलरिंग, रोटेशन, या अन्य विज़ुअल इफ़ेक्ट्स को रेंडर नहीं करता।

## **FAQ**

### क्या मैं मूल इमेज को बिना क्रॉपिंग, इफ़ेक्ट्स या शैप ट्रांसफ़ॉर्मेशन के एक्सट्रैक्ट कर सकता हूँ?

हाँ। [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/) ऑब्जेक्ट को एक्सेस करें और [IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getBinaryData--) को डिस्क पर लिखें। इससे प्रेजेंटेशन में स्टोर की गई मूल एन्कोडेड इमेज संरक्षित रहती है, न कि स्लाइड पर रेंडर किए गए रूप की।

### क्या मैं सभी एक्सट्रैक्टेड इमेज को PNG के रूप में एक्सपोर्ट कर सकता हूँ?

हाँ। [IPPImage.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getImage--) का उपयोग करके एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iimage/) ऑब्जेक्ट प्राप्त करें, फिर [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.iimage/#save-java.lang.String-int-) को [ImageFormat.Png](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.imageformat/) के साथ कॉल करें। यह आउटपुट को परिवर्तित करता है और मूल फ़ाइल टाइप या वेक्टर डेटा को संरक्षित नहीं रखता।

### एक ही इमेज को कई बार सेव करने से कैसे बचूँ?

[IPPImage.getBinaryData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/#getBinaryData--) का हैश बनाकर उसे एक सेट में रखें। यदि नया इमेज का हैश पहले से मौजूद है, तो उसे स्किप करें या मौजूदा आउटपुट फ़ाइल की ओर एक और रेफ़रेंस रिकॉर्ड करें।

### कुछ शैप्स इमेज क्यों नहीं बनाते?

पिक्चर फ्रेम्स, पिक्चर-फ़िल्ड शैप्स, OLE ऑब्जेक्ट फ्रेम्स, मीडिया फ़्रेम्स, ज़ूम फ़्रेम्स, टेबल्स, चार्ट्स, और SmartArt ऑब्जेक्ट्स इमेजेज रेफ़र कर सकते हैं। कुछ शैप टाइप्स नेस्टेड फ़ॉर्मैटिंग ऑब्जेक्ट्स के माध्यम से इमेजेज एक्सपोज़ करते हैं, इसलिए केवल `getPictureFormat()` या शैप `getFillFormat()` की जाँच हमेशा पर्याप्त नहीं होती।

### क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को एक्सट्रैक्ट कर सकता हूँ?

हाँ। [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ivideoframe/#getPictureFormat--) का उपयोग करें और `getPictureFormat().getPicture().getImage()` पढ़ें। यह वीडियो फ्रेम के साथ स्टोर किया गया पोस्टर इमेज निकालता है, वीडियो फ़ाइल से जेनरेट किया गया फ्रेम नहीं।

### मैं कैसे निर्धारित करूँ कि कौनसे शैप्स प्रेजेंटेशन इमेज कलेक्शन की एक विशिष्ट इमेज का उपयोग करते हैं?

Aspose.Slides के पास [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ippimage/) से शैप्स की रिवर्स लिंक नहीं होती। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप कोई इमेज रेफ़रेंस पाएँ, स्लाइड नंबर, शैप पाथ, और इमेज हैश या कलेक्शन आइटम रिकॉर्ड करें।

### क्या मैं OLE ऑब्जेक्ट्स के अंदर एम्बेडेड इमेजेज, जैसे अटैच्ड डॉक्यूमेंट्स, को एक्सट्रैक्ट कर सकता हूँ?

आप [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू एक्सट्रैक्ट कर सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड डॉक्यूमेंट स्वयं नहीं है। एम्बेडेड फ़ाइल के अंदर की इमेजेज को निकालने के लिए OLE डेटा को एक्सट्रैक्ट करें और उस फ़ाइल टाइप के टूल्स से.inspect करें।