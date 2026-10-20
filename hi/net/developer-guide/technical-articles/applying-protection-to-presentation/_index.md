---
title: .NET में Shape Locks के साथ प्रस्तुति संपादन प्रतिबंधित करें
linktitle: प्रस्तुति संपादन प्रतिबंधित करें
type: docs
weight: 70
url: /hi/net/applying-protection-to-presentation/
keywords:
- संपादन को रोकें
- संपादन से सुरक्षा
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलने को लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for .NET का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करना इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद कर सकता है।

यह लेख समझाता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने की सुविधा देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड ऑटोषेप्स, तालिकाएँ, OLE ऑब्जेक्ट्स, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्वों जैसे घटकों से बनी होती है जो प्रस्तुति बनाने के लिए उपयोग किए जाते हैं। Aspose.Slides for .NET में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा प्रदर्शित किया जाता है जो [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत लेता है।

विभिन्न आकार प्रकार विभिन्न लॉकिंग विकल्प प्रदान करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए आधार इंटरफ़ेस है। Aspose.Slides for .NET निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) ऑटोषेप्स को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) समूह आकारों को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) चित्र फ्रेम को लॉक करता है।  

[प्रस्तुति](https://reference.aspose.com/slides/net/aspose.slides/presentation/) पर लॉक लागू करने के लिए उसकी स्लाइड्स के माध्यम से क्रमबद्ध करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

आकार लॉक चयन, स्थानांतरित करना और आकार बदलने जैसे कार्यों को प्रतिबंधित करते हैं। वे पूरी प्रस्तुति को अपरिवर्तनीय नहीं बनाते।

### **PPTX शेप्स पर सुरक्षा लागू करें**

Aspose.Slides for .NET स्लाइड पर आकारों के साथ कार्य करने के लिए [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण ऑटोषेप्स के लिए [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) और [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) को `true` सेट करता है, तथा समूह आकार, कनेक्टर और चित्र फ्रेम के लिए समान लॉक लागू करता है। कनेक्टर [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) का उपयोग गति के लिए करते हैं; समूह भी समूह बनाने को प्रतिबंधित करने के लिए [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के साथ एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर की बाल आकारों को पार नहीं करता।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **सुरक्षा हटाएँ**

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्न उदाहरण एक प्रस्तुति को लोड करता है जिसमें आकार लॉक होते हैं और [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) और [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) के माध्यम से चयन, गति और आकार बदलने प्रतिबंध को साफ़ करता है। यह [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) को भी साफ़ करता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **निष्कर्ष**

Aspose.Slides for .NET आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने या स्लाइड्स के बीच समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक का चयन करें, और उन प्रतिबंधों को हटाने की आवश्यकता होने पर उनके मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं समान प्रस्तुति में shape locks और password protection को मिलाकर उपयोग कर सकता हूँ?**

हाँ। Shape locks विशिष्ट संपादन संचालन को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/net/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकती है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशेष स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। केवल चयनित स्लाइड्स के आकारों पर लॉक लागू करें। यह अन्य स्लाइड्स पर लॉक सेटिंग को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) संग्रह के माध्यम से क्रमबद्ध करें और प्रत्येक बाल आकार पर उपयुक्त लॉक लागू करें। इसे किसी भी अंतःस्थापित समूह के लिए दोहराएँ। ऊपर के उदाहरण केवल स्लाइड के आकार संग्रह को प्रक्रिया करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक नहीं सेट करते।