---
title: Aspose.Slides for .NET 14.9.0 में सार्वजनिक API और प्रतिकूल असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- स्थांतरण
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
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट्स और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) कक्षाओं, विधियों, प्रॉपर्टीज़ आदि की सूची देता है, साथ ही Aspose.Slides for .NET 14.9.0 API में प्रस्तुत अन्य परिवर्तन।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **ISmartArtNodeCollection में ICollection और Generic IEnumerable इंटरफ़ेसेस की विरासत जोड़ी गई**
Aspose.Slides.SmartArt.SmartArtNodeCollection क्लास (और संबंधित इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtNodeCollection) जेनरिक इंटरफ़ेस IEnumerable<ISmartArtNode> और इंटरफ़ेस ICollection को विरासत में प्राप्त करते हैं।
#### **SmartArtLayoutType.Custom एन्नम मान जोड़ा गया**
Custom SmartArt लेआउट प्रकार एक कस्टम टेम्पलेट वाले आरेख को दर्शाता है। कस्टम आरेख केवल प्रस्तुति फ़ाइल से लोड किए जा सकते हैं और ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) मेथड के माध्यम से निर्मित नहीं किए जा सकते।
#### **SmartArtShape क्लास और ISmartArtShape इंटरफ़ेस जोड़ा गया**
Aspose.Slides.SmartArt.SmartArtShape क्लास (और उसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShape) SmartArt आरेख में व्यक्तिगत आकारों तक पहुँच प्रदान करता है। SmartArtShape का उपयोग FillFormat, LineFormat बदलने, Hyperlinks जोड़ने और अन्य कार्यों के लिए किया जा सकता है।

{{% alert color="primary" %}} 

**नोट**: SmartArtShape IShape प्रॉपर्टीज़ RawFrame, Frame, Rotation, X, Y, Width, Height को सपोर्ट नहीं करता और इन्हें एक्सेस करने पर System.NotSupportedException उत्पन्न करता है।

उपयोग का उदाहरण:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **SmartArtShapeCollection क्लास, ISmartArtShapeCollection इंटरफ़ेस और ISmartArtNode.Shapes प्रॉपर्टी जोड़ी गई**
Aspose.Slides.SmartArt.SmartArtShapeCollection क्लास (और उसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShapeCollection) SmartArt आरेख में व्यक्तिगत आकारों तक पहुँच प्रदान करता है। इस संग्रह में SmartArtNode से जुड़े आकार शामिल होते हैं। SmartArtNode.Shapes प्रॉपर्टी नोड से जुड़े सभी आकारों का संग्रह लौटाती है।

{{% alert color="primary" %}} 

**नोट**: SmartArtLayoutType के आधार पर एक SmartArtShape कई नोड्स के बीच साझा किया जा सकता है।

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **स्लाइड्स को पेज नंबर के साथ सहेजने के लिए विधियों को जोड़ा गया**
निम्नलिखित विधियों को जोड़ा गया है:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

These methods allow developers to save specified presentation slides to PDF, XPS, TIFF, HTML formats. The 'slides' array is used to specify page numbers, starting from 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //स्लाइड स्थितियों की सरणी
presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **PPImage, IPPImage में छवियों को बदलने की विधियों को जोड़ा गया**
नई विधियाँ जोड़ी गईं:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//पहला तरीका

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);
//दूसरा तरीका

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);
//तीसरा तरीका

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```