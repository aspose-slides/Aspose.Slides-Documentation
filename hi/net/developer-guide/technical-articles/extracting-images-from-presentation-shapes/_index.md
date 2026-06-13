---
title: .NET में प्रस्तुति आकारों से छवियाँ निकालें
linktitle: आकार से छवि
type: docs
weight: 90
url: /hi/net/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियों को निकालें - तेज, कोड‑फ़्रेंडली समाधान."
---
## **समीक्षा**

एक प्रस्तुति में छवियाँ कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम, आकारों पर लागू चित्र भराव, OLE ऑब्जेक्ट प्रीव्यू छवियाँ, वीडियो या ऑडियो फ़्रेम थंबनेल, ज़ूम छवियाँ, या टेबल, चार्ट और SmartArt आकारों के भीतर नेस्टेड छवियाँ। Aspose.Slides इन छवियों को प्रस्तुति इमेज कलेक्शन में संग्रहीत करता है, जिसे [ImageCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट्स के माध्यम से एक्सपोज़ किया जाता है।

यदि आपको केवल प्रस्तुति में एम्बेडेड प्रत्येक छवि संसाधन को एक्सपोर्ट करना है, तो `presentation.Images` के माध्यम से इटररेट करें। यह लेख एक अलग कार्य पर केन्द्रित है: स्लाइड्स पर छवियों के उपयोग को खोजने के लिये आकारों को ट्रैवर्स करना, ताकि सहेजी गई फ़ाइलें स्लाइड नंबर, आकार स्थिति और स्रोत प्रकार (चित्र फ्रेम, भराव छवि, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम छवि) जैसे उपयोगी संदर्भ रख सकें।

{{% alert title="Tip" color="primary" %}}
[IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का उपयोग मूल एन्कोडेड छवि डेटा और फ़ाइल प्रकार को संरक्षित रखने के लिए करें। जब आप आउटपुट को PNG जैसे विशिष्ट फॉर्मेट में सामान्यीकृत करना चाहते हैं, तो [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के साथ उपयोग करें।
{{% /alert %}}

## **साझा सहायक विधियाँ**

नीचे दिए गए सहायक विधियाँ उदाहरणों को संक्षिप्त रखती हैं। `SaveOriginalImage` मूल एम्बेडेड बाइट्स लिखती है, MIME प्रकार से एक सुरक्षित एक्सटेंशन चुनती है, और SHA-256 हैश द्वारा डुप्लिकेट इमेज बाइनरी को स्किप करती है।

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
        case "image/bmp":
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

## **चित्र फ्रेम से छवियों को निकालें**

इस विधि का उपयोग उन चित्रों के लिये करें जो स्वतंत्र ऑब्जेक्ट के रूप में डाले गए हों। एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) अपनी चित्र को `PictureFormat.Picture.Image` में संग्रहीत करता है, जो एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट लौटाता है।

```c#
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

## **चित्र-भरे आकारों से छवियों को निकालें**

आकार चित्र को अपने भराव के रूप में उपयोग कर सकते हैं। पहले आकार के भराव प्रकार की जाँच करें: यदि यह [FillType.Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) नहीं है, तो उस भराव से निकालने के लिये कोई चित्र नहीं है। नीचे दिया गया उदाहरण [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) ऑब्जेक्ट्स को संभालता है और प्रत्येक छवि को [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) के माध्यम से PNG के रूप में सहेजता है।

```c#
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

## **OLE ऑब्जेक्ट फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) का एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह चित्र `SubstitutePictureFormat.Picture.Image` के माध्यम से उपलब्ध है। इस चित्र को निकालने से आपको प्रीव्यू छवि मिलती है, न कि एम्बेडेड OLE पैकेज की सामग्री।

```c#
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

## **वीडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) भी `PictureFormat.Picture.Image` में एक प्रीव्यू छवि संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, न कि वीडियो स्ट्रीम से डिकोड किया गया फ़्रेम।

```c#
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

## **ऑडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IAudioFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudioframe/) `PictureFormat.Picture.Image` में एक थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया चित्र है।

```c#
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

## **ज़ूम ऑब्जेक्ट्स से छवियों को निकालें**

[IZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/izoomframe/) और [ISectionZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/isectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `ZoomImage` पढ़ें।

```c#
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

## **सारांश ज़ूम फ्रेम से छवियों को निकालें**

एक [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomframe/) भी एक आकार है। इसकी सेक्शन आइटम्स कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक सारांश ज़ूम सेक्शन की `ZoomImage` प्रॉपर्टी के माध्यम से उजागर होती हैं।

```c#
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

## **टेबल आकारों से छवियों को निकालें**

एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) एक आकार है। टेबल में छवियाँ सामान्यतः टेबल सेल्स में चित्र भराव के रूप में संग्रहीत होती हैं।

```c#
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

## **चार्ट आकारों से छवियों को निकालें**

एक [IChart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/) एक आकार है। नीचे दिया गया उदाहरण चार्ट एरिया के चित्र भराव से छवि निकालता है।

```c#
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

## **SmartArt आकारों से छवियों को निकालें**

एक [ISmartArt](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट के आधार पर, छवियाँ नोड बुलेट भराव में या नोड आकारों के भराव फ़ॉर्मैट में संग्रहीत हो सकती हैं।

```c#
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

## **समूहित आकारों में छवियों को शामिल करें**

समूहित आकार अपनी स्वयं की आकार कलेक्शन रखते हैं। साझा `EnumerateShapes` सहायक में `includeGroupedShapes` विकल्प है। जब आप [IGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/igroupshape/) ऑब्जेक्ट्स के भीतर आकारों की जाँच करना चाहते हैं, तो इसे `true` सेट करें। नीचे दिया गया उदाहरण चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ़्रेम थंबनेल, और ऑडियो फ़्रेम थंबनेल से छवियों को निकालता है। टेबल, चार्ट, SmartArt और सारांश ज़ूम छवियों को भी शामिल करने के लिये, पिछले अनुभागों से विशिष्ट निष्कर्षण लॉजिक को पुन: उपयोग करें और समान पुनरावर्ती आकार ट्रैवर्सल बनाए रखें।

```c#
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

## **विशेष मामलों और व्यावहारिक नोट्स**

- **डुप्लिकेट छवियाँ:** कई आकार एक ही छवि का संदर्भ दे सकते हैं या समान बाइट्स वाली अलग छवियाँ हो सकती हैं। यदि आप प्रत्येक अद्वितीय छवि के लिये एक आउटपुट फ़ाइल चाहते हैं तो फ़ाइल लिखने से पहले [IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का हैश बनाएं।
- **मूल डेटा बनाम परिवर्तित आउटपुट:** [IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के साथ सहेजने से एकसमान आउटपुट फॉर्मेट (जैसे PNG) बनाना उपयोगी है।
- **असमर्थित भराव प्रकार:** ठोस, ग्रेडिएंट, पैटर्न, और नो-फ़िल आकारों में चित्र भराव नहीं होता। पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) की जाँच करें कि `PictureFillFormat` मौजूद है या नहीं।
- **समूहित आकार:** शीर्ष‑स्तर स्लाइड आकार कलेक्शन समूहों को फ्लैट नहीं करता। जब समूहित सामग्री महत्वपूर्ण हो तो [IGroupShape.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides/igroupshape/) को पुनरावर्ती रूप से जाँचें।
- **OLE ऑब्जेक्ट प्रीव्यू:** एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) `SubstitutePictureFormat` के माध्यम से प्रीव्यू चित्र उजागर कर सकता है, लेकिन वह केवल स्लाइड प्रीव्यू है, ओब्जेक्ट के भीतर एम्बेडेड फ़ाइल नहीं।
- **वीडियो फ़्रेम थंबनेल:** एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) `PictureFormat` के माध्यम से प्रीव्यू चित्र उजागर कर सकता है, लेकिन वह केवल स्लाइड पर प्रदर्शित पोस्टर है, वीडियो स्ट्रीम से निकाली गई नहीं।
- **ऑडियो फ़्रेम थंबनेल:** एक [IAudioFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudioframe/) `PictureFormat` के माध्यम से आइकन या थंबनेल उजागर कर सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **ज़ूम छवियाँ:** स्लाइड ज़ूम, सेक्शन ज़ूम और सारांश ज़ूम आकार कस्टम [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट्स को `ZoomImage` द्वारा उपयोग कर सकते हैं।
- **नेस्टेड आकार मॉडल:** टेबल, चार्ट और SmartArt ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) को लागू करते हैं, लेकिन उनकी छवियां अक्सर नेस्टेड टेबल सेल, चार्ट एलेमेंट या SmartArt नोड फ़ॉर्मैटिंग ऑब्जेक्ट में संग्रहीत होती हैं।
- **कट या रूपांतरित चित्र:** [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को एक्सेस करने से आपको संग्रहीत छवि संसाधन मिलता है। यह आकार द्वारा लागू क्रॉपिंग, ट्रांसपरेंसी, री‑कलरिंग, घूमाव या अन्य दृश्य प्रभावों को रेंडर नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मूल छवि को बिना क्रॉप, प्रभाव या आकार रूपांतरण के निकाल सकता हूँ?**

हाँ। [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) ऑब्जेक्ट तक पहुंचें और [IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को डिस्क पर लिखें। इससे प्रस्तुति में संग्रहीत मूल एन्कोडेड छवि संरक्षित रहती है, न कि स्लाइड पर छवि के रेंडर होने का तरीका।

**क्या मैं निकाली गई प्रत्येक छवि को PNG के रूप में एक्सपोर्ट कर सकता हूँ?**

हाँ। [IPPImage.Image](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का उपयोग करके एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट प्राप्त करें, फिर [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) को [ImageFormat.Png](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) के साथ कॉल करें। यह आउटपुट को कनवर्ट करता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं रखता।

**मैं एक ही छवि को कई बार सहेजने से कैसे बचूं?**

[IPPImage.BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) का हैश बनायें और उसे एक सेट में रखें। यदि नई छवि का हैश पहले से मौजूद है, तो उसे स्किप करें या मौजूदा आउटपुट फ़ाइल के लिए एक अन्य संदर्भ दर्ज करें।

**कुछ आकार छवि क्यों नहीं उत्पन्न करते?**

चित्र फ्रेम, चित्र‑भरे आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, टेबल, चार्ट और SmartArt ऑब्जेक्ट्स छवियों का संदर्भ दे सकते हैं। कुछ आकार प्रकार नेस्टेड फ़ॉर्मैटिंग ऑब्जेक्ट्स के माध्यम से छवियों को उजागर करते हैं, इसलिए केवल `PictureFormat` या आकार के `FillFormat` की जाँच हमेशा पर्याप्त नहीं होती।

**क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?**

हाँ। [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) का उपयोग करके `PictureFormat.Picture.Image` पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर चित्र निकालता है, न कि वीडियो फ़ाइल से उत्पन्न फ़्रेम।

**मैं कैसे निर्धारित करूँ कि कौन से आकार प्रस्तुति इमेज कलेक्शन की विशिष्ट छवि का उपयोग करते हैं?**

Aspose.Slides के पास [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) से आकारों की रिवर्स लिंक नहीं होती। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप एक छवि संदर्भ पाते हैं, स्लाइड नंबर, आकार पाथ और छवि हैश या कलेक्शन आइटम को रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट्स के भीतर एम्बेडेड छवियों, जैसे संलग्न दस्तावेज़, को निकाल सकता हूँ?**

आप [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ स्वयं नहीं है। एम्बेडेड फ़ाइल के भीतर से छवियों को निकालने के लिये, OLE डेटा को एक्सट्रैक्ट करें और उसके फ़ाइल प्रकार के लिए उपयुक्त टूल्स से जांचें।