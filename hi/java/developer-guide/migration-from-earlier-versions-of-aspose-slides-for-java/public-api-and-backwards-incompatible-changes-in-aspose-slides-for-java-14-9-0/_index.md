---
title: Aspose.Slides for Java 14.9.0 में सार्वजनिक API और असंगत बदलाव
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- माइग्रेशन
- लीगेसी कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सार्वजनिक API अपडेट और तोड़ने वाले बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) क्लासेस, मेथड्स, प्रॉपर्टीज़ आदि, साथ ही किसी भी नए प्रतिबंधों और अन्य [परिवर्तन](/slides/hi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) को सूचीबद्ध करता है जो Aspose.Slides for Java 14.9.0 API के साथ प्रस्तुत किए गए हैं।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
### **छवि को PPImage, IPPImage में बदलने के लिए जोड़े गए मेथड्स**
नए मेथड जोड़े गए:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // पहला तरीका
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // दूसरा तरीका
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **पृष्ठ संख्याएँ रखते हुए स्लाइड्स सहेजने के लिए जोड़े गए मेथड्स**
निम्नलिखित मेथड जोड़े गए हैं:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

इन मेथड्स का प्रयोग निर्दिष्ट प्रेजेंटेशन स्लाइड्स को PDF, XPS, TIFF, HTML फॉर्मेट में सहेजने के लिए किया जा सकता है। ‘slides’ एरे का उपयोग पृष्ठ संख्याएँ निर्दिष्ट करने के लिए किया जाता है, जो 1 से शुरू होती हैं।

``` java
// IPresentation में जोड़े गए ओवरलोड्स (SaveFormat मान जावा में int स्थिरांक हैं):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // स्लाइड स्थितियों की एरे

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **SmartArtLayoutType.Custom Enum मान जोड़ा गया**
यह SmartArt लेआउट प्रकार कस्टम टेम्पलेट वाले डायग्राम को दर्शाता है। कस्टम डायग्राम केवल प्रेजेंटेशन फ़ाइल से लोड किए जा सकते हैं और ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) मेथड के माध्यम से नहीं बनाए जा सकते।

### **SmartArtShape क्लास और ISmartArtShape इंटरफ़ेस जोड़ा गया**
Aspose.Slides.SmartArt.SmartArtShape क्लास (और इसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShape) SmartArt डायग्राम के भीतर व्यक्तिगत शैप्स तक पहुंच प्रदान करता है। SmartArtShape का उपयोग FillFormat, LineFormat बदलने, हाइपरलिंक जोड़ने आदि के लिए किया जा सकता है।

{{% alert color="info" %}} 

SmartArtShape, IShape प्रॉपर्टीज़ RawFrame, Frame, Rotation, X, Y, Width, Height का समर्थन नहीं करता और इन्हें एक्सेस करने का प्रयास करने पर System.NotSupportedException फेंकता है।

{{% /alert %}} 

उपयोग का उदाहरण:

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **SmartArtShapeCollection क्लास, ISmartArtShapeCollection इंटरफ़ेस और ISmartArtNode.getShapes() मेथड जोड़ा गया**
Aspose.Slides.SmartArt.SmartArtShapeCollection क्लास (और इसका इंटरफ़ेस Aspose.Slides.SmartArt.ISmartArtShapeCollection) SmartArt डायग्राम के भीतर व्यक्तिगत शैप्स तक पहुंच प्रदान करता है। कलेक्शन में SmartArtNode से जुड़े शैप्स शामिल होते हैं। प्रॉपर्टी SmartArtNode.Shapes नोड से जुड़े सभी शैप्स का संग्रह लौटाती है।

{{% alert color="info" %}} 

SmartArtLayoutType के आधार पर एक SmartArtShape कई नोड्स द्वारा साझा किया जा सकता है।

{{% /alert %}} 

``` java
import com.aspose.slides.*;
import java.awt.Color;


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