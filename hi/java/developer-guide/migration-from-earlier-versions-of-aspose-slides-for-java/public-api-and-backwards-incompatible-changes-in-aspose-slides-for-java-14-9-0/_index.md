---
title: "Aspose.Slides for Java 14.9.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन"
linktitle: "Aspose.Slides for Java 14.9.0"
type: docs
weight: 80
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- "स्थानांतरण"
- "परम्परागत कोड"
- "आधुनिक कोड"
- "परम्परागत दृष्टिकोण"
- "आधुनिक दृष्टिकोण"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और टूटने वाले परिवर्तन को देखें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधानों को सहजता से स्थानांतरण कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ Aspose.Slides for Java 14.9.0 API के साथ प्रस्तुत सभी [जोड़ा गया](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) क्लास, मेथड, प्रॉपर्टी आदि, साथ ही किसी भी नए प्रतिबंध और अन्य [परिवर्तन](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) को सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **छवि को PPImage, IPPImage से बदलने के लिए जोड़े गए मेथड**
नए मेथड जोड़े गए:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//पहला तरीका

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//दूसरा तरीका

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);
```
### **पृष्ठ संख्याएँ रखते हुए स्लाइड्स को सहेजने के लिए जोड़े गए मेथड**
निम्नलिखित मेथड जोड़े गए हैं:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

ये मेथड निर्दिष्ट प्रेजेंटेशन स्लाइड्स को PDF, XPS, TIFF, HTML फ़ॉर्मेट में सहेजने की अनुमति देते हैं। ‘slides’ ऐरे का उपयोग पृष्ठ संख्याएँ निर्दिष्ट करने के लिए किया जाता है, जो 1 से शुरू होती हैं।

``` java

 save(string fname, int[] slides, SaveFormat format);
```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //स्लाइड स्थितियों की एरे

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **SmartArtLayoutType.Custom Enum मान जोड़ा गया**
यह SmartArt लेआउट प्रकार कस्टम टेम्पलेट वाले डायग्राम को दर्शाता है। कस्टम डायग्राम केवल प्रेजेंटेशन फ़ाइल से लोड किए जा सकते हैं और मेथड ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) के द्वारा नहीं बनाए जा सकते।

### **SmartArtShape क्लास और ISmartArtShape इंटरफ़ेस जोड़ा गया**
Aspose.Slides.SmartArt.SmartArtShape क्लास (और इसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShape) SmartArt डायग्राम के भीतर व्यक्तिगत शेप्स तक पहुंच प्रदान करता है। SmartArtShape का उपयोग FillFormat, LineFormat बदलने, हाइपरलिंक्स जोड़ने आदि के लिए किया जा सकता है।

{{% alert color="primary" %}} 

SmartArtShape IShape प्रॉपर्टी RawFrame, Frame, Rotation, X, Y, Width, Height को समर्थन नहीं करता और इन्हें एक्सेस करने पर System.NotSupportedException फेंका जाता है।

{{% /alert %}} 

उपयोग का उदाहरण:

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **SmartArtShapeCollection क्लास, ISmartArtShapeCollection इंटरफ़ेस और ISmartArtNode.getShapes() मेथड जोड़े गए**
Aspose.Slides.SmartArt.SmartArtShapeCollection क्लास (और इसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShapeCollection) SmartArt डायग्राम के भीतर व्यक्तिगत शेप्स तक पहुंच प्रदान करता है। कलेक्शन में SmartArtNode से जुड़े शेप्स शामिल होते हैं। प्रॉपर्टी SmartArtNode.Shapes नोड से जुड़े सभी शेप्स का कलेक्शन लौटाती है।

{{% alert color="primary" %}} 

SmartArtLayoutType के आधार पर एक SmartArtShape कई नोड्स के बीच साझा किया जा सकता है।

{{% /alert %}} 

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```