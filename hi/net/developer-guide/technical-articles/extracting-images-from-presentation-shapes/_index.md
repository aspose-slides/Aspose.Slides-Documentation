---
title: .NET में प्रेज़ेंटेशन आकारों से छवियां निकालें
linktitle: आकार से छवि
type: docs
weight: 90
url: /hi/net/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रेज़ेंटेशन में आकारों से छवियां निकालें - तेज, कोड-फ्रेंडली समाधान."
---
## **अवलोकन**

प्रेज़ेंटेशन में छवियां कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम के रूप में, आकारों पर लागू चित्र भराव के रूप में, OLE ऑब्जेक्ट प्रीव्यू छवियों के रूप में, वीडियो या ऑडियो फ्रेम थंबनेल के रूप में, ज़ूम छवियों के रूप में, या टेबल, चार्ट और SmartArt आकारों के भीतर नेस्टेड छवियों के रूप में। Aspose.Slides इन छवियों को प्रेज़ेंटेशन इमेज कलेक्शन में संग्रहीत करता है, जिसे [ImageCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट्स के माध्यम से एक्सपोज़ किया गया है।

यदि आपको केवल प्रेज़ेंटेशन में एम्बेड की गई प्रत्येक छवि संसाधन को एक्सपोर्ट करने की आवश्यकता है, तो `presentation.Images` के माध्यम से इटररेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स पर छवियों के उपयोग वाले आकारों को खोजने के लिए आकारों को ट्रैवर्स करना, ताकि सहेजी गई फ़ाइलें स्लाइड नंबर, आकार की स्थिति, और स्रोत प्रकार (चित्र फ्रेम, भराव छवि, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम छवि) जैसे उपयोगी संदर्भ को बनाए रख सकें।

{{% alert title="Tip" color="info" %}}
मूल एन्कोडेड छवि डेटा और फ़ाइल प्रकार को बनाए रखने के लिए [IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का उपयोग करें। विशिष्ट फ़ॉर्मेट जैसे PNG में आउटपुट को सामान्यीकृत करना चाहते हैं तो [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के साथ उपयोग करें।
{{% /alert %}}

## **साझा सहायक विधियां**

नीचे दी गई सहायक विधियां उदाहरणों को संक्षिप्त रखती हैं। `SaveOriginalImage` मूल एम्बेडेड बाइट्स को लिखता है, MIME प्रकार से सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट छवि बाइनरी को छोड़ देता है।

```c#
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

private static bool SaveOriginalImage(
    IPPImage image,
    string outputDirectory,
    string fileNameBase,
    ISet<string> savedImageHashes)
{
    byte[] imageData = image.BinaryData;
    string imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes.Add(imageHash))
    {
        return false;
    }

    string extension = GetExtensionFromContentType(image.ContentType);
    string fileName = $"{fileNameBase}.{extension}";
    string outputPath = Path.Combine(outputDirectory, fileName);
    File.WriteAllBytes(outputPath, imageData);
    return true;
}

private static void SaveImageAsPng(IPPImage image, string outputDirectory, string fileNameBase)
{
    string fileName = $"{fileNameBase}.png";
    string outputPath = Path.Combine(outputDirectory, fileName);

    using (IImage outputImage = image.Image)
    {
        outputImage.Save(outputPath, ImageFormat.Png);
    }
}

private static IPPImage GetPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.FillType != FillType.Picture)
    {
        return null;
    }

    return fillFormat.PictureFillFormat.Picture.Image;
}

private static IEnumerable<(IShape Shape, string NamePart)> EnumerateShapes(
    IShapeCollection shapes,
    string prefix,
    bool includeGroupedShapes)
{
    int shapeCount = shapes.Count;
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes[shapeIndex];
        int displayIndex = shapeIndex + 1;
        string shapeNamePart = $"{prefix}_shape_{displayIndex}";
        yield return (shape, shapeNamePart);

        if (includeGroupedShapes && shape is IGroupShape groupShape)
        {
            foreach ((IShape Shape, string NamePart) childShape in EnumerateShapes(
                groupShape.Shapes,
                shapeNamePart,
                includeGroupedShapes))
            {
                yield return childShape;
            }
        }
    }
}

private static string GetSha256Hash(byte[] data)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hash = sha256.ComputeHash(data);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}

private static string GetExtensionFromContentType(string contentType)
{
    if (string.IsNullOrWhiteSpace(contentType))
    {
        return "bin";
    }

    string mediaType = contentType.Split(';')[0].Trim().ToLowerInvariant();
    switch (mediaType)
    {
        case "image/jpeg":
            return "jpg";
        case "image/png":
            return "png";
        case "image/gif":
            return "gif";
        case "image/bbmp":
            return "bmp";
        case "image/tiff":
            return "tiff";
        case "image/x-emf":
        case "image/emf":
            return "emf";
        case "image/x-wmf":
        case "image/wmf":
            return "wmf";
        case "image/svg+xml":
            return "svg";
        default:
            if (mediaType.StartsWith("image/"))
            {
                string extension = mediaType.Substring("image/".Length);
                return MakeSafeFileNamePart(extension);
            }

            return "bin";
    }
}

private static string MakeSafeFileNamePart(string value)
{
    foreach (char invalidCharacter in Path.GetInvalidFileNameChars())
    {
        value = value.Replace(invalidCharacter, '_');
    }

    return value;
}
```

## **चित्र फ्रेम से छवियां निकालें**

स्वतंत्र ऑब्जेक्ट के रूप में डाली गई तस्वीरों के लिए इस विधि का उपयोग करें। एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) अपनी तस्वीर को `PictureFormat.Picture.Image` में संग्रहीत करता है, जो एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट लौटाता है।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "extracted-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }
}
```

## **चित्र-भरे आकारों से छवियां निकालें**

आकार एक चित्र को भराव के रूप में उपयोग कर सकते हैं। पहले आकार के भराव प्रकार की जाँच करें: अगर यह [FillType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) नहीं है, तो उस भराव से निकालने के लिये कोई चित्र नहीं है। नीचे का उदाहरण [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) ऑब्जेक्ट को संभालता है और प्रत्येक छवि को [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) के माध्यम से PNG के रूप में सहेजता है।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "shape-fill-images");
Directory.CreateDirectory(outputDirectory);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }
}
```

## **OLE ऑब्जेक्ट फ्रेम से प्रीव्यू छवियां निकालें**

एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) के पास एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह चित्र `SubstitutePictureFormat.Picture.Image` के माध्यम से उपलब्ध है। इस चित्र को निकालने पर आपको प्रीव्यू छवि मिलती है, एम्बेडेड OLE पैकेज की सामग्री नहीं।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "ole-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **वीडियो फ्रेम से प्रीव्यू छवियां निकालें**

एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) भी `PictureFormat.Picture.Image` में प्रीव्यू छवि संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, वीडियो स्ट्रीम से डिकोड किया गया फ्रेम नहीं।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "video-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **ऑडियो फ्रेम से प्रीव्यू छवियां निकालें**

एक [IAudioFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudioframe/) `PictureFormat.Picture.Image` में थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया चित्र है।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "audio-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **ज़ूम ऑब्जेक्ट्स से छवियां निकालें**

[IZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/izoomframe/) और [ISectionZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/isectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `ZoomImage` पढ़ें।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IZoomFrame zoomFrame && zoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_zoom";
                SaveOriginalImage(zoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            if (item.Shape is ISectionZoomFrame sectionZoomFrame && sectionZoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_section_zoom";
                SaveOriginalImage(sectionZoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

        }
    }
}
```

## **समरी ज़ूम फ्रेम से छवियां निकालें**

एक [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomframe/) भी एक आकार है। इसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक समरी ज़ूम सेक्शन की `ZoomImage` प्रॉपर्टी के माध्यम से एक्सपोज़ होती हैं।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "summary-zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is ISummaryZoomFrame summaryZoomFrame)
            {
                int sectionCount = summaryZoomFrame.SummaryZoomCollection.Count;
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.SummaryZoomCollection[sectionIndex];
                    if (section.ZoomImage != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        string fileNameBase = $"{item.NamePart}_summary_zoom_{displayIndex}";
                        SaveOriginalImage(section.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
```

## **टेबल आकारों से छवियां निकालें**

एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) एक आकार है। टेबल में छवियां आमतौर पर टेबल सेल में चित्र भराव के रूप में संग्रहीत होती हैं।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "table-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is ITable table)
            {
                int rowCount = table.Rows.Count;
                int columnCount = table.Columns.Count;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table[columnIndex, rowIndex];
                        IPPImage image = GetPictureFillImage(cell.CellFormat.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_cell_{rowIndex + 1}_{columnIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **चार्ट आकारों से छवियां निकालें**

एक [IChart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/) एक आकार है। नीचे का उदाहरण चार्ट क्षेत्र की चित्र भराव से एक छवि निकालता है।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "chart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.Charts.IChart chart)
            {
                IFillFormat fillFormat = chart.FillFormat;
                IPPImage image = GetPictureFillImage(fillFormat);
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_chart_area";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **SmartArt आकारों से छवियां निकालें**

एक [ISmartArt](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट पर निर्भर करते हुए, छवियां नोड बुलेट भराव में या नोड आकारों के भराव फॉर्मेट में संग्रहीत हो सकती हैं।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "smartart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                int nodeCount = smartArt.AllNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndex];
                    IPPImage bulletImage = GetPictureFillImage(node.BulletFillFormat);
                    if (bulletImage != null)
                    {
                        string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_bullet";
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.Shapes.Count;
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        var nodeShape = node.Shapes[nodeShapeIndex];
                        IPPImage image = GetPictureFillImage(nodeShape.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_shape_{nodeShapeIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **ग्रुपेड आकारों के भीतर छवियां शामिल करें**

ग्रुपेड आकार अपनी स्वयं की आकार कलेक्शन रखते हैं। साझा `EnumerateShapes` सहायक में `includeGroupedShapes` विकल्प है। जब आप [IGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/igroupshape/) ऑब्जेक्ट्स के भीतर के आकारों की जांच करना चाहते हैं तो इसे `true` सेट करें। नीचे का उदाहरण चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल, और ऑडियो फ्रेम थंबनेल से छवियां निकालता है। टेबल, चार्ट, SmartArt, और समरी ज़ूम छवियों को भी शामिल करने के लिये, पिछले अनुभागों की विशेषज्ञ निकासी लॉजिक को पुन: उपयोग करें जबकि समान पुनरावर्ती आकार ट्रैवर्सल बनाए रखें।

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "all-shape-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **एज केस और व्यावहारिक नोट्स**

- **डुप्लिकेट छवियां:** कई आकार एक ही छवि का संदर्भ दे सकते हैं या अलग-अलग छवियां जो समान बाइट्स रखती हैं। यदि आप प्रत्येक अद्वितीय छवि के लिए एक आउटपुट फ़ाइल चाहते हैं तो फ़ाइलें लिखने से पहले [IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का हैश करें।
- **मूल डेटा बनाम रूपांतरित आउटपुट:** [IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा बना रहता है। [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के माध्यम से [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को सहेजना उपयोगी है जब आप एकसमान आउटपुट फ़ॉर्मेट चाहते हैं।
- **असमर्थित भराव प्रकार:** सॉलिड, ग्रेडिएंट, पैटर्न, और नो-फ़िल आकारों में चित्र भराव नहीं होता। `PictureFillFormat` पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) जाँचें।
- **ग्रुपेड आकार:** शीर्ष-स्तर स्लाइड आकार कलेक्शन ग्रुप को फ्लैटन नहीं करता। जब ग्रुपेड सामग्री महत्वपूर्ण हो तब [IGroupShape.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides/igroupshape/) को पुनरावर्ती रूप से जांचें।
- **OLE ऑब्जेक्ट प्रीव्यू:** एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) `SubstitutePictureFormat` के माध्यम से प्रीव्यू छवि दिखा सकता है, लेकिन वह केवल स्लाइड प्रीव्यू है। यह OLE ऑब्जेक्ट के भीतर एम्बेडेड फ़ाइल नहीं है।
- **वीडियो फ्रेम थंबनेल:** एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) `PictureFormat` के माध्यम से प्रीव्यू छवि दिखा सकता है, लेकिन वह केवल स्लाइड पर दिखाए गए पोस्टर है। यह वीडियो स्ट्रीम से निकाली नहीं गई है।
- **ऑडियो फ्रेम थंबनेल:** एक [IAudioFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudioframe/) `PictureFormat` के माध्यम से आइकन या थंबनेल दिखा सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **ज़ूम छवियां:** स्लाइड ज़ूम, सेक्शन ज़ूम, और समरी ज़ूम आकार कस्टम [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट्स को `ZoomImage` के माध्यम से उपयोग कर सकते हैं।
- **नेस्टेड आकार मॉडल:** टेबल, चार्ट, और SmartArt ऑब्जेक्ट [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) को लागू करते हैं, लेकिन उनकी छवियां अक्सर नेस्टेड टेबल सेल, चार्ट तत्व, या SmartArt नोड फॉर्मेटिंग ऑब्जेक्ट में संग्रहीत होती हैं।
- **कटा या परिवर्तित चित्र:** [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को एक्सेस करने से आपको संग्रहीत छवि संसाधन मिलता है। यह आकार द्वारा लागू किए गए क्रॉपिंग, ट्रांसपरेंसी, रीकलरिंग, रोटेशन, या अन्य दृश्य प्रभावों को रेंडर नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं मूल छवि को बिना क्रॉपिंग, प्रभावों, या आकार परिवर्तन के निकाल सकता हूं?

हां। [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट को एक्सेस करें और [IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को डिस्क पर लिखें। यह प्रेज़ेंटेशन में संग्रहीत मूल एन्कोडेड छवि को बनाए रखता है, न कि स्लाइड पर छवि के रेंडर होने का तरीका।

### क्या मैं प्रत्येक निकाली गई छवि को PNG के रूप में एक्सपोर्ट कर सकता हूं?

हां। [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का उपयोग करके एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट प्राप्त करें, और फिर [ImageFormat.Png](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) के साथ [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) को कॉल करें। यह आउटपुट को परिवर्तित करता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को नहीं रख सकता।

### मैं एक ही छवि को कई बार सहेजने से कैसे बचूं?

[IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का हैश उपयोग करें और हैश को एक सेट में रखें। यदि नई छवि का हैश पहले से मौजूद है, तो उसे छोड़ें या मौजूदा आउटपुट फ़ाइल के लिए दूसरा रेफरेंस रिकॉर्ड करें।

### कुछ आकार छवि क्यों नहीं बनाते?

चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, टेबल, चार्ट, और SmartArt ऑब्जेक्ट छवियों का संदर्भ दे सकते हैं। कुछ आकार प्रकार नेस्टेड फॉर्मेटिंग ऑब्जेक्ट्स के माध्यम से छवियां एक्सपोज़ करते हैं, इसलिए केवल `PictureFormat` या आकार `FillFormat` जाँच हमेशा पर्याप्त नहीं होती।

### क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूं?

हां। [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) का उपयोग करें और `PictureFormat.Picture.Image` पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर छवि को निकालता है, वीडियो फ़ाइल से उत्पन्न फ्रेम नहीं।

### मैं कैसे निर्धारित करूँ कि कौन से आकार प्रेज़ेंटेशन इमेज कलेक्शन से विशेष छवि का उपयोग करते हैं?

Aspose.Slides [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) से आकारों तक रिवर्स लिंक नहीं रखता। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप किसी छवि रेफरेंस को पाएं, स्लाइड नंबर, आकार पाथ, और छवि हैश या कलेक्शन आइटम रिकॉर्ड करें।

### क्या मैं OLE ऑब्जेक्ट्स के भीतर एम्बेडेड छवियों, जैसे संलग्न दस्तावेज़ों को निकाल सकता हूं?

आप [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ स्वयं नहीं है। एम्बेडेड फ़ाइल के भीतर छवियां निकालने के लिए, OLE डेटा एक्सट्रैक्ट करें और उस फ़ाइल प्रकार के लिए उपयुक्त टूल्स से जांचें।