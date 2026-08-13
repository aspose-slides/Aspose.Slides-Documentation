---
title: Aspose.Slides for .NET 14.9.0 में सार्वजनिक API और पिछले संस्करणों के साथ असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- स्थानांतरण
- पुराना कोड
- आधुनिक कोड
- पुराना दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट करें।"
---
{{% alert color="info" %}} 
यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) क्लास, मेथड, प्रॉपर्टी आदि, और Aspose.Slides for .NET 14.9.0 API द्वारा प्रस्तुत अन्य परिवर्तन सूचीबद्ध करता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **ISmartArtNodeCollection में ICollection और Generic IEnumerable इंटरफ़ेस से विरासत जोड़ दी गई**
क्लास Aspose.Slides.SmartArt.SmartArtNodeCollection (और संबंधित इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtNodeCollection) जेनरिक इंटरफ़ेस IEnumerable<ISmartArtNode> और इंटरफ़ेस ICollection से विरासत लेती है।
#### **SmartArtLayoutType.Custom Enum मान जोड़ा गया**
Custom SmartArt लेआउट प्रकार एक कस्टम टेम्प्लेट वाले डायग्राम को दर्शाता है। कस्टम डायग्राम केवल प्रस्तुति फ़ाइल से लोड किए जा सकते हैं और ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) मेथड के माध्यम से बनाए नहीं जा सकते।
#### **SmartArtShape क्लास और ISmartArtShape इंटरफ़ेस जोड़ा गया**
Aspose.Slides.SmartArt.SmartArtShape क्लास (और इसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShape) SmartArt डायग्राम में व्यक्तिगत शैप्स तक पहुँच प्रदान करता है। SmartArtShape का उपयोग FillFormat, LineFormat बदलने, हाइपरलिंक्स जोड़ने और अन्य कार्यों के लिए किया जा सकता है।
{{% alert color="info" %}} 
**Note**: SmartArtShape IShape प्रॉपर्टी RawFrame, Frame, Rotation, X, Y, Width, Height को समर्थन नहीं देता और इन्हें एक्सेस करने पर System.NotSupportedException फेंकता है।

उपयोग का उदाहरण:
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 
{{% /alert %}} 
#### **SmartArtShapeCollection क्लास, ISmartArtShapeCollection इंटरफ़ेस और ISmartArtNode.Shapes प्रॉपर्टी जोड़ी गई**
Aspose.Slides.SmartArt.SmartArtShapeCollection क्लास (और इसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShapeCollection) SmartArt डायग्राम में व्यक्तिगत शैप्स तक पहुँच प्रदान करता है। संग्रह में SmartArtNode से जुड़े शैप्स होते हैं। SmartArtNode.Shapes प्रॉपर्टी नोड से जुड़े सभी शैप्स के संग्रह को लौटाती है।
{{% alert color="info" %}} 
**Note**: SmartArtLayoutType के आधार पर एक SmartArtShape कई नोड्स के बीच साझा किया जा सकता है।
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 
{{% /alert %}} 
#### **पृष्ठ संख्या बनाए रखते हुए स्लाइड्स को सहेजने के लिए मेथड्स जोड़े गए**
निम्नलिखित मेथड्स जोड़े गए हैं:
- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);
ये मेथड्स डेवलपर्स को निर्दिष्ट प्रस्तुति स्लाइड्स को PDF, XPS, TIFF, HTML फॉर्मैट में सहेजने की अनुमति देते हैं। 'slides' एरे पृष्ठ संख्याएं निर्दिष्ट करने के लिए उपयोग किया जाता है, जो 1 से शुरू होती हैं।
Save(string fname, int[] slides, SaveFormat format);
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //स्लाइड स्थितियों की ऐरे

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **PPImage, IPPImage में इमेज बदलने के लिए मेथड्स जोड़े गए**
नए मेथड्स जोड़े गए:
- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //पहली विधि

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //दूसरी विधि

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //तीसरी विधि

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```